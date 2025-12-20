using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2Cppnewbattle_H;
using Il2Cppeffect_H;
using UnityEngine;
using Newtonsoft.Json;
using Il2CppSystem.Runtime.Remoting.Messaging;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        private static sbyte[] magatamaPotentialElemThresholds = new sbyte[]
        { //0, +1, +2, +3, +4, +5, +6, +7, +8, +9
            0,  1,  3,  5,  7, 11, 15, 19, 22, 25
        };

        private static sbyte[] magatamaPotentialSuppThresholds = new sbyte[]
        { //0, +1, +2, +3, +4, +5
            0,  2,  4,  8, 12, 18,
        };

        private static sbyte[][] magatamaPotentialAffinities = new sbyte[][]
        {
            new sbyte[] { },          // 00
            new sbyte[] { },          // 01 Marogareh  (Marogareh)
            new sbyte[] { 2 },        // 02 Wadatsumi  (Wadatsumi)
            new sbyte[] { 13 },       // 03 Ankh       (Ankh)
            new sbyte[] { 14 },       // 04 Iyomante   (Iyomante)
            new sbyte[] { 1 },        // 05 Shiranui   (Shiranui)
            new sbyte[] { 4 },        // 06 Hifumi     (Hifumi)
            new sbyte[] { 0 },        // 07 Kamurogi   (Kamudo)
            new sbyte[] { 3 },        // 08 Kamudo     (Narukami)
            new sbyte[] { 7 },        // 09 Anathema   (Anathema)
            new sbyte[] { 8, 9, 10 }, // 10 Miasma     (Miasma)
            new sbyte[] { 6 },        // 11 Nirvana    (Nirvana)
            new sbyte[] { 12 },       // 12 Vimana     (Murakumo)
            new sbyte[] { 2 },        // 13 Geis       (Geis)
            new sbyte[] { 14 },       // 14 Djed       (Djed)
            new sbyte[] { 1 },        // 15 Muspell    (Muspell)
            new sbyte[] { 5 },        // 16 Satan      (Gehenna)
            new sbyte[] { 8, 9, 10 }, // 17 Adama      (Kamurogi)
            new sbyte[] { 7 },        // 18 Gehenna    (Satan)
            new sbyte[] { 13 },       // 19 Sophia     (Adama)
            new sbyte[] { 4 },        // 20 Murakumo   (Vimana)
            new sbyte[] { 6 },        // 21 Gundari    (Gundari)
            new sbyte[] { 3 },        // 22 Narukami   (Sophia)
            new sbyte[] { 0, 12 },    // 23 Gaea       (Gaea)
            new sbyte[] { 5 },        // 24 Kailash    (Kailash)
            new sbyte[] { }           // 25 Masakados
        };

        private static sbyte[] magatamaPotentialPoints = new sbyte[]
        {
            0, // 00
            0, // 01 Marogareh  (Marogareh)
            1, // 02 Wadatsumi  (Wadatsumi)
            1, // 03 Ankh       (Ankh)
            1, // 04 Iyomante   (Iyomante)
            1, // 05 Shiranui   (Shiranui)
            1, // 06 Hifumi     (Hifumi)
            1, // 07 Kamurogi   (Kamudo)
            1, // 08 Kamudo     (Narukami)
            1, // 09 Anathema   (Anathema)
            1, // 10 Miasma     (Miasma)
            1, // 11 Nirvana    (Nirvana)
            1, // 12 Vimana     (Murakumo)
            2, // 13 Geis       (Geis)
            1, // 14 Djed       (Djed)
            2, // 15 Muspell    (Muspell)
            1, // 16 Satan      (Gehenna)
            2, // 17 Adama      (Kamurogi)
            2, // 18 Gehenna    (Satan)
            1, // 19 Sophia     (Adama)
            2, // 20 Murakumo   (Vimana)
            2, // 21 Gundari    (Gundari)
            2, // 22 Narukami   (Sophia)
            2, // 23 Gaea       (Gaea)
            2, // 24 Kailash    (Kailash)
            6  // 25 Masakados
        };

        private static byte[] tierOneElemMagatama = new byte[] { 2, 5, 6, 7, 8, 9, 10, 11, 12, 16 };

        [HarmonyPatch(typeof(datHeartsName), nameof(datHeartsName.Get))]
        private class HeartsNamePatch
        {
            public static bool Prefix(ref int id, ref string __result)
            {
                switch (id)
                {
                    case 01: __result = "Marogareh"; return false; // 01 (Marogareh)
                    case 02: __result = "Wadatsumi"; return false; // 02 (Wadatsumi)
                    case 03: __result = "Ankh"; return false;      // 03 (Ankh)
                    case 04: __result = "Iyomante"; return false;  // 04 (Iyomante)
                    case 05: __result = "Shiranui"; return false;  // 05 (Shiranui)
                    case 06: __result = "Hifumi"; return false;    // 06 (Hifumi)
                    case 07: __result = "Kamurogi"; return false;  // 07 (Kamudo)
                    case 08: __result = "Kamudo"; return false;    // 08 (Narukami)
                    case 09: __result = "Anathema"; return false;  // 09 (Anathema)
                    case 10: __result = "Miasma"; return false;    // 10 (Miasma)
                    case 11: __result = "Nirvana"; return false;   // 11 (Nirvana)
                    case 12: __result = "Vimana"; return false;    // 12 (Murakumo)
                    case 13: __result = "Geis"; return false;      // 13 (Geis)
                    case 14: __result = "Djed"; return false;      // 14 (Djed)
                    case 15: __result = "Muspell"; return false;   // 15 (Muspell)
                    case 16: __result = "Satan"; return false;     // 16 (Gehenna)
                    case 17: __result = "Adama"; return false;     // 17 (Kamurogi)
                    case 18: __result = "Gehenna"; return false;   // 18 (Satan)
                    case 19: __result = "Sophia"; return false;    // 19 (Adama)
                    case 20: __result = "Murakumo"; return false;  // 20 (Vimana)
                    case 21: __result = "Gundari"; return false;   // 21 (Gundari)
                    case 22: __result = "Narukami"; return false;  // 22 (Sophia)
                    case 23: __result = "Gaea"; return false;      // 23 (Gaea)
                    case 24: __result = "Kailash"; return false;   // 24 (Kailash)
                    case 25: __result = "Masakados"; return false; // 25 Masakados
                    default: return true;
                }
            }
        }

        [HarmonyPatch(typeof(frFont), nameof(frFont.frReplaceLocalizeText))]
        private class MagatamaGetMessagePatch
        {
            public static void Postfix(ref string message, ref frMsgInfo_t mi, ref List<int> index, ref string __result)
            {
                switch (message)
                {
                    case "<SPD 7><F015_L0190><WAIT>": __result = "<SP7>> You obtained the Magatama <CO2>" + datHeartsName.Get(2) + "<CO0>. <WA>"; break; // After Forneus
                    case "<SPD 7><F016_L0067><WAIT>": __result = "<SP7>> You obtained the Magatama <CO2>" + datHeartsName.Get(3) + "<CO0>. <WA>"; break; // After Leaving Pixe in Yoyogi
                    case "<SPD 7><F024_L0222><WAIT>": __result = "<SP7>> You obtained the Magatama <CO2>" + datHeartsName.Get(8) + "<CO0>. <WA>"; break; // After Thor
                    case "<SPD 7><F020_L0134><WAIT>": __result = "<SP7>> You obtained the Magatama <CO2>" + datHeartsName.Get(9) + "<CO0>. <WA>"; break; // After Ose
                    case "<SPD 7><F025_L0209><WAIT>": __result = "<SP7>> You obtained the Magatama <CO2>" + datHeartsName.Get(10) + "<CO0>. <WA>"; break; // After Mizuchi
                    case "<SPD 7><F027_L0021><WAIT>": __result = "<SP7>> You obtained the Magatama <CO2>" + datHeartsName.Get(13) + "<CO0>. <WA>"; break; // After Puzzle Boy
                    case "<SPD 7><F031_L0067><WAIT>": __result = "<SP7>> You obtained the Magatama <CO2>" + datHeartsName.Get(14) + "<CO0>. <WA>"; break; // After Moirae Sisters
                    case "<SPD 7><F017_L0046><WAIT>": __result = "<SP7>> You obtained the Magatama <CO2>" + datHeartsName.Get(15) + "<CO0>. <WA>"; break; // After Mara
                    case "<F025_L0260><WAIT>": __result = "> You obtained the Magatama <CO2>" + datHeartsName.Get(18) + "<CO0>. <WA>"; break; // After Black Frost
                    case "<SPD 7><F034_L0013><WAIT>": __result = "<SP7>> You obtained the Magatama <CO2>" + datHeartsName.Get(19) + "<CO0>. <WA>"; break; // After Albion
                    case "<SPD 7><F039_L0037><WAIT>": __result = "<SP7>> You obtained the Magatama <CO2>" + datHeartsName.Get(21) + "<CO0>. <WA>"; break; // After Bishamonten
                }
            }
        }

        [HarmonyPatch(typeof(cmpDrawDH), nameof(cmpDrawDH.cmpDrawHeartsBase))]
        private class cmpDrawHeartsBasePatch
        {
            public static void Prefix()
            {
                for (int i = 0; i <= 23; i++)
                {
                    switch (tblHearts.fclHeartsTbl[i+1].Flag)
                    {
                        case 0: cmpDrawDH.GBWK.HeartsIcon[i].IconColor = 2; break;
                        case 1: cmpDrawDH.GBWK.HeartsIcon[i].IconColor = 0; break;
                        case 4: cmpDrawDH.GBWK.HeartsIcon[i].IconColor = 1; break;
                    }
                }
            }
        }

        private static void ApplyMagatamaChanges()
        {
            Marogareh(1);
            Wadatsumi(2);
            Ankh(3);
            Iyomante(4);
            Shiranui(5);
            Hifumi(6);
            Kamurogi(7);
            Kamudo(8);
            Anathema(9);
            Miasma(10);
            Nirvana(11);
            Vimana(12);
            Geis(13);
            Djed(14);
            Muspell(15);
            Satan(16);
            Adama(17);
            Gehenna(18);
            Sophia(19);
            Murakumo(20);
            Gundari(21);
            Narukami(22);
            Gaea(23);
            Kailash(24);
            Masakados(25);
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
            datAisyo.tbl[384][12] = 100; // Shot

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
            datAisyo.tbl[385][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 4; // Dark

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 4; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 4; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 3; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 3; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 3; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 3; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 4; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 4; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 3; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 3; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 4; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 4; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 96; // Lunge
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 2;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 71; // Analyze
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 3;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 190; // Deathtouch
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 4;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 209; // Stun Gaze
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 5;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 98; // Berserk
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 10;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 305; // Counter
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 14;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 425; // "Pierce"
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 15;
        }

        private static void Wadatsumi(ushort id)
        {
            // Affinities
            datAisyo.tbl[386][0] = 100; // Phys
            datAisyo.tbl[386][1] = 100; // Fire
            datAisyo.tbl[386][2] = 65536; // Ice
            datAisyo.tbl[386][3] = 2147483778; // Elec
            datAisyo.tbl[386][4] = 100; // Force
            datAisyo.tbl[386][6] = 100; // Light
            datAisyo.tbl[386][7] = 100; // Dark
            datAisyo.tbl[386][8] = 100; // Curse
            datAisyo.tbl[386][9] = 100; // Nerve
            datAisyo.tbl[386][10] = 100; // Mind
            datAisyo.tbl[386][12] = 100; // Shot

            datAisyo.tbl[387][0] = 100; // Phys
            datAisyo.tbl[387][1] = 100; // Fire
            datAisyo.tbl[387][2] = 65536; // Ice
            datAisyo.tbl[387][3] = 2147483778; // Elec
            datAisyo.tbl[387][4] = 100; // Force
            datAisyo.tbl[387][6] = 100; // Light
            datAisyo.tbl[387][7] = 100; // Dark
            datAisyo.tbl[387][8] = 100; // Curse
            datAisyo.tbl[387][9] = 100; // Nerve
            datAisyo.tbl[387][10] = 100; // Mind
            datAisyo.tbl[387][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 0; // Neutral

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 0; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 0; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 8; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 8; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 6; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 6; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 5; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 5; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 5; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 5; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 3; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 3; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 180; // Ice Breath
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 7;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 293; // Mana Bonus
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 11;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 437; // Refrigerate
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 15;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 204; // Fog Breath
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 19;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 310; // Ice Boost
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 21;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 378; // Solitary Drift
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 23;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 315; // Anti-Ice
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 25;
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
            datAisyo.tbl[388][7] = 2147483778; // Dark
            datAisyo.tbl[388][8] = 100; // Curse
            datAisyo.tbl[388][9] = 100; // Nerve
            datAisyo.tbl[388][10] = 100; // Mind
            datAisyo.tbl[388][12] = 100; // Shot

            datAisyo.tbl[389][0] = 100; // Phys
            datAisyo.tbl[389][1] = 100; // Fire
            datAisyo.tbl[389][2] = 100; // Ice
            datAisyo.tbl[389][3] = 100; // Elec
            datAisyo.tbl[389][4] = 100; // Force
            datAisyo.tbl[389][6] = 65536; // Light
            datAisyo.tbl[389][7] = 2147483778; // Dark
            datAisyo.tbl[389][8] = 100; // Curse
            datAisyo.tbl[389][9] = 100; // Nerve
            datAisyo.tbl[389][10] = 100; // Mind
            datAisyo.tbl[389][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 1; // Light

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 2; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 2; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 3; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 3; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 5; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 5; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 9; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 9; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 0; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 0; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 8; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 8; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 36; // Dia
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 5;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 290; // Life Bonus
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 6;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 43; // Patra
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 8;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 349; // Life Refill
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 12;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 296; // Fast Retreat
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 16;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 457; // Diamrita
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
            datAisyo.tbl[390][12] = 100; // Shot

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
            datAisyo.tbl[391][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 1; // Light

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 8; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 8; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 3; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 3; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 3; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 3; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 8; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 8; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 3; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 3; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 3; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 3; // Luck


            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 52; // Tarunda
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 8;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 53; // Sukunda
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 12;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 54; // Rakunda
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 16;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 298; // Mind's Eye
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 18;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 350; // Mana Refill
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 22;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 57; // Dekaja
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 26;
        }

        private static void Shiranui(ushort id)
        {
            // Affinities
            datAisyo.tbl[392][0] = 100; // Phys
            datAisyo.tbl[392][1] = 65536; // Fire
            datAisyo.tbl[392][2] = 100; // Ice
            datAisyo.tbl[392][3] = 100; // Elec
            datAisyo.tbl[392][4] = 2147483778; // Force
            datAisyo.tbl[392][6] = 100; // Light
            datAisyo.tbl[392][7] = 100; // Dark
            datAisyo.tbl[392][8] = 100; // Curse
            datAisyo.tbl[392][9] = 100; // Nerve
            datAisyo.tbl[392][10] = 100; // Mind
            datAisyo.tbl[392][12] = 100; // Shot

            datAisyo.tbl[393][0] = 100; // Phys
            datAisyo.tbl[393][1] = 65536; // Fire
            datAisyo.tbl[393][2] = 100; // Ice
            datAisyo.tbl[393][3] = 100; // Elec
            datAisyo.tbl[393][4] = 2147483778; // Force
            datAisyo.tbl[393][6] = 100; // Light
            datAisyo.tbl[393][7] = 100; // Dark
            datAisyo.tbl[393][8] = 100; // Curse
            datAisyo.tbl[393][9] = 100; // Nerve
            datAisyo.tbl[393][10] = 100; // Mind
            datAisyo.tbl[393][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 4; // Dark

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 0; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 0; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 11; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 11; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 11; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 11; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 0; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 0; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 11; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 11; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 0; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 0; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 176; // Fire Breath
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 8;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 101; // Heat Wave
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 12;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 435; // Scald
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 16;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 205; // Taunt
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 18;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 309; // Fire Boost
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 20;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 300; // Bright Might
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 22;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 314; // Anti-Fire
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 25;
        }

        private static void Hifumi(ushort id)
        {
            // Affinities
            datAisyo.tbl[394][0] = 100; // Phys
            datAisyo.tbl[394][1] = 2147483778; // Fire
            datAisyo.tbl[394][2] = 100; // Ice
            datAisyo.tbl[394][3] = 100; // Elec
            datAisyo.tbl[394][4] = 65536; // Force
            datAisyo.tbl[394][6] = 100; // Light
            datAisyo.tbl[394][7] = 100; // Dark
            datAisyo.tbl[394][8] = 100; // Curse
            datAisyo.tbl[394][9] = 100; // Nerve
            datAisyo.tbl[394][10] = 100; // Mind
            datAisyo.tbl[394][12] = 100; // Shot

            datAisyo.tbl[395][0] = 100; // Phys
            datAisyo.tbl[395][1] = 2147483778; // Fire
            datAisyo.tbl[395][2] = 100; // Ice
            datAisyo.tbl[395][3] = 100; // Elec
            datAisyo.tbl[395][4] = 65536; // Force
            datAisyo.tbl[395][6] = 100; // Light
            datAisyo.tbl[395][7] = 100; // Dark
            datAisyo.tbl[395][8] = 100; // Curse
            datAisyo.tbl[395][9] = 100; // Nerve
            datAisyo.tbl[395][10] = 100; // Mind
            datAisyo.tbl[395][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 0; // Neutral

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 0; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 0; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 12; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 12; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 6; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 6; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 0; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 0; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 5; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 5; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 10; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 10; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 461; // Storm Gale
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 10;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 128; // Rapid Needle
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 12;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 312; // Force Boost
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 18;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 203; // War Cry
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 20;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 317; // Anti-Force
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 24;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 369; // Spirit Well
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 28;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 185; // Tornado
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 32;
        }

        private static void Kamurogi(ushort id)
        {
            // Affinities
            datAisyo.tbl[396][0] = 50; // Phys
            datAisyo.tbl[396][1] = 100; // Fire
            datAisyo.tbl[396][2] = 100; // Ice
            datAisyo.tbl[396][3] = 100; // Elec
            datAisyo.tbl[396][4] = 100; // Force
            datAisyo.tbl[396][6] = 100; // Light
            datAisyo.tbl[396][7] = 100; // Dark
            datAisyo.tbl[396][8] = 2147483778; // Curse
            datAisyo.tbl[396][9] = 2147483778; // Nerve
            datAisyo.tbl[396][10] = 2147483778; // Mind
            datAisyo.tbl[396][12] = 50; // Shot

            datAisyo.tbl[397][0] = 50; // Phys
            datAisyo.tbl[397][1] = 100; // Fire
            datAisyo.tbl[397][2] = 100; // Ice
            datAisyo.tbl[397][3] = 100; // Elec
            datAisyo.tbl[397][4] = 100; // Force
            datAisyo.tbl[397][6] = 100; // Light
            datAisyo.tbl[397][7] = 100; // Dark
            datAisyo.tbl[397][8] = 2147483778; // Curse
            datAisyo.tbl[397][9] = 2147483778; // Nerve
            datAisyo.tbl[397][10] = 2147483778; // Mind
            datAisyo.tbl[397][12] = 50; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 1; // Light

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 12; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 12; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 0; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 0; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 2; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 2; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 8; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 8; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 8; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 8; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 6; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 6; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 430; // Chi Blast
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 18;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 224; // Focus
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 21;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 97; // Hell Thrust
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 24;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 368; // Renewal
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 27;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 480; // Acrobat Kick
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 35;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 362; // Phys Boost
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 40;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 144; // Oni Kagura
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 45;
        }

        private static void Kamudo(ushort id)
        {
            // Affinities
            datAisyo.tbl[398][0] = 100; // Phys
            datAisyo.tbl[398][1] = 100; // Fire
            datAisyo.tbl[398][2] = 2147483778; // Ice
            datAisyo.tbl[398][3] = 65536; // Elec
            datAisyo.tbl[398][4] = 100; // Force
            datAisyo.tbl[398][6] = 100; // Light
            datAisyo.tbl[398][7] = 100; // Dark
            datAisyo.tbl[398][8] = 100; // Curse
            datAisyo.tbl[398][9] = 100; // Nerve
            datAisyo.tbl[398][10] = 100; // Mind
            datAisyo.tbl[398][12] = 100; // Shot

            datAisyo.tbl[399][0] = 100; // Phys
            datAisyo.tbl[399][1] = 100; // Fire
            datAisyo.tbl[399][2] = 2147483778; // Ice
            datAisyo.tbl[399][3] = 65536; // Elec
            datAisyo.tbl[399][4] = 100; // Force
            datAisyo.tbl[399][6] = 100; // Light
            datAisyo.tbl[399][7] = 100; // Dark
            datAisyo.tbl[399][8] = 100; // Curse
            datAisyo.tbl[399][9] = 100; // Nerve
            datAisyo.tbl[399][10] = 100; // Mind
            datAisyo.tbl[399][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 0; // Neutral

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 14; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 14; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 14; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 14; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 5; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 5; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 0; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 0; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 9; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 9; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 0; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 0; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 182; // Shock
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 14;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 125; // Stun Claw
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 18;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 440; // Jolt
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 20;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 299; // Might
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 24;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 311; // Elec Boost
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 27;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 316; // Anti-Elec
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 30;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 469; // Mjolnir
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 44;
        }

        private static void Anathema(ushort id)
        {
            // Affinities
            datAisyo.tbl[400][0] = 100; // Phys
            datAisyo.tbl[400][1] = 100; // Fire
            datAisyo.tbl[400][2] = 100; // Ice
            datAisyo.tbl[400][3] = 100; // Elec
            datAisyo.tbl[400][4] = 100; // Force
            datAisyo.tbl[400][6] = 2147483778; // Light
            datAisyo.tbl[400][7] = 65536; // Dark
            datAisyo.tbl[400][8] = 100; // Curse
            datAisyo.tbl[400][9] = 100; // Nerve
            datAisyo.tbl[400][10] = 100; // Mind
            datAisyo.tbl[400][12] = 100; // Shot

            datAisyo.tbl[401][0] = 100; // Phys
            datAisyo.tbl[401][1] = 100; // Fire
            datAisyo.tbl[401][2] = 100; // Ice
            datAisyo.tbl[401][3] = 100; // Elec
            datAisyo.tbl[401][4] = 100; // Force
            datAisyo.tbl[401][6] = 2147483778; // Light
            datAisyo.tbl[401][7] = 65536; // Dark
            datAisyo.tbl[401][8] = 100; // Curse
            datAisyo.tbl[401][9] = 100; // Nerve
            datAisyo.tbl[401][10] = 100; // Mind
            datAisyo.tbl[401][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 4; // Dark

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 3; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 3; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 18; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 18; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 10; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 10; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 4; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 4; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 4; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 4; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 3; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 3; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 34; // Mamudo
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 22;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 424; // Concentrate
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 26;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 477; // Makai Thunder
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 30;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 301; // Dark Might
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 32;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 197; // Stone Gaze
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 36;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 114; // Arid Needle
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 38;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 319; // Anti-Dark
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 40;
        }

        private static void Miasma(ushort id)
        {
            // Affinities
            datAisyo.tbl[402][0] = 100; // Phys
            datAisyo.tbl[402][1] = 100; // Fire
            datAisyo.tbl[402][2] = 100; // Ice
            datAisyo.tbl[402][3] = 100; // Elec
            datAisyo.tbl[402][4] = 100; // Force
            datAisyo.tbl[402][6] = 100; // Light
            datAisyo.tbl[402][7] = 100; // Dark
            datAisyo.tbl[402][8] = 50; // Curse
            datAisyo.tbl[402][9] = 50; // Nerve
            datAisyo.tbl[402][10] = 50; // Mind
            datAisyo.tbl[402][12] = 2147483778; // Shot

            datAisyo.tbl[403][0] = 100; // Phys
            datAisyo.tbl[403][1] = 100; // Fire
            datAisyo.tbl[403][2] = 100; // Ice
            datAisyo.tbl[403][3] = 100; // Elec
            datAisyo.tbl[403][4] = 100; // Force
            datAisyo.tbl[403][6] = 100; // Light
            datAisyo.tbl[403][7] = 100; // Dark
            datAisyo.tbl[403][8] = 50; // Curse
            datAisyo.tbl[403][9] = 50; // Nerve
            datAisyo.tbl[403][10] = 50; // Mind
            datAisyo.tbl[403][12] = 2147483778; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 4; // Dark

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 4; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 4; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 6; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 6; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 5; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 5; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 4; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 4; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 6; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 6; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 18; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 18; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 202; // Toxic Spray
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 26;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 110; // Chaos Blade
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 31;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 448; // Poison Volley
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 34;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 450; // Neural Shock
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 38;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 56; // Makajamon
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 42;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 63; // Tentarafoo
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 45;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 366; // Abyssal Mask
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 48;
        }

        private static void Nirvana(ushort id)
        {
            // Affinities
            datAisyo.tbl[404][0] = 100; // Phys
            datAisyo.tbl[404][1] = 100; // Fire
            datAisyo.tbl[404][2] = 100; // Ice
            datAisyo.tbl[404][3] = 100; // Elec
            datAisyo.tbl[404][4] = 100; // Force
            datAisyo.tbl[404][6] = 65536; // Light
            datAisyo.tbl[404][7] = 2147483778; // Dark
            datAisyo.tbl[404][8] = 100; // Curse
            datAisyo.tbl[404][9] = 100; // Nerve
            datAisyo.tbl[404][10] = 100; // Mind
            datAisyo.tbl[404][12] = 100; // Shot

            datAisyo.tbl[405][0] = 100; // Phys
            datAisyo.tbl[405][1] = 100; // Fire
            datAisyo.tbl[405][2] = 100; // Ice
            datAisyo.tbl[405][3] = 100; // Elec
            datAisyo.tbl[405][4] = 100; // Force
            datAisyo.tbl[405][6] = 65536; // Light
            datAisyo.tbl[405][7] = 2147483778; // Dark
            datAisyo.tbl[405][8] = 100; // Curse
            datAisyo.tbl[405][9] = 100; // Nerve
            datAisyo.tbl[405][10] = 100; // Mind
            datAisyo.tbl[405][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 1; // Light

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 5; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 5; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 8; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 8; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 9; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 9; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 7; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 7; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 7; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 7; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 15; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 15; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 193; // Violet Flash
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 30;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 68; // Tetraja
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 34;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 188; // Punishment
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 37;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 136; // Divine Shot
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 41;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 194; // Starlight
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 46;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 49; // Recarm
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 49;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 318; // Anti-Light
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 52;
        }

        private static void Vimana(ushort id)
        {
            // Affinities
            datAisyo.tbl[406][0] = 50; // Phys
            datAisyo.tbl[406][1] = 2147483778; // Fire
            datAisyo.tbl[406][2] = 2147483778; // Ice
            datAisyo.tbl[406][3] = 100; // Elec
            datAisyo.tbl[406][4] = 100; // Force
            datAisyo.tbl[406][6] = 100; // Light
            datAisyo.tbl[406][7] = 100; // Dark
            datAisyo.tbl[406][8] = 100; // Curse
            datAisyo.tbl[406][9] = 100; // Nerve
            datAisyo.tbl[406][10] = 100; // Mind
            datAisyo.tbl[406][12] = 50; // Shot

            datAisyo.tbl[407][0] = 50; // Phys
            datAisyo.tbl[407][1] = 2147483778; // Fire
            datAisyo.tbl[407][2] = 2147483778; // Ice
            datAisyo.tbl[407][3] = 100; // Elec
            datAisyo.tbl[407][4] = 100; // Force
            datAisyo.tbl[407][6] = 100; // Light
            datAisyo.tbl[407][7] = 100; // Dark
            datAisyo.tbl[407][8] = 100; // Curse
            datAisyo.tbl[407][9] = 100; // Nerve
            datAisyo.tbl[407][10] = 100; // Mind
            datAisyo.tbl[407][12] = 50; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 0; // Neutral

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 18; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 18; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 6; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 6; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 6; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 6; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 9; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 9; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 9; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 9; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 6; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 6; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 130; // Blast Arrow
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 29;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 291; // Life Gain
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 33;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 373; // Shot Boost
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 37;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 306; // Retaliate
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 41;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 133; // Javelin Rain
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 43;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 134; // Grand Tack
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 45;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 374; // Anti-Shot
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 50;
        }

        private static void Geis(ushort id)
        {
            // Affinities
            datAisyo.tbl[408][0] = 100; // Phys
            datAisyo.tbl[408][1] = 2147483778; // Fire
            datAisyo.tbl[408][2] = 262144; // Ice
            datAisyo.tbl[408][3] = 100; // Elec
            datAisyo.tbl[408][4] = 100; // Force
            datAisyo.tbl[408][6] = 100; // Light
            datAisyo.tbl[408][7] = 100; // Dark
            datAisyo.tbl[408][8] = 100; // Curse
            datAisyo.tbl[408][9] = 100; // Nerve
            datAisyo.tbl[408][10] = 100; // Mind
            datAisyo.tbl[408][12] = 100; // Shot

            datAisyo.tbl[409][0] = 100; // Phys
            datAisyo.tbl[409][1] = 2147483778; // Fire
            datAisyo.tbl[409][2] = 262144; // Ice
            datAisyo.tbl[409][3] = 100; // Elec
            datAisyo.tbl[409][4] = 100; // Force
            datAisyo.tbl[409][6] = 100; // Light
            datAisyo.tbl[409][7] = 100; // Dark
            datAisyo.tbl[409][8] = 100; // Curse
            datAisyo.tbl[409][9] = 100; // Nerve
            datAisyo.tbl[409][10] = 100; // Mind
            datAisyo.tbl[409][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 1; // Light

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 8; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 8; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 6; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 6; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 15; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 15; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 8; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 8; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 12; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 12; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 8; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 8; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 181; // Glacial Blast
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 32;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 294; // Mana Gain
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 36;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 325; // Null Ice
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 45;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 438; // Cocytus
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 51;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 335; // Ice Drain
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 60;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 439; // Fimbulvetr
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 69;
        }

        private static void Djed(ushort id)
        {
            // Affinities
            datAisyo.tbl[410][0] = 100; // Phys
            datAisyo.tbl[410][1] = 100; // Fire
            datAisyo.tbl[410][2] = 100; // Ice
            datAisyo.tbl[410][3] = 100; // Elec
            datAisyo.tbl[410][4] = 100; // Force
            datAisyo.tbl[410][6] = 100; // Light
            datAisyo.tbl[410][7] = 100; // Dark
            datAisyo.tbl[410][8] = 65536; // Curse
            datAisyo.tbl[410][9] = 100; // Nerve
            datAisyo.tbl[410][10] = 100; // Mind
            datAisyo.tbl[410][12] = 100; // Shot

            datAisyo.tbl[411][0] = 100; // Phys
            datAisyo.tbl[411][1] = 100; // Fire
            datAisyo.tbl[411][2] = 100; // Ice
            datAisyo.tbl[411][3] = 100; // Elec
            datAisyo.tbl[411][4] = 100; // Force
            datAisyo.tbl[411][6] = 100; // Light
            datAisyo.tbl[411][7] = 100; // Dark
            datAisyo.tbl[411][8] = 65536; // Curse
            datAisyo.tbl[411][9] = 100; // Nerve
            datAisyo.tbl[411][10] = 100; // Mind
            datAisyo.tbl[411][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 0; // Neutral

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 5; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 5; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 5; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 5; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 14; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 14; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 14; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 14; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 14; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 14; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 5; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 5; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 64; // Tarukaja
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 32;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 65; // Sukukaja
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 34;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 67; // Makakaja
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 36;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 66; // Rakukaja
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 38;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 77; // Dekunda
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 44;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 206; // Debilitate
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 68;
        }

        private static void Muspell(ushort id)
        {
            // Affinities
            datAisyo.tbl[412][0] = 100; // Phys
            datAisyo.tbl[412][1] = 262144; // Fire
            datAisyo.tbl[412][2] = 2147483778; // Ice
            datAisyo.tbl[412][3] = 100; // Elec
            datAisyo.tbl[412][4] = 100; // Force
            datAisyo.tbl[412][6] = 100; // Light
            datAisyo.tbl[412][7] = 100; // Dark
            datAisyo.tbl[412][8] = 100; // Curse
            datAisyo.tbl[412][9] = 100; // Nerve
            datAisyo.tbl[412][10] = 100; // Mind
            datAisyo.tbl[412][12] = 100; // Shot

            datAisyo.tbl[413][0] = 100; // Phys
            datAisyo.tbl[413][1] = 262144; // Fire
            datAisyo.tbl[413][2] = 2147483778; // Ice
            datAisyo.tbl[413][3] = 100; // Elec
            datAisyo.tbl[413][4] = 100; // Force
            datAisyo.tbl[413][6] = 100; // Light
            datAisyo.tbl[413][7] = 100; // Dark
            datAisyo.tbl[413][8] = 100; // Curse
            datAisyo.tbl[413][9] = 100; // Nerve
            datAisyo.tbl[413][10] = 100; // Mind
            datAisyo.tbl[413][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 4; // Dark

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 8; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 8; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 16; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 16; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 12; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 12; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 6; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 6; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 7; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 7; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 14; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 14; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 177; // Hellfire
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 33;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 458; // Heat Riser
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 41;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 324; // Null Fire
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 45;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 178; // Prominence
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 49;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 334; // Fire Drain
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 58;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 161; // Magma Axis
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 66;
        }

        private static void Satan(ushort id)
        {
            // Affinities
            datAisyo.tbl[414][0] = 100; // Phys
            datAisyo.tbl[414][1] = 100; // Fire
            datAisyo.tbl[414][2] = 100; // Ice
            datAisyo.tbl[414][3] = 100; // Elec
            datAisyo.tbl[414][4] = 100; // Force
            datAisyo.tbl[414][6] = 100; // Light
            datAisyo.tbl[414][7] = 65536; // Dark
            datAisyo.tbl[414][8] = 100; // Curse
            datAisyo.tbl[414][9] = 100; // Nerve
            datAisyo.tbl[414][10] = 100; // Mind
            datAisyo.tbl[414][12] = 100; // Shot

            datAisyo.tbl[415][0] = 100; // Phys
            datAisyo.tbl[415][1] = 100; // Fire
            datAisyo.tbl[415][2] = 100; // Ice
            datAisyo.tbl[415][3] = 100; // Elec
            datAisyo.tbl[415][4] = 100; // Force
            datAisyo.tbl[415][6] = 100; // Light
            datAisyo.tbl[415][7] = 65536; // Dark
            datAisyo.tbl[415][8] = 100; // Curse
            datAisyo.tbl[415][9] = 100; // Nerve
            datAisyo.tbl[415][10] = 100; // Mind
            datAisyo.tbl[415][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 4; // Dark

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 10; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 10; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 10; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 10; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 10; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 10; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 10; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 10; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 10; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 10; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 10; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 10; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 191; // Mana Drain
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 28;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 421; // Jive Talk
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 32;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 25; // Megido
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 40;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 70; // Tetrakarn
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 44;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 69; // Makarakarn
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 46;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 131; // Deadly Fury
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 52;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 363; // Element Boost
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 60;
        }

        private static void Adama(ushort id)
        {
            // Affinities
            datAisyo.tbl[416][0] = 100; // Phys
            datAisyo.tbl[416][1] = 100; // Fire
            datAisyo.tbl[416][2] = 100; // Ice
            datAisyo.tbl[416][3] = 100; // Elec
            datAisyo.tbl[416][4] = 100; // Force
            datAisyo.tbl[416][6] = 2147483778; // Light
            datAisyo.tbl[416][7] = 2147483778; // Dark
            datAisyo.tbl[416][8] = 65536; // Curse
            datAisyo.tbl[416][9] = 65536; // Nerve
            datAisyo.tbl[416][10] = 65536; // Mind
            datAisyo.tbl[416][12] = 100; // Shot

            datAisyo.tbl[417][0] = 100; // Phys
            datAisyo.tbl[417][1] = 100; // Fire
            datAisyo.tbl[417][2] = 100; // Ice
            datAisyo.tbl[417][3] = 100; // Elec
            datAisyo.tbl[417][4] = 100; // Force
            datAisyo.tbl[417][6] = 2147483778; // Light
            datAisyo.tbl[417][7] = 2147483778; // Dark
            datAisyo.tbl[417][8] = 65536; // Curse
            datAisyo.tbl[417][9] = 5655360; // Nerve
            datAisyo.tbl[417][10] = 65536; // Mind
            datAisyo.tbl[417][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 0; // Neutral

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 6; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 6; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 7; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 7; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 17; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 17; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 7; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 7; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 6; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 6; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 21; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 21; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 332; // Null Mind
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 38;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 451; // Overload
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 42;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 331; // Null Nerve
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 44;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 330; // Null Curse
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 46;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 143; // Xeros Beat
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 54;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 249; // Wild Dance
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 60;
        }

        private static void Gehenna(ushort id)
        {
            // Affinities
            datAisyo.tbl[418][0] = 100; // Phys
            datAisyo.tbl[418][1] = 100; // Fire
            datAisyo.tbl[418][2] = 100; // Ice
            datAisyo.tbl[418][3] = 100; // Elec
            datAisyo.tbl[418][4] = 100; // Force
            datAisyo.tbl[418][6] = 100; // Light
            datAisyo.tbl[418][7] = 131072; // Dark
            datAisyo.tbl[418][8] = 100; // Curse
            datAisyo.tbl[418][9] = 100; // Nerve
            datAisyo.tbl[418][10] = 100; // Mind
            datAisyo.tbl[418][12] = 100; // Shot

            datAisyo.tbl[419][0] = 100; // Phys
            datAisyo.tbl[419][1] = 100; // Fire
            datAisyo.tbl[419][2] = 100; // Ice
            datAisyo.tbl[419][3] = 100; // Elec
            datAisyo.tbl[419][4] = 100; // Force
            datAisyo.tbl[419][6] = 100; // Light
            datAisyo.tbl[419][7] = 131072; // Dark
            datAisyo.tbl[419][8] = 100; // Curse
            datAisyo.tbl[419][9] = 100; // Nerve
            datAisyo.tbl[419][10] = 100; // Mind
            datAisyo.tbl[419][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 4; // Dark

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 2; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 2; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 21; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 21; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 9; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 9; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 13; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 13; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 10; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 10; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 10; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 10; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 35; // Mamudoon
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 44;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 192; // Life Drain
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 48;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 447; // Millennia Curse
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 54;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 432; // Gate of Hell
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 60;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 329; // Null Dark
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 64;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 478; // Oblivion
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 70;
        }

        private static void Sophia(ushort id)
        {
            // Affinities
            datAisyo.tbl[420][0] = 100; // Phys
            datAisyo.tbl[420][1] = 100; // Fire
            datAisyo.tbl[420][2] = 100; // Ice
            datAisyo.tbl[420][3] = 100; // Elec
            datAisyo.tbl[420][4] = 100; // Force
            datAisyo.tbl[420][6] = 100; // Light
            datAisyo.tbl[420][7] = 100; // Dark
            datAisyo.tbl[420][8] = 100; // Curse
            datAisyo.tbl[420][9] = 65536; // Nerve
            datAisyo.tbl[420][10] = 100; // Mind
            datAisyo.tbl[420][12] = 100; // Shot

            datAisyo.tbl[421][0] = 100; // Phys
            datAisyo.tbl[421][1] = 100; // Fire
            datAisyo.tbl[421][2] = 100; // Ice
            datAisyo.tbl[421][3] = 100; // Elec
            datAisyo.tbl[421][4] = 100; // Force
            datAisyo.tbl[421][6] = 100; // Light
            datAisyo.tbl[421][7] = 100; // Dark
            datAisyo.tbl[421][8] = 100; // Curse
            datAisyo.tbl[421][9] = 65536; // Nerve
            datAisyo.tbl[421][10] = 100; // Mind
            datAisyo.tbl[421][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 1; // Light

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 2; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 2; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 7; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 7; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 13; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 13; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 11; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 11; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 17; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 17; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 17; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 17; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 38; // Diarahan
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 41;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 302; // Drain Attack
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 45;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 40; // Mediarama
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 49;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 292; // Life Surge
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 56;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 50; // Samarecarm
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 60;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 479; // Liberation
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 68;
        }

        private static void Murakumo(ushort id)
        {
            // Affinities
            datAisyo.tbl[422][0] = 100; // Phys
            datAisyo.tbl[422][1] = 100; // Fire
            datAisyo.tbl[422][2] = 100; // Ice
            datAisyo.tbl[422][3] = 2147483778; // Elec
            datAisyo.tbl[422][4] = 131072; // Force
            datAisyo.tbl[422][6] = 100; // Light
            datAisyo.tbl[422][7] = 100; // Dark
            datAisyo.tbl[422][8] = 100; // Curse
            datAisyo.tbl[422][9] = 100; // Nerve
            datAisyo.tbl[422][10] = 100; // Mind
            datAisyo.tbl[422][12] = 100; // Shot

            datAisyo.tbl[423][0] = 100; // Phys
            datAisyo.tbl[423][1] = 100; // Fire
            datAisyo.tbl[423][2] = 100; // Ice
            datAisyo.tbl[423][3] = 2147483778; // Elec
            datAisyo.tbl[423][4] = 131072; // Force
            datAisyo.tbl[423][6] = 100; // Light
            datAisyo.tbl[423][7] = 100; // Dark
            datAisyo.tbl[423][8] = 100; // Curse
            datAisyo.tbl[423][9] = 100; // Nerve
            datAisyo.tbl[423][10] = 100; // Mind
            datAisyo.tbl[423][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 0; // Neutral

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 16; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 16; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 15; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 15; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 13; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 13; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 12; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 12; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 4; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 4; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 5; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 5; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 472; // Kusanagi
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 45;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 345; // Endure
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 50;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 444; // Heavenly Cyclone
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 52;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 327; // Null Force
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 54;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 186; // Wind Cutter
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 64;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 337; // Force Drain
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 66;
        }

        private static void Gundari(ushort id)
        {
            // Affinities
            datAisyo.tbl[424][0] = 100; // Phys
            datAisyo.tbl[424][1] = 100; // Fire
            datAisyo.tbl[424][2] = 100; // Ice
            datAisyo.tbl[424][3] = 100; // Elec
            datAisyo.tbl[424][4] = 100; // Force
            datAisyo.tbl[424][6] = 131072; // Light
            datAisyo.tbl[424][7] = 100; // Dark
            datAisyo.tbl[424][8] = 100; // Curse
            datAisyo.tbl[424][9] = 100; // Nerve
            datAisyo.tbl[424][10] = 100; // Mind
            datAisyo.tbl[424][12] = 100; // Shot

            datAisyo.tbl[425][0] = 100; // Phys
            datAisyo.tbl[425][1] = 100; // Fire
            datAisyo.tbl[425][2] = 100; // Ice
            datAisyo.tbl[425][3] = 100; // Elec
            datAisyo.tbl[425][4] = 100; // Force
            datAisyo.tbl[425][6] = 131072; // Light
            datAisyo.tbl[425][7] = 100; // Dark
            datAisyo.tbl[425][8] = 100; // Curse
            datAisyo.tbl[425][9] = 100; // Nerve
            datAisyo.tbl[425][10] = 100; // Mind
            datAisyo.tbl[425][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 1; // Light

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 12; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 12; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 14; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 14; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 12; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 12; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 10; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 10; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 24; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 24; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 8; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 8; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 189; // Judgement Light
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 52;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 295; // Mana Surge
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 58;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 26; // Megidola
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 62;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 476; // Smite
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 64;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 328; // Null Light
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 66;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 195; // Radiance
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 72;
        }

        private static void Narukami(ushort id)
        {
            // Affinities
            datAisyo.tbl[426][0] = 100; // Phys
            datAisyo.tbl[426][1] = 100; // Fire
            datAisyo.tbl[426][2] = 100; // Ice
            datAisyo.tbl[426][3] = 131072; // Elec
            datAisyo.tbl[426][4] = 2147483778; // Force
            datAisyo.tbl[426][6] = 100; // Light
            datAisyo.tbl[426][7] = 100; // Dark
            datAisyo.tbl[426][8] = 100; // Curse
            datAisyo.tbl[426][9] = 100; // Nerve
            datAisyo.tbl[426][10] = 100; // Mind
            datAisyo.tbl[426][12] = 100; // Shot

            datAisyo.tbl[427][0] = 100; // Phys
            datAisyo.tbl[427][1] = 100; // Fire
            datAisyo.tbl[427][2] = 100; // Ice
            datAisyo.tbl[427][3] = 131072; // Elec
            datAisyo.tbl[427][4] = 2147483778; // Force
            datAisyo.tbl[427][6] = 100; // Light
            datAisyo.tbl[427][7] = 100; // Dark
            datAisyo.tbl[427][8] = 100; // Curse
            datAisyo.tbl[427][9] = 100; // Nerve
            datAisyo.tbl[427][10] = 100; // Mind
            datAisyo.tbl[427][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 1; // Light

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 11; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 11; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 17; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 17; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 11; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 11; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 22; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 22; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 10; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 10; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 9; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 9; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 183; // Bolt Storm
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 41;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 370; // Qigong
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 53;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 441; // Thunder Gods
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 58;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 326; // Null Elec
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 61;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 442; // Thunder Reign
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 67;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 336; // Elec Drain
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 71;
        }

        private static void Gaea(ushort id)
        {
            // Affinities
            datAisyo.tbl[428][0] = 50; // Phys
            datAisyo.tbl[428][1] = 100; // Fire
            datAisyo.tbl[428][2] = 100; // Ice
            datAisyo.tbl[428][3] = 2147483778; // Elec
            datAisyo.tbl[428][4] = 2147483778; // Force
            datAisyo.tbl[428][6] = 100; // Light
            datAisyo.tbl[428][7] = 100; // Dark
            datAisyo.tbl[428][8] = 100; // Curse
            datAisyo.tbl[428][9] = 100; // Nerve
            datAisyo.tbl[428][10] = 100; // Mind
            datAisyo.tbl[428][12] = 50; // Shot

            datAisyo.tbl[429][0] = 50; // Phys
            datAisyo.tbl[429][1] = 100; // Fire
            datAisyo.tbl[429][2] = 100; // Ice
            datAisyo.tbl[429][3] = 2147483778; // Elec
            datAisyo.tbl[429][4] = 2147483778; // Force
            datAisyo.tbl[429][6] = 100; // Light
            datAisyo.tbl[429][7] = 100; // Dark
            datAisyo.tbl[429][8] = 100; // Curse
            datAisyo.tbl[429][9] = 100; // Nerve
            datAisyo.tbl[429][10] = 100; // Mind
            datAisyo.tbl[429][12] = 50; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 4; // Dark

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 24; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 24; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 0; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 0; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 0; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 0; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 24; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 24; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 11; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 11; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 13; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 13; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 126; // Iron Claw
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 47;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 313; // Anti-Phys
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 53;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 307; // Avenge
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 59;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 375; // Null Shot
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 61;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 160; // Spiral Viper
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 67;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 163; // Gaea Rage
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 74;
        }

        private static void Kailash(ushort id)
        {
            // Affinities
            datAisyo.tbl[430][0] = 100; // Phys
            datAisyo.tbl[430][1] = 100; // Fire
            datAisyo.tbl[430][2] = 100; // Ice
            datAisyo.tbl[430][3] = 100; // Elec
            datAisyo.tbl[430][4] = 100; // Force
            datAisyo.tbl[430][6] = 50; // Light
            datAisyo.tbl[430][7] = 50; // Dark
            datAisyo.tbl[430][8] = 100; // Curse
            datAisyo.tbl[430][9] = 100; // Nerve
            datAisyo.tbl[430][10] = 100; // Mind
            datAisyo.tbl[430][12] = 100; // Shot

            datAisyo.tbl[431][0] = 100; // Phys
            datAisyo.tbl[431][1] = 100; // Fire
            datAisyo.tbl[431][2] = 100; // Ice
            datAisyo.tbl[431][3] = 100; // Elec
            datAisyo.tbl[431][4] = 100; // Force
            datAisyo.tbl[431][6] = 50; // Light
            datAisyo.tbl[431][7] = 50; // Dark
            datAisyo.tbl[431][8] = 100; // Curse
            datAisyo.tbl[431][9] = 100; // Nerve
            datAisyo.tbl[431][10] = 100; // Mind
            datAisyo.tbl[431][12] = 100; // Shot

            // Alignment
            tblHearts.fclHeartsTbl[id].Flag = 0; // Neutral

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 21; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 21; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 21; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 21; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 13; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 13; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 13; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 13; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 10; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 10; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 10; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 10; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 27; // Megidolaon
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 70;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 348; // Victory Cry
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 72;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 454; // Last Word
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 74;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 147; // Freikugel
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 75;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 364; // Anti-Elements
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 78;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 453; // Antichthon
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 80;
        }

        private static void Masakados(ushort id)
        {
            // Affinities
            datAisyo.tbl[432][0] = 50; // Phys
            datAisyo.tbl[432][1] = 50; // Fire
            datAisyo.tbl[432][2] = 50; // Ice
            datAisyo.tbl[432][3] = 50; // Elec
            datAisyo.tbl[432][4] = 50; // Force
            datAisyo.tbl[432][6] = 50; // Light
            datAisyo.tbl[432][7] = 50; // Dark
            datAisyo.tbl[432][8] = 50; // Curse
            datAisyo.tbl[432][9] = 50; // Nerve
            datAisyo.tbl[432][10] = 50; // Mind
            datAisyo.tbl[432][12] = 50; // Shot

            datAisyo.tbl[433][0] = 50; // Phys
            datAisyo.tbl[433][1] = 50; // Fire
            datAisyo.tbl[433][2] = 50; // Ice
            datAisyo.tbl[433][3] = 50; // Elec
            datAisyo.tbl[433][4] = 50; // Force
            datAisyo.tbl[433][6] = 50; // Light
            datAisyo.tbl[433][7] = 50; // Dark
            datAisyo.tbl[433][8] = 50; // Curse
            datAisyo.tbl[433][9] = 50; // Nerve
            datAisyo.tbl[433][10] = 50; // Mind
            datAisyo.tbl[433][12] = 50; // Shot

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0]       = 24; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 24; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[1]       = 24; // Intelligence
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[1] = 24; // Intelligence
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2]       = 24; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 24; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3]       = 24; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 24; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4]       = 24; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 24; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5]       = 24; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 24; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 357; // Pierce
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 1;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 339; // Fire Repel
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 1;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 340; // Ice Repel
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 1;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 341; // Elec Repel
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 1;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 342; // Force Repel
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 1;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 338; // Phys Repel
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 1;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 377; // Shot Repel
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 1;
        }
    }
}
