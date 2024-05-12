using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppkernel_H;
using UnityEngine;
using System.Runtime.CompilerServices;
using Il2CppTMPro;
using Il2Cppinterface_H;
using System.Text;
using Newtonsoft.Json;
using System.Xml.Linq;
using Il2CppSystem.Runtime.Remoting.Messaging;
using UnityEngine.Events;

namespace NocturneInsaniax
{

    internal partial class NocturneInsaniax : MelonMod
    {
        public static _FRQ qfont;

        [HarmonyPatch(typeof(frFont), nameof(frFont.frReplaceLocalizeText))]
        private class BattleMessagePatch
        {
            public static void Postfix(ref string message, ref frMsgInfo_t mi, ref List<int> index, ref string __result)
            {
                MelonLogger.Msg("--frFont.frReplaceLocalizeText--");
                MelonLogger.Msg("message: " + message);
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
                            case "<SPD 6><AI_MSG_L0126><WAIT>": __result = "<SP6>No, this is not the end, You've only led yourself further astray.<WA>"; break;
                            case "<SPD 6><AI_MSG_L0127><WAIT>": __result = "<SP6>Humans are weak. you cannot live without my law, my order. You need something to believe in.<WA>"; break;
                            case "<SPD 6><AI_MSG_L0128><WAIT>": __result = "<SP6>But now you've debased my truths, and so I shall slip from the minds of humans.<WA>"; break;
                            case "<AI_MSG_L0129><WAIT>": __result = "<SP6>Humanity will inevitably lose its way and long for salvation. Then... You can regret this decision...<WA>"; break;
                        }
                    }
                } catch { }

                
            }
        }

        //[HarmonyPatch(typeof(itfMesManager), nameof(itfMesManager.DrawManagerProc))]
        //private class DrawManagerProcPatch
        //{
        //    public static void Prefix(ref dds3ProcessID_t proc_id)
        //    {
        //        MelonLogger.Msg("--itfMesManager.DrawManagerProc Prefix--");

        //        try
        //        {
        //            if (nbMainProcess.nbGetMainProcessData().encno == 1278)
        //            {
        //                MelonLogger.Msg("g_manager.linkstack.puse_tail.pinst.message.maxpage: " + itfMesManager.g_manager.linkstack.puse_tail.pinst.message.maxpage);
        //                MelonLogger.Msg("g_manager.linkstack.puse_tail.pinst.message.page: " + itfMesManager.g_manager.linkstack.puse_tail.pinst.message.page);

        //                //if (itfMesManager.g_manager.linkstack.puse_tail.pinst.message.page == 0)
        //                //    itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont.tag_id = "<YHVH_L0_01>";

        //                //MelonLogger.Msg("pfont.y: " + itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont.y);
        //                //MelonLogger.Msg("pfont.tag_id: " + itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont.tag_id);
        //                //MelonLogger.Msg("pfont.strlen: " + itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont.strlen);
        //                //MelonLogger.Msg("pfont.draw_spd: " + itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont.draw_spd);
        //                //MelonLogger.Msg("pfont.space: " + itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont.space);
        //                //MelonLogger.Msg("pfont.str.draw_count: " + itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont.str.draw_count);
        //                //MelonLogger.Msg("pfont.str.col_no: " + itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont.str.col_no);
        //                //MelonLogger.Msg("pfont.str_end.draw_count: " + itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont.str.draw_count);
        //                //MelonLogger.Msg("pfont.str_end.col_no: " + itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont.str_end.col_no);

        //                if (itfMesManager.g_manager.linkstack.puse_tail.pinst.message.maxpage == 1 || itfMesManager.g_manager.linkstack.puse_tail.pinst.message.maxpage == 2)
        //                {
        //                    itfMesManager.g_manager.linkstack.puse_tail.pinst.message.maxpage = 3;

        //                    qfont = itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont;
        //                } 

        //                if (itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont == null && itfMesManager.g_manager.linkstack.puse_tail.pinst.message.maxpage == 3)
        //                {
        //                    itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont = qfont;
        //                }

        //                MelonLogger.Msg("g_manager.linkstack.puse_tail.pinst.message.pfont.tag_id: " + itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont.tag_id);
        //            }
        //        }
        //        catch { }

        //        //try
        //        //{
        //        //    MelonLogger.Msg("g_manager.linkstack: " + (itfMesManager.g_manager.linkstack == null));
        //        //    MelonLogger.Msg("g_manager.linkstack.puse_tail: " + (itfMesManager.g_manager.linkstack.puse_tail == null));
        //        //    MelonLogger.Msg("g_manager.linkstack.puse_tail.pinst: " + (itfMesManager.g_manager.linkstack.puse_tail.pinst == null));
        //        //    MelonLogger.Msg("g_manager.linkstack.puse_tail.pinst.message: " + (itfMesManager.g_manager.linkstack.puse_tail.pinst.message == null));
        //        //    MelonLogger.Msg("g_manager.linkstack.puse_tail.pinst.message.pfont: " + (itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont == null));
        //        //    MelonLogger.Msg("g_manager.linkstack.puse_tail.pinst.message.pfont.tag_id: " + (itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont.tag_id == null));
        //        //    MelonLogger.Msg("g_manager.linkstack.puse_tail.pinst.message.pfont.tag_id: " + itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont.tag_id);
        //        //}
        //        //catch { }
        //    }
        //}

        //[HarmonyPatch(typeof(itfMesManager), nameof(itfMesManager.itfMesMngMessage))]
        //private class itfMesMngMessagePatch
        //{
        //    public static void Prefix()
        //    {
        //        MelonLogger.Msg("--itfMesManager.itfMesMngMessage Prefix--");
        //    }
        //}

        [HarmonyPatch(typeof(itfMesManager), nameof(itfMesManager.itfMesMngRequestMessage))]
        private class itfMesMngRequestMessagePatch
        {
            public static void Prefix(ref int id, ref int message, ref int page, ref int callmode)
            {
                MelonLogger.Msg("--itfMesManager.itfMesMngRequestMessage Prefix--");
                MelonLogger.Msg("id: " + id);
                MelonLogger.Msg("message: " + message);
                MelonLogger.Msg("page: " + page);
                MelonLogger.Msg("callmode: " + callmode);
            }

            public static void Postfix(ref int id, ref int message, ref int page, ref int callmode, ref int __result)
            {
                MelonLogger.Msg("--itfMesManager.itfMesMngRequestMessage Postfix--");
                MelonLogger.Msg("id: " + id);
                MelonLogger.Msg("message: " + message);
                MelonLogger.Msg("page: " + page);
                MelonLogger.Msg("callmode: " + callmode);
                MelonLogger.Msg("result: " + __result);
            }
        }

        [HarmonyPatch(typeof(itfMesManager), nameof(itfMesManager.CallEventVoice))]
        private class CallEventVoicePatch
        {
            public static void Prefix(ref instanceMes_tag pinst)
            {
                MelonLogger.Msg("--itfMesManager.CallEventVoice Prefix--");
                MelonLogger.Msg("tagid: " + pinst.message.pfont.tag_id);
            }
            public static void Postfix(ref instanceMes_tag pinst)
            {
                MelonLogger.Msg("--itfMesManager.CallEventVoice Postfix--");
                MelonLogger.Msg("tagid: " + pinst.message.pfont.tag_id);
            }
        }

        [HarmonyPatch(typeof(SndAssetBundleManager), nameof(SndAssetBundleManager.IsConstantsVoice))]
        private class IsConstantsVoicePatch
        {
            public static void Prefix(ref string name)
            {
                MelonLogger.Msg("--SndAssetBundleManager.IsConstantsVoice Prefix--");
                MelonLogger.Msg("name: " + name);
            }
            public static void Postfix(ref string name, ref bool __result)
            {
                MelonLogger.Msg("--SndAssetBundleManager.IsConstantsVoice Postfix--");
                MelonLogger.Msg("name: " + name);

                try
                {
                    if (nbMainProcess.nbGetMainProcessData().encno == 1278)
                    {
                        __result = true;
                    }
                }
                catch { }

                MelonLogger.Msg("result: " + __result);
            }
        }

        [HarmonyPatch(typeof(SndAssetBundleManager), nameof(SndAssetBundleManager.LoadBossAIMSG))]
        private class LoadBossAIMSGPatch
        {
            public static void Prefix(ref string key)
            {
                MelonLogger.Msg("--SndAssetBundleManager.LoadBossAIMSG Prefix--");
                MelonLogger.Msg("key: " + key);
            }
        }

        [HarmonyPatch(typeof(SndAssetBundleManager), nameof(SndAssetBundleManager.VoiceCommonKey))]
        private class VoiceCommonKeyPatch
        {
            public static void Postfix(ref string key, ref string name, ref string __result)
            {
                MelonLogger.Msg("--SndAssetBundleManager.VoiceCommonKey Postfix--");
                MelonLogger.Msg("key: " + key);
                MelonLogger.Msg("name: " + name);
                MelonLogger.Msg("result: " + __result);
            }
        }







        [HarmonyPatch(typeof(SoundManager), nameof(SoundManager.PlayVoice))]
        private class PlayVoicePatch
        {
            public static void Prefix(ref string name)
            {
                MelonLogger.Msg("--SoundManager.PlayVoice Prefix--");
                MelonLogger.Msg("name: " + name);
            }
            public static void Postfix(ref string name)
            {
                MelonLogger.Msg("--SoundManager.PlayVoice Postfix--");
                MelonLogger.Msg("name: " + name);
            }
        }

        [HarmonyPatch(typeof(SoundManager), nameof(SoundManager._PlayVoice))]
        private class _PlayVoicePatch
        {
            public static void Prefix(ref string name)
            {
                MelonLogger.Msg("--SoundManager._PlayVoice Prefix--");
                MelonLogger.Msg("name: " + name);
            }
            public static void Postfix(ref string name)
            {
                MelonLogger.Msg("--SoundManager._PlayVoice Postfix--");
                MelonLogger.Msg("name: " + name);
            }
        }

        [HarmonyPatch(typeof(SoundManager), nameof(SoundManager._LoadVoice))]
        private class _LoadVoicePatch
        {
            public static void Prefix(ref string name)
            {
                MelonLogger.Msg("--SoundManager._LoadVoice Prefix--");
                MelonLogger.Msg("name: " + name);
            }
            public static void Postfix(ref string name)
            {
                MelonLogger.Msg("--SoundManager._LoadVoice Postfix--");
                MelonLogger.Msg("name: " + name);
            }
        }

        //[HarmonyPatch(typeof(AudioSourceExtention), nameof(AudioSourceExtention.PlayVoiceCallback))]
        //private class PlayVoiceCallbackPatch
        //{
        //    public static void Prefix(AudioClip audioClip, float volume, UnityAction compCallback)
        //    {
        //        MelonLogger.Msg("--AudioSourceExtention.PlayVoiceCallback Prefix--");
        //        MelonLogger.Msg("audioClip is null?: " + audioClip == null);
        //        MelonLogger.Msg("audioClip: " + audioClip.ToString());
        //        MelonLogger.Msg("volume: " + volume);
        //    }
        //    public static void Postfix(AudioClip audioClip, float volume, UnityAction compCallback)
        //    {
        //        MelonLogger.Msg("--AudioSourceExtention.PlayVoiceCallback Postfix--");
        //        MelonLogger.Msg("audioClip: " + audioClip.ToString());
        //        MelonLogger.Msg("volume: " + volume);
        //    }
        //}

        //[HarmonyPatch(typeof(SndAssetBundleManager), nameof(SndAssetBundleManager.ReplaceVoice))]
        //private class ReplaceVoicePatch
        //{
        //    public static void Prefix(ref string id)
        //    {
        //        MelonLogger.Msg("--SndAssetBundleManager.ReplaceVoice Prefix--");
        //        MelonLogger.Msg("id: " + id);
        //    }
        //    public static void Postfix(ref string id, ref string __result)
        //    {
        //        MelonLogger.Msg("--SndAssetBundleManager.ReplaceVoice Postfix--");
        //        MelonLogger.Msg("id: " + id);
        //        MelonLogger.Msg("result: " + __result);
        //    }
        //}

        //[HarmonyPatch(typeof(itfMesManager), nameof(itfMesManager.GetTypeHeader))]
        //private class GetTypeHeaderPatch
        //{
        //    //public static void Prefix(ref instanceMes_tag pinst, ref int index)
        //    //{
        //    //    MelonLogger.Msg("--itfMesManager.GetTypeHeader Prefix--");
        //    //    MelonLogger.Msg("index: " + index);
        //    //    MelonLogger.Msg("pinst: " + pinst);
        //    //    try
        //    //    {
        //    //        if (nbMainProcess.nbGetMainProcessData().encno == 1278)
        //    //        {
        //    //            var output = JsonConvert.SerializeObject(pinst);
        //    //            MelonLogger.Msg(output);
        //    //        }
        //    //    }
        //    //    catch { }
        //    //}

        //    public static void Postfix(ref instanceMes_tag pinst, ref int index, ref itfMesBinTypeHeader_t __result)
        //    {
        //        MelonLogger.Msg("--itfMesManager.GetTypeHeader Postfix--");
        //        MelonLogger.Msg("index: " + index);
        //        MelonLogger.Msg("pinst: " + pinst);
        //        //try
        //        //{
        //        //    if (nbMainProcess.nbGetMainProcessData().encno == 1278)
        //        //    {
        //        //        var output = JsonConvert.SerializeObject(pinst);
        //        //        MelonLogger.Msg(output);
        //        //    }
        //        //}
        //        //catch { }
        //        MelonLogger.Msg("result.ptr: " + __result.ptr);
        //        MelonLogger.Msg("result.type: " + __result.type);
        //        //try
        //        //{
        //        //    if (nbMainProcess.nbGetMainProcessData().encno == 1278)
        //        //    {
        //        //        var output = JsonConvert.SerializeObject(__result);
        //        //        MelonLogger.Msg(output);
        //        //    }
        //        //}
        //        //catch { }
        //    }
        //}

        [HarmonyPatch(typeof(itfMesManager), nameof(itfMesManager.ReadytoMessage))]
        private class ReadytoMessagePatch
        {
            public static void Prefix(ref instanceMes_tag pinst, ref int mode)
            {
                MelonLogger.Msg("--itfMesManager.ReadytoMessage--");
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
                        //else
                        //{
                        //    MelonLogger.Msg("addr:");
                        //    foreach (var addr in pinst.message.pbinheader.addr)
                        //        MelonLogger.Msg(addr);
                        //    MelonLogger.Msg("len:");
                        //    foreach (var len in pinst.message.pbinheader.len)
                        //        MelonLogger.Msg(len);
                        //}
                    }
                }
                catch { }
            }

            //public static void Postfix(ref instanceMes_tag pinst, ref int mode)
            //{
            //    MelonLogger.Msg("--itfMesManager.ReadytoMessage Postfix--");
            //    MelonLogger.Msg("pinst: " + pinst);
            //    try {
            //        if (nbMainProcess.nbGetMainProcessData().encno == 1278)
            //        {
            //            var output = JsonConvert.SerializeObject(pinst);
            //            MelonLogger.Msg(output);
            //        }
            //    } catch { }
            //    MelonLogger.Msg("mode: " + mode);
            //}
        }

        //[HarmonyPatch(typeof(frFont), nameof(frFont.MessageRequestExLocalize))]
        //private class MessageRequestExLocalizePatch
        //{
        //    public static void Prefix(ref int x, ref int y, ref byte Style, ref byte ColNo, ref byte Tp, ref byte Spd, ref byte[] pMsg, ref _FRQ pFRQ)
        //    {
        //        MelonLogger.Msg("--frFont.MessageRequestExLocalize Prefix--");
        //        MelonLogger.Msg("x: " + x);
        //        MelonLogger.Msg("y: " + y);
        //        MelonLogger.Msg("Style: " + Style);
        //        MelonLogger.Msg("ColNo: " + ColNo);
        //        MelonLogger.Msg("Tp: " + Tp);
        //        MelonLogger.Msg("Spd: " + Spd);
        //        MelonLogger.Msg("pMsg: " + Encoding.Unicode.GetString(pMsg));
        //    }

        //    //public static void Postfix(ref int x, ref int y, ref byte Style, ref byte ColNo, ref byte Tp, ref byte Spd, ref byte[] pMsg, ref _FRQ pFRQ, ref _FRQ __result)
        //    //{
        //    //    MelonLogger.Msg("--frFont.MessageRequestExLocalize Postfix--");
        //    //    //int encno = 0;
        //    //    //try {
        //    //    //    encno = nbMainProcess.nbGetMainProcessData().encno;
        //    //    //} catch { }

        //    //    //if (encno == 1278)
        //    //    //{
        //    //    //    if (__result.tag_id == "<AI_MSG_L0120>")
        //    //    //        __result.tag_id = "<YHVH_L0_01>";
        //    //    //}

        //    //    MelonLogger.Msg("x: " + x);
        //    //    MelonLogger.Msg("y: " + y);
        //    //    MelonLogger.Msg("Style: " + Style);
        //    //    MelonLogger.Msg("ColNo: " + ColNo);
        //    //    MelonLogger.Msg("Tp: " + Tp);
        //    //    MelonLogger.Msg("Spd: " + Spd);
        //    //    MelonLogger.Msg("pMsg: " + Encoding.Default.GetString(pMsg));
        //    //    MelonLogger.Msg("result: " + __result.tag_id);
        //    //}
        //}

        //[HarmonyPatch(typeof(frFont), nameof(frFont.frAnalyzeMessageLocalize))]
        //private class frAnalyzeMessageLocalizePatch
        //{
        //    public static void Prefix(ref frMsgInfo_t pMsgInfo, ref bool spc)
        //    {
        //        MelonLogger.Msg("--frFont.frAnalyzeMessageLocalize Prefix--");

        //        MelonLogger.Msg("pMsgInfo.X: " + pMsgInfo.X);
        //        MelonLogger.Msg("pMsgInfo.Y: " + pMsgInfo.Y);
        //        MelonLogger.Msg("pMsgInfo.Z: " + pMsgInfo.Z);
        //        MelonLogger.Msg("pMsgInfo.Style: " + pMsgInfo.Style);
        //        MelonLogger.Msg("pMsgInfo.ColNo: " + pMsgInfo.ColNo);
        //        MelonLogger.Msg("pMsgInfo.Tp: " + pMsgInfo.Tp);
        //        MelonLogger.Msg("pMsgInfo.Spd: " + pMsgInfo.Spd);
        //        MelonLogger.Msg("pMsgInfo.talk_tag: " + pMsgInfo.talk_tag);
        //        MelonLogger.Msg("pMsgInfo.pFRQ.tag_id: " + pMsgInfo.pFRQ.tag_id);
        //        MelonLogger.Msg("spc: " + spc);
        //    }

        //    public static void Postfix(ref frMsgInfo_t pMsgInfo, ref bool spc, ref _FRQ __result)
        //    {
        //        MelonLogger.Msg("--frFont.frAnalyzeMessageLocalize Postfix--");

        //        MelonLogger.Msg("pMsgInfo.X: " + pMsgInfo.X);
        //        MelonLogger.Msg("pMsgInfo.Y: " + pMsgInfo.Y);
        //        MelonLogger.Msg("pMsgInfo.Z: " + pMsgInfo.Z);
        //        MelonLogger.Msg("pMsgInfo.Style: " + pMsgInfo.Style);
        //        MelonLogger.Msg("pMsgInfo.ColNo: " + pMsgInfo.ColNo);
        //        MelonLogger.Msg("pMsgInfo.Tp: " + pMsgInfo.Tp);
        //        MelonLogger.Msg("pMsgInfo.Spd: " + pMsgInfo.Spd);
        //        MelonLogger.Msg("pMsgInfo.talk_tag: " + pMsgInfo.talk_tag);
        //        MelonLogger.Msg("pMsgInfo.pFRQ.tag_id: " + pMsgInfo.pFRQ.tag_id);
        //        MelonLogger.Msg("spc: " + spc);
        //        MelonLogger.Msg("result: " + __result.tag_id);
        //    }
        //}

        //[HarmonyPatch(typeof(itfMesManager), nameof(itfMesManager.DrawMesFlow))]
        //private class DrawMesFlowPatch
        //{
        //    public static void Postfix(ref instanceMes_tag pinst)
        //    {
        //        MelonLogger.Msg("--itfMesManager.DrawMesFlow Postfix--");
        //        MelonLogger.Msg("pinst.id: " + pinst.id);
        //        MelonLogger.Msg("pinst.key: " + pinst.key);
        //        MelonLogger.Msg("pinst.message.lines: " + pinst.message.lines);
        //        MelonLogger.Msg("pinst.message.page: " + pinst.message.page);
        //        MelonLogger.Msg("pinst.message.maxpage: " + pinst.message.maxpage);
        //        MelonLogger.Msg("pinst.variable.pptr:");
        //        foreach (var pptr in pinst.variable.pptr.Where(x => x != null))
        //            MelonLogger.Msg(pptr);
        //        MelonLogger.Msg("pinst.variable.pmh:");
        //        foreach (var pmh in pinst.variable.pmh.Where(x => x != null))
        //            MelonLogger.Msg(pmh);
        //        //try
        //        //{
        //        //    MelonLogger.Msg("pinst.message.pfont.tag_id: " + pinst.message.pfont.tag_id);
        //        //}
        //        //catch { }

        //        //try
        //        //{
        //        //    MelonLogger.Msg("puse_top equivalence: " + (pinst.message.pfont.tag_id == itfMesManager.g_manager.linkstack.puse_top.pinst.message.pfont.tag_id));
        //        //}
        //        //catch { }
        //        //try
        //        //{
        //        //    MelonLogger.Msg("puse_tail equivalence: " + (pinst.message.pfont.tag_id == itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont.tag_id));
        //        //}
        //        //catch { }
        //        //MelonLogger.Msg("g_manager.pmesflow: " + itfMesManager.g_manager.pmesflow.Length);
        //    }
        //}        //[HarmonyPatch(typeof(itfMesManager), nameof(itfMesManager.DrawMesFlow))]
        //private class DrawMesFlowPatch
        //{
        //    public static void Postfix(ref instanceMes_tag pinst)
        //    {
        //        MelonLogger.Msg("--itfMesManager.DrawMesFlow Postfix--");
        //        MelonLogger.Msg("pinst.id: " + pinst.id);
        //        MelonLogger.Msg("pinst.key: " + pinst.key);
        //        MelonLogger.Msg("pinst.message.lines: " + pinst.message.lines);
        //        MelonLogger.Msg("pinst.message.page: " + pinst.message.page);
        //        MelonLogger.Msg("pinst.message.maxpage: " + pinst.message.maxpage);
        //        MelonLogger.Msg("pinst.variable.pptr:");
        //        foreach (var pptr in pinst.variable.pptr.Where(x => x != null))
        //            MelonLogger.Msg(pptr);
        //        MelonLogger.Msg("pinst.variable.pmh:");
        //        foreach (var pmh in pinst.variable.pmh.Where(x => x != null))
        //            MelonLogger.Msg(pmh);
        //        //try
        //        //{
        //        //    MelonLogger.Msg("pinst.message.pfont.tag_id: " + pinst.message.pfont.tag_id);
        //        //}
        //        //catch { }

        //        //try
        //        //{
        //        //    MelonLogger.Msg("puse_top equivalence: " + (pinst.message.pfont.tag_id == itfMesManager.g_manager.linkstack.puse_top.pinst.message.pfont.tag_id));
        //        //}
        //        //catch { }
        //        //try
        //        //{
        //        //    MelonLogger.Msg("puse_tail equivalence: " + (pinst.message.pfont.tag_id == itfMesManager.g_manager.linkstack.puse_tail.pinst.message.pfont.tag_id));
        //        //}
        //        //catch { }
        //        //MelonLogger.Msg("g_manager.pmesflow: " + itfMesManager.g_manager.pmesflow.Length);
        //    }
        //}

        //[HarmonyPatch(typeof(itfMesManager), nameof(itfMesManager.DrawMessage))]
        //private class DrawMessagePatch
        //{
        //    public static void Postfix(ref _FRQ pfont, ref int __result)
        //    {
        //        MelonLogger.Msg("--itfMesManager.DrawMessage Postfix--");
        //        MelonLogger.Msg("pfont.tag_id: " + pfont.tag_id);
        //        MelonLogger.Msg("pfont.strlen: " + pfont.strlen);
        //        MelonLogger.Msg("pfont.draw_spd: " + pfont.draw_spd);
        //        MelonLogger.Msg("pfont.space: " + pfont.space);
        //        MelonLogger.Msg("pfont.str.draw_count: " + pfont.str.draw_count);
        //        MelonLogger.Msg("pfont.str_end.draw_count: " + pfont.str_end.draw_count);
        //        MelonLogger.Msg("result: " + __result);
        //    }
        //}
    }
}
