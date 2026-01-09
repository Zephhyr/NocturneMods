using HarmonyLib;
using Il2Cpp;
using Il2Cppbasic_H;
using Il2Cppfield_H;
using Il2Cppnewbattle_H;
using Il2Cppnewdata_H;
using MelonLoader;
using System.Collections.Generic;
using static Il2Cpp.SteamDlcFileUtil;
using static UnityEngine.GraphicsBuffer;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        static private byte[] tmp_dropPoint;

        #region datCalc

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetParam))]
        private class datGetParamPatch
        {
            public static bool Prefix(ref datUnitWork_t work, ref int paratype, ref int __result)
            {
                __result = datCalc.datGetBaseParam(work, paratype);
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
                if (work.id == 111 || work.id == 335)
                    __result = Convert.ToInt32((level + (str * 0.8f)) * 45 / 20);
                else
                    __result = Convert.ToInt32((level + (str * 0.8f)) * 30 / 20);
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetMagicHitPow))]
        private class MagicHitPowPatch
        {
            public static bool Prefix(ref datUnitWork_t work, ref int __result)
            {
                var level = work.level;
                var intStat = datCalc.datGetParam(work, 1);
                var agi = datCalc.datGetParam(work, 4);
                var luk = datCalc.datGetParam(work, 5);
                __result = level + Convert.ToInt32((intStat + (agi * 2) + luk) * 0.4f);
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
                __result = level + Convert.ToInt32(((agi * 2) + luk) * 0.4f);
                return false;
            }
        }

        //[HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetLevelForDraw))]
        //private class GetLevelForDrawPatch
        //{
        //    public static bool Prefix(ref datUnitWork_t work, ref int __result)
        //    {
        //        __result = work.level;
        //        return false;
        //    }
        //}

        #endregion datCalc

        #region nbCalc

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetCriticalPow))]
        private class CriticalPowPatch
        {
            public static bool Prefix(ref int sformindex, ref float pow, ref float __result)
            {
                if (nbMainProcess.nbGetUnitWorkFromFormindex(sformindex).id > 383)
                {
                    __result = pow * (1 + 0.3f);
                    return false;
                }


                bool criticalMelodyActive = false;
                byte pawToPawCount = 0;
                bool pawToPawActive = false;
                bool proxyGuardHoundActive = false;
                byte fourOniCount = 0;
                byte rulersVirtuosityCount = 0;

                // Critical Melody
                if (nbMainProcess.nbGetPartyFromFormindex(sformindex).partyindex <= 3)
                {
                    foreach (var ally in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3))
                    {
                        try
                        {
                            if (criticalMelodyIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id))
                                criticalMelodyActive = true;
                        }
                        catch { }
                    }
                }
                else
                {
                    foreach (var enemy in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex > 3))
                    {
                        try
                        {
                            if (criticalMelodyIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(enemy.formindex).id))
                                criticalMelodyActive = true; 
                        }
                        catch { }
                    }
                }
                // Paw-to-Paw Combat
                if (pawToPawCombatIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(sformindex).id))
                {
                    if (nbMainProcess.nbGetPartyFromFormindex(sformindex).partyindex <= 3)
                    {
                        foreach (var ally in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3))
                        {
                            try
                            {
                                if (pawToPawCombatIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id))
                                    pawToPawCount++; 
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        foreach (var enemy in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex > 3))
                        {
                            try
                            {
                                if (pawToPawCombatIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(enemy.formindex).id))
                                    pawToPawCount++;
                            }
                            catch { }
                        }
                    }

                    if (pawToPawCount >= 2) pawToPawActive = true;
                }
                // Proxy Guard Hound
                if (proxyGuardHoundRaces.Contains(datDevilFormat.tbl[nbMainProcess.nbGetUnitWorkFromFormindex(sformindex).id].race))
                {
                    if (nbMainProcess.nbGetPartyFromFormindex(sformindex).partyindex <= 3)
                    {
                        foreach (var ally in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3))
                        {
                            try
                            {
                                if (proxyGuardHoundIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id))
                                    proxyGuardHoundActive = true; 
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        foreach (var enemy in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex > 3))
                        {
                            try
                            {
                                if (proxyGuardHoundIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(enemy.formindex).id))
                                    proxyGuardHoundActive = true;
                            }
                            catch { }
                        }
                    }
                }
                // Four Oni
                else if (fourOniIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(sformindex).id))
                {
                    if (nbMainProcess.nbGetPartyFromFormindex(sformindex).partyindex <= 3)
                    {
                        foreach (var ally in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3))
                        {
                            try
                            {
                                if (fourOniIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id))
                                    fourOniCount++;
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        foreach (var enemy in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex > 3))
                        {
                            try
                            {
                                if (fourOniIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(enemy.formindex).id))
                                    fourOniCount++;
                            }
                            catch { }
                        }
                    }
                }
                // Ruler's Virtuosity
                else if (nbMainProcess.nbGetUnitWorkFromFormindex(sformindex).id == 0 && dds3GlobalWork.DDS3_GBWK.heartsequip == 25)
                {
                    try
                    {
                        foreach (var buff in new byte[] { 4, 5, 6, 7, 8, 11, 12, 13, 14, 15, 20 })
                            if (nbMainProcess.nbGetPartyFromFormindex(sformindex).count[buff] != 0)
                                rulersVirtuosityCount++;
                    }
                    catch { }
                }

                __result = pow * (1 + 0.3f + (Convert.ToInt16(criticalMelodyActive) * 0.1f) + (Convert.ToInt16(pawToPawActive) * 0.3f) + (Convert.ToInt16(proxyGuardHoundActive) * 0.3f) + (fourOniCount * 0.1f) + (rulersVirtuosityCount * 0.05f));
                return false;
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetButuriAttack))]
        private class PhysicalAttackPatch
        {
            public static bool Prefix(ref int nskill, ref int sformindex, ref int dformindex, ref int waza, ref int __result)
            {
                datUnitWork_t workFromFormindex1 = nbMainProcess.nbGetUnitWorkFromFormindex(sformindex);
                //datUnitWork_t workFromFormindex2 = nbMainProcess.nbGetUnitWorkFromFormindex(dformindex);

                double atkPow = (nskill == 0 || nskill == 167) ?
                    datCalc.datGetNormalAtkPow(workFromFormindex1) :
                    (workFromFormindex1.level + (datCalc.datGetParam(workFromFormindex1, 0) * 0.8f)) * waza / 20;

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

                double hpModifier = 1;
                if (datCalc.datCheckSyojiSkill(actionProcessData.work, 371) == 0) // Arms Master
                {
                    var maxhp = (double)workFromFormindex1.maxhp;
                    var currenthp = (double)(int)(workFromFormindex1.hp + (datCalc.datGetSkillCost(workFromFormindex1, nskill) * maxhp / 100));
                    double hpPercentage = (currenthp / maxhp);
                    hpModifier = 0.5 + (hpPercentage / 2);
                }

                //double atkPow = workFromFormindex1.maxhp * waza * 0.8 / 69.6;
                double atkPow = ((workFromFormindex1.level + (datCalc.datGetParam(workFromFormindex1, 0) * 0.8f)) * waza / 20) * hpModifier;

                //double defPow = datCalc.datGetParam(workFromFormindex2, 3);

                var atkBuff = nbCalc.nbGetHojoRitu(sformindex, 4);
                var defBuff = nbCalc.nbGetHojoRitu(dformindex, 7);
                if (nskill == 475 && defBuff < 1) defBuff = 1; 

                atkPow *= atkBuff * defBuff;
                //defPow /= atkBuff * defBuff;

                __result = Convert.ToInt32(atkPow);
                return false;
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetMagicAttack))]
        private class MagicAttackPatch
        {
            public static bool Prefix(ref int nskill, ref int sformindex, ref int dformindex, ref int waza, ref int __result)
            {
                datUnitWork_t workFromFormindex1 = nbMainProcess.nbGetUnitWorkFromFormindex(sformindex);
                //datUnitWork_t workFromFormindex2 = nbMainProcess.nbGetUnitWorkFromFormindex(dformindex);

                if (nskill == 490)
                    waza = waza * Math.Min(4, (workFromFormindex1.maxhp / workFromFormindex1.hp));

                double atkPow = (workFromFormindex1.level + (datCalc.datGetParam(workFromFormindex1, 1) * 0.8f)) * waza / 20;

                //double defPow = datCalc.datGetParam(workFromFormindex2, 3);

                var atkBuff = nbCalc.nbGetHojoRitu(sformindex, 5);
                var defBuff = nbCalc.nbGetHojoRitu(dformindex, 7);

                atkPow *= atkBuff * defBuff;
                //defPow /= atkBuff * defBuff;

                __result = Convert.ToInt32(atkPow);
                return false;
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetMagicKaifuku))]
        private class MagicKaifukuPatch
        {
            public static bool Prefix(ref int nskill, ref int sformindex, ref int dformindex, ref int waza, ref int __result)
            {
                datUnitWork_t workFromFormindex1 = nbMainProcess.nbGetUnitWorkFromFormindex(sformindex);

                double magicPow = (workFromFormindex1.level + (datCalc.datGetParam(workFromFormindex1, 2) * 1.6f)) * waza * 1.25 / 10f;

                var magicBuff = nbCalc.nbGetHojoRitu(sformindex, 5);

                magicPow *= magicBuff;

                __result = Convert.ToInt32(magicPow);
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
                else if (flag == 11 || flag == 29 || data.encno == 1270 || data.encno == 1272 || data.encno == 1273)
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

                    double chance = Math.Min(90, (72 + (level * 2) + ((agi * 4) + (luk * 3)) * 0.4f) - ((lvAvg * 2) + ((avgAgi * 4) + (avgLuk * 3)) * 0.4f));
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

                double chance = 12 * ((lvAvg + (avgAgi + (avgLuk * 2)) * 0.4f) / (level + (agi + (luk * 2)) * 0.4f));
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
                //if (GuaranteeEscape.Value == true)
                //{
                //    __result = 1;
                //    return false;
                //}

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

                bool hasResistOrImmunityPassive = false;
                if (datSkill.tbl[nskill].skillattr >= 0)
                {
                    foreach (var passive in resistPassives[datSkill.tbl[nskill].skillattr])
                    {
                        if (hasResistOrImmunityPassive)
                            break;
                        if (datCalc.datCheckSyojiSkill(workFromFormindex2, passive) != 0)
                            hasResistOrImmunityPassive = true;
                    }
                    foreach (var passive in immunityPassives[datSkill.tbl[nskill].skillattr])
                    {
                        if (hasResistOrImmunityPassive)
                            break;
                        if (datCalc.datCheckSyojiSkill(workFromFormindex2, passive) != 0)
                            hasResistOrImmunityPassive = true;
                    }
                }

                if (isWeak && !hasResistOrImmunityPassive &&
                    !(datNormalSkill.tbl[nskill].koukatype == 0 && nbMainProcess.nbGetPartyFromFormindex(dformindex).count[14] != 0) &&
                    !(datNormalSkill.tbl[nskill].koukatype == 1 && nbMainProcess.nbGetPartyFromFormindex(dformindex).count[13] != 0) &&
                    !(datSkill.tbl[nskill].skillattr == 6 && nbMainProcess.nbGetPartyFromFormindex(dformindex).count[12] != 0) &&
                    !(datSkill.tbl[nskill].skillattr == 7 && nbMainProcess.nbGetPartyFromFormindex(dformindex).count[11] != 0))
                    __result = 2; // Weak hit
                else
                    __result = 0; // Normal hit

                if ((workFromFormindex2.badstatus == 4 || // If target is asleep
                    (datSkill.tbl[nskill].skillattr == 1 && workFromFormindex2.badstatus == 64) || // If attack is fire and target is poisoned
                    (datSkill.tbl[nskill].skillattr == 2 && workFromFormindex2.badstatus == 256) || // If attack is ice and target is stunned
                    (datSkill.tbl[nskill].skillattr == 3 && workFromFormindex2.badstatus == 32) || // If attack is elec and target is muted
                    (datSkill.tbl[nskill].skillattr == 4 && workFromFormindex2.badstatus == 8) || // If attack is force and target is panicked
                    ((datNormalSkill.tbl[nskill].koukatype == 0 || (dds3GlobalWork.DDS3_GBWK.heartsequip == 13 && sformindex <= 3 && (datSkill.tbl[nskill].skillattr == 3 || datSkill.tbl[nskill].skillattr == 4) && workFromFormindex2.badstatus == 2)) && 
                    (workFromFormindex2.badstatus == 1 || workFromFormindex2.badstatus == 2))) // If attack is str-based or Storm Shatter is active and target is shocked or frozen
                    && (datNormalSkill.tbl[nskill].hptype == 1 || datNormalSkill.tbl[nskill].hptype == 6 || datNormalSkill.tbl[nskill].hptype == 12 || datNormalSkill.tbl[nskill].hptype == 14))
                    __result = 1; // Critical hit
                else if (!(new uint[] { 65536, 131072, 262144 }.Contains(aisyo) || datCalc.datCheckSyojiSkill(workFromFormindex2, 372) != 0)) // If target isn't immune or doesn't have Firm Stance
                {
                    // Kagutsuchi's Sear cannot randomly crit
                    if (nskill == 172 || nskill == 173)
                    {
                        __result = 0;
                        return false;
                    }

                    var critRate = datNormalSkill.tbl[nskill].criticalpoint;
                    if (nskill == 0)
                    {
                        if ((datCalc.datCheckSyojiSkill(workFromFormindex1, 300) != 0 && evtMoon.evtGetAgeOfMoon() == 8) ||
                            (datCalc.datCheckSyojiSkill(workFromFormindex1, 301) != 0 && evtMoon.evtGetAgeOfMoon() == 0))
                            critRate = 50;
                        else if (datCalc.datCheckSyojiSkill(workFromFormindex1, 299) != 0 || (workFromFormindex1.id == 111 || workFromFormindex1.id == 335))
                            critRate = 30;
                    }

                    sbyte skillAttr = datSkill.tbl[nskill].skillattr;
                    if (!new ushort[] { 0, 2, 3, 11 }.Contains(datNormalSkill.tbl[nskill].hptype))
                    {
                        // Mara's Unlimited Desire
                        if ((workFromFormindex1.id == 186 || workFromFormindex1.id == 321) && datNormalSkill.tbl[nskill].koukatype == 0 && nbMainProcess.nbGetPartyFromFormindex(sformindex).count[4] >= 3)
                            critRate = 100;
                        // Crit enabling innates
                        if (critEnablerUsers.Keys.Contains(skillAttr))
                        {
                            if (actionProcessData.partyindex <= 3)
                            {
                                foreach (var ally in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3))
                                {
                                    try
                                    {
                                        if (critEnablerUsers[skillAttr].Contains(nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id) ||
                                            (skillAttr == 1 && ally.formindex == 0 && nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id == 0 && dds3GlobalWork.DDS3_GBWK.heartsequip == 15) ||
                                            (skillAttr == 3 && ally.formindex == 0 && nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id == 0 && dds3GlobalWork.DDS3_GBWK.heartsequip == 22) ||
                                            (skillAttr == 5 && ally.formindex == 0 && nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id == 0 && dds3GlobalWork.DDS3_GBWK.heartsequip == 16))
                                            critRate = Math.Max(critRate, (short) 10);
                                    }
                                    catch { }
                                }
                            }
                            else
                            {
                                foreach (var enemy in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex > 3))
                                {
                                    try
                                    {
                                        if (critEnablerUsers[skillAttr].Contains(nbMainProcess.nbGetUnitWorkFromFormindex(enemy.formindex).id))
                                            critRate = Math.Max(critRate, (short) 10);
                                    }
                                    catch { }
                                }
                            }
                        }
                        // Lakshmi's Chanchala
                        if (skillAttr >= 1 && skillAttr <= 4 && nbMainProcess.nbGetPartyFromFormindex(sformindex).count[5] >= 3)
                        {
                            if (actionProcessData.partyindex <= 3)
                            {
                                foreach (var ally in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3))
                                {
                                    try
                                    {
                                        if (nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id == 7)
                                            critRate = Math.Max(critRate, (short) 10);
                                    }
                                    catch { }
                                }
                            }
                            else
                            {
                                foreach (var enemy in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex > 3))
                                {
                                    try
                                    {
                                        if (nbMainProcess.nbGetUnitWorkFromFormindex(enemy.formindex).id == 7)
                                            critRate = Math.Max(critRate, (short) 10);
                                    }
                                    catch { }
                                }
                            }
                        }
                        // Destabilize
                        if (skillAttr >= 1 && skillAttr <= 4)
                        {
                            foreach (var demon in nbMainProcess.nbGetMainProcessData().party)
                            {
                                try
                                {
                                    if (nbMainProcess.nbGetUnitWorkFromFormindex(demon.formindex).id == 113
                                        || (demon.formindex == 0 && nbMainProcess.nbGetUnitWorkFromFormindex(demon.formindex).id == 0 && dds3GlobalWork.DDS3_GBWK.heartsequip == 14))
                                        critRate = Math.Max(critRate, (short)10);
                                }
                                catch { }
                            }
                        }
                        // Deathly Affliction
                        if (workFromFormindex2.badstatus != 0 && critRate > 0)
                        {
                            bool deathlyAfflictionActive = false;

                            if (actionProcessData.partyindex <= 3)
                            {
                                foreach (var ally in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3))
                                {
                                    try
                                    {
                                        if (deathlyAfflictionIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id))
                                            deathlyAfflictionActive = true;
                                    }
                                    catch { }
                                }
                            }
                            else
                            {
                                foreach (var enemy in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex > 3))
                                {
                                    try
                                    {
                                        if (deathlyAfflictionIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(enemy.formindex).id))
                                            deathlyAfflictionActive = true;
                                    }
                                    catch { }
                                }
                            }

                            if (deathlyAfflictionActive) critRate += 20;
                        }
                    }
                    // Specter's Phantasmagoria
                    if (new ushort[] { 185, 257, 273, 275, 294, 295, 296 }.Contains(workFromFormindex1.id) &&
                        datSkill.tbl[nskill].skillattr <= 12 && 
                        (workFromFormindex1.param[2] + workFromFormindex1.mitamaparam[2]) > (workFromFormindex2.param[2] + workFromFormindex2.mitamaparam[2]))
                        critRate += 10;
                    // Hell Biker's Speed Star
                    if ((workFromFormindex1.id == 200 || workFromFormindex1.id == 350) &&
                        datSkill.tbl[nskill].skillattr <= 12 && 
                        (workFromFormindex1.param[4] + workFromFormindex1.mitamaparam[4]) > (workFromFormindex2.param[4] + workFromFormindex2.mitamaparam[4]))
                        critRate += 10;
                    // Seth's Covetous Fury
                    if ((workFromFormindex1.id == 230 || workFromFormindex1.id == 248) && datSkill.tbl[nskill].skillattr <= 12)
                    {
                        var covetousFuryActive = false;

                        for (int i = 0; i<= 5; i++)
                            if ((workFromFormindex1.param[i] + workFromFormindex1.mitamaparam[i]) < (workFromFormindex2.param[i] + workFromFormindex2.mitamaparam[i]))
                                covetousFuryActive = true;

                        if (covetousFuryActive) critRate += 10;
                    }
                    // Focused Assault
                    if (((sformindex == 0 && workFromFormindex1.id == 0 && dds3GlobalWork.DDS3_GBWK.heartsequip == 1) || focusedAssaultIds.Contains(workFromFormindex1.id)) && 
                        datNormalSkill.tbl[nskill].targetarea == 2 && 
                        datNormalSkill.tbl[nskill].targettype == 0 &&
                        previousSingleTargetFormIndex == dformindex &&
                        critRate > 0)
                    {
                        critRate += 20;
                    }

                    var luk = datCalc.datGetParam(workFromFormindex1, 5);
                    var lukMultiplier = 1 + ((float)luk / 250);
                    var critChance = critRate * lukMultiplier;

                    var rand = dds3KernelCore.dds3GetRandIntA(100);
                    __result = rand < critChance ? 1 : __result;
                }

                // Double Attack
                if (__result == 1 && nskill == 0 && datCalc.datCheckSyojiSkill(workFromFormindex1, 308) != 0)
                    nbMainProcess.nbPushAction(4, sformindex, dformindex, 167);

                if (__result == 2 && faithfulCompanionIds.Contains(workFromFormindex1.id))
                {
                    faithfulCompanionActive = true;
                    faithfulCompanionActive2 = true;
                }

                // Baal Avatar's Condemn Weakness
                if (__result == 0 && workFromFormindex1.id == 288 && workFromFormindex2.badstatus == 512)
                {
                    __result = 2;
                    nbHelpProcess.nbDispText("Condemn Weakness", string.Empty, 2, 45, 2315190144, false);
                }

                // Mitra's Righteous Vow
                if ((__result == 1 || __result == 2) && (workFromFormindex2.id == 2 || workFromFormindex2.id == 329) &&
                    !((datSkill.tbl[nskill].skillattr == 6 && nbMainProcess.nbGetPartyFromFormindex(dformindex).count[12] != 0) || (datSkill.tbl[nskill].skillattr == 7 && nbMainProcess.nbGetPartyFromFormindex(dformindex).count[11] != 0)))
                {
                    postSummonSkillName = "Righteous Vow";
                    PostSummonSkillCopy(459, 64, 0);
                    nbMainProcess.nbPushAction(4, nbMainProcess.nbGetPartyFromFormindex(dformindex).partyindex, nbMainProcess.nbGetPartyFromFormindex(dformindex).partyindex, 408);
                }

                return false;
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetKoukaType))]
        private class GetKoukaTypePatch
        {
            public static void Postfix(ref int nskill, ref int sformindex, ref int dformindex, ref int __result)
            {
                //if (nskill == 255)
                if (__result == 6)
                    return;

                if (nskill == 201 || nskill >= 505 || datSkill.tbl[nskill].skillattr == 13 || datSkill.tbl[nskill].skillattr == 14)
                {
                    __result = 0;
                    return;
                }    

                datUnitWork_t workFromFormindex1 = nbMainProcess.nbGetUnitWorkFromFormindex(sformindex);
                datUnitWork_t workFromFormindex2 = nbMainProcess.nbGetUnitWorkFromFormindex(dformindex);

                // Kagutsuchi's Infinite Light is drained by Kagutsuchi
                if (nskill == 221 && workFromFormindex1.id == 264 && workFromFormindex2.id == 264)
                {
                    __result = 2;
                }

                // Lucifer's Dawn of Demise
                if (workFromFormindex1.id == 344 && (__result == 1 || __result == 2))
                {
                    __result = 3;
                }

                // Mitra's Verdict
                try
                {
                    if (nbMainProcess.nbGetUnitWorkFromFormindex(sformindex).id == 329 && nbMainProcess.nbGetUnitWorkFromFormindex(dformindex).id == 0 && nskill == 495)
                    {
                        nbMainProcess.nbGetUnitWorkFromFormindex(dformindex).badstatus = 32768;
                        nbHelpProcess.nbDispText(frName.frGetCNameString(0) + " is cursed!", string.Empty, 2, 45, 2315190144, false);
                        __result = 0;
                    }
                } catch { }
                

                if (__result == 0 || __result == 4) // Hit or Miss
                {
                    // Scathach's Warrior Trainer
                    if (workFromFormindex1.id == 8 && nskill != 0)
                    {
                        bool warriorTrainerActive = false;

                        if (nbMainProcess.nbGetPartyFromFormindex(sformindex).partyindex <= 3)
                        {
                            foreach (var ally in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3))
                            {
                                try
                                {
                                    if (new ushort[] { 56, 147 }.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id))
                                        warriorTrainerActive = true;
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            foreach (var enemy in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex > 3))
                            {
                                try
                                {
                                    if (new ushort[] { 56, 147 }.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(enemy.formindex).id))
                                        warriorTrainerActive = true;
                                }
                                catch { }
                            }
                        }

                        if (warriorTrainerActive && SkillPotentialUtility.GetSkillPotential(nskill, currentDemonWork.id) > 0)
                        {
                            __result = 0; // Hit
                            return;
                        }
                    }
                    // Mother Harlot's Indlugence
                    if ((workFromFormindex1.id == 202 || workFromFormindex1.id == 352) && workFromFormindex2.badstatus != 0 && nskill != 0 && SkillPotentialUtility.GetSkillPotential(nskill, currentDemonWork.id) > 0)
                    {
                        __result = 0; // Hit
                        return;
                    }
                    // Guaranteed hit against enemies affected by certain status or if the target has Firm Stance
                    else if (datNormalSkill.tbl[nskill].hitlevel == 255 ||
                        workFromFormindex2.badstatus == 1 || // Shocked
                        workFromFormindex2.badstatus == 2 || // Frozen
                        workFromFormindex2.badstatus == 4 || // Asleep
                        workFromFormindex2.badstatus == 16 || // Bound
                        workFromFormindex2.badstatus == 256 || // Stunned
                        workFromFormindex2.badstatus == 1024 || // Petrified
                        datCalc.datCheckSyojiSkill(workFromFormindex2, 372) != 0)
                    {
                        __result = 0; // Hit
                        return;
                    }

                    float chance = 0;

                    var userLevel = workFromFormindex1.level;
                    var userAgi = datCalc.datGetParam(workFromFormindex1, 4);
                    var userLuk = datCalc.datGetParam(workFromFormindex1, 5);

                    var targetLevel = workFromFormindex2.level;
                    var targetAgi = datCalc.datGetParam(workFromFormindex2, 4);
                    var targetLuk = datCalc.datGetParam(workFromFormindex2, 5);

                    if (datNormalSkill.tbl[nskill].koukatype == 0)
                    {
                        var userStr = datCalc.datGetParam(workFromFormindex1, 0);

                        chance = (datNormalSkill.tbl[nskill].hitlevel - datNormalSkill.tbl[nskill].failpoint)
                        + ((userLevel / 2) + ((userStr/2) + (userAgi * 2) + userLuk) * 0.4f)
                        - ((targetLevel / 2) + ((targetAgi * 2) + targetLuk) * 0.4f);
                    }
                    else if (datNormalSkill.tbl[nskill].koukatype == 1)
                    {
                        var userInt = datCalc.datGetParam(workFromFormindex1, 1);

                        chance = datNormalSkill.tbl[nskill].hitlevel
                        + ((userLevel / 2) + (userInt + (userAgi * 2) + userLuk) * 0.4f)
                        - ((targetLevel / 2) + ((targetAgi * 2) + targetLuk) * 0.4f);
                    }

                    // Deathly Affliction
                    if (workFromFormindex2.badstatus != 0)
                    {
                        bool deathlyAfflictionActive = false;

                        if (actionProcessData.partyindex <= 3)
                        {
                            foreach (var ally in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3))
                            {
                                try
                                {
                                    if (deathlyAfflictionIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id))
                                        deathlyAfflictionActive = true;
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            foreach (var enemy in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex > 3))
                            {
                                try
                                {
                                    if (deathlyAfflictionIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(enemy.formindex).id))
                                        deathlyAfflictionActive = true;
                                }
                                catch { }
                            }
                        }

                        if (deathlyAfflictionActive) chance += 30;
                    }
                    // Helmsman
                    if (previousUnitId != 0 && helmsmanActive && helmsmanIds.Contains(previousUnitId))
                    {
                        chance += 30;
                    }
                    // Focused Assault
                    if (((sformindex == 0 && workFromFormindex1.id == 0 && dds3GlobalWork.DDS3_GBWK.heartsequip == 1) || focusedAssaultIds.Contains(workFromFormindex1.id)) &&
                        datNormalSkill.tbl[nskill].targetarea == 2 &&
                        datNormalSkill.tbl[nskill].targettype == 0 &&
                        previousSingleTargetFormIndex == dformindex)
                    {
                        chance += 20;
                    }

                    var accuracyBuff = nbCalc.nbGetHojoRitu(sformindex, 8);
                    var evasionBuff = nbCalc.nbGetHojoRitu(dformindex, 6);
                    if (nskill == 475 && evasionBuff < 1) evasionBuff = 1;

                    chance = chance * accuracyBuff * evasionBuff;
                    if (workFromFormindex1.badstatus == 256)
                        chance /= (float) 1.5;
                    var rand = dds3KernelCore.dds3GetRandIntA(100);
                    __result = rand < chance ? 0 : 4;
                }

                // Matador's Estocada
                if (__result != 0 && __result <= 4 && (workFromFormindex2.id == 199 || workFromFormindex2.id == 349) && random.Next(2) == 0)
                    nbMainProcess.nbPushAction(4, nbMainProcess.nbGetPartyFromFormindex(dformindex).partyindex, nbMainProcess.nbGetPartyFromFormindex(sformindex).partyindex, 403);

                // Ahriman's Silencing Bellow
                if (__result == 0 && (workFromFormindex2.id == 244 || workFromFormindex2.id == 258) && random.Next(2) == 0)
                    nbMainProcess.nbPushAction(4, nbMainProcess.nbGetPartyFromFormindex(dformindex).partyindex, nbMainProcess.nbGetPartyFromFormindex(sformindex).partyindex, 142);

                // Noah's Aurora
                if (__result == 0 && (workFromFormindex2.id == 246 || workFromFormindex2.id == 259 || workFromFormindex2.id == 292) && random.Next(4) != 0)
                    nbMainProcess.nbPushAction(4, nbMainProcess.nbGetPartyFromFormindex(dformindex).partyindex, nbMainProcess.nbGetPartyFromFormindex(dformindex).partyindex, 234);
            }
        }

        //[HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetExpMakaItem))]
        //private class GetExpMakaItemPatch
        //{
        //    public static void Prefix(ref datUnitWork_t w)
        //    {
        //        var luk = datCalc.datGetParam(nbMainProcess.nbGetUnitWorkFromFormindex(0), 5);
        //        var lukMultiplier = 1 + ((float)luk / 100);

        //        tmp_dropPoint = datDevilFormat.tbl[w.id].droppoint;

        //        for (int i = 0; i < datDevilFormat.tbl[w.id].droppoint.Length; i++)
        //        {
        //            datDevilFormat.tbl[w.id].droppoint[i] = Convert.ToByte(datDevilFormat.tbl[w.id].droppoint[i] * lukMultiplier);
        //        }
        //    }

        //    public static void Postfix(ref datUnitWork_t w)
        //    {
        //        datDevilFormat.tbl[w.id].droppoint = tmp_dropPoint;
        //    }
        //}

        #endregion nbCalc
    }
}