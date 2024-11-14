using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using UnityEngine;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        public static bool[] heartMastered = new bool[26];

        // Before displaying the skills
        [HarmonyPatch(typeof(cmpDrawStatus), nameof(cmpDrawStatus.cmpDrawSkill))]
        private class InfiniteMagatamaSkillsPatch
        {
            public static void Prefix(ref datUnitWork_t pStock, ref rstSkillInfo_t pSkillInfo)
            {
                // If currently looking at Demi-fiend's status
                if (pStock.id == 0)
                {
                    byte currentMagatama = dds3GlobalWork.DDS3_GBWK.heartsequip; // ID of the magatama currently "equipped"

                    // If DF is out of skills to learn from this magatama, and he doesn't know at least one of this magatama's skills and the magatama has been mastered
                    if (pSkillInfo.SkillID[0] == 0 && dds3GlobalWork.DDS3_GBWK.heartsskcnt[currentMagatama] != 0 && rstCalcCore.cmbChkHeartsMaster(currentMagatama) == 1)
                    {
                        dds3GlobalWork.DDS3_GBWK.heartsskcnt[currentMagatama] = 0; // Reset the progression of learned skills from this magatama
                    }

                    // While DF knows each skill of this magatama and there are still skills to learn
                    while (InfiniteMagatamaSkillsUtility.hasDemifiendThatSkill(tblHearts.fclHeartsTbl[currentMagatama].Skill[dds3GlobalWork.DDS3_GBWK.heartsskcnt[currentMagatama]].ID) && tblHearts.fclHeartsTbl[currentMagatama].Skill[dds3GlobalWork.DDS3_GBWK.heartsskcnt[currentMagatama]].ID != 0)
                    {
                        dds3GlobalWork.DDS3_GBWK.heartsskcnt[currentMagatama]++; // Skip the skill in the progression of learned skills from this magatama
                    }
                }
            }
        }

        // After checking if a magatama has been mastered
        [HarmonyPatch(typeof(rstCalcCore), nameof(rstCalcCore.cmbChkHeartsMaster))]
        private class InfiniteMagatamaSkillsPatch2
        {
            public static void Postfix(ref byte HeartsID, ref sbyte __result)
            {
                int consumedSkillsLength = InfiniteMagatamaSkillsUtility.GetConsummedSkillsLength(HeartsID); // Get the progression of learned skills from this magatama
                int MagatamaSkillsLength = InfiniteMagatamaSkillsUtility.GetMagatamaSkillsLength(HeartsID); // Get the number of learnable skills from this magatama

                //if (consumedSkillsLength < MagatamaSkillsLength) __result = 0; // If not all learnable skills have been learned at least once, the magatama isn't mastered
                //else __result = 1;

                if (consumedSkillsLength < MagatamaSkillsLength) heartMastered[HeartsID] = false; // If not all learnable skills have been learned at least once, the magatama isn't mastered
                else heartMastered[HeartsID] = true;
            }
        }

        private class InfiniteMagatamaSkillsUtility
        {
            // Returns the progression of learned skills from this magatama
            public static int GetConsummedSkillsLength(int HeartsID)
            {
                for (int i = 0; i < dds3GlobalWork.DDS3_GBWK.hearts_sk[HeartsID].Length; i++)
                {
                    if (dds3GlobalWork.DDS3_GBWK.hearts_sk[HeartsID][i] == 0)
                    {
                        return i;
                    }
                }
                return -1; // Not gonna happen
            }

            // Returns the number of learnable skills from this magatama
            public static int GetMagatamaSkillsLength(int HeartsID)
            {
                for (int i = 0; i < tblHearts.fclHeartsTbl[HeartsID].Skill.Length; i++)
                {
                    if (tblHearts.fclHeartsTbl[HeartsID].Skill[i].ID == 0)
                    {
                        return i;
                    }
                }
                return -1; // Not gonna happen
            }

            // Returns true if Demi-fiend has the skill
            public static bool hasDemifiendThatSkill(ushort SkillID)
            {
                for (int i = 0; i < dds3GlobalWork.DDS3_GBWK.unitwork[0].skill.Length; i++)
                {
                    if (dds3GlobalWork.DDS3_GBWK.unitwork[0].skill[i] == SkillID)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
