using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2Cppnewbattle_H;
using Il2Cppscr_H;
using static Il2Cpp.nbAi;
using System.Collections.Immutable;
using Newtonsoft.Json;

[assembly: MelonInfo(typeof(Test.Test), "Test", "1.0.0", "Zephhyr")]
[assembly: MelonGame("", "smt3hd")]

namespace Test
{
    internal class Test : MelonMod
    {
        public override void OnInitializeMelon()
        {
            //datDevilAI.divTbls[2][0].aichk[1].check[0] = 65596;
            //datDevilAI.divTbls[2][0].aichk[1].table = 1;
            //datDevilAI.divTbls[2][0].aitable[0][0].skill = 57;
            //datDevilAI.divTbls[2][0].aitable[0][1].skill = 57;
            //datDevilAI.divTbls[2][0].aitable[1][0].ritu = 100;
            //datDevilAI.divTbls[2][0].aitable[1][1].ritu = 0;
            //datDevilAI.divTbls[2][0].aitable[1][2].ritu = 0;
        }

        [HarmonyPatch(typeof(nbAiScript), "nbInitAiScript")]
        private class Patch1
        {
            public static void Prefix(ref nbActionProcessData_t a, ref int no)
            {
                MelonLogger.Msg("--nbInitAiScript--");
                MelonLogger.Msg("no: " + no);
                MelonLogger.Msg("id: " + a.work.id);
                MelonLogger.Msg("nowcommand: " + a.work.nowcommand);
                MelonLogger.Msg("nowindex: " + a.work.nowindex);
                MelonLogger.Msg("adata: " + a.adata);
                MelonLogger.Msg("aiselect: " + a.aiselect);
                MelonLogger.Msg("aijokentbl: " + a.aijokentbl);
            }

            public static void Postfix(ref nbActionProcessData_t a, ref int no)
            {
                MelonLogger.Msg("--nbInitAiScript Postfix--");
                MelonLogger.Msg("no: " + no);
                MelonLogger.Msg("id: " + a.work.id);
                MelonLogger.Msg("nowcommand: " + a.work.nowcommand);
                MelonLogger.Msg("nowindex: " + a.work.nowindex);
                MelonLogger.Msg("adata: " + a.adata);
                MelonLogger.Msg("aiselect: " + a.aiselect);
                MelonLogger.Msg("aijokentbl: " + a.aijokentbl);
            }
        }

        [HarmonyPatch(typeof(nbAiScript), "AiChkJoken")]
        private class Patch2
        {
            public static void Prefix(ref uint c)
            {
                MelonLogger.Msg("--AiChkJoken--");
                MelonLogger.Msg("c: " + c);
            }

            public static void Postfix(ref uint c)
            {
                MelonLogger.Msg("--AiChkJoken Postfix--");
                MelonLogger.Msg("c: " + c);
            }
        }

        [HarmonyPatch(typeof(nbAiScript), "nbCommand_AI")]
        private class Patch3
        {
            public static void Postfix()
            {
                MelonLogger.Msg("--nbCommand_AI--");
            }
        }

        [HarmonyPatch(typeof(ScrScriptProcess), "scrStartScript2")]
        private class Patch4
        {
            public static void Postfix(ref int priority, byte[] scrdata, int startproc)
            {
                MelonLogger.Msg("--scrStartScript2--");
                MelonLogger.Msg("priority: " + priority);
                MelonLogger.Msg("startproc: " + startproc);
            }
        }

        [HarmonyPatch(typeof(ScrScriptProcess), "AddScript2")]
        private class Patch5
        {
            public static void Postfix(ref byte[] scrdata, ref int startproc, ref scrProcessWork_s __result)
            {
                MelonLogger.Msg("--AddScript2--");
                MelonLogger.Msg("startproc: " + startproc);
            }
        }

        [HarmonyPatch(typeof(ScrScriptProcess), "AddScript")]
        private class Patch6
        {
            public static void Postfix(ref scrHeader_t header, ref scrTypeTable_t[] typetable, ref scrProcTable_t[] proctable, ref scrLabelTable_t[] labeltable,
                                       ref scrCode_t[] code, ref byte[] mesdata, ref byte[] stringdata, ref int startproc, ref scrProcessWork_s __result)
            {
                MelonLogger.Msg("--AddScript--");
                MelonLogger.Msg("User Id: " + header.UserID);
                MelonLogger.Msg("types length: " + typetable.Length);
                MelonLogger.Msg("procs length: " + proctable.Length);
                MelonLogger.Msg("labels length: " + labeltable.Length);
                MelonLogger.Msg("code length: " + code.Length);
                MelonLogger.Msg("startproc: " + startproc);
            }
        }

        [HarmonyPatch(typeof(nbAi), "Sel_JOKEN")]
        private class Patch9
        {
            public static void Postfix(ref nbActionProcessData_t a, ref int n)
            {
                MelonLogger.Msg("--Sel_JOKEN--");
                MelonLogger.Msg("n: " + n);
            }
        }

        [HarmonyPatch(typeof(nbAi), "nbRunAi")]
        private class Patch10
        {
            public static void Postfix(ref nbActionProcessData_t a)
            {
                MelonLogger.Msg("--nbRunAi--");
            }
        }

        [HarmonyPatch(typeof(nbAi), "nbRunAiSub")]
        private class Patch11
        {
            public static void Postfix(ref nbActionProcessData_t a, ref int tbl)
            {
                MelonLogger.Msg("--nbRunAiSub--");
                MelonLogger.Msg("tbl: " + tbl);
                MelonLogger.Msg("adata: " + a.adata);
                MelonLogger.Msg("aiselect: " + a.aiselect);
                MelonLogger.Msg("aijokentbl: " + a.aijokentbl);
            }
        }

        [HarmonyPatch(typeof(nbAi), "nbAiChkJoken")]
        private class Patch12
        {
            public static void Prefix(ref nbActionProcessData_t a, ref uint jo)
            {
                MelonLogger.Msg("--nbAiChkJoken--");
                MelonLogger.Msg("jo: " + jo);
                MelonLogger.Msg("adata: " + a.adata);
                MelonLogger.Msg("aiselect: " + a.aiselect);
                MelonLogger.Msg("aijokentbl: " + a.aijokentbl);
            }

            public static void Postfix(ref nbActionProcessData_t a, ref uint jo, ref int __result)
            {
                MelonLogger.Msg("--nbAiChkJoken Postfix--");
                MelonLogger.Msg("jo: " + jo);
                MelonLogger.Msg("adata: " + a.adata);
                MelonLogger.Msg("aiselect: " + a.aiselect);
                MelonLogger.Msg("aijokentbl: " + a.aijokentbl);
                MelonLogger.Msg("result: " + __result);
            }
        }

        [HarmonyPatch(typeof(nbAi), "AiChk")]
        private class Patch13
        {
            public static void Postfix(ref nbActionProcessData_t a, ref int n)
            {
                MelonLogger.Msg("--AiChk--");
                MelonLogger.Msg("n: " + n);
                MelonLogger.Msg("adata: " + a.adata);
                MelonLogger.Msg("aiselect: " + a.aiselect);
                MelonLogger.Msg("aijokentbl: " + a.aijokentbl);
            }
        }

        [HarmonyPatch(typeof(nbAi), "GetKoudou")]
        private class Patch14
        {
            public static void Postfix(ref nbActionProcessData_t a, ref int tbl, ref int __result)
            {
                MelonLogger.Msg("--GetKoudou--");
                MelonLogger.Msg("tbl: " + tbl);
                MelonLogger.Msg("adata: " + a.adata);
                MelonLogger.Msg("aiselect: " + a.aiselect);
                MelonLogger.Msg("aijokentbl: " + a.aijokentbl);
                MelonLogger.Msg("result: " + __result);
            }
        }

        [HarmonyPatch(typeof(nbAi), "SetKoudou")]
        private class Patch15
        {
            public static void Postfix(ref nbActionProcessData_t a, ref int tbl, ref int kou)
            {
                MelonLogger.Msg("--SetKoudou--");
                MelonLogger.Msg("tbl: " + tbl);
                MelonLogger.Msg("kou: " + kou);
                MelonLogger.Msg("adata: " + a.adata);
                MelonLogger.Msg("aiselect: " + a.aiselect);
                MelonLogger.Msg("aijokentbl: " + a.aijokentbl);
            }
        }

        [HarmonyPatch(typeof(nbAi), "Sel_AI")]
        private class Patch16
        {
            public static void Prefix(ref nbActionProcessData_t a, int n, int gr)
            {
                MelonLogger.Msg("--Sel_AI--");
                MelonLogger.Msg("n: " + n);
                MelonLogger.Msg("gr: " + gr);
                MelonLogger.Msg("adata: " + a.adata);
                MelonLogger.Msg("aiselect: " + a.aiselect);
                MelonLogger.Msg("aijokentbl: " + a.aijokentbl);
            }

            public static void Postfix(ref nbActionProcessData_t a, int n, int gr, ref int __result)
            {
                MelonLogger.Msg("--Sel_AI Postfix--");
                MelonLogger.Msg("n: " + n);
                MelonLogger.Msg("gr: " + gr);
                MelonLogger.Msg("adata: " + a.adata);
                MelonLogger.Msg("aiselect: " + a.aiselect);
                MelonLogger.Msg("aijokentbl: " + a.aijokentbl);
                MelonLogger.Msg("result: " + __result);
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), "SetAction_AISCR")]
        private class Patch17
        {
            public static void Prefix(ref nbActionProcessData_t a)
            {
                MelonLogger.Msg("--SetAction_AISCR--");
                MelonLogger.Msg("id: " + a.work.id);
                MelonLogger.Msg("nowcommand: " + a.work.nowcommand);
                MelonLogger.Msg("nowindex: " + a.work.nowindex);
                MelonLogger.Msg("adata: " + a.adata);
                MelonLogger.Msg("aiselect: " + a.aiselect);
                MelonLogger.Msg("aijokentbl: " + a.aijokentbl);
            }

            public static void Postfix(ref nbActionProcessData_t a)
            {
                MelonLogger.Msg("--SetAction_AISCR Postfix--");
                MelonLogger.Msg("id: " + a.work.id);
                MelonLogger.Msg("nowcommand: " + a.work.nowcommand);
                MelonLogger.Msg("nowindex: " + a.work.nowindex);
                MelonLogger.Msg("adata: " + a.adata);
                MelonLogger.Msg("aiselect: " + a.aiselect);
                MelonLogger.Msg("aijokentbl: " + a.aijokentbl);
            }
        }

        [HarmonyPatch(typeof(nbaifunc_t.funcDelegate), "Invoke")]
        private class Patch20
        {
            public static void Prefix(ref nbActionProcessData_t UnnamedParameter, ref int UnnamedParameter2)
            {
                MelonLogger.Msg("--Invoke--");
                MelonLogger.Msg("adata: " + UnnamedParameter.adata);
                MelonLogger.Msg("aiselect: " + UnnamedParameter.aiselect);
                MelonLogger.Msg("aijokentbl: " + UnnamedParameter.aijokentbl);
                MelonLogger.Msg("UnnamedParameter2: " + UnnamedParameter2);
            }

            public static void Postfix(ref nbActionProcessData_t UnnamedParameter, ref int UnnamedParameter2, ref int __result)
            {
                MelonLogger.Msg("--Invoke Postfix--");
                MelonLogger.Msg("adata: " + UnnamedParameter.adata);
                MelonLogger.Msg("aiselect: " + UnnamedParameter.aiselect);
                MelonLogger.Msg("aijokentbl: " + UnnamedParameter.aijokentbl);
                MelonLogger.Msg("UnnamedParameter2: " + UnnamedParameter2);
                MelonLogger.Msg("result: " + __result);
            }
        }

        [HarmonyPatch(typeof(datDevilAI), "Get")]
        private class Patch21
        {
            public static void Prefix(ref int id)
            {
                MelonLogger.Msg("--DevilAI.Get--");
                MelonLogger.Msg("id: " + id);
                MelonLogger.Msg("nbaifunc length: " + nbAi.nbaifunc.Length);
            }

            public static void Postfix(ref int id, ref datDevilAI_t __result)
            {
                MelonLogger.Msg("--DevilAI.Get Postfix--");
                MelonLogger.Msg("id: " + id);
                MelonLogger.Msg("script id: " + __result.scriptid);
                //MelonLogger.Msg(JsonConvert.SerializeObject(__result));
            }
        }

        [HarmonyPatch(typeof(datDevilAI), "tbl")]
        private class Patch22
        {
            public static void Postfix(ref int idx)
            {
                MelonLogger.Msg("--DevilAI.tbl--");
                MelonLogger.Msg("idx: " + idx);
            }
        }

        [HarmonyPatch(typeof(ScrTraceCode), "scrSetIntReturnValue")]
        private class Patch23
        {
            public static void Postfix(ref int i)
            {
                MelonLogger.Msg("--scrSetIntReturnValue--");
                MelonLogger.Msg("i: " + i);
            }
        }
    }
}