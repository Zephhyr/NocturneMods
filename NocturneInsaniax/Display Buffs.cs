﻿using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using Il2Cppnewbattle_H;
using UnityEngine;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
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
                ushort demonlevel = nbMainProcess.nbGetUnitWorkFromFormindex(target_formindex).level; // Gets the demon's name

                // If displayng the name of the single target
                if ((target_formindex == 0 && text2 == nickname) || (target_formindex != 0 && text2 == demonname))
                {
                    if (EnableEnemyLevelDisplay.Value)
                        text2 += "   Lv" + demonlevel;

                    // Gets the type with the buffs info
                    nbParty_t party_member = nbMainProcess.nbGetPartyFromFormindex(target_formindex);

                    // If there is at least one buffed applied
                    if (DisplayBuffsUtility.AtLeastOneBuff(party_member))
                    {
                        // Converts the buffs info into a list of strings with the proper format
                        List<string> buffs_strings = DisplayBuffsUtility.GetBuffStrings(party_member);

                        // Converts the list of strings into one continuous string to put after the target's name
                        text2 += DisplayBuffsUtility.GetBuffLine(buffs_strings);

                        // Makes the text box bigger
                        DisplayBuffsUtility.ChangeBoxSize();
                    }
                    else
                    {
                        // Reverts the box size
                        DisplayBuffsUtility.RevertBoxSize();
                    }
                }
                else
                {
                    // Reverts the box size
                    DisplayBuffsUtility.RevertBoxSize();
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






        private class DisplayBuffsUtility
        {
            // Converts the buffs info into a list of strings with the proper format
            public static List<string> GetBuffStrings(nbParty_t party)
            {
                List<string> buffs_strings = new List<string>();

                // Stat buffs
                for (int i = 4; i <= 8; i++)
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

                // Charge buffs
                if (party.count[15] > 0 && party.count[20] > 0)
                    buffs_strings.Add("3");
                else if (party.count[15] > 0 && party.count[20] == 0)
                    buffs_strings.Add("1");
                else if (party.count[15] == 0 && party.count[20] > 0)
                    buffs_strings.Add("2");
                else buffs_strings.Add("0");

                // Tetrakarn/Makarakarn
                if (party.count[13] > 0 && party.count[14] > 0)
                    buffs_strings.Add("3");
                else if (party.count[13] > 0 && party.count[14] == 0)
                    buffs_strings.Add("1");
                else if (party.count[13] == 0 && party.count[14] > 0)
                    buffs_strings.Add("2");
                else buffs_strings.Add("0");

                return buffs_strings;
            }

            // Converts the list of strings into one continuous string to put after the target's name
            public static string GetBuffLine(List<string> buffs_strings)
            {
                string result = "\n ";

                if (buffs_strings[0] != "")
                {
                    buffs_strings[0] = buffs_strings[0].Contains("+")
                        ? "<material=\"MsgFont4\">" + buffs_strings[0] + "<material=\"MsgFont0\">"
                        : "<material=\"MsgFont1\">" + buffs_strings[0] + "<material=\"MsgFont0\">";
                    result += "AT:" + buffs_strings[0];
                }

                if (buffs_strings[1] != "")
                {
                    if (result != "\n ") result += " ";
                    buffs_strings[1] = buffs_strings[1].Contains("+")
                        ? "<material=\"MsgFont4\">" + buffs_strings[1] + "<material=\"MsgFont0\">"
                        : "<material=\"MsgFont1\">" + buffs_strings[1] + "<material=\"MsgFont0\">";
                    result += "MA:" + buffs_strings[1];
                }

                if (buffs_strings[3] != "")
                {
                    if (result != "\n ") result += " ";
                    buffs_strings[3] = buffs_strings[3].Contains("+")
                        ? "<material=\"MsgFont4\">" + buffs_strings[3] + "<material=\"MsgFont0\">"
                        : "<material=\"MsgFont1\">" + buffs_strings[3] + "<material=\"MsgFont0\">";
                    result += "DF:" + buffs_strings[3];
                }

                if (buffs_strings[4] != "")
                {
                    if (result != "\n ") result += " ";
                    buffs_strings[4] = buffs_strings[4].Contains("+")
                        ? "<material=\"MsgFont4\">" + buffs_strings[4] + "<material=\"MsgFont0\">"
                        : "<material=\"MsgFont1\">" + buffs_strings[4] + "<material=\"MsgFont0\">";
                    result += "HT:" + buffs_strings[4];
                }

                if (buffs_strings[2] != "")
                {
                    if (result != "\n ") result += " ";
                    buffs_strings[2] = buffs_strings[2].Contains("+")
                        ? "<material=\"MsgFont4\">" + buffs_strings[2] + "<material=\"MsgFont0\">"
                        : "<material=\"MsgFont1\">" + buffs_strings[2] + "<material=\"MsgFont0\">";
                    result += "EV:" + buffs_strings[2];
                }

                switch (buffs_strings[5])
                {
                    case "1":
                        {
                            if (result != "\n ") result += "  ";
                            result += "<material=\"MsgFont3\">Focus<material=\"MsgFont0\">";
                            break;
                        }
                    case "2":
                        {
                            if (result != "\n ") result += "  ";
                            result += "<material=\"MsgFont3\">Concentrate<material=\"MsgFont0\">";
                            break;
                        }
                    case "3":
                        {
                            if (result != "\n ") result += "  ";
                            result += "<material=\"MsgFont3\">Animus<material=\"MsgFont0\">";
                            break;
                        }
                    default: break;
                }

                switch (buffs_strings[6])
                {
                    case "1":
                        {
                            if (result != "\n ") result += "  ";
                            result += "<material=\"MsgFont2\">Makarakarn<material=\"MsgFont0\">";
                            break;
                        }
                    case "2":
                        {
                            if (result != "\n ") result += "  ";
                            result += "<material=\"MsgFont2\">Tetrakarn<material=\"MsgFont0\">";
                            break;
                        }
                    case "3":
                        {
                            if (result != "\n ") result += "  ";
                            result += "<material=\"MsgFont2\">Tetra/Makarakarn<material=\"MsgFont0\">";
                            break;
                        }
                    default: break;
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
                if (party.count[13] == 1 || party.count[14] == 1)
                    return true;
                try
                {
                    if (party.count[15] == 1 || party.count[20] == 1)
                        return true;
                }
                catch { }

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