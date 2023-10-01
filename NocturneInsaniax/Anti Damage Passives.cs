using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using Il2Cppnewdata_H;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetAisyo))]
        private class AntiDamagePatch
        {
            public static void Postfix(ref int formindex, ref int attr, ref uint __result)
            {
                var work = nbMainProcess.nbGetUnitWorkFromFormindex(formindex);

                var resistance = Convert.ToString(__result, 2);
                while (resistance.Length < 32)
                    resistance = "0" + resistance;

                var substring = resistance.Substring(resistance.Length - 10).TrimStart('0');

                uint ratio = 100;
                if (string.IsNullOrEmpty(substring))
                    ratio = 0;
                else
                    ratio = Convert.ToUInt32(substring, 2);

                if (ratio == 75)
                    __result -= 25;

                bool isWeak = resistance[0] == '1';

                switch(attr)
                {
                    case 0:
                        {
                            if (isWeak && datCalc.datCheckSyojiSkill(work, 313) != 0)
                                __result -= 2147483648;
                            break;
                        }
                    case 1:
                        {
                            if (isWeak && (datCalc.datCheckSyojiSkill(work, 314) != 0 || datCalc.datCheckSyojiSkill(work, 364) != 0))
                                __result -= 2147483648;
                            if (datCalc.datCheckSyojiSkill(work, 364) != 0)
                            {
                                if (__result == 150)
                                    __result = 100;
                                __result -= Convert.ToUInt32(__result / 2);
                            }
                            break;
                        }
                    case 2:
                        {
                            if (isWeak && (datCalc.datCheckSyojiSkill(work, 315) != 0 || datCalc.datCheckSyojiSkill(work, 364) != 0))
                                __result -= 2147483648;
                            if (datCalc.datCheckSyojiSkill(work, 364) != 0)
                            {
                                if (__result == 150)
                                    __result = 100;
                                __result -= Convert.ToUInt32(__result / 2);
                            }
                            break;
                        }
                    case 3:
                        {
                            if (isWeak && (datCalc.datCheckSyojiSkill(work, 316) != 0 || datCalc.datCheckSyojiSkill(work, 364) != 0))
                                __result -= 2147483648;
                            if (datCalc.datCheckSyojiSkill(work, 364) != 0)
                            {
                                if (__result == 150)
                                    __result = 100;
                                __result -= Convert.ToUInt32(__result / 2);
                            }
                            break;
                        }
                    case 4:
                        {
                            if (isWeak && (datCalc.datCheckSyojiSkill(work, 317) != 0 || datCalc.datCheckSyojiSkill(work, 364) != 0))
                                __result -= 2147483648;
                            if (datCalc.datCheckSyojiSkill(work, 364) != 0)
                            {
                                if (__result == 150)
                                    __result = 100;
                                __result -= Convert.ToUInt32(__result / 2);
                            }
                            break;
                        }
                    case 6:
                        {
                            if (isWeak && datCalc.datCheckSyojiSkill(work, 318) != 0)
                                __result -= 2147483648;
                            break;
                        }
                    case 7:
                        {
                            if (isWeak && datCalc.datCheckSyojiSkill(work, 319) != 0)
                                __result -= 2147483648;
                            break;
                        }
                    case 8:
                        {
                            if (isWeak && (datCalc.datCheckSyojiSkill(work, 320) != 0 || datCalc.datCheckSyojiSkill(work, 365) != 0))
                                __result -= 2147483648;
                            if (datCalc.datCheckSyojiSkill(work, 365) != 0)
                            {
                                if (__result == 150)
                                    __result = 100;
                                __result -= Convert.ToUInt32(__result / 2);
                            }
                            break;
                        }
                    case 9:
                        {
                            if (isWeak && (datCalc.datCheckSyojiSkill(work, 321) != 0 || datCalc.datCheckSyojiSkill(work, 365) != 0))
                                __result -= 2147483648;
                            if (datCalc.datCheckSyojiSkill(work, 365) != 0)
                            {
                                if (__result == 150)
                                    __result = 100;
                                __result -= Convert.ToUInt32(__result / 2);
                            }
                            break;
                        }
                    case 10:
                        {
                            if (isWeak && (datCalc.datCheckSyojiSkill(work, 322) != 0 || datCalc.datCheckSyojiSkill(work, 365) != 0))
                                __result -= 2147483648;
                            if (datCalc.datCheckSyojiSkill(work, 365) != 0)
                            {
                                if (__result == 150)
                                    __result = 100;
                                __result -= Convert.ToUInt32(__result / 2);
                            }
                            break;
                        }
                    default: break;
                }
            }
        }
    }
}