using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;

namespace NewBossAI
{
    internal partial class NewBossAI : MelonMod
    {
        private static bool hasPierce; // Remembers if the attacker has Pierce or Son's Oath/Raidou the Eternal

        // Before getting the effectiveness of a skill
        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetKoukaType))]
        private class PiercePatch
        {
            public static void Prefix(ref int sformindex, ref int nskill)
            {
                // If the skill in question is NOT a self-switch (from Zephhyr's mod) nor Analyze
                if (nbMainProcess.nbGetUnitWorkFromFormindex(sformindex) != null)
                {
                    // 357 = Pierce and 361 = Son's Oath/Raidou the Eternal
                    hasPierce = nskill != 71 && (nbMainProcess.nbGetUnitWorkFromFormindex(sformindex).skill.Contains(357) || nbMainProcess.nbGetUnitWorkFromFormindex(sformindex).skill.Contains(361));
                }
            }
        }

        // After getting the effectiveness of an attack on 1 target
        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetAisyo))]
        private class PiercePatch2
        {
            public static void Postfix(ref uint __result, ref int attr, ref int formindex, ref int nskill)
            {
                // If the attack is not a repel, the attacker has Pierce, the attack is physical/magical/almighty and it's resisted/blocked/drained
                if (nskill != -1 && hasPierce && attr <= 11 && (__result < 100 || (__result >= 65536 && __result < 131072) || (__result > 262143 && __result < 2147483648)))
                {
                    __result = 100; // Forces the affinity to become "neutral"
                    nbMainProcess.nbGetMainProcessData().d31_kantuu = 1; // Displays the "Pierced!" message
                }
            }
        }
    }
}