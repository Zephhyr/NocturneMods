using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppkernel_H;
using UnityEngine;
using System.Runtime.CompilerServices;
using Il2CppTMPro;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        public static short currentRecord;

        public static float GetDiscountFactor(float limitDiscount = 50f, float finalDiscount = 80f)
        {
            int compendiumProgress = fclEncyc.fclEncycGetRatio2();
            float discountFactor;

            if (compendiumProgress < 100)
            {
                discountFactor = 1 - (compendiumProgress * limitDiscount) / (100f * 100f);
            }
            else
            {
                discountFactor = 1 - (compendiumProgress * finalDiscount) / (100f * 100f);
                discountFactor *= 2;
            }

            return discountFactor;
        }

        public static float GetDiscountFactor(int race, float limitDiscount = 50f, float finalDiscount = 80f)
        {
            float discountFactor = GetDiscountFactor();

            if (race == 7)
                discountFactor *= 2f;
            else if (race == 8)
                discountFactor *= 2.5f;

            return discountFactor;
        }

        [HarmonyPatch(typeof(frFont), nameof(frFont.frReplaceLocalizeText))]
        private class CompendiumMessagePatch
        {
            public static void Postfix(ref string message, ref frMsgInfo_t mi, ref List<int> index, ref string __result)
            {
                var pelem = dds3GlobalWork.DDS3_GBWK.encyc_record.pelem[currentRecord];

                if (__result.Contains("<SP7><FO1>It will cost <CO4>") && __result.Contains("Are you okay with that?"))
                {
                    var macca = int.Parse(string.Concat(__result.Replace("<SP7><FO1>It will cost <CO4>", string.Empty).Where(char.IsNumber)));
                    macca = (int)(macca * GetDiscountFactor(datDevilFormat.tbl[pelem.id].race));
                    __result = "<SP7><FO1>It will cost <CO4>" + macca + " Macca. <CO0>Are you okay with that?";
                }
                else if (__result.Contains("<SP7><FO1>It will cost <CO4>") && __result.Contains("But it seems you don't have enough."))
                {
                    var macca = int.Parse(string.Concat(__result.Replace("<SP7><FO1>It will cost <CO4>", string.Empty).Where(char.IsNumber)));
                    macca = (int)(macca * GetDiscountFactor(datDevilFormat.tbl[pelem.id].race));
                    __result = "<SP7><FO1>It will cost <CO4>" + macca + " Macca... <CO0>But it seems you don't have enough.";
                }
                else if (__result.Contains("Naturally, the stronger the demon, the more it will cost."))
                    __result += " The cost will be discounted based on how many demons you have registered.";
            }
        }

        [HarmonyPatch(typeof(CounterCtr), nameof(CounterCtr.Set))]
        private class CounterCtrSetPatch
        {
            public static void Prefix(ref int val, ref Color col, ref int colidx, ref CounterCtr __instance)
            {
                if (__instance.transform.GetParent().name.Contains("dlistsum_row0"))
                {
                    var race = __instance.transform.GetParent().FindChild("Text_raceTM").GetComponent<TextMeshProUGUI>().m_text;

                    val = (int)(val * GetDiscountFactor());
                    if (race.Contains("Element"))
                        val = (int)(val * 2);
                    else if (race.Contains("Mitama"))
                        val = (int)(val * 2.5);
                }
            }
        }

        [HarmonyPatch(typeof(fclEncyc), nameof(fclEncyc.PrepSummon))]
        private class PrepSummonPatch
        {
            public static void Prefix(ref fclEncyc.readmainwork_tag pwork, ref int __result)
            {
                MelonLogger.Msg("--fclEncyc.PrepSummon--");
                currentRecord = pwork.recindex;
            }

            public static void Postfix(ref fclEncyc.readmainwork_tag pwork, ref int __result)
            {
                MelonLogger.Msg("--fclEncyc.PrepSummon--");
                var pelem = dds3GlobalWork.DDS3_GBWK.encyc_record.pelem[pwork.recindex];
                MelonLogger.Msg("pwork.recindex: " + pwork.recindex);
                MelonLogger.Msg("pelem.id: " + pelem.id);

                pwork.mak = (int)(pwork.mak * GetDiscountFactor(datDevilFormat.tbl[pelem.id].race));
                if (__result == 0 && dds3GlobalWork.DDS3_GBWK.maka >= pwork.mak && datCalc.datCheckStockFull() == 0 && datCalc.datSearchDevilStock(pelem.id) == -1 && pwork.flags == 80)
                {
                    pwork.flags = (ushort)(pwork.flags | 1);
                    __result = 1;
                }
                else if (__result == 1 && dds3GlobalWork.DDS3_GBWK.maka < pwork.mak && datCalc.datCheckStockFull() == 0 && datCalc.datSearchDevilStock(pelem.id) == -1 && pwork.flags == 80)
                {
                    pwork.flags = (ushort)(pwork.flags | 4);
                    __result = 0;
                }

                MelonLogger.Msg("pwork.mak: " + pwork.mak);
                MelonLogger.Msg("pwork.flags: " + pwork.flags);
                MelonLogger.Msg("result: " + __result);
            }
        }

        [HarmonyPatch(typeof(fclMisc), nameof(fclMisc.fclScriptStart))]
        private class fclScriptStartPatch
        {
            public static void Prefix(ref byte[] pScriptData, ref int StartNo, ref dds3ProcessID_t pPID, ref dds3ProcessID_t __result)
            {
                MelonLogger.Msg("--fclMisc.fclScriptStart Prefix--");
                MelonLogger.Msg("currentRecord: " + currentRecord);
                var pelem = dds3GlobalWork.DDS3_GBWK.encyc_record.pelem[currentRecord];
                var statTotal = fclEncyc.GetDevilParam(pelem, 0) + fclEncyc.GetDevilParam(pelem, 2) + fclEncyc.GetDevilParam(pelem, 3) + fclEncyc.GetDevilParam(pelem, 4) + fclEncyc.GetDevilParam(pelem, 5);
                var price = (((statTotal * statTotal) / 20) * 100);
                price = (int)(price * GetDiscountFactor(datDevilFormat.tbl[pelem.id].race));
                MelonLogger.Msg("pelem.id: " + pelem.id);
                MelonLogger.Msg("price: " + price);
                MelonLogger.Msg("datCheckStockFull: " + datCalc.datCheckStockFull());
                MelonLogger.Msg("datSearchDevilStock: " + datCalc.datSearchDevilStock(pelem.id));

                if (StartNo == 18 && dds3GlobalWork.DDS3_GBWK.maka >= price && datCalc.datCheckStockFull() == 0 && datCalc.datSearchDevilStock(pelem.id) == -1)
                    StartNo = 17;
                else if (StartNo == 17 && dds3GlobalWork.DDS3_GBWK.maka < price && datCalc.datCheckStockFull() == 0 && datCalc.datSearchDevilStock(pelem.id) == -1)
                    StartNo = 18;
                MelonLogger.Msg("StartNo: " + StartNo);
            }
        }
    }
}
