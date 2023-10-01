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
        [HarmonyPatch(typeof(Localize), nameof(Localize.GetLocalizeText), new Type[] { typeof(string) })]
        private class LocalizeNamesPatch
        {
            public static bool Prefix(ref string ID, ref string __result)
            {
                switch (ID)
                {
                    case "<AISYO_L0002>": // Mitra
                        __result = "Rpl: Phys • Null: Light/Dark • Str: Fire/Ice • Weak: Force"; return false;
                    case "<AISYO_L0004>": // Odin
                        __result = "Rpl: Elec • Null: Ice • Str: Light/Dark • Weak: Force"; return false;
                    case "<AISYO_L0014>": // Qitian Dasheng
                        __result = "Null: Phys/Light"; return false;
                    case "<AISYO_L0015>": // Dionysus
                        __result = "Null: Fire/Light/Dark/Mind • Weak: Ice"; return false;
                    case "<AISYO_L0017>": // Skadi
                        __result = "Drn: Ice • Null: Light/Curse • Str: Phys/Force • Weak: Elec"; return false;
                    case "<AISYO_L0018>": // Parvati
                        __result = "Rpl: Light • Drn: Fire • Str: Ailments"; return false;
                    case "<AISYO_L0019>": // Kushinada
                        __result = "Rpl: Light • Str: Ailments • Weak: Dark"; return false;
                    case "<AISYO_L0022>": // Thor
                        __result = "Drn: Elec • Null: Light • Str: Phys • Weak: Curse/Nerve"; return false;
                    case "<AISYO_L0027>": // Zouchouten
                        __result = "Null: Light/Nerve/Curse • Str: Elec • Weak: Force"; return false;
                    case "<AISYO_L0028>": // Take-Minakata
                        __result = "Rpl: Elec • Null: Light • Str: Dark • Weak: Fire/Nerve"; return false;
                    case "<AISYO_L0030>": // Baihu
                        __result = "Null: Elec/Light • Str: Ice • Weak: Fire"; return false;
                    case "<AISYO_L0032>": // Zhuque
                        __result = "Drn: Fire • Null: Light • Str: Elec • Weak: Ice"; return false;
                    case "<AISYO_L0033>": // Shiisaa
                        __result = "Null: Elec/Light • Str: Force • Weak: Fire"; return false;
                    case "<AISYO_L0036>": // Flaemis
                        __result = "Drn: Fire • Weak: Ice"; return false;
                    case "<AISYO_L0037>": // Aquans
                        __result = "Rpl: Ice • Weak: Fire"; return false;
                    case "<AISYO_L0038>": // Aeros
                        __result = "Null: Force • Weak: Elec"; return false;
                    case "<AISYO_L0039>": // Erthys
                        __result = "Str: Elec • Weak: Force"; return false;
                    case "<AISYO_L0040>": // Saki Mitama
                        __result = "Str: Light/Dark/Ailments"; return false;
                    case "<AISYO_L0041>": // Kushi Mitama
                        __result = "Str: Light/Dark/Ailments"; return false;
                    case "<AISYO_L0042>": // Nigi Mitama
                        __result = "Str: Light/Dark/Ailments"; return false;
                    case "<AISYO_L0043>": // Ara Mitama
                        __result = "Str: Light/Dark/Ailments"; return false;
                    case "<AISYO_L0048>": // Karasu Tengu
                        __result = "Rpl: Force • Str: Fire • Weak: Ailments"; return false;
                    case "<AISYO_L0049>": // Dís
                        __result = "Drn: Fire • Weak: Dark"; return false;
                    case "<AISYO_L0050>": // Isora
                        __result = "Null: Ice • Weak: Fire"; return false;
                    case "<AISYO_L0055>": // Troll
                        __result = "Drn: Ice • Weak: Nerve/Mind"; return false;
                    case "<AISYO_L0063>": // Dominion
                        __result = "Rpl: Light • Str: Force • Weak: Dark/Curse"; return false;
                    case "<AISYO_L0064>": // Virtue
                        __result = "Rpl: Light • Str: Elec • Weak: Force/Dark"; return false;
                    case "<AISYO_L0067>": // Archangel
                        __result = "Null: Light • Str: Fire • Weak: Ice/Dark"; return false;
                    case "<AISYO_L0068>": // Angel
                        __result = "Null: Light • Str: Force • Weak: Elec/Dark"; return false;
                    case "<AISYO_L0080>": // Nozuchi
                        __result = "Null: Force/Curse • Weak: Elec"; return false;
                    case "<AISYO_L0082>": // Orthrus
                        __result = "Drn: Fire • Str: Mind • Weak: Ice"; return false;
                    case "<AISYO_L0086>": // Nekomata
                        __result = "Null: Force • Str: Fire • Weak: Ice"; return false;
                    case "<AISYO_L0088>": // Titan
                        __result = "Null: Force • Str: Phys • Weak: Elec"; return false;
                    case "<AISYO_L0089>": // Sarutahiko
                        __result = "Null: Light • Str: Dark • Weak: Nerve"; return false;
                    case "<AISYO_L0094>": // Oni
                        __result = "Str: Phys • Weak: Light/Nerve"; return false;
                    case "<AISYO_L0095>": // Yomotsu-Ikusa
                        __result = "Null: Nerve • Str: Dark • Weak: Force"; return false;
                    case "<AISYO_L0096>": // Momunofu
                        __result = "Str: Phys • Weak: Force/Ailments"; return false;
                    case "<AISYO_L0097>": // Shikigami
                        __result = "Null: Elec • Weak: Fire"; return false;
                    case "<AISYO_L0099>": // Dakini
                        __result = "Str: Phys/Fire • Weak: Ice"; return false;
                    case "<AISYO_L0102>": // Taraka
                        __result = "Null: Elec/Nerve • Str: Dark • Weak: Ice"; return false;
                    case "<AISYO_L0103>": // Datsue-Ba
                        __result = "Null: Nerve/Mind • Str: Ice • Weak: Elec"; return false;
                    case "<AISYO_L0105>": // Girimekhala
                        __result = "Rpl: Phys • Null: Dark • Weak: Light/Mind"; return false;
                    case "<AISYO_L0107>": // Pazuzu
                        __result = "Null: Dark • Str: Force/Mind • Weak: Ice"; return false;
                    case "<AISYO_L0109>": // Mot
                        __result = "Rpl: Force/Dark • Null: Ailments • Str: Phys/Fire • Weak: Elec"; return false;
                    case "<AISYO_L0110>": // Aciel
                        __result = "Rpl: Dark • Null: Magic • Weak: Phys/Light"; return false;
                    case "<AISYO_L0111>": // Surt
                        __result = "Drn: Fire • Null: Dark/Ailments • Str: Phys • Weak: Ice"; return false;
                    case "<AISYO_L0112>": // Abaddon
                        __result = "Rpl: Dark • Str: Magic • Weak: Light"; return false;
                    case "<AISYO_L0114>": // Lilith
                        __result = "Null: Dark/Mind • Str: Magic"; return false;
                    case "<AISYO_L0115>": // Nyx
                        __result = "Null: Mind • Str: Magic"; return false;
                    case "<AISYO_L0117>": // Succubus
                        __result = "Null: Mind • Str: Ice/Curse/Nerve • Weak: Light"; return false;
                    case "<AISYO_L0118>": // Incubus
                        __result = "Null: Curse/Mind • Str: Dark • Weak: Force"; return false;
                    case "<AISYO_L0120>": // Lilim
                        __result = "Null: Elec • Str: Dark/Mind • Weak: Ice"; return false;
                    case "<AISYO_L0121>": // Hresvelgr
                        __result = "Rpl: Ice • Null: Force/Dark • Str: Phys • Weak: Fire"; return false;
                    case "<AISYO_L0122>": // Mothman
                        __result = "Null: Fire/Dark/Curse • Weak: Elec"; return false;
                    case "<AISYO_L0126>": // Zhen
                        __result = "Str: Dark/Ailments • Weak: Fire"; return false;
                    case "<AISYO_L0127>": // Vetala
                        __result = "Rpl: Dark • Str: Ailments • Weak: Elec/Light"; return false;
                    case "<AISYO_L0130>": // Choronzon
                        __result = "Null: Fire/Dark • Str: Phys • Weak: Force/Light"; return false;
                    case "<AISYO_L0131>": // Preta
                        __result = "Null: Dark • Weak: Magic/Light"; return false;
                    case "<AISYO_L0134>": // Blob
                        __result = "Null: Dark • Str: Phys • Weak: Fire/Ice/Light"; return false;
                    case "<AISYO_L0135>": // Slime
                        __result = "Null: Dark • Str: Phys • Weak: Magic/Light"; return false;
                    case "<AISYO_L0136>": // Mou-Ryo
                        __result = "Null: Dark • Str: Fire • Weak: Light"; return false;
                    case "<AISYO_L0138>": // Michael
                        __result = "Rpl: Light • Str: Phys/Magic"; return false;
                    case "<AISYO_L0139>": // Gabriel
                        __result = "Rpl: Ice/Light • Str: Fire/Force"; return false;
                    case "<AISYO_L0140>": // Raphael
                        __result = "Rpl: Force/Light • Str: Ice/Elec"; return false;
                    case "<AISYO_L0141>": // Uriel
                        __result = "Rpl: Fire/Light • Str: Elec/Force"; return false;
                    case "<AISYO_L0144>": // Arahabaki
                        __result = "Null: Phys • Str: Light/Dark • Weak: Magic/Ailments"; return false;
                    case "<AISYO_L0147>": // Cu Chulainn
                        __result = "Rpl: Force • Null: Light • Str: Phys"; return false;
                    case "<AISYO_L0148>": // Qing Long
                        __result = "Drn: Force • Null: Light • Str: Ice • Weak: Fire"; return false;
                    case "<AISYO_L0149>": // Xuanwu
                        __result = "Drn: Ice • Null: Light • Str: Curse • Weak: Elec"; return false;
                    case "<AISYO_L0150>": // Barong
                        __result = "Rpl: Light • Drn: Elec • Str: Ice • Weak: Dark"; return false;
                    case "<AISYO_L0152>": // Garuda
                        __result = "Rpl: Force/Light • Null: Ailments • Weak: Dark"; return false;
                    case "<AISYO_L0154>": // Gurulu
                        __result = "Rpl: Force/Dark • Null: Ailments • Weak: Light"; return false;
                    case "<AISYO_L0155>": // Albion
                        __result = "Null: Phys/Light"; return false;
                    case "<AISYO_L0161>": // Samael
                        __result = "Rpl: Dark • Null: Mind • Weak: Light"; return false;
                    case "<AISYO_L0169>": // Kin-Ki
                        __result = "Str: Phys/Nerve/Mind • Weak: Curse"; return false;
                    case "<AISYO_L0170>": // Sui-Ki
                        __result = "Null: Ice/Dark • Str: Ailments • Weak: Fire"; return false;
                    case "<AISYO_L0171>": // Fuu-Ki
                        __result = "Null: Force/Dark • Str: Ailments • Weak: Elec"; return false;
                    case "<AISYO_L0172>": // Ongyo-Ki
                        __result = "Null: Phys/Dark/Ailments • Weak: Light"; return false;
                    case "<AISYO_L0173>": // Clotho
                        __result = "Null: Light/Dark • Str: Ailments"; return false;
                    case "<AISYO_L0174>": // Lachesis
                        __result = "Null: Ailments • Str: Light/Dark"; return false;
                    case "<AISYO_L0178>": // Phantom
                        __result = "Null: Dark • Str: Phys/Elec • Weak: Force/Light"; return false;
                    case "<AISYO_L0192>": // Dante/Raidou
                        __result = "Str: All except Almighty"; return false;
                    case "<AISYO_L0193>": // Metatron
                        __result = "Rpl: Light • Null: Fire/Ailments • Str: Phys/Elec/Force/Dark"; return false;
                    case "<AISYO_L0194>": // Beelzebub (Man)
                        __result = "Drn: Elec • Null: Force/Dark/Ailments • Str: Phys/Ice/Light"; return false;
                    case "<AISYO_L0195>": // Pale Rider
                        __result = "Rpl: Force/Dark • Null: Ailments • Str: Ice/Light"; return false;
                    case "<AISYO_L0196>": // White Rider
                        __result = "Null: Fire/Light/Curse/Mind"; return false;
                    case "<AISYO_L0197>": // Red Rider
                        __result = "Null: Elec/Force/Dark/Nerve"; return false;
                    case "<AISYO_L0198>": // Black Rider
                        __result = "Drn: Ice • Null: Dark/Ailments"; return false;
                    case "<AISYO_L0199>": // Matador
                        __result = "Null: Force/Dark"; return false;
                    case "<AISYO_L0200>": // Hell Biker
                        __result = "Null: Fire/Force • Str: Dark/Curse"; return false;
                    case "<AISYO_L0201>": // Daisoujou
                        __result = "Drn: Curse/Mind • Null: Light/Dark"; return false;
                    case "<AISYO_L0202>": // Mother Harlot
                        __result = "Rpl: Phys • Drn: Elec • Str: Light/Dark/Ailments"; return false;
                    case "<AISYO_L0203>": // Trumpeter
                        __result = "Null: Light/Dark/Ailments • Str: Magic"; return false;
                    case "<AISYO_L0206>": // Black Frost
                        __result = "Drn: Ice • Null: Dark • Str: Phys/Fire • Weak: Light"; return false;
                    case "<AISYO_L0207>": // Beelzebub (Man)
                        __result = "Drn: Elec • Null: Dark/Ailments • Str: Ice/Force"; return false;
                    case "<DEVIL_L0019>":
                        __result = "Kushinada-Hime"; return false;
                    case "<DEVIL_L0179>":
                        __result = "Ose Hallel"; return false;
                    case "<AISYO_L0179>":
                        __result = "Null: Light/Dark/Ailments • Str: Phys"; return false;
                    case "<DEVIL_L0180>":
                        __result = "Flauros Hallel"; return false;
                    case "<AISYO_L0180>":
                        __result = "Null: Light/Dark/Ailments • Str: Phys"; return false;
                    case "<DEVIL_L0181>":
                        __result = "Urthona"; return false;
                    case "<AISYO_L0181>":
                        __result = "Rpl: Elec • Weak: Force"; return false;
                    case "<DEVIL_L0182>":
                        __result = "Urizen"; return false;
                    case "<AISYO_L0182>":
                        __result = "Rpl: Fire • Weak: Ice"; return false;
                    case "<DEVIL_L0183>":
                        __result = "Luvah"; return false;
                    case "<AISYO_L0183>":
                        __result = "Rpl: Force • Weak: Elec"; return false;
                    case "<DEVIL_L0184>":
                        __result = "Tharmus"; return false;
                    case "<AISYO_L0184>":
                        __result = "Rpl: Ice • Weak: Fire"; return false;
                    case "<DEVIL_L0185>":
                        __result = "Specter"; return false;
                    case "<AISYO_L0185>":
                        __result = "Null: Light/Dark/Ailments"; return false;
                    case "<DEVIL_L0186>":
                        __result = "Mara"; return false;
                    case "<AISYO_L0186>":
                        __result = "Null: Light/Dark/Ailments"; return false;
                    case "<DEVIL_L0187>":
                        __result = "Doppelgänger"; return false;
                    case "<AISYO_L0187>":
                        __result = "Rpl: Phys • Str: Ailments • Weak: Light/Dark"; return false;
                    default: return true;
                }
            }
        }

        [HarmonyPatch(typeof(frFont), nameof(frFont.frReplaceLocalizeText))]
        private class CompendiumProfilePatch
        {
            public static void Postfix(ref string message, ref frMsgInfo_t mi, ref List<int> index, ref string __result)
            {
                switch (message)
                {
                    case "<COLLECTIONBOOK_L0179>":
                        __result = "Another form of Ose, one of the 72 demons of the Goetia. His divine appearence reflects him as he was before joining Lucifer's rebellion against God, after which he became a fallen angel."; break;
                    case "<COLLECTIONBOOK_L0180>":
                        __result = "Another form of Flauros, one of the 72 demons of the Goetia. His divine appearence reflects him as he was before joining Lucifer's rebellion against God, after which he became a fallen angel."; break;
                    case "<COLLECTIONBOOK_L0181>":
                        __result = "One of the four Zoas created when Albion was divided fourfold. He represents inspiration, creativity and the north."; break;
                    case "<COLLECTIONBOOK_L0182>":
                        __result = "One of the four Zoas created when Albion was divided fourfold. He represents conventional reason and law."; break;
                    case "<COLLECTIONBOOK_L0183>":
                        __result = "One of the four Zoas created when Albion was divided fourfold. He represents love, passion and rebellious energy."; break;
                    case "<COLLECTIONBOOK_L0184>":
                        __result = "One of the four Zoas created when Albion was divided fourfold. He represents time, sensation and free speech."; break;
                    case "<COLLECTIONBOOK_L0185>":
                        __result = "A spirit of the dead in Western folklore. A specter's appearance is said to be horrifying beyond anything imaginable. Those to whom it appears are paralyzed with fear, but are very rarely harmed."; break;
                    case "<COLLECTIONBOOK_L0186>":
                        __result = "A Buddhist demon that represents the fear of death. He sent his daughter to tempt Buddha during his meditations. Improper summoning has caused him to manifest with rather flaccid appearence and power."; break;
                    case "<COLLECTIONBOOK_L0187>":
                        __result = "A phantom copy of a living being. Doppelgängers are a sign of bad luck. Often, others see your doppelgänger from afar, but it is said you may also see your own doppelgänger right before you die."; break;
                    default: break;
                }
            }
        }

        private static void ApplyDemonChanges()
        {
            // Demons
            Vishnu(1);
            Mitra(2);
            Amaterasu(3);
            Odin(4);
            Atavaka(5);
            Horus(6);

            Lakshmi(7);
            Scathach(8);
            Sarasvati(9);
            Sati(10);

            Shiva(12);
            BeidouXingjun(13);
            QitianDasheng(14);
            Dionysus(15);

            Kali(16);
            Skadi(17);
            Parvati(18);
            Kushinada(19);
            KikuriHime(20);

            Bishamonten(21);
            Thor(22);
            Jikokuten(23);
            TakeMikazuchi(24);
            Okuninushi(25);
            Koumokuten(26);
            Zouchouten(27);
            TakeMinakata(28);

            Chimera(29);
            Baihu(30);
            Senri(31);
            Zhuque(32);
            Shiisaa(33);

            Xiezhai(34);

            Flaemis(36);
            Aquans(37);
            Aeros(38);
            Erthys(39);

            SakiMitama(40);
            KushiMitama(41);
            NigiMitama(42);
            AraMitama(43);

            Efreet(44);
            Jinn(47);
            KarasuTengu(48);
            Dis(49);
            Isora(50);
            KoppaTengu(52);

            Titania(53);
            Troll(55);
            Setanta(56);
            Kelpie(57);
            HighPixie(59);
            JackFrost(60);
            Pixie(61);

            Dominion(63);
            Virtue(64);
            Power(65);
            Principality(66);
            Archangel(67);
            Angel(68);

            Flauros(69);
            Decarabia(70);
            Ose(71);
            Berith(72);
            Eligor(73);
            Forneus(74);

            Yurlungur(75);
            Quetzalcoatl(76);
            NagaRaja(77);
            Nozuchi(80);

            Cerberus(81);
            Orthrus(82);
            Suparna(83);
            BadbCatha(84);
            Nekomata(86);

            Titan(88);
            Sarutahiko(89);

            Oni(94);
            YomotsuIkusa(95);
            Momunofu(96);
            Shikigami(97);

            Rangda(98);
            Dakini(99);
            Yaksini(100);
            YomotsuShikome(101);
            Taraka(102);
            DatsueBa(103);

            Mada(104);
            Girimekhala(105);
            Taotie(106);
            Pazuzu(107);
            Baphomet(108);

            Mot(109);
            Aciel(110);
            Surt(111);
            Abaddon(112);
            Loki(113);

            Lilith(114);
            Nyx(115);
            QueenMab(116);
            Succubus(117);
            Incubus(118);
            Fomorian(119);
            Lilim(120);

            Hresvelgr(121);
            Mothman(122);
            Raiju(123);
            Nue(124);
            Zhen(126);

            Vetala(127);
            Legion(128);
            Yaka(129);
            Choronzon(130);
            Preta(131);

            Shadow(132);
            BlackOoze(133);
            Blob(134);
            Slime(135);
            MouRyo(136);
            WillOWisp(137);

            Michael(138);
            Gabriel(139);
            Raphael(140);
            Uriel(141);

            Ganesha(142);
            Valkyrie(143);

            Arahabaki(144);

            KuramaTengu(145);
            CuChulainn(147);

            QingLong(148);
            Xuanwu(149);

            Barong(150);

            Garuda(152);
            Yatagarasu(153);
            Gurulu(154);
            Albion(155);

            Samael(161);

            Pisaca(167);

            Kaiwan(168);

            KinKi(169);
            SuiKi(170);
            FuuKi(171);
            OngyoKi(172);

            Clotho(173);
            Lachesis(174);
            Atropos(175);

            Loa(176);

            Phantom(178);

            DanteRaidou(192);
            Metatron(193);
            BeelzebubFly(194);

            PaleRider(195);
            WhiteRider(196);
            RedRider(197);
            BlackRider(198);
            Matador(199);
            HellBiker(200);
            Daisoujou(201);
            MotherHarlot(202);
            Trumpeter(203);

            BlackFrost(206);

            BeelzebubMan(207);

            // Bosses
            BossForneus(256);
        }

        private static void Vishnu(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[1].Param = 433;
            tblSkill.fclSkillTbl[id].Event[3].Param = 195;
            tblSkill.fclSkillTbl[id].Event[5].Param = 454;
            tblSkill.fclSkillTbl[id].Event[7].Param = 471;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 98;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Mitra(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 131072; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 2147483798; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 31;
            tblSkill.fclSkillTbl[id].Event[4].Param = 395;
            tblSkill.fclSkillTbl[id].Event[5].Param = 189;
            tblSkill.fclSkillTbl[id].Event[6].Param = 454;
            tblSkill.fclSkillTbl[id].Event[7].Param = 295;
        }

        private static void Amaterasu(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 459;
        }

        private static void Odin(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 65536; // Ice
            datAisyo.tbl[id][3] = 131072; // Elec
            datAisyo.tbl[id][4] = 2147483798; // Force
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 18;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 9;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 108;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 441;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 66;
            tblSkill.fclSkillTbl[id].Event[4].Param = 391;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 67;
            tblSkill.fclSkillTbl[id].Event[5].Param = 428;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 68;
            tblSkill.fclSkillTbl[id].Event[6].Param = 12;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 442;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 70;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Atavaka(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 299;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 107;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 430;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 345;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 48;
            tblSkill.fclSkillTbl[id].Event[4].Param = 450;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 49;
            tblSkill.fclSkillTbl[id].Event[5].Param = 313;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 50;
            tblSkill.fclSkillTbl[id].Event[6].Param = 110;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 51;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 306;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 52;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Horus(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 354;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 30;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 294;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 193;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 39;
            tblSkill.fclSkillTbl[id].Event[4].Param = 77;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 40;
            tblSkill.fclSkillTbl[id].Event[5].Param = 40;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 41;
            tblSkill.fclSkillTbl[id].Event[6].Param = 456;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 42;
            tblSkill.fclSkillTbl[id].Event[7].Param = 75;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 43;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Lakshmi(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 41;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 387;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 197;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 347;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 55;
            tblSkill.fclSkillTbl[id].Event[4].Param = 456;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 56;
            tblSkill.fclSkillTbl[id].Event[5].Param = 295;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 57;
            tblSkill.fclSkillTbl[id].Event[6].Param = 50;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 58;
            tblSkill.fclSkillTbl[id].Event[7].Param = 51;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 59;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Scathach(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 444;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 299;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 448;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 342;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 65;
            tblSkill.fclSkillTbl[id].Event[5].Param = 188;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 66;
            tblSkill.fclSkillTbl[id].Event[6].Param = 186;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 67;
            tblSkill.fclSkillTbl[id].Event[7].Param = 390;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 68;
            tblSkill.fclSkillTbl[id].Event[8].Param = 347;
            tblSkill.fclSkillTbl[id].Event[8].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[8].Type = 1;
            tblSkill.fclSkillTbl[id].Event[9].Param = 17;
            tblSkill.fclSkillTbl[id].Event[9].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[9].Type = 5;
        }

        private static void Sarasvati(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 198;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 350;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 49;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 443;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 31;
            tblSkill.fclSkillTbl[id].Event[4].Param = 387;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 32;
            tblSkill.fclSkillTbl[id].Event[5].Param = 312;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 33;
            tblSkill.fclSkillTbl[id].Event[6].Param = 185;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 34;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void Sati(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[6].Param = 215;
            tblSkill.fclSkillTbl[id].Event[7].Param = 25;
        }

        private static void Shiva(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 436;
            tblSkill.fclSkillTbl[id].Event[1].Param = 442;
            tblSkill.fclSkillTbl[id].Event[2].Param = 104;
            tblSkill.fclSkillTbl[id].Event[3].Param = 453;
            tblSkill.fclSkillTbl[id].Event[4].Param = 348;
            tblSkill.fclSkillTbl[id].Event[5].Param = 470;
            tblSkill.fclSkillTbl[id].Event[6].Param = 333;
        }

        private static void BeidouXingjun(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[7].Param = 432;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 66;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void QitianDasheng(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][7] = 100; // Dark

            // Skills
            tblSkill.fclSkillTbl[id].Event[1].Param = 362;
        }

        private static void Dionysus(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[4].Param = 426;
        }

        private static void Kali(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 307;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Type = 1;
            tblSkill.fclSkillTbl[id].Event[3].Param = 362;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 68;
            tblSkill.fclSkillTbl[id].Event[3].Type = 1;
            tblSkill.fclSkillTbl[id].Event[4].Param = 6;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[4].Type = 1;
            tblSkill.fclSkillTbl[id].Event[5].Param = 292;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 70;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 105;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 71;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 341;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 72;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Skadi(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 262144; // Ice
            datAisyo.tbl[id][3] = 2147483798; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 67;
            tblSkill.fclSkillTbl[id].Event[3].Param = 67;
            tblSkill.fclSkillTbl[id].Event[4].Param = 341;
            tblSkill.fclSkillTbl[id].Event[5].Param = 341;
            tblSkill.fclSkillTbl[id].Event[6].Param = 155;
            tblSkill.fclSkillTbl[id].Event[7].Param = 155;
            tblSkill.fclSkillTbl[id].Event[8].Param = 468;
            tblSkill.fclSkillTbl[id].Event[9].Param = 468;
            tblSkill.fclSkillTbl[id].Event[10].Param = 310;
            tblSkill.fclSkillTbl[id].Event[10].TargetLevel = 79;
            tblSkill.fclSkillTbl[id].Event[10].Type = 1;
            tblSkill.fclSkillTbl[id].Event[11].Param = 310;
            tblSkill.fclSkillTbl[id].Event[11].TargetLevel = 79;
            tblSkill.fclSkillTbl[id].Event[11].Type = 6;
        }

        private static void Parvati(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 262144; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[7].Param = 195;
            tblSkill.fclSkillTbl[id].Event[8].Param = 195;
            tblSkill.fclSkillTbl[id].Event[9].Param = 218;
            tblSkill.fclSkillTbl[id].Event[10].Param = 218;
        }

        private static void Kushinada(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 2147483798; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 40;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 47;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 90;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 5;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 42;
            tblSkill.fclSkillTbl[id].Event[4].Param = 456;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 43;
            tblSkill.fclSkillTbl[id].Event[5].Param = 353;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 44;
            tblSkill.fclSkillTbl[id].Event[6].Param = 367;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 45;
            tblSkill.fclSkillTbl[id].Event[7].Param = 392;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void KikuriHime(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 37;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 214;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 418;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 46;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 25;
            tblSkill.fclSkillTbl[id].Event[4].Param = 44;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 26;
            tblSkill.fclSkillTbl[id].Event[5].Param = 49;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 27;
            tblSkill.fclSkillTbl[id].Event[6].Param = 365;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 28;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void Bishamonten(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 104;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 304;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 179;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 345;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 73;
            tblSkill.fclSkillTbl[id].Event[4].Param = 309;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 74;
            tblSkill.fclSkillTbl[id].Event[5].Param = 195;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 75;
            tblSkill.fclSkillTbl[id].Event[6].Param = 364;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 76;
            tblSkill.fclSkillTbl[id].Event[7].Param = 458;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 77;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Thor(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 311;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 469;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 100;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 307;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 77;
            tblSkill.fclSkillTbl[id].Event[4].Param = 442;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 78;
            tblSkill.fclSkillTbl[id].Event[5].Param = 457;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 79;
            tblSkill.fclSkillTbl[id].Event[6].Param = 429;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 80;
            tblSkill.fclSkillTbl[id].Event[7].Param = 365;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 81;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Jikokuten(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 106;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 38;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 181;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 77;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 53;
            tblSkill.fclSkillTbl[id].Event[4].Param = 12;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 54;
            tblSkill.fclSkillTbl[id].Event[5].Param = 390;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 55;
            tblSkill.fclSkillTbl[id].Event[6].Param = 424;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 56;
            tblSkill.fclSkillTbl[id].Event[7].Param = 329;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 57;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void TakeMikazuchi(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 15;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 440;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 428;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 410;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[4].Param = 105;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 47;
            tblSkill.fclSkillTbl[id].Event[5].Param = 183;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 48;
            tblSkill.fclSkillTbl[id].Event[6].Param = 349;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 49;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 362;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 50;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Okuninushi(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 110;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 34;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 391;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 3;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 40;
            tblSkill.fclSkillTbl[id].Event[4].Param = 56;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 41;
            tblSkill.fclSkillTbl[id].Event[5].Param = 428;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 42;
            tblSkill.fclSkillTbl[id].Event[6].Param = 223;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 43;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 40;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 44;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Koumokuten(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 103;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 291;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 392;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 430;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 34;
            tblSkill.fclSkillTbl[id].Event[4].Param = 185;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 35;
            tblSkill.fclSkillTbl[id].Event[5].Param = 68;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 36;
            tblSkill.fclSkillTbl[id].Event[6].Param = 428;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 37;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 424;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Zouchouten(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 2147483798; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 2147483798; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 107;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 440;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 30;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 193;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 28;
            tblSkill.fclSkillTbl[id].Event[4].Param = 319;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[5].Param = 99;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 30;
            tblSkill.fclSkillTbl[id].Event[6].Param = 299;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 31;
            tblSkill.fclSkillTbl[id].Event[7].Param = 188;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 32;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void TakeMinakata(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483798; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 65536; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 2147483798; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[5].Param = 427;
        }

        private static void Chimera(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 435;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 309;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 203;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 126;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 56;
            tblSkill.fclSkillTbl[id].Event[4].Param = 178;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 57;
            tblSkill.fclSkillTbl[id].Event[5].Param = 213;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 58;
            tblSkill.fclSkillTbl[id].Event[6].Param = 386;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 59;
            tblSkill.fclSkillTbl[id].Event[7].Param = 116;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 60;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Baihu(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483798; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 65536; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 346;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 120;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 183;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 299;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 44;
            tblSkill.fclSkillTbl[id].Event[4].Param = 15;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 45;
            tblSkill.fclSkillTbl[id].Event[5].Param = 224;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[6].Param = 9;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 47;
            tblSkill.fclSkillTbl[id].Event[7].Param = 126;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 48;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Senri(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 353;
            tblSkill.fclSkillTbl[id].Event[3].Param = 353;
            tblSkill.fclSkillTbl[id].Event[4].Param = 399;
            tblSkill.fclSkillTbl[id].Event[5].Param = 399;
            tblSkill.fclSkillTbl[id].Event[6].Param = 23;
            tblSkill.fclSkillTbl[id].Event[7].Param = 23;
            tblSkill.fclSkillTbl[id].Event[8].Param = 367;
            tblSkill.fclSkillTbl[id].Event[9].Param = 367;
        }

        private static void Zhuque(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 262144; // Fire
            datAisyo.tbl[id][2] = 2147483798; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 75;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 176;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 53;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 49;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 37;
            tblSkill.fclSkillTbl[id].Event[4].Param = 410;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[5].Param = 5;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 39;
            tblSkill.fclSkillTbl[id].Event[6].Param = 17;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 40;
            tblSkill.fclSkillTbl[id].Event[7].Param = 346;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 41;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Shiisaa(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483798; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 65536; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 182;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 123;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 388;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 203;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 14;
            tblSkill.fclSkillTbl[id].Event[4].Param = 121;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 15;
            tblSkill.fclSkillTbl[id].Event[5].Param = 305;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 16;
            tblSkill.fclSkillTbl[id].Event[6].Param = 440;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 17;
            tblSkill.fclSkillTbl[id].Event[7].Param = 314;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 18;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Xiezhai(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 202;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 45;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 97;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 193;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 27;
            tblSkill.fclSkillTbl[id].Event[4].Param = 437;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 28;
            tblSkill.fclSkillTbl[id].Event[5].Param = 47;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[6].Param = 11;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 30;
            tblSkill.fclSkillTbl[id].Event[7].Param = 365;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 31;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Flaemis(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 262144; // Fire
            datAisyo.tbl[id][2] = 2147483798; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind
        }

        private static void Aquans(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483798; // Fire
            datAisyo.tbl[id][2] = 131072; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind
        }

        private static void Aeros(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483798; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 36;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 19;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 59;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 12;
            tblSkill.fclSkillTbl[id].Event[3].Param = 62;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 13;
            tblSkill.fclSkillTbl[id].Event[4].Param = 322;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 14;
            tblSkill.fclSkillTbl[id].Event[5].Param = 113;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 15;
        }

        private static void Erthys(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 2147483798; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 13;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 43;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 66;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 112;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 8;
            tblSkill.fclSkillTbl[id].Event[4].Param = 320;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 9;
            tblSkill.fclSkillTbl[id].Event[5].Param = 410;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 10;
            tblSkill.fclSkillTbl[id].Event[6].Param = 16;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 11;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void SakiMitama(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind
        }

        private static void KushiMitama(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind
        }

        private static void NigiMitama(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind
        }

        private static void AraMitama(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind
        }

        private static void Efreet(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 350;
            tblSkill.fclSkillTbl[id].Event[3].Param = 350;
            tblSkill.fclSkillTbl[id].Event[4].Param = 6;
            tblSkill.fclSkillTbl[id].Event[5].Param = 6;
            tblSkill.fclSkillTbl[id].Event[6].Param = 67;
            tblSkill.fclSkillTbl[id].Event[7].Param = 67;
            tblSkill.fclSkillTbl[id].Event[8].Param = 178;
            tblSkill.fclSkillTbl[id].Event[9].Param = 178;
            tblSkill.fclSkillTbl[id].Event[10].Param = 223;
            tblSkill.fclSkillTbl[id].Event[11].Param = 223;
        }

        private static void Jinn(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 443;
            tblSkill.fclSkillTbl[id].Event[3].Param = 457;
        }

        private static void KarasuTengu(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 131072; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 2147483798; // Curse
            datAisyo.tbl[id][9] = 2147483798; // Nerve
            datAisyo.tbl[id][10] = 2147483798; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 461;
            tblSkill.fclSkillTbl[id].Event[5].Param = 2;
            tblSkill.fclSkillTbl[id].Event[6].Param = 2;
        }

        private static void Dis(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 262144; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 2147483798; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[7].Param = 456;
        }

        private static void Isora(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483798; // Fire
            datAisyo.tbl[id][2] = 65536; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 71;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 118;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 386;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 180;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 15;
            tblSkill.fclSkillTbl[id].Event[4].Param = 210;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 16;
            tblSkill.fclSkillTbl[id].Event[5].Param = 39;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 17;
            tblSkill.fclSkillTbl[id].Event[6].Param = 437;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 18;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void KoppaTengu(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 461;
        }

        private static void Titania(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 452;
        }

        private static void Troll(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][9] = 2147483798; // Nerve

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 397;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 45;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 98;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 181;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 39;
            tblSkill.fclSkillTbl[id].Event[4].Param = 291;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 40;
            tblSkill.fclSkillTbl[id].Event[5].Param = 427;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 41;
            tblSkill.fclSkillTbl[id].Event[6].Param = 76;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 42;
            tblSkill.fclSkillTbl[id].Event[7].Param = 38;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 43;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Setanta(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 99;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 44;
            tblSkill.fclSkillTbl[id].Event[3].Type = 1;
            tblSkill.fclSkillTbl[id].Event[4].Param = 306;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 45;
            tblSkill.fclSkillTbl[id].Event[4].Type = 1;
            tblSkill.fclSkillTbl[id].Event[5].Param = 205;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 391;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 47;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 355;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 48;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
            tblSkill.fclSkillTbl[id].Event[8].Type = 0;
            tblSkill.fclSkillTbl[id].Event[9].Type = 0;
        }

        private static void Kelpie(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 2147483798; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 61;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 410;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 47;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 437;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 27;
            tblSkill.fclSkillTbl[id].Event[4].Param = 121;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 28;
            tblSkill.fclSkillTbl[id].Event[5].Param = 331;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[6].Param = 62;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 30;
            tblSkill.fclSkillTbl[id].Event[7].Param = 457;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 30;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void HighPixie(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[1].Param = 461;
        }

        private static void JackFrost(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 463;
        }

        private static void Pixie(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[6].Param = 461;
        }

        private static void Dominion(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][4] = 50; // Force

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 38;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 29;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 413;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 70;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 51;
            tblSkill.fclSkillTbl[id].Event[4].Param = 67;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 52;
            tblSkill.fclSkillTbl[id].Event[5].Param = 55;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 53;
            tblSkill.fclSkillTbl[id].Event[6].Param = 189;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 54;
            tblSkill.fclSkillTbl[id].Event[7].Param = 218;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 55;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Virtue(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 2147483798; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 2147483798; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 30;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 440;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 40;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 114;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 42;
            tblSkill.fclSkillTbl[id].Event[4].Param = 69;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 43;
            tblSkill.fclSkillTbl[id].Event[5].Param = 17;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 44;
            tblSkill.fclSkillTbl[id].Event[6].Param = 68;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 45;
            tblSkill.fclSkillTbl[id].Event[7].Param = 29;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Power(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 427;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 388;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 64;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 30;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 34;
            tblSkill.fclSkillTbl[id].Event[4].Param = 99;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 35;
            tblSkill.fclSkillTbl[id].Event[5].Param = 193;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 36;
            tblSkill.fclSkillTbl[id].Event[6].Param = 331;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 37;
            tblSkill.fclSkillTbl[id].Event[7].Param = 109;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Principality(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 300;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 20;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 101;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 37;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[4].Param = 435;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 30;
            tblSkill.fclSkillTbl[id].Event[5].Param = 188;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 31;
            tblSkill.fclSkillTbl[id].Event[6].Param = 293;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 32;
        }

        private static void Archangel(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 2147483798; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 2147483798; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 64;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 107;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 413;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 28;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 19;
            tblSkill.fclSkillTbl[id].Event[4].Param = 73;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 20;
            tblSkill.fclSkillTbl[id].Event[5].Param = 101;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 21;
            tblSkill.fclSkillTbl[id].Event[6].Param = 37;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 22;
            tblSkill.fclSkillTbl[id].Event[7].Param = 435;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 23;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Angel(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483798; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 2147483798; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 464;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 28;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 411;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 43;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 12;
            tblSkill.fclSkillTbl[id].Event[4].Param = 48;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 13;
            tblSkill.fclSkillTbl[id].Event[5].Param = 22;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 14;
            tblSkill.fclSkillTbl[id].Event[6].Param = 346;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 15;
        }

        private static void Flauros(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[5].Param = 292;
            tblSkill.fclSkillTbl[id].Event[6].Param = 104;
            tblSkill.fclSkillTbl[id].Event[7].Param = 366;
        }

        private static void Decarabia(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 196;
            tblSkill.fclSkillTbl[id].Event[4].Param = 25;
            tblSkill.fclSkillTbl[id].Event[5].Param = 212;
            tblSkill.fclSkillTbl[id].Event[6].Param = 72;
            tblSkill.fclSkillTbl[id].Event[7].Param = 328;
        }

        private static void Ose(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[5].Param = 224;
            tblSkill.fclSkillTbl[id].Event[6].Param = 313;
            tblSkill.fclSkillTbl[id].Event[7].Param = 69;
        }

        private static void Berith(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 446;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 386;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 101;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 177;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[4].Param = 57;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 39;
            tblSkill.fclSkillTbl[id].Event[5].Param = 309;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 40;
            tblSkill.fclSkillTbl[id].Event[6].Param = 207;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 41;
            tblSkill.fclSkillTbl[id].Event[7].Type = 0;
        }

        private static void Eligor(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 97;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 66;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 32;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 98;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 30;
            tblSkill.fclSkillTbl[id].Event[4].Param = 427;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 31;
            tblSkill.fclSkillTbl[id].Event[5].Param = 301;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 32;
            tblSkill.fclSkillTbl[id].Event[6].Param = 435;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 33;
            tblSkill.fclSkillTbl[id].Event[7].Param = 414;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 34;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Forneus(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[6].Param = 244;
        }

        private static void Yurlungur(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[5].Param = 186;
            tblSkill.fclSkillTbl[id].Event[6].Param = 50;
            tblSkill.fclSkillTbl[id].Event[7].Param = 445;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 75;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Quetzalcoatl(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 120;
            tblSkill.fclSkillTbl[id].Event[1].Param = 98;
            tblSkill.fclSkillTbl[id].Event[2].Param = 181;
            tblSkill.fclSkillTbl[id].Event[3].Param = 202;
            tblSkill.fclSkillTbl[id].Event[4].Param = 310;
            tblSkill.fclSkillTbl[id].Event[5].Param = 335;
            tblSkill.fclSkillTbl[id].Event[6].Param = 51;
            tblSkill.fclSkillTbl[id].Event[7].Param = 432;
        }

        private static void NagaRaja(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 99;
            tblSkill.fclSkillTbl[id].Event[3].Param = 99;
            tblSkill.fclSkillTbl[id].Event[4].Param = 183;
            tblSkill.fclSkillTbl[id].Event[5].Param = 183;
            tblSkill.fclSkillTbl[id].Event[6].Param = 305;
            tblSkill.fclSkillTbl[id].Event[7].Param = 305;
            tblSkill.fclSkillTbl[id].Event[8].Param = 391;
            tblSkill.fclSkillTbl[id].Event[9].Param = 391;
            tblSkill.fclSkillTbl[id].Event[10].Param = 324;
            tblSkill.fclSkillTbl[id].Event[11].Param = 324;

            //datDevilFormat.tbl[id].skill[4] = 367;
            //datDevilFormat.tbl[id].dropmakka = 65000;
        }

        private static void Nozuchi(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483798; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 96;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 90;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 420;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 305;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 15;
            tblSkill.fclSkillTbl[id].Event[3].Type = 1;
            tblSkill.fclSkillTbl[id].Event[4].Param = 202;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 16;
            tblSkill.fclSkillTbl[id].Event[5].Param = 66;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 17;
            tblSkill.fclSkillTbl[id].Event[6].Param = 115;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 18;
        }

        private static void Cerberus(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 122;
            tblSkill.fclSkillTbl[id].Event[4].Param = 465;
            tblSkill.fclSkillTbl[id].Event[7].Param = 411;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 66;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Orthrus(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 262144; // Fire
            datAisyo.tbl[id][2] = 2147483798; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 176;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 125;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 385;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 309;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 35;
            tblSkill.fclSkillTbl[id].Event[4].Param = 203;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 36;
            tblSkill.fclSkillTbl[id].Event[5].Param = 430;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 37;
            tblSkill.fclSkillTbl[id].Event[6].Param = 5;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 122;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 39;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Suparna(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 124;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 55;
            tblSkill.fclSkillTbl[id].Event[5].Param = 462;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 56;
        }

        private static void BadbCatha(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 75;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 111;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 411;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 443;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 24;
            tblSkill.fclSkillTbl[id].Event[4].Param = 317;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 25;
            tblSkill.fclSkillTbl[id].Event[5].Param = 347;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 26;
            tblSkill.fclSkillTbl[id].Event[6].Param = 23;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 27;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void Nekomata(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 2147483798; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 125;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 62;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 47;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 293;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 19;
            tblSkill.fclSkillTbl[id].Event[5].Param = 396;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 20;
            tblSkill.fclSkillTbl[id].Event[6].Param = 198;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 21;
            tblSkill.fclSkillTbl[id].Event[7].Param = 443;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 22;
        }

        private static void Titan(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 392;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 109;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 205;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 427;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 50;
            tblSkill.fclSkillTbl[id].Event[4].Param = 176;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 51;
            tblSkill.fclSkillTbl[id].Event[5].Param = 292;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 52;
            tblSkill.fclSkillTbl[id].Event[6].Param = 306;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 53;
            tblSkill.fclSkillTbl[id].Event[7].Param = 209;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 54;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Sarutahiko(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 2147483798; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 98;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 76;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 409;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 48;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 36;
            tblSkill.fclSkillTbl[id].Event[4].Param = 305;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 37;
            tblSkill.fclSkillTbl[id].Event[5].Param = 224;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[6].Param = 97;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 39;
        }

        private static void Oni(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483798; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 2147483798; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[7].Param = 428;
        }

        private static void YomotsuIkusa(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 2147483798; // Force
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 114;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 48;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 71;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 397;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 45;
            tblSkill.fclSkillTbl[id].Event[4].Param = 107;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[5].Param = 448;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 47;
            tblSkill.fclSkillTbl[id].Event[6].Param = 33;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 48;
            tblSkill.fclSkillTbl[id].Event[7].Param = 390;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 49;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Momunofu(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 2147483798; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 2147483798; // Curse
            datAisyo.tbl[id][9] = 2147483798; // Nerve
            datAisyo.tbl[id][10] = 2147483798; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 96;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 413;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 224;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 21;
            tblSkill.fclSkillTbl[id].Event[4].Param = 290;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 22;
            tblSkill.fclSkillTbl[id].Event[5].Param = 107;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 23;
            tblSkill.fclSkillTbl[id].Event[6].Param = 116;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 24;
        }

        private static void Shikigami(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483798; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 65536; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind
        }

        private static void Rangda(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 350;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 73;
            tblSkill.fclSkillTbl[id].Event[4].Param = 178;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 74;
            tblSkill.fclSkillTbl[id].Event[5].Param = 434;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 75;
            tblSkill.fclSkillTbl[id].Event[6].Param = 56;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 76;
            tblSkill.fclSkillTbl[id].Event[7].Param = 445;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 77;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Dakini(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 207;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 346;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 34;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 102;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 53;
            tblSkill.fclSkillTbl[id].Event[4].Param = 3;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 54;
            tblSkill.fclSkillTbl[id].Event[5].Param = 345;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 55;
            tblSkill.fclSkillTbl[id].Event[6].Param = 105;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 56;
            tblSkill.fclSkillTbl[id].Event[7].Param = 386;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 57;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }


        private static void Yaksini(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 386;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 109;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 74;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 21;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 44;
            tblSkill.fclSkillTbl[id].Event[4].Param = 211;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 45;
            tblSkill.fclSkillTbl[id].Event[5].Param = 325;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[6].Param = 63;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 47;
            tblSkill.fclSkillTbl[id].Event[7].Param = 306;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 48;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void YomotsuShikome(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 401;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 197;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 23;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 319;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 33;
            tblSkill.fclSkillTbl[id].Event[4].Param = 213;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 34;
            tblSkill.fclSkillTbl[id].Event[5].Param = 112;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 35;
            tblSkill.fclSkillTbl[id].Event[6].Param = 448;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 36;
            tblSkill.fclSkillTbl[id].Event[7].Param = 302;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 37;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Taraka(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 2147483798; // Ice
            datAisyo.tbl[id][3] = 65536; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 59;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 66;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 71;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 205;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 21;
            tblSkill.fclSkillTbl[id].Event[4].Param = 392;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 22;
            tblSkill.fclSkillTbl[id].Event[5].Param = 116;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 23;
            tblSkill.fclSkillTbl[id].Event[6].Param = 14;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 24;
            tblSkill.fclSkillTbl[id].Event[7].Param = 101;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 25;
        }

        private static void DatsueBa(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 2147483798; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 111;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 59;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 7;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 409;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 8;
            tblSkill.fclSkillTbl[id].Event[4].Param = 43;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 9;
            tblSkill.fclSkillTbl[id].Event[5].Param = 55;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 10;
            tblSkill.fclSkillTbl[id].Event[6].Param = 60;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 11;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void Mada(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[4].Param = 459;
            tblSkill.fclSkillTbl[id].Event[5].Param = 365;
            tblSkill.fclSkillTbl[id].Event[6].Param = 292;
            tblSkill.fclSkillTbl[id].Event[7].Param = 38;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 88;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Girimekhala(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][6] = 2147483798; // Light
            datAisyo.tbl[id][10] = 2147483798; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[4].Param = 450;
            tblSkill.fclSkillTbl[id].Event[5].Param = 450;
            tblSkill.fclSkillTbl[id].Event[8].Param = 102;
            tblSkill.fclSkillTbl[id].Event[9].Param = 102;
            tblSkill.fclSkillTbl[id].Event[10].Param = 105;
            tblSkill.fclSkillTbl[id].Event[10].TargetLevel = 63;
            tblSkill.fclSkillTbl[id].Event[10].Type = 1;
            tblSkill.fclSkillTbl[id].Event[11].Param = 105;
            tblSkill.fclSkillTbl[id].Event[11].TargetLevel = 63;
            tblSkill.fclSkillTbl[id].Event[11].Type = 6;
        }

        private static void Taotie(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 25;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 68;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 192;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 367;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 66;
            tblSkill.fclSkillTbl[id].Event[4].Param = 196;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 67;
            tblSkill.fclSkillTbl[id].Event[5].Param = 330;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 68;
            tblSkill.fclSkillTbl[id].Event[6].Param = 401;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[7].Param = 26;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 70;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Pazuzu(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 2147483798; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 196;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 185;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 414;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 327;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[4].Param = 40;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 47;
            tblSkill.fclSkillTbl[id].Event[5].Param = 114;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 48;
            tblSkill.fclSkillTbl[id].Event[6].Param = 63;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 49;
            tblSkill.fclSkillTbl[id].Event[7].Param = 187;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 50;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Baphomet(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 67;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 223;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 390;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 5;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 34;
            tblSkill.fclSkillTbl[id].Event[4].Param = 446;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 35;
            tblSkill.fclSkillTbl[id].Event[5].Param = 207;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 36;
            tblSkill.fclSkillTbl[id].Event[6].Param = 293;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 37;
            tblSkill.fclSkillTbl[id].Event[7].Param = 424;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Mot(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483798; // Elec
            datAisyo.tbl[id][4] = 131072; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 131072; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 363;
            tblSkill.fclSkillTbl[id].Event[4].Param = 27;
            tblSkill.fclSkillTbl[id].Event[5].Param = 364;
            tblSkill.fclSkillTbl[id].Event[6].Param = 223;
            tblSkill.fclSkillTbl[id].Event[7].Param = 445;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 96;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Aciel(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 2147483798; // Phys
            datAisyo.tbl[id][1] = 65536; // Fire
            datAisyo.tbl[id][2] = 65536; // Ice
            datAisyo.tbl[id][3] = 65536; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 2147483798; // Light
            datAisyo.tbl[id][7] = 131072; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[4].Param = 208;
            tblSkill.fclSkillTbl[id].Event[5].Param = 208;
            tblSkill.fclSkillTbl[id].Event[6].Param = 70;
            tblSkill.fclSkillTbl[id].Event[7].Param = 70;
            tblSkill.fclSkillTbl[id].Event[8].Param = 122;
            tblSkill.fclSkillTbl[id].Event[9].Param = 122;
            tblSkill.fclSkillTbl[id].Event[10].Param = 348;
            tblSkill.fclSkillTbl[id].Event[10].TargetLevel = 82;
            tblSkill.fclSkillTbl[id].Event[10].Type = 1;
            tblSkill.fclSkillTbl[id].Event[11].Param = 348;
            tblSkill.fclSkillTbl[id].Event[11].TargetLevel = 82;
            tblSkill.fclSkillTbl[id].Event[11].Type = 6;
        }

        private static void Surt(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][8] = 65536; // Curse

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 178;
            tblSkill.fclSkillTbl[id].Event[1].Param = 368;
            tblSkill.fclSkillTbl[id].Event[3].Param = 203;
            tblSkill.fclSkillTbl[id].Event[4].Param = 336;
            tblSkill.fclSkillTbl[id].Event[5].Param = 436;
            tblSkill.fclSkillTbl[id].Event[6].Param = 304;
            tblSkill.fclSkillTbl[id].Event[7].Param = 391;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 79;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Abaddon(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 2147483798; // Light
            datAisyo.tbl[id][7] = 131072; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[5].Param = 100;
            tblSkill.fclSkillTbl[id].Event[6].Param = 307;
            tblSkill.fclSkillTbl[id].Event[7].Param = 340;
        }

        private static void Loki(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 12;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 56;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 437;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 394;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 53;
            tblSkill.fclSkillTbl[id].Event[4].Param = 355;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 54;
            tblSkill.fclSkillTbl[id].Event[5].Param = 325;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 55;
            tblSkill.fclSkillTbl[id].Event[6].Param = 72;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 56;
            tblSkill.fclSkillTbl[id].Event[7].Param = 33;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 57;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Lilith(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 441;
            tblSkill.fclSkillTbl[id].Event[4].Param = 441;
            tblSkill.fclSkillTbl[id].Event[5].Param = 455;
            tblSkill.fclSkillTbl[id].Event[6].Param = 455;
            tblSkill.fclSkillTbl[id].Event[7].Param = 122;
            tblSkill.fclSkillTbl[id].Event[8].Param = 122;
            tblSkill.fclSkillTbl[id].Event[9].Param = 295;
            tblSkill.fclSkillTbl[id].Event[10].Param = 295;
            tblSkill.fclSkillTbl[id].Event[11].Param = 27;
            tblSkill.fclSkillTbl[id].Event[11].TargetLevel = 85;
            tblSkill.fclSkillTbl[id].Event[11].Type = 1;
            tblSkill.fclSkillTbl[id].Event[12].Param = 27;
            tblSkill.fclSkillTbl[id].Event[12].TargetLevel = 85;
            tblSkill.fclSkillTbl[id].Event[12].Type = 6;
        }

        private static void Nyx(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[4].Param = 181;
            tblSkill.fclSkillTbl[id].Event[5].Param = 455;
            tblSkill.fclSkillTbl[id].Event[6].Param = 334;
            tblSkill.fclSkillTbl[id].Event[7].Param = 26;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 74;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void QueenMab(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 41;
            tblSkill.fclSkillTbl[id].Event[4].Param = 41;
            tblSkill.fclSkillTbl[id].Event[5].Param = 18;
            tblSkill.fclSkillTbl[id].Event[6].Param = 18;
            tblSkill.fclSkillTbl[id].Event[7].Param = 69;
            tblSkill.fclSkillTbl[id].Event[8].Param = 69;
            tblSkill.fclSkillTbl[id].Event[9].Param = 424;
            tblSkill.fclSkillTbl[id].Event[10].Param = 424;
            tblSkill.fclSkillTbl[id].Event[11].Param = 452;
            tblSkill.fclSkillTbl[id].Event[12].Param = 452;
        }

        private static void Succubus(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483798; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind
        }

        private static void Incubus(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 2147483798; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 420;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 214;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 461;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 125;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 26;
            tblSkill.fclSkillTbl[id].Event[4].Param = 391;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 27;
            tblSkill.fclSkillTbl[id].Event[5].Param = 199;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 28;
            tblSkill.fclSkillTbl[id].Event[6].Param = 192;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[7].Param = 23;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 30;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Fomorian(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 7;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 210;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 96;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 98;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 19;
            tblSkill.fclSkillTbl[id].Event[4].Param = 290;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 20;
            tblSkill.fclSkillTbl[id].Event[5].Param = 386;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 21;
            tblSkill.fclSkillTbl[id].Event[6].Param = 10;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 22;
        }

        private static void Lilim(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 2147483798; // Ice
            datAisyo.tbl[id][3] = 65536; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 54;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 214;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 71;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 61;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 9;
            tblSkill.fclSkillTbl[id].Event[3].Type = 1;
            tblSkill.fclSkillTbl[id].Event[4].Param = 390;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 10;
            tblSkill.fclSkillTbl[id].Event[5].Param = 52;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 11;
            tblSkill.fclSkillTbl[id].Event[6].Param = 16;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 12;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void Hresvelgr(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 2147483798; // Fire
            datAisyo.tbl[id][2] = 131072; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 462;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 126;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 76;
            tblSkill.fclSkillTbl[id].Event[4].Param = 323;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 77;
            tblSkill.fclSkillTbl[id].Event[5].Param = 349;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 78;
            tblSkill.fclSkillTbl[id].Event[6].Param = 365;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 79;
            tblSkill.fclSkillTbl[id].Event[7].Param = 341;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 80;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Mothman(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][8] = 65536; // Curse

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 199;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 125;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 216;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 72;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 44;
            tblSkill.fclSkillTbl[id].Event[4].Param = 177;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 45;
            tblSkill.fclSkillTbl[id].Event[5].Param = 450;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[6].Param = 326;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 47;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 452;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 48;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Raiju(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 14;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 76;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 440;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 123;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 26;
            tblSkill.fclSkillTbl[id].Event[4].Param = 182;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 27;
            tblSkill.fclSkillTbl[id].Event[5].Param = 111;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 28;
            tblSkill.fclSkillTbl[id].Event[6].Param = 311;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void Nue(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 125;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 203;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 180;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 437;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 32;
            tblSkill.fclSkillTbl[id].Event[4].Param = 216;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 33;
            tblSkill.fclSkillTbl[id].Event[5].Param = 310;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 34;
            tblSkill.fclSkillTbl[id].Event[6].Param = 34;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 35;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void Zhen(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483798; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 209;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 46;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 19;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 113;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 7;
            tblSkill.fclSkillTbl[id].Event[4].Param = 90;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 8;
            tblSkill.fclSkillTbl[id].Event[5].Param = 461;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 9;
            tblSkill.fclSkillTbl[id].Event[6].Param = 203;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 10;
            tblSkill.fclSkillTbl[id].Event[7].Param = 331;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 11;
        }

        private static void Vetala(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 125;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 192;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 449;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 115;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 64;
            tblSkill.fclSkillTbl[id].Event[4].Param = 306;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 65;
            tblSkill.fclSkillTbl[id].Event[5].Param = 202;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 66;
            tblSkill.fclSkillTbl[id].Event[6].Param = 25;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 67;
            tblSkill.fclSkillTbl[id].Event[7].Param = 434;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 68;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Legion(ushort id)
        {
            tblSkill.fclSkillTbl[id].Event[5].Param = 452;
        }

        private static void Yaka(ushort id)
        {
            tblSkill.fclSkillTbl[id].Event[2].Param = 34;
        }

        private static void Choronzon(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 65536; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 2147483798; // Force
            datAisyo.tbl[id][6] = 2147483798; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind
        }

        private static void Preta(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483798; // Fire
            datAisyo.tbl[id][2] = 2147483798; // Ice
            datAisyo.tbl[id][3] = 2147483798; // Elec
            datAisyo.tbl[id][4] = 2147483798; // Force
            datAisyo.tbl[id][6] = 2147483798; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 123;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 165;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 190;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 5;
            tblSkill.fclSkillTbl[id].Event[3].Param = 124;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 6;
            tblSkill.fclSkillTbl[id].Event[4].Param = 32;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 7;
            tblSkill.fclSkillTbl[id].Event[5].Param = 204;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 8;
        }

        private static void Shadow(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 18;
        }

        private static void BlackOoze(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483798; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483798; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 198;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 119;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 190;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 448;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[4].Param = 115;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 30;
            tblSkill.fclSkillTbl[id].Event[5].Param = 191;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 31;
            tblSkill.fclSkillTbl[id].Event[6].Param = 216;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 32;
            tblSkill.fclSkillTbl[id].Event[7].Param = 318;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 33;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Blob(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 2147483798; // Fire
            datAisyo.tbl[id][2] = 2147483798; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483798; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind
        }

        private static void Slime(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 2147483798; // Fire
            datAisyo.tbl[id][2] = 2147483798; // Ice
            datAisyo.tbl[id][3] = 2147483798; // Elec
            datAisyo.tbl[id][4] = 2147483798; // Force
            datAisyo.tbl[id][6] = 2147483798; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 190;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 117;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 202;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 7;
            tblSkill.fclSkillTbl[id].Event[3].Param = 118;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 8;
            tblSkill.fclSkillTbl[id].Event[4].Param = 152;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 9;
            tblSkill.fclSkillTbl[id].Event[5].Param = 213;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 10;
        }

        private static void MouRyo(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483798; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 61;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 113;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 32;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 1;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 8;
            tblSkill.fclSkillTbl[id].Event[4].Param = 190;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 9;
            tblSkill.fclSkillTbl[id].Event[5].Param = 347;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 10;
            tblSkill.fclSkillTbl[id].Event[6].Param = 4;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 11;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void WillOWisp(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 2147483798; // Fire
            datAisyo.tbl[id][2] = 2147483798; // Ice
            datAisyo.tbl[id][3] = 2147483798; // Elec
            datAisyo.tbl[id][4] = 2147483798; // Force
            datAisyo.tbl[id][6] = 2147483798; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind
        }

        private static void Michael(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 362;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 348;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 91;
            tblSkill.fclSkillTbl[id].Event[4].Param = 459;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 92;
            tblSkill.fclSkillTbl[id].Event[5].Param = 467;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 93;
            tblSkill.fclSkillTbl[id].Event[6].Param = 295;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 94;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 27;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 95;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Gabriel(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 131072; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[1].Param = 439;
            tblSkill.fclSkillTbl[id].Event[2].Param = 424;
            tblSkill.fclSkillTbl[id].Event[3].Param = 426;
            tblSkill.fclSkillTbl[id].Event[4].Param = 459;
            tblSkill.fclSkillTbl[id].Event[5].Param = 195;
            tblSkill.fclSkillTbl[id].Event[6].Param = 363;
            tblSkill.fclSkillTbl[id].Event[7].Param = 413;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 92;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Raphael(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 131072; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 462;
            tblSkill.fclSkillTbl[id].Event[2].Param = 106;
            tblSkill.fclSkillTbl[id].Event[3].Param = 31;
            tblSkill.fclSkillTbl[id].Event[4].Param = 218;
            tblSkill.fclSkillTbl[id].Event[5].Param = 366;
            tblSkill.fclSkillTbl[id].Event[6].Param = 350;
            tblSkill.fclSkillTbl[id].Event[7].Param = 189;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 89;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Uriel(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 131072; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 431;
            tblSkill.fclSkillTbl[id].Event[1].Param = 179;
            tblSkill.fclSkillTbl[id].Event[2].Param = 26;
            tblSkill.fclSkillTbl[id].Event[3].Param = 195;
            tblSkill.fclSkillTbl[id].Event[4].Param = 458;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 78;
            tblSkill.fclSkillTbl[id].Event[4].Type = 6;
        }

        private static void Ganesha(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 362;
            tblSkill.fclSkillTbl[id].Event[1].Param = 323;
            tblSkill.fclSkillTbl[id].Event[2].Param = 459;
            tblSkill.fclSkillTbl[id].Event[3].Param = 155;
            tblSkill.fclSkillTbl[id].Event[4].Param = 337;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 63;
            tblSkill.fclSkillTbl[id].Event[4].Type = 6;
            tblSkill.fclSkillTbl[id].Event[5].Param = 365;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 64;
            tblSkill.fclSkillTbl[id].Event[5].Type = 6;
        }

        private static void Valkyrie(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 305;
            tblSkill.fclSkillTbl[id].Event[3].Param = 305;
            tblSkill.fclSkillTbl[id].Event[4].Param = 393;
            tblSkill.fclSkillTbl[id].Event[5].Param = 393;
            tblSkill.fclSkillTbl[id].Event[6].Param = 109;
            tblSkill.fclSkillTbl[id].Event[7].Param = 109;
            tblSkill.fclSkillTbl[id].Event[8].Param = 299;
            tblSkill.fclSkillTbl[id].Event[9].Param = 299;
            tblSkill.fclSkillTbl[id].Event[10].Param = 362;
            tblSkill.fclSkillTbl[id].Event[10].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[10].Type = 1;
            tblSkill.fclSkillTbl[id].Event[11].Param = 362;
            tblSkill.fclSkillTbl[id].Event[11].TargetLevel = 39;
            tblSkill.fclSkillTbl[id].Event[11].Type = 6;
        }

        private static void Arahabaki(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 65536; // Phys
            datAisyo.tbl[id][1] = 2147483798; // Fire
            datAisyo.tbl[id][2] = 2147483798; // Ice
            datAisyo.tbl[id][3] = 2147483798; // Elec
            datAisyo.tbl[id][4] = 2147483798; // Force
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 2147483798; // Curse
            datAisyo.tbl[id][9] = 2147483798; // Nerve
            datAisyo.tbl[id][10] = 2147483798; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 197;
            tblSkill.fclSkillTbl[id].Event[3].Param = 197;
            tblSkill.fclSkillTbl[id].Event[4].Param = 446;
            tblSkill.fclSkillTbl[id].Event[5].Param = 446;
            tblSkill.fclSkillTbl[id].Event[6].Param = 216;
            tblSkill.fclSkillTbl[id].Event[7].Param = 216;
            tblSkill.fclSkillTbl[id].Event[8].Param = 25;
            tblSkill.fclSkillTbl[id].Event[9].Param = 25;
            tblSkill.fclSkillTbl[id].Event[10].Param = 365;
            tblSkill.fclSkillTbl[id].Event[11].Param = 365;
        }

        private static void KuramaTengu(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 21;
        }

        private static void CuChulainn(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys

            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 21;
            tblSkill.fclSkillTbl[id].Event[4].Param = 21;
            tblSkill.fclSkillTbl[id].Event[5].Param = 426;
            tblSkill.fclSkillTbl[id].Event[6].Param = 426;
            tblSkill.fclSkillTbl[id].Event[7].Param = 362;
            tblSkill.fclSkillTbl[id].Event[8].Param = 362;
            tblSkill.fclSkillTbl[id].Event[9].Param = 304;
            tblSkill.fclSkillTbl[id].Event[10].Param = 304;
            tblSkill.fclSkillTbl[id].Event[11].Param = 108;
            tblSkill.fclSkillTbl[id].Event[12].Param = 108;
        }

        private static void QingLong(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483798; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 2147483798; // Elec
            datAisyo.tbl[id][4] = 262144; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 185;
            tblSkill.fclSkillTbl[id].Event[4].Param = 185;
            tblSkill.fclSkillTbl[id].Event[5].Param = 120;
            tblSkill.fclSkillTbl[id].Event[6].Param = 120;
            tblSkill.fclSkillTbl[id].Event[7].Param = 181;
            tblSkill.fclSkillTbl[id].Event[8].Param = 181;
            tblSkill.fclSkillTbl[id].Event[9].Param = 291;
            tblSkill.fclSkillTbl[id].Event[10].Param = 291;
            tblSkill.fclSkillTbl[id].Event[11].Param = 29;
            tblSkill.fclSkillTbl[id].Event[11].TargetLevel = 49;
            tblSkill.fclSkillTbl[id].Event[11].Type = 1;
            tblSkill.fclSkillTbl[id].Event[12].Param = 29;
            tblSkill.fclSkillTbl[id].Event[12].TargetLevel = 49;
            tblSkill.fclSkillTbl[id].Event[12].Type = 6;
        }

        private static void Xuanwu(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 262144; // Ice
            datAisyo.tbl[id][3] = 2147483798; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[10].Param = 430;
            tblSkill.fclSkillTbl[id].Event[10].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[10].Type = 1;
            tblSkill.fclSkillTbl[id].Event[11].Param = 430;
            tblSkill.fclSkillTbl[id].Event[11].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[11].Type = 6;
        }

        private static void Barong(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][2] = 50; // Ice

            // Skills
            tblSkill.fclSkillTbl[id].Event[6].Param = 413;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 65;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void Garuda(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][4] = 131072; // Force
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 31;
            tblSkill.fclSkillTbl[id].Event[1].Param = 186;
            tblSkill.fclSkillTbl[id].Event[2].Param = 345;
            tblSkill.fclSkillTbl[id].Event[3].Param = 126;
        }

        private static void Yatagarasu(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[1].Param = 29;
            tblSkill.fclSkillTbl[id].Event[2].Param = 21;
            tblSkill.fclSkillTbl[id].Event[6].Param = 444;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 51;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void Gurulu(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][4] = 131072; // Force
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[5].Param = 183;
            tblSkill.fclSkillTbl[id].Event[6].Param = 183;
            tblSkill.fclSkillTbl[id].Event[7].Param = 326;
            tblSkill.fclSkillTbl[id].Event[8].Param = 326;
            tblSkill.fclSkillTbl[id].Event[9].Param = 186;
            tblSkill.fclSkillTbl[id].Event[10].Param = 186;
            tblSkill.fclSkillTbl[id].Event[11].Param = 307;
            tblSkill.fclSkillTbl[id].Event[12].Param = 307;
        }

        private static void Albion(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][1] = 80; // Fire
            datAisyo.tbl[id][2] = 80; // Ice
            datAisyo.tbl[id][3] = 80; // Elec
            datAisyo.tbl[id][4] = 80; // Force

            // Skills
            tblSkill.fclSkillTbl[id].Event[4].Param = 100;
            tblSkill.fclSkillTbl[id].Event[5].Param = 100;
            tblSkill.fclSkillTbl[id].Event[6].Param = 333;
            tblSkill.fclSkillTbl[id].Event[7].Param = 333;
            tblSkill.fclSkillTbl[id].Event[8].Param = 106;
            tblSkill.fclSkillTbl[id].Event[9].Param = 106;
            tblSkill.fclSkillTbl[id].Event[10].Param = 51;
            tblSkill.fclSkillTbl[id].Event[10].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[10].Type = 1;
            tblSkill.fclSkillTbl[id].Event[11].Param = 51;
            tblSkill.fclSkillTbl[id].Event[11].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[11].Type = 6;
        }

        private static void Samael(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483798; // Light
            datAisyo.tbl[id][7] = 131072; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 432;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[6].Param = 242;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 77;
            tblSkill.fclSkillTbl[id].Event[7].Param = 338;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 78;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Pisaca(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 90;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 53;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 209;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 440;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[4].Param = 192;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 30;
            tblSkill.fclSkillTbl[id].Event[5].Param = 213;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 31;
            tblSkill.fclSkillTbl[id].Event[6].Param = 77;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 32;
            tblSkill.fclSkillTbl[id].Event[7].Param = 17;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 33;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Kaiwan(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[6].Param = 447;
        }

        private static void KinKi(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 10; // Phys
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 99;
            tblSkill.fclSkillTbl[id].Event[4].Param = 205;
            tblSkill.fclSkillTbl[id].Event[5].Param = 434;
            tblSkill.fclSkillTbl[id].Event[6].Param = 323;
            tblSkill.fclSkillTbl[id].Event[7].Param = 433;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 64;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void SuiKi(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 426;
            tblSkill.fclSkillTbl[id].Event[4].Param = 199;
            tblSkill.fclSkillTbl[id].Event[5].Param = 9;
            tblSkill.fclSkillTbl[id].Event[6].Param = 346;
            tblSkill.fclSkillTbl[id].Event[7].Param = 385;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 67;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void FuuKi(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][3] = 2147483798; // Elec
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[7].Param = 429;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 67;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void OngyoKi(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 105;
            tblSkill.fclSkillTbl[id].Event[1].Param = 33;
            tblSkill.fclSkillTbl[id].Event[2].Param = 26;
            tblSkill.fclSkillTbl[id].Event[3].Param = 432;
            tblSkill.fclSkillTbl[id].Event[4].Param = 362;
            tblSkill.fclSkillTbl[id].Event[5].Param = 223;
            tblSkill.fclSkillTbl[id].Event[6].Param = 458;
            tblSkill.fclSkillTbl[id].Event[7].Param = 348;
        }

        private static void Clotho(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[1].Param = 31;
            tblSkill.fclSkillTbl[id].Event[3].Param = 41;
            tblSkill.fclSkillTbl[id].Event[4].Param = 215;
            tblSkill.fclSkillTbl[id].Event[5].Param = 50;
            tblSkill.fclSkillTbl[id].Event[6].Param = 25;
            tblSkill.fclSkillTbl[id].Event[7].Param = 212;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 63;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Lachesis(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 50; // Dark

            // Skills
            tblSkill.fclSkillTbl[id].Event[4].Param = 70;
            tblSkill.fclSkillTbl[id].Event[5].Param = 206;
            tblSkill.fclSkillTbl[id].Event[6].Param = 304;
            tblSkill.fclSkillTbl[id].Event[7].Param = 72;
        }

        private static void Atropos(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 3;
            tblSkill.fclSkillTbl[id].Event[4].Param = 295;
            tblSkill.fclSkillTbl[id].Event[5].Param = 26;
            tblSkill.fclSkillTbl[id].Event[6].Param = 363;
            tblSkill.fclSkillTbl[id].Event[7].Param = 0;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[7].Type = 0;
        }

        private static void Loa(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 34;
            tblSkill.fclSkillTbl[id].Event[1].Param = 68;
            tblSkill.fclSkillTbl[id].Event[2].Param = 77;
            tblSkill.fclSkillTbl[id].Event[3].Param = 448;
            tblSkill.fclSkillTbl[id].Event[4].Param = 35;
            tblSkill.fclSkillTbl[id].Event[5].Param = 451;
            tblSkill.fclSkillTbl[id].Event[6].Param = 206;
            tblSkill.fclSkillTbl[id].Event[7].Param = 152;
        }

        private static void Phantom(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 2147483798; // Force
            datAisyo.tbl[id][6] = 2147483798; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind
        }

        private static void DanteRaidou(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind
        }

        private static void Metatron(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 65536; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 262144; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[1].Param = 6;
            tblSkill.fclSkillTbl[id].Event[2].Param = 431;
            tblSkill.fclSkillTbl[id].Event[3].Param = 27;
            tblSkill.fclSkillTbl[id].Event[5].Param = 458;
        }

        private static void BeelzebubFly(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 262144; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[1].Param = 24;
            tblSkill.fclSkillTbl[id].Event[6].Param = 462;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 98;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 462;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 98;
            tblSkill.fclSkillTbl[id].Event[7].Type = 6;
            tblSkill.fclSkillTbl[id].Event[8].Param = 442;
            tblSkill.fclSkillTbl[id].Event[8].TargetLevel = 99;
            tblSkill.fclSkillTbl[id].Event[8].Type = 1;
            tblSkill.fclSkillTbl[id].Event[9].Param = 442;
            tblSkill.fclSkillTbl[id].Event[9].TargetLevel = 99;
            tblSkill.fclSkillTbl[id].Event[9].Type = 6;
        }

        private static void PaleRider(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 131072; // Force
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 131072; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 79;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 63;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 102;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 212;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 64;
            tblSkill.fclSkillTbl[id].Event[4].Param = 449;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 65;
            tblSkill.fclSkillTbl[id].Event[5].Param = 451;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 66;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 206;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 67;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 431;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 68;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void WhiteRider(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 65536; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 287;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 68;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 31;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 178;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 53;
            tblSkill.fclSkillTbl[id].Event[4].Param = 57;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 54;
            tblSkill.fclSkillTbl[id].Event[5].Param = 347;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 55;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 323;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 56;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 179;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 57;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void RedRider(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 65536; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 280;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 183;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 77;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 64;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 56;
            tblSkill.fclSkillTbl[id].Event[4].Param = 428;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 57;
            tblSkill.fclSkillTbl[id].Event[5].Param = 451;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 58;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 307;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 59;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 186;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 60;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void BlackRider(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 262144; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 261;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 181;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 192;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 65;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 62;
            tblSkill.fclSkillTbl[id].Event[4].Param = 35;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 63;
            tblSkill.fclSkillTbl[id].Event[5].Param = 26;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 64;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 295;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 65;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 439;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 66;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Matador(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 443;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 275;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 224;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 77;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 31;
            tblSkill.fclSkillTbl[id].Event[4].Param = 205;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 32;
            tblSkill.fclSkillTbl[id].Event[5].Param = 276;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 33;
            tblSkill.fclSkillTbl[id].Event[6].Param = 349;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 34;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 306;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 35;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void HellBiker(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 65536; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 281;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 282;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 435;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 97;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 43;
            tblSkill.fclSkillTbl[id].Event[4].Param = 283;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 44;
            tblSkill.fclSkillTbl[id].Event[4].Type = 1;
            tblSkill.fclSkillTbl[id].Event[5].Param = 284;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 45;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 309;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 292;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 47;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Daisoujou(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 262144; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 262144; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 279;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 30;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 67;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 34;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[4].Param = 424;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 39;
            tblSkill.fclSkillTbl[id].Event[5].Param = 278;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 40;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 457;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 41;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 331;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 42;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void MotherHarlot(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills

            tblSkill.fclSkillTbl[id].Event[5].Param = 441;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 72;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 451;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 73;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 286;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 74;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Trumpeter(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills

            tblSkill.fclSkillTbl[id].Event[5].Param = 458;
            tblSkill.fclSkillTbl[id].Event[6].Param = 57;
            tblSkill.fclSkillTbl[id].Event[7].Param = 453;
            tblSkill.fclSkillTbl[id].Event[8].Param = 27;
            tblSkill.fclSkillTbl[id].Event[9].Param = 159;
            tblSkill.fclSkillTbl[id].Event[9].TargetLevel = 82;
            tblSkill.fclSkillTbl[id].Event[9].Type = 1;
        }

        private static void BlackFrost(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 262144; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483798; // Light
            datAisyo.tbl[id][7] = 65536; // Dark

            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 205;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 466;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 67;
            tblSkill.fclSkillTbl[id].Event[4].Param = 434;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 68;
            tblSkill.fclSkillTbl[id].Event[5].Param = 6;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[6].Param = 365;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 70;
            tblSkill.fclSkillTbl[id].Event[7].Param = 438;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 71;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void BeelzebubMan(ushort id)
        {
            datDevilFormat.tbl[id].aisyoid = (short) id;

            // Affinties
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 262144; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[1].Param = 24;
            tblSkill.fclSkillTbl[id].Event[2].Param = 27;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Type = 1;
            tblSkill.fclSkillTbl[id].Event[3].Param = 354;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 85;
            tblSkill.fclSkillTbl[id].Event[3].Type = 1;
            tblSkill.fclSkillTbl[id].Event[4].Param = 0;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 85;
            tblSkill.fclSkillTbl[id].Event[4].Type = 7;
            tblSkill.fclSkillTbl[id].Event[5].Param = 311;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 86;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 194;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 86;
            tblSkill.fclSkillTbl[id].Event[6].Type = 5;
        }

        // 2148532374 = Weak but status-immune

        private static void BossForneus(ushort id)
        {
            // Stats
            datDevilFormat.tbl[id].maxhp = 800;
            datDevilFormat.tbl[id].hp = 800;
            datDevilAI.divTbls[2][0].ailevel = 0;

            // Affinities
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