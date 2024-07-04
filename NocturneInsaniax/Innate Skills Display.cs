using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2CppTMPro;
using UnityEngine.UI;
using UnityEngine;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        static ushort demonCurrentlyDisplayed = 0;
        static int skillTraitID = 240;

        // Before displaying a skill in the "Skill" submenu
        [HarmonyPatch(typeof(cmpDrawSkill), nameof(cmpDrawSkill.cmpSkillNameCostDraw))]
        private class InnateSkillPatch1
        {
            public static void Prefix(datUnitWork_t pStock)
            {
                demonCurrentlyDisplayed = pStock.id; // Remember the current demon
            }
        }

        [HarmonyPatch(typeof(cmpDrawStatus), nameof(cmpDrawStatus.cmpDrawSkill))]
        private class InnateSkillPatch2
        {
            // Before displaying skills in the status/level up/fusion/compendium menu 
            public static void Prefix(ref datUnitWork_t pStock, rstSkillInfo_t pSkillInfo)
            {
                // Add the trait skill to the list of displayed upcoming skills
                pSkillInfo.SkillID[pSkillInfo.SkillCnt] = (ushort)skillTraitID;
                pSkillInfo.SkillCnt++;

                // Remember the demon currently being looked at
                demonCurrentlyDisplayed = pStock.id;
            }

            // After displaying skills in the demon/magatama/level up/fusion/compendium status menu 
            public static void Postfix(datUnitWork_t pStock, rstSkillInfo_t pSkillInfo)
            {
                // For each upcoming skill
                for (int i = 0; i < pSkillInfo.SkillID.Length; i++)
                {
                    // Get the skill's ID
                    ushort skillID = pSkillInfo.SkillID[i];

                    // Don't do anything if there's no skill
                    if (skillID == 0) break;

                    if (skillID == 425 && pStock.id == 0)
                    {
                        // If you cannot get "Pierce"
                        if (!EventBit.evtBitCheck(2241))
                        {
                            cmpStatus._statusUIScr.awaitText[i].text = "？"; // Displays a "？"
                        }
                        continue; //Skip "Pierce" on Demi-fiend
                    }
                    // Display the trait skill with different colors
                    else if (skillID == skillTraitID)
                    {
                        string name = datSkillName.Get(skillID, pStock.id);
                        cmpStatus._statusUIScr.awaitText[i].text = EnableSkillColourOutlines.Value
                            ? name
                            : "<material=\"TMC00\">" + name;

                        cmpStatus._statusUIScr.transform.Find("sskill/sskill_await0" + (i + 1) + "/sskill_base").gameObject.active = false;
                        cmpStatus._statusUIScr.transform.Find("sskill/sskill_await0" + (i + 1) + "/sskill_base_2").gameObject.active = true;
                    }
                    // Force the regular upcoming skills to always be dark, even on the magatama's status menu
                    else
                    {
                        cmpStatus._statusUIScr.transform.Find("sskill/sskill_await0" + (i + 1) + "/sskill_base").gameObject.active = true;
                        cmpStatus._statusUIScr.transform.Find("sskill/sskill_await0" + (i + 1) + "/sskill_base_2").gameObject.active = false;
                    }
                }

                //for (int i = 0; i < pSkillInfo.SkillID.Length; i++)
                //{
                //    ushort skillID = pSkillInfo.SkillID[i];
                //    if (skillID == 0) break;
                //    if (skillID == 425 && pStock.id == 0)
                //    {
                //        // If you cannot get "Pierce"
                //        if (!EventBit.evtBitCheck(2241))
                //        {
                //            //cmpStatus._statusUIScr.awaitText[i].text = "<material=\"TMC14\">？"; // Displays a "？"
                //            cmpStatus._statusUIScr.awaitText[i].text = "？"; // Displays a "？"
                //        }
                //        continue; //Skip "Pierce" on Demi-fiend
                //    }

                //    string name = datSkillName.Get(skillID, pStock.id);
                //    //cmpStatus._statusUIScr.awaitText[i].text = "<material=\"TMC14\">" + name;
                //    cmpStatus._statusUIScr.awaitText[i].text = name;
                //}
            }
        }

        // After getting the name of a skill
        [HarmonyPatch(typeof(datSkillName), nameof(datSkillName.Get))]
        private class InnateSkillPatch3
        {
            public static void Postfix(int id, ref string __result)
            {
                // If it's the trait skill
                if (id == skillTraitID)
                {
                    string skillName;

                    // If it's Demi-fiend's trait skill
                    if (demonCurrentlyDisplayed == 0)
                    {
                        // Display the name of the currently equipped magatama
                        skillName = datHeartsName.Get(dds3GlobalWork.DDS3_GBWK.heartsequip);
                    }

                    // If it's a demon's trait skill
                    else
                    {
                        // Display the name of the currently displayed demon
                        skillName = datDevilName.Get(demonCurrentlyDisplayed);
                    }

                    __result = "Trait: " + skillName;
                }
            }
        }

        // After getting the description of a skill
        [HarmonyPatch(typeof(datSkillHelp_msg), nameof(datSkillHelp_msg.Get))]
        private class InnateSkillPatch4
        {
            public static void Postfix(int id, ref string __result)
            {
                // If it's the trait skill
                if (id == skillTraitID)
                {
                    // If it's Demi-fiend's trait skill
                    if (demonCurrentlyDisplayed == 0)
                    {
                        // Display the name of the currently equipped magatama
                        __result = datHeartsName.Get(dds3GlobalWork.DDS3_GBWK.heartsequip) + "'s trait skill.";
                    }

                    // If it's a demon's trait skill
                    else
                    {
                        // Display the name of the currently displayed demon
                        __result = datDevilName.Get(demonCurrentlyDisplayed) + "'s trait skill.";
                    }
                }
            }
        }

        // Before updating the cursor when selecting demons from the command menu
        [HarmonyPatch(typeof(cmpUpdate), nameof(cmpUpdate.cmpUpdateDevilSelect))]
        private class InnateSkillPatch5
        {
            public static void Prefix(sbyte BufIdx)
            {
                // Restrict the following code to the skill and party submenus (I couldn't find how to narrow it down further)
                if (BufIdx == 0)
                {
                    // For each demons in stock
                    for (int i = 0; i < dds3GlobalWork.DDS3_GBWK.unitwork.Length; i++)
                    {
                        // Skip "ghost" demon slots
                        if (i != 0 && dds3GlobalWork.DDS3_GBWK.unitwork[i].id == 0) continue;

                        // Get the ID of the last skill currently equipped and its index
                        int skillCount = dds3GlobalWork.DDS3_GBWK.unitwork[i].skillcnt;
                        int lastSkillIndex = skillCount - 1;
                        int lastSkill = dds3GlobalWork.DDS3_GBWK.unitwork[i].skill[lastSkillIndex];

                        // If it's not the trait skill, add it at the bottom of the list
                        if (lastSkill != skillTraitID)
                        {
                            dds3GlobalWork.DDS3_GBWK.unitwork[i].skill[lastSkillIndex + 1] = skillTraitID;
                            dds3GlobalWork.DDS3_GBWK.unitwork[i].skillcnt++;
                        }
                    }
                }
            }
        }

        // Before updating the cursor on the main command menu
        [HarmonyPatch(typeof(cmpUpdate), nameof(cmpUpdate.cmpUpdateRoot))]
        private class InnateSkillPatch6
        {
            public static void Prefix()
            {
                // For each demons in stock
                for (int i = 0; i < dds3GlobalWork.DDS3_GBWK.unitwork.Length; i++)
                {
                    // Skip "ghost" demon slots
                    if (i != 0 && dds3GlobalWork.DDS3_GBWK.unitwork[i].id == 0) continue;

                    // Get the ID of the last skill currently equipped and its index
                    int skillCount = dds3GlobalWork.DDS3_GBWK.unitwork[i].skillcnt;
                    int lastSkillIndex = skillCount - 1;
                    int lastSkill = dds3GlobalWork.DDS3_GBWK.unitwork[i].skill[lastSkillIndex];

                    // If it's the trait skill, remove it
                    if (lastSkill == skillTraitID)
                    {
                        dds3GlobalWork.DDS3_GBWK.unitwork[i].skill[lastSkillIndex] = 0;
                        dds3GlobalWork.DDS3_GBWK.unitwork[i].skillcnt--;
                    }
                }
            }
        }

        // After running the analysis panel
        [HarmonyPatch(typeof(nbPanelProcess), nameof(nbPanelProcess.nbPanelAnalyzeRun))]
        private class InnateSkillPatch7
        {
            public static void Postfix()
            {
                // There is someone to analyze
                if (nbPanelProcess.pNbPanelAnalyzeUnitWork != null)
                {
                    demonCurrentlyDisplayed = nbPanelProcess.pNbPanelAnalyzeUnitWork.id; // Target's ID

                    // Replace the 9th skill by the trait (overrides what the "Analyze bosses" mod does)
                    nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(240);
                    nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_skill01").gameObject.GetComponent<Image>().color = new Color(0, 1, 0.75f, 1);
                }
            }
        }
    }
}