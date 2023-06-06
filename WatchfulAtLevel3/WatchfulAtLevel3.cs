using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;

[assembly: MelonInfo(typeof(WatchfulAtLevel3.WatchfulAtLevel3), "Watchful At Level3", "1.0.0", "Zephhyr")]
[assembly: MelonGame("", "smt3hd")]

namespace WatchfulAtLevel3
{
    internal class WatchfulAtLevel3 : MelonMod
    {
        public override void OnInitializeMelon()
        {
            tblHearts.fclHeartsTbl[1].Skill[0].ID = 354;
        }
    }
}