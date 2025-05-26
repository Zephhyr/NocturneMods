using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using Il2Cppnewdata_H;
using UnityEngine;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppTMPro;
using UnityEngine.UI;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        private const int MAXSTATS = 80;
        private const int MAXHPMP = 9999;
        private const float BAR_SCALE_X = (float)(40.0f / MAXSTATS);
        private const float BAR_SEGMENT_X = 18 * (float)(40.0f / MAXSTATS);
        private static uint[] pCol = (uint[])Array.CreateInstance(typeof(uint), MAXSTATS);
        //private static sdfTexHandle_t[] TexHandle = cmpInit.cmpTex;
        //private static fclSprTblArry_t[] SpriteTbl = etcSprTbl.cmpSprTblArry;
        private const string BundlePath = "smt3hd_Data/StreamingAssets/PC/";
        private static AssetBundle barData;
        private static Texture2D[] barAsset = new Texture2D[] { null, null, null, null, null };
        private static Sprite[] barSprite = new Sprite[] { null, null, null, null, null };
        private static string[] paramNames = new string[] { "Str", "Mag", "Vit", "Agi", "Luc" };
        private static int heartValue = 0;
        private static int paramValue = 0;

        [HarmonyPatch(typeof(rstcalc), "rstChkParamLimitAll")]
        private class PatchChkParamLimitAll
        {
            private static bool Prefix(ref int __result, datUnitWork_t pStock, bool paramSet = true)
            {
                __result = 0;
                if (PatchGetBaseParam.GetParam(pStock, 0) >= MAXSTATS) { __result += 1; }
                if (PatchGetBaseParam.GetParam(pStock, 2) >= MAXSTATS) { __result += 2; }
                if (PatchGetBaseParam.GetParam(pStock, 3) >= MAXSTATS) { __result += 4; }
                if (PatchGetBaseParam.GetParam(pStock, 4) >= MAXSTATS) { __result += 8; }
                if (PatchGetBaseParam.GetParam(pStock, 5) >= MAXSTATS)
                {
                    if (paramSet)
                    { rstcalc.rstSetMaxHpMp(0, ref pStock); }
                    __result += 16;
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), "datAddPlayerParam")]
        private class PatchAddPlayerParam
        {
            private static bool Prefix(int id, int add)
            {
                dds3GlobalWork.DDS3_GBWK.unitwork[0].param[id] += (sbyte)add;
                if (datCalc.datGetPlayerParam(id) >= MAXSTATS)
                { dds3GlobalWork.DDS3_GBWK.unitwork[0].param[id] = MAXSTATS; }
                if (datCalc.datGetPlayerParam(id) <= 0)
                { dds3GlobalWork.DDS3_GBWK.unitwork[0].param[id] = 0; }
                cmpMisc.cmpSetMaxHPMP(dds3GlobalWork.DDS3_GBWK.unitwork[0]);
                dds3GlobalWork.DDS3_GBWK.unitwork[0].hp = dds3GlobalWork.DDS3_GBWK.unitwork[0].maxhp;
                dds3GlobalWork.DDS3_GBWK.unitwork[0].mp = dds3GlobalWork.DDS3_GBWK.unitwork[0].maxmp;
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), "datGetBaseParam")]
        private class PatchGetBaseParam
        {
            private static bool Prefix(ref int __result, datUnitWork_t work, int paratype)
            {
                __result = GetParam(work, paratype);
                return false;
            }
            public static int GetParam(datUnitWork_t work, int paratype)
            {
                int result = work.param[paratype] + work.skillparam[paratype] + work.mitamaparam[paratype];
                result = result < MAXSTATS ? result > 1 ? result : 1 : MAXSTATS;
                return result;
            }
        }

        [HarmonyPatch(typeof(datCalc), "datGetBaseMaxHp")]
        private class PatchGetBaseMaxHP
        {
            public static int GetBaseMaxHP(datUnitWork_t work)
            {
                int result = (PatchGetBaseParam.GetParam(work, 3) + work.level) * 6;
                result = result < MAXHPMP ? result > 1 ? result : 1 : MAXHPMP;
                return result;
            }

            private static bool Prefix(ref int __result, datUnitWork_t work)
            {
                __result = GetBaseMaxHP(work);
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), "datGetBaseMaxMp")]
        private class PatchGetBaseMaxMP
        {
            public static int GetBaseMaxMP(datUnitWork_t work)
            {
                int result = (PatchGetBaseParam.GetParam(work, 2) + work.level) * 3;
                result = result < MAXHPMP ? result > 1 ? result : 1 : MAXHPMP;
                return result;
            }

            private static bool Prefix(ref int __result, datUnitWork_t work)
            {
                __result = GetBaseMaxMP(work);
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), "datGetMaxHp")]
        private class PatchGetMaxHP
        {
            private static bool Prefix(ref uint __result, datUnitWork_t work)
            {
                __result = (uint)PatchGetBaseMaxHP.GetBaseMaxHP(work);
                __result += datCalc.datCheckSyojiSkill(work, 0x122) == 1 ? (__result * 10 / 100) : 0;
                __result += datCalc.datCheckSyojiSkill(work, 0x123) == 1 ? (__result * 20 / 100) : 0;
                __result += datCalc.datCheckSyojiSkill(work, 0x124) == 1 ? (__result * 30 / 100) : 0;
                __result = __result < MAXHPMP ? __result > 1 ? __result : 1 : MAXHPMP;
                return false;
            }
        }

        [HarmonyPatch(typeof(datCalc), "datGetMaxMp")]
        private class PatchGetMaxMP
        {
            private static bool Prefix(ref uint __result, datUnitWork_t work)
            {
                __result = (uint)PatchGetBaseMaxMP.GetBaseMaxMP(work);
                __result += datCalc.datCheckSyojiSkill(work, 0x125) == 0 ? 0 : (__result * 10 / 100);
                __result += datCalc.datCheckSyojiSkill(work, 0x126) == 0 ? 0 : (__result * 20 / 100);
                __result += datCalc.datCheckSyojiSkill(work, 0x127) == 0 ? 0 : (__result * 30 / 100);
                __result = __result < MAXHPMP ? __result > 1 ? __result : 1 : MAXHPMP;
                return false;
            }
        }

        [HarmonyPatch(typeof(rstCalcCore), "cmbAddLevelUpParamEx")]
        private class PatchAddLevelUpParamEx
        {
            private static bool Prefix(out sbyte __result, ref datUnitWork_t pStock, sbyte Mode)
            {
                __result = 0;
                do
                {
                    uint ctr = fclMisc.FCL_RAND() % 6;
                    if (ctr == 1)
                    { continue; }
                    sbyte[] paramtbl;
                    if (pStock.id == 0)
                    { paramtbl = dds3GlobalWork.DDS3_GBWK.hearts_up_param[dds3GlobalWork.DDS3_GBWK.heartsequip]; }
                    else
                    { paramtbl = tblSkill.Get(pStock.id).GrowParamTbl; }
                    if (paramtbl.Length >= ctr)
                    { paramtbl[ctr]++; }
                    else
                    { return false; }
                    if (pStock.id <= 0)
                    { pStock.param[(int)ctr]++; }
                    if (pStock.param[(int)ctr] == 0 || pStock.param[(int)ctr] == MAXSTATS)
                    { return false; }
                    if (pStock.levelupparam.Length >= ctr)
                    { pStock.levelupparam[(int)ctr]++; __result = (sbyte)ctr; return false; }
                    break;
                }
                while (true);
                __result = 6;
                return false;
            }
        }

        [HarmonyPatch(typeof(cmpDrawStatus), "cmpDrawParamPanel")]
        private class PatchDrawParamPanel
        {
            private static void CreateParamGauge(sbyte ctr2, int X, int Y, uint[] pBaseCol, datUnitWork_t pStock, sbyte CursorPos, sbyte CursorMode, sbyte FlashMode)
            {
                if (ctr2 == 1 || ctr2 > pStock.param.Length || pBaseCol.Length == 0)
                { return; }
                if (pStock.param[ctr2] >= MAXSTATS)
                { pStock.param[ctr2] = MAXSTATS; }
                //int newX = cmpDraw.CMP_X((int)X);
                //int newY = cmpDraw.CMP_Y((int)(Y + ctr2 * 45));
                //fclDraw.fclDrawPartsEx3(X, Y + ctr2 * 45, 0, 0, pBaseCol, 4, 0, TexHandle, SpriteTbl, 0x47);
                int MenuOfs = 0;
                if (cmpStatus.statusDrawType == 32768)
                { MenuOfs = 3; }
                if (cmpStatus.statusDrawType == -1)
                { MenuOfs = -1; }
                cmpStatus.statusObj.GetComponentsInChildren<TMP_Text>()[ctr2 > 1 ? ctr2 + 2 + MenuOfs : ctr2 + 3 + MenuOfs].SetText(Localize.GetLocalizeText(paramNames[ctr2 > 1 ? ctr2 - 1 : ctr2]));
                MenuOfs = 0;
                if (cmpStatus.statusDrawType == -1 && cmpStatus.statusObj.GetComponentsInChildren<CounterCtr>().Length > 11)
                { MenuOfs = 1; }
                cmpStatus.statusObj.GetComponentsInChildren<CounterCtr>()[ctr2 > 1 ? ctr2 + 5 + MenuOfs : ctr2 + 6 + MenuOfs].Set(pStock.param[ctr2], Color.white, (CursorMode == 2 && CursorPos > -1) ? 1 : 0);
                if (-1 < CursorPos)
                { FlashMode = 2; }
                //cmpDrawStatus.cmpDrawParamGauge((int)X, (int)Y, pBaseCol, 0x14, (sbyte)ctr2, (sbyte)ctr2, FlashMode, pStock, cmpStatus.statusObj);
                PatchDrawParamGauge.Prefix((int)X, (int)Y, pBaseCol, 0x14, (sbyte)ctr2, (sbyte)ctr2, FlashMode, pStock, cmpStatus.statusObj);
                //newX = cmpDraw.CMP_X((int)X);
                //newY = cmpDraw.CMP_Y((int)Y);
                //fclDraw.fclDrawPartsEx2(X, Y, 0, 0, pBaseCol, 4, 1, TexHandle, SpriteTbl, 0x47);
            }
            private static bool Prefix(int X, int Y, uint[] pBaseCol, sbyte[] pParamOfs, datUnitWork_t pStock, sbyte CursorPos, sbyte CursorMode, sbyte FlashMode)
            {
                //var a = X * 3.75;
                //var b = Y * 2.25;
                //cmpDraw.CMP_X((int)(a + 172.5));
                //cmpDraw.CMP_Y((int)(b + 371.25));
                //int newX = cmpDraw.CMP_X((int)a);
                //int newY = cmpDraw.CMP_Y((int)b);
                //fclDraw.fclDrawParts(newX, newY + 4, 0, pBaseCol, 1, 4, TexHandle, SpriteTbl, 0x47);
                //fclDraw.fclDrawParts(newX, newY + 4, 0, pBaseCol, 1, 5, TexHandle, SpriteTbl, 0x47);
                //fclDraw.fclDrawParts(newX, newY + 4, 0, pBaseCol, 1, 6, TexHandle, SpriteTbl, 0x47);
                //fclDraw.fclDrawParts(newX, newY + 4, 0, pBaseCol, 1, 7, TexHandle, SpriteTbl, 0x47);
                CreateParamGauge((sbyte)0, (int)(X * 3.75), (int)(Y * 2.25), pBaseCol, pStock, CursorPos, CursorMode, FlashMode);
                CreateParamGauge((sbyte)2, (int)(X * 3.75), (int)(Y * 2.25), pBaseCol, pStock, CursorPos, CursorMode, FlashMode);
                CreateParamGauge((sbyte)3, (int)(X * 3.75), (int)(Y * 2.25), pBaseCol, pStock, CursorPos, CursorMode, FlashMode);
                CreateParamGauge((sbyte)4, (int)(X * 3.75), (int)(Y * 2.25), pBaseCol, pStock, CursorPos, CursorMode, FlashMode);
                CreateParamGauge((sbyte)5, (int)(X * 3.75), (int)(Y * 2.25), pBaseCol, pStock, CursorPos, CursorMode, FlashMode);
                /*
                if (-1 < CursorPos && CursorMode == 2)
                {
                    newX = cmpDraw.CMP_X((int)a);
                    newY = cmpDraw.CMP_Y((int)b + CursorPos * 0x14);
                    fclDraw.fclDrawParts(newX, newY, 0, pBaseCol, 6, 2, TexHandle, SpriteTbl, 0x47);
                }
                for(int ctr = 0; ctr < 5; ctr++)
                {
                    int TblNo = 0;
                    int PartsNo = 0;
                    newX = cmpDraw.CMP_X((int)a);
                    newY = cmpDraw.CMP_Y((int)b);
                    if (CursorMode == 2 && CursorPos == ctr)
                    {
                        TblNo = 6;
                        PartsNo = CursorPos + 5;
                    }
                    else
                    {
                        TblNo = 2;
                        PartsNo = ctr + 0xc;
                    }
                    fclDraw.fclDrawParts(newX, newY, 0, pBaseCol, (byte)TblNo, (ushort)PartsNo, TexHandle, SpriteTbl, 0x47);
                }*/
                return false;
            }
        }

        [HarmonyPatch(typeof(cmpDrawStatus), "cmpDrawParamGauge")]
        private class PatchDrawParamGauge
        {
            public static bool Prefix(int X, int Y, uint[] pBaseCol, int StepY, sbyte Pos, sbyte ParamOfs, sbyte FlashMode, datUnitWork_t pStock, GameObject stsObj)
            {
                if (Pos == 1 || ParamOfs == 1)
                { return true; }
                ReworkParamGauge(pBaseCol, StepY, Pos, ParamOfs, FlashMode, pStock, stsObj);
                return false;
            }
            private static void ReworkParamGauge(uint[] pBaseCol, int StepY, sbyte Pos, sbyte ParamOfs, sbyte FlashMode, datUnitWork_t pStock, GameObject stsObj)
            {
                if (stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>().Length != MAXSTATS)
                {
                    while (stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>().Length < MAXSTATS)
                    {
                        GameObject g = GameObject.Instantiate(stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentInChildren<Animator>().gameObject);
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
                        barPos.x = 255 + (len + 1) * BAR_SEGMENT_X;
                        stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>()[len].gameObject.transform.localScale = barScale;
                        stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>()[len].gameObject.transform.localPosition = barPos;
                    }
                    if (barData == null)
                    { barData = AssetBundle.LoadFromFile(AppContext.BaseDirectory + BundlePath + "sstatusbar_base_new"); AssetBundle.DontDestroyOnLoad(barData); }
                    barAsset[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)] = barData.LoadAllAssets()[0].Cast<Texture2D>();
                    Texture2D.DontDestroyOnLoad(barAsset[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)]);
                    barSprite[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)] = Sprite.Create(barAsset[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)], new Rect(0, 0, barAsset[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].width, barAsset[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].height), Vector2.zero);
                    barSprite[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].texture.Apply();
                    Sprite.DontDestroyOnLoad(barSprite[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)]);
                    stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentInChildren<Image>().sprite = barSprite[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)];
                }
                heartValue = 0;
                if ((pStock.flag >> 2 & 1) == 0)
                { heartValue = 0; }
                else if (FlashMode == 5)
                { heartValue = rstCalcCore.cmbGetHeartsParamEx((sbyte)dds3GlobalWork.DDS3_GBWK.heartsequip, ParamOfs, 0); }
                else
                { heartValue = rstCalcCore.cmbGetHeartsParam((sbyte)dds3GlobalWork.DDS3_GBWK.heartsequip, ParamOfs); }
                paramValue = pStock.param[ParamOfs];
                if (0 < paramValue)
                {
                    for (int ctr = 0; ctr < paramValue; ctr++)
                    {
                        if (MAXSTATS <= ctr)
                        { break; }
                        int segmentColor = 3;
                        if (paramValue - heartValue > ctr)
                        { segmentColor = 1; }
                        stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>()[ctr].SetInteger("sstatusbar_color", segmentColor);
                    }
                }
                for (int ctr = paramValue; ctr < MAXSTATS; ctr++)
                { stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>()[ctr].SetInteger("sstatusbar_color", 0); }
                int newFlashMode = FlashMode;
                if (FlashMode == 0)
                {
                    if (cmpDrawStatus.gStatusBlinkQue[(Pos > 1 ? Pos - 1 : Pos)] == 0)
                    { return; }
                    newFlashMode = FlashMode;
                    FlashMode = 2;
                }
                if (FlashMode == 1 || FlashMode == 2)
                {
                    cmpDrawStatus.cmpStatMakeBlinkCol(paramValue, (sbyte)newFlashMode, pCol);
                    if (paramValue - heartValue < paramValue)
                    {
                        if (heartValue < 0)
                        {
                            for (int cnt = paramValue + heartValue; cnt < paramValue; cnt++)
                            {
                                if (MAXSTATS <= cnt)
                                { break; }
                                stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>()[cnt].SetInteger("sstatusbar_color", 2);
                            }
                        }
                        else
                        {
                            for (int cnt = paramValue - heartValue; cnt < paramValue; cnt++)
                            {
                                if (MAXSTATS <= cnt)
                                { break; }
                                stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>()[cnt].SetInteger("sstatusbar_color", 2);
                            }
                        }
                    }
                }
                if (FlashMode == 3)
                {
                    //int cnt = -heartValue;
                    //if (heartValue < 0)
                    //    { cnt = heartValue; }
                    if (cmpDrawStatus.gStatusBlinkQue[(Pos > 1 ? Pos - 1 : Pos)] != 0)
                    {
                        cmpDrawStatus.cmpStatMakeBlinkCol(paramValue, 0, pCol);
                        //int cX = cmpDraw.CMP_X((chk + cnt) * 5 + X - 5);
                        //int cY = cmpDraw.CMP_Y(Y + Pos * StepY);
                        //fclDraw.fclDrawParts(cX, cY, 0, pCol, 6, 3, TexHandle, SpriteTbl, 0x47);
                    }
                }
                if (FlashMode == 4 || FlashMode == 5)
                {
                    cmpDrawStatus.cmpStatMakeBlinkCol(paramValue, FlashMode, pCol);
                    if (-(paramValue - heartValue) + MAXSTATS - 1 < 0 == (paramValue - heartValue) < MAXSTATS)
                    {
                        for (int cnt = 0; cnt < (paramValue - heartValue); cnt++)
                        { stsObj.GetComponentsInChildren<sstatusbarUI>()[(ParamOfs > 1 ? ParamOfs - 1 : ParamOfs)].gameObject.GetComponentsInChildren<Animator>()[cnt].SetInteger("sstatusbar_color", 4); }
                    }
                }
                return;
            }
        }
    }
}
