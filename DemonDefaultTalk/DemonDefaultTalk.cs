using HarmonyLib;
using MelonLoader;
using Il2Cppnewbattle_H;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Il2Cpp;

[assembly: MelonInfo(typeof(DemonDefaultTalk.DemonDefaultTalk), "Demons Can Use The Default Talk Command", "1.0.1", "Zephhyr")]
[assembly: MelonGame("", "smt3hd")]

namespace DemonDefaultTalk
{
    internal class DemonDefaultTalk : MelonMod
    {
        [HarmonyPatch(typeof(nbCommSelProcess), "DispCommandList2")]
        private class Patch
        {
            public static void Prefix(ref nbCommSelProcessData_t s, ref int type, ref int ox, ref int oy, ref int a)
            {
                if (s.my.formindex != 0)
                {
                    var talkIndices = new List<ushort>{ 32772 };
                    var talkSkills = s.commlist[1].ToList().Where(x => x != 0);

                    if (talkSkills.Any(x => x != 0))
                        talkIndices.AddRange(talkSkills);

                    talkIndices = talkIndices.Distinct().ToList();

                    var talkCommands = new ushort[288];
                    for (ushort i = 0; i < talkIndices.Count; i++)
                        talkCommands[i] = talkIndices[i];

                    s.commlist[1] = talkCommands;
                    s.commcnt[1] = talkIndices.Count;
                }
            }
        }
    }
}
