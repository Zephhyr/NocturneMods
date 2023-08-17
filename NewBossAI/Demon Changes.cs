using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2Cppnewbattle_H;
using Il2Cppeffect_H;
using UnityEngine;

namespace NewBossAI
{
    internal partial class NewBossAI : MelonMod
    {
        [HarmonyPatch(typeof(Localize), nameof(Localize.GetLocalizeText), new Type[] { typeof(string) })]
        private class LocalizeNamesPatch
        {
            public static bool Prefix(ref string ID, ref string __result)
            {
                switch (ID)
                {
                    case "<AISYO_L0015>": // Dionysus
                        __result = "Null: Fire/Light/Dark/Mind • Weak: Ice"; return false;
                    case "<AISYO_L0019>": // Kushinada
                        __result = "Rpl: Light • Str: Ailments • Weak: Dark"; return false;
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
                    case "<AISYO_L0102>": // Taraka
                        __result = "Null: Elec/Nerve • Str: Dark • Weak: Ice"; return false;
                    case "<AISYO_L0103>": // Datsue-Ba
                        __result = "Null: Nerve/Mind • Str: Ice • Weak: Elec"; return false;
                    case "<AISYO_L0107>": // Pazuzu
                        __result = "Null: Dark • Str: Force/Mind • Weak: Ice"; return false;
                    case "<AISYO_L0117>": // Succubus
                        __result = "Null: Mind • Str: Ice/Curse/Nerve • Weak: Light"; return false;
                    case "<AISYO_L0118>": // Incubus
                        __result = "Null: Curse/Mind • Str: Dark • Weak: Force"; return false;
                    case "<AISYO_L0120>": // Lilim
                        __result = "Null: Elec • Str: Dark/Mind • Weak: Ice"; return false;
                    case "<AISYO_L0122>": // Mothman
                        __result = "Null: Fire/Dark/Curse • Weak: Elec"; return false;
                    case "<AISYO_L0126>": // Zhen
                        __result = "Str: Dark/Ailments • Weak: Fire"; return false;
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
                    case "<AISYO_L0144>": // Arahabaki
                        __result = "Null: Phys • Str: Light/Dark • Weak: Magic/Ailments"; return false;
                    case "<AISYO_L0148>": // Qing Long
                        __result = "Drn: Force • Null: Light • Str: Ice • Weak: Fire"; return false;
                    case "<AISYO_L0149>": // Xuanwu
                        __result = "Drn: Ice • Null: Light • Str: Curse • Weak: Elec"; return false;
                    case "<AISYO_L0178>": // Phantom
                        __result = "Null: Dark • Str: Phys/Elec • Weak: Force/Light"; return false;
                    case "<AISYO_L0199>": // Matador
                        __result = "Null: Force/Dark"; return false;
                    case "<AISYO_L0200>": // Hell Biker
                        __result = "Null: Fire/Force • Str: Dark/Curse"; return false;
                    case "<AISYO_L0201>": // Daisoujou
                        __result = "Drn: Curse/Mind • Null: Light/Dark"; return false;
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
            Atavaka(5);
            Horus(6);

            Sarasvati(9);
            Sati(10);

            Dionysus(15);

            Kushinada(19);
            KikuriHime(20);

            TakeMikazuchi(24);
            Okuninushi(25);
            Koumokuten(26);
            Zouchouten(27);
            TakeMinakata(28);

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

            Jinn(47);
            KarasuTengu(48);
            Dis(49);
            Isora(50);
            KoppaTengu(52);

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

            Ose(71);
            Berith(72);
            Eligor(73);
            Forneus(74);

            NagaRaja(77);
            Nozuchi(80);

            Orthrus(82);
            BadbCatha(84);
            Nekomata(86);

            Titan(88);
            Sarutahiko(89);

            Oni(94);
            YomotsuIkusa(95);
            Momunofu(96);
            Shikigami(97);
            
            Yaksini(100);
            YomotsuShikome(101);
            Taraka(102);
            DatsueBa(103);

            Pazuzu(107);
            Baphomet(108);

            Succubus(117);
            Incubus(118);
            Fomorian(119);
            Lilim(120);

            Mothman(122);
            Raiju(123);
            Nue(124);
            Zhen(126);

            Legion(128);
            Yaka(129);
            Choronzon(130);
            Preta(131);

            BlackOoze(133);
            Blob(134);
            Slime(135);
            MouRyo(136);
            WillOWisp(137);

            Valkyrie(143);

            Arahabaki(144);

            KuramaTengu(145);

            QingLong(148);
            Xuanwu(149);

            Yatagarasu(153);

            Pisaca(167);

            Kaiwan(168);

            Phantom(178);

            Matador(199);
            HellBiker(200);
            Daisoujou(201);

            // Bosses
            BossForneus(256);
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

        private static void Dionysus(ushort id)
        {
            // Affinties
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[4].Param = 426;
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
            tblSkill.fclSkillTbl[id].Event[3].Param = 11;
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
            tblSkill.fclSkillTbl[id].Event[11].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[10].Type = 6;
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

        private static void Yatagarasu(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[1].Param = 29;
            tblSkill.fclSkillTbl[id].Event[2].Param = 21;
            tblSkill.fclSkillTbl[id].Event[6].Param = 444;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 51;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
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