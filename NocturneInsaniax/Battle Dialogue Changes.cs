using HarmonyLib;
using MelonLoader;
using Il2Cpp;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        [HarmonyPatch(typeof(frFont), nameof(frFont.frReplaceLocalizeText))]
        private class BattleMessagePatch
        {
            public static void Postfix(ref string message, ref frMsgInfo_t mi, ref List<int> index, ref string __result)
            {
                ////MelonLogger.Msg("--frFont.frReplaceLocalizeText--");
                try
                {
                    if (nbMainProcess.nbGetMainProcessData().encno == 1278)
                    {
                        switch (message)
                        {
                            // YHVH Dialogue 1
                            case "<SPD 6><AI_MSG_L0120><WAIT>": __result = "<SP6>How could you diminish me to such a state? Pathless fool... I cannot forgive you...<WA>"; break;
                            case "<SPD 6><AI_MSG_L0121><WAIT>": __result = "<SP6>I asked only that you take the life I granted you and obediently follow my word.<WA>"; break;
                            case "<AI_MSG_L0122><WAIT>": __result = "<SP6>The weight of your blasphemy is too great for death! Eternal suffering is the only suitable punishment!<WA>"; break;
                            // YHVH Dialogue 2
                            case "<SPD 6><AI_MSG_L0123><WAIT>": __result = "<SP6>Guh... Do you fully comprehend your actions?<WA>"; break;
                            case "<SPD 6><AI_MSG_L0124><WAIT>": __result = "<SP6>How will you repent for a sin this grave? Do you think yourself capable of carrying that cross?<WA>"; break;
                            case "<AI_MSG_L0125><WAIT>": __result = "<SP6>Praise my name, before it is too late! Praise my glory!<WA>"; break;
                            // YHVH Death Dialogue
                            case "<SPD 6><AI_MSG_L0040><WAIT>": __result = "<SP6>How could a mere human surpass gods and destory even me, your Creator?<WA>"; break;
                            case "<SPD 6><AI_MSG_L0126><WAIT>": __result = "<SP6>No, this is not the end. You've only led yourself further astray.<WA>"; break;
                            case "<SPD 6><AI_MSG_L0127><WAIT>": __result = "<SP6>Humans are weak. You cannot live without my law, my order. You need something to believe in.<WA>"; break;
                            case "<SPD 6><AI_MSG_L0128><WAIT>": __result = "<SP6>But now you've debased my truths, and so I shall slip from the minds of humans.<WA>"; break;
                            case "<AI_MSG_L0129><WAIT>": __result = "<SP6>Humanity will inevitably lose its way and long for salvation. Then... You can regret this decision...<WA>"; break;
                        }
                    }
                }
                catch { }
            }
        }

        [HarmonyPatch(typeof(itfMesManager), nameof(itfMesManager.ReadytoMessage))]
        private class ReadytoMessagePatch
        {
            public static void Prefix(ref instanceMes_tag pinst, ref int mode)
            {
                ////MelonLogger.Msg("--itfMesManager.ReadytoMessage--");
                try
                {
                    if (nbMainProcess.nbGetMainProcessData().encno == 1278)
                    {
                        if (pinst.message.pbinheader.addr.Contains(8620))
                        {
                            pinst.message.maxpage = 3;
                            pinst.message.pbinheader.page = 3;
                            pinst.message.pbinheader.addr = new uint[] { 8620, 8688, 8712 };
                            pinst.message.pbinheader.len = new int[] { 24, 24, 20 };
                        }
                        else if (pinst.message.pbinheader.addr.Contains(8688))
                        {
                            pinst.message.maxpage = 3;
                            pinst.message.pbinheader.page = 3;
                            pinst.message.pbinheader.addr = new uint[] { 8772, 8840, 8864 };
                            pinst.message.pbinheader.len = new int[] { 24, 24, 20 };
                        }
                        else if (pinst.message.pbinheader.addr.Contains(3780))
                        {
                            pinst.message.maxpage = 5;
                            pinst.message.pbinheader.page = 5;
                            pinst.message.pbinheader.addr = new uint[] { 3780, 8924, 8988, 9056, 9080 };
                            pinst.message.pbinheader.len = new int[] { 24, 24, 24, 24, 20 };
                        }
                    }
                }
                catch { }
            }
        }
    }
}
