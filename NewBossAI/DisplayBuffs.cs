using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using Il2Cppnewbattle_H;
using UnityEngine;

namespace NewBossAI
{
    internal partial class NewBossAI : MelonMod
    {
        static sbyte target_formindex = 0; // Formindex of the target we want to display the buffs of

        // Before displaying the text box
        [HarmonyPatch(typeof(nbHelpProcess), nameof(nbHelpProcess.nbDispText))]
        private class DisplayBuffsPatch
        {
            public static void Prefix(ref string text2)
            {
                string nickname = frName.frGetCNameString(0); // Gets the player's nickname

                if (nbMainProcess.nbGetUnitWorkFromFormindex(target_formindex) == null) return; // If the target died since last time, return

                string demonname = datDevilName.Get(nbMainProcess.nbGetUnitWorkFromFormindex(target_formindex).id); // Gets the demon's name

                // If displayng the name of the single target
                if ((target_formindex == 0 && text2 == nickname) || (target_formindex != 0 && text2 == demonname))
                {
                    // Gets the type with the buffs info
                    nbParty_t party_member = nbMainProcess.nbGetPartyFromFormindex(target_formindex);

                    // If there is at least one buffed applied
                    if (Utility.AtLeastOneBuff(party_member))
                    {
                        // Converts the buffs info into a list of strings with the proper format
                        List<string> buffs_strings = Utility.GetBuffStrings(party_member);

                        // Converts the list of strings into one continuous string to put after the target's name
                        text2 += Utility.GetBuffLine(buffs_strings);

                        // Makes the text box bigger
                        Utility.ChangeBoxSize();
                    }
                    else
                    {
                        // Reverts the box size
                        Utility.RevertBoxSize();
                    }
                }
                else
                {
                    // Reverts the box size
                    Utility.RevertBoxSize();
                }
            }
        }

        // Before displaying the target's info
        [HarmonyPatch(typeof(nbTarSelProcess), nameof(nbTarSelProcess.DispTargetHelp))]
        private class DisplayBuffsPatch2
        {
            public static void Prefix(ref nbTarSelProcessData_t t)
            {
                // If single target action then remember who was the target
                if (t.ctype == 0) target_formindex = t.nowform;
            }
        }






        private class Utility
        {
            // Converts the buffs info into a list of strings with the proper format
            public static List<string> GetBuffStrings(nbParty_t party)
            {
                List<string> buffs_strings = new List<string>();

                for (int i = 4; i < 8; i++)
                {
                    string buff = "";

                    if (party.count[i] != 0)
                    {
                        if (party.count[i] > 0)
                        {
                            buff += "+";
                        }
                        buff += party.count[i].ToString();
                    }
                    buffs_strings.Add(buff);
                }

                return buffs_strings;
            }

            // Converts the list of strings into one continuous string to put after the target's name
            public static string GetBuffLine(List<string> buffs_strings)
            {
                string result = "\n ";

                if (buffs_strings[0] != "")
                {
                    result += "AT:" + buffs_strings[0];
                }

                if (buffs_strings[1] != "")
                {
                    if (result != "\n ") result += " ";
                    result += "MA:" + buffs_strings[1];
                }

                if (buffs_strings[3] != "")
                {
                    if (result != "\n ") result += " ";
                    result += "DF:" + buffs_strings[3];
                }

                if (buffs_strings[2] != "")
                {
                    if (result != "\n ") result += " ";
                    result += "HT:" + buffs_strings[2];
                }

                return result;
            }

            // Checks if the target has at least one buff applied
            public static bool AtLeastOneBuff(nbParty_t party)
            {
                for (int i = 4; i < 8; i++)
                {
                    if (party.count[i] != 0)
                    {
                        return true;
                    }
                }

                return false;
            }

            // Makes the text box bigger
            public static void ChangeBoxSize()
            {
                nbMainProcess.GetBattleUI().transform.Find("../bannounce(Clone)/bannounce01").gameObject.transform.localScale = new Vector3(1f, 2.5f, 1f);
                nbMainProcess.GetBattleUI().transform.Find("../bannounce(Clone)/stretch/bannounce02").gameObject.transform.localScale = new Vector3(1f, 2.5f, 1f);
                nbMainProcess.GetBattleUI().transform.Find("../bannounce(Clone)/bannounce03").gameObject.transform.localScale = new Vector3(1f, 2.5f, 1f);
            }

            // Reverts the box size
            public static void RevertBoxSize()
            {
                nbMainProcess.GetBattleUI().transform.Find("../bannounce(Clone)/bannounce01").gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                nbMainProcess.GetBattleUI().transform.Find("../bannounce(Clone)/stretch/bannounce02").gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                nbMainProcess.GetBattleUI().transform.Find("../bannounce(Clone)/bannounce03").gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }
}