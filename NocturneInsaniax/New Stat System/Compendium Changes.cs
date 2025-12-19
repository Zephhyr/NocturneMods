using HarmonyLib;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2Cppkernel_H;
using Il2Cppnewdata_H;
using Il2CppTMPro;
using MelonLoader;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        private static bool ShowFusionStats = false;
        public static short currentRecord;
        private static short listWindowCursorPos = 0;
        private static Il2CppStructArray<short> pelemList;
        public const float limitDiscount = 50f; // What the discount scales towards the closer you get to 100% compendium completion
        public const float finalDiscount = 50f; // Discount once the compendium is completed

        private static void ApplyMitamaFusionChanges()
        {
            // If enabled, alter the Mitama fusion bonuses.
            if (EnableIntStat)
            {
                // Mitama Bonuses
                fclCombineTable.fclSpiritParamUpTbl[3].ParamType = fclCombineTable.fclSpiritParamUpTbl[3].ParamType.Append<ushort>(3).ToArray(); // Saki  -> Mag
                fclCombineTable.fclSpiritParamUpTbl[2].ParamType = fclCombineTable.fclSpiritParamUpTbl[2].ParamType.Append<ushort>(1).ToArray(); // Kushi  -> Str
                fclCombineTable.fclSpiritParamUpTbl[1].ParamType = fclCombineTable.fclSpiritParamUpTbl[1].ParamType.Append<ushort>(2).ToArray(); // Nigi  -> Int
                fclCombineTable.fclSpiritParamUpTbl[0].ParamType = fclCombineTable.fclSpiritParamUpTbl[0].ParamType.Append<ushort>(2).ToArray(); // Ara   -> Int
            }
        }

        private class CompendiumPriceHelper
        {
            public static int GetPrice(fclencyceelem_t pelem)
            {
                // If the unit is null, return nothing.
                if (pelem == null)
                { return 0; }

                // If the unit is either Dante or Raidou, return 0.
                if (pelem.id == 191 || pelem.id == 192)
                { return 0; }

                // Summoning price formula with applied discount
                return (int)((double)GetBasePrice(pelem) * (double)GetDiscountFactor(limitDiscount, finalDiscount));
            }

            public static int GetBasePrice(fclencyceelem_t pelem)
            {

                // If the unit is null, return nothing.
                if (pelem == null)
                { return 0; }

                // If the unit is either Dante or Raidou, return 0.
                if (pelem.id == 191 || pelem.id == 192)
                { return 0; }

                // Grab unit's stats
                int exp = (int)pelem.exp;
                int lvl = (int)pelem.level;
                int str = (int)pelem.param[0] + (int)pelem.mitamaparam[0];
                int intStat = (EnableIntStat ? (int)pelem.param[1] + (int)pelem.mitamaparam[1] : 0);
                int mag = (int)pelem.param[2] + (int)pelem.mitamaparam[2];
                int vit = (int)pelem.param[3] + (int)pelem.mitamaparam[3];
                int agi = (int)pelem.param[4] + (int)pelem.mitamaparam[4];
                int luc = (int)pelem.param[5] + (int)pelem.mitamaparam[5];

                // Return the following result
                return (int)(Math.Pow((double)(str + mag + vit + agi + luc + intStat) / (EnableStatScaling ? (EnableIntStat ? (double)STATS_SCALING + (double)STATS_SCALING / 6d : (double)STATS_SCALING) : 1d), 2) * 5d);
            }

            // Discount calculator
            public static float GetDiscountFactor(float limitDiscount, float finalDiscount)
            {
                int compendiumProgress = fclEncyc.fclEncycGetRatio2();
                float discountFactor;

                if (compendiumProgress < 100)
                { discountFactor = 1 - (compendiumProgress * limitDiscount) / (100f * 100f); }
                else
                {
                    discountFactor = 1 - (compendiumProgress * finalDiscount) / (100f * 100f);
                    discountFactor *= 2; // To counteract the 50% discount of the vanilla game when the compendium is completed
                }

                return discountFactor;
            }
        }

        public static float GetDiscountFactor(float limitDiscount = 50f, float finalDiscount = 80f)
        {
            int compendiumProgress = fclEncyc.fclEncycGetRatio2();
            float discountFactor;

            if (compendiumProgress < 100)
            {
                discountFactor = 1 - (compendiumProgress * limitDiscount) / (100f * 100f);
            }
            else
            {
                discountFactor = 1 - (compendiumProgress * finalDiscount) / (100f * 100f);
                discountFactor *= 2;
            }

            return discountFactor;
        }

        public static float GetDiscountFactor(int race, float limitDiscount = 50f, float finalDiscount = 80f)
        {
            float discountFactor = GetDiscountFactor();

            if (race == 7)
                discountFactor *= 2f;
            else if (race == 8)
                discountFactor *= 2.5f;

            return discountFactor;
        }

        [HarmonyPatch(typeof(fclEncyc), nameof(fclEncyc.GetNakamaMax))]
        private class GetNakamaMaxPatch
        {
            public static void Postfix(ref int __result)
            {
                __result = 200;
            }
        }

        [HarmonyPatch(typeof(frFont), nameof(frFont.frReplaceLocalizeText))]
        private class PatchCompendiumConfirmText
        {
            public static void Postfix(ref string __result)
            {
                // Grab the current record unit and set its price for this particular menu segment.
                fclencyceelem_t pelem = dds3GlobalWork.DDS3_GBWK.encyc_record.pelem[currentRecord];
                int macca = CompendiumPriceHelper.GetPrice(pelem);

                // Replace Mido's text to display the correct price when enough macca
                if (__result.Contains("<SP7><FO1>It will cost <CO4>") && __result.Contains("Are you okay with that?"))
                { __result = "<SP7><FO1>It will cost <CO4>" + macca + " Macca. <CO0>Are you okay with that?"; }

                // Replace Mido's text to display the correct price when not enough macca
                else if (__result.Contains("<SP7><FO1>It will cost <CO4>") && __result.Contains("But it seems you don't have enough."))
                { __result = "<SP7><FO1>It will cost <CO4>" + macca + " Macca... <CO0>But it seems you don't have enough."; }

                else if (__result.Contains("Naturally, the stronger the demon, the more it will cost."))
                    __result += " The cost will be discounted based on how many demons you have registered.";
            }
        }

        [HarmonyPatch(typeof(fclCombineCalc), nameof(fclCombineCalc.cmbAddBirthDevilToStock))]
        private class PatchCombineCalcSequence
        {
            private static void Postfix(ref Il2CppReferenceArray<datUnitWork_t> pStock, int top, byte StockNums)
            {
                // Why this function use an array of demons is confusing imo, but I'm not gonna worry about it.
                for (int i = 0; i < pStock.Length; i++)
                {
                    // Distributes Levelup points added by Sacrificial Fusion (hopefully).
                    for (int j = 0; j < pStock[i].param.Length; j++)
                    {
                        pStock[i].param[j] += pStock[i].levelupparam[j];
                        pStock[i].levelupparam[j] = 0;
                    }

                    // Recalculate HP/MP.
                    pStock[i].maxhp = (ushort)datCalc.datGetMaxHp(pStock[i]);
                    pStock[i].maxmp = (ushort)datCalc.datGetMaxMp(pStock[i]);
                }
            }
        }

        [HarmonyPatch(typeof(fclCombineCalcCore), nameof(fclCombineCalcCore.cmbCalcIkenieExp))]
        private class PatchCalcSacrificialFusionEXP
        {
            private static bool Prefix(datUnitWork_t pStock, datUnitWork_t pDevil1, datUnitWork_t pDevil2, datUnitWork_t pSacrifice)
            {
                // Calculate the Sacrificed Demon's EXP, multiplied by 1.5x, then add it to the current Demon's EXP total.
                uint newExp = (uint)((float)pSacrifice.exp * 1.5f) + rstCalcCore.cmbCalcLevelUpExp(ref pStock, pStock.level);

                // Calculate the new Level of the current Demon.
                // Also, cap it at 255, we don't need to do the game's really wonky math it was doing.
                int levelUpCount = rstCalcCore.cmbGetLevelUpCount(ref pStock, (int)newExp);
                int newLevel = levelUpCount + pStock.level > 255 ? 255 : levelUpCount + pStock.level;

                // This is a list of Stats it needs to check.
                bool[] paramChecks = { false, false, false, false, false, false };

                // Change the list's values to true if that Stat is capped.
                int i = 0;
                for (i = 0; i < paramChecks.Length; i++)
                {
                    if (datCalc.datGetBaseParam(pStock, i) >= MAXSTATS)
                    { paramChecks[i] = true; }
                }

                // If there's at least 1 Level Up in total.
                i = 0;
                if (levelUpCount > 0)
                {
                    // Loop through the number of LevelUps, multiplied by Points Per Level.
                    do
                    {
                        // If your stats are completely capped out.
                        if (EnableIntStat &&
                            paramChecks[0] == true &&
                            paramChecks[1] == true &&
                            paramChecks[2] == true &&
                            paramChecks[3] == true &&
                            paramChecks[4] == true &&
                            paramChecks[5] == true)
                        { break; }
                        if (!EnableIntStat &&
                            paramChecks[0] == true &&
                            paramChecks[2] == true &&
                            paramChecks[3] == true &&
                            paramChecks[4] == true &&
                            paramChecks[5] == true)
                        { break; }

                        // Grab a random Parameter ID.
                        int paramID = rstCalcCore.cmbAddLevelUpParamEx(ref pStock, 1);

                        // If within the correct Parameter ID ranges and not capped, increment both the Stat and the LevelUp Counter.
                        if (paramID > -1 && paramID < 6 && datCalc.datGetBaseParam(pStock, paramID) < MAXSTATS)
                        {
                            pStock.levelupparam[paramID]++;
                            i++;
                            if (datCalc.datGetBaseParam(pStock, paramID) >= MAXSTATS)
                            { paramChecks[paramID] = true; }
                        }
                    }
                    while (i < (EnableStatScaling ? levelUpCount * POINTS_PER_LEVEL : levelUpCount));
                }

                // Flag Nonsense.
                pStock.flag |= 0x200;

                // Set the Demon's Level to the new value.
                pStock.level = (ushort)newLevel;
                pStock.exp = newExp;

                // If the Demon's Level is 255, change their EXP.
                if (pStock.level == 255)
                { pStock.exp = rstCalcCore.cmbCalcLevelUpExp(ref pStock, 255); }

                return false;
            }
        }

        [HarmonyPatch(typeof(fclCombineDraw), nameof(fclCombineDraw.cmbDraw1stDevilSelect))]
        private class PatchCalcFusionFirstDemon
        {
            private static void Prefix()
            {
                // Check if you're viewing the first fusion fodder Demon.
                GameObject g = GameObject.Find("campUIBase/statusUI(Clone)/comstatus_parts/commode/commode_menu/commode01");
                if (g == null)
                { ShowFusionStats = false; return; }

                // If you are, don't show the resulting Fusion's stats.
                if (g.activeSelf && GameObject.Find("campUIBase/statusUI(Clone)/comstatus_parts/commode/commode_menu/commode01/dlistsort_baseon01").activeSelf)
                { ShowFusionStats = false; }
            }
        }

        [HarmonyPatch(typeof(fclCombineDraw), nameof(fclCombineDraw.cmbDraw2ndDevilSelect))]
        private class PatchCalcFusionSecondDemon
        {
            private static void Prefix()
            {
                // Check if you're viewing the second fusion fodder Demon.
                GameObject g = GameObject.Find("campUIBase/statusUI(Clone)/comstatus_parts/commode/commode_menu/commode02");
                if (g == null)
                { ShowFusionStats = false; return; }

                // If you are, don't show the resulting Fusion's stats.
                if (g.activeSelf && GameObject.Find("campUIBase/statusUI(Clone)/comstatus_parts/commode/commode_menu/commode02/dlistsort_baseon01").activeSelf)
                { ShowFusionStats = false; }
            }
        }

        [HarmonyPatch(typeof(fclCombineDraw), nameof(fclCombineDraw.cmbDrawSacDevilSelect))]
        private class PatchCalcFusionSacrificeDemon
        {
            private static void Prefix()
            {
                // Check if you're viewing the Sacrificial Fusion fodder Demon.
                GameObject g = GameObject.Find("campUIBase/statusUI(Clone)/comstatus_parts/commode/commode_menu/commode03");
                GameObject g2 = GameObject.Find("campUIBase/statusUI(Clone)/comstatus_parts/commode/commode_menu/commode04");
                if (g == null || g2 == null)
                { ShowFusionStats = false; return; }

                // If you are, don't show the resulting Fusion's stats.
                if (g.activeSelf && GameObject.Find("campUIBase/statusUI(Clone)/comstatus_parts/commode/commode_menu/commode03/dlistsort_baseon01").activeSelf && g2.activeSelf)
                { ShowFusionStats = false; }
            }
        }

        [HarmonyPatch(typeof(fclCombineDraw), nameof(fclCombineDraw.cmbDrawBirthDevil))]
        private class PatchCalcFusionResultDemon
        {
            private static void Prefix()
            {
                // Check if you're viewing the fusion result Demon during a Sacrificial Fusion.
                GameObject g = GameObject.Find("campUIBase/statusUI(Clone)/comstatus_parts/commode/commode_menu/commode03");
                GameObject g2 = GameObject.Find("campUIBase/statusUI(Clone)/comstatus_parts/commode/commode_menu/commode04");
                if (g == null || g2 == null)
                { ShowFusionStats = false; return; }

                // If you are, show its stats.
                if (g2.activeSelf && GameObject.Find("campUIBase/statusUI(Clone)/comstatus_parts/commode/commode_menu/commode04/dlistsort_baseon01").activeSelf)
                { ShowFusionStats = true; }

                // If this isn't Sacrificial Fusion, show its stats in another location.
                else if (g.activeSelf && GameObject.Find("campUIBase/statusUI(Clone)/comstatus_parts/commode/commode_menu/commode03/dlistsort_baseon01").activeSelf && !g2.activeSelf)
                { ShowFusionStats = true; }

                // If neither, don't show its stats.
                else
                { ShowFusionStats = false; }
            }
        }

        [HarmonyPatch(typeof(fclEncyc), nameof(fclEncyc.GetDevilParam))]
        private class PatchGetCompendiumDemonParam
        {
            // Returns a Compendium Demon's stat, making sure to cap it appropriately.
            private static bool Prefix(out int __result, fclencyceelem_t pelem, int type)
            {
                ShowFusionStats = false;
                __result = pelem.param[type] + pelem.levelupparam[type] + pelem.mitamaparam[type] < MAXSTATS ? pelem.param[type] + pelem.levelupparam[type] + pelem.mitamaparam[type] : MAXSTATS;
                return false;
            }
        }

        [HarmonyPatch(typeof(lstListWindow), nameof(lstListWindow.lstMoveCursor))]
        private class PatchMoveListWindowCursor
        {
            // Grabs the current List Window's Cursor Position.
            // Needed for later.
            private static void Postfix(lstListWindow_t pListWindow, sbyte Dir)
            { listWindowCursorPos = (short)pListWindow.CursorInfo.CursorPos.Index; }
        }

        [HarmonyPatch(typeof(fclEncyc), nameof(fclEncyc.CalcPhaseReadTop))]
        private class PatchSortListWindow
        {
            // Grabs the current Sorting Method.
            // Needed for later.
            private static void Postfix(fclEncyc.instance_tag pinst)
            {
                if (pinst.sort == 0)
                { pelemList = pinst.praceindex; }
                else
                { pelemList = pinst.plevelindex; }
            }
        }

        [HarmonyPatch(typeof(CounterCtr), nameof(CounterCtr.Set))]
        private class PatchPriceCounterCtrSet
        {
            public static void Prefix(ref int val, ref CounterCtr __instance)
            {
                if (__instance.transform.GetParent().name.Contains("dlistsum_row0"))
                {
                    // Grab the current list object index.
                    int id = int.Parse(__instance.transform.GetParent().name.Replace("dlistsum_row", ""));

                    // Offset the original id with where the compendium list menu lines up.
                    short index = (short)(id - 1 + listWindowCursorPos);

                    if (pelemList == null)
                    { val = 0; return; }

                    // Grab the Compendium's Demon ID list
                    Il2CppStructArray<short> demonIDlist = pelemList;

                    // If the index overshoots the list, return 0.
                    if (index >= demonIDlist.Length)
                    { val = 0; return; }

                    // Grab the (hopefully) correct unit out of the list.
                    fclencyceelem_t pelem = dds3GlobalWork.DDS3_GBWK.encyc_record.pelem[demonIDlist[index]];

                    // If the unit isn't null.
                    if (pelem == null)
                    { val = 0; return; }

                    // Apply discount on displayed prices
                    val = CompendiumPriceHelper.GetPrice(pelem);
                }
            }
        }

        [HarmonyPatch(typeof(fclEncyc), nameof(fclEncyc.PrepSummon))]
        private class PatchPrepSummon
        {
            public static void Prefix(ref fclEncyc.readmainwork_tag pwork)
            {
                // Remember the compendium record's ID (for another function later)
                currentRecord = pwork.recindex;
            }

            public static void Postfix(ref fclEncyc.readmainwork_tag pwork, ref int __result)
            {
                // Get the unit about to be summoned
                fclencyceelem_t pelem = dds3GlobalWork.DDS3_GBWK.encyc_record.pelem[pwork.recindex];
                    

                // Get discounted price for that summon
                pwork.mak = CompendiumPriceHelper.GetPrice(pelem);

                // If enough macca post-discount but not pre-discount (and stock not full and not already in stock and something idk)
                if (pwork.mak > 0 && __result == 0 && dds3GlobalWork.DDS3_GBWK.maka >= pwork.mak && datCalc.datCheckStockFull() == 0 && datCalc.datSearchDevilStock(pelem.id) == -1 && pwork.flags == 80)
                {
                    pwork.flags = (ushort)(pwork.flags | 1);
                    __result = 1;
                }
            }
        }

        [HarmonyPatch(typeof(fclMisc), nameof(fclMisc.fclScriptStart))]
        private class PatchCompendiumPrice
        {
            public static void Prefix(ref int StartNo)
            {
                if (StartNo == 18)
                {
                    // Get the unit about to be summoned
                    var pelem = dds3GlobalWork.DDS3_GBWK.encyc_record.pelem[currentRecord];

                    // Summoning price formula with applied discount
                    int price = CompendiumPriceHelper.GetPrice(pelem);

                    // If enough macca post-discount but not pre-discount (and stock not full and not already in stock and something idk)
                    if (price > 0 && dds3GlobalWork.DDS3_GBWK.maka >= price && datCalc.datCheckStockFull() == 0 && datCalc.datSearchDevilStock(pelem.id) == -1)
                    {
                        StartNo = 17;
                    }
                }
            }
        }

        [HarmonyPatch(typeof(fclCombineUpdate), nameof(fclCombineUpdate.cmbUpdateDecideDevil))]
        private class PatchUpdateDecideDevil
        {
            private static void Postfix()
            {
                datUnitWork_t pDevil = fclCombineInit.CMB_GBWK.BirthDevil;
                for (int i = 0; i < pDevil.skillparam.Length; i++)
                {
                    pDevil.mitamaparam[i] += pDevil.skillparam[i];
                    pDevil.skillparam[i] = 0;
                }
                fclCombineInit.CMB_GBWK.BirthDevil = pDevil;
            }
        }

        [HarmonyPatch(typeof(fclCombineCalcCore), nameof(fclCombineCalcCore.cmbCalcParamPowerUp))]
        private class PatchMitamaPowerUp
        {
            private static bool Prefix(out sbyte __result, ushort MitamaID, datUnitWork_t pStock)
            {
                // Return value. You get the drill by this point.
                __result = 0;

                // Check the Mitama ID.
                int mitama = MitamaID -= 40;
                if (mitama < 0 || mitama >= 4)
                { return false; }

                // If everything's capped, return.
                if (EnableIntStat && datCalc.datGetBaseParam(pStock, 0) + pStock.mitamaparam[0] >= MAXSTATS &&
                    datCalc.datGetBaseParam(pStock, 1) + pStock.mitamaparam[1] >= MAXSTATS &&
                    datCalc.datGetBaseParam(pStock, 2) + pStock.mitamaparam[2] >= MAXSTATS &&
                    datCalc.datGetBaseParam(pStock, 3) + pStock.mitamaparam[3] >= MAXSTATS &&
                    datCalc.datGetBaseParam(pStock, 4) + pStock.mitamaparam[4] >= MAXSTATS &&
                    datCalc.datGetBaseParam(pStock, 5) + pStock.mitamaparam[5] >= MAXSTATS)
                { return false; }

                // If everything's capped and Int is disabled, return.
                // Yes I needed two checks, don't ask please.
                else if (datCalc.datGetBaseParam(pStock, 0) + pStock.mitamaparam[0] >= MAXSTATS &&
                    datCalc.datGetBaseParam(pStock, 2) + pStock.mitamaparam[2] >= MAXSTATS &&
                    datCalc.datGetBaseParam(pStock, 3) + pStock.mitamaparam[3] >= MAXSTATS &&
                    datCalc.datGetBaseParam(pStock, 4) + pStock.mitamaparam[4] >= MAXSTATS &&
                    datCalc.datGetBaseParam(pStock, 5) + pStock.mitamaparam[5] >= MAXSTATS)
                { return false; }

                // Unseeded random number generator.
                System.Random rng = new();

                // New Parameter Value
                float paramNewValue = 0;
                ushort paramID = 6;
                int fails = 0;

                for (int i = 0; i < POINTS_PER_LEVEL; i++)
                {
                    do
                    {
                        // Pull a random stat from whatever the Mitama's upgradable stat pool is.
                        paramID = (ushort)(fclCombineTable.fclSpiritParamUpTbl[3 - mitama].ParamType[rng.Next(fclCombineTable.fclSpiritParamUpTbl[3 - mitama].ParamType.Length)] - 1);

                        // If it's somehow below zero or over 5, just return here and don't continue.
                        if (paramID < 0 || paramID > 5)
                        { return false; }

                        // Check the chance of the stat upgrading and if it's greater than 1, set it to 1.
                        paramNewValue += (float)Math.Max(Math.Ceiling(((float)pStock.param[paramID] / 2f * (float)fclCombineTable.fclSpiritParamUpTbl[3 - mitama].UpRate) / 100f - ((float)pStock.param[paramID] / 2f)), 0);
                        if (paramNewValue > 0f)
                        { paramNewValue = 1f; }

                        // If it fails, increment then return false if we failed 100 times.
                        else if (fails++ >= 100)
                        { return false; }
                    }
                    while (paramNewValue < 1f);

                    // If it's under or equal to the maximum, set the Mitama Bonus.
                    if (pStock.param[paramID] + pStock.skillparam[paramID] + pStock.mitamaparam[paramID] + paramNewValue < MAXSTATS)
                    {
                        pStock.skillparam[paramID] += (sbyte)paramNewValue;
                        paramNewValue = 0;
                    }
                }

                // Return 1
                __result = 1;

                return false;
            }
        }
    }
}
