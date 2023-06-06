using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using UnityEngine;

[assembly: MelonInfo(typeof(FusableBossDemons.FusableBossDemons), "Fusable Boss Demons", "1.0.2", "Zephhyr")]
[assembly: MelonGame("", "smt3hd")]

namespace FusableBossDemons
{
    internal class FusableBossDemons : MelonMod
    {
        public override void OnInitializeMelon()
        {
            datDevilFormat.tbl[179] = OseHallel(datDevilFormat.tbl[179], 179);
            datDevilFormat.tbl[180] = FlaurosHallel(datDevilFormat.tbl[180], 180);
            datDevilFormat.tbl[181] = Urthona(datDevilFormat.tbl[181], 181);
            datDevilFormat.tbl[182] = Urizen(datDevilFormat.tbl[182], 182);
            datDevilFormat.tbl[183] = Luvah(datDevilFormat.tbl[183], 183);
            datDevilFormat.tbl[184] = Tharmus(datDevilFormat.tbl[184], 184);
            datDevilFormat.tbl[185] = Specter(datDevilFormat.tbl[185], 185);
            datDevilFormat.tbl[186] = Mara(datDevilFormat.tbl[186], 186);
            datDevilFormat.tbl[187] = Doppelganger(datDevilFormat.tbl[187], 187);
        }

        public override void OnLateUpdate()
        {
            if (cmpModel.cmpDevilObj != null)
            {
                var modelName = cmpModel.cmpDevilObj.name;
                switch (modelName)
                {
                    case "devil_0x121":
                        {
                            var oseHallelModel = cmpModel.cmpDevilObj;
                            oseHallelModel.transform.position = new Vector3(-0.08f, -1.48f, 0);
                            oseHallelModel.transform.eulerAngles = new Vector3(270f, 194f, 0);
                            break;
                        }
                    case "devil_0x122":
                        {
                            var flaurosHallelModel = cmpModel.cmpDevilObj;
                            flaurosHallelModel.transform.position = new Vector3(-0.08f, -1.28f, -0.04f);
                            flaurosHallelModel.transform.eulerAngles = new Vector3(0f, 196f, 0);
                            break;
                        }
                    case "devil_0x117":
                        {
                            var urthonaModel = cmpModel.cmpDevilObj;
                            urthonaModel.transform.position = new Vector3(0f, -1.0f, 0f);
                            urthonaModel.transform.eulerAngles = new Vector3(270f, 195f, 0);
                            urthonaModel.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                            break;
                        }
                    case "devil_0x118":
                        {
                            var urizenModel = cmpModel.cmpDevilObj;
                            urizenModel.transform.position = new Vector3(0f, -1.0f, 0f);
                            urizenModel.transform.eulerAngles = new Vector3(270f, 195f, 0);
                            urizenModel.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                            break;
                        }
                    case "devil_0x119":
                        {
                            var luvahModel = cmpModel.cmpDevilObj;
                            luvahModel.transform.position = new Vector3(0f, -1.0f, 0f);
                            luvahModel.transform.eulerAngles = new Vector3(270f, 195f, 0);
                            luvahModel.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                            break;
                        }
                    case "devil_0x11a":
                        {
                            var tharmusModel = cmpModel.cmpDevilObj;
                            tharmusModel.transform.position = new Vector3(0f, -1.0f, 0f);
                            tharmusModel.transform.eulerAngles = new Vector3(270f, 195f, 0);
                            tharmusModel.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                            break;
                        }
                    case "devil_0x141":
                        {
                            var maraModel = cmpModel.cmpDevilObj;
                            maraModel.transform.position = new Vector3(0f, -0.6f, 0f);
                            maraModel.transform.eulerAngles = new Vector3(270f, 195f, 0);
                            break;
                        }
                    case "devil_0x00":
                        {
                            if (cmpModel.gTargetMinorNo == 187)
                            {
                                var demiModel = cmpModel.cmpDevilObj;
                                demiModel.transform.position = new Vector3(-0.04f, -0.9f, -1.4f);
                                demiModel.transform.eulerAngles = new Vector3(0f, 180f, 0);
                            }
                            break;
                        }
                    default: break;
                }
            }
        }

        [HarmonyPatch(typeof(fclCombineCalcCore), "cmbChkIkenieExtPatternDev")]
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
            }
        }

        [HarmonyPatch(typeof(frFont), "frReplaceLocalizeText")]
        private class CompendiumProfilePatch
        {
            public static void Postfix(ref string message, ref frMsgInfo_t mi, ref List<int> index, ref string __result)
            {
                switch (message)
                {
                    case "<COLLECTIONBOOK_L0179>":
                        {
                            __result = "Another form of Ose, one of the 72 demons of the Goetia. His divine appearence reflects him as he was before joining Lucifer's rebellion against God, after which he became a fallen angel.";
                            break;
                        }
                    case "<COLLECTIONBOOK_L0180>":
                        {
                            __result = "Another form of Flauros, one of the 72 demons of the Goetia. His divine appearence reflects him as he was before joining Lucifer's rebellion against God, after which he became a fallen angel.";
                            break;
                        }
                    case "<COLLECTIONBOOK_L0181>":
                        {
                            __result = "One of the four Zoas created when Albion was divided fourfold. He represents inspiration, creativity and the north.";
                            break;
                        }
                    case "<COLLECTIONBOOK_L0182>":
                        {
                            __result = "One of the four Zoas created when Albion was divided fourfold. He represents conventional reason and law.";
                            break;
                        }
                    case "<COLLECTIONBOOK_L0183>":
                        {
                            __result = "One of the four Zoas created when Albion was divided fourfold. He represents love, passion and rebellious energy.";
                            break;
                        }
                    case "<COLLECTIONBOOK_L0184>":
                        {
                            __result = "One of the four Zoas created when Albion was divided fourfold. He represents time, sensation and free speech.";
                            break;
                        }
                    case "<COLLECTIONBOOK_L0185>":
                        {
                            __result = "A spirit of the dead in Western folklore. A specter's appearance is said to be horrifying beyond anything imaginable. Those to whom it appears are paralyzed with fear, but are very rarely harmed.";
                            break;
                        }
                    case "<COLLECTIONBOOK_L0186>":
                        {
                            __result = "A Buddhist demon that represents the fear of death. He sent his daughter to tempt Buddha during his meditations. Improper summoning has caused him to manifest with rather flaccid appearence and power.";
                            break;
                        }
                    case "<COLLECTIONBOOK_L0187>":
                        {
                            __result = "A phantom copy of a living being. Doppelgängers are a sign of bad luck. Often, others see your doppelgänger from afar, but it is said you may also see your own doppelgänger right before you die.";
                            break;
                        }
                    default: break;
                }
            }
        }

        [HarmonyPatch(typeof(Localize), "GetLocalizeText", new Type[] { typeof(string) })]
        private class LocalizeNamesPatch
        {
            public static bool Prefix(ref string ID, ref string __result)
            {
                switch (ID)
                {
                    case "<DEVIL_L0179>":
                        {
                            __result = "Ose Hallel";
                            return false;
                        }
                    case "<AISYO_L0179>":
                        {
                            __result = "Null: Light/Dark/Ailments • Str: Phys";
                            return false;
                        }
                    case "<DEVIL_L0180>":
                        {
                            __result = "Flauros Hallel";
                            return false;
                        }
                    case "<AISYO_L0180>":
                        {
                            __result = "Null: Light/Dark/Ailments • Str: Phys";
                            return false;
                        }
                    case "<DEVIL_L0181>":
                        {
                            __result = "Urthona";
                            return false;
                        }
                    case "<AISYO_L0181>":
                        {
                            __result = "Rpl: Elec • Weak: Force";
                            return false;
                        }
                    case "<DEVIL_L0182>":
                        {
                            __result = "Urizen";
                            return false;
                        }
                    case "<AISYO_L0182>":
                        {
                            __result = "Rpl: Fire • Weak: Ice";
                            return false;
                        }
                    case "<DEVIL_L0183>":
                        {
                            __result = "Luvah";
                            return false;
                        }
                    case "<AISYO_L0183>":
                        {
                            __result = "Rpl: Force • Weak: Elec";
                            return false;
                        }
                    case "<DEVIL_L0184>":
                        {
                            __result = "Tharmus";
                            return false;
                        }
                    case "<AISYO_L0184>":
                        {
                            __result = "Rpl: Ice • Weak: Fire";
                            return false;
                        }
                    case "<DEVIL_L0185>":
                        {
                            __result = "Specter";
                            return false;
                        }
                    case "<AISYO_L0185>":
                        {
                            __result = "Null: Light/Dark/Ailments";
                            return false;
                        }
                    case "<DEVIL_L0186>":
                        {
                            __result = "Mara";
                            return false;
                        }
                    case "<AISYO_L0186>":
                        {
                            __result = "Null: Light/Dark/Ailments";
                            return false;
                        }
                    case "<DEVIL_L0187>":
                        {
                            __result = "Doppelgänger";
                            return false;
                        }
                    case "<AISYO_L0187>":
                        {
                            __result = "Rpl: Phys • Str: Ailments • Weak: Light/Dark";
                            return false;
                        }
                    case "<DATSKILLHELP_L0153>":
                        {
                            __result = "Low Physical damage to all foes.";
                            return false;
                        }
                    default: return true;
                }
            }
        }

        private datDevilFormat_t OseHallel(datDevilFormat_t oseHallel, int id)
        {
            oseHallel.flag = 3;
            oseHallel.race = 35;
            oseHallel.level = 70;
            oseHallel.aisyoid = (short)id;
            oseHallel.param = new sbyte[] { 25, 0, 15, 20, 22, 20 };
            oseHallel.keisyotype = 1;
            oseHallel.keisyoform = 2459;

            datDevilName.txt[id] = "オセ・ハレル";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 3, 0, 2, 2, 3, 2 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 110, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 206, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 70, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 57, TargetLevel = 71, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 77, TargetLevel = 72, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 69, TargetLevel = 73, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[6] = new fclSkillParam_t { Param = 41, TargetLevel = 74, Type = 1 };

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

            datDevilVisual05.tbl_5_0A0_0BF[19] = datDevilVisual09.tbl_9_120_13F[1];
            datDevilVisual05.tbl_5_0A0_0BF[19].formscale = 1f;

            datMotionSeTable.tbl[id] = 289;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[71];

            return oseHallel;
        }

        private datDevilFormat_t FlaurosHallel(datDevilFormat_t flaurosHallel, int id)
        {
            flaurosHallel.flag = 3;
            flaurosHallel.race = 35;
            flaurosHallel.level = 70;
            flaurosHallel.aisyoid = (short)id;
            flaurosHallel.param = new sbyte[] { 35, 0, 15, 30, 18, 14 };
            flaurosHallel.keisyotype = 1;
            flaurosHallel.keisyoform = 2523;

            datDevilName.txt[id] = "フラロウス・ハレル";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 3, 0, 1, 3, 2, 1 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 105, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 166, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 203, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 186, TargetLevel = 71, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 178, TargetLevel = 72, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 345, TargetLevel = 73, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[6] = new fclSkillParam_t { Param = 104, TargetLevel = 74, Type = 1 };

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

            datDevilVisual05.tbl_5_0A0_0BF[20] = datDevilVisual09.tbl_9_120_13F[2];
            datDevilVisual05.tbl_5_0A0_0BF[20].formscale = 1f;

            datMotionSeTable.tbl[id] = 290;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[69];

            return flaurosHallel;
        }

        private datDevilFormat_t Urthona(datDevilFormat_t urthona, int id)
        {
            urthona.flag = 3;
            urthona.race = 34;
            urthona.level = 30;
            urthona.aisyoid = (short)id;
            urthona.param = new sbyte[] { 20, 0, 10, 20, 8, 11 };
            urthona.keisyotype = 4;
            urthona.keisyoform = 2177;

            datDevilName.txt[id] = "アーソナ";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 2, 0, 1, 2, 1, 1 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 14, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 49, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 17, TargetLevel = 31, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 305, TargetLevel = 32, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 311, TargetLevel = 33, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 15, TargetLevel = 34, Type = 1 };

            datAisyo.tbl[id][0] = 100;
            datAisyo.tbl[id][1] = 100;
            datAisyo.tbl[id][2] = 100;
            datAisyo.tbl[id][3] = 131072;
            datAisyo.tbl[id][4] = 2147483798;
            datAisyo.tbl[id][6] = 100;
            datAisyo.tbl[id][7] = 100;
            datAisyo.tbl[id][8] = 100;
            datAisyo.tbl[id][9] = 100;
            datAisyo.tbl[id][10] = 100;

            mdlFileDefTable.devilModelFileTable[id] = mdlFileDefTable.devilModelFileTable[279];
            mdlFileDefTable.devilOnModelFileTable[id] = mdlFileDefTable.devilOnModelFileTable[279];
            mdlFileDefTable.devilModelIndex[id] = mdlFileDefTable.devilModelIndex[279];
            mdlFileDefTable.devilOnModelIndex[id] = mdlFileDefTable.devilOnModelIndex[279];

            datDevilVisual05.tbl_5_0A0_0BF[21] = datDevilVisual08.tbl_8_100_11F[23];
            datDevilVisual05.tbl_5_0A0_0BF[21].formscale = 0.6f;

            datMotionSeTable.tbl[id] = 279;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[155];

            return urthona;
        }

        private datDevilFormat_t Urizen(datDevilFormat_t urizen, int id)
        {
            urizen.flag = 3;
            urizen.race = 34;
            urizen.level = 30;
            urizen.aisyoid = (short)id;
            urizen.param = new sbyte[] { 20, 0, 10, 20, 8, 11 };
            urizen.keisyotype = 4;
            urizen.keisyoform = 2177;

            datDevilName.txt[id] = "ユリゼン";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 2, 0, 1, 2, 1, 1 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 2, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 49, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 5, TargetLevel = 31, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 305, TargetLevel = 32, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 309, TargetLevel = 33, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 3, TargetLevel = 34, Type = 1 };

            datAisyo.tbl[id][0] = 100;
            datAisyo.tbl[id][1] = 131072;
            datAisyo.tbl[id][2] = 2147483798;
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

            datDevilVisual05.tbl_5_0A0_0BF[22] = datDevilVisual08.tbl_8_100_11F[24];
            datDevilVisual05.tbl_5_0A0_0BF[22].formscale = 0.6f;

            datMotionSeTable.tbl[id] = 280;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[155];

            return urizen;
        }

        private datDevilFormat_t Luvah(datDevilFormat_t luvah, int id)
        {
            luvah.flag = 3;
            luvah.race = 34;
            luvah.level = 30;
            luvah.aisyoid = (short)id;
            luvah.param = new sbyte[] { 20, 0, 10, 20, 8, 11 };
            luvah.keisyotype = 4;
            luvah.keisyoform = 2177;

            datDevilName.txt[id] = "ルヴァ";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 2, 0, 1, 2, 1, 1 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 20, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 49, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 23, TargetLevel = 31, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 305, TargetLevel = 32, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 312, TargetLevel = 33, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 21, TargetLevel = 34, Type = 1 };

            datAisyo.tbl[id][0] = 100;
            datAisyo.tbl[id][1] = 100;
            datAisyo.tbl[id][2] = 100;
            datAisyo.tbl[id][3] = 2147483798;
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

            datDevilVisual05.tbl_5_0A0_0BF[23] = datDevilVisual08.tbl_8_100_11F[25];
            datDevilVisual05.tbl_5_0A0_0BF[23].formscale = 0.6f;

            datMotionSeTable.tbl[id] = 281;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[155];

            return luvah;
        }

        private datDevilFormat_t Tharmus(datDevilFormat_t tharmus, int id)
        {
            tharmus.flag = 3;
            tharmus.race = 34;
            tharmus.level = 30;
            tharmus.aisyoid = (short)id;
            tharmus.param = new sbyte[] { 20, 0, 10, 20, 8, 11 };
            tharmus.keisyotype = 4;
            tharmus.keisyoform = 2177;

            datDevilName.txt[id] = "サーマス";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 2, 0, 1, 2, 1, 1 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 8, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 49, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 11, TargetLevel = 31, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 305, TargetLevel = 32, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 310, TargetLevel = 33, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 9, TargetLevel = 34, Type = 1 };

            datAisyo.tbl[id][0] = 100;
            datAisyo.tbl[id][1] = 2147483798;
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

            datDevilVisual05.tbl_5_0A0_0BF[24] = datDevilVisual08.tbl_8_100_11F[26];
            datDevilVisual05.tbl_5_0A0_0BF[24].formscale = 0.6f;

            datMotionSeTable.tbl[id] = 282;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[155];

            return tharmus;
        }

        private datDevilFormat_t Specter(datDevilFormat_t specter, int id)
        {
            specter.flag = 3;
            specter.race = 23;
            specter.level = 40;
            specter.aisyoid = (short)id;
            specter.param = new sbyte[] { 24, 0, 18, 20, 8, 6 };
            specter.keisyotype = 4;
            specter.keisyoform = 2177;

            datDevilName.txt[id] = "スペクター";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 2, 0, 2, 2, 1, 1 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 153, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 192, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 3, TargetLevel = 41, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 25, TargetLevel = 42, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 152, TargetLevel = 43, Type = 1 };

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

            datDevilVisual05.tbl_5_0A0_0BF[25] = datDevilVisual08.tbl_8_100_11F[1];
            datDevilVisual05.tbl_5_0A0_0BF[25].formscale = 0.8f;

            datMotionSeTable.tbl[id] = 257;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[178];

            return specter;
        }

        private datDevilFormat_t Mara(datDevilFormat_t mara, int id)
        {
            mara.flag = 3;
            mara.race = 19;
            mara.level = 85;
            mara.aisyoid = (short)id;
            mara.param = new sbyte[] { 30, 0, 40, 25, 14, 15 };
            mara.keisyotype = 6;
            mara.keisyoform = 187;

            datDevilName.txt[id] = "マーラ";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 3, 0, 4, 2, 1, 1 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 62, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 56, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 97, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 24, TargetLevel = 86, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 207, TargetLevel = 87, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 100, TargetLevel = 88, Type = 1 };

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

            mdlFileDefTable.devilModelFileTable[id] = mdlFileDefTable.devilModelFileTable[321];
            mdlFileDefTable.devilOnModelFileTable[id] = mdlFileDefTable.devilOnModelFileTable[321];
            mdlFileDefTable.devilModelIndex[id] = mdlFileDefTable.devilModelIndex[321];
            mdlFileDefTable.devilOnModelIndex[id] = mdlFileDefTable.devilOnModelIndex[321];

            datDevilVisual05.tbl_5_0A0_0BF[26] = datDevilVisual10.tbl_10_140_15F[1];
            datDevilVisual05.tbl_5_0A0_0BF[26].formscale = 1f;

            datMotionSeTable.tbl[id] = 321;

            datDevilNegoFormat.tbl[id] = datDevilNegoFormat.tbl[133];

            return mara;
        }

        private datDevilFormat_t Doppelganger(datDevilFormat_t doppelganger, int id)
        {
            doppelganger.flag = 128;
            doppelganger.race = 23;
            doppelganger.level = 60;
            doppelganger.aisyoid = (short)id;
            doppelganger.param = new sbyte[] { 17, 0, 17, 17, 17, 17 };
            doppelganger.keisyotype = 6;
            doppelganger.keisyoform = 2523;

            datDevilName.txt[id] = "ドッペルゲンガー";

            tblSkill.fclSkillTbl[id].GrowParamTbl = new sbyte[] { 2, 0, 2, 2, 2, 2 };

            tblSkill.fclSkillTbl[id].Event[0] = new fclSkillParam_t { Param = 69, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[1] = new fclSkillParam_t { Param = 63, TargetLevel = 0, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[2] = new fclSkillParam_t { Param = 196, TargetLevel = 61, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[3] = new fclSkillParam_t { Param = 68, TargetLevel = 62, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[4] = new fclSkillParam_t { Param = 345, TargetLevel = 63, Type = 1 };
            tblSkill.fclSkillTbl[id].Event[5] = new fclSkillParam_t { Param = 26, TargetLevel = 64, Type = 1 };

            datAisyo.tbl[id][0] = 131072;
            datAisyo.tbl[id][1] = 100;
            datAisyo.tbl[id][2] = 100;
            datAisyo.tbl[id][3] = 100;
            datAisyo.tbl[id][4] = 100;
            datAisyo.tbl[id][6] = 2147483798;
            datAisyo.tbl[id][7] = 2147483798;
            datAisyo.tbl[id][8] = 50;
            datAisyo.tbl[id][9] = 50;
            datAisyo.tbl[id][10] = 50;

            mdlFileDefTable.devilModelFileTable[id] = mdlFileDefTable.devilModelFileTable[0];
            mdlFileDefTable.devilOnModelFileTable[id] = mdlFileDefTable.devilOnModelFileTable[0];
            mdlFileDefTable.devilModelIndex[id] = mdlFileDefTable.devilModelIndex[0];
            mdlFileDefTable.devilOnModelIndex[id] = mdlFileDefTable.devilOnModelIndex[0];

            datDevilVisual05.tbl_5_0A0_0BF[27] = datHuman.datHumanVisual[0];

            datMotionSeTable.tbl[id] = 0;

            return doppelganger;
        }
    }
}