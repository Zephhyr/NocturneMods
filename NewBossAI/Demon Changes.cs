using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2Cppnewbattle_H;
using Il2Cppeffect_H;
using UnityEngine;

namespace NewBossAI
{
    internal partial class NewBossAI : MelonMod
    {
        private static void ApplyDemonChanges()
        {
            NagaRaja(77);
            Yaksini(100);
            BossForneus(256);
        }

        // 2148532374 = Weak but status-immune

        private static void NagaRaja(ushort id)
        {
            //datDevilFormat.tbl[id].skill[4] = 367;
        }

        private static void Yaksini(ushort id)
        {
            //tblSkill.fclSkillTbl[id].Event[0].Param = 367;
        }

        private static void BossForneus(ushort id)
        {
            datDevilFormat.tbl[id].maxhp = 800;
            datDevilFormat.tbl[id].hp = 800;
            datDevilAI.divTbls[2][0].ailevel = 0;

            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 262144; // Ice
            datAisyo.tbl[id][3] = 2147483798; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind
        }
    }
}