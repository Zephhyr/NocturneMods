using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2Cppnewbattle_H;
using Il2Cppeffect_H;
using UnityEngine;
using static Il2Cpp.SteamDlcFileUtil;
using Newtonsoft.Json;
using static UnityEngine.UI.CanvasScaler;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        private static System.Random random = new System.Random();
        private static Dictionary<int, ActionTracker> actionTrackers = new Dictionary<int, ActionTracker>();

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
                short activeUnit = data.activeunit;

                if (activeUnit >= 4)
                {
                    var enemyUnits = data.enemyunit.Where(x => x.id != 0);
                    foreach (var unit in enemyUnits)
                    {
                        if (!actionTrackers.ContainsKey(unit.id))
                            actionTrackers.Add(unit.id, new ActionTracker());

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
                actionProcessData = a;

                actionTrackers[a.work.id].currentBattleActionCount++;
                actionTrackers[a.work.id].currentTurnActionCount++;
                MelonLogger.Msg("currentBattleTurnCount:" + actionTrackers[a.work.id].currentBattleTurnCount);
                MelonLogger.Msg("currentBattleActionCount:" + actionTrackers[a.work.id].currentBattleActionCount);
                MelonLogger.Msg("currentTurnActionCount:" + actionTrackers[a.work.id].currentTurnActionCount);
                MelonLogger.Msg("-Action Starts-");
                switch (a.work.id)
                {
                    case 11: AmeNoUzumeAI(ref a, ref code, ref n); break;
                    case 33: ShiisaaAI(ref a, ref code, ref n); break;
                    case 256: BossForneusAI(ref a, ref code, ref n); break;
                    case 294: BigSpecterAI(ref a, ref code, ref n); break;
                    case 295: BigSpecterAI(ref a, ref code, ref n); break;
                    case 296: BigSpecterAI(ref a, ref code, ref n); break;
                    case 317: BossTrollAI(ref a, ref code, ref n); break;
                    case 349: BossMatadorAI(ref a, ref code, ref n); break;
                    default: break;
                }
                MelonLogger.Msg("skill: " + a.work.nowindex);
            }
        }

        private static void AmeNoUzumeAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentTurnActionCount <= 1 &&
                nbMainProcess.nbGetMainProcessData().enemypcnt == 1)
            {
                if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(229))
                {
                    UseSummonSkill(ref a, 229, 89);
                }
                else
                    UseSkill(ref a, 219);
            }
            else
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 22); break;
                    case 2: UseSkill(ref a, 22); break;
                    case 3: UseSkill(ref a, 28); break;
                    case 4: UseSkill(ref a, 28); break;
                }
            }
        }

        private static void ShiisaaAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleActionCount <= 2)
                UseSkill(ref a, 203);
            else
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 121); break;
                    case 2: UseSkill(ref a, 123); break;
                    case 3: UseSkill(ref a, 182); break;
                    case 4: UseSkill(ref a, 182); break;
                }
            }
        }

        private static void BossForneusAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            MelonLogger.Msg("Forneus HP%: " + currentHpPercent);
            MelonLogger.Msg("Forneus HP: " + a.work.hp);

            if (currentHpPercent <= 60 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            else if (currentHpPercent <= 20 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;

            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(422))
            {
                UseSkill(ref a, 422); return;
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
            {
                UseSkill(ref a, 7);
                SetTargetingRule(ref code, ref n, 6, n);
                return;
            }
            
            if (actionTrackers[a.work.id].phase == 1)
            //if (currentHpPercent > 60)
            {
                int randomValue = random.Next(2);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 7); break;
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            //else if (currentHpPercent > 20)
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
                //if (actionTrackers[a.work.id].currentTurnActionCount == 1 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
                //    UseSkill(ref a, 219);
                if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(244))
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

        private static void BigSpecterAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(422))
                UseSkill(ref a, 422);
        }

        private static void BossTrollAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (BossCurrentHpPercent(ref a) <= 25 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;

            if (actionTrackers[a.work.id].phase == 2 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
            {
                UseSkill(ref a, 219); return;
            }
            else
            {
                int randomValue = random.Next(4);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 98); break;
                    case 2: UseSkill(ref a, 181); break;
                    case 3: UseSkill(ref a, 427); break;
                }
            }
        }

        private static void BossMatadorAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            MelonLogger.Msg("Matador HP%: " + currentHpPercent);
            MelonLogger.Msg("Matador HP: " + a.work.hp);

            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(422))
                UseSkill(ref a, 422);
            else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(276))
                UseSkill(ref a, 276);
            else if (a.work.nowindex == 22)
                UseSkill(ref a, 443);
        }

        //------------------------------------------------------------

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

        private static void UseSummonSkill(ref nbActionProcessData_t a, ushort skillId, ushort devilId)
        {
            a.aisummonid = devilId;
            if (!actionTrackers.ContainsKey(devilId))
                actionTrackers.Add(devilId, new ActionTracker());
            
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
    }

    internal class ActionTracker
    {
        public short currentBattleTurnCount;
        public short currentBattleActionCount;
        public short currentTurnActionCount;
        public short extraTurns;
        public short phase;
        public List<ushort> skillsUsedThisBattle;
        public List<ushort> skillsUsedThisTurn;
        

        public ActionTracker()
        {
            this.currentBattleTurnCount = 0;
            this.currentBattleActionCount = 0;
            this.currentTurnActionCount = 0;
            this.extraTurns = 0;
            this.phase = 1;
            this.skillsUsedThisBattle = new List<ushort>();
            this.skillsUsedThisTurn = new List<ushort>();
        }
    }
}