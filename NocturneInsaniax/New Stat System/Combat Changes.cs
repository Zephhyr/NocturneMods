using HarmonyLib;
using Il2Cpp;
using Il2Cppcamp_H;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2Cppnewbattle_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2CppTMPro;
using MelonLoader;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbCheckStoneDead))]
        private class PatchStoneTargetKill
        {
            private static bool Prefix(out int __result, int nskill, int dformindex)
            {
                // Result init
                __result = 0;

                // Grab the defender from its form index.
                datUnitWork_t defender = nbMainProcess.nbGetUnitWorkFromFormindex(dformindex);

                // If you're not petrified, just return.
                if ((defender.badstatus & 0xfff) != 0x400)
                { return false; }

                // Check the Skill's type and make sure it can kill petrified targets.
                // It only checks Physical, Force, and Shot Skills (Insaniax).
                bool found = false;
                foreach (int i in new int[] { 0, 4, 12 })
                {
                    if (datSkill.tbl[nskill].skillattr == i)
                    { found = true; break; }
                }

                // If it can't, return.
                if (found == false)
                { return false; }

                // Grab the user's Luc. It's actually used in the original formula.
                int luckValue = (int)((float)Math.Clamp(datCalc.datGetParam(defender, 5), 0, MAXSTATS) / (EnableStatScaling ? STATS_SCALING : 1f));

                // Assign a basic flat value for a formula later.
                float flatValue = 20f;

                // Double it because flag nonsense said so.
                if ((defender.flag & 4) != 0)
                { flatValue = 40f; }

                // This formula is FUCKED, don't ask me about it.
                float finalvalue = ((float)luckValue / (((float)defender.level + 20f) / 5f)) * (flatValue + 100f);

                // Instead, here's a better one.
                if (EnableStatScaling)
                { finalvalue = 75.0f - (float)luckValue / 2f; }

                // RNGesus Take the Wheel
                System.Random rng = new();

                // Return 1 if you hit the defender and killed them, otherwise return 0.
                __result = finalvalue >= rng.Next(100) ? 1 : 0;
                return false;
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetExpMakaItem))]
        private class PatchAddExp
        {
            private static bool Prefix(datUnitWork_t w)
            {
                // If Disabled, return original function.
                if (!EnableStatScaling)
                { return true; }

                // Get the Main Process Data.
                nbMainProcessData_t data = nbMainProcess.nbGetMainProcessData();

                // Get Demon's Devil Format
                datDevilFormat_t devil = datDevilFormat.Get(w.id, true);

                // Get the Player's Current level.
                int level = datCalc.datGetPlayerLevel();

                // Get the difference in level count.
                int leveldiff = level - devil.level;

                // Get the Demon's Experience
                int exp = devil.dropexp;

                // Get the Demon's Macca
                int macca = devil.dropmakka;

                // Get the Demi-Fiend's current Luck and do some math for scaling Drop Rates.
                float dropRateMult = 1.0f + Math.Clamp(datCalc.datGetParam(dds3GlobalWork.DDS3_GBWK.unitwork[0], 5), 0, MAXSTATS) / 150;
                //float dropRateMult = EnableStatScaling ? 0.75f + ((float)Math.Clamp(datCalc.datGetParam(dds3GlobalWork.DDS3_GBWK.unitwork[0], 5), 0, MAXSTATS) / STATS_SCALING) : 1f;

                // If the enemy has an Item.
                int droppedItem = 0;

                // Unseeded random number generator
                System.Random rng = new();

                // If the Level Difference is not zero.
                if (leveldiff != 0)
                {
                    // If the Level Difference is positive, gain less Experience.
                    if (leveldiff > 0)
                    { exp = (int)((float)exp / (1f + Math.Min(0.5f, (float)Math.Abs(leveldiff) * 0.05f))); }
                }

                // If the Difficulty is Merciful, massively increase gains.
                if (dds3ConfigMain.cfgGetBit(9) == 0)
                {
                    macca *= 5;
                    exp *= 3;
                }

                // If in the Boss Rush, massively reduce your gains, add them to the encounter's data, and return.
                if (datCalc.datBossRashChk(data.encno) != 0)
                {
                    macca /= 10;
                    exp /= 10;

                    data.maka += (uint)macca;
                    data.exp += (uint)exp;

                    return false;
                }

                // Add the new Macca and EXP values to the encounter's data.
                data.maka += (uint)macca;
                data.exp += (uint)exp;

                // Check the Drop Chance
                int chance = rng.Next(100);

                // Keep looping until it finds an item and attempts to drop it.
                do
                {
                    // If items exist, continue.
                    bool found = false;
                    for (int i = 0; i < devil.dropitem.Length; i++)
                    {
                        if (devil.dropitem[i] != 0)
                        { found = true; break; }
                    }

                    // Grab an item.
                    int newItem = rng.Next(0, devil.dropitem.Length - 1);

                    // If it's not an item in the list, continue.
                    if (devil.dropitem[newItem] == 0 && found == true)
                    { continue; }

                    // If you meet the Drop Chance, grab this particular item and break.
                    // If the item ID is zero, skip to the break.
                    if (devil.dropitem[newItem] != 0 && (float)devil.droppoint[newItem] * dropRateMult >= chance)
                    { droppedItem = devil.dropitem[newItem]; }

                    break;
                }
                while (true);

                // If this weird variable is 0 or an EventBit Check is true and the enemy has a special item.
                if (devil.specialbit == 0 || (EventBit.evtBitCheck(devil.specialbit) && devil.specialitem != 0))
                {
                    if ((float)devil.specialpoint >= chance)
                    { droppedItem = devil.specialitem; }
                }

                if (droppedItem == 0)
                { return false; }

                // Check if a Bead drops.
                chance = rng.Next(100);
                bool foundBead = false;
                if ((float)devil.hougyokupoint * dropRateMult >= chance)
                { foundBead = true; }

                // Check if a LifeStone drops.
                chance = rng.Next(100);
                bool foundLifeStone = false;
                if ((float)devil.masekipoint * dropRateMult >= chance)
                { foundLifeStone = true; }

                // For Life Stones and Beads.
                int droppedExtraItem = 0;

                // Loop through the Data's Item list
                for (int i = 0; i < data.item.Length; i++)
                {
                    if (foundBead && droppedExtraItem == 0)
                    { droppedExtraItem = 4; foundBead = false; }

                    else if (foundLifeStone && droppedExtraItem == 0)
                    { droppedExtraItem = 3; foundLifeStone = false; }

                    // Extra Drops
                    // Add a new Item to the table.
                    if (data.item[i] == 0 && droppedExtraItem != 0)
                    {
                        data.item[i] = (byte)droppedExtraItem;
                        data.itemcnt[i] += 1;
                        droppedExtraItem = 0;
                    }
                    // Add to an existing Item's count.
                    if (data.item[i] == droppedExtraItem && droppedExtraItem != 0)
                    {
                        data.itemcnt[i] += 1;
                        droppedExtraItem = 0;
                    }

                    // Main Drops
                    // Add a new Item to the table.
                    if (data.item[i] == 0 && droppedItem != 0)
                    {
                        data.item[i] = (byte)droppedItem;
                        data.itemcnt[i] += 1;
                        droppedItem = 0;
                    }
                    // Add to an existing Item's count.
                    if (data.item[i] == droppedItem && droppedItem != 0)
                    {
                        data.itemcnt[i] += 1;
                        droppedItem = 0;
                    }
                }

                return false;
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetMakaBaramaki))]
        private class PatchGetMaccaScattering
        {
            private static bool Prefix(out int __result, datUnitWork_t w)
            {
                // Get the Demi-Fiend
                datUnitWork_t work = dds3GlobalWork.DDS3_GBWK.unitwork[0];

                // Get whatever demon is dropping Macca.
                datDevilFormat_t devil = datDevilFormat.Get(w.id, true);

                // Get the above demon's Luc.
                int luck = Math.Clamp(datCalc.datGetParam(w, 5), 0, MAXSTATS);

                // Grab Demi-Fiend's Luc.
                int playerLuck = Math.Clamp(datCalc.datGetParam(work, 5), 0, MAXSTATS);

                // Grab the player's total Macca.
                int macca = dds3GlobalWork.DDS3_GBWK.maka;
                int baseMacca = macca;

                // Unseeded rng.
                System.Random rng = new();

                // Result init.
                __result = 0;

                // If you have no Macca, skip.
                if (macca == 0)
                { return false; }

                // Formula values.
                float adjform, baseform;
                adjform = 0.0f;
                baseform = 0.0f;

                // Flag nonsense again.
                if ((w.flag >> 5 & 1) == 0)
                {
                    // Do some math for the base formula.
                    baseform = Mathf.Abs((float)luck / ((float)w.level / 5.0f + 4.0f));

                    // If enabled, do a different one.
                    if (EnableStatScaling)
                    { baseform = ((float)w.level + (float)luck) / 300f; }

                    // If you're under 1/1000, just set the adjustment to zero.
                    if (baseform < 0.001f)
                    { adjform = 0; }

                    // Otherwise, grab a small segment of your Macca.
                    else
                    {
                        adjform = (float)macca / 20.0f * baseform;

                        // If enabled, use your whole stack of Macca instead of 1/20.
                        // Also, clamp it to as low as 1/10 of your total Macca and as high as your entire stack.
                        if (EnableStatScaling)
                        { adjform = (float)Math.Clamp((float)macca * baseform, (float)macca / 10f, (float)macca / 2f); }
                    }
                }

                // If that flag was false.
                // Effectively this means the demon isn't on your team.
                else
                {
                    // Base formula math again.
                    baseform = Mathf.Abs((float)playerLuck / ((float)work.level / 5.0f + 4.0f));

                    // If enabled, scale differently.
                    if (EnableStatScaling)
                    { baseform = ((float)work.level + (float)playerLuck) / 300f; }

                    // Grab the enemy's whole stack.
                    // Also make sure you don't accidentally generate more (or less) Macca than intended.
                    adjform = (float)Math.Clamp(devil.dropmakka * baseform, devil.dropmakka / 10f, devil.dropmakka);
                }

                // Generate a number between 0.0 and 1.0.
                float variance = (float)rng.NextDouble();

                // Do some math and return the result later.
                __result = (int)Mathf.Abs((variance - 0.5f) * 2f * 0.1f * ((float)adjform * 2.0f));

                // If enabled, scale it differently.
                if (EnableStatScaling)
                { __result = (int)Math.Clamp((variance + 0.5f) * adjform, 0d, (w.flag >> 5 & 1) == 0 ? macca : devil.dropmakka); }

                // If difficulty bit is 1 or lower and some more flag nonsense, divide by 10.
                if (dds3ConfigMain.cfgGetBit(9) <= 1 && (w.flag & 0x20) == 0)
                { __result /= 10; }

                // If result is less than 1, set it to zero.
                if (__result < 1)
                { __result = 0; }
                return false;
            }
        }
    }
}
