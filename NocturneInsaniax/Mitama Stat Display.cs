using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using Il2Cppnewdata_H;
using UnityEngine;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        [HarmonyPatch(typeof(cmpDrawStatus), nameof(cmpDrawStatus.cmpDrawParamGauge))]
        private class cmpStatMakeBlinkColPatch
        {
            public static void Postfix(ref int X, ref int Y, ref uint[] pBaseCol, ref int StepY, ref sbyte Pos, ref sbyte ParamOfs,
                                       ref sbyte FlashMode, ref datUnitWork_t pStock, ref GameObject stsObj)
            {
                switch (stsObj.name)
                {
                    case "sstatusbar01":
                        {
                            sbyte str;
                            sbyte mitamaStr;
                            bool mitamaFusion = (fclCombineInit.CMB_GBWK != null &&
                                pStock.id == fclCombineInit.CMB_GBWK.BirthDevil.id &&
                                pStock.param[0] != fclCombineInit.CMB_GBWK.BirthDevil.param[0]);
                            if (mitamaFusion)
                            {
                                str = fclCombineInit.CMB_GBWK.BirthDevil.param[0];
                                mitamaStr = fclCombineInit.CMB_GBWK.BirthDevil.mitamaparam[0];
                            }
                            else
                            {
                                str = pStock.param[0];
                                mitamaStr = pStock.mitamaparam[0];
                            }

                            if (mitamaStr == (sbyte)(str * 0.5))
                            {
                                cmpStatus._statusUIScr.transform.Find("sstatus/sstatusnum01").gameObject.GetComponent<CounterCtr>().colorIndex = 1;
                                cmpStatus._statusUIScr.transform.Find("sstatus/sstatusnum01").gameObject.GetComponent<CounterCtr>().Change();
                            }

                            for (int i = str + 1; i <= str + mitamaStr; i++)
                            {
                                var iString = i.ToString();
                                if (i < 10) iString = "0" + iString;
                                stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 3);
                            }
                            if (mitamaFusion)
                            {
                                for (int i = pStock.param[0] + pStock.mitamaparam[0] + 1; i <= fclCombineInit.CMB_GBWK.BirthDevil.param[0] + fclCombineInit.CMB_GBWK.BirthDevil.mitamaparam[0]; i++)
                                {
                                    var iString = i.ToString();
                                    if (i < 10) iString = "0" + iString;
                                    stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 4);
                                }
                            }
                            if (rstinit.GBWK != null)
                            {
                                sbyte levelUpStr = rstinit.GBWK.ParamOfs[0];
                                for (int i = str + 1; i <= str + levelUpStr; i++)
                                {
                                    var iString = i.ToString();
                                    if (i < 10) iString = "0" + iString;
                                    stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 2);
                                }
                                for (int i = str + levelUpStr + 1; i <= str + levelUpStr + mitamaStr; i++)
                                {
                                    var iString = i.ToString();
                                    if (i < 10) iString = "0" + iString;
                                    stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 3);
                                }
                            }
                            break;
                        }
                    case "sstatusbar02":
                        {
                            sbyte mag;
                            sbyte mitamaMag;
                            bool mitamaFusion = (fclCombineInit.CMB_GBWK != null &&
                                pStock.id == fclCombineInit.CMB_GBWK.BirthDevil.id &&
                                pStock.param[2] != fclCombineInit.CMB_GBWK.BirthDevil.param[2]);
                            if (mitamaFusion)
                            {
                                mag = fclCombineInit.CMB_GBWK.BirthDevil.param[2];
                                mitamaMag = fclCombineInit.CMB_GBWK.BirthDevil.mitamaparam[2];
                            }
                            else
                            {
                                mag = pStock.param[2];
                                mitamaMag = pStock.mitamaparam[2];
                            }

                            if (mitamaMag == (sbyte)(mag * 0.5))
                            {
                                cmpStatus._statusUIScr.transform.Find("sstatus/sstatusnum02").gameObject.GetComponent<CounterCtr>().colorIndex = 1;
                                cmpStatus._statusUIScr.transform.Find("sstatus/sstatusnum02").gameObject.GetComponent<CounterCtr>().Change();
                            }

                            for (int i = mag + 1; i <= mag + mitamaMag; i++)
                            {
                                var iString = i.ToString();
                                if (i < 10) iString = "0" + iString;
                                stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 3);
                            }
                            if (mitamaFusion)
                            {
                                for (int i = pStock.param[2] + pStock.mitamaparam[2] + 1; i <= fclCombineInit.CMB_GBWK.BirthDevil.param[2] + fclCombineInit.CMB_GBWK.BirthDevil.mitamaparam[2]; i++)
                                {
                                    var iString = i.ToString();
                                    if (i < 10) iString = "0" + iString;
                                    stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 4);
                                }
                            }
                            if (rstinit.GBWK != null)
                            {
                                sbyte levelUpMag = rstinit.GBWK.ParamOfs[2];
                                for (int i = mag + 1; i <= mag + levelUpMag; i++)
                                {
                                    var iString = i.ToString();
                                    if (i < 10) iString = "0" + iString;
                                    stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 2);
                                }
                                for (int i = mag + levelUpMag + 1; i <= mag + levelUpMag + mitamaMag; i++)
                                {
                                    var iString = i.ToString();
                                    if (i < 10) iString = "0" + iString;
                                    stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 3);
                                }
                            }
                            break;
                        }
                    case "sstatusbar03":
                        {
                            sbyte vit;
                            sbyte mitamaVit;
                            bool mitamaFusion = (fclCombineInit.CMB_GBWK != null &&
                                pStock.id == fclCombineInit.CMB_GBWK.BirthDevil.id &&
                                pStock.param[3] != fclCombineInit.CMB_GBWK.BirthDevil.param[3]);
                            if (mitamaFusion)
                            {
                                vit = fclCombineInit.CMB_GBWK.BirthDevil.param[3];
                                mitamaVit = fclCombineInit.CMB_GBWK.BirthDevil.mitamaparam[3];
                            }
                            else
                            {
                                vit = pStock.param[3];
                                mitamaVit = pStock.mitamaparam[3];
                            }

                            if (mitamaVit == (sbyte)(vit * 0.5))
                            {
                                cmpStatus._statusUIScr.transform.Find("sstatus/sstatusnum03").gameObject.GetComponent<CounterCtr>().colorIndex = 1;
                                cmpStatus._statusUIScr.transform.Find("sstatus/sstatusnum03").gameObject.GetComponent<CounterCtr>().Change();
                            }

                            for (int i = vit + 1; i <= vit + mitamaVit; i++)
                            {
                                var iString = i.ToString();
                                if (i < 10) iString = "0" + iString;
                                stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 3);
                            }
                            if (mitamaFusion)
                            {
                                for (int i = pStock.param[3] + pStock.mitamaparam[3] + 1; i <= fclCombineInit.CMB_GBWK.BirthDevil.param[3] + fclCombineInit.CMB_GBWK.BirthDevil.mitamaparam[3]; i++)
                                {
                                    var iString = i.ToString();
                                    if (i < 10) iString = "0" + iString;
                                    stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 4);
                                }
                            }
                            if (rstinit.GBWK != null)
                            {
                                sbyte levelUpVit = rstinit.GBWK.ParamOfs[3];
                                for (int i = vit + 1; i <= vit + levelUpVit; i++)
                                {
                                    var iString = i.ToString();
                                    if (i < 10) iString = "0" + iString;
                                    stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 2);
                                }
                                for (int i = vit + levelUpVit + 1; i <= vit + levelUpVit + mitamaVit; i++)
                                {
                                    var iString = i.ToString();
                                    if (i < 10) iString = "0" + iString;
                                    stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 3);
                                }
                            }
                            break;
                        }
                    case "sstatusbar04":
                        {
                            sbyte agi;
                            sbyte mitamaAgi;
                            bool mitamaFusion = (fclCombineInit.CMB_GBWK != null &&
                                pStock.id == fclCombineInit.CMB_GBWK.BirthDevil.id &&
                                pStock.param[4] != fclCombineInit.CMB_GBWK.BirthDevil.param[4]);
                            if (mitamaFusion)
                            {
                                agi = fclCombineInit.CMB_GBWK.BirthDevil.param[4];
                                mitamaAgi = fclCombineInit.CMB_GBWK.BirthDevil.mitamaparam[4];
                            }
                            else
                            {
                                agi = pStock.param[4];
                                mitamaAgi = pStock.mitamaparam[4];
                            }

                            if (mitamaAgi == (sbyte)(agi * 0.5))
                            {
                                cmpStatus._statusUIScr.transform.Find("sstatus/sstatusnum04").gameObject.GetComponent<CounterCtr>().colorIndex = 1;
                                cmpStatus._statusUIScr.transform.Find("sstatus/sstatusnum04").gameObject.GetComponent<CounterCtr>().Change();
                            }

                            for (int i = agi + 1; i <= agi + mitamaAgi; i++)
                            {
                                var iString = i.ToString();
                                if (i < 10) iString = "0" + iString;
                                stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 3);
                            }
                            if (mitamaFusion)
                            {
                                for (int i = pStock.param[4] + pStock.mitamaparam[4] + 1; i <= fclCombineInit.CMB_GBWK.BirthDevil.param[4] + fclCombineInit.CMB_GBWK.BirthDevil.mitamaparam[4]; i++)
                                {
                                    var iString = i.ToString();
                                    if (i < 10) iString = "0" + iString;
                                    stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 4);
                                }
                            }
                            if (rstinit.GBWK != null)
                            {
                                sbyte levelUpAgi = rstinit.GBWK.ParamOfs[4];
                                for (int i = agi + 1; i <= agi + levelUpAgi; i++)
                                {
                                    var iString = i.ToString();
                                    if (i < 10) iString = "0" + iString;
                                    stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 2);
                                }
                                for (int i = agi + levelUpAgi + 1; i <= agi + levelUpAgi + mitamaAgi; i++)
                                {
                                    var iString = i.ToString();
                                    if (i < 10) iString = "0" + iString;
                                    stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 3);
                                }
                            }
                            break;
                        }
                    case "sstatusbar05":
                        {
                            sbyte luk;
                            sbyte mitamaLuk;
                            bool mitamaFusion = (fclCombineInit.CMB_GBWK != null &&
                                pStock.id == fclCombineInit.CMB_GBWK.BirthDevil.id &&
                                pStock.param[5] != fclCombineInit.CMB_GBWK.BirthDevil.param[5]);
                            if (mitamaFusion)
                            {
                                luk = fclCombineInit.CMB_GBWK.BirthDevil.param[5];
                                mitamaLuk = fclCombineInit.CMB_GBWK.BirthDevil.mitamaparam[5];
                            }
                            else
                            {
                                luk = pStock.param[5];
                                mitamaLuk = pStock.mitamaparam[5];
                            }

                            if (mitamaLuk == (sbyte)(luk * 0.5))
                            {
                                cmpStatus._statusUIScr.transform.Find("sstatus/sstatusnum05").gameObject.GetComponent<CounterCtr>().colorIndex = 1;
                                cmpStatus._statusUIScr.transform.Find("sstatus/sstatusnum05").gameObject.GetComponent<CounterCtr>().Change();
                            }

                            for (int i = luk + 1; i <= luk + mitamaLuk; i++)
                            {
                                var iString = i.ToString();
                                if (i < 10) iString = "0" + iString;
                                stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 3);
                            }
                            if (mitamaFusion)
                            {
                                for (int i = pStock.param[5] + pStock.mitamaparam[5] + 1; i <= fclCombineInit.CMB_GBWK.BirthDevil.param[5] + fclCombineInit.CMB_GBWK.BirthDevil.mitamaparam[5]; i++)
                                {
                                    var iString = i.ToString();
                                    if (i < 10) iString = "0" + iString;
                                    stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 4);
                                }
                            }
                            if (rstinit.GBWK != null)
                            {
                                sbyte levelUpLuk = rstinit.GBWK.ParamOfs[5];
                                for (int i = luk + 1; i <= luk + levelUpLuk; i++)
                                {
                                    var iString = i.ToString();
                                    if (i < 10) iString = "0" + iString;
                                    stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 2);
                                }
                                for (int i = luk + levelUpLuk + 1; i <= luk + levelUpLuk + mitamaLuk; i++)
                                {
                                    var iString = i.ToString();
                                    if (i < 10) iString = "0" + iString;
                                    stsObj.transform.Find("sstatusbar_color" + iString).GetComponent<Animator>().SetInteger("sstatusbar_color", 3);
                                }
                            }
                            break;
                        }
                }
            }
        }
    }
}