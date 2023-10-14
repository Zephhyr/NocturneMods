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


                //if (true)
                if (evtMoon.evtGetAgeOfMoon() == 0 && datEncount.tbl[encno].btlsound == 0)
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

                case 9: AmalaNetworkShiisaaEncounter(); return 1270;

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

        private static void AmalaNetworkShiisaaEncounter()
        {
            datEncount.tbl[1270].devil[0] = 33;
            datEncount.tbl[1270].devil[1] = 33;
        }

        //------------------------------------------------------------

        private static void ApplyEncounterChanges()
        {
            datEncount.tbl[1269].flag = 13; // Forced Kodama + Will o' Wisp in Unknown Realm
            datEncount.tbl[14].flag = 11; // Boss Forneus
        }
    }
}
