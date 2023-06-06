using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;

[assembly: MelonInfo(typeof(NerfedMasakados.NerfedMasakados), "Nerfed Masakados", "1.0.0", "Zephhyr")]
[assembly: MelonGame("", "smt3hd")]

namespace NerfedMasakados
{
    internal class NerfedMasakados : MelonMod
    {
        public override void OnInitializeMelon()
        {
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