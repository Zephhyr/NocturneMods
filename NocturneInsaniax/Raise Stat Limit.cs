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
using static Il2Cpp.scrollbarUI;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        // Stat manipulation variables
        private const int MAXSTATS = 40;
        private const int MAXHPMP = 9999;
        private const int POINTS_PER_LEVEL = 1;
        private const float STATS_SCALING = 2f;
        private const bool EnableIntStat = false;
        private const bool EnableStatScaling = false;

        // Stat Bar manipulation variables
        private const string BundlePath = "smt3hd_Data/StreamingAssets/PC/";
        private const float BAR_SCALE_X = (float)(40f / MAXSTATS) * 0.885f;
        private const float BAR_SEGMENT_X = 14f;
        private static uint[] pCol = (uint[])Array.CreateInstance(typeof(uint), 4);
        private static AssetBundle barData = null;
        private static string[] paramNames = { "Str", "Int", "Mag", "Vit", "Agi", "Luc" };
        private static int[] LevelUpPoints = { 0, 0, 0, 0, 0, 0 };
        private const string barSpriteName = "sstatusbar_base";
        private static string[] StatusBarValues = { "shpnum_current", "shpnum_full", "smpnum_current", "smpnum_full" };
        private static string[] StockBarValues = { "barhp", "barmp" };
        private static string[] AnalyzeBarValues = { "banalyze_hp_known", "banalyze_mp_known" };
        private static string[] PartyBarValues = { "barhp", "barmp" };

        // Menu manipulation variables
        private static bool SettingAsignParam;

        [HarmonyPatch(typeof(rstcalc), nameof(rstcalc.rstChkParamLimitAll))]
        private class PatchChkParamLimitAll
        {
            private static bool Prefix(ref int __result, datUnitWork_t pStock, bool paramSet = true)
            {
                // Return value initialization
                __result = 0;

                // If your stats are not capped completely, return.
                if (datCalc.datGetBaseParam(pStock, 0) >= MAXSTATS)
                {
                    if (EnableIntStat && datCalc.datGetBaseParam(pStock, 1) < MAXSTATS) { return false; }
                    if (datCalc.datGetBaseParam(pStock, 2) < MAXSTATS) { return false; }
                    if (datCalc.datGetBaseParam(pStock, 3) < MAXSTATS) { return false; }
                    if (datCalc.datGetBaseParam(pStock, 4) < MAXSTATS) { return false; }
                    if (datCalc.datGetBaseParam(pStock, 5) < MAXSTATS) { return false; }

                    // If you got to this point, your stats are completely maxed out.
                    // Additionally, if this is true, recalculate your HP/MP.
                    if (paramSet)
                    {
                        pStock.maxhp = (ushort)datCalc.datGetMaxHp(pStock);
                        pStock.maxmp = (ushort)datCalc.datGetMaxMp(pStock);

                        // Make sure both HP/MP don't overshoot.
                        pStock.hp = pStock.hp > pStock.maxhp ? pStock.maxhp : pStock.hp;
                        pStock.mp = pStock.mp > pStock.maxmp ? pStock.maxmp : pStock.mp;
                    }

                    // Make sure to return 1 to tell the game your stats are capped.
                    __result = 1;
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datCheckSkillTakaraSagasi))]
        private class PatchLuckyFind
        {
            private static bool Prefix(out int __result)
            {
                __result = 0;

                // Loop through all of your Demons to search for any that have Lucky Find.
                for (int i = 0; i < dds3GlobalWork.DDS3_GBWK.unitwork.Length; i++)
                {
                    // Grab the work demon.
                    datUnitWork_t work = dds3GlobalWork.DDS3_GBWK.unitwork[i];

                    // Flag Check of some sort.
                    if ((~work.flag & 3) == 0)
                    {
                        // Grab the Demon's Luck.
                        int luck = EnableStatScaling ? (int)((float)datCalc.datGetParam(work, 5) / STATS_SCALING) : datCalc.datGetParam(work, 5);

                        // If the Demon has Lucky Find as a Skill.
                        if (datCalc.datCheckSyojiSkill(work, 0x161) != 0)
                        {
                            // A random integer check to see if the Demon's ID is returned.
                            uint randomChance = dds3KernelCore.dds3GetRandIntA(0x20);
                            if (randomChance <= (luck << 7) / 100)
                            { __result = work.id; return false; }
                        }
                    }
                }

                return false;
            }
        }

        [HarmonyPatch(typeof(scrParameterCommand), nameof(scrParameterCommand.prm_PLAYER_GET_PARAM))]
        private class PatchCommandPlayerGetParam
        {
            // This gets called from the Stat Doors in the Labyrinth of Amala.
            // Specifically, the Third Kalpa Player Stat Doors.
            private static bool Prefix(out int __result)
            {
                // Get Player's Param ID.
                int value = ScrTraceCode.scrGetIntPara(0);

                // Get the Parameter's actual raw value.
                value = datCalc.datGetPlayerParam(value);

                // Scale properly, then return.
                value = EnableStatScaling ? (int)Math.Floor((float)value / (Math.Ceiling((float)MAXSTATS / 40f) / STATS_SCALING)) : value;
                ScrTraceCode.scrSetIntReturnValue(value);
                __result = 1;
                return false;
            }
        }

        [HarmonyPatch(typeof(scrParameterCommand), nameof(scrParameterCommand.prm_NAKAMA_GET_PARAM))]
        private class PatchCommandAllyGetParam
        {
            // This gets called from the Stat Doors in the Labyrinth of Amala.
            // Specifically, the Fifth Kalpha Demon Stat Doors.
            private static bool Prefix(out int __result)
            {
                // Get Demon ID and Param ID.
                int id = ScrTraceCode.scrGetIntPara(0);
                int param = ScrTraceCode.scrGetIntPara(1);

                // Grab the Parameter's actual raw value.
                param = datCalc.datGetNakamaParam(id, param);

                // Scale it properly, then return.
                param = EnableStatScaling ? (int)Math.Floor((float)param / (Math.Ceiling((float)MAXSTATS / 40f) / STATS_SCALING)) : param;
                ScrTraceCode.scrSetIntReturnValue(param);
                __result = 1;
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datAddPlayerParam))]
        private class PatchAddPlayerParam
        {
            private static bool Prefix(int id, int add)
            {
                // This looks through each demon you control and checks if their ID is 0, which is Demi-Fiend.
                // Yes, this means if you *somehow* have Demi-Fiend more than once, it'll add the stat to each of them.
                foreach (datUnitWork_t work in dds3GlobalWork.DDS3_GBWK.unitwork.Where(x => x.id == 0))
                {
                    // Adds to then clamps whatever stat you're adding to.
                    // Note that "add" can be negative.
                    int heartParam = rstCalcCore.cmbGetHeartsParam((sbyte)dds3GlobalWork.DDS3_GBWK.heartsequip, (sbyte)id);
                    work.param[id] = (sbyte)Math.Clamp(work.param[id] + add, 0, MAXSTATS + heartParam);

                    // Adjust Max HP/MP and fully heal.
                    work.maxhp = (ushort)datCalc.datGetMaxHp(work);
                    work.maxhp = (ushort)datCalc.datGetMaxHp(work);
                    work.hp = work.hp > work.maxhp ? work.maxhp : work.hp;
                    work.mp = work.mp > work.maxmp ? work.maxmp : work.mp;
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetBaseParam))]
        private class PatchGetBaseParam
        {
            private static bool Prefix(ref int __result, datUnitWork_t work, int paratype)
            {
                // Just returns the parameter of the given type.
                int heartParam = work.id == 0 ? rstCalcCore.cmbGetHeartsParam((sbyte)dds3GlobalWork.DDS3_GBWK.heartsequip, (sbyte)paratype) : 0;
                __result = Math.Clamp(work.param[paratype] - heartParam + work.levelupparam[paratype], 0, MAXSTATS); ;
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetParam))]
        private class PatchGetParam
        {
            private static bool Prefix(out int __result, datUnitWork_t work, int paratype)
            {
                // Returns the base stat of the given parameter.
                int heartParam = work.id == 0 ? rstCalcCore.cmbGetHeartsParam((sbyte)dds3GlobalWork.DDS3_GBWK.heartsequip, (sbyte)paratype) : 0;
                __result = Math.Clamp(datCalc.datGetBaseParam(work, paratype) + heartParam + work.mitamaparam[paratype], 0, MAXSTATS + heartParam + work.mitamaparam[paratype]);
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetBaseMaxHp))]
        private class PatchGetBaseMaxHP
        {
            public static int GetBaseMaxHP(datUnitWork_t work)
            {
                // Calculate the unit's actual Base Max HP value.
                int result = (Math.Clamp(datCalc.datGetParam(work, 3), 0, MAXSTATS) + work.level) * 6;

                // If enabled, scale differently.
                if (EnableStatScaling)
                { result = (int)((float)(Math.Clamp(datCalc.datGetParam(work, 3), 0, MAXSTATS) / (float)STATS_SCALING + (float)work.level) * 6f); }

                // Return the result.
                return result;
            }

            private static bool Prefix(out int __result, datUnitWork_t work)
            {
                // Return the above function's value.
                __result = GetBaseMaxHP(work);
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetBaseMaxMp))]
        private class PatchGetBaseMaxMP
        {
            public static int GetBaseMaxMP(datUnitWork_t work)
            {
                // Calculate the unit's actual Base Max MP value.
                int result = (Math.Clamp(datCalc.datGetParam(work, 2), 0, MAXSTATS) + work.level) * 4;

                // If enabled, scale differently.
                if (EnableStatScaling)
                { result = (int)(((float)Math.Clamp(datCalc.datGetParam(work, 2), 0, MAXSTATS) / (float)STATS_SCALING + (float)work.level) * 4f); }

                // Return the result.
                return result;
            }

            private static bool Prefix(out int __result, datUnitWork_t work)
            {
                // Similar to the HP function, just return the above function's result.
                __result = GetBaseMaxMP(work);
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetMaxHp))]
        private class PatchGetMaxHP
        {
            public static uint GetMaxHP(datUnitWork_t work)
            {
                // Grab the Base Max HP.
                uint result = (uint)datCalc.datGetBaseMaxHp(work);

                // Add a percentage of your Max HP to your Max HP with certain special Skills.
                float boost = 1.0f;
                boost += datCalc.datCheckSyojiSkill(work, 0x122) == 1 ? 0.1f : 0;
                boost += datCalc.datCheckSyojiSkill(work, 0x123) == 1 ? 0.2f : 0;
                boost += datCalc.datCheckSyojiSkill(work, 0x124) == 1 ? 0.3f : 0;

                // Clamp the result.
                result = Math.Clamp((uint)((float)result * boost), 1, MAXHPMP);
                return result;
            }

            private static bool Prefix(out uint __result, datUnitWork_t work)
            {
                // Again, return the above function's result.
                __result = GetMaxHP(work);
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetMaxMp))]
        private class PatchGetMaxMP
        {
            public static uint GetMaxMP(datUnitWork_t work)
            {
                // Grab the Base Max MP.
                uint result = (uint)datCalc.datGetBaseMaxMp(work);

                // Like before, add percentages of it to it based on certain Skills.
                float boost = 1.0f;
                boost += datCalc.datCheckSyojiSkill(work, 0x125) == 1 ? 0.1f : 0;
                boost += datCalc.datCheckSyojiSkill(work, 0x126) == 1 ? 0.2f : 0;
                boost += datCalc.datCheckSyojiSkill(work, 0x127) == 1 ? 0.3f : 0;

                // Clamp.
                result = Math.Clamp((uint)((float)result * boost), 1, MAXHPMP);

                // Return.
                return result;
            }
            private static bool Prefix(out uint __result, datUnitWork_t work)
            {
                // Grab and return.
                __result = GetMaxMP(work);
                return false;
            }
        }

        [HarmonyPatch(typeof(rstcalc), nameof(rstcalc.rstSetMaxHpMp))]
        private class PatchSetMaxHpMp
        {
            private static void Postfix(sbyte Mode, ref datUnitWork_t pStock)
            {
                // Set the target's Max HP and MP
                pStock.maxhp = (ushort)datCalc.datGetMaxHp(pStock);
                pStock.maxmp = (ushort)datCalc.datGetMaxMp(pStock);

                // Make sure both HP/MP don't overshoot.
                pStock.hp = pStock.hp > pStock.maxhp ? pStock.maxhp : pStock.hp;
                pStock.mp = pStock.mp > pStock.maxmp ? pStock.maxmp : pStock.mp;
            }
        }

        [HarmonyPatch(typeof(rstCalcCore), nameof(rstCalcCore.cmbAddLevelUpParamEx))]
        private class PatchAddLevelUpParamEx
        {
            public static sbyte AddLevelUpParam(ref datUnitWork_t pStock, sbyte Mode)
            {
                // This is a list of Stats it needs to check.
                bool[] paramChecks = { false, false, false, false, false, false };

                // Change the list's values to true if that Stat is capped.
                for (int i = 0; i < paramChecks.Length; i++)
                {
                    if (datCalc.datGetBaseParam(pStock, i) >= MAXSTATS)
                    { paramChecks[i] = true; }
                }

                // Loop through the Stats.
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

                    // Grab a particular Stat ID.
                    // Note this will loop forever if the number's out of range.
                    // Additionally, if it selects Int while Int is disabled, it'll loop again to try and unselect it.
                    int ctr = -1;
                    do
                    { ctr = (int)(fclMisc.FCL_RAND() % paramChecks.Length); }
                    while (ctr < 0 || ctr > 6 || ctr == 1 && !EnableIntStat);

                    // If it's capped, continue and do it again.
                    if (paramChecks[ctr] == true)
                    { continue; }

                    // If this somehow happened, return 0x7f.
                    // This is probably an error code.
                    if (pStock.levelupparam.Length <= ctr)
                    { return 0x7f; }

                    // If Mode is zero, increment the LevelUp Stat.
                    if (Mode == 0)
                    { pStock.levelupparam[ctr]++; }

                    // Return the Stat ID.
                    return (sbyte)ctr;
                }
                while (true);

                // If you got to here, the function broke somehow, so just make sure it assigns nothing.
                return 6;
            }

            private static bool Prefix(out sbyte __result, ref datUnitWork_t pStock, sbyte Mode)
            {
                // Returns the previous function's value
                // Note: Mode at 0 will actually increase your stats. Otherwise it'll just check the ID.
                __result = AddLevelUpParam(ref pStock, Mode);
                return false;
            }
        }

        [HarmonyPatch(typeof(rstcalc), nameof(rstcalc.rstAutoAsignDevilParam))]
        private class PatchAutoAsignDevilParam
        {
            private static bool Prefix()
            {
                // This is a list of Stats it needs to check.
                bool[] paramChecks = { false, false, false, false, false, false };

                // Grab the current Stock demon.
                datUnitWork_t pStock = rstinit.GBWK.pCurrentStock;

                // Iterate a loop through Stats and checks for if the stat's capped already and set a boolean.
                int i = 0;
                for (i = 0; i < pStock.param.Length; i++)
                {
                    if (i == 1 && !EnableIntStat)
                    { continue; }
                    if (datCalc.datGetBaseParam(pStock, i) >= MAXSTATS)
                    { paramChecks[i] = true; }
                }

                // Iterate and set the demon's new LevelUp Stats.
                i = rstinit.GBWK.AsignParam * (EnableStatScaling ? POINTS_PER_LEVEL : 1);
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

                    // If you end up finishing the full distribution of stats, break the loop.
                    if (i <= 0)
                    { break; }

                    // Add a random stat to the demon.
                    int paramID = rstCalcCore.cmbAddLevelUpParamEx(ref pStock, 1);

                    // If the Stat's ID is over 5 or somehow goes under 0, continue.
                    if (paramID > 5 || paramID < 0)
                    { continue; }

                    // If the Stat's ID is already full, continue and remove the point distributed.
                    if (paramChecks[paramID] == true)
                    { continue; }

                    // Add to the demon's stats.
                    pStock.levelupparam[paramID] += 1;

                    // Set a boolean to true if the stat becomed capped out.
                    // Also forcibly set the stat to its new cap.
                    if (datCalc.datGetBaseParam(pStock, paramID) >= MAXSTATS)
                    { paramChecks[paramID] = true; }

                    // Increment.
                    i--;
                }
                while (true);

                // Recalculate Max HP/MP.
                pStock.maxhp = (ushort)datCalc.datGetMaxHp(pStock);
                pStock.maxmp = (ushort)datCalc.datGetMaxMp(pStock);
                return false;
            }
        }

        [HarmonyPatch(typeof(rstcalc), nameof(rstcalc.rstCalcEvo))]
        private class PatchCheckDemonEvo
        {
            private static void Postfix()
            {
                // Grab current Stock Demon.
                datUnitWork_t pStock = rstinit.GBWK.pCurrentStock;

                // Iterate through the Demon's LevelUp Stats
                for (int i = 0; i < pStock.levelupparam.Length; i++)
                {
                    // Forcibly set them to their Base Stats then clear them.
                    pStock.param[i] += pStock.levelupparam[i];
                    pStock.levelupparam[i] = 0;
                }
            }
        }

        [HarmonyPatch(typeof(rstCalcCore), nameof(rstCalcCore.cmbCalcEvoEvent))]
        private class PatchCalcEvoEvent
        {
            private static bool Prefix(datUnitWork_t pStock, Il2CppReferenceArray<fclSkillParam_t> pEvent, sbyte EvtBufFlag, datUnitWork_t pEvoDevil)
            {
                // If the event's Buffer Flag(?) is zero or the length of the event is under 2, return.
                if (EvtBufFlag == 0 || pEvent.Length < 2)
                { return true; }

                // Grab an Event index.
                fclSkillParam_t EventParam = pEvent[1];

                // If its Type isn't 5, use the first index instead.
                // Not sure what this is doing.
                if (EventParam.Type != 5)
                { EventParam = pEvent[0]; }

                // Grab what's probably the demon ID your demon evolves into.
                int DemonID = EventParam.Param;

                // If the Evo Demon exists and the current DemonID is over zero.
                if (pEvoDevil != null && DemonID > 0)
                {
                    // Copy the Demon into your Stock.
                    fclCombineCalcCore.cmbCopyDefaultDevilToStock((ushort)DemonID, pEvoDevil);

                    // If the new demon is a higher level.
                    if (pStock.level > pEvoDevil.level)
                    {
                        // Recalculate the new demon's Experience.
                        pEvoDevil.exp = rstCalcCore.cmbCalcLevelUpExp(ref pEvoDevil, pStock.level);

                        // Loop through the Stats and set them appropriately.
                        int i = 0;
                        do
                        {
                            // Grab the stat without granting a point to it.
                            int paramID = rstCalcCore.cmbAddLevelUpParamEx(ref pEvoDevil, 1);

                            // If the Stat returns properly.
                            if (paramID > -1 && paramID < 6)
                            {
                                // If under the cap, increase the stat.
                                if (datCalc.datGetBaseParam(pEvoDevil, paramID) < MAXSTATS)
                                { pEvoDevil.param[paramID]++; }
                            }

                            // Otherwise, break loop.
                            else
                            { continue; }

                            // Increment.
                            i++;
                        }
                        while (i < Math.Abs(pStock.level - pEvoDevil.level) * (EnableStatScaling ? POINTS_PER_LEVEL : 1));

                        // Forcibly set the new Demon's level to what it should be so that it doesn't trigger Level Ups.
                        pEvoDevil.level = pStock.level;

                        // Flag Nonsense that's included normally.
                        // Fixes their Skills from being removed from their Level Up Skill List.
                        pEvoDevil.flag |= 0x200;
                    }
                }

                return false;
            }
        }

        [HarmonyPatch(typeof(cmpPanel), nameof(cmpPanel.cmpDrawDevilInfo))]
        private class PatchDrawDevilInfo
        {
            private static void Postfix(int X, int Y, uint Z, uint Col, sbyte SelFlag, sbyte DrawType, datUnitWork_t pStock, cmpCursorEff_t pEff, int FadeRate, GameObject obj, int MatCol)
            {
                // Set up a list of the demon's HP/MP. We'll be referencing this.
                int[] StockStats = new int[] { pStock.hp, pStock.mp };

                // For loop going through Game Objects.
                for (int i = 0; i < 2; i++)
                {
                    // Grabs whatever the base Game Object's name is, then checks if the current Stock Bar object is a child of it.
                    GameObject g2 = GameObject.Find(obj.name + "/" + StockBarValues[i]);

                    // If it isn't, continue.
                    if (g2 == null)
                    { continue; }

                    // If it exists and its Counter's Image count is less than 4.
                    if (g2.GetComponent<CounterCtr>().image.Length < 4)
                    {
                        // Copy the first Image object.
                        GameObject g = GameObject.Instantiate(g2.GetComponent<CounterCtr>().image[0].gameObject);

                        // Set the new object's parent to the original's parent.
                        g.transform.parent = g2.transform;

                        // Change its position and scale to match the original object we copied.
                        g.transform.position = g2.GetComponent<CounterCtr>().image[0].transform.position;
                        g.transform.localPosition = g2.GetComponent<CounterCtr>().image[0].transform.localPosition;
                        g.transform.localScale = g2.GetComponent<CounterCtr>().image[0].transform.localScale;

                        // Append the object to the original object's Counter Image list.
                        g2.GetComponent<CounterCtr>().image = g2.GetComponent<CounterCtr>().image.Append<Image>(g.GetComponent<Image>()).ToArray<Image>();

                        // Count through the Counter's Image list.
                        for (int j = 0; j < g2.GetComponent<CounterCtr>().image.Length; j++)
                        {
                            // Check if the object's active, then activate it anyway.
                            bool chk = g2.GetComponent<CounterCtr>().image[j].gameObject.active;
                            g2.GetComponent<CounterCtr>().image[j].gameObject.active = true;

                            // Set the position and scale to new values. These are very precise.
                            g2.GetComponent<CounterCtr>().image[j].transform.localPosition = new Vector3(118 - j * 25, 31, -4);
                            g2.GetComponent<CounterCtr>().image[j].transform.localScale = new Vector3(g2.GetComponent<CounterCtr>().image[j].transform.localScale.x * 0.85f, g2.GetComponent<CounterCtr>().image[j].transform.localScale.y * 0.85f, g2.GetComponent<CounterCtr>().image[j].transform.localScale.z);

                            // Deactivate the object if it wasn't active.
                            g2.GetComponent<CounterCtr>().image[j].gameObject.active = chk;
                        }

                        // MAKE SURE this object doesn't get deleted.
                        GameObject.DontDestroyOnLoad(g);
                    }

                    // Set the object's color to white and set it to the proper Stat's value.
                    g2.GetComponent<CounterCtr>().Set(StockStats[i], Color.white, 0);
                }
            }
        }

        [HarmonyPatch(typeof(nbPanelProcess), nameof(nbPanelProcess.nbPanelPartyDraw))]
        private class PatchPanelPartyDraw
        {
            private static void Postfix()
            {
                // Iterate through your party's stats.
                for (int i = 0; i < 4; i++)
                {
                    // Grab the party object from the index.
                    nbParty_t party = nbMainProcess.nbGetPartyFromFormindex(i);

                    // If it's null, continue.
                    if (party == null)
                    { continue; }

                    // Grab the demon from the party's statindex.
                    datUnitWork_t pStock = dds3GlobalWork.DDS3_GBWK.unitwork[party.statindex];

                    // Grab their HP/MP for later.
                    int[] PartyStats = new int[] { pStock.hp, pStock.mp };

                    // Loops through the party's Bar objects
                    for (int k = 0; k < 2; k++)
                    {
                        // Grab the demon's Party Bar values.
                        GameObject g2 = GameObject.Find("bparty(Clone)/bparty_window0" + (i + 1) + "/" + PartyBarValues[k]);

                        // If it doesn't exist, continue;
                        if (g2 == null)
                        { continue; }

                        // If the Counter's image count is less than 4.
                        if (g2.GetComponent<CounterCtrBattle>().image.Length < 4)
                        {
                            // Copy the first image.
                            GameObject g = GameObject.Instantiate(g2.GetComponent<CounterCtrBattle>().image[0].gameObject);

                            // Set the parent to the Party Bar.
                            g.transform.parent = g2.transform;

                            // Set its position and scale to the original image's values.
                            g.transform.position = g2.GetComponent<CounterCtrBattle>().image[0].transform.position;
                            g.transform.localPosition = g2.GetComponent<CounterCtrBattle>().image[0].transform.localPosition;
                            g.transform.localScale = g2.GetComponent<CounterCtrBattle>().image[0].transform.localScale;

                            // Append the new image to the Party Bar's Counter Image List.
                            g2.GetComponent<CounterCtrBattle>().image = g2.GetComponent<CounterCtrBattle>().image.Append<Image>(g.GetComponent<Image>()).ToArray<Image>();

                            // Iterate through the Images.
                            for (int j = 0; j < g2.GetComponent<CounterCtrBattle>().image.Length; j++)
                            {
                                // Save previous active state and set to active.
                                bool chk = g2.GetComponent<CounterCtrBattle>().image[j].gameObject.active;
                                g2.GetComponent<CounterCtrBattle>().image[j].gameObject.active = true;

                                // Set new position and scale. Again, very precise.
                                g2.GetComponent<CounterCtrBattle>().image[j].transform.localPosition = new Vector3(119 - j * 25, 0, -4);
                                g2.GetComponent<CounterCtrBattle>().image[j].transform.localScale = new Vector3(g2.GetComponent<CounterCtrBattle>().image[j].transform.localScale.x * 0.85f, g2.GetComponent<CounterCtrBattle>().image[j].transform.localScale.y * 0.85f, g2.GetComponent<CounterCtrBattle>().image[j].transform.localScale.z);

                                // Set active state back.
                                g2.GetComponent<CounterCtrBattle>().image[j].gameObject.active = chk;
                            }

                            // MAKE SURE it doesn't get destroyed.
                            GameObject.DontDestroyOnLoad(g);
                        }

                        // Set color to white and set it up with the demon's stats.
                        g2.GetComponent<CounterCtrBattle>().Set(PartyStats[k], Color.white, 0);
                    }
                }


                // This section iterates through the Battle Menu's Summon Selection.
                for (int i = 0; i < 3; i++)
                {
                    // Iterate through the Party Bars.
                    for (int k = 0; k < 2; k++)
                    {
                        // Grab the Party Bar.
                        GameObject g2 = GameObject.Find("summon_command/bmenu_command/bmenu_command_s0" + (i + 1) + "/" + PartyBarValues[k]);
                        if (g2 == null)
                        { continue; }

                        // If the Counter's image count is less than 4.
                        if (g2.GetComponent<CounterCtrBattle>().image.Length < 4)
                        {
                            // Copy the first image.
                            GameObject g = GameObject.Instantiate(g2.GetComponent<CounterCtrBattle>().image[0].gameObject);

                            // Set its parent to the Party Bar.
                            g.transform.parent = g2.transform;

                            // Set its position and scale to the original object's values.
                            g.transform.position = g2.GetComponent<CounterCtrBattle>().image[0].transform.position;
                            g.transform.localPosition = g2.GetComponent<CounterCtrBattle>().image[0].transform.localPosition;
                            g.transform.localScale = g2.GetComponent<CounterCtrBattle>().image[0].transform.localScale;

                            // Append the image to the Counters' image lists.
                            // I dunno why there's two of them, but there is.
                            // Nocturne's weird.
                            g2.GetComponent<CounterCtr>().image = g2.GetComponent<CounterCtr>().image.Append<Image>(g.GetComponent<Image>()).ToArray<Image>();
                            g2.GetComponent<CounterCtrBattle>().image = g2.GetComponent<CounterCtrBattle>().image.Append<Image>(g.GetComponent<Image>()).ToArray<Image>();

                            // Iterate through the images.
                            for (int j = 0; j < g2.GetComponent<CounterCtrBattle>().image.Length; j++)
                            {
                                // Get the active state then set it to true.
                                bool chk = g2.GetComponent<CounterCtrBattle>().image[j].gameObject.active;
                                g2.GetComponent<CounterCtrBattle>().image[j].gameObject.active = true;

                                // Change the image's position and scale. You get the point by now. This happens a lot.
                                g2.GetComponent<CounterCtrBattle>().image[j].transform.localPosition = new Vector3(119 - j * 25, 0, -4);
                                g2.GetComponent<CounterCtrBattle>().image[j].transform.localScale = new Vector3(g2.GetComponent<CounterCtrBattle>().image[j].transform.localScale.x * 0.85f, g2.GetComponent<CounterCtrBattle>().image[j].transform.localScale.y * 0.85f, g2.GetComponent<CounterCtrBattle>().image[j].transform.localScale.z);

                                // Set active to previous value.
                                g2.GetComponent<CounterCtrBattle>().image[j].gameObject.active = chk;
                            }

                            // MAKE SURE it stays.
                            GameObject.DontDestroyOnLoad(g);
                        }
                    }
                }
            }
        }

        [HarmonyPatch(typeof(nbPanelProcess), nameof(nbPanelProcess.nbPanelAnalyzeRun))]
        private class PatchPanelAnalyzeRun
        {
            private static void Postfix()
            {
                // Grab the unit you're analyzing
                datUnitWork_t unit = nbPanelProcess.pNbPanelAnalyzeUnitWork;

                // If it exists, which it should.
                // While I was testing the Random Target Multihits, it could end upnull, so thank god I put this here.
                if (unit != null)
                {
                    // Set up the Analyze Bars.
                    int[] AnalyzeStats = new int[] { unit.hp, unit.maxhp, unit.mp, unit.maxmp };

                    // These are the specific images we're copying.
                    string[] images = { "num_hp01", "num_hpfull01", "num_mp01", "num_mpfull01", };

                    // Iterate through the Analyze Bars and images.
                    for (int i = 0; i < 4; i++)
                    {
                        // Find the image.
                        GameObject g2 = GameObject.Find(AnalyzeBarValues[i / 2] + "/" + images[i]);

                        // If it doesn't exist, skip.
                        if (g2 == null)
                        { continue; }

                        // If it has no Counter, skip.
                        if (g2.GetComponent<CounterCtr>() == null)
                        { continue; }

                        // If it's Counter has less than 5 images.
                        if (g2.GetComponent<CounterCtr>().image.Length < 5)
                        {

                            // Grab the currently Length and iterate until 5.
                            for (int j = g2.GetComponent<CounterCtr>().image.Length; j < 5; j++)
                            {
                                // Copy the image.
                                GameObject g = GameObject.Instantiate(g2);

                                // Remove the Counter from the copy since we don't need duplicates.
                                GameObject.Destroy(g.GetComponent<CounterCtr>());

                                // Rename the image. I don't think this matters, but I'm doing it anyway.
                                g.name = images[i].Replace("1", "") + (i + 1);

                                // Set the copy's parent to the original image's parent.
                                g.transform.parent = g2.transform.parent;

                                // Set the position and scale to the original's values.
                                g.transform.position = g2.GetComponent<CounterCtr>().transform.position;
                                g.transform.localPosition = g2.GetComponent<CounterCtr>().transform.localPosition;
                                g.transform.localScale = g2.GetComponent<CounterCtr>().transform.localScale;

                                // Append the copy to the Counter's image list.
                                g2.GetComponent<CounterCtr>().image = g2.GetComponent<CounterCtr>().image.Append<Image>(g.GetComponent<Image>()).ToArray<Image>();

                                // MAKE SURE it doesn't die.
                                GameObject.DontDestroyOnLoad(g);
                            }

                            // Iterate through the image lists completely.
                            for (int j = 0; j < g2.GetComponent<CounterCtr>().image.Length; j++)
                            {
                                // Set position and scale accordingly.
                                g2.GetComponent<CounterCtr>().image[j].transform.localPosition = new Vector3((i % 2) * 130 + 86 - j * 20 + 5, 32, -8);
                                g2.GetComponent<CounterCtr>().image[j].transform.localScale = new Vector3(0.8f, 1, 1);
                            }
                        }

                        // Set Counter's value and color.
                        g2.GetComponent<CounterCtr>().Set(AnalyzeStats[i], Color.white, 0);
                    }
                }
            }
        }

        [HarmonyPatch(typeof(rstupdate), nameof(rstupdate.rstResetAsignParam))]
        private class PatchResetAsignParam
        {
            private static bool Prefix()
            {
                // Just a call, nothing more.
                ResetParam();
                return false;
            }
            public static void ResetParam()
            {
                // Recalculates your LevelUp Points and their Maximum distribution.
                rstinit.GBWK.AsignParam = (short)(rstinit.GBWK.LevelUpCnt * POINTS_PER_LEVEL);
                rstinit.GBWK.AsignParamMax = (short)(rstinit.GBWK.LevelUpCnt * POINTS_PER_LEVEL);

                // Grab the current Stock Unit.
                datUnitWork_t pStock = rstinit.GBWK.pCurrentStock;

                // Clears out whatever points you did distribute.
                for (int i = 0; i < pStock.levelupparam.Length; i++)
                { pStock.levelupparam[i] = 0; }

                // I dunno what this does, but I'm guessing it just makes the Stat Point number visually glow.
                rstinit.SetPointAnime(rstinit.GBWK.TargetCnt);
            }
        }

        [HarmonyPatch(typeof(rstupdate), nameof(rstupdate.rstUpdateSeqAsignPlayerParam))]
        private class PatchUpdateAsignPlayerParam
        {
            public static sbyte YesResponse()
            {
                // I shit you not, this number is EXTREMELY important.
                // Wihtout this, you can't leave the menu properly. I honestly have no idea why.
                rstinit.GBWK.SeqInfo.Current = 0x18;

                // Clear the fact that you were setting stats.
                SettingAsignParam = false;

                // Grab the player unit.
                datUnitWork_t pStock = dds3GlobalWork.DDS3_GBWK.unitwork[0];

                // Distribute the Player's level up points to proper points.
                for (int i = 0; i < pStock.levelupparam.Length; i++)
                {
                    pStock.param[i] += (sbyte)pStock.levelupparam[i];
                    pStock.levelupparam[i] = 0;
                }

                // Recalculate HP/MP
                pStock.maxhp = (ushort)datCalc.datGetMaxHp(pStock);
                pStock.maxmp = (ushort)datCalc.datGetMaxMp(pStock);

                // Return that you said yes.
                return 1;
            }
            public static sbyte NoResponse()
            {
                // Return that you said no.
                return 0;
            }
            private static bool Prefix(ref datUnitWork_t pStock)
            {
                // If you're in the confirmation Message.
                if (fclMisc.fclChkMessage() == 2)
                {
                    // If you're at position zero and you hit the OK button.
                    if (fclMisc.fclGetSelMessagePos() == 0
                        && dds3PadManager.DDS3_PADCHECK_PRESS(Il2Cpplibsdf_H.SDF_PADMAP.OK)
                        && dds3PadManager.DDS3_PADCHECK_REP(Il2Cpplibsdf_H.SDF_PADMAP.OK) == true)
                    {
                        // If you're in a Selection Message, then respond.
                        if (fclMisc.fclChkSelMessage() == 1)
                        { YesResponse(); }
                    }

                    // If you're at position 1 and you hit the OK button or you hit the Cancel button.
                    if ((fclMisc.fclGetSelMessagePos() == 1
                        && dds3PadManager.DDS3_PADCHECK_PRESS(Il2Cpplibsdf_H.SDF_PADMAP.OK)
                        && dds3PadManager.DDS3_PADCHECK_REP(Il2Cpplibsdf_H.SDF_PADMAP.OK) == true) ||
                        (dds3PadManager.DDS3_PADCHECK_PRESS(Il2Cpplibsdf_H.SDF_PADMAP.CANCEL)
                        && dds3PadManager.DDS3_PADCHECK_REP(Il2Cpplibsdf_H.SDF_PADMAP.CANCEL) == true))
                    {
                        // If you're in a Selection Message, then respond.
                        if (fclMisc.fclChkSelMessage() == 1)
                        { NoResponse(); }
                    }

                    // This is so it doesn't continue while you're in a message.
                    return false;
                }

                // If you're not assigning your Stats, reset them once and start assigning them.
                if (SettingAsignParam == false)
                {
                    rstupdate.rstResetAsignParam();
                    SettingAsignParam = true;
                }

                // If your stats are capped, immediately skip the entire process.
                if (EnableIntStat && datCalc.datGetBaseParam(pStock, 0) >= MAXSTATS &&
                    datCalc.datGetBaseParam(pStock, 1) >= MAXSTATS &&
                    datCalc.datGetBaseParam(pStock, 2) >= MAXSTATS &&
                    datCalc.datGetBaseParam(pStock, 3) >= MAXSTATS &&
                    datCalc.datGetBaseParam(pStock, 4) >= MAXSTATS &&
                    datCalc.datGetBaseParam(pStock, 5) >= MAXSTATS)
                { YesResponse(); return false; }

                // Same thing as above, but without Int.
                else if (datCalc.datGetBaseParam(pStock, 0) >= MAXSTATS &&
                    datCalc.datGetBaseParam(pStock, 2) >= MAXSTATS &&
                    datCalc.datGetBaseParam(pStock, 3) >= MAXSTATS &&
                    datCalc.datGetBaseParam(pStock, 4) >= MAXSTATS &&
                    datCalc.datGetBaseParam(pStock, 5) >= MAXSTATS)
                { YesResponse(); return false; }

                // If the status object is null, immediately skip the entire process.
                if (cmpStatus.statusObj == null)
                { YesResponse(); return false; }

                // If you're in a Message, skip the rest.
                if (fclMisc.fclChkMessage() != 0)
                { return false; }

                // Grab the Cursor's index and adjust it accordingly.
                int cursorIndex = cmpMisc.cmpGetCursorIndex(rstinit.GBWK.ParamCursor);
                sbyte cursorParam = (sbyte)cursorIndex;

                // If Int is disabled, make sure it doesn't select it.
                if (!EnableIntStat)
                { cursorParam = cmpMisc.cmpExchgParamIndex((sbyte)cursorIndex); }

                // Otherwise, make sure it can select it.
                else
                {
                    // If the Status Bar object count is under 6.
                    if (cmpStatus._statusUIScr.ObjStsBar.Length < 6)
                    {
                        // Find the 6th Status Bar.
                        // This will only exist with Int enabled, so don't worry about it.
                        GameObject g = GameObject.Find("statusUI(Clone)/sstatus/sstatusbar06");

                        // Append to the Status Bar arrays.
                        cmpStatus._statusUIScr.ObjStsBar = cmpStatus._statusUIScr.ObjStsBar.Append(g).ToArray();
                        cmpStatus._statusUIScr.ObjStatus = cmpStatus._statusUIScr.ObjStsBar.Append(g).ToArray();
                    }

                    // Increase the selection caps to 6.
                    rstinit.GBWK.ParamCursor.CursorPos.ShiftMax = 6;
                    rstinit.GBWK.ParamCursor.CursorPos.ListNums = 6;
                }

                // Set up the Status Screen and its cursor.
                cmpUpdate.cmpSetupObject(cmpStatus._statusUIScr.gameObject, true);
                cmpUpdate.cmpMenuCursor(cursorIndex, cmpStatus._statusUIScr.stsCursor, cmpStatus._statusUIScr.ObjStsBar);

                // Make something glow.
                rstinit.SetPointAnime(rstinit.GBWK.TargetCnt);

                // Check if you pressed up. If you're holding it, delay the input a bit and then repeat it slowly.
                if (dds3PadManager.DDS3_PADCHECK_PRESS(Il2Cpplibsdf_H.SDF_PADMAP.U) && dds3PadManager.DDS3_PADCHECK_REP(Il2Cpplibsdf_H.SDF_PADMAP.U) == true)
                {
                    // Grab the cursor index.
                    cursorIndex = cmpMisc.cmpMoveCursor(rstinit.GBWK.ParamCursor, 0);

                    // If the cursor index is under the maximum, decrement it and play a sound.
                    if (cursorIndex < rstinit.GBWK.ParamCursor.CursorPos.ListNums)
                    {
                        cmpMisc.cmpMoveCursor(rstinit.GBWK.ParamCursor, -1);
                        cmpMisc.cmpPlaySE(16 & 0xFFFF);
                    }

                    // Otherwise just play a sound.
                    // This part never happens since the menu loops.
                    else
                    { cmpMisc.cmpPlaySE(2 & 0xFFFF); }
                }

                // Check if you pressed down. Works the same as the pressing up calls, just incrementing instead.
                if (dds3PadManager.DDS3_PADCHECK_PRESS(Il2Cpplibsdf_H.SDF_PADMAP.D) && dds3PadManager.DDS3_PADCHECK_REP(Il2Cpplibsdf_H.SDF_PADMAP.D) == true)
                {
                    // Grab the cursor index.
                    cursorIndex = cmpMisc.cmpMoveCursor(rstinit.GBWK.ParamCursor, 0);

                    // If under the cap, increment and play a sound.
                    if (cursorIndex < rstinit.GBWK.ParamCursor.CursorPos.ListNums)
                    {
                        cmpMisc.cmpMoveCursor(rstinit.GBWK.ParamCursor, 1);
                        cmpMisc.cmpPlaySE(16 & 0xFFFF);
                    }

                    // Otherwise just play a sound.
                    // Again, never happens.
                    else
                    { cmpMisc.cmpPlaySE(2 & 0xFFFF); }
                }

                // If you press the cancel Button.
                if (dds3PadManager.DDS3_PADCHECK_PRESS(Il2Cpplibsdf_H.SDF_PADMAP.CANCEL) && dds3PadManager.DDS3_PADCHECK_REP(Il2Cpplibsdf_H.SDF_PADMAP.CANCEL) == true)
                {
                    // Reset your stats and play a sound.
                    rstupdate.rstResetAsignParam();
                    cmpMisc.cmpPlaySE(2 & 0xFFFF);
                }

                // If you press the OK button.
                // This can also be done with Right on the DPad, so I had to add that back in.
                if ((dds3PadManager.DDS3_PADCHECK_PRESS(Il2Cpplibsdf_H.SDF_PADMAP.OK) && dds3PadManager.DDS3_PADCHECK_REP(Il2Cpplibsdf_H.SDF_PADMAP.OK) == true)
                    || (dds3PadManager.DDS3_PADCHECK_PRESS(Il2Cpplibsdf_H.SDF_PADMAP.R) && dds3PadManager.DDS3_PADCHECK_REP(Il2Cpplibsdf_H.SDF_PADMAP.R) == true))
                {
                    // If your Stat plus the LevelUp stats exceed or go up to the maximum, then play a sound and skip the rest of the function.
                    if (datCalc.datGetBaseParam(pStock, 0) >= MAXSTATS)
                    { cmpMisc.cmpPlaySE(2 & 0xFFFF); return false; }

                    // If you still have points to assign, assing one.
                    if (rstinit.GBWK.AsignParam > 0)
                    {
                        pStock.levelupparam[cursorParam]++;
                        rstinit.GBWK.AsignParam--;
                        cmpMisc.cmpPlaySE(1 & 0xFFFF);
                    }

                    // If you ran out, ask the player if they're okay with the changes.
                    if (rstinit.GBWK.AsignParam == 0)
                    {
                        // This message asks the player if they're good.
                        fclMisc.fclStartMessage(2);

                        // This asks the player for Yes/No as their response.
                        fclMisc.fclStartSelMessage(0x2b);
                        fclMisc.gSelMsgNo = 0x2b;
                    }
                }

                // If you press the Y/Triangle button.
                // This apparently can be done with DPad Left as well, so I had to readd that in.
                if ((dds3PadManager.DDS3_PADCHECK_PRESS(Il2Cpplibsdf_H.SDF_PADMAP.OPT1) && dds3PadManager.DDS3_PADCHECK_REP(Il2Cpplibsdf_H.SDF_PADMAP.OPT1) == true)
                    || (dds3PadManager.DDS3_PADCHECK_PRESS(Il2Cpplibsdf_H.SDF_PADMAP.L) && dds3PadManager.DDS3_PADCHECK_REP(Il2Cpplibsdf_H.SDF_PADMAP.L) == true))
                {
                    // If this stat has no points assigned to it, play a sound and skip.
                    if (pStock.levelupparam[cursorParam] < 1)
                    { cmpMisc.cmpPlaySE(2 & 0xFFFF); return false; }

                    // Otherwise, remove unassign a point to redistribute and play a sound.
                    else
                    {
                        pStock.levelupparam[cursorParam]--;
                        rstinit.GBWK.AsignParam++;
                        cmpMisc.cmpPlaySE(1 & 0xFFFF);
                    }
                }

                // Recalculate HP/MP.
                pStock.maxhp = (ushort)datCalc.datGetMaxHp(pStock);
                pStock.maxmp = (ushort)datCalc.datGetMaxMp(pStock);
                return false;
            }
        }

        [HarmonyPatch(typeof(rstupdate), nameof(rstupdate.rstUpdateSeqHeartsEvent))]
        private class PatchUpdateSeqMagatamaEvent
        {
            private static void Postfix()
            {
                // Grab the current Demon (should be the Demifiend).
                datUnitWork_t pStock = rstinit.GBWK.pCurrentStock;

                // Distributes Levelup points added by the Magatama (hopefully).
                for (int i = 0; i < pStock.param.Length; i++)
                {
                    pStock.param[i] += pStock.levelupparam[i];
                    pStock.levelupparam[i] = 0;
                }

                // Recalculate HP/MP.
                pStock.maxhp = (ushort)datCalc.datGetMaxHp(pStock);
                pStock.maxmp = (ushort)datCalc.datGetMaxMp(pStock);
            }
        }

        [HarmonyPatch(typeof(rstupdate), nameof(rstupdate.rstStandbyHeartsAddPoint))]
        private class PatchMagatamaAddPoint
        {
            private static bool Prefix()
            {
                // Grab the current Demon (should be the Demifiend).
                datUnitWork_t pStock = rstinit.GBWK.pCurrentStock;

                // This is a list of Stats it needs to check.
                bool[] paramChecks = { false, false, false, false, false, false };

                // Iterate a loop through Stats and checks for if the stat's capped already and set a boolean.
                for (int i = 0; i < pStock.param.Length; i++)
                {
                    if (i == 1 && !EnableIntStat)
                    { continue; }
                    if (datCalc.datGetBaseParam(pStock, i) >= MAXSTATS)
                    { paramChecks[i] = true; }
                }

                // Loop until you find a stat to increase.
                int param = -1;
                do
                {
                    // If your stats are completely capped out, break.
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

                    // Grab a stat at random to add to.
                    param = rstCalcCore.cmbAddLevelUpParamEx(ref pStock, 1);

                    // If a stat couldn't be found, break.
                    if (param > 5 || param < 0)
                    { break; }

                    // if it's capped, search again.
                    if (datCalc.datGetBaseParam(pStock, param) >= MAXSTATS)
                    { paramChecks[param] = true; continue; }

                    // Increase their LevelUp points.
                    pStock.levelupparam[param]++;
                    break;
                }
                while (param < 0 || param > 5);

                // Recalculate HP/MP.
                pStock.maxhp = (ushort)datCalc.datGetMaxHp(pStock);
                pStock.maxmp = (ushort)datCalc.datGetMaxMp(pStock);

                return false;
            }
        }

        [HarmonyPatch(typeof(cmpMisc), nameof(cmpMisc.cmpGetParamName))]
        private class PatchGetParamName
        {
            private static bool Prefix(out string __result, sbyte Index)
            {
                // Grab the Stat's Name from a clamped index.
                Index = (sbyte)Math.Clamp((int)Index, 0, 5);
                __result = paramNames[Index];
                return false;
            }
        }

        [HarmonyPatch(typeof(cmpDrawStatus), nameof(cmpDrawStatus.cmpDrawParamPanel))]
        private class PatchDrawParamPanel
        {
            private static void CreateParamGauge(sbyte ctr2, int X, int Y, uint[] pBaseCol, datUnitWork_t pStock, sbyte CursorPos, sbyte CursorMode, sbyte FlashMode)
            {
                // If the Stat supercedes the demon's stat list, the base status object doesn't exist, or the Base Color length is 0, return.
                if (ctr2 > pStock.param.Length || pBaseCol.Length == 0 || cmpStatus.statusObj == null)
                { return; }

                // If the Stat is capped, make sure it doesn't overshoot.
                if (pStock.param[ctr2] >= MAXSTATS)
                { pStock.param[ctr2] = MAXSTATS; }

                // Grab the Status Menu object.
                GameObject stsObj = GameObject.Find("statusUI(Clone)/sstatus");

                // If there's text objects in the Status Menu's children, set up the Stat Names.
                if (stsObj.GetComponentsInChildren<TMP_Text>() != null)
                { stsObj.GetComponentsInChildren<TMP_Text>()[(ctr2 > 1 && !EnableIntStat) ? ctr2 - 1 : ctr2].SetText(Localize.GetLocalizeText(cmpMisc.cmpGetParamName(ctr2))); }

                // If there's Counter objects in the Status Menu's children, set up their values and colors.
                if (stsObj.GetComponentsInChildren<CounterCtr>() != null)
                { stsObj.GetComponentsInChildren<CounterCtr>()[(ctr2 > 1 && !EnableIntStat) ? ctr2 - 1 : ctr2].Set(datCalc.datGetParam(pStock, ctr2), Color.white, (CursorMode == 2 && CursorPos > -1) ? 1 : 0); }

                // If your Cursor Position is over -1, set the FlashMode to 2.
                // Not sure what this does.
                if (-1 < CursorPos)
                { FlashMode = 2; }

                // Rework the entire Stat Bar.
                // I have no choice but to use a custom call here. For some reason using the original prefix crashes.
                PatchDrawParamGauge.ReworkParamGauge(pBaseCol, 0x14, (sbyte)ctr2, (sbyte)ctr2, FlashMode, pStock, stsObj);
            }
            private static bool Prefix(int X, int Y, uint[] pBaseCol, sbyte[] pParamOfs, datUnitWork_t pStock, sbyte CursorPos, sbyte CursorMode, sbyte FlashMode)
            {
                // If the Base status object is null, return.
                if (cmpStatus.statusObj == null)
                { return false; }

                // If there's no demon, return.
                if (pStock == null)
                { return false; }

                // Set up the demon's HP/MP values for reference.
                int[] StatusStats = new int[] { pStock.hp, pStock.maxhp, pStock.mp, pStock.maxmp };

                // Grab the Status Menu object.
                GameObject stsObj = GameObject.Find("statusUI(Clone)/sstatus");

                // If this is null, return.
                if (stsObj == null)
                { return false; }

                // If it's inactive, return.
                if (stsObj.activeSelf == false)
                { return false; }

                // If you have a Status Bar cursor and Int is enabled, scale the cursor down.
                if (GameObject.Find(stsObj.name + "/sstatusbar_cursur") && EnableIntStat)
                {
                    Vector3 newScale = new(1, 0.9f, 1);
                    GameObject.Find(stsObj.name + "/sstatusbar_cursur").transform.localScale = newScale;
                }

                // If there's no 6th Status Bar and Int is enabled.
                if (!GameObject.Find(stsObj.name + "/sstatusbar06") && EnableIntStat)
                {
                    // Grab the first bar.
                    GameObject g2 = GameObject.Find(stsObj.name + "/sstatusbar01");

                    // If it exists.
                    if (g2 != null)
                    {
                        // Duplicate it.
                        GameObject g = GameObject.Instantiate(g2);

                        // MAKE SURE the new one stays put.
                        GameObject.DontDestroyOnLoad(g);

                        // Rename.
                        g.name = "sstatusbar06";

                        // Set parent.
                        g.transform.parent = g2.transform.parent;

                        // Set position and scale.
                        g.transform.position = g2.transform.position;
                        g.transform.localPosition = new Vector3(g2.transform.localPosition.x, g2.transform.localPosition.y - 48 * 5, g2.transform.localPosition.z);
                        g.transform.localScale = g2.transform.localScale;

                        // Iterate through all bars.
                        for (int i = 0; i < 6; i++)
                        {
                            // Grab.
                            GameObject g3 = GameObject.Find("sstatusbar0" + (i + 1));

                            // If null, continue;
                            if (g3 == null)
                            { continue; }

                            // Get position and scale.
                            Vector3 newScale = g3.transform.localScale;
                            Vector3 newPos = g3.transform.localPosition;

                            // Adjust.
                            newPos.x *= 1;
                            newPos.y *= 0.9f;
                            newPos.x *= 1;
                            newScale.x *= 1;
                            newScale.y *= 0.9f;
                            newScale.z *= 1;

                            // Set to new values.
                            g3.transform.localScale = newScale;
                            g3.transform.localPosition = newPos;
                        }
                    }
                }

                // If there's no 6th Stat Bar number and Int is enabled.
                if (!GameObject.Find(stsObj.name + "/sstatusnum06") && EnableIntStat)
                {
                    // Get the first one.
                    GameObject g2 = GameObject.Find(stsObj.name + "/sstatusnum01");

                    // If it exists.
                    if (g2 != null)
                    {
                        // Copy it.
                        GameObject g = GameObject.Instantiate(g2);

                        // MAKE SURE it stays put.
                        GameObject.DontDestroyOnLoad(g);

                        // Rename.
                        g.name = "sstatusnum06";

                        // Set parent.
                        g.transform.parent = g2.transform.parent;

                        // Set position and scale.
                        g.transform.position = g2.transform.position;
                        g.transform.localPosition = new Vector3(g2.transform.localPosition.x, g2.transform.localPosition.y - 48 * 5, g2.transform.localPosition.z);
                        g.transform.localScale = g2.transform.localScale;

                        // Iterate.
                        for (int i = 0; i < 6; i++)
                        {
                            // Grab.
                            GameObject g3 = GameObject.Find("sstatusnum0" + (i + 1));

                            // If null, continue.
                            if (g3 == null)
                            { continue; }

                            // Get position and scale.
                            Vector3 newScale = g3.transform.localScale;
                            Vector3 newPos = g3.transform.localPosition;

                            // Adjust.
                            newPos.x *= 1;
                            newPos.y *= 0.9f;
                            newPos.x *= 1;
                            newScale.x *= 1;
                            newScale.y *= 0.9f;
                            newScale.z *= 1;

                            // Set to new values.
                            g3.transform.localScale = newScale;
                            g3.transform.localPosition = newPos;
                        }
                    }
                }

                // If there's no 6th Stat Name object and Int is enabled.
                if (!GameObject.Find(stsObj.name + "/Text_stat06TM") && EnableIntStat)
                {
                    // Grab.
                    GameObject g2 = GameObject.Find(stsObj.name + "/Text_stat01TM");

                    // If it exists.
                    if (g2 != null)
                    {
                        // Copy.
                        GameObject g = GameObject.Instantiate(g2);

                        // Keep it.
                        GameObject.DontDestroyOnLoad(g);

                        // Rename.
                        g.name = "Text_stat06TM";

                        // Parent.
                        g.transform.parent = g2.transform.parent;

                        // Pos and Scale.
                        g.transform.position = g2.transform.position;
                        g.transform.localPosition = new Vector3(g2.transform.localPosition.x, g2.transform.localPosition.y - 48 * 5, g2.transform.localPosition.z);
                        g.transform.localScale = g2.transform.localScale;

                        // Iterate.
                        for (int i = 0; i < 6; i++)
                        {
                            // Grab.
                            GameObject g3 = GameObject.Find("Text_stat0" + (i + 1) + "TM");

                            // If null, continue.
                            if (g3 == null)
                            { continue; }

                            // Grab Pos and scale.
                            Vector3 newScale = g3.transform.localScale;
                            Vector3 newPos = g3.transform.localPosition;

                            // Adjust
                            newPos.x *= 1;
                            newPos.y *= 0.9f;
                            newPos.x *= 1;
                            newScale.x *= 1;
                            newScale.y *= 0.9f;
                            newScale.z *= 1;

                            // Set to new.
                            g3.transform.localScale = newScale;
                            g3.transform.localPosition = newPos;
                        }
                    }
                }

                // Check all of the Status Bar Values.
                for (int i = 0; i < 4; i++)
                {
                    // Grab.
                    GameObject g2 = GameObject.Find(stsObj.name + "/" + StatusBarValues[i]);

                    // If null, continue.
                    if (g2 == null)
                    { continue; }

                    // If its Counter has less than 4 images.
                    if (g2.GetComponent<CounterCtr>().image.Length < 4)
                    {
                        // Copy.
                        GameObject g = GameObject.Instantiate(g2.GetComponent<CounterCtr>().image[0].gameObject);

                        // Set parent.
                        g.transform.parent = g2.transform;

                        // Set pos and scale.
                        g.transform.position = g2.GetComponent<CounterCtr>().image[0].transform.position;
                        g.transform.localPosition = g2.GetComponent<CounterCtr>().image[0].transform.localPosition;
                        g.transform.localScale = g2.GetComponent<CounterCtr>().image[0].transform.localScale;

                        // Append to Counter's image list.
                        g2.GetComponent<CounterCtr>().image = g2.GetComponent<CounterCtr>().image.Append<Image>(g.GetComponent<Image>()).ToArray<Image>();

                        // Iterate.
                        for (int j = 0; j < g2.GetComponent<CounterCtr>().image.Length; j++)
                        {
                            // Grab active state then set active.
                            bool chk = g2.GetComponent<CounterCtr>().image[j].gameObject.active;
                            g2.GetComponent<CounterCtr>().image[j].gameObject.active = true;

                            // Set new pos and scale/
                            g2.GetComponent<CounterCtr>().image[j].transform.localPosition = new Vector3(60 - j * 25, 0, -4);
                            g2.GetComponent<CounterCtr>().image[j].transform.localScale = new Vector3(g2.GetComponent<CounterCtr>().image[j].transform.localScale.x * 0.85f, g2.GetComponent<CounterCtr>().image[j].transform.localScale.y * 0.85f, g2.GetComponent<CounterCtr>().image[j].transform.localScale.z);

                            // Reset active state.
                            g2.GetComponent<CounterCtr>().image[j].gameObject.active = chk;
                        }
                        // Keep it.
                        GameObject.DontDestroyOnLoad(g);
                    }
                    // Set Stat value and color.
                    g2.GetComponent<CounterCtr>().Set(StatusStats[i], Color.white, 0);
                }

                // Check the bar count.
                int bars = 5 + (EnableIntStat ? 1 : 0);

                // Iterate through all bars.
                for (int i = 0; i < bars; i++)
                {
                    // Grab the bar.
                    GameObject g2 = GameObject.Find(stsObj.name + "/sstatusnum0" + (i + 1));

                    // If null, continue.
                    if (g2 == null)
                    { continue; }

                    // If inactive, continue.
                    if (g2.activeSelf == false)
                    { continue; }

                    // If the bar's Counter has less than 3 images.
                    if (g2.GetComponent<CounterCtr>().image.Length < 3)
                    {
                        // Copy it.
                        GameObject g = GameObject.Instantiate(g2.GetComponent<CounterCtr>().image[0].gameObject);

                        // Set parent.
                        g.transform.parent = g2.transform;

                        // Set pos and scale.
                        g.transform.position = g2.GetComponent<CounterCtr>().image[0].transform.position;
                        g.transform.localPosition = g2.GetComponent<CounterCtr>().image[0].transform.localPosition;
                        g.transform.localScale = g2.GetComponent<CounterCtr>().image[0].transform.localScale;

                        // Append.
                        g2.GetComponent<CounterCtr>().image = g2.GetComponent<CounterCtr>().image.Append<Image>(g.GetComponent<Image>()).ToArray<Image>();

                        // Iterate.
                        for (int j = 0; j < g2.GetComponent<CounterCtr>().image.Length; j++)
                        {
                            // Grab active, then activate.
                            bool chk = g2.GetComponent<CounterCtr>().image[j].gameObject.active;
                            g2.GetComponent<CounterCtr>().image[j].gameObject.active = true;

                            // Set pos and scale.
                            g2.GetComponent<CounterCtr>().image[j].transform.localPosition = new Vector3(30 - j * 25 + 5, 0, -4);
                            g2.GetComponent<CounterCtr>().image[j].transform.localScale = new Vector3(g2.GetComponent<CounterCtr>().image[j].transform.localScale.x * 0.85f, g2.GetComponent<CounterCtr>().image[j].transform.localScale.y, g2.GetComponent<CounterCtr>().image[j].transform.localScale.z);

                            // Reset active.
                            g2.GetComponent<CounterCtr>().image[j].gameObject.active = chk;
                        }
                        // Keep.
                        GameObject.DontDestroyOnLoad(g);
                    }
                    // Grab Stat ID.
                    int stat = (i > 0 && !EnableIntStat) ? i + 1 : i;

                    // Set default LevelUp stat value equal to both your Level Up and Mitama Bonuses.
                    int levelstat = LevelUpPoints[stat] + pStock.levelupparam[stat] + pStock.mitamaparam[stat];

                    // Set Stat value and color.
                    g2.GetComponent<CounterCtr>().Set(pStock.param[stat] + levelstat, Color.white, 0);
                }

                // If the Status Bar UI components don't exist, return.
                if (stsObj.GetComponentsInChildren<sstatusbarUI>() == null)
                { return false; }

                // Iterate through the ui.
                for (int i = 0; i < 6; i++)
                {
                    // If Int is disabled, continue.
                    if (i == 1 && !EnableIntStat)
                    { continue; }

                    // If this particular Status UI bar doesn't exist, continue.
                    if (stsObj.GetComponentsInChildren<sstatusbarUI>()[(i > 0 && !EnableIntStat) ? i - 1 : i] == null)
                    { continue; }

                    // If it's disabled, continue.
                    if (!stsObj.GetComponentsInChildren<sstatusbarUI>()[(i > 0 && !EnableIntStat) ? i - 1 : i].gameObject.activeSelf)
                    { continue; }

                    // Create the Stat Bar.
                    CreateParamGauge((sbyte)i, (int)(X * 3.75), (int)(Y * 2.25), pBaseCol, pStock, CursorPos, CursorMode, FlashMode);
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(cmpDrawDH), nameof(cmpDrawDH.cmpDrawHeartsInfo))]
        private class PatchDrawMagatamaInfo
        {
            private static bool Prefix(cmpHeartsInfo_t pHeartsInfo, sbyte HeartsID)
            {
                // If you're not using the Int stat, just skip this entire function.
                if (!EnableIntStat)
                { return true; }

                // This is for the various loops used within this function.
                int i = 0;

                // Grab the parent object of the entire Magatama Status menu.
                GameObject g = GameObject.Find("magUI(Clone)/magstatus");
                GameObject g2;
                GameObject g3;

                // If null, return.
                if (g == null)
                { return false; }

                // If it's inactive, return.
                if (g.activeSelf == false)
                { return false; }

                // If there's no 6th base.
                if (!GameObject.Find("magUI(Clone)/magstatus/magstatus_base06"))
                {
                    // Find the first one.
                    GameObject orig = GameObject.Find("magUI(Clone)/magstatus/magstatus_base01");

                    // Copy it.
                    g2 = GameObject.Instantiate(orig);

                    // MAKE SURE it stays put.
                    GameObject.DontDestroyOnLoad(g2);

                    // Rename it.
                    g2.name = "magstatus_base06";

                    // Set its parent to the whole menu.
                    g2.transform.parent = g.transform;

                    // Adjust position and scale.
                    g2.transform.position = orig.transform.position;
                    g2.transform.localScale = orig.transform.localScale;

                    // Make sure its local position compared to the parent is correct, since it's gonna get multiplied a bit.
                    g2.transform.localPosition = new(orig.transform.localPosition.x, orig.transform.localPosition.y - 56 * 5, orig.transform.localPosition.z);

                    // Increment through all of the base bars.
                    for (i = 0; i < 6; i++)
                    {
                        // Grab the base bar
                        g3 = GameObject.Find("magUI(Clone)/magstatus/magstatus_base0" + (i + 1));

                        // If it doesn't exist, continue;
                        if (g3 == null)
                        { continue; }

                        // Grab position and scale.
                        Vector3 newScale = g3.transform.localScale;
                        Vector3 newPos = g3.transform.localPosition;

                        // Multiply position and scale.
                        newPos.x *= 1;
                        newPos.y *= 0.825f;
                        newPos.x *= 1;
                        newScale.x *= 0.825f;
                        newScale.y *= 0.825f;
                        newScale.z *= 1;

                        // Set new position and scale.
                        g3.transform.localScale = newScale;
                        g3.transform.localPosition = newPos;
                    }
                }

                // If there's no 6th item.
                if (!GameObject.Find("magUI(Clone)/magstatus/magstatus_item06"))
                {
                    // Grab the first one.
                    GameObject orig = GameObject.Find("magUI(Clone)/magstatus/magstatus_item01");

                    // Copy it.
                    g2 = GameObject.Instantiate(orig);

                    // MAKE SURE it stays put.
                    GameObject.DontDestroyOnLoad(g2.gameObject);

                    // Rename it.
                    g2.name = "magstatus_item06";

                    // Set parent.
                    g2.transform.parent = g.transform;

                    // Set position and scale.
                    g2.transform.position = orig.transform.position;
                    g2.transform.localScale = orig.transform.localScale;

                    // Make sure it's in the right spot before scaling.
                    g2.transform.localPosition = new(orig.transform.localPosition.x, orig.transform.localPosition.y - 56 * 5, orig.transform.localPosition.z);

                    // Iterate through each item.
                    for (i = 0; i < 6; i++)
                    {
                        // Grab item.
                        g3 = GameObject.Find("magUI(Clone)/magstatus/magstatus_item0" + (i + 1));

                        // If null, continue.
                        if (g3 == null)
                        { continue; }

                        // Grab position and scale.
                        Vector3 newScale = g3.transform.localScale;
                        Vector3 newPos = g3.transform.localPosition;

                        // Multiply them.
                        newPos.x *= 1;
                        newPos.y *= 0.825f;
                        newPos.x *= 1;
                        newScale.x *= 0.825f;
                        newScale.y *= 0.825f;
                        newScale.z *= 1;

                        // Set them to new values.
                        g3.transform.localScale = newScale;
                        g3.transform.localPosition = newPos;
                    }
                }

                // Draw some various things to the screen.
                fclDraw.fclDrawParts(0, 0x28 + i * 0xd0, 0, new(4), 0xb, 0, cmpInitDH.GBWK.TexHandle, etcSprTbl.cmpSprTblArry, 0x47);
                fclDraw.fclDrawParts(0, 0x28 + i * 0xd0, 0, new(4), 0xb, 1, cmpInitDH.GBWK.TexHandle, etcSprTbl.cmpSprTblArry, 0x47);

                // Grab a color.
                uint color = fclMisc.fclGetBlendColor(0x80808080, 0x40404080, (uint)pHeartsInfo.Timer);

                // Set a list to that color.
                uint[] colorptr = { color, color, color, color };

                // Check if you have this particular Magatama.
                sbyte hasHeart = cmpInitDH.cmpChkHaveHearts(HeartsID);

                // Iterate until i is 6.
                i = 0;
                do
                {
                    // Unknown value.
                    int unk = 0;

                    // If i goes over the list of Stat Names, break.
                    if (paramNames.Length < i)
                    { break; }

                    // Grab Magatama Status Item object.
                    g = GameObject.Find("magUI(Clone)/magstatus/magstatus_item0" + (i + 1));

                    // If null, increment and continue.
                    if (g == null)
                    { i++; continue; }

                    // Set up the previous object.
                    cmpUpdate.cmpSetupObject(g, hasHeart == 1 ? true : false);

                    // Grab the text object from the previous object.
                    g2 = GameObject.Find("magUI(Clone)/magstatus/" + g.name + "/TextTM");

                    // If null, increment and continue.
                    if (g2 == null)
                    { i++; continue; }

                    // Set the text object's text.
                    g2.GetComponentInChildren<TMP_Text>().SetText(Localize.GetLocalizeText(cmpMisc.cmpGetParamName((sbyte)i)));

                    // Draw more parts to the screen.
                    fclDraw.fclDrawParts(0, 0x28 + i * 0xd0, 0, colorptr, 0xb, 3, cmpInitDH.GBWK.TexHandle, etcSprTbl.cmpSprTblArry, 0x47);
                    fclDraw.fclDrawParts(0, 0x28 + i * 0xd0, 0, colorptr, 0xb, (ushort)(i + 4), cmpInitDH.GBWK.TexHandle, etcSprTbl.cmpSprTblArry, 0x47);

                    // Set up the text object.
                    cmpUpdate.cmpSetupObject(g2, true);

                    // Grab the numerical text object.
                    g2 = GameObject.Find("magUI(Clone)/magstatus/" + g.name + "/magtex");

                    // If null, increment and continue.
                    if (g2 == null)
                    { i++; continue; }

                    // Grab the Magatama Stat with ID i.
                    int heartParam = hasHeart == 1 ? rstCalcCore.cmbGetHeartsParam(HeartsID, (sbyte)i) : 0;

                    // If it's 0, set the unknown value to 11.
                    if (heartParam == 0)
                    { unk = 0xb; }

                    // Otherwise set it to 9.
                    // If you somehow get the Stat to be negative, set it to 10 instead.
                    else
                    {
                        unk = 9;
                        if (heartParam < 1)
                        { unk = 10; }
                    }

                    // More draw calls.
                    fclDraw.fclDrawParts(0, 0x28 + i * 0xd0, 0, colorptr, 0xb, (ushort)unk, cmpInitDH.GBWK.TexHandle, etcSprTbl.cmpSprTblArry, 0x47);

                    // Set up the numerical text object.
                    cmpUpdate.cmpSetupObject(g2, true);

                    // Grab the number object
                    g2 = GameObject.Find("magUI(Clone)/magstatus/" + g.name + "/magtex/num_mag");

                    // If the object's Counter is null, return.
                    if (g2.GetComponent<CounterCtr>() == null)
                    { i++; continue; }

                    // Generate a color and set the Counter's value and color.
                    Color rgb = cmpInit.GetToRGBA(hasHeart != 0 ? heartParam > 0 ? 0xFFFFFFFF : heartParam < 0 ? 0xFF8080FF : 0x80808080 : 0x80808080);
                    g2.GetComponent<CounterCtr>().Set(heartParam, rgb);

                    // Set up the number object.
                    cmpUpdate.cmpSetupObject(g2, hasHeart == 1 ? true : false);
                    i++;
                }
                while (i < 6);

                // Draw the Magatama Help panel
                cmpDrawDH.cmpDrawHeartsHelpPanel(pHeartsInfo.Timer);

                // If the Magatama object is visible, draw its name.
                if (hasHeart == 1)
                { cmpDrawDH.cmpDrawHeartsName(0, 0, 0, pHeartsInfo.Timer, (sbyte)(HeartsID)); }
                else
                { cmpDrawDH.cmpDrawHeartsName(0, 0, 0, pHeartsInfo.Timer, -1); }

                // Grab the Magamama Menu object.
                g = cmpInitDH.DHeartsObj;

                // Set it up and draw a gradient of some sort.
                cmpUpdate.cmpSetupObject(g, true);
                cmpDrawDH.cmpDrawDisactiveGrad(pHeartsInfo.Timer);
                return false;
            }
        }

        [HarmonyPatch(typeof(fclRecoverDraw), nameof(fclRecoverDraw.rcvDrawStockWindowList))]
        private class PatchRecoverReviveDraw
        {
            private static bool Prefix(GameObject obj, uint Col, sbyte localstockidx, bool curidx)
            {
                // String List of GameObject Names.
                string[] objList = { "_current", "_full" };

                // Grab the parent object of the entire Recovery menu.
                GameObject g = GameObject.Find("recovUI/rcvlist");
                GameObject g2;
                GameObject g3;
                GameObject g4;

                // If the Recovery UI doesn't exist.
                if (g == null)
                { return true; }

                // If the Recovery UI isn't active.
                if (!g.activeSelf)
                { return true; }

                // Iterate between all 9 visible rows in the Recover List.
                for (int i = 0; i < 9; i++)
                {
                    // Grab the Row.
                    g2 = GameObject.Find("recovUI/rcvlist/rcv_row/rcv_row0" + (i + 1));

                    if (g2 == null)
                    { return true; }

                    if (!g2.activeSelf)
                    { return true; }

                    // This is gonna be a bit jank, basically gotta iterate through a couple of partial object names.
                    for (int j = 0; j < objList.Length; j++)
                    {
                        // Grab one of the HP Bar GameObjects.
                        g3 = GameObject.Find("recovUI/rcvlist/rcv_row/rcv_row0" + (i + 1) + "/rcvhpbar/rcvhpnum" + objList[j]);

                        // If there's less than 4 Digits, add another one.
                        if (g3.GetComponent<CounterCtr>().image.Length < 4)
                        {
                            // Create a duplicate of the first number in the list.
                            g4 = GameObject.Instantiate(g3.GetComponent<CounterCtr>().image[0].gameObject);
                            GameObject.DontDestroyOnLoad(g4);

                            // Rename it.
                            g4.name = "num_hp04";

                            // Parent it.
                            g4.transform.parent = g3.transform;

                            // Set up original local Position and Scale.
                            g4.transform.localPosition.Set(g3.transform.localPosition.x - 30, g3.transform.localPosition.y, g3.transform.localPosition.z);
                            g4.transform.localScale = g3.GetComponent<CounterCtr>().image[0].transform.localScale;

                            // Add it to the CounterCtr's image list.
                            g3.GetComponent<CounterCtr>().image = g3.GetComponent<CounterCtr>().image.Append<Image>(g4.GetComponent<Image>()).ToArray<Image>();

                            // Iterate through the objects and reposition/rescale them.
                            for (int k = 0; k < g3.GetComponent<CounterCtr>().image.Length; k++)
                            {
                                // Grab the game object.
                                g4 = g3.GetComponent<CounterCtr>().image[k].gameObject;

                                // Grab position and scale.
                                Vector3 newPos = g4.transform.localPosition;
                                Vector3 newScale = g4.transform.localScale;

                                // Change position and scale.
                                newPos.x += 15;
                                newPos.x *= 0.825f;
                                newPos.y *= 0.825f;
                                newPos.z *= 1;
                                newScale.x *= 0.825f;
                                newScale.y *= 0.825f;
                                newScale.z *= 1;

                                g4.transform.localPosition = newPos;
                                g4.transform.localScale = newScale;
                            }
                        }
                    }

                    // This is gonna be a bit jank, basically gotta iterate through a couple of partial object names.
                    for (int j = 0; j < objList.Length; j++)
                    {
                        // Grab one of the HP Bar GameObjects.
                        g3 = GameObject.Find("recovUI/rcvlist/rcv_row/rcv_row0" + (i + 1) + "/rcvmpbar/rcvmpnum" + objList[j]);

                        // If there's less than 4 Digits, add another one.
                        if (g3.GetComponent<CounterCtr>().image.Length < 4)
                        {
                            // Create a duplicate of the first number in the list.
                            g4 = GameObject.Instantiate(g3.GetComponent<CounterCtr>().image[0].gameObject);
                            GameObject.DontDestroyOnLoad(g4);

                            // Rename it.
                            g4.name = "num_mp04";

                            // Parent it.
                            g4.transform.parent = g3.transform;

                            // Set up original local Position and Scale.
                            g4.transform.localPosition.Set(g3.transform.localPosition.x - 30, g3.transform.localPosition.y, g3.transform.localPosition.z);
                            g4.transform.localScale = g3.GetComponent<CounterCtr>().image[0].transform.localScale;

                            // Add it to the CounterCtr's image list.
                            g3.GetComponent<CounterCtr>().image = g3.GetComponent<CounterCtr>().image.Append<Image>(g4.GetComponent<Image>()).ToArray<Image>();

                            // Iterate through the objects and reposition/rescale them.
                            for (int k = 0; k < g3.GetComponent<CounterCtr>().image.Length; k++)
                            {
                                // Grab the game object.
                                g4 = g3.GetComponent<CounterCtr>().image[k].gameObject;

                                // Grab position and scale.
                                Vector3 newPos = g4.transform.localPosition;
                                Vector3 newScale = g4.transform.localScale;

                                // Change position and scale.
                                newPos.x += 15;
                                newPos.x *= 0.825f;
                                newPos.y *= 0.825f;
                                newPos.z *= 1;
                                newScale.x *= 0.825f;
                                newScale.y *= 0.825f;
                                newScale.z *= 1;

                                g4.transform.localPosition = newPos;
                                g4.transform.localScale = newScale;
                            }
                        }
                    }
                }

                return true;
            }
        }

        [HarmonyPatch(typeof(cmpDrawStatus), nameof(cmpDrawStatus.cmpDrawParamGauge))]
        private class PatchDrawParamGauge
        {
            // This should NEVER get called, but if it ever does this is here as a back up.
            private static bool Prefix(int X, int Y, uint[] pBaseCol, int StepY, sbyte Pos, sbyte ParamOfs, sbyte FlashMode, datUnitWork_t pStock, GameObject stsObj)
            {
                // If no demon or status object, return.
                if (pStock == null || stsObj == null)
                { return false; }
                // Rework the Stat Bar.
                ReworkParamGauge(pBaseCol, StepY, Pos, ParamOfs, FlashMode, pStock, stsObj);
                return false;
            }
            private static void Postfix(int X, int Y, uint[] pBaseCol, int StepY, sbyte Pos, sbyte ParamOfs, sbyte FlashMode, datUnitWork_t pStock, GameObject stsObj)
            {
                // If no demon or status object, return.
                if (pStock == null || stsObj == null)
                { return; }
                // Rework the Stat Bar.
                ReworkParamGauge(pBaseCol, StepY, Pos, ParamOfs, FlashMode, pStock, stsObj);
                return;
            }

            public static void ReworkParamGauge(uint[] pBaseCol, int StepY, sbyte Pos, sbyte ParamOfs, sbyte FlashMode, datUnitWork_t pStock, GameObject stsObj)
            {
                // If the Status Bar UI count is wrong, return.
                if (stsObj.GetComponentsInChildren<sstatusbarUI>().Length < 5 + (EnableIntStat ? 1 : 0))
                { return; }

                // If the Stat is over 1 and Int doesn't exist, decrement.
                int stat = ParamOfs;
                if (stat > 0 && !EnableIntStat)
                { stat--; }

                // If the number of Animator objects within the Stat Bar of a particular Stat isn't equal to 4.
                if (stsObj.GetComponentsInChildren<sstatusbarUI>()[stat].gameObject.GetComponentsInChildren<Animator>().Length != 4)
                {
                    // This gets set within the while loops.
                    GameObject g;

                    // While the count is over, destroy the extra objects.
                    while (stsObj.GetComponentsInChildren<sstatusbarUI>()[stat].gameObject.GetComponentsInChildren<Animator>().Length > 4)
                    {
                        g = stsObj.GetComponentsInChildren<sstatusbarUI>()[stat].gameObject.GetComponentsInChildren<Animator>()[stsObj.GetComponentsInChildren<sstatusbarUI>()[stat].gameObject.GetComponentsInChildren<Animator>().Length - 1].gameObject;
                        g.transform.parent = null;
                        GameObject.Destroy(g);
                    }

                    // If the background bar is null, load it from the Asset Bundle.
                    // This is a custom AssetBundle you have to manually put in the right place.
                    if (barData == null)
                    { barData = AssetBundle.LoadFromFile(AppContext.BaseDirectory + BundlePath + barSpriteName); AssetBundle.DontDestroyOnLoad(barData); }

                    // If it's no longer null.
                    if (barData != null)
                    {
                        // Load its Texture2D.
                        Texture2D barAsset = barData.LoadAsset("sstatusbar_base_empty").Cast<Texture2D>();

                        // Keep it.
                        Texture2D.DontDestroyOnLoad(barAsset);

                        // Create a Sprite from the Texture2D and make sure to apply the Texture.
                        Sprite barSprite = Sprite.Create(barAsset, new Rect(0, 0, barAsset.width, barAsset.height), Vector2.zero);
                        barSprite.texture.Apply();

                        // Keep it.
                        Sprite.DontDestroyOnLoad(barSprite);

                        // Set the Stat Bar's sprite.
                        stsObj.GetComponentsInChildren<sstatusbarUI>()[stat].gameObject.GetComponentInChildren<Image>().sprite = barSprite;

                        // Set the Bar Segment Sprites
                        for (int i = 0; i < 4; i++)
                        {
                            // Find the necessary game object.
                            string path = stsObj.GetComponentsInChildren<sstatusbarUI>()[stat].gameObject.name + "/" + stsObj.GetComponentsInChildren<sstatusbarUI>()[stat].gameObject.GetComponentsInChildren<Animator>()[i].gameObject.name;
                            g = GameObject.Find(path + "/sstatusbar_red");

                            // Load the Red Segment Texture.
                            barAsset = barData.LoadAsset("statussegment_red").Cast<Texture2D>();

                            // Keep it.
                            Texture2D.DontDestroyOnLoad(barAsset);

                            // Create a Sprite from the Texture2D and make sure to apply the Texture.
                            barSprite = Sprite.Create(barAsset, new Rect(0, 0, barAsset.width, barAsset.height), Vector2.zero);
                            barSprite.texture.Apply();

                            // Keep it.
                            Sprite.DontDestroyOnLoad(barSprite);

                            // Set the Segment's Sprite.
                            g.GetComponent<Image>().sprite = barSprite;

                            // Set Pos and Scale of this particular Segment.
                            g.transform.localPosition = new(0f, 0f, 0f);
                            g.transform.localScale = new(0.35f, 0.35f, 1f);

                            // Set the previous object's internal sprite to the same sprite.
                            g = GameObject.Find(path + "/sstatusbar_red/sstatusbar_redg");
                            g.GetComponent<Image>().sprite = barSprite;

                            // Find the necessary game object.
                            g = GameObject.Find(path + "/sstatusbar_blue");

                            // Load the Blue Segment Texture.
                            barAsset = barData.LoadAsset("statussegment_blue").Cast<Texture2D>();

                            // Keep it.
                            Texture2D.DontDestroyOnLoad(barAsset);

                            // Create a Sprite from the Texture2D and make sure to apply the Texture.
                            barSprite = Sprite.Create(barAsset, new Rect(0, 0, barAsset.width, barAsset.height), Vector2.zero);
                            barSprite.texture.Apply();

                            // Keep it.
                            Sprite.DontDestroyOnLoad(barSprite);

                            // Set the Segment's Sprite.
                            g.GetComponent<Image>().sprite = barSprite;

                            // Set Pos and Scale of this particular Segment.
                            g.transform.localPosition = new(0f, 0f, 0f);
                            g.transform.localScale = new(0.35f, 0.35f, 1f);

                            // Set the previous object's internal sprite to the same sprite.
                            g = GameObject.Find(path + "/sstatusbar_blue/sstatusbar_blueg");
                            g.GetComponent<Image>().sprite = barSprite;
                        }
                    }
                }

                // Magatama Value.
                int heartValue = 0;
                if ((pStock.flag >> 2 & 1) == 0)
                { heartValue = 0; }
                else
                { heartValue = rstCalcCore.cmbGetHeartsParam((sbyte)dds3GlobalWork.DDS3_GBWK.heartsequip, ParamOfs); }

                // Stat Value
                int paramValue = pStock.param[ParamOfs];

                // Mitama Bonus Value.
                int mitamaValue = pStock.mitamaparam[ParamOfs];

                // LevelUp Value.
                int levelupValue = pStock.levelupparam[ParamOfs];

                // Set up the values into a list.
                int[] values = new int[] { Math.Max(paramValue - heartValue, 0), levelupValue, mitamaValue, heartValue };

                // Iterate through the Animator list to set the correct scale and position.
                float posOffset = 0;
                for (int len = 0; len < 4; len++)
                {
                    // Grab pos and scale.
                    Vector3 barScale = stsObj.GetComponentsInChildren<sstatusbarUI>()[stat].gameObject.GetComponentsInChildren<Animator>()[len].gameObject.transform.localScale;
                    Vector3 barPos = stsObj.GetComponentsInChildren<sstatusbarUI>()[stat].gameObject.GetComponentsInChildren<Animator>()[len].gameObject.transform.localPosition;

                    // Adjust the next value to be shorter if this exceeds the maximum.
                    if (posOffset + values[len] > MAXSTATS)
                    { values[len] = (int)Math.Clamp(values[len], 0f, Math.Max(MAXSTATS - posOffset, 0f)); }

                    // Adjust.
                    barScale.x = BAR_SCALE_X * values[len];
                    barPos.x = 274 + BAR_SEGMENT_X * 1.45f * BAR_SCALE_X * posOffset;
                    barPos.y = -16f;

                    // Iterate from the value list.
                    posOffset += values[len];

                    // Set new.
                    stsObj.GetComponentsInChildren<sstatusbarUI>()[stat].gameObject.GetComponentsInChildren<Animator>()[len].gameObject.transform.localScale = barScale;
                    stsObj.GetComponentsInChildren<sstatusbarUI>()[stat].gameObject.GetComponentsInChildren<Animator>()[len].gameObject.transform.localPosition = barPos;

                    // Set the Animator Color
                    stsObj.GetComponentsInChildren<sstatusbarUI>()[stat].gameObject.GetComponentsInChildren<Animator>()[len].SetInteger("sstatusbar_color", (len >= 2 ? 3 : len + 1));
                }

                // If Stat Position is greater than or equal to Blink que length, cap it.
                if (Pos >= cmpDrawStatus.gStatusBlinkQue.Length && cmpDrawStatus.gStatusBlinkQue.Length > 0)
                { Pos = (sbyte)(cmpDrawStatus.gStatusBlinkQue.Length - 1); }

                // If FlashMode is at least 0 or higher but under 3, set the Blink Color to FlashMode.
                if (FlashMode >= 0 && FlashMode < 3)
                { cmpDrawStatus.cmpStatMakeBlinkCol(cmpDrawStatus.gStatusBlinkQue[Pos], FlashMode, pCol); }

                // If FlashMode is 3.
                if (FlashMode == 3)
                {
                    // If the Blink que value is not 0, set the Blink color to 0.
                    if (cmpDrawStatus.gStatusBlinkQue[Pos] != 0)
                    { cmpDrawStatus.cmpStatMakeBlinkCol(cmpDrawStatus.gStatusBlinkQue[Pos], 0, pCol); }
                }

                // If Flash Mode is 4 or 5, set the Blink color to FlashMode.
                if (FlashMode == 4 || FlashMode == 5)
                { cmpDrawStatus.cmpStatMakeBlinkCol(cmpDrawStatus.gStatusBlinkQue[Pos], FlashMode, pCol); }
                return;
            }
        }
    }
}
