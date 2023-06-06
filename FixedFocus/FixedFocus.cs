using HarmonyLib;
using Il2Cpp;
using Il2Cppnewbattle_H;
using Il2Cppnewdata_H;
using MelonLoader;

[assembly: MelonInfo(typeof(FixedFocus.FixedFocus), "Fixed Focus", "1.0.0", "Zephhyr")]
[assembly: MelonGame("", "smt3hd")]

namespace FixedFocus
{
    internal class FixedFocus : MelonMod
    {
        public static short nowcommand;
        public static ushort nowindex;
        public static short focusState;

        [HarmonyPatch(typeof(nbCalc), "nbSetHojoCounter")]
        private class Patch
        {
            public static void Prefix(ref int formindex, ref int type, ref int point)
            {
                if (nowindex <= 287 && type == 15 && (nowcommand == 6 || datNormalSkill.tbl[nowindex].koukatype == 0))
                    point = focusState;
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), "SetAction_SKILL")]
        private class Patch2
        {
            public static void Prefix(ref nbActionProcessData_t a)
            {
                nowcommand = a.work.nowcommand;
                nowindex = a.work.nowindex;
                focusState = a.party.count[15];
            }

            public static void Postfix(ref nbActionProcessData_t a)
            {
                if (nowindex <= 287 && datNormalSkill.tbl[nowindex].koukatype == 0 && focusState == 1)
                    a.party.count[15] = 0;
            }
        }
    }
}