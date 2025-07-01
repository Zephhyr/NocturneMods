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
            { 003, new InnateSkill(383, 06, "Blinding Radiance", "While in the active party, all allies' \nLight attacks may Critically Strike.")}, // 003 Amaterasu
            { 004, new InnateSkill(383, 14, "Runes of Wisdom", "When switching out, Increase the damage \nof next the Strength-based attack \nby 120% for the switched ally.")}, // 004 Odin
            { 005, new InnateSkill(383, 15, "Focused Assault", "Atavaka gains 20% Hit Rate and \nCritical Rate when targetting the \nsame single foe as the previous ally.")}, // 005 Atavaka
            { 006, new InnateSkill(383, 14, "Eye of Horus", "When switching out, Increase the damage \nof next the Magic-based attack \nby 120% for the switched ally.")}, // 006 Horus
            { 007, new InnateSkill(383, 15, "Chanchala", "While in the active party, if an ally's \nMagical Attack is maximized, their \nElement attacks may Critically Strike.")}, // 007 Lakshmi
            { 008, new InnateSkill(383, 15, "Warrior Trainer", "While Setanta or Cu Chulainn is in \nthe active party, Scathach's attacks \nwith positive potential will not miss.")}, // 008 Scathach
            { 009, new InnateSkill(383, 04, "Vina Raga", "While in the active party, all allies' \nForce attacks may Critically Strike.")}, // 009 Sarasvati
            { 010, new InnateSkill(383, 13, "Restorative Melody", "While in the active party, \nHealing skill costs are reduced \nby 20% for all allies.")}, // 010 Sati
            { 011, new InnateSkill(383, 14, "Curious Dance", "When switching out, all -kaja and \n-nda effects on Ame-no-Uzume will \nbe passed to the switched ally.")}, // 011 Ame-no-Uzume
            { 012, new InnateSkill(383, 15, "Tripura Samhara", "While in the active party, \nskill costs are reduced by 20% \nfor allies with a charge effect.")}, // 012 Shiva
            { 013, new InnateSkill(383, 15, "Withheld Sentence", "While in the active party, \nallies are immune to random \ninstakills.")}, // 013 Beidou Xingjun
            { 014, new InnateSkill(383, 14, "Megalomania", "After Qitian Dasheng uses a \ncharge effect, he has a 30% \nchance to retain it.")}, // 014 Qitian Dasheng
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
            { 044, new InnateSkill(383, 01, "Malevolent Flames", "While in the active party, all allies' \nFire attacks may Critically Strike.")}, // 044 Efreet
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
            { 062, new InnateSkill(383, 06, "Light Gestalt", "Power gains Light skill potential \nbased on the total positive potential \nof allies in the active party.")}, // 062 Throne
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
            { 076, new InnateSkill(383, 02, "Breath of Plenty", "While in the active party, all allies' \nIce attacks may Critically Strike.")}, // 076 Quetzalcoatl
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
            { 109, new InnateSkill(383, 14, "Megalomania", "After Mot uses a \ncharge effect, he has a 30% \nchance to retain it.")}, // 109 Mot
            { 110, new InnateSkill(383, 15, "Withheld Sentence", "While in the active party, \nallies are immune to random \ninstakills.")}, // 110 Alciel
            { 111, new InnateSkill(383, 01, "Laevateinn", "Fire Enhancer & Surt's normal \nattacks deal medium Fire damage.")}, // 111 Surt
            { 112, new InnateSkill(414, 15, "Intimidate", "While in the active party, \nmay step in during negotiation to \n'convince' a lower level demon.")}, // 112 Abaddon
            { 113, new InnateSkill(383, 15, "Destabilize", "While in the active party, Element \nattacks may Critically Strike \nfor all allies and enemies.")}, // 113 Loki
            { 114, new InnateSkill(383, 05, "Forbidden Fruit", "While in the active party, all allies' \nAlmighty attacks may Critically Strike.")}, // 114 Lilith
            { 115, new InnateSkill(383, 14, "Megalomania", "After Nyx uses a \ncharge effect, she has a 30% \nchance to retain it.")}, // 115 Nyx
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
            { 150, new InnateSkill(383, 03, "Vanquishing Bolts", "While in the active party, all allies' \nElec attacks may Critically Strike.")}, // 150 Barong
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
            { 168, new InnateSkill(383, 07, "Dark Star", "While in the active party, all allies' \nDark attacks may Critically Strike.")}, // 168 Kaiwan
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
            { 229, new InnateSkill(383, 15, "Magatama Mimicry", "Demee-Ho gains skill potential \ndependant on which Magatama is \ncurrently ingested.")}, // 229 Demee-Ho
            { 230, new InnateSkill(383, 15, "", "")}, // 230 
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
            { 243, new InnateSkill(383, 15, "", "")}, // 243 
            { 244, new InnateSkill(383, 15, "", "")}, // 244 
            { 245, new InnateSkill(383, 15, "", "")}, // 245 
            { 246, new InnateSkill(383, 15, "", "")}, // 246 
            { 247, new InnateSkill(383, 15, "", "")}, // 247 
            { 248, new InnateSkill(383, 15, "", "")},
            { 249, new InnateSkill(383, 15, "Behemothic Bounce", "")}, // 249 Sarge Girimekhala
            { 250, new InnateSkill(383, 15, "Hidden Potential", "")}, // 250 NKE Pixie
            { 251, new InnateSkill(383, 02, "Ice Enhancer", "")}, // 251 NKE Jack Frost
            { 252, new InnateSkill(383, 15, "Devil Regeneration", "")}, // 252 Devil Dante
            { 253, new InnateSkill(383, 15, "Withheld Sentence", "")}, // 253 Gamete
            { 254, new InnateSkill(383, 15, "YHVH", "")}, // 254 YHVH
            { 255, new InnateSkill(383, 15, "", "")}, // 255 
            { 256, new InnateSkill(383, 15, "Best Friend", "")}, // 256 Boss Forneus
            { 257, new InnateSkill(383, 15, "Phantasmagoria", "")}, // 257 Boss Specter 1 (Mini)
            { 258, new InnateSkill(383, 15, "Boss Ahriman 2", "")}, // 258 Boss Ahriman 2
            { 259, new InnateSkill(383, 15, "Boss Noah 2", "")}, // 259 Boss Noah 2
            { 260, new InnateSkill(383, 15, "Twilit Melody", "")}, // 260 Forced Incubus
            { 261, new InnateSkill(383, 15, "Force Gestalt", "")}, // 261 Forced Koppa Tengu
            { 262, new InnateSkill(383, 15, "Dark Star", "")}, // 262 Forced Kaiwan
            { 263, new InnateSkill(383, 15, "Paw-to-Paw Combat", "")}, // 263 Boss Ose
            { 264, new InnateSkill(383, 15, "Boss Kagutsuchi 2", "")}, // 264 Boss Kagutsuchi 2
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
            { 288, new InnateSkill(383, 15, "Boss Baal Avatar", "")}, // 288 Boss Baal Avatar
            { 289, new InnateSkill(383, 15, "Paw-to-Paw Combat", "")}, // 289 Boss Ose Hallel
            { 290, new InnateSkill(383, 15, "Paw-to-Paw Combat", "")}, // 290 Boss Flauros Hallel
            { 291, new InnateSkill(383, 15, "Boss Ahriman 1", "")}, // 291 Boss Ahriman 1
            { 292, new InnateSkill(383, 15, "Boss Noah 1", "")}, // 292 Boss Noah 1
            { 293, new InnateSkill(383, 15, "Boss Kagutsuchi 1", "")}, // 293 Boss Kagutsuchi 1
            { 294, new InnateSkill(383, 15, "Phantasmagoria", "")}, // 294 Boss Specter 1 (Merged 6)
            { 295, new InnateSkill(383, 15, "Phantasmagoria", "")}, // 295 Boss Specter 1 (Merged 4-5)
            { 296, new InnateSkill(383, 15, "Phantasmagoria", "")}, // 296 Boss Specter 1 (Merged 2-3)
            { 297, new InnateSkill(383, 15, "Frigid Melody", "")}, // 297 Boss Mizuchi
            { 298, new InnateSkill(383, 14, "Retributive Zeal", "")}, // 298 Boss Michael
            { 299, new InnateSkill(383, 15, "Desperate Power", "")}, // 299 Boss Sakahagi
            { 300, new InnateSkill(383, 15, "Faithful Companion", "")}, // 300 Boss Orthrus
            { 301, new InnateSkill(383, 15, "Critical Melody", "")}, // 301 Boss Yaksini
            { 302, new InnateSkill(383, 03, "Odinson", "")}, // 302 Boss Thor
            { 303, new InnateSkill(383, 15, "Cold World", "")}, // 303 Boss Black Frost
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
            { 315, new InnateSkill(383, 15, "Dark Star", "")}, // 315 Boss Kaiwan
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
            { 336, new InnateSkill(383, 15, "Ambush Jack-o'-Lantern", "")}, // 336 Ambush Jack-o'-Lantern
            { 337, new InnateSkill(383, 03, "Odinson", "")}, // 337 Boss Thor 2
            { 338, new InnateSkill(383, 15, "", "")}, // 338 
            { 339, new InnateSkill(383, 15, "Boss Raidou/Dante 1", "")}, // 339 Boss Raidou/Dante 1
            { 340, new InnateSkill(383, 15, "Chase Raidou/Dante", "")}, // 340 Chase Raidou/Dante
            { 341, new InnateSkill(383, 15, "Boss Raidou/Dante 2", "")}, // 341 Boss Raidou/Dante 2
            { 342, new InnateSkill(383, 05, "Almighty Gestalt", "")}, // 342 Boss Metatron
            { 343, new InnateSkill(383, 05, "Almighty Enhancer", "")}, // 343 Boss Beelzebub
            { 344, new InnateSkill(383, 15, "Boss Lucifer", "")}, // 344 Boss Lucifer
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
            { 13, new InnateSkill(383, 15, "Geis", "")}, // 13 Geis
            { 14, new InnateSkill(383, 15, "Destabilize", "Element attacks may Critically Strike \nfor all allies and enemies.")}, // 14 Djed
            { 15, new InnateSkill(383, 01, "Malevolent Flames", "All allies' Fire attacks \nmay Critically Strike.")}, // 15 Muspell
            { 16, new InnateSkill(383, 05, "Forbidden Fruit", "Allies' Almighty attacks \nmay Critically Strike.")}, // 16 Satan
            { 17, new InnateSkill(383, 15, "Magnified Malady", "All allies deal 20% more damage \nagainst enemies with an ailment.")}, // 17 Adama
            { 18, new InnateSkill(383, 15, "Gehenna", "")}, // 18 Gehenna
            { 19, new InnateSkill(383, 15, "Withheld Sentence", "Allies are immune to \nrandom instakills.")}, // 19 Sophia
            { 20, new InnateSkill(383, 04, "Orochi's Bane", "Your Force attacks may \ninflict poison.")}, // 20 Murakumo
            { 21, new InnateSkill(383, 15, "Gundari", "")}, // 21 Gundari
            { 22, new InnateSkill(383, 03, "Vanquishing Bolts", "All allies' Elec attacks \nmay Critically Strike.")}, // 22 Narukami
            { 23, new InnateSkill(383, 14, "Megalomania", "After using a charge effect, \ngain a 30% chance to retain it.")}, // 23 Gaea
            { 24, new InnateSkill(383, 15, "Tripura Samhara", "Skill costs are reduced by 20% \nfor allies with a charge effect.")}, // 24 Kailash
            { 25, new InnateSkill(383, 15, "Masakados", "")} // 25 Masakados
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
        private static ushort[] magnifiedMaladyIds = new ushort[] { 80, 107, 136, 226 };
        private static ushort[] contagiousCurseIds = new ushort[] { 102, 126, 133, 178 };
        private static ushort[] wardOffEvilIds = new ushort[] { 93, 145 };
        private static ushort[] essenceThiefIds = new ushort[] { 127, 124, 137 };
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

                    if (skillID == 425 && pStock.id == 0)
                    {
                        // If you cannot get "Pierce"
                        if (!EventBit.evtBitCheck(2241))
                        {
                            cmpStatus._statusUIScr.awaitText[i].text = "？"; // Displays a "？"
                        }
                        continue; //Skip "Pierce" on Demi-fiend
                    }
                    else if (skillID != 0)
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
                            __result = magatamaInnateSkills[dds3GlobalWork.DDS3_GBWK.heartsequip].skillName;
                        }
                    }

                    // If it's Raidou/Dante's trait skill
                    else if (new ushort[] { 192, 339, 340, 341 }.Contains(currentDemonWork.id))
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
                            __result = demonInnateSkills[currentDemonWork.id].skillName;
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
                            __result = magatamaInnateSkills[dds3GlobalWork.DDS3_GBWK.heartsequip].skillHelp;
                        }
                    }

                    // If it's Raidou/Dante's trait skill
                    else if (new ushort[] { 192, 339, 340, 341 }.Contains(currentDemonWork.id))
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
                            __result = demonInnateSkills[currentDemonWork.id].skillHelp;
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
                if (text1 == "Attack" && datDevilFormat.Get(actionProcessData.work.id).attackattr != 0)
                {
                    text1 = demonInnateSkills[actionProcessData.work.id].skillName;
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