using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        [HarmonyPatch(typeof(cmpDrawStatus), nameof(cmpDrawStatus.cmpDrawSkill))]
        private class DisplayFutureSkillsPatch
        {
            public static void Postfix(datUnitWork_t pStock, rstSkillInfo_t pSkillInfo)
            {
                for (int i = 0; i < pSkillInfo.SkillID.Length; i++)
                {
                    ushort skillID = pSkillInfo.SkillID[i];
                    if (skillID == 0) break;
                    if (skillID == 425 && pStock.id == 0)
                    {
                        // If you can get Pierce without TDE (mod) but aren't high level level enough
                        if (EventBit.evtBitCheck(2241))
                        {
                            cmpStatus._statusUIScr.awaitText[i].text = "<material=\"TMC14\">？"; // Displays a "？"
                        }
                        continue; //Skip Pierce on Demi-fiend
                    }

                    string name = datSkillName.Get(skillID, pStock.id);
                    cmpStatus._statusUIScr.awaitText[i].text = "<material=\"TMC14\">" + name;
                }
            }
        }
    }
}