using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;

[assembly: MelonInfo(typeof(HardtypeMasakados.HardtypeMasakados), "Hardtype Masakados", "1.0.0", "Zephhyr")]
[assembly: MelonGame("", "smt3hd")]

namespace HardtypeMasakados
{
    internal class HardtypeMasakados : MelonMod
    {
        public override void OnInitializeMelon()
        {
            tblHearts.fclHeartsTbl[25].GrowParamTbl[5] = 10;
            tblHearts.fclHeartsTbl[25].MasterGrowParamTbl[5] = 10;

            tblHearts.fclHeartsTbl[25].Skill[1].ID = 339;
            tblHearts.fclHeartsTbl[25].Skill[2].ID = 340;
            tblHearts.fclHeartsTbl[25].Skill[3].ID = 341;
            tblHearts.fclHeartsTbl[25].Skill[4].ID = 342;
            tblHearts.fclHeartsTbl[25].Skill[5].ID = 338;
            tblHearts.fclHeartsTbl[25].Skill[6].ID = 348;

            datAisyo.tbl[432][0] = 50;
            datAisyo.tbl[432][1] = 50;
            datAisyo.tbl[432][2] = 50;
            datAisyo.tbl[432][3] = 50;
            datAisyo.tbl[432][4] = 50;
            datAisyo.tbl[432][11] = 100;

            datAisyo.tbl[433][0] = 50;
            datAisyo.tbl[433][1] = 50;
            datAisyo.tbl[433][2] = 50;
            datAisyo.tbl[433][3] = 50;
            datAisyo.tbl[433][4] = 50;
            datAisyo.tbl[433][11] = 100;
        }

        [HarmonyPatch(typeof(Localize), "GetLocalizeText", new Type[] { typeof(string) })]
        private class Patch
        {
            public static void Postfix(ref string ID, ref string __result)
            {
                if (__result.Contains("Null: All except Almighty"))
                {
                    __result = __result.Replace("Null: All except Almighty", "Null: Light/Dark/Ailments • Str: All Other");
                }

            }
        }
    }
}