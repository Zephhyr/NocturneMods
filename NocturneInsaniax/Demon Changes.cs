using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2Cppnewbattle_H;
using Il2Cppeffect_H;
using UnityEngine;
using Il2Cppmodel_H;

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
                        __result = "Rpl: Force • Str: Fire • Weak: Curse"; return false;
                    case "<AISYO_L0049>": // Dís
                        __result = "Drn: Fire • Weak: Dark"; return false;
                    case "<AISYO_L0050>": // Isora
                        __result = "Null: Ice • Weak: Fire"; return false;
                    case "<AISYO_L0055>": // Troll
                        __result = "Drn: Ice • Weak: Nerve/Mind"; return false;
                    case "<AISYO_L0057>": // Kelpie
                        __result = "Str: Ice/Elec/Nerve • Weak: Force"; return false;
                    case "<AISYO_L0063>": // Dominion
                        __result = "Rpl: Light • Str: Force • Weak: Dark/Curse"; return false;
                    case "<AISYO_L0064>": // Virtue
                        __result = "Rpl: Light • Str: Elec • Weak: Force/Dark"; return false;
                    case "<AISYO_L0067>": // Archangel
                        __result = "Null: Light • Str: Fire • Weak: Ice/Dark"; return false;
                    case "<AISYO_L0068>": // Angel
                        __result = "Null: Light • Str: Force • Weak: Elec/Dark"; return false;
                    case "<AISYO_L0069>": // Flauros
                        __result = "Rpl: Dark • Null: Fire • Weak: Nerve"; return false;
                    case "<AISYO_L0072>": // Berith
                        __result = "Drn: Fire • Null: Dark • Str: Phys • Weak: Force"; return false;
                    case "<AISYO_L0080>": // Nozuchi
                        __result = "Null: Force/Curse • Weak: Elec"; return false;
                    case "<AISYO_L0081>": // Cerberus
                        __result = "Rpl: Fire • Str: Phys/Ailments • Weak: Ice"; return false;
                    case "<AISYO_L0082>": // Orthrus
                        __result = "Drn: Fire • Str: Dark/Mind • Weak: Ice"; return false;
                    case "<AISYO_L0084>": // Babd Catha
                        __result = "Str: Phys/Force/Dark • Weak: Elec"; return false;
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
                    case "<AISYO_L0100>": // Yaksini
                        __result = "Null: Force • Str: Curse/Nerve • Weak: Elec"; return false;
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
                    case "<AISYO_L0145>": // Kurama Tengu
                        __result = "Drn: Force • Null: Fire/Light"; return false;
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
                    case "<AISYO_L0156>": // Manikin
                        __result = "Normal resistance"; return false;
                    case "<AISYO_L0157>": // Manikin
                        __result = "Normal resistance"; return false;
                    case "<AISYO_L0158>": // Manikin
                        __result = "Normal resistance"; return false;
                    case "<AISYO_L0159>": // Manikin
                        __result = "Normal resistance"; return false;
                    case "<AISYO_L0160>": // Manikin
                        __result = "Normal resistance"; return false;
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
                        __result = "Null: Light/Dark • Str: Nerve/Mind"; return false;
                    case "<AISYO_L0174>": // Lachesis
                        __result = "Null: Light/Dark • Str: Curse/Nerve"; return false;
                    case "<AISYO_L0175>": // Atropos
                        __result = "Null: Light/Dark • Str: Curse/Mind"; return false;
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
                        __result = "Null: Curse/Mind • Str: Phys/Light/Dark • Weak: Ice"; return false;
                    case "<DEVIL_L0224>":
                        __result = "Tam Lin"; return false;
                    case "<AISYO_L0224>":
                        __result = "Str: Fire/Elec/Light • Weak: Ice/Dark"; return false;
                    case "<DEVIL_L0225>":
                        __result = "Doppelgänger"; return false;
                    case "<AISYO_L0225>":
                        __result = "Rpl: Phys • Str: Ailments • Weak: Light/Dark"; return false;
                    case "<DEVIL_L0226>":
                        __result = "Nightmare"; return false;
                    case "<AISYO_L0226>":
                        __result = "Null: Dark/Mind • Str: Ice/Force/Nerve • Weak: Elec/Light"; return false;
                    case "<DEVIL_L0227>":
                        __result = "Gdon"; return false;
                    case "<AISYO_L0227>":
                        __result = "Drn: Fire • Str: Phys/Light/Mind • Weak: Ice/Curse"; return false;
                    case "<DEVIL_L0252>":
                        __result = "Dante"; return false;
                    case "<AISYO_L0252>":
                        __result = "Str: All except Almighty"; return false;
                    case "<DEVIL_L0253>":
                        __result = "Gamete"; return false;
                    case "<AISYO_L0253>":
                        __result = "Null: Dark • Str: Phys • Weak: Fire/Light"; return false;
                    case "<DEVIL_L0254>":
                        __result = "YHVH"; return false;
                    case "<AISYO_L0254>":
                        __result = "Str: All"; return false;
                    case "<DEVIL_L0362>":
                        __result = "Flauros"; return false;
                    case "<AISYO_L0362>":
                        __result = "Rpl: Dark • Null: Fire • Weak: Nerve"; return false;
                    case "<AISYO_L0410>": // Djed
                        __result = "Str: Ailments"; return false;
                    case "<AISYO_L0411>": // Djed
                        __result = "Str: Ailments"; return false;
                    case "<AISYO_L0412>": // Muspell
                        __result = "Str: Light/Dark"; return false;
                    case "<AISYO_L0413>": // Muspell
                        __result = "Str: Light/Dark"; return false;
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
                    case "<COLLECTIONBOOK_L0224>":
                        __result = "A faerie knight from Scotland. As a member of the Seelie Court, he is charged with protecting Carterhaugh. He was originally a child from the area, but after his kidnapping by the faeries at age nine, he took up their ways."; break;
                    case "<COLLECTIONBOOK_L0225>":
                        __result = "A phantom copy of a living being. Doppelgängers are a sign of bad luck. Often, others see your doppelgänger from afar, but it is said you may also see your own doppelgänger right before you die."; break;
                    case "<COLLECTIONBOOK_L0226>":
                        __result = "A malevolent spirit which inflicts bad dreams upon sleeping people. They are often depicted as ghostly black horses with manes of fire or smoke, fading away into the night."; break;
                    case "<COLLECTIONBOOK_L0227>":
                        __result = "The tiger mount of the goddess Durga, of Hindu mythology. Durga was born to defeat the Asura Mahisha, and Gdon was granted to her to help complete the task."; break;
                    default: break;
                }
            }
        }

        [HarmonyPatch(typeof(fclCombineCalcCore), nameof(fclCombineCalcCore.cmbChkIkenieExtPatternDev))]
        private class SpecialFusionPatch
        {
            public static void Postfix(ref datUnitWork_t pDevil1, ref datUnitWork_t pDevil2, ref datUnitWork_t pSacrifice,
                                        ref sbyte CurseFlag, ref sbyte LevelMode, ref ushort __result)
            {
                var normalResult = fclCombineCalcCore.cmbCalcNormal2(pDevil1, pDevil2, CurseFlag, LevelMode);
                if (normalResult == 71 && (pSacrifice.id == 62 || datDevilFormat.Get(pSacrifice.id).race == 24))
                    __result = 179;
                else if (normalResult == 69 && (pSacrifice.id == 62 || datDevilFormat.Get(pSacrifice.id).race == 24))
                    __result = 180;
                else if (normalResult == 90 && pSacrifice.id == 39)
                    __result = 181;
                else if (normalResult == 90 && pSacrifice.id == 36)
                    __result = 182;
                else if (normalResult == 90 && pSacrifice.id == 38)
                    __result = 183;
                else if (normalResult == 90 && pSacrifice.id == 37)
                    __result = 184;
                else if (normalResult == 178 && pSacrifice.id == 130)
                    __result = 185;
                else if (datDevilFormat.Get(normalResult).race == 19 && pSacrifice.id == 135)
                    __result = 186;
                else if (datDevilFormat.Get(normalResult).race == 10 && pSacrifice.id == 125)
                    __result = 224;
                //else
                //    __result = 225;
            }
        }

        private static datUnitVisual_t CopyDevilVisual(datUnitVisual_t origin)
        {
            return new datUnitVisual_t
            {
                center = origin.center,
                formsize = origin.formsize,
                formheight = origin.formheight,
                formscale = origin.formscale,
                oneshotr = origin.oneshotr,
                allshotr = origin.allshotr,
                modelsize = origin.modelsize,
                shadowsize = origin.shadowsize,
                badframe = origin.badframe,
                autowait = origin.autowait,
                motion = origin.motion,
                reserve1 = origin.reserve1,
                reserve2 = origin.reserve2,
                reserve3 = origin.reserve3
            };
        }

        private static void ApplyUniversalUnitVisualChange()
        {
            for (byte i = 0; i <= 31; i++)
            {
                datDevilVisual00.tbl_0_000_01F[i].motion[0].actframe = 12;
                datDevilVisual01.tbl_1_020_03F[i].motion[0].actframe = 12;
                datDevilVisual02.tbl_2_040_05F[i].motion[0].actframe = 12;
                datDevilVisual03.tbl_3_060_07F[i].motion[0].actframe = 12;
                datDevilVisual04.tbl_4_080_09F[i].motion[0].actframe = 12;
                datDevilVisual05.tbl_5_0A0_0BF[i].motion[0].actframe = 12;
                datDevilVisual06.tbl_6_0C0_0DF[i].motion[0].actframe = 12;
                datDevilVisual07.tbl_7_0E0_0FF[i].motion[0].actframe = 12;
                datDevilVisual08.tbl_8_100_11F[i].motion[0].actframe = 12;
                datDevilVisual09.tbl_9_120_13F[i].motion[0].actframe = 12;
                datDevilVisual10.tbl_10_140_15F[i].motion[0].actframe = 12;
                datDevilVisual11.tbl_11_160_17F[i].motion[0].actframe = 12;

                datDevilVisual00.tbl_0_000_01F[i].motion[22].motion_no = 2;
                datDevilVisual01.tbl_1_020_03F[i].motion[22].motion_no = 2;
                datDevilVisual02.tbl_2_040_05F[i].motion[22].motion_no = 2;
                datDevilVisual03.tbl_3_060_07F[i].motion[22].motion_no = 2;
                datDevilVisual04.tbl_4_080_09F[i].motion[22].motion_no = 2;
                datDevilVisual05.tbl_5_0A0_0BF[i].motion[22].motion_no = 2;
                datDevilVisual06.tbl_6_0C0_0DF[i].motion[22].motion_no = 2;
                datDevilVisual07.tbl_7_0E0_0FF[i].motion[22].motion_no = 2;
                datDevilVisual08.tbl_8_100_11F[i].motion[22].motion_no = 2;
                datDevilVisual09.tbl_9_120_13F[i].motion[22].motion_no = 2;
                datDevilVisual10.tbl_10_140_15F[i].motion[22].motion_no = 2;
                datDevilVisual11.tbl_11_160_17F[i].motion[22].motion_no = 2;
            }
        }

        private static void ApplyDemonChanges()
        {
            dds3ModelFileTable_t[] devilModelFileTable = new dds3ModelFileTable_t[368];
            for (int i = 0; i < mdlFileDefTable.devilModelFileTable.Length; i++)
                devilModelFileTable[i] = mdlFileDefTable.devilModelFileTable[i];
            for (int i = mdlFileDefTable.devilModelFileTable.Length; i < devilModelFileTable.Length; i++)
                devilModelFileTable[i] = new dds3ModelFileTable_t();
            mdlFileDefTable.devilModelFileTable = devilModelFileTable;

            dds3ModelFileTable_t[] devilOnModelFileTable = new dds3ModelFileTable_t[368];
            for (int i = 0; i < mdlFileDefTable.devilOnModelFileTable.Length; i++)
                devilOnModelFileTable[i] = mdlFileDefTable.devilOnModelFileTable[i];
            for (int i = mdlFileDefTable.devilOnModelFileTable.Length; i < devilOnModelFileTable.Length; i++)
                devilOnModelFileTable[i] = new dds3ModelFileTable_t();
            mdlFileDefTable.devilOnModelFileTable = devilOnModelFileTable;

            dds3ModelFileIndex_t[] devilModelIndex = new dds3ModelFileIndex_t[368];
            for (int i = 0; i < mdlFileDefTable.devilModelIndex.Length; i++)
                devilModelIndex[i] = mdlFileDefTable.devilModelIndex[i];
            for (int i = mdlFileDefTable.devilModelIndex.Length; i < devilModelIndex.Length; i++)
                devilModelIndex[i] = new dds3ModelFileIndex_t();
            mdlFileDefTable.devilModelIndex = devilModelIndex;

            dds3ModelFileIndex_t[] devilOnModelIndex = new dds3ModelFileIndex_t[368];
            for (int i = 0; i < mdlFileDefTable.devilOnModelIndex.Length; i++)
                devilOnModelIndex[i] = mdlFileDefTable.devilOnModelIndex[i];
            for (int i = mdlFileDefTable.devilOnModelIndex.Length; i < devilOnModelIndex.Length; i++)
                devilOnModelIndex[i] = new dds3ModelFileIndex_t();
            mdlFileDefTable.devilOnModelIndex = devilOnModelIndex;

            //ushort[] motionSeTbl = new ushort[368];
            //for (int i = 0; i < datMotionSeTable.tbl.Length; i++)
            //    motionSeTbl[i] = datMotionSeTable.tbl[i];
            //for (int i = datMotionSeTable.tbl.Length; i < motionSeTbl.Length; i++)
            //    motionSeTbl[i] = (ushort) 0;
            //datMotionSeTable.tbl = motionSeTbl;

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
            Unicorn(35);

            Flaemis(36);
            Aquans(37);
            Aeros(38);
            Erthys(39);

            SakiMitama(40);
            KushiMitama(41);
            NigiMitama(42);
            AraMitama(43);

            Efreet(44);
            Pulukishi(45);
            Ongkhot(46);
            Jinn(47);
            KarasuTengu(48);
            Dis(49);
            Isora(50);
            Apsaras(51);
            KoppaTengu(52);

            Titania(53);
            Oberon(54);
            Troll(55);
            Setanta(56);
            Kelpie(57);
            PyroJack(58);
            HighPixie(59);
            JackFrost(60);
            Pixie(61);

            Throne(62);
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
            Mizuchi(78);
            Naga(79);
            Nozuchi(80);

            Cerberus(81);
            Orthrus(82);
            Suparna(83);
            BadbCatha(84);
            Inugami(85);
            Nekomata(86);

            Gogmagog(87);
            Titan(88);
            Sarutahiko(89);
            Sudama(90);
            HuaPo(91);
            Kodama(92);

            ShikiOuji(93);
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
            Bicorn(125);
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
            Makami(151);
            Garuda(152);
            Yatagarasu(153);
            Gurulu(154);
            Albion(155);

            Manikin1(156);
            Manikin2(157);
            Manikin3(158);
            Manikin4(159);
            Manikin5(160);

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

            // Fusable Bosses Demons
            OseHallel(179);
            FlaurosHallel(180);
            Urthona(181);
            Urizen(182);
            Luvah(183);
            Tharmus(184);
            Specter(185);
            Mara(186);

            // Maniax Demons
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

            BrokerNue(209);

            // Recolour Demons
            TamLin(224);
            Doppelganger(225);
            Nightmare(226);
            Gdon(227);

            DevilDante(252);
            Gamete(253);

            // YHVH
            YHVH(254);

            // Bosses
            BossForneus(256);
            BossSpecter1(257);

            ForcedIncubus(260);
            ForcedKoppaTengu(261);
            ForcedKaiwan1(262);
            BossOse(263);

            BossKinKi(266);
            BossSuiKi(267);
            BossFuuKi(268);
            BossOngyoKi(269);

            BossClotho1(270);
            BossLachesis1(271);
            BossAtropos1(272);

            BossSpecter1Merged1(294);
            BossSpecter1Merged2(295);
            BossSpecter1Merged3(296);

            BossMizuchi(297);

            BossOrthrus(300);
            BossYaksini(301);
            BossThor1(302);

            BossEligor(307);
            BossEligor(308);
            BossEligor(309);
            ForcedKelpie(310);
            ForcedKelpie(311);
            BossBerith(312);
            ForcedSuccubus(313);

            ForcedKaiwan2(315);

            ForcedNekomata(316);
            BossTroll(317);
            ForcedWillOWisp(318);
            ForcedPreta(319);

            BossMara(321);

            BossClotho2(326);
            BossLachesis2(327);
            BossAtropos2(328);

            BossDanteRaidou1(339);
            ChaseDanteRaidou(340);
            BossDanteRaidou2(341);
            BossWhiteRider(346);
            BossRedRider(347);
            BossBlackRider(348);
            BossMatador(349);
            BossHellBiker(350);
            BossDaisoujou(351);

            BossVirtue(359);
            BossPower(360);
            BossLegion(361);

            // New Bosses
            BossFlauros(362);

            // Universal Animation Fixes
            ApplyUniversalUnitVisualChange();
            datDevilVisual07.tbl_7_0E0_0FF[30].motion[22].motion_no = 0;
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
            datAisyo.tbl[id][4] = 2147483778; // Force
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 2100;
            datDevilFormat.tbl[id].maxhp = 2100;
            datDevilFormat.tbl[id].mp = 316;
            datDevilFormat.tbl[id].maxmp = 316;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[2] = 459; // Luster Candy

            // AI
            datDevilAI.divTbls[0][3].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][3].aitable[0][0].ritu = 10;
            datDevilAI.divTbls[0][3].aitable[0][1].skill = 70;
            datDevilAI.divTbls[0][3].aitable[0][1].ritu = 10;
            datDevilAI.divTbls[0][3].aitable[0][2].skill = 459;
            datDevilAI.divTbls[0][3].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][3].aitable[0][3].skill = 178;
            datDevilAI.divTbls[0][3].aitable[0][3].ritu = 20;
            datDevilAI.divTbls[0][3].aitable[0][4].skill = 127;
            datDevilAI.divTbls[0][3].aitable[0][4].ritu = 40;

            datDevilAI.divTbls[0][3].aitable[1][0].skill = 70;
            datDevilAI.divTbls[0][3].aitable[1][0].ritu = 85;
            datDevilAI.divTbls[0][3].aitable[1][1].skill = 459;
            datDevilAI.divTbls[0][3].aitable[1][1].ritu = 5;
            datDevilAI.divTbls[0][3].aitable[1][2].skill = 178;
            datDevilAI.divTbls[0][3].aitable[1][2].ritu = 5;
            datDevilAI.divTbls[0][3].aitable[1][3].skill = 127;
            datDevilAI.divTbls[0][3].aitable[1][3].ritu = 5;

            datDevilAI.divTbls[0][3].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[0][3].aitable[2][0].ritu = 10;
            datDevilAI.divTbls[0][3].aitable[2][1].skill = 70;
            datDevilAI.divTbls[0][3].aitable[2][1].ritu = 60;
            datDevilAI.divTbls[0][3].aitable[2][2].skill = 459;
            datDevilAI.divTbls[0][3].aitable[2][2].ritu = 10;
            datDevilAI.divTbls[0][3].aitable[2][3].skill = 178;
            datDevilAI.divTbls[0][3].aitable[2][3].ritu = 10;
            datDevilAI.divTbls[0][3].aitable[2][4].skill = 127;
            datDevilAI.divTbls[0][3].aitable[2][4].ritu = 10;
        }

        private static void Odin(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 65536; // Ice
            datAisyo.tbl[id][3] = 131072; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
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
            tblSkill.fclSkillTbl[id].Event[5].Param = 475; // Gungnir
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 68;
            tblSkill.fclSkillTbl[id].Event[6].Param = 12; // Mabufudyne
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
            tblSkill.fclSkillTbl[id].Event[7].Param = 442; // Thunder Reign
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 70;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 2400;
            datDevilFormat.tbl[id].maxhp = 2400;
            datDevilFormat.tbl[id].mp = 360;
            datDevilFormat.tbl[id].maxmp = 360;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[1] = 475; // Gungnir
            datDevilFormat.tbl[id].skill[3] = 441; // Thunder Gods
            datDevilFormat.tbl[id].skill[5] = 18; // Maziodyne

            // AI
            datDevilAI.divTbls[0][4].aitable[0][0].skill = 9;
            datDevilAI.divTbls[0][4].aitable[0][0].ritu = 10;
            datDevilAI.divTbls[0][4].aitable[0][1].skill = 441;
            datDevilAI.divTbls[0][4].aitable[0][1].ritu = 10;
            datDevilAI.divTbls[0][4].aitable[0][2].skill = 12;
            datDevilAI.divTbls[0][4].aitable[0][2].ritu = 10;
            datDevilAI.divTbls[0][4].aitable[0][3].skill = 18;
            datDevilAI.divTbls[0][4].aitable[0][3].ritu = 10;
            datDevilAI.divTbls[0][4].aitable[0][4].skill = 108;
            datDevilAI.divTbls[0][4].aitable[0][4].ritu = 60;

            datDevilAI.divTbls[0][4].aitable[1][0].skill = 9;
            datDevilAI.divTbls[0][4].aitable[1][0].ritu = 10;
            datDevilAI.divTbls[0][4].aitable[1][1].skill = 441;
            datDevilAI.divTbls[0][4].aitable[1][1].ritu = 10;
            datDevilAI.divTbls[0][4].aitable[1][2].skill = 12;
            datDevilAI.divTbls[0][4].aitable[1][2].ritu = 30;
            datDevilAI.divTbls[0][4].aitable[1][3].skill = 18;
            datDevilAI.divTbls[0][4].aitable[1][3].ritu = 30;
            datDevilAI.divTbls[0][4].aitable[1][4].skill = 475;
            datDevilAI.divTbls[0][4].aitable[1][4].ritu = 20;

            datDevilAI.divTbls[0][4].aitable[2][0].skill = 9;
            datDevilAI.divTbls[0][4].aitable[2][0].ritu = 30;
            datDevilAI.divTbls[0][4].aitable[2][1].skill = 441;
            datDevilAI.divTbls[0][4].aitable[2][1].ritu = 70;
        }

        private static void Atavaka(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 131072; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 2147483778; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1800;
            datDevilFormat.tbl[id].maxhp = 1800;
            datDevilFormat.tbl[id].mp = 244;
            datDevilFormat.tbl[id].maxmp = 244;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[1] = 450; // Neural Shock

            // AI
            datDevilAI.divTbls[0][5].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][5].aitable[0][0].ritu = 10;
            datDevilAI.divTbls[0][5].aitable[0][1].skill = 107;
            datDevilAI.divTbls[0][5].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][5].aitable[0][2].skill = 110;
            datDevilAI.divTbls[0][5].aitable[0][2].ritu = 50;
            datDevilAI.divTbls[0][5].aitable[0][3].skill = 450;
            datDevilAI.divTbls[0][5].aitable[0][3].ritu = 10;

            datDevilAI.divTbls[0][5].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][5].aitable[1][0].ritu = 40;
            datDevilAI.divTbls[0][5].aitable[1][1].skill = 107;
            datDevilAI.divTbls[0][5].aitable[1][1].ritu = 15;
            datDevilAI.divTbls[0][5].aitable[1][2].skill = 110;
            datDevilAI.divTbls[0][5].aitable[1][2].ritu = 15;
            datDevilAI.divTbls[0][5].aitable[1][3].skill = 450;
            datDevilAI.divTbls[0][5].aitable[1][3].ritu = 30;

            datDevilAI.divTbls[0][5].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[0][5].aitable[2][0].ritu = 20;
            datDevilAI.divTbls[0][5].aitable[2][1].skill = 107;
            datDevilAI.divTbls[0][5].aitable[2][1].ritu = 35;
            datDevilAI.divTbls[0][5].aitable[2][2].skill = 110;
            datDevilAI.divTbls[0][5].aitable[2][2].ritu = 35;
            datDevilAI.divTbls[0][5].aitable[2][3].skill = 450;
            datDevilAI.divTbls[0][5].aitable[2][3].ritu = 10;
        }

        private static void Horus(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 2147483778; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 2000;
            datDevilFormat.tbl[id].maxhp = 2000;
            datDevilFormat.tbl[id].mp = 640;
            datDevilFormat.tbl[id].maxmp = 640;

            datDevilFormat.tbl[id].dropexp = 1000;
            datDevilFormat.tbl[id].dropmakka = 5000;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 30; // Mahama
            datDevilFormat.tbl[id].skill[1] = 193; // Violet Flash
            datDevilFormat.tbl[id].skill[2] = 40; // Mediarama
            datDevilFormat.tbl[id].skill[3] = 226; // Gathering
            datDevilFormat.tbl[id].skill[4] = 366; // Abyssal Mask
        }

        private static void Lakshmi(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

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
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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
            tblSkill.fclSkillTbl[id].Event[9].Param = 347; // Mana Aid
            tblSkill.fclSkillTbl[id].Event[9].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[9].Type = 5;
        }

        private static void Sarasvati(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1500;
            datDevilFormat.tbl[id].maxhp = 1500;
            datDevilFormat.tbl[id].mp = 480;
            datDevilFormat.tbl[id].maxmp = 480;

            datDevilFormat.tbl[id].dropexp = 600;
            datDevilFormat.tbl[id].dropmakka = 2400;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 443; // Dervish
            datDevilFormat.tbl[id].skill[1] = 185; // Tornado
            datDevilFormat.tbl[id].skill[2] = 198; // Mute Gaze
            datDevilFormat.tbl[id].skill[3] = 312; // Force Boost
            datDevilFormat.tbl[id].skill[4] = 366; // Abyssal Mask
        }

        private static void Sati(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 262144; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[6].Param = 215; // Allure
            tblSkill.fclSkillTbl[id].Event[7].Param = 25; // Megido

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1500;
            datDevilFormat.tbl[id].maxhp = 1500;
            datDevilFormat.tbl[id].mp = 272;
            datDevilFormat.tbl[id].maxmp = 272;

            // AI
            datDevilAI.divTbls[0][10].aitable[0][0].skill = 215;
            datDevilAI.divTbls[0][10].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[0][10].aitable[0][1].skill = 3;
            datDevilAI.divTbls[0][10].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][10].aitable[0][2].skill = 6;
            datDevilAI.divTbls[0][10].aitable[0][2].ritu = 30;

            datDevilAI.divTbls[0][10].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][10].aitable[1][0].ritu = 40;
            datDevilAI.divTbls[0][10].aitable[1][1].skill = 3;
            datDevilAI.divTbls[0][10].aitable[1][1].ritu = 30;
            datDevilAI.divTbls[0][10].aitable[1][2].skill = 6;
            datDevilAI.divTbls[0][10].aitable[1][2].ritu = 30;

            datDevilAI.divTbls[0][10].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[0][10].aitable[2][0].ritu = 20;
            datDevilAI.divTbls[0][10].aitable[2][1].skill = 3;
            datDevilAI.divTbls[0][10].aitable[2][1].ritu = 30;
            datDevilAI.divTbls[0][10].aitable[2][2].skill = 6;
            datDevilAI.divTbls[0][10].aitable[2][2].ritu = 30;
            datDevilAI.divTbls[0][10].aitable[2][2].skill = 215;
            datDevilAI.divTbls[0][10].aitable[2][2].ritu = 20;
        }

        private static void AmeNoUzume(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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
            datDevilFormat.tbl[id].skill[4] = 219; // Rage
            datDevilFormat.tbl[id].skill[5] = 366; // Abyssal Mask
        }

        private static void Shiva(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 179; // Trisagion
            tblSkill.fclSkillTbl[id].Event[1].Param = 442; // Thunder Reign
            tblSkill.fclSkillTbl[id].Event[2].Param = 104; // Hassohappa
            tblSkill.fclSkillTbl[id].Event[3].Param = 453; // Antichthon
            tblSkill.fclSkillTbl[id].Event[4].Param = 348; // Victory Cry
            tblSkill.fclSkillTbl[id].Event[5].Param = 470; // Tandava
            tblSkill.fclSkillTbl[id].Event[6].Param = 333; // Phys Drain
        }

        private static void BeidouXingjun(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[7].Param = 432; // Gate of Hell
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 66;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 2334;
            datDevilFormat.tbl[id].maxhp = 2334;
            datDevilFormat.tbl[id].mp = 340;
            datDevilFormat.tbl[id].maxmp = 340;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[4] = 432; // Gate of Hell

            // AI
            datDevilAI.divTbls[0][13].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][13].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[0][13].aitable[0][1].skill = 106;
            datDevilAI.divTbls[0][13].aitable[0][1].ritu = 10;
            datDevilAI.divTbls[0][13].aitable[0][2].skill = 188;
            datDevilAI.divTbls[0][13].aitable[0][2].ritu = 10;
            datDevilAI.divTbls[0][13].aitable[0][3].skill = 196;
            datDevilAI.divTbls[0][13].aitable[0][3].ritu = 30;
            datDevilAI.divTbls[0][13].aitable[0][4].skill = 35;
            datDevilAI.divTbls[0][13].aitable[0][4].ritu = 30;

            datDevilAI.divTbls[0][13].aitable[1][0].skill = 432;
            datDevilAI.divTbls[0][13].aitable[1][0].ritu = 60;
            datDevilAI.divTbls[0][13].aitable[1][1].skill = 106;
            datDevilAI.divTbls[0][13].aitable[1][1].ritu = 10;
            datDevilAI.divTbls[0][13].aitable[1][2].skill = 188;
            datDevilAI.divTbls[0][13].aitable[1][2].ritu = 10;
            datDevilAI.divTbls[0][13].aitable[1][3].skill = 196;
            datDevilAI.divTbls[0][13].aitable[1][3].ritu = 10;
            datDevilAI.divTbls[0][13].aitable[1][4].skill = 35;
            datDevilAI.divTbls[0][13].aitable[1][4].ritu = 10;
        }

        private static void QitianDasheng(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][1] = 100; // Ice
            datAisyo.tbl[id][2] = 100; // Elec
            datAisyo.tbl[id][7] = 100; // Dark

            // Skills
            tblSkill.fclSkillTbl[id].Event[1].Param = 362; // Phys Boost
        }

        private static void Dionysus(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 65536; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[4].Param = 426; // Sakura Rage
        }

        private static void Kali(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 65536; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 131072; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 2580;
            datDevilFormat.tbl[id].maxhp = 2580;
            datDevilFormat.tbl[id].mp = 344;
            datDevilFormat.tbl[id].maxmp = 344;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 6; // Maragidyne

            // AI
            datDevilAI.divTbls[0][16].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][16].aitable[0][0].ritu = 10;
            datDevilAI.divTbls[0][16].aitable[0][1].skill = 105;
            datDevilAI.divTbls[0][16].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][16].aitable[0][2].skill = 63;
            datDevilAI.divTbls[0][16].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][16].aitable[0][3].skill = 108;
            datDevilAI.divTbls[0][16].aitable[0][3].ritu = 30;
            datDevilAI.divTbls[0][16].aitable[0][4].skill = 6;
            datDevilAI.divTbls[0][16].aitable[0][4].ritu = 10;

            datDevilAI.divTbls[0][16].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][16].aitable[1][0].ritu = 40;
            datDevilAI.divTbls[0][16].aitable[1][1].skill = 105;
            datDevilAI.divTbls[0][16].aitable[1][1].ritu = 10;
            datDevilAI.divTbls[0][16].aitable[1][2].skill = 63;
            datDevilAI.divTbls[0][16].aitable[1][2].ritu = 40;
            datDevilAI.divTbls[0][16].aitable[1][3].skill = 108;
            datDevilAI.divTbls[0][16].aitable[1][3].ritu = 10;

            datDevilAI.divTbls[0][16].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[0][16].aitable[2][0].ritu = 10;
            datDevilAI.divTbls[0][16].aitable[2][1].skill = 105;
            datDevilAI.divTbls[0][16].aitable[2][1].ritu = 20;
            datDevilAI.divTbls[0][16].aitable[2][2].skill = 63;
            datDevilAI.divTbls[0][16].aitable[2][2].ritu = 10;
            datDevilAI.divTbls[0][16].aitable[2][3].skill = 108;
            datDevilAI.divTbls[0][16].aitable[2][3].ritu = 20;
            datDevilAI.divTbls[0][16].aitable[2][4].skill = 6;
            datDevilAI.divTbls[0][16].aitable[2][4].ritu = 40;
        }

        private static void Skadi(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 262144; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
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
            datAisyo.tbl[id][7] = 2147483778; // Dark
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
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1000;
            datDevilFormat.tbl[id].maxhp = 1000;
            datDevilFormat.tbl[id].mp = 300;
            datDevilFormat.tbl[id].maxmp = 300;

            datDevilFormat.tbl[id].dropexp = 300;
            datDevilFormat.tbl[id].dropmakka = 1000;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 37; // Diarama
            datDevilFormat.tbl[id].skill[1] = 214; // Sexy Gaze
            datDevilFormat.tbl[id].skill[2] = 219; // Rage
            datDevilFormat.tbl[id].skill[3] = 366; // Abyssal Mask
        }

        private static void Bishamonten(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 131072; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 262144; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 2147483778; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 131072; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 131072; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 131072; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
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
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 131072; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[5].Param = 427; // Fang Breaker

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 900;
            datDevilFormat.tbl[id].maxhp = 900;
            datDevilFormat.tbl[id].mp = 300;
            datDevilFormat.tbl[id].maxmp = 300;

            datDevilFormat.tbl[id].dropexp = 250;
            datDevilFormat.tbl[id].dropmakka = 600;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 16; // Mazio
            datDevilFormat.tbl[id].skill[1] = 14; // Zionga
            datDevilFormat.tbl[id].skill[2] = 224; // Focus
            datDevilFormat.tbl[id].skill[3] = 427; // Fang Breaker
            datDevilFormat.tbl[id].skill[4] = 57; // Dekaja
            datDevilFormat.tbl[id].skill[5] = 301; // Dark Might
            datDevilFormat.tbl[id].skill[6] = 311; // Elec Boost
            datDevilFormat.tbl[id].skill[7] = 366; // Abyssal Mask
        }

        private static void Chimera(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 262144; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 2147483778; // Mind

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
            datAisyo.tbl[id][1] = 2147483778; // Fire
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
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 262144; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 353; // Lucky Find
            tblSkill.fclSkillTbl[id].Event[3].Param = 353; // Lucky Find
            tblSkill.fclSkillTbl[id].Event[4].Param = 399; // Stone Hunt
            tblSkill.fclSkillTbl[id].Event[5].Param = 399; // Stone Hunt
            tblSkill.fclSkillTbl[id].Event[6].Param = 23; // Mazanma
            tblSkill.fclSkillTbl[id].Event[7].Param = 23; // Mazanma
            tblSkill.fclSkillTbl[id].Event[8].Param = 367; // Knowledge of Tools
            tblSkill.fclSkillTbl[id].Event[9].Param = 367; // Knowledge of Tools

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 420;
            datDevilFormat.tbl[id].maxhp = 420;
            datDevilFormat.tbl[id].mp = 164;
            datDevilFormat.tbl[id].maxmp = 164;

            datDevilFormat.tbl[id].dropexp = 200;
            datDevilFormat.tbl[id].dropmakka = 1000;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 23; // Mazanma
            datDevilFormat.tbl[id].skill[1] = 443; // Dervish
            datDevilFormat.tbl[id].skill[2] = 125; // Stun Claw
            datDevilFormat.tbl[id].skill[3] = 62; // Marin Karin
            datDevilFormat.tbl[id].skill[4] = 198; // Mute Gaze
            datDevilFormat.tbl[id].skill[5] = 219; // Rage
            datDevilFormat.tbl[id].skill[6] = 366; // Abyssal Mask
        }

        private static void Zhuque(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 262144; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1700;
            datDevilFormat.tbl[id].maxhp = 1700;
            datDevilFormat.tbl[id].mp = 480;
            datDevilFormat.tbl[id].maxmp = 480;

            datDevilFormat.tbl[id].dropexp = 800;
            datDevilFormat.tbl[id].dropmakka = 3000;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 5; // Maragion
            datDevilFormat.tbl[id].skill[1] = 17; // Mazionga
            datDevilFormat.tbl[id].skill[2] = 53; // Sukunda
            datDevilFormat.tbl[id].skill[3] = 277; // Startle
            datDevilFormat.tbl[id].skill[4] = 366; // Abyssal Mask
        }

        private static void Shiisaa(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
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
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 65536; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 2147483778; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 2147483778; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1200;
            datDevilFormat.tbl[id].maxhp = 1200;
            datDevilFormat.tbl[id].mp = 400;
            datDevilFormat.tbl[id].maxmp = 400;

            datDevilFormat.tbl[id].dropexp = 400;
            datDevilFormat.tbl[id].dropmakka = 2000;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 11; // Mabufula
            datDevilFormat.tbl[id].skill[1] = 97; // Hell Thrust
            datDevilFormat.tbl[id].skill[2] = 193; // Violet Flash
            datDevilFormat.tbl[id].skill[3] = 202; // Toxic Cloud
            datDevilFormat.tbl[id].skill[4] = 437; // Refrigerate
            datDevilFormat.tbl[id].skill[5] = 277; // Startle
            datDevilFormat.tbl[id].skill[6] = 366; // Abyssal Mask
        }

        private static void Unicorn(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 720;
            datDevilFormat.tbl[id].maxhp = 720;
            datDevilFormat.tbl[id].mp = 300;
            datDevilFormat.tbl[id].maxmp = 300;

            datDevilFormat.tbl[id].dropexp = 200;
            datDevilFormat.tbl[id].dropmakka = 600;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 10; // Mabufu
            datDevilFormat.tbl[id].skill[1] = 39; // Media
            datDevilFormat.tbl[id].skill[2] = 37; // Diarama
            datDevilFormat.tbl[id].skill[3] = 66; // Rakukaja
            datDevilFormat.tbl[id].skill[4] = 121; // Stun Bite
            datDevilFormat.tbl[id].skill[5] = 226; // Gathering
            datDevilFormat.tbl[id].skill[6] = 366; // Abyssal Mask
        }

        private static void Flaemis(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 262144; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 4; // Maragi
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 300; // Bright Might
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 67; // Makakaja
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 39; // Media
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 21;
            tblSkill.fclSkillTbl[id].Event[4].Param = 332; // Null Mind
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 22;
            tblSkill.fclSkillTbl[id].Event[5].Param = 2; // Agilao
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 23;
            tblSkill.fclSkillTbl[id].Event[6].Param = 424; // Concentrate
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 24;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 294;
            datDevilFormat.tbl[id].maxhp = 294;
            datDevilFormat.tbl[id].mp = 128;
            datDevilFormat.tbl[id].maxmp = 128;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 2;

            // AI
            datDevilAI.divTbls[0][36].aitable[0][0].skill = 39;
            datDevilAI.divTbls[0][36].aitable[0][0].ritu = 60;
            datDevilAI.divTbls[0][36].aitable[0][1].skill = 4;
            datDevilAI.divTbls[0][36].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[0][36].aitable[0][2].skill = 2;
            datDevilAI.divTbls[0][36].aitable[0][2].ritu = 20;

            datDevilAI.divTbls[0][36].aitable[1][0].skill = 4;
            datDevilAI.divTbls[0][36].aitable[1][0].ritu = 50;
            datDevilAI.divTbls[0][36].aitable[1][1].skill = 2;
            datDevilAI.divTbls[0][36].aitable[1][1].ritu = 50;

            datDevilAI.divTbls[0][36].aitable[2][0].skill = 67;
            datDevilAI.divTbls[0][36].aitable[2][0].ritu = 90;
            datDevilAI.divTbls[0][36].aitable[2][1].skill = 32768;
            datDevilAI.divTbls[0][36].aitable[2][1].ritu = 10;
        }

        private static void Aquans(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 131072; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 65; // Sukukaja
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 318; // Anti-Light
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 10; // Mabufu
            tblSkill.fclSkillTbl[id].Event[2].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[3].Param = 321; // Anti-Nerve
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 16;
            tblSkill.fclSkillTbl[id].Event[4].Param = 290; // Life Bonus
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 17;
            tblSkill.fclSkillTbl[id].Event[5].Param = 8; // Bufula
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 18;
            tblSkill.fclSkillTbl[id].Event[6].Param = 293; // Mana Bonus
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 19;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 204;
            datDevilFormat.tbl[id].maxhp = 204;
            datDevilFormat.tbl[id].mp = 100;
            datDevilFormat.tbl[id].maxmp = 100;
        }

        private static void Aeros(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
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
            datAisyo.tbl[id][4] = 2147483778; // Force
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

            // Enemy Skills
            datDevilFormat.tbl[id].skill[4] = 364; // Anti-Magic
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

            // Enemy Skills
            datDevilFormat.tbl[id].skill[1] = 364; // Anti-Magic
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

            // Enemy Skills
            datDevilFormat.tbl[id].skill[1] = 364; // Anti-Magic
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

            // Enemy Skills
            datDevilFormat.tbl[id].skill[2] = 364; // Anti-Magic
        }

        private static void Efreet(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 262144; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 780;
            datDevilFormat.tbl[id].maxhp = 780;
            datDevilFormat.tbl[id].mp = 300;
            datDevilFormat.tbl[id].maxmp = 300;

            // AI
            datDevilAI.divTbls[0][44].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][44].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[0][44].aitable[0][1].skill = 6;
            datDevilAI.divTbls[0][44].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][44].aitable[0][2].skill = 178;
            datDevilAI.divTbls[0][44].aitable[0][2].ritu = 30;
            datDevilAI.divTbls[0][44].aitable[0][3].skill = 67;
            datDevilAI.divTbls[0][44].aitable[0][3].ritu = 20;

            datDevilAI.divTbls[0][44].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][44].aitable[1][0].ritu = 10;
            datDevilAI.divTbls[0][44].aitable[1][1].skill = 6;
            datDevilAI.divTbls[0][44].aitable[1][1].ritu = 30;
            datDevilAI.divTbls[0][44].aitable[1][2].skill = 178;
            datDevilAI.divTbls[0][44].aitable[1][2].ritu = 10;
            datDevilAI.divTbls[0][44].aitable[1][3].skill = 67;
            datDevilAI.divTbls[0][44].aitable[1][3].ritu = 50;

            datDevilAI.divTbls[0][44].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[0][44].aitable[2][0].ritu = 20;
            datDevilAI.divTbls[0][44].aitable[2][1].skill = 6;
            datDevilAI.divTbls[0][44].aitable[2][1].ritu = 40;
            datDevilAI.divTbls[0][44].aitable[2][2].skill = 178;
            datDevilAI.divTbls[0][44].aitable[2][2].ritu = 40;
        }

        private static void Pulukishi(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 642;
            datDevilFormat.tbl[id].maxhp = 642;
            datDevilFormat.tbl[id].mp = 252;
            datDevilFormat.tbl[id].maxmp = 252;

            // AI
            datDevilAI.divTbls[0][45].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][45].aitable[0][0].ritu = 60;
            datDevilAI.divTbls[0][45].aitable[0][1].skill = 211;
            datDevilAI.divTbls[0][45].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[0][45].aitable[0][2].skill = 216;
            datDevilAI.divTbls[0][45].aitable[0][2].ritu = 20;

            datDevilAI.divTbls[0][45].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][45].aitable[1][0].ritu = 30;
            datDevilAI.divTbls[0][45].aitable[1][1].skill = 211;
            datDevilAI.divTbls[0][45].aitable[1][1].ritu = 35;
            datDevilAI.divTbls[0][45].aitable[1][2].skill = 216;
            datDevilAI.divTbls[0][45].aitable[1][2].ritu = 35;

            datDevilAI.divTbls[0][45].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[0][45].aitable[2][0].ritu = 20;
            datDevilAI.divTbls[0][45].aitable[2][1].skill = 24;
            datDevilAI.divTbls[0][45].aitable[2][1].ritu = 40;
            datDevilAI.divTbls[0][45].aitable[2][2].skill = 110;
            datDevilAI.divTbls[0][45].aitable[2][2].ritu = 40;
        }

        private static void Ongkhot(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 2147483778; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 504;
            datDevilFormat.tbl[id].maxhp = 504;
            datDevilFormat.tbl[id].mp = 184;
            datDevilFormat.tbl[id].maxmp = 184;

            // AI
            datDevilAI.divTbls[0][46].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][46].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[0][46].aitable[0][1].skill = 103;
            datDevilAI.divTbls[0][46].aitable[0][1].ritu = 70;

            datDevilAI.divTbls[0][46].aitable[1][0].skill = 64;
            datDevilAI.divTbls[0][46].aitable[1][0].ritu = 50;
            datDevilAI.divTbls[0][46].aitable[1][1].skill = 65;
            datDevilAI.divTbls[0][46].aitable[1][1].ritu = 50;

            datDevilAI.divTbls[0][46].aitable[2][0].skill = 70;
            datDevilAI.divTbls[0][46].aitable[2][0].ritu = 100;
        }

        private static void Jinn(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 131072; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 443; // Dervish
            tblSkill.fclSkillTbl[id].Event[3].Param = 457; // Diamrita

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 606;
            datDevilFormat.tbl[id].maxhp = 606;
            datDevilFormat.tbl[id].mp = 252;
            datDevilFormat.tbl[id].maxmp = 252;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[5] = 457; // Diamrita
            datDevilFormat.tbl[id].skill[6] = 443; // Dervish

            // AI
            datDevilAI.divTbls[0][47].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][47].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[0][47].aitable[0][1].skill = 21;
            datDevilAI.divTbls[0][47].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][47].aitable[0][2].skill = 205;
            datDevilAI.divTbls[0][47].aitable[0][2].ritu = 30;
            datDevilAI.divTbls[0][47].aitable[0][3].skill = 443;
            datDevilAI.divTbls[0][47].aitable[0][3].ritu = 20;

            datDevilAI.divTbls[0][47].aitable[1][0].skill = 45103;
            datDevilAI.divTbls[0][47].aitable[1][0].ritu = 50;
            datDevilAI.divTbls[0][47].aitable[1][1].skill = 116;
            datDevilAI.divTbls[0][47].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[0][47].aitable[1][2].skill = 457;
            datDevilAI.divTbls[0][47].aitable[1][2].ritu = 30;

            datDevilAI.divTbls[0][47].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[0][47].aitable[2][0].ritu = 30;
            datDevilAI.divTbls[0][47].aitable[2][1].skill = 21;
            datDevilAI.divTbls[0][47].aitable[2][1].ritu = 40;
            datDevilAI.divTbls[0][47].aitable[2][2].skill = 443;
            datDevilAI.divTbls[0][47].aitable[2][2].ritu = 30;
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
            datAisyo.tbl[id][8] = 2147483778; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 461; // Storm Gale
            tblSkill.fclSkillTbl[id].Event[5].Param = 2; // Agilao
            tblSkill.fclSkillTbl[id].Event[6].Param = 2; // Agilao

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 420;
            datDevilFormat.tbl[id].maxhp = 420;
            datDevilFormat.tbl[id].mp = 156;
            datDevilFormat.tbl[id].maxmp = 156;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 461; // Storm Gale
            datDevilFormat.tbl[id].skill[1] = 2; // Agilao
            datDevilFormat.tbl[id].skill[2] = 30; // Mahama
            datDevilFormat.tbl[id].skill[3] = 64; // Tarukaja
            datDevilFormat.tbl[id].skill[4] = 299; // Might

            // AI
            datDevilAI.divTbls[0][48].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][48].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[0][48].aitable[0][1].skill = 461;
            datDevilAI.divTbls[0][48].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][48].aitable[0][2].skill = 2;
            datDevilAI.divTbls[0][48].aitable[0][2].ritu = 30;
            datDevilAI.divTbls[0][48].aitable[0][3].skill = 64;
            datDevilAI.divTbls[0][48].aitable[0][3].ritu = 20;

            datDevilAI.divTbls[0][48].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][48].aitable[1][0].ritu = 10;
            datDevilAI.divTbls[0][48].aitable[1][1].skill = 461;
            datDevilAI.divTbls[0][48].aitable[1][1].ritu = 30;
            datDevilAI.divTbls[0][48].aitable[1][2].skill = 2;
            datDevilAI.divTbls[0][48].aitable[1][2].ritu = 30;
            datDevilAI.divTbls[0][48].aitable[1][3].skill = 30;
            datDevilAI.divTbls[0][48].aitable[1][3].ritu = 30;
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
            datAisyo.tbl[id][7] = 2147483778; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[7].Param = 456; // Amrita

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 300;
            datDevilFormat.tbl[id].maxhp = 300;
            datDevilFormat.tbl[id].mp = 148;
            datDevilFormat.tbl[id].maxmp = 148;

            // AI
            datDevilAI.divTbls[0][49].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][49].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[0][49].aitable[0][1].skill = 55;
            datDevilAI.divTbls[0][49].aitable[0][1].ritu = 40;
            datDevilAI.divTbls[0][49].aitable[0][2].skill = 2;
            datDevilAI.divTbls[0][49].aitable[0][2].ritu = 40;

            datDevilAI.divTbls[0][49].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][49].aitable[1][0].ritu = 10;
            datDevilAI.divTbls[0][49].aitable[1][1].skill = 55;
            datDevilAI.divTbls[0][49].aitable[1][1].ritu = 30;
            datDevilAI.divTbls[0][49].aitable[1][2].skill = 2;
            datDevilAI.divTbls[0][49].aitable[1][2].ritu = 30;
            datDevilAI.divTbls[0][49].aitable[1][3].skill = 197;
            datDevilAI.divTbls[0][49].aitable[1][3].ritu = 30;

            datDevilAI.divTbls[0][49].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][49].aitable[1][0].ritu = 10;
            datDevilAI.divTbls[0][49].aitable[1][1].skill = 55;
            datDevilAI.divTbls[0][49].aitable[1][1].ritu = 30;
            datDevilAI.divTbls[0][49].aitable[1][2].skill = 2;
            datDevilAI.divTbls[0][49].aitable[1][2].ritu = 30;
            datDevilAI.divTbls[0][49].aitable[1][3].skill = 197;
            datDevilAI.divTbls[0][49].aitable[1][3].ritu = 30;
            datDevilAI.divTbls[0][49].aitable[1][4].skill = 0;
            datDevilAI.divTbls[0][49].aitable[1][4].ritu = 0;
            datDevilAI.divTbls[0][49].aitable[1][4].target = 0;
        }

        private static void Isora(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
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
            tblSkill.fclSkillTbl[id].Event[4].Param = 210; // Dormina
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
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 262144; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 84;
            datDevilFormat.tbl[id].maxhp = 84;
            datDevilFormat.tbl[id].mp = 56;
            datDevilFormat.tbl[id].maxmp = 56;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[1] = 210; // Dormina
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
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 2147483778; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 461; // Storm Gale

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 210;
            datDevilFormat.tbl[id].maxhp = 210;
            datDevilFormat.tbl[id].mp = 116;
            datDevilFormat.tbl[id].maxmp = 116;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[1] = 461; // Storm Gale

            // AI
            datDevilAI.divTbls[0][52].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][52].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[0][52].aitable[0][1].skill = 64;
            datDevilAI.divTbls[0][52].aitable[0][1].ritu = 60;

            datDevilAI.divTbls[0][52].aitable[1][0].skill = 461;
            datDevilAI.divTbls[0][52].aitable[1][0].ritu = 50;
            datDevilAI.divTbls[0][52].aitable[1][1].skill = 59;
            datDevilAI.divTbls[0][52].aitable[1][1].ritu = 25;
            datDevilAI.divTbls[0][52].aitable[1][2].skill = 20;
            datDevilAI.divTbls[0][52].aitable[1][2].ritu = 25;

            datDevilAI.divTbls[0][52].aitable[2][0].skill = 461;
            datDevilAI.divTbls[0][52].aitable[2][0].ritu = 20;
            datDevilAI.divTbls[0][52].aitable[2][1].skill = 59;
            datDevilAI.divTbls[0][52].aitable[2][1].ritu = 20;
            datDevilAI.divTbls[0][52].aitable[2][2].skill = 20;
            datDevilAI.divTbls[0][52].aitable[2][2].ritu = 20;
            datDevilAI.divTbls[0][52].aitable[2][3].skill = 36916;
            datDevilAI.divTbls[0][52].aitable[2][3].ritu = 30;
            datDevilAI.divTbls[0][52].aitable[2][4].skill = 116;
            datDevilAI.divTbls[0][52].aitable[2][4].ritu = 10;
        }

        private static void Titania(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 452; // Pulinpaon

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 828;
            datDevilFormat.tbl[id].maxhp = 828;
            datDevilFormat.tbl[id].mp = 320;
            datDevilFormat.tbl[id].maxmp = 320;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[1] = 452; // Pulinpaon

            // AI
            datDevilAI.divTbls[0][53].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][53].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[0][53].aitable[0][1].skill = 181;
            datDevilAI.divTbls[0][53].aitable[0][1].ritu = 40;
            datDevilAI.divTbls[0][53].aitable[0][2].skill = 452;
            datDevilAI.divTbls[0][53].aitable[0][2].ritu = 30;

            datDevilAI.divTbls[0][53].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][53].aitable[1][0].ritu = 30;
            datDevilAI.divTbls[0][53].aitable[1][1].skill = 41;
            datDevilAI.divTbls[0][53].aitable[1][1].ritu = 30;
            datDevilAI.divTbls[0][53].aitable[1][2].skill = 452;
            datDevilAI.divTbls[0][53].aitable[1][2].ritu = 40;

            datDevilAI.divTbls[0][53].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[0][53].aitable[2][0].ritu = 40;
            datDevilAI.divTbls[0][53].aitable[2][1].skill = 181;
            datDevilAI.divTbls[0][53].aitable[2][1].ritu = 20;
            datDevilAI.divTbls[0][53].aitable[2][2].skill = 452;
            datDevilAI.divTbls[0][53].aitable[2][2].ritu = 40;
        }

        private static void Oberon(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 2147483778; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 762;
            datDevilFormat.tbl[id].maxhp = 762;
            datDevilFormat.tbl[id].mp = 260;
            datDevilFormat.tbl[id].maxmp = 260;

            // AI
            datDevilAI.divTbls[0][54].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][54].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[0][54].aitable[0][1].skill = 69;
            datDevilAI.divTbls[0][54].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[0][54].aitable[0][2].skill = 101;
            datDevilAI.divTbls[0][54].aitable[0][2].ritu = 60;

            datDevilAI.divTbls[0][54].aitable[1][0].skill = 40;
            datDevilAI.divTbls[0][54].aitable[1][0].ritu = 20;
            datDevilAI.divTbls[0][54].aitable[1][1].skill = 69;
            datDevilAI.divTbls[0][54].aitable[1][1].ritu = 30;
            datDevilAI.divTbls[0][54].aitable[1][2].skill = 101;
            datDevilAI.divTbls[0][54].aitable[1][2].ritu = 50;
        }

        private static void Troll(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 2147483778; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 702;
            datDevilFormat.tbl[id].maxhp = 702;
            datDevilFormat.tbl[id].mp = 192;
            datDevilFormat.tbl[id].maxmp = 192;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 181; // Glacial Blast
            datDevilFormat.tbl[id].skill[3] = 427; // Fang Breaker

            // AI
            datDevilAI.divTbls[0][55].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][55].aitable[0][0].ritu = 10;
            datDevilAI.divTbls[0][55].aitable[0][1].skill = 181;
            datDevilAI.divTbls[0][55].aitable[0][1].ritu = 25;
            datDevilAI.divTbls[0][55].aitable[0][2].skill = 38;
            datDevilAI.divTbls[0][55].aitable[0][2].ritu = 10;
            datDevilAI.divTbls[0][55].aitable[0][3].skill = 427;
            datDevilAI.divTbls[0][55].aitable[0][3].ritu = 25;
            datDevilAI.divTbls[0][55].aitable[0][4].skill = 98;
            datDevilAI.divTbls[0][55].aitable[0][4].ritu = 30;
        }

        private static void Setanta(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 131072; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 2147483778; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 600;
            datDevilFormat.tbl[id].maxhp = 600;
            datDevilFormat.tbl[id].mp = 220;
            datDevilFormat.tbl[id].maxmp = 220;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[4] = 205; // Taunt

            // AI
            datDevilAI.divTbls[0][56].aitable[0][0].skill = 99;
            datDevilAI.divTbls[0][56].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[0][56].aitable[0][1].skill = 109;
            datDevilAI.divTbls[0][56].aitable[0][1].ritu = 40;
            datDevilAI.divTbls[0][56].aitable[0][2].skill = 205;
            datDevilAI.divTbls[0][56].aitable[0][2].ritu = 20;
        }

        private static void Kelpie(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
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
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 31;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 324;
            datDevilFormat.tbl[id].maxhp = 324;
            datDevilFormat.tbl[id].mp = 156;
            datDevilFormat.tbl[id].maxmp = 156;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[2] = 457;
            datDevilFormat.tbl[id].skill[4] = 437;

            // AI
            datDevilAI.divTbls[0][57].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][57].aitable[0][0].ritu = 25;
            datDevilAI.divTbls[0][57].aitable[0][1].skill = 61;
            datDevilAI.divTbls[0][57].aitable[0][1].ritu = 25;
            datDevilAI.divTbls[0][57].aitable[0][2].skill = 121;
            datDevilAI.divTbls[0][57].aitable[0][2].ritu = 25;
            datDevilAI.divTbls[0][57].aitable[0][3].skill = 437;
            datDevilAI.divTbls[0][57].aitable[0][3].ritu = 25;

            datDevilAI.divTbls[0][57].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][57].aitable[1][0].ritu = 10;
            datDevilAI.divTbls[0][57].aitable[1][1].skill = 61;
            datDevilAI.divTbls[0][57].aitable[1][1].ritu = 15;
            datDevilAI.divTbls[0][57].aitable[1][2].skill = 121;
            datDevilAI.divTbls[0][57].aitable[1][2].ritu = 15;
            datDevilAI.divTbls[0][57].aitable[1][3].skill = 457;
            datDevilAI.divTbls[0][57].aitable[1][3].ritu = 40;
            datDevilAI.divTbls[0][57].aitable[1][4].skill = 437;
            datDevilAI.divTbls[0][57].aitable[1][4].ritu = 15;

            datDevilAI.divTbls[0][57].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[0][57].aitable[2][0].ritu = 15;
            datDevilAI.divTbls[0][57].aitable[2][1].skill = 61;
            datDevilAI.divTbls[0][57].aitable[2][1].ritu = 15;
            datDevilAI.divTbls[0][57].aitable[2][2].skill = 457;
            datDevilAI.divTbls[0][57].aitable[2][2].ritu = 70;
        }

        private static void PyroJack(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 262144; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[5].Param = 473; // Jack Agilao

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 222;
            datDevilFormat.tbl[id].maxhp = 222;
            datDevilFormat.tbl[id].mp = 116;
            datDevilFormat.tbl[id].maxmp = 116;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 473;
            datDevilFormat.tbl[id].skill[1] = 4;
            datDevilFormat.tbl[id].skill[2] = 96;
            datDevilFormat.tbl[id].skill[3] = 209;

            // AI
            datDevilAI.divTbls[0][58].aitable[0][0].skill = 473;
            datDevilAI.divTbls[0][58].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[0][58].aitable[0][1].skill = 4;
            datDevilAI.divTbls[0][58].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][58].aitable[0][2].skill = 96;
            datDevilAI.divTbls[0][58].aitable[0][2].ritu = 15;
            datDevilAI.divTbls[0][58].aitable[0][3].skill = 209;
            datDevilAI.divTbls[0][58].aitable[0][3].ritu = 15;

            datDevilAI.divTbls[0][58].aitable[1][0].skill = 473;
            datDevilAI.divTbls[0][58].aitable[1][0].ritu = 40;
            datDevilAI.divTbls[0][58].aitable[1][1].skill = 4;
            datDevilAI.divTbls[0][58].aitable[1][1].ritu = 30;
            datDevilAI.divTbls[0][58].aitable[1][2].skill = 96;
            datDevilAI.divTbls[0][58].aitable[1][2].ritu = 15;
            datDevilAI.divTbls[0][58].aitable[1][3].skill = 209;
            datDevilAI.divTbls[0][58].aitable[1][3].ritu = 15;
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
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 262144; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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

        private static void Throne(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 262144; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 2147483778; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1236;
            datDevilFormat.tbl[id].maxhp = 1236;
            datDevilFormat.tbl[id].mp = 344;
            datDevilFormat.tbl[id].maxmp = 344;

            // AI
            datDevilAI.divTbls[0][62].aitable[0][0].skill = 31;
            datDevilAI.divTbls[0][62].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[0][62].aitable[0][1].skill = 178;
            datDevilAI.divTbls[0][62].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][62].aitable[0][2].skill = 198;
            datDevilAI.divTbls[0][62].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][62].aitable[0][3].skill = 189;
            datDevilAI.divTbls[0][62].aitable[0][3].ritu = 10;

            datDevilAI.divTbls[0][62].aitable[1][0].skill = 189;
            datDevilAI.divTbls[0][62].aitable[1][0].ritu = 100;

            datDevilAI.divTbls[0][62].aitable[2][0].skill = 41;
            datDevilAI.divTbls[0][62].aitable[2][0].ritu = 100;
        }

        private static void Dominion(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 2147483778; // Dark
            datAisyo.tbl[id][8] = 2147483778; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 936;
            datDevilFormat.tbl[id].maxhp = 936;
            datDevilFormat.tbl[id].mp = 272;
            datDevilFormat.tbl[id].maxmp = 272;

            // AI
            datDevilAI.divTbls[0][63].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][63].aitable[0][0].ritu = 25;
            datDevilAI.divTbls[0][63].aitable[0][1].skill = 55;
            datDevilAI.divTbls[0][63].aitable[0][1].ritu = 25;
            datDevilAI.divTbls[0][63].aitable[0][2].skill = 70;
            datDevilAI.divTbls[0][63].aitable[0][2].ritu = 25;
            datDevilAI.divTbls[0][63].aitable[0][3].skill = 193;
            datDevilAI.divTbls[0][63].aitable[0][3].ritu = 25;

            datDevilAI.divTbls[0][63].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][63].aitable[1][0].ritu = 20;
            datDevilAI.divTbls[0][63].aitable[1][1].skill = 55;
            datDevilAI.divTbls[0][63].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[0][63].aitable[1][2].skill = 70;
            datDevilAI.divTbls[0][63].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[0][63].aitable[1][3].skill = 193;
            datDevilAI.divTbls[0][63].aitable[1][3].ritu = 20;
            datDevilAI.divTbls[0][63].aitable[1][4].skill = 38;
            datDevilAI.divTbls[0][63].aitable[1][4].ritu = 20;

            datDevilAI.divTbls[0][63].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[0][63].aitable[2][0].ritu = 30;
            datDevilAI.divTbls[0][63].aitable[2][1].skill = 55;
            datDevilAI.divTbls[0][63].aitable[2][1].ritu = 30;
            datDevilAI.divTbls[0][63].aitable[2][2].skill = 70;
            datDevilAI.divTbls[0][63].aitable[2][2].ritu = 10;
            datDevilAI.divTbls[0][63].aitable[2][3].skill = 193;
            datDevilAI.divTbls[0][63].aitable[2][3].ritu = 30;
        }

        private static void Virtue(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 2147483778; // Dark
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 744;
            datDevilFormat.tbl[id].maxhp = 744;
            datDevilFormat.tbl[id].mp = 232;
            datDevilFormat.tbl[id].maxmp = 232;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[1] = 29; // Hamaon
            datDevilFormat.tbl[id].skill[2] = 17; // Mazionga
            datDevilFormat.tbl[id].skill[4] = 68; // Tetraja
            datDevilFormat.tbl[id].skill[5] = 114; // Arid Needle

            // AI
            datDevilAI.divTbls[0][64].aitable[0][0].skill = 69;
            datDevilAI.divTbls[0][64].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[0][64].aitable[0][1].skill = 114;
            datDevilAI.divTbls[0][64].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][64].aitable[0][2].skill = 68;
            datDevilAI.divTbls[0][64].aitable[0][2].ritu = 30;

            datDevilAI.divTbls[0][64].aitable[1][0].skill = 114;
            datDevilAI.divTbls[0][64].aitable[1][0].ritu = 10;
            datDevilAI.divTbls[0][64].aitable[1][1].skill = 17;
            datDevilAI.divTbls[0][64].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[0][64].aitable[1][2].skill = 29;
            datDevilAI.divTbls[0][64].aitable[1][2].ritu = 40;
            datDevilAI.divTbls[0][64].aitable[1][3].skill = 69;
            datDevilAI.divTbls[0][64].aitable[1][3].ritu = 30;

            datDevilAI.divTbls[0][64].aitable[2][0].skill = 114;
            datDevilAI.divTbls[0][64].aitable[2][0].ritu = 20;
            datDevilAI.divTbls[0][64].aitable[2][1].skill = 17;
            datDevilAI.divTbls[0][64].aitable[2][1].ritu = 20;
            datDevilAI.divTbls[0][64].aitable[2][2].skill = 29;
            datDevilAI.divTbls[0][64].aitable[2][2].ritu = 50;
            datDevilAI.divTbls[0][64].aitable[2][3].skill = 69;
            datDevilAI.divTbls[0][64].aitable[2][3].ritu = 10;
        }

        private static void Power(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 2147483778; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 600;
            datDevilFormat.tbl[id].maxhp = 600;
            datDevilFormat.tbl[id].mp = 164;
            datDevilFormat.tbl[id].maxmp = 164;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[2] = 30; // Mahama
            datDevilFormat.tbl[id].skill[3] = 193; // Violet Flash
            datDevilFormat.tbl[id].skill[4] = 99; // Tempest
            datDevilFormat.tbl[id].skill[5] = 427; // Fang Breaker

            // AI
            datDevilAI.divTbls[0][65].aitable[0][0].skill = 64;
            datDevilAI.divTbls[0][65].aitable[0][0].ritu = 80;
            datDevilAI.divTbls[0][65].aitable[0][1].skill = 427;
            datDevilAI.divTbls[0][65].aitable[0][1].ritu = 20;

            datDevilAI.divTbls[0][65].aitable[1][0].skill = 427;
            datDevilAI.divTbls[0][65].aitable[1][0].ritu = 40;
            datDevilAI.divTbls[0][65].aitable[1][1].skill = 109;
            datDevilAI.divTbls[0][65].aitable[1][1].ritu = 40;
            datDevilAI.divTbls[0][65].aitable[1][1].skill = 99;
            datDevilAI.divTbls[0][65].aitable[1][1].ritu = 20;

            datDevilAI.divTbls[0][65].aitable[2][0].skill = 427;
            datDevilAI.divTbls[0][65].aitable[2][0].ritu = 40;
            datDevilAI.divTbls[0][65].aitable[2][1].skill = 30;
            datDevilAI.divTbls[0][65].aitable[2][1].ritu = 20;
            datDevilAI.divTbls[0][65].aitable[2][2].skill = 193;
            datDevilAI.divTbls[0][65].aitable[2][2].ritu = 40;
        }

        private static void Principality(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 2147483778; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 2147483778; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 452;
            datDevilFormat.tbl[id].maxhp = 452;
            datDevilFormat.tbl[id].mp = 160;
            datDevilFormat.tbl[id].maxmp = 160;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[1] = 188; // Punishment
            datDevilFormat.tbl[id].skill[3] = 20; // Zanma
            datDevilFormat.tbl[id].skill[4] = 435; // Scald

            // AI
            datDevilAI.divTbls[0][66].aitable[0][0].skill = 37;
            datDevilAI.divTbls[0][66].aitable[0][0].ritu = 100;

            datDevilAI.divTbls[0][66].aitable[1][0].skill = 188;
            datDevilAI.divTbls[0][66].aitable[1][0].ritu = 40;
            datDevilAI.divTbls[0][66].aitable[1][1].skill = 32768;
            datDevilAI.divTbls[0][66].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[0][66].aitable[1][2].skill = 20;
            datDevilAI.divTbls[0][66].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[0][66].aitable[1][3].skill = 435;
            datDevilAI.divTbls[0][66].aitable[1][3].ritu = 20;

            datDevilAI.divTbls[0][66].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[0][66].aitable[2][0].ritu = 10;
            datDevilAI.divTbls[0][66].aitable[2][1].skill = 101;
            datDevilAI.divTbls[0][66].aitable[2][1].ritu = 30;
            datDevilAI.divTbls[0][66].aitable[2][2].skill = 188;
            datDevilAI.divTbls[0][66].aitable[2][2].ritu = 20;
            datDevilAI.divTbls[0][66].aitable[2][3].skill = 20;
            datDevilAI.divTbls[0][66].aitable[2][3].ritu = 20;
            datDevilAI.divTbls[0][66].aitable[2][4].skill = 435;
            datDevilAI.divTbls[0][66].aitable[2][4].ritu = 20;
        }

        private static void Archangel(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 2147483778; // Dark
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
            datDevilAI.divTbls[0][67].aitable[2][2].skill = 101;
            datDevilAI.divTbls[0][67].aitable[2][2].ritu = 20;
        }

        private static void Angel(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 2147483778; // Dark
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
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 65536; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 131072; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[5].Param = 292; // Life Surge
            tblSkill.fclSkillTbl[id].Event[6].Param = 104; // Hassohappa
            tblSkill.fclSkillTbl[id].Event[7].Param = 366; // Abyssal Mask

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1164;
            datDevilFormat.tbl[id].maxhp = 1164;
            datDevilFormat.tbl[id].mp = 328;
            datDevilFormat.tbl[id].maxmp = 328;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 104; // Hassohappa

            // AI
            datDevilAI.divTbls[0][69].aitable[0][0].skill = 203;
            datDevilAI.divTbls[0][69].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[0][69].aitable[0][1].skill = 108;
            datDevilAI.divTbls[0][69].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][69].aitable[0][2].skill = 126;
            datDevilAI.divTbls[0][69].aitable[0][2].ritu = 40;
            datDevilAI.divTbls[0][69].aitable[0][3].skill = 32768;
            datDevilAI.divTbls[0][69].aitable[0][3].ritu = 10;

            datDevilAI.divTbls[0][69].aitable[1][0].skill = 203;
            datDevilAI.divTbls[0][69].aitable[1][0].ritu = 70;
            datDevilAI.divTbls[0][69].aitable[1][1].skill = 108;
            datDevilAI.divTbls[0][69].aitable[1][1].ritu = 15;
            datDevilAI.divTbls[0][69].aitable[1][2].skill = 126;
            datDevilAI.divTbls[0][69].aitable[1][2].ritu = 15;

            datDevilAI.divTbls[0][69].aitable[2][0].skill = 108;
            datDevilAI.divTbls[0][69].aitable[2][0].ritu = 35;
            datDevilAI.divTbls[0][69].aitable[2][1].skill = 126;
            datDevilAI.divTbls[0][69].aitable[2][1].ritu = 35;
            datDevilAI.divTbls[0][69].aitable[2][2].skill = 104;
            datDevilAI.divTbls[0][69].aitable[2][2].ritu = 30;
        }

        private static void Decarabia(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 196; // Hell Gaze
            tblSkill.fclSkillTbl[id].Event[4].Param = 25; // Megido
            tblSkill.fclSkillTbl[id].Event[5].Param = 212; // Eternal Rest
            tblSkill.fclSkillTbl[id].Event[6].Param = 72; // Trafuri
            tblSkill.fclSkillTbl[id].Event[7].Param = 328; // Null Light

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 930;
            datDevilFormat.tbl[id].maxhp = 930;
            datDevilFormat.tbl[id].mp = 320;
            datDevilFormat.tbl[id].maxmp = 320;

            // AI
            datDevilAI.divTbls[0][70].aitable[0][0].skill = 65;
            datDevilAI.divTbls[0][70].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[0][70].aitable[0][1].skill = 70;
            datDevilAI.divTbls[0][70].aitable[0][1].ritu = 50;
            datDevilAI.divTbls[0][70].aitable[0][2].skill = 32768;
            datDevilAI.divTbls[0][70].aitable[0][2].ritu = 30;

            datDevilAI.divTbls[0][70].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][70].aitable[1][0].ritu = 5;
            datDevilAI.divTbls[0][70].aitable[1][1].skill = 25;
            datDevilAI.divTbls[0][70].aitable[1][1].ritu = 10;
            datDevilAI.divTbls[0][70].aitable[1][2].skill = 70;
            datDevilAI.divTbls[0][70].aitable[1][2].ritu = 5;
            datDevilAI.divTbls[0][70].aitable[1][3].skill = 212;
            datDevilAI.divTbls[0][70].aitable[1][3].ritu = 80;

            datDevilAI.divTbls[0][70].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[0][70].aitable[2][0].ritu = 30;
            datDevilAI.divTbls[0][70].aitable[2][1].skill = 25;
            datDevilAI.divTbls[0][70].aitable[2][1].ritu = 35;
            datDevilAI.divTbls[0][70].aitable[2][2].skill = 70;
            datDevilAI.divTbls[0][70].aitable[2][2].ritu = 35;
        }

        private static void Ose(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[5].Param = 224; // Focus
            tblSkill.fclSkillTbl[id].Event[6].Param = 313; // Anti-Phys
            tblSkill.fclSkillTbl[id].Event[7].Param = 69; // Makarakarn

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 846;
            datDevilFormat.tbl[id].maxhp = 846;
            datDevilFormat.tbl[id].mp = 224;
            datDevilFormat.tbl[id].maxmp = 224;

            // AI
            datDevilAI.divTbls[0][71].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][71].aitable[0][0].ritu = 60;
            datDevilAI.divTbls[0][71].aitable[0][1].skill = 102;
            datDevilAI.divTbls[0][71].aitable[0][1].ritu = 40;
        }

        private static void Berith(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 262144; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 624;
            datDevilFormat.tbl[id].maxhp = 624;
            datDevilFormat.tbl[id].mp = 188;
            datDevilFormat.tbl[id].maxmp = 188;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[2] = 446; // Damnation

            // AI
            datDevilAI.divTbls[0][72].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][72].aitable[0][0].ritu = 10;
            datDevilAI.divTbls[0][72].aitable[0][1].skill = 101;
            datDevilAI.divTbls[0][72].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][72].aitable[0][2].skill = 177;
            datDevilAI.divTbls[0][72].aitable[0][2].ritu = 30;
            datDevilAI.divTbls[0][72].aitable[0][2].skill = 446;
            datDevilAI.divTbls[0][72].aitable[0][2].ritu = 30;

            datDevilAI.divTbls[0][72].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][72].aitable[1][0].ritu = 40;
            datDevilAI.divTbls[0][72].aitable[1][1].skill = 177;
            datDevilAI.divTbls[0][72].aitable[1][1].ritu = 40;
            datDevilAI.divTbls[0][72].aitable[1][2].skill = 446;
            datDevilAI.divTbls[0][72].aitable[1][2].ritu = 20;
        }

        private static void Eligor(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 420;
            datDevilFormat.tbl[id].maxhp = 420;
            datDevilFormat.tbl[id].mp = 152;
            datDevilFormat.tbl[id].maxmp = 152;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 97;
            datDevilFormat.tbl[id].skill[4] = 427;
            datDevilFormat.tbl[id].skill[5] = 219;
            datDevilFormat.tbl[id].skill[6] = 220;

            // AI
            datDevilAI.divTbls[0][73].aitable[0][0].skill = 66;
            datDevilAI.divTbls[0][73].aitable[0][0].ritu = 100;

            datDevilAI.divTbls[0][73].aitable[1][0].skill = 98;
            datDevilAI.divTbls[0][73].aitable[1][0].ritu = 25;
            datDevilAI.divTbls[0][73].aitable[1][1].skill = 32;
            datDevilAI.divTbls[0][73].aitable[1][1].ritu = 25;
            datDevilAI.divTbls[0][73].aitable[1][2].skill = 97;
            datDevilAI.divTbls[0][73].aitable[1][2].ritu = 25;
            datDevilAI.divTbls[0][73].aitable[1][3].skill = 427;
            datDevilAI.divTbls[0][73].aitable[1][3].ritu = 25;
        }

        private static void Forneus(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 262144; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 65536; // Fire
            datAisyo.tbl[id][2] = 65536; // Ice
            datAisyo.tbl[id][3] = 65536; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 2147483778; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 2147483778; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[5].Param = 186; // Wind Cutter
            tblSkill.fclSkillTbl[id].Event[6].Param = 50; // Samarecarm
            tblSkill.fclSkillTbl[id].Event[7].Param = 445; // Vayavya
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 75;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1368;
            datDevilFormat.tbl[id].maxhp = 1368;
            datDevilFormat.tbl[id].mp = 328;
            datDevilFormat.tbl[id].maxmp = 328;

            // AI
            datDevilAI.divTbls[0][75].aitable[0][0].skill = 183;
            datDevilAI.divTbls[0][75].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[0][75].aitable[0][1].skill = 186;
            datDevilAI.divTbls[0][75].aitable[0][1].ritu = 40;
            datDevilAI.divTbls[0][75].aitable[0][2].skill = 66;
            datDevilAI.divTbls[0][75].aitable[0][2].ritu = 20;

            datDevilAI.divTbls[0][75].aitable[1][0].skill = 41;
            datDevilAI.divTbls[0][75].aitable[1][0].ritu = 50;
            datDevilAI.divTbls[0][75].aitable[1][1].skill = 183;
            datDevilAI.divTbls[0][75].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[0][75].aitable[1][2].skill = 186;
            datDevilAI.divTbls[0][75].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[0][75].aitable[1][3].skill = 66;
            datDevilAI.divTbls[0][75].aitable[1][3].ritu = 10;
        }

        private static void Quetzalcoatl(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 65536; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 120; // Stone Bite
            tblSkill.fclSkillTbl[id].Event[1].Param = 98; // Berserk
            tblSkill.fclSkillTbl[id].Event[2].Param = 181; // Glacial Blast
            tblSkill.fclSkillTbl[id].Event[3].Param = 202; // Toxic Cloud
            tblSkill.fclSkillTbl[id].Event[4].Param = 310; // Ice Boost
            tblSkill.fclSkillTbl[id].Event[5].Param = 335; // Ice Drain
            tblSkill.fclSkillTbl[id].Event[6].Param = 51; // Recarmdra
            tblSkill.fclSkillTbl[id].Event[7].Param = 432; // Gate of Hell

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 996;
            datDevilFormat.tbl[id].maxhp = 996;
            datDevilFormat.tbl[id].mp = 268;
            datDevilFormat.tbl[id].maxmp = 268;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 181; // Glacial Blast
            datDevilFormat.tbl[id].skill[4] = 432; // Gate of Hell

            // AI
            datDevilAI.divTbls[0][76].aitable[0][0].skill = 432;
            datDevilAI.divTbls[0][76].aitable[0][0].ritu = 25;
            datDevilAI.divTbls[0][76].aitable[0][1].skill = 120;
            datDevilAI.divTbls[0][76].aitable[0][1].ritu = 25;
            datDevilAI.divTbls[0][76].aitable[0][2].skill = 98;
            datDevilAI.divTbls[0][76].aitable[0][2].ritu = 25;
            datDevilAI.divTbls[0][76].aitable[0][3].skill = 181;
            datDevilAI.divTbls[0][76].aitable[0][3].ritu = 25;

            datDevilAI.divTbls[0][76].aitable[1][0].skill = 432;
            datDevilAI.divTbls[0][76].aitable[1][0].ritu = 20;
            datDevilAI.divTbls[0][76].aitable[1][1].skill = 120;
            datDevilAI.divTbls[0][76].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[0][76].aitable[1][2].skill = 98;
            datDevilAI.divTbls[0][76].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[0][76].aitable[1][3].skill = 202;
            datDevilAI.divTbls[0][76].aitable[1][3].ritu = 20;
            datDevilAI.divTbls[0][76].aitable[1][4].skill = 181;
            datDevilAI.divTbls[0][76].aitable[1][4].ritu = 20;
        }

        private static void NagaRaja(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 262144; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 744;
            datDevilFormat.tbl[id].maxhp = 744;
            datDevilFormat.tbl[id].mp = 184;
            datDevilFormat.tbl[id].maxmp = 184;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[1] = 183; // Bolt Storm
            datDevilFormat.tbl[id].skill[4] = 302; // Drain Attack

            // AI
            datDevilAI.divTbls[0][77].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][77].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[0][77].aitable[0][1].skill = 183;
            datDevilAI.divTbls[0][77].aitable[0][1].ritu = 50;
            datDevilAI.divTbls[0][77].aitable[0][2].skill = 99;
            datDevilAI.divTbls[0][77].aitable[0][2].ritu = 20;

            datDevilAI.divTbls[0][77].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][77].aitable[1][0].ritu = 10;
            datDevilAI.divTbls[0][77].aitable[1][1].skill = 183;
            datDevilAI.divTbls[0][77].aitable[1][1].ritu = 40;
            datDevilAI.divTbls[0][77].aitable[1][2].skill = 99;
            datDevilAI.divTbls[0][77].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[0][77].aitable[1][3].skill = 36943;
            datDevilAI.divTbls[0][77].aitable[1][3].ritu = 30;
        }

        private static void Mizuchi(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 65536; // Ice
            datAisyo.tbl[id][3] = 262144; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 564;
            datDevilFormat.tbl[id].maxhp = 564;
            datDevilFormat.tbl[id].mp = 188;
            datDevilFormat.tbl[id].maxmp = 188;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[2] = 11; // Mabufula
            datDevilFormat.tbl[id].skill[3] = 67; // Makakaja
            datDevilFormat.tbl[id].skill[4] = 69; // Makarakarn

            // AI
            datDevilAI.divTbls[0][78].aitable[0][0].skill = 98;
            datDevilAI.divTbls[0][78].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[0][78].aitable[0][1].skill = 8;
            datDevilAI.divTbls[0][78].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[0][78].aitable[0][2].skill = 11;
            datDevilAI.divTbls[0][78].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][78].aitable[0][3].skill = 69;
            datDevilAI.divTbls[0][78].aitable[0][3].ritu = 15;
            datDevilAI.divTbls[0][78].aitable[0][4].skill = 32768;
            datDevilAI.divTbls[0][78].aitable[0][4].ritu = 15;
        }

        private static void Naga(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 262144; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 444;
            datDevilFormat.tbl[id].maxhp = 444;
            datDevilFormat.tbl[id].mp = 144;
            datDevilFormat.tbl[id].maxmp = 144;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 204; // Fog Breath
            datDevilFormat.tbl[id].skill[4] = 302; // Drain Attack

            // AI
            datDevilAI.divTbls[0][79].aitable[0][0].skill = 64;
            datDevilAI.divTbls[0][79].aitable[0][0].ritu = 25;
            datDevilAI.divTbls[0][79].aitable[0][1].skill = 14;
            datDevilAI.divTbls[0][79].aitable[0][1].ritu = 25;
            datDevilAI.divTbls[0][79].aitable[0][2].skill = 97;
            datDevilAI.divTbls[0][79].aitable[0][2].ritu = 25;
            datDevilAI.divTbls[0][79].aitable[0][3].skill = 204;
            datDevilAI.divTbls[0][79].aitable[0][3].ritu = 25;

            datDevilAI.divTbls[0][79].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][79].aitable[1][0].ritu = 30;
            datDevilAI.divTbls[0][79].aitable[1][1].skill = 14;
            datDevilAI.divTbls[0][79].aitable[1][1].ritu = 30;
            datDevilAI.divTbls[0][79].aitable[1][2].skill = 97;
            datDevilAI.divTbls[0][79].aitable[1][2].ritu = 40;
        }

        private static void Nozuchi(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
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
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 131072; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 122; // Hell Fang
            tblSkill.fclSkillTbl[id].Event[4].Param = 465; // Rend
            tblSkill.fclSkillTbl[id].Event[7].Param = 411; // Detain
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 66;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1296;
            datDevilFormat.tbl[id].maxhp = 1296;
            datDevilFormat.tbl[id].mp = 300;
            datDevilFormat.tbl[id].maxmp = 300;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 122; // Hell Fang

            // AI
            datDevilAI.divTbls[0][81].aitable[0][0].skill = 122;
            datDevilAI.divTbls[0][81].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[0][81].aitable[0][1].skill = 211;
            datDevilAI.divTbls[0][81].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[0][81].aitable[0][2].skill = 177;
            datDevilAI.divTbls[0][81].aitable[0][2].ritu = 40;

            datDevilAI.divTbls[0][81].aitable[1][0].skill = 177;
            datDevilAI.divTbls[0][81].aitable[1][0].ritu = 70;
            datDevilAI.divTbls[0][81].aitable[1][1].skill = 122;
            datDevilAI.divTbls[0][81].aitable[1][1].ritu = 30;
        }

        private static void Orthrus(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 262144; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 50; // Dark
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 402;
            datDevilFormat.tbl[id].maxhp = 402;
            datDevilFormat.tbl[id].mp = 168;
            datDevilFormat.tbl[id].maxmp = 168;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[4] = 430;

            // AI
            datDevilAI.divTbls[0][82].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][82].aitable[0][0].ritu = 10;
            datDevilAI.divTbls[0][82].aitable[0][1].skill = 125;
            datDevilAI.divTbls[0][82].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][82].aitable[0][2].skill = 176;
            datDevilAI.divTbls[0][82].aitable[0][2].ritu = 30;
            datDevilAI.divTbls[0][82].aitable[0][3].skill = 430;
            datDevilAI.divTbls[0][82].aitable[0][3].ritu = 30;

            datDevilAI.divTbls[0][82].aitable[1][0].skill = 203;
            datDevilAI.divTbls[0][82].aitable[1][0].ritu = 40;
            datDevilAI.divTbls[0][82].aitable[1][1].skill = 125;
            datDevilAI.divTbls[0][82].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[0][82].aitable[1][2].skill = 176;
            datDevilAI.divTbls[0][82].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[0][82].aitable[1][3].skill = 430;
            datDevilAI.divTbls[0][82].aitable[1][3].ritu = 20;

            datDevilAI.divTbls[0][82].aitable[2][0].skill = 176;
            datDevilAI.divTbls[0][82].aitable[2][0].ritu = 50;
            datDevilAI.divTbls[0][82].aitable[2][1].skill = 430;
            datDevilAI.divTbls[0][82].aitable[2][1].ritu = 50;
        }

        private static void Suparna(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 124; // Venom Claw
            tblSkill.fclSkillTbl[id].Event[3].TargetLevel = 55;
            tblSkill.fclSkillTbl[id].Event[5].Param = 462; // Winged Fury
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 56;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 812;
            datDevilFormat.tbl[id].maxhp = 812;
            datDevilFormat.tbl[id].mp = 292;
            datDevilFormat.tbl[id].maxmp = 292;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 124; // Venom Claw
            datDevilFormat.tbl[id].skill[4] = 462; // Winged Fury

            // AI
            datDevilAI.divTbls[0][83].aitable[0][0].skill = 124;
            datDevilAI.divTbls[0][83].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[0][83].aitable[0][1].skill = 65;
            datDevilAI.divTbls[0][83].aitable[0][1].ritu = 10;
            datDevilAI.divTbls[0][83].aitable[0][2].skill = 204;
            datDevilAI.divTbls[0][83].aitable[0][2].ritu = 10;
            datDevilAI.divTbls[0][83].aitable[0][3].skill = 21;
            datDevilAI.divTbls[0][83].aitable[0][3].ritu = 30;
            datDevilAI.divTbls[0][83].aitable[0][4].skill = 462;
            datDevilAI.divTbls[0][83].aitable[0][4].ritu = 20;

            datDevilAI.divTbls[0][83].aitable[1][0].skill = 124;
            datDevilAI.divTbls[0][83].aitable[1][0].ritu = 40;
            datDevilAI.divTbls[0][83].aitable[1][1].skill = 65;
            datDevilAI.divTbls[0][83].aitable[1][1].ritu = 30;
            datDevilAI.divTbls[0][83].aitable[1][2].skill = 204;
            datDevilAI.divTbls[0][83].aitable[1][2].ritu = 10;
            datDevilAI.divTbls[0][83].aitable[1][3].skill = 21;
            datDevilAI.divTbls[0][83].aitable[1][3].ritu = 20;

            datDevilAI.divTbls[0][83].aitable[2][0].skill = 124;
            datDevilAI.divTbls[0][83].aitable[2][0].ritu = 35;
            datDevilAI.divTbls[0][83].aitable[2][1].skill = 21;
            datDevilAI.divTbls[0][83].aitable[2][1].ritu = 30;
            datDevilAI.divTbls[0][83].aitable[2][2].skill = 462;
            datDevilAI.divTbls[0][83].aitable[2][2].ritu = 35;
        }

        private static void BadbCatha(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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
            tblSkill.fclSkillTbl[id].Event[7].Param = 124; // Venom Claw
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 28;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 234;
            datDevilFormat.tbl[id].maxhp = 234;
            datDevilFormat.tbl[id].mp = 116;
            datDevilFormat.tbl[id].maxmp = 116;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[1] = 443;
            datDevilFormat.tbl[id].skill[2] = 124;

            // AI
            datDevilAI.divTbls[0][84].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][84].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[0][84].aitable[0][1].skill = 111;
            datDevilAI.divTbls[0][84].aitable[0][1].ritu = 40;
            datDevilAI.divTbls[0][84].aitable[0][2].skill = 124;
            datDevilAI.divTbls[0][84].aitable[0][2].ritu = 40;

            datDevilAI.divTbls[0][84].aitable[1][0].skill = 443;
            datDevilAI.divTbls[0][84].aitable[1][0].ritu = 70;
            datDevilAI.divTbls[0][84].aitable[1][1].skill = 111;
            datDevilAI.divTbls[0][84].aitable[1][1].ritu = 15;
            datDevilAI.divTbls[0][84].aitable[1][2].skill = 124;
            datDevilAI.divTbls[0][84].aitable[1][2].ritu = 15;
        }

        private static void Inugami(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 65536; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 156;
            datDevilFormat.tbl[id].maxhp = 156;
            datDevilFormat.tbl[id].mp = 80;
            datDevilFormat.tbl[id].maxmp = 80;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 176; // Fire Breath
            datDevilFormat.tbl[id].skill[4] = 204; // Fog Breath

            // AI
            datDevilAI.divTbls[0][85].aitable[0][0].skill = 54;
            datDevilAI.divTbls[0][85].aitable[0][0].ritu = 50;
            datDevilAI.divTbls[0][85].aitable[0][1].skill = 32768;
            datDevilAI.divTbls[0][85].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][85].aitable[0][2].skill = 204;
            datDevilAI.divTbls[0][85].aitable[0][2].ritu = 20;

            datDevilAI.divTbls[0][85].aitable[1][0].skill = 117;
            datDevilAI.divTbls[0][85].aitable[1][0].ritu = 80;
            datDevilAI.divTbls[0][85].aitable[1][1].skill = 32768;
            datDevilAI.divTbls[0][85].aitable[1][1].ritu = 20;

            datDevilAI.divTbls[0][85].aitable[2][0].skill = 176;
            datDevilAI.divTbls[0][85].aitable[2][0].ritu = 40;
            datDevilAI.divTbls[0][85].aitable[2][1].skill = 216;
            datDevilAI.divTbls[0][85].aitable[2][1].ritu = 40;
            datDevilAI.divTbls[0][85].aitable[2][2].skill = 54;
            datDevilAI.divTbls[0][85].aitable[2][2].ritu = 20;
        }

        private static void Nekomata(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
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

        private static void Gogmagog(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 65536; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 65536; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 954;
            datDevilFormat.tbl[id].maxhp = 954;
            datDevilFormat.tbl[id].mp = 276;
            datDevilFormat.tbl[id].maxmp = 276;

            // AI
            datDevilAI.divTbls[0][87].aitable[0][0].skill = 53;
            datDevilAI.divTbls[0][87].aitable[0][0].ritu = 34;
            datDevilAI.divTbls[0][87].aitable[0][1].skill = 52;
            datDevilAI.divTbls[0][87].aitable[0][1].ritu = 33;
            datDevilAI.divTbls[0][87].aitable[0][2].skill = 54;
            datDevilAI.divTbls[0][87].aitable[0][2].ritu = 33;

            datDevilAI.divTbls[0][87].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][87].aitable[1][0].ritu = 25;
            datDevilAI.divTbls[0][87].aitable[1][1].skill = 185;
            datDevilAI.divTbls[0][87].aitable[1][1].ritu = 25;
            datDevilAI.divTbls[0][87].aitable[1][2].skill = 98;
            datDevilAI.divTbls[0][87].aitable[1][2].ritu = 25;
            datDevilAI.divTbls[0][87].aitable[1][2].skill = 37;
            datDevilAI.divTbls[0][87].aitable[1][2].ritu = 25;
        }

        private static void Titan(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 182;
            datDevilFormat.tbl[id].maxhp = 182;
            datDevilFormat.tbl[id].mp = 120;
            datDevilFormat.tbl[id].maxmp = 120;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[4] = 205; // Taunt
            datDevilFormat.tbl[id].skill[5] = 427; // Fang Breaker

            // AI
            datDevilAI.divTbls[0][88].aitable[0][0].skill = 427;
            datDevilAI.divTbls[0][88].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[0][88].aitable[0][1].skill = 109;
            datDevilAI.divTbls[0][88].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[0][88].aitable[0][2].skill = 176;
            datDevilAI.divTbls[0][88].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][88].aitable[0][3].skill = 209;
            datDevilAI.divTbls[0][88].aitable[0][3].ritu = 20;
            datDevilAI.divTbls[0][88].aitable[0][4].skill = 205;
            datDevilAI.divTbls[0][88].aitable[0][4].ritu = 20;
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
            datAisyo.tbl[id][9] = 2147483778; // Nerve
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
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 114;
            datDevilFormat.tbl[id].maxhp = 114;
            datDevilFormat.tbl[id].mp = 80;
            datDevilFormat.tbl[id].maxmp = 80;
        }

        private static void HuaPo(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 24;
            datDevilFormat.tbl[id].maxhp = 24;
            datDevilFormat.tbl[id].mp = 28;
            datDevilFormat.tbl[id].maxmp = 28;

            datDevilFormat.tbl[id].param[4] = 5;
            datDevilFormat.tbl[id].param[5] = 6;
        }

        private static void ShikiOuji(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 65536; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 131072; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 810;
            datDevilFormat.tbl[id].maxhp = 810;
            datDevilFormat.tbl[id].mp = 312;
            datDevilFormat.tbl[id].maxmp = 312;
        }

        private static void Oni(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[7].Param = 428; // Defense Kuzushi

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 300;
            datDevilFormat.tbl[id].maxhp = 300;
            datDevilFormat.tbl[id].mp = 104;
            datDevilFormat.tbl[id].maxmp = 104;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[2] = 428; // Defense Kuzushi

            // AI
            datDevilAI.divTbls[0][94].aitable[0][0].skill = 98;
            datDevilAI.divTbls[0][94].aitable[0][0].ritu = 50;
            datDevilAI.divTbls[0][94].aitable[0][1].skill = 203;
            datDevilAI.divTbls[0][94].aitable[0][1].ritu = 25;
            datDevilAI.divTbls[0][94].aitable[0][2].skill = 428;
            datDevilAI.divTbls[0][94].aitable[0][2].ritu = 25;
        }

        private static void YomotsuIkusa(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 50; // Dark
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

            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 448; // Poison Volley
            tblSkill.fclSkillTbl[id].Event[4].Param = 69; // Makarakarn
            tblSkill.fclSkillTbl[id].Event[5].Param = 204; // Fog Breath

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 792;
            datDevilFormat.tbl[id].maxhp = 792;
            datDevilFormat.tbl[id].mp = 236;
            datDevilFormat.tbl[id].maxmp = 236;

            // AI
            datDevilAI.divTbls[0][95].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][95].aitable[0][0].ritu = 12;
            datDevilAI.divTbls[0][95].aitable[0][1].skill = 107;
            datDevilAI.divTbls[0][95].aitable[0][1].ritu = 22;
            datDevilAI.divTbls[0][95].aitable[0][2].skill = 114;
            datDevilAI.divTbls[0][95].aitable[0][2].ritu = 22;
            datDevilAI.divTbls[0][95].aitable[0][3].skill = 33;
            datDevilAI.divTbls[0][95].aitable[0][3].ritu = 22;
            datDevilAI.divTbls[0][95].aitable[0][4].skill = 448;
            datDevilAI.divTbls[0][95].aitable[0][4].ritu = 22;
        }

        private static void Momunofu(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 2147483778; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 2147483778; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 240;
            datDevilFormat.tbl[id].maxhp = 240;
            datDevilFormat.tbl[id].mp = 104;
            datDevilFormat.tbl[id].maxmp = 104;
        }

        private static void Shikigami(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
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
            // Affinities
            datAisyo.tbl[id][0] = 131072; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1506;
            datDevilFormat.tbl[id].maxhp = 1506;
            datDevilFormat.tbl[id].mp = 384;
            datDevilFormat.tbl[id].maxmp = 384;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[2] = 178; // Prominence
            datDevilFormat.tbl[id].skill[3] = 434; // Bloodbath

            // AI
            datDevilAI.divTbls[0][98].aitable[0][0].skill = 206;
            datDevilAI.divTbls[0][98].aitable[0][0].ritu = 25;
            datDevilAI.divTbls[0][98].aitable[0][1].skill = 125;
            datDevilAI.divTbls[0][98].aitable[0][1].ritu = 25;
            datDevilAI.divTbls[0][98].aitable[0][2].skill = 178;
            datDevilAI.divTbls[0][98].aitable[0][2].ritu = 25;
            datDevilAI.divTbls[0][98].aitable[0][3].skill = 434;
            datDevilAI.divTbls[0][98].aitable[0][3].ritu = 25;

            datDevilAI.divTbls[0][98].aitable[1][0].skill = 125;
            datDevilAI.divTbls[0][98].aitable[1][0].ritu = 35;
            datDevilAI.divTbls[0][98].aitable[1][1].skill = 178;
            datDevilAI.divTbls[0][98].aitable[1][1].ritu = 35;
            datDevilAI.divTbls[0][98].aitable[1][2].skill = 434;
            datDevilAI.divTbls[0][98].aitable[1][2].ritu = 35;
        }

        private static void Dakini(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 954;
            datDevilFormat.tbl[id].maxhp = 954;
            datDevilFormat.tbl[id].mp = 252;
            datDevilFormat.tbl[id].maxmp = 252;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 105; // Dark Sword

            // AI
            datDevilAI.divTbls[0][99].aitable[0][0].skill = 105;
            datDevilAI.divTbls[0][99].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[0][99].aitable[0][1].skill = 3;
            datDevilAI.divTbls[0][99].aitable[0][1].ritu = 40;
            datDevilAI.divTbls[0][99].aitable[0][2].skill = 34;
            datDevilAI.divTbls[0][99].aitable[0][2].ritu = 10;
            datDevilAI.divTbls[0][99].aitable[0][3].skill = 102;
            datDevilAI.divTbls[0][99].aitable[0][3].ritu = 20;

            datDevilAI.divTbls[0][99].aitable[0][0].skill = 105;
            datDevilAI.divTbls[0][99].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[0][99].aitable[0][1].skill = 3;
            datDevilAI.divTbls[0][99].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][99].aitable[0][2].skill = 34;
            datDevilAI.divTbls[0][99].aitable[0][2].ritu = 30;
            datDevilAI.divTbls[0][99].aitable[0][3].skill = 102;
            datDevilAI.divTbls[0][99].aitable[0][3].ritu = 20;
        }


        private static void Yaksini(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 678;
            datDevilFormat.tbl[id].maxhp = 678;
            datDevilFormat.tbl[id].mp = 216;
            datDevilFormat.tbl[id].maxmp = 216;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[6] = 21;

            // AI
            datDevilAI.divTbls[0][100].aitable[0][0].skill = 21;
            datDevilAI.divTbls[0][100].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[0][100].aitable[0][1].skill = 109;
            datDevilAI.divTbls[0][100].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][100].aitable[0][2].skill = 211;
            datDevilAI.divTbls[0][100].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][100].aitable[0][3].skill = 63;
            datDevilAI.divTbls[0][100].aitable[0][3].ritu = 20;
        }

        private static void YomotsuShikome(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 504;
            datDevilFormat.tbl[id].maxhp = 504;
            datDevilFormat.tbl[id].mp = 192;
            datDevilFormat.tbl[id].maxmp = 192;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 23;
            datDevilFormat.tbl[id].skill[4] = 448;
            datDevilFormat.tbl[id].skill[5] = 302;

            // AI
            datDevilAI.divTbls[0][101].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][101].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[0][101].aitable[0][1].skill = 112;
            datDevilAI.divTbls[0][101].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[0][101].aitable[0][2].skill = 197;
            datDevilAI.divTbls[0][101].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][101].aitable[0][3].skill = 448;
            datDevilAI.divTbls[0][101].aitable[0][3].ritu = 20;
            datDevilAI.divTbls[0][101].aitable[0][4].skill = 23;
            datDevilAI.divTbls[0][101].aitable[0][4].ritu = 20;

            datDevilAI.divTbls[0][101].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][101].aitable[1][0].ritu = 10;
            datDevilAI.divTbls[0][101].aitable[1][1].skill = 112;
            datDevilAI.divTbls[0][101].aitable[1][1].ritu = 15;
            datDevilAI.divTbls[0][101].aitable[1][2].skill = 197;
            datDevilAI.divTbls[0][101].aitable[1][2].ritu = 15;
            datDevilAI.divTbls[0][101].aitable[1][3].skill = 45157;
            datDevilAI.divTbls[0][101].aitable[1][3].ritu = 45;
            datDevilAI.divTbls[0][101].aitable[1][4].skill = 448;
            datDevilAI.divTbls[0][101].aitable[1][4].ritu = 15;

            datDevilAI.divTbls[0][101].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[0][101].aitable[2][0].ritu = 20;
            datDevilAI.divTbls[0][101].aitable[2][1].skill = 112;
            datDevilAI.divTbls[0][101].aitable[2][1].ritu = 20;
            datDevilAI.divTbls[0][101].aitable[2][2].skill = 197;
            datDevilAI.divTbls[0][101].aitable[2][2].ritu = 20;
            datDevilAI.divTbls[0][101].aitable[2][3].skill = 448;
            datDevilAI.divTbls[0][101].aitable[2][3].ritu = 20;
            datDevilAI.divTbls[0][101].aitable[2][4].skill = 23;
            datDevilAI.divTbls[0][101].aitable[2][4].ritu = 20;
        }

        private static void Taraka(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 264;
            datDevilFormat.tbl[id].maxhp = 264;
            datDevilFormat.tbl[id].mp = 104;
            datDevilFormat.tbl[id].maxmp = 104;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 14;
            datDevilFormat.tbl[id].skill[4] = 205;

            // AI
            datDevilAI.divTbls[0][102].aitable[0][0].skill = 101;
            datDevilAI.divTbls[0][102].aitable[0][0].ritu = 25;
            datDevilAI.divTbls[0][102].aitable[0][1].skill = 66;
            datDevilAI.divTbls[0][102].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[0][102].aitable[0][2].skill = 59;
            datDevilAI.divTbls[0][102].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][102].aitable[0][3].skill = 14;
            datDevilAI.divTbls[0][102].aitable[0][3].ritu = 25;
            datDevilAI.divTbls[0][102].aitable[0][4].skill = 205;
            datDevilAI.divTbls[0][102].aitable[0][4].ritu = 10;
        }

        private static void DatsueBa(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
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
            tblSkill.fclSkillTbl[id].Event[6].Param = 60; // Lullaby
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
            // Affinities
            datAisyo.tbl[id][0] = 262144; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 2147483778; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[4].Param = 459; // Luster Candy
            tblSkill.fclSkillTbl[id].Event[5].Param = 365; // Anti-Ailments
            tblSkill.fclSkillTbl[id].Event[6].Param = 292; // Life Surge
            tblSkill.fclSkillTbl[id].Event[7].Param = 38; // Diarahan
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 88;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1974;
            datDevilFormat.tbl[id].maxhp = 1974;
            datDevilFormat.tbl[id].mp = 416;
            datDevilFormat.tbl[id].maxmp = 416;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[4] = 459; // Luster Candy

            // AI
            datDevilAI.divTbls[0][104].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][104].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[0][104].aitable[0][1].skill = 206;
            datDevilAI.divTbls[0][104].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[0][104].aitable[0][2].skill = 100;
            datDevilAI.divTbls[0][104].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][104].aitable[0][3].skill = 217;
            datDevilAI.divTbls[0][104].aitable[0][3].ritu = 20;
            datDevilAI.divTbls[0][104].aitable[0][4].skill = 459;
            datDevilAI.divTbls[0][104].aitable[0][4].ritu = 20;

            datDevilAI.divTbls[0][104].aitable[1][0].skill = 38;
            datDevilAI.divTbls[0][104].aitable[1][0].ritu = 20;
            datDevilAI.divTbls[0][104].aitable[1][1].skill = 32768;
            datDevilAI.divTbls[0][104].aitable[1][1].ritu = 10;
            datDevilAI.divTbls[0][104].aitable[1][2].skill = 217;
            datDevilAI.divTbls[0][104].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[0][104].aitable[1][3].skill = 100;
            datDevilAI.divTbls[0][104].aitable[1][3].ritu = 30;
            datDevilAI.divTbls[0][104].aitable[1][4].skill = 459;
            datDevilAI.divTbls[0][104].aitable[1][4].ritu = 20;

            datDevilAI.divTbls[0][104].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[0][104].aitable[2][0].ritu = 20;
            datDevilAI.divTbls[0][104].aitable[2][1].skill = 100;
            datDevilAI.divTbls[0][104].aitable[2][1].ritu = 30;
            datDevilAI.divTbls[0][104].aitable[2][2].skill = 217;
            datDevilAI.divTbls[0][104].aitable[2][2].ritu = 30;
            datDevilAI.divTbls[0][104].aitable[2][3].skill = 459;
            datDevilAI.divTbls[0][104].aitable[2][3].ritu = 20;
        }

        private static void Girimekhala(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][10] = 2147483778; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1416;
            datDevilFormat.tbl[id].maxhp = 1416;
            datDevilFormat.tbl[id].mp = 300;
            datDevilFormat.tbl[id].maxmp = 300;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[2] = 102; // Blight
            datDevilFormat.tbl[id].skill[3] = 105; // Dark Sword
            datDevilFormat.tbl[id].skill[4] = 450; // Neural Shock

            // AI
            datDevilAI.divTbls[0][105].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][105].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[0][105].aitable[0][1].skill = 211;
            datDevilAI.divTbls[0][105].aitable[0][1].ritu = 15;
            datDevilAI.divTbls[0][105].aitable[0][2].skill = 206;
            datDevilAI.divTbls[0][105].aitable[0][2].ritu = 25;
            datDevilAI.divTbls[0][105].aitable[0][3].skill = 102;
            datDevilAI.divTbls[0][105].aitable[0][3].ritu = 15;
            datDevilAI.divTbls[0][105].aitable[0][4].skill = 450;
            datDevilAI.divTbls[0][105].aitable[0][4].ritu = 15;

            datDevilAI.divTbls[0][105].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][105].aitable[1][0].ritu = 20;
            datDevilAI.divTbls[0][105].aitable[1][1].skill = 211;
            datDevilAI.divTbls[0][105].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[0][105].aitable[1][2].skill = 105;
            datDevilAI.divTbls[0][105].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[0][105].aitable[1][3].skill = 102;
            datDevilAI.divTbls[0][105].aitable[1][3].ritu = 20;
            datDevilAI.divTbls[0][105].aitable[1][4].skill = 450;
            datDevilAI.divTbls[0][105].aitable[1][4].ritu = 20;
        }

        private static void Taotie(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 2147483778; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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
            tblSkill.fclSkillTbl[id].Event[6].Param = 401; // Loan
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 69;
            tblSkill.fclSkillTbl[id].Event[7].Param = 26; // Megidola
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 70;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1566;
            datDevilFormat.tbl[id].maxhp = 1566;
            datDevilFormat.tbl[id].mp = 344;
            datDevilFormat.tbl[id].maxmp = 344;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[2] = 196;
            datDevilFormat.tbl[id].skill[3] = 25;
            datDevilFormat.tbl[id].skill[4] = 0;

            // AI
            datDevilAI.divTbls[0][106].aitable[0][0].skill = 192;
            datDevilAI.divTbls[0][106].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[0][106].aitable[0][1].skill = 68;
            datDevilAI.divTbls[0][106].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[0][106].aitable[0][2].skill = 25;
            datDevilAI.divTbls[0][106].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][106].aitable[0][3].skill = 196;
            datDevilAI.divTbls[0][106].aitable[0][3].ritu = 20;

            datDevilAI.divTbls[0][106].aitable[1][0].skill = 25;
            datDevilAI.divTbls[0][106].aitable[1][0].ritu = 85;
            datDevilAI.divTbls[0][106].aitable[1][1].skill = 68;
            datDevilAI.divTbls[0][106].aitable[1][1].ritu = 5;
            datDevilAI.divTbls[0][106].aitable[1][2].skill = 192;
            datDevilAI.divTbls[0][106].aitable[1][2].ritu = 5;
            datDevilAI.divTbls[0][106].aitable[1][3].skill = 196;
            datDevilAI.divTbls[0][106].aitable[1][3].ritu = 5;
            datDevilAI.divTbls[0][106].aitable[1][4].skill = 0;
            datDevilAI.divTbls[0][106].aitable[1][4].ritu = 0;

            datDevilAI.divTbls[0][106].aitable[2][0].skill = 182;
            datDevilAI.divTbls[0][106].aitable[2][0].ritu = 40;
            datDevilAI.divTbls[0][106].aitable[2][1].skill = 68;
            datDevilAI.divTbls[0][106].aitable[2][1].ritu = 20;
            datDevilAI.divTbls[0][106].aitable[2][2].skill = 25;
            datDevilAI.divTbls[0][106].aitable[2][2].ritu = 10;
            datDevilAI.divTbls[0][106].aitable[2][3].skill = 196;
            datDevilAI.divTbls[0][106].aitable[2][3].ritu = 30;
        }

        private static void Pazuzu(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
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
            tblSkill.fclSkillTbl[id].Event[3].Param = 327; // Null Force
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 756;
            datDevilFormat.tbl[id].maxhp = 756;
            datDevilFormat.tbl[id].mp = 256;
            datDevilFormat.tbl[id].maxmp = 256;

            // AI
            datDevilAI.divTbls[0][107].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][107].aitable[0][0].ritu = 25;
            datDevilAI.divTbls[0][107].aitable[0][1].skill = 196;
            datDevilAI.divTbls[0][107].aitable[0][1].ritu = 25;
            datDevilAI.divTbls[0][107].aitable[0][2].skill = 63;
            datDevilAI.divTbls[0][107].aitable[0][2].ritu = 25;
            datDevilAI.divTbls[0][107].aitable[0][3].skill = 114;
            datDevilAI.divTbls[0][107].aitable[0][3].ritu = 25;

            datDevilAI.divTbls[0][107].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][107].aitable[1][0].ritu = 10;
            datDevilAI.divTbls[0][107].aitable[1][1].skill = 196;
            datDevilAI.divTbls[0][107].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[0][107].aitable[1][2].skill = 63;
            datDevilAI.divTbls[0][107].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[0][107].aitable[1][3].skill = 114;
            datDevilAI.divTbls[0][107].aitable[1][3].ritu = 20;
            datDevilAI.divTbls[0][107].aitable[1][4].skill = 187;
            datDevilAI.divTbls[0][107].aitable[1][4].ritu = 30;

            datDevilAI.divTbls[0][107].aitable[2][0].skill = 196;
            datDevilAI.divTbls[0][107].aitable[2][0].ritu = 5;
            datDevilAI.divTbls[0][107].aitable[2][1].skill = 63;
            datDevilAI.divTbls[0][107].aitable[2][1].ritu = 5;
            datDevilAI.divTbls[0][107].aitable[2][2].skill = 187;
            datDevilAI.divTbls[0][107].aitable[2][2].ritu = 5;
            datDevilAI.divTbls[0][107].aitable[2][3].skill = 40;
            datDevilAI.divTbls[0][107].aitable[2][3].ritu = 85;
        }

        private static void Baphomet(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 131072; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 570;
            datDevilFormat.tbl[id].maxhp = 570;
            datDevilFormat.tbl[id].mp = 200;
            datDevilFormat.tbl[id].maxmp = 200;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 446; // Damnation
            datDevilFormat.tbl[id].skill[3] = 424; // Concentrate

            // AI
            datDevilAI.divTbls[0][108].aitable[0][0].skill = 446;
            datDevilAI.divTbls[0][108].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[0][108].aitable[0][1].skill = 5;
            datDevilAI.divTbls[0][108].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][108].aitable[0][2].skill = 32768;
            datDevilAI.divTbls[0][108].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][108].aitable[0][3].skill = 67;
            datDevilAI.divTbls[0][108].aitable[0][3].ritu = 10;

            datDevilAI.divTbls[0][108].aitable[1][0].skill = 67;
            datDevilAI.divTbls[0][108].aitable[1][0].ritu = 100;
        }

        private static void Mot(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 2036;
            datDevilFormat.tbl[id].maxhp = 2036;
            datDevilFormat.tbl[id].mp = 492;
            datDevilFormat.tbl[id].maxmp = 492;

            // AI
            datDevilAI.divTbls[0][109].aitable[0][0].skill = 6;
            datDevilAI.divTbls[0][109].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[0][109].aitable[0][1].skill = 24;
            datDevilAI.divTbls[0][109].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][109].aitable[0][2].skill = 67;
            datDevilAI.divTbls[0][109].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][109].aitable[0][3].skill = 27;
            datDevilAI.divTbls[0][109].aitable[0][3].ritu = 20;

            datDevilAI.divTbls[0][109].aitable[1][0].skill = 6;
            datDevilAI.divTbls[0][109].aitable[1][0].ritu = 20;
            datDevilAI.divTbls[0][109].aitable[1][1].skill = 24;
            datDevilAI.divTbls[0][109].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[0][109].aitable[1][2].skill = 67;
            datDevilAI.divTbls[0][109].aitable[1][2].ritu = 10;
            datDevilAI.divTbls[0][109].aitable[1][3].skill = 27;
            datDevilAI.divTbls[0][109].aitable[1][3].ritu = 50;

            datDevilAI.divTbls[0][109].aitable[2][0].skill = 6;
            datDevilAI.divTbls[0][109].aitable[2][0].ritu = 40;
            datDevilAI.divTbls[0][109].aitable[2][1].skill = 24;
            datDevilAI.divTbls[0][109].aitable[2][1].ritu = 40;
            datDevilAI.divTbls[0][109].aitable[2][2].skill = 67;
            datDevilAI.divTbls[0][109].aitable[2][2].ritu = 10;
            datDevilAI.divTbls[0][109].aitable[2][3].skill = 27;
            datDevilAI.divTbls[0][109].aitable[2][3].ritu = 10;
        }

        private static void Aciel(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 2147483778; // Phys
            datAisyo.tbl[id][1] = 65536; // Fire
            datAisyo.tbl[id][2] = 65536; // Ice
            datAisyo.tbl[id][3] = 65536; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1878;
            datDevilFormat.tbl[id].maxhp = 1878;
            datDevilFormat.tbl[id].mp = 408;
            datDevilFormat.tbl[id].maxmp = 408;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[4] = 208; // Sol Niger
            datDevilFormat.tbl[id].skill[4] = 122; // Hell Fang

            // AI
            datDevilAI.divTbls[0][110].aitable[0][0].skill = 122;
            datDevilAI.divTbls[0][110].aitable[0][0].ritu = 15;
            datDevilAI.divTbls[0][110].aitable[0][1].skill = 12;
            datDevilAI.divTbls[0][110].aitable[0][1].ritu = 45;
            datDevilAI.divTbls[0][110].aitable[0][2].skill = 70;
            datDevilAI.divTbls[0][110].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][110].aitable[0][3].skill = 208;
            datDevilAI.divTbls[0][110].aitable[0][3].ritu = 20;

            datDevilAI.divTbls[0][110].aitable[1][0].skill = 208;
            datDevilAI.divTbls[0][110].aitable[1][0].ritu = 20;
            datDevilAI.divTbls[0][110].aitable[1][1].skill = 12;
            datDevilAI.divTbls[0][110].aitable[1][1].ritu = 40;
            datDevilAI.divTbls[0][110].aitable[1][2].skill = 70;
            datDevilAI.divTbls[0][110].aitable[1][2].ritu = 40;

            datDevilAI.divTbls[0][110].aitable[2][0].skill = 122;
            datDevilAI.divTbls[0][110].aitable[2][0].ritu = 15;
            datDevilAI.divTbls[0][110].aitable[2][1].skill = 12;
            datDevilAI.divTbls[0][110].aitable[2][1].ritu = 25;
            datDevilAI.divTbls[0][110].aitable[2][2].skill = 70;
            datDevilAI.divTbls[0][110].aitable[2][2].ritu = 40;
            datDevilAI.divTbls[0][110].aitable[2][3].skill = 208;
            datDevilAI.divTbls[0][110].aitable[2][3].ritu = 20;
        }

        private static void Surt(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][8] = 65536; // Curse

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 178; // Prominence
            tblSkill.fclSkillTbl[id].Event[1].Param = 391; // Wooing
            tblSkill.fclSkillTbl[id].Event[3].Param = 203; // War Cry
            tblSkill.fclSkillTbl[id].Event[4].Param = 336; // Elec Drain
            tblSkill.fclSkillTbl[id].Event[5].Param = 436; // Ragnarok
            tblSkill.fclSkillTbl[id].Event[6].Param = 304; // Attack All

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1998;
            datDevilFormat.tbl[id].maxhp = 1998;
            datDevilFormat.tbl[id].mp = 376;
            datDevilFormat.tbl[id].maxmp = 376;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 178; // Prominence
            datDevilFormat.tbl[id].skill[2] = 436; // Ragnarok

            // AI
            datDevilAI.divTbls[0][111].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][111].aitable[0][0].ritu = 25;
            datDevilAI.divTbls[0][111].aitable[0][1].skill = 178;
            datDevilAI.divTbls[0][111].aitable[0][1].ritu = 25;
            datDevilAI.divTbls[0][111].aitable[0][2].skill = 203;
            datDevilAI.divTbls[0][111].aitable[0][2].ritu = 25;
            datDevilAI.divTbls[0][111].aitable[0][3].skill = 436;
            datDevilAI.divTbls[0][111].aitable[0][3].ritu = 25;

            datDevilAI.divTbls[0][111].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][111].aitable[1][0].ritu = 10;
            datDevilAI.divTbls[0][111].aitable[1][1].skill = 178;
            datDevilAI.divTbls[0][111].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[0][111].aitable[1][2].skill = 203;
            datDevilAI.divTbls[0][111].aitable[1][2].ritu = 50;
            datDevilAI.divTbls[0][111].aitable[1][3].skill = 436;
            datDevilAI.divTbls[0][111].aitable[1][3].ritu = 20;
        }

        private static void Abaddon(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 131072; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[5].Param = 100; // Hades Blast
            tblSkill.fclSkillTbl[id].Event[6].Param = 307; // Avenge
            tblSkill.fclSkillTbl[id].Event[7].Param = 340; // Ice Repel

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1614;
            datDevilFormat.tbl[id].maxhp = 1614;
            datDevilFormat.tbl[id].mp = 372;
            datDevilFormat.tbl[id].maxmp = 372;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 307; // Avenge

            // AI
            datDevilAI.divTbls[0][112].aitable[0][0].skill = 12;
            datDevilAI.divTbls[0][112].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[0][112].aitable[0][1].skill = 216;
            datDevilAI.divTbls[0][112].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][112].aitable[0][2].skill = 100;
            datDevilAI.divTbls[0][112].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][112].aitable[0][3].skill = 32768;
            datDevilAI.divTbls[0][112].aitable[0][3].ritu = 20;

            datDevilAI.divTbls[0][112].aitable[1][0].skill = 100;
            datDevilAI.divTbls[0][112].aitable[1][0].ritu = 100;
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1056;
            datDevilFormat.tbl[id].maxhp = 1056;
            datDevilFormat.tbl[id].mp = 288;
            datDevilFormat.tbl[id].maxmp = 288;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[4] = 437; // Refrigerate

            // AI
            datDevilAI.divTbls[0][113].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][113].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[0][113].aitable[0][1].skill = 12;
            datDevilAI.divTbls[0][113].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[0][113].aitable[0][2].skill = 56;
            datDevilAI.divTbls[0][113].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][113].aitable[0][3].skill = 32769;
            datDevilAI.divTbls[0][113].aitable[0][3].ritu = 20;
            datDevilAI.divTbls[0][113].aitable[0][4].skill = 437;
            datDevilAI.divTbls[0][113].aitable[0][4].ritu = 20;

            datDevilAI.divTbls[0][113].aitable[1][0].skill = 12;
            datDevilAI.divTbls[0][113].aitable[1][0].ritu = 50;
            datDevilAI.divTbls[0][113].aitable[1][1].skill = 56;
            datDevilAI.divTbls[0][113].aitable[1][1].ritu = 50;
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 2160;
            datDevilFormat.tbl[id].maxhp = 2160;
            datDevilFormat.tbl[id].mp = 440;
            datDevilFormat.tbl[id].maxmp = 440;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[2] = 455; // Soul Drain
            datDevilFormat.tbl[id].skill[3] = 441; // Thunder Gods
            datDevilFormat.tbl[id].skill[5] = 122; // Hell Fang

            // AI
            datDevilAI.divTbls[0][114].aitable[0][0].skill = 122;
            datDevilAI.divTbls[0][114].aitable[0][0].ritu = 25;
            datDevilAI.divTbls[0][114].aitable[0][1].skill = 215;
            datDevilAI.divTbls[0][114].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][114].aitable[0][2].skill = 196;
            datDevilAI.divTbls[0][114].aitable[0][2].ritu = 10;
            datDevilAI.divTbls[0][114].aitable[0][3].skill = 455;
            datDevilAI.divTbls[0][114].aitable[0][3].ritu = 10;
            datDevilAI.divTbls[0][114].aitable[0][4].skill = 441;
            datDevilAI.divTbls[0][114].aitable[0][4].ritu = 25;

            datDevilAI.divTbls[0][114].aitable[1][0].skill = 26;
            datDevilAI.divTbls[0][114].aitable[1][0].ritu = 45;
            datDevilAI.divTbls[0][114].aitable[1][1].skill = 215;
            datDevilAI.divTbls[0][114].aitable[1][1].ritu = 25;
            datDevilAI.divTbls[0][114].aitable[1][2].skill = 196;
            datDevilAI.divTbls[0][114].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[0][114].aitable[1][3].skill = 122;
            datDevilAI.divTbls[0][114].aitable[1][3].ritu = 10;
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1560;
            datDevilFormat.tbl[id].maxhp = 1560;
            datDevilFormat.tbl[id].mp = 388;
            datDevilFormat.tbl[id].maxmp = 388;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[2] = 455; // Soul Drain

            // AI
            datDevilAI.divTbls[0][115].aitable[0][0].skill = 60;
            datDevilAI.divTbls[0][115].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[0][115].aitable[0][1].skill = 181;
            datDevilAI.divTbls[0][115].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[0][115].aitable[0][2].skill = 455;
            datDevilAI.divTbls[0][115].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][115].aitable[0][3].skill = 69;
            datDevilAI.divTbls[0][115].aitable[0][3].ritu = 10;
            datDevilAI.divTbls[0][115].aitable[0][4].skill = 206;
            datDevilAI.divTbls[0][115].aitable[0][4].ritu = 10;

            datDevilAI.divTbls[0][115].aitable[1][0].skill = 60;
            datDevilAI.divTbls[0][115].aitable[1][0].ritu = 80;
            datDevilAI.divTbls[0][115].aitable[1][1].skill = 181;
            datDevilAI.divTbls[0][115].aitable[1][1].ritu = 10;
            datDevilAI.divTbls[0][115].aitable[1][1].skill = 455;
            datDevilAI.divTbls[0][115].aitable[1][1].ritu = 10;

            datDevilAI.divTbls[0][115].aitable[2][0].skill = 60;
            datDevilAI.divTbls[0][115].aitable[2][0].ritu = 20;
            datDevilAI.divTbls[0][115].aitable[2][1].skill = 181;
            datDevilAI.divTbls[0][115].aitable[2][1].ritu = 10;
            datDevilAI.divTbls[0][115].aitable[2][2].skill = 455;
            datDevilAI.divTbls[0][115].aitable[2][2].ritu = 10;
            datDevilAI.divTbls[0][115].aitable[2][3].skill = 69;
            datDevilAI.divTbls[0][115].aitable[2][3].ritu = 50;
            datDevilAI.divTbls[0][115].aitable[2][4].skill = 206;
            datDevilAI.divTbls[0][115].aitable[2][4].ritu = 10;
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1474;
            datDevilFormat.tbl[id].maxhp = 1474;
            datDevilFormat.tbl[id].mp = 308;
            datDevilFormat.tbl[id].maxmp = 308;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[2] = 41; // Mediarahan
            datDevilFormat.tbl[id].skill[5] = 452; // Pulinpaon
            datDevilFormat.tbl[id].skill[6] = 424; // Concentrate

            // AI
            datDevilAI.divTbls[0][116].aitable[0][0].skill = 18;
            datDevilAI.divTbls[0][116].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[0][116].aitable[0][1].skill = 32768;
            datDevilAI.divTbls[0][116].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[0][116].aitable[0][2].skill = 452;
            datDevilAI.divTbls[0][116].aitable[0][2].ritu = 40;

            datDevilAI.divTbls[0][116].aitable[1][0].skill = 41;
            datDevilAI.divTbls[0][116].aitable[1][0].ritu = 40;
            datDevilAI.divTbls[0][116].aitable[1][1].skill = 32768;
            datDevilAI.divTbls[0][116].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[0][116].aitable[1][2].skill = 18;
            datDevilAI.divTbls[0][116].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[0][116].aitable[1][3].skill = 452;
            datDevilAI.divTbls[0][116].aitable[1][3].ritu = 20;
        }

        private static void Succubus(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 366;
            datDevilFormat.tbl[id].maxhp = 366;
            datDevilFormat.tbl[id].mp = 212;
            datDevilFormat.tbl[id].maxmp = 212;
        }

        private static void Incubus(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 294;
            datDevilFormat.tbl[id].maxhp = 294;
            datDevilFormat.tbl[id].mp = 156;
            datDevilFormat.tbl[id].maxmp = 156;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 125; // Stun Claw
            datDevilFormat.tbl[id].skill[4] = 461; // Storm Gale

            // AI
            datDevilAI.divTbls[0][118].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][118].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[0][118].aitable[0][1].skill = 214;
            datDevilAI.divTbls[0][118].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[0][118].aitable[0][2].skill = 125;
            datDevilAI.divTbls[0][118].aitable[0][2].ritu = 60;

            datDevilAI.divTbls[0][118].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[0][118].aitable[1][0].ritu = 20;
            datDevilAI.divTbls[0][118].aitable[1][1].skill = 192;
            datDevilAI.divTbls[0][118].aitable[1][1].ritu = 30;
            datDevilAI.divTbls[0][118].aitable[1][2].skill = 199;
            datDevilAI.divTbls[0][118].aitable[1][2].ritu = 30;
            datDevilAI.divTbls[0][118].aitable[1][3].skill = 461;
            datDevilAI.divTbls[0][118].aitable[1][3].ritu = 20;
        }

        private static void Fomorian(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 80; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 65536; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 7; // Bufu
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 210; // Dormina
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
            datAisyo.tbl[id][2] = 2147483778; // Ice
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
            //datDevilNegoFormat.tbl[120].itema[0].item = 36;
        }

        private static void Hresvelgr(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1800;
            datDevilFormat.tbl[id].maxhp = 1800;
            datDevilFormat.tbl[id].mp = 380;
            datDevilFormat.tbl[id].maxmp = 380;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[1] = 462; // Winged Fury
            datDevilFormat.tbl[id].skill[3] = 310; // Ice Boost

            // AI
            datDevilAI.divTbls[0][121].aitable[0][0].skill = 12;
            datDevilAI.divTbls[0][121].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[0][121].aitable[0][1].skill = 462;
            datDevilAI.divTbls[0][121].aitable[0][1].ritu = 40;
            datDevilAI.divTbls[0][121].aitable[0][2].skill = 126;
            datDevilAI.divTbls[0][121].aitable[0][2].ritu = 20;

            datDevilAI.divTbls[0][121].aitable[1][0].skill = 12;
            datDevilAI.divTbls[0][121].aitable[1][0].ritu = 15;
            datDevilAI.divTbls[0][121].aitable[1][1].skill = 462;
            datDevilAI.divTbls[0][121].aitable[1][1].ritu = 15;
            datDevilAI.divTbls[0][121].aitable[1][2].skill = 126;
            datDevilAI.divTbls[0][121].aitable[1][2].ritu = 70;
        }

        private static void Mothman(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 65536; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 199; // Evil Gaze
            tblSkill.fclSkillTbl[id].Event[0].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[1].Param = 125; // Stun Claw
            tblSkill.fclSkillTbl[id].Event[1].TargetLevel = 0;
            tblSkill.fclSkillTbl[id].Event[2].Param = 211; // Binding Cry
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 540;
            datDevilFormat.tbl[id].maxhp = 540;
            datDevilFormat.tbl[id].mp = 244;
            datDevilFormat.tbl[id].maxmp = 244;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 211;
            datDevilFormat.tbl[id].skill[2] = 125;
            datDevilFormat.tbl[id].skill[3] = 450;
            datDevilFormat.tbl[id].skill[4] = 452;

            // AI
            datDevilAI.divTbls[0][122].aitable[0][0].skill = 125;
            datDevilAI.divTbls[0][122].aitable[0][0].ritu = 24;
            datDevilAI.divTbls[0][122].aitable[0][1].skill = 199;
            datDevilAI.divTbls[0][122].aitable[0][1].ritu = 24;
            datDevilAI.divTbls[0][122].aitable[0][2].skill = 211;
            datDevilAI.divTbls[0][122].aitable[0][2].ritu = 24;
            datDevilAI.divTbls[0][122].aitable[0][3].skill = 450;
            datDevilAI.divTbls[0][122].aitable[0][3].ritu = 14;
            datDevilAI.divTbls[0][122].aitable[0][4].skill = 452;
            datDevilAI.divTbls[0][122].aitable[0][4].ritu = 14;
        }

        private static void Raiju(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 262144; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 312;
            datDevilFormat.tbl[id].maxhp = 312;
            datDevilFormat.tbl[id].mp = 160;
            datDevilFormat.tbl[id].maxmp = 160;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 440;

            // AI
            datDevilAI.divTbls[0][123].aitable[0][0].skill = 440;
            datDevilAI.divTbls[0][123].aitable[0][0].ritu = 25;
            datDevilAI.divTbls[0][123].aitable[0][1].skill = 123;
            datDevilAI.divTbls[0][123].aitable[0][1].ritu = 25;
            datDevilAI.divTbls[0][123].aitable[0][2].skill = 111;
            datDevilAI.divTbls[0][123].aitable[0][2].ritu = 25;
            datDevilAI.divTbls[0][123].aitable[0][3].skill = 182;
            datDevilAI.divTbls[0][123].aitable[0][3].ritu = 25;
        }

        private static void Nue(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 65536; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 360;
            datDevilFormat.tbl[id].maxhp = 360;
            datDevilFormat.tbl[id].mp = 160;
            datDevilFormat.tbl[id].maxmp = 160;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[5] = 437;

            // AI
            datDevilAI.divTbls[0][124].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[0][124].aitable[0][0].ritu = 50;
            datDevilAI.divTbls[0][124].aitable[0][1].skill = 203;
            datDevilAI.divTbls[0][124].aitable[0][1].ritu = 50;

            datDevilAI.divTbls[0][124].aitable[1][0].skill = 437;
            datDevilAI.divTbls[0][124].aitable[1][0].ritu = 20;
            datDevilAI.divTbls[0][124].aitable[1][1].skill = 125;
            datDevilAI.divTbls[0][124].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[0][124].aitable[1][2].skill = 180;
            datDevilAI.divTbls[0][124].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[0][124].aitable[1][3].skill = 34;
            datDevilAI.divTbls[0][124].aitable[1][3].ritu = 20;
            datDevilAI.divTbls[0][124].aitable[1][4].skill = 41084;
            datDevilAI.divTbls[0][124].aitable[1][4].ritu = 20;
        }

        private static void Bicorn(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 180;
            datDevilFormat.tbl[id].maxhp = 180;
            datDevilFormat.tbl[id].mp = 84;
            datDevilFormat.tbl[id].maxmp = 84;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 65; // Sukukaja

            // AI
            datDevilAI.divTbls[0][125].aitable[0][0].skill = 119;
            datDevilAI.divTbls[0][125].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[0][125].aitable[0][1].skill = 61;
            datDevilAI.divTbls[0][125].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[0][125].aitable[0][2].skill = 209;
            datDevilAI.divTbls[0][125].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[0][125].aitable[0][3].skill = 32768;
            datDevilAI.divTbls[0][125].aitable[0][3].ritu = 20;
            datDevilAI.divTbls[0][125].aitable[0][4].skill = 65;
            datDevilAI.divTbls[0][125].aitable[0][4].ritu = 20;

            datDevilAI.divTbls[0][125].aitable[1][0].skill = 119;
            datDevilAI.divTbls[0][125].aitable[1][0].ritu = 20;
            datDevilAI.divTbls[0][125].aitable[1][1].skill = 61;
            datDevilAI.divTbls[0][125].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[0][125].aitable[1][2].skill = 209;
            datDevilAI.divTbls[0][125].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[0][125].aitable[1][3].skill = 32768;
            datDevilAI.divTbls[0][125].aitable[1][3].ritu = 20;
            datDevilAI.divTbls[0][125].aitable[1][4].skill = 65;
            datDevilAI.divTbls[0][125].aitable[1][4].ritu = 20;

            datDevilAI.divTbls[0][125].aitable[2][0].skill = 119;
            datDevilAI.divTbls[0][125].aitable[2][0].ritu = 70;
            datDevilAI.divTbls[0][125].aitable[2][1].skill = 32768;
            datDevilAI.divTbls[0][125].aitable[2][1].ritu = 30;
        }

        private static void Zhen(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
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
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 131072; // Dark
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1470;
            datDevilFormat.tbl[id].maxhp = 1470;
            datDevilFormat.tbl[id].mp = 332;
            datDevilFormat.tbl[id].maxmp = 332;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 449; // Poison Salvo
            datDevilFormat.tbl[id].skill[3] = 434; // Bloodbath

            // AI
            datDevilAI.divTbls[0][127].aitable[0][0].skill = 449;
            datDevilAI.divTbls[0][127].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[0][127].aitable[0][1].skill = 434;
            datDevilAI.divTbls[0][127].aitable[0][1].ritu = 40;
            datDevilAI.divTbls[0][127].aitable[0][2].skill = 125;
            datDevilAI.divTbls[0][127].aitable[0][2].ritu = 40;

            datDevilAI.divTbls[0][127].aitable[1][0].skill = 192;
            datDevilAI.divTbls[0][127].aitable[1][0].ritu = 100;
        }

        private static void Legion(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 131072; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[5].Param = 452; // Pulinpaon

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 630;
            datDevilFormat.tbl[id].maxhp = 630;
            datDevilFormat.tbl[id].mp = 240;
            datDevilFormat.tbl[id].maxmp = 240;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[5] = 452; // Pulinpaon

            // AI
            datDevilAI.divTbls[1][0].aitable[0][0].skill = 196;
            datDevilAI.divTbls[1][0].aitable[0][0].ritu = 15;
            datDevilAI.divTbls[1][0].aitable[0][1].skill = 190;
            datDevilAI.divTbls[1][0].aitable[0][1].ritu = 15;
            datDevilAI.divTbls[1][0].aitable[0][2].skill = 70;
            datDevilAI.divTbls[1][0].aitable[0][2].ritu = 55;
            datDevilAI.divTbls[1][0].aitable[0][3].skill = 452;
            datDevilAI.divTbls[1][0].aitable[0][3].ritu = 15;

            datDevilAI.divTbls[1][0].aitable[1][0].skill = 35;
            datDevilAI.divTbls[1][0].aitable[1][0].ritu = 25;
            datDevilAI.divTbls[1][0].aitable[1][1].skill = 196;
            datDevilAI.divTbls[1][0].aitable[1][1].ritu = 25;
            datDevilAI.divTbls[1][0].aitable[1][2].skill = 190;
            datDevilAI.divTbls[1][0].aitable[1][2].ritu = 25;
            datDevilAI.divTbls[1][0].aitable[1][3].skill = 452;
            datDevilAI.divTbls[1][0].aitable[1][3].ritu = 25;

            datDevilAI.divTbls[1][0].aitable[2][0].skill = 35;
            datDevilAI.divTbls[1][0].aitable[2][0].ritu = 25;
            datDevilAI.divTbls[1][0].aitable[2][1].skill = 196;
            datDevilAI.divTbls[1][0].aitable[2][1].ritu = 25;
            datDevilAI.divTbls[1][0].aitable[2][2].skill = 190;
            datDevilAI.divTbls[1][0].aitable[2][2].ritu = 25;
            datDevilAI.divTbls[1][0].aitable[2][3].skill = 452;
            datDevilAI.divTbls[1][0].aitable[2][3].ritu = 25;
        }

        private static void Yaka(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
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
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
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
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
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
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[2].Param = 18; // Maziodyne

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1260;
            datDevilFormat.tbl[id].maxhp = 1260;
            datDevilFormat.tbl[id].mp = 288;
            datDevilFormat.tbl[id].maxmp = 288;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 18; // Maziodyne

            // AI
            datDevilAI.divTbls[1][4].aitable[0][0].skill = 18;
            datDevilAI.divTbls[1][4].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[1][4].aitable[0][1].skill = 67;
            datDevilAI.divTbls[1][4].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[1][4].aitable[0][2].skill = 66;
            datDevilAI.divTbls[1][4].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[1][4].aitable[0][3].skill = 65;
            datDevilAI.divTbls[1][4].aitable[0][3].ritu = 20;
            datDevilAI.divTbls[1][4].aitable[0][4].skill = 32768;
            datDevilAI.divTbls[1][4].aitable[0][4].ritu = 20;

            datDevilAI.divTbls[1][4].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[1][4].aitable[1][0].ritu = 30;
            datDevilAI.divTbls[1][4].aitable[1][1].skill = 33;
            datDevilAI.divTbls[1][4].aitable[1][1].ritu = 40;
            datDevilAI.divTbls[1][4].aitable[1][2].skill = 191;
            datDevilAI.divTbls[1][4].aitable[1][2].ritu = 30;

            datDevilAI.divTbls[1][4].aitable[2][0].skill = 32768;
            datDevilAI.divTbls[1][4].aitable[2][0].ritu = 30;
            datDevilAI.divTbls[1][4].aitable[2][1].skill = 64;
            datDevilAI.divTbls[1][4].aitable[2][1].ritu = 40;
            datDevilAI.divTbls[1][4].aitable[2][2].skill = 18;
            datDevilAI.divTbls[1][4].aitable[2][2].ritu = 30;
        }

        private static void BlackOoze(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 444;
            datDevilFormat.tbl[id].maxhp = 444;
            datDevilFormat.tbl[id].mp = 148;
            datDevilFormat.tbl[id].maxmp = 148;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[4] = 448; // Poison Volley

            // AI
            datDevilAI.divTbls[1][5].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[1][5].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[1][5].aitable[0][1].skill = 190;
            datDevilAI.divTbls[1][5].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[1][5].aitable[0][2].skill = 216;
            datDevilAI.divTbls[1][5].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[1][5].aitable[0][3].skill = 198;
            datDevilAI.divTbls[1][5].aitable[0][3].ritu = 20;
            datDevilAI.divTbls[1][5].aitable[0][4].skill = 448;
            datDevilAI.divTbls[1][5].aitable[0][4].ritu = 20;

            datDevilAI.divTbls[1][5].aitable[1][0].skill = 36997;
            datDevilAI.divTbls[1][5].aitable[1][0].ritu = 30;
            datDevilAI.divTbls[1][5].aitable[1][1].skill = 448;
            datDevilAI.divTbls[1][5].aitable[1][1].ritu = 10;
            datDevilAI.divTbls[1][5].aitable[1][2].skill = 190;
            datDevilAI.divTbls[1][5].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[1][5].aitable[1][3].skill = 216;
            datDevilAI.divTbls[1][5].aitable[1][3].ritu = 20;
            datDevilAI.divTbls[1][5].aitable[1][4].skill = 198;
            datDevilAI.divTbls[1][5].aitable[1][4].ritu = 20;

            datDevilAI.divTbls[1][5].aitable[1][0].skill = 36997;
            datDevilAI.divTbls[1][5].aitable[1][0].ritu = 100;
        }

        private static void Blob(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
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
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
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
            datAisyo.tbl[id][6] = 2147483778; // Light
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
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
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
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 65536; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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
            tblSkill.fclSkillTbl[id].Event[11].TargetLevel = 38;
            tblSkill.fclSkillTbl[id].Event[11].Type = 6;

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1800;
            datDevilFormat.tbl[id].maxhp = 1800;
            datDevilFormat.tbl[id].mp = 480;
            datDevilFormat.tbl[id].maxmp = 480;

            datDevilFormat.tbl[id].dropexp = 800;
            datDevilFormat.tbl[id].dropmakka = 4000;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 109; // Guillotine
            datDevilFormat.tbl[id].skill[1] = 2; // Agilao
            datDevilFormat.tbl[id].skill[2] = 37; // Diarama
            datDevilFormat.tbl[id].skill[3] = 226; // Gathering
            datDevilFormat.tbl[id].skill[4] = 305; // Counter
            datDevilFormat.tbl[id].skill[5] = 299; // Might
            datDevilFormat.tbl[id].skill[6] = 277; // Startle
            datDevilFormat.tbl[id].skill[7] = 366; // Abyssal Mask
        }

        private static void Arahabaki(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 65536; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 2147483778; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 2147483778; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 594;
            datDevilFormat.tbl[id].maxhp = 594;
            datDevilFormat.tbl[id].mp = 160;
            datDevilFormat.tbl[id].maxmp = 160;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 446; // Damnation
            datDevilFormat.tbl[id].skill[4] = 25; // Megido

            // AI
            datDevilAI.divTbls[1][16].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[1][16].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[1][16].aitable[0][1].skill = 446;
            datDevilAI.divTbls[1][16].aitable[0][1].ritu = 40;
            datDevilAI.divTbls[1][16].aitable[0][2].skill = 197;
            datDevilAI.divTbls[1][16].aitable[0][2].ritu = 30;

            datDevilAI.divTbls[1][16].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[1][16].aitable[1][0].ritu = 60;
            datDevilAI.divTbls[1][16].aitable[1][1].skill = 25;
            datDevilAI.divTbls[1][16].aitable[1][1].ritu = 40;
        }

        private static void KuramaTengu(ushort id)
        {
            datAisyo.tbl[id][1] = 65536; // Fire

            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 21; // Zandyne

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 2200;
            datDevilFormat.tbl[id].maxhp = 2200;
            datDevilFormat.tbl[id].mp = 640;
            datDevilFormat.tbl[id].maxmp = 640;

            datDevilFormat.tbl[id].dropexp = 1000;
            datDevilFormat.tbl[id].dropmakka = 5000;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 21; // Zandyne
            datDevilFormat.tbl[id].skill[1] = 193; // Violet Flash
            datDevilFormat.tbl[id].skill[2] = 204; // Fog Breath
            datDevilFormat.tbl[id].skill[3] = 226; // Gathering
            datDevilFormat.tbl[id].skill[4] = 312; // Force Boost
            datDevilFormat.tbl[id].skill[5] = 366; // Abyssal Mask
        }

        private static void CuChulainn(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys

            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 426; // Sakura Rage
            tblSkill.fclSkillTbl[id].Event[4].Param = 426; // Sakura Rage
            tblSkill.fclSkillTbl[id].Event[5].Param = 474; // Gae Bolg
            tblSkill.fclSkillTbl[id].Event[6].Param = 474; // Gae Bolg
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
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
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
            datAisyo.tbl[id][3] = 2147483778; // Elec
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1200;
            datDevilFormat.tbl[id].maxhp = 1200;
            datDevilFormat.tbl[id].mp = 300;
            datDevilFormat.tbl[id].maxmp = 300;

            datDevilFormat.tbl[id].dropexp = 300;
            datDevilFormat.tbl[id].dropmakka = 1000;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 8; // Bufula
            datDevilFormat.tbl[id].skill[1] = 180; // Ice Breath
            datDevilFormat.tbl[id].skill[2] = 430; // Chi Blast
            datDevilFormat.tbl[id].skill[3] = 66; // Rakukaja
            datDevilFormat.tbl[id].skill[4] = 310; // Ice Boost
            datDevilFormat.tbl[id].skill[5] = 366; // Abyssal Mask
        }

        private static void Barong(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 262144; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 2147483778; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[6].Param = 413; // Persuade
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 65;
            tblSkill.fclSkillTbl[id].Event[6].Type = 1;
        }

        private static void Makami(ushort id)
        {
            // Enemy Stats
            datDevilFormat.tbl[id].hp = 800;
            datDevilFormat.tbl[id].maxhp = 800;
            datDevilFormat.tbl[id].mp = 700;
            datDevilFormat.tbl[id].maxmp = 700;

            datDevilFormat.tbl[id].dropexp = 360;
            datDevilFormat.tbl[id].dropmakka = 1000;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 204; // Fog Breath
            datDevilFormat.tbl[id].skill[1] = 176; // Fire Breath
            datDevilFormat.tbl[id].skill[2] = 39; // Media
            datDevilFormat.tbl[id].skill[3] = 37; // Diarama
            datDevilFormat.tbl[id].skill[4] = 117; // Feral Bite
            datDevilFormat.tbl[id].skill[5] = 226; // Gathering
            datDevilFormat.tbl[id].skill[6] = 309; // Fire Boost
            datDevilFormat.tbl[id].skill[7] = 366; // Abyssal Mask
        }

        private static void Garuda(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][4] = 131072; // Force
            datAisyo.tbl[id][7] = 2147483778; // Dark
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
            datAisyo.tbl[id][6] = 2147483778; // Light
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1044;
            datDevilFormat.tbl[id].maxhp = 1044;
            datDevilFormat.tbl[id].mp = 340;
            datDevilFormat.tbl[id].maxmp = 340;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 183; // Bolt Storm
            datDevilFormat.tbl[id].skill[3] = 447; // Millenia Curse

            // AI
            datDevilAI.divTbls[1][26].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[1][26].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[1][26].aitable[0][1].skill = 183;
            datDevilAI.divTbls[1][26].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[1][26].aitable[0][2].skill = 21;
            datDevilAI.divTbls[1][26].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[1][26].aitable[0][3].skill = 183;
            datDevilAI.divTbls[1][26].aitable[0][3].ritu = 20;
            datDevilAI.divTbls[1][26].aitable[0][4].skill = 447;
            datDevilAI.divTbls[1][26].aitable[0][4].ritu = 20;

            datDevilAI.divTbls[1][26].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[1][26].aitable[1][0].ritu = 10;
            datDevilAI.divTbls[1][26].aitable[1][1].skill = 183;
            datDevilAI.divTbls[1][26].aitable[1][1].ritu = 10;
            datDevilAI.divTbls[1][26].aitable[1][2].skill = 21;
            datDevilAI.divTbls[1][26].aitable[1][2].ritu = 35;
            datDevilAI.divTbls[1][26].aitable[1][3].skill = 183;
            datDevilAI.divTbls[1][26].aitable[1][3].ritu = 35;
            datDevilAI.divTbls[1][26].aitable[1][4].skill = 447;
            datDevilAI.divTbls[1][26].aitable[1][4].ritu = 10;
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

        private static void Manikin1(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 84;
            datDevilFormat.tbl[id].maxhp = 84;
            datDevilFormat.tbl[id].mp = 72;
            datDevilFormat.tbl[id].maxmp = 72;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 203;
            datDevilFormat.tbl[id].skill[1] = 211;
            datDevilFormat.tbl[id].skill[2] = 216;
            datDevilFormat.tbl[id].skill[3] = 367;

            // AI
            datDevilAI.divTbls[1][28].scriptid = 67;

            datDevilAI.divTbls[1][28].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[1][28].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[1][28].aitable[0][1].skill = 203;
            datDevilAI.divTbls[1][28].aitable[0][1].ritu = 10;
            datDevilAI.divTbls[1][28].aitable[0][2].skill = 211;
            datDevilAI.divTbls[1][28].aitable[0][2].ritu = 10;
            datDevilAI.divTbls[1][28].aitable[0][3].skill = 216;
            datDevilAI.divTbls[1][28].aitable[0][3].ritu = 10;
            datDevilAI.divTbls[1][28].aitable[0][4].skill = 32769;
            datDevilAI.divTbls[1][28].aitable[0][4].ritu = 40;

            datDevilAI.divTbls[1][28].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[1][28].aitable[1][0].ritu = 30;
            datDevilAI.divTbls[1][28].aitable[1][1].skill = 203;
            datDevilAI.divTbls[1][28].aitable[1][1].ritu = 10;
            datDevilAI.divTbls[1][28].aitable[1][2].skill = 211;
            datDevilAI.divTbls[1][28].aitable[1][2].ritu = 10;
            datDevilAI.divTbls[1][28].aitable[1][3].skill = 216;
            datDevilAI.divTbls[1][28].aitable[1][3].ritu = 10;
            datDevilAI.divTbls[1][28].aitable[1][4].skill = 32769;
            datDevilAI.divTbls[1][28].aitable[1][4].ritu = 40;
        }

        private static void Manikin2(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 84;
            datDevilFormat.tbl[id].maxhp = 84;
            datDevilFormat.tbl[id].mp = 72;
            datDevilFormat.tbl[id].maxmp = 72;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 203;
            datDevilFormat.tbl[id].skill[1] = 211;
            datDevilFormat.tbl[id].skill[2] = 216;
            datDevilFormat.tbl[id].skill[3] = 367;

            // AI
            datDevilAI.divTbls[1][29].scriptid = 67;

            datDevilAI.divTbls[1][29].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[1][29].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[1][29].aitable[0][1].skill = 203;
            datDevilAI.divTbls[1][29].aitable[0][1].ritu = 10;
            datDevilAI.divTbls[1][29].aitable[0][2].skill = 211;
            datDevilAI.divTbls[1][29].aitable[0][2].ritu = 10;
            datDevilAI.divTbls[1][29].aitable[0][3].skill = 216;
            datDevilAI.divTbls[1][29].aitable[0][3].ritu = 10;
            datDevilAI.divTbls[1][29].aitable[0][4].skill = 32769;
            datDevilAI.divTbls[1][29].aitable[0][4].ritu = 40;

            datDevilAI.divTbls[1][29].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[1][29].aitable[1][0].ritu = 30;
            datDevilAI.divTbls[1][29].aitable[1][1].skill = 203;
            datDevilAI.divTbls[1][29].aitable[1][1].ritu = 10;
            datDevilAI.divTbls[1][29].aitable[1][2].skill = 211;
            datDevilAI.divTbls[1][29].aitable[1][2].ritu = 10;
            datDevilAI.divTbls[1][29].aitable[1][3].skill = 216;
            datDevilAI.divTbls[1][29].aitable[1][3].ritu = 10;
            datDevilAI.divTbls[1][29].aitable[1][4].skill = 32769;
            datDevilAI.divTbls[1][29].aitable[1][4].ritu = 40;
        }

        private static void Manikin3(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 84;
            datDevilFormat.tbl[id].maxhp = 84;
            datDevilFormat.tbl[id].mp = 72;
            datDevilFormat.tbl[id].maxmp = 72;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 203;
            datDevilFormat.tbl[id].skill[1] = 211;
            datDevilFormat.tbl[id].skill[2] = 216;
            datDevilFormat.tbl[id].skill[3] = 367;

            // AI
            datDevilAI.divTbls[1][30].scriptid = 67;

            datDevilAI.divTbls[1][30].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[1][30].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[1][30].aitable[0][1].skill = 203;
            datDevilAI.divTbls[1][30].aitable[0][1].ritu = 10;
            datDevilAI.divTbls[1][30].aitable[0][2].skill = 211;
            datDevilAI.divTbls[1][30].aitable[0][2].ritu = 10;
            datDevilAI.divTbls[1][30].aitable[0][3].skill = 216;
            datDevilAI.divTbls[1][30].aitable[0][3].ritu = 10;
            datDevilAI.divTbls[1][30].aitable[0][4].skill = 32769;
            datDevilAI.divTbls[1][30].aitable[0][4].ritu = 40;

            datDevilAI.divTbls[1][30].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[1][30].aitable[1][0].ritu = 30;
            datDevilAI.divTbls[1][30].aitable[1][1].skill = 203;
            datDevilAI.divTbls[1][30].aitable[1][1].ritu = 10;
            datDevilAI.divTbls[1][30].aitable[1][2].skill = 211;
            datDevilAI.divTbls[1][30].aitable[1][2].ritu = 10;
            datDevilAI.divTbls[1][30].aitable[1][3].skill = 216;
            datDevilAI.divTbls[1][30].aitable[1][3].ritu = 10;
            datDevilAI.divTbls[1][30].aitable[1][4].skill = 32769;
            datDevilAI.divTbls[1][30].aitable[1][4].ritu = 40;
        }

        private static void Manikin4(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 84;
            datDevilFormat.tbl[id].maxhp = 84;
            datDevilFormat.tbl[id].mp = 72;
            datDevilFormat.tbl[id].maxmp = 72;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 203;
            datDevilFormat.tbl[id].skill[1] = 211;
            datDevilFormat.tbl[id].skill[2] = 216;
            datDevilFormat.tbl[id].skill[3] = 367;

            // AI
            datDevilAI.divTbls[1][31].scriptid = 67;

            datDevilAI.divTbls[1][31].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[1][31].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[1][31].aitable[0][1].skill = 203;
            datDevilAI.divTbls[1][31].aitable[0][1].ritu = 10;
            datDevilAI.divTbls[1][31].aitable[0][2].skill = 211;
            datDevilAI.divTbls[1][31].aitable[0][2].ritu = 10;
            datDevilAI.divTbls[1][31].aitable[0][3].skill = 216;
            datDevilAI.divTbls[1][31].aitable[0][3].ritu = 10;
            datDevilAI.divTbls[1][31].aitable[0][4].skill = 32769;
            datDevilAI.divTbls[1][31].aitable[0][4].ritu = 40;

            datDevilAI.divTbls[1][31].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[1][31].aitable[1][0].ritu = 30;
            datDevilAI.divTbls[1][31].aitable[1][1].skill = 203;
            datDevilAI.divTbls[1][31].aitable[1][1].ritu = 10;
            datDevilAI.divTbls[1][31].aitable[1][2].skill = 211;
            datDevilAI.divTbls[1][31].aitable[1][2].ritu = 10;
            datDevilAI.divTbls[1][31].aitable[1][3].skill = 216;
            datDevilAI.divTbls[1][31].aitable[1][3].ritu = 10;
            datDevilAI.divTbls[1][31].aitable[1][4].skill = 32769;
            datDevilAI.divTbls[1][31].aitable[1][4].ritu = 40;
        }

        private static void Manikin5(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 84;
            datDevilFormat.tbl[id].maxhp = 84;
            datDevilFormat.tbl[id].mp = 72;
            datDevilFormat.tbl[id].maxmp = 72;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 203;
            datDevilFormat.tbl[id].skill[1] = 211;
            datDevilFormat.tbl[id].skill[2] = 216;
            datDevilFormat.tbl[id].skill[3] = 367;

            // AI
            datDevilAI.divTbls[1][32].scriptid = 67;

            datDevilAI.divTbls[1][32].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[1][32].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[1][32].aitable[0][1].skill = 203;
            datDevilAI.divTbls[1][32].aitable[0][1].ritu = 10;
            datDevilAI.divTbls[1][32].aitable[0][2].skill = 211;
            datDevilAI.divTbls[1][32].aitable[0][2].ritu = 10;
            datDevilAI.divTbls[1][32].aitable[0][3].skill = 216;
            datDevilAI.divTbls[1][32].aitable[0][3].ritu = 10;
            datDevilAI.divTbls[1][32].aitable[0][4].skill = 32769;
            datDevilAI.divTbls[1][32].aitable[0][4].ritu = 40;

            datDevilAI.divTbls[1][32].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[1][32].aitable[1][0].ritu = 30;
            datDevilAI.divTbls[1][32].aitable[1][1].skill = 203;
            datDevilAI.divTbls[1][32].aitable[1][1].ritu = 10;
            datDevilAI.divTbls[1][32].aitable[1][2].skill = 211;
            datDevilAI.divTbls[1][32].aitable[1][2].ritu = 10;
            datDevilAI.divTbls[1][32].aitable[1][3].skill = 216;
            datDevilAI.divTbls[1][32].aitable[1][3].ritu = 10;
            datDevilAI.divTbls[1][32].aitable[1][4].skill = 32769;
            datDevilAI.divTbls[1][32].aitable[1][4].ritu = 40;
        }

        private static void Samael(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
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
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 444;
            datDevilFormat.tbl[id].maxhp = 444;
            datDevilFormat.tbl[id].mp = 152;
            datDevilFormat.tbl[id].maxmp = 152;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[5] = 440;

            // AI
            datDevilAI.divTbls[1][39].aitable[0][0].skill = 90;
            datDevilAI.divTbls[1][39].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[1][39].aitable[0][1].skill = 209;
            datDevilAI.divTbls[1][39].aitable[0][1].ritu = 20;
            datDevilAI.divTbls[1][39].aitable[0][2].skill = 213;
            datDevilAI.divTbls[1][39].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[1][39].aitable[0][3].skill = 192;
            datDevilAI.divTbls[1][39].aitable[0][3].ritu = 20;
            datDevilAI.divTbls[1][39].aitable[0][4].skill = 440;
            datDevilAI.divTbls[1][39].aitable[0][4].ritu = 20;

            datDevilAI.divTbls[1][39].aitable[1][0].skill = 90;
            datDevilAI.divTbls[1][39].aitable[1][0].ritu = 20;
            datDevilAI.divTbls[1][39].aitable[1][1].skill = 209;
            datDevilAI.divTbls[1][39].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[1][39].aitable[1][2].skill = 213;
            datDevilAI.divTbls[1][39].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[1][39].aitable[1][3].skill = 192;
            datDevilAI.divTbls[1][39].aitable[1][3].ritu = 20;
            datDevilAI.divTbls[1][39].aitable[1][4].skill = 37031;
            datDevilAI.divTbls[1][39].aitable[1][4].ritu = 20;
        }

        private static void Kaiwan(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[6].Param = 447; // Millenia Curse

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 726;
            datDevilFormat.tbl[id].maxhp = 726;
            datDevilFormat.tbl[id].mp = 264;
            datDevilFormat.tbl[id].maxmp = 264;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[4] = 447;

            // AI
            datDevilAI.divTbls[1][40].aitable[0][0].skill = 66;
            datDevilAI.divTbls[1][40].aitable[0][0].ritu = 50;
            datDevilAI.divTbls[1][40].aitable[0][1].skill = 65;
            datDevilAI.divTbls[1][40].aitable[0][1].ritu = 50;

            datDevilAI.divTbls[1][40].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[1][40].aitable[1][0].ritu = 20;
            datDevilAI.divTbls[1][40].aitable[1][1].skill = 119;
            datDevilAI.divTbls[1][40].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[1][40].aitable[1][2].skill = 213;
            datDevilAI.divTbls[1][40].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[1][40].aitable[1][3].skill = 447;
            datDevilAI.divTbls[1][40].aitable[1][3].ritu = 20;
            datDevilAI.divTbls[1][40].aitable[1][4].skill = 33;
            datDevilAI.divTbls[1][40].aitable[1][4].ritu = 20;

            datDevilAI.divTbls[1][40].aitable[2][0].skill = 37032;
            datDevilAI.divTbls[1][40].aitable[2][0].ritu = 70;
            datDevilAI.divTbls[1][40].aitable[2][1].skill = 32768;
            datDevilAI.divTbls[1][40].aitable[2][1].ritu = 30;
        }

        private static void KinKi(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 10; // Phys
            datAisyo.tbl[id][8] = 2147483778; // Curse
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
            datAisyo.tbl[id][1] = 2147483778; // Fire
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
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[3].Param = 216; // Panic Voice
            tblSkill.fclSkillTbl[id].Event[7].Param = 429; // Primal Force
            tblSkill.fclSkillTbl[id].Event[7].TargetLevel = 71;
            tblSkill.fclSkillTbl[id].Event[7].Type = 1;
        }

        private static void OngyoKi(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][6] = 2147483778; // Light
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
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
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
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[4].Param = 70; // Tetrakarn
            tblSkill.fclSkillTbl[id].Event[5].Param = 206; // Debilitate
            tblSkill.fclSkillTbl[id].Event[6].Param = 304; // Attack All
            tblSkill.fclSkillTbl[id].Event[7].Param = 72; // Trafuri
        }

        private static void Atropos(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

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
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 34; // Mamudo
            tblSkill.fclSkillTbl[id].Event[1].Param = 68; // Tetraja
            tblSkill.fclSkillTbl[id].Event[2].Param = 77; // Dekunda
            tblSkill.fclSkillTbl[id].Event[3].Param = 448; // Poison Volley
            tblSkill.fclSkillTbl[id].Event[4].Param = 35; // Mamudoon
            tblSkill.fclSkillTbl[id].Event[5].Param = 451; // Overload
            tblSkill.fclSkillTbl[id].Event[6].Param = 206; // Debilitate
            tblSkill.fclSkillTbl[id].Event[7].Param = 152; // Last Resort

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 918;
            datDevilFormat.tbl[id].maxhp = 918;
            datDevilFormat.tbl[id].mp = 300;
            datDevilFormat.tbl[id].maxmp = 300;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 448; // Poison Volley
            datDevilFormat.tbl[id].skill[4] = 451; // Overload

            // AI
            datDevilAI.divTbls[1][48].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[1][48].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[1][48].aitable[0][1].skill = 206;
            datDevilAI.divTbls[1][48].aitable[0][1].ritu = 30;
            datDevilAI.divTbls[1][48].aitable[0][2].skill = 68;
            datDevilAI.divTbls[1][48].aitable[0][2].ritu = 30;

            datDevilAI.divTbls[1][48].aitable[1][0].skill = 34;
            datDevilAI.divTbls[1][48].aitable[1][0].ritu = 20;
            datDevilAI.divTbls[1][48].aitable[1][1].skill = 206;
            datDevilAI.divTbls[1][48].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[1][48].aitable[1][2].skill = 448;
            datDevilAI.divTbls[1][48].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[1][48].aitable[1][3].skill = 451;
            datDevilAI.divTbls[1][48].aitable[1][3].ritu = 20;
            datDevilAI.divTbls[1][48].aitable[1][4].skill = 35;
            datDevilAI.divTbls[1][48].aitable[1][4].ritu = 20;

            datDevilAI.divTbls[1][48].aitable[2][0].skill = 152;
            datDevilAI.divTbls[1][48].aitable[2][0].ritu = 100;
        }

        private static void Chatterskull(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 262144; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 2147483778; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

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
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 660;
            datDevilFormat.tbl[id].maxhp = 660;
            datDevilFormat.tbl[id].mp = 236;
            datDevilFormat.tbl[id].maxmp = 236;
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
            tblSkill.fclSkillTbl[id].Event[5].Param = 451; // Overload
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
            tblSkill.fclSkillTbl[id].Event[5].Param = 451; // Overload
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1800;
            datDevilFormat.tbl[id].maxhp = 1800;
            datDevilFormat.tbl[id].mp = 540;
            datDevilFormat.tbl[id].maxmp = 540;

            datDevilFormat.tbl[id].dropexp = 800;
            datDevilFormat.tbl[id].dropmakka = 3000;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 443; // Dervish
            datDevilFormat.tbl[id].skill[1] = 275; // Andalucia
            datDevilFormat.tbl[id].skill[2] = 276; // Red Capote
            datDevilFormat.tbl[id].skill[3] = 224; // Focus
            datDevilFormat.tbl[id].skill[4] = 205; // Taunt
            datDevilFormat.tbl[id].skill[5] = 77; // Dekunda
            datDevilFormat.tbl[id].skill[6] = 277; // Startle
            datDevilFormat.tbl[id].skill[7] = 366; // Abyssal Mask
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 3000;
            datDevilFormat.tbl[id].maxhp = 3000;
            datDevilFormat.tbl[id].mp = 720;
            datDevilFormat.tbl[id].maxmp = 720;

            datDevilFormat.tbl[id].dropexp = 1600;
            datDevilFormat.tbl[id].dropmakka = 4000;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 281; // Hell Spin
            datDevilFormat.tbl[id].skill[1] = 282; // Hell Exhaust
            datDevilFormat.tbl[id].skill[2] = 283; // Hell Burner
            datDevilFormat.tbl[id].skill[3] = 284; // Hell Throttle
            datDevilFormat.tbl[id].skill[4] = 97; // Hell Thrust
            datDevilFormat.tbl[id].skill[5] = 77; // Dekunda
            datDevilFormat.tbl[id].skill[6] = 277; // Startle
            datDevilFormat.tbl[id].skill[7] = 366; // Abyssal Mask
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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 3000;
            datDevilFormat.tbl[id].maxhp = 3000;
            datDevilFormat.tbl[id].mp = 720;
            datDevilFormat.tbl[id].maxmp = 720;

            datDevilFormat.tbl[id].dropexp = 1600;
            datDevilFormat.tbl[id].dropmakka = 4000;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 30; // Mahama
            datDevilFormat.tbl[id].skill[1] = 34; // Mamudo
            datDevilFormat.tbl[id].skill[2] = 279; // Meditation
            datDevilFormat.tbl[id].skill[3] = 278; // Preach
            datDevilFormat.tbl[id].skill[4] = 67; // Makakaja
            datDevilFormat.tbl[id].skill[5] = 57; // Dekaja
            datDevilFormat.tbl[id].skill[6] = 277; // Startle
            datDevilFormat.tbl[id].skill[7] = 366; // Abyssal Mask
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
            tblSkill.fclSkillTbl[id].Event[6].Param = 451; // Overload
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
            datAisyo.tbl[id][6] = 2147483778; // Light
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
            datDevilFormat.tbl[id].aisyoid = (short)id;

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
            tblSkill.fclSkillTbl[id].Event[4].Param = 354; // Endure
            tblSkill.fclSkillTbl[id].Event[4].TargetLevel = 85;
            tblSkill.fclSkillTbl[id].Event[4].Type = 7;
            tblSkill.fclSkillTbl[id].Event[5].Param = 311; // Elec Boost
            tblSkill.fclSkillTbl[id].Event[5].TargetLevel = 86;
            tblSkill.fclSkillTbl[id].Event[5].Type = 1;
            tblSkill.fclSkillTbl[id].Event[6].Param = 311; // Elec Boost
            tblSkill.fclSkillTbl[id].Event[6].TargetLevel = 86;
            tblSkill.fclSkillTbl[id].Event[6].Type = 5;
        }

        private static void BrokerNue(ushort id)
        {
            // Skills
            tblSkill.fclSkillTbl[id].Event[0].Param = 457; // Diamrita
            tblSkill.fclSkillTbl[id].Event[1].Param = 456; // Amrita
        }

        private static void OseHallel(int id)
        {
            datDevilFormat.tbl[id].flag = 3;
            datDevilFormat.tbl[id].race = 24;
            datDevilFormat.tbl[id].level = 70;
            datDevilFormat.tbl[id].aisyoid = (short)id;
            datDevilFormat.tbl[id].param = new sbyte[] { 25, 0, 15, 20, 22, 20 };
            datDevilFormat.tbl[id].keisyotype = 1;
            datDevilFormat.tbl[id].keisyoform = 2459;

            datDevilName.txt[id] = "オセ・ハレル";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 3, 0, 2, 2, 3, 2 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 110, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 206, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 70, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 57, TargetLevel = 71, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 77, TargetLevel = 72, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 69, TargetLevel = 73, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[6] = new fclSkillParam_t { Param = 41, TargetLevel = 74, Type = 1 };

            // Affinities
            datAisyo.tbl[id][0] = 50;
            datAisyo.tbl[id][1] = 100;
            datAisyo.tbl[id][2] = 1048676;
            datAisyo.tbl[id][3] = 1048676;
            datAisyo.tbl[id][4] = 100;
            datAisyo.tbl[id][6] = 65536;
            datAisyo.tbl[id][7] = 65536;
            datAisyo.tbl[id][8] = 65536;
            datAisyo.tbl[id][9] = 65536;
            datAisyo.tbl[id][10] = 65536;

            mdlFileDefTable.devilModelFileTable[id] = mdlFileDefTable.devilModelFileTable[289];
            mdlFileDefTable.devilOnModelFileTable[id] = mdlFileDefTable.devilOnModelFileTable[289];
            mdlFileDefTable.devilModelIndex[id] = mdlFileDefTable.devilModelIndex[289];
            mdlFileDefTable.devilOnModelIndex[id] = mdlFileDefTable.devilOnModelIndex[289];

            mdlFileDefTable.devilModelIndex[id].major = 6;
            mdlFileDefTable.devilModelIndex[id].minor = 289;
            mdlFileDefTable.devilModelIndex[id].scale = 4096;
            mdlFileDefTable.devilModelIndex[id].radius = 1000;

            datDevilVisual05.tbl_5_0A0_0BF[19] = CopyDevilVisual(datDevilVisual09.tbl_9_120_13F[1]);
            datDevilVisual05.tbl_5_0A0_0BF[19].formscale = 1f;

            datMotionSeTable.tbl[id] = 289;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[71];
        }

        private static void FlaurosHallel(int id)
        {
            datDevilFormat.tbl[id].flag = 3;
            datDevilFormat.tbl[id].race = 24;
            datDevilFormat.tbl[id].level = 70;
            datDevilFormat.tbl[id].aisyoid = (short)id;
            datDevilFormat.tbl[id].param = new sbyte[] { 35, 0, 15, 30, 18, 14 };
            datDevilFormat.tbl[id].keisyotype = 1;
            datDevilFormat.tbl[id].keisyoform = 2523;

            datDevilName.txt[id] = "フラロウス・ハレル";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 3, 0, 1, 3, 2, 1 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 105, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 166, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 203, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 186, TargetLevel = 71, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 178, TargetLevel = 72, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 345, TargetLevel = 73, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[6] = new fclSkillParam_t { Param = 104, TargetLevel = 74, Type = 1 };

            // Affinities
            datAisyo.tbl[id][0] = 50;
            datAisyo.tbl[id][1] = 100;
            datAisyo.tbl[id][2] = 1048676;
            datAisyo.tbl[id][3] = 1048676;
            datAisyo.tbl[id][4] = 100;
            datAisyo.tbl[id][6] = 65536;
            datAisyo.tbl[id][7] = 65536;
            datAisyo.tbl[id][8] = 65536;
            datAisyo.tbl[id][9] = 65536;
            datAisyo.tbl[id][10] = 65536;

            mdlFileDefTable.devilModelFileTable[id] = mdlFileDefTable.devilModelFileTable[290];
            mdlFileDefTable.devilOnModelFileTable[id] = mdlFileDefTable.devilOnModelFileTable[290];
            mdlFileDefTable.devilModelIndex[id] = mdlFileDefTable.devilModelIndex[290];
            mdlFileDefTable.devilOnModelIndex[id] = mdlFileDefTable.devilOnModelIndex[290];

            mdlFileDefTable.devilModelIndex[id].major = 6;
            mdlFileDefTable.devilModelIndex[id].minor = 290;
            mdlFileDefTable.devilModelIndex[id].scale = 4096;
            mdlFileDefTable.devilModelIndex[id].radius = 1000;

            datDevilVisual05.tbl_5_0A0_0BF[20] = CopyDevilVisual(datDevilVisual09.tbl_9_120_13F[2]);
            datDevilVisual05.tbl_5_0A0_0BF[20].formscale = 1f;

            datMotionSeTable.tbl[id] = 290;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[69];
        }

        private static void Urthona(int id)
        {
            datDevilFormat.tbl[id].flag = 3;
            datDevilFormat.tbl[id].race = 32;
            datDevilFormat.tbl[id].level = 30;
            datDevilFormat.tbl[id].aisyoid = (short)id;
            datDevilFormat.tbl[id].param = new sbyte[] { 20, 0, 10, 20, 8, 11 };
            datDevilFormat.tbl[id].keisyotype = 4;
            datDevilFormat.tbl[id].keisyoform = 2177;

            datDevilName.txt[id] = "アーソナ";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 2, 0, 1, 2, 1, 1 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 14, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 49, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 17, TargetLevel = 31, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 305, TargetLevel = 32, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 311, TargetLevel = 33, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 15, TargetLevel = 34, Type = 1 };

            // Affinities
            datAisyo.tbl[id][0] = 100;
            datAisyo.tbl[id][1] = 100;
            datAisyo.tbl[id][2] = 100;
            datAisyo.tbl[id][3] = 131072;
            datAisyo.tbl[id][4] = 2147483778;
            datAisyo.tbl[id][6] = 100;
            datAisyo.tbl[id][7] = 100;
            datAisyo.tbl[id][8] = 100;
            datAisyo.tbl[id][9] = 100;
            datAisyo.tbl[id][10] = 100;

            mdlFileDefTable.devilModelFileTable[id] = mdlFileDefTable.devilModelFileTable[279];
            mdlFileDefTable.devilOnModelFileTable[id] = mdlFileDefTable.devilOnModelFileTable[279];
            mdlFileDefTable.devilModelIndex[id] = mdlFileDefTable.devilModelIndex[279];
            mdlFileDefTable.devilOnModelIndex[id] = mdlFileDefTable.devilOnModelIndex[279];

            mdlFileDefTable.devilModelIndex[id].major = 6;
            mdlFileDefTable.devilModelIndex[id].minor = 279;
            mdlFileDefTable.devilModelIndex[id].scale = 4096;
            mdlFileDefTable.devilModelIndex[id].radius = 1000;

            datDevilVisual05.tbl_5_0A0_0BF[21] = CopyDevilVisual(datDevilVisual08.tbl_8_100_11F[23]);
            datDevilVisual05.tbl_5_0A0_0BF[21].formscale = 0.6f;

            datMotionSeTable.tbl[id] = 279;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[155];
        }

        private static void Urizen(int id)
        {
            datDevilFormat.tbl[id].flag = 3;
            datDevilFormat.tbl[id].race = 32;
            datDevilFormat.tbl[id].level = 30;
            datDevilFormat.tbl[id].aisyoid = (short)id;
            datDevilFormat.tbl[id].param = new sbyte[] { 20, 0, 10, 20, 8, 11 };
            datDevilFormat.tbl[id].keisyotype = 4;
            datDevilFormat.tbl[id].keisyoform = 2177;

            datDevilName.txt[id] = "ユリゼン";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 2, 0, 1, 2, 1, 1 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 2, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 49, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 5, TargetLevel = 31, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 305, TargetLevel = 32, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 309, TargetLevel = 33, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 3, TargetLevel = 34, Type = 1 };

            // Affinities
            datAisyo.tbl[id][0] = 100;
            datAisyo.tbl[id][1] = 131072;
            datAisyo.tbl[id][2] = 2147483778;
            datAisyo.tbl[id][3] = 100;
            datAisyo.tbl[id][4] = 100;
            datAisyo.tbl[id][6] = 100;
            datAisyo.tbl[id][7] = 100;
            datAisyo.tbl[id][8] = 100;
            datAisyo.tbl[id][9] = 100;
            datAisyo.tbl[id][10] = 100;

            mdlFileDefTable.devilModelFileTable[id] = mdlFileDefTable.devilModelFileTable[280];
            mdlFileDefTable.devilOnModelFileTable[id] = mdlFileDefTable.devilOnModelFileTable[280];
            mdlFileDefTable.devilModelIndex[id] = mdlFileDefTable.devilModelIndex[280];
            mdlFileDefTable.devilOnModelIndex[id] = mdlFileDefTable.devilOnModelIndex[280];

            mdlFileDefTable.devilModelIndex[id].major = 6;
            mdlFileDefTable.devilModelIndex[id].minor = 280;
            mdlFileDefTable.devilModelIndex[id].scale = 4096;
            mdlFileDefTable.devilModelIndex[id].radius = 1000;

            datDevilVisual05.tbl_5_0A0_0BF[22] = CopyDevilVisual(datDevilVisual08.tbl_8_100_11F[24]);
            datDevilVisual05.tbl_5_0A0_0BF[22].formscale = 0.6f;

            datMotionSeTable.tbl[id] = 280;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[155];
        }

        private static void Luvah(int id)
        {
            datDevilFormat.tbl[id].flag = 3;
            datDevilFormat.tbl[id].race = 32;
            datDevilFormat.tbl[id].level = 30;
            datDevilFormat.tbl[id].aisyoid = (short)id;
            datDevilFormat.tbl[id].param = new sbyte[] { 20, 0, 10, 20, 8, 11 };
            datDevilFormat.tbl[id].keisyotype = 4;
            datDevilFormat.tbl[id].keisyoform = 2177;

            datDevilName.txt[id] = "ルヴァ";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 2, 0, 1, 2, 1, 1 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 20, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 49, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 23, TargetLevel = 31, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 305, TargetLevel = 32, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 312, TargetLevel = 33, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 21, TargetLevel = 34, Type = 1 };

            // Affinities
            datAisyo.tbl[id][0] = 100;
            datAisyo.tbl[id][1] = 100;
            datAisyo.tbl[id][2] = 100;
            datAisyo.tbl[id][3] = 2147483778;
            datAisyo.tbl[id][4] = 131072;
            datAisyo.tbl[id][6] = 100;
            datAisyo.tbl[id][7] = 100;
            datAisyo.tbl[id][8] = 100;
            datAisyo.tbl[id][9] = 100;
            datAisyo.tbl[id][10] = 100;

            mdlFileDefTable.devilModelFileTable[id] = mdlFileDefTable.devilModelFileTable[281];
            mdlFileDefTable.devilOnModelFileTable[id] = mdlFileDefTable.devilOnModelFileTable[281];
            mdlFileDefTable.devilModelIndex[id] = mdlFileDefTable.devilModelIndex[281];
            mdlFileDefTable.devilOnModelIndex[id] = mdlFileDefTable.devilOnModelIndex[281];

            mdlFileDefTable.devilModelIndex[id].major = 6;
            mdlFileDefTable.devilModelIndex[id].minor = 281;
            mdlFileDefTable.devilModelIndex[id].scale = 4096;
            mdlFileDefTable.devilModelIndex[id].radius = 1000;

            datDevilVisual05.tbl_5_0A0_0BF[23] = CopyDevilVisual(datDevilVisual08.tbl_8_100_11F[25]);
            datDevilVisual05.tbl_5_0A0_0BF[23].formscale = 0.6f;

            datMotionSeTable.tbl[id] = 281;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[155];
        }

        private static void Tharmus(int id)
        {
            datDevilFormat.tbl[id].flag = 3;
            datDevilFormat.tbl[id].race = 32;
            datDevilFormat.tbl[id].level = 30;
            datDevilFormat.tbl[id].aisyoid = (short)id;
            datDevilFormat.tbl[id].param = new sbyte[] { 20, 0, 10, 20, 8, 11 };
            datDevilFormat.tbl[id].keisyotype = 4;
            datDevilFormat.tbl[id].keisyoform = 2177;

            datDevilName.txt[id] = "サーマス";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 2, 0, 1, 2, 1, 1 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 8, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 49, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 11, TargetLevel = 31, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 305, TargetLevel = 32, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 310, TargetLevel = 33, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 9, TargetLevel = 34, Type = 1 };

            // Affinities
            datAisyo.tbl[id][0] = 100;
            datAisyo.tbl[id][1] = 2147483778;
            datAisyo.tbl[id][2] = 131072;
            datAisyo.tbl[id][3] = 100;
            datAisyo.tbl[id][4] = 100;
            datAisyo.tbl[id][6] = 100;
            datAisyo.tbl[id][7] = 100;
            datAisyo.tbl[id][8] = 100;
            datAisyo.tbl[id][9] = 100;
            datAisyo.tbl[id][10] = 100;

            mdlFileDefTable.devilModelFileTable[id] = mdlFileDefTable.devilModelFileTable[282];
            mdlFileDefTable.devilOnModelFileTable[id] = mdlFileDefTable.devilOnModelFileTable[282];
            mdlFileDefTable.devilModelIndex[id] = mdlFileDefTable.devilModelIndex[282];
            mdlFileDefTable.devilOnModelIndex[id] = mdlFileDefTable.devilOnModelIndex[282];

            mdlFileDefTable.devilModelIndex[id].major = 6;
            mdlFileDefTable.devilModelIndex[id].minor = 282;
            mdlFileDefTable.devilModelIndex[id].scale = 4096;
            mdlFileDefTable.devilModelIndex[id].radius = 1000;

            datDevilVisual05.tbl_5_0A0_0BF[24] = CopyDevilVisual(datDevilVisual08.tbl_8_100_11F[26]);
            datDevilVisual05.tbl_5_0A0_0BF[24].formscale = 0.6f;

            datMotionSeTable.tbl[id] = 282;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[155];
        }

        private static void Specter(int id)
        {
            datDevilFormat.tbl[id].flag = 3;
            datDevilFormat.tbl[id].race = 23;
            datDevilFormat.tbl[id].level = 40;
            datDevilFormat.tbl[id].aisyoid = (short)id;
            datDevilFormat.tbl[id].param = new sbyte[] { 24, 0, 18, 20, 8, 6 };
            datDevilFormat.tbl[id].keisyotype = 4;
            datDevilFormat.tbl[id].keisyoform = 2177;

            datDevilName.txt[id] = "スペクター";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 2, 0, 2, 2, 1, 1 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 153, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 192, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 3, TargetLevel = 41, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 25, TargetLevel = 42, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 152, TargetLevel = 43, Type = 1 };

            // Affinities
            datAisyo.tbl[id][0] = 100;
            datAisyo.tbl[id][1] = 100;
            datAisyo.tbl[id][2] = 1048676;
            datAisyo.tbl[id][3] = 1048676;
            datAisyo.tbl[id][4] = 100;
            datAisyo.tbl[id][6] = 65536;
            datAisyo.tbl[id][7] = 65536;
            datAisyo.tbl[id][8] = 65536;
            datAisyo.tbl[id][9] = 65536;
            datAisyo.tbl[id][10] = 65536;

            mdlFileDefTable.devilModelFileTable[id] = mdlFileDefTable.devilModelFileTable[257];
            mdlFileDefTable.devilOnModelFileTable[id] = mdlFileDefTable.devilOnModelFileTable[257];
            mdlFileDefTable.devilModelIndex[id] = mdlFileDefTable.devilModelIndex[257];
            mdlFileDefTable.devilOnModelIndex[id] = mdlFileDefTable.devilOnModelIndex[257];

            mdlFileDefTable.devilModelIndex[id].major = 6;
            mdlFileDefTable.devilModelIndex[id].minor = 257;
            mdlFileDefTable.devilModelIndex[id].scale = 4096;
            mdlFileDefTable.devilModelIndex[id].radius = 1000;

            datDevilVisual05.tbl_5_0A0_0BF[25] = CopyDevilVisual(datDevilVisual08.tbl_8_100_11F[1]);
            datDevilVisual05.tbl_5_0A0_0BF[25].formscale = 0.8f;

            datMotionSeTable.tbl[id] = 257;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[178];
        }

        private static void Mara(int id)
        {
            datDevilFormat.tbl[id].flag = 3;
            datDevilFormat.tbl[id].race = 19;
            datDevilFormat.tbl[id].level = 85;
            datDevilFormat.tbl[id].aisyoid = (short)id;
            datDevilFormat.tbl[id].param = new sbyte[] { 30, 0, 40, 25, 14, 15 };
            datDevilFormat.tbl[id].keisyotype = 6;
            datDevilFormat.tbl[id].keisyoform = 187;

            datDevilName.txt[id] = "マーラ";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 3, 0, 4, 2, 1, 1 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 62, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 56, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 97, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 24, TargetLevel = 86, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 207, TargetLevel = 87, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 100, TargetLevel = 88, Type = 1 };

            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            mdlFileDefTable.devilModelFileTable[id] = mdlFileDefTable.devilModelFileTable[321];
            mdlFileDefTable.devilOnModelFileTable[id] = mdlFileDefTable.devilOnModelFileTable[321];
            mdlFileDefTable.devilModelIndex[id] = mdlFileDefTable.devilModelIndex[321];
            mdlFileDefTable.devilOnModelIndex[id] = mdlFileDefTable.devilOnModelIndex[321];

            mdlFileDefTable.devilModelIndex[id].major = 6;
            mdlFileDefTable.devilModelIndex[id].minor = 321;
            mdlFileDefTable.devilModelIndex[id].scale = 4096;
            mdlFileDefTable.devilModelIndex[id].radius = 1000;

            datDevilVisual05.tbl_5_0A0_0BF[26] = CopyDevilVisual(datDevilVisual10.tbl_10_140_15F[1]);
            datDevilVisual05.tbl_5_0A0_0BF[26].formscale = 1f;

            datMotionSeTable.tbl[id] = 321;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[133];
        }

        private static void TamLin(ushort id)
        {
            datDevilFormat.tbl[id].flag = 3;
            datDevilFormat.tbl[id].race = 26;
            datDevilFormat.tbl[id].level = 27;
            datDevilFormat.tbl[id].aisyoid = (short)id;
            datDevilFormat.tbl[id].param = new sbyte[] { 14, 0, 8, 11, 12, 9 };
            datDevilFormat.tbl[id].keisyotype = 6;
            datDevilFormat.tbl[id].keisyoform = 2457;

            datDevilName.txt[id] = "タム・リン";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 3, 0, 1, 2, 2, 1 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 103, TargetLevel = 0, Type = 1 }; // Brutal Slash
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 182, TargetLevel = 0, Type = 1 }; // Shock
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 305, TargetLevel = 0, Type = 1 }; // Counter
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 64, TargetLevel = 28, Type = 1 }; // Tarukaja
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 30, TargetLevel = 29, Type = 1 }; // Mahama
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 205, TargetLevel = 30, Type = 1 }; // Taunt
            tblSkill.fclSkillTbl[id].Event[6] = new fclSkillParam_t { Param = 315, TargetLevel = 31, Type = 1 }; // Anti-Ice
            tblSkill.fclSkillTbl[id].Event[7] = new fclSkillParam_t { Param = 102, TargetLevel = 32, Type = 1 }; // Blight

            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 2147483778; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1200;
            datDevilFormat.tbl[id].maxhp = 1200;
            datDevilFormat.tbl[id].mp = 200;
            datDevilFormat.tbl[id].maxmp = 200;

            datDevilFormat.tbl[id].dropexp = 400;
            datDevilFormat.tbl[id].dropmakka = 2000;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 103; // Brutal Slash
            datDevilFormat.tbl[id].skill[1] = 182; // Shock
            datDevilFormat.tbl[id].skill[2] = 30; // Mahama
            datDevilFormat.tbl[id].skill[3] = 64; // Tarukaja
            datDevilFormat.tbl[id].skill[4] = 205; // Taunt
            datDevilFormat.tbl[id].skill[5] = 219; // Rage
            datDevilFormat.tbl[id].skill[6] = 305; // Counter
            datDevilFormat.tbl[id].skill[7] = 366; // Abyssal Mask
            

            mdlFileDefTable.devilModelFileTable[id].texFile = "";
            mdlFileDefTable.devilModelFileTable[id].modelFile = "d0xe0.PB";
            mdlFileDefTable.devilModelFileTable[id].motionFile = "";
            mdlFileDefTable.devilModelFileTable[id].akey = "dvl0xe0";
            mdlFileDefTable.devilModelFileTable[id].fname = "devil_0xe0";

            mdlFileDefTable.devilOnModelFileTable[id].texFile = "";
            mdlFileDefTable.devilOnModelFileTable[id].modelFile = "devil/on/0xe0_on.PB";
            mdlFileDefTable.devilOnModelFileTable[id].motionFile = "";
            mdlFileDefTable.devilOnModelFileTable[id].akey = "";
            mdlFileDefTable.devilOnModelFileTable[id].fname = "";

            mdlFileDefTable.devilModelIndex[id].major = 6;
            mdlFileDefTable.devilModelIndex[id].minor = 224;
            mdlFileDefTable.devilModelIndex[id].scale = 4096;
            mdlFileDefTable.devilModelIndex[id].radius = 1000;

            datDevilVisual07.tbl_7_0E0_0FF[0] = CopyDevilVisual(datDevilVisual04.tbl_4_080_09F[19]);
            datDevilVisual07.tbl_7_0E0_0FF[0].formscale = 1f;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[147];
        }

        private static void Doppelganger(ushort id)
        {
            datDevilFormat.tbl[id].flag = 128;
            datDevilFormat.tbl[id].race = 23;
            datDevilFormat.tbl[id].level = 60;
            datDevilFormat.tbl[id].aisyoid = (short)id;
            datDevilFormat.tbl[id].param = new sbyte[] { 17, 0, 17, 17, 17, 17 };
            datDevilFormat.tbl[id].keisyotype = 6;
            datDevilFormat.tbl[id].keisyoform = 2523;

            datDevilName.txt[id] = "ドッペルゲンガー";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 2, 0, 2, 2, 2, 2 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 69, TargetLevel = 0, Type = 1 }; // Makarakarn
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 63, TargetLevel = 0, Type = 1 }; // Tentarafoo
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 196, TargetLevel = 0, Type = 1 }; // Hell Gaze
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 345, TargetLevel = 61, Type = 1 }; // Endure
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 68, TargetLevel = 62, Type = 1 }; // Tetraja
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 366, TargetLevel = 63, Type = 1 }; // Abyssal Mask
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 26, TargetLevel = 64, Type = 1 }; // Megidola

            // Affinities
            datAisyo.tbl[id][0] = 131072; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 2147483778; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1300;
            datDevilFormat.tbl[id].maxhp = 1300;
            datDevilFormat.tbl[id].mp = 308;
            datDevilFormat.tbl[id].maxmp = 308;

            datDevilFormat.tbl[id].dropexp = 501;
            datDevilFormat.tbl[id].dropmakka = 512;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 69; // Makarakarn
            datDevilFormat.tbl[id].skill[1] = 63; // Tentarafoo
            datDevilFormat.tbl[id].skill[2] = 196; // Hell Gaze
            datDevilFormat.tbl[id].skill[3] = 219; // Rage
            datDevilFormat.tbl[id].skill[4] = 345; // Endure
            datDevilFormat.tbl[id].skill[5] = 366; // Abyssal Mask


            mdlFileDefTable.devilModelFileTable[id].texFile = "";
            mdlFileDefTable.devilModelFileTable[id].modelFile = "d0xe1.PB";
            mdlFileDefTable.devilModelFileTable[id].motionFile = "";
            mdlFileDefTable.devilModelFileTable[id].akey = "dvl0xe1";
            mdlFileDefTable.devilModelFileTable[id].fname = "devil_0xe1";

            mdlFileDefTable.devilOnModelFileTable[id].texFile = "";
            mdlFileDefTable.devilOnModelFileTable[id].modelFile = "devil/on/0xe1_on.PB";
            mdlFileDefTable.devilOnModelFileTable[id].motionFile = "";
            mdlFileDefTable.devilOnModelFileTable[id].akey = "";
            mdlFileDefTable.devilOnModelFileTable[id].fname = "";

            mdlFileDefTable.devilModelIndex[id].major = 6;
            mdlFileDefTable.devilModelIndex[id].minor = 225;
            mdlFileDefTable.devilModelIndex[id].scale = 4096;
            mdlFileDefTable.devilModelIndex[id].radius = 1000;

            datDevilVisual07.tbl_7_0E0_0FF[1] = CopyDevilVisual(datHuman.datHumanVisual[0]);
            datDevilVisual07.tbl_7_0E0_0FF[1].formscale = 1f;
        }

        private static void Nightmare(ushort id)
        {
            datDevilFormat.tbl[id].flag = 128;
            datDevilFormat.tbl[id].race = 22;
            datDevilFormat.tbl[id].level = 36;
            datDevilFormat.tbl[id].aisyoid = (short)id;
            datDevilFormat.tbl[id].param = new sbyte[] { 9, 0, 16, 9, 12, 10 };
            datDevilFormat.tbl[id].keisyotype = 2;
            datDevilFormat.tbl[id].keisyoform = 2235;

            datDevilName.txt[id] = "ナイトメア";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 1, 0, 3, 1, 2, 1 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 32, TargetLevel = 0, Type = 1 }; // Mudo
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 210, TargetLevel = 0, Type = 1 }; // Dormina
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 212, TargetLevel = 0, Type = 1 }; // Eternal Rest
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 60, TargetLevel = 37, Type = 1 }; // Lullaby
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 53, TargetLevel = 38, Type = 1 }; // Sukunda
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 74, TargetLevel = 39, Type = 1 }; // Riberama
            tblSkill.fclSkillTbl[id].Event[6] = new fclSkillParam_t { Param = 192, TargetLevel = 40, Type = 1 }; // Life Drain
            tblSkill.fclSkillTbl[id].Event[7] = new fclSkillParam_t { Param = 21, TargetLevel = 41, Type = 1 }; // Zandyne

            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 420;
            datDevilFormat.tbl[id].maxhp = 420;
            datDevilFormat.tbl[id].mp = 208;
            datDevilFormat.tbl[id].maxmp = 208;

            datDevilFormat.tbl[id].dropexp = 202;
            datDevilFormat.tbl[id].dropmakka = 219;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 32; // Mudo
            datDevilFormat.tbl[id].skill[1] = 210; // Dormina
            datDevilFormat.tbl[id].skill[2] = 212; // Eternal Rest
            datDevilFormat.tbl[id].skill[3] = 60; // Lullaby
            datDevilFormat.tbl[id].skill[4] = 53; // Sukunda
            datDevilFormat.tbl[id].skill[5] = 192; // Life Drain
            datDevilFormat.tbl[id].skill[6] = 21; // Zandyne

            // AI
            datDevilAI.divTbls[1][98].scriptid = 51;
            datDevilAI.divTbls[1][98].ailevel = 0;
            datDevilAI.divTbls[1][98].deadscriptid = 0;
            datDevilAI.divTbls[1][98].deadeventno = 0;

            datDevilAI.divTbls[1][98].aichk[0].check[0] = 1507328;
            datDevilAI.divTbls[1][98].aichk[0].check[1] = 0;
            datDevilAI.divTbls[1][98].aichk[0].table = 0;

            datDevilAI.divTbls[1][98].aichk[1].check[0] = 589828;
            datDevilAI.divTbls[1][98].aichk[1].check[1] = 0;
            datDevilAI.divTbls[1][98].aichk[1].table = 2;

            datDevilAI.divTbls[1][98].aichk[2].check[0] = 0;
            datDevilAI.divTbls[1][98].aichk[2].check[1] = 0;
            datDevilAI.divTbls[1][98].aichk[2].table = 1;

            datDevilAI.divTbls[1][98].aitable[0][0].skill = 60;
            datDevilAI.divTbls[1][98].aitable[0][0].ritu = 35;
            datDevilAI.divTbls[1][98].aitable[0][1].skill = 210;
            datDevilAI.divTbls[1][98].aitable[0][1].ritu = 35;
            datDevilAI.divTbls[1][98].aitable[0][2].skill = 32;
            datDevilAI.divTbls[1][98].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[1][98].aitable[0][3].skill = 21;
            datDevilAI.divTbls[1][98].aitable[0][3].ritu = 10;

            datDevilAI.divTbls[1][98].aitable[1][0].skill = 32768;
            datDevilAI.divTbls[1][98].aitable[1][0].ritu = 25;
            datDevilAI.divTbls[1][98].aitable[1][1].skill = 60;
            datDevilAI.divTbls[1][98].aitable[1][1].ritu = 20;
            datDevilAI.divTbls[1][98].aitable[1][2].skill = 210;
            datDevilAI.divTbls[1][98].aitable[1][2].ritu = 20;
            datDevilAI.divTbls[1][98].aitable[1][3].skill = 32;
            datDevilAI.divTbls[1][98].aitable[1][3].ritu = 25;
            datDevilAI.divTbls[1][98].aitable[1][4].skill = 21;
            datDevilAI.divTbls[1][98].aitable[1][4].ritu = 10;

            datDevilAI.divTbls[1][98].aitable[2][0].skill = 212;
            datDevilAI.divTbls[1][98].aitable[2][0].ritu = 40;
            datDevilAI.divTbls[1][98].aitable[2][1].skill = 32;
            datDevilAI.divTbls[1][98].aitable[2][1].ritu = 40;
            datDevilAI.divTbls[1][98].aitable[2][2].skill = 21;
            datDevilAI.divTbls[1][98].aitable[2][2].ritu = 20;


            mdlFileDefTable.devilModelFileTable[id].texFile = "";
            mdlFileDefTable.devilModelFileTable[id].modelFile = "d0xe2.PB";
            mdlFileDefTable.devilModelFileTable[id].motionFile = "";
            mdlFileDefTable.devilModelFileTable[id].akey = "dvl0xe2";
            mdlFileDefTable.devilModelFileTable[id].fname = "devil_0xe2";

            mdlFileDefTable.devilOnModelFileTable[id].texFile = "";
            mdlFileDefTable.devilOnModelFileTable[id].modelFile = "devil/on/0xe2_on.PB";
            mdlFileDefTable.devilOnModelFileTable[id].motionFile = "";
            mdlFileDefTable.devilOnModelFileTable[id].akey = "";
            mdlFileDefTable.devilOnModelFileTable[id].fname = "";

            mdlFileDefTable.devilModelIndex[id].major = 6;
            mdlFileDefTable.devilModelIndex[id].minor = 226;
            mdlFileDefTable.devilModelIndex[id].scale = 4096;
            mdlFileDefTable.devilModelIndex[id].radius = 1000;

            datDevilVisual07.tbl_7_0E0_0FF[2] = CopyDevilVisual(datDevilVisual01.tbl_1_020_03F[25]);
            datDevilVisual07.tbl_7_0E0_0FF[2].formscale = 1f;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[57];
        }

        private static void Gdon(ushort id)
        {
            datDevilFormat.tbl[id].flag = 128;
            datDevilFormat.tbl[id].race = 14;
            datDevilFormat.tbl[id].level = 40;
            datDevilFormat.tbl[id].aisyoid = (short)id;
            datDevilFormat.tbl[id].param = new sbyte[] { 19, 0, 9, 13, 12, 11 };
            datDevilFormat.tbl[id].keisyotype = 3;
            datDevilFormat.tbl[id].keisyoform = 2299;

            datDevilName.txt[id] = "ドゥン";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 3, 0, 1, 2, 1, 1 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 5, TargetLevel = 0, Type = 1 }; // Maragion
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 121, TargetLevel = 0, Type = 1 }; // Stun Bite
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 290, TargetLevel = 0, Type = 1 }; // Life Bonus
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 300, TargetLevel = 41, Type = 1 }; // Bright Might
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 3, TargetLevel = 42, Type = 1 }; // Agidyne
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 54, TargetLevel = 43, Type = 1 }; // Rakunda
            tblSkill.fclSkillTbl[id].Event[6] = new fclSkillParam_t { Param = 308, TargetLevel = 44, Type = 1 }; // Double Attack

            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 262144; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 2147483778; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 420;
            datDevilFormat.tbl[id].maxhp = 420;
            datDevilFormat.tbl[id].mp = 208;
            datDevilFormat.tbl[id].maxmp = 208;

            datDevilFormat.tbl[id].dropexp = 241;
            datDevilFormat.tbl[id].dropmakka = 258;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 5; // Maragion
            datDevilFormat.tbl[id].skill[1] = 121; // Stun Bite
            datDevilFormat.tbl[id].skill[2] = 3; // Agidyne
            datDevilFormat.tbl[id].skill[3] = 54; // Rakunda
            datDevilFormat.tbl[id].skill[4] = 300; // Bright Might
            datDevilFormat.tbl[id].skill[5] = 308; // Double Attack

            // AI
            datDevilAI.divTbls[1][99].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[1][99].aitable[0][0].ritu = 20;
            datDevilAI.divTbls[1][99].aitable[0][1].skill = 5;
            datDevilAI.divTbls[1][99].aitable[0][1].ritu = 35;
            datDevilAI.divTbls[1][99].aitable[0][2].skill = 3;
            datDevilAI.divTbls[1][99].aitable[0][2].ritu = 20;
            datDevilAI.divTbls[1][99].aitable[0][3].skill = 121;
            datDevilAI.divTbls[1][99].aitable[0][3].ritu = 20;
            datDevilAI.divTbls[1][99].aitable[0][4].skill = 54;
            datDevilAI.divTbls[1][99].aitable[0][4].ritu = 20;

            mdlFileDefTable.devilModelFileTable[id].texFile = "";
            mdlFileDefTable.devilModelFileTable[id].modelFile = "d0xe3.PB";
            mdlFileDefTable.devilModelFileTable[id].motionFile = "";
            mdlFileDefTable.devilModelFileTable[id].akey = "dvl0xe3";
            mdlFileDefTable.devilModelFileTable[id].fname = "devil_0xe3";

            mdlFileDefTable.devilOnModelFileTable[id].texFile = "";
            mdlFileDefTable.devilOnModelFileTable[id].modelFile = "devil/on/0xe3_on.PB";
            mdlFileDefTable.devilOnModelFileTable[id].motionFile = "";
            mdlFileDefTable.devilOnModelFileTable[id].akey = "";
            mdlFileDefTable.devilOnModelFileTable[id].fname = "";

            mdlFileDefTable.devilModelIndex[id].major = 6;
            mdlFileDefTable.devilModelIndex[id].minor = 227;
            mdlFileDefTable.devilModelIndex[id].scale = 4096;
            mdlFileDefTable.devilModelIndex[id].radius = 1000;

            datDevilVisual07.tbl_7_0E0_0FF[3] = CopyDevilVisual(datDevilVisual00.tbl_0_000_01F[30]);
            datDevilVisual07.tbl_7_0E0_0FF[3].formscale = 1f;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[30];
        }

        private static void DevilDante(ushort id)
        {
            datDevilFormat.tbl[id].flag = 34;
            datDevilFormat.tbl[id].race = 39;
            datDevilFormat.tbl[id].level = 70;
            datDevilFormat.tbl[id].aisyoid = (short)id;
            datDevilFormat.tbl[id].param = new sbyte[] { 18, 0, 14, 20, 18, 14 };
            datDevilFormat.tbl[id].keisyotype = 1;
            datDevilFormat.tbl[id].keisyoform = 2329;

            datDevilName.txt[id] = "ダンテ";

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
            datAisyo.tbl[id][11] = 100; // Self-Destruct

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 7500;
            datDevilFormat.tbl[id].hp = 3000;
            datDevilFormat.tbl[id].maxmp = 4000;
            datDevilFormat.tbl[id].mp = 4000;
            datDevilFormat.tbl[id].level = 60;
            datDevilFormat.tbl[id].flag = 50;

            datDevilFormat.tbl[id].dropexp = 10000;
            datDevilFormat.tbl[id].dropmakka = 10000;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 360; // Never Yield


            mdlFileDefTable.devilModelFileTable[id].texFile = "";
            mdlFileDefTable.devilModelFileTable[id].modelFile = "d0xfcd.PB";
            mdlFileDefTable.devilModelFileTable[id].motionFile = "";
            mdlFileDefTable.devilModelFileTable[id].akey = "dvl0xfcd";
            mdlFileDefTable.devilModelFileTable[id].fname = "devil_0xfcd";

            mdlFileDefTable.devilOnModelFileTable[id].texFile = "";
            mdlFileDefTable.devilOnModelFileTable[id].modelFile = "devil/on/0xfcd_on.PB";
            mdlFileDefTable.devilOnModelFileTable[id].motionFile = "";
            mdlFileDefTable.devilOnModelFileTable[id].akey = "";
            mdlFileDefTable.devilOnModelFileTable[id].fname = "";

            mdlFileDefTable.devilModelIndex[id].major = 6;
            mdlFileDefTable.devilModelIndex[id].minor = 252;
            mdlFileDefTable.devilModelIndex[id].scale = 4096;
            mdlFileDefTable.devilModelIndex[id].radius = 1000;

            datDevilVisual07.tbl_7_0E0_0FF[28] = CopyDevilVisual(datDevilVisual.dante[0]);
            datDevilVisual07.tbl_7_0E0_0FF[28].formscale = 1f;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[133];
        }

        private static void Gamete(ushort id)
        {
            datDevilFormat.tbl[id].flag = 34;
            datDevilFormat.tbl[id].race = 23;
            datDevilFormat.tbl[id].level = 36;
            datDevilFormat.tbl[id].aisyoid = (short)id;
            datDevilFormat.tbl[id].param = new sbyte[] { 14, 0, 10, 18, 8, 8 };
            datDevilFormat.tbl[id].keisyotype = 10;
            datDevilFormat.tbl[id].keisyoform = 187;

            datDevilName.txt[id] = "はいぐうし";

            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 660;
            datDevilFormat.tbl[id].maxhp = 660;
            datDevilFormat.tbl[id].mp = 184;
            datDevilFormat.tbl[id].maxmp = 184;

            datDevilFormat.tbl[id].dropexp = 0;
            datDevilFormat.tbl[id].dropmakka = 0;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 54; // Rakunda
            datDevilFormat.tbl[id].skill[1] = 57; // Dekaja
            datDevilFormat.tbl[id].skill[2] = 119; // Charm Bite
            datDevilFormat.tbl[id].skill[2] = 62; // Marin Karin
            datDevilFormat.tbl[id].skill[2] = 56; // Makajamon


            mdlFileDefTable.devilModelFileTable[id].texFile = "";
            mdlFileDefTable.devilModelFileTable[id].modelFile = "d0xfd.PB";
            mdlFileDefTable.devilModelFileTable[id].motionFile = "";
            mdlFileDefTable.devilModelFileTable[id].akey = "dvl0xfd";
            mdlFileDefTable.devilModelFileTable[id].fname = "devil_0xfd";

            mdlFileDefTable.devilOnModelFileTable[id].texFile = "";
            mdlFileDefTable.devilOnModelFileTable[id].modelFile = "devil/on/0xfd_on.PB";
            mdlFileDefTable.devilOnModelFileTable[id].motionFile = "";
            mdlFileDefTable.devilOnModelFileTable[id].akey = "";
            mdlFileDefTable.devilOnModelFileTable[id].fname = "";

            mdlFileDefTable.devilModelIndex[id].major = 6;
            mdlFileDefTable.devilModelIndex[id].minor = 253;
            mdlFileDefTable.devilModelIndex[id].scale = 4096;
            mdlFileDefTable.devilModelIndex[id].radius = 1000;

            datDevilVisual07.tbl_7_0E0_0FF[29] = CopyDevilVisual(datDevilVisual04.tbl_4_080_09F[5]);
            datDevilVisual07.tbl_7_0E0_0FF[29].formscale = 1f;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[133];
        }

        // 2148532374 = Weak but status-immune

        private static void BossForneus(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 262144; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
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

        private static void ForcedIncubus(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 420;
            datDevilFormat.tbl[id].maxhp = 420;
            datDevilFormat.tbl[id].mp = 156;
            datDevilFormat.tbl[id].maxmp = 156;

            datDevilFormat.tbl[id].dropexp = 300;
            datDevilFormat.tbl[id].dropitem[0] = 104;
            datDevilFormat.tbl[id].droppoint[0] = 100;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[3] = 125; // Stun Claw
            datDevilFormat.tbl[id].skill[4] = 461; // Storm Gale
            datDevilFormat.tbl[id].skill[5] = 23; // Mazanma

            // AI
            datDevilAI.divTbls[2][4].aitable[0][0].skill = 23;
            datDevilAI.divTbls[2][4].aitable[0][0].ritu = 100;
            datDevilAI.divTbls[2][4].aitable[0][1].skill = 0;
            datDevilAI.divTbls[2][4].aitable[0][1].ritu = 0;
            datDevilAI.divTbls[2][4].aitable[0][2].skill = 0;
            datDevilAI.divTbls[2][4].aitable[0][2].ritu = 0;

            datDevilAI.divTbls[2][4].aitable[1][0].skill = 23;
            datDevilAI.divTbls[2][4].aitable[1][0].ritu = 100;
            datDevilAI.divTbls[2][4].aitable[1][1].skill = 0;
            datDevilAI.divTbls[2][4].aitable[1][1].ritu = 0;
            datDevilAI.divTbls[2][4].aitable[1][2].skill = 0;
            datDevilAI.divTbls[2][4].aitable[1][2].ritu = 0;
            datDevilAI.divTbls[2][4].aitable[1][3].skill = 0;
            datDevilAI.divTbls[2][4].aitable[1][3].ritu = 0;

            datDevilAI.divTbls[2][4].aitable[2][0].skill = 23;
            datDevilAI.divTbls[2][4].aitable[2][0].ritu = 100;
            datDevilAI.divTbls[2][4].aitable[2][1].skill = 0;
            datDevilAI.divTbls[2][4].aitable[2][1].ritu = 0;
            datDevilAI.divTbls[2][4].aitable[2][2].skill = 0;
            datDevilAI.divTbls[2][4].aitable[2][2].ritu = 0;

            //datDevilAI.divTbls[2][4].aitable[0][0].skill = 32768;
            //datDevilAI.divTbls[2][4].aitable[0][0].ritu = 20;
            //datDevilAI.divTbls[2][4].aitable[0][1].skill = 214;
            //datDevilAI.divTbls[2][4].aitable[0][1].ritu = 20;
            //datDevilAI.divTbls[2][4].aitable[0][2].skill = 125;
            //datDevilAI.divTbls[2][4].aitable[0][2].ritu = 60;

            //datDevilAI.divTbls[2][4].aitable[1][0].skill = 32768;
            //datDevilAI.divTbls[2][4].aitable[1][0].ritu = 20;
            //datDevilAI.divTbls[2][4].aitable[1][1].skill = 192;
            //datDevilAI.divTbls[2][4].aitable[1][1].ritu = 30;
            //datDevilAI.divTbls[2][4].aitable[1][2].skill = 199;
            //datDevilAI.divTbls[2][4].aitable[1][2].ritu = 30;
            //datDevilAI.divTbls[2][4].aitable[1][3].skill = 461;
            //datDevilAI.divTbls[2][4].aitable[1][3].ritu = 20;

            //datDevilAI.divTbls[2][4].aitable[2][0].skill = 32768;
            //datDevilAI.divTbls[2][4].aitable[2][0].ritu = 20;
            //datDevilAI.divTbls[2][4].aitable[2][1].skill = 214;
            //datDevilAI.divTbls[2][4].aitable[2][1].ritu = 40;
            //datDevilAI.divTbls[2][4].aitable[2][2].skill = 125;
            //datDevilAI.divTbls[2][4].aitable[2][2].ritu = 40;
        }

        private static void ForcedKoppaTengu(ushort id)
        {
            // Enemy Stats
            datDevilFormat.tbl[id].hp = 312;
            datDevilFormat.tbl[id].maxhp = 312;
            datDevilFormat.tbl[id].mp = 116;
            datDevilFormat.tbl[id].maxmp = 116;

            datDevilFormat.tbl[id].dropexp = 0;
            datDevilFormat.tbl[id].dropitem[0] = 0;
            datDevilFormat.tbl[id].droppoint[0] = 0;

            // Enemy Skills
            datDevilFormat.tbl[id].skill[1] = 461; // Storm Gale

            // AI
            datDevilAI.divTbls[2][5].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[2][5].aitable[0][0].ritu = 40;
            datDevilAI.divTbls[2][5].aitable[0][1].skill = 64;
            datDevilAI.divTbls[2][5].aitable[0][1].ritu = 60;

            datDevilAI.divTbls[2][5].aitable[1][0].skill = 461;
            datDevilAI.divTbls[2][5].aitable[1][0].ritu = 50;
            datDevilAI.divTbls[2][5].aitable[1][1].skill = 59;
            datDevilAI.divTbls[2][5].aitable[1][1].ritu = 25;
            datDevilAI.divTbls[2][5].aitable[1][2].skill = 20;
            datDevilAI.divTbls[2][5].aitable[1][2].ritu = 25;

            datDevilAI.divTbls[2][5].aitable[2][0].skill = 461;
            datDevilAI.divTbls[2][5].aitable[2][0].ritu = 20;
            datDevilAI.divTbls[2][5].aitable[2][1].skill = 59;
            datDevilAI.divTbls[2][5].aitable[2][1].ritu = 20;
            datDevilAI.divTbls[2][5].aitable[2][2].skill = 20;
            datDevilAI.divTbls[2][5].aitable[2][2].ritu = 50;
            datDevilAI.divTbls[2][5].aitable[2][3].skill = 116;
            datDevilAI.divTbls[2][5].aitable[2][3].ritu = 10;
            datDevilAI.divTbls[2][5].aitable[2][4].skill = 0;
            datDevilAI.divTbls[2][5].aitable[2][4].ritu = 0;
        }

        private static void ForcedKaiwan1(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1200;
            datDevilFormat.tbl[id].maxhp = 1200;

            datDevilFormat.tbl[id].dropexp = 400;

            // AI
            datDevilAI.divTbls[2][6].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[2][6].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[2][6].aitable[0][1].skill = 446;
            datDevilAI.divTbls[2][6].aitable[0][1].ritu = 35;
            datDevilAI.divTbls[2][6].aitable[0][2].skill = 199;
            datDevilAI.divTbls[2][6].aitable[0][2].ritu = 35;

            datDevilAI.divTbls[2][6].aitable[1][0].skill = 190;
            datDevilAI.divTbls[2][6].aitable[1][0].ritu = 45;
            datDevilAI.divTbls[2][6].aitable[1][1].skill = 447;
            datDevilAI.divTbls[2][6].aitable[1][1].ritu = 45;
            datDevilAI.divTbls[2][6].aitable[1][2].skill = 199;
            datDevilAI.divTbls[2][6].aitable[1][2].ritu = 10;
        }

        private static void BossOse(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 6000;
            datDevilFormat.tbl[id].maxhp = 6000;
            datDevilFormat.tbl[id].level = 45;
            datDevilFormat.tbl[id].flag = 547;

            datDevilFormat.tbl[id].dropexp = 1800;
        }

        private static void BossKinKi(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 10; // Phys
            datAisyo.tbl[id][1] = 130; // Fire
            datAisyo.tbl[id][2] = 130; // Ice
            datAisyo.tbl[id][3] = 130; // Elec
            datAisyo.tbl[id][4] = 130; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 2147483778; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 5400;
            datDevilFormat.tbl[id].hp = 5400;
            datDevilFormat.tbl[id].level = 48;
            datDevilFormat.tbl[id].param[0] = 24;
            datDevilFormat.tbl[id].param[2] = 16;
            datDevilFormat.tbl[id].param[3] = 20;
            datDevilFormat.tbl[id].param[4] = 8;
            datDevilFormat.tbl[id].param[5] = 8;

            datDevilFormat.tbl[id].dropexp = 1800;
        }

        private static void BossSuiKi(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 65536; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 6000;
            datDevilFormat.tbl[id].hp = 6000;
            datDevilFormat.tbl[id].level = 48;
            datDevilFormat.tbl[id].param[0] = 20;
            datDevilFormat.tbl[id].param[2] = 20;
            datDevilFormat.tbl[id].param[3] = 10;
            datDevilFormat.tbl[id].param[4] = 10;
            datDevilFormat.tbl[id].param[5] = 10;

            datDevilFormat.tbl[id].dropexp = 1800;
        }

        private static void BossFuuKi(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 6000;
            datDevilFormat.tbl[id].hp = 6000;
            datDevilFormat.tbl[id].level = 48;
            datDevilFormat.tbl[id].param[0] = 20;
            datDevilFormat.tbl[id].param[2] = 20;
            datDevilFormat.tbl[id].param[3] = 10;
            datDevilFormat.tbl[id].param[4] = 10;
            datDevilFormat.tbl[id].param[5] = 10;

            datDevilFormat.tbl[id].dropexp = 1800;
        }

        private static void BossOngyoKi(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 65536; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 6000;
            datDevilFormat.tbl[id].hp = 6000;
            datDevilFormat.tbl[id].level = 54;
            datDevilFormat.tbl[id].param[0] = 30;
            datDevilFormat.tbl[id].param[2] = 24;
            datDevilFormat.tbl[id].param[3] = 10;
            datDevilFormat.tbl[id].param[4] = 10;
            datDevilFormat.tbl[id].param[5] = 20;

            datDevilFormat.tbl[id].dropexp = 5400;
        }

        private static void BossClotho1(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 4000;
            datDevilFormat.tbl[id].hp = 4000;
            datDevilFormat.tbl[id].level = 58;
            datDevilFormat.tbl[id].flag = 803;
            datDevilFormat.tbl[id].param[0] = 30;
            datDevilFormat.tbl[id].param[2] = 24;
            datDevilFormat.tbl[id].param[3] = 30;
            datDevilFormat.tbl[id].param[4] = 16;
            datDevilFormat.tbl[id].param[5] = 24;
        }

        private static void BossLachesis1(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 304; // Attack All

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 4000;
            datDevilFormat.tbl[id].hp = 4000;
            datDevilFormat.tbl[id].level = 63;
            datDevilFormat.tbl[id].flag = 803;
            datDevilFormat.tbl[id].param[0] = 30;
            datDevilFormat.tbl[id].param[2] = 24;
            datDevilFormat.tbl[id].param[3] = 30;
            datDevilFormat.tbl[id].param[4] = 16;
            datDevilFormat.tbl[id].param[5] = 24;
        }

        private static void BossAtropos1(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 4000;
            datDevilFormat.tbl[id].hp = 4000;
            datDevilFormat.tbl[id].level = 67;
            datDevilFormat.tbl[id].flag = 803;
            datDevilFormat.tbl[id].param[0] = 30;
            datDevilFormat.tbl[id].param[2] = 24;
            datDevilFormat.tbl[id].param[3] = 30;
            datDevilFormat.tbl[id].param[4] = 16;
            datDevilFormat.tbl[id].param[5] = 24;
        }

        private static void BossClotho2(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 4000;
            datDevilFormat.tbl[id].hp = 4000;
            datDevilFormat.tbl[id].level = 58;
            datDevilFormat.tbl[id].flag = 547;
            datDevilFormat.tbl[id].param[0] = 30;
            datDevilFormat.tbl[id].param[2] = 20;
            datDevilFormat.tbl[id].param[3] = 30;
            datDevilFormat.tbl[id].param[4] = 14;
            datDevilFormat.tbl[id].param[5] = 20;

            datDevilFormat.tbl[id].dropexp = 2500;
            datDevilFormat.tbl[id].dropmakka = 3000;
        }

        private static void BossLachesis2(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Skills
            datDevilFormat.tbl[id].skill[0] = 304; // Attack All

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 4000;
            datDevilFormat.tbl[id].hp = 4000;
            datDevilFormat.tbl[id].level = 63;
            datDevilFormat.tbl[id].flag = 547;
            datDevilFormat.tbl[id].param[0] = 30;
            datDevilFormat.tbl[id].param[2] = 20;
            datDevilFormat.tbl[id].param[3] = 30;
            datDevilFormat.tbl[id].param[4] = 13;
            datDevilFormat.tbl[id].param[5] = 20;

            datDevilFormat.tbl[id].dropexp = 2500;
            datDevilFormat.tbl[id].dropmakka = 3000;
        }

        private static void BossAtropos2(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 4000;
            datDevilFormat.tbl[id].hp = 4000;
            datDevilFormat.tbl[id].level = 67;
            datDevilFormat.tbl[id].flag = 547;
            datDevilFormat.tbl[id].param[0] = 30;
            datDevilFormat.tbl[id].param[2] = 20;
            datDevilFormat.tbl[id].param[3] = 30;
            datDevilFormat.tbl[id].param[4] = 12;
            datDevilFormat.tbl[id].param[5] = 20;

            datDevilFormat.tbl[id].dropexp = 2500;
            datDevilFormat.tbl[id].dropmakka = 3000;
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

        private static void BossMizuchi(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 65536; // Ice
            datAisyo.tbl[id][3] = 262144; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 6000;
            datDevilFormat.tbl[id].hp = 6000;
            datDevilFormat.tbl[id].level = 40;
            datDevilFormat.tbl[id].param[0] = 20;
            datDevilFormat.tbl[id].param[2] = 25;
            datDevilFormat.tbl[id].param[3] = 10;
            datDevilFormat.tbl[id].param[4] = 10;
            datDevilFormat.tbl[id].param[5] = 10;

            datDevilFormat.tbl[id].dropexp = 1200;
        }

        private static void BossOrthrus(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 262144; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 50; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 1600;
            datDevilFormat.tbl[id].hp = 1600;
            datDevilFormat.tbl[id].level = 30;
            datDevilFormat.tbl[id].param[0] = 8;
            datDevilFormat.tbl[id].param[2] = 12;
            datDevilFormat.tbl[id].param[3] = 14;
            datDevilFormat.tbl[id].param[4] = 6;
            datDevilFormat.tbl[id].param[5] = 6;

            datDevilFormat.tbl[id].dropexp = 300;
        }

        private static void BossYaksini(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 65536; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 1800;
            datDevilFormat.tbl[id].hp = 1800;
            datDevilFormat.tbl[id].level = 32;
            datDevilFormat.tbl[id].param[0] = 8;
            datDevilFormat.tbl[id].param[2] = 16;
            datDevilFormat.tbl[id].param[3] = 18;
            datDevilFormat.tbl[id].param[4] = 8;
            datDevilFormat.tbl[id].param[5] = 8;

            datDevilFormat.tbl[id].dropexp = 400;
        }

        private static void BossThor1(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 262144; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 65536; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 2147483778; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 3000;
            datDevilFormat.tbl[id].hp = 3000;
            datDevilFormat.tbl[id].level = 36;
            datDevilFormat.tbl[id].param[0] = 10;
            datDevilFormat.tbl[id].param[2] = 20;
            datDevilFormat.tbl[id].param[3] = 20;
            datDevilFormat.tbl[id].param[4] = 10;
            datDevilFormat.tbl[id].param[5] = 10;
            datDevilFormat.tbl[id].flag = 547;

            datDevilFormat.tbl[id].dropexp = 800;
        }

        private static void BossEligor(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 1200;
            datDevilFormat.tbl[id].hp = 1200;
            datDevilFormat.tbl[id].param[0] = 14;
            datDevilFormat.tbl[id].param[2] = 9;
            datDevilFormat.tbl[id].param[3] = 14;
            datDevilFormat.tbl[id].param[4] = 10;
            datDevilFormat.tbl[id].param[5] = 10;

            datDevilFormat.tbl[id].dropexp = 450;
        }

        private static void ForcedKelpie(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 1000;
            datDevilFormat.tbl[id].hp = 1000;
            datDevilFormat.tbl[id].param[0] = 13;
            datDevilFormat.tbl[id].param[2] = 13;
            datDevilFormat.tbl[id].param[3] = 9;
            datDevilFormat.tbl[id].param[4] = 8;
            datDevilFormat.tbl[id].param[5] = 7;

            datDevilFormat.tbl[id].dropexp = 200;
        }

        private static void BossBerith(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 262144; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 1800;
            datDevilFormat.tbl[id].hp = 1800;
            datDevilFormat.tbl[id].param[0] = 16;
            datDevilFormat.tbl[id].param[2] = 10;
            datDevilFormat.tbl[id].param[3] = 17;
            datDevilFormat.tbl[id].param[4] = 10;
            datDevilFormat.tbl[id].param[5] = 10;
        }

        private static void ForcedSuccubus(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 100; // Dark
            datAisyo.tbl[id][8] = 50; // Curse
            datAisyo.tbl[id][9] = 50; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 600;
            datDevilFormat.tbl[id].hp = 600;
            datDevilFormat.tbl[id].param[0] = 10;
            datDevilFormat.tbl[id].param[2] = 16;
            datDevilFormat.tbl[id].param[3] = 11;
            datDevilFormat.tbl[id].param[4] = 8;
            datDevilFormat.tbl[id].param[5] = 8;
        }

        private static void ForcedKaiwan2(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 50; // Fire
            datAisyo.tbl[id][2] = 50; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 50; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 65536; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1200;
            datDevilFormat.tbl[id].maxhp = 1200;

            datDevilFormat.tbl[id].dropexp = 400;

            // AI
            datDevilAI.divTbls[2][59].aitable[0][0].skill = 32768;
            datDevilAI.divTbls[2][59].aitable[0][0].ritu = 30;
            datDevilAI.divTbls[2][59].aitable[0][1].skill = 446;
            datDevilAI.divTbls[2][59].aitable[0][1].ritu = 35;
            datDevilAI.divTbls[2][59].aitable[0][2].skill = 199;
            datDevilAI.divTbls[2][59].aitable[0][2].ritu = 35;

            datDevilAI.divTbls[2][59].aitable[1][0].skill = 190;
            datDevilAI.divTbls[2][59].aitable[1][0].ritu = 45;
            datDevilAI.divTbls[2][59].aitable[1][1].skill = 447;
            datDevilAI.divTbls[2][59].aitable[1][1].ritu = 45;
            datDevilAI.divTbls[2][59].aitable[1][2].skill = 199;
            datDevilAI.divTbls[2][59].aitable[1][2].ritu = 10;
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
            datAisyo.tbl[id][2] = 2147483778; // Ice
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
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
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
            datAisyo.tbl[id][1] = 2147483778; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
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

        private static void BossMara(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 50; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 2147483778; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 50; // Light
            datAisyo.tbl[id][7] = 50; // Dark
            datAisyo.tbl[id][8] = 65536; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 65536; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 3000;
            datDevilFormat.tbl[id].hp = 1;
            datDevilFormat.tbl[id].level = 61;
            datDevilFormat.tbl[id].flag = 34;
            datDevilFormat.tbl[id].param[0] = 30;
            datDevilFormat.tbl[id].param[2] = 20;
            datDevilFormat.tbl[id].param[3] = 30;
            datDevilFormat.tbl[id].param[4] = 15;
            datDevilFormat.tbl[id].param[5] = 10;

            datDevilFormat.tbl[id].dropexp = 6000;
            datDevilFormat.tbl[id].dropmakka = 20000;

            // Display Skill
            datDevilFormat.tbl[id].skill[0] = 362;
            datDevilFormat.tbl[id].skill[1] = 357;
        }

        private static void BossDanteRaidou1(ushort id)
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
            datAisyo.tbl[id][11] = 100; // Self-Destruct

            datDevilFormat.tbl[id].maxhp = 2000;
            datDevilFormat.tbl[id].hp = 2000;
            datDevilFormat.tbl[id].level = 40;
            datDevilFormat.tbl[id].param[0] = 2;
            datDevilFormat.tbl[id].param[2] = 10;
            datDevilFormat.tbl[id].param[3] = 10;
            datDevilFormat.tbl[id].param[4] = 8;
            datDevilFormat.tbl[id].param[5] = 8;
            datDevilFormat.tbl[id].flag = 34;
        }

        private static void ChaseDanteRaidou(ushort id)
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
            datAisyo.tbl[id][11] = 100; // Self-Destruct

            datDevilFormat.tbl[id].maxhp = 7500;
            datDevilFormat.tbl[id].hp = 7500;
            datDevilFormat.tbl[id].level = 60;
            datDevilFormat.tbl[id].param[0] = 18;
            datDevilFormat.tbl[id].param[2] = 14;
            datDevilFormat.tbl[id].param[3] = 20;
            datDevilFormat.tbl[id].param[4] = 18;
            datDevilFormat.tbl[id].param[5] = 14;
            datDevilFormat.tbl[id].flag = 34;
        }

        private static void BossDanteRaidou2(ushort id)
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
            datAisyo.tbl[id][11] = 100; // Self-Destruct

            datDevilFormat.tbl[id].maxhp = 7500;
            datDevilFormat.tbl[id].hp = 7500;
            datDevilFormat.tbl[id].level = 60;
            datDevilFormat.tbl[id].param[0] = 18;
            datDevilFormat.tbl[id].param[2] = 14;
            datDevilFormat.tbl[id].param[3] = 20;
            datDevilFormat.tbl[id].param[4] = 18;
            datDevilFormat.tbl[id].param[5] = 14;
            datDevilFormat.tbl[id].flag = 34;

            // Display Skill
            datDevilFormat.tbl[id].skill[0] = 360;
        }

        private static void BossWhiteRider(ushort id)
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

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 6600;
            datDevilFormat.tbl[id].hp = 6600;
            datDevilFormat.tbl[id].param[2] = 13;
            datDevilFormat.tbl[id].param[4] = 13;
            datDevilFormat.tbl[id].flag = 34;

            datDevilFormat.tbl[id].dropexp = 6000;
            datDevilFormat.tbl[id].dropmakka = 5000;

            // Display Skill
            datDevilFormat.tbl[id].skill[0] = 366;
        }

        private static void BossRedRider(ushort id)
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

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 7200;
            datDevilFormat.tbl[id].hp = 7200;
            datDevilFormat.tbl[id].param[2] = 13;
            datDevilFormat.tbl[id].param[4] = 13;
            datDevilFormat.tbl[id].flag = 34;

            datDevilFormat.tbl[id].dropexp = 6200;
            datDevilFormat.tbl[id].dropmakka = 5000;

            // Display Skill
            datDevilFormat.tbl[id].skill[0] = 366;
        }

        private static void BossBlackRider(ushort id)
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

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 7800;
            datDevilFormat.tbl[id].hp = 7800;
            datDevilFormat.tbl[id].param[2] = 20;
            datDevilFormat.tbl[id].flag = 34;

            datDevilFormat.tbl[id].dropexp = 6400;
            datDevilFormat.tbl[id].dropmakka = 5000;

            // Display Skill
            datDevilFormat.tbl[id].skill[0] = 366;
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

        private static void BossHellBiker(ushort id)
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

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 5000;
            datDevilFormat.tbl[id].hp = 5000;
            datDevilFormat.tbl[id].param[0] = 12;
            datDevilFormat.tbl[id].param[4] = 12;
            datDevilFormat.tbl[id].param[5] = 10;
            datDevilFormat.tbl[id].flag = 34;

            // Display Skill
            datDevilFormat.tbl[id].skill[0] = 366;
        }

        private static void BossDaisoujou(ushort id)
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

            // Enemy Stats
            datDevilFormat.tbl[id].maxhp = 3500;
            datDevilFormat.tbl[id].hp = 3500;
            datDevilFormat.tbl[id].param[2] = 18;
            datDevilFormat.tbl[id].param[4] = 11;
            datDevilFormat.tbl[id].flag = 34;

            // Display Skill
            datDevilFormat.tbl[id].skill[0] = 366;
        }

        private static void BossVirtue(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 50; // Elec
            datAisyo.tbl[id][4] = 2147483778; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 2147483778; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 800;
            datDevilFormat.tbl[id].maxhp = 800;
            datDevilFormat.tbl[id].mp = 300;
            datDevilFormat.tbl[id].maxmp = 300;

            datDevilFormat.tbl[id].dropexp = 0;
            datDevilFormat.tbl[id].dropmakka = 0;

            // Display Skill
            datDevilFormat.tbl[id].skill[0] = 366;
        }

        private static void BossPower(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 131072; // Light
            datAisyo.tbl[id][7] = 2147483778; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 900;
            datDevilFormat.tbl[id].maxhp = 900;
            datDevilFormat.tbl[id].mp = 300;
            datDevilFormat.tbl[id].maxmp = 300;

            datDevilFormat.tbl[id].dropexp = 0;
            datDevilFormat.tbl[id].dropmakka = 0;

            // Display Skill
            datDevilFormat.tbl[id].skill[0] = 366;
        }

        private static void BossLegion(ushort id)
        {
            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 100; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 2147483778; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 2147483778; // Light
            datAisyo.tbl[id][7] = 131072; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 100; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 1000;
            datDevilFormat.tbl[id].maxhp = 1000;
            datDevilFormat.tbl[id].mp = 300;
            datDevilFormat.tbl[id].maxmp = 300;

            datDevilFormat.tbl[id].dropexp = 0;
            datDevilFormat.tbl[id].dropmakka = 0;

            // Display Skill
            datDevilFormat.tbl[id].skill[0] = 366;
        }

        private static void BossFlauros(int id)
        {
            datDevilFormat.tbl[id].flag = 547;
            datDevilFormat.tbl[id].race = 12;
            datDevilFormat.tbl[id].level = 50;
            datDevilFormat.tbl[id].aisyoid = (short)id;
            datDevilFormat.tbl[id].param = new sbyte[] { 30, 0, 16, 30, 18, 16 };
            datDevilFormat.tbl[id].keisyotype = 1;
            datDevilFormat.tbl[id].keisyoform = 2523;

            datDevilName.txt[id] = "フラロウス";

            // Affinities
            datAisyo.tbl[id][0] = 100; // Phys
            datAisyo.tbl[id][1] = 65536; // Fire
            datAisyo.tbl[id][2] = 100; // Ice
            datAisyo.tbl[id][3] = 100; // Elec
            datAisyo.tbl[id][4] = 100; // Force
            datAisyo.tbl[id][6] = 100; // Light
            datAisyo.tbl[id][7] = 131072; // Dark
            datAisyo.tbl[id][8] = 100; // Curse
            datAisyo.tbl[id][9] = 2147483778; // Nerve
            datAisyo.tbl[id][10] = 100; // Mind

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 10000;
            datDevilFormat.tbl[id].maxhp = 10000;
            datDevilFormat.tbl[id].mp = 10000;
            datDevilFormat.tbl[id].maxmp = 10000;

            datDevilFormat.tbl[id].dropexp = 4000;
            datDevilFormat.tbl[id].dropmakka = 10000;

            // Display Skill
            datDevilFormat.tbl[id].skill[0] = 64;
            datDevilFormat.tbl[id].skill[1] = 33;
            datDevilFormat.tbl[id].skill[2] = 108;
            datDevilFormat.tbl[id].skill[3] = 126;
            datDevilFormat.tbl[id].skill[4] = 435;
            datDevilFormat.tbl[id].skill[5] = 299;
            datDevilFormat.tbl[id].skill[6] = 306;
            datDevilFormat.tbl[id].skill[7] = 309;

            mdlFileDefTable.devilModelFileTable[id] = mdlFileDefTable.devilModelFileTable[69];
            mdlFileDefTable.devilOnModelFileTable[id] = mdlFileDefTable.devilOnModelFileTable[69];
            mdlFileDefTable.devilModelIndex[id] = mdlFileDefTable.devilModelIndex[69];
            mdlFileDefTable.devilOnModelIndex[id] = mdlFileDefTable.devilOnModelIndex[69];

            mdlFileDefTable.devilModelIndex[id].major = 6;
            mdlFileDefTable.devilModelIndex[id].minor = 69;
            mdlFileDefTable.devilModelIndex[id].scale = 4096;
            mdlFileDefTable.devilModelIndex[id].radius = 1000;

            datDevilVisual11.tbl_11_160_17F[10] = CopyDevilVisual(datDevilVisual02.tbl_2_040_05F[5]);
            datDevilVisual11.tbl_11_160_17F[10].formscale = 1.6f;

            datMotionSeTable.tbl[id] = 69;

            //datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[69];
        }

        private static void YHVH(ushort id)
        {
            datDevilFormat.tbl[id].flag = 563;
            datDevilFormat.tbl[id].race = 36;
            //datDevilFormat.tbl[id].level = 90;
            datDevilFormat.tbl[id].level = 1;
            datDevilFormat.tbl[id].aisyoid = (short)id;
            datDevilFormat.tbl[id].param = new sbyte[] { 40, 0, 40, 40, 40, 40 };
            //datDevilFormat.tbl[id].param = new sbyte[] { 1, 0, 1, 1, 1, 1 };
            datDevilFormat.tbl[id].keisyotype = 5;
            datDevilFormat.tbl[id].keisyoform = 411;

            datDevilAI.divTbls[1][126].scriptid = 133;
            datDevilAI.divTbls[1][126].deadscriptid = 40;

            datDevilName.txt[id] = "ヤハウェ";

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

            // Enemy Stats
            datDevilFormat.tbl[id].hp = 60000;
            //datDevilFormat.tbl[id].hp = 1;
            datDevilFormat.tbl[id].maxhp = 60000;
            datDevilFormat.tbl[id].mp = 60000;
            datDevilFormat.tbl[id].maxmp = 60000;

            datDevilFormat.tbl[id].dropexp = 0;
            datDevilFormat.tbl[id].dropmakka = 0;

            mdlFileDefTable.devilModelFileTable[id].texFile = "";
            mdlFileDefTable.devilModelFileTable[id].modelFile = "d0xfe.PB";
            mdlFileDefTable.devilModelFileTable[id].motionFile = "";
            mdlFileDefTable.devilModelFileTable[id].akey = "dvl0xfe";
            mdlFileDefTable.devilModelFileTable[id].fname = "devil_0xfe";

            mdlFileDefTable.devilOnModelFileTable[id].texFile = "";
            mdlFileDefTable.devilOnModelFileTable[id].modelFile = "devil/on/0xfe_on.PB";
            mdlFileDefTable.devilOnModelFileTable[id].motionFile = "";
            mdlFileDefTable.devilOnModelFileTable[id].akey = "";
            mdlFileDefTable.devilOnModelFileTable[id].fname = "";

            mdlFileDefTable.devilModelIndex[id].major = 6;
            mdlFileDefTable.devilModelIndex[id].minor = 254;
            mdlFileDefTable.devilModelIndex[id].scale = 4096;
            mdlFileDefTable.devilModelIndex[id].radius = 1000;

            datUnitVisual_t yhvhVisual = new datUnitVisual_t();
            yhvhVisual.center = new Vector4(0, 0, 0);
            yhvhVisual.formsize = 0;
            yhvhVisual.formheight = 500;
            yhvhVisual.formscale = 1.5f;
            yhvhVisual.oneshotr = 600;
            yhvhVisual.allshotr = 1000;
            yhvhVisual.modelsize = 1;
            yhvhVisual.shadowsize = 2;
            yhvhVisual.badframe = 8;
            yhvhVisual.autowait = 0;
            yhvhVisual.reserve1 = 0;
            yhvhVisual.reserve2 = 0;
            yhvhVisual.reserve3 = 0;
            yhvhVisual.motion = new datUnitMotion_s[] {
                new datUnitMotion_s{ motion_no= 0, movetype= 0, actframe= 40, se_no= -1, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 },
                new datUnitMotion_s{ motion_no= 1, movetype= 0, actframe= 40, se_no= 3, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 },
                new datUnitMotion_s{ motion_no= 0, movetype= 0, actframe= 60, se_no= 5, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 }, // Scorn
                new datUnitMotion_s{ motion_no= 9, movetype= 0, actframe= 33, se_no= 9, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 40 }, // Infinite Power
                new datUnitMotion_s{ motion_no= 5, movetype= 0, actframe= 37, se_no= 3, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 140, movey= 0, movez= 210, bframe= 0, hframe= 30 }, // Supernova
                new datUnitMotion_s{ motion_no= 8, movetype= 1, actframe= 38, se_no= 4, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 20 }, // Rampage
                new datUnitMotion_s{ motion_no= 10, movetype= 1, actframe= 30, se_no= 8, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 }, // Planned Chaos
                new datUnitMotion_s{ motion_no= 18, movetype= 1, actframe= 31, se_no= 11, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 }, // Mouth Of God
                new datUnitMotion_s{ motion_no= 3, movetype= 1, actframe= 37, se_no= 10, se_endtype= 0, se_endframe= -1, motionsp= 0.8f, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 25 }, // Crush
                new datUnitMotion_s{ motion_no= 9, movetype= 0, actframe= 33, se_no= 10, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 40 }, // Unending Curse
                new datUnitMotion_s{ motion_no= 9, movetype= 0, actframe= 33, se_no= 12, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 40 }, // Divine Harmony
                new datUnitMotion_s{ motion_no= 0, movetype= 0, actframe= 40, se_no= -1, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 },
                new datUnitMotion_s{ motion_no= 0, movetype= 0, actframe= 40, se_no= -1, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 },
                new datUnitMotion_s{ motion_no= 0, movetype= 0, actframe= 40, se_no= -1, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 },
                new datUnitMotion_s{ motion_no= 0, movetype= 0, actframe= 40, se_no= -1, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 },
                new datUnitMotion_s{ motion_no= 0, movetype= 0, actframe= 40, se_no= -1, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 },
                new datUnitMotion_s{ motion_no= 0, movetype= 0, actframe= 40, se_no= -1, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 },
                new datUnitMotion_s{ motion_no= 0, movetype= 0, actframe= 40, se_no= -1, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 },
                new datUnitMotion_s{ motion_no= 0, movetype= 0, actframe= 40, se_no= -1, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 },
                new datUnitMotion_s{ motion_no= 0, movetype= 0, actframe= 40, se_no= -1, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 },
                new datUnitMotion_s{ motion_no= 0, movetype= 0, actframe= 40, se_no= -1, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 },
                new datUnitMotion_s{ motion_no= 0, movetype= 0, actframe= 40, se_no= -1, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 },
                new datUnitMotion_s{ motion_no= 0, movetype= 0, actframe= 40, se_no= -1, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 },
                new datUnitMotion_s{ motion_no= 0, movetype= 0, actframe= 40, se_no= -1, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 },
                new datUnitMotion_s{ motion_no= 0, movetype= 0, actframe= 40, se_no= -1, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 },
                new datUnitMotion_s{ motion_no= 0, movetype= 0, actframe= 40, se_no= -1, se_endtype= 0, se_endframe= -1, motionsp= 1, atarisize= 100, movey= 0, movez= 0, bframe= 0, hframe= 10 }
            };
            datDevilVisual07.tbl_7_0E0_0FF[30] = yhvhVisual;
        }
    }
}