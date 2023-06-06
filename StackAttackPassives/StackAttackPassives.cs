using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2Cppnewbattle_H;

[assembly: MelonInfo(typeof(StackAttackPassives.StackAttackPassives), "Stack Attack Passives", "1.0.0", "Zephhyr")]
[assembly: MelonGame("", "smt3hd")]

namespace StackAttackPassives
{
    internal class StackAttackPassives : MelonMod
    {
        public override void OnInitializeMelon()
        {
            datSpecialSkill.tbl[11].n = 750;
            datSpecialSkill.tbl[14].n = 1;
        }

        [HarmonyPatch(typeof(nbCalc), "nbGetHitType")]
        private class GetHitTypePatch
        {
            public static void Postfix(ref nbActionProcessData_t ad, ref int nskill, ref int sformindex, ref int dformindex, ref int __result)
            {
                if (__result == 1 && (ad.autoskill == 300 || ad.autoskill == 301))
                {
                    Random rand = new Random();
                    __result = rand.Next(2);
                    ad.autoskill = 0;
                }
                else if (ad.autoskill == 299)
                    ad.autoskill = 0;
            }
        }

        [HarmonyPatch(typeof(Localize), "GetLocalizeText", new Type[] { typeof(string) })]
        private class LocalizeNamesPatch
        {
            public static bool Prefix(ref string ID, ref string __result)
            {
                switch (ID)
                {
                    case "<DATSKILLHELP_L0299>":
                        {
                            __result = "Greatly raises critical\nhit rate of normal attacks.";
                            return false;
                        }
                    case "<DATSKILLHELP_L0300>":
                        {
                            __result = "Drastically raises critical\nhit rate of normal attacks\nduring full Kagutsuchi.";
                            return false;
                        }
                    case "<DATSKILLHELP_L0301>":
                        {
                            __result = "Drastically raises critical\nhit rate of normal attacks\nduring new Kagutsuchi.";
                            return false;
                        }
                    default: return true;
                }
            }
        }
    }
}