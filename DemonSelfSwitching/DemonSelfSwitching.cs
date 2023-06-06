using HarmonyLib;
using MelonLoader;
using Il2Cppnewbattle_H;
using System.Collections.Generic;
using System.Linq;
using Il2Cpp;

[assembly: MelonInfo(typeof(DemonSelfSwitching.DemonSelfSwitching), "Demons Can Self-Switch", "1.1.0", "Zephhyr")]
[assembly: MelonGame("", "smt3hd")]

namespace DemonSelfSwitching
{
    internal class DemonSelfSwitching : MelonMod
    {
        [HarmonyPatch(typeof(nbCommSelProcess), "DispCommandList2")]
        private class Patch
        {
            public static void Prefix(ref nbCommSelProcessData_t s, ref int type, ref int ox, ref int oy, ref int a)
            {
                if (s.my.formindex != 0)
                {
                    var party = s.data.party;
                    var partyIndices = new List<short>();
                    for (ushort i = 0; i <= 3; i++)
                        if (party[i].statindex != 0)
                            partyIndices.Add(party[i].statindex);

                    var stock = dds3GlobalWork.DDS3_GBWK.stocklist.Distinct();
                    if (stock.Count() > (dds3GlobalWork.DDS3_GBWK.unitwork.Where(x => x.id != 0).Count() + 1))
                        stock = stock.SkipLast(stock.Count() - (dds3GlobalWork.DDS3_GBWK.unitwork.Where(x => x.id != 0).Count() + 1));

                    var stockIndices = new List<ushort>();
                    foreach (var i in stock.Where(x => x != 0))
                        if (!partyIndices.Contains((short)i))
                            stockIndices.Add((ushort)i);

                    var stockCommands = new ushort[288];
                    for (ushort i = 0; i < stockIndices.Count; i++)
                        stockCommands[i] = stockIndices[i];

                    s.commlist[3] = stockCommands;
                    s.commcnt[3] = stockIndices.Count;
                }
            }
        }

        [HarmonyPatch(typeof(nbTarSelProcess), "nbSetTargetProcess")]
        private class Patch1
        {
            public static void Prefix(nbActionProcessData_t act, ref int partyindex, ref int ctype, ref int crule, ref int carea)
            {
                if (partyindex != 0 && ctype == 0 && (crule == 12 || crule == 2) && carea == 1 && act.work.nowcommand == 6)
                    crule = 1;
            }
        }
    }
}
