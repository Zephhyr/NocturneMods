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
        [HarmonyPatch(typeof(Localize), "GetLocalizeText", new Type[] { typeof(string) })]
        private class LocalizeNamesPatch
        {
            public static bool Prefix(ref string ID, ref string __result)
            {
                switch (ID)
                {
                    case "<AISYO_L0033>": // Shiisaa
                        __result = "Null: Elec/Light • Str: Force • Weak: Fire"; return false;
                    case "<AISYO_L0038>": // Aeros
                        __result = "Null: Force • Weak: Elec"; return false;
                    case "<AISYO_L0039>": // Erthys
                        __result = "Str: Elec • Weak: Force"; return false;
                    case "<AISYO_L0050>": // Isora
                        __result = "Null: Ice • Weak: Fire"; return false;
                    case "<AISYO_L0068>": // Angel
                        __result = "Null: Light • Str: Force • Weak: Elec/Dark"; return false;
                    case "<AISYO_L0080>": // Nozuchi
                        __result = "Null: Force/Curse • Weak: Elec"; return false;
                    case "<AISYO_L0097>": // Shikigami
                        __result = "Null: Elec • Weak: Fire"; return false;
                    case "<AISYO_L0103>": // Datsue-Ba
                        __result = "Null: Nerve/Mind • Str: Ice • Weak: Elec"; return false;
                    case "<AISYO_L0120>": // Lilim
                        __result = "Null: Elec • Str: Dark/Mind • Weak: Ice"; return false;
                    case "<AISYO_L0126>": // Zhen
                        __result = "Str: Dark/Ailments • Weak: Fire"; return false;
                    case "<AISYO_L0130>": // Choronzon
                        __result = "Null: Fire/Dark • Str: Phys • Weak: Force/Light"; return false;
                    case "<AISYO_L0131>": // Preta
                        __result = "Null: Dark • Weak: Magic/Light"; return false;
                    case "<AISYO_L0135>": // Slime
                        __result = "Null: Dark • Str: Phys • Weak: Magic/Light"; return false;
                    case "<AISYO_L0136>": // Mou-Ryo
                        __result = "Null: Dark • Str: Fire • Weak: Light"; return false;
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
            Shiisaa(33);
            Aeros(38);
            Erthys(39);
            Isora(50);
            HighPixie(59);
            JackFrost(60);
            Pixie(61);
            Angel(68);
            NagaRaja(77);
            Nozuchi(80);
            Shikigami(97);
            Yaksini(100);
            DatsueBa(103);
            Lilim(120);
            Zhen(126);
            Preta(131);
            Slime(135);
            MouRyo(136);
            WillOWisp(137);

            // Bosses
            BossForneus(256);
        }

        // 2148532374 = Weak but status-immune

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

            tblSkill.fclSkillTbl[id].Event[0].Param = 182;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 123;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 203;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 14;
            tblSkill.fclSkillTbl[id].Event[3].Param = 388;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 15;
            tblSkill.fclSkillTbl[id].Event[4].Param = 121;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 16;
            tblSkill.fclSkillTbl[id].Event[5].Param = 305;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 17;
            tblSkill.fclSkillTbl[id].Event[6].Param = 314;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 18;
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

        private static void HighPixie(ushort id)
        {
            tblSkill.fclSkillTbl[id].Event[1].Param = 461;
        }

        private static void JackFrost(ushort id)
        {
            tblSkill.fclSkillTbl[id].Event[0].Param = 463;
        }

        private static void Pixie(ushort id)
        {
            tblSkill.fclSkillTbl[id].Event[6].Param = 461;
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

        private static void NagaRaja(ushort id)
        {
            //datDevilFormat.tbl[id].skill[4] = 367;
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

            tblSkill.fclSkillTbl[id].Event[0].Param = 96;
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 90;
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 420;
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 305;
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 15;
            tblSkill.fclSkillTbl[id].Event[3].Type = 1;
            tblSkill.fclSkillTbl[id].Event[4].Param = 66;
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 16;
            tblSkill.fclSkillTbl[id].Event[5].Param = 202;
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 17;
            tblSkill.fclSkillTbl[id].Event[6].Param = 115;
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 18;
        }

        private static void Yaksini(ushort id)
        {
            //tblSkill.fclSkillTbl[id].Event[0].Param = 208;
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

        private static void Choronzon(ushort id)
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
        }

        private static void Preta(ushort id)
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

        private static void BossForneus(ushort id)
        {
            datDevilFormat.tbl[id].maxhp = 800;
            datDevilFormat.tbl[id].hp = 800;
            datDevilAI.divTbls[2][0].ailevel = 0;

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