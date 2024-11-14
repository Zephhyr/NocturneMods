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
        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbCheckRenzokuEncount))]
        private class nbCheckRenzokuEncountPatch
        {
            public static void Postfix(ref nbMainProcessData_t data, ref int __result)
            {
                if (data.encno == 1270 && !datEncount.tbl[1271].devil.All(x => x == 0))
                {
                    nbMisc.nbSetRenzokuEncount(1271);
                    __result = 1;
                }
                else if (data.encno == 1270 && datEncount.tbl[1271].devil.All(x => x == 0))
                {
                    __result = 0;
                }
                else if (data.encno == 1271)
                {
                    __result = 0;
                }
            }
        }

        [HarmonyPatch(typeof(nbMisc), nameof(nbMisc.nbSetRenzokuEncount))]
        private class nbSetRenzokuEncountPatch
        {
            public static void Postfix(ref int enc)
            {
                //MelonLogger.Msg("-nbMisc.nbSetRenzokuEncount-");
            }
        }

        [HarmonyPatch(typeof(nbMainProcess), nameof(nbMainProcess.nbInitMainProcess))]
        private class nbInitMainProcessPatch
        {
            public static void Prefix(ref int encpackno, ref int packno, ref int packindex, ref int encno, ref int stagemajor, ref int stageminor)
            {
                //MelonLogger.Msg("-nbMainProcess.nbInitMainProcess-");
                //MelonLogger.Msg("encpackno: " + encpackno);
                //MelonLogger.Msg("bgmno: " + nbSound.bgmno);

                //if (dds3GlobalWork.DDS3_GBWK.hearts.Contains(9) || dds3ConfigMain.cfgGetBit(9u) == 0)
                //{
                //    encno = 1278;
                //    return;
                //}
                //if (true)
                if (evtMoon.evtGetAgeOfMoon() == 0 && datEncount.tbl[encno].btlsound == 0 && random.Next(2) == 0)
                {
                    encno = NewKagutsuchiEncounter(encno, encpackno);
                }
            }
        }

        //[HarmonyPatch(typeof(nbNegoProcess), nameof(nbNegoProcess.nbInitNegoProcess))]
        //private class nbInitNegoProcessPatch
        //{
        //    public static void Prefix()
        //    {
        //        //MelonLogger.Msg("nbNegoProcess.nbInitNegoProcess");
        //    }
        //}

        //------------------------------------------------------------

        private static int NewKagutsuchiEncounter(int encno, int encpackno)
        {
            datEncount.tbl[1270].backattack = -1;
            datEncount.tbl[1270].btlsound = 15;
            datEncount.tbl[1270].esc = 0;
            datEncount.tbl[1270].flag = 0;
            datEncount.tbl[1270].formationtype = 0;
            datEncount.tbl[1270].item = 0;
            datEncount.tbl[1270].itemcnt = 0;
            datEncount.tbl[1270].maxcall = 0;
            datEncount.tbl[1270].maxparty = 0;
            datEncount.tbl[1270].stageid = 0;
            datEncount.tbl[1270].devil = new ushort[11];

            datEncount.tbl[1271].backattack = -1;
            datEncount.tbl[1271].btlsound = 15;
            datEncount.tbl[1271].esc = 0;
            datEncount.tbl[1271].flag = 0;
            datEncount.tbl[1271].formationtype = 0;
            datEncount.tbl[1271].item = 0;
            datEncount.tbl[1271].itemcnt = 0;
            datEncount.tbl[1271].maxcall = 0;
            datEncount.tbl[1271].maxparty = 0;
            datEncount.tbl[1271].stageid = 0;
            datEncount.tbl[1271].devil = new ushort[11];

            switch (encpackno)
            {
                // Base Game

                case 1: ShinjukuMedicalCentreSlimeEncounter(); return 1270;
                case 2: ShinjukuMedicalCentreSlimeEncounter(); return 1270;
                case 3: ShinjukuMedicalCentreSlimeEncounter(); return 1270;
                case 4: ShinjukuMedicalCentreSlimeEncounter(); return 1270;
                case 31: ShinjukuMedicalCentreSlimeEncounter(); return 1270;
                case 48: ShinjukuMedicalCentreSlimeEncounter(); return 1270;
                case 49: ShinjukuMedicalCentreSlimeEncounter(); return 1270;
                case 80: ShinjukuMedicalCentreSlimeEncounter(); return 1270;
                case 122: ShinjukuMedicalCentreSlimeEncounter(); return 1270;
                case 123: ShinjukuMedicalCentreSlimeEncounter(); return 1270;

                case 7: Overworld1MouRyoZhenEncounter(); return 1270;
                case 12: Overworld1AngelEncounter(); return 1270;

                case 8: YoyogiParkHighPixieEncounter(); return 1270;

                case 5: ShibuyaChoronzonEncounter(); return 1270;
                case 6: ShibuyaChoronzonEncounter(); return 1270;
                case 32: ShibuyaChoronzonEncounter(); return 1270;

                case 9: AmalaNetworkAquansEncounter(); return 1270;
                case 10: AmalaNetworkAquansEncounter(); return 1270;
                case 11: AmalaNetworkAquansEncounter(); return 1270;

                case 13: GinzaShiisaaEncounter(); return 1270;
                case 33: GinzaShiisaaEncounter(); return 1270;
                case 34: GinzaShiisaaEncounter(); return 1270;

                case 14: Overworld2ArchangelEncounter(); return 1270;

                case 15: HarumiWarehouseChatterskullEncounter(); return 1270;

                case 16: UnderpassAmeNoUzumeEncounter(); return 1270;
                case 128: UnderpassAmeNoUzumeEncounter(); return 1270;

                case 19: UnderpassForneusEncounter(); return 1270;
                case 20: UnderpassForneusEncounter(); return 1270;

                case 17: UnderpassAmeNoUzumeEncounter(); return 1270;
                case 18: UnderpassAmeNoUzumeEncounter(); return 1270;
                case 129: UnderpassAmeNoUzumeEncounter(); return 1270;
                case 130: UnderpassAmeNoUzumeEncounter(); return 1270;

                case 22: Overworld3UnicornEncounter(); return 1270;

                case 23: IkebukuroTakeMinakataEncounter(); return 1270;
                case 24: IkebukuroTakeMinakataEncounter(); return 1270;
                case 25: IkebukuroTakeMinakataEncounter(); return 1270;
                case 35: IkebukuroTakeMinakataEncounter(); return 1270;

                case 26: MantraHeadquartersNueEncounter(); return 1270;
                case 27: MantraHeadquartersNueEncounter(); return 1270;
                case 28: MantraHeadquartersNueEncounter(); return 1270;
                case 29: MantraHeadquartersNueEncounter(); return 1270;
                case 30: MantraHeadquartersNueEncounter(); return 1270;
                case 132: MantraHeadquartersNueEncounter(); return 1270;
                case 133: MantraHeadquartersNueEncounter(); return 1270;

                case 160: GinzaMakamiEncounter(); return 1270;
                case 161: GinzaMakamiEncounter(); return 1270;
                case 162: GinzaMakamiEncounter(); return 1270;

                case 38: AssemblyOfNihiloXuanwuKikuriHimeEncounter(); return 1270;
                case 39: AssemblyOfNihiloXuanwuKikuriHimeEncounter(); return 1270;
                case 40: AssemblyOfNihiloXuanwuKikuriHimeEncounter(); return 1270;
                case 41: AssemblyOfNihiloXuanwuKikuriHimeEncounter(); return 1270;
                case 42: AssemblyOfNihiloXuanwuKikuriHimeEncounter(); return 1270;
                case 43: AssemblyOfNihiloXuanwuKikuriHimeEncounter(); return 1270;
                case 44: AssemblyOfNihiloXuanwuKikuriHimeEncounter(); return 1270;
                case 82: AssemblyOfNihiloXuanwuKikuriHimeEncounter(); return 1270;

                case 52: KabukichoPrisonXiezhaiEncounter(); return 1270;
                case 53: KabukichoPrisonXiezhaiEncounter(); return 1270;
                case 54: KabukichoPrisonXiezhaiEncounter(); return 1270;
                case 55: KabukichoPrisonXiezhaiEncounter(); return 1270;
                case 56: KabukichoPrisonXiezhaiEncounter(); return 1270;
                case 57: KabukichoPrisonXiezhaiEncounter(); return 1270;
                case 58: KabukichoPrisonXiezhaiEncounter(); return 1270;
                case 59: KabukichoPrisonXiezhaiEncounter(); return 1270;
                case 60: KabukichoPrisonXiezhaiEncounter(); return 1270;
                case 61: KabukichoPrisonXiezhaiEncounter(); return 1270;

                case 81: IkebukuroTunnelSarasvatiEncounter(); return 1270;
                case 83: IkebukuroTunnelSarasvatiEncounter(); return 1270;
                case 62: IkebukuroTunnelSarasvatiEncounter(); return 1270;
                case 63: IkebukuroTunnelSarasvatiEncounter(); return 1270;
                case 64: IkebukuroTunnelSarasvatiEncounter(); return 1270;
                case 65: IkebukuroTunnelSarasvatiEncounter(); return 1270;

                case 66: Overworld4ZhuqueEncounter(); return 1270;

                case 68: AsakusaValkyrieEncounter(); return 1270;

                case 21: Overworld2VirtueEncounter(); return 1270;

                case 46: BackOfNihiloBerithEligorEncounterEncounter(); return 1270;

                case 71: Overworld5HorusEncounter(); return 1270;

                case 166: ObeliskKuramaTenguEncounter(); return 1270;
                case 167: ObeliskKuramaTenguEncounter(); return 1270;
                case 168: ObeliskKuramaTenguEncounter(); return 1270;
                case 169: ObeliskKuramaTenguEncounter(); return 1270;
                case 72: ObeliskKuramaTenguEncounter(); return 1270;
                case 73: ObeliskKuramaTenguEncounter(); return 1270;
                case 74: ObeliskKuramaTenguEncounter(); return 1270;
                case 75: ObeliskKuramaTenguEncounter(); return 1270;
                case 76: ObeliskKuramaTenguEncounter(); return 1270;

                // Labyrinth of Amala

                case 173: FirstKalpaEncounter1(); return 1270; // First rooms
                case 174: FirstKalpaEncounter2(); return 1270; // Hallways
                case 175: FirstKalpaEncounter1(); return 1270; // First side-rooms
                case 176: FirstKalpaEncounter2(); return 1270; // Hallways
                case 177: FirstKalpaEncounter3(); return 1270; // Trap room
                case 178: FirstKalpaEncounter3(); return 1270; // Trap room basement
                case 179: FirstKalpaEncounter2(); return 1270; // Exit Hallway
                case 180: FirstKalpaEncounter4(); return 1270; // B1

                case 181: SecondKalpaEncounter1(); return 1270; // 1F Hallways
                case 182: SecondKalpaEncounter1(); return 1270; // 1F Rooms
                case 183: SecondKalpaEncounter1(); return 1270; // B1 Hallways
                case 184: SecondKalpaEncounter1(); return 1270; // B1 Rooms
                case 185: SecondKalpaEncounter2(); return 1270; // B2 Hallways
                case 186: SecondKalpaEncounter2(); return 1270; // B2 Rooms
                case 187: SecondKalpaEncounter3(); return 1270; // B3/B4 Hallways
                case 188: SecondKalpaEncounter3(); return 1270; // B3/B4 Rooms
                //case 191: SecondKalpaEncounter4(); return 1270; // Cursed Corridor

                case 193: ThirdKalpaEncounter1(); return 1270; // Central Chamber
                case 194: ThirdKalpaEncounter1(); return 1270; // B1 Corridor
                case 195: ThirdKalpaEncounter1(); return 1270; // Strength Chamber
                case 196: ThirdKalpaEncounter1(); return 1270; // B1 Corridor
                case 197: ThirdKalpaEncounter1(); return 1270; // Magic Chamber
                case 198: ThirdKalpaEncounter1(); return 1270; // B1 Corridor
                case 199: ThirdKalpaEncounter1(); return 1270; // Luck Chamber
                case 200: ThirdKalpaEncounter1(); return 1270; // B2 Corridor
                case 201: ThirdKalpaEncounter1(); return 1270; // B1 Center
                case 202: ThirdKalpaEncounter1(); return 1270; // B3/4 Corridor
                case 203: ThirdKalpaEncounter1(); return 1270; // B3 Room

                default: return encno;
            }
        }

        private static void ShinjukuMedicalCentreSlimeEncounter()
        {
            datEncount.tbl[1270].devil[0] = 135;
            datEncount.tbl[1270].item = 6;
            datEncount.tbl[1270].itemcnt = 1;

            datEncount.tbl[1271].devil[0] = 135;
            datEncount.tbl[1271].devil[1] = 135;
        }

        private static void Overworld1MouRyoZhenEncounter()
        {
            datEncount.tbl[1270].devil[0] = 136;
            datEncount.tbl[1270].devil[1] = 136;
            datEncount.tbl[1270].item = 6;
            datEncount.tbl[1270].itemcnt = 1;

            datEncount.tbl[1271].devil[0] = 126;
            datEncount.tbl[1271].devil[1] = 126;
            datEncount.tbl[1271].devil[2] = 126;
        }

        private static void Overworld1AngelEncounter()
        {
            datEncount.tbl[1270].devil[0] = 68;
            datEncount.tbl[1270].devil[1] = 68;
            datEncount.tbl[1270].item = 9;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void YoyogiParkHighPixieEncounter()
        {
            datEncount.tbl[1270].devil[0] = 61;
            datEncount.tbl[1270].devil[1] = 59;
            datEncount.tbl[1270].devil[2] = 61;
            datEncount.tbl[1270].item = 13;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void ShibuyaChoronzonEncounter()
        {
            datEncount.tbl[1270].devil[0] = 130;
            datEncount.tbl[1270].item = 29;
            datEncount.tbl[1270].itemcnt = 1;

            datEncount.tbl[1271].devil[0] = 136;
            datEncount.tbl[1271].devil[1] = 130;
            datEncount.tbl[1271].devil[2] = 136;
        }

        private static void AmalaNetworkAquansEncounter()
        {
            datEncount.tbl[1270].devil[0] = 37;
            datEncount.tbl[1270].item = 102;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void GinzaShiisaaEncounter()
        {
            datEncount.tbl[1270].devil[0] = 33;
            datEncount.tbl[1270].devil[1] = 33;
            datEncount.tbl[1270].item = 111;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void Overworld2ArchangelEncounter()
        {
            datEncount.tbl[1270].devil[0] = 67;
            datEncount.tbl[1270].devil[1] = 67;
            datEncount.tbl[1270].item = 9;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void HarumiWarehouseChatterskullEncounter()
        {
            datEncount.tbl[1270].devil[0] = 177;
            datEncount.tbl[1270].devil[1] = 177;
            datEncount.tbl[1270].devil[2] = 177;
            datEncount.tbl[1270].item = 32;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void UnderpassAmeNoUzumeEncounter()
        {
            datEncount.tbl[1270].maxcall = 1;
            datEncount.tbl[1270].maxparty = 3;
            datEncount.tbl[1270].item = 106;
            datEncount.tbl[1270].itemcnt = 1;

            datEncount.tbl[1270].devil[0] = 90;
            datEncount.tbl[1270].devil[1] = 11;
            datEncount.tbl[1270].devil[2] = 90;
        }

        private static void UnderpassForneusEncounter()
        {
            datEncount.tbl[1270].devil[0] = 50;
            datEncount.tbl[1270].devil[1] = 74;
            datEncount.tbl[1270].devil[2] = 50;
            datEncount.tbl[1270].item = 110;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void Overworld3UnicornEncounter()
        {
            datEncount.tbl[1270].maxcall = 8;
            datEncount.tbl[1270].maxparty = 3;
            datEncount.tbl[1270].item = 4;
            datEncount.tbl[1270].itemcnt = 1;

            datEncount.tbl[1270].devil[0] = 125;
            datEncount.tbl[1270].devil[1] = 35;
            datEncount.tbl[1270].devil[2] = 125;
        }

        private static void IkebukuroTakeMinakataEncounter()
        {
            datEncount.tbl[1270].devil[0] = 28;
            datEncount.tbl[1270].item = 50;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void TestManikinEncounter()
        {
            datEncount.tbl[1270].devil[0] = 156;
            datEncount.tbl[1270].devil[1] = 157;
            datEncount.tbl[1270].devil[2] = 158;
            datEncount.tbl[1270].devil[3] = 159;
            datEncount.tbl[1270].devil[4] = 160;
        }

        private static void MantraHeadquartersNueEncounter()
        {
            datEncount.tbl[1270].devil[0] = 124;
            datEncount.tbl[1270].devil[1] = 124;
            datEncount.tbl[1270].devil[2] = 124;
            datEncount.tbl[1270].item = 108;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void GinzaMakamiEncounter()
        {
            datEncount.tbl[1270].maxparty = 3;

            datEncount.tbl[1270].devil[0] = 0;
            datEncount.tbl[1270].devil[1] = 151;
            datEncount.tbl[1270].devil[2] = 0;
            datEncount.tbl[1270].item = 104;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void AssemblyOfNihiloXuanwuKikuriHimeEncounter()
        {
            datEncount.tbl[1270].devil[0] = 149;
            datEncount.tbl[1270].devil[1] = 20;
            datEncount.tbl[1270].item = 103;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void KabukichoPrisonXiezhaiEncounter()
        {
            datEncount.tbl[1270].devil[0] = 34;
            datEncount.tbl[1270].item = 49;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void IkebukuroTunnelSarasvatiEncounter()
        {
            datEncount.tbl[1270].devil[0] = 9;
            datEncount.tbl[1270].item = 51;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void Overworld4ZhuqueEncounter()
        {
            datEncount.tbl[1270].devil[0] = 32;
            datEncount.tbl[1270].item = 48;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void AsakusaValkyrieEncounter()
        {
            datEncount.tbl[1270].maxparty = 3;

            datEncount.tbl[1270].devil[0] = 0;
            datEncount.tbl[1270].devil[1] = 143;
            datEncount.tbl[1270].devil[2] = 0;
            datEncount.tbl[1270].item = 100;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void Overworld2VirtueEncounter()
        {
            datEncount.tbl[1270].maxparty = 3;

            datEncount.tbl[1270].devil[0] = 64;
            datEncount.tbl[1270].devil[1] = 64;
            datEncount.tbl[1270].devil[2] = 64;
            datEncount.tbl[1270].item = 4;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void BackOfNihiloBerithEligorEncounterEncounter()
        {
            datEncount.tbl[1270].maxparty = 3;

            datEncount.tbl[1270].devil[0] = 73;
            datEncount.tbl[1270].devil[1] = 72;
            datEncount.tbl[1270].devil[2] = 73;
            datEncount.tbl[1270].item = 26;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void Overworld5HorusEncounter()
        {
            datEncount.tbl[1270].maxparty = 3;

            datEncount.tbl[1270].devil[0] = 0;
            datEncount.tbl[1270].devil[1] = 6;
            datEncount.tbl[1270].devil[2] = 0;
            datEncount.tbl[1270].item = 25;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void ObeliskKuramaTenguEncounter()
        {
            datEncount.tbl[1270].maxparty = 3;

            datEncount.tbl[1270].devil[0] = 0;
            datEncount.tbl[1270].devil[1] = 145;
            datEncount.tbl[1270].devil[2] = 0;
            datEncount.tbl[1270].item = 99;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void YoyogiParkCuChulainnEncounter()
        {
            datEncount.tbl[1270].devil[0] = 147;
            datEncount.tbl[1270].item = 111;
            datEncount.tbl[1270].itemcnt = 1;
        }

        // Labyrinth of Amala

        private static void FirstKalpaMatadorEncounter()
        {
            datEncount.tbl[1270].devil[0] = 199;
            datEncount.tbl[1270].btlsound = 10;
            datEncount.tbl[1270].item = 33;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void FirstKalpaTamLinEncounter()
        {
            datEncount.tbl[1270].devil[0] = 224;
            datEncount.tbl[1270].item = 25;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void FirstKalpaXuanwuKikuriHimeEncounter()
        {
            datEncount.tbl[1270].devil[0] = 149;
            datEncount.tbl[1270].devil[1] = 20;
            datEncount.tbl[1270].item = 103;
            datEncount.tbl[1270].itemcnt = 1;

            datEncount.tbl[1271].devil[0] = 37;
            datEncount.tbl[1271].devil[1] = 37;
            datEncount.tbl[1271].devil[2] = 37;
            datEncount.tbl[1271].devil[3] = 37;
        }

        private static void FirstKalpaXiezhaiEncounter()
        {
            datEncount.tbl[1270].devil[0] = 34;
            datEncount.tbl[1270].item = 49;
            datEncount.tbl[1270].itemcnt = 1;

            datEncount.tbl[1271].devil[0] = 144;
            datEncount.tbl[1271].devil[1] = 144;
            datEncount.tbl[1271].devil[2] = 144;
            datEncount.tbl[1271].devil[3] = 144;
        }

        private static void FirstKalpaSenriEncounter()
        {
            datEncount.tbl[1270].devil[0] = 31;
            datEncount.tbl[1270].devil[1] = 31;
            datEncount.tbl[1270].item = 51;
            datEncount.tbl[1270].itemcnt = 1;

            datEncount.tbl[1271].maxcall = 8;
            datEncount.tbl[1271].maxparty = 3;

            datEncount.tbl[1271].devil[0] = 125;
            datEncount.tbl[1271].devil[1] = 35;
            datEncount.tbl[1271].devil[2] = 125;
        }

        private static void SecondKalpaDaisoujouEncounter()
        {
            datEncount.tbl[1270].devil[0] = 201;
            datEncount.tbl[1270].btlsound = 10;
            datEncount.tbl[1270].item = 60;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void SecondKalpaHellBikerEncounter()
        {
            datEncount.tbl[1270].devil[0] = 200;
            datEncount.tbl[1270].btlsound = 10;
            datEncount.tbl[1270].item = 59;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void SecondKalpaShadowEncounter()
        {
            datEncount.tbl[1270].devil[0] = 132;
            datEncount.tbl[1270].devil[1] = 132;
            datEncount.tbl[1270].devil[2] = 132;
            datEncount.tbl[1270].item = 32;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void SecondKalpaShikiOujiEncounter()
        {
            datEncount.tbl[1270].devil[0] = 93;
            datEncount.tbl[1270].item = 4;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void SecondKalpaDoppelgangerEncounter()
        {
            datEncount.tbl[1270].devil[0] = 225;
            datEncount.tbl[1270].btlsound = 16;
            datEncount.tbl[1270].item = 27;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void ThirdKalpaFourHorsemenEncounter()
        {
            datEncount.tbl[1270].maxcall = 3;
            datEncount.tbl[1270].maxparty = 4;
            datEncount.tbl[1270].devil[0] = 196;
            datEncount.tbl[1270].btlsound = 10;
            datEncount.tbl[1270].item = 10;
            datEncount.tbl[1270].itemcnt = 1;
        }

        private static void FirstKalpaEncounter1()
        {
            if (random.Next(4) == 0)
                FirstKalpaMatadorEncounter();
            else
                FirstKalpaTamLinEncounter();
        }

        private static void FirstKalpaEncounter2()
        {
            if (random.Next(4) == 0)
                FirstKalpaMatadorEncounter();
            else
                FirstKalpaXuanwuKikuriHimeEncounter();
        }

        private static void FirstKalpaEncounter3()
        {
            if (random.Next(4) == 0)
                FirstKalpaMatadorEncounter();
            else
                FirstKalpaXiezhaiEncounter();
        }

        private static void FirstKalpaEncounter4()
        {
            if (random.Next(4) == 0)
                FirstKalpaMatadorEncounter();
            else
                FirstKalpaSenriEncounter();
        }

        private static void SecondKalpaEncounter1()
        {
            if (random.Next(4) == 0)
                SecondKalpaDaisoujouEncounter();
            else
                SecondKalpaShadowEncounter();
        }

        private static void SecondKalpaEncounter2()
        {
            if (random.Next(4) == 0)
                SecondKalpaDaisoujouEncounter();
            else
                SecondKalpaShikiOujiEncounter();
        }

        private static void SecondKalpaEncounter3()
        {
            if (random.Next(4) == 0)
                SecondKalpaHellBikerEncounter();
            else
                SecondKalpaDoppelgangerEncounter();
        }

        private static void ThirdKalpaEncounter1()
        {
            if (random.Next(4) == 0)
                ThirdKalpaFourHorsemenEncounter();
            else
                YoyogiParkCuChulainnEncounter();
        }

        //------------------------------------------------------------

        private static void ApplyEncounterChanges()
        {
            datEncount.tbl[1267].devil[0] = 319; // Forced Preta
            datEncount.tbl[1269].flag = 13; // Forced Kodama + Will o' Wisp in Unknown Realm
            datEncount.tbl[1269].devil[1] = 318;
            datEncount.tbl[14].flag = 11; // Boss Forneus
            datEncount.tbl[20].maxparty = 7; // Boss Specter 1
            datEncount.tbl[85].flag = 11; // Boss Thor 1
            datEncount.tbl[268].flag = 11; // Boss Clotho
            datEncount.tbl[269].flag = 11; // Boss Lachesis
            datEncount.tbl[270].flag = 11; // Boss Atropos
            datEncount.tbl[271].flag = 11; // Boss Moirae Sisters

            datEncount.tbl[144].maxparty = 6; // Forced Incubus + Koppa Tengu
            datEncount.tbl[144].maxcall = 0;
            datEncount.tbl[144].devil[0] = 0;
            datEncount.tbl[144].devil[1] = 0;
            datEncount.tbl[144].devil[2] = 260;
            datEncount.tbl[144].devil[3] = 261;

            datEncount.tbl[115].flag = 11; // Boss Berith
            datEncount.tbl[115].maxparty = 3;
            datEncount.tbl[115].devil[0] = 0;
            datEncount.tbl[115].devil[1] = 312;
            datEncount.tbl[115].devil[2] = 0;

            datEncount.tbl[117].flag = 11; // Boss Ose

            datEncount.tbl[193].maxcall = 1; // Forced Naga
            datEncount.tbl[193].maxparty = 2;

            datEncount.tbl[713].maxparty = 5; // Boss Mara
            datEncount.tbl[713].devil[0] = 0;
            datEncount.tbl[713].devil[1] = 0;
            datEncount.tbl[713].devil[2] = 321;

            datEncount.tbl[990].devil[0] = 225; // Ambush Cube Doppelganger
            datEncount.tbl[990].btlsound = 16;

            datEncount.tbl[653].devil[0] = 226; // Ambush Cube Nightmare
            datEncount.tbl[653].devil[1] = 226;
            datEncount.tbl[653].devil[2] = 226;

            datEncount.tbl[1033].flag = 11; // Dante/Raidou 1

            datEncount.tbl[1035].maxcall = 4; // Dante/Raidou 2
            datEncount.tbl[1035].maxparty = 5;
            datEncount.tbl[1035].devil[0] = 0;
            datEncount.tbl[1035].devil[1] = 0;
            datEncount.tbl[1035].devil[2] = 341;
            datEncount.tbl[1035].devil[3] = 0;
            datEncount.tbl[1035].devil[4] = 0;
            datEncount.tbl[1035].btlsound = 21;

            // Boss Flauros
            datEncount.tbl[1277].devil[0] = 362;
            datEncount.tbl[1277].backattack = -1;
            datEncount.tbl[1277].btlsound = 5;
            datEncount.tbl[1277].flag = 13;
            datEncount.tbl[1277].formationtype = 0;
            datEncount.tbl[1277].areaid = 6;
            datEncount.tbl[1277].stageid = 220;
            datEncount.tbl[1277].maxcall = 0;
            datEncount.tbl[1277].maxparty = 0;

            // YHVH
            datEncount.tbl[1278].devil[0] = 254;
            datEncount.tbl[1278].backattack = -1;
            datEncount.tbl[1278].btlsound = 19;
            datEncount.tbl[1278].flag = 11;
            datEncount.tbl[1278].formationtype = 13;
            datEncount.tbl[1278].areaid = 2;
            datEncount.tbl[1278].stageid = 246;
            datEncount.tbl[1278].maxcall = 0;
            datEncount.tbl[1278].maxparty = 0;
        }
    }
}
