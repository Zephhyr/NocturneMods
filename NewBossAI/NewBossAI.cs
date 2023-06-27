using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2Cppnewbattle_H;
using Il2Cppeffect_H;

[assembly: MelonInfo(typeof(NewBossAI.NewBossAI), "New Boss AI", "1.0.0", "Zephhyr")]
[assembly: MelonGame("", "smt3hd")]

namespace NewBossAI
{
    internal class NewBossAI : MelonMod
    {
        private static Random random = new Random();
        private static ushort currentBattleTurnCount;
        private static ushort currentBattleActionCount;
        private static ushort currentTurnActionCount;
        private static List<ushort> skillsUsedThisBattle = new List<ushort>();
        private static List<ushort> skillsUsedThisTurn = new List<ushort>();

        public override void OnInitializeMelon()
        {
            datDevilFormat.tbl[256].maxhp = 600;
            datDevilFormat.tbl[256].hp = 600;
            
            datNormalSkill.tbl[81] = datNormalSkill.tbl[219];
            OverWriteSkillEffect(81, 219);
        }

        [HarmonyPatch(typeof(datSkillName), nameof(datSkillName.Get))]
        private class Patch
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

        //[HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetAction_READY))]
        //private class ActionProcessPatch1
        //{
        //    public static void Prefix(ref nbActionProcessData_t a)
        //    {
        //        MelonLogger.Msg("-SetAction_READY-");
        //    }
        //}
        //[HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetAction_SKILL))]
        //private class ActionProcessPatch
        //{
        //    public static void Prefix(ref nbActionProcessData_t a)
        //    {
        //        MelonLogger.Msg("-SetAction_SKILL-");
        //    }
        //}

        //------------------------------------------------------------

        [HarmonyPatch(typeof(nbInit), nameof(nbInit.nbCallNewBattle))]
        private class InitBattlePatch
        {
            public static void Postfix()
            {
                currentBattleTurnCount = 0;
                currentBattleActionCount = 0;
                skillsUsedThisBattle.Clear();
                MelonLogger.Msg("-Battle Starts-");
            }
        }

        [HarmonyPatch(typeof(nbMainProcess), nameof(nbMainProcess.nbSetPressMaePhase))]
        private class MainPhasePatch
        {
            public static void Postfix()
            {
                short activeUnit = nbMainProcess.nbGetMainProcessData().activeunit;

                if (activeUnit >= 4)
                {
                    currentBattleTurnCount++;
                    currentTurnActionCount = 0;
                    skillsUsedThisTurn.Clear();
                    MelonLogger.Msg("-Enemy Turn Starts-");
                }
            }
        }

        [HarmonyPatch(typeof(nbAi), nameof(nbAi.nbSetAiTarget))]
        private class AiPatch
        {
            public static void Prefix(ref nbActionProcessData_t a, ref int code, ref int n)
            {
                currentBattleActionCount++;
                currentTurnActionCount++;
                if (a.work.id >= 256)
                    RunNewBossAI(ref a);
            }
        }

        private static void RunNewBossAI(ref nbActionProcessData_t a)
        {
            switch (a.work.id)
            {
                case 256: RunNewForneusAI(ref a); break;
                default: break;
            }
        }

        private static void RunNewForneusAI(ref nbActionProcessData_t a)
        {
            MelonLogger.Msg("currentBattleTurnCount:" + currentBattleTurnCount);
            MelonLogger.Msg("currentBattleActionCount:" + currentBattleActionCount);
            MelonLogger.Msg("currentTurnActionCount:" + currentTurnActionCount);
            MelonLogger.Msg("-Action Starts-");
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            MelonLogger.Msg("Forneus HP%: " + currentHpPercent);
            MelonLogger.Msg("Forneus HP: " + a.work.hp);
            
            if (!skillsUsedThisBattle.Contains(81))
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
                if (currentTurnActionCount == 1 && !skillsUsedThisTurn.Contains(219))
                    UseSkill(ref a, 219);
                else if (!skillsUsedThisBattle.Contains(244))
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
            else
            {
                if (currentTurnActionCount == 1 && !skillsUsedThisTurn.Contains(219))
                    UseSkill(ref a, 219);
                else if (!skillsUsedThisBattle.Contains(272))
                    UseSkill(ref a, 272);
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
            if (!skillsUsedThisBattle.Contains(skillId)) skillsUsedThisBattle.Add(skillId);
            if (!skillsUsedThisTurn.Contains(skillId)) skillsUsedThisTurn.Add(skillId);
        }

        private static ushort BossCurrentHpPercent(ref nbActionProcessData_t a)
        {
            ushort maxhp = a.work.maxhp;
            ushort currenthp = a.work.hp;
            return (ushort) ((currenthp*100)/maxhp);
        }

        //------------------------------------------------------------

        private static void OverWriteSkillEffect(ushort targetId, ushort originId)
        {
            datNormalSkillVisual.tbl[targetId] = datNormalSkillVisual.tbl[originId];
            nbActionProcess.sobedtbl[targetId] = nbActionProcess.sobedtbl[originId];
            nbCamera_SkillPtrTable.tbl[targetId] = nbCamera_SkillPtrTable.tbl[originId];
        }
    }
}