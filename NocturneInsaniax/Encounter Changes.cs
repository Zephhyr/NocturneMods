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
                MelonLogger.Msg("nbMisc.nbSetRenzokuEncount");
            }
        }

        [HarmonyPatch(typeof(nbMainProcess), nameof(nbMainProcess.nbInitMainProcess))]
        private class nbInitMainProcessPatch
        {
            public static void Prefix(ref int encpackno, ref int packno, ref int packindex, ref int encno, ref int stagemajor, ref int stageminor)
            {
                MelonLogger.Msg("nbMainProcess.nbInitMainProcess");
                MelonLogger.Msg("encpackno: " + encpackno);

                //if (dds3GlobalWork.DDS3_GBWK.hearts.Contains(9) || dds3ConfigMain.cfgGetBit(9u) == 0)
                //{
                //    encno = 1278;
                //    return;
                //}
                if (true)
                //if (evtMoon.evtGetAgeOfMoon() == 0 && datEncount.tbl[encno].btlsound == 0 && random.Next(2) == 0)
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
        //        MelonLogger.Msg("nbNegoProcess.nbInitNegoProcess");
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

                case 14: OverworldArchangelEncounter(); return 1270;

                case 15: HarumiWarehouseChatterskullEncounter(); return 1270;

                case 16: UnderpassAmeNoUzumeEncounter(); return 1270;
                case 128: UnderpassAmeNoUzumeEncounter(); return 1270;

                case 19: UnderpassForneusEncounter(); return 1270;
                case 20: UnderpassForneusEncounter(); return 1270;

                case 17: UnderpassAmeNoUzumeEncounter(); return 1270;
                case 18: UnderpassAmeNoUzumeEncounter(); return 1270;
                case 129: UnderpassAmeNoUzumeEncounter(); return 1270;
                case 130: UnderpassAmeNoUzumeEncounter(); return 1270;

                case 22: OverworldUnicornEncounter(); return 1270;

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

                default: return encno;
            }
        }

        private static void ShinjukuMedicalCentreSlimeEncounter()
        {
            datEncount.tbl[1270].devil[0] = 135;

            datEncount.tbl[1271].devil[0] = 135;
            datEncount.tbl[1271].devil[1] = 135;
        }

        private static void Overworld1MouRyoZhenEncounter()
        {
            datEncount.tbl[1270].devil[0] = 136;
            datEncount.tbl[1270].devil[1] = 136;

            datEncount.tbl[1271].devil[0] = 126;
            datEncount.tbl[1271].devil[1] = 126;
            datEncount.tbl[1271].devil[2] = 126;
        }

        private static void Overworld1AngelEncounter()
        {
            datEncount.tbl[1270].devil[0] = 68;
            datEncount.tbl[1270].devil[1] = 68;
        }

        private static void YoyogiParkHighPixieEncounter()
        {
            datEncount.tbl[1270].devil[0] = 61;
            datEncount.tbl[1270].devil[1] = 59;
            datEncount.tbl[1270].devil[2] = 61;
        }

        private static void ShibuyaChoronzonEncounter()
        {
            datEncount.tbl[1270].devil[0] = 130;

            datEncount.tbl[1271].devil[0] = 136;
            datEncount.tbl[1271].devil[1] = 130;
            datEncount.tbl[1271].devil[2] = 136;
        }

        private static void AmalaNetworkAquansEncounter()
        {
            datEncount.tbl[1270].devil[0] = 37;
        }

        private static void GinzaShiisaaEncounter()
        {
            datEncount.tbl[1270].devil[0] = 33;
            datEncount.tbl[1270].devil[1] = 33;
        }

        private static void OverworldArchangelEncounter()
        {
            datEncount.tbl[1270].devil[0] = 67;
            datEncount.tbl[1270].devil[1] = 67;
        }

        private static void HarumiWarehouseChatterskullEncounter()
        {
            datEncount.tbl[1270].devil[0] = 177;
            datEncount.tbl[1270].devil[1] = 177;
            datEncount.tbl[1270].devil[2] = 177;
        }

        private static void UnderpassAmeNoUzumeEncounter()
        {
            datEncount.tbl[1270].maxcall = 1;
            datEncount.tbl[1270].maxparty = 3;

            datEncount.tbl[1270].devil[0] = 90;
            datEncount.tbl[1270].devil[1] = 11;
            datEncount.tbl[1270].devil[2] = 90;
        }

        private static void UnderpassForneusEncounter()
        {
            datEncount.tbl[1270].devil[0] = 50;
            datEncount.tbl[1270].devil[1] = 74;
            datEncount.tbl[1270].devil[2] = 50;
        }

        private static void OverworldUnicornEncounter()
        {
            datEncount.tbl[1270].maxcall = 8;
            datEncount.tbl[1270].maxparty = 3;

            datEncount.tbl[1270].devil[0] = 125;
            datEncount.tbl[1270].devil[1] = 35;
            datEncount.tbl[1270].devil[2] = 125;
        }

        private static void IkebukuroTakeMinakataEncounter()
        {
            datEncount.tbl[1270].devil[0] = 28;
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
        }

        private static void GinzaMakamiEncounter()
        {
            datEncount.tbl[1270].maxparty = 3;

            datEncount.tbl[1270].devil[0] = 0;
            datEncount.tbl[1270].devil[1] = 151;
            datEncount.tbl[1270].devil[2] = 0;
        }

        private static void AssemblyOfNihiloXuanwuKikuriHimeEncounter()
        {
            datEncount.tbl[1270].devil[0] = 149;
            datEncount.tbl[1270].devil[1] = 20;
        }

        private static void KabukichoPrisonXiezhaiEncounter()
        {
            datEncount.tbl[1270].devil[0] = 34;
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
            datEncount.tbl[1033].flag = 11; // Boss Raidou/Dante 1

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

            datEncount.tbl[1278].devil[0] = 400;
        }
    }
}
