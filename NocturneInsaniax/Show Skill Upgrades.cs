using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppnewdata_H;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        [HarmonyPatch(typeof(frFont), nameof(frFont.frReplaceLocalizeText))]
        private class SkillChangePatch
        {
            public static void Postfix(ref string message, ref frMsgInfo_t mi, ref List<int> index, ref string __result)
            {
                if (rstinit.GBWK != null)
                {
                    var data = rstinit.GBWK;
                    if (data.PUpSkillResult != 0)
                    {
                        var PUpSkillIndex = data.PUpSkillIndex;
                        var PUpSkillID = data.PUpSkillID;
                        var currentSkillName = datSkillName.Get(data.pCurrentStock.skill[PUpSkillIndex]);
                        var newSkillName = datSkillName.Get(PUpSkillID);

                        if (__result.Contains("to change a skill..."))
                            __result = __result.Replace("to change a skill...", "to change <CO4>" + currentSkillName + "<CO0> to <CO4>" + newSkillName + "<CO0>...");
                    }
                }
            }
        }
    }
}
