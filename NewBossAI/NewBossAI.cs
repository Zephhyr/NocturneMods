using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2Cppnewbattle_H;
using Il2Cppeffect_H;
using MelonLoader.CoreClrUtils;
using static UnityEngine.ScriptingUtility;
using System.Diagnostics;

[assembly: MelonInfo(typeof(NewBossAI.NewBossAI), "New Boss AI", "1.0.0", "Zephhyr")]
[assembly: MelonGame("", "smt3hd")]

namespace NewBossAI
{
    internal class NewBossAI : MelonMod
    {
        private static Random random = new Random();
        private static Dictionary<int, ActionTracker> actionTrackers = new Dictionary<int, ActionTracker>();
        private static Dictionary<int, short> extraTurns = new Dictionary<int, short>();

        public override void OnInitializeMelon()
        {
            BossForneus();
            NewBeastEye();
        }

        [HarmonyPatch(typeof(datSkillName), nameof(datSkillName.Get))]
        private class SkillNamesPatch
        {
            public static void Postfix(ref int id, ref string __result)
            {
                switch (id)
                {
                    case 81: __result = "Beast Eye"; return;
                    case 219: __result = "Rage"; return;
                    case 220: __result = "Psycho Rage"; return;
                }
            }
        }
        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetAddPressPacket))]
        private class PressPatch1
        {
            public static void Postfix(ref nbActionProcessData_t a, ref int nskill)
            {
                if (a.newaddpresstype == 15 && nskill == 81)
                {
                    a.newaddpresstype = 18;
                    if (!extraTurns.ContainsKey(a.work.id))
                        extraTurns.Add(a.work.id, 1);
                    else
                        extraTurns[a.work.id] += 1;
                }
            }
        }
        [HarmonyPatch(typeof(nbMakePacket), nameof(nbMakePacket.nbMakeNewPressPacket))]
        private class PressPatch2
        {
            public static void Postfix(ref int startframe, ref int uniqueid, ref int ptype, ref nbFormation_t form)
            {
                if (ptype == 18)
                {
                    nbMakePacket.nbAddNewPressPacket(startframe, uniqueid, 1, 1);
                    nbHelpProcess.nbDispText("Turn Count Increased!", string.Empty, 2, 45, 2315190144, false);
                }
            }
        }

        //------------------------------------------------------------

        [HarmonyPatch(typeof(nbInit), nameof(nbInit.nbCallNewBattle))]
        private class InitBattlePatch
        {
            public static void Postfix()
            {
                actionTrackers.Clear();
                extraTurns.Clear();
                MelonLogger.Msg("-Battle Starts-");
            }
        }

        [HarmonyPatch(typeof(nbMainProcess), nameof(nbMainProcess.nbSetPressMaePhase))]
        private class MainPhasePatch
        {
            public static void Postfix()
            {
                var mainProcessData = nbMainProcess.nbGetMainProcessData();
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

                        if (extraTurns.ContainsKey(unit.id))
                        {
                            nbMainProcess.nbGetMainProcessData().press4_p += extraTurns[unit.id];
                            nbMainProcess.nbGetMainProcessData().press4_ten += extraTurns[unit.id];
                        }
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

                if (a.work.id >= 256)
                    RunNewBossAI(ref a, ref code, ref n);
            }
        }

        private static void RunNewBossAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            switch (a.work.id)
            {
                case 256: RunNewForneusAI(ref a, ref code, ref n); break;
                default: break;
            }
        }

        private static void RunNewForneusAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            MelonLogger.Msg("currentBattleTurnCount:" + actionTrackers[a.work.id].currentBattleTurnCount);
            MelonLogger.Msg("currentBattleActionCount:" + actionTrackers[a.work.id].currentBattleActionCount);
            MelonLogger.Msg("currentTurnActionCount:" + actionTrackers[a.work.id].currentTurnActionCount);
            MelonLogger.Msg("-Action Starts-");
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            MelonLogger.Msg("Forneus HP%: " + currentHpPercent);
            MelonLogger.Msg("Forneus HP: " + a.work.hp);
            
            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(81))
            {
                UseSkill(ref a, 81); return;
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
            datDevilAI.divTbls[2][0].ailevel = 1;
        }

        private static void OverWriteSkillEffect(ushort targetId, ushort originId)
        {
            datNormalSkillVisual.tbl[targetId] = datNormalSkillVisual.tbl[originId];
            nbActionProcess.sobedtbl[targetId] = nbActionProcess.sobedtbl[originId];
            nbCamera_SkillPtrTable.tbl[targetId] = nbCamera_SkillPtrTable.tbl[originId];
        }

        private static void NewBeastEye()
        {
            datSkill.tbl[81].keisyoform = 512;
            datSkill.tbl[81].skillattr = 5;
            datNormalSkill.tbl[81].hojotype = 4096;
            datNormalSkill.tbl[81].hojopoint = 2;
            datNormalSkill.tbl[81].hpbase = 0;
            datNormalSkill.tbl[81].hpn = 50;
            datNormalSkill.tbl[81].hptype = 0;
            datNormalSkill.tbl[81].program = 13;
            datNormalSkill.tbl[81].use = 2;
            OverWriteSkillEffect(81, 219);
        }
    }

    internal class ActionTracker
    {
        public ushort currentBattleTurnCount;
        public ushort currentBattleActionCount;
        public ushort currentTurnActionCount;
        public List<ushort> skillsUsedThisBattle;
        public List<ushort> skillsUsedThisTurn;

        public ActionTracker()
        {
            this.currentBattleTurnCount = 0;
            this.currentBattleActionCount = 0;
            this.currentTurnActionCount = 0;
            this.skillsUsedThisBattle = new List<ushort>();
            this.skillsUsedThisTurn = new List<ushort>();
        }
    }
}