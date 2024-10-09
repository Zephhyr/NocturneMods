using HarmonyLib;
using MelonLoader;
using Il2Cppnewbattle_H;
using System.Collections.Generic;
using System.Linq;
using Il2Cpp;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        [HarmonyPatch(typeof(nbCommSelProcess), nameof(nbCommSelProcess.DispCommandList2))]
        private class NewCommandsPatch
        {
            public static void Prefix(ref nbCommSelProcessData_t s, ref int type, ref int ox, ref int oy, ref int a)
            {
                if (nbMainProcess.nbGetUnitWorkFromFormindex(s.my.formindex).id != 0)
                {
                    // Self-Switch
                    var party = s.data.party;
                    var partyIndices = new List<short>();
                    for (ushort i = 0; i <= 3; i++)
                        if (party[i].statindex != 0)
                            partyIndices.Add(party[i].statindex);

                    var stock = dds3GlobalWork.DDS3_GBWK.stocklist.Distinct();
                    if (stock.Count() > (dds3GlobalWork.DDS3_GBWK.unitwork.Where(x => x.id != 0 && x.hp > 0).Count() + 1))
                        stock = stock.SkipLast(stock.Count() - (dds3GlobalWork.DDS3_GBWK.unitwork.Where(x => x.id != 0 && x.hp > 0).Count() + 1));

                    var stockIndices = new List<ushort>();
                    foreach (var i in stock.Where(x => x != 0))
                        if (!partyIndices.Contains((short)i))
                            stockIndices.Add((ushort)i);

                    var stockCommands = new ushort[288];
                    for (ushort i = 0; i < stockIndices.Count; i++)
                        stockCommands[i] = stockIndices[i];

                    s.commlist[3] = stockCommands;
                    s.commcnt[3] = stockIndices.Count;

                    // Use Items
                    if (datCalc.datCheckSyojiSkill(nbMainProcess.nbGetUnitWorkFromFormindex(s.my.formindex), 367) != 0)
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


                    // Test - Add all skills
                    //var skillCommands = new ushort[288];
                    //for (ushort i = 0; i < 288; i++)
                    //    skillCommands[i] = i;
                    //skillCommands[0] = s.commlist[0][0];
                    ////skillCommands[1] = 475;
                    ////skillCommands[2] = 469;
                    ////skillCommands[3] = 443;

                    //s.commlist[0] = skillCommands;
                    //s.commcnt[0] = 288;
                }
                //else
                //{
                //    // Test - Add all skills
                //    var skillCommands = new ushort[288];
                //    for (ushort i = 0; i < 288; i++)
                //        skillCommands[i] = i;
                //    skillCommands[0] = s.commlist[0][0];

                //    s.commlist[0] = skillCommands;
                //    s.commcnt[0] = 288;
                //}
            }
        }

        [HarmonyPatch(typeof(nbTarSelProcess), nameof(nbTarSelProcess.nbSetTargetProcess))]
        private class NewCommandsPatch1
        {
            public static void Prefix(nbActionProcessData_t act, ref int partyindex, ref int ctype, ref int crule, ref int carea)
            {
                actionProcessData = act;

                if (partyindex != 0 && ctype == 0 && (crule == 12 || crule == 2) && carea == 1 && act.work.nowcommand == 6)
                    crule = 1;
            }
        }
    }
}
