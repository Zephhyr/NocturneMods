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
                        __result = "Null: Light/Dark/Curse/Mind"; return false;
                    case "<AISYO_L0202>": // Mother Harlot
                        __result = "Rpl: Phys • Drn: Elec • Str: Light/Dark/Ailments"; return false;
                    case "<AISYO_L0203>": // Trumpeter
                        __result = "Null: Light/Dark/Ailments • Str: Magic"; return false;
                    case "<AISYO_L0206>": // Black Frost
                        __result = "Drn: Ice • Null: Dark • Str: Phys/Fire • Weak: Light"; return false;
                    case "<AISYO_L0207>": // Beelzebub (Man)
                        __result = "Drn: Elec • Null: Dark/Ailments • Str: Ice/Force"; return false;
                    case "<AISYO_L00316>": // Forced Nekomata
                        __result = "Null: Force • Str: Fire • Weak: Ice"; return false;
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
            // Negotiation Items
            foreach (var itemSet in datDevilNegoFormat.tbl)
            {
                itemSet.itema[0].ritu = 40;
                itemSet.itema[1].ritu = 30;
                itemSet.itema[2].ritu = 20;
                itemSet.itema[3].ritu = 10;

                itemSet.itemb[0].ritu = 40;
                itemSet.itemb[1].ritu = 30;
                itemSet.itemb[2].ritu = 20;
                itemSet.itemb[3].ritu = 10;

                itemSet.stone[0].ritu = 40;
                itemSet.stone[1].ritu = 30;
                itemSet.stone[2].ritu = 20;
                itemSet.stone[3].ritu = 10;
            }

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
            AmeNoUzume(11);

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
            Apsaras(51);
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
            HuaPo(91);
            Kodama(92);

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
            Chatterskull(177);

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
            BossSpecter1(257);

            BossSpecter1Merged1(294);
            BossSpecter1Merged2(295);
            BossSpecter1Merged3(296);

            ForcedNekomata(316);
            BossTroll(317);
            ForcedWillOWisp(318);

            BossMatador(349);
        }

        private static void Vishnu(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[1].Param = 433; // Akashic Arts
            tblSkill.fclSkillTbl[id].Event[3].Param = 195; // Radiance
            tblSkill.fclSkillTbl[id].Event[5].Param = 454; // Last Word
            tblSkill.fclSkillTbl[id].Event[7].Param = 471; // Chaturbhuja
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 98;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Mitra(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[3].Param = 31; // Mahamaon
            tblSkill.fclSkillTbl[id].Event[4].Param = 395; // Death Pact
            tblSkill.fclSkillTbl[id].Event[5].Param = 189; // Judgement Light
            tblSkill.fclSkillTbl[id].Event[6].Param = 454; // Last Word
            tblSkill.fclSkillTbl[id].Event[7].Param = 295; // Mana Surge
        }

        private static void Amaterasu(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 459; // Luster Candy
        }

        private static void Odin(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 18; // Maziodyne
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 9; // Bufudyne
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 108; // Deathbound
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 441; // Thunder Gods
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 66;
            tblSkill.fclSkillTbl[id].Event[4].Param = 391; // Wooing
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 67;
            tblSkill.fclSkillTbl[id].Event[5].Param = 428; // Defense Kuzushi
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 68;
            tblSkill.fclSkillTbl[id].Event[6].Param = 12; // Mabufudyne
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 442; // Thunder Reign
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 70;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Atavaka(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 299; // Might
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 107; // Mighty Gust
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 430; // Chi Blast
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 345; // Endure
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 48;
            tblSkill.fclSkillTbl[id].Event[4].Param = 450; // Neural Shock
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 49;
            tblSkill.fclSkillTbl[id].Event[5].Param = 313; // Anti-Phys
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 50;
            tblSkill.fclSkillTbl[id].Event[6].Param = 110; // Chaos Blade
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 51;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 306; // Retaliate
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 52;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Horus(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 354; // Endure
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 30; // Mahama
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 294; // Mana Gain
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 193; // Violet Flash
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 39;
            tblSkill.fclSkillTbl[id].Event[4].Param = 77; // Dekunda
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 40;
            tblSkill.fclSkillTbl[id].Event[5].Param = 40; // Mediarama
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 41;
            tblSkill.fclSkillTbl[id].Event[6].Param = 456; // Amrita
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 42;
            tblSkill.fclSkillTbl[id].Event[7].Param = 75; // Liftoma
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 43;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Lakshmi(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 41; // Mediarahan
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 387; // Seduce
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 197; // Stone Gaze
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 347; // Mana Aid
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 55;
            tblSkill.fclSkillTbl[id].Event[4].Param = 456; // Amrita
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 56;
            tblSkill.fclSkillTbl[id].Event[5].Param = 295; // Mana Surge
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 57;
            tblSkill.fclSkillTbl[id].Event[6].Param = 50; // Samarecarm
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 58;
            tblSkill.fclSkillTbl[id].Event[7].Param = 51; // Recarmdra
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 59;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Scathach(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 444; // Heavenly Cyclone
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 299; // Might
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 448; // Poison Volley
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 342; // Force Repel
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 65;
            tblSkill.fclSkillTbl[id].Event[5].Param = 188; // Punishment
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 66;
            tblSkill.fclSkillTbl[id].Event[6].Param = 186; // Wind Cutter
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 67;
            tblSkill.fclSkillTbl[id].Event[7].Param = 390; // Dark Pledge
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 68;
            tblSkill.fclSkillTbl[id].Event[8].Param = 347; // Mana Aid
            tblSkill.fclSkillTbl[id].Event[8].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[8].Type = 1;
            tblSkill.fclSkillTbl[id].Event[9].Param = 17; // Mazionga
            tblSkill.fclSkillTbl[id].Event[9].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[9].Type = 5;
        }

        private static void Sarasvati(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 198; // Mute Gaze
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 350; // Mana Refill
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 49; // Recarm
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 443; // Dervish
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 31;
            tblSkill.fclSkillTbl[id].Event[4].Param = 387; // Seduce
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 32;
            tblSkill.fclSkillTbl[id].Event[5].Param = 312; // Force Boost
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 33;
            tblSkill.fclSkillTbl[id].Event[6].Param = 185; // Tornado
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 34;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void Sati(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[6].Param = 215; // Allure
            tblSkill.fclSkillTbl[id].Event[7].Param = 25; // Megido
        }

        private static void AmeNoUzume(ushort id)
        {
            // Enemy Stats
            datDevilFormat.tbl[id].hp = 600;
            datDevilFormat.tbl[id].maxhp = 600;
            datDevilFormat.tbl[id].mp = 400;
            datDevilFormat.tbl[id].maxmp = 400;
            
            datDevilFormat.tbl[id].dropexp = 100;
            datDevilFormat.tbl[id].dropmakka = 1000;


            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 22; // Mazan
            datDevilFormat.tbl[id].skill[1] = 39; // Media
            datDevilFormat.tbl[id].skill[2] = 28; // Hama
            datDevilFormat.tbl[id].skill[3] = 229; // Laughter
            datDevilFormat.tbl[id].skill[4] = 366; // Abyssal Mask
            datDevilFormat.tbl[id].skill[5] = 219; // Rage
        }

        private static void Shiva(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 436; // Ragnarok
            tblSkill.fclSkillTbl[id].Event[1].Param = 442; // Thunder Reign
            tblSkill.fclSkillTbl[id].Event[2].Param = 104; // Hassohappa
            tblSkill.fclSkillTbl[id].Event[3].Param = 453; // Antichthon
            tblSkill.fclSkillTbl[id].Event[4].Param = 348; // Victory Cry
            tblSkill.fclSkillTbl[id].Event[5].Param = 470; // Tandava
            tblSkill.fclSkillTbl[id].Event[6].Param = 333; // Phys Drain
        }

        private static void BeidouXingjun(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[7].Param = 432; // Gate of Hell
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 66;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void QitianDasheng(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][7] = 100; // Dark

            // Skills
            tblSkill.fclSkillTbl[id].Event[1].Param = 362; // Phys Boost
        }

        private static void Dionysus(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[4].Param = 426; // Sakura Rage
        }

        private static void Kali(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 307; // Avenge
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Type = 1;
            tblSkill.fclSkillTbl[id].Event[3].Param = 362; // Phys Boost
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 68;
            tblSkill.fclSkillTbl[id].Event[3].Type = 1;
            tblSkill.fclSkillTbl[id].Event[4].Param = 6; // Maragidyne
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[4].Type = 1;
            tblSkill.fclSkillTbl[id].Event[5].Param = 292; // Life Surge
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 70;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 105; // Dark Sword
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 71;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 341; // Elec Repel
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 72;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Skadi(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[2].Param = 67; // Makakaja
            tblSkill.fclSkillTbl[id].Event[3].Param = 67; // Makakaja
            tblSkill.fclSkillTbl[id].Event[4].Param = 341; // Elec Repel
            tblSkill.fclSkillTbl[id].Event[5].Param = 341; // Elec Repel
            tblSkill.fclSkillTbl[id].Event[6].Param = 155; // Earthquake
            tblSkill.fclSkillTbl[id].Event[7].Param = 155; // Earthquake
            tblSkill.fclSkillTbl[id].Event[8].Param = 468; // Niflheim
            tblSkill.fclSkillTbl[id].Event[9].Param = 468; // Niflheim
            tblSkill.fclSkillTbl[id].Event[10].Param = 310; // Ice Boost
            tblSkill.fclSkillTbl[id].Event[10].TargetLevel = 79;
            tblSkill.fclSkillTbl[id].Event[10].Type = 1;
            tblSkill.fclSkillTbl[id].Event[11].Param = 310; // Ice Boost
            tblSkill.fclSkillTbl[id].Event[11].TargetLevel = 79;
            tblSkill.fclSkillTbl[id].Event[11].Type = 6;
        }

        private static void Parvati(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[7].Param = 195; // Radiance
            tblSkill.fclSkillTbl[id].Event[8].Param = 195; // Radiance
            tblSkill.fclSkillTbl[id].Event[9].Param = 218; // Prayer
            tblSkill.fclSkillTbl[id].Event[10].Param = 218; // Prayer
        }

        private static void Kushinada(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 40; // Mediarama
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 47; // Paraladi
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 90; // Poison Arrow
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 5; // Maragion
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 42;
            tblSkill.fclSkillTbl[id].Event[4].Param = 456; // Amrita
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 43;
            tblSkill.fclSkillTbl[id].Event[5].Param = 353; // Lucky Find
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 44;
            tblSkill.fclSkillTbl[id].Event[6].Param = 367; // Knowledge of Tools
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 45;
            tblSkill.fclSkillTbl[id].Event[7].Param = 392; // Beseech
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void KikuriHime(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 37; // Diarama
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 214; // Sexy Gaze
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 418; // Maiden Plea
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 46; // Posumudi
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 25;
            tblSkill.fclSkillTbl[id].Event[4].Param = 44; // Me Patra
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 26;
            tblSkill.fclSkillTbl[id].Event[5].Param = 49; // Recarm
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 27;
            tblSkill.fclSkillTbl[id].Event[6].Param = 365; // Anti-Ailments
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 28;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void Bishamonten(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 104; // Hassohappa
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 304; // Attack All
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 179; // Trisagion
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 345; // Endure
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 73;
            tblSkill.fclSkillTbl[id].Event[4].Param = 309; // Fire Boost
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 74;
            tblSkill.fclSkillTbl[id].Event[5].Param = 195; // Radiance
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 75;
            tblSkill.fclSkillTbl[id].Event[6].Param = 364; // Anti-Magic
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 76;
            tblSkill.fclSkillTbl[id].Event[7].Param = 458; // Heat Riser
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 77;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Thor(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 311; // Elec Boost
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 469; // Mjolnir
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 100; // Hades Blast
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 307; // Avenge
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 77;
            tblSkill.fclSkillTbl[id].Event[4].Param = 442; // Thunder Reign
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 78;
            tblSkill.fclSkillTbl[id].Event[5].Param = 457; // Diamrita
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 79;
            tblSkill.fclSkillTbl[id].Event[6].Param = 429; // Primal Force
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 80;
            tblSkill.fclSkillTbl[id].Event[7].Param = 365; // Anti-Ailments
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 81;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Jikokuten(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 106; // Stasis Blade
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 38; // Diarahan
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 181; // Glacial Blast
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 77; // Dekunda
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 53;
            tblSkill.fclSkillTbl[id].Event[4].Param = 12; // Mabufudyne
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 54;
            tblSkill.fclSkillTbl[id].Event[5].Param = 390; // Dark Pledge
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 55;
            tblSkill.fclSkillTbl[id].Event[6].Param = 424; // Concentrate
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 56;
            tblSkill.fclSkillTbl[id].Event[7].Param = 329; // Null Dark
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 57;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void TakeMikazuchi(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 15; // Ziodyne
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 440; // Jolt
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 428; // Defense Kuzushi
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 410; // Arbitration
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[4].Param = 105; // Dark Sword
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 47;
            tblSkill.fclSkillTbl[id].Event[5].Param = 183; // Bolt Storm
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 48;
            tblSkill.fclSkillTbl[id].Event[6].Param = 349; // Life Refill
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 49;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 362; // Phys Boost
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 50;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Okuninushi(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 110; // Chaos Blade
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 34; // Mamudo
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 391; // Wooing
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 3; // Agidyne
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 40;
            tblSkill.fclSkillTbl[id].Event[4].Param = 56; // Makajamon
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 41;
            tblSkill.fclSkillTbl[id].Event[5].Param = 428; // Defense Kuzushi
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 42;
            tblSkill.fclSkillTbl[id].Event[6].Param = 223; // Beckon Call
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 43;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 40; // Mediarama
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 44;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Koumokuten(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 103; // Brutal Slash
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 291; // Life Gain
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 392; // Beseech
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 430; // Chi Blast
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 34;
            tblSkill.fclSkillTbl[id].Event[4].Param = 185; // Tornado
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 35;
            tblSkill.fclSkillTbl[id].Event[5].Param = 68; // Tetraja
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 36;
            tblSkill.fclSkillTbl[id].Event[6].Param = 428; // Defense Kuzushi
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 37;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 424; // Concentrate
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Zouchouten(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 107; // Mighty Gust
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 440; // Jolt
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 30; // Mahama
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 193; // Violet Flash
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 28;
            tblSkill.fclSkillTbl[id].Event[4].Param = 319; // Anti-Dark
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[5].Param = 99; // Tempest
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 30;
            tblSkill.fclSkillTbl[id].Event[6].Param = 299; // Might
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 31;
            tblSkill.fclSkillTbl[id].Event[7].Param = 188; // Punishment
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 32;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void TakeMinakata(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[5].Param = 427; // Fang Breaker
        }

        private static void Chimera(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 435; // Scald
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 309; // Fire Boost
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 203; // War Cry
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 126; // Iron Claw
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 56;
            tblSkill.fclSkillTbl[id].Event[4].Param = 178; // Prominence
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 57;
            tblSkill.fclSkillTbl[id].Event[5].Param = 213; // Sonic Wave
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 58;
            tblSkill.fclSkillTbl[id].Event[6].Param = 386; // Kidnap
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 59;
            tblSkill.fclSkillTbl[id].Event[7].Param = 116; // Kamikaze
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 60;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Baihu(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 346; // Life Aid
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 120; // Stone Bite
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 183; // Bolt Storm
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 299; // Might
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 44;
            tblSkill.fclSkillTbl[id].Event[4].Param = 15; // Ziodyne
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 45;
            tblSkill.fclSkillTbl[id].Event[5].Param = 224; // Focus
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[6].Param = 9; // Bufudyne
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 47;
            tblSkill.fclSkillTbl[id].Event[7].Param = 126; // Iron Claw
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 48;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Senri(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 353; // Lucky Find
            tblSkill.fclSkillTbl[id].Event[3].Param = 353; // Lucky Find
            tblSkill.fclSkillTbl[id].Event[4].Param = 399; // Stone Hunt
            tblSkill.fclSkillTbl[id].Event[5].Param = 399; // Stone Hunt
            tblSkill.fclSkillTbl[id].Event[6].Param = 23; // Mazanma
            tblSkill.fclSkillTbl[id].Event[7].Param = 23; // Mazanma
            tblSkill.fclSkillTbl[id].Event[8].Param = 367; // Knowledge of Tools
            tblSkill.fclSkillTbl[id].Event[9].Param = 367; // Knowledge of Tools
        }

        private static void Zhuque(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 75; // Liftoma
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 176; // Fire Breath
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 53; // Sukunda
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 49; // Recarm
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 37;
            tblSkill.fclSkillTbl[id].Event[4].Param = 410; // Arbitration
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[5].Param = 5; // Maragion
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 39;
            tblSkill.fclSkillTbl[id].Event[6].Param = 17; // Mazionga
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 40;
            tblSkill.fclSkillTbl[id].Event[7].Param = 346; // Life Aid
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 41;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Shiisaa(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 182; // Shock
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 123; // Feral Claw
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 388; // Brainwash
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 203; // War Cry
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 14;
            tblSkill.fclSkillTbl[id].Event[4].Param = 121; // Stun Bite
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 15;
            tblSkill.fclSkillTbl[id].Event[5].Param = 305; // Counter
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 16;
            tblSkill.fclSkillTbl[id].Event[6].Param = 440; // Jolt
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 17;
            tblSkill.fclSkillTbl[id].Event[7].Param = 314; // Anti-Fire
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 18;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 180;
            datDevilFormat.tbl[id].maxhp = 180;
            datDevilFormat.tbl[id].mp = 76;
            datDevilFormat.tbl[id].maxmp = 76;
            
            datDevilFormat.tbl[id].dropexp = 40;
            datDevilFormat.tbl[id].dropmakka = 200;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 182; // Shock
            datDevilFormat.tbl[id].skill[1] = 123; // Feral Claw
            datDevilFormat.tbl[id].skill[2] = 203; // War Cry
            datDevilFormat.tbl[id].skill[3] = 121; // Stun Bite
            datDevilFormat.tbl[id].skill[4] = 305; // Counter
            datDevilFormat.tbl[id].skill[5] = 366; // Abyssal Mask
        }

        private static void Xiezhai(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 202; // Toxic Cloud
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 45; // Mutudi
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 97; // Hell Thrust
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 193; // Violet Flash
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 27;
            tblSkill.fclSkillTbl[id].Event[4].Param = 437; // Refrigerate
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 28;
            tblSkill.fclSkillTbl[id].Event[5].Param = 47; // Paraladi
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[6].Param = 11; // Mabufula
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 30;
            tblSkill.fclSkillTbl[id].Event[7].Param = 365; // Anti-Ailments
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 31;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Flaemis(ushort id)
        {
            // Affinities
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
            // Affinities
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
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 36; // Dia
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 19; // Zan
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 64; // Tarukaja
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 59; // Shibaboo
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 12;
            tblSkill.fclSkillTbl[id].Event[4].Param = 62; // Marin Karin
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 13;
            tblSkill.fclSkillTbl[id].Event[5].Param = 322; // Anti-Mind
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 14;
            tblSkill.fclSkillTbl[id].Event[6].Param = 113; // Venom Needle
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 15;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 102;
            datDevilFormat.tbl[id].maxhp = 102;
            datDevilFormat.tbl[id].mp = 76;
            datDevilFormat.tbl[id].maxmp = 76;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 62;
            datDevilFormat.tbl[id].skill[1] = 36;
            datDevilFormat.tbl[id].skill[2] = 19;
            datDevilFormat.tbl[id].skill[3] = 64;

            // AI
            datDevilAI.divTbls[0][38].scriptid = 31;

            datDevilAI.divTbls[0][38].aitable[0][0].skill = 62;
            datDevilAI.divTbls[0][38].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[0][38].aitable[0][1].skill = 32768;
            datDevilAI.divTbls[0][38].aitable[0][1].ritu = 40;
            datDevilAI.divTbls[0][38].aitable[0][2].skill = 64;
            datDevilAI.divTbls[0][38].aitable[0][2].ritu = 30;

            datDevilAI.divTbls[0][38].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][38].aitable[1][0].ritu = 30;
            datDevilAI.divTbls[0][38].aitable[1][1].skill = 19;
            datDevilAI.divTbls[0][38].aitable[1][1].ritu = 40;
            datDevilAI.divTbls[0][38].aitable[1][2].skill = 36;
            datDevilAI.divTbls[0][38].aitable[1][2].ritu = 30;

            datDevilAI.divTbls[0][38].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[0][38].aitable[2][0].ritu = 20;
            datDevilAI.divTbls[0][38].aitable[2][1].skill = 19;
            datDevilAI.divTbls[0][38].aitable[2][1].ritu = 60;
            datDevilAI.divTbls[0][38].aitable[2][2].skill = 64;
            datDevilAI.divTbls[0][38].aitable[2][2].ritu = 20;
        }

        private static void Erthys(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 13; // Zio
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 43; // Patra
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 66; // Rakukaja
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 112; // Stun Needle
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 8;
            tblSkill.fclSkillTbl[id].Event[4].Param = 320; // Anti-Curse
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 9;
            tblSkill.fclSkillTbl[id].Event[5].Param = 410; // Arbitration
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 10;
            tblSkill.fclSkillTbl[id].Event[6].Param = 16; // Mazio
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 11;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 90;
            datDevilFormat.tbl[id].maxhp = 90;
            datDevilFormat.tbl[id].mp = 48;
            datDevilFormat.tbl[id].maxmp = 48;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 112;

            // AI
            datDevilAI.divTbls[0][39].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[0][39].aitable[2][0].ritu = 30;
            datDevilAI.divTbls[0][39].aitable[2][1].skill = 112;
            datDevilAI.divTbls[0][39].aitable[2][1].ritu = 40;
            datDevilAI.divTbls[0][39].aitable[2][2].skill = 13;
            datDevilAI.divTbls[0][39].aitable[2][2].ritu = 30;
        }

        private static void SakiMitama(ushort id)
        {
            // Affinities
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
            // Affinities
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
            // Affinities
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
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[2].Param = 350; // Mana Refill
            tblSkill.fclSkillTbl[id].Event[3].Param = 350; // Mana Refill
            tblSkill.fclSkillTbl[id].Event[4].Param = 6; // Maragidyne
            tblSkill.fclSkillTbl[id].Event[5].Param = 6; // Maragidyne
            tblSkill.fclSkillTbl[id].Event[6].Param = 67; // Makakaja
            tblSkill.fclSkillTbl[id].Event[7].Param = 67; // Makakaja
            tblSkill.fclSkillTbl[id].Event[8].Param = 178; // Prominence
            tblSkill.fclSkillTbl[id].Event[9].Param = 178; // Prominence
            tblSkill.fclSkillTbl[id].Event[10].Param = 223; // Beckon Call
            tblSkill.fclSkillTbl[id].Event[11].Param = 223; // Beckon Call
        }

        private static void Jinn(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 443; // Dervish
            tblSkill.fclSkillTbl[id].Event[3].Param = 457; // Diamrita
        }

        private static void KarasuTengu(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 461; // Storm Gale
            tblSkill.fclSkillTbl[id].Event[5].Param = 2; // Agilao
            tblSkill.fclSkillTbl[id].Event[6].Param = 2; // Agilao
        }

        private static void Dis(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[7].Param = 456; // Amrita
        }

        private static void Isora(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 71; // Analyze
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 118; // Venom Bite
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 386; // Kidnap
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 180; // Ice Breath
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 15;
            tblSkill.fclSkillTbl[id].Event[4].Param = 210; // Lullaby
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 16;
            tblSkill.fclSkillTbl[id].Event[5].Param = 39; // Media
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 17;
            tblSkill.fclSkillTbl[id].Event[6].Param = 437; // Refrigerate
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 18;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 160;
            datDevilFormat.tbl[id].maxhp = 160;
            datDevilFormat.tbl[id].mp = 88;
            datDevilFormat.tbl[id].maxmp = 88;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 180;
            datDevilFormat.tbl[id].skill[1] = 39;
            datDevilFormat.tbl[id].skill[2] = 118;
            datDevilFormat.tbl[id].skill[3] = 437;

            // AI
            datDevilAI.divTbls[0][50].aitable[0][0].skill = 180;
            datDevilAI.divTbls[0][50].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[0][50].aitable[0][1].skill = 32768;
            datDevilAI.divTbls[0][50].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[0][50].aitable[0][2].skill = 118;
            datDevilAI.divTbls[0][50].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][50].aitable[0][3].skill = 437;
            datDevilAI.divTbls[0][50].aitable[0][3].ritu = 30;
        }

        private static void Apsaras(ushort id)
        {
            // Enemy Stats
            datDevilFormat.tbl[id].hp = 84;
            datDevilFormat.tbl[id].maxhp = 84;
            datDevilFormat.tbl[id].mp = 56;
            datDevilFormat.tbl[id].maxmp = 56;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[1] = 210; // Lullaby
            datDevilFormat.tbl[id].skill[2] = 55; // Makajam 

            // AI
            datDevilAI.divTbls[0][51].aitable[0][0].skill = 60;
            datDevilAI.divTbls[0][51].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[0][51].aitable[0][1].skill = 32768;
            datDevilAI.divTbls[0][51].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[0][51].aitable[0][2].skill = 210;
            datDevilAI.divTbls[0][51].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][51].aitable[0][3].skill = 55;
            datDevilAI.divTbls[0][51].aitable[0][3].ritu = 20;

            datDevilAI.divTbls[0][51].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][51].aitable[1][0].ritu = 100;

            datDevilAI.divTbls[0][51].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[0][51].aitable[2][0].ritu = 100;
        }

        private static void KoppaTengu(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 461; // Storm Gale
        }

        private static void Titania(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 452; // Pulinpaon
        }

        private static void Troll(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][9] = 2147483798; // Nerve

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 397; // Begging
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 45; // Mutudi
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 98; // Berserk
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 181; // Glacial Blast
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 39;
            tblSkill.fclSkillTbl[id].Event[4].Param = 291; // Life Gain
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 40;
            tblSkill.fclSkillTbl[id].Event[5].Param = 427; // Fang Breaker
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 41;
            tblSkill.fclSkillTbl[id].Event[6].Param = 76; // Lightoma
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 42;
            tblSkill.fclSkillTbl[id].Event[7].Param = 38; // Diarahan
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 43;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Setanta(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 99; // Tempest
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 44;
            tblSkill.fclSkillTbl[id].Event[3].Type = 1;
            tblSkill.fclSkillTbl[id].Event[4].Param = 306; // Retaliate
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 45;
            tblSkill.fclSkillTbl[id].Event[4].Type = 1;
            tblSkill.fclSkillTbl[id].Event[5].Param = 205; // Taunt
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 391; // Wooing
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 47;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 355; // Charisma
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 48;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
            tblSkill.fclSkillTbl[id].Event[8].Type = 0;
            tblSkill.fclSkillTbl[id].Event[9].Type = 0;
        }

        private static void Kelpie(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 61; // Pulinpa
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 410; // Arbitration
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 47; // Paraladi
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 437; // Refrigerate
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 27;
            tblSkill.fclSkillTbl[id].Event[4].Param = 121; // Stun Bite
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 28;
            tblSkill.fclSkillTbl[id].Event[5].Param = 331; // Null Nerve
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[6].Param = 62; // Marin Karin
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 30;
            tblSkill.fclSkillTbl[id].Event[7].Param = 457; // Diamrita
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 30;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void HighPixie(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[1].Param = 461; // Storm Gale

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 84;
            datDevilFormat.tbl[id].maxhp = 84;
            datDevilFormat.tbl[id].mp = 64;
            datDevilFormat.tbl[id].maxmp = 64;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[1] = 13;

            // AI
            datDevilAI.divTbls[0][59].aitable[0][0].skill = 461;
            datDevilAI.divTbls[0][59].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[0][59].aitable[0][1].skill = 32768;
            datDevilAI.divTbls[0][59].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[0][59].aitable[0][2].skill = 32769;
            datDevilAI.divTbls[0][59].aitable[0][2].ritu = 10;
            datDevilAI.divTbls[0][59].aitable[0][3].skill = 13;
            datDevilAI.divTbls[0][59].aitable[0][3].ritu = 30;

            datDevilAI.divTbls[0][59].aitable[1][0].skill = 461;
            datDevilAI.divTbls[0][59].aitable[1][0].ritu = 40;
            datDevilAI.divTbls[0][59].aitable[1][1].skill = 32768;
            datDevilAI.divTbls[0][59].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[0][59].aitable[1][2].skill = 32769;
            datDevilAI.divTbls[0][59].aitable[1][2].ritu = 10;
            datDevilAI.divTbls[0][59].aitable[1][3].skill = 13;
            datDevilAI.divTbls[0][59].aitable[1][3].ritu = 30;
        }

        private static void JackFrost(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 463; // Jack Bufu

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 78;
            datDevilFormat.tbl[id].maxhp = 78;
            datDevilFormat.tbl[id].mp = 60;
            datDevilFormat.tbl[id].maxmp = 60;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 463; // Jack Bufu
            datDevilFormat.tbl[id].skill[3] = 180; // Ice Breath

            // AI
            datDevilAI.divTbls[0][60].aitable[0][0].skill = 463;
            datDevilAI.divTbls[0][60].aitable[0][0].ritu = 40;

            datDevilAI.divTbls[0][60].aitable[1][1].skill = 10;
            datDevilAI.divTbls[0][60].aitable[1][1].ritu = 40;
            datDevilAI.divTbls[0][60].aitable[1][2].skill = 180;
            datDevilAI.divTbls[0][60].aitable[1][2].ritu = 40;

            datDevilAI.divTbls[0][60].aitable[2][1].skill = 463;
            datDevilAI.divTbls[0][60].aitable[2][1].ritu = 20;
        }

        private static void Pixie(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[6].Param = 461; // Storm Gale

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 36;
            datDevilFormat.tbl[id].maxhp = 36;
            datDevilFormat.tbl[id].mp = 32;
            datDevilFormat.tbl[id].maxmp = 32;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[2] = 54;

            // AI
            datDevilAI.divTbls[0][61].aitable[0][0].skill = 13;
            datDevilAI.divTbls[0][61].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[0][61].aitable[0][1].skill = 36;
            datDevilAI.divTbls[0][61].aitable[0][1].ritu = 40;
            datDevilAI.divTbls[0][61].aitable[0][2].skill = 32768;
            datDevilAI.divTbls[0][61].aitable[0][2].ritu = 10;
            datDevilAI.divTbls[0][61].aitable[0][3].skill = 54;
            datDevilAI.divTbls[0][61].aitable[0][3].ritu = 10;

            datDevilAI.divTbls[0][61].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][61].aitable[1][0].ritu = 40;
            datDevilAI.divTbls[0][61].aitable[1][1].skill = 36;
            datDevilAI.divTbls[0][61].aitable[1][1].ritu = 40;
            datDevilAI.divTbls[0][61].aitable[1][2].skill = 54;
            datDevilAI.divTbls[0][61].aitable[1][2].ritu = 20;
        }

        private static void Dominion(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][4] = 50; // Force

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 38; // Diarahan
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 29; // Hamaon
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 413; // Persuade
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 70; // Tetrakarn
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 51;
            tblSkill.fclSkillTbl[id].Event[4].Param = 67; // Makakaja
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 52;
            tblSkill.fclSkillTbl[id].Event[5].Param = 55; // Makajam
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 53;
            tblSkill.fclSkillTbl[id].Event[6].Param = 189; // Judgement Light
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 54;
            tblSkill.fclSkillTbl[id].Event[7].Param = 218; // Prayer
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 55;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Virtue(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 30; // Mahama
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 440; // Jolt
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 40; // Mediarama
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 114; // Arid Needle
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 42;
            tblSkill.fclSkillTbl[id].Event[4].Param = 69; // Makarakarn
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 43;
            tblSkill.fclSkillTbl[id].Event[5].Param = 17; // Mazionga
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 44;
            tblSkill.fclSkillTbl[id].Event[6].Param = 68; // Tetraja
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 45;
            tblSkill.fclSkillTbl[id].Event[7].Param = 29; // Hamaon
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Power(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 427; // Fang Breaker
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 388; // Brainwash
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 64; // Tarukaja
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 30; // Mahama
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 34;
            tblSkill.fclSkillTbl[id].Event[4].Param = 99; // Tempest
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 35;
            tblSkill.fclSkillTbl[id].Event[5].Param = 193; // Violet Flash
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 36;
            tblSkill.fclSkillTbl[id].Event[6].Param = 331; // Null Nerve
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 37;
            tblSkill.fclSkillTbl[id].Event[7].Param = 109; // Guillotine
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Principality(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 300; // Bright Might
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 20; // Zanma
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 101; // Heat Wave
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 37; // Diarama
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[4].Param = 435; // Scald
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 30;
            tblSkill.fclSkillTbl[id].Event[5].Param = 188; // Punishment
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 31;
            tblSkill.fclSkillTbl[id].Event[6].Param = 293; // Mana Bonus
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 32;
        }

        private static void Archangel(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 64; // Tarukaja
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 107; // Mighty Gust
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 413; // Persuade
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 28; // Hama
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 19;
            tblSkill.fclSkillTbl[id].Event[4].Param = 73; // Estoma
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 20;
            tblSkill.fclSkillTbl[id].Event[5].Param = 101; // Heat Wave
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 21;
            tblSkill.fclSkillTbl[id].Event[6].Param = 37; // Diarama
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 22;
            tblSkill.fclSkillTbl[id].Event[7].Param = 435; // Scald
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 23;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 254;
            datDevilFormat.tbl[id].maxhp = 254;
            datDevilFormat.tbl[id].mp = 96;
            datDevilFormat.tbl[id].maxmp = 96;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[4] = 101; // Heat Wave
            datDevilFormat.tbl[id].skill[5] = 435; // Scald

            // AI
            datDevilAI.divTbls[0][67].aitable[0][0].skill = 64;
            datDevilAI.divTbls[0][67].aitable[0][0].ritu = 70;
            datDevilAI.divTbls[0][67].aitable[0][0].skill = 435;
            datDevilAI.divTbls[0][67].aitable[0][0].ritu = 30;

            datDevilAI.divTbls[0][67].aitable[1][0].skill = 37;
            datDevilAI.divTbls[0][67].aitable[1][0].ritu = 100;

            datDevilAI.divTbls[0][67].aitable[2][0].skill = 107;
            datDevilAI.divTbls[0][67].aitable[2][0].ritu = 40;
            datDevilAI.divTbls[0][67].aitable[2][1].skill = 28;
            datDevilAI.divTbls[0][67].aitable[2][1].ritu = 40;
            datDevilAI.divTbls[0][67].aitable[2][2].skill = 96;
            datDevilAI.divTbls[0][67].aitable[2][2].ritu = 20;
        }

        private static void Angel(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 464; // Humble Blessing
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 28; // Hama
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 411; // Detain
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 43; // Patra
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 12;
            tblSkill.fclSkillTbl[id].Event[4].Param = 48; // Petradi
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 13;
            tblSkill.fclSkillTbl[id].Event[5].Param = 22; // Mazan
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 14;
            tblSkill.fclSkillTbl[id].Event[6].Param = 346; // Life Aid
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 15;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 108;
            datDevilFormat.tbl[id].maxhp = 108;
            datDevilFormat.tbl[id].mp = 72;
            datDevilFormat.tbl[id].maxmp = 72;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 28;
            datDevilFormat.tbl[id].skill[1] = 22;
            datDevilFormat.tbl[id].skill[2] = 464;

            // AI
            datDevilAI.divTbls[0][68].aitable[0][0].skill = 28;
            datDevilAI.divTbls[0][68].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[0][68].aitable[0][1].skill = 32768;
            datDevilAI.divTbls[0][68].aitable[0][1].ritu = 40;
            datDevilAI.divTbls[0][68].aitable[0][2].skill = 22;
            datDevilAI.divTbls[0][68].aitable[0][2].ritu = 20;

            datDevilAI.divTbls[0][68].aitable[1][0].skill = 464;
            datDevilAI.divTbls[0][68].aitable[1][0].ritu = 90;
            datDevilAI.divTbls[0][68].aitable[1][1].skill = 22;
            datDevilAI.divTbls[0][68].aitable[1][1].ritu = 10;

            datDevilAI.divTbls[0][68].aitable[2][0].skill = 28;
            datDevilAI.divTbls[0][68].aitable[2][0].ritu = 40;
            datDevilAI.divTbls[0][68].aitable[2][1].skill = 32768;
            datDevilAI.divTbls[0][68].aitable[2][1].ritu = 40;
            datDevilAI.divTbls[0][68].aitable[2][2].skill = 22;
            datDevilAI.divTbls[0][68].aitable[2][2].ritu = 20;
        }

        private static void Flauros(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[5].Param = 292; // Life Surge
            tblSkill.fclSkillTbl[id].Event[6].Param = 104; // Hassohappa
            tblSkill.fclSkillTbl[id].Event[7].Param = 366; // Abyssal Mask
        }

        private static void Decarabia(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 196; // Hell Gaze
            tblSkill.fclSkillTbl[id].Event[4].Param = 25; // Megido
            tblSkill.fclSkillTbl[id].Event[5].Param = 212; // Eternal Rest
            tblSkill.fclSkillTbl[id].Event[6].Param = 72; // Trafuri
            tblSkill.fclSkillTbl[id].Event[7].Param = 328; // Null Light
        }

        private static void Ose(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[5].Param = 224; // Focus
            tblSkill.fclSkillTbl[id].Event[6].Param = 313; // Anti-Phys
            tblSkill.fclSkillTbl[id].Event[7].Param = 69; // Makarakarn
        }

        private static void Berith(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 446; // Damnation
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 386; // Kidnap
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 101; // Heat Wave
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 177; // Hellfire
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[4].Param = 57; // Dekaja
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 39;
            tblSkill.fclSkillTbl[id].Event[5].Param = 309; // Fire Boost
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 40;
            tblSkill.fclSkillTbl[id].Event[6].Param = 207; // Dismal Tune
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 41;
            tblSkill.fclSkillTbl[id].Event[7].Type = 0;
        }

        private static void Eligor(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 97; // Hell Thrust
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 66; // Rakukaja
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 32; // Mudo
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 98; // Berserk
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 30;
            tblSkill.fclSkillTbl[id].Event[4].Param = 427; // Fang Breaker
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 31;
            tblSkill.fclSkillTbl[id].Event[5].Param = 301; // Dark Might
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 32;
            tblSkill.fclSkillTbl[id].Event[6].Param = 435; // Scald
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 33;
            tblSkill.fclSkillTbl[id].Event[7].Param = 414; // Intimidate
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 34;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Forneus(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[6].Param = 244; // Icy Death

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 200;
            datDevilFormat.tbl[id].maxhp = 200;
            datDevilFormat.tbl[id].mp = 108;
            datDevilFormat.tbl[id].maxmp = 108;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[1] = 121;
            datDevilFormat.tbl[id].skill[2] = 244;

            // AI
            datDevilAI.divTbls[0][74].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][74].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[0][74].aitable[0][1].skill = 8;
            datDevilAI.divTbls[0][74].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][74].aitable[0][2].skill = 244;
            datDevilAI.divTbls[0][74].aitable[0][2].ritu = 30;
            datDevilAI.divTbls[0][74].aitable[0][3].skill = 121;
            datDevilAI.divTbls[0][74].aitable[0][3].ritu = 20;

            datDevilAI.divTbls[0][74].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][74].aitable[1][0].ritu = 50;
            datDevilAI.divTbls[0][74].aitable[1][1].skill = 121;
            datDevilAI.divTbls[0][74].aitable[1][1].ritu = 50;
        }

        private static void Yurlungur(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[5].Param = 186; // Wind Cutter
            tblSkill.fclSkillTbl[id].Event[6].Param = 50; // Samarecarm
            tblSkill.fclSkillTbl[id].Event[7].Param = 445; // Vayavya
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 75;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Quetzalcoatl(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 120; // Stone Bite
            tblSkill.fclSkillTbl[id].Event[1].Param = 98; // Berserk
            tblSkill.fclSkillTbl[id].Event[2].Param = 181; // Glacial Blast
            tblSkill.fclSkillTbl[id].Event[3].Param = 202; // Toxic Cloud
            tblSkill.fclSkillTbl[id].Event[4].Param = 310; // Ice Boost
            tblSkill.fclSkillTbl[id].Event[5].Param = 335; // Ice Drain
            tblSkill.fclSkillTbl[id].Event[6].Param = 51; // Recarmdra
            tblSkill.fclSkillTbl[id].Event[7].Param = 432; // Gate of Hell
        }

        private static void NagaRaja(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 99; // Tempest
            tblSkill.fclSkillTbl[id].Event[3].Param = 99; // Tempest
            tblSkill.fclSkillTbl[id].Event[4].Param = 183; // Bolt Storm
            tblSkill.fclSkillTbl[id].Event[5].Param = 183; // Bolt Storm
            tblSkill.fclSkillTbl[id].Event[6].Param = 305; // Counter
            tblSkill.fclSkillTbl[id].Event[7].Param = 305; // Counter
            tblSkill.fclSkillTbl[id].Event[8].Param = 391; // Wooing
            tblSkill.fclSkillTbl[id].Event[9].Param = 391; // Wooing
            tblSkill.fclSkillTbl[id].Event[10].Param = 324; // Null Fire
            tblSkill.fclSkillTbl[id].Event[11].Param = 324; // Null Fire

            //datDevilFormat.tbl[id].skill[4] = 367;
            //datDevilFormat.tbl[id].dropmakka = 65000;
        }

        private static void Nozuchi(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 96; // Lunge
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 90; // Poison Arrow
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 420; // Flatter
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 305; // Counter
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 15;
            tblSkill.fclSkillTbl[id].Event[3].Type = 1;
            tblSkill.fclSkillTbl[id].Event[4].Param = 202; // Toxic Cloud
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 16;
            tblSkill.fclSkillTbl[id].Event[5].Param = 66; // Rakukaja
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 17;
            tblSkill.fclSkillTbl[id].Event[6].Param = 115; // Sacrifice
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 18;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 180;
            datDevilFormat.tbl[id].maxhp = 180;
            datDevilFormat.tbl[id].mp = 80;
            datDevilFormat.tbl[id].maxmp = 80;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[4] = 90; // Poison Arrow

            // AI
            datDevilAI.divTbls[0][80].aitable[0][0].skill = 202;
            datDevilAI.divTbls[0][80].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[0][80].aitable[0][1].skill = 96;
            datDevilAI.divTbls[0][80].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[0][80].aitable[0][2].skill = 66;
            datDevilAI.divTbls[0][80].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][80].aitable[0][3].skill = 90;
            datDevilAI.divTbls[0][80].aitable[0][3].ritu = 20;

            datDevilAI.divTbls[0][80].aitable[1][0].skill = 202;
            datDevilAI.divTbls[0][80].aitable[1][0].ritu = 20;
            datDevilAI.divTbls[0][80].aitable[1][1].skill = 90;
            datDevilAI.divTbls[0][80].aitable[1][1].ritu = 40;
            datDevilAI.divTbls[0][80].aitable[1][2].skill = 66;
            datDevilAI.divTbls[0][80].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[0][80].aitable[1][3].skill = 96;
            datDevilAI.divTbls[0][80].aitable[1][3].ritu = 20;

            datDevilAI.divTbls[0][80].aitable[2][0].skill = 115;
            datDevilAI.divTbls[0][80].aitable[2][0].ritu = 5;
            datDevilAI.divTbls[0][80].aitable[2][1].skill = 96;
            datDevilAI.divTbls[0][80].aitable[2][1].ritu = 50;
            datDevilAI.divTbls[0][80].aitable[2][2].skill = 32768;
            datDevilAI.divTbls[0][80].aitable[2][2].ritu = 45;
        }

        private static void Cerberus(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 122; // Hell Fang
            tblSkill.fclSkillTbl[id].Event[4].Param = 465; // Rend
            tblSkill.fclSkillTbl[id].Event[7].Param = 411; // Detain
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 66;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Orthrus(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 176; // Fire Breath
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 125; // Stun Claw
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 385; // Scout
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 309; // Fire Boost
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 35;
            tblSkill.fclSkillTbl[id].Event[4].Param = 203; // War Cry
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 36;
            tblSkill.fclSkillTbl[id].Event[5].Param = 430; // Chi Blast
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 37;
            tblSkill.fclSkillTbl[id].Event[6].Param = 5; // Maragion
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 122; // Hell Fang
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 39;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Suparna(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 124; // Venom Claw
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 55;
            tblSkill.fclSkillTbl[id].Event[5].Param = 462; // Winged Fury
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 56;
        }

        private static void BadbCatha(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 75; // Liftoma
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 111; // Needle Rush
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 411; // Detain
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 443; // Dervish
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 24;
            tblSkill.fclSkillTbl[id].Event[4].Param = 317; // Anti-Force
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 25;
            tblSkill.fclSkillTbl[id].Event[5].Param = 347; // Mana Aid
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 26;
            tblSkill.fclSkillTbl[id].Event[6].Param = 23; // Mazanma
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 27;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void Nekomata(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 125; // Stun Claw
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 62; // Marin Karin
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 47; // Paraladi
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 293; // Mana Bonus
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 19;
            tblSkill.fclSkillTbl[id].Event[5].Param = 396; // Plead
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 20;
            tblSkill.fclSkillTbl[id].Event[6].Param = 198; // Mute Gaze
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 21;
            tblSkill.fclSkillTbl[id].Event[7].Param = 443; // Dervish
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 22;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 182;
            datDevilFormat.tbl[id].maxhp = 182;
            datDevilFormat.tbl[id].mp = 120;
            datDevilFormat.tbl[id].maxmp = 120;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[1] = 125;
            datDevilFormat.tbl[id].skill[2] = 198;

            // AI
            datDevilAI.divTbls[0][86].aitable[0][0].skill = 62;
            datDevilAI.divTbls[0][86].aitable[0][0].ritu = 60;
            datDevilAI.divTbls[0][86].aitable[0][1].skill = 125;
            datDevilAI.divTbls[0][86].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][86].aitable[0][2].skill = 198;
            datDevilAI.divTbls[0][86].aitable[0][2].ritu = 10;

            datDevilAI.divTbls[0][86].aitable[1][0].skill = 62;
            datDevilAI.divTbls[0][86].aitable[1][0].ritu = 30;
            datDevilAI.divTbls[0][86].aitable[1][1].skill = 125;
            datDevilAI.divTbls[0][86].aitable[1][1].ritu = 60;
            datDevilAI.divTbls[0][86].aitable[1][2].skill = 198;
            datDevilAI.divTbls[0][86].aitable[1][2].ritu = 10;

            datDevilAI.divTbls[0][86].aitable[2][0].skill = 125;
            datDevilAI.divTbls[0][86].aitable[2][0].ritu = 60;
            datDevilAI.divTbls[0][86].aitable[2][1].skill = 32768;
            datDevilAI.divTbls[0][86].aitable[2][1].ritu = 40;
        }

        private static void Titan(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 392; // Beseech
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 109; // Guillotine
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 205; // Taunt
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 427; // Fang Breaker
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 50;
            tblSkill.fclSkillTbl[id].Event[4].Param = 176; // Fire Breath
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 51;
            tblSkill.fclSkillTbl[id].Event[5].Param = 292; // Life Surge
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 52;
            tblSkill.fclSkillTbl[id].Event[6].Param = 306; // Retaliate
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 53;
            tblSkill.fclSkillTbl[id].Event[7].Param = 209; // Stun Gaze
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 54;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Sarutahiko(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 98; // Berserk
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 76; // Lightoma
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 409; // Haggle
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 48; // Petradi
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 36;
            tblSkill.fclSkillTbl[id].Event[4].Param = 305; // Counter
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 37;
            tblSkill.fclSkillTbl[id].Event[5].Param = 224; // Focus
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[6].Param = 97; // Hell Thrust
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 39;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 480;
            datDevilFormat.tbl[id].maxhp = 480;
            datDevilFormat.tbl[id].mp = 168;
            datDevilFormat.tbl[id].maxmp = 168;
        }

        private static void Sudama(ushort id)
        {
            // Enemy Stats
            datDevilFormat.tbl[id].hp = 114;
            datDevilFormat.tbl[id].maxhp = 114;
            datDevilFormat.tbl[id].mp = 80;
            datDevilFormat.tbl[id].maxmp = 80;
        }

        private static void HuaPo(ushort id)
        {
            // Enemy Stats
            datDevilFormat.tbl[id].hp = 54;
            datDevilFormat.tbl[id].maxhp = 54;
            datDevilFormat.tbl[id].mp = 40;
            datDevilFormat.tbl[id].maxmp = 40;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 214;

            // AI
            datDevilAI.divTbls[0][91].aitable[1][0].skill = 1;
            datDevilAI.divTbls[0][91].aitable[1][0].ritu = 60;
            datDevilAI.divTbls[0][91].aitable[1][1].skill = 32768;
            datDevilAI.divTbls[0][91].aitable[1][1].ritu = 30;
            datDevilAI.divTbls[0][91].aitable[1][2].skill = 214;
            datDevilAI.divTbls[0][91].aitable[1][2].ritu = 10;

            datDevilAI.divTbls[0][91].aitable[2][0].skill = 1;
            datDevilAI.divTbls[0][91].aitable[2][0].ritu = 60;
            datDevilAI.divTbls[0][91].aitable[2][1].skill = 32768;
            datDevilAI.divTbls[0][91].aitable[2][1].ritu = 10;
            datDevilAI.divTbls[0][91].aitable[2][2].skill = 4;
            datDevilAI.divTbls[0][91].aitable[2][2].ritu = 20;
            datDevilAI.divTbls[0][91].aitable[2][3].skill = 214;
            datDevilAI.divTbls[0][91].aitable[2][3].ritu = 10;
        }

        private static void Kodama(ushort id)
        {
            //tblSkill.fclSkillTbl[id].Event[2].Param = 39;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 24;
            datDevilFormat.tbl[id].maxhp = 24;
            datDevilFormat.tbl[id].mp = 28;
            datDevilFormat.tbl[id].maxmp = 28;
        }

        private static void Oni(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[7].Param = 428; // Defense Kuzushi
        }

        private static void YomotsuIkusa(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 114; // Arid Needle
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 48; // Petradi
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 71; // Analyze
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 397; // Begging
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 45;
            tblSkill.fclSkillTbl[id].Event[4].Param = 107; // Mighty Gust
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[5].Param = 448; // Poison Volley
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 47;
            tblSkill.fclSkillTbl[id].Event[6].Param = 33; // Mudoon
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 48;
            tblSkill.fclSkillTbl[id].Event[7].Param = 390; // Dark Pledge
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 49;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Momunofu(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 96; // Lunge
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 413; // Persuade
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 224; // Focus
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 21;
            tblSkill.fclSkillTbl[id].Event[4].Param = 290; // Life Bonus
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 22;
            tblSkill.fclSkillTbl[id].Event[5].Param = 107; // Mighty Gust
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 23;
            tblSkill.fclSkillTbl[id].Event[6].Param = 116; // Kamikaze
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 24;
        }

        private static void Shikigami(ushort id)
        {
            // Affinities
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 48;
            datDevilFormat.tbl[id].maxhp = 48;
            datDevilFormat.tbl[id].mp = 36;
            datDevilFormat.tbl[id].maxmp = 36;
            
            // AI
            datDevilAI.divTbls[0][97].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][97].aitable[1][0].ritu = 20;
            datDevilAI.divTbls[0][97].aitable[1][1].skill = 13;
            datDevilAI.divTbls[0][97].aitable[1][1].ritu = 50;
            datDevilAI.divTbls[0][97].aitable[1][2].skill = 52;
            datDevilAI.divTbls[0][97].aitable[1][2].ritu = 10;
            datDevilAI.divTbls[0][97].aitable[1][3].skill = 53;
            datDevilAI.divTbls[0][97].aitable[1][3].ritu = 10;
            datDevilAI.divTbls[0][97].aitable[1][4].skill = 64;
            datDevilAI.divTbls[0][97].aitable[1][4].ritu = 10;
        }

        private static void Rangda(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 350; // Mana Refill
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 73;
            tblSkill.fclSkillTbl[id].Event[4].Param = 178; // Prominence
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 74;
            tblSkill.fclSkillTbl[id].Event[5].Param = 434; // Bloodbath
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 75;
            tblSkill.fclSkillTbl[id].Event[6].Param = 56; // Makajamon
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 76;
            tblSkill.fclSkillTbl[id].Event[7].Param = 445; // Vayavya
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 77;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Dakini(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 207; // Dismal Tune
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 346; // Life Aid
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 34; // Mamudo
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 102; // Blight
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 53;
            tblSkill.fclSkillTbl[id].Event[4].Param = 3; // Agidyne
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 54;
            tblSkill.fclSkillTbl[id].Event[5].Param = 345; // Endure
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 55;
            tblSkill.fclSkillTbl[id].Event[6].Param = 105; // Dark Sword
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 56;
            tblSkill.fclSkillTbl[id].Event[7].Param = 386; // Kidnap
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 57;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }


        private static void Yaksini(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 386; // Kidnap
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 109; // Guillotine
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 74; // Riberama
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 21; // Zandyne
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 44;
            tblSkill.fclSkillTbl[id].Event[4].Param = 211; // Binding Cry
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 45;
            tblSkill.fclSkillTbl[id].Event[5].Param = 325; // Null Ice
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[6].Param = 63; // Tentarafoo
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 47;
            tblSkill.fclSkillTbl[id].Event[7].Param = 306; // Retaliate
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 48;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void YomotsuShikome(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 401;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 197; // Stone Gaze
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 23; // Mazanma
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 319; // Anti-Dark
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 33;
            tblSkill.fclSkillTbl[id].Event[4].Param = 213; // Sonic Wave
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 34;
            tblSkill.fclSkillTbl[id].Event[5].Param = 112; // Stun Needle
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 35;
            tblSkill.fclSkillTbl[id].Event[6].Param = 448; // Poison Volley
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 36;
            tblSkill.fclSkillTbl[id].Event[7].Param = 302; // Drain Attack
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 37;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Taraka(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 59; // Shibaboo
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 66; // Rakukaja
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 71; // Analyze
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 205; // Taunt
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 21;
            tblSkill.fclSkillTbl[id].Event[4].Param = 392; // Beseech
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 22;
            tblSkill.fclSkillTbl[id].Event[5].Param = 116; // Kamikaze
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 23;
            tblSkill.fclSkillTbl[id].Event[6].Param = 14; // Zionga
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 24;
            tblSkill.fclSkillTbl[id].Event[7].Param = 101; // Heat Wave
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 25;
        }

        private static void DatsueBa(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 111; // Needle Rush
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 59; // Shibaboo
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 7; // Bufu
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 409; // Haggle
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 8;
            tblSkill.fclSkillTbl[id].Event[4].Param = 43; // Patra
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 9;
            tblSkill.fclSkillTbl[id].Event[5].Param = 55; // Makajam
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 10;
            tblSkill.fclSkillTbl[id].Event[6].Param = 60; // Dormina
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 11;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 72;
            datDevilFormat.tbl[id].maxhp = 72;
            datDevilFormat.tbl[id].mp = 60;
            datDevilFormat.tbl[id].maxmp = 60;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 7;

            // AI
            datDevilAI.divTbls[0][103].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][103].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[0][103].aitable[0][1].skill = 59;
            datDevilAI.divTbls[0][103].aitable[0][1].ritu = 40;
            datDevilAI.divTbls[0][103].aitable[0][2].skill = 7;
            datDevilAI.divTbls[0][103].aitable[0][2].ritu = 30;
        }

        private static void Mada(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[4].Param = 459; // Luster Candy
            tblSkill.fclSkillTbl[id].Event[5].Param = 365; // Anti-Ailments
            tblSkill.fclSkillTbl[id].Event[6].Param = 292; // Life Surge
            tblSkill.fclSkillTbl[id].Event[7].Param = 38; // Diarahan
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 88;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Girimekhala(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][6] = 2147483798; // Light
            datAisyo.tbl[id][10] = 2147483798; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[4].Param = 450; // Neural Shock
            tblSkill.fclSkillTbl[id].Event[5].Param = 450; // Neural Shock
            tblSkill.fclSkillTbl[id].Event[8].Param = 102; // Blight
            tblSkill.fclSkillTbl[id].Event[9].Param = 102; // Blight
            tblSkill.fclSkillTbl[id].Event[10].Param = 105; // Dark Sword
            tblSkill.fclSkillTbl[id].Event[10].TargetLevel = 63;
            tblSkill.fclSkillTbl[id].Event[10].Type = 1;
            tblSkill.fclSkillTbl[id].Event[11].Param = 105; // Dark Sword
            tblSkill.fclSkillTbl[id].Event[11].TargetLevel = 63;
            tblSkill.fclSkillTbl[id].Event[11].Type = 6;
        }

        private static void Taotie(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 25; // Megido
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 68; // Tetraja
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 192; // Life Drain
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 367; // Knowledge of Tools
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 66;
            tblSkill.fclSkillTbl[id].Event[4].Param = 196; // Hell Gaze
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 67;
            tblSkill.fclSkillTbl[id].Event[5].Param = 330; // Null Curse
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 68;
            tblSkill.fclSkillTbl[id].Event[6].Param = 401;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[7].Param = 26; // Megidola
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 70;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Pazuzu(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 196; // Hell Gaze
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 185; // Tornado
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 414; // Intimidate
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 327; // Force
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[4].Param = 40; // Mediarama
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 47;
            tblSkill.fclSkillTbl[id].Event[5].Param = 114; // Arid Needle
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 48;
            tblSkill.fclSkillTbl[id].Event[6].Param = 63; // Tentarafoo
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 49;
            tblSkill.fclSkillTbl[id].Event[7].Param = 187; // Wet Wind
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 50;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Baphomet(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 67; // Makakaja
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 223; // Beckon Call
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 390; // Dark Pledge
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 5; // Maragion
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 34;
            tblSkill.fclSkillTbl[id].Event[4].Param = 446; // Damnation
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 35;
            tblSkill.fclSkillTbl[id].Event[5].Param = 207; // Dismal Tune
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 36;
            tblSkill.fclSkillTbl[id].Event[6].Param = 293; // Mana Bonus
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 37;
            tblSkill.fclSkillTbl[id].Event[7].Param = 424; // Concentrate
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Mot(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[3].Param = 363; // Magic Boost
            tblSkill.fclSkillTbl[id].Event[4].Param = 27; // Megidolaon
            tblSkill.fclSkillTbl[id].Event[5].Param = 364; // Anti-Magic
            tblSkill.fclSkillTbl[id].Event[6].Param = 223; // Beckon Call
            tblSkill.fclSkillTbl[id].Event[7].Param = 445; // Vayavya
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 96;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Aciel(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[4].Param = 208; // Sol Niger
            tblSkill.fclSkillTbl[id].Event[5].Param = 208; // Sol Niger
            tblSkill.fclSkillTbl[id].Event[6].Param = 70; // Tetrakarn
            tblSkill.fclSkillTbl[id].Event[7].Param = 70; // Tetrakarn
            tblSkill.fclSkillTbl[id].Event[8].Param = 122; // Hell Fang
            tblSkill.fclSkillTbl[id].Event[9].Param = 122; // Hell Fang
            tblSkill.fclSkillTbl[id].Event[10].Param = 348; // Victory Cry
            tblSkill.fclSkillTbl[id].Event[10].TargetLevel = 82;
            tblSkill.fclSkillTbl[id].Event[10].Type = 1;
            tblSkill.fclSkillTbl[id].Event[11].Param = 348; // Victory Cry
            tblSkill.fclSkillTbl[id].Event[11].TargetLevel = 82;
            tblSkill.fclSkillTbl[id].Event[11].Type = 6;
        }

        private static void Surt(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][8] = 65536; // Curse

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 178; // Prominence
            tblSkill.fclSkillTbl[id].Event[1].Param = 368; // Laevateinn
            tblSkill.fclSkillTbl[id].Event[3].Param = 203; // War Cry
            tblSkill.fclSkillTbl[id].Event[4].Param = 336; // Elec Drain
            tblSkill.fclSkillTbl[id].Event[5].Param = 436; // Ragnarok
            tblSkill.fclSkillTbl[id].Event[6].Param = 304; // Attack All
            tblSkill.fclSkillTbl[id].Event[7].Param = 391; // Wooing
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 79;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Abaddon(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[5].Param = 100; // Hades Blast
            tblSkill.fclSkillTbl[id].Event[6].Param = 307; // Avenge
            tblSkill.fclSkillTbl[id].Event[7].Param = 340; // Ice Repel
        }

        private static void Loki(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 12; // Mabufudyne
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 56; // Makajamon
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 437; // Refrigerate
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 394; // Mischief
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 53;
            tblSkill.fclSkillTbl[id].Event[4].Param = 355; // Charisma
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 54;
            tblSkill.fclSkillTbl[id].Event[5].Param = 325; // Null Ice
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 55;
            tblSkill.fclSkillTbl[id].Event[6].Param = 72; // Trafuri
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 56;
            tblSkill.fclSkillTbl[id].Event[7].Param = 33; // Mudoon
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 57;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Lilith(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 441; // Thunder Gods
            tblSkill.fclSkillTbl[id].Event[4].Param = 441; // Thunder Gods
            tblSkill.fclSkillTbl[id].Event[5].Param = 455; // Soul Drain
            tblSkill.fclSkillTbl[id].Event[6].Param = 455; // Soul Drain
            tblSkill.fclSkillTbl[id].Event[7].Param = 122; // Hell Fang
            tblSkill.fclSkillTbl[id].Event[8].Param = 122; // Hell Fang
            tblSkill.fclSkillTbl[id].Event[9].Param = 295; // Mana Surge
            tblSkill.fclSkillTbl[id].Event[10].Param = 295; // Mana Surge
            tblSkill.fclSkillTbl[id].Event[11].Param = 27; // Megidolaon
            tblSkill.fclSkillTbl[id].Event[11].TargetLevel = 85;
            tblSkill.fclSkillTbl[id].Event[11].Type = 1;
            tblSkill.fclSkillTbl[id].Event[12].Param = 27; // Megidolaon
            tblSkill.fclSkillTbl[id].Event[12].TargetLevel = 85;
            tblSkill.fclSkillTbl[id].Event[12].Type = 6;
        }

        private static void Nyx(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[4].Param = 181; // Glacial Blast
            tblSkill.fclSkillTbl[id].Event[5].Param = 455; // Soul Drain
            tblSkill.fclSkillTbl[id].Event[6].Param = 334; // Fire Drain
            tblSkill.fclSkillTbl[id].Event[7].Param = 26; // Megidola
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 74;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void QueenMab(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 41; // Mediarahan
            tblSkill.fclSkillTbl[id].Event[4].Param = 41; // Mediarahan
            tblSkill.fclSkillTbl[id].Event[5].Param = 18; // Maziodyne
            tblSkill.fclSkillTbl[id].Event[6].Param = 18; // Maziodyne
            tblSkill.fclSkillTbl[id].Event[7].Param = 69; // Makarakarn
            tblSkill.fclSkillTbl[id].Event[8].Param = 69; // Makarakarn
            tblSkill.fclSkillTbl[id].Event[9].Param = 424; // Concentrate
            tblSkill.fclSkillTbl[id].Event[10].Param = 424; // Concentrate
            tblSkill.fclSkillTbl[id].Event[11].Param = 452; // Pulinpaon
            tblSkill.fclSkillTbl[id].Event[12].Param = 452; // Pulinpaon
        }

        private static void Succubus(ushort id)
        {
            // Affinities
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
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 420; // Flatter
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 214; // Sexy Gaze
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 461; // Storm Gale
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 125; // Stun Claw
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 26;
            tblSkill.fclSkillTbl[id].Event[4].Param = 391; // Wooing
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 27;
            tblSkill.fclSkillTbl[id].Event[5].Param = 199; // Evil Gaze
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 28;
            tblSkill.fclSkillTbl[id].Event[6].Param = 192; // Life Drain
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[7].Param = 23; // Mazanma
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 30;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Fomorian(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 7; // Bufu
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 210; // Lullaby
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 96; // Lunge
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 98; // Berserk
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 19;
            tblSkill.fclSkillTbl[id].Event[4].Param = 290; // Life Bonus
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 20;
            tblSkill.fclSkillTbl[id].Event[5].Param = 386; // Kidnap
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 21;
            tblSkill.fclSkillTbl[id].Event[6].Param = 10; // Mabufu
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 22;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 192;
            datDevilFormat.tbl[id].maxhp = 192;
            datDevilFormat.tbl[id].mp = 100;
            datDevilFormat.tbl[id].maxmp = 100;
        }

        private static void Lilim(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 54; // Rakunda
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 214; // Sexy Gaze
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 71; // Analyze
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 61; // Pulinpa
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 9;
            tblSkill.fclSkillTbl[id].Event[3].Type = 1;
            tblSkill.fclSkillTbl[id].Event[4].Param = 390; // Dark Pledge
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 10;
            tblSkill.fclSkillTbl[id].Event[5].Param = 52; // Tarunda
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 11;
            tblSkill.fclSkillTbl[id].Event[6].Param = 16; // Mazio
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 12;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 78;
            datDevilFormat.tbl[id].maxhp = 78;
            datDevilFormat.tbl[id].mp = 64;
            datDevilFormat.tbl[id].maxmp = 64;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[4] = 61; // Pulinpa

            // AI
            datDevilAI.divTbls[0][120].aitable[1][0].skill = 214;
            datDevilAI.divTbls[0][120].aitable[1][0].ritu = 40;
            datDevilAI.divTbls[0][120].aitable[1][1].skill = 16;
            datDevilAI.divTbls[0][120].aitable[1][1].ritu = 40;
            datDevilAI.divTbls[0][120].aitable[1][2].skill = 61;
            datDevilAI.divTbls[0][120].aitable[1][2].ritu = 20;

            datDevilAI.divTbls[0][120].aitable[2][0].skill = 16;
            datDevilAI.divTbls[0][120].aitable[2][0].ritu = 40;
            datDevilAI.divTbls[0][120].aitable[2][1].skill = 61;
            datDevilAI.divTbls[0][120].aitable[2][1].ritu = 40;
            datDevilAI.divTbls[0][120].aitable[2][2].skill = 32768;
            datDevilAI.divTbls[0][120].aitable[2][2].ritu = 20;

            // Negotiation Items
            datDevilNegoFormat.tbl[120].itema[0].item = 36;
        }

        private static void Hresvelgr(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[2].Param = 462; // Winged Fury
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 126; // Iron Claw
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 76;
            tblSkill.fclSkillTbl[id].Event[4].Param = 323; // Null Phys
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 77;
            tblSkill.fclSkillTbl[id].Event[5].Param = 349; // Life Refill
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 78;
            tblSkill.fclSkillTbl[id].Event[6].Param = 365; // Anti-Ailments
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 79;
            tblSkill.fclSkillTbl[id].Event[7].Param = 341; // Elec Repel
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 80;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Mothman(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][8] = 65536; // Curse

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 199; // Evil Gaze
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 125; // Stun Claw
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 216; // Panic Voice
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 72; // Trafuri
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 44;
            tblSkill.fclSkillTbl[id].Event[4].Param = 177; // Hellfire
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 45;
            tblSkill.fclSkillTbl[id].Event[5].Param = 450; // Neural Shock
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[6].Param = 326; // Null Elec
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 47;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 452; // Pulinpaon
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 48;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Raiju(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 14; // Zionga
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 76; // Lightoma
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 440; // Jolt
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 123; // Feral Claw
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 26;
            tblSkill.fclSkillTbl[id].Event[4].Param = 182; // Shock
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 27;
            tblSkill.fclSkillTbl[id].Event[5].Param = 111; // Needle Rush
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 28;
            tblSkill.fclSkillTbl[id].Event[6].Param = 311; // Elec Boost
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void Nue(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 125; // Stun Claw
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 203; // War Cry
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 180; // Ice Breath
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 437; // Refrigerate
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 32;
            tblSkill.fclSkillTbl[id].Event[4].Param = 216; // Panic Voice
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 33;
            tblSkill.fclSkillTbl[id].Event[5].Param = 310; // Ice Boost
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 34;
            tblSkill.fclSkillTbl[id].Event[6].Param = 34; // Mamudo
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 35;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void Zhen(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 209; // Stun Gaze
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 46; // Posumudi
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 19; // Zan
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 113; // Venom Needle
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 7;
            tblSkill.fclSkillTbl[id].Event[4].Param = 90; // Poison Arrow
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 8;
            tblSkill.fclSkillTbl[id].Event[5].Param = 461; // Storm Gale
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 9;
            tblSkill.fclSkillTbl[id].Event[6].Param = 203; // War Cry
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 10;
            tblSkill.fclSkillTbl[id].Event[7].Param = 331; // Null Nerve
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 11;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 72;
            datDevilFormat.tbl[id].maxhp = 72;
            datDevilFormat.tbl[id].mp = 48;
            datDevilFormat.tbl[id].maxmp = 48;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 461;
            datDevilFormat.tbl[id].skill[3] = 90;

            // AI
            datDevilAI.divTbls[0][126].aitable[0][0].skill = 461;
            datDevilAI.divTbls[0][126].aitable[0][0].ritu = 35;
            datDevilAI.divTbls[0][126].aitable[0][1].skill = 32768;
            datDevilAI.divTbls[0][126].aitable[0][1].ritu = 35;
            datDevilAI.divTbls[0][126].aitable[0][2].skill = 90;
            datDevilAI.divTbls[0][126].aitable[0][2].ritu = 30;

            datDevilAI.divTbls[0][126].aitable[1][0].skill = 113;
            datDevilAI.divTbls[0][126].aitable[1][0].ritu = 60;
            datDevilAI.divTbls[0][126].aitable[1][1].skill = 461;
            datDevilAI.divTbls[0][126].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[0][126].aitable[1][2].skill = 32768;
            datDevilAI.divTbls[0][126].aitable[1][2].ritu = 10;
            datDevilAI.divTbls[0][126].aitable[1][3].skill = 90;
            datDevilAI.divTbls[0][126].aitable[1][3].ritu = 10;

            datDevilAI.divTbls[0][126].aitable[2][0].skill = 461;
            datDevilAI.divTbls[0][126].aitable[2][0].ritu = 30;
            datDevilAI.divTbls[0][126].aitable[2][1].skill = 113;
            datDevilAI.divTbls[0][126].aitable[2][1].ritu = 20;
            datDevilAI.divTbls[0][126].aitable[2][2].skill = 32768;
            datDevilAI.divTbls[0][126].aitable[2][2].ritu = 10;
            datDevilAI.divTbls[0][126].aitable[2][3].skill = 203;
            datDevilAI.divTbls[0][126].aitable[2][3].ritu = 20;
            datDevilAI.divTbls[0][126].aitable[2][4].skill = 90;
            datDevilAI.divTbls[0][126].aitable[2][4].ritu = 20;
        }

        private static void Vetala(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 125; // Stun Claw
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 192; // Life Drain
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 449; // Poison Salvo
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 115; // Sacrifice
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 64;
            tblSkill.fclSkillTbl[id].Event[4].Param = 306; // Retaliate
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 65;
            tblSkill.fclSkillTbl[id].Event[5].Param = 202; // Toxic Cloud
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 66;
            tblSkill.fclSkillTbl[id].Event[6].Param = 25; // Megido
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 67;
            tblSkill.fclSkillTbl[id].Event[7].Param = 434; // Bloodbath
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 68;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Legion(ushort id)
        {
            tblSkill.fclSkillTbl[id].Event[5].Param = 452; // Pulinpaon
        }

        private static void Yaka(ushort id)
        {
            tblSkill.fclSkillTbl[id].Event[2].Param = 34; // Mamudo

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 150;
            datDevilFormat.tbl[id].maxhp = 150;
            datDevilFormat.tbl[id].mp = 108;
            datDevilFormat.tbl[id].maxmp = 108;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 34; // Mamudo

            // AI
            datDevilAI.divTbls[1][1].aitable[0][0].skill = 34;
            datDevilAI.divTbls[1][1].aitable[0][0].ritu = 55;

            datDevilAI.divTbls[1][1].aitable[1][2].skill = 34;
            datDevilAI.divTbls[1][1].aitable[1][2].ritu = 10;
        }

        private static void Choronzon(ushort id)
        {
            // Affinities
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 182;
            datDevilFormat.tbl[id].maxhp = 182;
            datDevilFormat.tbl[id].mp = 60;
            datDevilFormat.tbl[id].maxmp = 60;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[2] = 1;
            datDevilFormat.tbl[id].skill[3] = 53;
            datDevilFormat.tbl[id].skill[4] = 176;

            // AI
            datDevilAI.divTbls[1][2].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[1][2].aitable[0][0].ritu = 10;
            datDevilAI.divTbls[1][2].aitable[0][1].skill = 98;
            datDevilAI.divTbls[1][2].aitable[0][1].ritu = 50;
            datDevilAI.divTbls[1][2].aitable[0][2].skill = 1;
            datDevilAI.divTbls[1][2].aitable[0][2].ritu = 10;
            datDevilAI.divTbls[1][2].aitable[0][3].skill = 176;
            datDevilAI.divTbls[1][2].aitable[0][3].ritu = 30;

            datDevilAI.divTbls[1][2].aitable[1][0].skill = 197;
            datDevilAI.divTbls[1][2].aitable[1][0].ritu = 50;
            datDevilAI.divTbls[1][2].aitable[1][1].skill = 53;
            datDevilAI.divTbls[1][2].aitable[1][1].ritu = 50;

            datDevilAI.divTbls[1][2].aitable[2][0].skill = 197;
            datDevilAI.divTbls[1][2].aitable[2][0].ritu = 30;
            datDevilAI.divTbls[1][2].aitable[2][1].skill = 98;
            datDevilAI.divTbls[1][2].aitable[2][1].ritu = 30;
            datDevilAI.divTbls[1][2].aitable[2][2].skill = 176;
            datDevilAI.divTbls[1][2].aitable[2][2].ritu = 20;
            datDevilAI.divTbls[1][2].aitable[2][3].skill = 53;
            datDevilAI.divTbls[1][2].aitable[2][3].ritu = 20;
        }

        private static void Preta(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 123; // Feral Claw
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 65; // Sukukaja
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 190; // Deathtouch
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 5;
            tblSkill.fclSkillTbl[id].Event[3].Param = 124; // Venom Claw
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 6;
            tblSkill.fclSkillTbl[id].Event[4].Param = 32; // Mudo
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 7;
            tblSkill.fclSkillTbl[id].Event[5].Param = 204; // Fog Breath
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 8;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 40;
            datDevilFormat.tbl[id].maxhp = 40;
            datDevilFormat.tbl[id].mp = 32;
            datDevilFormat.tbl[id].maxmp = 32;
        }

        private static void Shadow(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 18; // Maziodyne
        }

        private static void BlackOoze(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 198; // Mute Gaze
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 119; // Charm Bite
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 190; // Deathtouch
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 448; // Poison Volley
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[4].Param = 115; // Sacrifice
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 30;
            tblSkill.fclSkillTbl[id].Event[5].Param = 191; // Mana Drain
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 31;
            tblSkill.fclSkillTbl[id].Event[6].Param = 216; // Panic Voice
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 32;
            tblSkill.fclSkillTbl[id].Event[7].Param = 318; // Anti-Light
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 33;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Blob(ushort id)
        {
            // Affinities
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 156;
            datDevilFormat.tbl[id].maxhp = 156;
            datDevilFormat.tbl[id].mp = 88;
            datDevilFormat.tbl[id].maxmp = 88;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[2] = 52; // Tarunda
            datDevilFormat.tbl[id].skill[3] = 191; // Mana Drain
            datDevilFormat.tbl[id].skill[4] = 152; // Last Resort

            // AI
            datDevilAI.divTbls[1][6].aitable[0][0].skill = 113;
            datDevilAI.divTbls[1][6].aitable[0][0].ritu = 25;
            datDevilAI.divTbls[1][6].aitable[0][1].skill = 32768;
            datDevilAI.divTbls[1][6].aitable[0][1].ritu = 70;
            datDevilAI.divTbls[1][6].aitable[0][2].skill = 152;
            datDevilAI.divTbls[1][6].aitable[0][2].ritu = 5;

            datDevilAI.divTbls[1][6].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[1][6].aitable[1][0].ritu = 40;
            datDevilAI.divTbls[1][6].aitable[1][1].skill = 20;
            datDevilAI.divTbls[1][6].aitable[1][1].ritu = 40;
            datDevilAI.divTbls[1][6].aitable[1][2].skill = 52;
            datDevilAI.divTbls[1][6].aitable[1][2].ritu = 20;
        }

        private static void Slime(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 190; // Deathtouch
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 117; // Feral Bite
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 202; // Toxic Cloud
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 7;
            tblSkill.fclSkillTbl[id].Event[3].Param = 118; // Venom Bite
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 8;
            tblSkill.fclSkillTbl[id].Event[4].Param = 152; // Last Resort
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 9;
            tblSkill.fclSkillTbl[id].Event[5].Param = 213; // Sonic Wave
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 10;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 66;
            datDevilFormat.tbl[id].maxhp = 66;
            datDevilFormat.tbl[id].mp = 44;
            datDevilFormat.tbl[id].maxmp = 44;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 190;
            datDevilFormat.tbl[id].skill[4] = 117;
            datDevilFormat.tbl[id].skill[5] = 202;

            // AI
            datDevilAI.divTbls[1][7].aitable[0][0].skill = 213;
            datDevilAI.divTbls[1][7].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[1][7].aitable[0][1].skill = 32768;
            datDevilAI.divTbls[1][7].aitable[0][1].ritu = 40;
            datDevilAI.divTbls[1][7].aitable[0][2].skill = 117;
            datDevilAI.divTbls[1][7].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[1][7].aitable[0][3].skill = 202;
            datDevilAI.divTbls[1][7].aitable[0][3].ritu = 20;

            datDevilAI.divTbls[1][7].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[1][7].aitable[1][0].ritu = 35;
            datDevilAI.divTbls[1][7].aitable[1][1].skill = 213;
            datDevilAI.divTbls[1][7].aitable[1][1].ritu = 25;
            datDevilAI.divTbls[1][7].aitable[1][2].skill = 36999;
            datDevilAI.divTbls[1][7].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[1][7].aitable[1][3].skill = 152;
            datDevilAI.divTbls[1][7].aitable[1][3].ritu = 10;
            datDevilAI.divTbls[1][7].aitable[1][4].skill = 190;
            datDevilAI.divTbls[1][7].aitable[1][4].ritu = 10;

            datDevilAI.divTbls[1][7].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[1][7].aitable[2][0].ritu = 60;
            datDevilAI.divTbls[1][7].aitable[2][1].skill = 117;
            datDevilAI.divTbls[1][7].aitable[2][1].ritu = 40;
        }

        private static void MouRyo(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 61; // Pulinpa
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 113; // Venom Needle
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 32; // Mudo
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 1; // Agi
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 8;
            tblSkill.fclSkillTbl[id].Event[4].Param = 190; // Deathtouch
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 9;
            tblSkill.fclSkillTbl[id].Event[5].Param = 347; // Mana Aid
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 10;
            tblSkill.fclSkillTbl[id].Event[6].Param = 4; // Maragi
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 11;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 66;
            datDevilFormat.tbl[id].maxhp = 66;
            datDevilFormat.tbl[id].mp = 56;
            datDevilFormat.tbl[id].maxmp = 56;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 1;
            datDevilFormat.tbl[id].skill[4] = 32;

            // AI
            datDevilAI.divTbls[1][8].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[1][8].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[1][8].aitable[0][1].skill = 190;
            datDevilAI.divTbls[1][8].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[1][8].aitable[0][2].skill = 61;
            datDevilAI.divTbls[1][8].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[1][8].aitable[0][3].skill = 32;
            datDevilAI.divTbls[1][8].aitable[0][3].ritu = 20;
            datDevilAI.divTbls[1][8].aitable[0][4].skill = 113;
            datDevilAI.divTbls[1][8].aitable[0][4].ritu = 20;

            datDevilAI.divTbls[1][8].aitable[1][0].skill = 1;
            datDevilAI.divTbls[1][8].aitable[1][0].ritu = 20;
            datDevilAI.divTbls[1][8].aitable[1][1].skill = 190;
            datDevilAI.divTbls[1][8].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[1][8].aitable[1][2].skill = 61;
            datDevilAI.divTbls[1][8].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[1][8].aitable[1][3].skill = 32;
            datDevilAI.divTbls[1][8].aitable[1][3].ritu = 20;
            datDevilAI.divTbls[1][8].aitable[1][4].skill = 113;
            datDevilAI.divTbls[1][8].aitable[1][4].ritu = 20;
        }

        private static void WillOWisp(ushort id)
        {
            // Affinities
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 20;
            datDevilFormat.tbl[id].maxhp = 20;
            datDevilFormat.tbl[id].mp = 24;
            datDevilFormat.tbl[id].maxmp = 24;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[2] = 111;

            // AI
            datDevilAI.divTbls[1][9].aitable[0][0].skill = 190;
            datDevilAI.divTbls[1][9].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[1][9].aitable[0][1].skill = 32768;
            datDevilAI.divTbls[1][9].aitable[0][1].ritu = 40;
            datDevilAI.divTbls[1][9].aitable[0][2].skill = 111;
            datDevilAI.divTbls[1][9].aitable[0][2].ritu = 30;

            datDevilAI.divTbls[1][9].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[1][9].aitable[2][0].ritu = 30;
            datDevilAI.divTbls[1][9].aitable[2][1].skill = 67;
            datDevilAI.divTbls[1][9].aitable[2][1].ritu = 50;
            datDevilAI.divTbls[1][9].aitable[2][2].skill = 111;
            datDevilAI.divTbls[1][9].aitable[2][2].ritu = 20;
        }

        private static void Michael(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[2].Param = 362; // Phys Boost
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 348; // Victory Cry
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 91;
            tblSkill.fclSkillTbl[id].Event[4].Param = 459; // Luster Candy
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 92;
            tblSkill.fclSkillTbl[id].Event[5].Param = 467; // Divine Light
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 93;
            tblSkill.fclSkillTbl[id].Event[6].Param = 295; // Mana Surge
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 94;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 27; // Megidolaon
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 95;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Gabriel(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[1].Param = 439; // Fimbulvetr
            tblSkill.fclSkillTbl[id].Event[2].Param = 424; // Concentrate
            tblSkill.fclSkillTbl[id].Event[3].Param = 426; // Sakura Rage
            tblSkill.fclSkillTbl[id].Event[4].Param = 459; // Luster Candy
            tblSkill.fclSkillTbl[id].Event[5].Param = 195; // Radiance
            tblSkill.fclSkillTbl[id].Event[6].Param = 363; // Magic Boost
            tblSkill.fclSkillTbl[id].Event[7].Param = 413; // Persuade
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 92;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Raphael(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 462; // Winged Fury
            tblSkill.fclSkillTbl[id].Event[2].Param = 106; // Stasis Blade
            tblSkill.fclSkillTbl[id].Event[3].Param = 31; // Mahamaon
            tblSkill.fclSkillTbl[id].Event[4].Param = 218; // Prayer
            tblSkill.fclSkillTbl[id].Event[5].Param = 366; // Abyssal Mask
            tblSkill.fclSkillTbl[id].Event[6].Param = 350; // Mana Refill
            tblSkill.fclSkillTbl[id].Event[7].Param = 189; // Judgement Light
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 89;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Uriel(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 431; // Revelation
            tblSkill.fclSkillTbl[id].Event[1].Param = 179; // Trisagion
            tblSkill.fclSkillTbl[id].Event[2].Param = 26; // Megidola
            tblSkill.fclSkillTbl[id].Event[3].Param = 195; // Radiance
            tblSkill.fclSkillTbl[id].Event[4].Param = 458; // Heat Riser
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 78;
            tblSkill.fclSkillTbl[id].Event[4].Type = 6;
        }

        private static void Ganesha(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 362; // Phys Boost
            tblSkill.fclSkillTbl[id].Event[1].Param = 323; // Null Phys
            tblSkill.fclSkillTbl[id].Event[2].Param = 459; // Luster Candy
            tblSkill.fclSkillTbl[id].Event[3].Param = 155; // Earthquake
            tblSkill.fclSkillTbl[id].Event[4].Param = 337; // Force Drain
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 63;
            tblSkill.fclSkillTbl[id].Event[4].Type = 6;
            tblSkill.fclSkillTbl[id].Event[5].Param = 365; // Anti-Ailments
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 64;
            tblSkill.fclSkillTbl[id].Event[5].Type = 6;
        }

        private static void Valkyrie(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 305; // Counter
            tblSkill.fclSkillTbl[id].Event[3].Param = 305; // Counter
            tblSkill.fclSkillTbl[id].Event[4].Param = 393; // Soul Recruit
            tblSkill.fclSkillTbl[id].Event[5].Param = 393; // Soul Recruit
            tblSkill.fclSkillTbl[id].Event[6].Param = 109; // Guillotine
            tblSkill.fclSkillTbl[id].Event[7].Param = 109; // Guillotine
            tblSkill.fclSkillTbl[id].Event[8].Param = 299; // Might
            tblSkill.fclSkillTbl[id].Event[9].Param = 299; // Might
            tblSkill.fclSkillTbl[id].Event[10].Param = 362; // Phys Boost
            tblSkill.fclSkillTbl[id].Event[10].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[10].Type = 1;
            tblSkill.fclSkillTbl[id].Event[11].Param = 362; // Phys Boost
            tblSkill.fclSkillTbl[id].Event[11].TargetLevel = 39;
            tblSkill.fclSkillTbl[id].Event[11].Type = 6;
        }

        private static void Arahabaki(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[2].Param = 197; // Stone Gaze
            tblSkill.fclSkillTbl[id].Event[3].Param = 197; // Stone Gaze
            tblSkill.fclSkillTbl[id].Event[4].Param = 446; // Damnation
            tblSkill.fclSkillTbl[id].Event[5].Param = 446; // Damnation
            tblSkill.fclSkillTbl[id].Event[6].Param = 216; // Panic Voice
            tblSkill.fclSkillTbl[id].Event[7].Param = 216; // Panic Voice
            tblSkill.fclSkillTbl[id].Event[8].Param = 25; // Megido
            tblSkill.fclSkillTbl[id].Event[9].Param = 25; // Megido
            tblSkill.fclSkillTbl[id].Event[10].Param = 365; // Anti-Ailments
            tblSkill.fclSkillTbl[id].Event[11].Param = 365; // Anti-Ailments
        }

        private static void KuramaTengu(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 21; // Zandyne
        }

        private static void CuChulainn(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys

            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 21; // Zandyne
            tblSkill.fclSkillTbl[id].Event[4].Param = 21; // Zandyne
            tblSkill.fclSkillTbl[id].Event[5].Param = 426; // Sakura Rage
            tblSkill.fclSkillTbl[id].Event[6].Param = 426; // Sakura Rage
            tblSkill.fclSkillTbl[id].Event[7].Param = 362; // Phys Boost
            tblSkill.fclSkillTbl[id].Event[8].Param = 362; // Phys Boost
            tblSkill.fclSkillTbl[id].Event[9].Param = 304; // Attack All
            tblSkill.fclSkillTbl[id].Event[10].Param = 304; // Attack All
            tblSkill.fclSkillTbl[id].Event[11].Param = 108; // Deathbound
            tblSkill.fclSkillTbl[id].Event[12].Param = 108; // Deathbound
        }

        private static void QingLong(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[3].Param = 185; // Tornado
            tblSkill.fclSkillTbl[id].Event[4].Param = 185; // Tornado
            tblSkill.fclSkillTbl[id].Event[5].Param = 120; // Stone Bite
            tblSkill.fclSkillTbl[id].Event[6].Param = 120; // Stone Bite
            tblSkill.fclSkillTbl[id].Event[7].Param = 181; // Glacial Blast
            tblSkill.fclSkillTbl[id].Event[8].Param = 181; // Glacial Blast
            tblSkill.fclSkillTbl[id].Event[9].Param = 291; // Life Gain
            tblSkill.fclSkillTbl[id].Event[10].Param = 291; // Life Gain
            tblSkill.fclSkillTbl[id].Event[11].Param = 29; // Hamaon
            tblSkill.fclSkillTbl[id].Event[11].TargetLevel = 49;
            tblSkill.fclSkillTbl[id].Event[11].Type = 1;
            tblSkill.fclSkillTbl[id].Event[12].Param = 29; // Hamaon
            tblSkill.fclSkillTbl[id].Event[12].TargetLevel = 49;
            tblSkill.fclSkillTbl[id].Event[12].Type = 6;
        }

        private static void Xuanwu(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[10].Param = 430; // Chi Blast
            tblSkill.fclSkillTbl[id].Event[10].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[10].Type = 1;
            tblSkill.fclSkillTbl[id].Event[11].Param = 430; // Chi Blast
            tblSkill.fclSkillTbl[id].Event[11].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[11].Type = 6;
        }

        private static void Barong(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][2] = 50; // Ice

            // Skills
            tblSkill.fclSkillTbl[id].Event[6].Param = 413; // Persuade
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 65;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void Garuda(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][4] = 131072; // Force
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 31; // Mahamaon
            tblSkill.fclSkillTbl[id].Event[1].Param = 186; // Wind Cutter
            tblSkill.fclSkillTbl[id].Event[2].Param = 345; // Endure
            tblSkill.fclSkillTbl[id].Event[3].Param = 126; // Iron Claw
        }

        private static void Yatagarasu(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[1].Param = 29; // Hamaon
            tblSkill.fclSkillTbl[id].Event[2].Param = 21; // Zandyne
            tblSkill.fclSkillTbl[id].Event[6].Param = 444; // Heavenly Cyclone
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 51;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void Gurulu(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][4] = 131072; // Force
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 447; // Millenia Curse
            tblSkill.fclSkillTbl[id].Event[4].Param = 447; // Millenia Curse
            tblSkill.fclSkillTbl[id].Event[5].Param = 183; // Bolt Storm
            tblSkill.fclSkillTbl[id].Event[6].Param = 183; // Bolt Storm
            tblSkill.fclSkillTbl[id].Event[7].Param = 326; // Null Elec
            tblSkill.fclSkillTbl[id].Event[8].Param = 326; // Null Elec
            tblSkill.fclSkillTbl[id].Event[9].Param = 186; // Wind Cutter
            tblSkill.fclSkillTbl[id].Event[10].Param = 186; // Wind Cutter
            tblSkill.fclSkillTbl[id].Event[11].Param = 307; // Avenge
            tblSkill.fclSkillTbl[id].Event[12].Param = 307; // Avenge
        }

        private static void Albion(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][1] = 80; // Fire
            datAisyo.tbl[id][2] = 80; // Ice
            datAisyo.tbl[id][3] = 80; // Elec
            datAisyo.tbl[id][4] = 80; // Force

            // Skills
            tblSkill.fclSkillTbl[id].Event[4].Param = 100; // Hades Blast
            tblSkill.fclSkillTbl[id].Event[5].Param = 100; // Hades Blast
            tblSkill.fclSkillTbl[id].Event[6].Param = 333; // Phys Drain
            tblSkill.fclSkillTbl[id].Event[7].Param = 333; // Phys Drain
            tblSkill.fclSkillTbl[id].Event[8].Param = 106; // Stasis Blade
            tblSkill.fclSkillTbl[id].Event[9].Param = 106; // Stasis Blade
            tblSkill.fclSkillTbl[id].Event[10].Param = 51; // Recarmdra
            tblSkill.fclSkillTbl[id].Event[10].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[10].Type = 1;
            tblSkill.fclSkillTbl[id].Event[11].Param = 51; // Recarmdra
            tblSkill.fclSkillTbl[id].Event[11].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[11].Type = 6;
        }

        private static void Samael(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 432; // Gate of Hell
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[6].Param = 242; // God's Curse
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 77;
            tblSkill.fclSkillTbl[id].Event[7].Param = 338; // Phys Repel
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 78;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Pisaca(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 90; // Poison Arrow
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 53; // Sukunda
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 209; // Stun Gaze
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 440; // Jolt
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 29;
            tblSkill.fclSkillTbl[id].Event[4].Param = 192; // Life Drain
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 30;
            tblSkill.fclSkillTbl[id].Event[5].Param = 213; // Sonic Wave
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 31;
            tblSkill.fclSkillTbl[id].Event[6].Param = 77; // Dekunda
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 32;
            tblSkill.fclSkillTbl[id].Event[7].Param = 17; // Mazionga
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 33;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Kaiwan(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[6].Param = 447; // Millenia Curse
        }

        private static void KinKi(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 10; // Phys
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 99; // Tempest
            tblSkill.fclSkillTbl[id].Event[4].Param = 205; // Taunt
            tblSkill.fclSkillTbl[id].Event[5].Param = 434; // Bloodbath
            tblSkill.fclSkillTbl[id].Event[6].Param = 323; // Null Phys
            tblSkill.fclSkillTbl[id].Event[7].Param = 433; // Akashic Arts
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 64;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void SuiKi(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 426; // Sakura Rage
            tblSkill.fclSkillTbl[id].Event[4].Param = 199; // Evil Gaze
            tblSkill.fclSkillTbl[id].Event[5].Param = 9; // Bufudyne
            tblSkill.fclSkillTbl[id].Event[6].Param = 346; // Life Aid
            tblSkill.fclSkillTbl[id].Event[7].Param = 385; // Scout
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 67;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void FuuKi(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][3] = 2147483798; // Elec
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[7].Param = 429; // Primal Force
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 67;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void OngyoKi(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 105; // Dark Sword
            tblSkill.fclSkillTbl[id].Event[1].Param = 33; // Mudoon
            tblSkill.fclSkillTbl[id].Event[2].Param = 26; // Megidola
            tblSkill.fclSkillTbl[id].Event[3].Param = 432; // Gate of Hell
            tblSkill.fclSkillTbl[id].Event[4].Param = 362; // Phys Boost
            tblSkill.fclSkillTbl[id].Event[5].Param = 223; // Beckon Call
            tblSkill.fclSkillTbl[id].Event[6].Param = 458; // Heat Riser
            tblSkill.fclSkillTbl[id].Event[7].Param = 348; // Victory Cry
        }

        private static void Clotho(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[1].Param = 31; // Mahamaon
            tblSkill.fclSkillTbl[id].Event[3].Param = 41; // Mediarahan
            tblSkill.fclSkillTbl[id].Event[4].Param = 215; // Allure
            tblSkill.fclSkillTbl[id].Event[5].Param = 50; // Samarecarm
            tblSkill.fclSkillTbl[id].Event[6].Param = 25; // Megido
            tblSkill.fclSkillTbl[id].Event[7].Param = 212; // Eternal Rest
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 63;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Lachesis(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 50; // Dark

            // Skills
            tblSkill.fclSkillTbl[id].Event[4].Param = 70; // Tetrakarn
            tblSkill.fclSkillTbl[id].Event[5].Param = 206; // Debilitate
            tblSkill.fclSkillTbl[id].Event[6].Param = 304; // Attack All
            tblSkill.fclSkillTbl[id].Event[7].Param = 72; // Trafuri
        }

        private static void Atropos(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 3; // Agidyne
            tblSkill.fclSkillTbl[id].Event[4].Param = 295; // Mana Surge
            tblSkill.fclSkillTbl[id].Event[5].Param = 26; // Megidola
            tblSkill.fclSkillTbl[id].Event[6].Param = 363; // Magic Boost
            tblSkill.fclSkillTbl[id].Event[7].Param = 0;
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[7].Type = 0;
        }

        private static void Loa(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 34; // Mamudo
            tblSkill.fclSkillTbl[id].Event[1].Param = 68; // Tetraja
            tblSkill.fclSkillTbl[id].Event[2].Param = 77; // Dekunda
            tblSkill.fclSkillTbl[id].Event[3].Param = 448; // Poison Volley
            tblSkill.fclSkillTbl[id].Event[4].Param = 35; // Mamudoon
            tblSkill.fclSkillTbl[id].Event[5].Param = 451; // Neural Storm
            tblSkill.fclSkillTbl[id].Event[6].Param = 206; // Debilitate
            tblSkill.fclSkillTbl[id].Event[7].Param = 152; // Last Resort
        }

        private static void Chatterskull(ushort id)
        {
            // Enemy Stats
            datDevilFormat.tbl[id].hp = 156;
            datDevilFormat.tbl[id].maxhp = 156;
            datDevilFormat.tbl[id].mp = 128;
            datDevilFormat.tbl[id].maxmp = 128;
        }

        private static void Phantom(ushort id)
        {
            // Affinities
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
            // Affinities
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
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[1].Param = 6; // Maragidyne
            tblSkill.fclSkillTbl[id].Event[2].Param = 431; // Revelation
            tblSkill.fclSkillTbl[id].Event[3].Param = 27; // Megidolaon
            tblSkill.fclSkillTbl[id].Event[5].Param = 458; // Heat Riser
        }

        private static void BeelzebubFly(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[1].Param = 24; // Mazandyne
            tblSkill.fclSkillTbl[id].Event[6].Param = 462; // Winged Fury
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 98;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 462; // Winged Fury
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 98;
            tblSkill.fclSkillTbl[id].Event[7].Type = 6;
            tblSkill.fclSkillTbl[id].Event[8].Param = 442; // Thunder Reign
            tblSkill.fclSkillTbl[id].Event[8].TargetLevel = 99;
            tblSkill.fclSkillTbl[id].Event[8].Type = 1;
            tblSkill.fclSkillTbl[id].Event[9].Param = 442; // Thunder Reign
            tblSkill.fclSkillTbl[id].Event[9].TargetLevel = 99;
            tblSkill.fclSkillTbl[id].Event[9].Type = 6;
        }

        private static void PaleRider(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 79; // Pestilence
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 63; // Tentarafoo
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 102; // Blight
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 212; // Eternal Rest
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 64;
            tblSkill.fclSkillTbl[id].Event[4].Param = 449; // Poison Salvo
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 65;
            tblSkill.fclSkillTbl[id].Event[5].Param = 451; // Neural Storm
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 66;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 206; // Debilitate
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 67;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 431; // Revelation
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 68;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void WhiteRider(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 287; // God's Bow
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 68; // Tetraja
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 31; // Mahamaon
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 178; // Prominence
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 53;
            tblSkill.fclSkillTbl[id].Event[4].Param = 57; // Dekaja
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 54;
            tblSkill.fclSkillTbl[id].Event[5].Param = 347; // Mana Aid
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 55;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 323; // Null Phys
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 56;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 179; // Trisagion
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 57;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void RedRider(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 280; // Terrorblade
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 183; // Bolt Storm
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 77; // Dekunda
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 64; // Tarukaja
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 56;
            tblSkill.fclSkillTbl[id].Event[4].Param = 428; // Defense Kuzushi
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 57;
            tblSkill.fclSkillTbl[id].Event[5].Param = 451; // Neural Storm
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 58;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 307; // Avenge
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 59;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 186; // Wind Cutter
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 60;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void BlackRider(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 261; // Soul Divide
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 181; // Glacial Blast
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 192; // Life Drain
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 65; // Sukukaja
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 62;
            tblSkill.fclSkillTbl[id].Event[4].Param = 447; // Millenia Curse
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 63;
            tblSkill.fclSkillTbl[id].Event[5].Param = 26; // Megidola
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 64;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 295; // Mana Surge
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 65;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 439; // Fimbulvetr
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 66;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Matador(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 443; // Dervish
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 275; // Andalucia
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 224; // Focus
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 77; // Dekunda
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 31;
            tblSkill.fclSkillTbl[id].Event[4].Param = 205; // Taunt
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 32;
            tblSkill.fclSkillTbl[id].Event[5].Param = 276; // Red Capote
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 33;
            tblSkill.fclSkillTbl[id].Event[6].Param = 349; // Life Refill
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 34;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 306; // Retaliate
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 35;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void HellBiker(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[0].Param = 281; // Hell Spin
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 282; // Hell Exhaust
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 435; // Scald
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 97; // Hell Thrust
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 43;
            tblSkill.fclSkillTbl[id].Event[4].Param = 283; // Hell Burner
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 44;
            tblSkill.fclSkillTbl[id].Event[4].Type = 1;
            tblSkill.fclSkillTbl[id].Event[5].Param = 284; // Hell Throttle
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 45;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 309; // Fire Boost
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 46;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 292; // Life Surge
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 47;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Daisoujou(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 279; // Meditation
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 30; // Mahama
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 67; // Makakaja
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 34; // Mamudo
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[4].Param = 424; // Concentrate
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 39;
            tblSkill.fclSkillTbl[id].Event[5].Param = 278; // Preach
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 40;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 457; // Diamrita
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 41;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 331; // Null Nerve
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 42;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void MotherHarlot(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[5].Param = 441; // Thunder Gods
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 72;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 451; // Neural Storm
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 73;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 286; // Death Lust
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 74;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void Trumpeter(ushort id)
        {
            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[5].Param = 458; // Heat Riser
            tblSkill.fclSkillTbl[id].Event[6].Param = 57; // Dekaja
            tblSkill.fclSkillTbl[id].Event[7].Param = 453; // Antichthon
            tblSkill.fclSkillTbl[id].Event[8].Param = 27; // Megidolaon
            tblSkill.fclSkillTbl[id].Event[9].Param = 159; // Evil Melody
            tblSkill.fclSkillTbl[id].Event[9].TargetLevel = 82;
            tblSkill.fclSkillTbl[id].Event[9].Type = 1;
        }

        private static void BlackFrost(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 262144; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483798; // Light
            datAisyo.tbl[id][7] = 65536; // Dark

            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 205; // Taunt
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 466; // Jack Bufudyne
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 67;
            tblSkill.fclSkillTbl[id].Event[4].Param = 434; // Bloodbath
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 68;
            tblSkill.fclSkillTbl[id].Event[5].Param = 6; // Maragidyne
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[6].Param = 365; // Anti-Ailments
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 70;
            tblSkill.fclSkillTbl[id].Event[7].Param = 438; // Cocytus
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 71;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void BeelzebubMan(ushort id)
        {
            datDevilFormat.tbl[id].aisyoid = (short) id;

            // Affinities
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
            tblSkill.fclSkillTbl[id].Event[1].Param = 24; // Mazandyne
            tblSkill.fclSkillTbl[id].Event[2].Param = 27; // Megidolaon
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Type = 1;
            tblSkill.fclSkillTbl[id].Event[3].Param = 354; // Endure
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 85;
            tblSkill.fclSkillTbl[id].Event[3].Type = 1;
            tblSkill.fclSkillTbl[id].Event[4].Param = 0;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 85;
            tblSkill.fclSkillTbl[id].Event[4].Type = 7;
            tblSkill.fclSkillTbl[id].Event[5].Param = 311; // Elec Boost
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 86;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 194; // Starlight
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 86;
            tblSkill.fclSkillTbl[id].Event[6].Type = 5;
        }

        // 2148532374 = Weak but status-immune

        private static void BossForneus(ushort id)
        {
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

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 800;
            datDevilFormat.tbl[id].hp = 800;
            datDevilFormat.tbl[id].param[0] = 7;
            datDevilFormat.tbl[id].param[2] = 7;
            
            datDevilFormat.tbl[id].dropexp = 200;
            //datDevilFormat.tbl[id].dropmakka = 65000;
            //datDevilAI.divTbls[2][0].ailevel = 0;
        }

        private static void BossSpecter1(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Stats
            datDevilFormat.tbl[id].maxhp = 160;
            datDevilFormat.tbl[id].hp = 160;
        }

        private static void BossSpecter1Merged1(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 600;
            datDevilFormat.tbl[id].hp = 600;
            datDevilFormat.tbl[id].flag = 547;
        }

        private static void BossSpecter1Merged2(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Stats
            datDevilFormat.tbl[id].maxhp = 300;
            datDevilFormat.tbl[id].hp = 300;
            datDevilFormat.tbl[id].flag = 547;
        }

        private static void BossSpecter1Merged3(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 160;
            datDevilFormat.tbl[id].hp = 160;
            datDevilFormat.tbl[id].flag = 547;
        }

        private static void BossTroll(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 262144; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 2147483898; // Nerve
            datAisyo.tbl[id][10] = 2147483898; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 1400;
            datDevilFormat.tbl[id].hp = 1400;
            datDevilFormat.tbl[id].level = 18;
            datDevilFormat.tbl[id].param[0] = 14;
            datDevilFormat.tbl[id].param[2] = 10;
            datDevilFormat.tbl[id].param[4] = 9;
            datDevilFormat.tbl[id].param[5] = 9;

            datDevilFormat.tbl[id].dropexp = 200;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 98; // Berserk
            datDevilFormat.tbl[id].skill[1] = 181; // Glacial Blast
            datDevilFormat.tbl[id].skill[2] = 427; // Fang Breaker
            datDevilFormat.tbl[id].skill[3] = 219; // Rage

            // AI
            datDevilAI.divTbls[2][59].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[2][59].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[2][59].aitable[0][1].skill = 98;
            datDevilAI.divTbls[2][59].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[2][59].aitable[0][2].skill = 181;
            datDevilAI.divTbls[2][59].aitable[0][2].ritu = 30;
            datDevilAI.divTbls[2][59].aitable[0][2].skill = 427;
            datDevilAI.divTbls[2][59].aitable[0][2].ritu = 30;

            datDevilAI.divTbls[2][60].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[2][60].aitable[1][0].ritu = 15;
            datDevilAI.divTbls[2][60].aitable[1][1].skill = 98;
            datDevilAI.divTbls[2][60].aitable[1][1].ritu = 15;
            datDevilAI.divTbls[2][60].aitable[1][2].skill = 181;
            datDevilAI.divTbls[2][60].aitable[1][2].ritu = 55;
            datDevilAI.divTbls[2][60].aitable[1][2].skill = 427;
            datDevilAI.divTbls[2][60].aitable[1][2].ritu = 15;
        }

        private static void ForcedNekomata(ushort id)
        {
            // Affinities
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 240;
            datDevilFormat.tbl[id].maxhp = 240;
            datDevilFormat.tbl[id].mp = 120;
            datDevilFormat.tbl[id].maxmp = 120;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[1] = 125;
            datDevilFormat.tbl[id].skill[2] = 198;

            // AI
            datDevilAI.divTbls[2][60].aitable[0][0].skill = 62;
            datDevilAI.divTbls[2][60].aitable[0][0].ritu = 50;
            datDevilAI.divTbls[2][60].aitable[0][1].skill = 125;
            datDevilAI.divTbls[2][60].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[2][60].aitable[0][2].skill = 32768;
            datDevilAI.divTbls[2][60].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[2][60].aitable[0][2].skill = 198;
            datDevilAI.divTbls[2][60].aitable[0][2].ritu = 10;

            datDevilAI.divTbls[2][60].aitable[1][0].skill = 62;
            datDevilAI.divTbls[2][60].aitable[1][0].ritu = 30;
            datDevilAI.divTbls[2][60].aitable[1][1].skill = 125;
            datDevilAI.divTbls[2][60].aitable[1][1].ritu = 30;
            datDevilAI.divTbls[2][60].aitable[1][2].skill = 32768;
            datDevilAI.divTbls[2][60].aitable[1][2].ritu = 30;
            datDevilAI.divTbls[2][60].aitable[1][2].skill = 198;
            datDevilAI.divTbls[2][60].aitable[1][2].ritu = 10;

            datDevilAI.divTbls[2][60].aitable[2][0].skill = 125;
            datDevilAI.divTbls[2][60].aitable[2][0].ritu = 50;
            datDevilAI.divTbls[2][60].aitable[2][1].skill = 32768;
            datDevilAI.divTbls[2][60].aitable[2][1].ritu = 50;
        }

        private static void ForcedWillOWisp(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 60; // Phys
            datAisyo.tbl[id][1] = 2147483798; // Fire
            datAisyo.tbl[id][2] = 2147483798; // Ice
            datAisyo.tbl[id][3] = 2147483798; // Elec
            datAisyo.tbl[id][4] = 2147483798; // Force
            datAisyo.tbl[id][6] = 2147483798; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Stats
            datDevilFormat.tbl[id].param[0] = 2;
            datDevilFormat.tbl[id].param[2] = 3;

            // Display Skill
            datDevilFormat.tbl[id].skill[1] = 67;

            // AI
            datDevilAI.divTbls[2][62].aitable[1][0].skill = 67;
        }

        private static void ForcedPreta(ushort id)
        {
            // Affinities
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 20;
            datDevilFormat.tbl[id].maxhp = 20;
            datDevilFormat.tbl[id].mp = 32;
            datDevilFormat.tbl[id].maxmp = 32;
        }

        private static void BossMatador(ushort id)
        {
            // Affinities
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

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 2000;
            datDevilFormat.tbl[id].hp = 2000;
            datDevilFormat.tbl[id].param[0] = 6;
            datDevilFormat.tbl[id].flag = 34;

            // Display Skill
            datDevilFormat.tbl[id].skill[0] = 366;
        }
    }
}