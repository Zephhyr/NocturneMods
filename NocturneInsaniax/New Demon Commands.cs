using HarmonyLib;
using MelonLoader;
using Il2Cppnewbattle_H;
using Il2Cpp;
using Newtonsoft.Json;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        [HarmonyPatch(typeof(nbCommSelProcess), nameof(nbCommSelProcess.DispCommandList2))]
        private class NewCommandsPatch
        {
            public static void Prefix(ref nbCommSelProcessData_t s, ref int type, ref int ox, ref int oy, ref int a)
            {
                actionProcessData = s.act;

                if (nbMainProcess.nbGetUnitWorkFromFormindex(s.my.formindex).id != 0)
                {
                    // Self-Switch
                    var party = s.data.party;
                    var partyIndices = new List<short>();
                    for (ushort i = 0; i <= 3; i++)
                        if (party[i].statindex != 0)
                            partyIndices.Add(party[i].statindex);

                    var stock = dds3GlobalWork.DDS3_GBWK.stocklist.Distinct().Where(x => x != 0 && dds3GlobalWork.DDS3_GBWK.unitwork[x].id != 0);
                    var stockIndices = new List<ushort>();
                    foreach (var i in stock)
                        if (!partyIndices.Contains((short)i))
                            stockIndices.Add((ushort)i);

                    var stockCommands = new ushort[288];
                    for (ushort i = 0; i < stockIndices.Count; i++)
                        stockCommands[i] = stockIndices[i];

                    var stockDisableCommands = new sbyte[288];
                    foreach (var i in stock)
                    {
                        if (dds3GlobalWork.DDS3_GBWK.unitwork[i].hp == 0) stockDisableCommands[Array.IndexOf(stockCommands, (ushort) i)] = 4;
                    }

                    s.commlist[3] = stockCommands;
                    s.commdisable[3] = stockDisableCommands;
                    s.commcnt[3] = stockIndices.Count;

                    // Prevent Talking in NKEs
                    if (s.act.data.encno == 1270 || s.act.data.encno == 1271 || s.act.data.encno == 1272)
                    {
                        for (int i = 0; i < s.commlist[1].Length; i++)
                            if (s.commlist[1][i] > 0)
                                s.commdisable[1][i] = 1;
                    }

                    // Use Items
                    if (datCalc.datCheckSyojiSkill(nbMainProcess.nbGetUnitWorkFromFormindex(s.my.formindex), 367) != 0)
                    //if (true)
                    {
                        var items = dds3GlobalWork.DDS3_GBWK.item;
                        var itemIndices = new List<ushort>();
                        for (ushort i = 0; i <= 63; i++)
                            if (items[i] != 0 && datItem.tbl[i].use >= 2)
                                itemIndices.Add(i);

                        var itemCommands = new ushort[288];
                        for (ushort i = 0; i < itemIndices.Count; i++)
                            itemCommands[i] = itemIndices[i];

                        var itemDisableCommands = new sbyte[288];
                        if (datEncount.tbl[s.act.data.encno].esc == 1 && itemCommands.Contains((ushort)56))
                            itemDisableCommands[Array.IndexOf(itemCommands, (ushort)56)] = 1;

                        // Toggle item use in battle
                        if (ToggleItemUseInBattle.Value == false)
                        {
                            for (int i = 0; i < itemDisableCommands.Length; i++)
                                itemDisableCommands[i] = 1;
                        }

                        s.commlist[2] = itemCommands;
                        s.commdisable[2] = itemDisableCommands;
                        s.commcnt[2] = itemIndices.Count;
                    }


                    //Test - Add all skills
                    //var skillCommands = new ushort[288];
                    //for (ushort i = 0; i < 288; i++)
                    //    skillCommands[i] = i;
                    //skillCommands[0] = s.commlist[0][0];
                    //skillCommands[1] = 481;
                    ////skillCommands[2] = 134;
                    ////skillCommands[3] = 141;

                    //s.commlist[0] = skillCommands;
                    //s.commcnt[0] = 288;
                }
                else
                {
                    // Prevent Talking in NKEs
                    if (s.act.data.encno == 1270 || s.act.data.encno == 1271 || s.act.data.encno == 1272) 
                    {
                        for (int i = 0; i < s.commlist[1].Length; i++)
                            if (s.commlist[1][i] > 0)
                                s.commdisable[1][i] = 1;
                    }

                    // Toggle item use in battle
                    if (ToggleItemUseInBattle.Value == false)
                    {
                        var itemDisableCommands = new sbyte[288];

                        for (int i = 0; i < itemDisableCommands.Length; i++)
                            itemDisableCommands[i] = 1;

                        s.commdisable[2] = itemDisableCommands;
                    }

                    //Test - Add all skills
                    //var skillCommands = new ushort[288];
                    //for (ushort i = 0; i < 288; i++)
                    //    skillCommands[i] = i;
                    //skillCommands[0] = s.commlist[0][0];
                    //skillCommands[1] = 480;
                    ////skillCommands[2] = 477;
                    ////skillCommands[3] = 478;

                    //s.commlist[0] = skillCommands;
                    //s.commcnt[0] = 288;
                }
            }
        }

        [HarmonyPatch(typeof(nbTarSelProcess), nameof(nbTarSelProcess.nbSetTargetProcess))]
        private class NewCommandsPatch1
        {
            public static void Prefix(nbActionProcessData_t act, ref int partyindex, ref int ctype, ref int crule, ref int carea)
            {
                actionProcessData = act;

                if (act.work.id != 0 && ctype == 0 && (crule == 12 || crule == 2) && carea == 1 && act.work.nowcommand == 6)
                    crule = 1;
            }
        }
    }
}
