using HarmonyLib;
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
            Hifumi(6);
            Kamudo(7);
            Narukami(8);
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
            datAisyo.tbl[388][0] = 100; // Phys
            datAisyo.tbl[388][1] = 100; // Fire
            datAisyo.tbl[388][2] = 100; // Ice
            datAisyo.tbl[388][3] = 100; // Elec
            datAisyo.tbl[388][4] = 100; // Force
            datAisyo.tbl[388][6] = 65536; // Light
            datAisyo.tbl[388][7] = 2147483798; // Dark
            datAisyo.tbl[388][8] = 100; // Curse
            datAisyo.tbl[388][9] = 100; // Nerve
            datAisyo.tbl[388][10] = 100; // Mind

            datAisyo.tbl[389][0] = 100; // Phys
            datAisyo.tbl[389][1] = 100; // Fire
            datAisyo.tbl[389][2] = 100; // Ice
            datAisyo.tbl[389][3] = 100; // Elec
            datAisyo.tbl[389][4] = 100; // Force
            datAisyo.tbl[389][6] = 65536; // Light
            datAisyo.tbl[389][7] = 2147483798; // Dark
            datAisyo.tbl[389][8] = 100; // Curse
            datAisyo.tbl[389][9] = 100; // Nerve
            datAisyo.tbl[389][10] = 100; // Mind

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5] = 3; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 3; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 36;
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 5;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 290;
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 6;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 43;
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 8;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 296;
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 12;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 39;
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 16;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 346;
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 20;
        }

        private static void Iyomante(ushort id)
        {
            // Affinities
            datAisyo.tbl[390][0] = 100; // Phys
            datAisyo.tbl[390][1] = 100; // Fire
            datAisyo.tbl[390][2] = 100; // Ice
            datAisyo.tbl[390][3] = 100; // Elec
            datAisyo.tbl[390][4] = 100; // Force
            datAisyo.tbl[390][6] = 100; // Light
            datAisyo.tbl[390][7] = 100; // Dark
            datAisyo.tbl[390][8] = 100; // Curse
            datAisyo.tbl[390][9] = 100; // Nerve
            datAisyo.tbl[390][10] = 65536; // Mind

            datAisyo.tbl[391][0] = 100; // Phys
            datAisyo.tbl[391][1] = 100; // Fire
            datAisyo.tbl[391][2] = 100; // Ice
            datAisyo.tbl[391][3] = 100; // Elec
            datAisyo.tbl[391][4] = 100; // Force
            datAisyo.tbl[391][6] = 100; // Light
            datAisyo.tbl[391][7] = 100; // Dark
            datAisyo.tbl[391][8] = 100; // Curse
            datAisyo.tbl[391][9] = 100; // Nerve
            datAisyo.tbl[391][10] = 65536; // Mind

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
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 23;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 77;
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 28;
        }

        private static void Shiranui(ushort id)
        {
            // Affinities
            datAisyo.tbl[392][0] = 100; // Phys
            datAisyo.tbl[392][1] = 65536; // Fire
            datAisyo.tbl[392][2] = 100; // Ice
            datAisyo.tbl[392][3] = 100; // Elec
            datAisyo.tbl[392][4] = 2147483798; // Force
            datAisyo.tbl[392][6] = 100; // Light
            datAisyo.tbl[392][7] = 100; // Dark
            datAisyo.tbl[392][8] = 100; // Curse
            datAisyo.tbl[392][9] = 100; // Nerve
            datAisyo.tbl[392][10] = 100; // Mind

            datAisyo.tbl[393][0] = 100; // Phys
            datAisyo.tbl[393][1] = 65536; // Fire
            datAisyo.tbl[393][2] = 100; // Ice
            datAisyo.tbl[393][3] = 100; // Elec
            datAisyo.tbl[393][4] = 2147483798; // Force
            datAisyo.tbl[393][6] = 100; // Light
            datAisyo.tbl[393][7] = 100; // Dark
            datAisyo.tbl[393][8] = 100; // Curse
            datAisyo.tbl[393][9] = 100; // Nerve
            datAisyo.tbl[393][10] = 100; // Mind

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

        private static void Hifumi(ushort id)
        {
            // Affinities
            datAisyo.tbl[394][0] = 100; // Phys
            datAisyo.tbl[394][1] = 2147483798; // Fire
            datAisyo.tbl[394][2] = 100; // Ice
            datAisyo.tbl[394][3] = 100; // Elec
            datAisyo.tbl[394][4] = 65536; // Force
            datAisyo.tbl[394][6] = 100; // Light
            datAisyo.tbl[394][7] = 100; // Dark
            datAisyo.tbl[394][8] = 100; // Curse
            datAisyo.tbl[394][9] = 100; // Nerve
            datAisyo.tbl[394][10] = 100; // Mind

            datAisyo.tbl[395][0] = 100; // Phys
            datAisyo.tbl[395][1] = 2147483798; // Fire
            datAisyo.tbl[395][2] = 100; // Ice
            datAisyo.tbl[395][3] = 100; // Elec
            datAisyo.tbl[395][4] = 65536; // Force
            datAisyo.tbl[395][6] = 100; // Light
            datAisyo.tbl[395][7] = 100; // Dark
            datAisyo.tbl[395][8] = 100; // Curse
            datAisyo.tbl[395][9] = 100; // Nerve
            datAisyo.tbl[395][10] = 100; // Mind

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4] = 3; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 3; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5] = 5; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 5; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 461;
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 10;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 312;
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 18;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 203;
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 24;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 317;
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 26;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 185;
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 30;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 327;
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 40;
        }

        private static void Kamudo(ushort id)
        {
            // Affinities
            datAisyo.tbl[396][0] = 50; // Phys
            datAisyo.tbl[396][1] = 100; // Fire
            datAisyo.tbl[396][2] = 100; // Ice
            datAisyo.tbl[396][3] = 100; // Elec
            datAisyo.tbl[396][4] = 100; // Force
            datAisyo.tbl[396][6] = 100; // Light
            datAisyo.tbl[396][7] = 100; // Dark
            datAisyo.tbl[396][8] = 2147483798; // Curse
            datAisyo.tbl[396][9] = 2147483798; // Nerve
            datAisyo.tbl[396][10] = 2147483798; // Mind

            datAisyo.tbl[397][0] = 50; // Phys
            datAisyo.tbl[397][1] = 100; // Fire
            datAisyo.tbl[397][2] = 100; // Ice
            datAisyo.tbl[397][3] = 100; // Elec
            datAisyo.tbl[397][4] = 100; // Force
            datAisyo.tbl[397][6] = 100; // Light
            datAisyo.tbl[397][7] = 100; // Dark
            datAisyo.tbl[397][8] = 2147483798; // Curse
            datAisyo.tbl[397][9] = 2147483798; // Nerve
            datAisyo.tbl[397][10] = 2147483798; // Mind

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3] = 3; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 3; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5] = 1; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 1; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 430;
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 18;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 224;
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 21;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 99;
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 24;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 97;
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 27;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 299;
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 30;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 345;
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 40;
        }

        private static void Narukami(ushort id)
        {
            // Affinities
            datAisyo.tbl[398][0] = 100; // Phys
            datAisyo.tbl[398][1] = 100; // Fire
            datAisyo.tbl[398][2] = 2147483798; // Ice
            datAisyo.tbl[398][3] = 65536; // Elec
            datAisyo.tbl[398][4] = 100; // Force
            datAisyo.tbl[398][6] = 100; // Light
            datAisyo.tbl[398][7] = 100; // Dark
            datAisyo.tbl[398][8] = 100; // Curse
            datAisyo.tbl[398][9] = 100; // Nerve
            datAisyo.tbl[398][10] = 100; // Mind

            datAisyo.tbl[399][0] = 100; // Phys
            datAisyo.tbl[399][1] = 100; // Fire
            datAisyo.tbl[399][2] = 2147483798; // Ice
            datAisyo.tbl[399][3] = 65536; // Elec
            datAisyo.tbl[399][4] = 100; // Force
            datAisyo.tbl[399][6] = 100; // Light
            datAisyo.tbl[399][7] = 100; // Dark
            datAisyo.tbl[399][8] = 100; // Curse
            datAisyo.tbl[399][9] = 100; // Nerve
            datAisyo.tbl[399][10] = 100; // Mind

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0] = 6; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 6; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4] = 4; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 4; // Agility

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 182;
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 14;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 112;
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 18;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 316;
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 24;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 125;
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 30;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 469;
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 36;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 326;
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 42;
        }
    }
}
