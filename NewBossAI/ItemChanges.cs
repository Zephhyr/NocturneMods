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
        [HarmonyPatch(typeof(datItemName), nameof(datItemName.Get))]
        private class ItemNamePatch
        {
            public static bool Prefix(ref int id, ref string __result)
            {
                switch (id)
                {
                    case 57: __result = "Hourglass"; return false;
                    default: return true;
                }
            }
        }

        [HarmonyPatch(typeof(datItemHelp_msg), nameof(datItemHelp_msg.Get))]
        private class ItemDescriptionPatch
        {
            public static bool Prefix(ref int id, ref string __result)
            {
                switch (id)
                {
                    case 34: __result = "Repels Magical attacks \nfor one ally once \nnext turn."; return false; // Magic Mirror
                    case 35: __result = "Repels Physical attacks \nfor one ally once \nnext turn."; return false; // Attack Mirror
                    case 57: __result = "Passes the time \nuntil a full Kagutsuchi."; return false; // Hourglass
                    case 76: __result = "Healing-type Magatama"; return false; // Geis
                    default: return true;
                }
            }

            [HarmonyPatch(typeof(fclShopCalc), nameof(fclShopCalc.shpCreateItemList))]
            private class ShopItemsPatch
            {
                public static void Postfix(ref fclDataShop_t pData)
                {
                    pData.BuyItemList[pData.BuyItemCnt++] = 57;

                    if (pData.Place == 4 && !dds3GlobalWork.DDS3_GBWK.hearts.Contains(13)) // Adds Geis to shop number 4 (Asakusa) if you don't already have it
                    {
                        pData.BuyItemList[pData.BuyItemCnt++] = 76;
                    }
                }
            }

            [HarmonyPatch(typeof(fclShopCalc), nameof(fclShopCalc.shpCalcItemPrice))]
            private class ShopPricesPatch
            {
                public static void Postfix(ref sbyte Mode, ref int __result)
                {
                    // If buying on Hard then multiply prices by 2/3
                    if (Mode == 0 && dds3ConfigMain.cfgGetBit(9u) == 2) __result = __result * 2 / 3;
                }
            }
        }

        //------------------------------------------------------------

        private static void ApplyItemChanges()
        {
            HourglassItem();
        }

        private static void HourglassItem()
        {
            datItem.tbl[57].flag = 4; // Normal item
            datItem.tbl[57].price = 500; // 500 macca each
            datItem.tbl[57].skillid = 78; // Triggers the skill n°78
            datItem.tbl[57].use = 1; // Can only be used out of battle
        }
    }
}
