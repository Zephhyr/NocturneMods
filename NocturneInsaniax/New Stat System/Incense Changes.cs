using HarmonyLib;
using Il2Cpp;
using Il2Cppcamp_H;
using Il2Cppfacility_H;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2Cppnewbattle_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2CppTMPro;
using MelonLoader;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        private static void ApplyIncenseChanges()
        {
            // If Enabled, add the Int Incense to the Lucky Ticket Prizes.
            if (EnableIntStat)
            {
                // Lucky Ticket Item Box Prizes
                for (int i = 0; i < 7; i++)
                {
                    // Change the Incense Items and add the Int Incense.
                    if (i > 1)
                    {
                        fclJunkShopTable.fclShopItemBoxTbl[1][i].ItemID = (byte)(0x26 + i - 1);
                        fclJunkShopTable.fclShopItemBoxTbl[1][i].Rate = 10;
                    }
                    // Adjusting the Incense's drop rate because I believe it's necessary.
                    else
                    { fclJunkShopTable.fclShopItemBoxTbl[1][i].Rate = 40; }
                }
            }
        }
    }
}
