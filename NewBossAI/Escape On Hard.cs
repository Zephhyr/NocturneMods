using MelonLoader;
using HarmonyLib;
using Il2Cpp;

namespace NewBossAI
{
    internal partial class NewBossAI : MelonMod
    {
        static bool temporaryNormalMode = false; // Remembers if the game was on Hard difficulty before switching to Normal

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbCheckEscape))]
        private class EscapePatch
        {
            public static void Prefix()// Before checking if the player can escape
            {
                // If the game is on Hard difficulty
                if (dds3ConfigMain.cfgGetBit(9u) == 2)
                {
                    dds3ConfigMain.cfgSetBit(9u, 1); // Switches the game to Normal
                    temporaryNormalMode = true; // Remembers that it's only temporary
                }
            }

            public static void Postfix(ref int __result)// After checking if the player can escape
            {
                bool hasFastRetreat = datCalc.datCheckSkillInParty(296) == 1;

                // If Demi-fiend has Fast Retreat
                if (hasFastRetreat)
                {
                    __result = 1; // Always escape successfully
                }

                // If on Normal mode temporarily
                if (temporaryNormalMode)
                {
                    // If the escape is supposed to be successful then flip a coin
                    if (__result == 1 && !hasFastRetreat) __result = random.Next(0, 2);

                    // Switches back to Hard mode
                    dds3ConfigMain.cfgSetBit(9u, 2);
                }

                temporaryNormalMode = false;
            }
        }
    }
}