using HarmonyLib;
using MelonLoader;
using newdata_H;
using StandardLibrary;

[assembly: MelonInfo(typeof(MyMod), "My Mod Name", "1.0.0", "Zephhyr")]
[assembly: MelonGame("", "smt3hd")]

namespace StandardLibrary
{
    class MyMod : MelonMod
    {
        public override void OnInitializeMelon()
        {
        }

        [HarmonyPatch(typeof(datDevilFormat))]
        private class Patch
        {
            public static void PreFix() 
            {
            }

            public static void PostFix() 
            {
            }

            public static void Transpiler() {
            }

            public static void Finalizer() {
            }
        }

    }
}