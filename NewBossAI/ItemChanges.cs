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
        [HarmonyPatch(typeof(datItemHelp_msg), nameof(datItemHelp_msg.Get))]
        private class ItemDescriptionPatch
        {
            public static bool Prefix(ref int id, ref string __result)
            {
                switch (id)
                {
                    case 34: __result = "Repels Magical attacks \nfor one ally once \nnext turn."; return false;
                    case 35: __result = "Repels Physical attacks \nfor one ally once \nnext turn."; return false;
                    case 76: __result = "Healing-type Magatama"; return false;
                    default: return true;
                }
            }

            [HarmonyPatch(typeof(fclShopCalc), nameof(fclShopCalc.shpCreateItemList))]
            private class BuyGeisPatch
            {
                // Adds Geis to shop number 4 (Asakusa) if you don't already have it
                public static void Postfix(ref fclDataShop_t pData)
                {
                    if (pData.Place == 4 && !dds3GlobalWork.DDS3_GBWK.hearts.Contains(13))
                    {
                        pData.BuyItemList[pData.BuyItemCnt] = 76; // Adds Geis to the shop list
                        pData.BuyItemCnt++; // Adds a slot to the shop list
                        datItemHelp_msg.txt[76] = datItemHelp_msg.txt[66]; // Gives Geis the same description as Ankh ("Healing-type Magatama")
                    }
                }
            }
        }
    }
}
