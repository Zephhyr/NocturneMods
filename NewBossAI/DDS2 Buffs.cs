using HarmonyLib;
using MelonLoader;
using Il2Cppnewbattle_H;
using System.Collections.Generic;
using Il2Cpp;
using Il2Cppnewdata_H;
using Il2Cppfield_H;
using Il2Cppkernel_H;

namespace NewBossAI
{
    internal partial class NewBossAI : MelonMod
    {
        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetHojoRitu))]
        private class DDS2BuffRatioPatch
        {
            public static bool Prefix(ref int formindex, ref int type, ref float __result)
            {
                nbParty_t party = nbMainProcess.nbGetPartyFromFormindex(formindex);
                short[] count = party.count;
                short stacks = count[type];

                double newEffect = 1;
                if (stacks > 0)
                {
                    if (type == 6 || type == 7)
                    {
                        switch (stacks)
                        {
                            case 1: newEffect = 1 / 1.3; break;
                            case 2: newEffect = 1 / 1.5; break;
                            case 3: newEffect = 1 / 1.6; break;
                            case 4: newEffect = 1 / 1.6; break;
                        }
                    }
                    else
                    {
                        switch (stacks)
                        {
                            case 1: newEffect = 1.3; break;
                            case 2: newEffect = 1.5; break;
                            case 3: newEffect = 1.6; break;
                            case 4: newEffect = 1.6; break;
                        }
                    }
                }
                else if (stacks < 0)
                {
                    if (type == 6 || type == 7)
                    {
                        switch (stacks)
                        {
                            case -1: newEffect = 1.3; break;
                            case -2: newEffect = 1.5; break;
                            case -3: newEffect = 1.6; break;
                            case -4: newEffect = 1.6; break;
                        }
                    }
                    else
                    {
                        switch (stacks)
                        {
                            case -1: newEffect = 1 / 1.3; break;
                            case -2: newEffect = 1 / 1.5; break;
                            case -3: newEffect = 1 / 1.6; break;
                            case -4: newEffect = 1 / 1.6; break;
                        }
                    }
                }

                if ((type == 4 && count[15] > 0) || (type == 5 && count[19] > 0))
                    newEffect *= 2.5;

                __result = (float) newEffect;
                return false;
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetHojoCounterMax))]
        private class DDS2BuffMaxPatch
        {
            public static bool Prefix(ref int hojotype, ref int __result)
            {
                if (hojotype >= 4 && hojotype <= 8)
                {
                    __result = 3;
                    return false;
                }
                else return true;
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetHojoCounterMin))]
        private class DDS2BuffMinPatch
        {
            public static bool Prefix(ref int hojotype, ref int __result)
            {
                if (hojotype >= 4 && hojotype <= 8)
                {
                    __result = -3;
                    return false;
                }
                else return true;
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetActionSeq))]
        private class DDS2BuffLimitPatch
        {
            public static void Prefix(ref nbActionProcessData_t a, ref int seq)
            {
                actionProcessData = a;

                var party = nbMainProcess.nbGetMainProcessData().party;
                foreach (var unit in party)
                {
                    for (int i = 4; i <= 8; i++)
                    {
                        if (unit.count[i] > 3)
                            unit.count[i] = 3;
                        if (unit.count[i] < -3)
                            unit.count[i] = -3;
                    }
                }
            }
        }
    }
}