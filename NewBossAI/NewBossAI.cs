using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2Cppnewbattle_H;
using Il2Cppeffect_H;
using UnityEngine;

[assembly: MelonInfo(typeof(NewBossAI.NewBossAI), "New Boss AI", "1.0.0", "Zephhyr, Matthiew Purple")]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace NewBossAI
{
    internal partial class NewBossAI : MelonMod
    {
        private static System.Random random = new System.Random();
        private static Dictionary<int, ActionTracker> actionTrackers = new Dictionary<int, ActionTracker>();

        public override void OnInitializeMelon()
        {
            BossForneus();
            ApplySkillChanges();
            ApplyItemChanges();
        }

        [HarmonyPatch(typeof(nbInit), nameof(nbInit.nbCallNewBattle))]
        private class InitBattlePatch
        {
            public static void Postfix()
            {
                actionTrackers.Clear();
                MelonLogger.Msg("-Battle Starts-");
            }
        }

        [HarmonyPatch(typeof(nbMainProcess), nameof(nbMainProcess.nbSetPressMaePhase))]
        private class MainPhasePatch
        {
            public static void Postfix(ref nbMainProcessData_t data)
            {
                //var mainProcessData = nbMainProcess.nbGetMainProcessData();
                var mainProcessData = data;
                short activeUnit = mainProcessData.activeunit;

                if (activeUnit >= 4)
                {
                    var enemyUnits = mainProcessData.enemyunit.Where(x => x.id != 0);
                    foreach (var unit in enemyUnits)
                    {
                        if (!actionTrackers.ContainsKey(unit.id))
                        {
                            actionTrackers.Add(unit.id, new ActionTracker());
                        }

                        nbMainProcess.nbGetMainProcessData().press4_p += actionTrackers[unit.id].extraTurns;
                        nbMainProcess.nbGetMainProcessData().press4_ten += actionTrackers[unit.id].extraTurns;
                    }
                    
                    foreach (var actionCounter in actionTrackers.Values)
                    {
                        actionCounter.currentBattleTurnCount++;
                        actionCounter.currentTurnActionCount = 0;
                        actionCounter.skillsUsedThisTurn.Clear();
                    }

                    MelonLogger.Msg("-Enemy Turn Starts-");
                }
            }
        }

        [HarmonyPatch(typeof(nbAi), nameof(nbAi.nbSetAiTarget))]
        private class AiPatch
        {
            public static void Prefix(ref nbActionProcessData_t a, ref int code, ref int n)
            {
                actionTrackers[a.work.id].currentBattleActionCount++;
                actionTrackers[a.work.id].currentTurnActionCount++;
                MelonLogger.Msg("currentBattleTurnCount:" + actionTrackers[a.work.id].currentBattleTurnCount);
                MelonLogger.Msg("currentBattleActionCount:" + actionTrackers[a.work.id].currentBattleActionCount);
                MelonLogger.Msg("currentTurnActionCount:" + actionTrackers[a.work.id].currentTurnActionCount);
                MelonLogger.Msg("-Action Starts-");
                switch (a.work.id)
                {
                    case 256: RunNewForneusAI(ref a, ref code, ref n); break;
                    default: break;
                }
            }
        }

        private static void RunNewForneusAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            MelonLogger.Msg("Forneus HP%: " + currentHpPercent);
            MelonLogger.Msg("Forneus HP: " + a.work.hp);
            
            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(88))
            {
                UseSkill(ref a, 88); return;
            }

            if (currentHpPercent > 60)
            {
                int randomValue = random.Next(2);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 7); break;
                }
            }
            else if (currentHpPercent > 20)
            {
                if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(10))
                    UseSkill(ref a, 10);
                else
                {
                    int randomValue = random.Next(2);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 7); break;
                    }
                }
            }
            else
            {
                if (actionTrackers[a.work.id].currentTurnActionCount == 1 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
                    UseSkill(ref a, 219);
                else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(244))
                    UseSkill(ref a, 244);
                else
                {
                    int randomValue = random.Next(2);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 7); break;
                    }
                }
            }
        }

        private static void UseNormalAttack(ref nbActionProcessData_t a)
        {
            a.work.nowcommand = 0;
            a.work.nowindex = 0;
        }

        private static void UseSkill(ref nbActionProcessData_t a, ushort skillId)
        {
            a.work.nowcommand = 1;
            a.work.nowindex = skillId;

            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(skillId)) actionTrackers[a.work.id].skillsUsedThisBattle.Add(skillId);
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(skillId)) actionTrackers[a.work.id].skillsUsedThisTurn.Add(skillId);
        }

        private static void SetTargetingRule(ref int code, ref int n, int newCode, int newN)
        {
            // -Rules-
            // 0  - Default AI
            // 1  - Target lowest HP
            // 2  - Target affected by status
            // 3  - Target specific ID
            // 4  - Target weak-to-light
            // 5  - Target weak-to-dark
            // 6  - Target Demi-Fiend
            // 7  - ?
            // 8  - Target Randomly
            // 9  - ?
            // 10 - Target lowest level
            code = newCode;
            n = newN;
        }

        private static ushort BossCurrentHpPercent(ref nbActionProcessData_t a)
        {
            ushort maxhp = a.work.maxhp;
            ushort currenthp = a.work.hp;
            return (ushort) ((currenthp*100)/maxhp);
        }

        //------------------------------------------------------------

        private static void BossForneus()
        {
            datDevilFormat.tbl[256].maxhp = 800;
            datDevilFormat.tbl[256].hp = 800;
            datDevilAI.divTbls[2][0].ailevel = 0;
        }
    }

    internal class ActionTracker
    {
        public ushort currentBattleTurnCount;
        public ushort currentBattleActionCount;
        public ushort currentTurnActionCount;
        public short extraTurns;
        public List<ushort> skillsUsedThisBattle;
        public List<ushort> skillsUsedThisTurn;
        

        public ActionTracker()
        {
            this.currentBattleTurnCount = 0;
            this.currentBattleActionCount = 0;
            this.currentTurnActionCount = 0;
            this.extraTurns = 0;
            this.skillsUsedThisBattle = new List<ushort>();
            this.skillsUsedThisTurn = new List<ushort>();
        }
    }
}