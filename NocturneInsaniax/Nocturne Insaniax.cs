using HarmonyLib;
using Il2Cpp;
using Il2Cppbasic_H;
using Il2Cppinterface_H;
using Il2Cppkernel_H;
using Il2Cppnewbattle_H;
using Il2Cppnewdata_H;
using Il2Cppscr_H;
using Il2CppTMPro;
using MelonLoader;
using MelonLoader.CoreClrUtils;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using UnityEngine;

[assembly: MelonInfo(typeof(NocturneInsaniax.NocturneInsaniax), "Nocturne Insaniax", "0.8.0", "Zephhyr, Matthiew Purple")]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
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

            //var output = JsonConvert.SerializeObject(datDevilVisual11.tbl_11_160_17F);
            //MelonLogger.Msg(output);

            ApplySkillChanges();
            ApplyItemChanges();
            ApplyShopChanges();
            ApplyMagatamaChanges();
            ApplyDemonChanges();
            ApplyEncounterChanges();
        }

        public override void OnLateUpdate()
        {
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
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D224_MSEE0_14", "D224_MSEE0_14", 93519872 , false);
                Smg.Instance._TblAdd(Smg.eType.SE_MSE, "D224_MSEE0_15", "D224_MSEE0_15", 93519873 , false);
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
                doppelgangerKeys.Add("D225_MSEE1_16", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_15", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_17", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_15", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_18", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_15", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_20", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_15", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_21", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_15", diff = true });
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
                doppelgangerKeys.Add("D225_MSEE1_16_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_15_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_17_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_15_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_18_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_15_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_20_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_15_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_21_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_15_E", diff = true });
                doppelgangerKeys.Add("D225_MSEE1_24_E", new SndAssetBundleManager.SndData { key = "dvl0xe1", path = 4, id = 0, name = "D225_MSEE1_24_E", diff = true });
                SndAssetBundleManager.SEBundleTable.Add("dvl0xe1", doppelgangerKeys);

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

                var bgmKeys = new Il2CppSystem.Collections.Generic.Dictionary<string, SndAssetBundleManager.SndData>();
                bgmKeys.Add("B1600_B1601_BGM01", new SndAssetBundleManager.SndData { key = "b_bgm16", path = 1, id = 0, name = "B1600_B1601_BGM01", diff = true });
                SndAssetBundleManager.BGMBundleTable.Add("b_bgm16", bgmKeys);

                //foreach (var dic in SndAssetBundleManager.SEBundleTable)
                //{
                //    MelonLogger.Msg(dic.key + ":");
                //    foreach (var sound in dic.value)
                //    {
                //        MelonLogger.Msg(sound.key + " - " + sound.value.name);
                //    }
                //}

                //foreach (var sound in SndAssetBundleManager.VoiceBundleTable)
                //{
                //    MelonLogger.Msg(sound.key + " - " + sound.value.name);
                //}
            }
        }

        [HarmonyPatch(typeof(nbEncount), nameof(nbEncount.nbGetBgmCategoryInBattle))]
        private class nbGetBgmCategoryInBattlePatch
        {
            public static void Postfix(int __result)
            {
                //MelonLogger.Msg("--nbEncount.nbGetBgmCategoryInBattle--");
                switch (__result)
                {
                    case 16:  
                        nbSound.bgmno = "B1600_B1601_BGM01";
                        nbSound.bgmsub = 0;
                        nbSound.bgmloadphase = 1;
                        nbSound.bgmdone = 0;
                        nbSound.bgmkey = 16;
                        break;
                    default: break;
                }
            }
        }

        //[HarmonyPatch(typeof(SndAssetBundleManager), nameof(SndAssetBundleManager.LoadKeysMSE))]
        //private class LoadKeysMSEPatch
        //{
        //    public static void Postfix()
        //    {
        //        MelonLogger.Msg("--SndAssetBundleManager.LoadKeysMSE--");
        //        //MelonLogger.Msg("DF keys");
        //        //for (int i = 0; i <= 25; i++)
        //        //    MelonLogger.Msg(i + ": " + nbSound.GetMotionMIDI(0, i));
        //        //MelonLogger.Msg("Dop keys");
        //        //for (int i = 0; i <= 25; i++)
        //        //    MelonLogger.Msg(i + ": " + nbSound.GetMotionMIDI(225, i));
        //        //MelonLogger.Msg("YHVH keys");
        //        //for (int i = 0; i <= 25; i++)
        //        //    MelonLogger.Msg(i + ": " + nbSound.GetMotionMIDI(254, i));
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
                if (pFileName == "dds3data/fld/f/f027/f027_001") // Asakusa 1
                {
                    // 4.0364 0.2 31.4621
                    fld_Npc.fldItemBoxAdd(351, -403.64f, -20f, 3146.21f, new Vector4(0, 0, 0, 1)); // Add Item Box in Asakusa
                }
                
            }
        }
    }
}