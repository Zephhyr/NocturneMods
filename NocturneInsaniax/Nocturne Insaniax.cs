using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2Cppnewbattle_H;
using Il2Cppeffect_H;
using UnityEngine;
using static Il2Cpp.SteamDlcFileUtil;

[assembly: MelonInfo(typeof(NocturneInsaniax.NocturneInsaniax), "Nocturne Insaniax", "0.8.0", "Zephhyr, Matthiew Purple")]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        private static System.Random random = new System.Random();
        private static Dictionary<int, ActionTracker> actionTrackers = new Dictionary<int, ActionTracker>();

        public override void OnInitializeMelon()
        {
            //foreach (var skill in tblSkill.fclSkillTbl[194].Event)
            //    MelonLogger.Msg(skill.TargetLevel + " - " + skill.Param + " - " + skill.Type);

            ApplySkillChanges();
            ApplyItemChanges();
            ApplyDemonChanges();
        }
    }
}