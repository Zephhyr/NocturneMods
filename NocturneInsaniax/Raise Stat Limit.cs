using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using Il2Cppnewdata_H;
using UnityEngine;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppTMPro;
using UnityEngine.UI;
using Il2Cppcamp_H;
using Il2Cppnewbattle_H;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        private const int MAXSTATS = 40;
        private const int MAXHPMP = 9999;
        private const int POINTS_PER_LEVEL = 1;
        private const string BundlePath = "smt3hd_Data/StreamingAssets/PC/";
        private const float BAR_SCALE_X = (float)(40.0f / MAXSTATS) + (float)(16.0f / MAXSTATS);
        private const float BAR_SEGMENT_X = 18 * (float)(40.0f / MAXSTATS) - (float)(14.0f / MAXSTATS / 2);
        private static uint[] pCol = (uint[])Array.CreateInstance(typeof(uint), MAXSTATS);
        private static AssetBundle barData = null;
        private static Texture2D[] barAsset = new Texture2D[] { null, null, null, null, null };
        private static Sprite[] barSprite = new Sprite[] { null, null, null, null, null };
        private const string barSpriteName = "sstatusbar_base_empty";
        private static string[] paramNames = new string[] { "Str", "Mag", "Vit", "Agi", "Luc" };
        private static string[] StatusBarValues = new string[] { "shpnum_current", "shpnum_full", "smpnum_current", "smpnum_full" };
        private static string[] StockBarValues = new string[] { "barhp", "barmp" };
        private static string[] AnalyzeBarValues = new string[] { "banalyze_hp_known", "banalyze_mp_known" };
        private static string[] PartyBarValues = new string[] { "barhp", "barmp" };
        private static bool SettingAsignParam;
        private static bool EvoCheck;

        [HarmonyPatch(typeof(rstcalc), nameof(rstcalc.rstChkParamLimitAll))]
        private class PatchChkParamLimitAll
        {
            private static bool Prefix(ref int __result, datUnitWork_t pStock, bool paramSet = true)
            {
                __result = 0;
                if (PatchGetBaseParam.GetParam(pStock, 0) >= MAXSTATS)
                {
                    if (PatchGetBaseParam.GetParam(pStock, 2) < MAXSTATS) { return false; }
                    if (PatchGetBaseParam.GetParam(pStock, 3) < MAXSTATS) { return false; }
                    if (PatchGetBaseParam.GetParam(pStock, 4) < MAXSTATS) { return false; }
                    if (PatchGetBaseParam.GetParam(pStock, 5) < MAXSTATS) { return false; }
                    if (paramSet)
                    { rstcalc.rstSetMaxHpMp(0, ref pStock); }
                    __result = 1;
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datAddPlayerParam))]
        private class PatchAddPlayerParam
        {
            private static bool Prefix(int id, int add)
            {
                foreach (datUnitWork_t work in dds3GlobalWork.DDS3_GBWK.unitwork.Where(x => x.id == 0))
                {
                    work.param[id] += (sbyte)add;
                    if (datCalc.datGetPlayerParam(id) >= MAXSTATS)
                    { work.param[id] = MAXSTATS; }
                    if (datCalc.datGetPlayerParam(id) < 1 + (sbyte)(work.skillparam[id] + (sbyte)work.mitamaparam[id]))
                    { work.param[id] = (sbyte)(1 + (work.skillparam[id] + work.mitamaparam[id])); }
                    work.maxhp = (ushort)PatchGetMaxHP.GetMaxHP(work);
                    work.maxmp = (ushort)PatchGetMaxMP.GetMaxMP(work);
                    work.hp = work.maxhp;
                    work.mp = work.maxmp;
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetBaseParam))]
        private class PatchGetBaseParam
        {
            private static bool Prefix(ref int __result, datUnitWork_t work, int paratype)
            {
                __result = GetParam(work, paratype);
                return false;
            }
            public static int GetParam(datUnitWork_t work, int paratype)
            {
                int result = work.param[paratype] + work.mitamaparam[paratype];
                result = Math.Clamp(result, 1, MAXSTATS);
                return result;
            }
        }

        [HarmonyPatch(typeof(cmpMisc), nameof(cmpMisc.cmpUseItemKou))]
        private class PatchIncense
        {
            private static bool Prefix(ushort ItemID, datUnitWork_t pStock)
            {
                int statID = ItemID - 0x26;
                if (statID > -1 && statID < 6)
                {
                    if (rstCalcCore.cmbGetParamBase(ref pStock, statID) < MAXSTATS)
                    {
                        pStock.param[statID]++;
                        rstcalc.rstSetMaxHpMp(1, ref pStock);
                    }
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetBaseMaxHp))]
        private class PatchGetBaseMaxHP
        {
            public static int GetBaseMaxHP(datUnitWork_t work)
            {
                int result = (PatchGetBaseParam.GetParam(work, 3) + work.level) * 6;
                if (rstinit.GBWK != null)
                { result += rstinit.GBWK.ParamOfs[3] * 6; }
                return result;
            }

            private static bool Prefix(ref int __result, datUnitWork_t work)
            {
                __result = GetBaseMaxHP(work);
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetBaseMaxMp))]
        private class PatchGetBaseMaxMP
        {
            public static int GetBaseMaxMP(datUnitWork_t work)
            {
                int result = (PatchGetBaseParam.GetParam(work, 2) + work.level) * 4;
                if (rstinit.GBWK != null)
                { result += rstinit.GBWK.ParamOfs[2] * 4; }
                return result;
            }

            private static bool Prefix(ref int __result, datUnitWork_t work)
            {
                __result = GetBaseMaxMP(work);
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetMaxHp))]
        private class PatchGetMaxHP
        {
            public static uint GetMaxHP(datUnitWork_t work)
            {
                uint result = (uint)PatchGetBaseMaxHP.GetBaseMaxHP(work);
                result += datCalc.datCheckSyojiSkill(work, 0x122) == 1 ? (uint)(result * 0.1) : 0;
                result += datCalc.datCheckSyojiSkill(work, 0x123) == 1 ? (uint)(result * 0.2) : 0;
                result += datCalc.datCheckSyojiSkill(work, 0x124) == 1 ? (uint)(result * 0.3) : 0;
                result = Math.Clamp(result, 1, MAXHPMP);
                return result;
            }

            private static bool Prefix(ref uint __result, datUnitWork_t work)
            {
                __result = PatchGetMaxHP.GetMaxHP(work);
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datGetMaxMp))]
        private class PatchGetMaxMP
        {
            public static uint GetMaxMP(datUnitWork_t work)
            {
                uint result = (uint)PatchGetBaseMaxMP.GetBaseMaxMP(work);
                result += datCalc.datCheckSyojiSkill(work, 0x125) == 1 ? (uint)(result * 0.1) : 0;
                result += datCalc.datCheckSyojiSkill(work, 0x126) == 1 ? (uint)(result * 0.2) : 0;
                result += datCalc.datCheckSyojiSkill(work, 0x127) == 1 ? (uint)(result * 0.3) : 0;
                result = Math.Clamp(result, 1, MAXHPMP);
                return result;
            }
            private static bool Prefix(ref uint __result, datUnitWork_t work)
            {
                __result = (uint)PatchGetMaxMP.GetMaxMP(work);
                return false;
            }
        }

        [HarmonyPatch(typeof(rstcalc), nameof(rstcalc.rstSetMaxHpMp))]
        private class PatchSetMaxHPMP
        {
            private static bool Prefix(sbyte Mode, ref datUnitWork_t pStock)
            {
                pStock.maxhp = (ushort)datCalc.datGetMaxHp(pStock);
                pStock.maxmp = (ushort)datCalc.datGetMaxMp(pStock);
                if (Mode == 1)
                {
                    pStock.hp = pStock.maxhp;
                    pStock.mp = pStock.maxmp;
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(rstcalc), nameof(rstcalc.rstAddLevel))]
        private class PatchAddLevel
        {
            private static bool Prefix(int Val, datUnitWork_t pStock)
            {
                pStock.level = (ushort)Math.Clamp(pStock.level + Val, 1, 0xff);
                return false;
            }
        }

        [HarmonyPatch(typeof(rstCalcCore), nameof(rstCalcCore.cmbAddLevelUpParamEx))]
        private class PatchAddLevelUpParamEx
        {
            private static bool Prefix(out sbyte __result, ref datUnitWork_t pStock, sbyte Mode)
            {
                __result = AddLevelUpParam(ref pStock, Mode);
                return false;
            }

            public static sbyte AddLevelUpParam(ref datUnitWork_t pStock, sbyte Mode)
            {
                do
                {
                    int ctr = (int)(fclMisc.FCL_RAND() % 5);
                    if (ctr > 0)
                    { ctr++; }
                    if (rstinit.GBWK.ParamOfs.Length <= ctr)
                    { break; }
                    rstinit.GBWK.ParamOfs[ctr]++;
                    if (pStock.param[ctr] + rstinit.GBWK.ParamOfs[ctr] <= 0 || pStock.param[ctr] + rstinit.GBWK.ParamOfs[ctr] >= MAXSTATS)
                    { return 0x7f; }
                    return (sbyte)ctr;
                }
                while (true);
                return 6;
            }
        }

        [HarmonyPatch(typeof(rstcalc), nameof(rstcalc.rstAutoAsignDevilParam))]
        private class PatchAutoAsignDevilParam
        {
            private static bool Prefix()
            {
                EvoCheck = false;
                int i = 0;
                for (i = 0; i < rstinit.GBWK.ParamOfs.Length; i++)
                {
                    if (i == 1)
                    { continue; }
                    rstinit.GBWK.ParamOfs[i] = 0;
                }
                i = 0;
                datUnitWork_t pStock = rstinit.GBWK.pCurrentStock;
                do
                {
                    if (rstinit.GBWK.AsignParam * POINTS_PER_LEVEL <= i)
                    { break; }
                    var paramID = rstCalcCore.cmbAddLevelUpParamEx(ref pStock, 0);
                    if (paramID > 5 || paramID == -1)
                    { continue; }
                    if (pStock.param[paramID] + rstinit.GBWK.ParamOfs[paramID] >= MAXSTATS)
                    { pStock.param[paramID] = MAXSTATS; }
                    else
                    { pStock.param[paramID] += rstinit.GBWK.ParamOfs[paramID]; }
                    i++;
                }
                while (true);
                return false;
            }
        }

        [HarmonyPatch(typeof(rstcalc), nameof(rstcalc.rstCalcEvo))]
        private class PatchChkDevilEvo
        {
            private static bool Prefix()
            { EvoCheck = true; return true; }
        }

        [HarmonyPatch(typeof(cmpPanel), nameof(cmpPanel.cmpDrawDevilInfo))]
        private class PatchDrawDevilInfo
        {
            private static void Postfix(int X, int Y, uint Z, uint Col, sbyte SelFlag, sbyte DrawType, datUnitWork_t pStock, cmpCursorEff_t pEff, int FadeRate, GameObject obj, int MatCol)
            {
                int[] StockStats = new int[] { pStock.hp, pStock.mp };
                for (int i = 0; i < 2; i++)
                {
                    GameObject g2 = GameObject.Find(obj.name + "/" + StockBarValues[i]);
                    if (g2 == null)
                    { continue; }
                    if (g2.GetComponent<CounterCtr>().image.Length < 4)
                    {
                        GameObject g = GameObject.Instantiate(g2.GetComponent<CounterCtr>().image[0].gameObject);
                        g.transform.parent = g2.transform;
                        g.transform.position = g2.GetComponent<CounterCtr>().image[0].transform.position;
                        g2.GetComponent<CounterCtr>().image = g2.GetComponent<CounterCtr>().image.Append<Image>(g.GetComponent<Image>()).ToArray<Image>();
                        for (int j = 0; j < g2.GetComponent<CounterCtr>().image.Length; j++)
                        {
                            bool chk = g2.GetComponent<CounterCtr>().image[j].gameObject.active;
                            g2.GetComponent<CounterCtr>().image[j].gameObject.active = true;
                            g2.GetComponent<CounterCtr>().image[j].transform.localPosition = new Vector3(118 - j * 25, 31, -4);
                            g2.GetComponent<CounterCtr>().image[j].transform.localScale = new Vector3(g2.GetComponent<CounterCtr>().image[j].transform.localScale.x * 0.90f, g2.GetComponent<CounterCtr>().image[j].transform.localScale.y * 0.90f, g2.GetComponent<CounterCtr>().image[j].transform.localScale.z);
                            g2.GetComponent<CounterCtr>().image[j].gameObject.active = chk;
                        }
                        GameObject.DontDestroyOnLoad(g);
                    }
                    g2.GetComponent<CounterCtr>().Set(StockStats[i], Color.white, 0);
                }
            }
        }

        [HarmonyPatch(typeof(nbPanelProcess), nameof(nbPanelProcess.nbPanelPartyDraw))]
        private class PatchPanelPartyDraw
        {
            private static void Postfix()
            {
                for (int i = 0; i < 4; i++)
                {
                    nbParty_t party = nbMainProcess.nbGetPartyFromFormindex(i);
                    if (party == null)
                    { continue; }
                    if (i > 0 && party.statindex == 0)
                    { continue; }
                    datUnitWork_t pStock = dds3GlobalWork.DDS3_GBWK.unitwork[party.statindex];
                    int[] PartyStats = new int[] { pStock.hp, pStock.mp };

                    for (int k = 0; k < 2; k++)
                    {
                        GameObject g2 = GameObject.Find("bparty(Clone)/bparty_window0" + (i + 1) + "/" + PartyBarValues[k]);
                        if (g2 == null)
                        { continue; }
                        if (g2.GetComponent<CounterCtrBattle>().image.Length < 4)
                        {
                            GameObject g = GameObject.Instantiate(g2.GetComponent<CounterCtrBattle>().image[0].gameObject);
                            g.transform.parent = g2.transform;
                            g.transform.position = g2.GetComponent<CounterCtrBattle>().image[0].transform.position;
                            g2.GetComponent<CounterCtrBattle>().image = g2.GetComponent<CounterCtrBattle>().image.Append<Image>(g.GetComponent<Image>()).ToArray<Image>();
                            for (int j = 0; j < g2.GetComponent<CounterCtrBattle>().image.Length; j++)
                            {
                                bool chk = g2.GetComponent<CounterCtrBattle>().image[j].gameObject.active;
                                g2.GetComponent<CounterCtrBattle>().image[j].gameObject.active = true;
                                g2.GetComponent<CounterCtrBattle>().image[j].transform.localPosition = new Vector3(119 - j * 25, 0, -4);
                                g2.GetComponent<CounterCtrBattle>().image[j].transform.localScale = new Vector3(g2.GetComponent<CounterCtrBattle>().image[j].transform.localScale.x * 0.90f, g2.GetComponent<CounterCtrBattle>().image[j].transform.localScale.y * 0.90f, g2.GetComponent<CounterCtrBattle>().image[j].transform.localScale.z);
                                g2.GetComponent<CounterCtrBattle>().image[j].gameObject.active = chk;
                            }
                            GameObject.DontDestroyOnLoad(g);
                        }
                        g2.GetComponent<CounterCtrBattle>().Set(PartyStats[k], Color.white, 0);
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        GameObject g2 = GameObject.Find("summon_command/bmenu_command/bmenu_command_s0" + (i + 1) + "/" + PartyBarValues[k]);
                        if (g2 == null)
                        { continue; }
                        if (g2.GetComponent<CounterCtrBattle>().image.Length < 4)
                        {
                            GameObject g = GameObject.Instantiate(g2.GetComponent<CounterCtrBattle>().image[0].gameObject);
                            g.transform.parent = g2.transform;
                            g.transform.position = g2.GetComponent<CounterCtrBattle>().image[0].transform.position;
                            g2.GetComponent<CounterCtr>().image = g2.GetComponent<CounterCtr>().image.Append<Image>(g.GetComponent<Image>()).ToArray<Image>();
                            g2.GetComponent<CounterCtrBattle>().image = g2.GetComponent<CounterCtrBattle>().image.Append<Image>(g.GetComponent<Image>()).ToArray<Image>();
                            for (int j = 0; j < g2.GetComponent<CounterCtrBattle>().image.Length; j++)
                            {
                                bool chk = g2.GetComponent<CounterCtrBattle>().image[j].gameObject.active;
                                g2.GetComponent<CounterCtrBattle>().image[j].gameObject.active = true;
                                g2.GetComponent<CounterCtrBattle>().image[j].transform.localPosition = new Vector3(119 - j * 25, 0, -4);
                                g2.GetComponent<CounterCtrBattle>().image[j].transform.localScale = new Vector3(g2.GetComponent<CounterCtrBattle>().image[j].transform.localScale.x * 0.90f, g2.GetComponent<CounterCtrBattle>().image[j].transform.localScale.y * 0.90f, g2.GetComponent<CounterCtrBattle>().image[j].transform.localScale.z);
                                g2.GetComponent<CounterCtrBattle>().image[j].gameObject.active = chk;
                            }
                            GameObject.DontDestroyOnLoad(g);
                        }
                    }
                }
            }
        }

        [HarmonyPatch(typeof(nbPanelProcess), nameof(nbPanelProcess.nbPanelAnalyzeRun))]
        private class PatchPanelAnalyzeRun
        {
            private static void Postfix()
            {
                datUnitWork_t unit = nbPanelProcess.pNbPanelAnalyzeUnitWork;
                if (unit != null)
                {
                    int[] AnalyzeStats = new int[] { unit.hp, unit.maxhp, unit.mp, unit.maxmp };
                    string[] images = { "num_hp01", "num_hpfull01", "num_mp01", "num_mpfull01", };
                    for (int i = 0; i < 4; i++)
                    {
                        GameObject g2 = GameObject.Find(AnalyzeBarValues[i / 2] + "/" + images[i]);
                        if (g2 == null)
                        { continue; }
                        if (g2.GetComponent<CounterCtr>() == null)
                        { continue; }
                        if (g2.GetComponent<CounterCtr>().image.Length < 5)
                        {
                            for (int j = g2.GetComponent<CounterCtr>().image.Length; j < 5; j++)
                            {
                                GameObject g = GameObject.Instantiate(g2);
                                GameObject.Destroy(g.GetComponent<CounterCtr>());
                                g.name = images[i].Replace("1", "") + (i + 1);
                                g.transform.parent = g2.transform.parent;
                                g.transform.position = g2.GetComponent<CounterCtr>().transform.position;
                                g.transform.localPosition = g2.GetComponent<CounterCtr>().transform.localPosition;
                                g.transform.localScale = g2.GetComponent<CounterCtr>().transform.localScale;
                                g2.GetComponent<CounterCtr>().image = g2.GetComponent<CounterCtr>().image.Append<Image>(g.GetComponent<Image>()).ToArray<Image>();
                                GameObject.DontDestroyOnLoad(g);
                            }
                            for (int j = 0; j < g2.GetComponent<CounterCtr>().image.Length; j++)
                            {
                                g2.GetComponent<CounterCtr>().image[j].transform.localPosition = new Vector3((i % 2) * 130 + 86 - j * 20 + 5, 32, -8);
                                g2.GetComponent<CounterCtr>().image[j].transform.localScale = new Vector3(0.8f, 0.90f, 1);
                            }
                        }
                        g2.GetComponent<CounterCtr>().Set(AnalyzeStats[i], Color.white, 0);
                    }
                }
            }
        }

        [HarmonyPatch(typeof(rstupdate), nameof(rstupdate.rstResetAsignParam))]
        private class PatchResetAsignParam
        {
            private static bool Prefix()
            {
                ResetParam();
                return false;
            }
            public static void ResetParam()
            {
                rstinit.GBWK.AsignParam = (short)(rstinit.GBWK.LevelUpCnt * POINTS_PER_LEVEL);
                rstinit.GBWK.AsignParamMax = (short)(rstinit.GBWK.LevelUpCnt * POINTS_PER_LEVEL);
                for (int i = 0; i < rstinit.GBWK.ParamOfs.Length; i++)
                { rstinit.GBWK.ParamOfs[i] = 0; }
                rstinit.SetPointAnime(rstinit.GBWK.AsignParam);
            }
        }

        [HarmonyPatch(typeof(rstupdate), nameof(rstupdate.rstUpdateSeqAsignPlayerParam))]
        private class PatchUpdateAsignPlayerParam
        {
            public static sbyte YesResponse()
            {
                rstinit.GBWK.SeqInfo.Current = 0x18;
                return 1;
            }
            public static sbyte NoResponse()
            {
                rstupdate.rstResetAsignParam();
                return 0;
            }
            private static bool Prefix(ref datUnitWork_t pStock)
            {
                if (fclMisc.fclChkMessage() == 2)
                {
                    if (fclMisc.fclGetSelMessagePos() == 0
                        && dds3PadManager.DDS3_PADCHECK_PRESS(Il2Cpplibsdf_H.SDF_PADMAP.OK)
                        && dds3PadManager.DDS3_PADCHECK_REP(Il2Cpplibsdf_H.SDF_PADMAP.OK) == true)
                    {
                        if (fclMisc.fclChkSelMessage() == 1)
                        { YesResponse(); }
                    }
                    if ((fclMisc.fclGetSelMessagePos() == 1
                        && dds3PadManager.DDS3_PADCHECK_PRESS(Il2Cpplibsdf_H.SDF_PADMAP.OK)
                        && dds3PadManager.DDS3_PADCHECK_REP(Il2Cpplibsdf_H.SDF_PADMAP.OK) == true) ||
                        (dds3PadManager.DDS3_PADCHECK_PRESS(Il2Cpplibsdf_H.SDF_PADMAP.CANCEL)
                        && dds3PadManager.DDS3_PADCHECK_REP(Il2Cpplibsdf_H.SDF_PADMAP.CANCEL) == true))
                    {
                        if (fclMisc.fclChkSelMessage() == 1)
                        { NoResponse(); }
                    }
                    return false;
                }
                if (SettingAsignParam == false)
                {
                    SettingAsignParam = true;
                    EvoCheck = false;
                    PatchResetAsignParam.ResetParam();
                }
                if (rstinit.GBWK.LevelUpCnt <= 0)
                { SettingAsignParam = false; }
                if (pStock.param[0] + rstinit.GBWK.ParamOfs[0] >= MAXSTATS &&
                    pStock.param[2] + rstinit.GBWK.ParamOfs[2] >= MAXSTATS &&
                    pStock.param[3] + rstinit.GBWK.ParamOfs[3] >= MAXSTATS &&
                    pStock.param[4] + rstinit.GBWK.ParamOfs[4] >= MAXSTATS &&
                    pStock.param[5] + rstinit.GBWK.ParamOfs[5] >= MAXSTATS)
                { YesResponse(); return false; }
                if (cmpStatus.statusObj == null)
                { YesResponse(); return false; }
                if (fclMisc.fclChkMessage() != 0)
                { return false; }
                int cursorIndex = cmpMisc.cmpGetCursorIndex(rstinit.GBWK.ParamCursor);
                sbyte cursorParam = cmpMisc.cmpExchgParamIndex((sbyte)cursorIndex);
                cmpUpdate.cmpSetupObject(cmpStatus._statusUIScr.gameObject, true);
                if (dds3PadManager.DDS3_PADCHECK_PRESS(Il2Cpplibsdf_H.SDF_PADMAP.U) && dds3PadManager.DDS3_PADCHECK_REP(Il2Cpplibsdf_H.SDF_PADMAP.U) == true)
                {
                    cursorIndex = Math.Clamp((int)cmpMisc.cmpMoveCursor(rstinit.GBWK.ParamCursor, 0), 0, 4);
                    if (cursorIndex < 4)
                    { cmpMisc.cmpMoveCursor(rstinit.GBWK.ParamCursor, -1); cmpMisc.cmpPlaySE(1 & 0xFFFF); }
                    else
                    { cmpMisc.cmpPlaySE(2 & 0xFFFF); }
                    rstinit.SetPointAnime(cursorIndex);
                }
                if (dds3PadManager.DDS3_PADCHECK_PRESS(Il2Cpplibsdf_H.SDF_PADMAP.D) && dds3PadManager.DDS3_PADCHECK_REP(Il2Cpplibsdf_H.SDF_PADMAP.D) == true)
                {
                    cursorIndex = Math.Clamp((int)cmpMisc.cmpMoveCursor(rstinit.GBWK.ParamCursor, 0), 0, 4);
                    if (cursorIndex < 4)
                    { cmpMisc.cmpMoveCursor(rstinit.GBWK.ParamCursor, 1); cmpMisc.cmpPlaySE(1 & 0xFFFF); }
                    else
                    { cmpMisc.cmpPlaySE(2 & 0xFFFF); }
                    rstinit.SetPointAnime(cursorIndex);
                }
                cmpUpdate.cmpMenuCursor(cmpMisc.cmpGetCursorIndex(rstinit.GBWK.ParamCursor), cmpStatus._statusUIScr.stsCursor, cmpStatus._statusUIScr.ObjStsBar);
                if (dds3PadManager.DDS3_PADCHECK_PRESS(Il2Cpplibsdf_H.SDF_PADMAP.CANCEL) && dds3PadManager.DDS3_PADCHECK_REP(Il2Cpplibsdf_H.SDF_PADMAP.CANCEL) == true)
                {
                    rstupdate.rstResetAsignParam();
                    cmpMisc.cmpPlaySE(2 & 0xFFFF);
                }
                if (dds3PadManager.DDS3_PADCHECK_PRESS(Il2Cpplibsdf_H.SDF_PADMAP.OK) && dds3PadManager.DDS3_PADCHECK_REP(Il2Cpplibsdf_H.SDF_PADMAP.OK) == true)
                {
                    if (pStock.param[cursorParam] + rstinit.GBWK.ParamOfs[cursorParam] > MAXSTATS)
                    { cmpMisc.cmpPlaySE(2 & 0xFFFF); return false; }
                    if (rstinit.GBWK.AsignParam > 0)
                    {
                        rstinit.GBWK.ParamOfs[cursorParam]++;
                        rstinit.GBWK.AsignParam--;
                        cmpMisc.cmpPlaySE(1 & 0xFFFF);
                    }
                    if (rstinit.GBWK.AsignParam == 0)
                    {
                        fclMisc.fclStartMessage(2);
                        fclMisc.fclStartSelMessage(0x2b);
                        fclMisc.gSelMsgNo = 0x2b;
                    }
                }
                if (dds3PadManager.DDS3_PADCHECK_PRESS(Il2Cpplibsdf_H.SDF_PADMAP.OPT1) && dds3PadManager.DDS3_PADCHECK_REP(Il2Cpplibsdf_H.SDF_PADMAP.OPT1) == true)
                {
                    if (rstinit.GBWK.ParamOfs[cursorParam] < 1)
                    { cmpMisc.cmpPlaySE(2 & 0xFFFF); return false; }
                    else
                    {
                        rstinit.GBWK.ParamOfs[cursorParam]--;
                        rstinit.GBWK.AsignParam++;
                        cmpMisc.cmpPlaySE(2 & 0xFFFF);
                    }
                }
                pStock.maxhp = (ushort)PatchGetMaxHP.GetMaxHP(pStock);
                pStock.maxmp = (ushort)PatchGetMaxMP.GetMaxMP(pStock);
                return false;
            }
        }

        [HarmonyPatch(typeof(cmpDrawStatus), nameof(cmpDrawStatus.cmpDrawParamPanel))]
        private class PatchDrawParamPanel
        {
            private static void CreateParamGauge(sbyte ctr2, int X, int Y, uint[] pBaseCol, datUnitWork_t pStock, sbyte CursorPos, sbyte CursorMode, sbyte FlashMode)
            {
                if (ctr2 == 1 || ctr2 > pStock.param.Length || pBaseCol.Length == 0)
                { return; }
                if (pStock.param[ctr2] >= MAXSTATS)
                { pStock.param[ctr2] = MAXSTATS; }
                int MenuOfs = 0;
                if (cmpStatus.statusDrawType == 32768)
                { MenuOfs = 3; }
                if (cmpStatus.statusDrawType == -1)
                { MenuOfs = -1; }
                if (cmpStatus.statusObj.GetComponentsInChildren<TMP_Text>().Length >= 8 + MenuOfs)
                { cmpStatus.statusObj.GetComponentsInChildren<TMP_Text>()[ctr2 > 1 ? ctr2 + 2 + MenuOfs : ctr2 + 3 + MenuOfs].SetText(Localize.GetLocalizeText(paramNames[ctr2 > 1 ? ctr2 - 1 : ctr2])); }
                MenuOfs = 0;
                if (cmpStatus.statusDrawType == -1 && cmpStatus.statusObj.GetComponentsInChildren<CounterCtr>().Length >= 12)
                { MenuOfs = 1; }
                if (cmpStatus.statusObj.GetComponentsInChildren<TMP_Text>().Length >= 11 + MenuOfs)
                { cmpStatus.statusObj.GetComponentsInChildren<CounterCtr>()[ctr2 > 1 ? ctr2 + 5 + MenuOfs : ctr2 + 6 + MenuOfs].Set(pStock.param[ctr2], Color.white, (CursorMode == 2 && CursorPos > -1) ? 1 : 0); }
                if (-1 < CursorPos)
                { FlashMode = 2; }
                PatchDrawParamGauge.Prefix((int)X, (int)Y, pBaseCol, 0x14, (sbyte)ctr2, (sbyte)ctr2, FlashMode, pStock, cmpStatus.statusObj);
            }
            private static bool Prefix(int X, int Y, uint[] pBaseCol, sbyte[] pParamOfs, datUnitWork_t pStock, sbyte CursorPos, sbyte CursorMode, sbyte FlashMode)
            {
                if (cmpStatus.statusObj == null)
                { return false; }
                int[] StatusStats = new int[] { pStock.hp, pStock.maxhp, pStock.mp, pStock.maxmp };
                for (int i = 0; i < 4; i++)
                {
                    GameObject g2 = GameObject.Find(StatusBarValues[i]);
                    if (g2 == null)
                    { continue; }
                    if (g2.GetComponent<CounterCtr>().image.Length < 4)
                    {
                        GameObject g = GameObject.Instantiate(g2.GetComponent<CounterCtr>().image[0].gameObject);
                        g.transform.parent = g2.transform;
                        g.transform.position = g2.GetComponent<CounterCtr>().image[0].transform.position;
                        g2.GetComponent<CounterCtr>().image = g2.GetComponent<CounterCtr>().image.Append<Image>(g.GetComponent<Image>()).ToArray<Image>();
                        for (int j = 0; j < g2.GetComponent<CounterCtr>().image.Length; j++)
                        {
                            bool chk = g2.GetComponent<CounterCtr>().image[j].gameObject.active;
                            g2.GetComponent<CounterCtr>().image[j].gameObject.active = true;
                            g2.GetComponent<CounterCtr>().image[j].transform.localPosition = new Vector3(60 - j * 25, 0, -4);
                            g2.GetComponent<CounterCtr>().image[j].transform.localScale = new Vector3(g2.GetComponent<CounterCtr>().image[j].transform.localScale.x * 0.90f, g2.GetComponent<CounterCtr>().image[j].transform.localScale.y * 0.90f, g2.GetComponent<CounterCtr>().image[j].transform.localScale.z);
                            g2.GetComponent<CounterCtr>().image[j].gameObject.active = chk;
                        }
                        GameObject.DontDestroyOnLoad(g);
                    }
                    g2.GetComponent<CounterCtr>().Set(StatusStats[i], Color.white, 0);
                }
                for (int i = 0; i < 5; i++)
                {
                    GameObject g2 = GameObject.Find("sstatusnum0" + (i + 1));
                    if (g2 == null)
                    { continue; }
                    if (g2.GetComponent<CounterCtr>().image.Length < 3)
                    {
                        GameObject g = GameObject.Instantiate(g2.GetComponent<CounterCtr>().image[0].gameObject);
                        g.transform.parent = g2.transform;
                        g.transform.position = g2.GetComponent<CounterCtr>().image[0].transform.position;
                        g2.GetComponent<CounterCtr>().image = g2.GetComponent<CounterCtr>().image.Append<Image>(g.GetComponent<Image>()).ToArray<Image>();
                        for (int j = 0; j < g2.GetComponent<CounterCtr>().image.Length; j++)
                        {
                            bool chk = g2.GetComponent<CounterCtr>().image[j].gameObject.active;
                            g2.GetComponent<CounterCtr>().image[j].gameObject.active = true;
                            g2.GetComponent<CounterCtr>().image[j].transform.localPosition = new Vector3(30 - j * 25 + 5, 0, -4);
                            g2.GetComponent<CounterCtr>().image[j].transform.localScale = new Vector3(g2.GetComponent<CounterCtr>().image[j].transform.localScale.x * 0.90f, g2.GetComponent<CounterCtr>().image[j].transform.localScale.y * 0.90f, g2.GetComponent<CounterCtr>().image[j].transform.localScale.z);
                            g2.GetComponent<CounterCtr>().image[j].gameObject.active = chk;
                        }
                        GameObject.DontDestroyOnLoad(g);
                    }
                    if (pStock == null)
                    { continue; }
                    int stat = i > 0 ? i + 1 : i;
                    int levelstat = 0;
                    if (rstinit.GBWK != null && !EvoCheck)
                    { levelstat = rstinit.GBWK.ParamOfs[stat]; }
                    g2.GetComponent<CounterCtr>().Set(rstCalcCore.cmbGetParam(pStock, stat) + levelstat, Color.white, 0);
                }
                CreateParamGauge((sbyte)0, (int)(X * 3.75), (int)(Y * 2.25), pBaseCol, pStock, CursorPos, CursorMode, FlashMode);
                CreateParamGauge((sbyte)2, (int)(X * 3.75), (int)(Y * 2.25), pBaseCol, pStock, CursorPos, CursorMode, FlashMode);
                CreateParamGauge((sbyte)3, (int)(X * 3.75), (int)(Y * 2.25), pBaseCol, pStock, CursorPos, CursorMode, FlashMode);
                CreateParamGauge((sbyte)4, (int)(X * 3.75), (int)(Y * 2.25), pBaseCol, pStock, CursorPos, CursorMode, FlashMode);
                CreateParamGauge((sbyte)5, (int)(X * 3.75), (int)(Y * 2.25), pBaseCol, pStock, CursorPos, CursorMode, FlashMode);
                return false;
            }
        }

        [HarmonyPatch(typeof(cmpDrawStatus), nameof(cmpDrawStatus.cmpDrawParamGauge))]
        private class PatchDrawParamGauge
        {
            public static bool Prefix(int X, int Y, uint[] pBaseCol, int StepY, sbyte Pos, sbyte ParamOfs, sbyte FlashMode, datUnitWork_t pStock, GameObject stsObj)
            {
                if (Pos == 1 || ParamOfs == 1 || pStock == null || stsObj == null)
                { return false; }
                ReworkParamGauge(pBaseCol, StepY, Pos, ParamOfs, FlashMode, pStock, stsObj);
                return false;
            }
            private static void ReworkParamGauge(uint[] pBaseCol, int StepY, sbyte Pos, sbyte ParamOfs, sbyte FlashMode, datUnitWork_t pStock, GameObject stsObj)
            {
                if (stsObj.GetComponentsInChildren<sstatusbarUI>().Length < 1)
                { return; }
                if (stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>().Length != MAXSTATS)
                {
                    GameObject g;
                    while (stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>().Length < MAXSTATS)
                    {
                        g = GameObject.Instantiate(stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentInChildren<Animator>().gameObject);
                        g.transform.parent = stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.transform;
                        g.transform.position = g.transform.parent.position;
                        g.transform.localPosition = stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentInChildren<Animator>().gameObject.transform.localPosition;
                    }
                    while (stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>().Length > MAXSTATS)
                    {
                        GameObject.Destroy(stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>()[stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>().Length - 1].gameObject);
                    }
                    for (int len = MAXSTATS - 1; len >= 0; len--)
                    {
                        Vector3 barScale = stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>()[len].gameObject.transform.localScale;
                        Vector3 barPos = stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>()[len].gameObject.transform.localPosition;
                        barScale.x = BAR_SCALE_X;
                        barScale.y = 1;
                        barScale.z = 1;
                        barPos.x = 250 + (len) * BAR_SEGMENT_X + (18 - BAR_SEGMENT_X) + 2 / BAR_SCALE_X;
                        stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>()[len].gameObject.transform.localScale = barScale;
                        stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>()[len].gameObject.transform.localPosition = barPos;
                    }
                    if (barData == null)
                    { barData = AssetBundle.LoadFromFile(AppContext.BaseDirectory + BundlePath + barSpriteName); AssetBundle.DontDestroyOnLoad(barData); }
                    barAsset[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)] = barData.LoadAsset(barSpriteName).Cast<Texture2D>();
                    Texture2D.DontDestroyOnLoad(barAsset[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)]);
                    barSprite[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)] = Sprite.Create(barAsset[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)], new Rect(0, 0, barAsset[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].width, barAsset[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].height), Vector2.zero);
                    barSprite[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].texture.Apply();
                    Sprite.DontDestroyOnLoad(barSprite[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)]);
                    stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentInChildren<Image>().sprite = barSprite[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)];
                }
                int heartValue = 0;
                if ((pStock.flag >> 2 & 1) == 0)
                { heartValue = 0; }
                else if (FlashMode == 5)
                { heartValue = rstCalcCore.cmbGetHeartsParamEx((sbyte)dds3GlobalWork.DDS3_GBWK.heartsequip, ParamOfs, 0); }
                else
                { heartValue = rstCalcCore.cmbGetHeartsParam((sbyte)dds3GlobalWork.DDS3_GBWK.heartsequip, ParamOfs); }
                int paramValue = pStock.param[ParamOfs];
                int levelupValue = 0;
                int mitamaValue = pStock.mitamaparam[ParamOfs];
                if (rstinit.GBWK != null && !EvoCheck)
                { levelupValue = rstinit.GBWK.ParamOfs[ParamOfs]; }
                for (int ctr = 0; ctr < paramValue + levelupValue + mitamaValue; ctr++)
                {
                    if (MAXSTATS <= ctr)
                    { break; }
                    int segmentColor = 3;
                    if (paramValue + levelupValue + mitamaValue - heartValue > ctr)
                    { segmentColor = 4; }
                    if (paramValue + levelupValue - heartValue > ctr)
                    { segmentColor = 2; }
                    if (paramValue - heartValue > ctr)
                    { segmentColor = 1; }
                    stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>()[ctr].SetInteger("sstatusbar_color", segmentColor);
                }
                for (int ctr = paramValue + levelupValue + mitamaValue; ctr < MAXSTATS; ctr++)
                { stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>()[ctr].SetInteger("sstatusbar_color", 0); }
                int newFlashMode = FlashMode;
                if (FlashMode == 0)
                {
                    if (cmpDrawStatus.gStatusBlinkQue[(Pos > 1 ? Pos - 1 : Pos)] != 0)
                    { FlashMode = 2; }
                }
                if (FlashMode == 1 || FlashMode == 2)
                { cmpDrawStatus.cmpStatMakeBlinkCol(cmpDrawStatus.gStatusBlinkQue[(Pos > 1 ? Pos - 1 : Pos)], (sbyte)newFlashMode, pCol); }
                if (FlashMode == 3)
                {
                    if (cmpDrawStatus.gStatusBlinkQue[(Pos > 1 ? Pos - 1 : Pos)] != 0)
                    { cmpDrawStatus.cmpStatMakeBlinkCol(cmpDrawStatus.gStatusBlinkQue[(Pos > 1 ? Pos - 1 : Pos)], 0, pCol); }
                }
                if (FlashMode == 4 || FlashMode == 5)
                { cmpDrawStatus.cmpStatMakeBlinkCol(cmpDrawStatus.gStatusBlinkQue[(Pos > 1 ? Pos - 1 : Pos)], FlashMode, pCol); }
                return;
            }
        }
    }
}
