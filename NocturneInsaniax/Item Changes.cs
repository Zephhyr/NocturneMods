﻿using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2Cppnewbattle_H;
using Il2Cppeffect_H;
using UnityEngine;
using Il2Cppfield_H;

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
                    case 44: __result = "Graven Image"; return false;
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
                    case 64: __result = "Marogareh"; return false;
                    case 65: __result = "Wadatsumi"; return false;
                    case 66: __result = "Ankh"; return false;
                    case 67: __result = "Iyomante"; return false;
                    case 68: __result = "Shiranui"; return false;
                    case 69: __result = "Hifumi"; return false;
                    case 70: __result = "Kamurogi"; return false;
                    case 71: __result = "Kamudo"; return false;
                    case 72: __result = "Anathema"; return false;
                    case 73: __result = "Miasma"; return false;
                    case 74: __result = "Nirvana"; return false;
                    case 75: __result = "Vimana"; return false;
                    case 76: __result = "Geis"; return false;
                    case 77: __result = "Djed"; return false;
                    case 78: __result = "Muspell"; return false;
                    case 79: __result = "Satan"; return false;
                    case 80: __result = "Adama"; return false;
                    case 81: __result = "Gehenna"; return false;
                    case 82: __result = "Sophia"; return false;
                    case 83: __result = "Murakumo"; return false;
                    case 84: __result = "Gundari"; return false;
                    case 85: __result = "Narukami"; return false;
                    case 86: __result = "Gaea"; return false;
                    case 87: __result = "Kailash"; return false;
                    case 88: __result = "Masakados"; return false;
                    case 107: __result = "Malachite"; return false;
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
                    case 1: __result = "Recovers an ally's HP or MP. \nMay cause side effects."; return false; // Muscle Drink
                    case 2: __result = "Fixed HP recovery for one ally."; return false; // Medicine
                    case 3: __result = "Moderate HP recovery for one ally."; return false; // Life Stone
                    case 4: __result = "Full HP recovery for one ally."; return false; // Bead
                    case 5: __result = "Full HP recovery for all allies."; return false; // Bead Chain
                    case 6: __result = "Fixed MP recovery for one ally."; return false; // Chakra Drop
                    case 7: __result = "Full MP recovery for one ally."; return false; // Chakra Pot
                    case 8: __result = "Full MP recovery for all allies."; return false; // Great Chakra
                    case 9: __result = "Moderate HP/MP recovery for one ally."; return false; // Soma Droplet
                    case 10: __result = "Full HP/MP recovery for one ally."; return false; // Soma
                    case 11: __result = "Full HP/MP recovery for all allies."; return false; // Bead of Life
                    case 12: __result = "Slight MP recovery for one ally. \nReusable."; return false; // Chakra Elixir
                    case 15: __result = "Cures Bind/Sleep/Panic \nfor all allies."; return false; // Sacred Water
                    case 21: __result = "Low Fire damage to all foes. \nPow: 24, Acc: 100%"; return false; // Maragi Rock
                    case 22: __result = "Low Ice damage to all foes. \nPow: 20, Acc: 100%, Freeze: 12%"; return false; // Mabufu Rock
                    case 23: __result = "Low Elec damage to all foes. \nPow: 20, Acc: 100%, Shock: 12%"; return false; // Mazio Rock
                    case 24: __result = "Low Force damage to all foes. \nPow: 24, Acc: 100%"; return false; // Mazan Rock
                    case 25: __result = "Low Light damage to all foes. \nMay instakill when weak to Light. \nPow: 30, Acc: 100%, Fatal: 20%"; return false; // Mahama Rock
                    case 26: __result = "Low Dark damage to all foes. \nMay instakill when weak to Dark. \nPow: 30, Acc: 100%, Fatal: 20%"; return false; // Mamudo Rock
                    case 27: __result = "Medium Almighty damage to all foes. \nPow: 36, Acc: 100%"; return false; // Megido Rock
                    case 28: __result = "Med-High Almighty damage to all foes. \nPow: 42, Acc: 100%"; return false; // Megidola Rock
                    case 29: __result = "Low Shot damage to random foes. \n2-5 hits. Pow: 22, Acc: 90%, \nCrit: 18%"; return false; // Needle Orb
                    case 31: __result = "50% Chance to inflict Mute \non one foe. (Curse-Type)"; return false; // Makajam Rock
                    case 32: __result = "60% Chance to inflict Stone \non one foe. (Dark-Type)"; return false; // Medusa Eye
                    case 33: __result = "Negates -nda effects on all allies."; return false; // Dekunda Rock
                    case 34: __result = "Repels Magical attacks \nfor one ally once \nnext turn."; return false; // Magic Mirror
                    case 35: __result = "Repels Physical attacks \nfor one ally once \nnext turn."; return false; // Attack Mirror
                    case 36: __result = "Negates -kaja effects on all foes."; return false; // Dekaja Rock
                    case 37: __result = "Negates one Light/Dark attack \nfor all allies."; return false; // Tetraja Rock
                    case 44: __result = "Great HP recovery for one ally. \nReusable."; return false; // Graven Image
                    case 47: __result = "Displays an enemy's info."; return false; // Spyglass
                    case 48: __result = "Medium Fire damage to one foe. \nPow: 45, Acc: 100%"; return false; // Agilao Rock
                    case 49: __result = "Medium Ice damage to one foe. \nPow: 39, Acc: 100%, Freeze: 25%"; return false; // Bufula Rock
                    case 50: __result = "Medium Elec damage to one foe. \nPow: 39, Acc: 100%, Shock: 25%"; return false; // Zionga Rock
                    case 51: __result = "Medium Force damage to one foe. \nPow: 45, Acc: 100%"; return false; // Zanma Rock
                    case 57: __result = "Passes the time \nuntil the next new \nor full Kagutsuchi."; return false; // Hourglass
                    case 59: __result = "Increases the damage of the user's \nnext Strength-based attack by 120%."; return false; // Focus Rock
                    case 60: __result = "Increases the damage of the user's \nnext Magic-based attack by 120%."; return false; // Concentrate Rock
                    case 62: __result = "Demi-fiend earns enough \nEXP to level up but \nloses one level."; return false; // Cursed Gospel
                    case 63: __result = "Grants four flashing turn icons. \n(Limit: 1)"; return false; // Impel Stone
                    case 76: __result = "Ice-type Magatama."; return false; // Geis
                    case 80: __result = "Ailment-type Magatama. \n"; return false; // Adama
                    case 83: __result = "Force-type Magatama. \n"; return false; // Murakumo
                    case 85: __result = "Elec-type Magatama. \n"; return false; // Narukami
                    case 86: __result = "Physical-type Magatama."; return false; // Gaea
                    case 107: __result = "A beautiful gemstone \nthat symbolizes \nearth."; return false; // Malachite
                    default: return true;
                }
            }

            [HarmonyPatch(typeof(fclShopCalc), nameof(fclShopCalc.shpCreateItemList))]
            private class ShopItemsPatch
            {
                public static void Postfix(ref fclDataShop_t pData)
                {
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
            GravenImage(44);
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

            VimanaItem(75);
            GeisItem(76);
            AdamaItem(80);
            MurakumoItem(83);
            NarukamiItem(85);
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

        private static void GravenImage(ushort id)
        {
            datItem.tbl[id].skillid = 37;
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

        private static void VimanaItem(ushort id)
        {
            datItem.tbl[id].price = 20000;
        }

        private static void GeisItem(ushort id)
        {
            datItem.tbl[id].price = 30000;
        }

        private static void AdamaItem(ushort id)
        {
            datItem.tbl[id].price = 40000;
        }

        private static void MurakumoItem(ushort id)
        {
            datItem.tbl[id].price = 80000;
        }

        private static void NarukamiItem(ushort id)
        {
            datItem.tbl[id].price = 100000;
        }

        //------------------------------------------------------------

        private static void ApplyShopChanges()
        {
            ShibuyaShop(1);
            AsakusaShop(4);
            CollectorShop(5);
            RagShop();
        }

        private static void ShibuyaShop(ushort id)
        {
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[5].ID = 47; // Spyglass
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[6].ID = 57; // Hourglass
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[7].ID = 67; // Iyomante
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[8].ID = 68; // Shiranui
        }

        private static void AsakusaShop(ushort id)
        {
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[2].ID = 48; // Agilao Rock
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[3].ID = 49; // Bufula Rock
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[4].ID = 50; // Zionga Rock
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[5].ID = 51; // Zanma Rock
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[6].ID = 25; // Mahama Rock
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[7].ID = 26; // Mamudo Rock
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[8].ID = 55; // Light Ball
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[9].ID = 54; // Float Ball
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[10].ID = 74; // Nirvana
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[11].ID = 75; // Vimana
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[12].ID = 0;
        }

        private static void CollectorShop(ushort id)
        {
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[5].ID = 76; // Geis
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[6].ID = 80; // Adama
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[7].ID = 83; // Murakumo
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[8].ID = 85; // Narukami
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
            fclRagShopTable.fclRagItemTbl[21].Rate[0].ItemID = 96;
            fclRagShopTable.fclRagItemTbl[21].Rate[0].Nums = 3;
            fclRagShopTable.fclRagItemTbl[21].Rate[1].ItemID = 101;
            fclRagShopTable.fclRagItemTbl[21].Rate[1].Nums = 3;
            fclRagShopTable.fclRagItemTbl[21].Rate[2].ItemID = 107;
            fclRagShopTable.fclRagItemTbl[21].Rate[2].Nums = 1;
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

            // Chakra Pot Item Box in Ikebukuro Tunnel
            fldGlobal.fldHitData._fldItemBoxTbl[94]._ItemNum = 3;

            // Dekunda Item Box in Ikebukuro Tunnel
            fldGlobal.fldHitData._fldItemBoxTbl[95]._ItemID = 33;

            // Bead Item Box in Ikebukuro Tunnel
            fldGlobal.fldHitData._fldItemBoxTbl[95]._ItemID = 4;

            // Bead Item Box in Ikebukuro Tunnel
            fldGlobal.fldHitData._fldItemBoxTbl[103]._ItemID = 5;

            // New Item Box outside Shibuya
            fldGlobal.fldHitData._fldItemBoxTbl[335]._ItemID = 47;
            fldGlobal.fldHitData._fldItemBoxTbl[335]._ItemNum = 5;

            // New Item Box outside Ikebukuro
            fldGlobal.fldHitData._fldItemBoxTbl[336]._ItemID = 59;
            fldGlobal.fldHitData._fldItemBoxTbl[336]._ItemNum = 2;

            // Item Box surrounded by damage-floor near Ikebukuro
            fldGlobal.fldHitData._fldItemBoxTbl[236]._ItemNum = 10;

            // Medicine Item Box in treasure room in Back of Nihilo
            fldGlobal.fldHitData._fldItemBoxTbl[88]._ItemNum = 10;

            // Bead Item Box in treasure room in Back of Nihilo
            fldGlobal.fldHitData._fldItemBoxTbl[89]._ItemNum = 3;

            // Tetraja Rock Item Box in treasure room in Back of Nihilo
            fldGlobal.fldHitData._fldItemBoxTbl[80]._ItemNum = 3;

            // Life Stone Item Box outside the Obelisk
            fldGlobal.fldHitData._fldItemBoxTbl[238]._ItemNum = 10;

            // Macca Item Box outside the Obelisk
            fldGlobal.fldHitData._fldItemBoxTbl[170]._Param = 20000;

            // Concentrate Rock Item Box in Obelisk
            fldGlobal.fldHitData._fldItemBoxTbl[118]._ItemID = 60;
            fldGlobal.fldHitData._fldItemBoxTbl[118]._ItemNum = 3;

            // Chakra Drop Item Box in Obelisk
            fldGlobal.fldHitData._fldItemBoxTbl[120]._ItemNum = 5;

            // Dekunda Rock Item Box in Obelisk
            fldGlobal.fldHitData._fldItemBoxTbl[122]._ItemID = 33;
            fldGlobal.fldHitData._fldItemBoxTbl[122]._ItemNum = 3;

            // Dekaja Rock Item Box in Obelisk
            fldGlobal.fldHitData._fldItemBoxTbl[123]._ItemNum = 3;

            // Macca Item Box in Obelisk
            fldGlobal.fldHitData._fldItemBoxTbl[127]._Param = 18000;

            // Bead Item Box in Obelisk
            fldGlobal.fldHitData._fldItemBoxTbl[129]._ItemID = 4;
            fldGlobal.fldHitData._fldItemBoxTbl[129]._ItemNum = 2;

            // Great Chakra Item Box in Obelisk
            fldGlobal.fldHitData._fldItemBoxTbl[134]._ItemID = 8;

            // Dekunda Rock Item Box in Obelisk Treasure Room
            fldGlobal.fldHitData._fldItemBoxTbl[166]._ItemID = 33;
            fldGlobal.fldHitData._fldItemBoxTbl[166]._ItemNum = 10;

            // Malachite Item Box in Obelisk Treasure Room
            fldGlobal.fldHitData._fldItemBoxTbl[135]._ItemID = 107;

            // Eternal Spyglass Item Box in Obelisk Treasure Room
            fldGlobal.fldHitData._fldItemBoxTbl[136]._Trap = 0;
            fldGlobal.fldHitData._fldItemBoxTbl[136]._ItemID = 46;
            fldGlobal.fldHitData._fldItemBoxTbl[136]._ItemNum = 1;

            // Dekunda Rock Item Box in Obelisk Treasure Room
            fldGlobal.fldHitData._fldItemBoxTbl[137]._ItemID = 36;
            fldGlobal.fldHitData._fldItemBoxTbl[137]._ItemNum = 10;

            // Dekunda Rock Item Box in Obelisk Treasure Room
            fldGlobal.fldHitData._fldItemBoxTbl[131]._ItemID = 10;

            // Cursed Gospel Item Box in Amala Network 2
            fldGlobal.fldHitData._fldItemBoxTbl[138]._ItemID = 62;

            // Soma Droplet Item Box in Amala Network 2
            fldGlobal.fldHitData._fldItemBoxTbl[139]._ItemID = 10;

            // Bead Item Box in Amala Network 2
            fldGlobal.fldHitData._fldItemBoxTbl[140]._ItemID = 4;

            // Bead Item Box in Amala Network 2
            fldGlobal.fldHitData._fldItemBoxTbl[142]._ItemID = 7;

            // Macca Box in Asakusa
            fldGlobal.fldHitData._fldItemBoxTbl[111]._Param = 20000;

            // Bead Box in Asakusa Tunnel
            fldGlobal.fldHitData._fldItemBoxTbl[147]._ItemID = 4;

            // Macca Box in Asakusa Tunnel
            fldGlobal.fldHitData._fldItemBoxTbl[146]._Param = 10000;

            // Life Stone Item Box in Yoyogi Park
            fldGlobal.fldHitData._fldItemBoxTbl[165]._ItemNum = 5;

            // Macca Box in Overworld 6
            fldGlobal.fldHitData._fldItemBoxTbl[14]._Param = 10000;

            // Macca Box in Diet Building
            fldGlobal.fldHitData._fldItemBoxTbl[200]._Param = 30000;

            // Great Chakra Item Box in First Kalpa
            fldGlobal.fldHitData._fldItemBoxTbl[256]._ItemID = 8;

            // Bead Chain Item Box in First Kalpa
            fldGlobal.fldHitData._fldItemBoxTbl[257]._ItemID = 5;

            // Bead Chain Item Box in First Kalpa
            fldGlobal.fldHitData._fldItemBoxTbl[261]._ItemID = 5;

            // Great Chakra Item Box in Second Kalpa
            fldGlobal.fldHitData._fldItemBoxTbl[276]._ItemID = 8;

            // Macca Item Box in Fourth Kalpa
            fldGlobal.fldHitData._fldItemBoxTbl[325]._Param = 666666;

            // Satan Magatama Box behind Ongyo-Ki
            fldGlobal.fldHitData._fldItemBoxTbl[104]._ItemID = 16;

            // Kailash Magatama Box behind Mitra
            fldGlobal.fldHitData._fldItemBoxTbl[337]._Type = 2;
            fldGlobal.fldHitData._fldItemBoxTbl[337]._ItemID = 24;
            fldGlobal.fldHitData._fldItemBoxTbl[337]._ItemNum = 1;

            // Boss Cerberus Box
            fldGlobal.fldHitData._fldItemBoxTbl[348]._Type = 2;
            fldGlobal.fldHitData._fldItemBoxTbl[348]._ItemID = 0;
            fldGlobal.fldHitData._fldItemBoxTbl[348]._ItemNum = 0;
            fldGlobal.fldHitData._fldItemBoxTbl[348]._Trap = 1;
            fldGlobal.fldHitData._fldItemBoxTbl[348]._Param = 1275;

            // Boss Cerberus Box
            fldGlobal.fldHitData._fldItemBoxTbl[349]._Type = 2;
            fldGlobal.fldHitData._fldItemBoxTbl[349]._ItemID = 0;
            fldGlobal.fldHitData._fldItemBoxTbl[349]._ItemNum = 0;
            fldGlobal.fldHitData._fldItemBoxTbl[349]._Trap = 1;
            fldGlobal.fldHitData._fldItemBoxTbl[349]._Param = 1276;

            // Boss Flauros Box
            fldGlobal.fldHitData._fldItemBoxTbl[350]._Type = 2;
            fldGlobal.fldHitData._fldItemBoxTbl[350]._ItemID = 0;
            fldGlobal.fldHitData._fldItemBoxTbl[350]._ItemNum = 0;
            fldGlobal.fldHitData._fldItemBoxTbl[350]._Trap = 1;
            fldGlobal.fldHitData._fldItemBoxTbl[350]._Param = 1277;

            // YHVH Box
            fldGlobal.fldHitData._fldItemBoxTbl[351]._Type = 2;
            fldGlobal.fldHitData._fldItemBoxTbl[351]._ItemID = 0;
            fldGlobal.fldHitData._fldItemBoxTbl[351]._ItemNum = 0;
            fldGlobal.fldHitData._fldItemBoxTbl[351]._Trap = 1;
            fldGlobal.fldHitData._fldItemBoxTbl[351]._Param = 672; //1278; //1035;

            //fldGlobal.fldHitData._fldItemBoxTbl.Add(new fldTakaraTbl_t { _ItemID = 47, _ItemNum = 5 });
        }
    }
}
