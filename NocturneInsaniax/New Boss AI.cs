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
                    case 28: TakeMinakataAI(ref a, ref code, ref n); break;
                    case 33: ShiisaaAI(ref a, ref code, ref n); break;
                    case 35: UnicornAI(ref a, ref code, ref n); break;
                    case 124: NKENueAI(ref a, ref code, ref n); break;
                    case 256: BossForneusAI(ref a, ref code, ref n); break;
                    case 294: BigSpecterAI(ref a, ref code, ref n); break;
                    case 295: BigSpecterAI(ref a, ref code, ref n); break;
                    case 296: BigSpecterAI(ref a, ref code, ref n); break;
                    case 300: BossOrthrusAI(ref a, ref code, ref n); break;
                    case 301: BossYaksiniAI(ref a, ref code, ref n); break;
                    case 302: BossThor1AI(ref a, ref code, ref n); break;
                    case 317: BossTrollAI(ref a, ref code, ref n); break;
                    case 339: BossDanteRaidou1AI(ref a, ref code, ref n); break;
                    case 349: BossMatadorAI(ref a, ref code, ref n); break;
                    case 351: BossDaisoujouAI(ref a, ref code, ref n); break;
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

        private static void TakeMinakataAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
            {
                UseSkill(ref a, 220);
            }
            else if (AllyPartyBuffed(1))
            {
                UseSkill(ref a, 57);
            }
            else if (BossFocused(ref a))
            {
                int randomValue = random.Next(4);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 16); break;
                    case 2: UseSkill(ref a, 14); break;
                    case 3: UseSkill(ref a, 427); break;
                }
            }
            else
            {
                int randomValue = random.Next(4);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 16); break;
                    case 1: UseSkill(ref a, 14); break;
                    case 2: UseSkill(ref a, 224); break;
                    case 3: UseSkill(ref a, 427); break;
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

        private static void UnicornAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleActionCount <= 1)
                UseSkill(ref a, 66);
            else if (nbMainProcess.nbGetMainProcessData().enemypcnt <= 2)
                UseSummonSkill(ref a, 226, 125);
            else
            {
                if (nbMainProcess.nbGetMainProcessData().enemyunit.Where(x => x.hp < x.maxhp).Any())
                {
                    int randomValue = random.Next(5);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 37); break;
                        case 1: UseSkill(ref a, 39); break;
                        case 2: UseSkill(ref a, 10); break;
                        case 3: UseSkill(ref a, 10); break;
                        case 4: UseSkill(ref a, 121); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 10); break;
                        case 2: UseSkill(ref a, 121); break;
                    }
                }
            }
        }

        private static void NKENueAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (a.work.nowindex == 227 && a.data.encno == 1270)
                UseNormalAttack(ref a);
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

            if (actionTrackers[a.work.id].extraTurns < 1)
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
            {
                int randomValue = random.Next(2);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 7); break;
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
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

        private static void BossOrthrusAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (currentHpPercent <= 60 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            else if (currentHpPercent <= 20 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;

            if (actionTrackers[a.work.id].phase == 1)
            {
                int randomValue = random.Next(2);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 125); break;
                    case 1: UseSkill(ref a, 176); break;
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                {
                    UseSkill(ref a, 422); return;
                }
                else
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 125); break;
                        case 1: UseSkill(ref a, 2); break;
                        case 2: UseSkill(ref a, 5); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 3)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                {
                    UseSkill(ref a, 422); return;
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(203))
                {
                    UseSkill(ref a, 203); return;
                }
                else
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 430); break;
                        case 1: UseSkill(ref a, 3); break;
                        case 2: UseSkill(ref a, 177); break;
                    }
                }
            }
        }

        private static void BossYaksiniAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (currentHpPercent <= 65 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            else if (currentHpPercent <= 30 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;

            if (actionTrackers[a.work.id].phase == 1)
            {
                int randomValue = random.Next(3);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 461); break;
                    case 2: UseSkill(ref a, 20); break;
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                {
                    UseSkill(ref a, 422); return;
                }
                else
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 109); break;
                        case 1: UseSkill(ref a, 23); break;
                        case 2: UseSkill(ref a, 211); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 3)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                {
                    UseSkill(ref a, 422); return;
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(63))
                {
                    UseSkill(ref a, 63); return;
                }
                else
                {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 109); break;
                        case 1: UseSkill(ref a, 185); break;
                        case 2: UseSkill(ref a, 21); break;
                        case 3: UseSkill(ref a, 211); break;
                    }
                }
            }
        }

        private static void BossThor1AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (currentHpPercent <= 50 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            else if (currentHpPercent <= 20 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;

            if (actionTrackers[a.work.id].phase == 1)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                {
                    UseSkill(ref a, 422); return;
                }
                else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
                {
                    UseSkill(ref a, 16); return;
                }
                else {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 428); break;
                        case 2: UseSkill(ref a, 16); break;
                        case 3: UseSkill(ref a, 14); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                if (actionTrackers[a.work.id].extraTurns < 2)
                {
                    UseSkill(ref a, 422); return;
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(457) || a.work.badstatus != 0)
                {
                    UseSkill(ref a, 457); return;
                }
                else
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 428); break;
                        case 1: UseSkill(ref a, 17); break;
                        case 2: UseSkill(ref a, 469); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 3)
            {
                if (actionTrackers[a.work.id].extraTurns < 2)
                {
                    UseSkill(ref a, 422); return;
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(457) || a.work.badstatus != 0)
                {
                    UseSkill(ref a, 457); return;
                }
                else if (EnemyPartyDebuffed(2) && random.Next(4) == 0)
                {
                    UseSkill(ref a, 77);
                }
                else if (AllyPartyBuffed(2) && random.Next(4) == 0)
                {
                    UseSkill(ref a, 57);
                }
                else
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 17); break;
                        case 2: UseSkill(ref a, 469); break;
                    }
                }
            }
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

        private static void BossDanteRaidou1AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 422);
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
            {
                UseNormalAttack(ref a);
            }
        }

        private static void BossMatadorAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            MelonLogger.Msg("Matador HP%: " + currentHpPercent);
            MelonLogger.Msg("Matador HP: " + a.work.hp);

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 422);
            else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(276))
                UseSkill(ref a, 276);
            else if (a.work.nowindex == 22)
                UseSkill(ref a, 443);
        }

        private static void BossDaisoujouAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            MelonLogger.Msg("Daisoujou HP%: " + currentHpPercent);
            MelonLogger.Msg("Daisoujou HP: " + a.work.hp);

            if (currentHpPercent <= 80 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            else if (currentHpPercent <= 50 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;

            if (actionTrackers[a.work.id].phase == 1)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                    UseSkill(ref a, 422);
                else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
                {
                    UseSkill(ref a, 279);
                }
                else
                {
                    int randomValue = random.Next(2);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 279); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                if (!EnemyPartyBuffed(3, 5) && random.Next(2) == 0)
                {
                    UseSkill(ref a, 67);
                }
                else if (AllyPartyBuffed(1) && random.Next(3) == 0)
                {
                    UseSkill(ref a, 57);
                }
                else
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 279); break;
                        case 1: UseSkill(ref a, 30); break;
                        case 2: UseSkill(ref a, 34); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 3)
            {
                if (actionTrackers[a.work.id].extraTurns < 2)
                {
                    UseSkill(ref a, 422); return;
                }
                else if (!EnemyPartyBuffed(3, 5) && random.Next(3) == 0)
                {
                    UseSkill(ref a, 67);
                }
                else if (AllyPartyBuffed(1) && random.Next(3) == 0)
                {
                    UseSkill(ref a, 57);
                }
                else
                {
                    if (BossConcentrated(ref a))
                    {
                        int randomValue = random.Next(3);
                        switch (randomValue)
                        {
                            case 1: UseSkill(ref a, 278); break;
                            case 2: UseSkill(ref a, 30); break;
                            case 3: UseSkill(ref a, 34); break;
                        }
                    }
                    else
                    {
                        int randomValue = random.Next(6);
                        switch (randomValue)
                        {
                            case 0: UseSkill(ref a, 279); break;
                            case 1: UseSkill(ref a, 278); break;
                            case 2: UseSkill(ref a, 30); break;
                            case 3: UseSkill(ref a, 34); break;
                            case 4: UseSkill(ref a, 424); break;
                            case 5: UseSkill(ref a, 424); break;
                        }
                    }
                }
            }
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

        private static bool BossFocused(ref nbActionProcessData_t a)
        {
            return (a.party.count[15] != 0);
        }

        private static bool BossConcentrated(ref nbActionProcessData_t a)
        {
            return (a.party.count[19] != 0);
        }

        private static bool AllyPartyBuffed(ushort threshold)
        {
            var allyParty = nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3);
            foreach (var unit in allyParty)
            {
                for (int i = 4; i <= 8; i++)
                {
                    if (unit.count[i] >= threshold)
                        return true;
                }
            }
            return false;
        }

        private static bool AllyPartyDebuffed(ushort threshold)
        {
            var allyParty = nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3 && dds3GlobalWork.DDS3_GBWK.unitwork[x.partyindex].hp != 0);
            foreach (var unit in allyParty)
            {
                for (int i = 4; i <= 8; i++)
                {
                    if (unit.count[i] <= threshold * -1)
                        return true;
                }
            }
            return false;
        }

        private static bool EnemyPartyBuffed(ushort threshold)
        {
            var allyParty = nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex >= 4 && dds3GlobalWork.DDS3_GBWK.unitwork[x.partyindex].hp != 0);
            foreach (var unit in allyParty)
            {
                for (int i = 4; i <= 8; i++)
                {
                    if (unit.count[i] >= threshold)
                        return true;
                }
            }
            return false;
        }

        private static bool EnemyPartyBuffed(ushort threshold, int type)
        {
            var allyParty = nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex >= 4 && dds3GlobalWork.DDS3_GBWK.unitwork[x.partyindex].hp != 0);
            foreach (var unit in allyParty)
            {
                if (unit.count[type] >= threshold)
                    return true;
            }
            return false;
        }

        private static bool EnemyPartyDebuffed(ushort threshold)
        {
            var allyParty = nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex >= 4 && dds3GlobalWork.DDS3_GBWK.unitwork[x.partyindex].hp != 0);
            foreach (var unit in allyParty)
            {
                for (int i = 4; i <= 8; i++)
                {
                    if (unit.count[i] <= threshold * -1)
                        return true;
                }
            }
            return false;
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