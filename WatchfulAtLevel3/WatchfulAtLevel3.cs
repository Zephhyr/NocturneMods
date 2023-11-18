using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using static Il2Cpp.SteamDlcFileUtil;

[assembly: MelonInfo(typeof(WatchfulAtLevel3.WatchfulAtLevel3), "Watchful At Level3", "1.0.0", "Zephhyr")]
[assembly: MelonGame("", "smt3hd")]

namespace WatchfulAtLevel3
{
    internal class WatchfulAtLevel3 : MelonMod
    {
        public override void OnInitializeMelon()
        {
            //tblHearts.fclHeartsTbl[1].Skill[0].ID = 354;

            // Skills
            tblSkill.fclSkillTbl[191].Event[0].Param = 262; // E & I
            tblSkill.fclSkillTbl[191].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[191].Event[0].Type = 1;
            tblSkill.fclSkillTbl[191].Event[1].Param = 414; // Intimidate
            tblSkill.fclSkillTbl[191].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[191].Event[1].Type = 1;
            tblSkill.fclSkillTbl[191].Event[2].Param = 265; // Provoke
            tblSkill.fclSkillTbl[191].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[191].Event[2].Type = 1;
            tblSkill.fclSkillTbl[191].Event[3].Param = 274; // Holy Star
            tblSkill.fclSkillTbl[191].Event[3].TargetLevel = 0;
            tblSkill.fclSkillTbl[191].Event[3].Type = 1;
            tblSkill.fclSkillTbl[191].Event[4].Param = 268; // Whirlwind
            tblSkill.fclSkillTbl[191].Event[4].TargetLevel = 17;
            tblSkill.fclSkillTbl[191].Event[4].Type = 1;
            tblSkill.fclSkillTbl[191].Event[5].Param = 264; // Twosome Time
            tblSkill.fclSkillTbl[191].Event[5].TargetLevel = 23;
            tblSkill.fclSkillTbl[191].Event[5].Type = 1;
            tblSkill.fclSkillTbl[191].Event[6].Param = 263; // Rebellion Gaming
            tblSkill.fclSkillTbl[191].Event[6].TargetLevel = 40;
            tblSkill.fclSkillTbl[191].Event[6].Type = 1;
            tblSkill.fclSkillTbl[191].Event[7].Param = 360; // Never Yield
            tblSkill.fclSkillTbl[191].Event[7].TargetLevel = 50;
            tblSkill.fclSkillTbl[191].Event[7].Type = 1;
            tblSkill.fclSkillTbl[191].Event[8].Param = 267; // Roundtrip
            tblSkill.fclSkillTbl[191].Event[8].TargetLevel = 60;
            tblSkill.fclSkillTbl[191].Event[8].Type = 1;
            tblSkill.fclSkillTbl[191].Event[9].Param = 266; // Stinger
            tblSkill.fclSkillTbl[191].Event[9].TargetLevel = 64;
            tblSkill.fclSkillTbl[191].Event[9].Type = 1;
            tblSkill.fclSkillTbl[191].Event[10].Param = 269; // Showtime
            tblSkill.fclSkillTbl[191].Event[10].TargetLevel = 72;
            tblSkill.fclSkillTbl[191].Event[10].Type = 1;
            tblSkill.fclSkillTbl[191].Event[11].Param = 361; // Son's Oath
            tblSkill.fclSkillTbl[191].Event[11].TargetLevel = 80;
            tblSkill.fclSkillTbl[191].Event[11].Type = 1;

            tblSkill.fclSkillTbl[192].Event[0].Param = 262; // E & I
            tblSkill.fclSkillTbl[192].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[192].Event[0].Type = 1;
            tblSkill.fclSkillTbl[192].Event[1].Param = 410; // Intimidate
            tblSkill.fclSkillTbl[192].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[192].Event[1].Type = 1;
            tblSkill.fclSkillTbl[192].Event[2].Param = 265; // Provoke
            tblSkill.fclSkillTbl[192].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[192].Event[2].Type = 1;
            tblSkill.fclSkillTbl[192].Event[3].Param = 274; // Holy Star
            tblSkill.fclSkillTbl[192].Event[3].TargetLevel = 0;
            tblSkill.fclSkillTbl[192].Event[3].Type = 1;
            tblSkill.fclSkillTbl[192].Event[4].Param = 268; // Whirlwind
            tblSkill.fclSkillTbl[192].Event[4].TargetLevel = 17;
            tblSkill.fclSkillTbl[192].Event[4].Type = 1;
            tblSkill.fclSkillTbl[192].Event[5].Param = 264; // Twosome Time
            tblSkill.fclSkillTbl[192].Event[5].TargetLevel = 23;
            tblSkill.fclSkillTbl[192].Event[5].Type = 1;
            tblSkill.fclSkillTbl[192].Event[6].Param = 263; // Rebellion Gaming
            tblSkill.fclSkillTbl[192].Event[6].TargetLevel = 40;
            tblSkill.fclSkillTbl[192].Event[6].Type = 1;
            tblSkill.fclSkillTbl[192].Event[7].Param = 360; // Never Yield
            tblSkill.fclSkillTbl[192].Event[7].TargetLevel = 50;
            tblSkill.fclSkillTbl[192].Event[7].Type = 1;
            tblSkill.fclSkillTbl[192].Event[8].Param = 267; // Roundtrip
            tblSkill.fclSkillTbl[192].Event[8].TargetLevel = 60;
            tblSkill.fclSkillTbl[192].Event[8].Type = 1;
            tblSkill.fclSkillTbl[192].Event[9].Param = 266; // Stinger
            tblSkill.fclSkillTbl[192].Event[9].TargetLevel = 64;
            tblSkill.fclSkillTbl[192].Event[9].Type = 1;
            tblSkill.fclSkillTbl[192].Event[10].Param = 269; // Showtime
            tblSkill.fclSkillTbl[192].Event[10].TargetLevel = 72;
            tblSkill.fclSkillTbl[192].Event[10].Type = 1;
            tblSkill.fclSkillTbl[192].Event[11].Param = 361; // Son's Oath
            tblSkill.fclSkillTbl[192].Event[11].TargetLevel = 80;
            tblSkill.fclSkillTbl[192].Event[11].Type = 1;

            // Stats
            datDevilFormat.tbl[192].level = 1;
            datDevilFormat.tbl[192].param[0] = 8;
            datDevilFormat.tbl[192].param[2] = 6;
            datDevilFormat.tbl[192].param[3] = 6;
            datDevilFormat.tbl[192].param[4] = 8;
            datDevilFormat.tbl[192].param[5] = 3;
            datDevilFormat.tbl[192].hp = 42;
            datDevilFormat.tbl[192].maxhp = 42;
            datDevilFormat.tbl[192].mp = 21;
            datDevilFormat.tbl[192].maxmp = 21;
        }

        [HarmonyPatch(typeof(datSkillName), nameof(datSkillName.Get))]
        private class SkillNamesPatch
        {
            public static bool Prefix(ref int id, ref string __result)
            {
                switch (id)
                {
                    // Vanilla Skills
                    case 263: __result = "Rebellion Gaming"; return false;
                    default: return true;
                }
            }

            public static void Postfix(ref int id, ref string __result)
            {
                if (__result == "Rebellion")
                    __result =  "Rebellion Gaming";
                else if (__result == "Boogie-Woogie")
                    __result =  "Jackpot";
                else if (__result == "Enter Yoshitsune")
                    __result =  "Upper Slash";
                else if (__result == "Mishaguji Raiden")
                    __result =  "Round Robin";
                else if (__result == "Hitokoto Storm")
                    __result =  "Approching Storm";
                else if (__result == "Raptor Guardian")
                    __result =  "Griffon Vigor";
                else if (__result == "Mokoi Boomerang")
                    __result = "Bayonet";
                else if (__result == "Tekisatsu")
                    __result =  "Stinger";
                else if (__result == "Jiraiya Dance")
                    __result =  "Nightmare Combo";
                else if (__result == "Raidou the Eternal")
                    __result =  "More Power";
            }
        }

        [HarmonyPatch(typeof(datDevilName), nameof(datDevilName.Get))]
        private class DevilNamesPatch
        {
            public static void Postfix(ref int id, ref string __result)
            {
                if (__result == "Raidou")
                    __result = "Vergil";
            }
        }

        [HarmonyPatch(typeof(datRaceName), nameof(datRaceName.Get))]
        private class DevilRacePatch
        {
            public static void Postfix(ref int id, ref string __result)
            {
                if (id == 40)
                    __result = "Demi-Fiend";
            }
        }
    }
}