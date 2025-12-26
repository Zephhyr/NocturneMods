using HarmonyLib;
using Il2Cpp;
using Il2Cppeffect_H;
using Il2Cppfacility_H;
using Il2Cppmodel_H;
using Il2Cppnewbattle_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2CppTMPro;
using MelonLoader;
using Newtonsoft.Json;
using System.Linq;
using System.Xml;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        public static ushort[] bossList = new ushort[] {
            162, 163, 164, 165, 166, 244, 245, 246, 248, 249, 251, 252, 254, 256, 257, 258, 259, 262, 263, 264, 266, 267, 268, 269, 270, 271, 272, 273, 274, 275, 276, 277, 278, 279,
            280, 281, 282, 283, 284, 285, 286, 287, 288, 289, 290, 291, 292, 293, 294, 295, 296, 297, 298, 299, 300, 301, 302, 303, 304, 305, 306, 307, 308, 309, 312, 313, 320, 321,
            322, 323, 324, 325, 326, 327, 328, 329, 333, 334, 335, 337, 339, 340, 341, 342, 343, 344, 345, 346, 347, 348, 349, 350, 351, 352, 353, 362, 363, 364, 365, 366
        };
        public static ushort[] pushedSkillList = new ushort[] { 142, 148, 149, 150, 151, 164, 165, 166, 167, 234, 403, 407, 408, 416, 417, 496 };

        //public static List<nbActionProcess.SOBED> newSobed = new List<nbActionProcess.SOBED>();

        public static ushort previousUnitId;
        public static short previousSingleTargetFormIndex = -1;
        public static ushort[] activeUnitIds = new ushort[16];
        public static short[][] activeUnitPartyCount = new short[16][];

        public static nbActionProcessData_t? actionProcessData;

        public static string switchOutSkillName = "";
        public static string switchOutSkillName2 = "";
        public static string postSummonSkillName = "";

        [HarmonyPatch(typeof(datSkillName), nameof(datSkillName.Get))]
        private class SkillNamesPatch
        {
            public static bool Prefix(ref int id, ref string __result)
            {
                // Decarabia's Kept Waiting
                try
                {
                    if (id == 150 && (actionProcessData.work.id == 70 &&
                                ((actionProcessData.partyindex <= 3 && nbMainProcess.nbGetMainProcessData().party.Any(x => x.partyindex <= 3 && nbMainProcess.nbGetUnitWorkFromFormindex(x.formindex).id == 74)) ||
                                (actionProcessData.partyindex > 3 && nbMainProcess.nbGetMainProcessData().party.Any(x => x.partyindex > 3 && nbMainProcess.nbGetUnitWorkFromFormindex(x.formindex).id == 74)))))
                    {
                        __result = "Kept Waiting";
                        return false;
                    }
                } catch { }
                

                switch (id)
                {            
                    // Vanilla Skills
                    case 60: __result = "Lullaby"; return false;
                    case 80: __result = "Muscle Drink"; return false;
                    case 81: __result = "Life Stone"; return false;
                    case 82: __result = "Chakra Drop"; return false;
                    case 83: __result = "Chakra Pot"; return false;
                    case 84: __result = "Great Chakra"; return false;
                    case 85: __result = "Soma Droplet"; return false;
                    case 86: __result = "Soma"; return false;
                    case 90: __result = "Poison Arrow"; return false;
                    case 92: __result = "Bead of Life"; return false;
                    case 94: __result = "Medicine"; return false;
                    case 113: __result = "Venom Needle"; return false;
                    case 133: __result = "Javelin Rain"; return false;
                    case 143: __result = "Xeros Beat"; return false;
                    case 169: __result = "Decimate"; return false;
                    case 170: __result = "Decimate"; return false;
                    case 172: __result = "Sear"; return false;
                    case 173: __result = "Sear"; return false;
                    case 174: __result = "Crush"; return false;
                    case 175: __result = "Repulse"; return false;
                    case 179: __result = "Trisagion"; return false;
                    case 202: __result = "Toxic Spray"; return false;
                    case 210: __result = "Dormina"; return false;
                    case 219: __result = "Rage"; return false;
                    case 220: __result = "Psycho Rage"; return false;
                    case 243: __result = "Hell's Forfeit"; return false;
                    case 252: __result = "Foul Gathering"; return false;
                    case 254: __result = "Omnipotence"; return false;
                    case 270: __result = "Dark Matter"; return false;
                    case 285: __result = "Babylon Goblet"; return false;
                    case 286: __result = "Death Lust"; return false;
                    case 413: __result = "Silver Tongue"; return false;
                    case 415: __result = "Entice"; return false;

                        // High King = "King of Kings"
                        // Root of Evil = "In the beginning, there was darkness"

                    // New Skills
                    case 128: __result = "Rapid Needle"; return false;
                    case 129: __result = "Tathlum Shot"; return false;
                    case 130: __result = "Blast Arrow"; return false;
                    case 134: __result = "Grand Tack"; return false;
                    case 135: __result = "Heaven's Bow"; return false;
                    case 141: __result = "Riot Gun"; return false;
                    case 142: __result = "Silencing Bellow"; return false;
                    case 148: __result = "Renewal"; return false;
                    case 149: __result = "Spirit Well"; return false;
                    case 150: __result = "Qigong"; return false;
                    case 151: __result = "Renewal & Spirit Well"; return false;
                    case 167: __result = "Double Attack"; return false;
                    case 188: __result = "Punishment"; return false;
                    case 189: __result = "Judgement Light"; return false;

                    case 308: __result = "Double Attack"; return false;
                    case 360: __result = "Never Yield"; return false;      
                    case 362: __result = "Phys Boost"; return false;
                    case 363: __result = "Element Boost"; return false;
                    case 364: __result = "Anti-Elements"; return false;
                    case 365: __result = "Anti-Ailments"; return false;
                    case 366: __result = "Abyssal Mask"; return false;
                    case 367: __result = "Knowledge of Tools"; return false;
                    case 368: __result = "Renewal"; return false;
                    case 369: __result = "Spirit Well"; return false;
                    case 370: __result = "Qigong"; return false;
                    case 371: __result = "Arms Master"; return false;
                    case 372: __result = "Firm Stance"; return false;
                    case 373: __result = "Shot Boost"; return false;
                    case 374: __result = "Anti-Shot"; return false;
                    case 375: __result = "Null: Shot"; return false;
                    case 376: __result = "Shot Drain"; return false;
                    case 377: __result = "Shot Repel"; return false;
                    case 378: __result = "Solitary Drift"; return false;
                    case 379: __result = "Pierce"; return false;

                    case 403: __result = "Estocada"; return false;
                    case 404: __result = "Nation Founder"; return false;
                    case 405: __result = "Retributive Zeal"; return false;
                    case 406: __result = switchOutSkillName2; return false;
                    case 407: __result = switchOutSkillName; return false;
                    case 408: __result = postSummonSkillName; return false;
                    case 416: __result = "Ramayana"; return false;
                    case 417: __result = "Evil Mirror"; return false;

                    case 422: __result = "Beast Eye"; return false;      
                    case 423: __result = "Dragon Eye"; return false;     
                    case 424: __result = "Concentrate"; return false;
                    case 425: __result = "Impaler's Animus"; return false;
                    case 426: __result = "Sakura Rage"; return false;
                    case 427: __result = "Fang Breaker"; return false;
                    case 428: __result = "Defense Kuzushi"; return false;
                    case 429: __result = "Primal Force"; return false;
                    case 430: __result = "Chi Blast"; return false;
                    case 431: __result = "Revelation"; return false;
                    case 432: __result = "Gate of Hell"; return false;
                    case 433: __result = "Akashic Arts"; return false;
                    case 434: __result = "Bloodbath"; return false;
                    case 435: __result = "Scald"; return false;
                    case 436: __result = "Ragnarok"; return false;
                    case 437: __result = "Refrigerate"; return false;
                    case 438: __result = "Cocytus"; return false;
                    case 439: __result = "Fimbulvetr"; return false;
                    case 440: __result = "Jolt"; return false;
                    case 441: __result = "Thunder Gods"; return false;
                    case 442: __result = "Thunder Reign"; return false;
                    case 443: __result = "Dervish"; return false;
                    case 444: __result = "Heavenly Cyclone"; return false;
                    case 445: __result = "Vayavya"; return false;
                    case 446: __result = "Damnation"; return false;
                    case 447: __result = "Millennia Curse"; return false;
                    case 448: __result = "Poison Volley"; return false;
                    case 449: __result = "Poison Salvo"; return false;
                    case 450: __result = "Neural Shock"; return false;
                    case 451: __result = "Overload"; return false;
                    case 452: __result = "Pulinpaon"; return false;      
                    case 453: __result = "Antichthon"; return false;      
                    case 454: __result = "Last Word"; return false;
                    case 455: __result = "Soul Drain"; return false;
                    case 456: __result = "Amrita"; return false;
                    case 457: __result = "Diamrita"; return false;
                    case 458: __result = "Heat Riser"; return false;
                    case 459: __result = "Luster Candy"; return false;
                    case 460: __result = "Silent Prayer"; return false;
                    case 461: __result = "Storm Gale"; return false;
                    case 462: __result = "Winged Fury"; return false;
                    case 463: __result = "Jack Bufu"; return false;
                    case 464: __result = "Humble Blessing"; return false;
                    case 465: __result = "Rend"; return false;
                    case 466: __result = "Jack Bufudyne"; return false;
                    case 467: __result = "Divine Light"; return false;
                    case 468: __result = "Niflheim"; return false;
                    case 469: __result = "Mjolnir"; return false;
                    case 470: __result = "Tandava"; return false;
                    case 471: __result = "Chaturbhuja"; return false;
                    case 472: __result = "Kusanagi"; return false;
                    case 473: __result = "Jack Agilao"; return false;
                    case 474: __result = "Gae Bolg"; return false;
                    case 475: __result = "Gungnir"; return false;
                    case 476: __result = "Smite"; return false;
                    case 477: __result = "Makai Thunder"; return false;
                    case 478: __result = "Scintilla"; return false;
                    case 479: __result = "Liberation"; return false;
                    case 480: __result = "Acrobat Kick"; return false;
                    case 481: __result = "Oni-Jackura"; return false;

                    case 489: __result = "Pain"; return false;
                    case 490: __result = "Spiteful Force"; return false;
                    case 491: __result = "Phlegethon"; return false;
                    case 492: __result = "Judecca Tomb"; return false;
                    case 493: __result = "Weeping Heaven"; return false;
                    case 494: __result = "Carnal Winds"; return false;
                    case 495: __result = "Verdict"; return false;
                    case 496: __result = "Devil Regeneration"; return false;
                    case 497: __result = "Devil Trigger"; return false;
                    case 498: __result = "Scorn"; return false;
                    case 499: __result = "Crush"; return false;
                    case 500: __result = "Rampage"; return false;
                    case 501: __result = "Inferno of God"; return false;
                    case 502: __result = "Hailstorm of God"; return false;
                    case 503: __result = "Lightning of God"; return false;
                    case 504: __result = "Tornado of God"; return false;
                    case 505: __result = "Planned Chaos"; return false;
                    case 506: __result = "Mouth of God"; return false;
                    case 507: __result = "Black Hole"; return false;
                    case 508: __result = "Supernova"; return false;
                    case 509: __result = "Infinite Power"; return false;
                    case 510: __result = "Unending Curse"; return false;
                    case 511: __result = "Divine Harmony"; return false;
                    default: return true;
                }
            }
        }

        [HarmonyPatch(typeof(datSkillHelp_msg), nameof(datSkillHelp_msg.Get))]
        private class SkillDescriptionPatch
        {
            public static bool Prefix(ref int id, ref string __result)
            {
                switch (id)
                {
                    // Vanilla Skills
                    case 1: __result = "Low Fire damage to one foe. \nPow: 30, Acc: 100%"; return false; // Agi
                    case 2: __result = "Medium Fire damage to one foe. \nPow: 45, Acc: 100%"; return false; // Agilao
                    case 3: __result = "High Fire damage to one foe. \nPow: 60, Acc: 100%"; return false; // Agidyne
                    case 4: __result = "Low Fire damage to all foes. \nPow: 24, Acc: 100%"; return false; // Maragi
                    case 5: __result = "Medium Fire damage to all foes. \nPow: 36, Acc: 100%"; return false; // Maragion
                    case 6: __result = "High Fire damage to all foes. \nPow: 48, Acc: 100%"; return false; // Maragidyne
                    case 7: __result = "Low Ice damage to one foe. \nPow: 27, Acc: 100%, Freeze: 20%"; return false; // Bufu
                    case 8: __result = "Medium Ice damage to one foe. \nPow: 39, Acc: 100%, Freeze: 24%"; return false; // Bufula
                    case 9: __result = "High Ice damage to one foe. \nPow: 51, Acc: 100%, Freeze: 28%"; return false; // Bufudyne
                    case 10: __result = "Low Ice damage to all foes. \nPow: 20, Acc: 100%, Freeze: 11%"; return false; // Mabufu
                    case 11: __result = "Medium Ice damage to all foes. \nPow: 30, Acc: 100%, Freeze: 14%"; return false; // Mabufula
                    case 12: __result = "High Ice damage to all foes. \nPow: 40, Acc: 100%, Freeze: 17%"; return false; // Mabufudyne
                    case 13: __result = "Low Elec damage to one foe. \nPow: 27, Acc: 100%, Shock: 22%"; return false; // Zio
                    case 14: __result = "Medium Elec damage to one foe. \nPow: 39, Acc: 100%, Shock: 26%"; return false; // Zionga
                    case 15: __result = "High Elec damage to one foe. \nPow: 51, Acc: 100%, Shock: 30%"; return false; // Ziodyne
                    case 16: __result = "Low Elec damage to all foes. \nPow: 20, Acc: 100%, Shock: 13%"; return false; // Mazio
                    case 17: __result = "Medium Elec damage to all foes. \nPow: 30, Acc: 100%, Shock: 16%"; return false; // Mazionga
                    case 18: __result = "High Elec damage to all foes. \nPow: 40, Acc: 100%, Shock: 19%"; return false; // Maziodyne
                    case 19: __result = "Low Force damage to one foe. \nPow: 30, Acc: 100%"; return false; // Zan
                    case 20: __result = "Medium Force damage to one foe. \nPow: 45, Acc: 100%"; return false; // Zanma
                    case 21: __result = "High Force damage to one foe. \nPow: 60, Acc: 100%"; return false; // Zandyne
                    case 22: __result = "Low Force damage to all foes. \nPow: 24, Acc: 100%"; return false; // Mazan
                    case 23: __result = "Medium Force damage to all foes. \nPow: 36, Acc: 100%"; return false; // Mazanma
                    case 24: __result = "High Force damage to all foes. \nPow: 48, Acc: 100%"; return false; // Mazandyne
                    case 25: __result = "Medium Almighty damage to all foes. \nPow: 36, Acc: 100%"; return false; // Megido
                    case 26: __result = "Med-High Almighty damage to all foes. \nPow: 42, Acc: 100%"; return false; // Megidola
                    case 27: __result = "High Almighty damage to all foes. \nPow: 48, Acc: 100%"; return false; // Megidolaon
                    case 28: __result = "Low Light damage to one foe. \nMay instakill when weak to Light. \nPow: 36, Acc: 100%, Fatal: 30%"; return false; // Hama
                    case 29: __result = "Med-High Light damage to one foe. \nMay instakill when weak to Light. \nPow: 54, Acc: 100%, Fatal: 50%"; return false; // Hamaon
                    case 30: __result = "Low Light damage to all foes. \nMay instakill when weak to Light. \nPow: 30, Acc: 100%, Fatal: 20%"; return false; // Mahama
                    case 31: __result = "Med-High Light damage to all foes. \nMay instakill when weak to Light. \nPow: 42, Acc: 100%, Fatal: 30%"; return false; // Mahamaon
                    case 32: __result = "Low Dark damage to one foe. \nMay instakill when weak to Dark. \nPow: 36, Acc: 100%, Fatal: 30%"; return false; // Mudo
                    case 33: __result = "Med-High Dark damage to one foe. \nMay instakill when weak to Dark. \nPow: 54, Acc: 100%, Fatal: 50%"; return false; // Mudoon
                    case 34: __result = "Low Dark damage to all foes. \nMay instakill when weak to Dark. \nPow: 30, Acc: 100%, Fatal: 20%"; return false; // Mamudo
                    case 35: __result = "Med-High Dark damage to all foes. \nMay instakill when weak to Dark. \nPow: 42, Acc: 100%, Fatal: 30%"; return false; // Mamudoon
                    case 36: __result = "Moderate HP recovery for one ally. \nPow: 10"; return false; // Dia
                    case 37: __result = "Great HP recovery for one ally. \nPow: 20"; return false; // Diarama
                    case 38: __result = "Full HP recovery for one ally."; return false; // Diarahan
                    case 39: __result = "Moderate HP recovery for all allies. \nPow: 10"; return false; // Media
                    case 40: __result = "Great HP recovery for all allies. \nPow: 20"; return false; // Mediarama
                    case 41: __result = "Full HP recovery for all allies."; return false; // Mediarahan
                    //case 42: __result = "Donates MP to one ally."; return false; // Makatora
                    case 43: __result = "Cures Bind/Sleep/Panic for one ally."; return false; // Patra
                    case 44: __result = "Cures Bind/Sleep/Panic for all allies."; return false; // Me Patra
                    case 45: __result = "Cures Mute for one ally."; return false; // Mutudi
                    case 46: __result = "Cures Poison for one ally."; return false; // Posumudi
                    case 47: __result = "Cures Stun for one ally."; return false; // Paraladi
                    case 48: __result = "Cures Stone for one ally."; return false; // Petradi
                    case 49: __result = "Revives one ally with slight HP."; return false; // Recarm
                    case 50: __result = "Revives one ally to full HP."; return false; // Samarecarm
                    case 51: __result = "Sacrifice self to fully recover allies' HP/MP."; return false; // Recarmdra
                    case 52: __result = "Lowers all foes' \nPhysical/Magical Attack \nby one rank."; return false; // Tarunda
                    case 53: __result = "Lowers all foes' Evasion/Hit Rate \nby one rank."; return false; // Sukunda
                    case 54: __result = "Lowers all foes' Defense \nby one rank."; return false; // Rakunda
                    case 55: __result = "50% Chance to inflict Mute \non one foe. (Curse-Type)"; return false; // Makajam
                    case 56: __result = "25% Chance to inflict Mute \non all foes. (Curse-Type)"; return false; // Makajamon
                    case 57: __result = "Negates -kaja effects on all foes."; return false; // Dekaja
                    case 59: __result = "Low Nerve damage to one foe. \nPow: 30, Acc: 100%, Bind: 30%"; return false; // Shibaboo
                    case 60: __result = "30% Chance to inflict Sleep \non all foes. (Mind-Type)"; return false; // Lullaby
                    case 61: __result = "Low Mind damage to one foe. \nPow: 30, Acc: 100%, Panic: 30%"; return false; // Pulinpa
                    case 62: __result = "50% Chance to inflict Charm \non one foe. (Mind-Type)"; return false; // Marin Karin
                    case 63: __result = "Medium Mind damage to all foes. \nPow: 30, Acc: 100%, Panic: 40%"; return false; // Tentarafoo
                    case 64: __result = "Raises all allies' \nPhysical/Magical Attack \nby one rank."; return false; // Tarukaja
                    case 65: __result = "Raises all allies' Evasion/Hit Rate \nby one rank."; return false; // Sukukaja
                    case 66: __result = "Raises all allies' Defense \nby one rank."; return false; // Rakukaja
                    case 67: __result = "Raises all allies' \nMagical Attack/Hit Rate \nby one rank."; return false; // Makakaja
                    case 68: __result = "Negates one Light/Dark attack \nfor all allies."; return false; // Tetraja
                    case 69: __result = "Repels Magic-based attacks \nfor one ally once \nnext turn."; return false; // Makarakarn
                    case 70: __result = "Repels Strength-based attacks \nfor one ally once \nnext turn."; return false; // Tetrakarn
                    case 71: __result = "Displays an enemy's info \nat 1/2 turn cost."; return false; // Analyze
                    case 72: __result = "Escape from most battles without fail."; return false; // Trafuri
                    case 73: __result = "Reduces encounter rate \nof low-level demons \nuntil a new Kagutsuchi."; return false; // Trafuri
                    case 74: __result = "Raises encounter rate \nuntil a new Kagutsuchi."; return false; // Riberama
                    case 75: __result = "Negates floor damage \nuntil a new Kagutsuchi."; return false; // Liftoma
                    case 76: __result = "Lights up dark areas \nuntil a new Kagutsuchi."; return false; // Lightoma
                    case 77: __result = "Negates -nda effects on all allies."; return false; // Dekunda
                    case 79: __result = "Medium Almighty damage to all foes. \nMay instakill when poisoned. \nPow: 36, Acc: 100%, Fatal: 90%"; return false; // Pestilence
                    case 90: __result = "Low Curse damage to one foe. \nPow: 30, Acc: 100%, Poison: 30%"; return false; // Poison Arrow
                    case 96: __result = "Low Physical damage to one foe. \nPow: 42, Acc: 90%, Crit: 20%"; return false; // Lunge
                    case 97: __result = "Medium Physical damage to one foe. \nPow: 48, Acc: 86%, Crit: 28%"; return false; // Hell Thrust
                    case 98: __result = "Low Physical damage to random foes. \n2-5 hits. Pow: 20, Acc: 94%, \nCrit: 12%"; return false; // Berserk
                    case 99: __result = "Medium Physical damage to all foes. \nPow: 30, Acc: 85%, Crit: 25%"; return false; // Tempest
                    case 100: __result = "High Physical damage to all foes. \nPow: 40, Acc: 82%, Crit: 36%"; return false; // Hades Blast
                    case 101: __result = "Low Physical damage to all foes. \nHP-based. Max Pow: 24, Acc: 88%, \nCrit: 24%"; return false; // Heat Wave
                    case 102: __result = "Medium Physical damage to all foes. \nHP-based. Max Pow: 32, Acc: 85%, \nCrit: 30%, Poison: 24%"; return false; // Blight
                    case 103: __result = "Medium Physical damage to one foe. \nHP-based. Max Pow: 52, Acc: 88%, \nCrit: 24%"; return false; // Brutal Slash
                    case 104: __result = "Mega Physical damage to all foes. \nHP-based. Max Pow: 48, Acc: 80%, \nCrit: 40%"; return false; // Hassohappa
                    case 105: __result = "High Physical damage to one foe. \nHP-based. Max Pow: 60, Acc: 80%, \nCrit: 40%, Mute: 30%"; return false; // Dark Sword
                    case 106: __result = "High Physical damage to one foe. \nHP-based. Max Pow: 60, Acc: 80%, \nCrit: 40%, Bind: 30%"; return false; // Stasis Blade
                    case 107: __result = "Low Physical damage to one foe. \nHP-based. Max Pow: 48, Acc: 90%, \nCrit: 20%"; return false; // Mighty Gust
                    case 108: __result = "High Physical damage to random foes. \n3-5 hits. HP-based. Max Pow: 40, \nAcc: 94%, Crit: 20%"; return false; // Deathbound
                    case 109: __result = "High Physical damage to one foe. \nHP-based. Max Pow: 56, Acc: 85%, \nCrit: 30%, Stun: 30%"; return false; // Guillotine
                    case 110: __result = "High Physical damage to random foes. \n3-5 hits. HP-based. Max Pow: 30, \nAcc: 92%, Crit: 20%, Panic: 24%"; return false; // Chaos Blade
                    case 111: __result = "Low Shot damage to one foe. \n2-4 hits. Pow: 13, Acc: 90%, \nCrit: 20%"; return false; // Needle Rush
                    case 112: __result = "Low Shot damage to one foe. \n2-4 hits. Pow: 12, Acc: 90%, \nCrit: 18%, Stun: 18%"; return false; // Stun Needle
                    case 113: __result = "Low Shot damage to one foe. \n2-4 hits. Pow: 12, Acc: 90%, \nCrit: 18%, Poison: 18%"; return false; // Venom Needle
                    case 114: __result = "Low Shot damage to one foe. \n2-4 hits. Pow: 11, Acc: 90%, \nCrit: 18%, Stone: 16%"; return false; // Arid Needle
                    case 115: __result = "Sacrifice self to deal Mega Str-based \nAlmighty damage to all foes. \nPow: 55, Acc: 90%, Crit: 20%"; return false; // Sacrifice
                    case 116: __result = "Sacrifice self to deal Mega Str-based \nAlmighty damage to one foe. \nPow: 80, Acc: 90%, Crit: 20%"; return false; // Kamikaze
                    case 117: __result = "Low Physical damage to one foe. \nPow: 44, Acc: 88%, Crit: 24%"; return false; // Feral Bite
                    case 118: __result = "Low Physical damage to one foe. \nPow: 42, Acc: 88%, Crit: 22%, \nPoison: 22%"; return false; // Venom Bite
                    case 119: __result = "Low Physical damage to one foe. \nPow: 42, Acc: 88%, Crit: 22%, \nCharm: 22%"; return false; // Charm Bite
                    case 120: __result = "Low Physical damage to one foe. \nPow: 40, Acc: 88%, Crit: 22%, \nStone: 20%"; return false; // Stone Bite
                    case 121: __result = "Low Physical damage to one foe. \nPow: 42, Acc: 88%, Crit: 22%, \nStun: 22%"; return false; // Stun Bite
                    case 122: __result = "High Physical damage to one foe. \nPow: 56, Acc: 80%, Crit: 40%"; return false; // Hell Fang
                    case 123: __result = "Low Physical damage to one foe. \nPow: 44, Acc: 88%, Crit: 24%"; return false; // Feral Claw
                    case 124: __result = "Low Physical damage to one foe. \nPow: 42, Acc: 88%, Crit: 22%, \nPoison: 22%"; return false; // Venom Claw
                    case 125: __result = "Low Physical damage to one foe. \nPow: 42, Acc: 88%, Crit: 22%, \nStun: 22%"; return false; // Stun Claw
                    case 126: __result = "High Physical damage to one foe. \nPow: 56, Acc: 80%, Crit: 40%"; return false; // Iron Claw
                    case 127: __result = "High Light damage to all foes. \nPow: 48, Acc: 100%, Mute: 30%"; return false; // Godly Light
                    case 131: __result = "High Physical damage to one foe. \nPow: 54, Acc: 95%, Crit: 50%"; return false; // Deadly Fury
                    case 133: __result = "Medium Shot damage to all foes. \nPow: 32, Acc: 95%, Crit: 24%, \nBind: 30%"; return false; // Javelin Rain
                    case 136: __result = "Medium Mag-based Shot damage to \none foe. Pow: 34, Acc: 120%, \nCrit: 100%"; return false; // Divine Shot
                    case 143: __result = "High Physical damage to all foes. \nPow: 36, Acc: 95%, Crit: 24%, \nMute: 30%"; return false; // Xeros Beat
                    case 144: __result = "High Physical damage to all foes. \nPow: 42, Acc: 95%, Crit: 30%"; return false; // Oni Kagura
                    case 147: __result = "Mega Str-based Almighty damage to \none foe. Pow: 66, Acc: 95%, Crit: 30%"; return false; // Freikugel
                    case 152: __result = "Sacrifice self to deal Mega Str-based \nAlmighty damage to all foes and allies. \nPow: 60, Acc: 100%, Crit: 0%"; return false; // Last Resort
                    case 153: __result = "High Physical damage to all foes. \nPow: 40, Acc: 98%, Crit: 20%"; return false; // Foul Havoc
                    case 155: __result = "Mega Physical damage to all foes. \nPow: 60, Acc: 200%, Crit: 0%, \nStun: 20%"; return false; // Earthquake
                    case 160: __result = "Mega Shot damage to one foe. \nPow: 62, Acc: 95%, Crit: 30%"; return false; // Spiral Viper
                    case 161: __result = "Mega Fire damage to one foe. \nPow: 80, Acc: 120%"; return false; // Magma Axis
                    case 163: __result = "Mega Physical damage to all foes. \nPow: 52, Acc: 95%, Crit: 30%"; return false; // Gaea Rage
                    case 176: __result = "Low Fire damage to random foes. \n3-5 hits. Pow: 20, Acc: 100%"; return false; // Fire Breath
                    case 177: __result = "Medium Fire damage to random foes. \n3-6 hits. Pow: 30, Acc: 100%"; return false; // Hellfire
                    case 178: __result = "High Fire damage to random foes. \n3-7 hits. Pow: 40, Acc: 100%"; return false; // Prominence
                    case 179: __result = "Mega Fire damage to one foe. \nPow: 80, Acc: 100%"; return false; // Trisagion
                    case 180: __result = "Low Ice damage to random foes. \n3-5 hits. Pow: 18, Acc: 100%, \nFreeze: 15%"; return false; // Ice Breath
                    case 181: __result = "Medium Ice damage to random foes. \n3-6 hits. Pow: 24, Acc: 100%, \nFreeze: 18%"; return false; // Glacial Blast
                    case 182: __result = "Low Elec damage to random foes. \n3-5 hits. Pow: 18, Acc: 100%, \nShock: 15%"; return false; // Shock
                    case 183: __result = "Medium Elec damage to random foes. \n3-6 hits. Pow: 24, Acc: 100%, \nShock: 18%"; return false; // Bolt Storm
                    case 184: __result = "Low Force damage to random foes. \n3-5 hits. Pow: 20, Acc: 100%"; return false; // Wing Buffet
                    case 185: __result = "Medium Force damage to random foes. \n3-6 hits. Pow: 30, Acc: 100%"; return false; // Tornado
                    case 186: __result = "Mega Force damage to one foe. \nPow: 80, Acc: 100%"; return false; // Wind Cutter
                    case 187: __result = "High Force damage to all foes. \nPow: 45, Acc: 100%, Stun: 30%"; return false; // Wet Wind
                    case 190: __result = "Drains HP from one foe. \nPow: 25, Acc: 100% (Almighty-Type)"; return false; // Deathtouch
                    case 191: __result = "Drains MP from one foe. \nPow: 15, Acc: 100% (Almighty-Type)"; return false; // Mana Drain
                    case 192: __result = "Drains HP/MP from one foe. \nPow: 25/15, Acc: 100% \n(Almighty-Type)"; return false; // Life Drain
                    case 193: __result = "Medium Light damage to one foe. \nPow: 45, Acc: 100%"; return false; // Violet Flash
                    case 194: __result = "Medium Light damage to all foes. \nPow: 36, Acc: 100%"; return false; // Starlight
                    case 195: __result = "Mega Light damage to all foes. \nPow: 60, Acc: 100%"; return false; // Radiance
                    case 196: __result = "60% Chance to instakill one foe. \n(Dark-Type)"; return false; // Hell Gaze
                    case 197: __result = "60% Chance to inflict Stone \non one foe. (Dark-Type)"; return false; // Stone Gaze
                    case 198: __result = "60% Chance to inflict Mute \non one foe. (Curse-Type)"; return false; // Mute Gaze
                    case 199: __result = "60% Chance to reduce HP of one foe \nto 1. (Dark-Type)"; return false; // Evil Gaze
                    case 202: __result = "50% Chance to inflict Poison on \nall foes. Lowers Defense by one rank. \n(Curse-Type)"; return false; // Toxic Spray
                    case 203: __result = "Lowers all foes' \nPhysical/Magical Attack \nby two ranks."; return false; // War Cry
                    case 204: __result = "Lowers all foes' Evasion/Hit Rate \nby two ranks."; return false; // Fog Breath
                    case 205: __result = "Lowers Defense and raises \nPhysical Attack by two ranks \nfor all foes."; return false; // Taunt
                    case 206: __result = "Lowers all stats by one rank \nfor all foes."; return false; // Debilitate
                    case 207: __result = "Medium Curse damage to all foes. \nPow: 30, Acc: 100%, Mute: 40%"; return false; // Dismal Tune
                    case 208: __result = "40% Chance to reduce HP of all foes \nto 1. (Almighty-Type)"; return false; // Sol Niger
                    case 209: __result = "50% Chance to inflict Stun \non one foe. (Nerve-Type)"; return false; // Stun Gaze
                    case 210: __result = "60% Chance to inflict Sleep \non one foe. (Mind-Type)"; return false; // Dormina
                    case 211: __result = "30% Chance to inflict Bind \non all foes. (Nerve-Type)"; return false; // Binding Cry
                    case 212: __result = "Instakill all foes afflicted \nwith Sleep."; return false; // Eternal Rest
                    case 213: __result = "30% Chance to inflict Panic on \nall foes. (Mind-Type)"; return false; // Sonic Wave
                    case 214: __result = "60% Chance to inflict Charm on \none foe. (Mind-Type)"; return false; // Sexy Gaze
                    case 215: __result = "40% Chance to inflict Charm on \nall foes. (Mind-Type)"; return false; // Allure
                    case 216: __result = "30% Chance to inflict Panic on \nall foes. (Mind-Type)"; return false; // Panic Voice
                    case 217: __result = "Mega Mind damage to all foes. \nPow: 60, Acc: 100%, Panic: 40%"; return false; // Intoxicate
                    case 218: __result = "Full HP recovery & cures all ailments \nfor all allies."; return false; // Prayer
                    case 223: __result = "Summons a random ally \nfrom the stock."; return false; // Beckon Call
                    case 224: __result = "Increases the damage of the user's \nnext Strength-based attack by 120%."; return false; // Focus
                    case 235: __result = "Mega Almighty damage to random foes. \n4-8 hits. Pow: 36, Acc: 100%"; return false; // Fire of Sinai
                    case 242: __result = "High Almighty damage to all foes. \nMay inflict random ailments. \nPow: 40, Acc: 100%, Random: 50%"; return false; // God's Curse
                    case 244: __result = "Medium Ice damage to all foes. \nLowers targets' Evasion/Hit Rate. \nPow: 30, Acc: 100%, Freeze: 25%"; return false; // Icy Death
                    case 249: __result = "High Mind damage to random foes. \n3-7 hits. Pow: 36, Acc: 100%, Panic: 40%"; return false; // Wild Dance
                    case 250: __result = "Drains HP/MP from one foe. \nPow: 80/40, Acc: 100% \n(Almighty-Type)"; return false; // Domination
                    case 257: __result = "Mega Almighty damage to random foes. \n4-8 hits. Pow: 40, Acc: 100%."; return false; // Fire of Sinai
                    case 259: __result = "Mega Almighty damage to all foes. \nMay instakill when not immune to Dark. \nPow: 60, Acc: 100%, Fatal: 90%"; return false; // Death Flies
                    case 260: __result = "Mega Almighty damage to all foes. \nMay instakill when not immune to Dark. \nPow: 60, Acc: 100%, Fatal: 90%"; return false; // Death Flies
                    case 261: __result = "High Curse damage to all foes. \nPow: 48, Acc: 60%, Mute: 100%"; return false; // Soul Divide
                    case 262: __result = "Low Shot damage to one foe. \nLowers target's Evasion/Defense. \nPow: 32, Acc: 120%, Crit: 18%"; return false; // Boogie-Woogie/E & I
                    case 263: __result = "High Physical damage to one foe. \nPow: 48, Acc: 200%, Crit: 40%"; return false; // Enter Yoshitsune/Rebellion
                    case 264: __result = "Medium Shot damage to all foes. \nPow: 30, Acc: 200%, Crit: 0%, \nPanic: 24%"; return false; // Mokoi Boomerang/Twosome Time
                    case 265: __result = "Lowers Defense/raises Physical Attack \nby two ranks for all foes. \nSlight MP recovery for the user."; return false; // Provoke
                    case 266: __result = "Medium Str-based Almighty damage \nto one foe. May instakill when not \nimmune to Dark. Pow: 42, Acc: 90%"; return false; // Tekisatsu/Stinger
                    case 267: __result = "High Elec damage to all foes. \nLowers targets' Evasion/Hit Rate. \nPow: 40, Acc: 120%, Shock: 20%"; return false; // Mishaguji Raiden/Roundtrip
                    case 268: __result = "High Force damage to all foes. \nLowers targets' Physical/Magical Attack. \nPow: 48, Acc: 120%"; return false; // Hitokoto Storm/Whirlwind
                    case 269: __result = "High Almighty damage to all foes. \nPow: 48, Acc: 200%"; return false; // Jiraiya Dance/Showtime
                    case 275: __result = "Medium Physical damage to all foes. \nPow: 32, Acc: 100%, Crit: 5%"; return false; // Andalucia
                    case 276: __result = "Maximizes own Evasion/Hit Rate."; return false; // Red Capote
                    case 278: __result = "Medium Mind damage to all foes. \nMay inflict random ailments. \nPow: 30, Acc: 100%, Random: 40%"; return false; // Preach
                    case 279: __result = "Drains HP/MP from one foe. \nPow: 35/20, Acc: 100% \n(Almighty-Type)"; return false; // Meditation
                    case 280: __result = "Medium Physical damage to random foes. \n3-6 hits. Pow: 32, Acc: 96%, \nCrit: 10%, Panic: 40%"; return false; // Terrorblade
                    case 281: __result = "Medium Physical damage to all foes. \nPow: 32, Acc: 94%, Crit: 12%"; return false; // Hell Spin
                    case 282: __result = "Medium Force damage to all foes. \nNegates -kaja effects. \nPow: 30, Acc: 100%"; return false; // Hell Exhaust
                    case 283: __result = "Medium Str-based Fire damage \nto all foes. Pow: 32, Acc: 88%, \nCrit: 12%"; return false; // Hell Burner
                    case 284: __result = "Raises all allies' \nPhysical Attack/Evasion/Hit Rate \nby one rank."; return false; // Hell Throttle
                    case 285: __result = "Lowers all foes' Evasion/Hit Rate \nby one rank. 50% Chance to \ninflict Panic. (Almighty-Type)"; ; return false; // Babylon Goblet
                    case 286: __result = "High Almighty damage to all foes. \nSlight HP recovery for the user. \nPow: 48, Acc: 100%, Charm: 30%"; return false; // Death Lust
                    case 287: __result = "Mega Light damage to one foe. \nMay instakill when weak to Light. \nPow: 80, Acc: 100%, Fatal: 90%"; return false; // God's Bow
                    
                    case 290: __result = "Raises Maximum HP by 10%."; return false; // Life Bonus
                    case 291: __result = "Raises Maximum HP by 20%."; return false; // Life Gain
                    case 292: __result = "Raises Maximum HP by 30%."; return false; // Life Surge
                    case 293: __result = "Raises Maximum MP by 10%."; return false; // Mana Bonus
                    case 294: __result = "Raises Maximum MP by 20%."; return false; // Mana Gain
                    case 295: __result = "Raises Maximum MP by 30%."; return false; // Mana Surge
                    case 296: __result = "Guarantees escape \nwhen possible."; return false; // Fast Retreat
                    case 298: __result = "Prevents being attacked \nfrom behind."; return false; // Mind's Eye
                    case 299: __result = "Raises Critical Rate of \nnormal attacks to 30%."; return false; // Might
                    case 300: __result = "Raises Critical Rate of \nnormal attacks to 50% \nduring full Kagutsuchi."; return false; // Bright Might
                    case 301: __result = "Raises Critical Rate of \nnormal attacks to 50% \nduring new Kagutsuchi."; return false; // Dark Might
                    case 302: __result = "Normal attacks will drain HP."; return false; // Drain Attack
                    case 304: __result = "Normal attacks will \nhit all enemies."; return false; // Attack All
                    case 305: __result = "May perform a weak counterattack \nwhen physically attacked. Pow: 32"; return false; // Counter
                    case 306: __result = "May perform a medium counterattack \nwhen physically attacked. Pow: 48"; return false; // Retaliate
                    case 307: __result = "May perform a strong counterattack \nwhen physically attacked. Pow: 56"; return false; // Avenge
                    case 309: __result = "Raises Fire attack damage by 30%."; return false; // Fire Boost
                    case 310: __result = "Raises Ice attack damage by 30%."; return false; // Ice Boost
                    case 311: __result = "Raises Elec attack damage by 30%."; return false; // Elec Boost
                    case 312: __result = "Raises Force attack damage by 30%."; return false; // Force Boost
                    case 313: __result = "Protects against Physical attacks."; return false; // Anti-Phys
                    case 314: __result = "Protects against Fire attacks."; return false; // Anti-Fire
                    case 315: __result = "Protects against Ice attacks."; return false; // Anti-Ice
                    case 316: __result = "Protects against Elec attacks."; return false; // Anti-Elec
                    case 317: __result = "Protects against Force attacks."; return false; // Anti-Force
                    case 345: __result = "Survive a fatal blow with 1 HP \nremaining once per battle."; return false; // Endure
                    case 346: __result = "Great HP recovery after battle. \nMust be in the active party."; return false; // Life Aid
                    case 347: __result = "Moderate MP recovery after battle. \nMust be in the active party."; return false; // Mana Aid
                    case 354: __result = "Earn 100% EXP when not \nparticipating in battle."; return false; // Watchful
                    case 357: __result = "Attacks ignore all resistances \nexcept Repel."; return false; // Pierce
                    case 360: __result = "Protects against ailments and instakills. \nSurvive a fatal blow with 1 HP \nremaining once per battle."; return false; // Raidou Endure/Never Yield
                    case 361: __result = "Pierce & raises damage of all attacks by 30%."; return false; // Raidou the Eternal/Son's Oath

                    case 385: __result = "Invite a demon to join. \nEffective when speaker is adult \nand target is female."; return false; // Scout
                    case 386: __result = "Invite a demon to join. \nEffective when speaker is older \nthan target."; return false; // Kidnap
                    case 387: __result = "Invite a demon to join. \nEffective when speaker is female \nand target is male."; return false; // Seduce
                    case 388: __result = "Invite a demon to join. \nEffective when speaker is much \nhigher level than target."; return false; // Brainwash
                    case 390: __result = "Invite a demon to join. \nEffective during new Kagutsuchi."; return false; // Dark Pledge
                    case 391: __result = "Invite a demon to join. Effective when \nspeaker is young male or old female \nand target is young female."; return false; // Wooing
                    case 392: __result = "Invite a demon to join. \nEffective when speaker is much lower \nlevel than target."; return false; // Beseech
                    case 393: __result = "Invite a demon to join in Odin's name. \nEffective when target is male."; return false; // Soul Recruit
                    case 394: __result = "Invite a demon to join using sex appeal. \nEffective when speaker is male \nand target is female."; return false; // Mischief

                    case 396: __result = "Ask for Macca and items."; return false; // Plead
                    case 397: __result = "Ask for Macca and items. \nEffective when speaker is much lower \nlevel than target."; return false; // Begging
                    case 398: __result = "Ask for Macca and items. \nEffective when speaker is much higher \nlevel than target."; return false; // Threaten

                    case 409: __result = "While in the active party, \nmay step in during negotiation and \nensure lesser demands."; return false; // Haggle
                    case 410: __result = "While in the active party, \nmay step in during negotiation and \nsoothe an enraged demon."; return false; // Arbitration
                    case 411: __result = "While in the active party, may step \nin during negotiation and prevent a \ndemon from making off with payment."; return false; // Detain
                    case 412: __result = "While in the active party, \nmay step in during negotiation to \nurge a demon of the same race."; return false; // Kinspeak
                    case 413: __result = "While in the active party, \nmay step in during negotiation to \npersuade an indecisive demon."; return false; // Silver Tongue
                    case 414: __result = "While in the active party, \nmay step in during negotiation to \n'convince' a lower level demon."; return false; // Intimidate
                    case 415: __result = "While in the active party, \nmay step in during negotiation to \ntempt a male demon."; return false; // Entice
                    case 418: __result = "While in the active party, \nmay step in during negotiation and \npacify an enraged demon."; return false; // Maiden Plea
                    case 419: __result = "While in the active party, \nmay step in during negotiation to \nfix trouble with the power of liquor."; return false; // Wine Party
                    case 420: __result = "While in the active party, \nmay step in during negotiation to \nconvince a higher level demon."; return false; // Flatter

                    // New Skills
                    case 128: __result = "Low Shot damage to random foes. \n2-5 hits. Pow: 22, Acc: 90%, \nCrit: 18%"; return false; // Rapid Needle
                    case 129: __result = "Medium Shot damage to one foe. \nPow: 44, Acc: 84%, Crit: 30%"; return false; // Tathlum Shot
                    case 130: __result = "Medium Shot damage to all foes. \nPow: 28, Acc: 82%, Crit: 28%"; return false; // Blast Arrow
                    case 134: __result = "High Shot damage to one foe. \nPow: 52, Acc: 80%, Crit: 40%"; return false; // Grand Tack
                    case 135: __result = "High Shot damage to all foes. \nPow: 36, Acc: 84%, Crit: 30%"; return false; // Heaven's Bow
                    case 141: __result = "Mega Shot damage to one foe. \nPow: 60, Acc: 90%, Crit: 30%"; return false; // Riot Gun
                    case 188: __result = "50% Chance to instakill one foe. \n(Light-Type)"; return false; // Punishment
                    case 189: __result = "30% Chance to instakill all foes. \n(Light-Type)"; return false; // Judgement Light

                    case 308: __result = "Attack again after a \ncritical normal attack."; return false; // Double Attack
                    case 362: __result = "Raises Physical attack damage by 30%."; return false; // Phys Boost
                    case 363: __result = "Raises Element attack damage by 30%. \n(Does not stack with similar effects)"; return false; // Element Boost
                    case 364: __result = "Protects against Element attacks. \n(Does not stack with similar effects)"; return false; // Anti-Elements
                    case 365: __result = "Protects against Ailment attacks. \n(Does not stack with similar effects)"; return false; // Anti-Ailments
                    case 366: __result = "Protects against ailments \nand instakills."; return false; // Abyssal Mask
                    case 367: __result = "Allows the use of items."; return false; // Knowledge of Tools
                    case 368: __result = "Very slight HP recovery \nafter each action."; return false; // Renewal
                    case 369: __result = "Very slight MP recovery \nafter each action."; return false; // Spirit Well
                    case 370: __result = "Slight HP/MP recovery \nafter each action. \n(Does not stack with similar effects)"; return false; // Qigong
                    case 371: __result = "Reduce the base HP costs of skills \nby 50%. HP-based skills always deal \nmaximum damage."; return false; // Arms Master
                    case 372: __result = "Negates random Critical hits \nbut prevents dodging attacks."; return false; // Firm Stance
                    case 373: __result = "Raises Shot attack damage by 30%."; return false; // Shot Boost
                    case 374: __result = "Protects against Shot attacks."; return false; // Anti-Shot
                    case 375: __result = "Nullifies Shot attacks."; return false; // Null: Shot
                    case 376: __result = "Absorbs Shot attacks, \nreplenishing HP."; return false; // Shot Drain
                    case 377: __result = "Repels Shot attacks."; return false; // Shot Repel
                    case 378: __result = "While alone, gain a flashing \nturn icon at the start of each turn. \n(Does not stack with similar effects)"; return false; // Solitary Drift
                    case 379: __result = "Attacks ignore all resistances \nexcept Repel."; return false; // Pierce

                    //case 373: __result = "Survive a fatal blow then fully \nrecover HP once per battle. \n(Does not stack with similar effects)"; return false; // Enduring Soul

                    case 424: __result = "Increases the damage of the user's \nnext Magic-based attack by 120%."; return false; // Concentrate
                    case 425: __result = "Increases the damage of the user's \nnext attack by 120% and grants \nit Pierce."; return false; // Impaler's Animus
                    case 426: __result = "High Physical damage to all foes. \nPow: 36, Acc: 90%, Crit: 20%, \nCharm: 20%"; return false; // Sakura Rage
                    case 427: __result = "Low Physical damage to one foe. \nLowers target's Physical Attack. \nPow: 36, Acc: 90%, Crit: 10%"; return false; // Fang Breaker
                    case 428: __result = "Low Physical damage to one foe. \nLowers target's Defense. \nPow: 32, Acc: 90%, Crit: 10%"; return false; // Defense Kuzushi
                    case 429: __result = "Mega Physical damage to one foe. \nPow: 80, Acc: 94%, Crit: 0%"; return false; // Primal Force
                    case 430: __result = "Low Physical damage to all foes. \nPow: 24, Acc: 86%, Crit: 34%"; return false; // Chi Blast
                    case 431: __result = "High Physical damage to all foes. \nPow: 42, Acc: 90%, Crit: 30%, \nMute: 30%"; return false; // Revelation
                    case 432: __result = "High Physical damage to all foes. \nPow: 42, Acc: 90%, Crit: 30%, \nStone: 24%"; return false; // Gate of Hell
                    case 433: __result = "High Physical damage to one foe. \nPow: 54, Acc: 97%, Crit: 50%"; return false; // Akashic Arts
                    case 434: __result = "High Physical damage to random foes. \n3-5 hits, Pow: 32, Acc: 86%, \nCrit: 40%"; return false; // Bloodbath
                    case 435: __result = "Low Fire damage to all foes. \nLowers targets' Physical Attack. \nPow: 30, Acc: 100%"; return false; // Scald
                    case 436: __result = "Mega Fire damage to all foes. \nPow: 60, Acc: 100%"; return false; // Ragnarok
                    case 437: __result = "Low Ice damage to one foe. \nLowers target's Evasion/Hit Rate. \nPow: 32, Acc: 100%, Freeze: 24%"; return false; // Refrigerate
                    case 438: __result = "High Ice damage to random foes. \n3-7 hits, Pow: 40, Acc: 100%, \nFreeze: 30%"; return false; // Cocytus
                    case 439: __result = "Mega Ice damage to all foes. \nPow: 50, Acc: 100%, Freeze: 22%"; return false; // Fimbulvetr
                    case 440: __result = "Low Elec damage to one foe. \nPow: 32, Acc: 100%, Shock: 65%"; return false; // Jolt
                    case 441: __result = "Mega Elec damage to one foe. \nPow: 70, Acc: 100%, Shock: 34%"; return false; // Thunder Gods
                    case 442: __result = "Mega Elec damage to all foes. \nPow: 50, Acc: 100%, Shock: 22%"; return false; // Thunder Reign
                    case 443: __result = "Low Force damage to all foes. \nLowers targets' Evasion. \nPow: 30, Acc: 100%"; return false; // Dervish
                    case 444: __result = "High Force damage to random foes. \n3-7 hits, Pow: 40, Acc: 100%"; return false; // Heavenly Cyclone
                    case 445: __result = "Mega Force damage to all foes. \nPow: 60, Acc: 100%"; return false; // Vayavya
                    case 446: __result = "50% Chance to instakill one foe. \n(Dark-Type)"; return false; // Damnation
                    case 447: __result = "30% Chance to instakill all foes. \n(Dark-Type)"; return false; // Millennia Curse
                    case 448: __result = "Low Curse damage to random foes. \n3-6 hits, Pow: 18, Acc: 100%, \nPoison: 40%"; return false; // Poison Volley
                    case 449: __result = "Medium Curse damage to one foe. \nPow: 39, Acc: 100%, Poison: 70%"; return false; // Poison Salvo
                    case 450: __result = "Medium Nerve damage to one foe. \nPow: 39, Acc: 100%, Stun: 70%"; return false; // Neural Shock
                    case 451: __result = "Medium Nerve damage to all foes. \nPow: 30, Acc: 100%, Stun: 50%"; return false; // Overload
                    case 452: __result = "Medium Mind damage to one foe. \nPow: 39, Acc: 100%, Panic: 70%"; return false; // Pulinpaon
                    case 453: __result = "High Almighty damage to one foe. \nLowers all stats for target. \nPow: 50, Acc: 100%"; return false; // Antichthon
                    case 454: __result = "Mega Almighty damage to one foe. \nPow: 80, Acc: 100%"; return false; // Last Word
                    case 455: __result = "Drains HP/MP from one foe. \nPow: 32/32, Acc: 100% \n(Almighty-Type)"; return false; // Soul Drain
                    case 456: __result = "Cures all ailments for all allies."; return false; // Amrita
                    case 457: __result = "Great HP recovery and cures \nall ailments for one ally. \nPow: 18"; return false; // Diamrita
                    case 458: __result = "Raises all stats by two ranks \nfor one ally."; return false; // Heat Riser
                    case 459: __result = "Raises all stats by one rank \nfor all allies."; return false; // Luster Candy
                    case 460: __result = "Negates -kaja & -nda effects \non all foes & allies."; return false; // Silent Prayer
                    case 461: __result = "Low Force damage to random foes. \n3-5 hits. Pow: 20, Acc: 100%"; return false; // Storm Gale
                    case 462: __result = "High Str-based Force damage to \nall foes. Pow: 36, Acc: 90%, \nCrit: 20%"; return false; // Winged Fury
                    case 463: __result = "Low Ice damage to one foe. \nLowers target's Defense. \nPow: 27, Acc: 100%, Freeze: 20%"; return false; // Jack Bufu
                    case 464: __result = "Moderate HP recovery \nfor all allies. Pow: 8 \n(Cannot be used outside of battle)"; return false; // Humble Blessing
                    case 465: __result = "Mega Physical damage to one foe. \nPow: 60, Acc: 90%, Crit: 40%"; return false; // Rend
                    case 466: __result = "Mega Ice damage to one foe. Lowers \ntarget's Defense. Ignores Cold World. \nPow: 70, Acc: 100%, Freeze: 20%"; return false; // Jack Bufudyne
                    case 467: __result = "High Physical damage to all foes. \nLowers all stats for all targets. \nPow: 48, Acc: 85%, Crit: 0%"; return false; // Divine Light
                    case 468: __result = "Mega Ice damage to all foes. \nLowers targets' Defense/Evasion. \nPow: 60, Acc: 100%, Freeze: 25%"; return false; // Niflheim
                    case 469: __result = "High Str-based Elec damage to one \nfoe. HP-based. Max Pow: 50, \nAcc: 90%, Crit: 20%, Shock: 20%"; return false; // Mjolnir
                    case 470: __result = "Mega Almighty damage to all foes. \nMinimizes targets' Defense. \nPow: 60, Acc: 100%"; return false; // Tandava
                    case 471: __result = "Mega Str-based Almighty damage to \nrandom foes. 5-7 hits. Pow: 40, \nAcc: 100%, Crit: 1%"; return false; // Chaturbhuja
                    case 472: __result = "High Str-based Force damage to \none foe. HP-based. \nMax Pow: 54, Acc: 90%, Crit: 24%"; return false; // Kusanagi
                    case 473: __result = "Medium Fire damage to one foe. \nLowers target's Phys/Mag Attack. \nPow: 45, Acc: 100%"; return false; // Jack Agilao
                    case 474: __result = "Medium Str-based Force damage to \none foe. HP-based. \nMax Pow: 34, Acc: 120%, Crit: 100%"; return false; // Gae Bolg
                    case 475: __result = "High Physical damage to one foe. \nIgnores target's -kaja effects. \nPow: 52, Acc: 90%, Crit: 20%"; return false; // Gungnir
                    case 476: __result = "Mega Light damage to one foe. \nPow: 80, Acc: 100%"; return false; // Smite
                    case 477: __result = "Medium Dark damage to one foe. \nPow: 45, Acc: 100%, Bind: 20%"; return false; // Makai Thunder
                    case 478: __result = "Mega Dark damage to all foes. \nPow: 60, Acc: 100%"; return false; // Scintilla
                    case 479: __result = "Full HP recovery, negates \n-nda effects and cures \nall ailments for one ally."; return false; // Liberation
                    case 480: __result = "Medium Physical damage to one foe. \nPow: 34, Acc: 120%, Crit: 100%"; return false; // Acrobat Kick
                    case 481: __result = "High Physical damage to all foes. \nPow: 42, Acc: 90%, Crit: 30%, \nFreeze: 30%"; return false; // Oni-Jackura
                    default: return true;
                }
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.InitActionProcessData))]
        private class ActionProcessDataPatch
        {
            public static void Postfix(ref int type, ref int from, ref int to, ref int d, ref nbActionProcessData_t __result)
            {
                actionProcessData = __result;
                currentDemonWork = __result.work;
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetAction_COMM))]
        private class SetAction_COMMPatch
        {
            public static void Prefix(ref nbActionProcessData_t a)
            {
                actionProcessData = a;
                currentDemonWork = a.work;
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.CheckAction_COMM))]
        private class CheckAction_COMMPatch
        {
            public static void Prefix(ref nbActionProcessData_t a)
            {
                actionProcessData = a;
                currentDemonWork = a.work;
            }
        }

        [HarmonyPatch(typeof(nbMainProcess), nameof(nbMainProcess.nbSetEndPhase))]
        private class nbSetEndPhasePatch
        {
            public static void Postfix()
            {
                actionProcessData = null;
                try
                {
                    nbMainProcess.GetBattleUI().transform.Find("../bannounce(Clone)/stretch/TextTM").gameObject.GetComponent<TextMeshProUGUI>().outlineColor = new Color(0.294f, 0.294f, 0.980f, 1);
                    nbMainProcess.GetBattleUI().transform.Find("../bannounce(Clone)/stretch/TextTM").gameObject.GetComponent<TextMeshProUGUI>().enableVertexGradient = false;
                } catch { }
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetAddPressPacket))]
        private class BeastEyePatch1
        {
            public static void Postfix(ref nbActionProcessData_t a, ref int nskill)
            {
                actionProcessData = a;

                if (a.newaddpresstype == 15 && (nskill == 422 || nskill == 423))
                {
                    if (nskill == 422)
                    {
                        a.newaddpresstype = 18;
                        actionTrackers[a.work.id].extraTurns += 1;
                    }
                    else if (nskill == 423)
                    {
                        a.newaddpresstype = 19;
                        actionTrackers[a.work.id].extraTurns += 2;
                    }
                }
                else if (a.newaddpresstype == 15 && (nskill == 498))
                {
                    a.newaddpresstype = 20;
                }
            }
        }
        [HarmonyPatch(typeof(nbMakePacket), nameof(nbMakePacket.nbMakeNewPressPacket))]
        private class BeastEyePatch2
        {
            public static void Postfix(ref int startframe, ref int uniqueid, ref int ptype, ref nbFormation_t form)
            {
                if (ptype == 20 && nbMainProcess.nbGetUnitWorkFromFormindex(form.formindex).id == 254)
                {
                    nbHelpProcess.nbDispText("YHVH trembles with scorn...", string.Empty, 2, 45, 2315190144, false);
                }
                else if (ptype == 18)
                {
                    nbMakePacket.nbAddNewPressPacket(startframe, uniqueid, 1, 1);
                    nbHelpProcess.nbDispText("Turn Count increased!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (ptype == 19)
                {
                    nbMakePacket.nbAddNewPressPacket(startframe, uniqueid, 2, 2);
                    nbHelpProcess.nbDispText("Turn Count increased!", string.Empty, 2, 45, 2315190144, false);
                }
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetAllPacket))]
        private class RemoveFreezeAndShockPatch
        {
            public static void Postfix(ref nbActionProcessData_t a, ref int koukatype, ref int nskill, ref int sformindex, ref int dformindex, 
                                       ref int cnt, ref int frame, ref float koukaritu)
            {
                actionProcessData = a;

                datUnitWork_t target = nbMainProcess.nbGetUnitWorkFromFormindex(dformindex);

                // Remove Freeze and Shock after guaranteed critical strike
                if ((datNormalSkill.tbl[nskill].koukatype == 0 || (dds3GlobalWork.DDS3_GBWK.heartsequip == 13 && sformindex <= 3 && (datSkill.tbl[nskill].skillattr == 3 || datSkill.tbl[nskill].skillattr == 4) && target.badstatus == 2)) && (target.badstatus == 1 || target.badstatus == 2)
                    && (datNormalSkill.tbl[nskill].hptype == 1 || datNormalSkill.tbl[nskill].hptype == 6 || datNormalSkill.tbl[nskill].hptype == 12 || datNormalSkill.tbl[nskill].hptype == 14))
                {
                    var form = a.data.form[dformindex];
                    nbMakePacket.nbMakeBadKaifukuPacket(frame, a.uniqueid, ref form);
                }

                // Okuninushi's Nation Founder, Hanuman's Ramayana
                if (a.work.nowcommand == 1 && new ushort[] { 36, 37, 38, 457 }.Contains(a.work.nowindex) || 
                    a.work.nowcommand == 5 && new ushort[] { 1, 2, 3, 4, 9, 10 }.Contains(a.work.nowindex))
                {
                    if (a.work.id == 25) nbMainProcess.nbPushAction(4, a.partyindex, nbMainProcess.nbGetPartyFromFormindex(dformindex).partyindex, 404);
                    else if (a.work.id == 146 && nbMainProcess.nbGetUnitWorkFromFormindex(dformindex).badstatus != 0) nbMainProcess.nbPushAction(4, a.partyindex, nbMainProcess.nbGetPartyFromFormindex(dformindex).partyindex, 416);
                }

                // Doppelganger's Dark Mirror
                if (a.work.id == 0 && a.work.nowcommand == 1 && !pushedSkillList.Contains(a.work.nowindex) && datNormalSkill.tbl[a.work.nowindex].targettype == 0)
                {
                    bool doppelgangerAllyPresent = GetCurrentSideParty(a).Any(x => nbMainProcess.nbGetUnitWorkFromFormindex(x.formindex).id == 225);
                    if (doppelgangerAllyPresent)
                    {
                        DarkMirrorCopy(a.work.nowindex);
                        var doppelgangerParty = a.data.party.First(x => x.partyindex <= 3 && nbMainProcess.nbGetUnitWorkFromFormindex(x.formindex).id == 225);

                        if (datNormalSkill.tbl[a.work.nowindex].targetarea == 2)
                            nbMainProcess.nbPushAction(4, doppelgangerParty.partyindex, nbMainProcess.nbGetPartyFromFormindex(dformindex).partyindex, 417);
                        else if (datNormalSkill.tbl[a.work.nowindex].targetarea == 9 &&
                            datNormalSkill.tbl[a.work.nowindex].targetrule == 0)
                            nbMainProcess.nbPushAction(4, doppelgangerParty.partyindex, nbMainProcess.nbGetPartyFromFormindex(dformindex).partyindex, 417);
                        else if (datNormalSkill.tbl[a.work.nowindex].targetarea == 9 &&
                            datNormalSkill.tbl[a.work.nowindex].targetrule == 1 && !((a.work.nowindex == 224 || a.work.nowindex == 424 || a.work.nowindex == 425) && (doppelgangerParty.count[15] != 0 || doppelgangerParty.count[20] != 0)))
                            nbMainProcess.nbPushAction(4, doppelgangerParty.partyindex, doppelgangerParty.partyindex, 417);
                    }
                    bool doppelgangerEnemyPresent = GetOppositeSideParty(a).Any(x => nbMainProcess.nbGetUnitWorkFromFormindex(x.formindex).id == 225);
                    if (doppelgangerEnemyPresent)
                    {
                        DarkMirrorCopy(a.work.nowindex);
                        foreach(var doppelgangerParty in a.data.party.Where(x => x.partyindex > 3 && nbMainProcess.nbGetUnitWorkFromFormindex(x.formindex).id == 225))
                        {
                            if (datNormalSkill.tbl[a.work.nowindex].targetarea == 2)
                                nbMainProcess.nbPushAction(4, doppelgangerParty.partyindex, a.partyindex, 417);
                            else if (datNormalSkill.tbl[a.work.nowindex].targetarea == 9 &&
                                datNormalSkill.tbl[a.work.nowindex].targetrule == 0)
                                nbMainProcess.nbPushAction(4, doppelgangerParty.partyindex, doppelgangerParty.partyindex, 417);
                            else if (datNormalSkill.tbl[a.work.nowindex].targetarea == 9 &&
                                datNormalSkill.tbl[a.work.nowindex].targetrule == 1 && !((a.work.nowindex == 224 || a.work.nowindex == 424 || a.work.nowindex == 425) && (doppelgangerParty.count[15] != 0 || doppelgangerParty.count[20] != 0)))
                                nbMainProcess.nbPushAction(4, doppelgangerParty.partyindex, doppelgangerParty.partyindex, 417);
                        }
                    }
                }
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetDamagePacket))]
        private class PoisonDamagePatch
        {
            public static void Prefix(ref nbActionProcessData_t a, ref int hp)
            {
                actionProcessData = a;

                if (a.work.badstatus == 64)
                {
                    if (bossList.Contains(a.work.id))
                        hp = Math.Max(a.work.hp / 16, a.work.maxhp / 64);
                }
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datExecSkill))]
        private class OutOfBattleSkillPatch
        {
            public static void Postfix(ref int nskill)
            {
                // If using an hourglass
                if (nskill == 78)
                {
                    int currentPhase = evtMoon.evtGetAgeOfMoon16();
                    if (currentPhase < 8)
                    {
                        // Advance Shige's Excavation
                        if (EventBit.evtBitCheck(1282) && !EventBit.evtBitCheck(1286))
                        {
                            dds3GlobalWork.DDS3_GBWK.fldSave.AnahoriCnt += (8 - currentPhase);
                            if (dds3GlobalWork.DDS3_GBWK.fldSave.AnahoriCnt >= 48 && !EventBit.evtBitCheck(1285))
                                EventBit.evtBitOn(1285);
                            if (dds3GlobalWork.DDS3_GBWK.fldSave.AnahoriCnt >= 112 && EventBit.evtBitCheck(1284))
                                EventBit.evtBitOn(1286);
                            else if (dds3GlobalWork.DDS3_GBWK.fldSave.AnahoriCnt >= 160 && !EventBit.evtBitCheck(1284))
                                EventBit.evtBitOn(1286);
                        }

                        dds3GlobalWork.DDS3_GBWK.Moon.MoveCnt = 0; // Beginning of a new phase
                        evtMoon.evtSetAgeOfMoon(8); // Set Kagutsuchi's phase to full
                    }
                    else if (currentPhase < 16)
                    {
                        // Advance Shige's Excavation
                        if (EventBit.evtBitCheck(1282) && !EventBit.evtBitCheck(1286))
                        {
                            dds3GlobalWork.DDS3_GBWK.fldSave.AnahoriCnt += (16 - currentPhase);
                            if (dds3GlobalWork.DDS3_GBWK.fldSave.AnahoriCnt >= 48 && !EventBit.evtBitCheck(1285))
                                EventBit.evtBitOn(1285);
                            if (dds3GlobalWork.DDS3_GBWK.fldSave.AnahoriCnt >= 112 && EventBit.evtBitCheck(1284))
                                EventBit.evtBitOn(1286);
                            else if (dds3GlobalWork.DDS3_GBWK.fldSave.AnahoriCnt >= 160 && !EventBit.evtBitCheck(1284))
                                EventBit.evtBitOn(1286);
                        }

                        // Clear all effects that last "until a new kagutsuchi"
                        fldMain.fldEsutoMaClearMsg();
                        fldMain.fldRiberaMaClearMsg();
                        fldMain.fldRifutoMaClearMsg();
                        fldMain.fldLightMaClearMsg();

                        dds3GlobalWork.DDS3_GBWK.Moon.MoveCnt = 0; // Beginning of a new phase
                        evtMoon.evtSetAgeOfMoon(0); // Set Kagutsuchi's phase to new
                    }

                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_CLEAR_NORMAL());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_CLEAR_HARD());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_END_SIJIMA());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_END_MUSUBI());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_END_YOSUGA());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_END_GOOD());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_END_BAD());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_END_ALL());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_MAP_ALL());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_USE_TERMINAL1());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_USE_TERMINAL50());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_PLACE_VLTX());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_BATTLE_WIN());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_BATTLE_WEAK100());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_BATTLE_D999());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_BATTLE_BAD_ALL());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_GAMEOVER());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_COM_SUCCESS());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_COM_NAKAMA3());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_AKUMA_GATTAI());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_AKUMA_GATTAI50());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_AKUMA_BOOK_ALL());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_MAGA_GET1());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_MAGA_GETALL());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_MAGA_MASTER());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_MAGA_MASTER_ALL());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_CHR_LVUP());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_CHR_PARAM_MAX_ALL());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_CHR_PARAM_MAX_NAKAMA());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_GIFT100());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_NAKAMA_CHANGE_LVUP());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_NAKAMA_MUTATION_LVUP());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_NAME_ALL());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_DRINK_ALL());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_PB_CLEAR());
                    //Achievement.Unlock(Achievement.achievementTbl.MAIN_PB_CLEAR_ALL());

                    // Test - Add rigged demons to party
                    //dds3GlobalWork.DDS3_GBWK.maka = 0;

                    //var output = Newtonsoft.Json.JsonConvert.SerializeObject(mdlManager.mdlResrcMajorList);
                    ////MelonLogger.Msg(output);

                    //datCalc.datAddMaka(10000000);
                    //datCalc.datAddItem(38, 10);
                    //datCalc.datAddItem(39, 10);
                    //datCalc.datAddItem(40, 10);
                    //datCalc.datAddItem(41, 10);
                    //datCalc.datAddItem(42, 10);
                    //datCalc.datAddItem(43, 10);
                    //datCalc.datAddDevil(23, 0);
                    //datCalc.datAddDevil(7, 0);
                    //datCalc.datAddDevil(104, 0);
                    //datCalc.datAddDevil(230, 0);

                    //if (dds3GlobalWork.DDS3_GBWK.unitwork.Where(x => x.id == 56).Count() == 0)
                    //{
                    //datCalc.datAddDevil(56, 0);
                    //}
                    foreach (datUnitWork_t work in dds3GlobalWork.DDS3_GBWK.unitwork.Where(x => x.id == 0)) // Demi-fiend
                    {
                        //work.param[0] = 98;
                        //work.param[1] = 98;
                        //work.param[2] = 98;
                        //work.param[3] = 98;
                        //work.param[4] = 98;
                        //work.param[5] = 98;
                        //work.skill[0] = 226;
                        //work.badstatus = 32768;
                        //work.level = 95;
                        //work.exp = rstCalcCore.GetNextExpDisp(work, 0) - 1;
                    }
                    //foreach (datUnitWork_t work in dds3GlobalWork.DDS3_GBWK.unitwork.Where(x => x.id == 61)) // Pixie
                    //{
                    //    work.exp = rstCalcCore.GetNextExpDisp(work, 0) - 1;
                    //}
                    //foreach (datUnitWork_t work in dds3GlobalWork.DDS3_GBWK.unitwork.Where(x => x.id == 59)) // High Pixie
                    //{
                    //    work.level = 15;
                    //    work.exp = rstCalcCore.GetNextExpDisp(work, 0) - 1;
                    //}
                    //}
                    //}
                }
                // If using a cursed gospel
                if (nskill == 91)
                {

                    // Grab Demi-Fiend and check his Level.
                    // If it's 1 or lower, return and run the original function.
                    datUnitWork_t work = dds3GlobalWork.DDS3_GBWK.unitwork[0];

                    if (work.level > 1)
                    {
                        // Lower Level by 1.
                        work.level--;

                        // Set EXP needed to exactly 1 before the next level.
                        work.exp = rstCalcCore.GetNextExpDisp(work, 0) - 1;

                        // Create a list of Stat IDs, then remove 1 if EnableIntStat is false.
                        List<int> statlist = new List<int> { 0, 1, 2, 3, 4, 5 };
                        if (!EnableIntStat)
                        { statlist.Remove(1); }

                        // Iterate through Stats and reduce them at random a number of times equal to the current Stat points per level.
                        // If EnableStatScaling is false, it's just 1 point.
                        int changes = 1 * (EnableStatScaling ? POINTS_PER_LEVEL : 1);
                        System.Random rng = new();
                        while (changes > 0 && statlist.Count > 0)
                        {
                            // Randomize the Stat ID.
                            int statID = statlist[rng.Next(statlist.Count)];

                            // If the Base Stat is over 1, decrement it and the change count.
                            if (work.param[statID] - tblHearts.fclHeartsTbl[dds3GlobalWork.DDS3_GBWK.heartsequip].GrowParamTbl[statID] > 1)
                            {
                                work.param[statID]--;
                                changes--;
                            }

                            // Remove anything that can't be reduced from being potentially chosen again.
                            else
                            { statlist.Remove(statID); }
                        }

                        // Fix HP/MP calculations.
                        work.maxhp = (ushort)datCalc.datGetMaxHp(work);
                        work.maxmp = (ushort)datCalc.datGetMaxMp(work);
                        work.hp = (ushort)Math.Clamp(work.hp, 0u, work.maxhp);
                        work.mp = (ushort)Math.Clamp(work.mp, 0u, work.maxmp);

                        // Set Demi-Fiend's object to the changed unit.
                        dds3GlobalWork.DDS3_GBWK.unitwork[0] = work;
                    }
                }
            }
        }

        [HarmonyPatch(typeof(nbHelpProcess), nameof(nbHelpProcess.nbDispText))]
        private class DispTextPatch
        {
            public static void Prefix(ref string text1, ref string text2, ref int type, int max, uint col)
            {
                try
                {
                    if (type == 1 && actionProcessData.work.nowcommand == 1)
                    {
                        switch (actionProcessData.work.nowindex)
                        {
                            case 54: // Rakunda
                                {
                                    type = 0;
                                    var limitReached = true;
                                    foreach (var unitBuffs in currentSideBuffs)
                                    {
                                        if (unitBuffs[7] >= -2)
                                            limitReached = false;
                                    }
                                    text1 = limitReached ? "Limit reached!" : "Decreased enemy's Defense!";
                                    break;
                                }
                            case 64: // Tarukaja
                                {
                                    type = 0;
                                    var limitReached = true;
                                    foreach (var unitBuffs in currentSideBuffs)
                                    {
                                        if (unitBuffs[4] <= 2 || unitBuffs[5] <= 2)
                                            limitReached = false;
                                    }
                                    text1 = limitReached ? "Limit reached!" : "Physical/Magical Attack increased!";
                                    break;
                                }
                            case 67: // Makakaja
                                {
                                    type = 0;
                                    var limitReached = true;
                                    foreach (var unitBuffs in currentSideBuffs)
                                    {
                                        if (unitBuffs[5] <= 2 || unitBuffs[8] <= 2)
                                            limitReached = false;
                                    }
                                    text1 = limitReached ? "Limit reached!" : "Magical Attack/Hit Rate increased!";
                                    break;
                                }
                            case 206: // Debilitate
                                {
                                    if (text1 == "Decreased all stats performance!")
                                        text1 = "All stats decreased!";
                                    break;
                                }
                            case 276: // Red Capote
                                {
                                    type = 0;
                                    var limitReached = true;
                                    if (currentUnitBuffs[6] <= 2 || currentUnitBuffs[8] <= 2)
                                        limitReached = false;
                                    text1 = limitReached ? "Limit reached!" : "Evasion/Hit Rate maximized!";
                                    break;
                                }
                            default: break;
                        }
                    }
                } catch { }
            }
        }

        [HarmonyPatch(typeof(itfMesManager), nameof(itfMesManager.itfMesMngGetStrImmediate))]
        private class itfMesMngGetStrImmediatePatch
        {
            public static void Postfix(ref int id, ref int message, ref int page, ref string __result)
            {
                if (nbMainProcess.nbGetMainProcessData().enemyunit[0].nowindex == 497 && __result == "Dante appeared! ")
                {
                    __result = "Dante transformed! ";
                }
            }
        }

        [HarmonyPatch(typeof(nbUnitProcess), nameof(nbUnitProcess.nbSummonUnit))]
        private class nbSummonUnitPatch
        {
            public static void Prefix(ref int side, ref int stockno, ref int formindex)
            {
                // Dismiss Dante when summoning Devil Dante
                if (formindex == 6 && actionProcessData.work.nowindex == 497)
                {
                    nbUnitProcess.nbReturnUnit(4, 0, 0);
                    nbMakePacket.nbAddNewPressPacket(0, 0, -10, -10);
                }
                // Remove additional turns after Foul Gathering
                else if ((actionProcessData.work.id == 257 || actionProcessData.work.id == 273 || actionProcessData.work.id == 275)
                    && actionProcessData.work.nowindex == 252)
                {
                    nbMakePacket.nbAddNewPressPacket(0, 0, -10, -10);
                }
            }
        }

        [HarmonyPatch(typeof(effModelTrackPoly), nameof(effModelTrackPoly.Eff_ModelTrackPoly_DANTE_Check))]
        private class Eff_ModelTrackPoly_DANTE_CheckPatch
        {
            public static void Postfix(ref dds3ModelHandle_t hModel, ref int __result)
            {
                if (mdlManager.mdlGetMajorNum(ref hModel) == 1 && mdlManager.mdlGetMinorNum(ref hModel) == 252)
                    __result = 1;
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetAisyoRitu))]
        private class GetAisyoRituPatch
        {
            public static void Postfix(ref int nskill, ref int sformindex, ref int dformindex, ref float __result)
            {
                var skillattr = datSkill.tbl[nskill].skillattr;
                var workFromFormindex1 = nbMainProcess.nbGetUnitWorkFromFormindex(sformindex);
                var workFromFormindex2 = nbMainProcess.nbGetUnitWorkFromFormindex(dformindex);

                // Element Melody
                if (melodyUsers.ContainsKey(skillattr) && nbCalc.nbGetAisyo(nskill, dformindex, skillattr) >= 2147483778)
                {
                    bool elementMelodyActive = false;

                    if (nbMainProcess.nbGetPartyFromFormindex(sformindex).partyindex <= 3)
                    {
                        foreach (var ally in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3))
                        {
                            try
                            {
                                if (melodyUsers[skillattr].Contains(nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id))
                                {
                                    elementMelodyActive = true; break;
                                }
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        foreach (var enemy in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex > 3))
                        {
                            try
                            {
                                if (melodyUsers[skillattr].Contains(nbMainProcess.nbGetUnitWorkFromFormindex(enemy.formindex).id))
                                {
                                    elementMelodyActive = true; break;
                                }
                            }
                            catch { }
                        }
                    }
                    if (elementMelodyActive) __result = __result * 1.1f;
                }
                // Magnified Malady
                if (workFromFormindex2.badstatus != 0)
                {
                    bool magnifiedMaladyActive = false;

                    if (nbMainProcess.nbGetPartyFromFormindex(sformindex).partyindex <= 3)
                    {
                        foreach (var ally in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3))
                        {
                            try
                            {
                                if (magnifiedMaladyIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id) ||
                                    (ally.formindex == 0 && nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id == 0 && dds3GlobalWork.DDS3_GBWK.heartsequip == 17))
                                {
                                    magnifiedMaladyActive = true; break;
                                }
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        foreach (var enemy in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex > 3))
                        {
                            try
                            {
                                if (magnifiedMaladyIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(enemy.formindex).id))
                                {
                                    magnifiedMaladyActive = true; break;
                                }
                            }
                            catch { }
                        }
                    }
                    if (magnifiedMaladyActive) __result = __result * 1.2f;
                }
                // Underdog
                if (workFromFormindex1.id == 204 || workFromFormindex1.id == 283)
                {
                    var missingHP = (workFromFormindex1.maxhp - workFromFormindex1.hp) / workFromFormindex1.maxhp;
                    __result = __result * (1 + (missingHP * 0.3f));
                }
                // Desperate Power
                else if (workFromFormindex1.id == 205 || workFromFormindex1.id == 299)
                {
                    var missingMP = (workFromFormindex1.maxmp - workFromFormindex1.mp) / workFromFormindex1.maxmp;
                    __result = __result * (1 + (missingMP * 0.3f));
                }
                // Moirae Cutter
                else
                {
                    bool clothoPresent = false;
                    bool lachesisPresent = false;
                    bool atroposPresent = false;

                    if (nbMainProcess.nbGetPartyFromFormindex(sformindex).partyindex <= 3)
                    {
                        foreach (var ally in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3))
                        {
                            try
                            {
                                if (nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id == 173) clothoPresent = true;
                                else if (nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id == 174) lachesisPresent = true;
                                else if (nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id == 175) atroposPresent = true;
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        foreach (var enemy in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex > 3))
                        {
                            try
                            {
                                if (nbMainProcess.nbGetUnitWorkFromFormindex(enemy.formindex).id == 326) clothoPresent = true;
                                else if (nbMainProcess.nbGetUnitWorkFromFormindex(enemy.formindex).id == 327) lachesisPresent = true;
                                else if (nbMainProcess.nbGetUnitWorkFromFormindex(enemy.formindex).id == 328) atroposPresent = true;
                            }
                            catch { }
                        }
                    }

                    if (clothoPresent && lachesisPresent && atroposPresent) __result = __result * 1.1f;
                }

                switch (skillattr)
                {
                    case 0:
                        {
                            if (datCalc.datCheckSyojiSkill(workFromFormindex1, 361) != 0)
                            {
                                __result = (__result / 1.5f) * 1.3f;
                            }
                            else if (datCalc.datCheckSyojiSkill(workFromFormindex1, 362) != 0)
                            {
                                __result = __result * 1.3f;
                            }
                            break;
                        }
                    case 1:
                        {
                            if (datCalc.datCheckSyojiSkill(workFromFormindex1, 309) != 0 || datCalc.datCheckSyojiSkill(workFromFormindex1, 361) != 0)
                            {
                                __result = (__result / 1.5f) * 1.3f;
                            }
                            else if (datCalc.datCheckSyojiSkill(workFromFormindex1, 363) != 0)
                            {
                                __result = __result * 1.3f;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (datCalc.datCheckSyojiSkill(workFromFormindex1, 310) != 0 || datCalc.datCheckSyojiSkill(workFromFormindex1, 361) != 0)
                            {
                                __result = (__result / 1.5f) * 1.3f;
                            }
                            else if (datCalc.datCheckSyojiSkill(workFromFormindex1, 363) != 0)
                            {
                                __result = __result * 1.3f;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (datCalc.datCheckSyojiSkill(workFromFormindex1, 311) != 0 || datCalc.datCheckSyojiSkill(workFromFormindex1, 361) != 0)
                            {
                                __result = (__result / 1.5f) * 1.3f;
                            }
                            else if (datCalc.datCheckSyojiSkill(workFromFormindex1, 363) != 0)
                            {
                                __result = __result * 1.3f;
                            }
                            break;
                        }
                    case 4:
                        {
                            if (datCalc.datCheckSyojiSkill(workFromFormindex1, 312) != 0 || datCalc.datCheckSyojiSkill(workFromFormindex1, 361) != 0)
                            {
                                __result = (__result / 1.5f) * 1.3f;
                            }
                            else if (datCalc.datCheckSyojiSkill(workFromFormindex1, 363) != 0)
                            {
                                __result = __result * 1.3f;
                            }
                            break;
                        }
                    case 12:
                        {
                            if (datCalc.datCheckSyojiSkill(workFromFormindex1, 373) != 0)
                            {
                                __result = __result * 1.3f;
                            }
                            break;
                        }
                    default: break;
                }

                // Girimekhala's Behemothic Bounce
                if (behemothicBounceIds.Contains(workFromFormindex2.id) && workFromFormindex2.badstatus != 2 && nbCalc.nbGetAisyo(nskill, dformindex, skillattr) == 131072)
                    __result = __result * 3;
            }
        }

        [HarmonyPatch(typeof(SoundManager), nameof(SoundManager._PlaySE_Core))]
        private class _PlaySE_CorePatch
        {
            public static bool Prefix(ref AudioClip audioClip, ref bool loop, ref float volume, ref float pan, ref string name, ref int id, ref int __result)
            {
                if (name == "BSE_SE02" && actionProcessData.work.nowcommand == 1 && (actionProcessData.work.nowindex == 165 || actionProcessData.work.nowindex == 166))
                {
                    __result = -1;
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(nbMakePacket), nameof(nbMakePacket.nbMakeDamagePacket))]
        private class RunSeKoukaPatch
        {
            public static void Postfix()
            {
                if (actionProcessData.work.nowcommand == 1 && actionProcessData.work.nowindex == 167)
                {
                    nbSound.nbPlaySe("BSE_SE02");
                }
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetNormalSkillAttr))]
        private class nbGetNormalSkillAttrPatch
        {
            public static void Postfix(ref int nskill, ref int __result)
            {
                if (nskill == 167 && datDevilFormat.tbl[currentDemonWork.id].attackattr != 0)
                    __result = datDevilFormat.tbl[currentDemonWork.id].attackattr;
            }
        }

        [HarmonyPatch(typeof(nbMainProcess), nameof(nbMainProcess.nbSetPhase))]
        private class nbSetPhasePatch
        {
            public static void Postfix(ref int phase)
            {
                ////MelonLogger.Msg("--nbMainProcess.nbSetPhase--");
                //try
                //{
                //    //MelonLogger.Msg("phase: " + phase);
                //    //MelonLogger.Msg("demon: " + datDevilName.Get(actionProcessData.work.id));
                //    //MelonLogger.Msg("nowcommand: " + actionProcessData.work.nowcommand);
                //    //MelonLogger.Msg("nowindex: " + actionProcessData.work.nowindex);
                //    //MelonLogger.Msg("partyindex: " + actionProcessData.partyindex);
                //    //MelonLogger.Msg("nowtform: " + actionProcessData.work.nowtform);
                //    //MelonLogger.Msg("type: " + actionProcessData.type);
                //    //MelonLogger.Msg("target: " + actionProcessData.target);
                //}
                //catch { }

                if (phase == 7)
                {
                    for (int i = 0; i <= 16; i++)
                    {
                        try
                        {
                            activeUnitIds[i] = nbMainProcess.nbGetUnitWorkFromFormindex(i).id;
                            activeUnitPartyCount[i] = nbMainProcess.nbGetPartyFromFormindex(i).count;
                        }
                        catch { }
                    }
                }
                if (phase == 8)
                {
                    try
                    {
                        // After Summon
                        if (actionProcessData.work.nowcommand == 6 || (actionProcessData.work.nowcommand == 1 && actionProcessData.work.nowindex == 223))
                        {
                            // Arahabaki's Affable Hospitality
                            if (activeUnitIds.Contains((ushort) 144))
                            {
                                bool affableHospitalityActive = false;
                                var arahabakiParty = new nbParty_t();
                                foreach (var ally in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3))
                                {
                                    try
                                    {
                                        if (nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id == 144 && nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).badstatus != 32)
                                        {
                                            affableHospitalityActive = true;
                                            arahabakiParty = nbMainProcess.nbGetPartyFromFormindex(ally.formindex);
                                        }
                                    }
                                    catch { }
                                }

                                if (affableHospitalityActive)
                                {
                                    var incomingParty = nbMainProcess.nbGetPartyFromFormindex(actionProcessData.work.nowtform);
                                    bool activate = false;
                                    for (short i = 4; i <= 14; i++)
                                    {
                                        incomingParty.count[i] = Math.Max((short)0, arahabakiParty.count[i]);
                                        if (arahabakiParty.count[i] != 0) activate = true;
                                    }
                                    if (activate)
                                    {
                                        switchOutSkillName2 = "Affable Hospitality";
                                        SwitchOutSkillCopy2(67, 67, 0, false);
                                        nbMainProcess.nbPushAction(4, arahabakiParty.partyindex, incomingParty.partyindex, 406);
                                    }
                                }
                            }
                            // Daisoujou's Guiding Wisdom
                            else if (activeUnitIds.Contains((ushort)201))
                            {
                                bool guidingWisdomActive = false;
                                var daisoujouParty = new nbParty_t();
                                foreach (var ally in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3))
                                {
                                    try
                                    {
                                        if (nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id == 201)
                                        {
                                            guidingWisdomActive = true;
                                            daisoujouParty = nbMainProcess.nbGetPartyFromFormindex(ally.formindex);
                                        }
                                    }
                                    catch { }
                                }

                                if (guidingWisdomActive)
                                {
                                    switchOutSkillName2 = "Guiding Wisdom";
                                    SwitchOutSkillCopy2(416, 416, 0, false);
                                    var incomingParty = nbMainProcess.nbGetPartyFromFormindex(actionProcessData.work.nowtform);
                                    nbMainProcess.nbPushAction(4, daisoujouParty.partyindex, incomingParty.partyindex, 406);
                                }
                            }
                            if (actionProcessData.work.id != 0 && actionProcessData.work.nowcommand == 6)
                            {
                                // Odin's Runes of Wisdom
                                if (actionProcessData.work.id == 4 || (actionProcessData.work.id == 0 && activeUnitIds[actionProcessData.work.nowtform] == 4))
                                {
                                    var party = nbMainProcess.nbGetPartyFromFormindex(actionProcessData.work.nowtform);
                                    switchOutSkillName = "Runes Of Wisdom";
                                    SwitchOutSkillCopy(224, 224, 0, true);
                                    nbMainProcess.nbPushAction(4, party.partyindex, party.partyindex, 407);
                                }
                                // Horus' Eye of Horus
                                else if (actionProcessData.work.id == 6 || (actionProcessData.work.id == 0 && activeUnitIds[actionProcessData.work.nowtform] == 6))
                                {
                                    var party = nbMainProcess.nbGetPartyFromFormindex(actionProcessData.work.nowtform);
                                    switchOutSkillName = "Eye of Horus";
                                    SwitchOutSkillCopy(424, 424, 0, true);
                                    nbMainProcess.nbPushAction(4, party.partyindex, party.partyindex, 407);
                                }
                                // Ame-no-Uzume's Curious Dance
                                else if (actionProcessData.work.id == 11 || (actionProcessData.work.id == 0 && activeUnitIds[actionProcessData.work.nowtform] == 11))
                                {
                                    var outgoingParty = activeUnitPartyCount[actionProcessData.work.nowtform];
                                    var incomingParty = nbMainProcess.nbGetPartyFromFormindex(actionProcessData.work.nowtform);
                                    bool activate = false;
                                    for (short i = 4; i <= 8; i++)
                                    {
                                        incomingParty.count[i] = outgoingParty[i];
                                        if (incomingParty.count[i] != 0) activate = true;
                                    }
                                    if (activate)
                                    {
                                        switchOutSkillName = "Curious Dance";
                                        SwitchOutSkillCopy(67, 67, 0, false);
                                        nbMainProcess.nbPushAction(4, incomingParty.partyindex, incomingParty.partyindex, 407);
                                    }
                                }
                                // Kushinada-Hime's Monstrous Offering
                                else if ((actionProcessData.work.id == 19 || (actionProcessData.work.id == 0 && activeUnitIds[actionProcessData.work.nowtform] == 19))
                                    && datDevilFormat.tbl[nbMainProcess.nbGetUnitWorkFromFormindex(actionProcessData.work.nowtform).id].race == 3)
                                {
                                    var outgoingParty = activeUnitPartyCount[actionProcessData.work.nowtform];
                                    var incomingParty = nbMainProcess.nbGetPartyFromFormindex(actionProcessData.work.nowtform);
                                    bool activate = false;
                                    for (short i = 4; i <= 20; i++)
                                    {
                                        if (!(i >= 16 && i <= 19))
                                        {
                                            incomingParty.count[i] = Math.Max((short)0, outgoingParty[i]);
                                            if (incomingParty.count[i] != 0) activate = true;
                                        }
                                    }
                                    if (activate)
                                    {
                                        switchOutSkillName = "Monstrous Offering";
                                        SwitchOutSkillCopy(67, 67, 0, false);
                                        nbMainProcess.nbPushAction(4, incomingParty.partyindex, incomingParty.partyindex, 407);
                                    }
                                }
                                // Titania's Seelie Decree
                                else if ((actionProcessData.work.id == 53 || (actionProcessData.work.id == 0 && activeUnitIds[actionProcessData.work.nowtform] == 53))
                                    && datDevilFormat.tbl[nbMainProcess.nbGetUnitWorkFromFormindex(actionProcessData.work.nowtform).id].race == 10)
                                {
                                    var outgoingParty = activeUnitPartyCount[actionProcessData.work.nowtform];
                                    var incomingParty = nbMainProcess.nbGetPartyFromFormindex(actionProcessData.work.nowtform);
                                    bool activate = false;
                                    for (short i = 4; i <= 20; i++)
                                    {
                                        if (!(i >= 16 && i <= 19))
                                        {
                                            incomingParty.count[i] = Math.Max((short)0, outgoingParty[i]);
                                            if (incomingParty.count[i] != 0) activate = true;
                                        }
                                    }
                                    if (activate)
                                    {
                                        switchOutSkillName = "Seelie Decree";
                                        SwitchOutSkillCopy(67, 67, 0, false);
                                        nbMainProcess.nbPushAction(4, incomingParty.partyindex, incomingParty.partyindex, 407);
                                    }
                                }
                                // Queen Mab's Unseelie Decree
                                else if ((actionProcessData.work.id == 116 || (actionProcessData.work.id == 0 && activeUnitIds[actionProcessData.work.nowtform] == 116))
                                    && datDevilFormat.tbl[nbMainProcess.nbGetUnitWorkFromFormindex(actionProcessData.work.nowtform).id].race == 20)
                                {
                                    var outgoingParty = activeUnitPartyCount[actionProcessData.work.nowtform];
                                    var incomingParty = nbMainProcess.nbGetPartyFromFormindex(actionProcessData.work.nowtform);
                                    bool activate = false;
                                    for (short i = 4; i <= 20; i++)
                                    {
                                        if (!(i >= 16 && i <= 19))
                                        {
                                            incomingParty.count[i] = Math.Max((short)0, outgoingParty[i]);
                                            if (incomingParty.count[i] != 0) activate = true;
                                        }
                                    }
                                    if (activate)
                                    {
                                        switchOutSkillName = "Unseelie Decree";
                                        SwitchOutSkillCopy(67, 67, 0, false);
                                        nbMainProcess.nbPushAction(4, incomingParty.partyindex, incomingParty.partyindex, 407);
                                    }
                                }
                                // Four Horsemen
                                else if ((fourHorsemenIds.Contains(actionProcessData.work.id) || (actionProcessData.work.id == 0 && fourHorsemenIds.Contains(activeUnitIds[actionProcessData.work.nowtform])))
                                    && fourHorsemenIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(actionProcessData.work.nowtform).id))
                                {
                                    var outgoingParty = activeUnitPartyCount[actionProcessData.work.nowtform];
                                    var incomingParty = nbMainProcess.nbGetPartyFromFormindex(actionProcessData.work.nowtform);
                                    bool activate = false;
                                    for (short i = 4; i <= 20; i++)
                                    {
                                        if (!(i >= 16 && i <= 19))
                                        {
                                            incomingParty.count[i] = Math.Max((short)0, outgoingParty[i]);
                                            if (incomingParty.count[i] != 0) activate = true;
                                        }
                                    }
                                    if (activate)
                                    {
                                        switchOutSkillName = "Four Horsemen";
                                        SwitchOutSkillCopy(67, 67, 0, false);
                                        nbMainProcess.nbPushAction(4, incomingParty.partyindex, incomingParty.partyindex, 407);
                                    }
                                }
                            }
                            // Oberon's Fairy King's Melody
                            if (nbMainProcess.nbGetUnitWorkFromFormindex(actionProcessData.work.nowtform).id == 54)
                            {
                                var party = nbMainProcess.nbGetPartyFromFormindex(actionProcessData.work.nowtform);
                                postSummonSkillName = "Fairy King's Melody";
                                PostSummonSkillCopy(77, 77, 1);
                                nbMainProcess.nbPushAction(4, party.partyindex, party.partyindex, 408);
                            }
                            // Four Devas
                            if (fourDevasIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(actionProcessData.work.nowtform).id))
                            {
                                var party = nbMainProcess.nbGetPartyFromFormindex(actionProcessData.work.nowtform);
                                postSummonSkillName = "Four Devas";
                                PostSummonSkillCopy(459, 64, 1);
                                nbMainProcess.nbPushAction(4, party.partyindex, party.partyindex, 408);

                                //var party = nbMainProcess.nbGetPartyFromFormindex(actionProcessData.work.nowtform);
                                //foreach (var ally in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3))
                                //{
                                //    try
                                //    {
                                //        if (fourDevasIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id))
                                //        {
                                //            postSummonSkillName = "Four Devas";
                                //            PostSummonSkillCopy(459, 64, 0);
                                //            nbMainProcess.nbPushAction(4, party.partyindex, ally.partyindex, 408);
                                //        }
                                //    } catch { }
                                //}
                            }
                        }
                        // After any other action: Renewal, Spirit Well, Qigong
                        else if ((!(actionProcessData.work.nowcommand == 1 && pushedSkillList.Contains(actionProcessData.work.nowindex)) &&
                            !(actionProcessData.work.nowcommand == 3 && actionProcessData.work.nowindex == 0) && 
                            !(actionProcessData.work.nowcommand == 7 && actionProcessData.work.nowindex == 0))
                            && actionProcessData.work.badstatus != 32)
                        {
                            if (datCalc.datCheckSyojiSkill(actionProcessData.work, 370) != 0 ||
                                (actionProcessData.work.id == 70 && // Decarabia's Kept Waiting
                                ((actionProcessData.partyindex <= 3 && nbMainProcess.nbGetMainProcessData().party.Any(x => x.partyindex <= 3 && nbMainProcess.nbGetUnitWorkFromFormindex(x.formindex).id == 74)) ||
                                (actionProcessData.partyindex > 3 && nbMainProcess.nbGetMainProcessData().party.Any(x => x.partyindex > 3 && nbMainProcess.nbGetUnitWorkFromFormindex(x.formindex).id == 74)))))
                                nbMainProcess.nbPushAction(4, actionProcessData.partyindex, actionProcessData.partyindex, 150);
                            else
                            {
                                if (datCalc.datCheckSyojiSkill(actionProcessData.work, 368) != 0 &&
                                    datCalc.datCheckSyojiSkill(actionProcessData.work, 369) != 0)
                                    nbMainProcess.nbPushAction(4, actionProcessData.partyindex, actionProcessData.partyindex, 151);
                                else if (datCalc.datCheckSyojiSkill(actionProcessData.work, 368) != 0)
                                    nbMainProcess.nbPushAction(4, actionProcessData.partyindex, actionProcessData.partyindex, 148);
                                else if (datCalc.datCheckSyojiSkill(actionProcessData.work, 369) != 0)
                                    nbMainProcess.nbPushAction(4, actionProcessData.partyindex, actionProcessData.partyindex, 149);
                                else if (actionProcessData.work.id == 252)
                                    nbMainProcess.nbPushAction(4, actionProcessData.partyindex, actionProcessData.partyindex, 496);
                            }
                        }

                        if (actionProcessData.work.nowcommand == 1 && actionProcessData.work.nowindex == 221)
                        {
                            foreach (var party in actionProcessData.data.party)
                            {
                                for (int i = 4; i <= 8; i++)
                                {
                                    if (party.count[i] != 0)
                                        party.count[i] = 0;
                                }

                                nbHelpProcess.nbDispText("All -kaja & -nda effects negated!", string.Empty, 2, 45, 2315190144, false);
                            }
                        }

                        if (actionProcessData.work.nowcommand == 1 && actionProcessData.work.nowindex == 241)
                        {
                            foreach (var party in actionProcessData.data.party.Where(x => x.formindex <= 3))
                            {
                                for (int i = 4; i <= 8; i++)
                                {
                                    if (party.count[i] > 0)
                                        party.count[i] = 0;
                                }

                                nbHelpProcess.nbDispText("All -kaja effects negated!", string.Empty, 2, 45, 2315190144, false);
                            }
                        }

                        if (actionProcessData.work.nowcommand == 1 && actionProcessData.work.nowindex == 272)
                        {
                            foreach (var party in actionProcessData.data.party)
                            {
                                for (int i = 4; i <= 8; i++)
                                {
                                    if (party.count[i] <= 3 && party.count[i] > 0)
                                        party.count[i]--;
                                    else if (party.count[i] >= -3 && party.count[i] < 0)
                                        party.count[i]++;
                                }
                            }

                            actionProcessData.data.press4_p = 0;
                            actionProcessData.data.press4_ten = 0;
                        }
                    } catch { }

                    helmsmanActive = (helmsmanIds.Contains(actionProcessData.work.id) &&
                        !(actionProcessData.work.nowcommand == 1 && pushedSkillList.Contains(actionProcessData.work.nowindex)) &&
                        !(actionProcessData.work.nowcommand == 3 && actionProcessData.work.nowindex == 0))
                        ? true : false;

                    if (!faithfulCompanionActive2)
                        faithfulCompanionActive = false;
                    faithfulCompanionActive2 = false;

                    previousUnitId = actionProcessData.work.id;
                    previousSingleTargetFormIndex = (actionProcessData.work.nowcommand == 0 && actionProcessData.work.nowindex == 0) ||
                        (actionProcessData.work.nowcommand == 1 && datNormalSkill.tbl[actionProcessData.work.nowindex].targetarea == 2 && datNormalSkill.tbl[actionProcessData.work.nowindex].targettype == 0) ||
                        (actionProcessData.work.nowcommand == 5 && datNormalSkill.tbl[datItem.tbl[actionProcessData.work.nowindex].skillid].targetarea == 2 && datNormalSkill.tbl[datItem.tbl[actionProcessData.work.nowindex].skillid].targettype == 0)
                        ? actionProcessData.work.nowtform
                        : (short) -1;
                }
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetAction_SKILL))]
        private class SetAction_SKILLPatch
        {
            public static void Prefix(ref nbActionProcessData_t a)
            {
                ////MelonLogger.Msg("--nbActionProcess.SetAction_SKILL--");
                ////MelonLogger.Msg("select: " + a.select);

                // Set Oberon's Fairy King's Melody to target the whole party
                if (a.work.id == 54 & a.work.nowcommand == 1 && a.work.nowindex == 408)
                {
                    uint newSelect = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        try
                        {
                            var work = nbMainProcess.nbGetUnitWorkFromFormindex(i);
                            if (work.id != -1)
                                newSelect += Convert.ToUInt32(Math.Pow(2, i));
                        }
                        catch { }
                    }
                    if (datNormalSkill.tbl[408].targettype == 1)
                    {
                        a.select = newSelect;
                    }
                }
                // Set Four Devas to target all Four Devas targets
                if (fourDevasIds.Contains(a.work.id) & a.work.nowcommand == 1 && a.work.nowindex == 408)
                {
                    uint newSelect = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        try
                        {
                            var work = nbMainProcess.nbGetUnitWorkFromFormindex(i);
                            if (fourDevasIds.Contains(work.id))
                                newSelect += Convert.ToUInt32(Math.Pow(2, i));
                        }
                        catch { }
                    }
                    if (datNormalSkill.tbl[408].targettype == 1)
                    {
                        a.select = newSelect;
                    }
                }
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetHpDrainRitu))]
        private class nbGetHpDrainRituPatch
        {
            public static void Postfix(ref int nskill, ref int sformindex, ref int dformindex, ref float __result)
            {
                // Essence Thief
                if (!essenceThiefIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(sformindex).id)) __result *= 0.5f;
            }
        }
        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetMpDrainRitu))]
        private class nbGetMpDrainRituPatch
        {
            public static void Postfix(ref int nskill, ref int sformindex, ref int dformindex, ref float __result)
            {
                // Essence Thief
                if (!essenceThiefIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(sformindex).id)) __result *= 0.5f;
            }
        }


        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetDeadPacket))]
        private class SetDeadPacketPatch
        {
            public static void Postfix(ref nbActionProcessData_t a, ref int formindex)
            {
                var work = nbMainProcess.nbGetUnitWorkFromFormindex(formindex);
                var party = nbMainProcess.nbGetPartyFromFormindex(formindex);

                if (work.id > 383)
                    return;

                if (retributiveZealRaces.Contains(datDevilFormat.tbl[work.id].race))
                {
                    if (party.partyindex <= 3)
                    {
                        foreach (var ally in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3 && x.partyindex != party.partyindex))
                        {
                            try
                            {
                                if (retributiveZealIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(ally.formindex).id))
                                    nbMainProcess.nbPushAction(4, ally.partyindex, ally.partyindex, 405);
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        foreach (var enemy in nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex > 3 && x.partyindex != party.partyindex))
                        {
                            try
                            {
                                if (retributiveZealIds.Contains(nbMainProcess.nbGetUnitWorkFromFormindex(enemy.formindex).id))
                                    nbMainProcess.nbPushAction(4, enemy.partyindex, enemy.partyindex, 405);
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        private static nbParty_t[] GetCurrentSideParty(nbActionProcessData_t a)
        {
            if (a.partyindex <= 3)
                return a.data.party.Where(x => x.partyindex <= 3 && x.flag != 0).ToArray();
            else
                return a.data.party.Where(x => x.partyindex > 3 && x.flag != 0).ToArray();
        }

        private static nbParty_t[] GetOppositeSideParty(nbActionProcessData_t a)
        {
            if (a.partyindex <= 3)
                return a.data.party.Where(x => x.partyindex > 3 && x.flag != 0).ToArray();
            else
                return a.data.party.Where(x => x.partyindex <= 3 && x.flag != 0).ToArray();
        }

        //------------------------------------------------------------

        private static void OverWriteSkillEffect(ushort targetId, ushort originId)
        {
            datNormalSkillVisual.tbl[targetId] = new datNormalSkillVisual_t { 
                motion = datNormalSkillVisual.tbl[originId].motion,
                animetype = datNormalSkillVisual.tbl[originId].animetype,
                hatudo = datNormalSkillVisual.tbl[originId].hatudo,
                bedno = datNormalSkillVisual.tbl[originId].bedno
            };
            nbActionProcess.sobedtbl[targetId] = new nbActionProcess.SOBED {
                keyname = nbActionProcess.sobedtbl[originId].keyname,
                bed_fname = nbActionProcess.sobedtbl[originId].bed_fname,
                se0_str = nbActionProcess.sobedtbl[originId].se0_str,
                se1_str = nbActionProcess.sobedtbl[originId].se1_str,
                tga_fname = nbActionProcess.sobedtbl[originId].tga_fname,
                pbdata = nbActionProcess.sobedtbl[originId].pbdata
            };
            nbCamera_SkillPtrTable.tbl[targetId] = new nbCameraSkillPtr_t {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[originId].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[originId].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[originId].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[originId].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[originId].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[originId].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[originId].anim
            };
        }

        private static void OverWriteSkillEffect(ushort targetId, ushort animOriginId, ushort effectOriginId)
        {
            datNormalSkillVisual.tbl[targetId] = new datNormalSkillVisual_t
            {
                motion = datNormalSkillVisual.tbl[animOriginId].motion,
                animetype = datNormalSkillVisual.tbl[animOriginId].animetype,
                hatudo = datNormalSkillVisual.tbl[animOriginId].hatudo,
                bedno = datNormalSkillVisual.tbl[animOriginId].bedno
            };
            nbActionProcess.sobedtbl[targetId] = new nbActionProcess.SOBED
            {
                keyname = nbActionProcess.sobedtbl[effectOriginId].keyname,
                bed_fname = nbActionProcess.sobedtbl[effectOriginId].bed_fname,
                se0_str = nbActionProcess.sobedtbl[effectOriginId].se0_str,
                se1_str = nbActionProcess.sobedtbl[effectOriginId].se1_str,
                tga_fname = nbActionProcess.sobedtbl[effectOriginId].tga_fname,
                pbdata = nbActionProcess.sobedtbl[effectOriginId].pbdata
            };
            nbCamera_SkillPtrTable.tbl[targetId] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[effectOriginId].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[effectOriginId].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[effectOriginId].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[effectOriginId].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[effectOriginId].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[effectOriginId].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[effectOriginId].anim
            };
        }

        private static void OverWriteSkillEffectDante(ushort targetId, ushort animOriginId, ushort effectOriginId)
        {
            datNormalSkillVisual.tbl[targetId] = new datNormalSkillVisual_t
            {
                motion = datNormalSkillVisual.tbl[animOriginId].motion,
                animetype = datNormalSkillVisual.tbl[animOriginId].animetype,
                hatudo = datNormalSkillVisual.tbl[animOriginId].hatudo,
                bedno = datNormalSkillVisual.tbl[animOriginId].bedno
            };
            nbActionProcess.sobedtbl[targetId] = new nbActionProcess.SOBED
            {
                keyname = nbActionProcess.sobedtbl_dante[effectOriginId].keyname,
                bed_fname = nbActionProcess.sobedtbl_dante[effectOriginId].bed_fname,
                se0_str = nbActionProcess.sobedtbl_dante[effectOriginId].se0_str,
                se1_str = nbActionProcess.sobedtbl_dante[effectOriginId].se1_str,
                tga_fname = nbActionProcess.sobedtbl_dante[effectOriginId].tga_fname,
                pbdata = nbActionProcess.sobedtbl_dante[effectOriginId].pbdata
            };
            nbCamera_SkillPtrTable.tbl[targetId] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[effectOriginId].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[effectOriginId].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[effectOriginId].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[effectOriginId].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[effectOriginId].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[effectOriginId].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[effectOriginId].anim
            };
        }

        private static void ApplySkillChanges()
        {
            //datSkill_t[] skills = new datSkill_t[512];
            //for (int i = 0; i < datSkill.tbl.Length; i++)
            //    skills[i] = datSkill.tbl[i];
            //for (int i = datSkill.tbl.Length; i < skills.Length; i++)
            //    skills[i] = new datSkill_t();
            //datSkill.tbl = skills;

            datNormalSkill_t[] normalSkills = new datNormalSkill_t[512];
            for (int i = 0; i < datNormalSkill.tbl.Length; i++)
                normalSkills[i] = datNormalSkill.tbl[i];
            for (int i = datNormalSkill.tbl.Length; i < normalSkills.Length; i++)
                normalSkills[i] = new datNormalSkill_t();
            datNormalSkill.tbl = normalSkills;

            fclKeisyoSkillLevel_t[] skillLevels = new fclKeisyoSkillLevel_t[512];
            for (int i = 0; i < tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Length; i++)
                skillLevels[i] = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[i];
            for (int i = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Length; i < skillLevels.Length; i++)
                skillLevels[i] = new fclKeisyoSkillLevel_t();
            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl = skillLevels;

            datNormalSkillVisual_t[] visuals = new datNormalSkillVisual_t[512];
            for (int i = 0; i < datNormalSkillVisual.tbl.Length; i++)
                visuals[i] = datNormalSkillVisual.tbl[i];
            for (int i = datNormalSkillVisual.tbl.Length; i < visuals.Length; i++)
                visuals[i] = new datNormalSkillVisual_t();
            datNormalSkillVisual.tbl = visuals;

            nbActionProcess.SOBED[] SOBEDs = new nbActionProcess.SOBED[512];
            for (int i = 0; i < nbActionProcess.sobedtbl.Length; i++)
                SOBEDs[i] = nbActionProcess.sobedtbl[i];
            for (int i = nbActionProcess.sobedtbl.Length; i < SOBEDs.Length; i++)
                SOBEDs[i] = new nbActionProcess.SOBED();
            nbActionProcess.sobedtbl = SOBEDs;

            nbCameraSkillPtr_t[] cameras = new nbCameraSkillPtr_t[513];
            for (int i = 0; i < nbCamera_SkillPtrTable.tbl.Length; i++)
                cameras[i] = nbCamera_SkillPtrTable.tbl[i];
            for (int i = nbCamera_SkillPtrTable.tbl.Length; i < cameras.Length; i++)
                cameras[i] = new nbCameraSkillPtr_t();
            nbCamera_SkillPtrTable.tbl = cameras;

            // Normal Skills
            Attack(0);
            Agi(1);
            Agilao(2);
            Agidyne(3);
            Maragi(4);
            Maragion(5);
            Maragidyne(6);

            Bufu(7);
            Bufula(8);
            Bufudyne(9);
            Mabufu(10);
            Mabufula(11);
            Mabufudyne(12);

            Zio(13);
            Zionga(14);
            Ziodyne(15);
            Mazio(16);
            Mazionga(17);
            Maziodyne(18);

            Zan(19);
            Zanma(20);
            Zandyne(21);
            Mazan(22);
            Mazanma(23);
            Mazandyne(24);

            Megido(25);
            Megidola(26);
            Megidolaon(27);

            Hama(28);
            Hamaon(29);
            Mahama(30);
            Mahamaon(31);

            Mudo(32);
            Mudoon(33);
            Mamudo(34);
            Mamudoon(35);

            Dia(36);
            Diarama(37);
            Diarahan(38);
            Media(39);
            Mediarama(40);
            Mediarahan(41);
            Makatora(42);
            Patra(43);
            MePatra(44);
            Mutudi(45);
            Posumudi(46);
            Paraladi(47);
            Petradi(48);
            Recarm(49);
            Samarecarm(50);

            Tarunda(52);
            Sukunda(53);
            Rakunda(54);

            Makajam(55);
            Makajamon(56);

            Dekaja(57);

            Shibaboo(59);
            Lullaby(60);
            Pulinpa(61);
            MarinKarin(62);
            Tentarafoo(63);
            
            Tarukaja(64);
            Sukukaja(65);
            Rakukaja(66);
            Makakaja(67);

            Tetraja(68);
            Makarakarn(69);
            Tetrakarn(70);

            Analyze(71);
            Trafuri(72);
            Estoma(73);
            Riberama(74);
            Liftoma(75);
            Lightoma(76);
            Dekunda(77);

            HourglassSkill(78);

            Pestilence(79);

            LifeStoneSkill(81);
            ChakraDropSkill(82);
            DisCharmSkill(88);

            PoisonArrow(90);

            CursedGospelSkill(91);

            BeadOfLifeSkill(92);

            MedicineSkill(94);

            Lunge(96);
            HellThrust(97);
            Berserk(98);
            Tempest(99);
            HadesBlast(100);
            
            HeatWave(101);
            Blight(102);
            BrutalSlash(103);
            Hassohappa(104);
            DarkSword(105);
            StasisBlade(106);
            MightyGust(107);
            Deathbound(108);
            Guillotine(109);
            ChaosBlade(110);

            NeedleRush(111);
            StunNeedle(112);
            VenomNeedle(113);
            AridNeedle(114);
            
            Sacrifice(115);
            Kamikaze(116);
            
            FeralBite(117);
            VenomBite(118);
            CharmBite(119);
            StoneBite(120);
            StunBite(121);
            HellFang(122);

            FeralClaw(123);
            VenomClaw(124);
            StunClaw(125);
            IronClaw(126);

            GodlyLight(127);

            RapidNeedle(128);
            TathlumShot(129);
            BlastArrow(130);

            DeadlyFury(131);
            JavelinRain(133);

            GrandTack(134);
            HeavensBow(135);
            RiotGun(141);

            SilencingBellow(142);

            DivineShot(136);
            XerosBeat(143);
            OniKagura(144);
            Freikugel(147);

            Renewal(148);
            SpiritWell(149);
            Qigong(150);
            RenewalSpiritWell(151);

            LastResort(152);

            FoulHavoc(153);
            Earthquake(155);
            SpiralViper(160);

            MagmaAxis(161);

            GaeaRage(163);
            Counter(164);
            Retaliate(165);
            Avenge(166);
            DoubleAttack(167);

            Tentacle(168);
            Sear1(172);
            Sear2(173);
            AhrimanCrush(174);

            FireBreath(176);
            Hellfire(177);
            Prominence(178);
            Trisagion(179);

            IceBreath(180);
            GlacialBlast(181);

            Shock(182);
            BoltStorm(183);

            WingBuffet(184);
            Tornado(185);
            WindCutter(186);
            WetWind(187);

            Deathtouch(190);
            ManaDrain(191);
            LifeDrain(192);

            VioletFlash(193);
            Starlight(194);
            Radiance(195);

            HellGaze(196);
            StoneGaze(197);
            MuteGaze(198);
            EvilGaze(199);

            BaelsBane(201);

            ToxicSpray(202);
            WarCry(203);
            FogBreath(204);
            Taunt(205);
            Debilitate(206);

            DismalTune(207);
            SolNiger(208);
            StunGaze(209);
            Dormina(210);
            BindingCry(211);
            EternalRest(212);
            SonicWave(213);
            SexyGaze(214);
            Allure(215);
            PanicVoice(216);
            Intoxicate(217);
            Prayer(218);

            Rage(219);
            PsychoRage(220);

            InfiniteLight(221);

            BeckonCall(223);
            Focus(224);

            Aurora(234);
            BossFireOfSinai(235);
            VastLight(241);
            GodsCurse(242);
            IcyDeath(244);
            Mirage(245);

            WildDance(249);
            Domination(250);

            FoulGathering(252);
            Apocalypse(253);

            Omnipotence(254);

            FireOfSinai(257);

            BeelzebubAttack(258);
            BossDeathFlies(259);
            DeathFlies(260);
            SoulDivide(261);

            BoogieWoogie(262);
            EnterYoshitsune(263);
            MokoiBoomerang(264);
            //Provoke
            Tekisatsu(266);
            MishagujiRaiden(267);
            HitokotoStorm(268);
            JiraiyaDance(269);

            DarkMatter(270);
            EvilGleam(271);
            RootOfEvil(272);
            HighKing(273);

            RaptorGuardian(274);

            Andalucia(275);
            RedCapote(276);

            Startle(277);

            Preach(278);
            Meditation(279);
            Terrorblade(280);
            HellSpin(281);
            HellExhaust(282);
            HellBurner(283);
            HellThrottle(284);
            BabylonGoblet(285);
            DeathLust(286);
            GodsBow(287);

            Punishment(188);
            JudgementLight(189);

            Estocada(403);
            NationFounder(404);
            RetributiveZeal(405);
            Ramayana(416);

            NewBeastEye(422);
            NewDragonEye(423);
            Concentrate(424);
            ImpalersAnimus(425);
            SakuraRage(426);
            FangBreaker(427);
            DefenseKuzushi(428);
            PrimalForce(429);
            ChiBlast(430);
            Revelation(431);
            GateOfHell(432);
            AkashicArts(433);
            Bloodbath(434);

            Scald(435);
            Ragnarok(436);

            Refrigerate(437);
            Cocytus(438);
            Fimbulvetr(439);

            Jolt(440);
            ThunderGods(441);
            ThunderReign(442);

            Dervish(443);
            HeavenlyCyclone(444);
            Vayavya(445);

            Damnation(446);
            MillenniaCurse(447);

            PoisonVolley(448);
            PoisonSalvo(449);
            NeuralShock(450);
            Overload(451);
            Pulinpaon(452);

            Antichthon(453);
            LastWord(454);
            SoulDrain(455);
            
            Amrita(456);
            Diamrita(457);
            HeatRiser(458);
            LusterCandy(459);
            SilentPrayer(460);
            
            StormGale(461);
            WingedFury(462);

            JackBufu(463);
            HumbleBlessing(464);
            Rend(465);
            JackBufudyne(466);
            DivineLight(467);
            Niflheim(468);
            Mjolnir(469);
            Tandava(470);
            Chaturbhuja(471);
            Kusanagi(472);
            JackAgilao(473);
            GaeBolg(474);
            Gungnir(475);
            Smite(476);
            MakaiThunder(477);
            Oblivion(478);
            Liberation(479);
            AcrobatKick(480);
            OniJackura(481);

            Pain(489);
            SpitefulForce(490);

            // Lucifer Skills
            Phlegethon(491);
            JudeccaTomb(492);
            WeepingHeaven(493);
            CarnalWinds(494);

            Verdict(495);
            DevilRegeneration(496);
            DevilTrigger(497);

            // YHVH Skills
            Scorn(498);
            YHVHCrush(499);
            Rampage(500);
            InfernoOfGod(501);
            HailstormOfGod(502);
            LightningOfGod(503);
            TornadoOfGod(504);
            PlannedChaos(505);
            MouthOfGod(506);
            BlackHole(507);
            Supernova(508);
            InfinitePower(509);
            UnendingCurse(510);
            DivineHarmony(511);

            // Passive Skills
            Might(11);
            BrightMight(12);
            DarkMight(13);
            DrainAttack(14);
            AttackAll(16);
            CounterPassive(17);
            RetaliatePassive(18);
            AvengePassive(19);
            DoubleAttackPassive(20);
            LifeAid(58);
            ManaAid(59);
            VictoryCry(60);
            LifeRefill(61);
            ManaRefill(62);

            PhysBoost(74);
            MagicBoost(75);
            AntiElements(76);
            AntiAilments(77);
            AbyssalMask(78);
            KnowledgeOfTools(79);
            RenewalPassive(80);
            SpiritWellPassive(81);
            QigongPassive(82);
            ArmsMaster(83);
            FirmStance(84);
            ShotBoost(85);
            AntiShot(86);
            NullShot(87);
            ShotDrain(88);
            ShotRepel(89);
            SolitaryDrift(90);
            Pierce(91);

            // Talk Skills
            TalkSkillChanges();

            // Skill Upgrade Changes
            SkillUpgradeChanges();

            // Universal Changes
            foreach (var skill in datSkill.tbl)
                skill.capacity = 0;

            foreach (var skill in negoSkillScenarios.Keys)
                if (tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == skill).Any())
                    tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == skill).Level = 14;

            if (tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 353).Any())
                tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 353).Level = 14;
        }

        // Physical Skills

        private static void Attack(ushort id)
        {
            datNormalSkill.tbl[id].failpoint = 4;
        }

        private static void Lunge(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].criticalpoint = 20;
        }

        private static void HellThrust(ushort id)
        {
            datNormalSkill.tbl[id].cost = 14;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].failpoint = 14;
            datNormalSkill.tbl[id].criticalpoint = 28;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 5;
        }

        private static void Berserk(ushort id)
        {
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].hpn = 20;
            datNormalSkill.tbl[id].failpoint = 6;
            datNormalSkill.tbl[id].criticalpoint = 12;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 4;
        }

        private static void Tempest(ushort id)
        {
            datNormalSkill.tbl[id].cost = 26;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].failpoint = 15;
            datNormalSkill.tbl[id].criticalpoint = 25;
        }

        private static void HadesBlast(ushort id)
        {
            datNormalSkill.tbl[id].cost = 36;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].failpoint = 18;
            datNormalSkill.tbl[id].criticalpoint = 36;
        }

        private static void HeatWave(ushort id)
        {
            datNormalSkill.tbl[id].cost = 18;
            datNormalSkill.tbl[id].hpn = 24;
            datNormalSkill.tbl[id].failpoint = 12;
            datNormalSkill.tbl[id].criticalpoint = 24;
        }

        private static void Blight(ushort id)
        {
            datNormalSkill.tbl[id].cost = 26;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].failpoint = 15;
            datNormalSkill.tbl[id].criticalpoint = 30;
            datNormalSkill.tbl[id].badlevel = 24;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 9;
        }

        private static void BrutalSlash(ushort id)
        {
            datNormalSkill.tbl[id].cost = 18;
            datNormalSkill.tbl[id].hpn = 52;
            datNormalSkill.tbl[id].failpoint = 12;
            datNormalSkill.tbl[id].criticalpoint = 24;
        }

        private static void Hassohappa(ushort id)
        {
            datNormalSkill.tbl[id].cost = 46;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].failpoint = 20;
            datNormalSkill.tbl[id].criticalpoint = 40;
        }

        private static void DarkSword(ushort id)
        {
            datNormalSkill.tbl[id].cost = 28;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].failpoint = 20;
            datNormalSkill.tbl[id].criticalpoint = 40;
            datNormalSkill.tbl[id].badlevel = 30;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 9;
        }

        private static void StasisBlade(ushort id)
        {
            datNormalSkill.tbl[id].cost = 28;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].failpoint = 20;
            datNormalSkill.tbl[id].criticalpoint = 40;
            datNormalSkill.tbl[id].badlevel = 30;
        }

        private static void MightyGust(ushort id)
        {
            datNormalSkill.tbl[id].cost = 14;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].criticalpoint = 20;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 4;
        }

        private static void Deathbound(ushort id)
        {
            datNormalSkill.tbl[id].cost = 31;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].failpoint = 6;
            datNormalSkill.tbl[id].criticalpoint = 20;
        }

        private static void Guillotine(ushort id)
        {
            datNormalSkill.tbl[id].cost = 21;
            datNormalSkill.tbl[id].hpn = 56;
            datNormalSkill.tbl[id].failpoint = 15;
            datNormalSkill.tbl[id].criticalpoint = 30;
            datNormalSkill.tbl[id].badlevel = 30;
        }

        private static void ChaosBlade(ushort id)
        {
            datNormalSkill.tbl[id].cost = 36;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].failpoint = 8;
            datNormalSkill.tbl[id].criticalpoint = 20;
            datNormalSkill.tbl[id].badlevel = 24;
        }

        private static void FeralBite(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].hpn = 44;
            datNormalSkill.tbl[id].failpoint = 12;
            datNormalSkill.tbl[id].criticalpoint = 24;
        }

        private static void VenomBite(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].failpoint = 12;
            datNormalSkill.tbl[id].criticalpoint = 22;
            datNormalSkill.tbl[id].badlevel = 22;
        }

        private static void CharmBite(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].failpoint = 12;
            datNormalSkill.tbl[id].criticalpoint = 22;
            datNormalSkill.tbl[id].badlevel = 20;
        }

        private static void StoneBite(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].failpoint = 12;
            datNormalSkill.tbl[id].criticalpoint = 22;
            datNormalSkill.tbl[id].badlevel = 20;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 6;
        }

        private static void StunBite(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].failpoint = 12;
            datNormalSkill.tbl[id].criticalpoint = 22;
            datNormalSkill.tbl[id].badlevel = 22;
        }

        private static void HellFang(ushort id)
        {
            datNormalSkill.tbl[id].cost = 18;
            datNormalSkill.tbl[id].hpn = 56;
            datNormalSkill.tbl[id].failpoint = 20;
            datNormalSkill.tbl[id].criticalpoint = 40;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 7;
        }

        private static void FeralClaw(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].hpn = 44;
            datNormalSkill.tbl[id].failpoint = 12;
            datNormalSkill.tbl[id].criticalpoint = 24;
        }

        private static void VenomClaw(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].failpoint = 12;
            datNormalSkill.tbl[id].criticalpoint = 22;
            datNormalSkill.tbl[id].badlevel = 22;
        }

        private static void StunClaw(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].failpoint = 12;
            datNormalSkill.tbl[id].criticalpoint = 22;
            datNormalSkill.tbl[id].badlevel = 22;
        }

        private static void IronClaw(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].hpn = 56;
            datNormalSkill.tbl[id].failpoint = 20;
            datNormalSkill.tbl[id].criticalpoint = 40;
        }

        private static void DeadlyFury(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].hpn = 54;
            datNormalSkill.tbl[id].failpoint = 5;
            datNormalSkill.tbl[id].criticalpoint = 50;
            datNormalSkill.tbl[id].targettype = 0;
        }

        private static void XerosBeat(ushort id)
        {
            datNormalSkill.tbl[id].cost = 26;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].failpoint = 5;
            datNormalSkill.tbl[id].criticalpoint = 24;
            datNormalSkill.tbl[id].badlevel = 30;
        }

        private static void OniKagura(ushort id)
        {
            datNormalSkill.tbl[id].cost = 30;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].failpoint = 5;
            datNormalSkill.tbl[id].criticalpoint = 30;
        }

        private static void FoulHavoc(ushort id)
        {
            datNormalSkill.tbl[id].cost = 18;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 16;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].failpoint = 2;
            datNormalSkill.tbl[id].criticalpoint = 20;
        }

        private static void Earthquake(ushort id)
        {
            datSkill.tbl[id].keisyoform = 128;
            datNormalSkill.tbl[id].cost = 44;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].hitlevel = 200;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].badlevel = 20;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 256;

            datNormalSkillVisual.tbl[id].motion = 4;
        }

        private static void GaeaRage(ushort id)
        {
            datNormalSkill.tbl[id].cost = 44;
            datNormalSkill.tbl[id].hpn = 52;
            datNormalSkill.tbl[id].failpoint = 5;
            datNormalSkill.tbl[id].criticalpoint = 30;
        }

        private static void Counter(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 32;

            datNormalSkillVisual.tbl[id].motion = 3;
        }

        private static void Retaliate(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 48;

            OverWriteSkillEffect(id, 96);
            datNormalSkillVisual.tbl[id].motion = 3;
        }

        private static void Avenge(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 56;

            OverWriteSkillEffect(id, 103);
            datNormalSkillVisual.tbl[id].motion = 3;
        }

        private static void EnterYoshitsune(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].criticalpoint = 40;
        }

        private static void Andalucia(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].criticalpoint = 5;
        }

        private static void Terrorblade(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].failpoint = 4;
            datNormalSkill.tbl[id].criticalpoint = 10;
            datNormalSkill.tbl[id].targetcntmax = 6;
        }

        private static void HellSpin(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].failpoint = 6;
            datNormalSkill.tbl[id].criticalpoint = 12;
        }

        private static void DoubleAttack(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 152;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 0;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 3;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].hptype = 14;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 164);
            datNormalSkillVisual.tbl[id].motion = 3;
            nbActionProcess.sobedtbl[id].se1_str = "BSE_SE02";
        }

        private static void SakuraRage(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 16;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 20;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 128;
            datNormalSkill.tbl[id].cost = 36;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 20;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 5;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 1;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 98, 285);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 9;
        }

        private static void FangBreaker(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 16;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 18;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 10;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 2;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 96);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 5;
        }

        private static void DefenseKuzushi(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 16;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 18;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 10;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 128;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 96, 107);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 5;
        }

        private static void PrimalForce(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 16;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 24;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 6;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 80;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 96, 139);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 10;
        }

        private static void ChiBlast(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 128;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 34;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 14;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 24;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 65, 101);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 6;
        }

        private static void Revelation(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 128;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 32;
            datNormalSkill.tbl[id].cost = 38;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 30;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 28, 143);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 11;
        }

        private static void GateOfHell(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 128;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 24;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 1024;
            datNormalSkill.tbl[id].cost = 38;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 30;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 98, 79);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 11;
        }

        private static void AkashicArts(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 16;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 24;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 50;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 3;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 18;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 3;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 96, 275);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 11;
        }

        private static void Bloodbath(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 128;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 38;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 40;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 14;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 0;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 5;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 1;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 100);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 10;
        }

        private static void Rend(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 18;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 40;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 126);
        }

        private static void DivineLight(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 15;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 682;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 98, 189);
        }

        private static void Gungnir(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 18;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 20;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 52;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 107);
        }

        private static void AcrobatKick(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 32;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 100;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 120;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 34;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 97);
            datNormalSkillVisual.tbl[id].motion = 9;
        }

        // Shot Skills

        private static void NeedleRush(ushort id)
        {
            datSkill.tbl[id].skillattr = 12;

            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].hpn = 13;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].criticalpoint = 20;
            datNormalSkill.tbl[id].targetcntmax = 4;
            datNormalSkill.tbl[id].targetcntmin = 2;
        }

        private static void StunNeedle(ushort id)
        {
            datSkill.tbl[id].skillattr = 12;

            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 12;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].criticalpoint = 18;
            datNormalSkill.tbl[id].badlevel = 18;
            datNormalSkill.tbl[id].targetcntmax = 4;
            datNormalSkill.tbl[id].targetcntmin = 2;
        }

        private static void VenomNeedle(ushort id)
        {
            datSkill.tbl[id].skillattr = 12;

            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 12;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].criticalpoint = 18;
            datNormalSkill.tbl[id].badlevel = 18;
            datNormalSkill.tbl[id].targetcntmax = 4;
            datNormalSkill.tbl[id].targetcntmin = 2;
        }

        private static void AridNeedle(ushort id)
        {
            datSkill.tbl[id].skillattr = 12;

            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 11;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].criticalpoint = 18;
            datNormalSkill.tbl[id].badlevel = 16;
            datNormalSkill.tbl[id].targetcntmax = 4;
            datNormalSkill.tbl[id].targetcntmin = 2;
        }

        private static void RapidNeedle(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 128;
            datSkill.tbl[id].skillattr = 12;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 18;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 18;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 22;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 5;
            datNormalSkill.tbl[id].targetcntmin = 2;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 1;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 111);

            nbCamera_SkillPtrTable.tbl[id] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[98].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[98].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[98].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[98].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[98].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[98].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[98].anim
            };
        }

        private static void TathlumShot(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 128;
            datSkill.tbl[id].skillattr = 12;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 30;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 16;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 44;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 111, 97);
            datNormalSkillVisual.tbl[id].bedno = datNormalSkillVisual.tbl[96].bedno;
            datNormalSkillVisual.tbl[id].hatudo = datNormalSkillVisual.tbl[96].hatudo;
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 5;
        }

        private static void BlastArrow(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 128;
            datSkill.tbl[id].skillattr = 12;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 28;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 28;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 18;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 28;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 111, 99);
            datNormalSkillVisual.tbl[id].bedno = datNormalSkillVisual.tbl[96].bedno;
            datNormalSkillVisual.tbl[id].hatudo = datNormalSkillVisual.tbl[96].hatudo;
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 8;
        }

        private static void GrandTack(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 128;
            datSkill.tbl[id].skillattr = 12;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 22;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 40;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 20;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 52;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 111, 110);
            datNormalSkillVisual.tbl[id].bedno = datNormalSkillVisual.tbl[96].bedno;
            datNormalSkillVisual.tbl[id].hatudo = datNormalSkillVisual.tbl[96].hatudo;
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 7;

            nbCamera_SkillPtrTable.tbl[id] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[111].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[111].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[111].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[111].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[111].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[111].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[111].anim
            };
        }

        private static void HeavensBow(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 128;
            datSkill.tbl[id].skillattr = 12;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 36;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 30;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 16;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 111, 110);
            datNormalSkillVisual.tbl[id].bedno = datNormalSkillVisual.tbl[96].bedno;
            datNormalSkillVisual.tbl[id].hatudo = datNormalSkillVisual.tbl[96].hatudo;
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 10;

            nbCamera_SkillPtrTable.tbl[id] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[98].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[98].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[98].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[98].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[98].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[98].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[98].anim
            };
        }

        private static void RiotGun(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 128;
            datSkill.tbl[id].skillattr = 12;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 28;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 30;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 111, 171);
            datNormalSkillVisual.tbl[id].bedno = datNormalSkillVisual.tbl[96].bedno;
            datNormalSkillVisual.tbl[id].hatudo = datNormalSkillVisual.tbl[96].hatudo;
            nbActionProcess.sobedtbl[id].se0_str = nbActionProcess.sobedtbl[110].se0_str;
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 11;

            nbCamera_SkillPtrTable.tbl[id] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[111].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[111].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[111].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[111].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[111].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[111].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[111].anim
            };
        }

        private static void JavelinRain(ushort id)
        {
            datSkill.tbl[id].skillattr = 12;

            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].failpoint = 5;
            datNormalSkill.tbl[id].criticalpoint = 24;
            datNormalSkill.tbl[id].badlevel = 30;
        }

        private static void DivineShot(ushort id)
        {
            datSkill.tbl[id].skillattr = 12;

            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].hpn = 34;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 16;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].hitlevel = 120;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].criticalpoint = 100;
        }

        private static void SpiralViper(ushort id)
        {
            datSkill.tbl[id].skillattr = 12;

            datNormalSkill.tbl[id].cost = 22;
            datNormalSkill.tbl[id].hpn = 62;
            datNormalSkill.tbl[id].failpoint = 5;
            datNormalSkill.tbl[id].criticalpoint = 30;
        }

        private static void BoogieWoogie(ushort id)
        {
            datSkill.tbl[id].skillattr = 12;

            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].hitlevel = 120;
            datNormalSkill.tbl[id].criticalpoint = 18;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 160;
        }

        private static void MokoiBoomerang(ushort id)
        {
            datSkill.tbl[id].skillattr = 12;

            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].badlevel = 24;
        }

        // Fire Skills

        private static void Agi(ushort id)
        {
            datNormalSkill.tbl[id].cost = 4;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 80;

            //int newSobedIndex = 18;
            //nbActionProcess.sobedtbl[id] = new nbActionProcess.SOBED
            //{
            //    keyname = newSobed[newSobedIndex].keyname,
            //    bed_fname = newSobed[newSobedIndex].bed_fname,
            //    se0_str = newSobed[newSobedIndex].se0_str,
            //    se1_str = newSobed[newSobedIndex].se1_str,
            //    tga_fname = newSobed[newSobedIndex].tga_fname,
            //    pbdata = newSobed[newSobedIndex].pbdata
            //};

            ////MelonLogger.Msg(JsonConvert.SerializeObject(nbActionProcess.sobedtbl[id]));
        }

        private static void Agilao(ushort id)
        {
            datNormalSkill.tbl[id].cost = 8;
            datNormalSkill.tbl[id].hpn = 45;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 222;
        }

        private static void Agidyne(ushort id)
        {
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 432;
        }

        private static void Maragi(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].hpn = 24;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 66;
        }

        private static void Maragion(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 180;
        }

        private static void Maragidyne(ushort id)
        {
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 350;
        }

        private static void MagmaAxis(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].hitlevel = 120;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].hpn = 80;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
        }

        private static void FireBreath(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 20;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 58;
            datNormalSkill.tbl[id].targetcntmax = 5;
            datNormalSkill.tbl[id].targetcntmin = 3;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 4;
        }

        private static void Hellfire(ushort id)
        {
            datNormalSkill.tbl[id].cost = 24;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 154;
            datNormalSkill.tbl[id].targetcntmax = 6;
            datNormalSkill.tbl[id].targetcntmin = 3;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 8;
        }

        private static void Prominence(ushort id)
        {
            datNormalSkill.tbl[id].cost = 48;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 296;
            datNormalSkill.tbl[id].targetcntmax = 7;
            datNormalSkill.tbl[id].targetcntmin = 3;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 11;
        }

        private static void Trisagion(ushort id)
        {
            datSkill.tbl[id].keisyoform = 1;
            datNormalSkill.tbl[id].cost = 32;
            datNormalSkill.tbl[id].hpn = 80;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 10;
        }

        private static void HellBurner(ushort id)
        {
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 12;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 12;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 20;
            datNormalSkill.tbl[id].magiclimit = 220;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;
        }

        private static void Scald(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 1;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 2;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 80;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 4, 101);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 5;
        }

        private static void Ragnarok(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 1;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 60;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 179);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 12;
        }

        private static void JackAgilao(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 1;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 10;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 45;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 222;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 2);
        }

        private static void OniJackura(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2;
            datNormalSkill.tbl[id].cost = 28;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 30;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 180, 143);
        }

        // Ice Skills

        private static void Bufu(ushort id)
        {
            datNormalSkill.tbl[id].cost = 4;
            datNormalSkill.tbl[id].hpn = 27;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 74;
            datNormalSkill.tbl[id].badlevel = 20;
        }

        private static void Bufula(ushort id)
        {
            datNormalSkill.tbl[id].cost = 8;
            datNormalSkill.tbl[id].hpn = 39;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 196;
            datNormalSkill.tbl[id].badlevel = 24;
        }

        private static void Bufudyne(ushort id)
        {
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].hpn = 51;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 370;
            datNormalSkill.tbl[id].badlevel = 28;
        }

        private static void Mabufu(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].hpn = 20;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 58;
            datNormalSkill.tbl[id].badlevel = 11;
        }

        private static void Mabufula(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 154;
            datNormalSkill.tbl[id].badlevel = 14;
        }

        private static void Mabufudyne(ushort id)
        {
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 296;
            datNormalSkill.tbl[id].badlevel = 17;
        }

        private static void IceBreath(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 18;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 54;
            datNormalSkill.tbl[id].targetcntmax = 5;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].badlevel = 15;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 4;
        }

        private static void GlacialBlast(ushort id)
        {
            datNormalSkill.tbl[id].cost = 24;
            datNormalSkill.tbl[id].hpn = 24;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 128;
            datNormalSkill.tbl[id].targetcntmax = 6;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].badlevel = 18;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 8;
        }

        private static void IcyDeath(ushort id)
        {
            datNormalSkill.tbl[id].badlevel = 25;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2;
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 544;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 154;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;
        }

        private static void Refrigerate(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 2;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 24;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2;
            datNormalSkill.tbl[id].cost = 8;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 544;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 84;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 7);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 4;
        }

        private static void Cocytus(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 2;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2;
            datNormalSkill.tbl[id].cost = 48;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 296;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 7;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 1;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 7, 180);
        }

        private static void Fimbulvetr(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 2;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 22;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2;
            datNormalSkill.tbl[id].cost = 60;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 181);
            nbActionProcess.sobedtbl[id].bed_fname = nbActionProcess.sobedtbl[12].bed_fname;
            nbActionProcess.sobedtbl[id].keyname = nbActionProcess.sobedtbl[181].keyname;
            nbActionProcess.sobedtbl[id].se0_str = nbActionProcess.sobedtbl[181].se0_str;
            nbActionProcess.sobedtbl[id].se1_str = nbActionProcess.sobedtbl[12].se1_str;
            nbActionProcess.sobedtbl[id].tga_fname = nbActionProcess.sobedtbl[181].tga_fname;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 12;
        }

        private static void JackBufu(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 2;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 20;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2;
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 128;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 27;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 74;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 7);
        }

        private static void JackBufudyne(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 2;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 20;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2;
            datNormalSkill.tbl[id].cost = 32;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 128;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 70;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 9);
        }

        private static void Niflheim(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 2;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 25;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2;
            datNormalSkill.tbl[id].cost = 60;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 160;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 181);
            nbActionProcess.sobedtbl[id].bed_fname =  nbActionProcess.sobedtbl[12].bed_fname;
            nbActionProcess.sobedtbl[id].keyname = nbActionProcess.sobedtbl[181].keyname;
            nbActionProcess.sobedtbl[id].se0_str = nbActionProcess.sobedtbl[181].se0_str;
            nbActionProcess.sobedtbl[id].se1_str = nbActionProcess.sobedtbl[12].se1_str;
            nbActionProcess.sobedtbl[id].tga_fname = nbActionProcess.sobedtbl[181].tga_fname;
            nbActionProcess.sobedtbl[id].pbdata = nbActionProcess.sobedtbl[12].pbdata;
        }

        // Elec Skills

        private static void Zio(ushort id)
        {
            datNormalSkill.tbl[id].cost = 4;
            datNormalSkill.tbl[id].hpn = 27;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 74;
            datNormalSkill.tbl[id].badlevel = 22;
        }

        private static void Zionga(ushort id)
        {
            datNormalSkill.tbl[id].cost = 8;
            datNormalSkill.tbl[id].hpn = 39;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 196;
            datNormalSkill.tbl[id].badlevel = 26;
        }

        private static void Ziodyne(ushort id)
        {
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].hpn = 51;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 370;
            datNormalSkill.tbl[id].badlevel = 30;
        }

        private static void Mazio(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].hpn = 20;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 58;
            datNormalSkill.tbl[id].badlevel = 13;
        }

        private static void Mazionga(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 154;
            datNormalSkill.tbl[id].badlevel = 16;
        }

        private static void Maziodyne(ushort id)
        {
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 296;
            datNormalSkill.tbl[id].badlevel = 19;
        }

        private static void Shock(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 18;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 54;
            datNormalSkill.tbl[id].targetcntmax = 5;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].badlevel = 15;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 4;
        }

        private static void BoltStorm(ushort id)
        {
            datNormalSkill.tbl[id].cost = 24;
            datNormalSkill.tbl[id].hpn = 24;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 128;
            datNormalSkill.tbl[id].targetcntmax = 6;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].badlevel = 18;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 8;
        }

        private static void MishagujiRaiden(ushort id)
        {
            datNormalSkill.tbl[id].cost = 50;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].badlevel = 20;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 544;
            datNormalSkill.tbl[id].hitlevel = 120;
        }

        private static void Jolt(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 3;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 65;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 1;
            datNormalSkill.tbl[id].cost = 8;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 84;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 182);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 4;
        }

        private static void ThunderGods(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 3;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 34;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 1;
            datNormalSkill.tbl[id].cost = 32;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 70;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 15, 193);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 10;
        }

        private static void ThunderReign(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 3;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 22;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 1;
            datNormalSkill.tbl[id].cost = 60;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 15, 195);
            //nbActionProcess.sobedtbl[id].se0_str = nbActionProcess.sobedtbl[193].se0_str;
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 12;
        }

        private static void Mjolnir(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 3;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 20;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 1;
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 20;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].hptype = 6;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 20;
            datNormalSkill.tbl[id].magiclimit = 220;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 106, 15);
            datNormalSkillVisual.tbl[id].bedno = datNormalSkillVisual.tbl[15].bedno;
            datNormalSkillVisual.tbl[id].hatudo = datNormalSkillVisual.tbl[15].hatudo;
        }

        // Force Skills

        private static void Zan(ushort id)
        {
            datNormalSkill.tbl[id].cost = 4;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 80;
        }

        private static void Zanma(ushort id)
        {
            datNormalSkill.tbl[id].cost = 8;
            datNormalSkill.tbl[id].hpn = 45;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 222;
        }

        private static void Zandyne(ushort id)
        {
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 432;
        }

        private static void Mazan(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].hpn = 24;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 66;
        }

        private static void Mazanma(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 180;
        }

        private static void Mazandyne(ushort id)
        {
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 350;
        }

        private static void WingBuffet(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 20;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 58;
            datNormalSkill.tbl[id].targetcntmax = 5;
            datNormalSkill.tbl[id].targetcntmin = 3;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 0;
        }

        private static void Tornado(ushort id)
        {
            datNormalSkill.tbl[id].cost = 24;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 154;
            datNormalSkill.tbl[id].targetcntmax = 6;
            datNormalSkill.tbl[id].targetcntmin = 3;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 82;
        }

        private static void WindCutter(ushort id)
        {
            datNormalSkill.tbl[id].cost = 32;
            datNormalSkill.tbl[id].hpn = 80;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 10;
        }

        private static void WetWind(ushort id)
        {
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].hpn = 45;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 350;
            datNormalSkill.tbl[id].badlevel = 30;
        }

        private static void HitokotoStorm(ushort id)
        {
            datNormalSkill.tbl[id].cost = 50;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 10;
            datNormalSkill.tbl[id].hitlevel = 120;
        }

        private static void HellExhaust(ushort id)
        {
            datNormalSkill.tbl[id].cost = 30;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 154;
        }

        private static void Dervish(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 4;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 32;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 80;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 22, 184);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 5;
        }

        private static void HeavenlyCyclone(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 4;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 48;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 296;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 7;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 1;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            //OverWriteSkillEffect(id, 23);
            OverWriteSkillEffectDante(id, 23, 6);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 11;
        }

        private static void Vayavya(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 4;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 60;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 186);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 12;
        }

        private static void StormGale(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 4;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 20;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 58;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 5;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 1;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 22, 184);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 4;
        }

        private static void WingedFury(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 4;
            datSkill.tbl[id].skillattr = 4;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 30;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 20;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 20;
            datNormalSkill.tbl[id].magiclimit = 220;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            //OverWriteSkillEffect(id, 184, 24);
            OverWriteSkillEffectDante(id, 184, 6);

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 11;
        }

        private static void Kusanagi(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 4;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 14;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 20;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 52;
            datNormalSkill.tbl[id].hptype = 6;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 20;
            datNormalSkill.tbl[id].magiclimit = 220;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 106, 21);
            datNormalSkillVisual.tbl[id].bedno = datNormalSkillVisual.tbl[21].bedno;
            datNormalSkillVisual.tbl[id].hatudo = datNormalSkillVisual.tbl[21].hatudo;
        }

        private static void GaeBolg(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 4;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 100;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 120;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 34;
            datNormalSkill.tbl[id].hptype = 6;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 20;
            datNormalSkill.tbl[id].magiclimit = 220;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 106, 21);
            datNormalSkillVisual.tbl[id].bedno = datNormalSkillVisual.tbl[21].bedno;
            datNormalSkillVisual.tbl[id].hatudo = datNormalSkillVisual.tbl[21].hatudo;
        }

        // Almighty Skills

        private static void Megido(ushort id)
        {
            datNormalSkill.tbl[id].cost = 30;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 182;
        }

        private static void Megidola(ushort id)
        {
            datNormalSkill.tbl[id].cost = 45;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].magicbase = 21;
            datNormalSkill.tbl[id].magiclimit = 260;
        }

        private static void Megidolaon(ushort id)
        {
            datNormalSkill.tbl[id].cost = 60;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 350;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 12;
        }

        private static void Pestilence(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 182;
            datNormalSkill.tbl[id].badlevel = 90;
        }

        private static void Freikugel(ushort id)
        {
            datNormalSkill.tbl[id].cost = 18;
            datNormalSkill.tbl[id].hpn = 66;
            datNormalSkill.tbl[id].failpoint = 5;
            datNormalSkill.tbl[id].criticalpoint = 30;
        }

        private static void Deathtouch(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].hpn = 25;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 74;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 2;
        }

        private static void ManaDrain(ushort id)
        {
            datNormalSkill.tbl[id].cost = 3;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].hpn = 15;
            datNormalSkill.tbl[id].mpn = 15;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 44;
        }

        private static void LifeDrain(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].hpn = 25;
            datNormalSkill.tbl[id].mpn = 15;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 74;
        }

        private static void SolNiger(ushort id)
        {
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].hitlevel = 40;
            datNormalSkill.tbl[id].flag = 1;
        }

        private static void BossFireOfSinai(ushort id)
        {
            datNormalSkill.tbl[id].cost = 72;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].hitlevel = 120;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].targetcntmax = 8;
            datNormalSkill.tbl[id].targetcntmin = 4;
        }

        private static void FireOfSinai(ushort id)
        {
            datNormalSkill.tbl[id].cost = 72;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].targetcntmax = 8;
            datNormalSkill.tbl[id].targetcntmin = 4;
        }

        private static void GodsCurse(ushort id)
        {
            datNormalSkill.tbl[id].cost = 50;
            datNormalSkill.tbl[id].badlevel = 50;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].magicbase = 21;
            datNormalSkill.tbl[id].magiclimit = 32767;
        }

        private static void BossDeathFlies(ushort id)
        {
            datNormalSkill.tbl[id].cost = 75;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].hitlevel = 120;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].badlevel = 90;
        }

        private static void DeathFlies(ushort id)
        {
            datNormalSkill.tbl[id].cost = 75;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].badlevel = 90;
        }

        private static void Tekisatsu(ushort id)
        {
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].basstatus = 2048;
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].criticalpoint = 0;
        }

        private static void JiraiyaDance(ushort id)
        {
            datNormalSkill.tbl[id].cost = 60;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 32767;
        }

        private static void Meditation(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 35;
            datNormalSkill.tbl[id].mpn = 20;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 182;
        }

        private static void BabylonGoblet(ushort id)
        {
            datSkill.tbl[id].skillattr = 5;
            datNormalSkill.tbl[id].badlevel = 50;
            datNormalSkill.tbl[id].basstatus = 8;
            datNormalSkill.tbl[id].cost = 25;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 544;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targettype = 1;
        }

        private static void DeathLust(ushort id)
        {
            datNormalSkill.tbl[id].cost = 60;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 350;
            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 128;
        }

        private static void Antichthon(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 5;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 60;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 682;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 25, 270);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 12;
        }

        private static void LastWord(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 5;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 0;
            datNormalSkill.tbl[id].hojotype = 99;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 80;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 111, 171);
            datNormalSkillVisual.tbl[id].bedno = datNormalSkillVisual.tbl[96].bedno;
            datNormalSkillVisual.tbl[id].hatudo = datNormalSkillVisual.tbl[96].hatudo;
            nbActionProcess.sobedtbl[id].se0_str = nbActionProcess.sobedtbl[110].se0_str;
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 14;

            nbCamera_SkillPtrTable.tbl[id] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[111].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[111].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[111].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[111].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[111].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[111].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[111].anim
            };
        }

        private static void SoulDrain(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 5;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 0;
            datNormalSkill.tbl[id].hojotype = 99;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].hptype = 12;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 32;
            datNormalSkill.tbl[id].mptype = 12;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 191);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 9;
        }

        private static void Tandava(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 5;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 100;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 120;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 6;
            datNormalSkill.tbl[id].hojotype = 128;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 196, 173);
        }

        private static void Chaturbhuja(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 5;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 100;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 1;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 120;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 7;
            datNormalSkill.tbl[id].targetcntmin = 5;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 1;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 196, 235);
        }

        // Light Skills

        private static void Hama(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 16;
            datNormalSkill.tbl[id].magiclimit = 180;
        }

        private static void Hamaon(ushort id)
        {
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].badlevel = 50;
            datNormalSkill.tbl[id].hpn = 54;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 390;
        }

        private static void Mahama(ushort id)
        {
            datNormalSkill.tbl[id].cost = 18;
            datNormalSkill.tbl[id].badlevel = 20;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 16;
            datNormalSkill.tbl[id].magiclimit = 152;
        }

        private static void Mahamaon(ushort id)
        {
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 310;
        }

        private static void VioletFlash(ushort id)
        {
            datNormalSkill.tbl[id].cost = 8;
            datNormalSkill.tbl[id].hpn = 45;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 222;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 4;
        }

        private static void Starlight(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 180;
        }

        private static void Radiance(ushort id)
        {
            datNormalSkill.tbl[id].cost = 60;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 12;
        }

        private static void GodsBow(ushort id)
        {
            datNormalSkill.tbl[id].cost = 36;
            datNormalSkill.tbl[id].hpn = 80;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].badlevel = 90;
        }

        private static void Punishment(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 6;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 50;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2048;
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 0;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            datNormalSkillVisual.tbl[id] = datNormalSkillVisual.tbl[28];
            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 5;
        }

        private static void JudgementLight(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 6;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2048;
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 0;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            datNormalSkillVisual.tbl[id] = datNormalSkillVisual.tbl[28];
            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 7;
        }

        private static void Smite(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 6;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 32;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 80;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 28, 188);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 10;
        }

        private static void GodlyLight(ushort id)
        {
            datNormalSkill.tbl[id].cost = 45;
            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 32;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 350;
        }

        // Dark Skills

        private static void Mudo(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 16;
            datNormalSkill.tbl[id].magiclimit = 180;
        }

        private static void Mudoon(ushort id)
        {
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].badlevel = 50;
            datNormalSkill.tbl[id].hpn = 54;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 390;
        }

        private static void Mamudo(ushort id)
        {
            datNormalSkill.tbl[id].cost = 18;
            datNormalSkill.tbl[id].badlevel = 20;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 16;
            datNormalSkill.tbl[id].magiclimit = 152;
        }

        private static void Mamudoon(ushort id)
        {
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 310;
        }

        private static void HellGaze(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].badlevel = 60;
        }

        private static void StoneGaze(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].badlevel = 60;
        }

        private static void EvilGaze(ushort id)
        {
            datNormalSkill.tbl[id].cost = 8;
            datNormalSkill.tbl[id].hitlevel = 60;
            datNormalSkill.tbl[id].flag = 1;
        }

        private static void Damnation(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 7;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 50;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2048;
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 0;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 32, 243);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 5;
        }

        private static void MillenniaCurse(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 7;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2048;
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 0;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 32, 243);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 7;
        }

        private static void MakaiThunder(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 7;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 20;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 16;
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 45;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 222;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 226);
            datNormalSkillVisual.tbl[id].motion = 24;
            datNormalSkillVisual.tbl[id].bedno = datNormalSkillVisual.tbl[32].bedno;
            datNormalSkillVisual.tbl[id].hatudo = datNormalSkillVisual.tbl[32].hatudo;
        }

        private static void Oblivion(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 7;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 60;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 32, 208);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 12;
        }

        // Curse Skills

        private static void Makajam(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].badlevel = 50;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 4;
        }

        private static void Makajamon(ushort id)
        {
            datNormalSkill.tbl[id].cost = 18;
            datNormalSkill.tbl[id].badlevel = 25;
        }

        private static void PoisonArrow(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 8;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 64;
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 80;
            datNormalSkill.tbl[id].targettype = 0;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 3;
        }

        private static void MuteGaze(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].badlevel = 60;
        }

        private static void ToxicSpray(ushort id)
        {
            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 64;
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].hitlevel = 50;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 128;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targettype = 1;
        }

        private static void DismalTune(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 154;
            datNormalSkill.tbl[id].badlevel = 40;
        }

        private static void SoulDivide(ushort id)
        {
            datNormalSkill.tbl[id].cost = 50;
            datNormalSkill.tbl[id].badlevel = 100;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 350;
            datNormalSkill.tbl[id].hitlevel = 60;
        }

        private static void PoisonVolley(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 8;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 40;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 64;
            datNormalSkill.tbl[id].cost = 24;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 18;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 54;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 6;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 1;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 90);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 8;

            nbCamera_SkillPtrTable.tbl[id] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[98].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[98].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[98].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[98].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[98].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[98].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[98].anim
            };
        }

        private static void PoisonSalvo(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 8;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 70;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 64;
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 39;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 196;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 3;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 90);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 8;
        }

        // Nerve Skills

        private static void Shibaboo(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 80;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 3;
        }

        private static void StunGaze(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].badlevel = 50;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 2;
        }

        private static void BindingCry(ushort id)
        {
            datNormalSkill.tbl[id].cost = 15;
            datNormalSkill.tbl[id].badlevel = 30;
        }

        private static void NeuralShock(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 9;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 70;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 256;
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 39;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 196;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 59, 261);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 8;
        }

        private static void Overload(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 9;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 50;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 256;
            datNormalSkill.tbl[id].cost = 45;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 154;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 59, 187);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 10;
        }

        // Mind Skills

        private static void Lullaby(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].badlevel = 30;
        }

        private static void Pulinpa(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 80;
        }

        private static void MarinKarin(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].badlevel = 50;
        }

        private static void Tentarafoo(ushort id)
        {
            datNormalSkill.tbl[id].cost = 45;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 154;
            datNormalSkill.tbl[id].badlevel = 40;
        }

        private static void Dormina(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].badlevel = 60;
        }

        private static void EternalRest(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
        }

        private static void SonicWave(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].badlevel = 30;
        }

        private static void SexyGaze(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].badlevel = 60;
        }

        private static void Allure(ushort id)
        {
            datNormalSkill.tbl[id].cost = 15;
            datNormalSkill.tbl[id].badlevel = 40;
        }

        private static void PanicVoice(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].badlevel = 30;
        }

        private static void Intoxicate(ushort id)
        {
            datNormalSkill.tbl[id].cost = 60;
            datNormalSkill.tbl[id].badlevel = 40;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
        }

        private static void WildDance(ushort id)
        {
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 268;
            datNormalSkill.tbl[id].targetcntmax = 7;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].badlevel = 40;
        }

        private static void Preach(ushort id)
        {
            datNormalSkill.tbl[id].cost = 24;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 154;
            datNormalSkill.tbl[id].badlevel = 40;
        }

        private static void Pulinpaon(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 10;
            datSkill.tbl[id].index = (short) id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 70;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 8;
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 39;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 196;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 63);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 8;
        }

        // Self-Destruct Skills

        private static void Sacrifice(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 55;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].criticalpoint = 20;
        }

        private static void Kamikaze(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 80;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].criticalpoint = 20;
        }

        private static void LastResort(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].criticalpoint = 0;
        }

        // Healing Skills

        private static void Dia(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].hpn = 10;
        }

        private static void Diarama(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 20;
        }

        private static void Diarahan(ushort id)
        {
            datNormalSkill.tbl[id].cost = 24;
            datNormalSkill.tbl[id].hpn = 100;
        }

        private static void Media(ushort id)
        {
            datNormalSkill.tbl[id].cost = 18;
            datNormalSkill.tbl[id].hpn = 10;
        }

        private static void Mediarama(ushort id)
        {
            datNormalSkill.tbl[id].cost = 36;
            datNormalSkill.tbl[id].hpn = 20;
        }

        private static void Mediarahan(ushort id)
        {
            datNormalSkill.tbl[id].cost = 72;
            datNormalSkill.tbl[id].hpn = 100;
        }

        private static void Patra(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
        }

        private static void MePatra(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
        }

        private static void Mutudi(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
        }

        private static void Posumudi(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
        }

        private static void Paraladi(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
        }

        private static void Petradi(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
        }

        private static void Recarm(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
        }

        private static void Samarecarm(ushort id)
        {
            datNormalSkill.tbl[id].cost = 50;
        }

        private static void Prayer(ushort id)
        {
            datNormalSkill.tbl[id].cost = 90;
        }

        private static void Amrita(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 13;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 2;
            datNormalSkill.tbl[id].basstatus = 1535;
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 44);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 7;
        }

        private static void Diamrita(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 13;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 2;
            datNormalSkill.tbl[id].basstatus = 1535;
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 18;
            datNormalSkill.tbl[id].hptype = 2;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 3;

            OverWriteSkillEffect(id, 44);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 7;
        }

        private static void Renewal(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 13;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 10;
            datNormalSkill.tbl[id].hptype = 11;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 1;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 81);
            datNormalSkillVisual.tbl[id].motion = 0;
            datNormalSkillVisual.tbl[id].hatudo = 0;
        }

        private static void SpiritWell(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 15;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 3;
            datNormalSkill.tbl[id].mptype = 11;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 1;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 82);
            datNormalSkillVisual.tbl[id].motion = 0;
            datNormalSkillVisual.tbl[id].hatudo = 0;
        }

        private static void Qigong(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 15;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 15;
            datNormalSkill.tbl[id].hptype = 11;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 5;
            datNormalSkill.tbl[id].mptype = 11;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 1;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 85);
            datNormalSkillVisual.tbl[id].motion = 0;
            datNormalSkillVisual.tbl[id].hatudo = 0;
        }

        private static void RenewalSpiritWell(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 15;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 10;
            datNormalSkill.tbl[id].hptype = 11;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 3;
            datNormalSkill.tbl[id].mptype = 11;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 1;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 85);
            datNormalSkillVisual.tbl[id].motion = 0;
            datNormalSkillVisual.tbl[id].hatudo = 0;
        }

        private static void Liberation(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 13;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 2;
            datNormalSkill.tbl[id].basstatus = 1535;
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 262144;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 100;
            datNormalSkill.tbl[id].hptype = 11;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 3;

            OverWriteSkillEffect(id, 50);
        }

        private static void HumbleBlessing(ushort id)
        {
            datSkill.tbl[id].capacity = 2;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 13;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 8;
            datNormalSkill.tbl[id].hptype = 2;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 3;

            OverWriteSkillEffect(id, 39);
        }

        // Support Skills

        private static void Tarunda(ushort id)
        {
            datNormalSkill.tbl[id].cost = 15;
        }

        private static void Sukunda(ushort id)
        {
            datNormalSkill.tbl[id].cost = 15;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 2;
        }

        private static void Rakunda(ushort id)
        {
            datNormalSkill.tbl[id].cost = 15;
        }

        private static void Dekaja(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
        }

        private static void Tarukaja(ushort id)
        {
            datNormalSkill.tbl[id].cost = 15;
            datNormalSkill.tbl[id].hojotype = 5;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 4;
        }

        private static void Sukukaja(ushort id)
        {
            datNormalSkill.tbl[id].cost = 15;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 4;
        }

        private static void Rakukaja(ushort id)
        {
            datNormalSkill.tbl[id].cost = 15;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 4;
        }

        private static void Makakaja(ushort id)
        {
            datNormalSkill.tbl[id].cost = 15;
            datNormalSkill.tbl[id].hojotype = 260;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 4;
        }

        private static void Tetraja(ushort id)
        {
            datNormalSkill.tbl[id].cost = 30;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 5;
        }

        private static void Makarakarn(ushort id)
        {
            datNormalSkill.tbl[id].cost = 50;
            datNormalSkill.tbl[id].targettype = 0;
        }

        private static void Tetrakarn(ushort id)
        {
            datNormalSkill.tbl[id].cost = 50;
            datNormalSkill.tbl[id].targettype = 0;
        }

        private static void Analyze(ushort id)
        {
            datNormalSkill.tbl[id].cost = 3;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 2;
        }

        private static void Trafuri(ushort id)
        {
            datNormalSkill.tbl[id].cost = 30;
        }

        private static void Estoma(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
        }

        private static void Riberama(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
        }

        private static void Liftoma(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
        }

        private static void Lightoma(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
        }

        private static void Dekunda(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 3;
        }

        private static void WarCry(ushort id)
        {
            datNormalSkill.tbl[id].cost = 45;
        }

        private static void FogBreath(ushort id)
        {
            datNormalSkill.tbl[id].cost = 35;
        }

        private static void Taunt(ushort id)
        {
            datNormalSkill.tbl[id].cost = 25;
        }

        private static void Debilitate(ushort id)
        {
            datNormalSkill.tbl[id].cost = 60;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == id).Level = 10;
        }

        private static void BeckonCall(ushort id)
        {
            datSkill.tbl[id].skillattr = 14;
            datNormalSkill.tbl[id].cost = 20;
        }

        private static void Focus(ushort id)
        {
            datSkill.tbl[id].skillattr = 14;
            datNormalSkill.tbl[id].cost = 10;
        }

        private static void Provoke(ushort id)
        {
            datNormalSkill.tbl[id].cost = 0;
        }

        private static void RaptorGuardian(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
        }

        private static void RedCapote(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].hojopoint = 6;
        }

        private static void HellThrottle(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 14;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 30;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 273;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 284, 65);
        }

        private static void Concentrate(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 14;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 33554432;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 1;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 224);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 6;
        }

        private static void ImpalersAnimus(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 14;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 50331648;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 1;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 224);
        }

        private static void HeatRiser(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 14;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 2;
            datNormalSkill.tbl[id].hojotype = 341;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 224);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 8;
        }

        private static void LusterCandy(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 14;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 60;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 341;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 219);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 10;
        }

        private static void SilentPrayer(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 14;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 50;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 263168;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 2;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 77, 77);
            //nbActionProcess.sobedtbl[id].se1_str = nbActionProcess.sobedtbl[189].se1_str;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = id;
            skillLevel.Level = 8;
        }

        // Utility Skills

        private static void Makatora(ushort id)
        {
            datSkill.tbl[id].skillattr = 15; // Utility skill
        }

        private static void MedicineSkill(ushort id)
        {
            datSkill.tbl[id].skillattr = 13; // Healing skill
        }

        private static void LifeStoneSkill(ushort id)
        {
            datSkill.tbl[id].skillattr = 13; // Healing skill
        }

        private static void DisCharmSkill(ushort id)
        {
            datSkill.tbl[id].skillattr = 13; // Healing skill
        }

        private static void BeadOfLifeSkill(ushort id)
        {
            datSkill.tbl[id].skillattr = 15; // Utility skill
        }

        private static void ChakraDropSkill(ushort id)
        {
            datSkill.tbl[id].skillattr = 15; // Utility skill
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 5;
        }

        private static void HourglassSkill(ushort id)
        {
            datSkill.tbl[id].skillattr = 15; // Utility skill
            datNormalSkill.tbl[id].koukatype = 1; // Not Physical
            datNormalSkill.tbl[id].program = 14; // Phase shift
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targettype = 3; // Field
        }

        private static void CursedGospelSkill(ushort id)
        {
            datSkill.tbl[id].skillattr = 15; // Utility skill
            datNormalSkill.tbl[id].koukatype = 1; // Not Physical
            datNormalSkill.tbl[id].program = 14; // Phase shift
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targettype = 3; // Field
        }

        // Enemy-Only Skills

        private static void Rage(ushort id)
        {
            datSkill.tbl[id].skillattr = 15; // Utility skill
        }

        private static void PsychoRage(ushort id)
        {
            datSkill.tbl[id].skillattr = 15; // Utility skill
        }

        private static void BaelsBane(ushort id)
        {
            datSkill.tbl[id].skillattr = 5; // Almighty
            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].hitlevel = 255;
        }

        private static void Aurora(ushort id)
        {
            datNormalSkill.tbl[id].targetrule = 1;
            datNormalSkill.tbl[id].targettype = 0;
        }

        private static void Sear1(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].criticalpoint = 0;
        }

        private static void Sear2(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].criticalpoint = 0;
        }

        private static void VastLight(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 90;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
        }

        private static void InfiniteLight(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 120;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].targetarea = 11;
        }

        private static void Mirage(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 154;
            datNormalSkill.tbl[id].badlevel = 60;
        }

        private static void Domination(ushort id)
        {
            datSkill.tbl[id].skillattr = 5; // Almighty
            datNormalSkill.tbl[id].badlevel = 100;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 16;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].mpn = 30;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
        }

        private static void FoulGathering(ushort id)
        {
            nbCamera_SkillPtrTable.tbl[id] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[208].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[208].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[208].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[208].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[208].anim
            };
        }

        private static void Tentacle(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].criticalpoint = 20;
        }

        private static void AhrimanCrush(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].criticalpoint = 4;
        }

        private static void Apocalypse(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 80;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
        }

        private static void SilencingBellow(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 2;
            datSkill.tbl[id].skillattr = 5;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 32;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 50;
            datNormalSkill.tbl[id].hojotype = 1024;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 10;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffectDante(id, 137, 3);
            datNormalSkillVisual.tbl[id].motion = 4;
        }

        private static void Omnipotence(ushort id)
        {
            datSkill.tbl[id].skillattr = 14;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 3;
            datNormalSkill.tbl[id].hojotype = 341;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 5;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;
        }

        private static void BeelzebubAttack(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].criticalpoint = 30;
        }

        private static void NewBeastEye(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 15;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 2;
            datNormalSkill.tbl[id].hojotype = 4096;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 13;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 219);
        }

        private static void NewDragonEye(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 15;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 2;
            datNormalSkill.tbl[id].hojotype = 4096;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 13;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 219);
        }

        private static void Startle(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 15;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            OverWriteSkillEffect(id, 219);
        }

        private static void Estocada(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].hptype = 14;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 96);
            datNormalSkillVisual.tbl[id].motion = 3;
            datNormalSkillVisual.tbl[id].hatudo = datNormalSkillVisual.tbl[0].hatudo;
        }

        private static void NationFounder(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 14;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 341;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 67);
        }

        private static void RetributiveZeal(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 14;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 6;
            datNormalSkill.tbl[id].hojotype = 5;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 64);
        }

        private static void SwitchOutSkillCopy2(ushort functionId, ushort effectId, byte targetType, bool applyBuff)
        {
            datSkill.tbl[406].flag = 0;
            datSkill.tbl[406].keisyoform = 512;
            datSkill.tbl[406].skillattr = datSkill.tbl[functionId].skillattr;
            datSkill.tbl[406].index = 408;
            datSkill.tbl[406].type = 0;

            datNormalSkill.tbl[406].badlevel = datNormalSkill.tbl[functionId].badlevel;
            datNormalSkill.tbl[406].badtype = datNormalSkill.tbl[functionId].badtype;
            datNormalSkill.tbl[406].basstatus = datNormalSkill.tbl[functionId].basstatus;
            datNormalSkill.tbl[406].cost = 0;
            datNormalSkill.tbl[406].costbase = 0;
            datNormalSkill.tbl[406].costtype = 2;
            datNormalSkill.tbl[406].criticalpoint = datNormalSkill.tbl[functionId].criticalpoint;
            datNormalSkill.tbl[406].deadtype = datNormalSkill.tbl[functionId].deadtype;
            datNormalSkill.tbl[406].failpoint = datNormalSkill.tbl[functionId].failpoint;
            datNormalSkill.tbl[406].flag = datNormalSkill.tbl[functionId].flag;
            datNormalSkill.tbl[406].hitlevel = datNormalSkill.tbl[functionId].hitlevel;
            datNormalSkill.tbl[406].hitprog = datNormalSkill.tbl[functionId].hitprog;
            datNormalSkill.tbl[406].hittype = datNormalSkill.tbl[functionId].hittype;
            datNormalSkill.tbl[406].hojopoint = applyBuff ? datNormalSkill.tbl[functionId].hojopoint : (sbyte)0;
            datNormalSkill.tbl[406].hojotype = applyBuff ? datNormalSkill.tbl[functionId].hojotype : 1;
            datNormalSkill.tbl[406].hpbase = datNormalSkill.tbl[functionId].hpbase;
            datNormalSkill.tbl[406].hpn = datNormalSkill.tbl[functionId].hpn;
            datNormalSkill.tbl[406].hptype = datNormalSkill.tbl[functionId].hptype;
            datNormalSkill.tbl[406].koukatype = datNormalSkill.tbl[functionId].koukatype;
            datNormalSkill.tbl[406].magicbase = datNormalSkill.tbl[functionId].magicbase;
            datNormalSkill.tbl[406].magiclimit = datNormalSkill.tbl[functionId].magiclimit;
            datNormalSkill.tbl[406].minus = datNormalSkill.tbl[functionId].minus;
            datNormalSkill.tbl[406].mpbase = datNormalSkill.tbl[functionId].mpbase;
            datNormalSkill.tbl[406].mpn = datNormalSkill.tbl[functionId].mpn;
            datNormalSkill.tbl[406].mptype = datNormalSkill.tbl[functionId].mptype;
            datNormalSkill.tbl[406].program = datNormalSkill.tbl[functionId].program;
            datNormalSkill.tbl[406].targetarea = datNormalSkill.tbl[functionId].targetarea;
            datNormalSkill.tbl[406].targetcntmax = datNormalSkill.tbl[functionId].targetcntmax;
            datNormalSkill.tbl[406].targetcntmin = datNormalSkill.tbl[functionId].targetcntmin;
            datNormalSkill.tbl[406].targetprog = datNormalSkill.tbl[functionId].targetprog;
            datNormalSkill.tbl[406].targetrandom = datNormalSkill.tbl[functionId].targetrandom;
            datNormalSkill.tbl[406].targetrule = datNormalSkill.tbl[functionId].targetrule;
            datNormalSkill.tbl[406].targettype = targetType;
            datNormalSkill.tbl[406].untargetbadstat = datNormalSkill.tbl[functionId].untargetbadstat;
            datNormalSkill.tbl[406].use = 2;

            OverWriteSkillEffect(406, effectId);
        }

        private static void SwitchOutSkillCopy(ushort functionId, ushort effectId, byte targetType, bool applyBuff)
        {
            datSkill.tbl[407].flag = 0;
            datSkill.tbl[407].keisyoform = 512;
            datSkill.tbl[407].skillattr = datSkill.tbl[functionId].skillattr;
            datSkill.tbl[407].index = 408;
            datSkill.tbl[407].type = 0;

            datNormalSkill.tbl[407].badlevel = datNormalSkill.tbl[functionId].badlevel;
            datNormalSkill.tbl[407].badtype = datNormalSkill.tbl[functionId].badtype;
            datNormalSkill.tbl[407].basstatus = datNormalSkill.tbl[functionId].basstatus;
            datNormalSkill.tbl[407].cost = 0;
            datNormalSkill.tbl[407].costbase = 0;
            datNormalSkill.tbl[407].costtype = 2;
            datNormalSkill.tbl[407].criticalpoint = datNormalSkill.tbl[functionId].criticalpoint;
            datNormalSkill.tbl[407].deadtype = datNormalSkill.tbl[functionId].deadtype;
            datNormalSkill.tbl[407].failpoint = datNormalSkill.tbl[functionId].failpoint;
            datNormalSkill.tbl[407].flag = datNormalSkill.tbl[functionId].flag;
            datNormalSkill.tbl[407].hitlevel = datNormalSkill.tbl[functionId].hitlevel;
            datNormalSkill.tbl[407].hitprog = datNormalSkill.tbl[functionId].hitprog;
            datNormalSkill.tbl[407].hittype = datNormalSkill.tbl[functionId].hittype;
            datNormalSkill.tbl[407].hojopoint = applyBuff ? datNormalSkill.tbl[functionId].hojopoint : (sbyte) 0;
            datNormalSkill.tbl[407].hojotype = applyBuff ? datNormalSkill.tbl[functionId].hojotype : 1;
            datNormalSkill.tbl[407].hpbase = datNormalSkill.tbl[functionId].hpbase;
            datNormalSkill.tbl[407].hpn = datNormalSkill.tbl[functionId].hpn;
            datNormalSkill.tbl[407].hptype = datNormalSkill.tbl[functionId].hptype;
            datNormalSkill.tbl[407].koukatype = datNormalSkill.tbl[functionId].koukatype;
            datNormalSkill.tbl[407].magicbase = datNormalSkill.tbl[functionId].magicbase;
            datNormalSkill.tbl[407].magiclimit = datNormalSkill.tbl[functionId].magiclimit;
            datNormalSkill.tbl[407].minus = datNormalSkill.tbl[functionId].minus;
            datNormalSkill.tbl[407].mpbase = datNormalSkill.tbl[functionId].mpbase;
            datNormalSkill.tbl[407].mpn = datNormalSkill.tbl[functionId].mpn;
            datNormalSkill.tbl[407].mptype = datNormalSkill.tbl[functionId].mptype;
            datNormalSkill.tbl[407].program = datNormalSkill.tbl[functionId].program;
            datNormalSkill.tbl[407].targetarea = datNormalSkill.tbl[functionId].targetarea;
            datNormalSkill.tbl[407].targetcntmax = datNormalSkill.tbl[functionId].targetcntmax;
            datNormalSkill.tbl[407].targetcntmin = datNormalSkill.tbl[functionId].targetcntmin;
            datNormalSkill.tbl[407].targetprog = datNormalSkill.tbl[functionId].targetprog;
            datNormalSkill.tbl[407].targetrandom = datNormalSkill.tbl[functionId].targetrandom;
            datNormalSkill.tbl[407].targetrule = datNormalSkill.tbl[functionId].targetrule;
            datNormalSkill.tbl[407].targettype = targetType;
            datNormalSkill.tbl[407].untargetbadstat = datNormalSkill.tbl[functionId].untargetbadstat;
            datNormalSkill.tbl[407].use = 2;

            OverWriteSkillEffect(407, effectId);
            datNormalSkillVisual.tbl[407].motion = 0;
            datNormalSkillVisual.tbl[407].hatudo = 0;
        }

        private static void PostSummonSkillCopy(ushort functionId, ushort effectId, byte targetType)
        {
            datSkill.tbl[408].flag = 0;
            datSkill.tbl[408].keisyoform = 512;
            datSkill.tbl[408].skillattr = datSkill.tbl[functionId].skillattr;
            datSkill.tbl[408].index = 408;
            datSkill.tbl[408].type = 0;

            datNormalSkill.tbl[408].badlevel = datNormalSkill.tbl[functionId].badlevel;
            datNormalSkill.tbl[408].badtype = datNormalSkill.tbl[functionId].badtype;
            datNormalSkill.tbl[408].basstatus = datNormalSkill.tbl[functionId].basstatus;
            datNormalSkill.tbl[408].cost = 0;
            datNormalSkill.tbl[408].costbase = 0;
            datNormalSkill.tbl[408].costtype = 2;
            datNormalSkill.tbl[408].criticalpoint = datNormalSkill.tbl[functionId].criticalpoint;
            datNormalSkill.tbl[408].deadtype = datNormalSkill.tbl[functionId].deadtype;
            datNormalSkill.tbl[408].failpoint = datNormalSkill.tbl[functionId].failpoint;
            datNormalSkill.tbl[408].flag = datNormalSkill.tbl[functionId].flag;
            datNormalSkill.tbl[408].hitlevel = datNormalSkill.tbl[functionId].hitlevel;
            datNormalSkill.tbl[408].hitprog = datNormalSkill.tbl[functionId].hitprog;
            datNormalSkill.tbl[408].hittype = datNormalSkill.tbl[functionId].hittype;
            datNormalSkill.tbl[408].hojopoint = datNormalSkill.tbl[functionId].hojopoint;
            datNormalSkill.tbl[408].hojotype = datNormalSkill.tbl[functionId].hojotype;
            datNormalSkill.tbl[408].hpbase = datNormalSkill.tbl[functionId].hpbase;
            datNormalSkill.tbl[408].hpn = datNormalSkill.tbl[functionId].hpn;
            datNormalSkill.tbl[408].hptype = datNormalSkill.tbl[functionId].hptype;
            datNormalSkill.tbl[408].koukatype = datNormalSkill.tbl[functionId].koukatype;
            datNormalSkill.tbl[408].magicbase = datNormalSkill.tbl[functionId].magicbase;
            datNormalSkill.tbl[408].magiclimit = datNormalSkill.tbl[functionId].magiclimit;
            datNormalSkill.tbl[408].minus = datNormalSkill.tbl[functionId].minus;
            datNormalSkill.tbl[408].mpbase = datNormalSkill.tbl[functionId].mpbase;
            datNormalSkill.tbl[408].mpn = datNormalSkill.tbl[functionId].mpn;
            datNormalSkill.tbl[408].mptype = datNormalSkill.tbl[functionId].mptype;
            datNormalSkill.tbl[408].program = datNormalSkill.tbl[functionId].program;
            datNormalSkill.tbl[408].targetarea = datNormalSkill.tbl[functionId].targetarea;
            datNormalSkill.tbl[408].targetcntmax = datNormalSkill.tbl[functionId].targetcntmax;
            datNormalSkill.tbl[408].targetcntmin = datNormalSkill.tbl[functionId].targetcntmin;
            datNormalSkill.tbl[408].targetprog = datNormalSkill.tbl[functionId].targetprog;
            datNormalSkill.tbl[408].targetrandom = datNormalSkill.tbl[functionId].targetrandom;
            datNormalSkill.tbl[408].targetrule = datNormalSkill.tbl[functionId].targetrule;
            datNormalSkill.tbl[408].targettype = targetType;
            datNormalSkill.tbl[408].untargetbadstat = datNormalSkill.tbl[functionId].untargetbadstat;
            datNormalSkill.tbl[408].use = 2;

            OverWriteSkillEffect(408, effectId);
        }

        private static void Ramayana(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 13;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 2;
            datNormalSkill.tbl[id].basstatus = 1535;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 44);
        }

        private static void DarkMirrorCopy(ushort id)
        {
            datSkill.tbl[417].flag = 0;
            datSkill.tbl[417].keisyoform = 512;
            datSkill.tbl[417].skillattr = datSkill.tbl[id].skillattr;
            datSkill.tbl[417].index = 417;
            datSkill.tbl[417].type = 0;

            datNormalSkill.tbl[417].badlevel = datNormalSkill.tbl[id].badlevel;
            datNormalSkill.tbl[417].badtype = datNormalSkill.tbl[id].badtype;
            datNormalSkill.tbl[417].basstatus = datNormalSkill.tbl[id].basstatus;
            datNormalSkill.tbl[417].cost = 0;
            datNormalSkill.tbl[417].costbase = 0;
            datNormalSkill.tbl[417].costtype = 0;
            datNormalSkill.tbl[417].criticalpoint = datNormalSkill.tbl[id].criticalpoint;
            datNormalSkill.tbl[417].deadtype = datNormalSkill.tbl[id].deadtype;
            datNormalSkill.tbl[417].failpoint = datNormalSkill.tbl[id].failpoint;
            datNormalSkill.tbl[417].flag = datNormalSkill.tbl[id].flag;
            datNormalSkill.tbl[417].hitlevel = datNormalSkill.tbl[id].hitlevel;
            datNormalSkill.tbl[417].hitprog = datNormalSkill.tbl[id].hitprog;
            datNormalSkill.tbl[417].hittype = datNormalSkill.tbl[id].hittype;
            datNormalSkill.tbl[417].hojopoint = datNormalSkill.tbl[id].hojopoint;
            datNormalSkill.tbl[417].hojotype = datNormalSkill.tbl[id].hojotype;
            datNormalSkill.tbl[417].hpbase = datNormalSkill.tbl[id].hpbase;
            datNormalSkill.tbl[417].hpn = Convert.ToInt16(datNormalSkill.tbl[id].hpn / 2);
            datNormalSkill.tbl[417].hptype = datNormalSkill.tbl[id].hptype;
            datNormalSkill.tbl[417].koukatype = datNormalSkill.tbl[id].koukatype;
            datNormalSkill.tbl[417].magicbase = datNormalSkill.tbl[id].magicbase;
            datNormalSkill.tbl[417].magiclimit = datNormalSkill.tbl[id].magiclimit;
            datNormalSkill.tbl[417].minus = datNormalSkill.tbl[id].minus;
            datNormalSkill.tbl[417].mpbase = datNormalSkill.tbl[id].mpbase;
            datNormalSkill.tbl[417].mpn = Convert.ToInt16(datNormalSkill.tbl[id].mpn / 2);
            datNormalSkill.tbl[417].mptype = datNormalSkill.tbl[id].mptype;
            datNormalSkill.tbl[417].program = datNormalSkill.tbl[id].program;
            datNormalSkill.tbl[417].targetarea = datNormalSkill.tbl[id].targetarea;
            datNormalSkill.tbl[417].targetcntmax = datNormalSkill.tbl[id].targetcntmax;
            datNormalSkill.tbl[417].targetcntmin = datNormalSkill.tbl[id].targetcntmin;
            datNormalSkill.tbl[417].targetprog = datNormalSkill.tbl[id].targetprog;
            datNormalSkill.tbl[417].targetrandom = datNormalSkill.tbl[id].targetrandom;
            datNormalSkill.tbl[417].targetrule = datNormalSkill.tbl[id].targetrule;
            datNormalSkill.tbl[417].targettype = 0;
            datNormalSkill.tbl[417].untargetbadstat = datNormalSkill.tbl[id].untargetbadstat;
            datNormalSkill.tbl[417].use = 2;

            OverWriteSkillEffect(417, id);
        }

        private static void Verdict(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 5;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 1;
            datNormalSkill.tbl[id].magiclimit = 1;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 100;
            datNormalSkill.tbl[id].mptype = 8;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 196);
        }

        private static void DevilTrigger(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 15;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 0;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 0;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 3;
            datNormalSkill.tbl[id].targetarea = 1;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 1;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 226);
            datNormalSkillVisual.tbl[id].bedno = datNormalSkillVisual.tbl[15].bedno;
            datNormalSkillVisual.tbl[id].hatudo = datNormalSkillVisual.tbl[15].hatudo;
        }

        private static void DevilRegeneration(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 15;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 50;
            datNormalSkill.tbl[id].hpn = 0;
            datNormalSkill.tbl[id].hptype = 11;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 1;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 81);
            datNormalSkillVisual.tbl[id].motion = 0;
            datNormalSkillVisual.tbl[id].hatudo = 0;
        }

        private static void Pain(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 16;
            datSkill.tbl[id].skillattr = 5;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 33;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 150;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 27, 107);
            datNormalSkillVisual.tbl[id].motion = 8;
        }

        private static void SpitefulForce(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 5;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 25;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 152);
            datNormalSkillVisual.tbl[id].motion = 13;
        }

        // Lucifer Skills

        private static void DarkMatter(ushort id)
        {
            datNormalSkill.tbl[id].criticalpoint = 29;
            datNormalSkill.tbl[id].hptype = 14;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].mptype = 14;
            datNormalSkill.tbl[id].mpn = 10;
        }

        private static void EvilGleam(ushort id)
        {
            datSkill.tbl[id].skillattr = 5;

            datNormalSkill.tbl[id].badlevel = 36;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 8;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
        }

        private static void RootOfEvil(ushort id)
        {
            datSkill.tbl[id].skillattr = 15;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hptype = 8;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].targetarea = 2;
        }

        private static void HighKing(ushort id)
        {
            datNormalSkill.tbl[id].badlevel = 36;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 32;
            datNormalSkill.tbl[id].hpn = 90;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
        }

        private static void Phlegethon(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 1;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 10;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 177);
        }

        private static void JudeccaTomb(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 2;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 27;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 1025;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 181);
        }

        private static void WeepingHeaven(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 3;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 27;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 258;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 183);
        }

        private static void CarnalWinds(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 4;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 27;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 128;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 24);
        }

        // YHVH Skills

        private static void Scorn(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 15;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 1;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 2;
            datNormalSkill.tbl[id].hojotype = 4096;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 13;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            datNormalSkillVisual.tbl[id] = new datNormalSkillVisual_t
            {
                motion = 2,//datNormalSkillVisual.tbl[0].motion,
                animetype = datNormalSkillVisual.tbl[0].animetype,
                hatudo = datNormalSkillVisual.tbl[0].hatudo,
                bedno = datNormalSkillVisual.tbl[0].bedno
            };
            nbActionProcess.sobedtbl[id] = new nbActionProcess.SOBED
            {
                keyname = nbActionProcess.sobedtbl[96].keyname,
                bed_fname = nbActionProcess.sobedtbl[96].bed_fname,
                se0_str = nbActionProcess.sobedtbl[0].se0_str,
                se1_str = nbActionProcess.sobedtbl[0].se1_str,
                tga_fname = nbActionProcess.sobedtbl[96].tga_fname,
                pbdata = nbActionProcess.sobedtbl[96].pbdata
            };
            nbCamera_SkillPtrTable.tbl[id] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[96].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[96].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[96].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[96].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[96].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[96].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[96].anim
            };
        }

        private static void YHVHCrush(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 16;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 30;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 45;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 96, 107);
        }

        private static void Rampage(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 128;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 10;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 0;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 8;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 1;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 98);
            datNormalSkillVisual.tbl[id].motion = 5;
            nbCamera_SkillPtrTable.tbl[id] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[208].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[208].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[208].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[208].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[208].anim
            };
        }

        private static void InfernoOfGod(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 1;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 45;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 178);
            datNormalSkillVisual.tbl[id].motion = 4;
            nbCamera_SkillPtrTable.tbl[id] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[208].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[208].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[208].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[208].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[208].anim
            };
        }

        private static void HailstormOfGod(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 2;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 45;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 181);
            datNormalSkillVisual.tbl[id].motion = 4;
            nbCamera_SkillPtrTable.tbl[id] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[208].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[208].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[208].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[208].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[208].anim
            };
        }

        private static void LightningOfGod(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 3;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 45;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 183);
            datNormalSkillVisual.tbl[id].motion = 4;
            nbCamera_SkillPtrTable.tbl[id] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[208].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[208].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[208].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[208].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[208].anim
            };
        }

        private static void TornadoOfGod(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 4;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 45;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 24);
            datNormalSkillVisual.tbl[id].motion = 4;
            nbCamera_SkillPtrTable.tbl[id] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[208].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[208].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[208].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[208].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[208].anim
            };
        }

        private static void PlannedChaos(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 5;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 3;
            datNormalSkill.tbl[id].basstatus = 508;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 150;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 25, 270);
            datNormalSkillVisual.tbl[id].motion = 6;
            nbCamera_SkillPtrTable.tbl[id] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[208].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[208].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[208].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[208].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[208].anim
            };
        }

        private static void MouthOfGod(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 5;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2048;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 100;
            datNormalSkill.tbl[id].hptype = 8;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 32, 243);
            datNormalSkillVisual.tbl[id].motion = 7;
            nbCamera_SkillPtrTable.tbl[id] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[208].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[208].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[208].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[208].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[208].anim
            };
        }

        private static void BlackHole(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 5;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 150;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 0;
            datNormalSkill.tbl[id].hojotype = 99;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 10;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 32;
            datNormalSkill.tbl[id].mptype = 12;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 191);
            datNormalSkillVisual.tbl[id].motion = 6;
            nbCamera_SkillPtrTable.tbl[id] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[208].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[208].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[208].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[208].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[208].anim
            };
        }

        private static void Supernova(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 5;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 221);
            datNormalSkillVisual.tbl[id].motion = 4;
            nbCamera_SkillPtrTable.tbl[id] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[208].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[208].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[208].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[208].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[208].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[208].anim
            };
        }

        private static void InfinitePower(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 14;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 6;
            datNormalSkill.tbl[id].hojotype = 341;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 1;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 224);
            datNormalSkillVisual.tbl[id].motion = 3;
        }

        private static void UnendingCurse(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 14;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 6;
            datNormalSkill.tbl[id].hojotype = 682;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 208);
            datNormalSkillVisual.tbl[id].motion = 9;
        }

        private static void DivineHarmony(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 14;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 0;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 263168;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 2;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 50);
            datNormalSkillVisual.tbl[id].motion = 10;
        }

        // Passive Skills

        private static void Might(ushort id)
        {
            datSkill.tbl[299].skillattr = 0;

            datSpecialSkill.tbl[id].n = 750;
        }

        private static void BrightMight(ushort id)
        {
            datSkill.tbl[300].skillattr = 0;
        }

        private static void DarkMight(ushort id)
        {
            datSkill.tbl[301].skillattr = 0;
        }

        private static void DrainAttack(ushort id)
        {
            datSkill.tbl[302].skillattr = 0;

            datSpecialSkill.tbl[id].n = 1;
        }

        private static void AttackAll(ushort id)
        {
            datSkill.tbl[304].skillattr = 0;
        }

        private static void CounterPassive(ushort id)
        {
            datSkill.tbl[305].skillattr = 0;
        }

        private static void RetaliatePassive(ushort id)
        {
            datSkill.tbl[306].skillattr = 0;
        }

        private static void AvengePassive(ushort id)
        {
            datSkill.tbl[307].skillattr = 0;
        }

        private static void LifeAid(ushort id)
        {
            datSpecialSkill.tbl[id].n = 2;
        }

        private static void ManaAid(ushort id)
        {
            datSkill.tbl[347].skillattr = 15;

            datSpecialSkill.tbl[id].n = 4;
        }

        private static void VictoryCry(ushort id)
        {
            datSkill.tbl[348].skillattr = 15;
        }

        private static void LifeRefill(ushort id)
        {
            datSpecialSkill.tbl[id].n = 4;
        }

        private static void ManaRefill(ushort id)
        {
            datSkill.tbl[350].skillattr = 15;

            datSpecialSkill.tbl[id].n = 10;
        }

        private static void DoubleAttackPassive(ushort id)
        {
            datSkill.tbl[308].keisyoform = 1;
            datSkill.tbl[308].skillattr = 0;
            datSkill.tbl[308].type = 1;

            datSpecialSkill.tbl[id].a = 2;
            datSpecialSkill.tbl[id].b = 1;
            datSpecialSkill.tbl[id].m = 3;
            datSpecialSkill.tbl[id].n = 4;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = 308;
            skillLevel.Level = 7;
        }

        private static void PhysBoost(ushort id)
        {
            datSkill.tbl[362].keisyoform = 1;
            datSkill.tbl[362].skillattr = 0;
            datSkill.tbl[362].type = 1;

            datSpecialSkill.tbl[id].a = 2;
            datSpecialSkill.tbl[id].b = 1;
            datSpecialSkill.tbl[id].m = 3;
            datSpecialSkill.tbl[id].n = 4;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = 362;
            skillLevel.Level = 8;
        }

        private static void MagicBoost(ushort id)
        {
            datSkill.tbl[363].keisyoform = 1;
            datSkill.tbl[363].skillattr = 15;
            datSkill.tbl[363].type = 1;

            datSpecialSkill.tbl[id].a = 2;
            datSpecialSkill.tbl[id].b = 1;
            datSpecialSkill.tbl[id].m = 3;
            datSpecialSkill.tbl[id].n = 4;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = 363;
            skillLevel.Level = 8;
        }

        private static void AntiElements(ushort id)
        {
            datSkill.tbl[364].keisyoform = 1;
            datSkill.tbl[364].skillattr = 15;
            datSkill.tbl[364].type = 1;

            datSpecialSkill.tbl[id].a = 0;
            datSpecialSkill.tbl[id].b = 0;
            datSpecialSkill.tbl[id].m = 0;
            datSpecialSkill.tbl[id].n = 50;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = 364;
            skillLevel.Level = 8;
        }

        private static void AntiAilments(ushort id)
        {
            datSkill.tbl[365].keisyoform = 1;
            datSkill.tbl[365].skillattr = 15;
            datSkill.tbl[365].type = 1;

            datSpecialSkill.tbl[id].a = 0;
            datSpecialSkill.tbl[id].b = 0;
            datSpecialSkill.tbl[id].m = 0;
            datSpecialSkill.tbl[id].n = 50;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = 365;
            skillLevel.Level = 8;
        }

        private static void AbyssalMask(ushort id)
        {
            datSkill.tbl[366].keisyoform = 1;
            datSkill.tbl[366].skillattr = 15;
            datSkill.tbl[366].type = 1;

            datSpecialSkill.tbl[id].a = 2;
            datSpecialSkill.tbl[id].b = 1;
            datSpecialSkill.tbl[id].m = 3;
            datSpecialSkill.tbl[id].n = 4;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = 366;
            skillLevel.Level = 8;
        }

        private static void KnowledgeOfTools(ushort id)
        {
            datSkill.tbl[367].keisyoform = 1;
            datSkill.tbl[367].skillattr = 15;
            datSkill.tbl[367].type = 1;

            datSpecialSkill.tbl[id].a = 2;
            datSpecialSkill.tbl[id].b = 1;
            datSpecialSkill.tbl[id].m = 3;
            datSpecialSkill.tbl[id].n = 4;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = 367;
            skillLevel.Level = 5;
        }

        private static void RenewalPassive(ushort id)
        {
            datSkill.tbl[368].keisyoform = 1;
            datSkill.tbl[368].skillattr = 13;
            datSkill.tbl[368].type = 1;

            datSpecialSkill.tbl[id].a = 2;
            datSpecialSkill.tbl[id].b = 1;
            datSpecialSkill.tbl[id].m = 3;
            datSpecialSkill.tbl[id].n = 4;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = 368;
            skillLevel.Level = 3;
        }

        private static void SpiritWellPassive(ushort id)
        {
            datSkill.tbl[369].keisyoform = 1;
            datSkill.tbl[369].skillattr = 15;
            datSkill.tbl[369].type = 1;

            datSpecialSkill.tbl[id].a = 2;
            datSpecialSkill.tbl[id].b = 1;
            datSpecialSkill.tbl[id].m = 3;
            datSpecialSkill.tbl[id].n = 4;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = 369;
            skillLevel.Level = 3;
        }

        private static void QigongPassive(ushort id)
        {
            datSkill.tbl[370].keisyoform = 1;
            datSkill.tbl[370].skillattr = 15;
            datSkill.tbl[370].type = 1;

            datSpecialSkill.tbl[id].a = 2;
            datSpecialSkill.tbl[id].b = 1;
            datSpecialSkill.tbl[id].m = 3;
            datSpecialSkill.tbl[id].n = 4;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = 370;
            skillLevel.Level = 7;
        }

        private static void ArmsMaster(ushort id)
        {
            datSkill.tbl[371].keisyoform = 1;
            datSkill.tbl[371].skillattr = 0;
            datSkill.tbl[371].type = 1;

            datSpecialSkill.tbl[id].a = 2;
            datSpecialSkill.tbl[id].b = 1;
            datSpecialSkill.tbl[id].m = 3;
            datSpecialSkill.tbl[id].n = 4;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = 371;
            skillLevel.Level = 7;
        }

        private static void FirmStance(ushort id)
        {
            datSkill.tbl[372].keisyoform = 1;
            datSkill.tbl[372].skillattr = 15;
            datSkill.tbl[372].type = 1;

            datSpecialSkill.tbl[id].a = 2;
            datSpecialSkill.tbl[id].b = 1;
            datSpecialSkill.tbl[id].m = 3;
            datSpecialSkill.tbl[id].n = 4;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = 372;
            skillLevel.Level = 6;
        }

        private static void ShotBoost(ushort id)
        {
            datSkill.tbl[373].keisyoform = 1;
            datSkill.tbl[373].skillattr = 12;
            datSkill.tbl[373].type = 1;

            datSpecialSkill.tbl[id].a = 2;
            datSpecialSkill.tbl[id].b = 1;
            datSpecialSkill.tbl[id].m = 3;
            datSpecialSkill.tbl[id].n = 4;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = 373;
            skillLevel.Level = 8;
        }

        private static void AntiShot(ushort id)
        {
            datSkill.tbl[374].keisyoform = 1;
            datSkill.tbl[374].skillattr = 12;
            datSkill.tbl[374].type = 1;

            datSpecialSkill.tbl[id].a = 0;
            datSpecialSkill.tbl[id].b = 0;
            datSpecialSkill.tbl[id].m = 0;
            datSpecialSkill.tbl[id].n = 0;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = 374;
            skillLevel.Level = 5;
        }

        private static void NullShot(ushort id)
        {
            datSkill.tbl[375].keisyoform = 1;
            datSkill.tbl[375].skillattr = 12;
            datSkill.tbl[375].type = 1;

            datSpecialSkill.tbl[id].a = 0;
            datSpecialSkill.tbl[id].b = 0;
            datSpecialSkill.tbl[id].m = 0;
            datSpecialSkill.tbl[id].n = 0;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = 375;
            skillLevel.Level = 10;
        }

        private static void ShotDrain(ushort id)
        {
            datSkill.tbl[376].keisyoform = 1;
            datSkill.tbl[376].skillattr = 12;
            datSkill.tbl[376].type = 1;

            datSpecialSkill.tbl[id].a = 0;
            datSpecialSkill.tbl[id].b = 0;
            datSpecialSkill.tbl[id].m = 0;
            datSpecialSkill.tbl[id].n = 0;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = 376;
            skillLevel.Level = 11;
        }

        private static void ShotRepel(ushort id)
        {
            datSkill.tbl[377].keisyoform = 1;
            datSkill.tbl[377].skillattr = 12;
            datSkill.tbl[377].type = 1;

            datSpecialSkill.tbl[id].a = 0;
            datSpecialSkill.tbl[id].b = 0;
            datSpecialSkill.tbl[id].m = 0;
            datSpecialSkill.tbl[id].n = 0;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.FirstOrDefault(x => x.SkillID == 0);
            skillLevel.SkillID = 377;
            skillLevel.Level = 12;
        }

        private static void SolitaryDrift(ushort id)
        {
            datSkill.tbl[378].keisyoform = 1;
            datSkill.tbl[378].skillattr = 15;
            datSkill.tbl[378].type = 1;

            datSpecialSkill.tbl[id].a = 2;
            datSpecialSkill.tbl[id].b = 1;
            datSpecialSkill.tbl[id].m = 3;
            datSpecialSkill.tbl[id].n = 4;
        }

        private static void Pierce(ushort id)
        {
            datSkill.tbl[379].keisyoform = 1;
            datSkill.tbl[379].skillattr = 15;
            datSkill.tbl[379].type = 1;

            datSpecialSkill.tbl[id].a = 2;
            datSpecialSkill.tbl[id].b = 1;
            datSpecialSkill.tbl[id].m = 3;
            datSpecialSkill.tbl[id].n = 4;
        }

        // Talk Skills

        private static void TalkSkillChanges()
        {
            datSkill.tbl[355].skillattr = 15; // Charisma
            datSkill.tbl[384].skillattr = 15; // Talk
            datSkill.tbl[385].skillattr = 15; // Scout
            datSkill.tbl[386].skillattr = 15; // Kidnap
            datSkill.tbl[387].skillattr = 15; // Seduce
            datSkill.tbl[388].skillattr = 15; // Brainwash
            datSkill.tbl[389].skillattr = 15;
            datSkill.tbl[390].skillattr = 15; // Dark Pledge
            datSkill.tbl[391].skillattr = 15; // Wooing
            datSkill.tbl[392].skillattr = 15; // Beseech
            datSkill.tbl[393].skillattr = 15; // Soul Recruit
            datSkill.tbl[394].skillattr = 15; // Mischief
            datSkill.tbl[395].skillattr = 15; // Death Pact
            datSkill.tbl[396].skillattr = 15; // Plead
            datSkill.tbl[397].skillattr = 15; // Begging
            datSkill.tbl[398].skillattr = 15; // Threaten
            datSkill.tbl[399].skillattr = 15; // Stone Hunt
            datSkill.tbl[400].skillattr = 15; // Trade
            datSkill.tbl[401].skillattr = 15; // Loan
            datSkill.tbl[402].skillattr = 15;
            datSkill.tbl[409].skillattr = 15; // Haggle
            datSkill.tbl[410].skillattr = 15; // Arbitration
            datSkill.tbl[411].skillattr = 15; // Detain
            datSkill.tbl[412].skillattr = 15; // Kinspeak
            datSkill.tbl[413].skillattr = 15; // Silver Tongue
            datSkill.tbl[414].skillattr = 15; // Intimidate
            datSkill.tbl[415].skillattr = 15; // Entice
            datSkill.tbl[418].skillattr = 15; // Maiden Plea
            datSkill.tbl[419].skillattr = 15; // Wine Party
            datSkill.tbl[420].skillattr = 15; // Flatter
            datSkill.tbl[421].skillattr = 15; // Jive Talk
        }

        // Skill Upgrade Changes

        private static void SkillUpgradeChanges()
        {
            Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray<Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray<ushort>> newSkillPowerUpTbl = 
                new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray<Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray<ushort>>(57);

            for (int i = 0; i <= 54; i++)
                newSkillPowerUpTbl[i] = tblSkillPowerUp.fclSkillPowerUpTbl[i];

            newSkillPowerUpTbl[55] = new ushort[2] { 374, 375 };
            newSkillPowerUpTbl[56] = new ushort[2] { 375, 376 };

            tblSkillPowerUp.fclSkillPowerUpTbl = newSkillPowerUpTbl;
        }
    }
}
