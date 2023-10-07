using HarmonyLib;
using MelonLoader;
using Il2Cppnewbattle_H;
using System.Collections.Generic;
using Il2Cpp;
using Il2Cppnewdata_H;
using Il2Cppfield_H;
using Il2Cppbasic_H;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        static private byte[] tmp_dropPoint;

        #region datCalc

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetBaseMaxHp))]
        private class BaseMaxHpPatch
        {
            public static bool Prefix(ref datUnitWork_t work, ref int __result)
            {
                var level = work.level;
                var vit = datCalc.datGetParam(work, 3);
                __result = (level + vit) * 6;
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetMaxHp))]
        private class MaxHpPatch
        {
            public static bool Prefix(ref datUnitWork_t work, ref uint __result)
            {
                var baseHp = datCalc.datGetBaseMaxHp(work);
                var boost = 1.0;
                if (datCalc.datCheckSyojiSkill(work, 290) == 1)
                    boost += 0.1;
                if (datCalc.datCheckSyojiSkill(work, 291) == 1)
                    boost += 0.2;
                if (datCalc.datCheckSyojiSkill(work, 292) == 1)
                    boost += 0.3;
                __result = Math.Min(Convert.ToUInt32(baseHp * boost), 999);
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetBaseMaxMp))]
        private class BaseMaxMpPatch
        {
            public static bool Prefix(ref datUnitWork_t work, ref int __result)
            {
                var level = work.level;
                var mag = datCalc.datGetParam(work, 2);
                __result = (level + mag) * 4;
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetMaxMp))]
        private class MaxMpPatch
        {
            public static bool Prefix(ref datUnitWork_t work, ref uint __result)
            {
                var baseMp = datCalc.datGetBaseMaxMp(work);
                var boost = 1.0;
                if (datCalc.datCheckSyojiSkill(work, 293) == 1)
                    boost += 0.1;
                if (datCalc.datCheckSyojiSkill(work, 294) == 1)
                    boost += 0.2;
                if (datCalc.datCheckSyojiSkill(work, 295) == 1)
                    boost += 0.3;
                __result = Math.Min(Convert.ToUInt32(baseMp * boost), 999);
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetNormalAtkPow))]
        private class NormalAtkPowPatch
        {
            public static bool Prefix(ref datUnitWork_t work, ref int __result)
            {
                var level = work.level;
                var str = datCalc.datGetParam(work, 0);
                if (datCalc.datCheckSyojiSkill(work, 368) == 1)
                    __result = Convert.ToInt32((level + str) * 48 / 15);
                else
                    __result = Convert.ToInt32((level + str) * 32 / 15);
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetMagicHitPow))]
        private class MagicHitPowPatch
        {
            public static bool Prefix(ref datUnitWork_t work, ref int __result)
            {
                var level = work.level;
                var mag = datCalc.datGetParam(work, 2);
                var agi = datCalc.datGetParam(work, 4);
                var luk = datCalc.datGetParam(work, 5);
                __result = level + mag + (agi * 2) + luk;
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetDefPow))]
        private class DefPowPatch
        {
            public static bool Prefix(ref datUnitWork_t work, ref int __result)
            {
                var vit = datCalc.datGetParam(work, 3);
                __result = vit;
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetSakePow))]
        private class SakePowPatch
        {
            public static bool Prefix(ref datUnitWork_t work, ref int __result)
            {
                var level = work.level;
                var agi = datCalc.datGetParam(work, 4);
                var luk = datCalc.datGetParam(work, 5);
                __result = level + (agi * 2) + luk;
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetLevelForDraw))]
        private class GetLevelForDrawPatch
        {
            public static bool Prefix(ref datUnitWork_t work, ref int __result)
            {
                __result = work.level;
                return false;
            }
        }

        #endregion datCalc

        #region nbCalc

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetButuriAttack))]
        private class PhysicalAttackPatch
        {
            public static bool Prefix(ref int nskill, ref int sformindex, ref int dformindex, ref int waza, ref int __result)
            {
                datUnitWork_t workFromFormindex1 = nbMainProcess.nbGetUnitWorkFromFormindex(sformindex);
                //datUnitWork_t workFromFormindex2 = nbMainProcess.nbGetUnitWorkFromFormindex(dformindex);

                double atkPow = nskill == 0 ?
                    datCalc.datGetNormalAtkPow(workFromFormindex1) :
                    (workFromFormindex1.level + datCalc.datGetParam(workFromFormindex1, 0)) * waza / 15;

                //double defPow = datCalc.datGetParam(workFromFormindex2, 3);

                var atkBuff = nbCalc.nbGetHojoRitu(sformindex, 4);
                var defBuff = nbCalc.nbGetHojoRitu(dformindex, 7);

                atkPow *= atkBuff * defBuff;
                //defPow /= atkBuff * defBuff;

                __result = Convert.ToInt32(atkPow);
                return false;
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetMaxHpWazaPoint))]
        private class MaxHpAttackPatch
        {
            public static bool Prefix(ref int nskill, ref int sformindex, ref int dformindex, ref int waza, ref int __result)
            {
                datUnitWork_t workFromFormindex1 = nbMainProcess.nbGetUnitWorkFromFormindex(sformindex);
                //datUnitWork_t workFromFormindex2 = nbMainProcess.nbGetUnitWorkFromFormindex(dformindex);

                var maxhp = (double) workFromFormindex1.maxhp;
                var currenthp = (double) (int) (workFromFormindex1.hp + (datCalc.datGetSkillCost(workFromFormindex1, nskill) * maxhp / 100));
                double hpPercentage = (currenthp / maxhp);
                double hpModifier = 0.5 + hpPercentage / 2;

                //double atkPow = workFromFormindex1.maxhp * waza * 0.8 / 69.6;
                double atkPow = ((workFromFormindex1.level + datCalc.datGetParam(workFromFormindex1, 0)) * waza / 15) * hpModifier;

                //double defPow = datCalc.datGetParam(workFromFormindex2, 3);

                var atkBuff = nbCalc.nbGetHojoRitu(sformindex, 4);
                var defBuff = nbCalc.nbGetHojoRitu(dformindex, 7);

                atkPow *= atkBuff * defBuff;
                //defPow /= atkBuff * defBuff;

                __result = Convert.ToInt32(atkPow);
                return false;
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbCheckSensei))]
        private class CheckSenseiPatch
        {
            public static bool Prefix(ref nbMainProcessData_t data, ref int __result)
            {
                var flag = datEncount.Get(data.encno).flag;

                if (flag == 13 || flag == 8)
                    __result = 0;
                else if (flag == 11)
                    __result = 1;
                else
                {
                    var lvAvg = nbCalc.nbGetLvAvg2(data, 1);
                    var avgAgi = nbCalc.nbGetParamAvg2(data, 1, 4);
                    var avgLuk = nbCalc.nbGetParamAvg2(data, 1, 5);

                    datUnitWork_t work = dds3GlobalWork.DDS3_GBWK.unitwork[0];
                    var level = work.level;
                    var agi = datCalc.datGetParam(work, 4);
                    var luk = datCalc.datGetParam(work, 5);

                    double chance = (72 + (level * 2) + (agi * 4) + (luk * 3)) - ((lvAvg * 2) + (avgAgi * 4) + (avgLuk * 3));
                    var rand = dds3KernelCore.dds3GetRandIntA(128);
                    __result = rand < chance ? 0 : 1;
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbCheckBackAttack))]
        private class CheckBackAttackPatch
        {
            public static bool Prefix(ref nbMainProcessData_t data, ref int __result)
            {
                if (datCalc.datCheckSkillInParty(298) == 1)
                {
                    __result = 0;
                    return false;
                }
                var lvAvg = nbCalc.nbGetLvAvg2(data, 1);
                var avgAgi = nbCalc.nbGetParamAvg2(data, 1, 4);
                var avgLuk = nbCalc.nbGetParamAvg2(data, 1, 5);

                datUnitWork_t work = dds3GlobalWork.DDS3_GBWK.unitwork[0];
                var level = work.level;
                var agi = datCalc.datGetParam(work, 4);
                var luk = datCalc.datGetParam(work, 5);

                double chance = 12 * (lvAvg + avgAgi + (avgLuk * 2)) / (level + agi + (luk * 2));
                var rand = dds3KernelCore.dds3GetRandIntA(128);
                __result = rand > chance ? 0 : 1 + datEncount.Get(data.encno).backattack;

                return false;
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbCheckEscape))]
        private class CheckEscapePatch
        {
            public static bool Prefix(ref nbMainProcessData_t data, ref int __result)
            {
                var encounter = datEncount.Get(data.encno);
                if ((encounter.flag >> 5 & 1) != 0 || datCalc.datCheckSkillInParty(296) != 0)
                    __result = 1;
                else
                {
                    bool allDisabled = true;
                    foreach (var enemy in data.enemyunit)
                    {
                        if (enemy.badstatus != 4 && enemy.badstatus != 8 && enemy.badstatus != 16 && enemy.badstatus != 128 && enemy.badstatus != 1024 && enemy.badstatus != 2048)
                        {
                            allDisabled = false;
                            break;
                        }
                    }
                    if (allDisabled)
                    {
                        __result = 1;
                        return false;
                    }

                    var allyAvgAgi = nbCalc.nbGetParamAvg2(data, 0, 4);
                    var allyAvgLuk = nbCalc.nbGetParamAvg2(data, 0, 5);
                    var enemyAvgAgi = nbCalc.nbGetParamAvg2(data, 1, 4);
                    var enemyAvgLuk = nbCalc.nbGetParamAvg2(data, 1, 5);
                    var attemptCount = data.esccnt;
                    var moonModifier = evtMoon.evtGetAgeOfMoon() == 8 ? 20 : 0;

                    double chance = 20 * ((allyAvgAgi + allyAvgLuk) / (enemyAvgAgi + enemyAvgLuk)) + 40 - moonModifier + 10 * attemptCount;
                    if (dds3ConfigMain.cfgGetBit(9) == 2)
                        chance /= 2;
                    var rand = dds3KernelCore.dds3GetRandIntA(100);
                    __result = rand < chance ? 1 - encounter.esc : 0;
                }

                return false;
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetHitType))]
        private class GetHitTypePatch
        {
            public static bool Prefix(ref nbActionProcessData_t ad, ref int nskill, ref int sformindex, ref int dformindex, ref int __result)
            {
                datUnitWork_t workFromFormindex1 = nbMainProcess.nbGetUnitWorkFromFormindex(sformindex);
                datUnitWork_t workFromFormindex2 = nbMainProcess.nbGetUnitWorkFromFormindex(dformindex);

                var aisyo = nbCalc.nbGetAisyo(nskill, dformindex, datSkill.tbl[nskill].skillattr);
                var resistance = Convert.ToString(aisyo, 2);
                while (resistance.Length < 32)
                    resistance = "0" + resistance;
                bool isWeak = resistance[0] == '1';

                if (isWeak)
                    __result = 2;
                else if (datNormalSkill.tbl[nskill].koukatype == 0 && (workFromFormindex2.badstatus == 1 || workFromFormindex2.badstatus == 2))
                    __result = 1;
                else
                {
                    var critRate = datNormalSkill.tbl[nskill].criticalpoint;
                    if (nskill == 0)
                    {
                        if ((datCalc.datCheckSyojiSkill(workFromFormindex1, 300) != 0 && evtMoon.evtGetAgeOfMoon() == 8) ||
                            (datCalc.datCheckSyojiSkill(workFromFormindex1, 301) != 0 && evtMoon.evtGetAgeOfMoon() == 0))
                            critRate = 50;
                        else if (datCalc.datCheckSyojiSkill(workFromFormindex1, 299) != 0 || datCalc.datCheckSyojiSkill(workFromFormindex1, 368) != 0)
                            critRate = 30;
                    }
                    var luk = datCalc.datGetParam(workFromFormindex1, 5);
                    var lukMultiplier = 1 + ((float)luk / 100);
                    var critChance = critRate * lukMultiplier;

                    var rand = dds3KernelCore.dds3GetRandIntA(100);
                    __result = rand < critChance ? 1 : 0;
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetKoukaType))]
        private class GetKoukaTypePatch
        {
            public static void Postfix(ref int nskill, ref int sformindex, ref int dformindex, ref int __result)
            {
                if (datNormalSkill.tbl[nskill].koukatype == 0 && (__result == 0 || __result == 4))
                {
                    datUnitWork_t workFromFormindex1 = nbMainProcess.nbGetUnitWorkFromFormindex(sformindex);
                    datUnitWork_t workFromFormindex2 = nbMainProcess.nbGetUnitWorkFromFormindex(dformindex);

                    if (workFromFormindex2.badstatus == 1 || workFromFormindex2.badstatus == 2 || workFromFormindex2.badstatus == 4 || workFromFormindex2.badstatus == 16 || workFromFormindex2.badstatus == 256 || workFromFormindex2.badstatus == 1024)
                    {
                        __result = 0;
                        return;
                    }

                    var userLevel = workFromFormindex1.level;
                    var userAgi = datCalc.datGetParam(workFromFormindex1, 4);
                    var userLuk = datCalc.datGetParam(workFromFormindex1, 5);
                    var accuracyBuff = nbCalc.nbGetHojoRitu(sformindex, 8);
                    
                    var targetLevel = workFromFormindex2.level;
                    var targetAgi = datCalc.datGetParam(workFromFormindex2, 4);
                    var targetLuk = datCalc.datGetParam(workFromFormindex2, 5);
                    var evasionBuff = nbCalc.nbGetHojoRitu(dformindex, 6);

                    var chance = ((datNormalSkill.tbl[nskill].hitlevel - datNormalSkill.tbl[nskill].failpoint) + (userLevel + (userAgi * 2) + userLuk) - (targetLevel + (targetAgi * 2) + targetLuk)) * accuracyBuff * evasionBuff;
                    var rand = dds3KernelCore.dds3GetRandIntA(100);
                    __result = rand < chance ? 0 : 4;
                }
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetExpMakaItem))]
        private class GetExpMakaItemPatch
        {
            public static void Prefix(ref datUnitWork_t w)
            {
                var luk = datCalc.datGetParam(nbMainProcess.nbGetUnitWorkFromFormindex(0), 5);
                var lukMultiplier = 1 + ((float)luk / 100);

                tmp_dropPoint = datDevilFormat.tbl[w.id].droppoint;

                for (int i = 0; i < datDevilFormat.tbl[w.id].droppoint.Length; i++)
                    datDevilFormat.tbl[w.id].droppoint[i] = Convert.ToByte(datDevilFormat.tbl[w.id].droppoint[i] * lukMultiplier);
            }

            public static void Postfix(ref datUnitWork_t w)
            {
                datDevilFormat.tbl[w.id].droppoint = tmp_dropPoint;
            }
        }

        #endregion nbCalc
    }
}