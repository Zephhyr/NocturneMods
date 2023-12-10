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
        public static int[] bossList = new int[] { 256, 257, 294, 295, 296, 300, 301, 302, 339, 349 };
        public static nbActionProcessData_t? actionProcessData;

        [HarmonyPatch(typeof(datSkillName), nameof(datSkillName.Get))]
        private class SkillNamesPatch
        {
            public static bool Prefix(ref int id, ref string __result)
            {
                switch (id)
                {            
                    // Vanilla Skills
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
                    case 179: __result = "Trisagion"; return false;      
                    case 202: __result = "Toxic Spray"; return false;           
                    case 219: __result = "Rage"; return false;           
                    case 220: __result = "Psycho Rage"; return false;
                    case 285: __result = "Babylon Goblet"; return false;
                    case 286: __result = "Death Lust"; return false;

                    // New Skills
                    case 188: __result = "Punishment"; return false;      
                    case 189: __result = "Judgement Light"; return false;      

                    case 360: __result = "Never Yield"; return false;      
                    case 362: __result = "Phys Boost"; return false;      
                    case 363: __result = "Magic Boost"; return false;      
                    case 364: __result = "Anti-Magic"; return false;      
                    case 365: __result = "Anti-Ailments"; return false;
                    case 366: __result = "Abyssal Mask"; return false;
                    case 367: __result = "Knowledge of Tools"; return false;
                    case 368: __result = "Laevateinn"; return false;

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
                    case 451: __result = "Neural Storm"; return false;
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
                    case 28: __result = "Low Light damage to one foe. \nMay instakill when weak to Light."; return false; // Hama
                    case 29: __result = "High Light damage to one foe. \nMay instakill when weak to Light."; return false; // Hamaon
                    case 30: __result = "Low Light damage to all foes. \nMay instakill when weak to Light."; return false; // Mahama
                    case 31: __result = "High Light damage to all foes. \nMay instakill when weak to Light."; return false; // Mahamaon
                    case 32: __result = "Low Dark damage to one foe. \nMay instakill when weak to Dark."; return false; // Mudo
                    case 33: __result = "High Dark damage to one foe. \nMay instakill when weak to Dark."; return false; // Mudoon
                    case 34: __result = "Low Dark damage to all foes. \nMay instakill when weak to Dark."; return false; // Mamudo
                    case 35: __result = "High Dark damage to all foes. \nMay instakill when weak to Dark."; return false; // Mamudoon
                    //case 42: __result = "Donates MP to one ally."; return false; // Makatora
                    case 59: __result = "Low Nerve damage to one foe. \nMay inflict Bind."; return false; // Shibaboo
                    case 61: __result = "Low Mind damage to one foe. \nMay inflict Panic."; return false; // Pulinpa
                    case 63: __result = "High Mind damage to all foes. \nMay inflict Panic."; return false; // Tentarafoo
                    case 64: __result = "Raises party's \nPhysical/Magical Attack."; return false; // Tarukaja
                    case 67: __result = "Raises party's \nMagical Attack/Hit Rate."; return false; // Makakaja
                    case 69: __result = "Repels Magical attacks \nfor one ally once \nnext turn."; return false; // Makarakarn
                    case 70: __result = "Repels Physical attacks \nfor one ally once \nnext turn."; return false; // Tetrakarn
                    case 90: __result = "Low Curse damage to one foe. \nMay inflict Poison."; return false; // Poison Arrow
                    case 101: __result = "Low Physical damage to all foes. \nDamage relative to HP."; return false; // Heat Wave
                    case 102: __result = "Medium Physical damage to all foes. \n May inflict Poison. \nDamage relative to HP."; return false; // Blight
                    case 103: __result = "Medium Physical damage to one foe. \nDamage relative to HP."; return false; // Brutal Slash
                    case 104: __result = "Massive Physical damage to all foes. \nDamage relative to HP."; return false; // Hassohappa
                    case 105: __result = "Massive Physical damage to one foe. \nMay inflict Mute. \nDamage relative to HP."; return false; // Dark Sword
                    case 106: __result = "Massive Physical damage to one foe. \nMay inflict Bind. \nDamage relative to HP."; return false; // Stasis Blade
                    case 107: __result = "Low Physical damage to one foe. \nDamage relative to HP."; return false; // Mighty Gust
                    case 108: __result = "High Physical damage to random foes. \nDamage relative to HP."; return false; // Deathbound
                    case 109: __result = "High Physical damage to one foe. \nMay inflict Stun. \nDamage relative to HP."; return false; // Guillotine
                    case 110: __result = "High Physical damage to random foes. \nMay inflict Panic. \nDamage relative to HP."; return false; // Deathbound
                    case 127: __result = "High Light damage to all foes. \nMay inflict Mute."; return false; // Godly Light
                    case 131: __result = "High Physical damage to all foes. \nHigh critical rate."; return false; // Deadly Fury
                    case 133: __result = "Medium Physical damage to all foes. \nMay inflict Bind."; return false; // Javelin Rain
                    case 136: __result = "High Physical damage to one foe."; return false; // Divine Shot
                    case 143: __result = "High Physical damage to all foes. \nMay inflict Mute."; return false; // Xeros Beat
                    case 144: __result = "High Physical damage to all foes."; return false; // Oni Kagura
                    case 147: __result = "Massive Strength-based Almighty damage to one foe."; return false; // Freikugel
                    case 181: __result = "Medium Ice damage to random foes."; return false; // Glacial Blast
                    case 183: __result = "Medium Elec damage to random foes."; return false; // Bolt Storm
                    case 185: __result = "Medium Force damage to random foes."; return false; // Tornado
                    case 187: __result = "High Force damage to all foes. \nMay inflict Stun."; return false; // Wet Wind
                    case 193: __result = "Medium Light damage to one foe."; return false; // Violet Flash
                    case 194: __result = "Medium Light damage to all foes."; return false; // Starlight
                    case 195: __result = "Massive Light damage to all foes."; return false; // Radiance
                    case 199: __result = "Dark: Chance to reduce HP of one foe to 1."; return false; // Evil Gaze
                    case 202: __result = "Lowers all foes' Defense. \nMay inflict Poison."; return false; // Toxic Cloud
                    case 207: __result = "Medium Curse damage to all foes. \nMay inflict Mute."; return false; // Dismal Tune
                    case 208: __result = "Chance to reduce HP of all foes to 1."; return false; // Sol Niger
                    case 217: __result = "Massive Mind damage to all foes. \nMay inflict Panic."; return false; // Intoxicate
                    case 224: __result = "More than doubles damage \nof next Physical attack."; return false; // Focus
                    case 242: __result = "High Almighty damage to all foes. \nMay inflict random ailments."; return false; // God's Curse
                    case 244: __result = "Medium Ice damage to all foes. \nLowers targets' Evasion/Hit Rate."; return false; // Icy Death
                    case 249: __result = "High Mind damage to random foes. \nMay inflict Panic."; return false; // Wild Dance
                    case 250: __result = "Drains HP/MP from one foe."; return false; // Domination
                    case 259: __result = "Massive Almighty damage to all foes. \nInstakills when not immune to Dark."; return false; // Death Flies
                    case 260: __result = "Massive Almighty damage to all foes. \nInstakills when not immune to Dark."; return false; // Death Flies
                    case 261: __result = "High Curse damage to all foes. \nInflicts Mute. Low accuracy."; return false; // Soul Divide
                    case 262: __result = "Low Physical damage to one foe. \nLowers target's Evasion/Defense."; return false; // Boogie-Woogie/E & I
                    case 267: __result = "High Elec damage to all foes. \nLowers targets' Evasion/Hit Rate."; return false; // Mishaguji Raiden/Roundtrip
                    case 268: __result = "High Force damage to all foes. \nLowers targets' Physical/Magical Attack."; return false; // Hitokoto Storm/Whirlwind
                    case 276: __result = "Maximizes own Evasion/Hit Rate."; return false; // Red Capote
                    case 278: __result = "Medium Mind damage to all foes. \nMay inflict random ailments."; return false; // Preach
                    case 280: __result = "Medium Physical damage to random foes. \nMay inflict Panic."; return false; // Terrorblade
                    case 281: __result = "Medium Physical damage to all foes."; return false; // Hell Spin
                    case 282: __result = "Medium Force damage to all foes. \nNegates -kaja effects."; return false; // Hell Exhaust
                    case 283: __result = "Medium Strength-based Fire damage \nto all foes."; return false; // Hell Burner
                    case 284: __result = "Raises party's Physical Attack/Evasion/Hit Rate."; return false; // Hell Throttle
                    case 285: __result = "Lowers all foes' Evasion/Hit Rate. \nMay inflict Panic."; return false; // Babylon Goblet
                    case 286: __result = "High Almighty damage to all foes. \nHeals user's HP and may inflict Charm."; return false; // Death Lust
                    case 287: __result = "Massive Light damage to one foe. \nInstakills when weak to Light."; return false; // God's Bow
                    case 296: __result = "Guarantees escape \nwhen possible."; return false; // Fast Retreat
                    case 298: __result = "Prevents being attacked \nfrom behind."; return false; // Mind's Eye
                    case 299: __result = "Greatly raises critical \nhit rate of normal attacks."; return false; // Might
                    case 300: __result = "Drastically raises critical \nhit rate of normal attacks \nduring full Kagutsuchi."; return false; // Bright Might
                    case 301: __result = "Drastically raises critical \nhit rate of normal attacks \nduring new Kagutsuchi."; return false; // Dark Might
                    case 309: __result = "Raises Fire attack damage by 30%."; return false; // Fire Boost
                    case 310: __result = "Raises Ice attack damage by 30%."; return false; // Ice Boost
                    case 311: __result = "Raises Elec attack damage by 30%."; return false; // Elec Boost
                    case 312: __result = "Raises Force attack damage by 30%."; return false; // Force Boost
                    case 313: __result = "Protects against Physical attacks"; return false; // Anti-Phys
                    case 314: __result = "Protects against Fire attacks"; return false; // Anti-Fire
                    case 315: __result = "Protects against Ice attacks"; return false; // Anti-Ice
                    case 316: __result = "Protects against Elec attacks"; return false; // Anti-Elec
                    case 317: __result = "Protects against Force attacks"; return false; // Anti-Force
                    case 354: __result = "Earn 100% EXP when \nnot participating in battle."; return false; // Watchful
                    case 357: __result = "Attacks ignore all resistances \nexcept Repel."; return false; // Pierce
                    case 360: __result = "Protects against ailments and instakills \n& Survive a fatal blow with 1 HP \nremaining once per battle."; return false; // Raidou Endure/Never Yield
                    case 361: __result = "Pierce & raises damage of all attacks by 30%."; return false; // Raidou the Eternal/Son's Oath
                    
                    // New Skills
                    case 188: __result = "Light: Chance to instakill one foe."; return false; // Punishment
                    case 189: __result = "Light: Chance to instakill all foes."; return false; // Judgement Light

                    case 362: __result = "Raises Physical attack damage by 30%."; return false; // Phys Boost 
                    case 363: __result = "Raises Magical attack damage by 30%."; return false; // Magic Boost
                    case 364: __result = "Protects against Magical attacks."; return false; // Anti-Magic 
                    case 365: __result = "Protects against Ailment attacks."; return false; // Anti-Ailments
                    case 366: __result = "Protects against ailments and instakills."; return false; // Abyssal Mask
                    case 367: __result = "Allows the use of items."; return false; // Knowledge of Tools
                    case 368: __result = "Fire Boost & greatly empowers \nnormal attacks."; return false; // Laevateinn

                    case 424: __result = "More than doubles damage \nof next Magical attack."; return false; // Concentrate
                    case 425: __result = "More than doubles damage \nof next attack and grants Pierce."; return false; // Impaler's Animus
                    case 426: __result = "High Physical damage to all foes. \nMay inflict Charm."; return false; // Sakura Rage
                    case 427: __result = "Low Physical damage to one foe. \nLowers target's Physical Attack."; return false; // Fang Breaker
                    case 428: __result = "Low Physical damage to one foe. \nLowers target's Defense."; return false; // Defense Kuzushi
                    case 429: __result = "Massive Physical damage to one foe."; return false; // Primal Force
                    case 430: __result = "Low Physical damage to all foes. \nHigh critical rate."; return false; // Chi Blast
                    case 431: __result = "High Physical damage to all foes. \nMay inflict Mute."; return false; // Revelation
                    case 432: __result = "High Physical damage to all foes. \nMay inflict Stone."; return false; // Gate of Hell
                    case 433: __result = "High Physical damage to one foe. \nHigh critical rate."; return false; // Akashic Arts
                    case 434: __result = "High Physical damage to random foes. \nHigh critial rate."; return false; // Bloodbath
                    case 435: __result = "Low Fire damage to all foes. \nLowers targets' Physical Attack."; return false; // Scald
                    case 436: __result = "Massive Fire damage to all foes."; return false; // Ragnarok
                    case 437: __result = "Low Ice damage to one foe. \nLowers target's Evasion/Hit Rate."; return false; // Refrigerate
                    case 438: __result = "High Ice damage to random foes."; return false; // Cocytus
                    case 439: __result = "Massive Ice damage to all foes."; return false; // Fimbulvetr
                    case 440: __result = "Low Elec damage to one foe. \nHigh chance to inflict shock"; return false; // Jolt
                    case 441: __result = "Massive Elec damage to one foe."; return false; // Thunder Gods
                    case 442: __result = "Massive Elec damage to all foes."; return false; // Thunder Reign
                    case 443: __result = "Low Force damage to all foes. \nLowers targets' Evasion."; return false; // Dervish
                    case 444: __result = "High Force damage to random foes."; return false; // Heavenly Cyclone
                    case 445: __result = "Massive Force damage to all foes."; return false; // Vayavya
                    case 446: __result = "Dark: Chance to instakill one foe."; return false; // Damnation
                    case 447: __result = "Dark: Chance to instakill all foes."; return false; // Millennia Curse
                    case 448: __result = "Medium Curse damage to random foes. \nMay inflict Poison."; return false; // Poison Volley
                    case 449: __result = "High Curse damage to one foe. \nMay inflict Poison."; return false; // Poison Salvo
                    case 450: __result = "High Nerve damage to one foe. \nMay inflict Stun."; return false; // Neural Shock
                    case 451: __result = "High Nerve damage to all foes. \nMay inflict Stun."; return false; // Neural Storm
                    case 452: __result = "High Mind damage to one foe. \nMay inflict Panic."; return false; // Pulinpaon
                    case 453: __result = "High Almighty damage to one foe. \nLowers target's Attack/Defense/Evasion/Hit Rate."; return false; // Antichthon
                    case 454: __result = "Massive Almighty damage to one foe."; return false; // Last Word
                    case 455: __result = "Drains HP/MP from one foe."; return false; // Soul Drain
                    case 456: __result = "Cures all ailments for the party."; return false; // Amrita
                    case 457: __result = "Moderate HP recovery and cures \nall ailments for one ally."; return false; // Diamrita
                    case 458: __result = "Greatly raises own \nAttack/Defense/Evasion/Hit Rate."; return false; // Heat Riser
                    case 459: __result = "Raises party's \nAttack/Defense/Evasion/Hit Rate."; return false; // Luster Candy
                    case 460: __result = "Negates -kaja & -nda effects \non all foes & allies."; return false; // Silent Prayer
                    case 461: __result = "Low Force damage to random foes."; return false; // Storm Gale
                    case 462: __result = "High Strength-based Force damage \nto all foes."; return false; // Winged Fury
                    case 463: __result = "Low Ice damage to one foe. \nLowers target's Defense."; return false; // Jack Bufu
                    case 464: __result = "Slight HP recovery for the party."; return false; // Humble Blessing
                    case 465: __result = "Massive Physical damage to one foe. \nHigh critical rate."; return false; // Rend
                    case 466: __result = "Massive Ice damage to one foe. \nLowers target's Defense."; return false; // Jack Bufudyne
                    case 467: __result = "High Physical damage to all foes. \nLowers targets' Attack/Defense/Evasion/Hit Rate."; return false; // Divine Light
                    case 468: __result = "Massive Ice damage to all foes. \nLowers targets' Defense/Evasion."; return false; // Niflheim
                    case 469: __result = "High Strength-based Elec damage \nto one foe. \nDamage relative to HP."; return false; // Mjolnir
                    case 470: __result = "Massive Almighty damage to all foes. \nMinimizes targets' Defense."; return false; // Tandava
                    case 471: __result = "Massive Strength-based Almighty damage \nto random foes."; return false; // Chaturbhuja

                    default: return true;
                }
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.InitActionProcessData))]
        private class ActionProcessDataPatch
        {
            public static void Postfix(ref nbActionProcessData_t __result)
            {
                actionProcessData = __result;
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
            }
        }
        [HarmonyPatch(typeof(nbMakePacket), nameof(nbMakePacket.nbMakeNewPressPacket))]
        private class BeastEyePatch2
        {
            public static void Postfix(ref int startframe, ref int uniqueid, ref int ptype, ref nbFormation_t form)
            {
                if (ptype == 18)
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
                if (((datNormalSkill.tbl[nskill].koukatype == 0 && (target.badstatus == 1 || target.badstatus == 2)) || (target.badstatus == 256 && random.Next(2) == 1))
                    && (datNormalSkill.tbl[nskill].hptype == 1 || datNormalSkill.tbl[nskill].hptype == 6 || datNormalSkill.tbl[nskill].hptype == 12 || datNormalSkill.tbl[nskill].hptype == 14))
                {
                    var form = a.data.form[dformindex];
                    nbMakePacket.nbMakeBadKaifukuPacket(frame, a.uniqueid, ref form);
                }
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetDamagePacket))]
        private class PoisonDamagePatch
        {
            public static void Prefix(ref nbActionProcessData_t a, ref int hp)
            {
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
                    if (evtMoon.evtGetAgeOfMoon16() < 8)
                    {
                        dds3GlobalWork.DDS3_GBWK.Moon.MoveCnt = 0; // Beginning of a new phase
                        evtMoon.evtSetAgeOfMoon(8); // Set Kagutsuchi's phase to full
                    }
                    else if (evtMoon.evtGetAgeOfMoon16() < 16)
                    {
                        // Clear all effects that last "until a new kagutsuchi"
                        fldMain.fldEsutoMaClearMsg();
                        fldMain.fldRiberaMaClearMsg();
                        fldMain.fldRifutoMaClearMsg();
                        fldMain.fldLightMaClearMsg();

                        dds3GlobalWork.DDS3_GBWK.Moon.MoveCnt = 0; // Beginning of a new phase
                        evtMoon.evtSetAgeOfMoon(0); // Set Kagutsuchi's phase to full
                    }

                    // Test - Add rigged demons to party
                    //if (dds3GlobalWork.DDS3_GBWK.unitwork.Where(x => x.id == 11).Count() == 0)
                    //{
                    //    datCalc.datAddDevil(11, 0);
                    //    foreach (datUnitWork_t work in dds3GlobalWork.DDS3_GBWK.unitwork.Where(x => x.id == 11))
                    //    {
                    //        work.skill[2] = 52;
                    //        work.skill[3] = 53;
                    //        work.skill[4] = 54;
                    //        work.skill[5] = 302;
                    //        work.skill[6] = 329;
                    //        work.skill[7] = 332;
                    //        work.skillcnt = 8;
                    //    }
                    //}
                    //else if (dds3GlobalWork.DDS3_GBWK.unitwork.Where(x => x.id == 67).Count() == 0)
                    //{
                    //    datCalc.datAddDevil(67, 0);
                    //    foreach (datUnitWork_t work in dds3GlobalWork.DDS3_GBWK.unitwork.Where(x => x.id == 67))
                    //    {
                    //        work.skill[3] = 65;
                    //        work.skill[4] = 66;
                    //        work.skill[5] = 302;
                    //        work.skill[6] = 329;
                    //        work.skill[7] = 332;
                    //        work.skillcnt = 8;
                    //    }
                    //}
                    //else
                    //{
                    //    foreach (datUnitWork_t work in dds3GlobalWork.DDS3_GBWK.unitwork.Where(x => x.id == 134))
                    //    {
                    //        work.skill[1] = 328;
                    //        work.skill[6] = 332;
                    //    }
                    //}
                }
                // If using a cursed gospel
                if (nskill == 91)
                {
                    datUnitWork_t unit = dds3GlobalWork.DDS3_GBWK.unitwork[0];
                    if (unit.level > 1)
                    {
                        unit.level--;
                        unit.exp = rstCalcCore.GetNextExpDisp(unit, 0) - 1;

                        bool hasLostStat = false;
                        List<short> statList = new List<short> { 0, 2, 3, 4, 5 };

                        while (!hasLostStat)
                        {
                            short stat = statList[random.Next(statList.Count)];

                            // If the BASE stat is higher than 1 (total stat minus magatama stat)
                            if (unit.param[stat] - tblHearts.fclHeartsTbl[dds3GlobalWork.DDS3_GBWK.heartsequip].GrowParamTbl[stat] > 1)
                            {
                                unit.param[stat]--;
                                hasLostStat = true;
                            }
                            else
                            {
                                statList.Remove(stat);
                            }
                        }

                        dds3GlobalWork.DDS3_GBWK.unitwork[0] = unit;
                    }
                }
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetKoukaBadDamage))]
        private class CheckStatusPatch
        {
            public static void Postfix(ref int nskill, int sformindex, int dformindex, float ai, int nvirtual, ref uint __result)
            {
                if (datSkill.tbl[nskill].skillattr == 6 || datSkill.tbl[nskill].skillattr == 7)
                {
                    int[] lightSkills = new int[] { 28, 29, 30, 31, 287 };
                    int[] darkSkills = new int[] { 32, 33, 34, 35 };

                    var lightResistance = Convert.ToString(nbCalc.nbGetAisyo(nskill, dformindex, 6), 2);
                    var darkResistance = Convert.ToString(nbCalc.nbGetAisyo(nskill, dformindex, 7), 2);

                    if ((lightSkills.Contains(nskill) && !(lightResistance.Length == 32 && lightResistance[lightResistance.Length - 32] == '1' && lightResistance[lightResistance.Length - 21] == '0')) ||
                        (darkSkills.Contains(nskill) && !(darkResistance.Length == 32 && darkResistance[darkResistance.Length - 32] == '1' && darkResistance[darkResistance.Length - 21] == '0')))
                    {
                        __result = 0;
                        return;
                    }
                }

                var work = nbMainProcess.nbGetUnitWorkFromFormindex(dformindex);

                if (__result == 1 && datCalc.datCheckSyojiSkill(work, 366) != 0 && datNormalSkill.tbl[nskill].basstatus != 1 && datNormalSkill.tbl[nskill].basstatus != 2)
                {
                    __result = (uint)random.Next(2);
                    return;
                }

                if (bossList.Contains(work.id) && (datNormalSkill.tbl[nskill].basstatus == 8 || datNormalSkill.tbl[nskill].basstatus == 16 || datNormalSkill.tbl[nskill].basstatus == 32 || datNormalSkill.tbl[nskill].basstatus == 128 || datNormalSkill.tbl[nskill].basstatus == 1024 || datNormalSkill.tbl[nskill].basstatus == 2048))
                {
                    __result = 0;
                    return;
                }
            }
        }

        [HarmonyPatch(typeof(nbHelpProcess), nameof(nbHelpProcess.nbDispText))]
        private class DispTextPatch
        {
            public static void Prefix(ref string text1, ref string text2, ref int type, int max, uint col)
            {
                if (type == 1 && actionProcessData.work.nowcommand == 1)
                {
                    switch (actionProcessData.work.nowindex)
                    {
                        case 54:
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
                        case 64: 
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
                        case 67: 
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
                        case 276: 
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
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetAisyoRitu))]
        private class GetAisyoRituPatch
        {
            public static void Postfix(ref int nskill, ref int sformindex, ref int dformindex, ref float __result)
            {
                var skillattr = datSkill.tbl[nskill].skillattr;
                var work = nbMainProcess.nbGetUnitWorkFromFormindex(sformindex);

                switch (skillattr)
                {
                    case 0:
                        {
                            if (datCalc.datCheckSyojiSkill(work, 361) != 0)
                            {
                                __result = (__result / 1.5f) * 1.3f;
                            }
                            else if (datCalc.datCheckSyojiSkill(work, 362) != 0)
                            {
                                __result = __result * 1.3f;
                            }
                            break;
                        }
                    case 1:
                        {
                            if (datCalc.datCheckSyojiSkill(work, 309) != 0 || datCalc.datCheckSyojiSkill(work, 361) != 0)
                            {
                                __result = (__result / 1.5f) * 1.3f;
                            }
                            else if (datCalc.datCheckSyojiSkill(work, 363) != 0 || datCalc.datCheckSyojiSkill(work, 368) != 0)
                            {
                                __result = __result * 1.3f;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (datCalc.datCheckSyojiSkill(work, 310) != 0 || datCalc.datCheckSyojiSkill(work, 361) != 0)
                            {
                                __result = (__result / 1.5f) * 1.3f;
                            }
                            else if (datCalc.datCheckSyojiSkill(work, 363) != 0)
                            {
                                __result = __result * 1.3f;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (datCalc.datCheckSyojiSkill(work, 311) != 0 || datCalc.datCheckSyojiSkill(work, 361) != 0)
                            {
                                __result = (__result / 1.5f) * 1.3f;
                            }
                            else if (datCalc.datCheckSyojiSkill(work, 363) != 0)
                            {
                                __result = __result * 1.3f;
                            }
                            break;
                        }
                    case 4:
                        {
                            if (datCalc.datCheckSyojiSkill(work, 312) != 0 || datCalc.datCheckSyojiSkill(work, 361) != 0)
                            {
                                __result = (__result / 1.5f) * 1.3f;
                            }
                            else if (datCalc.datCheckSyojiSkill(work, 363) != 0)
                            {
                                __result = __result * 1.3f;
                            }
                            break;
                        }
                    default: break;
                }
            }
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
            Dormina(60);
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

            PoisonArrow(90);

            CursedGospelSkill(91);

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

            NeedleOrbSkill(128);

            DeadlyFury(131);
            JavelinRain(133);
            DivineShot(136);
            XerosBeat(143);
            OniKagura(144);
            Freikugel(147);

            LastResort(152);

            FoulHavoc(153);
            Earthquake(155);
            SpiralViper(160);

            MagmaAxis(161);

            GaeaRage(163);
            Counter(164);
            Retaliate(165);
            Avenge(166);

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

            ToxicCloud(202);
            WarCry(203);
            FogBreath(204);
            Taunt(205);
            Debilitate(206);

            DismalTune(207);
            SolNiger(208);
            StunGaze(209);
            Lullaby(210);
            BindingCry(211);
            EternalRest(212);
            SonicWave(213);
            SexyGaze(214);
            Allure(215);
            PanicVoice(216);
            Intoxicate(217);
            Prayer(218);

            BeckonCall(223);
            Focus(224);

            FireOfSinai(235);
            VastLight(241);
            GodsCurse(242);
            IcyDeath(244);
            Mirage(245);

            WildDance(249);
            Domination(250);

            Apocalypse(253);

            FireOfSinai(257);

            DeathFlies(259);
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

            RaptorGuardian(274);

            Andalucia(275);
            RedCapote(276);

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
            NeuralStorm(451);
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

            // Passive Skills
            Might(11);
            DrainAttack(14);

            PhysBoost(74);
            MagicBoost(75);
            AntiMagic(76);
            AntiAilments(77);
            AbyssalMask(78);
            KnowledgeOfTools(79);
            Laevateinn(80);

            foreach (var skill in datSkill.tbl)
                skill.capacity = 0;
        }

        // Physical Skills

        private static void Lunge(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].failpoint = 20;
            datNormalSkill.tbl[id].criticalpoint = 20;
        }

        private static void HellThrust(ushort id)
        {
            datNormalSkill.tbl[id].cost = 14;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].failpoint = 30;
            datNormalSkill.tbl[id].criticalpoint = 30;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 5;
        }

        private static void Berserk(ushort id)
        {
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].hpn = 20;
            datNormalSkill.tbl[id].failpoint = 6;
            datNormalSkill.tbl[id].criticalpoint = 12;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 4;
        }

        private static void Tempest(ushort id)
        {
            datNormalSkill.tbl[id].cost = 24;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].failpoint = 30;
            datNormalSkill.tbl[id].criticalpoint = 30;
        }

        private static void HadesBlast(ushort id)
        {
            datNormalSkill.tbl[id].cost = 30;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].failpoint = 20;
            datNormalSkill.tbl[id].criticalpoint = 40;
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
            datNormalSkill.tbl[id].cost = 30;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].failpoint = 16;
            datNormalSkill.tbl[id].criticalpoint = 30;
            datNormalSkill.tbl[id].badlevel = 24;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 9;
        }

        private static void BrutalSlash(ushort id)
        {
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].hpn = 52;
            datNormalSkill.tbl[id].failpoint = 24;
            datNormalSkill.tbl[id].criticalpoint = 24;
        }

        private static void Hassohappa(ushort id)
        {
            datNormalSkill.tbl[id].cost = 35;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].failpoint = 20;
            datNormalSkill.tbl[id].criticalpoint = 40;
        }

        private static void DarkSword(ushort id)
        {
            datNormalSkill.tbl[id].cost = 22;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].failpoint = 40;
            datNormalSkill.tbl[id].criticalpoint = 40;
            datNormalSkill.tbl[id].badlevel = 30;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 9;
        }

        private static void StasisBlade(ushort id)
        {
            datNormalSkill.tbl[id].cost = 22;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].failpoint = 40;
            datNormalSkill.tbl[id].criticalpoint = 40;
            datNormalSkill.tbl[id].badlevel = 36;
        }

        private static void MightyGust(ushort id)
        {
            datNormalSkill.tbl[id].cost = 14;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].failpoint = 20;
            datNormalSkill.tbl[id].criticalpoint = 20;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 4;
        }

        private static void Deathbound(ushort id)
        {
            datNormalSkill.tbl[id].cost = 24;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].failpoint = 6;
            datNormalSkill.tbl[id].criticalpoint = 20;
        }

        private static void Guillotine(ushort id)
        {
            datNormalSkill.tbl[id].cost = 18;
            datNormalSkill.tbl[id].hpn = 56;
            datNormalSkill.tbl[id].failpoint = 30;
            datNormalSkill.tbl[id].criticalpoint = 30;
            datNormalSkill.tbl[id].badlevel = 30;
        }

        private static void ChaosBlade(ushort id)
        {
            datNormalSkill.tbl[id].cost = 32;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].failpoint = 6;
            datNormalSkill.tbl[id].criticalpoint = 20;
            datNormalSkill.tbl[id].badlevel = 24;
        }

        private static void NeedleRush(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].failpoint = 20;
            datNormalSkill.tbl[id].criticalpoint = 20;
        }

        private static void StunNeedle(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 38;
            datNormalSkill.tbl[id].failpoint = 18;
            datNormalSkill.tbl[id].criticalpoint = 18;
            datNormalSkill.tbl[id].badlevel = 36;
        }

        private static void VenomNeedle(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 38;
            datNormalSkill.tbl[id].failpoint = 18;
            datNormalSkill.tbl[id].criticalpoint = 18;
            datNormalSkill.tbl[id].badlevel = 36;
        }

        private static void AridNeedle(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].failpoint = 18;
            datNormalSkill.tbl[id].criticalpoint = 18;
            datNormalSkill.tbl[id].badlevel = 30;
        }

        private static void FeralBite(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].hpn = 44;
            datNormalSkill.tbl[id].failpoint = 24;
            datNormalSkill.tbl[id].criticalpoint = 24;
        }

        private static void VenomBite(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].failpoint = 22;
            datNormalSkill.tbl[id].criticalpoint = 22;
            datNormalSkill.tbl[id].badlevel = 44;
        }

        private static void CharmBite(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].failpoint = 22;
            datNormalSkill.tbl[id].criticalpoint = 22;
            datNormalSkill.tbl[id].badlevel = 40;
        }

        private static void StoneBite(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].failpoint = 22;
            datNormalSkill.tbl[id].criticalpoint = 22;
            datNormalSkill.tbl[id].badlevel = 40;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 6;
        }

        private static void StunBite(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].failpoint = 22;
            datNormalSkill.tbl[id].criticalpoint = 22;
            datNormalSkill.tbl[id].badlevel = 44;
        }

        private static void HellFang(ushort id)
        {
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].hpn = 56;
            datNormalSkill.tbl[id].failpoint = 40;
            datNormalSkill.tbl[id].criticalpoint = 40;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 7;
        }

        private static void FeralClaw(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].hpn = 44;
            datNormalSkill.tbl[id].failpoint = 24;
            datNormalSkill.tbl[id].criticalpoint = 24;
        }

        private static void VenomClaw(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].failpoint = 22;
            datNormalSkill.tbl[id].criticalpoint = 22;
            datNormalSkill.tbl[id].badlevel = 44;
        }

        private static void StunClaw(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].failpoint = 22;
            datNormalSkill.tbl[id].criticalpoint = 22;
            datNormalSkill.tbl[id].badlevel = 44;
        }

        private static void IronClaw(ushort id)
        {
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].hpn = 56;
            datNormalSkill.tbl[id].failpoint = 40;
            datNormalSkill.tbl[id].criticalpoint = 40;
        }

        private static void DeadlyFury(ushort id)
        {
            datNormalSkill.tbl[id].cost = 32;
            datNormalSkill.tbl[id].hpn = 44;
            datNormalSkill.tbl[id].failpoint = 5;
            datNormalSkill.tbl[id].criticalpoint = 40;
        }

        private static void JavelinRain(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].failpoint = 5;
            datNormalSkill.tbl[id].criticalpoint = 24;
        }

        private static void DivineShot(ushort id)
        {
            datNormalSkill.tbl[id].cost = 14;
            datNormalSkill.tbl[id].hpn = 56;
            datNormalSkill.tbl[id].failpoint = 5;
            datNormalSkill.tbl[id].criticalpoint = 30;
        }

        private static void XerosBeat(ushort id)
        {
            datNormalSkill.tbl[id].cost = 24;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].failpoint = 5;
            datNormalSkill.tbl[id].criticalpoint = 24;
        }

        private static void OniKagura(ushort id)
        {
            datNormalSkill.tbl[id].cost = 28;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].failpoint = 5;
            datNormalSkill.tbl[id].criticalpoint = 30;
        }

        private static void FoulHavoc(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 24;
            datNormalSkill.tbl[id].failpoint = 10;
            datNormalSkill.tbl[id].criticalpoint = 20;
        }

        private static void Earthquake(ushort id)
        {
            datSkill.tbl[id].keisyoform = 128;
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].hitlevel = 200;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].badlevel = 20;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 256;
        }

        private static void SpiralViper(ushort id)
        {
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].hpn = 62;
            datNormalSkill.tbl[id].failpoint = 5;
            datNormalSkill.tbl[id].criticalpoint = 30;
        }

        private static void GaeaRage(ushort id)
        {
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].hpn = 52;
            datNormalSkill.tbl[id].failpoint = 5;
            datNormalSkill.tbl[id].criticalpoint = 30;
        }

        private static void Counter(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 32;
        }

        private static void Retaliate(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 48;
        }

        private static void Avenge(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 56;
        }

        private static void BoogieWoogie(ushort id)
        {
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].hitlevel = 120;
            datNormalSkill.tbl[id].criticalpoint = 30;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 160;
        }

        private static void EnterYoshitsune(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].criticalpoint = 40;
        }

        private static void MokoiBoomerang(ushort id)
        {
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].criticalpoint = 40;
        }

        private static void Andalucia(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].criticalpoint = 4;
        }

        private static void Terrorblade(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].failpoint = 4;
            datNormalSkill.tbl[id].criticalpoint = 10;
        }

        private static void HellSpin(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].failpoint = 4;
            datNormalSkill.tbl[id].criticalpoint = 10;
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
            datNormalSkill.tbl[id].cost = 32;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 20;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 20;
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 10;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 20;
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 10;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 20;
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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
            datNormalSkill.tbl[id].cost = 18;
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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
            datNormalSkill.tbl[id].cost = 17;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 50;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 12;
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

            OverWriteSkillEffect(id, 65, 101);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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
            datNormalSkill.tbl[id].cost = 34;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 30;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 8;
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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

            datNormalSkill.tbl[id].badlevel = 25;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 1024;
            datNormalSkill.tbl[id].cost = 34;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 30;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 8;
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

            OverWriteSkillEffect(id, 98, 281);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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
            datNormalSkill.tbl[id].cost = 20;
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
            datNormalSkill.tbl[id].targetcntmax = 3;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 96, 275);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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
            datNormalSkill.tbl[id].cost = 35;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 50;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 13;
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = id;
            skillLevel.Level = 10;
        }

        private static void NeedleOrbSkill(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 128;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 1;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 18;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 18;
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
            datNormalSkill.tbl[id].targetcntmax = 5;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 1;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 111);
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
            datNormalSkill.tbl[id].cost = 30;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 10;
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

        // Fire Skills

        private static void Agi(ushort id)
        {
            datNormalSkill.tbl[id].cost = 4;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 80;
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

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 4;
        }

        private static void Hellfire(ushort id)
        {
            datNormalSkill.tbl[id].cost = 24;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 154;
            datNormalSkill.tbl[id].targetcntmax = 6;
            datNormalSkill.tbl[id].targetcntmin = 3;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 8;
        }

        private static void Prominence(ushort id)
        {
            datNormalSkill.tbl[id].cost = 48;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 296;
            datNormalSkill.tbl[id].targetcntmax = 7;
            datNormalSkill.tbl[id].targetcntmin = 3;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 11;
        }

        private static void Trisagion(ushort id)
        {
            datSkill.tbl[id].keisyoform = 1;
            datNormalSkill.tbl[id].cost = 32;
            datNormalSkill.tbl[id].hpn = 80;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = id;
            skillLevel.Level = 10;
        }

        private static void HellBurner(ushort id)
        {
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = id;
            skillLevel.Level = 12;
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
            datNormalSkill.tbl[id].badlevel = 25;
        }

        private static void Bufudyne(ushort id)
        {
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].hpn = 51;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 370;
            datNormalSkill.tbl[id].badlevel = 30;
        }

        private static void Mabufu(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].hpn = 20;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 58;
            datNormalSkill.tbl[id].badlevel = 12;
        }

        private static void Mabufula(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 154;
            datNormalSkill.tbl[id].badlevel = 15;
        }

        private static void Mabufudyne(ushort id)
        {
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 296;
            datNormalSkill.tbl[id].badlevel = 18;
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

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 4;
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

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 8;
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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
            datNormalSkill.tbl[id].badlevel = 28;
        }

        private static void Ziodyne(ushort id)
        {
            datNormalSkill.tbl[id].cost = 16;
            datNormalSkill.tbl[id].hpn = 51;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 370;
            datNormalSkill.tbl[id].badlevel = 34;
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
            datNormalSkill.tbl[id].badlevel = 17;
        }

        private static void Maziodyne(ushort id)
        {
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 296;
            datNormalSkill.tbl[id].badlevel = 21;
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

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 4;
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

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 8;
        }

        private static void MishagujiRaiden(ushort id)
        {
            datNormalSkill.tbl[id].cost = 50;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].badlevel = 21;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 544;
        }

        private static void Jolt(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 3;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 72;
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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

            datNormalSkill.tbl[id].badlevel = 40;
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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

            datNormalSkill.tbl[id].badlevel = 30;
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
            datNormalSkill.tbl[id].hpn = 50;
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

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 0;
        }

        private static void Tornado(ushort id)
        {
            datNormalSkill.tbl[id].cost = 24;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 154;
            datNormalSkill.tbl[id].targetcntmax = 6;
            datNormalSkill.tbl[id].targetcntmin = 3;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 82;
        }

        private static void WindCutter(ushort id)
        {
            datNormalSkill.tbl[id].cost = 32;
            datNormalSkill.tbl[id].hpn = 80;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 10;
        }

        private static void WetWind(ushort id)
        {
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].hpn = 45;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 350;
            datNormalSkill.tbl[id].badlevel = 20;
        }

        private static void HitokotoStorm(ushort id)
        {
            datNormalSkill.tbl[id].cost = 50;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 32767;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 10;
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
            datNormalSkill.tbl[id].koukatype = 0;
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = id;
            skillLevel.Level = 11;
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

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 12;
        }

        private static void Pestilence(ushort id)
        {
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 182;
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
            datNormalSkill.tbl[id].hpn = 27;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 74;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 2;
        }

        private static void ManaDrain(ushort id)
        {
            datNormalSkill.tbl[id].cost = 3;
            datNormalSkill.tbl[id].hpn = 14;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 44;
        }

        private static void LifeDrain(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].hpn = 27;
            datNormalSkill.tbl[id].mpn = 14;
            datNormalSkill.tbl[id].magicbase = 12;
            datNormalSkill.tbl[id].magiclimit = 74;
        }

        private static void SolNiger(ushort id)
        {
            datNormalSkill.tbl[id].cost = 40;
            datNormalSkill.tbl[id].hitlevel = 40;
            datNormalSkill.tbl[id].flag = 1;
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

        private static void DeathFlies(ushort id)
        {
            datNormalSkill.tbl[id].cost = 75;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
        }

        private static void Tekisatsu(ushort id)
        {
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].hpn = 48;
            datNormalSkill.tbl[id].failpoint = 3;
            datNormalSkill.tbl[id].criticalpoint = 4;
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
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].mpn = 20;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 182;
        }

        private static void BabylonGoblet(ushort id)
        {
            datSkill.tbl[id].skillattr = 5;
            datNormalSkill.tbl[id].badlevel = 40;
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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

            OverWriteSkillEffect(id, 202, 160);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = id;
            skillLevel.Level = 14;
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

            OverWriteSkillEffect(id, 192);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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
            datNormalSkill.tbl[id].hpn = 20;
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
            datNormalSkill.tbl[id].targetcntmax = 15;
            datNormalSkill.tbl[id].targetcntmin = 10;
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

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 4;
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

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 12;
        }

        private static void GodsBow(ushort id)
        {
            datNormalSkill.tbl[id].cost = 36;
            datNormalSkill.tbl[id].hpn = 80;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
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
            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 5;
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
            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 7;
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = id;
            skillLevel.Level = 7;
        }

        // Curse Skills

        private static void Makajam(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 4;
        }

        private static void Makajamon(ushort id)
        {
            datNormalSkill.tbl[id].cost = 18;
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

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = id;
            skillLevel.Level = 3;
        }

        private static void MuteGaze(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].badlevel = 50;
        }

        private static void ToxicCloud(ushort id)
        {
            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 64;
            datNormalSkill.tbl[id].cost = 20;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].hitlevel = 255;
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
            datNormalSkill.tbl[id].badlevel = 20;
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

            datNormalSkill.tbl[id].badlevel = 30;
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
            datNormalSkill.tbl[id].hpn = 24;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 18;
            datNormalSkill.tbl[id].magiclimit = 128;
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = id;
            skillLevel.Level = 8;
        }

        private static void PoisonSalvo(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 8;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 40;
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
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 432;
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 3;
        }

        private static void StunGaze(ushort id)
        {
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].badlevel = 50;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 2;
        }

        private static void BindingCry(ushort id)
        {
            datNormalSkill.tbl[id].cost = 15;
            datNormalSkill.tbl[id].badlevel = 20;
        }

        private static void NeuralShock(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 9;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 30;
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
            datNormalSkill.tbl[id].hpn = 51;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 370;
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = id;
            skillLevel.Level = 8;
        }

        private static void NeuralStorm(ushort id)
        {
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 9;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 20;
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
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 59, 187);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = id;
            skillLevel.Level = 10;
        }

        // Mind Skills

        private static void Dormina(ushort id)
        {
            datNormalSkill.tbl[id].cost = 10;
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
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 296;
            datNormalSkill.tbl[id].badlevel = 25;
        }

        private static void Lullaby(ushort id)
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
            datNormalSkill.tbl[id].badlevel = 20;
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
            datNormalSkill.tbl[id].badlevel = 30;
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

            datNormalSkill.tbl[id].badlevel = 40;
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
            datNormalSkill.tbl[id].hpn = 51;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 24;
            datNormalSkill.tbl[id].magiclimit = 432;
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = id;
            skillLevel.Level = 8;
        }

        // Self-Destruct Skills

        private static void Sacrifice(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 56;
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 44);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = id;
            skillLevel.Level = 7;
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

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 2;
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

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 4;
        }

        private static void Sukukaja(ushort id)
        {
            datNormalSkill.tbl[id].cost = 15;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 4;
        }

        private static void Rakukaja(ushort id)
        {
            datNormalSkill.tbl[id].cost = 15;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 4;
        }

        private static void Makakaja(ushort id)
        {
            datNormalSkill.tbl[id].cost = 15;
            datNormalSkill.tbl[id].hojotype = 260;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 4;
        }

        private static void Tetraja(ushort id)
        {
            datNormalSkill.tbl[id].cost = 30;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 5;
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

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 2;
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

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == id).FirstOrDefault().Level = 10;
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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
            datNormalSkill.tbl[id].targetrule = 1;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            OverWriteSkillEffect(id, 224);
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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
            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
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

            OverWriteSkillEffect(id, 77, 131);
            //nbActionProcess.sobedtbl[id].se1_str = nbActionProcess.sobedtbl[189].se1_str;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = id;
            skillLevel.Level = 8;
        }

        // Utility Skills

        private static void Makatora(ushort id)
        {
            datSkill.tbl[id].skillattr = 15; // Utility skill
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

        private static void BaelsBane(ushort id)
        {
            datSkill.tbl[id].skillattr = 5; // Almighty
            datNormalSkill.tbl[id].badlevel = 100;
        }

        private static void VastLight(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 80;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
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
            datNormalSkill.tbl[id].hpn = 80;
            datNormalSkill.tbl[id].mpn = 40;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
        }

        private static void Apocalypse(ushort id)
        {
            datNormalSkill.tbl[id].hpn = 80;
            datNormalSkill.tbl[id].magicbase = 30;
            datNormalSkill.tbl[id].magiclimit = 32767;
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

            OverWriteSkillEffect(id, 219);
        }

        // Passive Skills

        private static void Might(ushort id)
        {
            datSpecialSkill.tbl[id].n = 750;
        }

        private static void DrainAttack(ushort id)
        {
            datSpecialSkill.tbl[id].n = 1;
        }

        private static void PhysBoost(ushort id)
        {
            datSkill.tbl[362].keisyoform = 1;

            datSpecialSkill.tbl[id].a = 2;
            datSpecialSkill.tbl[id].b = 1;
            datSpecialSkill.tbl[id].m = 3;
            datSpecialSkill.tbl[id].n = 4;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = 362;
            skillLevel.Level = 7;
        }

        private static void MagicBoost(ushort id)
        {
            datSkill.tbl[363].keisyoform = 1;

            datSpecialSkill.tbl[id].a = 2;
            datSpecialSkill.tbl[id].b = 1;
            datSpecialSkill.tbl[id].m = 3;
            datSpecialSkill.tbl[id].n = 4;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = 363;
            skillLevel.Level = 8;
        }

        private static void AntiMagic(ushort id)
        {
            datSkill.tbl[364].keisyoform = 1;

            datSpecialSkill.tbl[id].a = 0;
            datSpecialSkill.tbl[id].b = 0;
            datSpecialSkill.tbl[id].m = 0;
            datSpecialSkill.tbl[id].n = 50;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = 364;
            skillLevel.Level = 8;
        }

        private static void AntiAilments(ushort id)
        {
            datSkill.tbl[365].keisyoform = 1;

            datSpecialSkill.tbl[id].a = 0;
            datSpecialSkill.tbl[id].b = 0;
            datSpecialSkill.tbl[id].m = 0;
            datSpecialSkill.tbl[id].n = 50;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = 365;
            skillLevel.Level = 8;
        }

        private static void AbyssalMask(ushort id)
        {
            datSkill.tbl[366].keisyoform = 1;

            datSpecialSkill.tbl[id].a = 2;
            datSpecialSkill.tbl[id].b = 1;
            datSpecialSkill.tbl[id].m = 3;
            datSpecialSkill.tbl[id].n = 4;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = 366;
            skillLevel.Level = 8;
        }

        private static void KnowledgeOfTools(ushort id)
        {
            datSkill.tbl[367].keisyoform = 1;

            datSpecialSkill.tbl[id].a = 2;
            datSpecialSkill.tbl[id].b = 1;
            datSpecialSkill.tbl[id].m = 3;
            datSpecialSkill.tbl[id].n = 4;

            var skillLevel = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == 0).FirstOrDefault();
            skillLevel.SkillID = 367;
            skillLevel.Level = 5;
        }

        private static void Laevateinn(ushort id)
        {
            datSkill.tbl[368].keisyoform = 512;

            datSpecialSkill.tbl[id].a = 2;
            datSpecialSkill.tbl[id].b = 1;
            datSpecialSkill.tbl[id].m = 3;
            datSpecialSkill.tbl[id].n = 4;
        }
    }
}
