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
                    case 57: __result = "Hourglass"; return false;
                    case 59: __result = "Focus Rock"; return false;
                    case 60: __result = "Concentrate Rock"; return false;
                    case 62: __result = "Cursed Gospel"; return false;
                    case 63: __result = "Impel Stone"; return false;
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
                    case 57: __result = "Passes the time \nuntil the next new \nor full Kagutsuchi."; return false; // Hourglass
                    case 59: __result = "More than doubles damage \nof next Physical attack."; return false; // Focus Rock
                    case 60: __result = "More than doubles damage \nof next Magical attack."; return false; // Concentrate Rock
                    case 62: __result = "Demi-fiend earns enough \nEXP to level up but \nloses one level."; return false; // Cursed Gospel
                    case 63: __result = "Grants four flashing \nturn icons. \n(Limit: 1)"; return false; // Impel Rock
                    case 76: __result = "Healing-type Magatama"; return false; // Geis
                    case 86: __result = "Physical-type Magatama"; return false; // Gaea
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

            [HarmonyPatch(typeof(fclRagInit), nameof(fclRagInit.ragCreateAllList))]
            private class RagStockPatch
            {
                public static void Prefix(ref fclDataRag_t pData)
                {
                    if (pData.ItemListCnt == 21)
                    {
                        if (!dds3GlobalWork.DDS3_GBWK.hearts.Contains(23))
                        {
                            pData.ItemList = new sbyte[32] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };
                        }
                        else
                        {
                            pData.ItemListCnt = 20;
                            pData.ItemList = new sbyte[32] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, };
                        }
                    }
                }

                public static void Postfix(ref fclDataRag_t pData)
                {
                    if (pData.ItemListCnt == 21)
                    {
                        pData.ItemList = new sbyte[32] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    }
                    else if (pData.ItemListCnt == 20)
                    {
                        pData.ItemList = new sbyte[32] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    }
                }
            }

            [HarmonyPatch(typeof(fclRagUpdate), nameof(fclRagUpdate.ragChkItemErr))]
            private class ragChkItemErrPatch
            {
                public static void Postfix(ref ushort ItemID, ref sbyte __result)
                {
                    if (ItemID == 63 && dds3GlobalWork.DDS3_GBWK.item[63] >= 1)
                        __result = 1;
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
            HourglassItem(57);
            FocusRockItem(59);
            ConcentrateRockItem(60);
            CursedGospelItem(62);
            ImpelStoneItem(63);
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

        private static void HourglassItem(ushort id)
        {
            datItem.tbl[id].flag = 4;
            datItem.tbl[id].price = 100;
            datItem.tbl[id].skillid = 78;
            datItem.tbl[id].use = 1;
        }
        private static void FocusRockItem(ushort id)
        {
            datItem.tbl[id].flag = 4;
            datItem.tbl[id].price = 100;
            datItem.tbl[id].skillid = 224;
            datItem.tbl[id].use = 2;
        }

        private static void ConcentrateRockItem(ushort id)
        {
            datItem.tbl[id].flag = 4;
            datItem.tbl[id].price = 100;
            datItem.tbl[id].skillid = 424;
            datItem.tbl[id].use = 2;
        }

        private static void CursedGospelItem(ushort id)
        {
            datItem.tbl[id].flag = 4;
            datItem.tbl[id].price = 100;
            datItem.tbl[id].skillid = 91;
            datItem.tbl[id].use = 1;
        }

        private static void ImpelStoneItem(ushort id)
        {
            datItem.tbl[id].flag = 4;
            datItem.tbl[id].price = 12500;
            datItem.tbl[id].skillid = 220;
            datItem.tbl[id].use = 2;
        }

        //------------------------------------------------------------

        private static void ApplyShopChanges()
        {
            ShibuyaShop(1);
            RagShop();
        }

        private static void ShibuyaShop(ushort id)
        {
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[5].ID = 47; // Spyglass
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[6].ID = 57; // Hourglass
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[7].ID = 67; // Iyomante
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[8].ID = 68; // Shiranui
        }

        private static void RagShop()
        {
            fclRagShopTable.fclRagItemPackTbl[1] = new byte[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            fclRagShopTable.fclRagItemTbl[9].ItemID = 33;
            fclRagShopTable.fclRagItemTbl[9].Rate[0].ItemID = 103;
            fclRagShopTable.fclRagItemTbl[9].Rate[1].ItemID = 110;

            fclRagShopTable.fclRagItemTbl[10].ItemID = 34;
            fclRagShopTable.fclRagItemTbl[10].Rate[0].ItemID = 102;
            fclRagShopTable.fclRagItemTbl[10].Rate[1].ItemID = 108;

            fclRagShopTable.fclRagItemTbl[11].ItemID = 35;
            fclRagShopTable.fclRagItemTbl[11].Rate[0].ItemID = 102;
            fclRagShopTable.fclRagItemTbl[11].Rate[1].ItemID = 105;

            fclRagShopTable.fclRagItemTbl[12].ItemID = 36;
            fclRagShopTable.fclRagItemTbl[12].Rate[0].ItemID = 106;
            fclRagShopTable.fclRagItemTbl[12].Rate[1].ItemID = 110;

            fclRagShopTable.fclRagItemTbl[13].ItemID = 37;
            fclRagShopTable.fclRagItemTbl[13].Rate[0].ItemID = 106;
            fclRagShopTable.fclRagItemTbl[13].Rate[1].ItemID = 111;

            fclRagShopTable.fclRagItemTbl[14].ItemID = 52;
            fclRagShopTable.fclRagItemTbl[14].Rate[0].ItemID = 105;
            fclRagShopTable.fclRagItemTbl[14].Rate[1].ItemID = 106;

            fclRagShopTable.fclRagItemTbl[15].ItemID = 53;
            fclRagShopTable.fclRagItemTbl[15].Rate[0].ItemID = 105;
            fclRagShopTable.fclRagItemTbl[15].Rate[0].Nums = 1;
            fclRagShopTable.fclRagItemTbl[15].Rate[1].ItemID = 110;
            fclRagShopTable.fclRagItemTbl[15].Rate[1].Nums = 1;

            fclRagShopTable.fclRagItemTbl[16].ItemID = 56;
            fclRagShopTable.fclRagItemTbl[16].Rate[0].ItemID = 108;
            fclRagShopTable.fclRagItemTbl[16].Rate[0].Nums = 1;
            fclRagShopTable.fclRagItemTbl[16].Rate[1].ItemID = 111;
            fclRagShopTable.fclRagItemTbl[16].Rate[1].Nums = 1;

            fclRagShopTable.fclRagItemTbl[17].ItemID = 59;
            fclRagShopTable.fclRagItemTbl[17].Rate[0].ItemID = 103;
            fclRagShopTable.fclRagItemTbl[17].Rate[0].Nums = 1;
            fclRagShopTable.fclRagItemTbl[17].Rate[1].ItemID = 104;
            fclRagShopTable.fclRagItemTbl[17].Rate[1].Nums = 1;

            fclRagShopTable.fclRagItemTbl[18].ItemID = 60;
            fclRagShopTable.fclRagItemTbl[18].Rate[0].ItemID = 103;
            fclRagShopTable.fclRagItemTbl[18].Rate[0].Nums = 1;
            fclRagShopTable.fclRagItemTbl[18].Rate[1].ItemID = 105;
            fclRagShopTable.fclRagItemTbl[18].Rate[1].Nums = 1;

            fclRagShopTable.fclRagItemTbl[19].ItemID = 62;
            fclRagShopTable.fclRagItemTbl[19].Rate[0].ItemID = 99;
            fclRagShopTable.fclRagItemTbl[19].Rate[0].Nums = 1;
            fclRagShopTable.fclRagItemTbl[19].Rate[1].ItemID = 108;
            fclRagShopTable.fclRagItemTbl[19].Rate[1].Nums = 1;

            fclRagShopTable.fclRagItemTbl[20].ItemID = 63;
            fclRagShopTable.fclRagItemTbl[20].Rate[0].ItemID = 96;
            fclRagShopTable.fclRagItemTbl[20].Rate[0].Nums = 2;
            fclRagShopTable.fclRagItemTbl[20].Rate[1].ItemID = 97;
            fclRagShopTable.fclRagItemTbl[20].Rate[1].Nums = 2;
            fclRagShopTable.fclRagItemTbl[20].Rate[2].ItemID = 99;
            fclRagShopTable.fclRagItemTbl[20].Rate[2].Nums = 1;

            fclRagShopTable.fclRagItemTbl[21].ItemID = 86;
            fclRagShopTable.fclRagItemTbl[21].Rate[0].ItemID = 99;
            fclRagShopTable.fclRagItemTbl[21].Rate[0].Nums = 2;
            fclRagShopTable.fclRagItemTbl[21].Rate[1].ItemID = 101;
            fclRagShopTable.fclRagItemTbl[21].Rate[1].Nums = 3;
            fclRagShopTable.fclRagItemTbl[21].Rate[2].ItemID = 105;
            fclRagShopTable.fclRagItemTbl[21].Rate[2].Nums = 4;
        }

        //------------------------------------------------------------

        private static void ApplyItemBoxChanges()
        {
            //fldGlobal.fldHitData._fldItemBoxTbl[335]._Param = int.MaxValue;
            //fldGlobal.fldHitData._fldItemBoxTbl[335]._Type = 2;
            //fldGlobal.fldHitData._fldItemBoxTbl[335]._ItemID = 0;
            //fldGlobal.fldHitData._fldItemBoxTbl[335]._ItemNum = 0;
            //fldGlobal.fldHitData._fldItemBoxTbl[335]._Trap = 1;
            //fldGlobal.fldHitData._fldItemBoxTbl[335]._Param = 451;

            //fldGlobal.fldHitData._fldNpcUp[52]._model_id2 = 74;

            //fldGlobal.fldHitData._fldItemBoxTbl[20]._Param = 9000000;

            // First Item Box in Amala Network 1 (Needle Orbs)
            fldGlobal.fldHitData._fldItemBoxTbl[22]._ItemID = 29;
            fldGlobal.fldHitData._fldItemBoxTbl[22]._ItemNum = 2;

            // First Item Box in Treasure Room in Amala Network 1 (Megido Rock)
            fldGlobal.fldHitData._fldItemBoxTbl[27]._ItemID = 27;

            // Medusa Eye Item Box in Underpass Manikin Hideout
            fldGlobal.fldHitData._fldItemBoxTbl[40]._ItemID = 32;

            // Dekaja Rock Item Box in Underpass before Matador
            fldGlobal.fldHitData._fldItemBoxTbl[42]._ItemID = 36;
            fldGlobal.fldHitData._fldItemBoxTbl[42]._ItemNum = 1;

            // New Item Box outside Shibuya
            fldGlobal.fldHitData._fldItemBoxTbl[335]._ItemID = 47;
            fldGlobal.fldHitData._fldItemBoxTbl[335]._ItemNum = 5;
        }
    }
}
