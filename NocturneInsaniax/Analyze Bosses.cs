﻿using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using Il2CppTMPro;
using Il2Cppresult2_H;
using Il2Cppnewdata_H;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        static bool isHPMPOn = true; // Remembers if the HP/MP related numbers are displayed

        // After checking if the analysis panel should be hidden
        [HarmonyPatch(typeof(datAnalyzeOff), nameof(datAnalyzeOff.Get))]
        private class AnalyzeBossesPatch
        {
            public static void Postfix(ref byte __result)
            {
                __result = 0; // Always decide NOT to hide the analysis panel
            }
        }

        // Before running the analysis panel
        [HarmonyPatch(typeof(nbPanelProcess), nameof(nbPanelProcess.nbPanelAnalyzeRun))]
        private class AnalyzeBossesPatch1
        {
            public static void Prefix()
            {
                // Waits a bit before searching for 
                if (nbMainProcess.GetBattleUI(5) != null && !isHPMPOn)
                {
                    // Display HP and MP info (in case it was hidden for a boss)
                    AnalyzeBossesUtility.DisplayHPMP(true);
                    isHPMPOn = true;
                }
            }
        }

        // After running the analysis panel
        [HarmonyPatch(typeof(nbPanelProcess), nameof(nbPanelProcess.nbPanelAnalyzeRun))]
        private class AnalyzeBossesPatch2
        {
            public static void Postfix()
            {
                // There is someone to analyze
                if (nbPanelProcess.pNbPanelAnalyzeUnitWork != null)
                {
                    string affinitiesText; // Text for the affinities

                    int ID = nbPanelProcess.pNbPanelAnalyzeUnitWork.id; // Target's ID
                    switch (ID)
                    {
                        case 0318: //Will o' Wisp
                            affinitiesText = datAisyoName.Get(137);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(190);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(67);
                            break;
                        case 0319: //Preta
                            affinitiesText = datAisyoName.Get(131);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(123);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(65);
                            break;
                        case 0256: //Forneus
                            affinitiesText = datAisyoName.Get(74);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(7);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(10);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(244);
                            break;
                        case 0257: //Specter1 (Not merged)
                            affinitiesText = datAisyoName.Get(257);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(192);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(66);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(52);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(51);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(318);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(366);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(345);
                            break;
                        case 0273: //Specter2
                            affinitiesText = datAisyoName.Get(273);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(25);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(191);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            break;
                        case 0275: //Specter3
                            affinitiesText = datAisyoName.Get(275);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(152);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            break;
                        case 0294: //Specter4 (6 merged)
                            affinitiesText = datAisyoName.Get(294);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(153);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(3);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(56);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(63);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(26);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(366);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(345);
                            break;
                        case 0295: //Specter5 (4 or 5 merged)
                            affinitiesText = datAisyoName.Get(295);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(153);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(3);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(56);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(63);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(26);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(366);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(345);
                            break;
                        case 0296: //Specter6 (2 or 3 merged)
                            affinitiesText = datAisyoName.Get(296);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(153);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(3);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(56);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(63);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(26);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(366);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(345);
                            break;
                        case 0316: //Nekomata
                            affinitiesText = datAisyoName.Get(86);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(62);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(125);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(198);
                            break;
                        case 0317: //Troll
                            affinitiesText = datAisyoName.Get(55);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(98);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(181);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(427);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            break;
                        case 0300: //Orthrus
                            affinitiesText = datAisyoName.Get(82);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(2);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(3);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(5);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(125);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(430);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(176);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(177);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(203);
                            break;
                        case 0301: //Yaksini
                            affinitiesText = datAisyoName.Get(100);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(20);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(21);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(23);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(461);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(185);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(109);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(211);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(63);
                            break;
                        case 0302: //Thor1
                            affinitiesText = "Drn: Elec • Null: Light • Weak: Curse/Nerve";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(14);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(16);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(17);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(428);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(469);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(457);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            break;
                        case 0337: //Thor2
                            affinitiesText = datAisyoName.Get(22);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(15);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(18);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(183);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(97);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(109);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(67);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            break;
                        case 0307: //Eligor1
                            affinitiesText = "Null: Dark • Str: Phys • Weak: Elec";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(98);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(97);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(32);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(66);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(226);
                            break;
                        case 0308: //Eligor2
                            affinitiesText = "Null: Dark • Str: Phys • Weak: Elec";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(98);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(97);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(32);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(66);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(226);
                            break;
                        case 0309: //Eligor3
                            affinitiesText = "Null: Dark • Str: Phys • Weak: Elec";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(98);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(97);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(32);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(66);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(226);
                            break;
                        case 0312: //Berith
                            affinitiesText = datAisyoName.Get(72);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(101);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(5);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(177);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(226);
                            break;
                        case 0260: //Incubus
                            affinitiesText = datAisyoName.Get(118);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(199);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(214);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(192);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(125);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(461);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(23);
                            break;
                        case 0261: //Koppa
                            affinitiesText = datAisyoName.Get(52);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(461);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(20);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(59);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(226);
                            break;
                        case 0310: //Kelpie1
                            affinitiesText = datAisyoName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(61);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(437);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(121);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(457);
                            break;
                        case 0311: //Kelpie2
                            affinitiesText = datAisyoName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(61);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(437);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(121);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(457);
                            break;
                        case 0262: //Kaiwan1
                            affinitiesText = datAisyoName.Get(168);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(190);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(446);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(447);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(199);
                            break;
                        case 0315: //Kaiwan2
                            affinitiesText = datAisyoName.Get(168);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(190);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(446);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(447);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(199);
                            break;
                        case 0263: //Ose
                            affinitiesText = datAisyoName.Get(71);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(102);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(65);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(70);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(69);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            break;
                        case 0289: //Ose Hallel
                            affinitiesText = "Rpl: Light • Null: Dark • Str: Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(38);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(70);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(69);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(54);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(110);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(18);
                            break;
                        case 0265: //Mizuchi1
                            affinitiesText = datAisyoName.Get(78);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(245);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(9);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(181);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(11);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(8);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(10);
                            break;
                        case 0297: //Mizuchi2
                            affinitiesText = datAisyoName.Get(78);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(245);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(9);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(181);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(11);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(8);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(10);
                            break;
                        case 0270: //Clotho (Alone)
                            affinitiesText = datAisyoName.Get(173);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(37);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(39);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(29);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(31);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(62);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(215);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(196);
                            break;
                        case 0326: //Clotho (with Atropos and Lachesis)
                            affinitiesText = datAisyoName.Get(173);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(37);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(39);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(29);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(31);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(62);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(215);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(196);
                            break;
                        case 0271: //Lachesis (Alone)
                            affinitiesText = datAisyoName.Get(174);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(52);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(54);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(66);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(69);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(70);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(206);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(304);
                            break;
                        case 0327: //Lachesis (with Clotho and Atropos)
                            affinitiesText = datAisyoName.Get(174);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(52);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(54);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(66);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(69);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(70);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(206);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(304);
                            break;
                        case 0272: //Atropos (Alone)
                            affinitiesText = datAisyoName.Get(175);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(2);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(5);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(8);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(11);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(14);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(17);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(20);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(23);
                            break;
                        case 0328: //Atropos (with Clotho and Lachesis)
                            affinitiesText = datAisyoName.Get(175);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(2);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(5);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(8);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(11);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(14);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(17);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(20);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(23);
                            break;
                        case 0274: //Girimehkala
                            affinitiesText = datAisyoName.Get(105);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(102);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(110);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(105);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(211);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(207);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(450);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(206);
                            break;
                        case 0299: //Sakahagi1
                            affinitiesText = datAisyoName.Get(205);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(5);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(11);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(17);
                            break;
                        case 0355: //Sakahagi2
                            affinitiesText = datAisyoName.Get(205);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(299);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(367);
                            break;
                        case 0276: //Aciel
                            affinitiesText = datAisyoName.Get(110);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(122);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(100);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(191);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(208);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            break;
                        case 0277: //Skadi
                            affinitiesText = datAisyoName.Get(17);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(155);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(468);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(188);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(66);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(333);
                            
                            break;
                        case 0278: //Albion
                            affinitiesText = datAisyoName.Get(155);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(106);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(109);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(100);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(101);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(329);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(330);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(331);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(332);
                            break;
                        case 0279: //Urthona
                            affinitiesText = datAisyoName.Get(181);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(15);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(18);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(440);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(251);
                            break;
                        case 0280: //Urizen
                            affinitiesText = datAisyoName.Get(182);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(3);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(6);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(435);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(251);
                            break;
                        case 0281: //Luvah
                            affinitiesText = datAisyoName.Get(183);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(21);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(24);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(443);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(251);
                            break;
                        case 0282: //Tharmus
                            affinitiesText = datAisyoName.Get(184);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(9);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(437);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(251);
                            break;
                        case 0283: //Futomimi1
                            affinitiesText = datAisyoName.Get(204);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(427);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(430);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(433);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(203);
                            break;
                        case 0354: //Futomimi2
                            affinitiesText = datAisyoName.Get(204);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(427);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(430);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(433);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(203);
                            break;
                        case 0284: //Gabriel
                            affinitiesText = datAisyoName.Get(139);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(426);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(195);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(38);
                            break;
                        case 0285: //Raphael
                            affinitiesText = datAisyoName.Get(140);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(106);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(462);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(189);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(69);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(70);
                            break;
                        case 0286: //Uriel
                            affinitiesText = datAisyoName.Get(141);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(431);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(179);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(476);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            break;
                        case 0335: //Surt
                            affinitiesText = "Drn: Fire • Null: Light/Dark/Ailments • Str: Phys";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(177);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(179);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(99);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(97);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(306);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            break;
                        case 0333: //Mada
                            affinitiesText = "Drn: Phys • Null: Light/Dark/Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(100);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(3);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(217);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(206);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(226);
                            break;
                        case 0334: //Mot
                            affinitiesText = "Rpl: Force • Drn: Ice • Str: Phys • Weak: Elec • Null: All other";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(67);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(99);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(24);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(37);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(307);
                            break;
                        case 0329: //Mithra
                            affinitiesText = "Null: Light/Dark/Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(35);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(33);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(31);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(29);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(206);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(189);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(26);
                            break;
                        case 0287: //Samael
                            affinitiesText = "Null: Light/Dark/Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(242);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(66);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(26);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(6);
                            break;
                        case 0291: //Ahriman1
                            affinitiesText = "Rpl: Light/Dark • Null: Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(3);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(9);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(15);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(21);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(6);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(18);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(24);
                            break;
                        case 0258: //Ahriman2
                            affinitiesText = "Rpl: Light/Dark • Null: Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(168);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(253);
                            break;
                        case 0292: //Noah1
                            string repelText = "";

                            if (nbCalc.nbGetAisyo(71, 4, 0) == 131072)
                            {
                                repelText = "Rpl: Phys";

                                if (nbCalc.nbGetAisyo(71, 4, 1) == 131072) repelText += "/Fire";
                                if (nbCalc.nbGetAisyo(71, 4, 2) == 131072) repelText += "/Ice";
                                if (nbCalc.nbGetAisyo(71, 4, 3) == 131072) repelText += "/Elec";
                                if (nbCalc.nbGetAisyo(71, 4, 4) == 131072) repelText += "/Force";

                                repelText += " • ";
                            }

                            affinitiesText = repelText + "Null: Light/Dark/Ailments";

                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(234);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(3);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(9);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(15);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(21);
                            break;
                        case 0259: //Noah2
                            string repelText2 = "Rpl: Phys";

                            if (nbCalc.nbGetAisyo(71, 4, 1) == 131072) repelText2 += "/Fire";
                            if (nbCalc.nbGetAisyo(71, 4, 2) == 131072) repelText2 += "/Ice";
                            if (nbCalc.nbGetAisyo(71, 4, 3) == 131072) repelText2 += "/Elec";
                            if (nbCalc.nbGetAisyo(71, 4, 4) == 131072) repelText2 += "/Force";

                            repelText2 += " • ";

                            affinitiesText = repelText2 + "Null: Light/Dark/Ailments";

                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(234);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(250);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(6);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(18);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(24);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            break;
                        case 0288: //Baal Avatar
                            affinitiesText = "Rpl: Light • Null: Dark/Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(201);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(31);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(189);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(195);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(26);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(230);
                            break;
                        case 0290: //Flauros Hallel
                            affinitiesText = "Rpl: Light • Null: Dark • Str: Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(38);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(104);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(67);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(66);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(65);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(70);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(24);
                            break;
                        case 0293: //Kagutsuchi1
                            affinitiesText = "Null: Light/Dark/Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(6);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(18);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(24);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(26);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(254);
                            break;
                        case 0264: //Kagutsuchi2
                            affinitiesText = "Null: Light/Dark/Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(6);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(18);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(24);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(26);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(221);
                            break;
                        case 0344: //Lucifer
                            affinitiesText = "Null: Light/Dark/Ailments • Str: All other";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(271);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);

                            // If on Hard Mode in Chronicles
                            if (!EventBit.evtBitCheck(3712) && dds3ConfigMain.cfgGetBit(9) == 2)
                            {
                                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(38); // Diarahan
                            }
                            else
                            {
                                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(37); // Diarama
                            }

                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(178);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(181);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(273);
                            break;
                        case 0313: //Succubus (Berith's ally)
                            affinitiesText = datAisyoName.Get(117);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(214);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(210);
                            break;
                        case 0117: //Succubus (Chest boss)
                            if (nbMainProcess.nbGetMainProcessData().encno != 990) return; // If fighting a regular Succubus
                            affinitiesText = datAisyoName.Get(117);
                            break;
                        case 0266: //Kin-Ki
                            affinitiesText = datAisyoName.Get(169);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(52);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(54);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(66);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(97);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(99);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            break;
                        case 0267: //Sui-Ki
                            affinitiesText = datAisyoName.Get(170);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(9);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(181);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(97);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(98);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(199);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(67);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            break;
                        case 0268: //Fuu-Ki
                            affinitiesText = datAisyoName.Get(171);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(21);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(185);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(97);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(110);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(216);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(67);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            break;
                        case 0269: //Ongyo-Ki
                            affinitiesText = "Null: Dark/Ailments • Weak: Light";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(33);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(199);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(105);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(106);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(25);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(206);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(66);
                            break;
                        case 0303: //Black Frost
                            affinitiesText = datAisyoName.Get(206);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(438);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(6);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(35);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(98);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(434);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            break;
                        case 0321: //Mara
                            affinitiesText = datAisyoName.Get(186);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(458);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(97);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(362);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(357);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = string.Empty;
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = string.Empty;
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = string.Empty;
                            break;
                        case 0320: //Bishamonten 1 
                            affinitiesText = datAisyoName.Get(21);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(109);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(104);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(178);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(179);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(424);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(365);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(366);
                            break;
                        case 0322: //Bishamonten 2
                            affinitiesText = datAisyoName.Get(21);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(67);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(178);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(6);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(177);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(99);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            break;
                        case 0323: //Jikokuten
                            affinitiesText = "Rpl: Ice • Null: Light/Dark/Ailments • Weak: Fire";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(9);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(181);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(70);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            break;
                        case 0324: //Koumokuten
                            affinitiesText = "Rpl: Force • Null: Light/Dark/Ailments • Weak: Elec";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(21);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(24);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(186);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(98);
                            break;
                        case 0325: //Zouchouten
                            affinitiesText = "Null: Light/Dark/Ailments • Weak: Force";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(15);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(18);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(183);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(192);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            break;
                        case 0349: //Matador
                            affinitiesText = datAisyoName.Get(199);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(276);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(443);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(275);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(205);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(366);
                            break;
                        case 0351: //Daisoujou
                            affinitiesText = datAisyoName.Get(201);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(279);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(30);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(34);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(278);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(67);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(424);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(366);
                            break;
                        case 0350: //Hell Biker
                            affinitiesText = datAisyoName.Get(200);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(281);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(283);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(282);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(284);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(97);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(366);
                            break;
                        case 0346: //White Rider
                            affinitiesText = datAisyoName.Get(196);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(287);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(178);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(496);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(366);
                            break;
                        case 359: //Virtue (White Rider)
                            affinitiesText = datAisyoName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(30);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(188);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(40);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(68);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(54);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(366);
                            break;
                        case 0347: //Red Rider
                            affinitiesText = datAisyoName.Get(197);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(280);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(186);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(183);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(497);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(366);
                            break;
                        case 0360: //Power (Red Rider)
                            affinitiesText = datAisyoName.Get(65);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(109);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(29);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(366);
                            break;
                        case 0348: //Black Rider
                            affinitiesText = datAisyoName.Get(198);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(261);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(181);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(26);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(226);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(366);
                            break;
                        case 0361: //Legion (Black Rider)
                            affinitiesText = datAisyoName.Get(128);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(99);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(190);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(35);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(196);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(70);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(366);
                            break;
                        case 0345: //Pale Rider
                            affinitiesText = datAisyoName.Get(195);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(79);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(63);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(102);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(212);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(451);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(226);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(366);
                            break;
                        case 0358: //Loa (Pale Rider)
                            affinitiesText = datAisyoName.Get(176);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(34);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(35);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(60);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(448);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(68);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(206);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(152);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(366);
                            break;
                        case 0352: //Mother Harlot
                            affinitiesText = datAisyoName.Get(202);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(285);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(286);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(18);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(183);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(205);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(304);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(366);
                            break;
                        case 0353: //Trumpeter
                            affinitiesText = datAisyoName.Get(203);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(6);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(18);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(24);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(158);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(159);
                            break;
                        case 0343: //Beelzebub (Fly)
                            affinitiesText = datAisyoName.Get(194);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(18);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(462);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(259);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(299);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(328);
                            break;
                        case 0357: //Beelzebub (Man)
                            affinitiesText = datAisyoName.Get(207);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(260);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(17);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(24);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            break;
                        case 0342: //Metatron
                            affinitiesText = datAisyoName.Get(193);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(431);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(6);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(31);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(257);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(458);
                            break;
                        case 0339: //Dante/Raidou1
                            affinitiesText = datAisyoName.Get(192);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(262);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(263);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(265);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(274);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(264);
                            break;
                        case 0340: //Dante/Raidou Chase
                            affinitiesText = datAisyoName.Get(192);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(262);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(263);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(266);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(274);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(264);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(266);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(267);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(360);
                            break;
                        case 0341: //Dante/Raidou2
                            affinitiesText = datAisyoName.Get(192);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(262);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(263);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(266);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(274);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(264);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(266);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(267);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(360); 
                            break;
                        case 0252: //DevilDante
                            affinitiesText = datAisyoName.Get(192);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(262);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(263);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(274);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(264);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(267);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(268);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(266);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(269);
                            break;
                        default:
                            if (new int[]{ 713, 1035, 1277, 1278 }.Contains(actionProcessData.data.encno))
                            {
                                // Remove HP and MP info
                                AnalyzeBossesUtility.DisplayHPMP(false);
                                isHPMPOn = false;
                                return;
                            }
                            else
                            {
                                if (datDevilFormat.tbl[nbPanelProcess.pNbPanelAnalyzeUnitWork.id].maxhp > 999)
                                {
                                    AnalyzeBossesUtility.DisplayHP(false);
                                }
                                if (datDevilFormat.tbl[nbPanelProcess.pNbPanelAnalyzeUnitWork.id].maxmp > 999)
                                {
                                    AnalyzeBossesUtility.DisplayMP(false);
                                }
                                return; // Not do anything special if the target isn't a boss
                            }
                    }
                    nbMainProcess.GetBattleUI(5).transform.Find("banalyze_attribute/banalyze_attribute_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = affinitiesText; // Apply the affinities' text


                    // Remove HP and MP info (because most bosses have more than triple digits HP/MP)
                    AnalyzeBossesUtility.DisplayHPMP(false);
                    isHPMPOn = false;
                }
            }
        }

        private class AnalyzeBossesUtility
        {
            // Turns on or off all HP/MP related objects
            public static void DisplayHPMP(bool state)
            {
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_hp/banalyze_hp_known/banalyze_slash").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_hp/banalyze_hp_known/num_hp01").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_hp/banalyze_hp_known/num_hp02").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_hp/banalyze_hp_known/num_hp03").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_hp/banalyze_hp_known/num_hpfull01").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_hp/banalyze_hp_known/num_hpfull02").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_hp/banalyze_hp_known/num_hpfull03").gameObject.SetActive(state);

                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_mp/banalyze_mp_known/banalyze_slash").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_mp/banalyze_mp_known/num_mp01").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_mp/banalyze_mp_known/num_mp02").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_mp/banalyze_mp_known/num_mp03").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_mp/banalyze_mp_known/num_mpfull01").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_mp/banalyze_mp_known/num_mpfull02").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_mp/banalyze_mp_known/num_mpfull03").gameObject.SetActive(state);
            }

            public static void DisplayHP(bool state)
            {
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_hp/banalyze_hp_known/banalyze_slash").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_hp/banalyze_hp_known/num_hp01").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_hp/banalyze_hp_known/num_hp02").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_hp/banalyze_hp_known/num_hp03").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_hp/banalyze_hp_known/num_hpfull01").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_hp/banalyze_hp_known/num_hpfull02").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_hp/banalyze_hp_known/num_hpfull03").gameObject.SetActive(state);
            }

            public static void DisplayMP(bool state)
            {
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_mp/banalyze_mp_known/banalyze_slash").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_mp/banalyze_mp_known/num_mp01").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_mp/banalyze_mp_known/num_mp02").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_mp/banalyze_mp_known/num_mp03").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_mp/banalyze_mp_known/num_mpfull01").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_mp/banalyze_mp_known/num_mpfull02").gameObject.SetActive(state);
                nbMainProcess.GetBattleUI(5).transform.Find("banalyze_mp/banalyze_mp_known/num_mpfull03").gameObject.SetActive(state);
            }
        }
    }
}