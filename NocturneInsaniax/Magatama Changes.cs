﻿using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2Cppnewbattle_H;
using Il2Cppeffect_H;
using UnityEngine;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        private static void ApplyMagatamaChanges()
        {
            Marogareh(1);
            Wadatsumi(2);
            Ankh(3);
            Iyomante(4);
            Shiranui(5);
        }

        private static void Marogareh(ushort id)
        {
            // Affinities
            datAisyo.tbl[384][0] = 100; // Phys
            datAisyo.tbl[384][1] = 100; // Fire
            datAisyo.tbl[384][2] = 100; // Ice
            datAisyo.tbl[384][3] = 100; // Elec
            datAisyo.tbl[384][4] = 100; // Force
            datAisyo.tbl[384][6] = 100; // Light
            datAisyo.tbl[384][7] = 100; // Dark
            datAisyo.tbl[384][8] = 100; // Curse
            datAisyo.tbl[384][9] = 100; // Nerve
            datAisyo.tbl[384][10] = 100; // Mind

            datAisyo.tbl[385][0] = 100; // Phys
            datAisyo.tbl[385][1] = 100; // Fire
            datAisyo.tbl[385][2] = 100; // Ice
            datAisyo.tbl[385][3] = 100; // Elec
            datAisyo.tbl[385][4] = 100; // Force
            datAisyo.tbl[385][6] = 100; // Light
            datAisyo.tbl[385][7] = 100; // Dark
            datAisyo.tbl[385][8] = 100; // Curse
            datAisyo.tbl[385][9] = 100; // Nerve
            datAisyo.tbl[385][10] = 100; // Mind

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5] = 2; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 2; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 96;
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 2;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 71;
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 3;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 190;
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 4;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 209;
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 5;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 98;
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 10;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 305;
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 14;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 301;
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 18;
            tblHearts.fclHeartsTbl[id].Skill[7].ID = 425;
            tblHearts.fclHeartsTbl[id].Skill[7].TargetLevel = 19;
        }

        private static void Wadatsumi(ushort id)
        {
            // Affinities
            datAisyo.tbl[386][0] = 100; // Phys
            datAisyo.tbl[386][1] = 100; // Fire
            datAisyo.tbl[386][2] = 65536; // Ice
            datAisyo.tbl[386][3] = 2147483798; // Elec
            datAisyo.tbl[386][4] = 100; // Force
            datAisyo.tbl[386][6] = 100; // Light
            datAisyo.tbl[386][7] = 100; // Dark
            datAisyo.tbl[386][8] = 100; // Curse
            datAisyo.tbl[386][9] = 100; // Nerve
            datAisyo.tbl[386][10] = 100; // Mind

            datAisyo.tbl[387][0] = 100; // Phys
            datAisyo.tbl[387][1] = 100; // Fire
            datAisyo.tbl[387][2] = 65536; // Ice
            datAisyo.tbl[387][3] = 2147483798; // Elec
            datAisyo.tbl[387][4] = 100; // Force
            datAisyo.tbl[387][6] = 100; // Light
            datAisyo.tbl[387][7] = 100; // Dark
            datAisyo.tbl[387][8] = 100; // Curse
            datAisyo.tbl[387][9] = 100; // Nerve
            datAisyo.tbl[387][10] = 100; // Mind

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2] = 4; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 4; // Magic

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 180;
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 7;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 293;
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 11;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 310;
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 15;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 204;
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 19;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 437;
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 21;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 315;
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 23;
        }

        private static void Ankh(ushort id)
        {
            // Affinities
            datAisyo.tbl[386][0] = 100; // Phys
            datAisyo.tbl[386][1] = 100; // Fire
            datAisyo.tbl[386][2] = 100; // Ice
            datAisyo.tbl[386][3] = 100; // Elec
            datAisyo.tbl[386][4] = 100; // Force
            datAisyo.tbl[386][6] = 65536; // Light
            datAisyo.tbl[386][7] = 2147483798; // Dark
            datAisyo.tbl[386][8] = 100; // Curse
            datAisyo.tbl[386][9] = 100; // Nerve
            datAisyo.tbl[386][10] = 100; // Mind

            datAisyo.tbl[387][0] = 100; // Phys
            datAisyo.tbl[387][1] = 100; // Fire
            datAisyo.tbl[387][2] = 100; // Ice
            datAisyo.tbl[387][3] = 100; // Elec
            datAisyo.tbl[387][4] = 100; // Force
            datAisyo.tbl[387][6] = 65536; // Light
            datAisyo.tbl[387][7] = 2147483798; // Dark
            datAisyo.tbl[387][8] = 100; // Curse
            datAisyo.tbl[387][9] = 100; // Nerve
            datAisyo.tbl[387][10] = 100; // Mind

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5] = 3; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 3; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 36;
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 5;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 290;
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 6;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 296;
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 11;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 39;
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 16;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 346;
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 21;
        }

        private static void Iyomante(ushort id)
        {
            // Affinities
            datAisyo.tbl[386][0] = 100; // Phys
            datAisyo.tbl[386][1] = 100; // Fire
            datAisyo.tbl[386][2] = 100; // Ice
            datAisyo.tbl[386][3] = 100; // Elec
            datAisyo.tbl[386][4] = 100; // Force
            datAisyo.tbl[386][6] = 100; // Light
            datAisyo.tbl[386][7] = 100; // Dark
            datAisyo.tbl[386][8] = 100; // Curse
            datAisyo.tbl[386][9] = 100; // Nerve
            datAisyo.tbl[386][10] = 65536; // Mind

            datAisyo.tbl[387][0] = 100; // Phys
            datAisyo.tbl[387][1] = 100; // Fire
            datAisyo.tbl[387][2] = 100; // Ice
            datAisyo.tbl[387][3] = 100; // Elec
            datAisyo.tbl[387][4] = 100; // Force
            datAisyo.tbl[387][6] = 100; // Light
            datAisyo.tbl[387][7] = 100; // Dark
            datAisyo.tbl[387][8] = 100; // Curse
            datAisyo.tbl[387][9] = 100; // Nerve
            datAisyo.tbl[387][10] = 65536; // Mind

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0] = 3; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 3; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3] = 3; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 3; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5] = 2; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 2; // Luck


            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 52;
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 8;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 53;
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 12;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 54;
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 16;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 300;
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 18;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 298;
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 22;
        }

        private static void Shiranui(ushort id)
        {
            // Affinities
            datAisyo.tbl[386][0] = 100; // Phys
            datAisyo.tbl[386][1] = 65536; // Fire
            datAisyo.tbl[386][2] = 100; // Ice
            datAisyo.tbl[386][3] = 100; // Elec
            datAisyo.tbl[386][4] = 2147483798; // Force
            datAisyo.tbl[386][6] = 100; // Light
            datAisyo.tbl[386][7] = 100; // Dark
            datAisyo.tbl[386][8] = 100; // Curse
            datAisyo.tbl[386][9] = 100; // Nerve
            datAisyo.tbl[386][10] = 100; // Mind

            datAisyo.tbl[387][0] = 100; // Phys
            datAisyo.tbl[387][1] = 65536; // Fire
            datAisyo.tbl[387][2] = 100; // Ice
            datAisyo.tbl[387][3] = 100; // Elec
            datAisyo.tbl[387][4] = 2147483798; // Force
            datAisyo.tbl[387][6] = 100; // Light
            datAisyo.tbl[387][7] = 100; // Dark
            datAisyo.tbl[387][8] = 100; // Curse
            datAisyo.tbl[387][9] = 100; // Nerve
            datAisyo.tbl[387][10] = 100; // Mind

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4] = 5; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 5; // Agility

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 176;
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 8;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 309;
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 14;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 101;
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 16;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 435;
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 18;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 205;
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 21;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 314;
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 23;
        }
    }
}