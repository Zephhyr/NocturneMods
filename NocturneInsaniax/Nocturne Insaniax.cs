using HarmonyLib;
using Il2Cpp;
using Il2Cppbasic_H;
using Il2Cppcamp_H;
using Il2Cppfacility_H;
using Il2Cppinterface_H;
using Il2Cppkernel_H;
using Il2Cppnewbattle_H;
using Il2Cppnewdata_H;
using Il2Cppscr_H;
using Il2CppTMPro;
using MelonLoader;
using MelonLoader.CoreClrUtils;
using Newtonsoft.Json;
using UnityEngine;
using System.Linq;
using Il2Cppeffect_H;
using Il2Cppmodel_H;

[assembly: MelonInfo(typeof(NocturneInsaniax.NocturneInsaniax), "Nocturne Insaniax", "0.9.2", "Zephhyr, Matthiew Purple, Bud, X Kirby, Margothic, Scribe, Snappy, Mason White")]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        public static string configPath = "InsaniaxConfig.cfg";
        public static MelonPreferences_Category InsaniaxSettings;
        public static MelonPreferences_Entry<bool> EnableSkillColourOutlines;
        public static MelonPreferences_Entry<bool> EnableSkillColourGradient;
        public static MelonPreferences_Entry<bool> EnableColourPassives;
        public static MelonPreferences_Entry<bool> EnableEnemyLevelDisplay;
        public static MelonPreferences_Entry<bool> EnableModeOverride;
        public static MelonPreferences_Entry<bool> ModeOverrideValue;
        public static MelonPreferences_Entry<bool> ToggleExpOnRandomEncounters;
        public static MelonPreferences_Entry<bool> ToggleItemUseInBattle;
        public static MelonPreferences_Entry<double> EncounterMaccaMultiplier;
        public static MelonPreferences_Entry<bool> GuaranteeEscape;
        public static MelonPreferences_Entry<bool> GuaranteeNKEs;
        public static MelonPreferences_Entry<bool> GuaranteeFiendNKEs;


        public override void OnInitializeMelon()
        {
            //foreach (var skill in tblSkill.fclSkillTbl[192].Event)
            //    MelonLogger.Msg(skill.TargetLevel + " - " + skill.Param + " - " + skill.Type);

            //foreach (var skill in tblHearts.fclHeartsTbl[1].Skill)
            //    MelonLogger.Msg(skill.TargetLevel + " - " + skill.ID);

            //MelonLogger.Msg("[");
            //foreach (var v in fld_Npc.fldNpc)
            //{
            //    var output = JsonConvert.SerializeObject(v);
            //    MelonLogger.Msg(output + ",");
            //}
            //MelonLogger.Msg("]");

            //var output = JsonConvert.SerializeObject(fclJunkShopTable.fclShopItemBoxTbl);
            //MelonLogger.Msg(output);

            //var output = JsonConvert.SerializeObject(nbEventProcess.nbEtbl);
            //MelonLogger.Msg(output);

            //var output = JsonConvert.SerializeObject(tblSkill.fclSkillTbl);
            //MelonLogger.Msg(output);

            //var output = JsonConvert.SerializeObject(nbActionProcess.sobedtbl);
            //MelonLogger.Msg(output);

            // Load New Sobeds
            //AssetBundle sobedData = AssetBundle.LoadFromFile(AppContext.BaseDirectory + BundlePath + "sobed_dds2");
            //AssetBundle.DontDestroyOnLoad(sobedData);
            //for (int i = 0; i < sobedData.AllAssetNames().Length; i++)
            //{
            //    UnityEngine.Object sobed = sobedData.LoadAsset(sobedData.AllAssetNames()[i]);

            //    if (sobed.TryCast<TextAsset>() == false)
            //    { continue; }
            //    TextAsset sobedTextData = sobed.Cast<TextAsset>();
            //    TextAsset.DontDestroyOnLoad(sobedTextData);
            //    nbActionProcess.SOBED s = new();
            //    string FileName = sobedData.AllAssetNames()[i].Replace("assets/assetbundle/dds3data/sobed_dds2/", "");
            //    s.bed_fname = sobedData.AllAssetNames()[i].Replace("assets/assetbundle/dds3data/sobed_dds2/", "");
            //    s.keyname = sobedData.AllAssetNames()[i].Replace("assets/assetbundle/dds3data/sobed_dds2/", "").Replace(".bed.bytes", "");
            //    s.tga_fname = new string[] { };
            //    s.pbdata = new nbActionProcess.SOBED_PB[] { new() };
            //    int j = 0;
            //    while (true)
            //    {
            //        UnityEngine.Object o = sobedData.LoadAsset(FileName + "." + j + ".tmx.tga");
            //        if (o == null)
            //        { break; }
            //        Texture2D t = o.Cast<Texture2D>();
            //        Texture2D.DontDestroyOnLoad(t);
            //        s.tga_fname = s.tga_fname.Append("tga/" + FileName + "." + j + ".tmx.tga").ToArray();
            //        j++;
            //    }
            //    newSobed.Add(s);
            //    //nbActionProcess.sobedtbl = nbActionProcess.sobedtbl.Append(s).ToArray();
            //}
            //for (int i = 0; i < newSobed.Count; i++)
            //{
            //    MelonLogger.Msg("- Index " + i + " of newSobed -");
            //    MelonLogger.Msg("bed_fname: " + newSobed[i].bed_fname);
            //    MelonLogger.Msg("keyname: " + newSobed[i].keyname);
            //    MelonLogger.Msg("se0_str: " + newSobed[i].se0_str);
            //    MelonLogger.Msg("se1_str: " + newSobed[i].se1_str);
            //    for (int j = 0; j < newSobed[i].tga_fname.Length; j++)
            //    {
            //        MelonLogger.Msg("- Texture " + j + " found -");
            //        MelonLogger.Msg("tga_fname: " + newSobed[i].tga_fname[j]);
            //    }
            //    for (int j = 0; j < newSobed[i].pbdata.Length; j++)
            //    {
            //        MelonLogger.Msg("- SOBED_PB Data " + j + " found -");
            //        MelonLogger.Msg("prefab_name: " + newSobed[i].pbdata[j].prefab_name);
            //        MelonLogger.Msg("type: " + newSobed[i].pbdata[j].type);
            //    }
            //}

            // Apply Changes
            ApplySkillChanges();
            ApplyItemChanges();
            ApplyShopChanges();
            ApplyMagatamaChanges();
            ApplyDemonChanges();
            ApplyEncounterChanges();

            // Apply Config
            InsaniaxSettings = MelonPreferences.CreateCategory("INSANIAX SETTINGS");
            EnableSkillColourOutlines = InsaniaxSettings.CreateEntry("Enable Skill Colour Outlines", true);
            EnableSkillColourGradient = InsaniaxSettings.CreateEntry("Enable Skill Colour Gradient", true);
            EnableColourPassives = InsaniaxSettings.CreateEntry("Enable Colour Passives", true);
            EnableEnemyLevelDisplay = InsaniaxSettings.CreateEntry("Enable Enemy Level Display", true);
            EnableModeOverride = InsaniaxSettings.CreateEntry("Enable Mode Override", false);
            ModeOverrideValue = InsaniaxSettings.CreateEntry("Mode Override Value (false=Chronicle, true=Maniax)", false);
            ToggleExpOnRandomEncounters = InsaniaxSettings.CreateEntry("Toggle Random Encounter EXP", true);
            ToggleItemUseInBattle = InsaniaxSettings.CreateEntry("Toggle Item Use In Battle", true);
            EncounterMaccaMultiplier = InsaniaxSettings.CreateEntry("Encounter Macca Multiplier", 1.0);
            GuaranteeEscape = InsaniaxSettings.CreateEntry("Guarantee Escape", false);
            GuaranteeNKEs = InsaniaxSettings.CreateEntry("Guarantee New Kagutsuchi Encounters", false);
            GuaranteeFiendNKEs = InsaniaxSettings.CreateEntry("Guarantee Fiend NKEs In Labyrinth", false);

            InsaniaxSettings.SetFilePath(configPath, autoload: true, printmsg: false);

            if (File.Exists(configPath))
            {
                LoggerInstance.Msg("Insaniax mod config loaded.");
                InsaniaxSettings.LoadFromFile(false);
            }
            else
            {
                LoggerInstance.Msg("No config found - config created in root directory.");
                InsaniaxSettings.SaveToFile(false);
            }
        }

        public override void OnLateUpdate()
        {
            if (cmpInitDH._DHeartsUIScr != null && cmpInitDH._DHeartsUIScr.gameObject.active)
            {
                for (int i = 1; i <= 24; i++)
                {
                    string heartIndex = i.ToString();
                    if (heartIndex.Length == 1) heartIndex = "0" + heartIndex;

                    //GameObject magPedOff = cmpInitDH._DHeartsUIScr.gameObject.transform.Find("magatama/magatamaset" + heartIndex + "/magpedestal/magpedestal_off").gameObject;
                    GameObject magPedOn = cmpInitDH._DHeartsUIScr.gameObject.transform.Find("magatama/magatamaset" + heartIndex + "/magpedestal/magpedestal_on").gameObject;
                    GameObject magPedBlue = cmpInitDH._DHeartsUIScr.gameObject.transform.Find("magatama/magatamaset" + heartIndex + "/magpedestal/magpedestal_blue").gameObject;

                    if (heartMastered[i] && magPedOn.active && !magPedBlue.active)
                    {
                        magPedOn.active = false;
                        magPedBlue.active = true;
                    }
                    else if (!heartMastered[i] && !magPedOn.active && magPedBlue.active)
                    {
                        magPedOn.active = true;
                        magPedBlue.active = false;
                    }
                }
            }

            if (cmpModel.cmpDevilObj != null)
            {
                var modelName = cmpModel.cmpDevilObj.name;
                switch (modelName)
                {
                    case "devil_0x121":
                        {
                            var oseHallelModel = cmpModel.cmpDevilObj;
                            oseHallelModel.transform.position = new Vector3(-0.08f, -1.48f, 0);
                            oseHallelModel.transform.eulerAngles = new Vector3(270f, 194f, 0);
                            break;
                        }
                    case "devil_0x122":
                        {
                            var flaurosHallelModel = cmpModel.cmpDevilObj;
                            flaurosHallelModel.transform.position = new Vector3(-0.08f, -1.28f, -0.04f);
                            flaurosHallelModel.transform.eulerAngles = new Vector3(0f, 196f, 0);
                            break;
                        }
                    case "devil_0x117":
                        {
                            var urthonaModel = cmpModel.cmpDevilObj;
                            urthonaModel.transform.position = new Vector3(0f, -1.0f, 0f);
                            urthonaModel.transform.eulerAngles = new Vector3(270f, 195f, 0);
                            urthonaModel.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                            break;
                        }
                    case "devil_0x118":
                        {
                            var urizenModel = cmpModel.cmpDevilObj;
                            urizenModel.transform.position = new Vector3(0f, -1.0f, 0f);
                            urizenModel.transform.eulerAngles = new Vector3(270f, 195f, 0);
                            urizenModel.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                            break;
                        }
                    case "devil_0x119":
                        {
                            var luvahModel = cmpModel.cmpDevilObj;
                            luvahModel.transform.position = new Vector3(0f, -1.0f, 0f);
                            luvahModel.transform.eulerAngles = new Vector3(270f, 195f, 0);
                            luvahModel.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                            break;
                        }
                    case "devil_0x11a":
                        {
                            var tharmusModel = cmpModel.cmpDevilObj;
                            tharmusModel.transform.position = new Vector3(0f, -1.0f, 0f);
                            tharmusModel.transform.eulerAngles = new Vector3(270f, 195f, 0);
                            tharmusModel.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                            break;
                        }
                    case "devil_0x141":
                        {
                            var maraModel = cmpModel.cmpDevilObj;
                            maraModel.transform.position = new Vector3(0f, -0.6f, 0f);
                            maraModel.transform.eulerAngles = new Vector3(270f, 195f, 0);
                            break;
                        }
                    case "devil_0xe0":
                        {
                            var tamLinModel = cmpModel.cmpDevilObj;
                            tamLinModel.transform.position = new Vector3(-0.04f, -1f, -1f);
                            tamLinModel.transform.eulerAngles = new Vector3(270f, 196f, 0);
                            break;
                        }
                    case "devil_0xe1":
                        {
                            var doppelgangerModel = cmpModel.cmpDevilObj;
                            doppelgangerModel.transform.position = new Vector3(-0.04f, -0.9f, -1.4f);
                            doppelgangerModel.transform.eulerAngles = new Vector3(0f, 180f, 0);
                            break;
                        }
                    case "devil_0xe2":
                        {
                            var nightmareModel = cmpModel.cmpDevilObj;
                            nightmareModel.transform.position = new Vector3(0.04f, -1.56f, 0.4f);
                            nightmareModel.transform.eulerAngles = new Vector3(270f, 198f, 0);
                            break;
                        }
                    case "devil_0xe3":
                        {
                            var gdonModel = cmpModel.cmpDevilObj;
                            gdonModel.transform.position = new Vector3(-0.36f, -0.64f, 0.6f);
                            gdonModel.transform.eulerAngles = new Vector3(0, 198f, 0);
                            break;
                        }
                    case "devil_0xe4":
                        {
                            var vritraModel = cmpModel.cmpDevilObj;
                            vritraModel.transform.position = new Vector3(0.04f, -1.88f, -0.4f);
                            vritraModel.transform.eulerAngles = new Vector3(270f, 178f, 0);
                            break;
                        }
                    case "devil_0xe5":
                        {
                            var demeehoModel = cmpModel.cmpDevilObj;
                            demeehoModel.transform.position = new Vector3(0f, -0.4f, -0.4f);
                            demeehoModel.transform.eulerAngles = new Vector3(0f, 184f, 0);
                            break;
                        }
                    default: break;
                }
            }
        }

        [HarmonyPatch(typeof(fldMain), nameof(fldMain.fldFirstInit))]
        private class fldFirstInitPatch
        {
            public static void Postfix()
            {
                MelonLogger.Msg("-fldMain.fldFirstInit-");
                //var output = JsonConvert.SerializeObject(fldGlobal.fldHitData._fldItemBoxTbl);
                //var output = JsonConvert.SerializeObject(fldGlobal.fldHitData._fldNpcUp);
                //var output = JsonConvert.SerializeObject(fld_Npc.gfldTakaraWork);
                //MelonLogger.Msg(output);

                ApplyItemBoxChanges();
            }
        }

        [HarmonyPatch(typeof(Smg), nameof(Smg.SmgTableInit))]
        private class SmgTableInitPatch
        {
            public static void Postfix()
            {
                // Tam Lin
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D224_MSEE0_03", "D224_MSEE0_03", 503316480, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D224_MSEE0_04", "D224_MSEE0_04", 503382016, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D224_MSEE0_08", "D224_MSEE0_08", 503447552, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D224_MSEE0_12", "D224_MSEE0_12", 503513088, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D224_MSEE0_14", "D224_MSEE0_14", 93519872, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D224_MSEE0_15", "D224_MSEE0_15", 93519873, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D224_MSEE0_23", "D224_MSEE0_23", 503578624, false);

                // Doppelganger
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_03", "D225_MSEE1_03", 504365056, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_04", "D225_MSEE1_04", 504430592, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_05", "D225_MSEE1_05", 504496128, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_06", "D225_MSEE1_06", 504561664, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_08", "D225_MSEE1_08", 504627200, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_10", "D225_MSEE1_10", 504692736, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_12", "D225_MSEE1_12", 504758272, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_14", "D225_MSEE1_14", 504823808, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_15", "D225_MSEE1_15", 504889344, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_16", "D225_MSEE1_16", 504954880, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_17", "D225_MSEE1_17", 505020416, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_18", "D225_MSEE1_18", 505085952, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_20", "D225_MSEE1_20", 505151488, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_21", "D225_MSEE1_21", 505217024, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_24", "D225_MSEE1_24", 505282560, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_03_E", "D225_MSEE1_03_E", (268435472 + 235929600), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_04_E", "D225_MSEE1_04_E", (268501008 + 235929600), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_05_E", "D225_MSEE1_05_E", (268566544 + 235929600), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_06_E", "D225_MSEE1_06_E", (268632080 + 235929600), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_08_E", "D225_MSEE1_08_E", (268697616 + 235929600), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_10_E", "D225_MSEE1_10_E", (268763152 + 235929600), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_12_E", "D225_MSEE1_12_E", (268828688 + 235929600), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_14_E", "D225_MSEE1_14_E", (268894224 + 235929600), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_15_E", "D225_MSEE1_15_E", (268959760 + 235929600), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_16_E", "D225_MSEE1_16_E", (269025296 + 235929600), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_17_E", "D225_MSEE1_17_E", (269090832 + 235929600), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_18_E", "D225_MSEE1_18_E", (269156368 + 235929600), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_20_E", "D225_MSEE1_20_E", (269221904 + 235929600), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_21_E", "D225_MSEE1_21_E", (269287440 + 235929600), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D225_MSEE1_24_E", "D225_MSEE1_24_E", (269352976 + 235929600), false);

                // Nightmare
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D226_MSEE2_03", "D226_MSEE2_03", 505413632, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D226_MSEE2_04", "D226_MSEE2_04", 505479168, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D226_MSEE2_05", "D226_MSEE2_05", 505544704, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D226_MSEE2_08", "D226_MSEE2_08", 505610240, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D226_MSEE2_14", "D226_MSEE2_14", 264830976, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D226_MSEE2_15", "D226_MSEE2_15", 264830977, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D226_MSEE2_23", "D226_MSEE2_23", 505675776, false);

                // Gdon
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D227_MSEE3_03", "D227_MSEE3_03", 506462208, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D227_MSEE3_04", "D227_MSEE3_04", 506527744, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D227_MSEE3_05", "D227_MSEE3_05", 506593280, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D227_MSEE3_23", "D227_MSEE3_23", 506658816, false);

                // Vritra
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D228_MSEE4_03", "D228_MSEE4_03", 507510784, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D228_MSEE4_04", "D228_MSEE4_04", 507576320, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D228_MSEE4_08", "D228_MSEE4_08", 507641856, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D228_MSEE4_23", "D228_MSEE4_23", 507707392, false);

                // Demeeho
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D229_MSEE5_03", "D229_MSEE5_03", 508559360, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D229_MSEE5_04", "D229_MSEE5_04", 508624896, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D229_MSEE5_06", "D229_MSEE5_06", 508690432, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D229_MSEE5_08", "D229_MSEE5_08", 508755968, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D229_MSEE5_14", "D229_MSEE5_14", 265027584, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D229_MSEE5_15", "D229_MSEE5_15", 265027585, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D229_MSEE5_23", "D229_MSEE5_23", 508821504, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D229_MSEE5_03_E", "D229_MSEE5_03_E", (331350032 + 177209344), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D229_MSEE5_04_E", "D229_MSEE5_04_E", (331415568 + 177209344), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D229_MSEE5_06_E", "D229_MSEE5_06_E", (331481104 + 177209344), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D229_MSEE5_08_E", "D229_MSEE5_08_E", (331546640 + 177209344), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D229_MSEE5_14_E", "D229_MSEE5_14_E", (87818256 + 177209344), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D229_MSEE5_15_E", "D229_MSEE5_15_E", (87818257 + 177209344), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D229_MSEE5_23_E", "D229_MSEE5_23_E", (331612176 + 177209344), false);

                // Devil Dante
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_03", "D252M_MSEFC_03", 532676608, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_04", "D252M_MSEFC_04", 532742144, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_05", "D252M_MSEFC_05", 532807680, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_06", "D252M_MSEFC_06", 532873216, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_07", "D252M_MSEFC_07", 532938752, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_08", "D252M_MSEFC_08", 533004288, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_09", "D252M_MSEFC_09", 533069824, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_10", "D252M_MSEFC_10", 533135360, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_12", "D252M_MSEFC_12", 533200896, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_16", "D252M_MSEFC_16", 533266432, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_17", "D252M_MSEFC_17", 533331968, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_18", "D252M_MSEFC_18", 533397504, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_23", "D252M_MSEFC_23", 533463040, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_03_E", "D252M_MSEFC_03_E", (469762066 + 62914558), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_04_E", "D252M_MSEFC_04_E", (469827602 + 62914558), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_06_E", "D252M_MSEFC_06_E", (469958674 + 62914558), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_09_E", "D252M_MSEFC_09_E", (470155282 + 62914558), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_10_E", "D252M_MSEFC_10_E", (470220818 + 62914558), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_16_E", "D252M_MSEFC_16_E", (470351890 + 62914558), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_17_E", "D252M_MSEFC_17_E", (470417426 + 62914558), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_18_E", "D252M_MSEFC_18_E", (470482962 + 62914558), false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D252M_MSEFC_23_E", "D252M_MSEFC_23_E", (470548498 + 62914558), false);

                // Gamete
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D253_MSEFD_03", "D253_MSEFD_03", 533725184, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D253_MSEFD_04", "D253_MSEFD_04", 533790720, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D253_MSEFD_05", "D253_MSEFD_05", 533856256, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D253_MSEFD_08", "D253_MSEFD_08", 533921792, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D253_MSEFD_14", "D253_MSEFD_14", 218431488, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D253_MSEFD_15", "D253_MSEFD_15", 218431489, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D253_MSEFD_23", "D253_MSEFD_23", 533987328, false);

                // YHVH
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D254_MSEFE_01", "D254_MSEFE_01", 534839296, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D254_MSEFE_03", "D254_MSEFE_03", 534970368, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D254_MSEFE_04", "D254_MSEFE_04", 535035904, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D254_MSEFE_05", "D254_MSEFE_05", 535101440, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D254_MSEFE_08", "D254_MSEFE_08", 535298048, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D254_MSEFE_09", "D254_MSEFE_09", 535363584, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D254_MSEFE_10", "D254_MSEFE_10", 535429120, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D254_MSEFE_11", "D254_MSEFE_11", 535494656, false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D254_MSEFE_12", "D254_MSEFE_12", 535560192, false);

                // Music
                Smg.Instance._TblAdd(Smg.eType.BGM, "B1600_B1601_BGM01", "B1600_B1601_BGM01_L_", 9134875, true);
                Smg.Instance._TblAdd(Smg.eType.BGM, "B1700_B1701_BGM01", "B1700_B1701_BGM01_L_", 9134876, true);
                Smg.Instance._TblAdd(Smg.eType.BGM, "B1800_B1801_BGM01", "B1800_B1801_BGM01_L_", 9134877, true);
                Smg.Instance._TblAdd(Smg.eType.BGM, "B1900_B1901_BGM01", "B1900_B1901_BGM01_L_", 9134878, true);
                Smg.Instance._TblAdd(Smg.eType.BGM, "B2000_B2001_BGM01", "B2000_B2001_BGM01_L_", 9134879, true);
                Smg.Instance._TblAdd(Smg.eType.BGM, "B2100_B2101_BGM01", "B2100_B2101_BGM01_L_", 9134880, true);
                Smg.Instance._TblAdd(Smg.eType.BGM, "B2200_B2201_BGM01", "B2200_B2201_BGM01_L_", 9134881, true);


                //foreach (var sound in Smg.Instance._tableSe_MSE)
                //    MelonLogger.Msg(sound.key + " - " + sound.value.MidiId);
            }
        }

        [HarmonyPatch(typeof(SndAssetBundleManager), nameof(SndAssetBundleManager.Initialize))]
        private class SndAssetBundleManagerInitializePatch
        {
            public static void Postfix()
            {
                var tamLinKeys = new Il2CppSystem.Collections.Generic.Dictionary<string, SndAssetBundleManager.SndData>();
                tamLinKeys.Add("D224_MSEE0_03", new SndAssetBundleManager.SndData { key = "dvl0xe0", path = 4, id = 0, name = "D224_MSEE0_03", diff = true });
                tamLinKeys.Add("D224_MSEE0_04", new SndAssetBundleManager.SndData { key = "dvl0xe0", path = 4, id = 0, name = "D224_MSEE0_04", diff = true });
                tamLinKeys.Add("D224_MSEE0_08", new SndAssetBundleManager.SndData { key = "dvl0xe0", path = 4, id = 0, name = "D224_MSEE0_08", diff = true });
                tamLinKeys.Add("D224_MSEE0_12", new SndAssetBundleManager.SndData { key = "dvl0xe0", path = 4, id = 0, name = "D224_MSEE0_12", diff = true });
                tamLinKeys.Add("D224_MSEE0_14", new SndAssetBundleManager.SndData { key = "dvl0xe0", path = 4, id = 0, name = "D224_MSEE0_14", diff = true });
                tamLinKeys.Add("D224_MSEE0_15", new SndAssetBundleManager.SndData { key = "dvl0xe0", path = 4, id = 0, name = "D224_MSEE0_15", diff = true });
                tamLinKeys.Add("D224_MSEE0_23", new SndAssetBundleManager.SndData { key = "dvl0xe0", path = 4, id = 0, name = "D224_MSEE0_23", diff = true });
                SndAssetBundleManager.SEBundleTable.Add("dvl0xe0", tamLinKeys);

                var doppelgangerKeys = new Il2CppSystem.Collections.Generic.Dictionary<string, SndAssetBundleManager.SndData>();
                doppelgangerKeys.Add("D225_MSEE1_03", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_03", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_04", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_04", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_05", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_04", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_06", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_04", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_08", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_08", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_10", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_08", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_12", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_12", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_14", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_14", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_15", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_15", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_16", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_16", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_17", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_17", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_18", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_18", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_20", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_20", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_21", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_21", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_24", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_24", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_03_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_03_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_04_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_04_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_05_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_04_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_06_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_04_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_08_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_08_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_10_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_08_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_12_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_12_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_14_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_14_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_15_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_15_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_16_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_16_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_17_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_17_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_18_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_18_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_20_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_20_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_21_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_21_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_24_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_24_E", diff = true });
                SndAssetBundleManager.SEBundleTable.Add("dvl0xe1", doppelgangerKeys);

                var nightmareKeys = new Il2CppSystem.Collections.Generic.Dictionary<string, SndAssetBundleManager.SndData>();
                nightmareKeys.Add("D226_MSEE2_03", new SndAssetBundleManager.SndData { key = "dvl0xe2", path = 4, id = 0, name = "D226_MSEE2_03", diff = true });
                nightmareKeys.Add("D226_MSEE2_04", new SndAssetBundleManager.SndData { key = "dvl0xe2", path = 4, id = 0, name = "D226_MSEE2_04", diff = true });
                nightmareKeys.Add("D226_MSEE2_05", new SndAssetBundleManager.SndData { key = "dvl0xe2", path = 4, id = 0, name = "D226_MSEE2_05", diff = true });
                nightmareKeys.Add("D226_MSEE2_08", new SndAssetBundleManager.SndData { key = "dvl0xe2", path = 4, id = 0, name = "D226_MSEE2_08", diff = true });
                nightmareKeys.Add("D226_MSEE2_14", new SndAssetBundleManager.SndData { key = "dvl0xe2", path = 4, id = 0, name = "D226_MSEE2_14", diff = true });
                nightmareKeys.Add("D226_MSEE2_15", new SndAssetBundleManager.SndData { key = "dvl0xe2", path = 4, id = 0, name = "D226_MSEE2_15", diff = true });
                nightmareKeys.Add("D226_MSEE2_23", new SndAssetBundleManager.SndData { key = "dvl0xe2", path = 4, id = 0, name = "D226_MSEE2_23", diff = true });
                SndAssetBundleManager.SEBundleTable.Add("dvl0xe2", nightmareKeys);

                var gdonKeys = new Il2CppSystem.Collections.Generic.Dictionary<string, SndAssetBundleManager.SndData>();
                gdonKeys.Add("D227_MSEE3_03", new SndAssetBundleManager.SndData { key = "dvl0xe3", path = 4, id = 0, name = "D227_MSEE3_03", diff = true });
                gdonKeys.Add("D227_MSEE3_04", new SndAssetBundleManager.SndData { key = "dvl0xe3", path = 4, id = 0, name = "D227_MSEE3_04", diff = true });
                gdonKeys.Add("D227_MSEE3_05", new SndAssetBundleManager.SndData { key = "dvl0xe3", path = 4, id = 0, name = "D227_MSEE3_05", diff = true });
                gdonKeys.Add("D227_MSEE3_23", new SndAssetBundleManager.SndData { key = "dvl0xe3", path = 4, id = 0, name = "D227_MSEE3_23", diff = true });
                SndAssetBundleManager.SEBundleTable.Add("dvl0xe3", gdonKeys);

                var vritraKeys = new Il2CppSystem.Collections.Generic.Dictionary<string, SndAssetBundleManager.SndData>();
                vritraKeys.Add("D228_MSEE4_03", new SndAssetBundleManager.SndData { key = "dvl0xe4", path = 4, id = 0, name = "D228_MSEE4_03", diff = true });
                vritraKeys.Add("D228_MSEE4_04", new SndAssetBundleManager.SndData { key = "dvl0xe4", path = 4, id = 0, name = "D228_MSEE4_04", diff = true });
                vritraKeys.Add("D228_MSEE4_08", new SndAssetBundleManager.SndData { key = "dvl0xe4", path = 4, id = 0, name = "D228_MSEE4_08", diff = true });
                vritraKeys.Add("D228_MSEE4_23", new SndAssetBundleManager.SndData { key = "dvl0xe4", path = 4, id = 0, name = "D228_MSEE4_23", diff = true });
                SndAssetBundleManager.SEBundleTable.Add("dvl0xe4", vritraKeys);

                var demeehoKeys = new Il2CppSystem.Collections.Generic.Dictionary<string, SndAssetBundleManager.SndData>();
                demeehoKeys.Add("D229_MSEE5_03", new SndAssetBundleManager.SndData { key = "dvl0xe5", path = 4, id = 0, name = "D229_MSEE5_03", diff = true });
                demeehoKeys.Add("D229_MSEE5_04", new SndAssetBundleManager.SndData { key = "dvl0xe5", path = 4, id = 0, name = "D229_MSEE5_04", diff = true });
                demeehoKeys.Add("D229_MSEE5_06", new SndAssetBundleManager.SndData { key = "dvl0xe5", path = 4, id = 0, name = "D229_MSEE5_06", diff = true });
                demeehoKeys.Add("D229_MSEE5_08", new SndAssetBundleManager.SndData { key = "dvl0xe5", path = 4, id = 0, name = "D229_MSEE5_08", diff = true });
                demeehoKeys.Add("D229_MSEE5_14", new SndAssetBundleManager.SndData { key = "dvl0xe5", path = 4, id = 0, name = "D229_MSEE5_14", diff = true });
                demeehoKeys.Add("D229_MSEE5_15", new SndAssetBundleManager.SndData { key = "dvl0xe5", path = 4, id = 0, name = "D229_MSEE5_15", diff = true });
                demeehoKeys.Add("D229_MSEE5_23", new SndAssetBundleManager.SndData { key = "dvl0xe5", path = 4, id = 0, name = "D229_MSEE5_23", diff = true });
                demeehoKeys.Add("D229_MSEE5_03_E", new SndAssetBundleManager.SndData { key = "dvl0xe5", path = 4, id = 0, name = "D229_MSEE5_03_E", diff = true });
                demeehoKeys.Add("D229_MSEE5_04_E", new SndAssetBundleManager.SndData { key = "dvl0xe5", path = 4, id = 0, name = "D229_MSEE5_04_E", diff = true });
                demeehoKeys.Add("D229_MSEE5_06_E", new SndAssetBundleManager.SndData { key = "dvl0xe5", path = 4, id = 0, name = "D229_MSEE5_06_E", diff = true });
                demeehoKeys.Add("D229_MSEE5_08_E", new SndAssetBundleManager.SndData { key = "dvl0xe5", path = 4, id = 0, name = "D229_MSEE5_08_E", diff = true });
                demeehoKeys.Add("D229_MSEE5_14_E", new SndAssetBundleManager.SndData { key = "dvl0xe5", path = 4, id = 0, name = "D229_MSEE5_14_E", diff = true });
                demeehoKeys.Add("D229_MSEE5_15_E", new SndAssetBundleManager.SndData { key = "dvl0xe5", path = 4, id = 0, name = "D229_MSEE5_15_E", diff = true });
                demeehoKeys.Add("D229_MSEE5_23_E", new SndAssetBundleManager.SndData { key = "dvl0xe5", path = 4, id = 0, name = "D229_MSEE5_23_E", diff = true });
                SndAssetBundleManager.SEBundleTable.Add("dvl0xe5", demeehoKeys);

                var sethKeys = new Il2CppSystem.Collections.Generic.Dictionary<string, SndAssetBundleManager.SndData>();
                sethKeys.Add("D230_MSEE6_03", new SndAssetBundleManager.SndData { key = "dvl0xe6", path = 4, id = 0, name = "D230_MSEE6_03", diff = true });
                sethKeys.Add("D230_MSEE6_04", new SndAssetBundleManager.SndData { key = "dvl0xe6", path = 4, id = 0, name = "D230_MSEE6_04", diff = true });
                sethKeys.Add("D230_MSEE6_05", new SndAssetBundleManager.SndData { key = "dvl0xe6", path = 4, id = 0, name = "D230_MSEE6_05", diff = true });
                sethKeys.Add("D230_MSEE6_08", new SndAssetBundleManager.SndData { key = "dvl0xe6", path = 4, id = 0, name = "D230_MSEE6_08", diff = true });
                sethKeys.Add("D230_MSEE6_23", new SndAssetBundleManager.SndData { key = "dvl0xe6", path = 4, id = 0, name = "D230_MSEE6_23", diff = true });
                SndAssetBundleManager.SEBundleTable.Add("dvl0xe6", sethKeys);

                var devilDanteKeys = new Il2CppSystem.Collections.Generic.Dictionary<string, SndAssetBundleManager.SndData>();
                devilDanteKeys.Add("D252M_MSEFC_03", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_03", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_04", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_04", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_05", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_05", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_06", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_06", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_07", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_07", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_08", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_08", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_09", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_09", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_10", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_10", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_12", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_12", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_16", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_16", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_17", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_17", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_18", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_18", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_23", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_23", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_03_E", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_03_E", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_04_E", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_04_E", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_05_E", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_05_E", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_06_E", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_06_E", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_07_E", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_07_E", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_08_E", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_08_E", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_09_E", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_09_E", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_10_E", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_10_E", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_12_E", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_12_E", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_16_E", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_16_E", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_17_E", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_17_E", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_18_E", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_18_E", diff = true });
                devilDanteKeys.Add("D252M_MSEFC_23_E", new SndAssetBundleManager.SndData { key = "dvl0xfcd", path = 4, id = 0, name = "D252M_MSEFC_23_E", diff = true });
                SndAssetBundleManager.SEBundleTable.Add("dvl0xfcd", devilDanteKeys);

                var notSlimeKeys = new Il2CppSystem.Collections.Generic.Dictionary<string, SndAssetBundleManager.SndData>();
                notSlimeKeys.Add("D253_MSEFD_03", new SndAssetBundleManager.SndData { key = "dvl0xfd", path = 4, id = 0, name = "D253_MSEFD_03", diff = true });
                notSlimeKeys.Add("D253_MSEFD_04", new SndAssetBundleManager.SndData { key = "dvl0xfd", path = 4, id = 0, name = "D253_MSEFD_04", diff = true });
                notSlimeKeys.Add("D253_MSEFD_05", new SndAssetBundleManager.SndData { key = "dvl0xfd", path = 4, id = 0, name = "D253_MSEFD_05", diff = true });
                notSlimeKeys.Add("D253_MSEFD_08", new SndAssetBundleManager.SndData { key = "dvl0xfd", path = 4, id = 0, name = "D253_MSEFD_08", diff = true });
                notSlimeKeys.Add("D253_MSEFD_14", new SndAssetBundleManager.SndData { key = "dvl0xfd", path = 4, id = 0, name = "D253_MSEFD_14", diff = true });
                notSlimeKeys.Add("D253_MSEFD_15", new SndAssetBundleManager.SndData { key = "dvl0xfd", path = 4, id = 0, name = "D253_MSEFD_15", diff = true });
                notSlimeKeys.Add("D253_MSEFD_23", new SndAssetBundleManager.SndData { key = "dvl0xfd", path = 4, id = 0, name = "D253_MSEFD_23", diff = true });
                SndAssetBundleManager.SEBundleTable.Add("dvl0xfd", notSlimeKeys);

                var yhvhKeys = new Il2CppSystem.Collections.Generic.Dictionary<string, SndAssetBundleManager.SndData>();
                yhvhKeys.Add("D254_MSEFE_01", new SndAssetBundleManager.SndData { key = "dvl0xfe", path = 4, id = 0, name = "D254_MSEFE_01", diff = true });
                yhvhKeys.Add("D254_MSEFE_03", new SndAssetBundleManager.SndData { key = "dvl0xfe", path = 4, id = 0, name = "D254_MSEFE_03", diff = true });
                yhvhKeys.Add("D254_MSEFE_04", new SndAssetBundleManager.SndData { key = "dvl0xfe", path = 4, id = 0, name = "D254_MSEFE_04", diff = true });
                yhvhKeys.Add("D254_MSEFE_05", new SndAssetBundleManager.SndData { key = "dvl0xfe", path = 4, id = 0, name = "D254_MSEFE_05", diff = true });
                yhvhKeys.Add("D254_MSEFE_08", new SndAssetBundleManager.SndData { key = "dvl0xfe", path = 4, id = 0, name = "D254_MSEFE_08", diff = true });
                yhvhKeys.Add("D254_MSEFE_09", new SndAssetBundleManager.SndData { key = "dvl0xfe", path = 4, id = 0, name = "D254_MSEFE_09", diff = true });
                yhvhKeys.Add("D254_MSEFE_10", new SndAssetBundleManager.SndData { key = "dvl0xfe", path = 4, id = 0, name = "D254_MSEFE_10", diff = true });
                yhvhKeys.Add("D254_MSEFE_11", new SndAssetBundleManager.SndData { key = "dvl0xfe", path = 4, id = 0, name = "D254_MSEFE_11", diff = true });
                yhvhKeys.Add("D254_MSEFE_12", new SndAssetBundleManager.SndData { key = "dvl0xfe", path = 4, id = 0, name = "D254_MSEFE_12", diff = true });
                SndAssetBundleManager.SEBundleTable.Add("dvl0xfe", yhvhKeys);

                var bgm16Keys = new Il2CppSystem.Collections.Generic.Dictionary<string, SndAssetBundleManager.SndData>();
                bgm16Keys.Add("B1600_B1601_BGM01", new SndAssetBundleManager.SndData { key = "b_bgm16", path = 1, id = 0, name = "B1600_B1601_BGM01", diff = true });
                SndAssetBundleManager.BGMBundleTable.Add("b_bgm16", bgm16Keys);

                var bgm17Keys = new Il2CppSystem.Collections.Generic.Dictionary<string, SndAssetBundleManager.SndData>();
                bgm17Keys.Add("B1700_B1701_BGM01", new SndAssetBundleManager.SndData { key = "b_bgm17", path = 1, id = 0, name = "B1700_B1701_BGM01", diff = true });
                SndAssetBundleManager.BGMBundleTable.Add("b_bgm17", bgm17Keys);

                var bgm18Keys = new Il2CppSystem.Collections.Generic.Dictionary<string, SndAssetBundleManager.SndData>();
                bgm18Keys.Add("B1800_B1801_BGM01", new SndAssetBundleManager.SndData { key = "b_bgm18", path = 1, id = 0, name = "B1800_B1801_BGM01", diff = true });
                SndAssetBundleManager.BGMBundleTable.Add("b_bgm18", bgm18Keys);

                var bgm19Keys = new Il2CppSystem.Collections.Generic.Dictionary<string, SndAssetBundleManager.SndData>();
                bgm19Keys.Add("B1900_B1901_BGM01", new SndAssetBundleManager.SndData { key = "b_bgm19", path = 1, id = 0, name = "B1900_B1901_BGM01", diff = true });
                SndAssetBundleManager.BGMBundleTable.Add("b_bgm19", bgm19Keys);

                var bgm20Keys = new Il2CppSystem.Collections.Generic.Dictionary<string, SndAssetBundleManager.SndData>();
                bgm20Keys.Add("B2000_B2001_BGM01", new SndAssetBundleManager.SndData { key = "b_bgm20", path = 1, id = 0, name = "B2000_B2001_BGM01", diff = true });
                SndAssetBundleManager.BGMBundleTable.Add("b_bgm20", bgm20Keys);

                var bgm21Keys = new Il2CppSystem.Collections.Generic.Dictionary<string, SndAssetBundleManager.SndData>();
                bgm21Keys.Add("B2100_B2101_BGM01", new SndAssetBundleManager.SndData { key = "b_bgm21", path = 1, id = 0, name = "B12100_B2101_BGM01", diff = true });
                SndAssetBundleManager.BGMBundleTable.Add("b_bgm21", bgm21Keys);

                var bgm22Keys = new Il2CppSystem.Collections.Generic.Dictionary<string, SndAssetBundleManager.SndData>();
                bgm22Keys.Add("B2200_B2201_BGM01", new SndAssetBundleManager.SndData { key = "b_bgm22", path = 1, id = 0, name = "B12200_B2201_BGM01", diff = true });
                SndAssetBundleManager.BGMBundleTable.Add("b_bgm22", bgm22Keys);

                //foreach (var dic in SndAssetBundleManager.SEBundleTable)
                //{
                //    MelonLogger.Msg(dic.key + ":");
                //    foreach (var sound in dic.value)
                //    {
                //        MelonLogger.Msg(sound.key + " - " + sound.value.name);
                //    }
                //}
            }
        }

        [HarmonyPatch(typeof(nbEncount), nameof(nbEncount.nbGetBgmCategoryInBattle))]
        private class nbGetBgmCategoryInBattlePatch
        {
            public static void Postfix(ref int __result)
            {
                //MelonLogger.Msg("--nbEncount.nbGetBgmCategoryInBattle--");
                if (__result == 14)
                {
                    if (!EventBit.evtBitCheck(3712))
                        __result = 17;
                    //var encno = nbMainProcess.nbGetMainProcessData().encno;
                    //if (encno == 1033)
                    //    __result = 17;
                }
                else if (__result == 21)
                {
                    if (!EventBit.evtBitCheck(3712))
                        __result = 20;
                }
                switch (__result)
                {
                    case 16:  // CLUB MILTON
                        nbSound.bgmno = "B1600_B1601_BGM01";
                        nbSound.bgmsub = 0;
                        nbSound.bgmloadphase = 1;
                        nbSound.bgmdone = 0;
                        nbSound.bgmkey = 16;
                        break;
                    case 17: // Battle - Raidou
                        nbSound.bgmno = "B1700_B1701_BGM01";
                        nbSound.bgmsub = 0;
                        nbSound.bgmloadphase = 1;
                        nbSound.bgmdone = 0;
                        nbSound.bgmkey = 17;
                        break;
                    case 18: // Hunting - Betrayal
                        nbSound.bgmno = "B1800_B1801_BGM01";
                        nbSound.bgmsub = 0;
                        nbSound.bgmloadphase = 1;
                        nbSound.bgmdone = 0;
                        nbSound.bgmkey = 18;
                        break;
                    case 19: // Enemy of God
                        nbSound.bgmno = "B1900_B1901_BGM01";
                        nbSound.bgmsub = 0;
                        nbSound.bgmloadphase = 1;
                        nbSound.bgmdone = 0;
                        nbSound.bgmkey = 19;
                        break;
                    case 20: // An Old Foe
                        nbSound.bgmno = "B2000_B2001_BGM01";
                        nbSound.bgmsub = 0;
                        nbSound.bgmloadphase = 1;
                        nbSound.bgmdone = 0;
                        nbSound.bgmkey = 20;
                        break;
                    case 21: // Devils Never Cry
                        nbSound.bgmno = "B2100_B2101_BGM01";
                        nbSound.bgmsub = 0;
                        nbSound.bgmloadphase = 1;
                        nbSound.bgmdone = 0;
                        nbSound.bgmkey = 21;
                        break;
                    case 22: // Rare Devil
                        nbSound.bgmno = "B2200_B2201_BGM01";
                        nbSound.bgmsub = 0;
                        nbSound.bgmloadphase = 1;
                        nbSound.bgmdone = 0;
                        nbSound.bgmkey = 22;
                        break;
                    default: break;
                }
            }
        }

        [HarmonyPatch(typeof(EventBit), nameof(EventBit.evtBitCheck))]
        private class evtBitCheckPatch
        {
            public static void Postfix(ref int no, ref bool __result)
            {
                try
                {
                    //MelonLogger.Msg("--EventBit.evtBitCheck--");
                    if (EnableModeOverride.Value && no == 3712)
                        __result = ModeOverrideValue.Value;
                    // Checks the flag responsible for unlocking Pierce
                    else if (no == 2241)
                    {
                        //if (!__result) __result = true; // Artificially makes it obtainable
                        //else tblHearts.fclHeartsTbl[1].Skill[6].TargetLevel = 15; // If unlocked normally, you can get it early
                        if (__result) tblHearts.fclHeartsTbl[1].Skill[6].TargetLevel = 15; // If unlocked normally, you can get it
                        else tblHearts.fclHeartsTbl[1].Skill[6].TargetLevel = 200; // Otherwise, you can't
                    }
                }
                catch { }
            }
        }

        //[HarmonyPatch(typeof(SndAssetBundleManager), nameof(SndAssetBundleManager.LoadKeysMSE))]
        //private class LoadKeysMSEPatch
        //{
        //    public static void Postfix()
        //    {
        //        MelonLogger.Msg("--SndAssetBundleManager.LoadKeysMSE--");
        //        MelonLogger.Msg("Jack Frost keys");
        //        for (int i = 0; i <= 25; i++)
        //            MelonLogger.Msg(i + ": " + nbSound.GetMotionMIDI(60, i));
        //        MelonLogger.Msg("Demee-Ho keys");
        //        for (int i = 0; i <= 25; i++)
        //            MelonLogger.Msg(i + ": " + nbSound.GetMotionMIDI(229, i));
        //    }
        //}

        //[HarmonyPatch(typeof(nbSound), nameof(nbSound.nbGetMotionSeNo))]
        //private class nbGetMotionSeNoPatch
        //{
        //    public static void Postfix(int id, int mot, int __result)
        //    {
        //        MelonLogger.Msg("--nbSound.nbGetMotionSeNo--");
        //        MelonLogger.Msg("id: " + id);
        //        MelonLogger.Msg("mot: " + mot);
        //        MelonLogger.Msg("result: " + __result);
        //    }
        //}

        //[HarmonyPatch(typeof(nbSound), nameof(nbSound.GetMotionMIDI))]
        //private class GetMotionMIDIPatch
        //{
        //    public static void Postfix(int id, int mot, uint __result)
        //    {
        //        MelonLogger.Msg("--nbSound.GetMotionMIDI--");
        //        MelonLogger.Msg("id: " + id);
        //        MelonLogger.Msg("mot: " + mot);
        //        MelonLogger.Msg("result: " + __result);
        //    }
        //}

        //[HarmonyPatch(typeof(mdlEffect), nameof(mdlEffect.mdlCreateEffect_P2A_D3P))]
        //private class mdlCreateEffectPatch
        //{
        //    public static void Postfix(ref dds3ModelHandle_t aHandle, ref int aPlayGroup, ref int aType, ref int bPos)
        //    {
        //        MelonLogger.Msg("--mdlEffect.mdlCreateEffect_P2A_D3P--");
        //        MelonLogger.Msg("aPlayGroup: " + aPlayGroup);
        //        MelonLogger.Msg("aType: " + aType);
        //        MelonLogger.Msg("bPos: " + bPos);
        //        MelonLogger.Msg("aHandle.resrc.effectResrcList.items.Count: " + aHandle.resrc.effectResrcList.items.Count);
        //        //MelonLogger.Msg("resrc: " + Newtonsoft.Json.JsonConvert.SerializeObject(aHandle.resrc));
        //    }
        //}

        //[HarmonyPatch(typeof(mdlEffect), nameof(mdlEffect.mdlGenEffect))]
        //private class mdlGenEffectPatch
        //{
        //    public static void Postfix(ref dds3ModelHandle_t aHandle, ref int aGroup, ref int aPlayGroup)
        //    {
        //        MelonLogger.Msg("--mdlEffect.mdlGenEffect--");
        //        MelonLogger.Msg("aGroup: " + aGroup);
        //        MelonLogger.Msg("aPlayGroup: " + aPlayGroup);
        //        MelonLogger.Msg("aHandle.resrc.effectResrcList.items.Count: " + aHandle.resrc.effectResrcList.items.Count);
        //        //MelonLogger.Msg("resrc: " + Newtonsoft.Json.JsonConvert.SerializeObject(aHandle.resrc));
        //    }
        //}

        //[HarmonyPatch(typeof(mdlManager), nameof(mdlManager.mdlEffectCreateUnity))]
        //private class mdlEffectCreateUnityPatch
        //{
        //    public static void Postfix(ref int aMajor, ref int aMinor, ref mdlEffectResrcList_t efc_res_list)
        //    {
        //        MelonLogger.Msg("--mdlManager.mdlEffectCreateUnity--");
        //        MelonLogger.Msg("aMajor: " + aMajor);
        //        MelonLogger.Msg("aMinor: " + aMinor);
        //        MelonLogger.Msg("efc_res_list.items.Count: " + efc_res_list.items.Count);
        //        MelonLogger.Msg("aKey: " + mdlFileDefTable.GetAkey(aMinor));
        //        //MelonLogger.Msg("resrc: " + cmpModel.cmpModelHandle.resrc);
        //        //MelonLogger.Msg("resrc: " + Newtonsoft.Json.JsonConvert.SerializeObject(cmpModel.cmpModelHandle.resrc));
        //    }
        //}

        //[HarmonyPatch(typeof(mdlManager), nameof(mdlManager.mdlLoad))]
        //private class mdlLoadPatch
        //{
        //    public static void Postfix(ref int aMajor, ref int aMinor, ref int bPos, ref dds3ModelHandle_t __result)
        //    {
        //        MelonLogger.Msg("--mdlManager.mdlLoad--");
        //        MelonLogger.Msg("aMajor: " + aMajor);
        //        MelonLogger.Msg("aMinor: " + aMinor);
        //        MelonLogger.Msg("bPos: " + bPos);
        //        //MelonLogger.Msg("aKey: " + mdlFileDefTable.GetAkey(aMinor));
        //        //MelonLogger.Msg("resrc: " + cmpModel.cmpModelHandle.resrc);
        //    }
        //}

        //[HarmonyPatch(typeof(cmpModel), nameof(cmpModel.cmpModelLoadForUnity))]
        //private class cmpModelLoadForUnityPatch
        //{
        //    public static void Postfix(ref int MajorNo, ref int MinorNo, ref int BlockMode, ref bool __result)
        //    {
        //        MelonLogger.Msg("--cmpModel.cmpModelLoadForUnity--");
        //        MelonLogger.Msg("MajorNo: " + MajorNo);
        //        MelonLogger.Msg("MinorNo: " + MinorNo);
        //        MelonLogger.Msg("BlockMode: " + BlockMode);
        //        MelonLogger.Msg("result: " + __result);
        //    }
        //}

        //[HarmonyPatch(typeof(cmpModel), nameof(cmpModel.cmpModelLoadEffectForUnity))]
        //private class cmpModelLoadEffectForUnityPatch
        //{
        //    public static void Postfix(ref int MajorNo, ref int MinorNo, ref int BlockMode, ref bool __result)
        //    {
        //        MelonLogger.Msg("--cmpModel.cmpModelLoadEffectForUnity--");
        //        MelonLogger.Msg("MajorNo: " + MajorNo);
        //        MelonLogger.Msg("MinorNo: " + MinorNo);
        //        MelonLogger.Msg("BlockMode: " + BlockMode);
        //        MelonLogger.Msg("aFilename: " + "dds3data/dvl_pb/" + mdlFileDefTable.GetPBname(MinorNo) + ".bytes");
        //        MelonLogger.Msg("result: " + __result);
        //    }
        //}

        //[HarmonyPatch(typeof(billManager), nameof(billManager.dds3BillboardFileLoad))]
        //private class dds3BillboardFileLoadPatch
        //{
        //    public static void Postfix(ref int type, ref string pFileName, ref string akey)
        //    {
        //        MelonLogger.Msg("--billManager.dds3BillboardFileLoad--");
        //        MelonLogger.Msg("type: " + type);
        //        MelonLogger.Msg("pFileName: " + pFileName);
        //        MelonLogger.Msg("akey: " + akey);
        //    }
        //}

        //[HarmonyPatch(typeof(billManager), nameof(billManager.dds3BillboardGeneral))]
        //private class dds3BillboardGeneralPatch
        //{
        //    public static void Postfix(ref int number)
        //    {
        //        MelonLogger.Msg("--billManager.dds3BillboardGeneral--");
        //        MelonLogger.Msg("number: " + number);
        //    }
        //}
        //[HarmonyPatch(typeof(parManager), nameof(parManager.dds3Particle_BasicCreate))]
        //private class dds3Particle_BasicCreatePatch
        //{
        //    public static void Postfix(ref dds3Particle_Basic_t pParBasic, ref bool pCopy)
        //    {
        //        MelonLogger.Msg("--parManager.dds3Particle_BasicCreate--");
        //        MelonLogger.Msg("pCopy: " + pCopy);
        //    }
        //}
        //[HarmonyPatch(typeof(parManager), nameof(parManager.dds3Particle_SpiralCreate))]
        //private class dds3Particle_SpiralCreatePatch
        //{
        //    public static void Postfix(ref int bPos, ref bool pCopy, ref int billno)
        //    {
        //        MelonLogger.Msg("--parManager.dds3Particle_SpiralCreate--");
        //        MelonLogger.Msg("bPos: " + bPos);
        //        MelonLogger.Msg("pCopy: " + pCopy);
        //        MelonLogger.Msg("billno: " + billno);
        //    }
        //}
        //[HarmonyPatch(typeof(parManager), nameof(parManager.dds3Particle_SmokeCreate))]
        //private class dds3Particle_SmokeCreatePatch
        //{
        //    public static void Postfix(ref int bPos, ref bool pCopy, ref int billno)
        //    {
        //        MelonLogger.Msg("--parManager.dds3Particle_SmokeCreate--");
        //        MelonLogger.Msg("bPos: " + bPos);
        //        MelonLogger.Msg("pCopy: " + pCopy);
        //        MelonLogger.Msg("billno: " + billno);
        //    }
        //}
        //[HarmonyPatch(typeof(parManager), nameof(parManager.dds3Particle_SparkCreate))]
        //private class dds3Particle_SparkCreatePatch
        //{
        //    public static void Postfix(ref int bPos, ref bool pCopy, ref int billno)
        //    {
        //        MelonLogger.Msg("--parManager.dds3Particle_SparkCreate--");
        //        MelonLogger.Msg("bPos: " + bPos);
        //        MelonLogger.Msg("pCopy: " + pCopy);
        //        MelonLogger.Msg("billno: " + billno);
        //    }
        //}
        //[HarmonyPatch(typeof(parManager), nameof(parManager.dds3Particle_RadiateCreate))]
        //private class dds3Particle_RadiateCreatePatch
        //{
        //    public static void Postfix(ref int bPos, ref bool pCopy, ref int billno)
        //    {
        //        MelonLogger.Msg("--parManager.dds3Particle_RadiateCreate--");
        //        MelonLogger.Msg("bPos: " + bPos);
        //        MelonLogger.Msg("pCopy: " + pCopy);
        //        MelonLogger.Msg("billno: " + billno);
        //    }
        //}
        //[HarmonyPatch(typeof(parManager), nameof(parManager.dds3Particle_SphereSpiralCreate))]
        //private class dds3Particle_SphereSpiralCreatePatch
        //{
        //    public static void Postfix(ref int bPos, ref bool pCopy, ref int billno)
        //    {
        //        MelonLogger.Msg("--parManager.dds3Particle_SphereSpiralCreate--");
        //        MelonLogger.Msg("bPos: " + bPos);
        //        MelonLogger.Msg("pCopy: " + pCopy);
        //        MelonLogger.Msg("billno: " + billno);
        //    }
        //}
        //[HarmonyPatch(typeof(parManager), nameof(parManager.dds3Particle_SphereSmokeCreate))]
        //private class dds3Particle_SphereSmokeCreatePatch
        //{
        //    public static void Postfix(ref int bPos, ref bool pCopy, ref int billno)
        //    {
        //        MelonLogger.Msg("--parManager.dds3Particle_SphereSmokeCreate--");
        //        MelonLogger.Msg("bPos: " + bPos);
        //        MelonLogger.Msg("pCopy: " + pCopy);
        //        MelonLogger.Msg("billno: " + billno);
        //    }
        //}
        //[HarmonyPatch(typeof(parManager), nameof(parManager.dds3Particle_SphereRingCreate))]
        //private class dds3Particle_SphereRingCreatePatch
        //{
        //    public static void Postfix(ref int bPos, ref bool pCopy, ref int billno)
        //    {
        //        MelonLogger.Msg("--parManager.dds3Particle_SphereRingCreate--");
        //        MelonLogger.Msg("bPos: " + bPos);
        //        MelonLogger.Msg("pCopy: " + pCopy);
        //        MelonLogger.Msg("billno: " + billno);
        //    }
        //}
        //[HarmonyPatch(typeof(parManager), nameof(parManager.dds3Particle_Spark2Create))]
        //private class dds3Particle_Spark2CreatePatch
        //{
        //    public static void Postfix(ref int bPos, ref bool pCopy, ref int billno)
        //    {
        //        MelonLogger.Msg("--parManager.dds3Particle_Spark2Create--");
        //        MelonLogger.Msg("bPos: " + bPos);
        //        MelonLogger.Msg("pCopy: " + pCopy);
        //        MelonLogger.Msg("billno: " + billno);
        //    }
        //}
        //[HarmonyPatch(typeof(parManager), nameof(parManager.dds3Particle_SphereAtomCreate))]
        //private class dds3Particle_SphereAtomCreatePatch
        //{
        //    public static void Postfix(ref int bPos, ref bool pCopy, ref int billno)
        //    {
        //        MelonLogger.Msg("--parManager.dds3Particle_SphereAtomCreate--");
        //        MelonLogger.Msg("bPos: " + bPos);
        //        MelonLogger.Msg("pCopy: " + pCopy);
        //        MelonLogger.Msg("billno: " + billno);
        //    }
        //}
        //[HarmonyPatch(typeof(parManager), nameof(parManager.dds3Particle_NopCreate))]
        //private class dds3Particle_NopCreatePatch
        //{
        //    public static void Postfix(ref int bPos, ref bool pCopy, ref int billno)
        //    {
        //        MelonLogger.Msg("--parManager.dds3Particle_NopCreate--");
        //        MelonLogger.Msg("bPos: " + bPos);
        //        MelonLogger.Msg("pCopy: " + pCopy);
        //        MelonLogger.Msg("billno: " + billno);
        //    }
        //}
        //[HarmonyPatch(typeof(parManager), nameof(parManager.dds3Particle_SparkOffsetCreate))]
        //private class dds3Particle_SparkOffsetCreatePatch
        //{
        //    public static void Postfix(ref int bPos, ref bool pCopy, ref int billno)
        //    {
        //        MelonLogger.Msg("--parManager.dds3Particle_SparkOffsetCreate--");
        //        MelonLogger.Msg("bPos: " + bPos);
        //        MelonLogger.Msg("pCopy: " + pCopy);
        //        MelonLogger.Msg("billno: " + billno);
        //    }
        //}
        //[HarmonyPatch(typeof(parManager), nameof(parManager.dds3Particle_SmokeOffsetCreate))]
        //private class dds3Particle_SmokeOffsetCreatePatch
        //{
        //    public static void Postfix(ref int bPos, ref bool pCopy, ref int billno)
        //    {
        //        MelonLogger.Msg("--parManager.dds3Particle_SmokeOffsetCreate--");
        //        MelonLogger.Msg("bPos: " + bPos);
        //        MelonLogger.Msg("pCopy: " + pCopy);
        //        MelonLogger.Msg("billno: " + billno);
        //    }
        //}
        //[HarmonyPatch(typeof(parManager), nameof(parManager.dds3Particle_SphereSpiral2Create))]
        //private class dds3Particle_SphereSpiral2CreatePatch
        //{
        //    public static void Postfix(ref int bPos, ref bool pCopy, ref int billno)
        //    {
        //        MelonLogger.Msg("--parManager.dds3Particle_SphereSpiral2Create--");
        //        MelonLogger.Msg("bPos: " + bPos);
        //        MelonLogger.Msg("pCopy: " + pCopy);
        //        MelonLogger.Msg("billno: " + billno);
        //    }
        //}



        [HarmonyPatch(typeof(fld_Npc), nameof(fld_Npc.fldItemBoxAdd))]
        private class ItemBoxAddPatch
        {
            public static void Prefix(int idx, float x, float y, float z, Vector4 rot)
            {
                MelonLogger.Msg("-fld_Npc.fldItemBoxAdd-");
                MelonLogger.Msg("idx: " + idx);
                MelonLogger.Msg("x: " + x);
                MelonLogger.Msg("y: " + y);
                MelonLogger.Msg("z: " + z);
                MelonLogger.Msg("rot: " + rot);
            }
        }

        [HarmonyPatch(typeof(fld_Npc), nameof(fld_Npc.fldNpcAdd))]
        private class NpcAddPatch
        {
            public static void Prefix(int Type, float x, float y, float z, Vector4 rot, int hojiID, ref string name, int eveidx)
            {
                MelonLogger.Msg("-fld_Npc.fldNpcAdd-");
                MelonLogger.Msg("Type: " + Type);
                MelonLogger.Msg("x: " + x);
                MelonLogger.Msg("y: " + y);
                MelonLogger.Msg("z: " + z);
                MelonLogger.Msg("rot: " + rot);
                MelonLogger.Msg("hojiID: " + hojiID);
                MelonLogger.Msg("name: " + name);
                MelonLogger.Msg("eveidx: " + eveidx);
            }
        }

        [HarmonyPatch(typeof(fld_Npc), nameof(fld_Npc.fldItemBoxOpen))]
        private class ItemBoxOpenPatch
        {
            public static void Prefix(int idx)
            {
                MelonLogger.Msg("-fld_Npc.fldItemBoxOpen-");
                MelonLogger.Msg("idx: " + idx);
            }
        }

        [HarmonyPatch(typeof(fldGlobal), nameof(fldGlobal.fldGbSetTakaraOpen))]
        private class SetTakaraOpenPatch
        {
            public static void Prefix(int idx)
            {
                MelonLogger.Msg("-fldGlobal.fldGbSetTakaraOpen-");
                MelonLogger.Msg("idx: " + idx);
            }
        }

        [HarmonyPatch(typeof(fldFileResolver), nameof(fldFileResolver.fldLoadFile))]
        private class fldLoadFilePatch
        {
            public static void Prefix(string pFileName, string akey)
            {
                MelonLogger.Msg("-fldFileResolver.fldLoadFile-");
                MelonLogger.Msg("pFileName: " + pFileName);
                MelonLogger.Msg("akey: " + akey);
            }

            public static void Postfix(string pFileName, string akey)
            {
                if (pFileName == "dds3data/fld/f/f002/f002_001") // Overworld 1
                {
                    // Co-ordinates are divided by 100 in-game, y co-ordinate is reversed
                    fld_Npc.fldItemBoxAdd(335, -117.80762f, -821.31445f, -3201.4497f, new Vector4(0, 0, 0, 1)); // Add Item Box outside Shibuya
                }
                if (pFileName == "dds3data/fld/f/f004/f004_001") // Overworld 3
                {
                    // -42.0961 14.5565 -33.3055
                    fld_Npc.fldItemBoxAdd(336, -4209.61f, -1455.65f, -3330.55f, new Vector4(0, 0, 0, 1)); // Add Item Box outside Ikebukuro
                }
                if (pFileName == "dds3data/fld/f/f020/f020_006") // Assembly of Nihilo Core
                {
                    // 1.9422 0 -2.6764
                    // 0 45 0
                    fld_Npc.fldItemBoxAdd(350, 194.22f, 0f, -267.64f, new Vector4(0, 45, 0, 1)); // Add Item Box in Nihilo Core
                }
                if (pFileName == "dds3data/fld/f/f034/f034_001") // Amala Temple Entrance
                {
                    // 19.5531 0 51.822
                    fld_Npc.fldItemBoxAdd(349, 1955.31f, 0f, 5182.2f, new Vector4(0, 90, 0, 1)); // Add Item Box in Amala Temple Entrance
                }
                if (pFileName == "dds3data/fld/f/f027/f027_001") // Asakusa 1
                {
                    // 4.0364 0.2 31.4621
                    fld_Npc.fldItemBoxAdd(351, -403.64f, -20f, 3146.21f, new Vector4(0, 0, 0, 1)); // Add Item Box in Asakusa
                }
                if (pFileName == "dds3data/fld/f/f033/f033_028") // Diet Building After Mot
                {
                    // -2.2584 0 -4.307
                    fld_Npc.fldItemBoxAdd(348, -225.84f, 0f, -430.70f, new Vector4(0, 0, 0, 1)); // Add Item Box in Diet Building after Mot
                }
                if (pFileName == "dds3data/fld/f/f033/f033_029") // Diet Building After Mitra
                {
                    // 13.7302 1.2692 -12.8815
                    // fld_Npc.fldItemBoxAdd(337, 1373.02f, -126.92f, -1288.15f, new Vector4(0, 0, 0, 1)); // Add Item Box in Diet Building after Mitra
                    // 15.2281 0 -24.3815
                    fld_Npc.fldItemBoxAdd(337, 1522.81f, 0f, -2438.15f, new Vector4(0, 0, 0, 1)); // Add Item Box in Diet Building after Mitra
                }
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetKakutokuExp))]
        private class nbGetKakutokuExpPatch
        {
            public static void Postfix(ref nbMainProcessData_t data, ref int __result)
            {
                // Toggle EXP on random encounters
                if (ToggleExpOnRandomEncounters.Value == false && datEncount.tbl[data.encno].esc != 1)
                __result = 0;
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetKakutokuMaka))]
        private class nbGetKakutokuMakaPatch
        {
            public static void Postfix(ref nbMainProcessData_t data, ref int __result)
            {
                // Macca multiplier
                __result = Convert.ToInt32(__result * EncounterMaccaMultiplier.Value);
            }
        }

        [HarmonyPatch(typeof(fldProcess), nameof(fldProcess.ProcSequence))]
        private class fldProcessProcSequencePatch
        {
            public static void Prefix()
            {
                MelonLogger.Msg("--fldProcess.ProcSequence--");
                MelonLogger.Msg("encounttbl: " + fldProcess.fldBattleData.encounttbl);
                MelonLogger.Msg("encountpack: " + fldProcess.fldBattleData.encountpack);
            }
        }

        // These patches seem to prevent a crash during the level up screen, I don't know why
        [HarmonyPatch(typeof(rstinit), nameof(rstinit.rstChkLevelUpTarget))]
        private class rstChkLevelUpTargetPatch
        {
            public static void Prefix(ref datUnitWork_t pStock)
            {
                //MelonLogger.Msg("--rstinit.rstChkLevelUpTarget--");
                //MelonLogger.Msg("pStock.id: " + pStock.id);
            }
            public static void Postfix(ref datUnitWork_t pStock, ref int __result)
            {
                //MelonLogger.Msg("--rstinit.rstChkLevelUpTarget Post--");
                //MelonLogger.Msg("pStock.id: " + pStock.id);
                //MelonLogger.Msg("result: " + __result);
            }
        }

        [HarmonyPatch(typeof(rstcalc), nameof(rstcalc.rstAddLevel))]
        private class rstAddLevelPatch
        {
            public static void Prefix(ref int Val, ref datUnitWork_t pStock)
            {
                //MelonLogger.Msg("--rstcalc.rstAddLevel--");
                //MelonLogger.Msg("Val: " + Val);
                //MelonLogger.Msg("pStock.id: " + pStock.id);
            }
        }

        [HarmonyPatch(typeof(rstcalc), nameof(rstcalc.rstSetLevelUpCount))]
        private class rstSetLevelUpCountPatch
        {
            public static void Prefix(ref datUnitWork_t pStock)
            {
                //MelonLogger.Msg("--rstcalc.rstSetLevelUpCount--");
                //MelonLogger.Msg("pStock.id: " + pStock.id);
            }
            public static void Postfix(ref datUnitWork_t pStock, ref sbyte __result)
            {
                //MelonLogger.Msg("--rstcalc.rstSetLevelUpCount Post--");
                //MelonLogger.Msg("pStock.id: " + pStock.id);
                //MelonLogger.Msg("result: " + __result);
            }
        }

        [HarmonyPatch(typeof(rstcalc), nameof(rstcalc.rstCalcSeqDevilLevelUp))]
        private class rstCalcSeqDevilLevelUpPatch
        {
            public static void Prefix()
            {
                //MelonLogger.Msg("--rstcalc.rstCalcSeqDevilLevelUp--");
            }
            public static void Postfix(ref int __result)
            {
                //MelonLogger.Msg("--rstcalc.rstCalcSeqDevilLevelUp Post--");
                //MelonLogger.Msg("result: " + __result);
            }
        }

        [HarmonyPatch(typeof(rstcalc), nameof(rstcalc.rstCalc))]
        private class rstCalcPatch
        {
            public static void Prefix()
            {
                //MelonLogger.Msg("--rstcalc.rstCalc--");
            }
            public static void Postfix()
            {
                //MelonLogger.Msg("--rstcalc.rstCalc Post--");
            }
        }

        [HarmonyPatch(typeof(fclMisc), nameof(fclMisc.fclSetMessageVar))]
        private class fclSetMessageVarPatch
        {
            public static void Prefix(ref sbyte Index, ref string pStr)
            {
                //MelonLogger.Msg("--fclMisc.fclSetMessageVar--");
                //MelonLogger.Msg("Index: " + Index);
                //MelonLogger.Msg("pStr: " + pStr);
            }
        }
        [HarmonyPatch(typeof(fclMisc), nameof(fclMisc.fclStartMessage))]
        private class fclStartMessagePatch
        {
            public static void Prefix(ref int MsgNo)
            {
                //MelonLogger.Msg("--fclMisc.fclStartMessage--");
                //MelonLogger.Msg("MsgNo: " + MsgNo);
            }
        }
        [HarmonyPatch(typeof(fclMisc), nameof(fclMisc.fclStartSelMessage))]
        private class fclStartSelMessagePatch
        {
            public static void Prefix(ref int SelMsgNo)
            {
                //MelonLogger.Msg("--fclMisc.fclStartSelMessage--");
                //MelonLogger.Msg("SelMsgNo: " + SelMsgNo);
            }
        }
    }
}