using HarmonyLib;
using MelonLoader;
using Il2Cppnewbattle_H;
using System.Collections.Generic;
using Il2Cpp;
using Il2Cppnewdata_H;
using Il2Cppfield_H;

[assembly: MelonInfo(typeof(NewStatFormulae.NewStatFormulae), "New Stat Formulae", "1.0.0", "Zephhyr")]
[assembly: MelonGame("", "smt3hd")]

namespace NewStatFormulae
{
    internal class NewStatFormulae : MelonMod
    {
        #region datCalc

        [HarmonyPatch(typeof(datCalc), "datGetBaseMaxHp")]
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

        [HarmonyPatch(typeof(datCalc), "datGetMaxHp")]
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
                __result = Convert.ToUInt32(baseHp * boost);
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), "datGetBaseMaxMp")]
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

        [HarmonyPatch(typeof(datCalc), "datGetMaxMp")]
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
                __result = Convert.ToUInt32(baseMp * boost);
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), "datGetNormalAtkPow")]
        private class NormalAtkPowPatch
        {
            public static bool Prefix(ref datUnitWork_t work, ref int __result)
            {
                var level = work.level;
                var str = datCalc.datGetParam(work, 0);
                __result = Convert.ToInt32((level + str) * 32 / 14.5);
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), "datGetMagicHitPow")]
        private class MagicHitPowPatch
        {
            public static bool Prefix(ref datUnitWork_t work, ref int __result)
            {
                var level = work.level;
                var mag = datCalc.datGetParam(work, 2);
                var agi = datCalc.datGetParam(work, 4);
                var luk = datCalc.datGetParam(work, 5);
                __result = level + mag + agi + (luk * 2);
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), "datGetDefPow")]
        private class DefPowPatch
        {
            public static bool Prefix(ref datUnitWork_t work, ref int __result)
            {
                var vit = datCalc.datGetParam(work, 3);
                __result = vit;
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), "datGetSakePow")]
        private class SakePowPatch
        {
            public static bool Prefix(ref datUnitWork_t work, ref int __result)
            {
                var level = work.level;
                var agi = datCalc.datGetParam(work, 4);
                var luk = datCalc.datGetParam(work, 5);
                __result = level + (agi * 2) + luk + 10;
                return false;
            }
        }

        #endregion datCalc

        #region nbCalc

        [HarmonyPatch(typeof(nbCalc), "nbGetButuriAttack")]
        private class PhysicalAttackPatch
        {
            public static bool Prefix(ref int nskill, ref int sformindex, ref int dformindex, ref int waza, ref int __result)
            {
                datUnitWork_t workFromFormindex1 = nbMainProcess.nbGetUnitWorkFromFormindex(sformindex);
                //datUnitWork_t workFromFormindex2 = nbMainProcess.nbGetUnitWorkFromFormindex(dformindex);

                double atkPow = nskill == 0 ?
                    datCalc.datGetNormalAtkPow(workFromFormindex1) :
                    (workFromFormindex1.level + datCalc.datGetParam(workFromFormindex1, 0)) * waza / 14.5;

                //double defPow = datCalc.datGetParam(workFromFormindex2, 3);

                var atkBuff = nbCalc.nbGetHojoRitu(sformindex, 4);
                var defBuff = nbCalc.nbGetHojoRitu(dformindex, 7);

                atkPow *= atkBuff * defBuff;
                //defPow /= atkBuff * defBuff;

                __result = Convert.ToInt32(atkPow);
                return false;
            }
        }

        [HarmonyPatch(typeof(nbCalc), "nbGetMaxHpWazaPoint")]
        private class MaxHpAttackPatch
        {
            public static bool Prefix(ref int nskill, ref int sformindex, ref int dformindex, ref int waza, ref int __result)
            {
                datUnitWork_t workFromFormindex1 = nbMainProcess.nbGetUnitWorkFromFormindex(sformindex);
                //datUnitWork_t workFromFormindex2 = nbMainProcess.nbGetUnitWorkFromFormindex(dformindex);

                double atkPow = workFromFormindex1.maxhp * waza * 0.8 / 69.6;

                //double defPow = datCalc.datGetParam(workFromFormindex2, 3);

                var atkBuff = nbCalc.nbGetHojoRitu(sformindex, 4);
                var defBuff = nbCalc.nbGetHojoRitu(dformindex, 7);

                atkPow *= atkBuff * defBuff;
                //defPow /= atkBuff * defBuff;

                __result = Convert.ToInt32(atkPow);
                return false;
            }
        }

        //[HarmonyPatch(typeof(nbCalc), "nbGetMagicAttack")]
        //private class magicAttackPatch
        //{
        //    public static void Postfix(ref int nskill, ref int sformindex, ref int dformindex, ref int waza, ref int __result)
        //    {
        //        datUnitWork_t workFromFormindex1 = nbMainProcess.nbGetUnitWorkFromFormindex(sformindex);
        //        datUnitWork_t workFromFormindex2 = nbMainProcess.nbGetUnitWorkFromFormindex(dformindex);

        //        var newWaza = 30 * Math.Log(waza) - 70;

        //        double atkPow = (workFromFormindex1.level + datCalc.datGetParam(workFromFormindex1, 2)) * newWaza / 14.5;
        //        //double atkPow = (workFromFormindex1.level + datCalc.datGetParam(workFromFormindex1, 2) * 2) * Math.Pow(waza, 0.75) / 12;
        //        //double atkPow2 = 0.004 * (5 * (datCalc.datGetParam(workFromFormindex1, 2) + 36) - workFromFormindex1.level) * (24 * waza * (workFromFormindex1.level / 255) + datNormalSkill.tbl[nskill].magicbase);

        //        //double defPow = datCalc.datGetParam(workFromFormindex2, 3);

        //        var atkBuff = nbCalc.nbGetHojoRitu(sformindex, 5);
        //        var defBuff = nbCalc.nbGetHojoRitu(dformindex, 7);

        //        MelonLogger.Msg("atkBuff: " + atkBuff);
        //        MelonLogger.Msg("defBuff: " + defBuff);

        //        atkPow *= atkBuff * defBuff;
        //        //defPow /= atkBuff * defBuff;

        //        MelonLogger.Msg("waza:" + waza);
        //        MelonLogger.Msg("newWaza:" + newWaza);
        //        MelonLogger.Msg("atkPow:" + atkPow);
        //        MelonLogger.Msg("normal:" + __result);
        //    }
        //}

        [HarmonyPatch(typeof(nbCalc), "nbCheckSensei")]
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

        [HarmonyPatch(typeof(nbCalc), "nbCheckBackAttack")]
        private class CheckBackAttackPatch
        {
            public static bool Prefix(ref nbMainProcessData_t data, ref int __result)
            {
                var lvAvg = nbCalc.nbGetLvAvg2(data, 1);
                var avgAgi = nbCalc.nbGetParamAvg2(data, 1, 4);
                var avgLuk = nbCalc.nbGetParamAvg2(data, 1, 5);

                datUnitWork_t work = dds3GlobalWork.DDS3_GBWK.unitwork[0];
                var level = work.level;
                var agi = datCalc.datGetParam(work, 4);
                var luk = datCalc.datGetParam(work, 5);

                double chance = 12 * (lvAvg + avgAgi + (avgLuk * 2)) / (level + agi + (luk * 2));
                var rand = dds3KernelCore.dds3GetRandIntA(128);
                __result = rand > chance ? 0 : 1 - datEncount.Get(data.encno).backattack;

                return false;
            }
        }

        //[HarmonyPatch(typeof(nbCalc), "nbGetHitType")]
        //private class GetHitTypePatch
        //{
        //    public static void Postfix(ref nbActionProcessData_t ad, ref int nskill, ref int sformindex, ref int dformindex, ref int __result)
        //    //public static bool Prefix(ref nbActionProcessData_t ad, ref int nskill, ref int sformindex, ref int dformindex, ref int __result)
        //    {
        //        datUnitWork_t workFromFormindex1 = nbMainProcess.nbGetUnitWorkFromFormindex(sformindex);
        //        datUnitWork_t workFromFormindex2 = nbMainProcess.nbGetUnitWorkFromFormindex(dformindex);

        //        var aisyo = nbCalc.nbGetAisyo(nskill, dformindex, datSkill.tbl[nskill].skillattr);

        //        if (nskill == 0)
        //        {
        //            if (datCalc.datCheckSyojiSkill(workFromFormindex1, 300) != 0 && evtMoon.evtGetAgeOfMoon() == 8)
        //                ad.autoskill = 300;
        //            else if (datCalc.datCheckSyojiSkill(workFromFormindex1, 301) != 0 && evtMoon.evtGetAgeOfMoon() == 0)
        //                ad.autoskill = 301;
        //        }

        //        MelonLogger.Msg("normalResult: " + __result);
        //        //return false;
        //    }
        //}
            #endregion nbCalc
    }
}