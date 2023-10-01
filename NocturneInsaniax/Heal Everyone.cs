using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using Il2Cppnewdata_H;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        // List of unit IDs to keep tabs on who has already been healed by the game's vanilla behavior
        static List<ushort> demonsAlreadyHealed = new List<ushort>();

        // Before applying the effect of a skill/item
        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datExecSkill))]
        private class HealEveryonePatch
        {
            public static bool Prefix(ref int nskill, ref datUnitWork_t d)
            {
                // If using Media, Mediarama, Mediarahan/Bead Chain, Great Chakra or Bead of Life
                if (nskill == 39 || nskill == 40 || nskill == 41 || nskill == 84 || nskill == 92)
                {
                    // If skill/item already used on target (or target dead), skip datExectSkill
                    if (demonsAlreadyHealed.Contains(d.id) || d.hp == 0) return false;

                    // Else add it to the list and apply the skill/item
                    else demonsAlreadyHealed.Add(d.id);
                }

                return true;
            }
        }

        // After selecting a skill (outside of battle)
        [HarmonyPatch(typeof(cmpMisc), nameof(cmpMisc.cmpUseSkillTokusyu))]
        private class HealEveryonePatch2
        {
            public static void Postfix(ref ushort SkillID, ref datUnitWork_t pSrc)
            {
                // Clears "the list"
                demonsAlreadyHealed.Clear();

                // If using Media, Mediarama or Mediarahan
                if (SkillID == 39 || SkillID == 40 || SkillID == 41)
                {
                    // Apply effect on EVERYONE (including stock)
                    foreach (datUnitWork_t unit in dds3GlobalWork.DDS3_GBWK.unitwork)
                    {
                        datCalc.datExecSkill(SkillID, pSrc, unit); // Will be skipped if the unit is already in "the list" 
                    }
                }
            }
        }

        // After selecting an item (outside of battle)
        [HarmonyPatch(typeof(cmpMisc), nameof(cmpMisc.cmpUseItemTokusyu))]
        private class HealEveryonePatch3
        {
            public static void Postfix(ref ushort ItemID, ref datUnitWork_t pSrc, ref datUnitWork_t pDst)
            {
                // Clears "the list"
                demonsAlreadyHealed.Clear();

                // If using a Bead Chain, Great Chakra or Bead or Life
                if (ItemID == 5 || ItemID == 8 || ItemID == 11)
                {
                    // Apply effect on EVERYONE (including stock)
                    foreach (datUnitWork_t unit in dds3GlobalWork.DDS3_GBWK.unitwork)
                    {
                        switch (ItemID)
                        {
                            case 5:
                                datCalc.datExecSkill(41, pSrc, unit); // Will be skipped if the unit is already in "the list"
                                break;
                            case 8:
                                datCalc.datExecSkill(84, pSrc, unit); // ...
                                break;
                            case 11:
                                datCalc.datExecSkill(92, pSrc, unit); // ...
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        // After checking if a target needs healing
        [HarmonyPatch(typeof(cmpCalc), nameof(cmpCalc.cmpStartSkillMsg))]
        private class HealEveryonePatch5
        {
            public static void Postfix(ref ushort SkillID, ref int __result)
            {
                // If the game thinks the skill/item is useless for the main party
                if (__result != 0)
                {
                    // If the skill/item is Media, Mediarama, Mediarahan/Bead Chain or Bead of Life
                    if (SkillID == 39 || SkillID == 40 || SkillID == 41 || SkillID == 92)
                    {
                        // If SOMEONE (including stock) needs HP (without being dead)
                        foreach (datUnitWork_t i in dds3GlobalWork.DDS3_GBWK.unitwork)
                        {
                            if (i.hp != 0 && i.hp != i.maxhp)
                            {
                                __result = 0; // Forces the game to let the player use it
                                return;
                            }
                        }
                    }

                    // If the item is Great Chakra or Bead of Life
                    if (SkillID == 84 || SkillID == 92)
                    {
                        // If SOMEONE (including stock) needs MP
                        foreach (datUnitWork_t i in dds3GlobalWork.DDS3_GBWK.unitwork)
                        {
                            if (i.mp != i.maxmp)
                            {
                                __result = 0; // Forces the game to let the player use it
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}