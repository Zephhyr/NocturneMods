using HarmonyLib;
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
                    case 39: __result = "Intelligence Incense"; return false;
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
                    case 38: __result = "Raises Strength by 2 \nand full HP recovery \nfor one ally."; return false; // Strength Incense
                    case 39: __result = "Raises Intelligence by 2 \nand full HP recovery \nfor one ally."; return false; // Intelligence Incense
                    case 40: __result = "Raises Magic by 2 \nand full HP recovery \nfor one ally."; return false; // Magic Incense
                    case 41: __result = "Raises Vitality by 2 \nand full HP recovery \nfor one ally."; return false; // Vitality Incense
                    case 42: __result = "Raises Agility by 2 \nand full HP recovery \nfor one ally."; return false; // Agility Incense
                    case 43: __result = "Raises Luck by 2 \nand full HP recovery \nfor one ally."; return false; // Luck Incense
                    case 44: __result = "Great HP recovery for one ally. \nReusable."; return false; // Graven Image
                    case 46: __result = "Displays an enemy's info \nat 1/2 turn cost \nReusable."; return false; // Spyglass
                    case 47: __result = "Displays an enemy's info \nat 1/2 turn cost."; return false; // Spyglass
                    case 48: __result = "Medium Fire damage to one foe. \nPow: 45, Acc: 100%"; return false; // Agilao Rock
                    case 49: __result = "Medium Ice damage to one foe. \nPow: 39, Acc: 100%, Freeze: 25%"; return false; // Bufula Rock
                    case 50: __result = "Medium Elec damage to one foe. \nPow: 39, Acc: 100%, Shock: 25%"; return false; // Zionga Rock
                    case 51: __result = "Medium Force damage to one foe. \nPow: 45, Acc: 100%"; return false; // Zanma Rock
                    case 57: __result = "Passes the time \nuntil the next new \nor full Kagutsuchi."; return false; // Hourglass
                    case 59: __result = "Increases the damage of the user's \nnext Strength-based attack by 120%."; return false; // Focus Rock
                    case 60: __result = "Increases the damage of the user's \nnext Magic-based attack by 120%."; return false; // Concentrate Rock
                    case 62: __result = "Grants " + frName.frGetCNameString(0) + " enough \nEXP to level up but reduces \nlevel by one."; return false; // Cursed Gospel
                    case 63: __result = "Grants four flashing turn icons. \n(Limit: 1)"; return false; // Impel Stone
                    case 64: __result = "Neutral Magatama \nImparts basic skills \nNormal resistance"; return false; // Marogareh
                    case 65: __result = "Ice-type Magatama \nImparts Ice magic & potential \n<material=\"MsgFont2\">Null: Ice<material=\"MsgFont0\">  <material=\"MsgFont1\">Weak: Elec"; return false; // Wadatsumi
                    case 66: __result = "Healing-type Magatama \nImparts Healing magic & potential \n<material=\"MsgFont2\">Null: Light<material=\"MsgFont0\">  <material=\"MsgFont1\">Weak: Dark"; return false; // Ankh
                    case 67: __result = "Support-type Magatama \nImparts Support magic & potential \n<material=\"MsgFont2\">Null: Mind"; return false; // Iyomante
                    case 68: __result = "Fire-type Magatama \nImparts Fire magic & potential \n<material=\"MsgFont2\">Null: Fire<material=\"MsgFont0\">  <material=\"MsgFont1\">Weak: Force"; return false; // Shiranui
                    case 69: __result = "Force-type Magatama \nImparts Force magic & potential \n<material=\"MsgFont2\">Null: Force<material=\"MsgFont0\">  <material=\"MsgFont1\">Weak: Fire"; return false; // Hifumi
                    case 70: __result = "Physical-type Magatama \nImparts Physical skills & potential \n<material=\"MsgFont2\">Strong: Phys/Shot<material=\"MsgFont0\">  <material=\"MsgFont1\">Weak: Ailments"; return false; // Kamurogi
                    case 71: __result = "Elec-type Magatama \nImparts Electricity magic & potential \n<material=\"MsgFont2\">Null: Elec<material=\"MsgFont0\">  <material=\"MsgFont1\">Weak: Ice"; return false; // Kamudo
                    case 72: __result = "Dark-type Magatama \nImparts Dark magic & potential \n<material=\"MsgFont2\">Null: Dark<material=\"MsgFont0\">  <material=\"MsgFont1\">Weak: Light"; return false; // Anathema
                    case 73: __result = "Ailment-type Magatama \nImparts Ailment magic & potential \n<material=\"MsgFont2\">Strong: Ailments<material=\"MsgFont0\">  <material=\"MsgFont1\">Weak: Shot"; return false; // Miasma
                    case 74: __result = "Light-type Magatama \nImparts Light magic & potential \n<material=\"MsgFont2\">Null: Light<material=\"MsgFont0\">  <material=\"MsgFont1\">Weak: Dark"; return false; // Nirvana
                    case 75: __result = "Shot-type Magatama \nImparts Shot skills & potential \n<material=\"MsgFont2\">Strong: Phys/Shot<material=\"MsgFont0\">  <material=\"MsgFont1\">Weak: Fire/Ice"; return false; // Vimana
                    case 76: __result = "Ice-type Magatama \nImparts Ice magic & potential \n<material=\"MsgFont2\">Drain: Ice<material=\"MsgFont0\">  <material=\"MsgFont1\">Weak: Fire"; return false; // Geis
                    case 77: __result = "Support-type Magatama \nImparts Support magic & potential \n<material=\"MsgFont2\">Null: Curse"; return false; // Djed
                    case 78: __result = "Fire-type Magatama \nImparts Fire magic & potential \n<material=\"MsgFont2\">Drain: Fire<material=\"MsgFont0\">  <material=\"MsgFont1\">Weak: Ice"; return false; // Muspell
                    case 79: __result = "Almighty-type Magatama \nImparts Almighty magic & potential \n<material=\"MsgFont2\">Null: Dark"; return false; // Satan
                    case 80: __result = "Ailment-type Magatama. \nImparts Ailment magic & potential \n<material=\"MsgFont2\">Null: Ailments<material=\"MsgFont0\">  <material=\"MsgFont1\">Weak: Light/Dark"; return false; // Adama
                    case 81: __result = "Dark-type Magatama. \nImparts Dark magic & potential \n<material=\"MsgFont2\">Repel: Dark"; return false; // Gehenna
                    case 82: __result = "Healing-type Magatama. \nImparts Healing magic & potential \n<material=\"MsgFont2\">Null: Nerve"; return false; // Sophia
                    case 83: __result = "Force-type Magatama. \nImparts Force magic & potential \n<material=\"MsgFont2\">Repel: Force<material=\"MsgFont0\">  <material=\"MsgFont1\">Weak: Elec"; return false; // Murakumo
                    case 84: __result = "Light-type Magatama. \nImparts Light magic & potential \n<material=\"MsgFont2\">Repel: Light"; return false; // Gundari
                    case 85: __result = "Elec-type Magatama. \nImparts Electricity magic & potential \n<material=\"MsgFont2\">Repel: Elec<material=\"MsgFont0\">  <material=\"MsgFont1\">Weak: Force"; return false; // Narukami
                    case 86: __result = "Physical/Shot-type Magatama. \nImparts Phys/Shot skills & potential \n<material=\"MsgFont2\">Strong: Phys/Shot<material=\"MsgFont0\">  <material=\"MsgFont1\">Weak: Elec/Force"; return false; // Gaea
                    case 87: __result = "Almighty-type Magatama. \nImparts Almighty magic & potential \n<material=\"MsgFont2\">Strong: Light/Dark"; return false; // Kailash
                    case 88: __result = "Magatama that holds ultimate power \n<material=\"MsgFont2\">Strong: All except Almighty"; return false; // Masakados
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

            [HarmonyPatch(typeof(cmpMisc), nameof(cmpMisc.cmpUseItemKou))]
            private class PatchIncense
            {
                private static bool Prefix(ushort ItemID, datUnitWork_t pStock)
                {
                    // Checks the currently used item's ID and make sure it's the Stat Incense items.
                    if (ItemID > 0x25 && ItemID < 0x2c)
                    {
                        // Set the Stat ID relative to the current Incense.
                        int statID = ItemID - 0x26;

                        // Increases the target's stat if it isn't above the maximum, then recalculates HP/MP and heals them.
                        if (datCalc.datGetBaseParam(pStock, statID) < MAXSTATS)
                        {
                            pStock.param[statID] = (sbyte)Math.Min(pStock.param[statID] + 2, MAXSTATS);
                            while (pStock.param[statID] + pStock.mitamaparam[statID] > MAXSTATS)
                                pStock.mitamaparam[statID]--;

                            pStock.maxhp = (ushort)datCalc.datGetMaxHp(pStock);
                            pStock.maxmp = (ushort)datCalc.datGetMaxMp(pStock);
                            pStock.hp = pStock.maxhp;
                            pStock.mp = (ushort)Math.Clamp(pStock.mp, 0u, pStock.maxmp);
                            return false;
                        }
                    }
                    return true;
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
            IntelligenceIncense(39);
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
            datItem.tbl[id].skillid = 93;
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

        private static void IntelligenceIncense(ushort id)
        {
            datItem.tbl[id].flag = 4;
            datItem.tbl[id].price = 2000;
            datItem.tbl[id].skillid = 0;
            datItem.tbl[id].use = 1;
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
            datItem.tbl[id].price = 5000;
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
            TowerOfKagutsuchiShop(6);
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

        private static void TowerOfKagutsuchiShop(ushort id)
        {
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[0].ID = 2; // Medicine
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[1].ID = 13; // Revival Bead
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[2].ID = 16; // Dis-Poison
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[3].ID = 17; // Dis-Stun
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[4].ID = 18; // Dis-Charm
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[5].ID = 20; // Dis-Stone
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[6].ID = 19; // Dis-Mute
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[7].ID = 15; // Sacred Water
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[8].ID = 6; // Chakra Drop
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[9].ID = 55; // Light Ball
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[10].ID = 54; // Float Ball
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[11].ID = 29; // Needle Orb
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[12].ID = 48; // Agilao Rock
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[13].ID = 49; // Bufula Rock
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[14].ID = 50; // Zionga Rock
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[15].ID = 51; // Zanma Rock
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[16].ID = 25; // Mahama Rock
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[17].ID = 26; // Mamudo Rock
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[18].ID = 31; // Makajam Rock
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[19].ID = 30; // Wagtail Plume
            fclJunkShopTable.fclShopItemPackTbl[id].ItemList[20].ID = 62; // Cursed Gospel
        }

        private static void RagShop()
        {
            fclRagShopTable.fclRagItemPackTbl[1] = new byte[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            fclRagShopTable.fclRagItemTbl[8].ItemID = 32;
            fclRagShopTable.fclRagItemTbl[8].Rate[0].ItemID = 104;
            fclRagShopTable.fclRagItemTbl[8].Rate[0].Nums = 1;
            fclRagShopTable.fclRagItemTbl[8].Rate[1].ItemID = 110;
            fclRagShopTable.fclRagItemTbl[8].Rate[1].Nums = 1;

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

            // Flaemis
            fclRagShopTable.fclRagSeireiTbl[1].Param.Param[0] = 23;
            fclRagShopTable.fclRagSeireiTbl[1].Param.Param[1] = 30;
            fclRagShopTable.fclRagSeireiTbl[1].Param.Param[2] = 29;
            fclRagShopTable.fclRagSeireiTbl[1].Param.Param[3] = 15;
            fclRagShopTable.fclRagSeireiTbl[1].Param.Param[4] = 14;
            fclRagShopTable.fclRagSeireiTbl[1].Param.Param[5] = 17;
            fclRagShopTable.fclRagSeireiTbl[1].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[1].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[1].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[1].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[1].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[1].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[1].Param.Skill[0] = 4;
            fclRagShopTable.fclRagSeireiTbl[1].Param.Skill[1] = 300;
            fclRagShopTable.fclRagSeireiTbl[1].Param.Skill[2] = 67;

            fclRagShopTable.fclRagSeireiTbl[2].Param.Param[0] = 23;
            fclRagShopTable.fclRagSeireiTbl[2].Param.Param[1] = 32;
            fclRagShopTable.fclRagSeireiTbl[2].Param.Param[2] = 30;
            fclRagShopTable.fclRagSeireiTbl[2].Param.Param[3] = 15;
            fclRagShopTable.fclRagSeireiTbl[2].Param.Param[4] = 14;
            fclRagShopTable.fclRagSeireiTbl[2].Param.Param[5] = 17;
            fclRagShopTable.fclRagSeireiTbl[2].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[2].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[2].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[2].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[2].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[2].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[2].Param.Skill[0] = 4;
            fclRagShopTable.fclRagSeireiTbl[2].Param.Skill[1] = 300;
            fclRagShopTable.fclRagSeireiTbl[2].Param.Skill[2] = 67;
            fclRagShopTable.fclRagSeireiTbl[2].Param.Skill[3] = 39;

            fclRagShopTable.fclRagSeireiTbl[3].Param.Param[0] = 25;
            fclRagShopTable.fclRagSeireiTbl[3].Param.Param[1] = 33;
            fclRagShopTable.fclRagSeireiTbl[3].Param.Param[2] = 30;
            fclRagShopTable.fclRagSeireiTbl[3].Param.Param[3] = 15;
            fclRagShopTable.fclRagSeireiTbl[3].Param.Param[4] = 14;
            fclRagShopTable.fclRagSeireiTbl[3].Param.Param[5] = 17;
            fclRagShopTable.fclRagSeireiTbl[3].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[3].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[3].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[3].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[3].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[3].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[3].Param.Skill[0] = 4;
            fclRagShopTable.fclRagSeireiTbl[3].Param.Skill[1] = 300;
            fclRagShopTable.fclRagSeireiTbl[3].Param.Skill[2] = 67;
            fclRagShopTable.fclRagSeireiTbl[3].Param.Skill[3] = 39;
            fclRagShopTable.fclRagSeireiTbl[3].Param.Skill[4] = 332;

            fclRagShopTable.fclRagSeireiTbl[4].Param.Param[0] = 23;
            fclRagShopTable.fclRagSeireiTbl[4].Param.Param[1] = 32;
            fclRagShopTable.fclRagSeireiTbl[4].Param.Param[2] = 30;
            fclRagShopTable.fclRagSeireiTbl[4].Param.Param[3] = 15;
            fclRagShopTable.fclRagSeireiTbl[4].Param.Param[4] = 14;
            fclRagShopTable.fclRagSeireiTbl[4].Param.Param[5] = 17;
            fclRagShopTable.fclRagSeireiTbl[4].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[4].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[4].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[4].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[4].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[4].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[4].Param.Skill[0] = 4;
            fclRagShopTable.fclRagSeireiTbl[4].Param.Skill[1] = 300;
            fclRagShopTable.fclRagSeireiTbl[4].Param.Skill[2] = 369;
            fclRagShopTable.fclRagSeireiTbl[4].Param.Skill[3] = 39;

            fclRagShopTable.fclRagSeireiTbl[5].Param.Param[0] = 25;
            fclRagShopTable.fclRagSeireiTbl[5].Param.Param[1] = 33;
            fclRagShopTable.fclRagSeireiTbl[5].Param.Param[2] = 30;
            fclRagShopTable.fclRagSeireiTbl[5].Param.Param[3] = 15;
            fclRagShopTable.fclRagSeireiTbl[5].Param.Param[4] = 14;
            fclRagShopTable.fclRagSeireiTbl[5].Param.Param[5] = 17;
            fclRagShopTable.fclRagSeireiTbl[5].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[5].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[5].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[5].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[5].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[5].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[5].Param.Skill[0] = 4;
            fclRagShopTable.fclRagSeireiTbl[5].Param.Skill[1] = 300;
            fclRagShopTable.fclRagSeireiTbl[5].Param.Skill[2] = 369;
            fclRagShopTable.fclRagSeireiTbl[5].Param.Skill[3] = 39;
            fclRagShopTable.fclRagSeireiTbl[5].Param.Skill[4] = 332;

            // Aquans
            fclRagShopTable.fclRagSeireiTbl[6].Param.Param[0] = 15;
            fclRagShopTable.fclRagSeireiTbl[6].Param.Param[1] = 19;
            fclRagShopTable.fclRagSeireiTbl[6].Param.Param[2] = 25;
            fclRagShopTable.fclRagSeireiTbl[6].Param.Param[3] = 15;
            fclRagShopTable.fclRagSeireiTbl[6].Param.Param[4] = 15;
            fclRagShopTable.fclRagSeireiTbl[6].Param.Param[5] = 19;
            fclRagShopTable.fclRagSeireiTbl[6].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[6].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[6].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[6].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[6].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[6].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[6].Param.Skill[0] = 65;
            fclRagShopTable.fclRagSeireiTbl[6].Param.Skill[1] = 318;
            fclRagShopTable.fclRagSeireiTbl[6].Param.Skill[2] = 10;

            fclRagShopTable.fclRagSeireiTbl[7].Param.Param[0] = 15;
            fclRagShopTable.fclRagSeireiTbl[7].Param.Param[1] = 20;
            fclRagShopTable.fclRagSeireiTbl[7].Param.Param[2] = 25;
            fclRagShopTable.fclRagSeireiTbl[7].Param.Param[3] = 15;
            fclRagShopTable.fclRagSeireiTbl[7].Param.Param[4] = 15;
            fclRagShopTable.fclRagSeireiTbl[7].Param.Param[5] = 21;
            fclRagShopTable.fclRagSeireiTbl[7].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[7].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[7].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[7].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[7].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[7].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[7].Param.Skill[0] = 65;
            fclRagShopTable.fclRagSeireiTbl[7].Param.Skill[1] = 318;
            fclRagShopTable.fclRagSeireiTbl[7].Param.Skill[2] = 10;
            fclRagShopTable.fclRagSeireiTbl[7].Param.Skill[3] = 321;

            fclRagShopTable.fclRagSeireiTbl[8].Param.Param[0] = 15;
            fclRagShopTable.fclRagSeireiTbl[8].Param.Param[1] = 21;
            fclRagShopTable.fclRagSeireiTbl[8].Param.Param[2] = 27;
            fclRagShopTable.fclRagSeireiTbl[8].Param.Param[3] = 15;
            fclRagShopTable.fclRagSeireiTbl[8].Param.Param[4] = 15;
            fclRagShopTable.fclRagSeireiTbl[8].Param.Param[5] = 21;
            fclRagShopTable.fclRagSeireiTbl[8].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[8].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[8].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[8].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[8].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[8].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[8].Param.Skill[0] = 65;
            fclRagShopTable.fclRagSeireiTbl[8].Param.Skill[1] = 318;
            fclRagShopTable.fclRagSeireiTbl[8].Param.Skill[2] = 10;
            fclRagShopTable.fclRagSeireiTbl[8].Param.Skill[3] = 321;
            fclRagShopTable.fclRagSeireiTbl[8].Param.Skill[4] = 290;

            fclRagShopTable.fclRagSeireiTbl[9].Param.Param[0] = 15;
            fclRagShopTable.fclRagSeireiTbl[9].Param.Param[1] = 20;
            fclRagShopTable.fclRagSeireiTbl[9].Param.Param[2] = 25;
            fclRagShopTable.fclRagSeireiTbl[9].Param.Param[3] = 15;
            fclRagShopTable.fclRagSeireiTbl[9].Param.Param[4] = 15;
            fclRagShopTable.fclRagSeireiTbl[9].Param.Param[5] = 21;
            fclRagShopTable.fclRagSeireiTbl[9].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[9].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[9].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[9].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[9].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[9].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[9].Param.Skill[0] = 65;
            fclRagShopTable.fclRagSeireiTbl[9].Param.Skill[1] = 318;
            fclRagShopTable.fclRagSeireiTbl[9].Param.Skill[2] = 325;
            fclRagShopTable.fclRagSeireiTbl[9].Param.Skill[3] = 321;

            fclRagShopTable.fclRagSeireiTbl[10].Param.Param[0] = 15;
            fclRagShopTable.fclRagSeireiTbl[10].Param.Param[1] = 21;
            fclRagShopTable.fclRagSeireiTbl[10].Param.Param[2] = 27;
            fclRagShopTable.fclRagSeireiTbl[10].Param.Param[3] = 15;
            fclRagShopTable.fclRagSeireiTbl[10].Param.Param[4] = 15;
            fclRagShopTable.fclRagSeireiTbl[10].Param.Param[5] = 21;
            fclRagShopTable.fclRagSeireiTbl[10].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[10].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[10].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[10].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[10].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[10].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[10].Param.Skill[0] = 65;
            fclRagShopTable.fclRagSeireiTbl[10].Param.Skill[1] = 318;
            fclRagShopTable.fclRagSeireiTbl[10].Param.Skill[2] = 331;
            fclRagShopTable.fclRagSeireiTbl[10].Param.Skill[3] = 332;
            fclRagShopTable.fclRagSeireiTbl[10].Param.Skill[4] = 290;

            // Aeros
            fclRagShopTable.fclRagSeireiTbl[11].Param.Param[0] = 12;
            fclRagShopTable.fclRagSeireiTbl[11].Param.Param[1] = 20;
            fclRagShopTable.fclRagSeireiTbl[11].Param.Param[2] = 19;
            fclRagShopTable.fclRagSeireiTbl[11].Param.Param[3] = 15;
            fclRagShopTable.fclRagSeireiTbl[11].Param.Param[4] = 19;
            fclRagShopTable.fclRagSeireiTbl[11].Param.Param[5] = 12;
            fclRagShopTable.fclRagSeireiTbl[11].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[11].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[11].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[11].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[11].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[11].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[11].Param.Skill[0] = 36;
            fclRagShopTable.fclRagSeireiTbl[11].Param.Skill[1] = 19;
            fclRagShopTable.fclRagSeireiTbl[11].Param.Skill[2] = 64;

            fclRagShopTable.fclRagSeireiTbl[12].Param.Param[0] = 12;
            fclRagShopTable.fclRagSeireiTbl[12].Param.Param[1] = 20;
            fclRagShopTable.fclRagSeireiTbl[12].Param.Param[2] = 19;
            fclRagShopTable.fclRagSeireiTbl[12].Param.Param[3] = 15;
            fclRagShopTable.fclRagSeireiTbl[12].Param.Param[4] = 21;
            fclRagShopTable.fclRagSeireiTbl[12].Param.Param[5] = 13;
            fclRagShopTable.fclRagSeireiTbl[12].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[12].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[12].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[12].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[12].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[12].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[12].Param.Skill[0] = 36;
            fclRagShopTable.fclRagSeireiTbl[12].Param.Skill[1] = 19;
            fclRagShopTable.fclRagSeireiTbl[12].Param.Skill[2] = 64;
            fclRagShopTable.fclRagSeireiTbl[12].Param.Skill[3] = 59;

            fclRagShopTable.fclRagSeireiTbl[13].Param.Param[0] = 12;
            fclRagShopTable.fclRagSeireiTbl[13].Param.Param[1] = 21;
            fclRagShopTable.fclRagSeireiTbl[13].Param.Param[2] = 21;
            fclRagShopTable.fclRagSeireiTbl[13].Param.Param[3] = 15;
            fclRagShopTable.fclRagSeireiTbl[13].Param.Param[4] = 21;
            fclRagShopTable.fclRagSeireiTbl[13].Param.Param[5] = 13;
            fclRagShopTable.fclRagSeireiTbl[13].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[13].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[13].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[13].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[13].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[13].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[13].Param.Skill[0] = 36;
            fclRagShopTable.fclRagSeireiTbl[13].Param.Skill[1] = 19;
            fclRagShopTable.fclRagSeireiTbl[13].Param.Skill[2] = 64;
            fclRagShopTable.fclRagSeireiTbl[13].Param.Skill[3] = 59;
            fclRagShopTable.fclRagSeireiTbl[13].Param.Skill[4] = 62;

            fclRagShopTable.fclRagSeireiTbl[14].Param.Param[0] = 12;
            fclRagShopTable.fclRagSeireiTbl[14].Param.Param[1] = 20;
            fclRagShopTable.fclRagSeireiTbl[14].Param.Param[2] = 19;
            fclRagShopTable.fclRagSeireiTbl[14].Param.Param[3] = 15;
            fclRagShopTable.fclRagSeireiTbl[14].Param.Param[4] = 21;
            fclRagShopTable.fclRagSeireiTbl[14].Param.Param[5] = 13;
            fclRagShopTable.fclRagSeireiTbl[14].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[14].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[14].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[14].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[14].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[14].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[14].Param.Skill[0] = 36;
            fclRagShopTable.fclRagSeireiTbl[14].Param.Skill[1] = 19;
            fclRagShopTable.fclRagSeireiTbl[14].Param.Skill[2] = 373;
            fclRagShopTable.fclRagSeireiTbl[14].Param.Skill[3] = 59;

            fclRagShopTable.fclRagSeireiTbl[15].Param.Param[0] = 12;
            fclRagShopTable.fclRagSeireiTbl[15].Param.Param[1] = 21;
            fclRagShopTable.fclRagSeireiTbl[15].Param.Param[2] = 21;
            fclRagShopTable.fclRagSeireiTbl[15].Param.Param[3] = 15;
            fclRagShopTable.fclRagSeireiTbl[15].Param.Param[4] = 21;
            fclRagShopTable.fclRagSeireiTbl[15].Param.Param[5] = 13;
            fclRagShopTable.fclRagSeireiTbl[15].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[15].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[15].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[15].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[15].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[15].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[15].Param.Skill[0] = 36;
            fclRagShopTable.fclRagSeireiTbl[15].Param.Skill[1] = 19;
            fclRagShopTable.fclRagSeireiTbl[15].Param.Skill[2] = 373;
            fclRagShopTable.fclRagSeireiTbl[15].Param.Skill[3] = 59;
            fclRagShopTable.fclRagSeireiTbl[15].Param.Skill[4] = 62;

            // Erthys
            fclRagShopTable.fclRagSeireiTbl[16].Param.Param[0] = 15;
            fclRagShopTable.fclRagSeireiTbl[16].Param.Param[1] = 15;
            fclRagShopTable.fclRagSeireiTbl[16].Param.Param[2] = 12;
            fclRagShopTable.fclRagSeireiTbl[16].Param.Param[3] = 20;
            fclRagShopTable.fclRagSeireiTbl[16].Param.Param[4] = 10;
            fclRagShopTable.fclRagSeireiTbl[16].Param.Param[5] = 12;
            fclRagShopTable.fclRagSeireiTbl[16].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[16].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[16].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[16].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[16].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[16].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[16].Param.Skill[0] = 13;
            fclRagShopTable.fclRagSeireiTbl[16].Param.Skill[1] = 43;
            fclRagShopTable.fclRagSeireiTbl[16].Param.Skill[2] = 66;

            fclRagShopTable.fclRagSeireiTbl[17].Param.Param[0] = 15;
            fclRagShopTable.fclRagSeireiTbl[17].Param.Param[1] = 15;
            fclRagShopTable.fclRagSeireiTbl[17].Param.Param[2] = 13;
            fclRagShopTable.fclRagSeireiTbl[17].Param.Param[3] = 22;
            fclRagShopTable.fclRagSeireiTbl[17].Param.Param[4] = 10;
            fclRagShopTable.fclRagSeireiTbl[17].Param.Param[5] = 12;
            fclRagShopTable.fclRagSeireiTbl[17].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[17].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[17].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[17].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[17].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[17].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[17].Param.Skill[0] = 13;
            fclRagShopTable.fclRagSeireiTbl[17].Param.Skill[1] = 43;
            fclRagShopTable.fclRagSeireiTbl[17].Param.Skill[2] = 66;
            fclRagShopTable.fclRagSeireiTbl[17].Param.Skill[3] = 112;

            fclRagShopTable.fclRagSeireiTbl[18].Param.Param[0] = 15;
            fclRagShopTable.fclRagSeireiTbl[18].Param.Param[1] = 15;
            fclRagShopTable.fclRagSeireiTbl[18].Param.Param[2] = 13;
            fclRagShopTable.fclRagSeireiTbl[18].Param.Param[3] = 24;
            fclRagShopTable.fclRagSeireiTbl[18].Param.Param[4] = 11;
            fclRagShopTable.fclRagSeireiTbl[18].Param.Param[5] = 12;
            fclRagShopTable.fclRagSeireiTbl[18].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[18].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[18].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[18].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[18].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[18].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[18].Param.Skill[0] = 13;
            fclRagShopTable.fclRagSeireiTbl[18].Param.Skill[1] = 43;
            fclRagShopTable.fclRagSeireiTbl[18].Param.Skill[2] = 66;
            fclRagShopTable.fclRagSeireiTbl[18].Param.Skill[3] = 112;
            fclRagShopTable.fclRagSeireiTbl[18].Param.Skill[4] = 320;

            fclRagShopTable.fclRagSeireiTbl[19].Param.Param[0] = 15;
            fclRagShopTable.fclRagSeireiTbl[19].Param.Param[1] = 15;
            fclRagShopTable.fclRagSeireiTbl[19].Param.Param[2] = 13;
            fclRagShopTable.fclRagSeireiTbl[19].Param.Param[3] = 22;
            fclRagShopTable.fclRagSeireiTbl[19].Param.Param[4] = 10;
            fclRagShopTable.fclRagSeireiTbl[19].Param.Param[5] = 12;
            fclRagShopTable.fclRagSeireiTbl[19].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[19].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[19].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[19].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[19].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[19].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[19].Param.Skill[0] = 13;
            fclRagShopTable.fclRagSeireiTbl[19].Param.Skill[1] = 368;
            fclRagShopTable.fclRagSeireiTbl[19].Param.Skill[2] = 66;
            fclRagShopTable.fclRagSeireiTbl[19].Param.Skill[3] = 112;

            fclRagShopTable.fclRagSeireiTbl[20].Param.Param[0] = 15;
            fclRagShopTable.fclRagSeireiTbl[20].Param.Param[1] = 15;
            fclRagShopTable.fclRagSeireiTbl[20].Param.Param[2] = 13;
            fclRagShopTable.fclRagSeireiTbl[20].Param.Param[3] = 24;
            fclRagShopTable.fclRagSeireiTbl[20].Param.Param[4] = 11;
            fclRagShopTable.fclRagSeireiTbl[20].Param.Param[5] = 12;
            fclRagShopTable.fclRagSeireiTbl[20].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[20].Param.Level * 6 + fclRagShopTable.fclRagSeireiTbl[20].Param.Param[3] * 3);
            fclRagShopTable.fclRagSeireiTbl[20].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagSeireiTbl[20].Param.Level * 4 + fclRagShopTable.fclRagSeireiTbl[20].Param.Param[2] * 2);
            fclRagShopTable.fclRagSeireiTbl[20].Param.Skill[0] = 13;
            fclRagShopTable.fclRagSeireiTbl[20].Param.Skill[1] = 368;
            fclRagShopTable.fclRagSeireiTbl[20].Param.Skill[2] = 66;
            fclRagShopTable.fclRagSeireiTbl[20].Param.Skill[3] = 112;
            fclRagShopTable.fclRagSeireiTbl[20].Param.Skill[4] = 320;

            // Saki Mitama
            fclRagShopTable.fclRagMitamaTbl[1].Param.Param[0] = 20;
            fclRagShopTable.fclRagMitamaTbl[1].Param.Param[1] = 20;
            fclRagShopTable.fclRagMitamaTbl[1].Param.Param[2] = 42;
            fclRagShopTable.fclRagMitamaTbl[1].Param.Param[3] = 42;
            fclRagShopTable.fclRagMitamaTbl[1].Param.Param[4] = 20;
            fclRagShopTable.fclRagMitamaTbl[1].Param.Param[5] = 42;
            fclRagShopTable.fclRagMitamaTbl[1].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[1].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[1].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[1].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[1].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[1].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[1].Param.Skill[0] = 60;
            fclRagShopTable.fclRagMitamaTbl[1].Param.Skill[1] = 400;
            fclRagShopTable.fclRagMitamaTbl[1].Param.Skill[2] = 71;

            fclRagShopTable.fclRagMitamaTbl[2].Param.Param[0] = 20;
            fclRagShopTable.fclRagMitamaTbl[2].Param.Param[1] = 20;
            fclRagShopTable.fclRagMitamaTbl[2].Param.Param[2] = 43;
            fclRagShopTable.fclRagMitamaTbl[2].Param.Param[3] = 43;
            fclRagShopTable.fclRagMitamaTbl[2].Param.Param[4] = 20;
            fclRagShopTable.fclRagMitamaTbl[2].Param.Param[5] = 43;
            fclRagShopTable.fclRagMitamaTbl[2].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[2].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[2].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[2].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[2].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[2].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[2].Param.Skill[0] = 60;
            fclRagShopTable.fclRagMitamaTbl[2].Param.Skill[1] = 400;
            fclRagShopTable.fclRagMitamaTbl[2].Param.Skill[2] = 71;
            fclRagShopTable.fclRagMitamaTbl[2].Param.Skill[3] = 23;

            fclRagShopTable.fclRagMitamaTbl[3].Param.Param[0] = 20;
            fclRagShopTable.fclRagMitamaTbl[3].Param.Param[1] = 20;
            fclRagShopTable.fclRagMitamaTbl[3].Param.Param[2] = 44;
            fclRagShopTable.fclRagMitamaTbl[3].Param.Param[3] = 44;
            fclRagShopTable.fclRagMitamaTbl[3].Param.Param[4] = 20;
            fclRagShopTable.fclRagMitamaTbl[3].Param.Param[5] = 44;
            fclRagShopTable.fclRagMitamaTbl[3].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[3].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[3].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[3].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[3].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[3].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[3].Param.Skill[0] = 60;
            fclRagShopTable.fclRagMitamaTbl[3].Param.Skill[1] = 400;
            fclRagShopTable.fclRagMitamaTbl[3].Param.Skill[2] = 71;
            fclRagShopTable.fclRagMitamaTbl[3].Param.Skill[3] = 23;
            fclRagShopTable.fclRagMitamaTbl[3].Param.Skill[4] = 40;

            fclRagShopTable.fclRagMitamaTbl[4].Param.Param[0] = 21;
            fclRagShopTable.fclRagMitamaTbl[4].Param.Param[1] = 21;
            fclRagShopTable.fclRagMitamaTbl[4].Param.Param[2] = 42;
            fclRagShopTable.fclRagMitamaTbl[4].Param.Param[3] = 42;
            fclRagShopTable.fclRagMitamaTbl[4].Param.Param[4] = 21;
            fclRagShopTable.fclRagMitamaTbl[4].Param.Param[5] = 42;
            fclRagShopTable.fclRagMitamaTbl[4].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[4].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[4].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[4].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[4].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[4].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[4].Param.Skill[0] = 60;
            fclRagShopTable.fclRagMitamaTbl[4].Param.Skill[1] = 363;
            fclRagShopTable.fclRagMitamaTbl[4].Param.Skill[2] = 71;
            fclRagShopTable.fclRagMitamaTbl[4].Param.Skill[3] = 23;

            fclRagShopTable.fclRagMitamaTbl[5].Param.Param[0] = 22;
            fclRagShopTable.fclRagMitamaTbl[5].Param.Param[1] = 22;
            fclRagShopTable.fclRagMitamaTbl[5].Param.Param[2] = 42;
            fclRagShopTable.fclRagMitamaTbl[5].Param.Param[3] = 42;
            fclRagShopTable.fclRagMitamaTbl[5].Param.Param[4] = 22;
            fclRagShopTable.fclRagMitamaTbl[5].Param.Param[5] = 42;
            fclRagShopTable.fclRagMitamaTbl[5].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[5].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[5].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[5].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[5].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[5].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[5].Param.Skill[0] = 60;
            fclRagShopTable.fclRagMitamaTbl[5].Param.Skill[1] = 363;
            fclRagShopTable.fclRagMitamaTbl[5].Param.Skill[2] = 71;
            fclRagShopTable.fclRagMitamaTbl[5].Param.Skill[3] = 23;
            fclRagShopTable.fclRagMitamaTbl[5].Param.Skill[4] = 40;

            // Kushi Mitama
            fclRagShopTable.fclRagMitamaTbl[6].Param.Param[0] = 39;
            fclRagShopTable.fclRagMitamaTbl[6].Param.Param[1] = 20;
            fclRagShopTable.fclRagMitamaTbl[6].Param.Param[2] = 20;
            fclRagShopTable.fclRagMitamaTbl[6].Param.Param[3] = 39;
            fclRagShopTable.fclRagMitamaTbl[6].Param.Param[4] = 39;
            fclRagShopTable.fclRagMitamaTbl[6].Param.Param[5] = 20;
            fclRagShopTable.fclRagMitamaTbl[6].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[6].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[6].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[6].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[6].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[6].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[6].Param.Skill[0] = 65;
            fclRagShopTable.fclRagMitamaTbl[6].Param.Skill[1] = 57;
            fclRagShopTable.fclRagMitamaTbl[6].Param.Skill[2] = 71;

            fclRagShopTable.fclRagMitamaTbl[7].Param.Param[0] = 40;
            fclRagShopTable.fclRagMitamaTbl[7].Param.Param[1] = 20;
            fclRagShopTable.fclRagMitamaTbl[7].Param.Param[2] = 20;
            fclRagShopTable.fclRagMitamaTbl[7].Param.Param[3] = 40;
            fclRagShopTable.fclRagMitamaTbl[7].Param.Param[4] = 40;
            fclRagShopTable.fclRagMitamaTbl[7].Param.Param[5] = 20;
            fclRagShopTable.fclRagMitamaTbl[7].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[7].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[7].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[7].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[7].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[7].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[7].Param.Skill[0] = 65;
            fclRagShopTable.fclRagMitamaTbl[7].Param.Skill[1] = 57;
            fclRagShopTable.fclRagMitamaTbl[7].Param.Skill[2] = 71;
            fclRagShopTable.fclRagMitamaTbl[7].Param.Skill[3] = 317;

            fclRagShopTable.fclRagMitamaTbl[8].Param.Param[0] = 41;
            fclRagShopTable.fclRagMitamaTbl[8].Param.Param[1] = 20;
            fclRagShopTable.fclRagMitamaTbl[8].Param.Param[2] = 20;
            fclRagShopTable.fclRagMitamaTbl[8].Param.Param[3] = 41;
            fclRagShopTable.fclRagMitamaTbl[8].Param.Param[4] = 41;
            fclRagShopTable.fclRagMitamaTbl[8].Param.Param[5] = 20;
            fclRagShopTable.fclRagMitamaTbl[8].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[8].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[8].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[8].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[8].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[8].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[8].Param.Skill[0] = 65;
            fclRagShopTable.fclRagMitamaTbl[8].Param.Skill[1] = 57;
            fclRagShopTable.fclRagMitamaTbl[8].Param.Skill[2] = 71;
            fclRagShopTable.fclRagMitamaTbl[8].Param.Skill[3] = 317;
            fclRagShopTable.fclRagMitamaTbl[8].Param.Skill[4] = 315;

            fclRagShopTable.fclRagMitamaTbl[9].Param.Param[0] = 39;
            fclRagShopTable.fclRagMitamaTbl[9].Param.Param[1] = 21;
            fclRagShopTable.fclRagMitamaTbl[9].Param.Param[2] = 21;
            fclRagShopTable.fclRagMitamaTbl[9].Param.Param[3] = 39;
            fclRagShopTable.fclRagMitamaTbl[9].Param.Param[4] = 39;
            fclRagShopTable.fclRagMitamaTbl[9].Param.Param[5] = 21;
            fclRagShopTable.fclRagMitamaTbl[9].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[9].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[9].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[9].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[9].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[9].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[9].Param.Skill[0] = 65;
            fclRagShopTable.fclRagMitamaTbl[9].Param.Skill[1] = 57;
            fclRagShopTable.fclRagMitamaTbl[9].Param.Skill[2] = 365;
            fclRagShopTable.fclRagMitamaTbl[9].Param.Skill[3] = 317;

            fclRagShopTable.fclRagMitamaTbl[10].Param.Param[0] = 39;
            fclRagShopTable.fclRagMitamaTbl[10].Param.Param[1] = 22;
            fclRagShopTable.fclRagMitamaTbl[10].Param.Param[2] = 22;
            fclRagShopTable.fclRagMitamaTbl[10].Param.Param[3] = 39;
            fclRagShopTable.fclRagMitamaTbl[10].Param.Param[4] = 39;
            fclRagShopTable.fclRagMitamaTbl[10].Param.Param[5] = 22;
            fclRagShopTable.fclRagMitamaTbl[10].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[10].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[10].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[10].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[10].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[10].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[10].Param.Skill[0] = 65;
            fclRagShopTable.fclRagMitamaTbl[10].Param.Skill[1] = 57;
            fclRagShopTable.fclRagMitamaTbl[10].Param.Skill[2] = 365;
            fclRagShopTable.fclRagMitamaTbl[10].Param.Skill[3] = 317;
            fclRagShopTable.fclRagMitamaTbl[10].Param.Skill[4] = 315;

            // Nigi Mitama
            fclRagShopTable.fclRagMitamaTbl[11].Param.Param[0] = 20;
            fclRagShopTable.fclRagMitamaTbl[11].Param.Param[1] = 36;
            fclRagShopTable.fclRagMitamaTbl[11].Param.Param[2] = 36;
            fclRagShopTable.fclRagMitamaTbl[11].Param.Param[3] = 20;
            fclRagShopTable.fclRagMitamaTbl[11].Param.Param[4] = 20;
            fclRagShopTable.fclRagMitamaTbl[11].Param.Param[5] = 36;
            fclRagShopTable.fclRagMitamaTbl[11].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[11].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[11].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[11].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[11].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[11].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[11].Param.Skill[0] = 54;
            fclRagShopTable.fclRagMitamaTbl[11].Param.Skill[1] = 369;
            fclRagShopTable.fclRagMitamaTbl[11].Param.Skill[2] = 71;

            fclRagShopTable.fclRagMitamaTbl[12].Param.Param[0] = 20;
            fclRagShopTable.fclRagMitamaTbl[12].Param.Param[1] = 37;
            fclRagShopTable.fclRagMitamaTbl[12].Param.Param[2] = 37;
            fclRagShopTable.fclRagMitamaTbl[12].Param.Param[3] = 20;
            fclRagShopTable.fclRagMitamaTbl[12].Param.Param[4] = 20;
            fclRagShopTable.fclRagMitamaTbl[12].Param.Param[5] = 37;
            fclRagShopTable.fclRagMitamaTbl[12].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[12].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[12].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[12].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[12].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[12].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[12].Param.Skill[0] = 54;
            fclRagShopTable.fclRagMitamaTbl[12].Param.Skill[1] = 369;
            fclRagShopTable.fclRagMitamaTbl[12].Param.Skill[2] = 71;
            fclRagShopTable.fclRagMitamaTbl[12].Param.Skill[3] = 309;

            fclRagShopTable.fclRagMitamaTbl[13].Param.Param[0] = 20;
            fclRagShopTable.fclRagMitamaTbl[13].Param.Param[1] = 38;
            fclRagShopTable.fclRagMitamaTbl[13].Param.Param[2] = 38;
            fclRagShopTable.fclRagMitamaTbl[13].Param.Param[3] = 20;
            fclRagShopTable.fclRagMitamaTbl[13].Param.Param[4] = 20;
            fclRagShopTable.fclRagMitamaTbl[13].Param.Param[5] = 38;
            fclRagShopTable.fclRagMitamaTbl[13].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[13].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[13].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[13].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[13].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[13].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[13].Param.Skill[0] = 54;
            fclRagShopTable.fclRagMitamaTbl[13].Param.Skill[1] = 369;
            fclRagShopTable.fclRagMitamaTbl[13].Param.Skill[2] = 71;
            fclRagShopTable.fclRagMitamaTbl[13].Param.Skill[3] = 309;
            fclRagShopTable.fclRagMitamaTbl[13].Param.Skill[4] = 311;

            fclRagShopTable.fclRagMitamaTbl[14].Param.Param[0] = 21;
            fclRagShopTable.fclRagMitamaTbl[14].Param.Param[1] = 36;
            fclRagShopTable.fclRagMitamaTbl[14].Param.Param[2] = 36;
            fclRagShopTable.fclRagMitamaTbl[14].Param.Param[3] = 21;
            fclRagShopTable.fclRagMitamaTbl[14].Param.Param[4] = 21;
            fclRagShopTable.fclRagMitamaTbl[14].Param.Param[5] = 36;
            fclRagShopTable.fclRagMitamaTbl[14].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[14].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[14].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[14].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[14].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[14].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[14].Param.Skill[0] = 54;
            fclRagShopTable.fclRagMitamaTbl[14].Param.Skill[1] = 369;
            fclRagShopTable.fclRagMitamaTbl[14].Param.Skill[2] = 364;
            fclRagShopTable.fclRagMitamaTbl[14].Param.Skill[3] = 309;

            fclRagShopTable.fclRagMitamaTbl[15].Param.Param[0] = 22;
            fclRagShopTable.fclRagMitamaTbl[15].Param.Param[1] = 36;
            fclRagShopTable.fclRagMitamaTbl[15].Param.Param[2] = 36;
            fclRagShopTable.fclRagMitamaTbl[15].Param.Param[3] = 22;
            fclRagShopTable.fclRagMitamaTbl[15].Param.Param[4] = 22;
            fclRagShopTable.fclRagMitamaTbl[15].Param.Param[5] = 36;
            fclRagShopTable.fclRagMitamaTbl[15].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[15].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[15].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[15].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[15].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[15].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[15].Param.Skill[0] = 54;
            fclRagShopTable.fclRagMitamaTbl[15].Param.Skill[1] = 369;
            fclRagShopTable.fclRagMitamaTbl[15].Param.Skill[2] = 364;
            fclRagShopTable.fclRagMitamaTbl[15].Param.Skill[3] = 309;
            fclRagShopTable.fclRagMitamaTbl[15].Param.Skill[4] = 311;

            // Ara Mitama
            fclRagShopTable.fclRagMitamaTbl[16].Param.Param[0] = 32;
            fclRagShopTable.fclRagMitamaTbl[16].Param.Param[1] = 32;
            fclRagShopTable.fclRagMitamaTbl[16].Param.Param[2] = 20;
            fclRagShopTable.fclRagMitamaTbl[16].Param.Param[3] = 20;
            fclRagShopTable.fclRagMitamaTbl[16].Param.Param[4] = 32;
            fclRagShopTable.fclRagMitamaTbl[16].Param.Param[5] = 20;
            fclRagShopTable.fclRagMitamaTbl[16].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[16].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[16].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[16].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[16].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[16].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[16].Param.Skill[0] = 64;
            fclRagShopTable.fclRagMitamaTbl[16].Param.Skill[1] = 300;
            fclRagShopTable.fclRagMitamaTbl[16].Param.Skill[2] = 71;

            fclRagShopTable.fclRagMitamaTbl[17].Param.Param[0] = 33;
            fclRagShopTable.fclRagMitamaTbl[17].Param.Param[1] = 33;
            fclRagShopTable.fclRagMitamaTbl[17].Param.Param[2] = 20;
            fclRagShopTable.fclRagMitamaTbl[17].Param.Param[3] = 20;
            fclRagShopTable.fclRagMitamaTbl[17].Param.Param[4] = 33;
            fclRagShopTable.fclRagMitamaTbl[17].Param.Param[5] = 20;
            fclRagShopTable.fclRagMitamaTbl[17].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[17].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[17].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[17].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[17].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[17].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[17].Param.Skill[0] = 64;
            fclRagShopTable.fclRagMitamaTbl[17].Param.Skill[1] = 300;
            fclRagShopTable.fclRagMitamaTbl[17].Param.Skill[2] = 71;
            fclRagShopTable.fclRagMitamaTbl[17].Param.Skill[3] = 346;

            fclRagShopTable.fclRagMitamaTbl[18].Param.Param[0] = 34;
            fclRagShopTable.fclRagMitamaTbl[18].Param.Param[1] = 34;
            fclRagShopTable.fclRagMitamaTbl[18].Param.Param[2] = 20;
            fclRagShopTable.fclRagMitamaTbl[18].Param.Param[3] = 20;
            fclRagShopTable.fclRagMitamaTbl[18].Param.Param[4] = 34;
            fclRagShopTable.fclRagMitamaTbl[18].Param.Param[5] = 20;
            fclRagShopTable.fclRagMitamaTbl[18].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[18].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[18].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[18].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[18].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[18].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[18].Param.Skill[0] = 64;
            fclRagShopTable.fclRagMitamaTbl[18].Param.Skill[1] = 300;
            fclRagShopTable.fclRagMitamaTbl[18].Param.Skill[2] = 71;
            fclRagShopTable.fclRagMitamaTbl[18].Param.Skill[3] = 346;
            fclRagShopTable.fclRagMitamaTbl[18].Param.Skill[4] = 349;

            fclRagShopTable.fclRagMitamaTbl[19].Param.Param[0] = 32;
            fclRagShopTable.fclRagMitamaTbl[19].Param.Param[1] = 32;
            fclRagShopTable.fclRagMitamaTbl[19].Param.Param[2] = 21;
            fclRagShopTable.fclRagMitamaTbl[19].Param.Param[3] = 21;
            fclRagShopTable.fclRagMitamaTbl[19].Param.Param[4] = 32;
            fclRagShopTable.fclRagMitamaTbl[19].Param.Param[5] = 21;
            fclRagShopTable.fclRagMitamaTbl[19].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[19].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[19].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[19].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[19].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[19].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[19].Param.Skill[0] = 64;
            fclRagShopTable.fclRagMitamaTbl[19].Param.Skill[1] = 367;
            fclRagShopTable.fclRagMitamaTbl[19].Param.Skill[2] = 71;
            fclRagShopTable.fclRagMitamaTbl[19].Param.Skill[3] = 346;

            fclRagShopTable.fclRagMitamaTbl[20].Param.Param[0] = 32;
            fclRagShopTable.fclRagMitamaTbl[20].Param.Param[1] = 32;
            fclRagShopTable.fclRagMitamaTbl[20].Param.Param[2] = 22;
            fclRagShopTable.fclRagMitamaTbl[20].Param.Param[3] = 22;
            fclRagShopTable.fclRagMitamaTbl[20].Param.Param[4] = 32;
            fclRagShopTable.fclRagMitamaTbl[20].Param.Param[5] = 22;
            fclRagShopTable.fclRagMitamaTbl[20].Param.MaxHP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[20].Param.Level * 6 + fclRagShopTable.fclRagMitamaTbl[20].Param.Param[3] * 3);
            fclRagShopTable.fclRagMitamaTbl[20].Param.MaxMP = Convert.ToUInt16(fclRagShopTable.fclRagMitamaTbl[20].Param.Level * 4 + fclRagShopTable.fclRagMitamaTbl[20].Param.Param[2] * 2);
            fclRagShopTable.fclRagMitamaTbl[20].Param.Skill[0] = 64;
            fclRagShopTable.fclRagMitamaTbl[20].Param.Skill[1] = 367;
            fclRagShopTable.fclRagMitamaTbl[20].Param.Skill[2] = 71;
            fclRagShopTable.fclRagMitamaTbl[20].Param.Skill[3] = 346;
            fclRagShopTable.fclRagMitamaTbl[20].Param.Skill[4] = 349;
        }

        [HarmonyPatch(typeof(frFont), nameof(frFont.frReplaceLocalizeText))]
        private class ShopMessagePatch
        {
            public static void Postfix(ref string message, ref frMsgInfo_t mi, ref List<int> index, ref string __result)
            {
                try
                {
                    switch (message)
                    {
                        // ToK Shop Dialogue
                        case "<SPD 7><FONT 1><SHOP_MES_DATA_L0034><WAIT>": __result = "<SP7><FO1>Hey, I found this huge stash of weird books...<WA>"; break;
                        case "<SHOP_MES_DATA_L0035><WAIT>": __result = "I don't suppose you want to buy some, do you?<WA>"; break;
                        case "<SHOP_MES_DATA_L0036><WAIT>": __result = "Come to think of it, isn't this area kind of dangerous to have a shop?<WA>"; break;
                        case "<SHOP_MES_DATA_L0037><WAIT>": __result = "On the other hand, it does have the best view in town!<WA>"; break;

                        case "<SPD 7><FONT 1><SHOP_MES_DATA_L0038><WAIT>": __result = "<SP7><FO1>Magatama? I don't have any of those.<WA>"; break;
                        case "<SHOP_MES_DATA_L0039><WAIT>": __result = "My friend said he saw one in the Diet Building.<WA>"; break;
                        case "<SHOP_MES_DATA_L0040><WAIT>": __result = "I don't know why he was snooping around there, its dangerous.<WA>"; break;
                        case "<SHOP_MES_DATA_L0041><WAIT>": __result = "I heard there's some drill sergeant wannabe on patrol...<WA>"; break;
                    }
                }
                catch { }
            }
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

            // Dekunda Rock Item Box in Underpass before Matador
            fldGlobal.fldHitData._fldItemBoxTbl[42]._ItemID = 33;
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

            // New Item Box In Ikebukuro
            fldGlobal.fldHitData._fldItemBoxTbl[338]._Type = 1;
            fldGlobal.fldHitData._fldItemBoxTbl[338]._ItemID = 39;
            fldGlobal.fldHitData._fldItemBoxTbl[338]._ItemNum = 1;

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

            // New Item Box In Ikebukuro
            fldGlobal.fldHitData._fldItemBoxTbl[339]._Type = 1;
            fldGlobal.fldHitData._fldItemBoxTbl[339]._ItemID = 39;
            fldGlobal.fldHitData._fldItemBoxTbl[339]._ItemNum = 1;

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

            // New Item Box In White Temple
            fldGlobal.fldHitData._fldItemBoxTbl[340]._Type = 1;
            fldGlobal.fldHitData._fldItemBoxTbl[340]._ItemID = 39;
            fldGlobal.fldHitData._fldItemBoxTbl[340]._ItemNum = 1;

            // New Item Box In Tower of Kagutsuchi
            fldGlobal.fldHitData._fldItemBoxTbl[341]._Type = 1;
            fldGlobal.fldHitData._fldItemBoxTbl[341]._ItemID = 39;
            fldGlobal.fldHitData._fldItemBoxTbl[341]._ItemNum = 1;

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

            // Int Incenses in TDE room in 5th Kalpa
            fldGlobal.fldHitData._fldItemBoxTbl[330]._ItemID = 39;

            // Kailash Magatama Box behind Mitra
            fldGlobal.fldHitData._fldItemBoxTbl[337]._Type = 2;
            fldGlobal.fldHitData._fldItemBoxTbl[337]._ItemID = 24;
            fldGlobal.fldHitData._fldItemBoxTbl[337]._ItemNum = 1;

            // Boss Seth Box
            fldGlobal.fldHitData._fldItemBoxTbl[75]._Type = 2;
            fldGlobal.fldHitData._fldItemBoxTbl[75]._ItemID = 0;
            fldGlobal.fldHitData._fldItemBoxTbl[75]._ItemNum = 0;
            fldGlobal.fldHitData._fldItemBoxTbl[75]._Trap = 1;
            fldGlobal.fldHitData._fldItemBoxTbl[75]._Param = 989;

            // Triple Reason Box
            fldGlobal.fldHitData._fldItemBoxTbl[347]._Type = 2;
            fldGlobal.fldHitData._fldItemBoxTbl[347]._ItemID = 0;
            fldGlobal.fldHitData._fldItemBoxTbl[347]._ItemNum = 0;
            fldGlobal.fldHitData._fldItemBoxTbl[347]._Trap = 1;
            fldGlobal.fldHitData._fldItemBoxTbl[347]._Param = 1274;

            // Classic Mot Box
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
            fldGlobal.fldHitData._fldItemBoxTbl[327]._Type = 2;
            fldGlobal.fldHitData._fldItemBoxTbl[327]._ItemID = 0;
            fldGlobal.fldHitData._fldItemBoxTbl[327]._ItemNum = 0;
            fldGlobal.fldHitData._fldItemBoxTbl[327]._Trap = 1;
            fldGlobal.fldHitData._fldItemBoxTbl[327]._Param = 1278;

            // Asakusa Box
            fldGlobal.fldHitData._fldItemBoxTbl[351]._Type = 3;
            fldGlobal.fldHitData._fldItemBoxTbl[351]._ItemID = 0;
            fldGlobal.fldHitData._fldItemBoxTbl[351]._ItemNum = 1;
            fldGlobal.fldHitData._fldItemBoxTbl[351]._Trap = 0;
            fldGlobal.fldHitData._fldItemBoxTbl[351]._Param = 10000;

            //fldGlobal.fldHitData._fldItemBoxTbl.Add(new fldTakaraTbl_t { _ItemID = 47, _ItemNum = 5 });
        }
    }
}
