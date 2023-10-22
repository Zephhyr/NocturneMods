using HarmonyLib;
using Il2Cpp;
using MelonLoader;
using Newtonsoft.Json;
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

            ApplySkillChanges();
            ApplyItemChanges();
            ApplyShopChanges();
            ApplyMagatamaChanges();
            ApplyDemonChanges();
            ApplyEncounterChanges();
        }

        [HarmonyPatch(typeof(fld_Npc), nameof(fld_Npc.fldItemBoxAdd))]
        private class ItemBoxAddPatch
        {
            public static void Prefix(int idx, float x, float y, float z, Vector4 rot)
            {
                MelonLogger.Msg("fld_Npc.fldItemBoxAdd");
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
                MelonLogger.Msg("fld_Npc.fldNpcAdd");
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
                MelonLogger.Msg("fld_Npc.fldItemBoxOpen");
                MelonLogger.Msg("idx: " + idx);
            }
        }

        [HarmonyPatch(typeof(fldGlobal), nameof(fldGlobal.fldGbSetTakaraOpen))]
        private class SetTakaraOpenPatch
        {
            public static void Prefix(int idx)
            {
                MelonLogger.Msg("fldGlobal.fldGbSetTakaraOpen");
                MelonLogger.Msg("idx: " + idx);
            }
        }

        [HarmonyPatch(typeof(fldFileResolver), nameof(fldFileResolver.fldLoadFile))]
        private class fldLoadFilePatch
        {
            public static void Prefix(string pFileName, string akey)
            {
                MelonLogger.Msg("fldFileResolver.fldLoadFile");
                MelonLogger.Msg("pFileName: " + pFileName);
                MelonLogger.Msg("akey: " + akey);
            }

            public static void Postfix(string pFileName, string akey)
            {
                if (pFileName == "dds3data/fld/f/f002/f002_001") // Overworld 1
                {
                    // Co-ordinates are divided by 100 in-game
                    fld_Npc.fldItemBoxAdd(335, -117.80762f, -821.31445f, -3201.4497f, new Vector4(0, 0, 0, 1)); // Add Item Box outside Shibuya
                }
            }
        }

        [HarmonyPatch(typeof(fldMain), nameof(fldMain.fldFirstInit))]
        private class fldFirstInitPatch
        {
            public static void Postfix()
            {
                MelonLogger.Msg("fldMain.fldFirstInit");
                //var output = JsonConvert.SerializeObject(fldGlobal.fldHitData._fldItemBoxTbl);
                //var output = JsonConvert.SerializeObject(fldGlobal.fldHitData._fldNpcUp);
                //var output = JsonConvert.SerializeObject(fld_Npc.gfldTakaraWork);
                //MelonLogger.Msg(output);

                ApplyItemBoxChanges();
            }
        }
    }
}