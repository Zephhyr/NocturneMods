using HarmonyLib;
using Il2Cpp;
using Il2Cppnewbattle_H;
using MelonLoader;
using MelonLoader.CoreClrUtils;
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
                    default: break;
                }
            }
        }

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
                if (pFileName == "dds3data/fld/f/f004/f004_001") // Overworld 1
                {
                    // -42.0961 14.5565 -33.3055
                    fld_Npc.fldItemBoxAdd(336, -4209.61f, -1455.65f, -3330.55f, new Vector4(0, 0, 0, 1)); // Add Item Box outside Ikebukuro
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
    }
}