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
        [HarmonyPatch(typeof(datHeartsName), nameof(datHeartsName.Get))]
        private class HeartsNamePatch
        {
            public static bool Prefix(ref int id, ref string __result)
            {
                switch (id)
                {
                    case 01: __result = "Marogareh"; return false;
                    case 02: __result = "Wadatsumi"; return false;
                    case 03: __result = "Ankh"; return false;
                    case 04: __result = "Iyomante"; return false;
                    case 05: __result = "Shiranui"; return false;
                    case 06: __result = "Hifumi"; return false;
                    case 07: __result = "Kamudo"; return false;
                    case 08: __result = "Narukami"; return false;
                    case 09: __result = "Anathema"; return false;
                    case 10: __result = "Miasma"; return false;
                    case 11: __result = "Nirvana"; return false;
                    case 12: __result = "Murakumo"; return false;
                    case 13: __result = "Geis"; return false;
                    case 14: __result = "Djed"; return false;
                    case 15: __result = "Muspell"; return false;
                    case 16: __result = "Gehenna"; return false;
                    case 17: __result = "Kamurogi"; return false;
                    case 18: __result = "Satan"; return false;
                    case 19: __result = "Adama"; return false;
                    case 20: __result = "Vimana"; return false;
                    case 21: __result = "Gundari"; return false;
                    case 22: __result = "Sophia"; return false;
                    case 23: __result = "Gaea"; return false;
                    case 24: __result = "Kailash"; return false;
                    case 25: __result = "Masakados"; return false;
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
                    case "<SPD 7><F025_L0260><WAIT>": __result = "<SP7>> You obtained the Magatama <CO2>" + datHeartsName.Get(18) + "<CO0>. <WA>"; break; // After Black Frost
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
                //foreach (var icon in cmpDrawDH.GBWK.HeartsIcon)
                //{
                //    icon.IconColor = 2;
                //}
                //MelonLogger.Msg(JsonConvert.SerializeObject(cmpDrawDH.GBWK.HeartsIcon));
            }
        }

        private static void ApplyMagatamaChanges()
        {
            //foreach (var heart in tblHearts.fclHeartsTbl)
            //    heart.Flag = 4;

            Marogareh(1);
            Wadatsumi(2);
            Ankh(3);
            Iyomante(4);
            Shiranui(5);
            Hifumi(6);
            Kamudo(7);
            Narukami(8);
            Anathema(9);
            Miasma(10);
            Nirvana(11);
            Murakumo(12);
            Geis(13);
            Djed(14);
            Muspell(15);
            Gehenna(16);
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
            //tblHearts.fclHeartsTbl[id].Skill[6].ID = 301; // Dark Might
            //tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 18;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 425; // "Pierce"
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 15;
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
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 180; // Ice Breath
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 7;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 293; // Mana Bonus
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 11;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 310; // Ice Boost
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 15;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 204; // Fog Breath
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 19;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 437; // Refrigerate
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 21;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 315; // Anti-Ice
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
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 36; // Dia
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 5;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 290; // Life Bonus
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 6;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 43; // Patra
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 8;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 296; // Fast Retreat
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 12;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 39; // Media
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 16;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 346; // Life Aid
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
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 52; // Tarunda
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 8;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 53; // Sukunda
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 12;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 54; // Rakunda
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 16;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 300; // Bright Might
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 18;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 298; // Mind's Eye
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 23;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 57; // Dekaja
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
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 176; // Fire Breath
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 8;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 309; // Fire Boost
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 14;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 101; // Heat Wave
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 16;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 435; // Scald
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 18;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 205; // Taunt
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 21;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 314; // Anti-Fire
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
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 461; // Storm Gale
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 10;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 312; // Force Boost
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 18;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 203; // War Cry
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 24;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 317; // Anti-Force
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 26;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 185; // Tornado
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 30;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 327; // Null Force
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
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 430; // Chi Blast
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 18;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 224; // Focus
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 21;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 99; // Tempest
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 24;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 97; // Hell Thrust
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 27;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 299; // Might
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 30;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 345; // Endure
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
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 182; // Shock
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 14;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 125; // Stun Claw
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 18;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 311; // Elec Boost
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 20;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 316; // Anti-Elec
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 30;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 469; // Mjolnir
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 44;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 326; // Null Elec
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 46;
        }

        private static void Anathema(ushort id)
        {
            // Affinities
            datAisyo.tbl[400][0] = 100; // Phys
            datAisyo.tbl[400][1] = 100; // Fire
            datAisyo.tbl[400][2] = 100; // Ice
            datAisyo.tbl[400][3] = 100; // Elec
            datAisyo.tbl[400][4] = 100; // Force
            datAisyo.tbl[400][6] = 2147483798; // Light
            datAisyo.tbl[400][7] = 65536; // Dark
            datAisyo.tbl[400][8] = 100; // Curse
            datAisyo.tbl[400][9] = 100; // Nerve
            datAisyo.tbl[400][10] = 100; // Mind

            datAisyo.tbl[401][0] = 100; // Phys
            datAisyo.tbl[401][1] = 100; // Fire
            datAisyo.tbl[401][2] = 100; // Ice
            datAisyo.tbl[401][3] = 100; // Elec
            datAisyo.tbl[401][4] = 100; // Force
            datAisyo.tbl[401][6] = 2147483798; // Light
            datAisyo.tbl[401][7] = 65536; // Dark
            datAisyo.tbl[401][8] = 100; // Curse
            datAisyo.tbl[401][9] = 100; // Nerve
            datAisyo.tbl[401][10] = 100; // Mind

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4] = 2; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 2; // Agility

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 191; // Mana Drain
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 24;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 424; // Concentrate
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 27;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 34; // Mamudo
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 30;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 319; // Anti-Dark
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 34;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 197; // Stone Gaze
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 38;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 35; // Mamudoon
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 44;
        }

        private static void Miasma(ushort id)
        {
            // Affinities
            datAisyo.tbl[402][0] = 100; // Phys
            datAisyo.tbl[402][1] = 2147483798; // Fire
            datAisyo.tbl[402][2] = 65536; // Ice
            datAisyo.tbl[402][3] = 100; // Elec
            datAisyo.tbl[402][4] = 100; // Force
            datAisyo.tbl[402][6] = 100; // Light
            datAisyo.tbl[402][7] = 100; // Dark
            datAisyo.tbl[402][8] = 100; // Curse
            datAisyo.tbl[402][9] = 100; // Nerve
            datAisyo.tbl[402][10] = 100; // Mind

            datAisyo.tbl[403][0] = 100; // Phys
            datAisyo.tbl[403][1] = 2147483798; // Fire
            datAisyo.tbl[403][2] = 65536; // Ice
            datAisyo.tbl[403][3] = 100; // Elec
            datAisyo.tbl[403][4] = 100; // Force
            datAisyo.tbl[403][6] = 100; // Light
            datAisyo.tbl[403][7] = 100; // Dark
            datAisyo.tbl[403][8] = 100; // Curse
            datAisyo.tbl[403][9] = 100; // Nerve
            datAisyo.tbl[403][10] = 100; // Mind

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2] = 2; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 2; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4] = 6; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 6; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5] = 4; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 4; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 448; // Poison Volley
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 28;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 110; // Chaos Blade
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 34;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 181; // Glacial Blast
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 36;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 450; // Neural Shock
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 38;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 325; // Null Ice
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 42;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 63; // Tentarafoo
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 45;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 335; // Ice Drain
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 54;
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
            datAisyo.tbl[404][7] = 2147483798; // Dark
            datAisyo.tbl[404][8] = 100; // Curse
            datAisyo.tbl[404][9] = 100; // Nerve
            datAisyo.tbl[404][10] = 100; // Mind

            datAisyo.tbl[405][0] = 100; // Phys
            datAisyo.tbl[405][1] = 100; // Fire
            datAisyo.tbl[405][2] = 100; // Ice
            datAisyo.tbl[405][3] = 100; // Elec
            datAisyo.tbl[405][4] = 100; // Force
            datAisyo.tbl[405][6] = 65536; // Light
            datAisyo.tbl[405][7] = 2147483798; // Dark
            datAisyo.tbl[405][8] = 100; // Curse
            datAisyo.tbl[405][9] = 100; // Nerve
            datAisyo.tbl[405][10] = 100; // Mind

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3] = 3; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 3; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4] = 3; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 3; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5] = 8; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 8; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 193; // Violet Flash
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 30;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 318; // Anti-Light
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 33;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 188; // Punishment
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 37;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 136; // Divine Shot
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 41;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 194; // Starlight
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 46;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 328; // Null Light
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 51;
        }

        private static void Murakumo(ushort id)
        {
            // Affinities
            datAisyo.tbl[406][0] = 50; // Phys
            datAisyo.tbl[406][1] = 2147483798; // Fire
            datAisyo.tbl[406][2] = 2147483798; // Ice
            datAisyo.tbl[406][3] = 100; // Elec
            datAisyo.tbl[406][4] = 100; // Force
            datAisyo.tbl[406][6] = 100; // Light
            datAisyo.tbl[406][7] = 100; // Dark
            datAisyo.tbl[406][8] = 100; // Curse
            datAisyo.tbl[406][9] = 100; // Nerve
            datAisyo.tbl[406][10] = 100; // Mind

            datAisyo.tbl[407][0] = 50; // Phys
            datAisyo.tbl[407][1] = 2147483798; // Fire
            datAisyo.tbl[407][2] = 2147483798; // Ice
            datAisyo.tbl[407][3] = 100; // Elec
            datAisyo.tbl[407][4] = 100; // Force
            datAisyo.tbl[407][6] = 100; // Light
            datAisyo.tbl[407][7] = 100; // Dark
            datAisyo.tbl[407][8] = 100; // Curse
            datAisyo.tbl[407][9] = 100; // Nerve
            datAisyo.tbl[407][10] = 100; // Mind

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0] = 6; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 6; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2] = 6; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 6; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3] = 3; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 3; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4] = 3; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 3; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5] = 1; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 1; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 102; // Blight
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 33;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 332; // Null Mind
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 35;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 144; // Oni Kagura
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 37;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 331; // Null Nerve
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 40;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 472; // Kusanagi
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 44;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 330; // Null Curse
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 45;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 366; // Abyssal Mask
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 54;
        }

        private static void Geis(ushort id)
        {
            // Affinities
            datAisyo.tbl[408][0] = 100; // Phys
            datAisyo.tbl[408][1] = 100; // Fire
            datAisyo.tbl[408][2] = 100; // Ice
            datAisyo.tbl[408][3] = 100; // Elec
            datAisyo.tbl[408][4] = 100; // Force
            datAisyo.tbl[408][6] = 65536; // Light
            datAisyo.tbl[408][7] = 100; // Dark
            datAisyo.tbl[408][8] = 100; // Curse
            datAisyo.tbl[408][9] = 100; // Nerve
            datAisyo.tbl[408][10] = 100; // Mind

            datAisyo.tbl[409][0] = 100; // Phys
            datAisyo.tbl[409][1] = 100; // Fire
            datAisyo.tbl[409][2] = 100; // Ice
            datAisyo.tbl[409][3] = 100; // Elec
            datAisyo.tbl[409][4] = 100; // Force
            datAisyo.tbl[409][6] = 65536; // Light
            datAisyo.tbl[409][7] = 100; // Dark
            datAisyo.tbl[409][8] = 100; // Curse
            datAisyo.tbl[409][9] = 100; // Nerve
            datAisyo.tbl[409][10] = 100; // Mind

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3] = 6; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 6; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4] = 3; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 3; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5] = 3; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 3; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 37; // Diarama
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 32;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 349; // Life Refill
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 36;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 68; // Tetraja
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 40;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 456; // Amrita
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 42;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 40; // Mediarama
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 44;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 38; // Diarahan
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 56;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 350; // Mana Refill
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 60;
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
            datAisyo.tbl[410][8] = 50; // Curse
            datAisyo.tbl[410][9] = 50; // Nerve
            datAisyo.tbl[410][10] = 50; // Mind

            datAisyo.tbl[411][0] = 100; // Phys
            datAisyo.tbl[411][1] = 100; // Fire
            datAisyo.tbl[411][2] = 100; // Ice
            datAisyo.tbl[411][3] = 100; // Elec
            datAisyo.tbl[411][4] = 100; // Force
            datAisyo.tbl[411][6] = 100; // Light
            datAisyo.tbl[411][7] = 100; // Dark
            datAisyo.tbl[411][8] = 50; // Curse
            datAisyo.tbl[411][9] = 50; // Nerve
            datAisyo.tbl[411][10] = 50; // Mind

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0] = 5; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 5; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2] = 2; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 2; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3] = 5; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 5; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4] = 2; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 2; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5] = 5; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 5; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 64; // Tarukaja
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 32;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 65; // Sukukaja
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 35;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 67; // Makakaja
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 38;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 66; // Rakukaja
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 41;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 77; // Dekunda
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 46;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 25; // Megido
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 60;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 206; // Debilitate
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 72;
        }

        private static void Muspell(ushort id)
        {
            // Affinities
            datAisyo.tbl[412][0] = 100; // Phys
            datAisyo.tbl[412][1] = 100; // Fire
            datAisyo.tbl[412][2] = 100; // Ice
            datAisyo.tbl[412][3] = 100; // Elec
            datAisyo.tbl[412][4] = 100; // Force
            datAisyo.tbl[412][6] = 50; // Light
            datAisyo.tbl[412][7] = 50; // Dark
            datAisyo.tbl[412][8] = 100; // Curse
            datAisyo.tbl[412][9] = 100; // Nerve
            datAisyo.tbl[412][10] = 100; // Mind

            datAisyo.tbl[413][0] = 100; // Phys
            datAisyo.tbl[413][1] = 100; // Fire
            datAisyo.tbl[413][2] = 100; // Ice
            datAisyo.tbl[413][3] = 100; // Elec
            datAisyo.tbl[413][4] = 100; // Force
            datAisyo.tbl[413][6] = 50; // Light
            datAisyo.tbl[413][7] = 50; // Dark
            datAisyo.tbl[413][8] = 100; // Curse
            datAisyo.tbl[413][9] = 100; // Nerve
            datAisyo.tbl[413][10] = 100; // Mind

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3] = 6; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 6; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5] = 3; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 3; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 56; // Makajamon
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 36;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 199; // Evil Gaze
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 40;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 294; // Mana Gain
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 43;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 449; // Poison Salvo
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 46;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 249; // Wild Dance
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 49;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 451; // Overload
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 52;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 133; // Javelin Rain
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 56;
        }

        private static void Gehenna(ushort id)
        {
            // Affinities
            datAisyo.tbl[414][0] = 100; // Phys
            datAisyo.tbl[414][1] = 262144; // Fire
            datAisyo.tbl[414][2] = 2147483798; // Ice
            datAisyo.tbl[414][3] = 100; // Elec
            datAisyo.tbl[414][4] = 100; // Force
            datAisyo.tbl[414][6] = 100; // Light
            datAisyo.tbl[414][7] = 100; // Dark
            datAisyo.tbl[414][8] = 100; // Curse
            datAisyo.tbl[414][9] = 100; // Nerve
            datAisyo.tbl[414][10] = 100; // Mind

            datAisyo.tbl[415][0] = 100; // Phys
            datAisyo.tbl[415][1] = 262144; // Fire
            datAisyo.tbl[415][2] = 2147483798; // Ice
            datAisyo.tbl[415][3] = 100; // Elec
            datAisyo.tbl[415][4] = 100; // Force
            datAisyo.tbl[415][6] = 100; // Light
            datAisyo.tbl[415][7] = 100; // Dark
            datAisyo.tbl[415][8] = 100; // Curse
            datAisyo.tbl[415][9] = 100; // Nerve
            datAisyo.tbl[415][10] = 100; // Mind

            // Stats
            tblHearts.fclHeartsTbl[id].GrowParamTbl[0] = 5; // Strength
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[0] = 5; // Strength
            tblHearts.fclHeartsTbl[id].GrowParamTbl[2] = 5; // Magic
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[2] = 5; // Magic
            tblHearts.fclHeartsTbl[id].GrowParamTbl[3] = 1; // Vitality
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[3] = 1; // Vitality
            tblHearts.fclHeartsTbl[id].GrowParamTbl[4] = 9; // Agility
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[4] = 9; // Agility
            tblHearts.fclHeartsTbl[id].GrowParamTbl[5] = 1; // Luck
            tblHearts.fclHeartsTbl[id].MasterGrowParamTbl[5] = 1; // Luck

            // Skills
            tblHearts.fclHeartsTbl[id].Skill[0].ID = 177; // Hellfire
            tblHearts.fclHeartsTbl[id].Skill[0].TargetLevel = 33;
            tblHearts.fclHeartsTbl[id].Skill[1].ID = 446; // Damnation
            tblHearts.fclHeartsTbl[id].Skill[1].TargetLevel = 36;
            tblHearts.fclHeartsTbl[id].Skill[2].ID = 324; // Null Fire
            tblHearts.fclHeartsTbl[id].Skill[2].TargetLevel = 42;
            tblHearts.fclHeartsTbl[id].Skill[3].ID = 178; // Prominence
            tblHearts.fclHeartsTbl[id].Skill[3].TargetLevel = 50;
            tblHearts.fclHeartsTbl[id].Skill[4].ID = 334; // Fire Drain
            tblHearts.fclHeartsTbl[id].Skill[4].TargetLevel = 55;
            tblHearts.fclHeartsTbl[id].Skill[5].ID = 432; // Gate of Hell
            tblHearts.fclHeartsTbl[id].Skill[5].TargetLevel = 60;
            tblHearts.fclHeartsTbl[id].Skill[6].ID = 161; // Magma Axis
            tblHearts.fclHeartsTbl[id].Skill[6].TargetLevel = 65;
        }
    }
}
