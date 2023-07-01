using HarmonyLib;
using Il2Cpp;
using Il2Cppnewbattle_H;
using Il2Cppnewdata_H;
using MelonLoader;

namespace NewBossAI
{
    internal partial class NewBossAI : MelonMod
    {
        public static short focusNowcommand;
        public static ushort focusNowindex;
        public static short focusState;

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbSetHojoCounter))]
        private class FocusPatch
        {
            public static void Prefix(ref int formindex, ref int type, ref int point)
            {
                if (focusNowindex <= 287 && type == 15 && (focusNowcommand == 6 || datNormalSkill.tbl[focusNowindex].koukatype == 0))
                    point = focusState;
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetAction_SKILL))]
        private class FocusPatch2
        {
            public static void Prefix(ref nbActionProcessData_t a)
            {
                focusNowcommand = a.work.nowcommand;
                focusNowindex = a.work.nowindex;
                focusState = a.party.count[15];
            }

            public static void Postfix(ref nbActionProcessData_t a)
            {
                if (focusNowindex <= 287 && datNormalSkill.tbl[focusNowindex].koukatype == 0 && focusState == 1)
                    a.party.count[15] = 0;
            }
        }
    }
}