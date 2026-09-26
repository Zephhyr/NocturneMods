using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2CppTMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Xml.Linq;
using Il2Cppnewbattle_H;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        private static Dictionary<ushort, InnateSkill> demonInnateSkills = new Dictionary<ushort, InnateSkill>
        {
            { 000, new InnateSkill(383, 15, "", "")}, // 000
            { 001, new InnateSkill(383, 15, "Tripura Samhara", "While in the active party, \nskill costs are reduced by 20% \nfor allies with a charge effect.")}, // 001 Vishnu
            { 002, new InnateSkill(383, 14, "Righteous Vow", "After Mitra survives a critical or \nweakness hit, raise all of his stats \nby one rank.")}, // 002 Mitra
            { 003, new InnateSkill(383, 06, "Searing Brilliance", "While in the active party, all allies' \nLight attacks may Critically Strike. \n(10% base rate)")}, // 003 Amaterasu
            { 004, new InnateSkill(383, 14, "Runes of Wisdom", "When switching out, increase the damage \nof the next Strength-based attack \nused by the switched ally by 120%.")}, // 004 Odin
            { 005, new InnateSkill(383, 15, "Focused Assault", "Atavaka gains 20% Hit Rate and \nCritical Rate when targetting the \nsame single foe as the previous ally.")}, // 005 Atavaka
            { 006, new InnateSkill(383, 14, "Eye of Horus", "When switching out, increase the damage \nof the next Magic-based attack \nused by the switched ally by 120%.")}, // 006 Horus
            { 007, new InnateSkill(383, 15, "Chanchala", "While in the active party, if an ally's \nMagical Attack is maximized, their \nElement attacks may Critically Strike.")}, // 007 Lakshmi
            { 008, new InnateSkill(383, 15, "Warrior Trainer", "While Setanta or Cu Chulainn is in \nthe active party, Scathach's attacks \nwith positive potential will not miss.")}, // 008 Scathach
            { 009, new InnateSkill(383, 04, "Vina Raga", "While in the active party, all allies' \nForce attacks may Critically Strike. \n(10% base rate)")}, // 009 Sarasvati
            { 010, new InnateSkill(383, 13, "Restorative Melody", "While in the active party, \nHealing skill costs are reduced \nby 20% for all allies.")}, // 010 Sati
            { 011, new InnateSkill(383, 14, "Curious Dance", "When switching out, all -kaja and \n-nda effects on Ame-no-Uzume will \nbe passed to the switched ally.")}, // 011 Ame-no-Uzume
            { 012, new InnateSkill(383, 15, "Tripura Samhara", "While in the active party, \nskill costs are reduced by 20% \nfor allies with a charge effect.")}, // 012 Shiva
            { 013, new InnateSkill(383, 15, "Withheld Sentence", "While in the active party, \nallies are immune to random \ninstakills.")}, // 013 Beidou Xingjun
            { 014, new InnateSkill(383, 14, "Megalomania", "While in the active party, \nafter an ally uses a charge effect \nthey gain a 20% chance to retain it.")}, // 014 Qitian Dasheng
            { 015, new InnateSkill(419, 15, "Wine Party", "While in the active party, \nmay step in during negotiation to \nfix trouble with the power of liquor.")}, // 015 Dionysus
            { 016, new InnateSkill(383, 00, "Phys Gestalt", "Kali gains Phys skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 016 Kali
            { 017, new InnateSkill(383, 02, "Queen of Winter", "Ice Enhancer & Skadi's Ice \nattacks have an increased \nchance to inflict Freeze.")}, // 017 Skadi
            { 018, new InnateSkill(383, 13, "Restorative Melody", "While in the active party, \nHealing skill costs are reduced \nby 20% for all allies.")}, // 018 Parvati
            { 019, new InnateSkill(383, 14, "Monstrous Offering", "When switching to a Fury demon \nall Support effects on Kushinada-Hime \nwill be passed to the switched ally.")}, // 019 Kushinada
            { 020, new InnateSkill(418, 15, "Maiden Plea", "While in the active party, \nmay step in during negotiation and \npacify an enraged demon.")}, // 020 Kikuri-Hime
            { 021, new InnateSkill(383, 14, "Four Devas", "When summoned from the stock, \nraise all stats of all Four Devas \nin the active party by one rank.")}, // 021 Bishamonten
            { 022, new InnateSkill(383, 03, "Odinson", "Elec Enhancer & Thor's Elec \nattacks have an increased \nchance to inflict Shock.")}, // 022 Thor
            { 023, new InnateSkill(383, 14, "Four Devas", "When summoned from the stock, \nraise all stats of all Four Devas \nin the active party by one rank.")}, // 023 Jikokuten
            { 024, new InnateSkill(410, 15, "Arbitration", "While in the active party, \nmay step in during negotiation and \nsoothe an enraged demon.")}, // 024 Take-Mikazuchi
            { 025, new InnateSkill(383, 14, "Nation Founder", "After Okuninushi heals a single ally, \nraise all stats of the healed ally \nby one rank.")}, // 025 Okuninushi
            { 026, new InnateSkill(383, 14, "Four Devas", "When summoned from the stock, \nraise all stats of all Four Devas \nin the active party by one rank.")}, // 026 Koumokuten
            { 027, new InnateSkill(383, 14, "Four Devas", "When summoned from the stock, \nraise all stats of all Four Devas \nin the active party by one rank.")}, // 027 Zouchouten
            { 028, new InnateSkill(414, 15, "Intimidate", "While in the active party, \nmay step in during negotiation to \n'convince' a lower level demon.")}, // 028 Take-Minakata
            { 029, new InnateSkill(383, 15, "Proxy Guard Hound", "While in the active party, increases \nCritical Damage by 30% for Avatar, \nHoly, Beast and Wilder allies.")}, // 029 Chimera
            { 030, new InnateSkill(383, 15, "Auspicious Beast", "While in the active party, raise allied \nAuspicious Beast's skill potentials \nto Baihu's if they were lower.")}, // 030 Baihu
            { 031, new InnateSkill(383, 15, "Paw-to-Paw Combat", "Senri's Critical Damage \nincreases by 30% if at least two \nallies have Paw-to-Paw Combat.")}, // 031 Senri
            { 032, new InnateSkill(383, 15, "Auspicious Beast", "While in the active party, raise allied \nAuspicious Beast's skill potentials \nto Zhuque's if they were lower.")}, // 032 Zhuque
            { 033, new InnateSkill(383, 14, "Divine Benevolence", "While in the active party, \nSupport skill costs are reduced \nby 20% for all allies.")}, // 033 Shiisaa
            { 034, new InnateSkill(383, 15, "Helmsman", "When Xiezhai acts, the next ally \ngains 30% Hit Rate if they attack.")}, // 034 Xiezhai
            { 035, new InnateSkill(383, 06, "Light Enhancer", "While in the active party, \nraise allies' Light skill potential \nto Unicorns's if it was lower.")}, // 035 Unicorn
            { 036, new InnateSkill(383, 01, "Fire Enhancer", "While in the active party, \nraise allies' Fire skill potential \nto Flaemis' if it was lower.")}, // 036 Flaemis
            { 037, new InnateSkill(383, 02, "Ice Enhancer", "While in the active party, \nraise allies' Ice skill potential \nto Aquans' if it was lower.")}, // 037 Aquans
            { 038, new InnateSkill(383, 04, "Force Enhancer", "While in the active party, \nraise allies' Force skill potential \nto Aeros' if it was lower.")}, // 038 Aeros
            { 039, new InnateSkill(383, 03, "Elec Enhancer", "While in the active party, \nraise allies' Elec skill potential \nto Erthys' if it was lower.")}, // 039 Erthys
            { 040, new InnateSkill(383, 15, "Enlightening Ritual", "When fused with another demon, \nallows the known skills of the result \ndemon to be overridden.")}, // 040 Saki Mitama
            { 041, new InnateSkill(383, 15, "Enlightening Ritual", "When fused with another demon, \nallows the known skills of the result \ndemon to be overridden.")}, // 041 Kushi Mitama
            { 042, new InnateSkill(383, 15, "Enlightening Ritual", "When fused with another demon, \nallows the known skills of the result \ndemon to be overridden.")}, // 042 Nigi Mitama
            { 043, new InnateSkill(383, 15, "Enlightening Ritual", "When fused with another demon, \nallows the known skills of the result \ndemon to be overridden.")}, // 043 Ara Mitama
            { 044, new InnateSkill(383, 01, "Malevolent Flames", "While in the active party, all allies' \nFire attacks may Critically Strike. \n(10% base rate)")}, // 044 Efreet
            { 045, new InnateSkill(413, 15, "Silver Tongue", "While in the active party, \nmay step in during negotiation to \npersuade an indecisive demon.")}, // 045 Pulukishi
            { 046, new InnateSkill(383, 00, "Phys Gestalt", "Ongkhot gains Phys skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 046 Ongkhot
            { 047, new InnateSkill(420, 15, "Flatter", "While in the active party, \nmay step in during negotiation to \nconvince a higher level demon.")}, // 047 Jinn
            { 048, new InnateSkill(383, 04, "Force Gestalt", "Karasu Tengu gains Force skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 048 Karasu Tengu
            { 049, new InnateSkill(383, 15, "Planck of Norn", "When switching out, a Press Turn \nicon will not be consumed.")}, // 049 Dís
            { 050, new InnateSkill(383, 13, "Restorative Melody", "While in the active party, \nHealing skill costs are reduced \nby 20% for all allies.")}, // 050 Isora
            { 051, new InnateSkill(415, 15, "Entice", "While in the active party, \nmay step in during negotiation to \ntempt a male demon.")}, // 051 Apsaras
            { 052, new InnateSkill(383, 04, "Force Gestalt", "Koppa Tengu gains Force skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 052 Koppa Tengu
            { 053, new InnateSkill(383, 14, "Seelie Decree", "When switching to a Fairy demon \nall Support effects on Titania \nwill be passed to the switched ally.")}, // 053 Titania
            { 054, new InnateSkill(383, 14, "Fairy King's Melody", "When summoned from the stock, \nnegate -nda effects on the party.")}, // 054 Oberon
            { 055, new InnateSkill(383, 02, "Ice Gestalt", "Troll gains Ice skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 055 Troll
            { 056, new InnateSkill(383, 15, "Proxy Guard Hound", "While in the active party, increases \nCritical Damage by 30% for Avatar, \nHoly, Beast and Wilder allies.")}, // 056 Setanta
            { 057, new InnateSkill(410, 15, "Arbitration", "While in the active party, \nmay step in during negotiation and \nsoothe an enraged demon.")}, // 057 Kelpie
            { 058, new InnateSkill(383, 01, "Fiery Melody", "While in the active party, \nallies' Fire damage is increased \nby 10% when striking a weakness.")}, // 058 Jack-o'-Lantern
            { 059, new InnateSkill(353, 15, "Lucky Find", "Occasionally find items on the Vortex World Map while in the active party.")}, // 059 High Pixie
            { 060, new InnateSkill(383, 02, "Ice Enhancer", "While in the active party, \nraise allies' Ice skill potential \nto Jack Frost's if it was lower.")}, // 060 Jack Frost
            { 061, new InnateSkill(383, 15, "Hidden Potential", "Under special circumstances, \nPixie gains greatly improved \nskill potentials.")}, // 061 Pixie
            { 062, new InnateSkill(383, 06, "Light Gestalt", "Throne gains Light skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 062 Throne
            { 063, new InnateSkill(383, 06, "Light Enhancer", "While in the active party, \nraise allies' Light skill potential \nto Dominion's if it was lower.")}, // 063 Dominion
            { 064, new InnateSkill(411, 15, "Detain", "While in the active party, \nmay step in during negotiation and \nprevent a demon from making off with payment.")}, // 064 Virtue
            { 065, new InnateSkill(383, 06, "Light Gestalt", "Power gains Light skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 065 Power
            { 066, new InnateSkill(383, 12, "Shot Enhancer", "While in the active party, \nraise allies' Shot skill potential \nto Principality's if it was lower.")}, // 066 Principality
            { 067, new InnateSkill(383, 15, "Focused Assault", "Archangel gains 20% Hit Rate and \nCritical Rate when targetting the \nsame single foe as the previous ally.")}, // 067 Archangel
            { 068, new InnateSkill(411, 15, "Detain", "While in the active party, \nmay step in during negotiation and \nprevent a demon from making off with payment.")}, // 068 Angel
            { 069, new InnateSkill(383, 15, "Paw-to-Paw Combat", "Flauros' Critical Damage \nincreases by 30% if at least two \nallies have Paw-to-Paw Combat.")}, // 069 Flauros
            { 070, new InnateSkill(383, 15, "Kept Waiting", "Decarabia gains slight HP/MP \nrecovery after each action if \nForneus is also in the active party.")}, // 070 Decarabia
            { 071, new InnateSkill(383, 15, "Paw-to-Paw Combat", "Ose's Critical Damage \nincreases by 30% if at least two \nallies have Paw-to-Paw Combat.")}, // 071 Ose
            { 072, new InnateSkill(383, 01, "Fire Gestalt", "Berith gains Fire skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 072 Berith
            { 073, new InnateSkill(383, 15, "Helmsman", "When Eligor acts, the next ally \ngains 30% Hit Rate if they attack.")}, // 073 Eligor
            { 074, new InnateSkill(383, 15, "Best Friend", "Forneus' -nda effects reduce \nenemies' stats by one extra rank if \nDecarabia is also in the active party.")}, // 074 Forneus
            { 075, new InnateSkill(383, 02, "Ice Gestalt", "Yurlungur gains Ice skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 075 Yurlungur
            { 076, new InnateSkill(383, 02, "Breath of Plenty", "While in the active party, all allies' \nIce attacks may Critically Strike. \n(10% base rate)")}, // 076 Quetzalcoatl
            { 077, new InnateSkill(383, 03, "Elec Gestalt", "Naga Raja gains Elec skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 077 Naga Raja
            { 078, new InnateSkill(383, 02, "Frigid Melody", "While in the active party, \nallies' Ice damage is increased \nby 10% when striking a weakness.")}, // 078 Mizuchi
            { 079, new InnateSkill(383, 03, "Elec Gestalt", "Naga gains Elec skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 079 Naga
            { 080, new InnateSkill(383, 15, "Magnified Malady", "While in the active party, all allies \ndeal 20% more damage against \nenemies with an ailment.")}, // 080 Nozuchi
            { 081, new InnateSkill(383, 15, "Faithful Companion", "After Cerberus strikes a weakness, \nthe next ally deals 20% more \ndamage if they attack.")}, // 081 Cerberus
            { 082, new InnateSkill(383, 15, "Faithful Companion", "After Orthrus strikes a weakness, \nthe next ally deals 20% more \ndamage if they attack.")}, // 082 Orthrus
            { 083, new InnateSkill(383, 04, "Force Enhancer", "While in the active party, \nraise allies' Force skill potential \nto Suparna's if it was lower.")}, // 083 Suparna
            { 084, new InnateSkill(383, 04, "Gusting Melody", "While in the active party, \nallies' Force damage is increased \nby 10% when striking a weakness.")}, // 084 Badb Catha
            { 085, new InnateSkill(383, 15, "Faithful Companion", "After Inugami strikes a weakness, \nthe next ally deals 20% more \ndamage if they attack.")}, // 085 Inugami
            { 086, new InnateSkill(383, 15, "Paw-to-Paw Combat", "Nekomata's Critical Damage \nincreases by 30% if at least two \nallies have Paw-to-Paw Combat.")}, // 086 Nekomata
            { 087, new InnateSkill(383, 15, "Critical Melody", "While in the active party, \nallies' Critical Damage is \nincreased by 10%.")}, // 087 Gogmagog
            { 088, new InnateSkill(383, 00, "Phys Enhancer", "While in the active party, \nraise allies' Phys skill potential \nto Titan's if it was lower.")}, // 088 Titan
            { 089, new InnateSkill(409, 15, "Haggle", "While in the active party, \nmay step in during negotiation and \nensure lesser demands.")}, // 089 Sarutahiko
            { 090, new InnateSkill(383, 12, "Shot Gestalt", "Sudama gains Shot skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 090 Sudama
            { 091, new InnateSkill(383, 01, "Fire Gestalt", "Hua Po gains Fire skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 091 Hua Po
            { 092, new InnateSkill(383, 04, "Force Gestalt", "Kodama gains Force skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 092 Kodama
            { 093, new InnateSkill(383, 13, "Ward Off Evil", "While in the active party, \nall allies have an increased \nchance to recover from ailments.")}, // 093 Shiki-Ouji
            { 094, new InnateSkill(409, 15, "Haggle", "While in the active party, \nmay step in during negotiation and \nensure lesser demands.")}, // 094 Oni
            { 095, new InnateSkill(383, 12, "Shot Enhancer", "While in the active party, \nraise allies' Shot skill potential \nto Yomotsu-Ikusa's if it was lower.")}, // 095 Yomotsu-Ikusa
            { 096, new InnateSkill(413, 15, "Silver Tongue", "While in the active party, \nmay step in during negotiation to \npersuade an indecisive demon.")}, // 096 Momunofu
            { 097, new InnateSkill(383, 03, "Elec Gestalt", "Shikigami gains Elec skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 097 Shikigami
            { 098, new InnateSkill(383, 01, "Fire Gestalt", "Rangda gains Fire skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 098 Rangda
            { 099, new InnateSkill(383, 00, "Phys Enhancer", "While in the active party, \nraise allies' Phys skill potential \nto Dakini's if it was lower.")}, // 099 Dakini
            { 100, new InnateSkill(383, 15, "Critical Melody", "While in the active party, \nallies' Critical Damage is \nincreased by 10%.")}, // 100 Yaksini
            { 101, new InnateSkill(383, 12, "Shot Gestalt", "Yomotsu-Shikome gains Shot skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 101 Yomotsu-Shikome
            { 102, new InnateSkill(383, 15, "Contagious Curse", "While in the active party, \nallies' Ailment Rate is \nincreased by 20%.")}, // 102 Taraka
            { 103, new InnateSkill(383, 02, "Ice Gestalt", "Datsue-Ba gains Ice skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 103 Datsue-Ba
            { 104, new InnateSkill(419, 15, "Wine Party", "While in the active party, \nmay step in during negotiation to \nfix trouble with the power of liquor.")}, // 104 Mada
            { 105, new InnateSkill(383, 15, "Behemothic Bounce", "Damage reflected by Girimekhala \nis tripled.")}, // 105 Girimekhala
            { 106, new InnateSkill(353, 15, "Lucky Find", "Occasionally find items on the Vortex World Map while in the active party.")}, // 106 Taotie
            { 107, new InnateSkill(383, 15, "Magnified Malady", "While in the active party, all allies \ndeal 20% more damage against \nenemies with an ailment.")}, // 107 Pazuzu
            { 108, new InnateSkill(383, 07, "Dark Gestalt", "Baphomet gains Dark skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 108 Baphomet
            { 109, new InnateSkill(383, 14, "Megalomania", "While in the active party, \nafter an ally uses a charge effect \nthey gain a 20% chance to retain it.")}, // 109 Mot
            { 110, new InnateSkill(383, 15, "Withheld Sentence", "While in the active party, \nallies are immune to random \ninstakills.")}, // 110 Alciel
            { 111, new InnateSkill(383, 01, "Laevateinn", "Fire Enhancer & Surt's normal \nattacks deal medium Fire damage.")}, // 111 Surt
            { 112, new InnateSkill(414, 15, "Intimidate", "While in the active party, \nmay step in during negotiation to \n'convince' a lower level demon.")}, // 112 Abaddon
            { 113, new InnateSkill(383, 15, "Destabilize", "While in the active party, Element \nattacks may Critically Strike \nfor all allies and enemies.")}, // 113 Loki
            { 114, new InnateSkill(383, 05, "Forbidden Fruit", "While in the active party, all allies' \nAlmighty attacks may Critically Strike. \n(10% base rate)")}, // 114 Lilith
            { 115, new InnateSkill(383, 14, "Megalomania", "While in the active party, \nafter an ally uses a charge effect \nthey gain a 20% chance to retain it.")}, // 115 Nyx
            { 116, new InnateSkill(383, 14, "Unseelie Decree", "When switching to a Night demon \nall Support effects on Queen Mab \nwill be passed to the switched ally.")}, // 116 Queen Mab
            { 117, new InnateSkill(415, 15, "Entice", "While in the active party, \nmay step in during negotiation to \ntempt a male demon.")}, // 117 Succubus
            { 118, new InnateSkill(383, 07, "Twilit Melody", "While in the active party, \nallies' Dark damage is increased \nby 10% when striking a weakness.")}, // 118 Incubus
            { 119, new InnateSkill(383, 00, "Phys Enhancer", "While in the active party, \nraise allies' Phys skill potential \nto Fomorian's if it was lower.")}, // 119 Fomorian
            { 120, new InnateSkill(420, 15, "Flatter", "While in the active party, \nmay step in during negotiation to \nconvince a higher level demon.")}, // 120 Lilim
            { 121, new InnateSkill(383, 04, "Force Gestalt", "Hresvelgr gains Force skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 121 Hresvelgr
            { 122, new InnateSkill(353, 15, "Lucky Find", "Occasionally find items on the Vortex World Map while in the active party.")}, // 122 Mothman
            { 123, new InnateSkill(383, 03, "Thunderous Melody", "While in the active party, \nallies' Elec damage is increased \nby 10% when striking a weakness.")}, // 123 Raiju
            { 124, new InnateSkill(383, 15, "Critical Melody", "While in the active party, \nallies' Critical Damage is \nincreased by 10%.")}, // 124 Nue
            { 125, new InnateSkill(383, 15, "Critical Melody", "While in the active party, \nallies' Critical Damage is \nincreased by 10%.")}, // 125 Bicorn
            { 126, new InnateSkill(383, 15, "Contagious Curse", "While in the active party, \nallies' Ailment Rate is \nincreased by 20%.")}, // 126 Zhen
            { 127, new InnateSkill(383, 15, "Essence Thief", "Vetala's attacks which drain \nHP/MP restore 100% of the damage \ndealt.")}, // 127 Vetala
            { 128, new InnateSkill(383, 15, "Deathly Affliction", "While in the active party, all allies \ngain 20% Hit Rate and Critical Rate \nagainst enemies with an ailment.")}, // 128 Legion
            { 129, new InnateSkill(383, 15, "Deathly Affliction", "While in the active party, all allies \ngain 20% Hit Rate and Critical Rate \nagainst enemies with an ailment.")}, // 129 Yaka
            { 130, new InnateSkill(383, 00, "Phys Gestalt", "Choronzon gains Phys skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 130 Choronzon
            { 131, new InnateSkill(383, 15, "Focused Assault", "Preta gains 20% Hit Rate and \nCritical Rate when targetting the \nsame single foe as the previous ally.")}, // 131 Preta
            { 132, new InnateSkill(383, 07, "Dark Enhancer", "While in the active party, \nraise allies' Dark skill potential \nto Shadow's if it was lower.")}, // 132 Shadow
            { 133, new InnateSkill(383, 15, "Contagious Curse", "While in the active party, \nallies' Ailment Rate is \nincreased by 20%.")}, // 133 Black Ooze
            { 134, new InnateSkill(383, 15, "Essence Thief", "Blob's attacks which drain \nHP/MP restore 100% of the damage \ndealt.")}, // 134 Blob
            { 135, new InnateSkill(383, 15, "Deathly Affliction", "While in the active party, all allies \ngain 20% Hit Rate and Critical Rate \nagainst enemies with an ailment.")}, // 135 Slime
            { 136, new InnateSkill(383, 15, "Magnified Malady", "While in the active party, all allies \ndeal 20% more damage against \nenemies with an ailment.")}, // 136 Mou-Ryo
            { 137, new InnateSkill(383, 15, "Essence Thief", "Will o' Wisp's attacks which drain \nHP/MP restore 100% of the damage \ndealt.")}, // 137 Will o' Wisp
            { 138, new InnateSkill(383, 14, "Retributive Zeal", "When an allied Divine or Seraph \ndemon dies, Maximize Michael's \nPhysical/Magical Attack.")}, // 138 Michael
            { 139, new InnateSkill(383, 14, "Retributive Zeal", "When an allied Divine or Seraph \ndemon dies, Maximize Gabriel's \nPhysical/Magical Attack.")}, // 139 Gabriel
            { 140, new InnateSkill(383, 14, "Retributive Zeal", "When an allied Divine or Seraph \ndemon dies, Maximize Raphael's \nPhysical/Magical Attack.")}, // 140 Raphael
            { 141, new InnateSkill(383, 14, "Retributive Zeal", "When an allied Divine or Seraph \ndemon dies, Maximize Uriel's \nPhysical/Magical Attack.")}, // 141 Uriel
            { 142, new InnateSkill(383, 14, "Divine Benevolence", "While in the active party, \nSupport skill costs are reduced \nby 20% for all allies.")}, // 142 Ganesha
            { 143, new InnateSkill(383, 15, "Helmsman", "When Valkyrie acts, the next ally \ngains 30% Hit Rate if they attack.")}, // 143 Valkyrie
            { 144, new InnateSkill(383, 14, "Affable Hospitality", "When an ally is summoned from the \nstock, Arahabaki shares non-charge \nSupport effects with the switched ally.")}, // 144 Arahabaki
            { 145, new InnateSkill(383, 13, "Ward Off Evil", "While in the active party, \nall allies have an increased \nchance to recover from ailments.")}, // 145 Kurama Tengu
            { 146, new InnateSkill(383, 15, "Ramayana", "Phys Gestalt & after \nHanuman heals a single ally, \ncure their ailments.")}, // 146 Hanuman
            { 147, new InnateSkill(383, 15, "Proxy Guard Hound", "While in the active party, increases \nCritical Damage by 30% for Avatar, \nHoly, Beast and Wilder allies.")}, // 147 Cu Chulainn
            { 148, new InnateSkill(383, 15, "Auspicious Beast", "While in the active party, raise allied \nAuspicious Beast's skill potentials \nto Qing Long's if they were lower.")}, // 148 Qing Long
            { 149, new InnateSkill(383, 15, "Auspicious Beast", "While in the active party, raise allied \nAuspicious Beast's skill potentials \nto Xuanwu's if they were lower.")}, // 149 Xuanwu
            { 150, new InnateSkill(383, 03, "Vanquishing Bolts", "While in the active party, all allies' \nElec attacks may Critically Strike. \n(10% base rate)")}, // 150 Barong
            { 151, new InnateSkill(383, 15, "Faithful Companion", "After Makami strikes a weakness, \nthe next ally deals 20% more \ndamage if they attack.")}, // 151 Makami
            { 152, new InnateSkill(383, 04, "Force Enhancer", "While in the active party, \nraise allies' Force skill potential \nto Garuda's if it was lower.")}, // 152 Garuda
            { 153, new InnateSkill(383, 15, "Helmsman", "When Yatagarasu acts, the next ally \ngains 30% Hit Rate if they attack.")}, // 153 Yatagarasu
            { 154, new InnateSkill(383, 04, "Gusting Melody", "While in the active party, \nallies' Force damage is increased \nby 10% when striking a weakness.")}, // 154 Gurulu
            { 155, new InnateSkill(383, 15, "Milton", "Albion Nullifies damage from \nElement attacks based on which Zoas \nare in the active party.")}, // 155 Albion
            { 156, new InnateSkill(383, 15, "No Innate Skill", "")}, // 156 Manikin
            { 157, new InnateSkill(383, 15, "No Innate Skill", "")}, // 157 Manikin
            { 158, new InnateSkill(383, 15, "No Innate Skill", "")}, // 158 Manikin
            { 159, new InnateSkill(383, 15, "No Innate Skill", "")}, // 159 Manikin
            { 160, new InnateSkill(383, 15, "No Innate Skill", "")}, // 160 Manikin
            { 161, new InnateSkill(383, 15, "Undermine Divinity", "Samael's attacks against targets \nwith an ailment gain Pierce.")}, // 161 Samael
            { 162, new InnateSkill(383, 15, "No Innate Skill", "")}, // 162 Manikin
            { 163, new InnateSkill(383, 15, "No Innate Skill", "")}, // 163 Manikin
            { 164, new InnateSkill(383, 15, "No Innate Skill", "")}, // 164 Manikin
            { 165, new InnateSkill(383, 15, "No Innate Skill", "")}, // 165 Manikin
            { 166, new InnateSkill(383, 15, "No Innate Skill", "")}, // 166 Manikin
            { 167, new InnateSkill(353, 15, "Lucky Find", "Occasionally find items on the Vortex World Map while in the active party.")}, // 167 Pisaca
            { 168, new InnateSkill(383, 07, "Dark Star", "While in the active party, all allies' \nDark attacks may Critically Strike. \n(10% base rate)")}, // 168 Kaiwan
            { 169, new InnateSkill(383, 15, "Four Oni", "Kin-Ki's Charged/Critical Damage \nincreases by 10% for each \nFour Oni in the active party.")}, // 169 Kin-Ki
            { 170, new InnateSkill(383, 15, "Four Oni", "Sui-Ki's Charged/Critical Damage \nincreases by 10% for each \nFour Oni in the active party.")}, // 170 Sui-Ki
            { 171, new InnateSkill(383, 15, "Four Oni", "Fuu-Ki's Charged/Critical Damage \nincreases by 10% for each \nFour Oni in the active party.")}, // 171 Fuu-Ki
            { 172, new InnateSkill(383, 15, "Four Oni", "Ongyo-Ki's Charged/Critical Damage \nincreases by 10% for each \nFour Oni in the active party.")}, // 172 Ongyo-Ki
            { 173, new InnateSkill(383, 15, "Moirae Spinner", "When all three Moirae are in \nthe active party, skill costs are \nreduced by 20% for all allies.")}, // 173 Clotho
            { 174, new InnateSkill(383, 15, "Moirae Measurer", "When all three Moirae are in \nthe active party, allies' -kaja effects \nincrease stats by one extra rank.")}, // 174 Lachesis
            { 175, new InnateSkill(383, 15, "Moirae Cutter", "When all three Moirae are in \nthe active party, all allies' attacks \ndeal 10% more damage.")}, // 175 Atropos
            { 176, new InnateSkill(383, 15, "Taboo", "While in the active party, \ndouble the Ailment Rate for \nall allies and enemies.")}, // 176 Loa
            { 177, new InnateSkill(383, 07, "Dark Enhancer", "While in the active party, \nraise allies' Dark skill potential \nto Chatterskull's if it was lower.")}, // 177 Chatterskull
            { 178, new InnateSkill(383, 15, "Contagious Curse", "While in the active party, \nallies' Ailment Rate is \nincreased by 20%.")}, // 178 Phantom
            { 179, new InnateSkill(383, 15, "Paw-to-Paw Combat", "Ose Hallel's Critical Damage \nincreases by 30% if at least two \nallies have Paw-to-Paw Combat.")}, // 179 Ose Hallel
            { 180, new InnateSkill(383, 15, "Paw-to-Paw Combat", "Flauros Hallel's Critical Damage \nincreases by 30% if at least two \nallies have Paw-to-Paw Combat.")}, // 180 Flauros Hallel
            { 181, new InnateSkill(383, 03, "Thunderous Melody", "While in the active party, \nallies' Elec damage is increased \nby 10% when striking a weakness.")}, // 181 Urthona
            { 182, new InnateSkill(383, 01, "Fiery Melody", "While in the active party, \nallies' Fire damage is increased \nby 10% when striking a weakness.")}, // 182 Urizen
            { 183, new InnateSkill(383, 04, "Gusting Melody", "While in the active party, \nallies' Force damage is increased \nby 10% when striking a weakness.")}, // 183 Luvah
            { 184, new InnateSkill(383, 02, "Frigid Melody", "While in the active party, \nallies' Ice damage is increased \nby 10% when striking a weakness.")}, // 184 Tharmus
            { 185, new InnateSkill(383, 15, "Phantasmagoria", "Specter's attacks, including Magic, \ngain 10% Critical Rate against \ntargets with a lower Magic stat.")}, // 185 Specter
            { 186, new InnateSkill(383, 15, "Unlimited Desire", "If Mara's Physical Attack is \nmaximized, his Strength-based \nattacks always Critically Strike.")}, // 186 Mara
            { 187, new InnateSkill(383, 15, "", "")}, // 187 
            { 188, new InnateSkill(383, 15, "", "")}, // 188 
            { 189, new InnateSkill(383, 15, "", "")}, // 189 
            { 190, new InnateSkill(383, 15, "", "")}, // 190 
            { 191, new InnateSkill(383, 15, "", "")}, // 191 
            { 192, new InnateSkill(383, 15, "Raidou/Dante", "")}, // 192 Raidou/Dante
            { 193, new InnateSkill(383, 05, "Almighty Gestalt", "Metatron gains Almighty skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 193 Metatron
            { 194, new InnateSkill(383, 05, "Almighty Enhancer", "While in the active party, \nraise allies' Almighty skill potential \nto Beelzebub's if it was lower.")}, // 194 Beelzebub (Fly)
            { 195, new InnateSkill(383, 14, "Four Horsemen", "When switching to a Four Horsemen, \nall Support effects on Pale Rider \nwill be passed to the switched ally.")}, // 195 Pale Rider
            { 196, new InnateSkill(383, 14, "Four Horsemen", "When switching to a Four Horsemen, \nall Support effects on White Rider \nwill be passed to the switched ally.")}, // 196 White Rider
            { 197, new InnateSkill(383, 14, "Four Horsemen", "When switching to a Four Horsemen, \nall Support effects on Red Rider \nwill be passed to the switched ally.")}, // 197 Red Rider
            { 198, new InnateSkill(383, 14, "Four Horsemen", "When switching to a Four Horsemen, \nall Support effects on Black Rider \nwill be passed to the switched ally.")}, // 198 Black Rider
            { 199, new InnateSkill(383, 00, "Estocada", "Matador may perform a weak \ncounterattack after dodging or nullifying \nan attack. Pow: 32")}, // 199 Matador
            { 200, new InnateSkill(383, 15, "Speed Star", "Hell Biker's attacks, including Magic, \ngain 10% Critical Rate against \ntargets with a lower Agility stat.")}, // 200 Hell Biker
            { 201, new InnateSkill(383, 13, "Guiding Wisdom", "While in the active party, \nwhen an ally is summoned from the \nstock, cure their ailments.")}, // 201 Daisoujou
            { 202, new InnateSkill(383, 15, "Indulgence", "Mother Harlot's attacks with \npositive potential will not miss \nagainst targets with an ailment.")}, // 202 Mother Harlot
            { 203, new InnateSkill(383, 15, "Final Countdown", "On every 8th turn Trumpeter takes, \nskills cost nothing for the turn.")}, // 203 Trumpeter
            { 204, new InnateSkill(383, 15, "Underdog", "Futomimi deals up to 30% more \ndamage based on his missing HP.")}, // 204 Futomimi
            { 205, new InnateSkill(383, 15, "Desperate Power", "Sakahagi deals up to 30% more \ndamage based on his missing MP.")}, // 205 Sakahagi
            { 206, new InnateSkill(383, 02, "Cold World", "Black Frost's Ice attacks may \ninstakill instead of inflicting Freeze.")}, // 206 Black Frost
            { 207, new InnateSkill(383, 05, "Almighty Enhancer", "While in the active party, \nraise allies' Almighty skill potential \nto Beelzebub's if it was lower.")}, // 207 Beelzebub (Man)
            { 208, new InnateSkill(383, 15, "", "")}, // 208 
            { 209, new InnateSkill(383, 15, "", "")}, // 209 
            { 210, new InnateSkill(383, 15, "", "")}, // 210 
            { 211, new InnateSkill(383, 15, "", "")}, // 211 
            { 212, new InnateSkill(383, 15, "", "")}, // 212 
            { 213, new InnateSkill(383, 15, "", "")}, // 213 
            { 214, new InnateSkill(383, 15, "", "")}, // 214 
            { 215, new InnateSkill(383, 15, "", "")}, // 215 
            { 216, new InnateSkill(383, 15, "", "")}, // 216 
            { 217, new InnateSkill(383, 15, "", "")}, // 217 
            { 218, new InnateSkill(383, 15, "", "")}, // 218 
            { 219, new InnateSkill(383, 15, "", "")}, // 219 
            { 220, new InnateSkill(383, 15, "", "")}, // 220 
            { 221, new InnateSkill(383, 15, "", "")}, // 221 
            { 222, new InnateSkill(383, 15, "", "")}, // 222 
            { 223, new InnateSkill(383, 15, "", "")}, // 223 
            { 224, new InnateSkill(383, 06, "Blessed Melody", "While in the active party, \nallies' Light damage is increased \nby 10% when striking a weakness.")}, // 224 Tam Lin
            { 225, new InnateSkill(383, 15, "Evil Mirror", "Doppelgänger mimics single-target \nskills used by the Demi-fiend \nwith reduced power.")}, // 225 Doppelganger
            { 226, new InnateSkill(383, 15, "Magnified Malady", "While in the active party, all allies \ndeal 20% more damage against \nenemies with an ailment.")}, // 226 Nightmare
            { 227, new InnateSkill(383, 15, "Paw-to-Paw Combat", "Gdon's Critical Damage increases \nby 30% if at least two \nallies have Paw-to-Paw Combat.")}, // 227 Gdon
            { 228, new InnateSkill(383, 03, "Elec Enhancer", "While in the active party, \nraise allies' Elec skill potential \nto Vritra's if it was lower.")}, // 228 Vritra
            { 229, new InnateSkill(383, 15, "Magatama Mimicry", "Demee-Ho gains skill potential \ndependent on which Magatama is \ncurrently ingested.")}, // 229 Demee-Ho
            { 230, new InnateSkill(383, 15, "Covetous Fury", "Seth's attacks, including Magic, \ngain 10% Critical Rate against \ntargets with any greater stat.")}, // 230 Seth
            { 231, new InnateSkill(383, 15, "", "")}, // 231 
            { 232, new InnateSkill(383, 15, "", "")}, // 232 
            { 233, new InnateSkill(383, 15, "", "")}, // 233 
            { 234, new InnateSkill(383, 15, "", "")}, // 234 
            { 235, new InnateSkill(383, 15, "", "")}, // 235 
            { 236, new InnateSkill(383, 15, "", "")}, // 236 
            { 237, new InnateSkill(383, 15, "", "")}, // 237 
            { 238, new InnateSkill(383, 15, "", "")}, // 238 
            { 239, new InnateSkill(383, 15, "", "")}, // 239 
            { 240, new InnateSkill(383, 15, "", "")}, // 240 
            { 241, new InnateSkill(383, 15, "", "")}, // 241 
            { 242, new InnateSkill(383, 15, "", "")}, // 242 
            { 243, new InnateSkill(383, 15, "Magnified Malady", "")}, // 243 Boss Pazuzu
            { 244, new InnateSkill(383, 15, "Silencing Bellow", "")}, // 244 Triple Reason Ahriman
            { 245, new InnateSkill(383, 15, "Condemn Weakness", "")}, // 245 Triple Reason Baal Avatar
            { 246, new InnateSkill(383, 15, "Aurora", "")}, // 246 Triple Reason Noah
            { 247, new InnateSkill(383, 15, "", "")}, // 247 
            { 248, new InnateSkill(383, 15, "Covetous Fury", "")}, // Boss Seth
            { 249, new InnateSkill(383, 15, "Behemothic Bounce", "")}, // 249 Sarge Girimekhala
            { 250, new InnateSkill(383, 15, "Hidden Potential", "")}, // 250 NKE Pixie
            { 251, new InnateSkill(383, 02, "Ice Enhancer", "")}, // 251 NKE Jack Frost
            { 252, new InnateSkill(383, 15, "Devil Regeneration", "")}, // 252 Devil Dante
            { 253, new InnateSkill(383, 15, "Withheld Sentence", "")}, // 253 Gamete
            { 254, new InnateSkill(383, 15, "Shalt Not Resist", "")}, // 254 YHVH
            { 255, new InnateSkill(383, 15, "", "")}, // 255 
            { 256, new InnateSkill(383, 15, "Best Friend", "")}, // 256 Boss Forneus
            { 257, new InnateSkill(383, 15, "Phantasmagoria", "")}, // 257 Boss Specter 1 (Mini)
            { 258, new InnateSkill(383, 05, "Silencing Bellow", "")}, // 258 Boss Ahriman 2
            { 259, new InnateSkill(383, 15, "Aurora", "")}, // 259 Boss Noah 2
            { 260, new InnateSkill(383, 15, "Twilit Melody", "")}, // 260 Forced Incubus
            { 261, new InnateSkill(383, 15, "Force Gestalt", "")}, // 261 Forced Koppa Tengu
            { 262, new InnateSkill(383, 07, "Dark Star", "")}, // 262 Forced Kaiwan
            { 263, new InnateSkill(383, 15, "Paw-to-Paw Combat", "")}, // 263 Boss Ose
            { 264, new InnateSkill(383, 15, "Eternal Light", "")}, // 264 Boss Kagutsuchi 2
            { 265, new InnateSkill(383, 15, "Frigid Melody", "")}, // 265 Ambush Mizuchi
            { 266, new InnateSkill(383, 15, "Four Oni", "")}, // 169 Boss Kin-Ki
            { 267, new InnateSkill(383, 15, "Four Oni", "")}, // 170 Boss Sui-Ki
            { 268, new InnateSkill(383, 15, "Four Oni", "")}, // 171 Boss Fuu-Ki
            { 269, new InnateSkill(383, 15, "Four Oni", "")}, // 172 Boss Ongyo-Ki
            { 270, new InnateSkill(383, 15, "Moirae Spinner", "")}, // 270 Boss Clotho (Solo)
            { 271, new InnateSkill(383, 15, "Moirae Measurer", "")}, // 271 Boss Lachesis (Solo)
            { 272, new InnateSkill(383, 15, "Moirae Cutter", "")}, // 272 Boss Atropos (Solo)
            { 273, new InnateSkill(383, 15, "Phantasmagoria", "")}, // 273 Boss Specter 2
            { 274, new InnateSkill(383, 15, "Behemothic Bounce", "")}, // 274 Boss Girimekhala
            { 275, new InnateSkill(383, 15, "Phantasmagoria", "")}, // 275 Boss Specter 3
            { 276, new InnateSkill(383, 15, "Withheld Sentence", "")}, // 276 Boss Alciel
            { 277, new InnateSkill(383, 02, "Queen of Winter", "")}, // 277 Boss Skadi
            { 278, new InnateSkill(383, 15, "Milton", "")}, // 278 Boss Albion
            { 279, new InnateSkill(383, 03, "Thunderous Melody", "")}, // 279 Boss Urthona
            { 280, new InnateSkill(383, 01, "Fiery Melody", "")}, // 280 Boss Urizen
            { 281, new InnateSkill(383, 04, "Gusting Melody", "")}, // 281 Boss Luvah
            { 282, new InnateSkill(383, 02, "Frigid Melody", "")}, // 282 Boss Tharmus
            { 283, new InnateSkill(383, 15, "Underdog", "")}, // 283 Boss Futomimi
            { 284, new InnateSkill(383, 14, "Retributive Zeal", "")}, // 284 Boss Gabriel
            { 285, new InnateSkill(383, 14, "Retributive Zeal", "")}, // 285 Boss Raphael
            { 286, new InnateSkill(383, 14, "Retributive Zeal", "")}, // 286 Boss Uriel
            { 287, new InnateSkill(383, 15, "Undermine Divinity", "")}, // 287 Boss Samael
            { 288, new InnateSkill(383, 15, "Condemn Weakness", "")}, // 288 Boss Baal Avatar
            { 289, new InnateSkill(383, 15, "Paw-to-Paw Combat", "")}, // 289 Boss Ose Hallel
            { 290, new InnateSkill(383, 15, "Paw-to-Paw Combat", "")}, // 290 Boss Flauros Hallel
            { 291, new InnateSkill(383, 05, "Hell's Forfeit", "")}, // 291 Boss Ahriman 1
            { 292, new InnateSkill(383, 15, "Aurora", "")}, // 292 Boss Noah 1
            { 293, new InnateSkill(383, 15, "Pulsating Light", "")}, // 293 Boss Kagutsuchi 1
            { 294, new InnateSkill(383, 15, "Phantasmagoria", "")}, // 294 Boss Specter 1 (Merged 6)
            { 295, new InnateSkill(383, 15, "Phantasmagoria", "")}, // 295 Boss Specter 1 (Merged 4-5)
            { 296, new InnateSkill(383, 15, "Phantasmagoria", "")}, // 296 Boss Specter 1 (Merged 2-3)
            { 297, new InnateSkill(383, 15, "Frigid Melody", "")}, // 297 Boss Mizuchi
            { 298, new InnateSkill(383, 14, "Retributive Zeal", "")}, // 298 Boss Michael
            { 299, new InnateSkill(383, 15, "Desperate Power", "")}, // 299 Boss Sakahagi
            { 300, new InnateSkill(383, 15, "Faithful Companion", "")}, // 300 Boss Orthrus
            { 301, new InnateSkill(383, 15, "Critical Melody", "")}, // 301 Boss Yaksini
            { 302, new InnateSkill(383, 03, "Odinson", "")}, // 302 Boss Thor
            { 303, new InnateSkill(383, 02, "Cold World", "")}, // 303 Boss Black Frost
            { 304, new InnateSkill(383, 15, "Faithful Companion", "")}, // 304 Boss Cerberus R
            { 305, new InnateSkill(383, 15, "Faithful Companion", "")}, // 305 Boss Cerberus C
            { 306, new InnateSkill(383, 15, "Faithful Companion", "")}, // 306 Boss Cerberus L
            { 307, new InnateSkill(383, 15, "Helmsman", "")}, // 307 Boss Eligor
            { 308, new InnateSkill(383, 15, "Helmsman", "")}, // 308 Boss Eligor
            { 309, new InnateSkill(383, 15, "Helmsman", "")}, // 309 Boss Eligor
            { 310, new InnateSkill(383, 15, "Arbitration", "")}, // 310 Ambush Kelpie
            { 311, new InnateSkill(383, 15, "Arbitration", "")}, // 311 Ambush Kelpie
            { 312, new InnateSkill(383, 01, "Fire Gestalt", "")}, // 312 Boss Berith
            { 313, new InnateSkill(383, 15, "Entice", "")}, // 313 Boss Succubus
            { 314, new InnateSkill(383, 15, "Lucky Find", "")}, // 314 Ambush High Pixie
            { 315, new InnateSkill(383, 07, "Dark Star", "")}, // 315 Boss Kaiwan
            { 316, new InnateSkill(383, 15, "Paw-to-Paw Combat", "")}, // 316 Forced Nekomata
            { 317, new InnateSkill(383, 02, "Ice Gestalt", "")}, // 317 Boss Troll
            { 318, new InnateSkill(383, 15, "Forced Will o' Wisp", "")}, // 318 Forced Will o' Wisp
            { 319, new InnateSkill(383, 15, "Focused Assault", "")}, // 319 Forced Preta
            { 320, new InnateSkill(383, 14, "Four Devas", "")}, // 320 Boss Bishamonten 1
            { 321, new InnateSkill(383, 15, "Unlimited Desire", "")}, // 321 Boss Mara
            { 322, new InnateSkill(383, 14, "Four Devas", "")}, // 322 Boss Bishamonten 2
            { 323, new InnateSkill(383, 14, "Four Devas", "")}, // 323 Boss Jikokuten
            { 324, new InnateSkill(383, 14, "Four Devas", "")}, // 324 Boss Koumokuten
            { 325, new InnateSkill(383, 14, "Four Devas", "")}, // 325 Boss Zouchouten
            { 326, new InnateSkill(383, 15, "Moirae Spinner", "")}, // 326 Boss Clotho (Together)
            { 327, new InnateSkill(383, 15, "Moirae Measurer", "")}, // 327 Boss Lachesis (Together)
            { 328, new InnateSkill(383, 15, "Moirae Cutter", "")}, // 328 Boss Atropos (Together)
            { 329, new InnateSkill(383, 14, "Righteous Vow", "")}, // 329 Boss Mitra
            { 330, new InnateSkill(383, 15, "", "")}, // 330 
            { 331, new InnateSkill(383, 15, "", "")}, // 331 
            { 332, new InnateSkill(383, 15, "", "")}, // 332 
            { 333, new InnateSkill(383, 15, "Wine Party", "")}, // 333 Boss Mada
            { 334, new InnateSkill(383, 15, "Megalomania", "")}, // 334 Boss Mot
            { 335, new InnateSkill(383, 01, "Laevateinn", "")}, // 335 Boss Surt
            { 336, new InnateSkill(383, 15, "Puzzle Boy", "")}, // 336 Puzzle Boy
            { 337, new InnateSkill(383, 03, "Odinson", "")}, // 337 Boss Thor 2
            { 338, new InnateSkill(383, 15, "", "")}, // 338 
            { 339, new InnateSkill(383, 15, "Boss Raidou/Dante 1", "")}, // 339 Boss Raidou/Dante 1
            { 340, new InnateSkill(383, 15, "Chase Raidou/Dante", "")}, // 340 Chase Raidou/Dante
            { 341, new InnateSkill(383, 15, "Boss Raidou/Dante 2", "")}, // 341 Boss Raidou/Dante 2
            { 342, new InnateSkill(383, 05, "Almighty Gestalt", "")}, // 342 Boss Metatron
            { 343, new InnateSkill(383, 05, "Almighty Enhancer", "")}, // 343 Boss Beelzebub
            { 344, new InnateSkill(383, 15, "Dawn of Demise", "")}, // 344 Boss Lucifer
            { 345, new InnateSkill(383, 15, "Four Horsemen", "")}, // 345 Boss Pale Rider
            { 346, new InnateSkill(383, 15, "Four Horsemen", "")}, // 346 Boss White Rider
            { 347, new InnateSkill(383, 15, "Four Horsemen", "")}, // 347 Boss Red Rider
            { 348, new InnateSkill(383, 15, "Four Horsemen", "")}, // 348 Boss Black Rider
            { 349, new InnateSkill(383, 00, "Estocada", "")}, // 349 Boss Matador
            { 350, new InnateSkill(383, 15, "Speed Star", "")}, // 350 Boss Hell Biker
            { 351, new InnateSkill(383, 13, "Guiding Wisdom", "")}, // 351 Boss Daisoujou
            { 352, new InnateSkill(383, 15, "Indulgence", "")}, // 352 Boss Mother Harlot
            { 353, new InnateSkill(383, 15, "Final Countdown", "")}, // 353 Boss Trumpeter
            { 354, new InnateSkill(383, 15, "", "")}, // 354 
            { 355, new InnateSkill(383, 15, "", "")}, // 355 
            { 356, new InnateSkill(383, 15, "No Innate Skill", "")}, // 356 Nasu Fly
            { 357, new InnateSkill(383, 15, "", "")}, // 357 
            { 358, new InnateSkill(383, 15, "Taboo", "")}, // 358 Boss Loa
            { 359, new InnateSkill(383, 15, "Detain", "")}, // 359 Boss Virtue
            { 360, new InnateSkill(383, 15, "Light Gestalt", "")}, // 360 Boss Power
            { 361, new InnateSkill(383, 15, "Deathly Affliction", "")}, // 361 Boss Legion
            { 362, new InnateSkill(383, 15, "Paw-to-Paw Combat", "")}, // 362 Boss Flauros
            { 363, new InnateSkill(383, 06, "Blessed Melody", "")}, // 363 Raidou Tam Lin
            { 364, new InnateSkill(383, 15, "Paw-to-Paw Combat", "")}, // 364 Raidou Gdon
            { 365, new InnateSkill(383, 03, "Elec Enhancer", "")}, // 365 Raidou Vritra
            { 366, new InnateSkill(383, 02, "Ice Enhancer", "")}, // 366 Raidou Jack Frost
            { 367, new InnateSkill(383, 15, "", "")}, // 367 
            { 368, new InnateSkill(383, 15, "", "")}, // 368 
            { 369, new InnateSkill(383, 15, "", "")}, // 369 
            { 370, new InnateSkill(383, 15, "", "")}, // 370 
            { 371, new InnateSkill(383, 15, "", "")}, // 371 
            { 372, new InnateSkill(383, 15, "", "")}, // 372 
            { 373, new InnateSkill(383, 15, "", "")}, // 373 
            { 374, new InnateSkill(383, 15, "", "")}, // 374 
            { 375, new InnateSkill(383, 15, "", "")}, // 375 
            { 376, new InnateSkill(383, 15, "", "")}, // 376 
            { 377, new InnateSkill(383, 15, "", "")}, // 377 
            { 378, new InnateSkill(383, 15, "", "")}, // 378 
            { 379, new InnateSkill(383, 15, "", "")}, // 379 
            { 380, new InnateSkill(383, 15, "", "")}, // 380 
            { 381, new InnateSkill(383, 15, "", "")}, // 381 
            { 382, new InnateSkill(383, 15, "", "")}, // 382 
            { 383, new InnateSkill(383, 15, "", "")}  // 383 
        };

        private static Dictionary<ushort, InnateSkill> demonInnateSkillsJp = new Dictionary<ushort, InnateSkill>
        {
            { 000, new InnateSkill(383, 15, "", "")}, // 000
            { 001, new InnateSkill(383, 15, "三都破壊", "戦闘メンバーにいる間、\nチャージ効果状態の味方はスキル\n消費MPが20%減少する。")}, // 001 Vishnu
            { 002, new InnateSkill(383, 14, "正義の誓い", "ミトラがクリティカルまたは弱点攻撃を耐\nえ抜いた後、全能力が1段階上昇する。")}, // 002 Mitra
            { 003, new InnateSkill(383, 06, "熾烈なる輝き", "戦闘メンバーにいる間、\n味方全体の破魔属性攻撃がクリティカル\n可能になる。(基本発生率10%)")}, // 003 Amaterasu
            { 004, new InnateSkill(383, 14, "知恵のルーン", "交代して下がる際、交代先の\n味方が最初に行う力依存攻撃の\nダメージを120%増加させる。")}, // 004 Odin
            { 005, new InnateSkill(383, 15, "集中攻撃", "直前の味方と同じ敵単体を狙う際、\n命中率とクリティカル率が20%上昇。")}, // 005 Atavaka
            { 006, new InnateSkill(383, 14, "ホルスの眼", "交代して下がる際、交代先の\n味方が最初に行う魔法攻撃の\nダメージを120%増加させる。")}, // 006 Horus
            { 007, new InnateSkill(383, 15, "チャンチャラー", "戦闘メンバーにいる間、\n味方の魔法攻撃力が最大値であれば、\nその属性攻撃がクリティカル可能になる。")}, // 007 Lakshmi
            { 008, new InnateSkill(383, 15, "武芸の師", "セタンタまたはクー・フーリンが戦闘\nメンバーにいる間、スカアハのプラス適正\nを持つスキルの攻撃はミスしなくなる。")}, // 008 Scathach
            { 009, new InnateSkill(383, 04, "ヴィーナーラーガ", "戦闘メンバーにいる間、\n味方全体の衝撃属性攻撃がクリティカル\n可能になる。(基本発生率10%)")}, // 009 Sarasvati
            { 010, new InnateSkill(383, 13, "癒しの調べ", "戦闘メンバーにいる間、\nすべての味方の回復スキル消費\nが20%減少する。")}, // 010 Sati
            { 011, new InnateSkill(383, 14, "岩戸開きの舞", "交代して下がる際、アメノウズメにかかっ\nているすべてのカジャ・ンダ\n系効果を交代先の味方に引き継ぐ。")}, // 011 Ame-no-Uzume
            { 012, new InnateSkill(383, 15, "三都破壊", "戦闘メンバーにいる間、\nチャージ効果状態の味方はスキル\n消費MPが20%減少する。")}, // 012 Shiva
            { 013, new InnateSkill(383, 15, "執行猶予", "戦闘メンバーにいる間、\n味方全体は確率による即死攻撃を\n無効化する。")}, // 013 Beidou Xingjun
            { 014, new InnateSkill(383, 14, "メガロマニア", "戦闘メンバーにいる間、\n味方がチャージ効果を消費した後、\n20%の確率でその効果が維持される。")}, // 014 Qitian Dasheng
            { 015, new InnateSkill(419, 15, "酒の宴", "戦闘メンバーにいる間、\n悪魔交渉に割り込んで酒の力でト\nラブルを解決することがある。")}, // 015 Dionysus
            { 016, new InnateSkill(383, 00, "物理のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、カーリーの物理適正\nが上昇する。")}, // 016 Kali
            { 017, new InnateSkill(383, 02, "冬の女王", "『氷結の増幅』＆スカディ\nの氷結攻撃による凍結(Freeze)\n付与確率が上昇する。")}, // 017 Skadi
            { 018, new InnateSkill(383, 13, "癒しの調べ", "戦闘メンバーにいる間、\nすべての味方の回復スキル消費\nが20%減少する。")}, // 018 Parvati
            { 019, new InnateSkill(383, 14, "怪物の贄", "破壊神の悪魔へ交代する際、\nクシナダヒメにかかっているすべての\n補助効果を交代先の味方に引き継ぐ。")}, // 019 Kushinada
            { 020, new InnateSkill(418, 15, "乙女の仲裁", "戦闘メンバーにいる間、\n悪魔交渉に介入して激怒した悪魔\nをなだめることがある。")}, // 020 Kikuri-Hime
            { 021, new InnateSkill(383, 14, "四天王", "ストックから召喚された時、\n戦闘メンバーにいるすべての『四天王』\nの全能力を1段階上昇させる。")}, // 021 Bishamonten
            { 022, new InnateSkill(383, 03, "オーディンの息子", "『電撃の増幅』＆トール\nの電撃攻撃による感電(Shock)\n付与確率が上昇する。")}, // 022 Thor
            { 023, new InnateSkill(383, 14, "四天王", "ストックから召喚された時、\n戦闘メンバーにいるすべての『四天王』\nの全能力を1段階上昇させる。")}, // 023 Jikokuten
            { 024, new InnateSkill(410, 15, "執り成し", "戦闘メンバーにいる間、\n悪魔交渉に割り込んで怒った悪魔\nをなだめることがある。")}, // 024 Take-Mikazuchi
            { 025, new InnateSkill(383, 14, "国造り", "オオクニヌシが単体の味方を回復\nさせた後、回復した味方の全能力\nを1段階上昇させる。")}, // 025 Okuninushi
            { 026, new InnateSkill(383, 14, "四天王", "ストックから召喚された時、\n戦闘メンバーにいるすべての『四天王』\nの全能力を1段階上昇させる。")}, // 026 Koumokuten
            { 027, new InnateSkill(383, 14, "四天王", "ストックから召喚された時、\n戦闘メンバーにいるすべての『四天王』\nの全能力を1段階上昇させる。")}, // 027 Zouchouten
            { 028, new InnateSkill(414, 15, "脅し", "戦闘メンバーにいる間、\n悪魔交渉に割り込んで自分よりレベルの\n低い悪魔を「説得」することがある。")}, // 028 Take-Minakata
            { 029, new InnateSkill(383, 15, "代役猛犬", "戦闘メンバーにいる間、神獣・聖獣・\n魔獣・妖獣の味方のクリティカルダメージ\nを30%増加させる。")}, // 029 Chimera
            { 030, new InnateSkill(383, 15, "七宿連星神", "戦闘メンバーにいる間、『七宿連星神』を持\nつ、他の味方のスキル適正がビャッコより\n低い場合、ビャッコの適正数値まで上昇する。")}, // 030 Baihu
            { 031, new InnateSkill(383, 15, "にゃん2ブロー", "『にゃん2ブロー』を持つ味方が2体以上い\nる場合、センリのクリティカル\nダメージが30%増加する。")}, // 031 Senri
            { 032, new InnateSkill(383, 15, "七宿連星神", "戦闘メンバーにいる間、『七宿連星神』を持\nつ、他の味方のスキル適正がスザクより\n低い場合、スザクの適正数値まで上昇する。")}, // 032 Zhuque
            { 033, new InnateSkill(383, 14, "良き助言者", "戦闘メンバーにいる間、\nすべての味方の補助スキル消費\nが20%減少する。")}, // 033 Shiisaa
            { 034, new InnateSkill(383, 15, "水先案内", "カイチが行動した時、\n次の行動順の味方が攻撃を行う場合、\n命中率が30%上昇する。")}, // 034 Xiezhai
            { 035, new InnateSkill(383, 06, "破魔の増幅", "戦闘メンバーにいる間、味方の\n破魔適正がユニコーンより低い場合、\nユニコーンの数値まで引き上げる。")}, // 035 Unicorn
            { 036, new InnateSkill(383, 01, "火炎の増幅", "戦闘メンバーにいる間、味方の\n火炎適正がフレイミーズより低い場合、\nフレイミーズの数値まで引き上げる。")}, // 036 Flaemis
            { 037, new InnateSkill(383, 02, "氷結の増幅", "戦闘メンバーにいる間、味方の\n氷結適正がアクアンズより低い場合、\nアクアンズの数値まで引き上げる。")}, // 037 Aquans
            { 038, new InnateSkill(383, 04, "衝撃の増幅", "戦闘メンバーにいる間、味方の\n衝撃適正がエアロスより低い場合、\nエアロスの数値まで引き上げる。")}, // 038 Aeros
            { 039, new InnateSkill(383, 03, "電撃の増幅", "戦闘メンバーにいる間、味方の\n電撃適正がアーシーズより低い場合、\nアーシーズの数値まで引き上げる。")}, // 039 Erthys
            { 040, new InnateSkill(383, 15, "啓蒙の儀式 ", "他の悪魔と合体させた際、\n合体後の悪魔の修得スキルを上\n書きできるようにする。")}, // 040 Saki Mitama
            { 041, new InnateSkill(383, 15, "啓蒙の儀式 ", "他の悪魔と合体させた際、\n合体後の悪魔の修得スキルを上\n書きできるようにする。")}, // 041 Kushi Mitama
            { 042, new InnateSkill(383, 15, "啓蒙の儀式 ", "他の悪魔と合体させた際、\n合体後の悪魔の修得スキルを上\n書きできるようにする。")}, // 042 Nigi Mitama
            { 043, new InnateSkill(383, 15, "啓蒙の儀式 ", "他の悪魔と合体させた際、\n合体後の悪魔の修得スキルを上\n書きできるようにする。")}, // 043 Ara Mitama
            { 044, new InnateSkill(383, 01, "邪悪なる炎", "戦闘メンバーにいる間、\n味方全体の火炎属性攻撃がクリティカル\n可能になる。(基本発生率10%)")}, // 044 Efreet
            { 045, new InnateSkill(413, 15, "雄弁な演説", "戦闘メンバーにいる間、\n悪魔交渉に割り込んで迷っている\n悪魔を説得することがある。")}, // 045 Pulukishi
            { 046, new InnateSkill(383, 00, "物理のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、オンコットの物理適正\nが上昇する。")}, // 046 Ongkhot
            { 047, new InnateSkill(420, 15, "ゴマすり", "戦闘メンバーにいる間、\n悪魔交渉に割り込んで格上の悪魔\nを説得することがある。")}, // 047 Jinn
            { 048, new InnateSkill(383, 04, "衝撃のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、カラステングの衝撃適正\nが上昇する。")}, // 048 Karasu Tengu
            { 049, new InnateSkill(383, 15, "ノルンの瞬き", "交代して下がる際、\nプレスターンアイコンを消費しない。")}, // 049 Dís
            { 050, new InnateSkill(383, 13, "癒しの調べ", "戦闘メンバーにいる間、\nすべての味方の回復スキル消費\nが20%減少する。")}, // 050 Isora
            { 051, new InnateSkill(415, 15, "惹き付ける", "戦闘メンバーにいる間、\n悪魔交渉に割り込んで男性悪魔を\n口説き落としすることがある。")}, // 051 Apsaras
            { 052, new InnateSkill(383, 04, "衝撃のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、コッパテングの衝撃適正\nが上昇する。")}, // 052 Koppa Tengu
            { 053, new InnateSkill(383, 14, "シーリーの布告", "妖精の悪魔へ交代する際、\nティターニアにかかっているすべての\n補助効果を交代先の味方に引き継ぐ。")}, // 053 Titania
            { 054, new InnateSkill(383, 14, "妖精王のメロディ", "ストックから召喚された時、\n味方全体の「ンダ系」\n効果を打ち消す。")}, // 054 Oberon
            { 055, new InnateSkill(383, 02, "氷結のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、トロールの氷結適正\nが上昇する。")}, // 055 Troll
            { 056, new InnateSkill(383, 15, "代役猛犬", "戦闘メンバーにいる間、神獣・聖獣・\n魔獣・妖獣の味方のクリティカルダメージ\nを30%増加させる。")}, // 056 Setanta
            { 057, new InnateSkill(410, 15, "執り成し", "戦闘メンバーにいる間、\n悪魔交渉に割り込んで怒った悪魔\nをなだめることがある。")}, // 057 Kelpie
            { 058, new InnateSkill(383, 01, "烈火の調べ", "戦闘メンバーにいる間、\n弱点を突いた際の味方の\n火炎ダメージが10%増加する。")}, // 058 Jack-o'-Lantern
            { 059, new InnateSkill(353, 15, "宝探し", "戦闘メンバーにいる間、\nボルテクス界のフィールド上\nで時折アイテムを発見する。")}, // 059 High Pixie
            { 060, new InnateSkill(383, 02, "氷結の増幅", "戦闘メンバーにいる間、味方の\n氷結適正がジャックフロストより低い場合、\nジャックフロストの数値まで引き上げる。")}, // 060 Jack Frost
            { 061, new InnateSkill(383, 15, "潜在能力", "特別な条件下において、\nピクシーのスキル適正が大幅に上昇する。")}, // 061 Pixie
            { 062, new InnateSkill(383, 06, "破魔のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、ソロネの破魔適正\nが上昇する。")}, // 062 Throne
            { 063, new InnateSkill(383, 06, "破魔の増幅", "戦闘メンバーにいる間、味方の\n破魔適正がドミニオンより低い場合、\nドミニオンの数値まで引き上げる。")}, // 063 Dominion
            { 064, new InnateSkill(411, 15, "引き止め", "戦闘メンバーにいる間、\n悪魔交渉中に介入し、悪魔が報酬を持\nち逃げするのを防ぐことがある。")}, // 064 Virtue
            { 065, new InnateSkill(383, 06, "破魔のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、パワーの破魔適正\nが上昇する。")}, // 065 Power
            { 066, new InnateSkill(383, 12, "銃撃の増幅", "戦闘メンバーにいる間、味方の\n銃撃適正がプリンシパリティより低い場合、\nプリンシパリティの数値まで引き上げる。")}, // 066 Principality
            { 067, new InnateSkill(383, 15, "集中攻撃", "直前の味方と同じ敵単体を狙う際、\n命中率とクリティカル率が20%上昇。")}, // 067 Archangel
            { 068, new InnateSkill(411, 15, "引き止め", "戦闘メンバーにいる間、\n悪魔交渉中に介入し、悪魔が報酬を持\nち逃げするのを防ぐことがある。")}, // 068 Angel
            { 069, new InnateSkill(383, 15, "にゃん2ブロー", "『にゃん2ブロー』を持つ味方が2体以上い\nる場合、フラロウスのクリティカル\nダメージが30%増加する。")}, // 069 Flauros
            { 070, new InnateSkill(383, 15, "待ちぼうけ", "フォルネウスも戦闘メンバーにいる場合、\nデカラビアの行動後にHPとMP\nがわずかに回復する。")}, // 070 Decarabia
            { 071, new InnateSkill(383, 15, "にゃん2ブロー", "『にゃん2ブロー』を持つ味方が2体以上い\nる場合、オセのクリティカル\nダメージが30%増加する。")}, // 071 Ose
            { 072, new InnateSkill(383, 01, "火炎のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、ベリスの火炎適正\nが上昇する。")}, // 072 Berith
            { 073, new InnateSkill(383, 15, "水先案内", "エリゴールが行動した時、\n次の行動順の味方が攻撃を行う場合、\n命中率が30%上昇する。")}, // 073 Eligor
            { 074, new InnateSkill(383, 15, "ベストフレンド", "デカラビアも戦闘メンバーにいる場合、\nフォルネウスのンダ系効果による敵の\n能力低下量が1段階追加される。")}, // 074 Forneus
            { 075, new InnateSkill(383, 02, "氷結のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、ユルングルの氷結適正\nが上昇する。")}, // 075 Yurlungur
            { 076, new InnateSkill(383, 02, "豊穣の息吹", "戦闘メンバーにいる間、\n味方全体の衝氷結性攻撃がクリティカル\n可能になる。(基本発生率10%)")}, // 076 Quetzalcoatl
            { 077, new InnateSkill(383, 03, "電撃のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、ナーガラジャの電撃適正\nが上昇する。")}, // 077 Naga Raja
            { 078, new InnateSkill(383, 02, "凍空の調べ", "戦闘メンバーにいる間、\n弱点を突いた際の味方の\n氷結ダメージが10%増加する。")}, // 078 Mizuchi
            { 079, new InnateSkill(383, 03, "電撃のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、ナーガの電撃適正\nが上昇する。")}, // 079 Naga
            { 080, new InnateSkill(383, 15, "連なる厄災", "戦闘メンバーにいる間、\n状態異常にかかった敵に対し、\n味方全体の与ダメージが20%増加する。")}, // 080 Nozuchi
            { 081, new InnateSkill(383, 15, "忠犬", "ケルベロスが弱点を突いた後、\n次の行動順の味方が攻撃を\n行うとダメージが20%増加する。")}, // 081 Cerberus
            { 082, new InnateSkill(383, 15, "忠犬", "オルトロスが弱点を突いた後、\n次の行動順の味方が攻撃を\n行うとダメージが20%増加する。")}, // 082 Orthrus
            { 083, new InnateSkill(383, 04, "衝撃の増幅", "戦闘メンバーにいる間、味方の\n衝撃適正がスパルナより低い場合、\nスパルナの数値まで引き上げる。")}, // 083 Suparna
            { 084, new InnateSkill(383, 04, "旋風の調べ", "戦闘メンバーにいる間、\n弱点を突いた際の味方の\n衝撃ダメージが10%増加する。")}, // 084 Badb Catha
            { 085, new InnateSkill(383, 15, "忠犬", "イヌガミが弱点を突いた後、\n次の行動順の味方が攻撃を\n行うとダメージが20%増加する。")}, // 085 Inugami
            { 086, new InnateSkill(383, 15, "にゃん2ブロー", "『にゃん2ブロー』を持つ味方が2体以上い\nる場合、ネコマタのクリティカル\nダメージが30%増加する。")}, // 086 Nekomata
            { 087, new InnateSkill(383, 15, "必殺の調べ", "戦闘メンバーにいる間、\n味方全体のクリティカルダメージが\n10%増加する。")}, // 087 Gogmagog
            { 088, new InnateSkill(383, 00, "物理の増幅", "戦闘メンバーにいる間、味方の\n物理適正がティターンより低い場合、\nティターンの数値まで引き上げる。")}, // 088 Titan
            { 089, new InnateSkill(409, 15, "値切り", "戦闘メンバーにいる間、\n悪魔交渉に割り込んで要求を軽減\nさせることがある。")}, // 089 Sarutahiko
            { 090, new InnateSkill(383, 12, "銃撃のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、スダマの銃撃適正\nが上昇する。")}, // 090 Sudama
            { 091, new InnateSkill(383, 01, "火炎のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、カハクの火炎適正\nが上昇する。")}, // 091 Hua Po
            { 092, new InnateSkill(383, 04, "衝撃のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、コダマの衝撃適正\nが上昇する。")}, // 092 Kodama
            { 093, new InnateSkill(383, 13, "厄除けのお守り", "戦闘メンバーにいる間、\n全味方の状態異常からの\n回復確率が上昇する。")}, // 093 Shiki-Ouji
            { 094, new InnateSkill(409, 15, "値切り", "戦闘メンバーにいる間、\n悪魔交渉に割り込んで要求を軽減\nさせることがある。")}, // 094 Oni
            { 095, new InnateSkill(383, 12, "銃撃の増幅", "戦闘メンバーにいる間、味方の\n銃撃適正がヨモツイクサより低い場合、\nヨモツイクサの数値まで引き上げる。")}, // 095 Yomotsu-Ikusa
            { 096, new InnateSkill(413, 15, "雄弁な演説", "戦闘メンバーにいる間、\n悪魔交渉に割り込んで迷っている\n悪魔を説得することがある。")}, // 096 Momunofu
            { 097, new InnateSkill(383, 03, "電撃のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、シキガミの電撃適正\nが上昇する。")}, // 097 Shikigami
            { 098, new InnateSkill(383, 01, "火炎のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、ランダの火炎適正\nが上昇する。")}, // 098 Rangda
            { 099, new InnateSkill(383, 00, "物理の増幅", "戦闘メンバーにいる間、味方の\n物理適正がダーキニーより低い場合、\nダーキニーの数値まで引き上げる。")}, // 099 Dakini
            { 100, new InnateSkill(383, 15, "必殺の調べ", "戦闘メンバーにいる間、\n味方全体のクリティカルダメージが\n10%増加する。")}, // 100 Yaksini
            { 101, new InnateSkill(383, 12, "銃撃のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、ヨモツシコメの銃撃適正\nが上昇する。")}, // 101 Yomotsu-Shikome
            { 102, new InnateSkill(383, 15, "伝染する呪い", "戦闘メンバーにいる間、\n味方の状態異常付与率が20%上昇。")}, // 102 Taraka
            { 103, new InnateSkill(383, 02, "氷結のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、ダツエバルの氷結適正\nが上昇する。")}, // 103 Datsue-Ba
            { 104, new InnateSkill(419, 15, "酒の宴", "戦闘メンバーにいる間、\n悪魔交渉に割り込んで酒の力でト\nラブルを解決することがある。")}, // 104 Mada
            { 105, new InnateSkill(383, 15, "反射する巨象", "ギリメカラが反射したダメージが\n3倍になる。")}, // 105 Girimekhala
            { 106, new InnateSkill(353, 15, "宝探し", "戦闘メンバーにいる間、\nボルテクス界のフィールド上\nで時折アイテムを発見する。")}, // 106 Taotie
            { 107, new InnateSkill(383, 15, "連なる厄災", "戦闘メンバーにいる間、\n状態異常にかかった敵に対し、\n味方全体の与ダメージが20%増加する。")}, // 107 Pazuzu
            { 108, new InnateSkill(383, 07, "呪殺のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、バフォメットの呪殺適正\nが上昇する。")}, // 108 Baphomet
            { 109, new InnateSkill(383, 14, "メガロマニア", "戦闘メンバーにいる間、\n味方がチャージ効果を消費した後、\n20%の確率でその効果が維持される。")}, // 109 Mot
            { 110, new InnateSkill(383, 15, "執行猶予", "戦闘メンバーにいる間、\n味方全体は確率による即死攻撃を\n無効化する。")}, // 110 Alciel
            { 111, new InnateSkill(383, 01, "レーヴァテイン", "『火炎の増幅』＆スルト\nの通常攻撃が火炎属性\n(中ダメージ)になる。")}, // 111 Surt
            { 112, new InnateSkill(414, 15, "脅し", "戦闘メンバーにいる間、\n悪魔交渉に割り込んで自分よりレベルの\n低い悪魔を「説得」することがある。")}, // 112 Abaddon
            { 113, new InnateSkill(383, 15, "混迷化", "戦闘メンバーにいる間、\n属性攻撃が、すべての味方および敵において\n確率でクリティカルになる。")}, // 113 Loki
            { 114, new InnateSkill(383, 05, "禁断の果実", "戦闘メンバーにいる間、\n味方全体の万能属性攻撃がクリティカル\n可能になる。(基本発生率10%)")}, // 114 Lilith
            { 115, new InnateSkill(383, 14, "メガロマニア", "戦闘メンバーにいる間、\n味方がチャージ効果を消費した後、\n20%の確率でその効果が維持される。")}, // 115 Nyx
            { 116, new InnateSkill(383, 14, "ウヌシーリーの布告", "夜魔の悪魔に交代する際、\nクイーンメイブにかかっているすべての\n補助効果が交代先の味方に引き継がれる。")}, // 116 Queen Mab
            { 117, new InnateSkill(415, 15, "惹き付ける", "戦闘メンバーにいる間、\n悪魔交渉に割り込んで男性悪魔を\n口説き落としすることがある。")}, // 117 Succubus
            { 118, new InnateSkill(383, 07, "真宵の調べ", "戦闘メンバーにいる間、\n弱点を突いた際の味方の\n呪殺ダメージが10%増加する。")}, // 118 Incubus
            { 119, new InnateSkill(383, 00, "物理の増幅", "戦闘メンバーにいる間、味方の\n物理適正がフォーモリアより低い場合、\nフォーモリアの数値まで引き上げる。")}, // 119 Fomorian
            { 120, new InnateSkill(420, 15, "ゴマすり", "戦闘メンバーにいる間、\n悪魔交渉に割り込んで格上の悪魔\nを説得することがある。")}, // 120 Lilim
            { 121, new InnateSkill(383, 04, "衝撃のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、フレスベルグの衝撃適正\nが上昇する。")}, // 121 Hresvelgr
            { 122, new InnateSkill(353, 15, "宝探し", "戦闘メンバーにいる間、\nボルテクス界のフィールド上\nで時折アイテムを発見する。")}, // 122 Mothman
            { 123, new InnateSkill(383, 03, "稲妻の調べ", "戦闘メンバーにいる間、\n弱点を突いた際の味方の\n電撃ダメージが10%増加する。")}, // 123 Raiju
            { 124, new InnateSkill(383, 15, "必殺の調べ", "戦闘メンバーにいる間、\n味方全体のクリティカルダメージが\n10%増加する。")}, // 124 Nue
            { 125, new InnateSkill(383, 15, "必殺の調べ", "戦闘メンバーにいる間、\n味方全体のクリティカルダメージが\n10%増加する。")}, // 125 Bicorn
            { 126, new InnateSkill(383, 15, "伝染する呪い", "戦闘メンバーにいる間、\n味方の状態異常付与率が20%上昇。")}, // 126 Zhen
            { 127, new InnateSkill(383, 15, "エッセンスシーフ", "HP/MPを吸収する攻撃を行った際、\n与えたダメージの100%分を回復する。")}, // 127 Vetala
            { 128, new InnateSkill(383, 15, "死に至る病", "戦闘メンバーにいる間、\n状態異常の敵に対して全味方の命中率\nとクリティカル率が20%上昇する。")}, // 128 Legion
            { 129, new InnateSkill(383, 15, "死に至る病", "戦闘メンバーにいる間、\n状態異常の敵に対して全味方の命中率\nとクリティカル率が20%上昇する。")}, // 129 Yaka
            { 130, new InnateSkill(383, 00, "物理のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、コロンゾンの物理適正\nが上昇する。")}, // 130 Choronzon
            { 131, new InnateSkill(383, 15, "集中攻撃", "直前の味方と同じ敵単体を狙う際、\n命中率とクリティカル率が20%上昇。")}, // 131 Preta
            { 132, new InnateSkill(383, 07, "呪殺の増幅", "戦闘メンバーにいる間、味方の\n呪殺適正がシャドウより低い場合、\nシャドウの数値まで引き上げる。")}, // 132 Shadow
            { 133, new InnateSkill(383, 15, "伝染する呪い", "戦闘メンバーにいる間、\n味方の状態異常付与率が20%上昇。")}, // 133 Black Ooze
            { 134, new InnateSkill(383, 15, "エッセンスシーフ", "HP/MPを吸収する攻撃を行った際、\n与えたダメージの100%分を回復する。")}, // 134 Blob
            { 135, new InnateSkill(383, 15, "死に至る病", "戦闘メンバーにいる間、\n状態異常の敵に対して全味方の命中率\nとクリティカル率が20%上昇する。")}, // 135 Slime
            { 136, new InnateSkill(383, 15, "連なる厄災", "戦闘メンバーにいる間、\n状態異常にかかった敵に対し、\n味方全体の与ダメージが20%増加する。")}, // 136 Mou-Ryo
            { 137, new InnateSkill(383, 15, "エッセンスシーフ", "HP/MPを吸収する攻撃を行った際、\n与えたダメージの100%分を回復する。")}, // 137 Will o' Wisp
            { 138, new InnateSkill(383, 14, "報復の熱意", "味方の天使または大天使が悪魔が死亡\nした時、ミカエルの物理/魔法攻撃力を\n最大まで高める。")}, // 138 Michael
            { 139, new InnateSkill(383, 14, "報復の熱意", "味方の天使または大天使が悪魔が死亡\nした時、ガブリエルの物理/魔法攻撃力を\n最大まで高める。")}, // 139 Gabriel
            { 140, new InnateSkill(383, 14, "報復の熱意", "味方の天使または大天使が悪魔が死亡\nした時、ラファエルの物理/魔法攻撃力を\n最大まで高める。")}, // 140 Raphael
            { 141, new InnateSkill(383, 14, "報復の熱意", "味方の天使または大天使が悪魔が死亡\nした時、ウリエルの物理/魔法攻撃力を\n最大まで高める。")}, // 141 Uriel
            { 142, new InnateSkill(383, 14, "良き助言者", "戦闘メンバーにいる間、\nすべての味方の補助スキル消費\nが20%減少する。")}, // 142 Ganesha
            { 143, new InnateSkill(383, 15, "水先案内", "ヴァルキリーが行動した時、\n次の行動順の味方が攻撃を行う場合、\n命中率が30%上昇する。")}, // 143 Valkyrie
            { 144, new InnateSkill(383, 14, "客人歓待", "ストックから味方を召喚した際、\nアラハバキにかかっているチャージ以外の\n補助効果が交代した味方に引き継がれる。")}, // 144 Arahabaki
            { 145, new InnateSkill(383, 13, "厄除けのお守り", "戦闘メンバーにいる間、\n全味方の状態異常からの\n回復確率が上昇する。")}, // 145 Kurama Tengu
            { 146, new InnateSkill(383, 15, "ラーマーヤナ", "『物理のノウハウ』＆ハヌマーン\nが単体の味方を回復した後、\nその味方の状態異常を解除する。")}, // 146 Hanuman
            { 147, new InnateSkill(383, 15, "代役猛犬", "戦闘メンバーにいる間、神獣・聖獣・\n魔獣・妖獣の味方のクリティカルダメージ\nを30%増加させる。")}, // 147 Cu Chulainn
            { 148, new InnateSkill(383, 15, "七宿連星神", "戦闘メンバーにいる間、『七宿連星神』を持\nつ、他の味方のスキル適正がセイリュウより\n低い場合、セイリュウの適正数値まで上昇する。")}, // 148 Qing Long
            { 149, new InnateSkill(383, 15, "七宿連星神", "戦闘メンバーにいる間、『七宿連星神』を持\nつ、他の味方のスキル適正がゲンブより\n低い場合、ゲンブの適正数値まで上昇する。")}, // 149 Xuanwu
            { 150, new InnateSkill(383, 03, "討滅の雷爪", "戦闘メンバーにいる間、\n味方全体の電撃属性攻撃がクリティカル\n可能になる。(基本発生率10%)")}, // 150 Barong
            { 151, new InnateSkill(383, 15, "忠犬", "マカミが弱点を突いた後、\n次の行動順の味方が攻撃を\n行うとダメージが20%増加する。")}, // 151 Makami
            { 152, new InnateSkill(383, 04, "衝撃の増幅", "戦闘メンバーにいる間、味方の\n衝撃適正がガルーダより低い場合、\nガルーダの数値まで引き上げる。")}, // 152 Garuda
            { 153, new InnateSkill(383, 15, "水先案内", "ヤタガラスが行動した時、\n次の行動順の味方が攻撃を行う場合、\n命中率が30%上昇する。")}, // 153 Yatagarasu
            { 154, new InnateSkill(383, 04, "旋風の調べ", "戦闘メンバーにいる間、\n弱点を突いた際の味方の\n衝撃ダメージが10%増加する。")}, // 154 Gurulu
            { 155, new InnateSkill(383, 15, "ミルトン", "アクティブパーティにいるゾアの\n種類に応じて、アルビオンは属性攻撃から\nのダメージを無効化する。")}, // 155 Albion
            { 156, new InnateSkill(383, 15, "生来のスキルなし", "")}, // 156 Manikin
            { 157, new InnateSkill(383, 15, "生来のスキルなし", "")}, // 157 Manikin
            { 158, new InnateSkill(383, 15, "生来のスキルなし", "")}, // 158 Manikin
            { 159, new InnateSkill(383, 15, "生来のスキルなし", "")}, // 159 Manikin
            { 160, new InnateSkill(383, 15, "生来のスキルなし", "")}, // 160 Manikin
            { 161, new InnateSkill(383, 15, "神性侵蝕", "状態異常にかかっている対象への\nサマエルの攻撃が貫通(貫通性能)\nを得る。")}, // 161 Samael
            { 162, new InnateSkill(383, 15, "生来のスキルなし", "")}, // 162 Manikin
            { 163, new InnateSkill(383, 15, "生来のスキルなし", "")}, // 163 Manikin
            { 164, new InnateSkill(383, 15, "生来のスキルなし", "")}, // 164 Manikin
            { 165, new InnateSkill(383, 15, "生来のスキルなし", "")}, // 165 Manikin
            { 166, new InnateSkill(383, 15, "生来のスキルなし", "")}, // 166 Manikin
            { 167, new InnateSkill(353, 15, "宝探し", "戦闘メンバーにいる間、\nボルテクス界のフィールド上\nで時折アイテムを発見する。")}, // 167 Pisaca
            { 168, new InnateSkill(383, 07, "漆黒の流星", "戦闘メンバーにいる間、\n味方全体の衝呪殺性攻撃がクリティカル\n可能になる。(基本発生率10%)")}, // 168 Kaiwan
            { 169, new InnateSkill(383, 15, "四鬼", "バトル参加中の『四鬼』1体につき、\nキンキのチャージ攻撃・クリティカ\nルダメージが10%増加する。")}, // 169 Kin-Ki
            { 170, new InnateSkill(383, 15, "四鬼", "バトル参加中の『四鬼』1体につき、\nスイキのチャージ攻撃・クリティカ\nルダメージが10%増加する。")}, // 170 Sui-Ki
            { 171, new InnateSkill(383, 15, "四鬼", "バトル参加中の『四鬼』1体につき、\nフウキのチャージ攻撃・クリティカ\nルダメージが10%増加する。")}, // 171 Fuu-Ki
            { 172, new InnateSkill(383, 15, "四鬼", "バトル参加中の『四鬼』1体につき、\nオンギョウキのチャージ攻撃・クリティカ\nルダメージが10%増加する。")}, // 172 Ongyo-Ki
            { 173, new InnateSkill(383, 15, "モイラの紡ぎ車", "バトル参加中にモイライ三姉妹が全員揃って\nいる時、味方全体のスキル消費\nコストが20%軽減される。")}, // 173 Clotho
            { 174, new InnateSkill(383, 15, "モイラの糸", "バトル参加中にモイライ三姉妹が全員揃って\nいる時、味方のカジャ系スキルの\nステータス上昇量が1段階増加する。")}, // 174 Lachesis
            { 175, new InnateSkill(383, 15, "モイラのハサミ", "バトル参加中にモイライ三姉妹が全員揃って\nいる時、味方全体の与ダメー\nジが10%増加する。")}, // 175 Atropos
            { 176, new InnateSkill(383, 15, "禁じられた言葉", "戦闘メンバーにいる間、\n味方および敵全体の状態異常\n付与率が2倍になる。")}, // 176 Loa
            { 177, new InnateSkill(383, 07, "呪殺の増幅", "戦闘メンバーにいる間、味方の\n呪殺適正がラフィン・スカルより低い場合、\nラフィン・スカルの数値まで引き上げる。")}, // 177 Chatterskull
            { 178, new InnateSkill(383, 15, "伝染する呪い", "戦闘メンバーにいる間、\n味方の状態異常付与率が20%上昇。")}, // 178 Phantom
            { 179, new InnateSkill(383, 15, "にゃん2ブロー", "『にゃん2ブロー』を持つ味方が2体以上い\nる場合、オセ・ハレルのクリティカル\nダメージが30%増加する。")}, // 179 Ose Hallel
            { 180, new InnateSkill(383, 15, "にゃん2ブロー", "『にゃん2ブロー』を持つ味方が2体以上い\nる場合、フラロウス・ハレルのクリティカル\nダメージが30%増加する。")}, // 180 Flauros Hallel
            { 181, new InnateSkill(383, 03, "稲妻の調べ", "戦闘メンバーにいる間、\n弱点を突いた際の味方の\n電撃ダメージが10%増加する。")}, // 181 Urthona
            { 182, new InnateSkill(383, 01, "烈火の調べ", "戦闘メンバーにいる間、\n弱点を突いた際の味方の\n火炎ダメージが10%増加する。")}, // 182 Urizen
            { 183, new InnateSkill(383, 04, "旋風の調べ", "戦闘メンバーにいる間、\n弱点を突いた際の味方の\n衝撃ダメージが10%増加する。")}, // 183 Luvah
            { 184, new InnateSkill(383, 02, "凍空の調べ", "戦闘メンバーにいる間、\n弱点を突いた際の味方の\n氷結ダメージが10%増加する。")}, // 184 Tharmus
            { 185, new InnateSkill(383, 15, "幻影劇", "スペクターの攻撃(魔法を含む)は、\n自分より魔力が低い対象に対して\nクリティカル率が10%上昇する。")}, // 185 Specter
            { 186, new InnateSkill(383, 15, "無尽蔵の欲求", "マーラの物理攻撃力が最大\nまで高まっている場合、力依存の\n攻撃が常にクリティカルになる。")}, // 186 Mara
            { 187, new InnateSkill(383, 15, "", "")}, // 187 
            { 188, new InnateSkill(383, 15, "", "")}, // 188 
            { 189, new InnateSkill(383, 15, "", "")}, // 189 
            { 190, new InnateSkill(383, 15, "", "")}, // 190 
            { 191, new InnateSkill(383, 15, "", "")}, // 191 
            { 192, new InnateSkill(383, 15, "Raidou/Dante", "")}, // 192 Raidou/Dante
            { 193, new InnateSkill(383, 05, "万能のノウハウ", "戦闘メンバーにいる味方のプラス適正の\n合計値に応じて、メタトロンの万能適正\nが上昇する。")}, // 193 Metatron
            { 194, new InnateSkill(383, 05, "万能の増幅", "戦闘メンバーにいる間、味方の\n万能適正がフレイミーズより低い場合、\nベルゼブブの数値まで引き上げる。")}, // 194 Beelzebub (Fly)
            { 195, new InnateSkill(383, 14, "黙示の四騎士", "他の『黙示の四騎士』の悪魔に交代する際、\nペイルライダーにかかっていたすべての\n補助効果が交代先の味方に引き継がれる。")}, // 195 Pale Rider
            { 196, new InnateSkill(383, 14, "黙示の四騎士", "他の『黙示の四騎士』の悪魔に交代する際、\nホワイトライダーにかかっていたすべての\n補助効果が交代先の味方に引き継がれる。")}, // 196 White Rider
            { 197, new InnateSkill(383, 14, "黙示の四騎士", "他の『黙示の四騎士』の悪魔に交代する際、\nレッドライダーにかかっていたすべての\n補助効果が交代先の味方に引き継がれる。")}, // 197 Red Rider
            { 198, new InnateSkill(383, 14, "黙示の四騎士", "他の『黙示の四騎士』の悪魔に交代する際、\nブラックライダーにかかっていたすべての\n補助効果が交代先の味方に引き継がれる。")}, // 198 Black Rider
            { 199, new InnateSkill(383, 00, "エストカーダ", "攻撃を回避または無効化した際、\n低い威力の反撃を行うことがある。\n威力: 32")}, // 199 Matador
            { 200, new InnateSkill(383, 15, "スピードスター", "ヘルズエンジェルの攻撃(魔法を含む)は、\n自分より速さが低い対象に対して\nクリティカル率が10%上昇する。")}, // 200 Hell Biker
            { 201, new InnateSkill(383, 13, "導きの叡智", "戦闘メンバーにいる時、\nストックから召喚された味方の\n状態異常を解除する。")}, // 201 Daisoujou
            { 202, new InnateSkill(383, 15, "甘やかし", "マザーハーロットのプラス適性を持つ攻撃\nは、状態異常の対象に対してミスしなく\nなる。")}, // 202 Mother Harlot
            { 203, new InnateSkill(383, 15, "最後の秒読み", "トランペッターのターンが8の\n倍数毎に来る際、そのターンの\nスキルの消費が0になる。")}, // 203 Trumpeter
            { 204, new InnateSkill(383, 15, "判官贔屓", "減少しているHPに応じて、\nフトミミのダメージが最大\n30%増加する。")}, // 204 Futomimi
            { 205, new InnateSkill(383, 15, "権力への必死", "減少しているMPに応じて、\nサカハギのダメージが最大\n30%増加する。")}, // 205 Sakahagi
            { 206, new InnateSkill(383, 02, "大冷界", "ブラックフロストの氷結攻撃は、\n凍結付与の代わりに即死効果を\n与えることがある。")}, // 206 Black Frost
            { 207, new InnateSkill(383, 05, "万能の増幅", "戦闘メンバーにいる間、味方の\n万能適正がフレイミーズより低い場合、\nベルゼブブの数値まで引き上げる。")}, // 207 Beelzebub (Man)
            { 208, new InnateSkill(383, 15, "", "")}, // 208 
            { 209, new InnateSkill(383, 15, "", "")}, // 209 
            { 210, new InnateSkill(383, 15, "", "")}, // 210 
            { 211, new InnateSkill(383, 15, "", "")}, // 211 
            { 212, new InnateSkill(383, 15, "", "")}, // 212 
            { 213, new InnateSkill(383, 15, "", "")}, // 213 
            { 214, new InnateSkill(383, 15, "", "")}, // 214 
            { 215, new InnateSkill(383, 15, "", "")}, // 215 
            { 216, new InnateSkill(383, 15, "", "")}, // 216 
            { 217, new InnateSkill(383, 15, "", "")}, // 217 
            { 218, new InnateSkill(383, 15, "", "")}, // 218 
            { 219, new InnateSkill(383, 15, "", "")}, // 219 
            { 220, new InnateSkill(383, 15, "", "")}, // 220 
            { 221, new InnateSkill(383, 15, "", "")}, // 221 
            { 222, new InnateSkill(383, 15, "", "")}, // 222 
            { 223, new InnateSkill(383, 15, "", "")}, // 223 
            { 224, new InnateSkill(383, 06, "断罪の調べ", "戦闘メンバーにいる間、\n弱点を突いた際の味方の\n破魔ダメージが10%増加する。")}, // 224 Tam Lin
            { 225, new InnateSkill(383, 15, "邪悪な鏡", "人修羅が使用した単体対象\nスキルを、威力を下げて\nコピーする。")}, // 225 Doppelganger
            { 226, new InnateSkill(383, 15, "連なる厄災", "戦闘メンバーにいる間、\n状態異常にかかった敵に対し、\n味方全体の与ダメージが20%増加する。")}, // 226 Nightmare
            { 227, new InnateSkill(383, 15, "にゃん2ブロー", "『にゃん2ブロー』を持つ味方が2体以上い\nる場合、ドゥンのクリティカル\nダメージが30%増加する。")}, // 227 Gdon
            { 228, new InnateSkill(383, 03, "電撃の増幅", "戦闘メンバーにいる間、味方の\n電撃適正がヴリトラより低い場合、\nヴリトラの数値まで引き上げる。")}, // 228 Vritra
            { 229, new InnateSkill(383, 15, "マガタマコピー", "現在装着している\nマガタマに応じて\nスキル適性を得る。")}, // 229 Demee-Ho
            { 230, new InnateSkill(383, 15, "強欲な怒り", "セトの攻撃（魔法を含む）は、\n自分よりステータスが高い項目を持つ対象に対して\nクリティカル率が10%上昇する。")}, // 230 Seth
            { 231, new InnateSkill(383, 15, "", "")}, // 231 
            { 232, new InnateSkill(383, 15, "", "")}, // 232 
            { 233, new InnateSkill(383, 15, "", "")}, // 233 
            { 234, new InnateSkill(383, 15, "", "")}, // 234 
            { 235, new InnateSkill(383, 15, "", "")}, // 235 
            { 236, new InnateSkill(383, 15, "", "")}, // 236 
            { 237, new InnateSkill(383, 15, "", "")}, // 237 
            { 238, new InnateSkill(383, 15, "", "")}, // 238 
            { 239, new InnateSkill(383, 15, "", "")}, // 239 
            { 240, new InnateSkill(383, 15, "", "")}, // 240 
            { 241, new InnateSkill(383, 15, "", "")}, // 241 
            { 242, new InnateSkill(383, 15, "", "")}, // 242 
            { 243, new InnateSkill(383, 15, "連なる厄災", "")}, // 243 Boss Pazuzu
            { 244, new InnateSkill(383, 15, "静寂の轟き", "")}, // 244 Triple Reason Ahriman
            { 245, new InnateSkill(383, 15, "弱さを非難する", "")}, // 245 Triple Reason Baal Avatar
            { 246, new InnateSkill(383, 15, "夜のオーロラ", "")}, // 246 Triple Reason Noah
            { 247, new InnateSkill(383, 15, "", "")}, // 247 
            { 248, new InnateSkill(383, 15, "強欲な怒り", "")}, // Boss Seth
            { 249, new InnateSkill(383, 15, "反射する巨象", "")}, // 249 Sarge Girimekhala
            { 250, new InnateSkill(383, 15, "潜在能力", "")}, // 250 NKE Pixie
            { 251, new InnateSkill(383, 02, "氷結の増幅", "")}, // 251 NKE Jack Frost
            { 252, new InnateSkill(383, 15, "魔人の自動回復", "")}, // 252 Devil Dante
            { 253, new InnateSkill(383, 15, "執行猶予", "")}, // 253 Gamete
            { 254, new InnateSkill(383, 15, "抵抗してはならない", "")}, // 254 YHVH
            { 255, new InnateSkill(383, 15, "", "")}, // 255 
            { 256, new InnateSkill(383, 15, "ベストフレンド", "")}, // 256 Boss Forneus
            { 257, new InnateSkill(383, 15, "幻影劇", "")}, // 257 Boss Specter 1 (Mini)
            { 258, new InnateSkill(383, 05, "静寂の轟き", "")}, // 258 Boss Ahriman 2
            { 259, new InnateSkill(383, 15, "夜のオーロラ", "")}, // 259 Boss Noah 2
            { 260, new InnateSkill(383, 15, "真宵の調べ", "")}, // 260 Forced Incubus
            { 261, new InnateSkill(383, 15, "衝撃のノウハウ", "")}, // 261 Forced Koppa Tengu
            { 262, new InnateSkill(383, 07, "漆黒の流星", "")}, // 262 Forced Kaiwan
            { 263, new InnateSkill(383, 15, "にゃん2ブロー", "")}, // 263 Boss Ose
            { 264, new InnateSkill(383, 15, "永遠の光", "")}, // 264 Boss Kagutsuchi 2
            { 265, new InnateSkill(383, 15, "凍空の調べ", "")}, // 265 Ambush Mizuchi
            { 266, new InnateSkill(383, 15, "四鬼", "")}, // 169 Boss Kin-Ki
            { 267, new InnateSkill(383, 15, "四鬼", "")}, // 170 Boss Sui-Ki
            { 268, new InnateSkill(383, 15, "四鬼", "")}, // 171 Boss Fuu-Ki
            { 269, new InnateSkill(383, 15, "四鬼", "")}, // 172 Boss Ongyo-Ki
            { 270, new InnateSkill(383, 15, "モイラの紡ぎ車", "")}, // 270 Boss Clotho (Solo)
            { 271, new InnateSkill(383, 15, "モイラの糸", "")}, // 271 Boss Lachesis (Solo)
            { 272, new InnateSkill(383, 15, "モイラのハサミ", "")}, // 272 Boss Atropos (Solo)
            { 273, new InnateSkill(383, 15, "幻影劇", "")}, // 273 Boss Specter 2
            { 274, new InnateSkill(383, 15, "反射する巨象", "")}, // 274 Boss Girimekhala
            { 275, new InnateSkill(383, 15, "幻影劇", "")}, // 275 Boss Specter 3
            { 276, new InnateSkill(383, 15, "執行猶予", "")}, // 276 Boss Alciel
            { 277, new InnateSkill(383, 02, "冬の女王", "")}, // 277 Boss Skadi
            { 278, new InnateSkill(383, 15, "ミルトン", "")}, // 278 Boss Albion
            { 279, new InnateSkill(383, 03, "稲妻の調べ", "")}, // 279 Boss Urthona
            { 280, new InnateSkill(383, 01, "烈火の調べ", "")}, // 280 Boss Urizen
            { 281, new InnateSkill(383, 04, "旋風の調べ", "")}, // 281 Boss Luvah
            { 282, new InnateSkill(383, 02, "凍空の調べ", "")}, // 282 Boss Tharmus
            { 283, new InnateSkill(383, 15, "判官贔屓", "")}, // 283 Boss Futomimi
            { 284, new InnateSkill(383, 14, "報復の熱意", "")}, // 284 Boss Gabriel
            { 285, new InnateSkill(383, 14, "報復の熱意", "")}, // 285 Boss Raphael
            { 286, new InnateSkill(383, 14, "報復の熱意", "")}, // 286 Boss Uriel
            { 287, new InnateSkill(383, 15, "神性侵蝕", "")}, // 287 Boss Samael
            { 288, new InnateSkill(383, 15, "弱さを非難する", "")}, // 288 Boss Baal Avatar
            { 289, new InnateSkill(383, 15, "にゃん2ブロー", "")}, // 289 Boss Ose Hallel
            { 290, new InnateSkill(383, 15, "にゃん2ブロー", "")}, // 290 Boss Flauros Hallel
            { 291, new InnateSkill(383, 05, "地獄の代償", "")}, // 291 Boss Ahriman 1
            { 292, new InnateSkill(383, 15, "夜のオーロラ", "")}, // 292 Boss Noah 1
            { 293, new InnateSkill(383, 15, "脈動する光", "")}, // 293 Boss Kagutsuchi 1
            { 294, new InnateSkill(383, 15, "幻影劇", "")}, // 294 Boss Specter 1 (Merged 6)
            { 295, new InnateSkill(383, 15, "幻影劇", "")}, // 295 Boss Specter 1 (Merged 4-5)
            { 296, new InnateSkill(383, 15, "幻影劇", "")}, // 296 Boss Specter 1 (Merged 2-3)
            { 297, new InnateSkill(383, 15, "凍空の調べ", "")}, // 297 Boss Mizuchi
            { 298, new InnateSkill(383, 14, "報復の熱意", "")}, // 298 Boss Michael
            { 299, new InnateSkill(383, 15, "権力への必死", "")}, // 299 Boss Sakahagi
            { 300, new InnateSkill(383, 15, "忠犬", "")}, // 300 Boss Orthrus
            { 301, new InnateSkill(383, 15, "必殺の調べ", "")}, // 301 Boss Yaksini
            { 302, new InnateSkill(383, 03, "オーディンの息子", "")}, // 302 Boss Thor
            { 303, new InnateSkill(383, 02, "大冷界", "")}, // 303 Boss Black Frost
            { 304, new InnateSkill(383, 15, "忠犬", "")}, // 304 Boss Cerberus R
            { 305, new InnateSkill(383, 15, "忠犬", "")}, // 305 Boss Cerberus C
            { 306, new InnateSkill(383, 15, "忠犬", "")}, // 306 Boss Cerberus L
            { 307, new InnateSkill(383, 15, "水先案内", "")}, // 307 Boss Eligor
            { 308, new InnateSkill(383, 15, "水先案内", "")}, // 308 Boss Eligor
            { 309, new InnateSkill(383, 15, "水先案内", "")}, // 309 Boss Eligor
            { 310, new InnateSkill(383, 15, "執り成し", "")}, // 310 Ambush Kelpie
            { 311, new InnateSkill(383, 15, "執り成し", "")}, // 311 Ambush Kelpie
            { 312, new InnateSkill(383, 01, "火炎のノウハウ", "")}, // 312 Boss Berith
            { 313, new InnateSkill(383, 15, "惹き付ける", "")}, // 313 Boss Succubus
            { 314, new InnateSkill(383, 15, "宝探し", "")}, // 314 Ambush High Pixie
            { 315, new InnateSkill(383, 07, "漆黒の流星", "")}, // 315 Boss Kaiwan
            { 316, new InnateSkill(383, 15, "にゃん2ブロー", "")}, // 316 Forced Nekomata
            { 317, new InnateSkill(383, 02, "氷結のノウハウ", "")}, // 317 Boss Troll
            { 318, new InnateSkill(383, 15, "Forced Will o' Wisp", "")}, // 318 Forced Will o' Wisp
            { 319, new InnateSkill(383, 15, "集中攻撃", "")}, // 319 Forced Preta
            { 320, new InnateSkill(383, 14, "四天王", "")}, // 320 Boss Bishamonten 1
            { 321, new InnateSkill(383, 15, "無尽蔵の欲求", "")}, // 321 Boss Mara
            { 322, new InnateSkill(383, 14, "四天王", "")}, // 322 Boss Bishamonten 2
            { 323, new InnateSkill(383, 14, "四天王", "")}, // 323 Boss Jikokuten
            { 324, new InnateSkill(383, 14, "四天王", "")}, // 324 Boss Koumokuten
            { 325, new InnateSkill(383, 14, "四天王", "")}, // 325 Boss Zouchouten
            { 326, new InnateSkill(383, 15, "モイラの紡ぎ車", "")}, // 326 Boss Clotho (Together)
            { 327, new InnateSkill(383, 15, "モイラの糸", "")}, // 327 Boss Lachesis (Together)
            { 328, new InnateSkill(383, 15, "モイラのハサミ", "")}, // 328 Boss Atropos (Together)
            { 329, new InnateSkill(383, 14, "正義の誓い", "")}, // 329 Boss Mitra
            { 330, new InnateSkill(383, 15, "", "")}, // 330 
            { 331, new InnateSkill(383, 15, "", "")}, // 331 
            { 332, new InnateSkill(383, 15, "", "")}, // 332 
            { 333, new InnateSkill(383, 15, "酒の宴", "")}, // 333 Boss Mada
            { 334, new InnateSkill(383, 15, "メガロマニア", "")}, // 334 Boss Mot
            { 335, new InnateSkill(383, 01, "レーヴァテイン", "")}, // 335 Boss Surt
            { 336, new InnateSkill(383, 15, "Puzzle Boy", "")}, // 336 Puzzle Boy
            { 337, new InnateSkill(383, 03, "オーディンの息子", "")}, // 337 Boss Thor 2
            { 338, new InnateSkill(383, 15, "", "")}, // 338 
            { 339, new InnateSkill(383, 15, "Boss Raidou/Dante 1", "")}, // 339 Boss Raidou/Dante 1
            { 340, new InnateSkill(383, 15, "Chase Raidou/Dante", "")}, // 340 Chase Raidou/Dante
            { 341, new InnateSkill(383, 15, "Boss Raidou/Dante 2", "")}, // 341 Boss Raidou/Dante 2
            { 342, new InnateSkill(383, 05, "万能のノウハウ", "")}, // 342 Boss Metatron
            { 343, new InnateSkill(383, 05, "万能の増幅", "")}, // 343 Boss Beelzebub
            { 344, new InnateSkill(383, 15, "終焉の夜明け", "")}, // 344 Boss Lucifer
            { 345, new InnateSkill(383, 15, "黙示の四騎士", "")}, // 345 Boss Pale Rider
            { 346, new InnateSkill(383, 15, "黙示の四騎士", "")}, // 346 Boss White Rider
            { 347, new InnateSkill(383, 15, "黙示の四騎士", "")}, // 347 Boss Red Rider
            { 348, new InnateSkill(383, 15, "黙示の四騎士", "")}, // 348 Boss Black Rider
            { 349, new InnateSkill(383, 00, "エストカーダ", "")}, // 349 Boss Matador
            { 350, new InnateSkill(383, 15, "スピードスター", "")}, // 350 Boss Hell Biker
            { 351, new InnateSkill(383, 13, "導きの叡智", "")}, // 351 Boss Daisoujou
            { 352, new InnateSkill(383, 15, "甘やかし", "")}, // 352 Boss Mother Harlot
            { 353, new InnateSkill(383, 15, "最後の秒読み", "")}, // 353 Boss Trumpeter
            { 354, new InnateSkill(383, 15, "", "")}, // 354 
            { 355, new InnateSkill(383, 15, "", "")}, // 355 
            { 356, new InnateSkill(383, 15, "生来のスキルなし", "")}, // 356 Nasu Fly
            { 357, new InnateSkill(383, 15, "", "")}, // 357 
            { 358, new InnateSkill(383, 15, "禁じられた言葉", "")}, // 358 Boss Loa
            { 359, new InnateSkill(383, 15, "引き止め", "")}, // 359 Boss Virtue
            { 360, new InnateSkill(383, 15, "破魔のノウハウ", "")}, // 360 Boss Power
            { 361, new InnateSkill(383, 15, "死に至る病", "")}, // 361 Boss Legion
            { 362, new InnateSkill(383, 15, "にゃん2ブロー", "")}, // 362 Boss Flauros
            { 363, new InnateSkill(383, 06, "断罪の調べ", "")}, // 363 Raidou Tam Lin
            { 364, new InnateSkill(383, 15, "にゃん2ブロー", "")}, // 364 Raidou Gdon
            { 365, new InnateSkill(383, 03, "電撃の増幅", "")}, // 365 Raidou Vritra
            { 366, new InnateSkill(383, 02, "氷結の増幅", "")}, // 366 Raidou Jack Frost
            { 367, new InnateSkill(383, 15, "", "")}, // 367 
            { 368, new InnateSkill(383, 15, "", "")}, // 368 
            { 369, new InnateSkill(383, 15, "", "")}, // 369 
            { 370, new InnateSkill(383, 15, "", "")}, // 370 
            { 371, new InnateSkill(383, 15, "", "")}, // 371 
            { 372, new InnateSkill(383, 15, "", "")}, // 372 
            { 373, new InnateSkill(383, 15, "", "")}, // 373 
            { 374, new InnateSkill(383, 15, "", "")}, // 374 
            { 375, new InnateSkill(383, 15, "", "")}, // 375 
            { 376, new InnateSkill(383, 15, "", "")}, // 376 
            { 377, new InnateSkill(383, 15, "", "")}, // 377 
            { 378, new InnateSkill(383, 15, "", "")}, // 378 
            { 379, new InnateSkill(383, 15, "", "")}, // 379 
            { 380, new InnateSkill(383, 15, "", "")}, // 380 
            { 381, new InnateSkill(383, 15, "", "")}, // 381 
            { 382, new InnateSkill(383, 15, "", "")}, // 382 
            { 383, new InnateSkill(383, 15, "", "")}  // 383 
        };

        private static Dictionary<ushort, InnateSkill> magatamaInnateSkills = new Dictionary<ushort, InnateSkill>
        {
            { 00, new InnateSkill(383, 15, "", "")}, // 00
            { 01, new InnateSkill(383, 15, "Focused Assault", "Gain 20% Hit Rate and \nCritical Rate when targetting the \nsame single foe as the previous ally.")}, // 01 Marogareh
            { 02, new InnateSkill(383, 02, "Ice Gestalt", "Gain Ice skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 02 Wadatsumi
            { 03, new InnateSkill(383, 13, "Restorative Melody", "Healing skill costs are reduced \nby 20% for all allies.")}, // 03 Ankh
            { 04, new InnateSkill(383, 14, "Divine Benevolence", "Support skill costs are reduced \nby 20% for all allies.")}, // 04 Iyomante
            { 05, new InnateSkill(383, 01, "Fire Gestalt", "Gain Fire skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 05 Shiranui
            { 06, new InnateSkill(383, 04, "Force Gestalt", "Gain Force skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 06 Hifumi
            { 07, new InnateSkill(383, 00, "Phys Gestalt", "Gain Phys skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 07 Kamurogi
            { 08, new InnateSkill(383, 03, "Elec Gestalt", "Gain Elec skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 08 Kamudo
            { 09, new InnateSkill(383, 07, "Dark Gestalt", "Gain Dark skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 09 Anathema
            { 10, new InnateSkill(383, 15, "Contagious Curse", "Allies' Ailment Rate is \nincreased by 20%.")}, // 10 Miasma
            { 11, new InnateSkill(383, 06, "Light Gestalt", "Gain Light skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 11 Nirvana
            { 12, new InnateSkill(383, 12, "Shot Gestalt", "Gain Shot skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 12 Vimana
            { 13, new InnateSkill(383, 02, "Storm Shatter", "Allied Elec and Force attacks \nwill Critically Strike and gain \nPierce against frozen enemies.")}, // 13 Geis
            { 14, new InnateSkill(383, 15, "Destabilize", "Element attacks may Critically Strike \nfor all allies and enemies.")}, // 14 Djed
            { 15, new InnateSkill(383, 01, "Malevolent Flames", "All allies' Fire attacks \nmay Critically Strike. \n(10% base rate)")}, // 15 Muspell
            { 16, new InnateSkill(383, 05, "Forbidden Fruit", "Allies' Almighty attacks \nmay Critically Strike. \n(10% base rate)")}, // 16 Satan
            { 17, new InnateSkill(383, 15, "Magnified Malady", "All allies deal 20% more damage \nagainst enemies with an ailment.")}, // 17 Adama
            { 18, new InnateSkill(383, 07, "Dark Opus", "If the entire active party has natural \npositive Dark potential, gain a flashing \nturn icon at the start of each turn.")}, // 18 Gehenna
            { 19, new InnateSkill(383, 15, "Withheld Sentence", "Allies are immune to \nrandom instakills.")}, // 19 Sophia
            { 20, new InnateSkill(383, 04, "Orochi's Bane", "Your Force attacks may \ninflict poison. \n(30% base rate)")}, // 20 Murakumo
            { 21, new InnateSkill(383, 06, "Light Opus", "If the entire active party has natural \npositive Light potential, gain a flashing \nturn icon at the start of each turn.")}, // 21 Gundari
            { 22, new InnateSkill(383, 03, "Vanquishing Bolts", "All allies' Elec attacks \nmay Critically Strike. \n(10% base rate)")}, // 22 Narukami
            { 23, new InnateSkill(383, 14, "Megalomania", "After an ally uses a charge effect, \nthey gain a 20% chance to retain it.")}, // 23 Gaea
            { 24, new InnateSkill(383, 15, "Tripura Samhara", "Skill costs are reduced by 20% \nfor allies with a charge effect.")}, // 24 Kailash
            { 25, new InnateSkill(383, 15, "Ruler's Virtuosity", "Gain 5% increased Critical Damage \nfor each unique effect active on you.")} // 25 Masakados
        };

        private static Dictionary<ushort, InnateSkill> magatamaInnateSkillsJp = new Dictionary<ushort, InnateSkill>
        {
            { 00, new InnateSkill(383, 15, "", "")}, // 00
            { 01, new InnateSkill(383, 15, "集中攻撃", "直前の味方と同じ敵単体を狙う際、\n命中率とクリティカル率が20%上昇。")}, // 01 Marogareh
            { 02, new InnateSkill(383, 02, "氷結のノウハウ", "戦闘メンバーの味方のプラス適性の\n合計に基づき、氷結スキル適性を獲得。")}, // 02 Wadatsumi
            { 03, new InnateSkill(383, 13, "癒しの調べ", "味方全員の回復スキルのコスト\nが20%減少。")}, // 03 Ankh
            { 04, new InnateSkill(383, 14, "良き助言者", "味方全員の補助スキルのコスト\nが20%減少。")}, // 04 Iyomante
            { 05, new InnateSkill(383, 01, "火炎のノウハウ", "戦闘メンバーの味方のプラス適性の\n合計に基づき、火炎スキル適性を獲得。")}, // 05 Shiranui
            { 06, new InnateSkill(383, 04, "衝撃のノウハウ", "戦闘メンバーの味方のプラス適性の\n合計に基づき、衝撃スキル適性を獲得。")}, // 06 Hifumi
            { 07, new InnateSkill(383, 00, "物理のノウハウ", "戦闘メンバーの味方のプラス適性の\n合計に基づき、物理スキル適性を獲得。")}, // 07 Kamurogi
            { 08, new InnateSkill(383, 03, "電撃のノウハウ", "戦闘メンバーの味方のプラス適性の\n合計に基づき、電撃スキル適性を獲得。")}, // 08 Kamudo
            { 09, new InnateSkill(383, 07, "呪殺のノウハウ", "戦闘メンバーの味方のプラス適性の\n合計に基づき、呪殺スキル適性を獲得。")}, // 09 Anathema
            { 10, new InnateSkill(383, 15, "伝染する呪い", "味方の状態異常付与率が20%上昇。")}, // 10 Miasma
            { 11, new InnateSkill(383, 06, "破魔のノウハウ", "戦闘メンバーの味方のプラス適性の\n合計に基づき、破魔スキル適性を獲得。")}, // 11 Nirvana
            { 12, new InnateSkill(383, 12, "銃撃のノウハウ", "戦闘メンバーの味方のプラス適性の\n合計に基づき、銃撃スキル適性を獲得。")}, // 12 Vimana
            { 13, new InnateSkill(383, 02, "嵐の粉砕", "味方の電撃および衝撃攻撃が、\n凍結状態の敵に対してクリティカルとなり、\n貫通を得る。")}, // 13 Geis
            { 14, new InnateSkill(383, 15, "混迷化", "属性攻撃が、すべての味方および敵において\n確率でクリティカルになる。")}, // 14 Djed
            { 15, new InnateSkill(383, 01, "邪悪なる炎", "味方全体の火炎属性攻撃がクリティカル\n可能になる。(基本発生率10%)")}, // 15 Muspell
            { 16, new InnateSkill(383, 05, "禁断の果実", "味方全体の万能属性攻撃がクリティカル\n可能になる。(基本発生率10%)")}, // 16 Satan
            { 17, new InnateSkill(383, 15, "連なる厄災", "状態異常にかかった敵に対し、\n味方全体の与ダメージが20%増加する。")}, // 17 Adama
            { 18, new InnateSkill(383, 07, "呪殺交響曲", "アクティブパーティ全員が本来呪殺のプラス\n適性を持っている場合、各ターンの開始時に\n点滅するプレスターンアイコンをつ獲得する。")}, // 18 Gehenna
            { 19, new InnateSkill(383, 15, "執行猶予", "味方全体は確率による即死攻撃を\n無効化する。")}, // 19 Sophia
            { 20, new InnateSkill(383, 04, "大蛇を屠る毒", "自身の衝撃攻撃で毒を付与することがある。\n(基本発生率30%)")}, // 20 Murakumo
            { 21, new InnateSkill(383, 06, "破魔交響曲", "アクティブパーティ全員が本来破魔のプラス\n適性を持っている場合、各ターンの開始時に\n点滅するプレスターンアイコンをつ獲得する。")}, // 21 Gundari
            { 22, new InnateSkill(383, 03, "討滅の雷爪", "味方全体の電撃属性攻撃がクリティカル\n可能になる。(基本発生率10%)")}, // 22 Narukami
            { 23, new InnateSkill(383, 14, "メガロマニア", "味方がチャージ効果を消費した後、\n20%の確率でその効果が維持される。")}, // 23 Gaea
            { 24, new InnateSkill(383, 15, "三都破壊", "チャージ効果状態の味方はスキル\n消費MPが20%減少する。")}, // 24 Kailash
            { 25, new InnateSkill(383, 15, "覇道の達人", "自身に付与されている固有効果つにつき、\nクリティカルダメージが5%増加する。")} // 25 Masakados
        };

        private static Dictionary<sbyte, List<ushort>> gestaltUsers = new Dictionary<sbyte, List<ushort>>
        {
            { 00, new List<ushort> { 16, 46, 130, 146 } }, // Phys
            { 01, new List<ushort> { 72, 91, 98 } }, // Fire
            { 02, new List<ushort> { 55, 75, 103 } }, // Ice
            { 03, new List<ushort> { 77, 79, 97 } }, // Elec
            { 04, new List<ushort> { 48, 52, 92, 121, 261 } }, // Force
            { 05, new List<ushort> { 193 } }, // Almighty
            { 06, new List<ushort> { 62, 65, 360 } }, // Light
            { 07, new List<ushort> { 108 } }, // Dark
            { 08, new List<ushort> { } }, // Curse (Not Used)
            { 09, new List<ushort> { } }, // Nerve (Not Used)
            { 10, new List<ushort> { } }, // Mind (Not Used)
            { 11, new List<ushort> { 193 } }, // Self-Destruct (Not Used)
            { 12, new List<ushort> { 90, 101 } }, // Shot
            { 13, new List<ushort> { } }, // Heal (Not Used)
            { 14, new List<ushort> { } }, // Support (Not Used)
            { 15, new List<ushort> { } } // Util (Not Used)
        };

        private static Dictionary<sbyte, byte> gestaltMagatama = new Dictionary<sbyte, byte>
        {
            { 00, 07 }, // Phys
            { 01, 05 }, // Fire
            { 02, 02 }, // Ice
            { 03, 08 }, // Elec
            { 04, 06 }, // Force
            { 05, 00 }, // Almighty (Not Used)
            { 06, 11 }, // Light
            { 07, 09 }, // Dark
            { 08, 00 }, // Curse (Not Used)
            { 09, 00 }, // Nerve (Not Used)
            { 10, 00 }, // Mind (Not Used)
            { 11, 00 }, // Self-Destruct (Not Used)
            { 12, 12 }, // Shot
            { 13, 00 }, // Heal (Not Used)
            { 14, 00 }, // Support (Not Used)
            { 15, 00 }  // Util (Not Used)
        };

        private static Dictionary<sbyte, List<ushort>> enhancerUsers = new Dictionary<sbyte, List<ushort>>
        {
            { 00, new List<ushort> { 88, 99, 119 } }, // Phys
            { 01, new List<ushort> { 36, 111, 335 } }, // Fire
            { 02, new List<ushort> { 17, 37, 60, 277 } }, // Ice
            { 03, new List<ushort> { 22, 39, 228, 302, 337 } }, // Elec
            { 04, new List<ushort> { 38, 83, 152 } }, // Force
            { 05, new List<ushort> { 194, 207, 343 } }, // Almighty
            { 06, new List<ushort> { 35, 63 } }, // Light
            { 07, new List<ushort> { 132, 177 } }, // Dark
            { 08, new List<ushort> {  } }, // Curse (Not Used)
            { 09, new List<ushort> {  } }, // Nerve (Not Used)
            { 10, new List<ushort> {  } }, // Mind (Not Used)
            { 11, new List<ushort> { 194, 207, 343 } }, // Self-Destruct (Not Used)
            { 12, new List<ushort> { 66, 95 } }, // Shot
            { 13, new List<ushort> {  } }, // Heal (Not Used)
            { 14, new List<ushort> {  } }, // Support (Not Used)
            { 15, new List<ushort> {  } }  // Util (Not Used)
        };

        private static Dictionary<sbyte, List<ushort>> melodyUsers = new Dictionary<sbyte, List<ushort>>
        {
            { 1, new List<ushort> { 58, 182, 280 } }, // Fire
            { 2, new List<ushort> { 78, 184, 265, 297, 282 } }, // Ice
            { 3, new List<ushort> { 123, 181, 279 } }, // Elec
            { 4, new List<ushort> { 84, 154, 183, 281 } }, // Force
            { 5, new List<ushort>() }, // Almighty (Not Used)
            { 6, new List<ushort> { 224 } }, // Light
            { 7, new List<ushort> { 118, 260 } } // Dark
        };

        private static Dictionary<sbyte, List<ushort>> critEnablerUsers = new Dictionary<sbyte, List<ushort>>
        {
            { 1, new List<ushort> { 44 } }, // Fire
            { 2, new List<ushort> { 76 } }, // Ice
            { 3, new List<ushort> { 150 } }, // Elec
            { 4, new List<ushort> { 9 } }, // Force
            { 5, new List<ushort> { 114 } }, // Almighty
            { 6, new List<ushort> { 3 } }, // Light
            { 7, new List<ushort> { 168, 262, 315 } } // Dark
        };

        private static Dictionary<int, List<ushort>> miltonIds = new Dictionary<int, List<ushort>>
        {
            { 1, new List<ushort> { 182, 280 } }, // Fire
            { 2, new List<ushort> { 184, 282 } }, // Ice
            { 3, new List<ushort> { 181, 279 } }, // Elec
            { 4, new List<ushort> { 183, 281 } }, // Force
        };

        private static Dictionary<ushort, List<int>> negoSkillScenarios = new Dictionary<ushort, List<int>>
        {
            { 409, new List<int> { 0 } }, // Haggle
            { 410, new List<int> { 1 } }, // Arbitration
            { 411, new List<int> { 2 } }, // Detain
            { 412, new List<int> { 3 } }, // Kinspeak
            { 413, new List<int> { 0 } }, // Persuade
            { 414, new List<int> { 0 } }, // Intimidate
            { 415, new List<int> { 0 } }, // Nag
            { 418, new List<int> { 1 } }, // Maiden Plea
            { 419, new List<int> { 0, 1, 2, 3 } }, // Wine Party
            { 420, new List<int> { 0 } } // Flatter
        };

        private static ushort[] tripuraSamharaIds = new ushort[] { 1, 12 };
        private static ushort[] criticalMelodyIds = new ushort[] { 87, 100, 124, 125, 301 };
        private static ushort[] restorativeMelodyIds = new ushort[] { 10, 18, 50 };
        private static ushort[] divineBenevolenceIds = new ushort[] { 33, 142 };
        private static ushort[] pawToPawCombatIds = new ushort[] { 31, 69, 71, 86, 179, 180, 227, 263, 289, 290, 316, 362 };
        private static ushort[] auspiciousBeastIds = new ushort[] { 30, 32, 148, 149 };
        private static ushort[] faithfulCompanionIds = new ushort[] { 81, 82, 85, 151, 300, 304, 305, 306 };
        private static ushort[] focusedAssaultIds = new ushort[] { 5, 67, 131 };
        private static ushort[] helmsmanIds = new ushort[] { 34, 73, 143, 153, 307, 308, 309 };
        private static ushort[] deathlyAfflictionIds = new ushort[] { 128, 129, 135, 361 };
        private static ushort[] magnifiedMaladyIds = new ushort[] { 80, 107, 136, 226, 243 };
        private static ushort[] contagiousCurseIds = new ushort[] { 102, 126, 133, 178 };
        private static ushort[] wardOffEvilIds = new ushort[] { 93, 145 };
        private static ushort[] essenceThiefIds = new ushort[] { 127, 134, 137 };
        private static ushort[] behemothicBounceIds = new ushort[] { 105, 249, 274 };
        private static ushort[] withheldSentenceIds = new ushort[] { 13, 110, 253 };
        private static ushort[] megalomaniaIds = new ushort[] { 14, 109, 115, 334 };
        private static ushort[] proxyGuardHoundRaces = new ushort[] { 6, 14, 21, 28 };
        private static ushort[] proxyGuardHoundIds = new ushort[] { 29, 56, 147 };
        private static ushort[] retributiveZealRaces = new ushort[] { 11, 24 };
        private static ushort[] retributiveZealIds = new ushort[] { 138, 139, 140, 141, 284, 285, 286 };
        private static ushort[] fourDevasIds = new ushort[] { 21, 23, 26, 27 };
        private static ushort[] fourOniIds = new ushort[] { 169, 170, 171, 172, 266, 267, 268, 269 };
        private static ushort[] fourHorsemenIds = new ushort[] { 195, 196, 197, 198 };
        private static ushort[] luckyFindIds = new ushort[] { 59, 106, 122, 167 };

        static ushort innateSkillId = 383;

        private static bool faithfulCompanionActive = false;
        private static bool faithfulCompanionActive2 = false;
        private static bool helmsmanActive = false;

        [HarmonyPatch(typeof(cmpDrawStatus), nameof(cmpDrawStatus.cmpDrawSkill))]
        private class InnateSkillPatch1
        {
            // Before displaying skills in the status/level up/fusion/compendium menu 
            public static void Prefix(ref datUnitWork_t pStock, rstSkillInfo_t pSkillInfo)
            {
                // Add the trait skill to the list of displayed upcoming skills
                pSkillInfo.SkillID[pSkillInfo.SkillCnt] = innateSkillId;
                pSkillInfo.SkillCnt++;
            }

            // After displaying skills in the demon/magatama/level up/fusion/compendium status menu 
            public static void Postfix(datUnitWork_t pStock, rstSkillInfo_t pSkillInfo)
            {
                // For each upcoming skill
                for (int i = 0; i < pSkillInfo.SkillID.Length; i++)
                {
                    // Get the skill's ID
                    ushort skillID = pSkillInfo.SkillID[i];

                    // Don't do anything if there's no skill
                    //if (skillID == 0) break;

                    if (skillID != 0)
                    {
                        string name = datSkillName.Get(skillID, pStock.id);

                        if (skillID == innateSkillId)
                        {
                            cmpStatus._statusUIScr.awaitText[i].text = EnableSkillColourOutlines.Value
                                ? name
                                : "<material=\"TMC01\">" + name;

                            cmpStatus._statusUIScr.transform.Find("sskill/sskill_await0" + (i + 1) + "/sskill_base").gameObject.active = false;
                            cmpStatus._statusUIScr.transform.Find("sskill/sskill_await0" + (i + 1) + "/sskill_base_2").gameObject.active = true;
                        }
                        else
                        {
                            cmpStatus._statusUIScr.awaitText[i].text = EnableSkillColourOutlines.Value
                                ? name
                                : "<material=\"TMC02\">" + name;

                            cmpStatus._statusUIScr.transform.Find("sskill/sskill_await0" + (i + 1) + "/sskill_base").gameObject.active = true;
                            cmpStatus._statusUIScr.transform.Find("sskill/sskill_await0" + (i + 1) + "/sskill_base_2").gameObject.active = false;
                        }
                    }
                }
            }
        }

        // After getting the name of a skill
        [HarmonyPatch(typeof(datSkillName), nameof(datSkillName.Get))]
        private class InnateSkillPatch2
        {
            public static void Postfix(int id, ref string __result)
            {
                // If it's the trait skill
                if (id == innateSkillId)
                {
                    // If it's Demi-fiend's trait skill
                    if (currentDemonWork.id == 0)
                    {
                        if (demonInnateSkills[currentDemonWork.id].skillId != 383)
                        {
                            __result = datSkillName.Get(magatamaInnateSkills[dds3GlobalWork.DDS3_GBWK.heartsequip].skillId);
                        }
                        else
                        {
                            __result = JapaneseLanguage ? magatamaInnateSkillsJp[dds3GlobalWork.DDS3_GBWK.heartsequip].skillName : magatamaInnateSkills[dds3GlobalWork.DDS3_GBWK.heartsequip].skillName;
                        }
                    }

                    // If it's Raidou/Dante's trait skill
                    else if (new ushort[] { 191, 192, 339, 340, 341 }.Contains(currentDemonWork.id))
                    {
                        if (!EventBit.evtBitCheck(3712))
                        {
                            __result = datSkillName.Get(410); // Arbitration for Raidou
                        }
                        else
                        {
                            __result = datSkillName.Get(414); // Intimidate for Dante
                        }
                    }

                    // If it's a demon's trait skill
                    else
                    {
                        if (demonInnateSkills[currentDemonWork.id].skillId != 383)
                        {
                            __result = datSkillName.Get(demonInnateSkills[currentDemonWork.id].skillId);
                        }
                        else
                        {
                            __result = JapaneseLanguage ? demonInnateSkillsJp[currentDemonWork.id].skillName : demonInnateSkills[currentDemonWork.id].skillName;
                        }
                    }
                }
            }
        }

        // After getting the description of a skill
        [HarmonyPatch(typeof(datSkillHelp_msg), nameof(datSkillHelp_msg.Get))]
        private class InnateSkillPatch3
        {
            public static void Postfix(int id, ref string __result)
            {
                // If it's the trait skill
                if (id == innateSkillId)
                {
                    // If it's Demi-fiend's trait skill
                    if (currentDemonWork.id == 0)
                    {
                        if (demonInnateSkills[currentDemonWork.id].skillId != 383)
                        {
                            __result = datSkillHelp_msg.Get(magatamaInnateSkills[dds3GlobalWork.DDS3_GBWK.heartsequip].skillId);
                        }
                        else
                        {
                            __result = JapaneseLanguage ? magatamaInnateSkillsJp[dds3GlobalWork.DDS3_GBWK.heartsequip].skillHelp : magatamaInnateSkills[dds3GlobalWork.DDS3_GBWK.heartsequip].skillHelp;
                        }
                    }

                    // If it's Raidou/Dante's trait skill
                    else if (new ushort[] { 191, 192, 339, 340, 341 }.Contains(currentDemonWork.id))
                    {
                        if (!EventBit.evtBitCheck(3712))
                        {
                            __result = datSkillHelp_msg.Get(410); // Arbitration for Raidou
                        }
                        else
                        {
                            __result = datSkillHelp_msg.Get(414); // Intimidate for Dante
                        }
                    }

                    // If it's a demon's trait skill
                    else
                    {
                        if (demonInnateSkills[currentDemonWork.id].skillId != 383)
                        {
                            __result = datSkillHelp_msg.Get(demonInnateSkills[currentDemonWork.id].skillId);
                        }
                        else
                        {
                            __result = JapaneseLanguage ? demonInnateSkillsJp[currentDemonWork.id].skillHelp : demonInnateSkills[currentDemonWork.id].skillHelp;
                        }
                    }
                }
            }
        }

        // Before updating the cursor when selecting demons from the command menu
        [HarmonyPatch(typeof(cmpUpdate), nameof(cmpUpdate.cmpUpdateDevilSelect))]
        private class InnateSkillPatch4
        {
            public static void Prefix(sbyte BufIdx)
            {
                // Restrict the following code to the skill and party submenus (I couldn't find how to narrow it down further)
                if (BufIdx == 0)
                {
                    // For each demons in stock
                    for (int i = 0; i < dds3GlobalWork.DDS3_GBWK.unitwork.Length; i++)
                    {
                        // Skip "ghost" demon slots
                        if (i != 0 && dds3GlobalWork.DDS3_GBWK.unitwork[i].id == 0) continue;

                        // Get current demons's skill count
                        int skillCount = dds3GlobalWork.DDS3_GBWK.unitwork[i].skillcnt;

                        if (skillCount > 0)
                        {
                            // Get the ID of the last skill currently equipped and its index
                            int lastSkillIndex = skillCount - 1;
                            int lastSkill = dds3GlobalWork.DDS3_GBWK.unitwork[i].skill[lastSkillIndex];

                            // If it's not the trait skill, add it at the bottom of the list
                            if (lastSkill != innateSkillId)
                            {
                                dds3GlobalWork.DDS3_GBWK.unitwork[i].skill[lastSkillIndex + 1] = innateSkillId;
                                dds3GlobalWork.DDS3_GBWK.unitwork[i].skillcnt++;
                            }
                        }
                    }
                }
            }
        }

        // Before updating the cursor on the main command menu
        [HarmonyPatch(typeof(cmpUpdate), nameof(cmpUpdate.cmpUpdateRoot))]
        private class InnateSkillPatch5
        {
            public static void Prefix()
            {
                // For each demons in stock
                for (int i = 0; i < dds3GlobalWork.DDS3_GBWK.unitwork.Length; i++)
                {
                    // Skip "ghost" demon slots
                    if (i != 0 && dds3GlobalWork.DDS3_GBWK.unitwork[i].id == 0) continue;

                    // Get current demons's skill count
                    int skillCount = dds3GlobalWork.DDS3_GBWK.unitwork[i].skillcnt;

                    if (skillCount > 0)
                    {
                        // Get the ID of the last skill currently equipped and its index
                        int lastSkillIndex = skillCount - 1;
                        int lastSkill = dds3GlobalWork.DDS3_GBWK.unitwork[i].skill[lastSkillIndex];

                        // If it's the trait skill, remove it
                        if (lastSkill == innateSkillId)
                        {
                            dds3GlobalWork.DDS3_GBWK.unitwork[i].skill[lastSkillIndex] = 0;
                            dds3GlobalWork.DDS3_GBWK.unitwork[i].skillcnt--;
                        }
                    }
                }
            }
        }

        // After running the analysis panel
        [HarmonyPatch(typeof(nbPanelProcess), nameof(nbPanelProcess.nbPanelAnalyzeRun))]
        private class InnateSkillPatch6
        {
            public static void Postfix()
            {
                // There is someone to analyze
                if (nbPanelProcess.pNbPanelAnalyzeUnitWork != null)
                {
                    currentDemonWork = nbPanelProcess.pNbPanelAnalyzeUnitWork; // Target's ID

                    // Replace the 9th skill by the trait (overrides what the "Analyze bosses" mod does)
                    nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = EnableSkillColourOutlines.Value
                        ? datSkillName.Get(innateSkillId)
                        : "<material=\"TMC01\">" + datSkillName.Get(innateSkillId);
                    nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_skill01").gameObject.GetComponent<Image>().color = new Color(0, 1, 0.75f, 1);
                }
            }
        }

        [HarmonyPatch(typeof(nbHelpProcess), nameof(nbHelpProcess.nbDispText))]
        private class DispInnateAttackPassiveNamePatch
        {
            public static void Prefix(ref string text1, ref string text2, ref int type, ref int max, ref uint col, ref bool type_skill)
            {
                if ((text1 == "Attack" || text1 == "Attack") && datDevilFormat.Get(actionProcessData.work.id).attackattr != 0)
                {
                    text1 = JapaneseLanguage ? demonInnateSkillsJp[actionProcessData.work.id].skillName : demonInnateSkills[actionProcessData.work.id].skillName;
                }
            }
        }

        // Checks outside of battle for Life Refill/Mana Refill (on active party) every moon shift
        // Also checks Lucky Find/Mind's Eye (on active party) and Life/Mana Bonus/Gain/Surge (on everyone) when starting a battle
        // ALSO checks for Pierce/Son's Oath/[Relevant boost passive] (on attacker) and Endure/Never Yield/[Relevant passive resistances] (on attackee) when attacking
        // ALSO checks for Charisma (on attacker) when starting a negotiation
        // ALSO checks for Fast Retreat (on party) when trying to escape a battle
        // ALSO checks for Life Aid/Mana Aid/Victory Cry (on party) when leaving a battle
        // (0 = absent, 1 = present)
        //[HarmonyPatch(typeof(datCalc), nameof(datCalc.datCheckSyojiSkill))]
        //private class datCheckSyojiSkillPatch
        //{
        //    public static void Postfix(datUnitWork_t work, uint skill, ref int __result)
        //    {
        //        if (demonInnateSkills[work.id].skillId == skill || (skill == 345 && datCalc.datCheckSyojiSkill(work, 373) != 0))
        //            __result = 1;
        //    }
        //}

        // Get the number of members ready to intervene
        [HarmonyPatch(typeof(nbNegoProcess), nameof(nbNegoProcess.nbGetHojoSkillWorkCnt))]
        private class nbGetHojoSkillWorkCntPatch
        {
            public static void Postfix(ref nbNegoProcessData_t n, ref int __result)
            {
                var party = n.data.party;
                for (int i = 1; i <= 3; i++)
                {
                    var work = nbMainProcess.nbGetUnitWorkFromFormindex(party[i].formindex);
                    if (work.id == 192 || (demonInnateSkills[work.id].skillId >= 409 && demonInnateSkills[work.id].skillId <= 420))
                    {
                        __result += 1;
                        break;
                    }
                }
            }
        }

        // Get the intervention effects (only if nbGetHojoSkillWorkCnt didn't return 0)
        [HarmonyPatch(typeof(nbNegoProcess), nameof(nbNegoProcess.nbSearchHojoSkillWork))]
        private class nbSearchHojoSkillWorkPatch
        {
            public static void Postfix(ref nbNegoProcessData_t n, ref int type, ref uint __result)
            {
                // int type
                // 1 = angry
                // 2 = leaves
                // 3 = battle continues
                // uint __result
                // Right-most bits: skill ID
                // Left-most bits: party index

                var party = n.data.party;
                for (short i = 1; i <= 3; i++)
                {
                    var work = nbMainProcess.nbGetUnitWorkFromFormindex(party[i].formindex);
                    if (work.id == 192 || (demonInnateSkills[work.id].skillId >= 409 && demonInnateSkills[work.id].skillId <= 420))
                    {
                        if (work.id == 192 && !EventBit.evtBitCheck(3712)) // Arbitration for Raidou
                        {
                            __result = Convert.ToUInt32(Convert.ToString(i, 2) + "0000000" + 410, 2);
                        }
                        else if (work.id == 192 && EventBit.evtBitCheck(3712)) // Intimidate for Dante
                        {
                            __result = Convert.ToUInt32(Convert.ToString(i, 2) + "0000000" + 414, 2);
                        }
                        else if (negoSkillScenarios[demonInnateSkills[work.id].skillId].Contains(type))
                            __result = Convert.ToUInt32(Convert.ToString(i, 2) + "0000000" + Convert.ToString(demonInnateSkills[work.id].skillId, 2), 2);
                        break;
                    }
                }
            }
        }

        public static List<ushort> GetActivePartyOutsideOfBattle()
        {
            var party = new List<ushort>();
            for (byte i = 0; i < cmpDrawStock.GBWK.pStockInfo.LocalStock[0].PartyCnt; i++)
                party.Add(dds3GlobalWork.DDS3_GBWK.unitwork[cmpDrawStock.GBWK.pStockInfo.LocalStock[0].StockIdx[i]].id);
            return party;
        }

        internal struct InnateSkill
        {
            public ushort skillId;
            public sbyte skillAttr;
            public string skillName;
            public string skillHelp;

            public InnateSkill(ushort skillId, sbyte skillAttr, string skillName, string skillHelp)
            { 
                this.skillId = skillId; 
                this.skillAttr = skillAttr; 
                this.skillName = skillName; 
                this.skillHelp = skillHelp; 
            }
        }
    }
}