using HarmonyLib;
using Il2Cpp;
using Il2Cppnewbattle_H;
using Il2Cppnewdata_H;
using MelonLoader;

[assembly: MelonInfo(typeof(FixedFocusMagic.FixedFocusMagic), "Fixed Focus (Compatible with Focus Magic)", "1.0.0", "Zephhyr & Matthiew Purple")]
[assembly: MelonGame("", "smt3hd")]

namespace FixedFocusMagic
{
    internal class FixedFocusMagic : MelonMod
    {
        public static short nowcommand;
        public static ushort nowindex;
        public static short focusState;

        [HarmonyPatch(typeof(nbCalc), "nbSetHojoCounter")]
        private class Patch
        {
            public static void Prefix(ref int formindex, ref int type, ref int point)
            {
                bool isFocusableSkill = datNormalSkill.tbl[nowindex].hptype == 1 || datNormalSkill.tbl[nowindex].hptype == 6 || datNormalSkill.tbl[nowindex].hptype == 12 || datNormalSkill.tbl[nowindex].hptype == 14 || datNormalSkill.tbl[nowindex].mptype == 12;

                if (nowindex <= 287 && type == 15 && (nowcommand == 6 || isFocusableSkill))
                    point = focusState;
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), "SetAction_SKILL")]
        private class Patch2
        {
            public static void Prefix(ref nbActionProcessData_t a)
            {
                if (nowcommand == 5) nowindex = datItem.tbl[nowindex].skillid;
                nowcommand = a.work.nowcommand;
                nowindex = a.work.nowindex;
                focusState = a.party.count[15];
            }

            public static void Postfix(ref nbActionProcessData_t a)
            {
                bool isFocusableSkill = datNormalSkill.tbl[nowindex].hptype == 1 || datNormalSkill.tbl[nowindex].hptype == 6 || datNormalSkill.tbl[nowindex].hptype == 12 || datNormalSkill.tbl[nowindex].hptype == 14 || datNormalSkill.tbl[nowindex].mptype == 12;

                if (nowcommand != 6 && nowindex <= 287 && isFocusableSkill && focusState == 1)
                    a.party.count[15] = 0;
            }
        }
    }
}