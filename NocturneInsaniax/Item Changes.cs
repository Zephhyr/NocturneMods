using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2Cppnewbattle_H;
using Il2Cppeffect_H;
using UnityEngine;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        [HarmonyPatch(typeof(datItemName), nameof(datItemName.Get))]
        private class ItemNamePatch
        {
            public static bool Prefix(ref int id, ref string __result)
            {
                switch (id)
                {
                    case 29: __result = "Needle Orb"; return false;
                    case 32: __result = "Medusa Eye"; return false;
                    case 33: __result = "Dekunda Rock"; return false;
                    case 46: __result = "Eternal Spyglass"; return false;
                    case 47: __result = "Spyglass"; return false;
                    case 48: __result = "Agilao Rock"; return false;
                    case 49: __result = "Bufula Rock"; return false;
                    case 50: __result = "Zionga Rock"; return false;
                    case 51: __result = "Zanma Rock"; return false;
                    case 59: __result = "Bright Hourglass"; return false;
                    case 60: __result = "Dark Hourglass"; return false;
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
                    case 29: __result = "Low Physical damage \nto random foes."; return false; // Needle Orb
                    case 32: __result = "Dark: Chance to inflict \nStone on one foe."; return false; // Medusa Eye
                    case 33: __result = "Negates -nda effects \non the party."; return false; // Dekunda Rock
                    case 34: __result = "Repels Magical attacks \nfor one ally once \nnext turn."; return false; // Magic Mirror
                    case 35: __result = "Repels Physical attacks \nfor one ally once \nnext turn."; return false; // Attack Mirror
                    case 47: __result = "Displays an enemy's info."; return false; // Spyglass
                    case 48: __result = "Medium Fire damage \nto one foe."; return false; // Agilao Rock
                    case 49: __result = "Medium Ice damage \nto one foe."; return false; // Bufula Rock
                    case 50: __result = "Medium Elec damage \nto one foe."; return false; // Zionga Rock
                    case 51: __result = "Medium Force damage \nto one foe."; return false; // Zanma Rock
                    case 59: __result = "Passes the time \nuntil a full Kagutsuchi."; return false; // Bright Hourglass
                    case 60: __result = "Passes the time \nuntil a new Kagutsuchi."; return false; // Dark Hourglass
                    case 76: __result = "Healing-type Magatama"; return false; // Geis
                    default: return true;
                }
            }

            [HarmonyPatch(typeof(fclShopCalc), nameof(fclShopCalc.shpCreateItemList))]
            private class ShopItemsPatch
            {
                public static void Postfix(ref fclDataShop_t pData)
                {
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
            ChakraElixir(12);
            NeedleOrbItem(29);
            MedusaEye(32);
            DekundaRock(33);
            Spyglass(47);
            AgilaoRock(48);
            BufulaRock(49);
            ZiongaRock(50);
            ZanmaRock(51);
            BrightHourglassItem(59);
            DarkHourglassItem(60);
        }

        private static void ChakraElixir(ushort id)
        {
            datItem.tbl[id].skillid = 82;
        }

        private static void NeedleOrbItem(ushort id)
        {
            datItem.tbl[id].flag = 4;
            datItem.tbl[id].price = 300;
            datItem.tbl[id].skillid = 128;
            datItem.tbl[id].use = 2;
        }

        private static void MedusaEye(ushort id)
        {
            datItem.tbl[id].flag = 4;
            datItem.tbl[id].price = 400;
            datItem.tbl[id].skillid = 197;
            datItem.tbl[id].use = 2;
        }

        private static void DekundaRock(ushort id)
        {
            datItem.tbl[id].flag = 4;
            datItem.tbl[id].price = 400;
            datItem.tbl[id].skillid = 77;
            datItem.tbl[id].use = 2;
        }

        private static void Spyglass(ushort id)
        {
            datItem.tbl[id].flag = 4;
            datItem.tbl[id].price = 100;
            datItem.tbl[id].skillid = 71;
            datItem.tbl[id].use = 2;
        }

        private static void AgilaoRock(ushort id)
        {
            datItem.tbl[id].flag = 4;
            datItem.tbl[id].price = 400;
            datItem.tbl[id].skillid = 2;
            datItem.tbl[id].use = 2;
        }

        private static void BufulaRock(ushort id)
        {
            datItem.tbl[id].flag = 4;
            datItem.tbl[id].price = 400;
            datItem.tbl[id].skillid = 8;
            datItem.tbl[id].use = 2;
        }

        private static void ZiongaRock(ushort id)
        {
            datItem.tbl[id].flag = 4;
            datItem.tbl[id].price = 400;
            datItem.tbl[id].skillid = 14;
            datItem.tbl[id].use = 2;
        }

        private static void ZanmaRock(ushort id)
        {
            datItem.tbl[id].flag = 4;
            datItem.tbl[id].price = 400;
            datItem.tbl[id].skillid = 20;
            datItem.tbl[id].use = 2;
        }

        private static void BrightHourglassItem(ushort id)
        {
            datItem.tbl[id].flag = 4;
            datItem.tbl[id].price = 100;
            datItem.tbl[id].skillid = 78;
            datItem.tbl[id].use = 1;
        }
        private static void DarkHourglassItem(ushort id)
        {
            datItem.tbl[id].flag = 4;
            datItem.tbl[id].price = 100;
            datItem.tbl[id].skillid = 91;
            datItem.tbl[id].use = 1;
        }

        //------------------------------------------------------------

        private static void ApplyShopChanges()
        {
            ShibuyaShop(1);
        }

        private static void ShibuyaShop(ushort id)
        {
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[5].ID = 47; // Spyglass
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[6].ID = 59; // Bright Hourglass
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[7].ID = 60; // Dark Hourglass
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[8].ID = 67; // Iyomante
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[9].ID = 68; // Shiranui
        }
    }
}
