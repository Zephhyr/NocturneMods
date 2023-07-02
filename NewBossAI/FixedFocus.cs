using HarmonyLib;
using Il2Cpp;
using Il2Cppnewbattle_H;
using Il2Cppnewdata_H;
using MelonLoader;
using MelonLoader.TinyJSON;

namespace NewBossAI
{
    internal partial class NewBossAI : MelonMod
    {
        public static short chargeNowcommand;
        public static ushort chargeNowindex;
        public static short focusState;
        public static short concentrateState;

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbSetHojoCounter))]
        private class FocusPatch
        {
            public static void Prefix(ref int formindex, ref int type, ref int point)
            {
                if (chargeNowindex <= 287 && type == 15 && (chargeNowcommand == 6 || datNormalSkill.tbl[chargeNowindex].koukatype == 0))
                    point = focusState;
                else if (chargeNowindex <= 287 && type == 19 && (chargeNowcommand == 6 || datNormalSkill.tbl[chargeNowindex].koukatype == 1))
                    point = concentrateState;
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetAction_SKILL))]
        private class FocusPatch2
        {
            public static void Prefix(ref nbActionProcessData_t a)
            {
                chargeNowcommand = a.work.nowcommand;
                chargeNowindex = a.work.nowindex;
                focusState = a.party.count[15];
                concentrateState = a.party.count[19];
            }

            public static void Postfix(ref nbActionProcessData_t a)
            {
                if (chargeNowindex <= 287 && ((datNormalSkill.tbl[chargeNowindex].koukatype == 0 && focusState == 1) ||
                    (datNormalSkill.tbl[chargeNowindex].koukatype == 1 || datNormalSkill.tbl[chargeNowindex].koukatype == 12) && concentrateState == 1))
                {
                    a.party.count[15] = 0;
                    a.party.count[19] = 0;
                }                   
            }
        }

        [HarmonyPatch(typeof(nbSkillError), nameof(nbSkillError.nbCheckBattleSkillError2))]
        private class FocusPatch4
        {
            public static void Postfix(ref int nskill, ref uint select, ref int __result)
            {
                if ((nskill == 89 || nskill == 224) && (nbMainProcess.nbGetMainProcessData().party[nbMainProcess.nbGetMainProcessData().activeunit].count[15] == 1 ||
                    nbMainProcess.nbGetMainProcessData().party[nbMainProcess.nbGetMainProcessData().activeunit].count[19] == 1))
                {
                    __result = 4;
                }
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbSetHojoKouka))]
        private class FocusPatch6
        {
            public static void Postfix(ref int formindex, ref uint hojotype, ref int hojopoint, ref int nvirtual, ref int __result)
            {
                var arr = Convert.ToString(hojotype, 2);

                if (arr.Length >= 26 && arr[arr.Length - 26] == Char.Parse("1"))
                {
                    var ivar2 = nbCalc.nbSetHojoAddCounter(formindex, 19, 1, nvirtual);
                    if (ivar2 == 0)
                        __result += ivar2;
                    else __result -= ivar2;

                    nbHelpProcess.nbDispText(datDevilName.Get(nbMainProcess.nbGetUnitWorkFromFormindex(formindex).id) + " is building up power!", string.Empty, 2, 45, 2315190144, false);
                }
            }
        }
    }
}