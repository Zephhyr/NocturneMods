using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using MelonLoader.TinyJSON;
using Newtonsoft.Json;

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
                ////MelonLogger.Msg("message: " + message);
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
                            case "<SPD 6><AI_MSG_L0040><WAIT>": __result = "<SP6>How could a mere human surpass gods and destroy even me, your Creator?<WA>"; break;
                            case "<SPD 6><AI_MSG_L0126><WAIT>": __result = "<SP6>No, this is not the end. You've only led yourself further astray.<WA>"; break;
                            case "<SPD 6><AI_MSG_L0127><WAIT>": __result = "<SP6>Humans are weak. You cannot live without my law, my order. You need something to believe in.<WA>"; break;
                            case "<SPD 6><AI_MSG_L0128><WAIT>": __result = "<SP6>But now you've debased my truths, and so I shall slip from the minds of humans.<WA>"; break;
                            case "<AI_MSG_L0129><WAIT>": __result = "<SP6>Humanity will inevitably lose its way and long for salvation. Then... You can regret this decision...<WA>"; break;
                        }
                    }
                    else if (nbMainProcess.nbGetMainProcessData().encno == 307)
                    {
                        switch (message)
                        {
                            // Girimekhala Dialogue 1
                            case "<SPD 6><AI_MSG_L0120><WAIT>": __result = "<SP6>KILL YOU! *trumpet*<WA>"; break;
                            // Girimekhala Dialogue 2
                            case "<SPD 6><AI_MSG_L0121><WAIT>": __result = "<SP6>Guh... ugh... ughhh...<WA>"; break;
                            case "<AI_MSG_L0122><WAIT>": __result = "<SP6>...I am... Girimekhala... I... will kill... you...<WA>"; break;
                            // Girimekhala Death Dialogue
                            case "<SPD 6><AI_MSG_L0040><WAIT>": __result = "<SP6>...Kill... you...<WA>"; break;
                        }
                    }
                    else if (nbMainProcess.nbGetMainProcessData().encno == 1272)
                    {
                        switch (message)
                        {
                            // Jack Frost Dialogue 1
                            case "<SPD 6><AI_MSG_L0120><WAIT>": __result = "<SP6>Hee, why are you standing on your hee-ho toes?<WA>"; break;
                            case "<SPD 6><AI_MSG_L0126><WAIT>": __result = "<SP6>Oh, I see-ho. You think I'm just a plain old Frost!<WA>"; break;
                            case "<SPD 6><AI_MSG_L0127><WAIT>": __result = "<SP6>Isn't that right!? Yeah, I'm talking to you, hee-ho!<WA>"; break;
                            case "<SPD 6><AI_MSG_L0128><WAIT>": __result = "<SP6>I'm Jack... Jack Frost the Magnificent!<WA>"; break;
                            case "<AI_MSG_L0129><WAIT>": __result = "<SP6>I'll teach you a lesson you'll never forget! Heeeeeeeeeeho!!!!!<WA>"; break;
                            // Jack Frost Dialogue 2
                            case "<SPD 6><AI_MSG_L0121><WAIT>": __result = "<SP6>Heeeee-ya ho!<WA>"; break;
                        }
                    }
                    else if (nbMainProcess.nbGetMainProcessData().encno == 1273)
                    {
                        switch (message)
                        {
                            // Sarge Girimekhala Dialogue 1
                            case "<SPD 6><AI_MSG_L0120><WAIT>": __result = "<SP6>It's my duty to kill all demons without the balls to survive!<WA>"; break;
                            case "<SPD 6><AI_MSG_L0121><WAIT>": __result = "<SP6>When I get through with you, you'll be sipping Magatsuhi through a straw!<WA>"; break;
                            case "<AI_MSG_L0122><WAIT>": __result = "<SP6>Got that, you worthless piece of shit!?<WA>"; break;
                            // Sarge Girimekhala Dialogue 2
                            case "<SPD 6><AI_MSG_L0123><WAIT>": __result = "<SP6>You call that a battle stance!? My grandmother looks more menacing than that!<WA>"; break;
                            case "<SPD 6><AI_MSG_L0124><WAIT>": __result = "<SP6>Don't you have a Reason? My Reason is kicking your ass!<WA>"; break;
                            case "<AI_MSG_L0125><WAIT>": __result = "<SP6>Got that, you worthless piece of shit!?<WA>"; break;
                        }
                    }
                    else
                    {
                        switch (message)
                        {
                            // Specter 1 Dialogue
                            case "<SPD 6><AI_MSG_L0055><WAIT>": __result = "<SP6>My MaGiC bIggEr ThAn YoUrS!<WA>"; break;
                            // Specter 3 Dialogue
                            case "<SPD 6><AI_MSG_L0004><WAIT>": __result = "<SP6>ThIs TiMe Me HaVe PlAn!<WA>"; break;
                            case "<SPD 6><AI_MSG_L0005><WAIT>": __result = "<SP6>ThIs TiMe Me HaVe PlAn!<WA>"; break;
                            case "<SPD 6><AI_MSG_L0006><WAIT>": __result = "<SP6>ThIs TiMe Me HaVe PlAn!<WA>"; break;
                            case "<SPD 6><AI_MSG_L0007><WAIT>": __result = "<SP6>ThIs TiMe Me HaVe PlAn!<WA>"; break;
                            case "<SPD 6><AI_MSG_L0009><WAIT>": __result = "<SP6>NoW mE bIggEr ThAn YoOoOoOoU! NoW yOu DiIiIiIiIiIiE!<WA>"; break;
                            case "<SPD 6><AI_MSG_L0010><WAIT>": __result = "<SP6>M-Me NoT bIg EnOUgh! Me StIll KiLL YoOoOoOoU!<WA>"; break;
                            case "<SPD 6><AI_MSG_L0011><WAIT>": __result = "<SP6>...I WeAk! YoUr FaULt! Me StIll KiLL YoOoOoOoU!<WA>"; break;
                            case "<SPD 6><AI_MSG_L0012><WAIT>": __result = "<SP6>Me BiG... wHy Me StIll Too WeAk...<WA>"; break;
                            // Albion Dialogue
                            case "<SPD 6><AI_MSG_L0061><WAIT>": __result = "<SP6>LINE-UP-THE-FLEET! TIME-FOR-SOME-HEAT! WITH-MY-BOYS-ON-THE-STREET! I-CANNOT-BE-BEAT!<WA>"; break;
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
                    else if(nbMainProcess.nbGetMainProcessData().encno == 1272)
                    {
                        if (pinst.message.pbinheader.addr.Contains(8620))
                        {
                            pinst.message.maxpage = 5;
                            pinst.message.pbinheader.page = 5;
                            pinst.message.pbinheader.addr = new uint[] { 8620, 8924, 8988, 9056, 9080 };
                            pinst.message.pbinheader.len = new int[] { 24, 24, 24, 24, 20 };
                        }
                        else if (pinst.message.pbinheader.addr.Contains(8688))
                        {
                            pinst.message.maxpage = 1;
                            pinst.message.pbinheader.page = 1;
                            pinst.message.pbinheader.addr = new uint[] { 8688 };
                            pinst.message.pbinheader.len = new int[] { 24 };
                        }
                    }
                    else if (nbMainProcess.nbGetMainProcessData().encno == 1273)
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
                    }
                }
                catch { }
            }
        }
    }
}
