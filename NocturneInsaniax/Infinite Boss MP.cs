using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using Il2Cppnewbattle_H;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        // List of demons that should be able to run out of MP
        static public List<ushort> bossesWithMana = new List<ushort>()
        {
            273, // Specter 2
            299, // Sakahagi
            355  // Sakahagi
        };
        static public bool sakahagiSkip = true;

        // Before removing HP or MP from someone during combat
        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbAddHpMp))]
        private class InfiniteBossMpPatch1
        {
            public static void Prefix(ref int formindex, ref int type, ref int n)
            {
                // Gets id of the unit
                ushort id = nbMainProcess.nbGetUnitWorkFromFormindex(formindex).id;
                ushort skillId = nbMainProcess.nbGetUnitWorkFromFormindex(formindex).nowindex;

                // If an enemy (that shouldn't be able to run out of MP) is about to lose MP
                if (formindex >= 4 && bossList.Contains(id) && !bossesWithMana.Contains(id) && type == 1 && n < 0)
                    n = 0; // Makes it lose 0 MP
            }
        }

        [HarmonyPatch(typeof(nbAi), nameof(nbAi.Chk_MYMP))]
        private class InfiniteBossMpPatch2
        {
            public static void Postfix(ref nbActionProcessData_t a, ref int n, ref int __result)
            {
                if (actionProcessData.work.id == 299 && actionProcessData.work.nowcommand == -1 && actionProcessData.work.nowindex == 0 && sakahagiSkip == true)
                {
                    sakahagiSkip = false;
                    __result = 0;
                }
            }
        }
    }
}