using MelonLoader;
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
                            affinitiesText = "Null: Dark• Str: Magic";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(1);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(190);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(232);
                            break;
                        case 0273: //Specter2
                            affinitiesText = "Null: Magic/Light/Dark/Nerve/Mind";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(191);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(25);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            break;
                        case 0275: //Specter3
                            affinitiesText = "Rpl: Magic • Null: Light/Dark/Nerve/Mind";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(226);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(152);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            break;
                        case 0294: //Specter4 (6 merged)
                            affinitiesText = "Null: Dark • Str: Magic";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(153);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(1);
                            break;
                        case 0295: //Specter5 (4 or 5 merged)
                            affinitiesText = "Null: Dark • Str: Magic";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(153);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(1);
                            break;
                        case 0296: //Specter6 (2 or 3 merged)
                            affinitiesText = "Null: Dark • Str: Magic";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(153);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(1);
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
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
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
                            affinitiesText = "Drn: Fire • Null: Dark • Str: Phys • Weak: Ice";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(101);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(5);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(177);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(226);
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
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            break;
                        case 0265: //Mizuchi1
                            affinitiesText = "Drn: Elec • Null: Ice/Light/Dark/Ailments • Weak: Fire";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(245);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(9);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(181);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(11);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(8);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(10);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(7);
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
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(7);
                            break;
                        case 0272: //Atropos (Alone)
                            affinitiesText = "Null: Light/Dark/Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(2);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(8);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(14);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(20);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(5);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(11);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(17);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(23);
                            break;
                        case 0328: //Atropos (with Clotho and Lachesis)
                            affinitiesText = "Null: Light/Dark/Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(2);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(8);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(14);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(20);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(5);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(11);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(17);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(23);
                            break;
                        case 0270: //Clotho (Alone)
                            affinitiesText = "Null: Light/Dark/Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(36);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(37);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(62);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(30);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = "";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = "";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = "";
                            break;
                        case 0326: //Clotho (with Atropos and Lachesis)
                            affinitiesText = "Null: Light/Dark/Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(36);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(37);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(39);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(40);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(62);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(30);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = "";
                            break;
                        case 0271: //Lachesis (Alone)
                            affinitiesText = "Null: Light/Dark/Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(54);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(66);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(70);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(69);
                            break;
                        case 0327: //Lachesis (with Clotho and Atropos)
                            affinitiesText = "Null: Light/Dark/Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(54);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(66);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(67);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(70);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(69);
                            break;
                        case 0274: //Girimehkala
                            affinitiesText = "Rpl: Phys • Null: Light/Dark/Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(216);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(211);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(102);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(202);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(65);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(54);
                            break;
                        case 0299: //Sakahagi1
                            affinitiesText = datAisyoName.Get(205);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(5);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(11);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(17);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(23);
                            break;
                        case 0355: //Sakahagi2
                            affinitiesText = datAisyoName.Get(205);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(5);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(11);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(17);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(23);
                            break;
                        case 0276: //Aciel
                            affinitiesText = "Rpl: Dark • Null: Light/Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(191);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(208);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(99);
                            break;
                        case 0277: //Skadi
                            affinitiesText = "Drn: Phys • Null: Light/Dark/Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(155);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(66);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(188);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(24);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(56);
                            break;
                        case 0278: //Albion
                            affinitiesText = "Null: Light/Dark/Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(236);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(106);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(109);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(100);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(101);
                            break;
                        case 0281: //Luvah
                            affinitiesText = "Rpl: Force • Null: Light/Dark/Ailments • Weak: Elec";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(21);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(24);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(50);
                            break;
                        case 0280: //Urizen
                            affinitiesText = "Rpl: Fire • Null: Light/Dark/Ailments • Weak: Ice";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(3);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(6);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(50);
                            break;
                        case 0282: //Tharmus
                            affinitiesText = "Rpl: Ice • Null: Light/Dark/Ailments • Weak: Fire";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(9);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(50);
                            break;
                        case 0279: //Urthona
                            affinitiesText = "Rpl: Elec • Null: Light/Dark/Ailments • Weak: Wind";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(15);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(18);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(50);
                            break;
                        case 0283: //Futomimi1
                            affinitiesText = datAisyoName.Get(204);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(203);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(198);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(96);
                            break;
                        case 0354: //Futomimi2
                            affinitiesText = datAisyoName.Get(204);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(203);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(198);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(96);
                            break;
                        case 0284: //Gabriel
                            affinitiesText = "Rpl: Light/Dark • Null: Ailments • Str: Magic";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(195);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(18);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(189);
                            break;
                        case 0285: //Raphael
                            affinitiesText = "Rpl: Light/Dark • Null: Ailments • Str: Magic";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(106);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(70);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(69);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(38);
                            break;
                        case 0286: //Uriel
                            affinitiesText = "Rpl: Light/Dark • Null: Ailments • Str: Magic";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(178);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(38);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(26);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
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
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(306);
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
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(243);
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
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(6);
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
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(241);
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
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(272);
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
                        case 0361: //Legion (Black Rider)
                            affinitiesText = "Rpl: Dark • Str: Ailments • Weak: Elec/Light";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(99);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(190);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(35);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(196);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(67);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(70);
                            break;
                        case 0358: //Loa (Pale Rider)
                            affinitiesText = "Null: Dark/Curse/Nerve • Str: Mind • Weak: Light";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(34);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(68);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(60);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(118);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(197);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(152);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(35);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(206);
                            break;
                        case 0267: //Sui-Ki
                            affinitiesText = "Drn: Ice • Null: Light/Dark/Ailments • Weak: Fire • Str: All other";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(8);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(11);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(180);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(181);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(98);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(97);
                            break;
                        case 0266: //Kin-Ki
                            affinitiesText = "Null: Light/Dark/Ailments • Str: Phys";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(96);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(97);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(98);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(99);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(101);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(102);
                            break;
                        case 0268: //Fuu-Ki
                            affinitiesText = "Drn: Force • Null: Light/Dark/Ailments • Str: Phys • Weak: Elec";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(67);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(185);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(22);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(21);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(98);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(97);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(99);
                            break;
                        case 0269: //Ongyo-Ki
                            affinitiesText = "Null: Light/Dark/Mind/Curse";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(33);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(199);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(105);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(106);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(66);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(65);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            break;
                        case 0303: //Black Frost
                            affinitiesText = "Rpl: Fire/Dark/Ailments • Drn: Ice • Null: Light • Str: Phys";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(35);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(9);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(98);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(37);
                            break;
                        case 0321: //Mara
                            affinitiesText = "Null: Light/Dark/Ailments";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(38);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(207);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(97);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(100);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(23);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(62);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(56);
                            break;
                        case 0320: //Bishamon 1 
                            affinitiesText = "Rpl: Fire • Null: Light/Dark/Ailments • Weak: Ice";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(104);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(178);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(38);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(189);
                            break;
                        case 0322: //Bishamon 2
                            affinitiesText = "Rpl: Fire • Null: Light/Dark/Ailments • Weak: Ice";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(67);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(178);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(6);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(177);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(99);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(206);
                            break;
                        case 0323: //Jikoku
                            affinitiesText = "Rpl: Ice • Null: Light/Dark/Ailments • Weak: Fire";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(9);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(181);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(70);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            break;
                        case 0324: //Koumoku
                            affinitiesText = "Rpl: Force • Null: Light/Dark/Ailments • Weak: Elec";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(21);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(24);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(186);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(98);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(108);
                            break;
                        case 0325: //Zouchou
                            affinitiesText = "Null: Light/Dark/Ailments • Weak: Force";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(219);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(15);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(18);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(183);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(192);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
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
                            break;
                        case 359: //Virtue (White Rider)
                            affinitiesText = datAisyoName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(30);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(188);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(40);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(69);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(54);
                            break;
                        case 0347: //Red Rider
                            affinitiesText = datAisyoName.Get(197);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(280);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(186);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(183);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(497);
                            break;
                        case 0360: //Power (Red Rider)
                            affinitiesText = "Rpl: Light • Str: Ailments • Weak: Dark";
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(109);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(29);
                            break;
                        case 0348: //Black Rider
                            affinitiesText = datAisyoName.Get(198);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(261);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(181);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(26);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(498);
                            break;
                        case 0345: //Pale Rider
                            affinitiesText = datAisyoName.Get(195);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(79);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(212);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(102);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(499);
                            break;
                        case 0352: //Mother Harlot
                            affinitiesText = datAisyoName.Get(202);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(285);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(286);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(220);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(56);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(18);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(183);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            break;
                        case 0353: //Trumpeter
                            affinitiesText = datAisyoName.Get(203);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(158);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(159);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(67);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(6);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(12);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(18);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(24);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            break;
                        case 0207: //Beelzebub1
                            affinitiesText = datAisyoName.Get(194);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(260);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(17);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(24);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            break;
                        case 0343: //Beelzebub2
                            affinitiesText = datAisyoName.Get(194);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(260);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(17);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(24);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(224);
                            break;
                        case 0357: //Beelzebub3
                            affinitiesText = datAisyoName.Get(194);
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
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(235);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(189);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(31);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(27);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(64);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(67);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(57);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(77);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(206);
                            break;
                        case 0339: //Dante/Raidou1
                            affinitiesText = datAisyoName.Get(192);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(262);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(263);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(265);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(274);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(264);
                            break;
                        case 0340: //Dante/Raidou2
                            affinitiesText = datAisyoName.Get(192);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(262);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(263);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(265);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(274);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(264);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(268);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(267);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(266);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(269);
                            break;
                        case 0341: //Dante/Raidou3
                            affinitiesText = datAisyoName.Get(192);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill01/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(262);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill02/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(263);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill03/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(265);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill04/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(274);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill05/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(264);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill06/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(268);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill07/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(267);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill08/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(266);
                            nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = datSkillName.Get(269);
                            break;
                        default:
                            if (actionProcessData.data.encno == 1270 || actionProcessData.data.encno == 1271)
                            {
                                // Remove HP and MP info
                                AnalyzeBossesUtility.DisplayHPMP(false);
                                isHPMPOn = false;
                                return;
                            }
                            else
                                return; // Not do anything special if the target isn't a boss
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
        }
    }
}