using HarmonyLib;
using MelonLoader;
using Il2Cppnewbattle_H;
using System.Collections.Generic;
using Il2Cpp;

[assembly: MelonInfo(typeof(DemonsCanUseItems.DemonsCanUseItems), "Demons Can Use Items", "1.0.2", "Zephhyr")]
[assembly: MelonGame("", "smt3hd")]

namespace DemonsCanUseItems
{
    internal class DemonsCanUseItems : MelonMod
    {
        [HarmonyPatch(typeof(nbCommSelProcess), "DispCommandList2")]
        private class Patch
        {
            public static void Prefix(ref nbCommSelProcessData_t s, ref int type, ref int ox, ref int oy, ref int a)
            {
                if (s.my.formindex != 0)
                {
                    var items = dds3GlobalWork.DDS3_GBWK.item;
                    var itemIndices = new List<ushort>();
                    for (ushort i = 0; i <= 56; i++)
                        if (items[i] != 0 && datItem.tbl[i].use >= 2 && datItem.tbl[i].skillid != 72)
                            itemIndices.Add(i);

                    var itemCommands = new ushort[288];
                    for (ushort i = 0; i < itemIndices.Count; i++)
                        itemCommands[i] = itemIndices[i];

                    s.commlist[2] = itemCommands;
                    s.commcnt[2] = itemIndices.Count;
                }
            }
        }
    }
}
