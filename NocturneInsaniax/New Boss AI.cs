using HarmonyLib;
using Il2Cpp;
using Il2Cppeffect_H;
using Il2Cppfacility_H;
using Il2Cppnewbattle_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using MelonLoader;
using MelonLoader.TinyJSON;
using Newtonsoft.Json;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Xml;
using UnityEngine;
using static Il2Cpp.SteamDlcFileUtil;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        private static System.Random random = new System.Random();
        private static short auroraValue = 0;
        private static Dictionary<int, ActionTracker> actionTrackers = new Dictionary<int, ActionTracker>();
        private static Dictionary<int, List<ushort>> resistPassives = new Dictionary<int, List<ushort>>
        {
            { 00, new List<ushort>{ 313 } }, // Phys
            { 01, new List<ushort>{ 314, 364 } }, // Fire
            { 02, new List<ushort>{ 315, 364 } }, // Ice
            { 03, new List<ushort>{ 316, 364 } }, // Elec
            { 04, new List<ushort>{ 317, 364 } }, // Force
            { 05, new List<ushort>{ } }, // Almighty
            { 06, new List<ushort>{ 318 } }, // Light
            { 07, new List<ushort>{ 319 } }, // Dark
            { 08, new List<ushort>{ 320, 365 } }, // Curse
            { 09, new List<ushort>{ 321, 365 } }, // Nerve
            { 10, new List<ushort>{ 322, 365 } }, // Mind
            { 11, new List<ushort>{ } }, // Self-Destruct
            { 12, new List<ushort>{ 374 } }, // Shot
            { 13, new List<ushort>{ } }, // Heal
            { 14, new List<ushort>{ } }, // Support
            { 15, new List<ushort>{ } }, // Util
        };
        private static Dictionary<int, List<ushort>> immunityPassives = new Dictionary<int, List<ushort>>
        {
            { 00, new List<ushort>{ 323, 333, 338 } }, // Phys
            { 01, new List<ushort>{ 324, 334, 339 } }, // Fire
            { 02, new List<ushort>{ 325, 335, 340 } }, // Ice
            { 03, new List<ushort>{ 326, 336, 341 } }, // Elec
            { 04, new List<ushort>{ 327, 337, 342 } }, // Force
            { 05, new List<ushort>{ } }, // Almighty
            { 06, new List<ushort>{ 328 } }, // Light
            { 07, new List<ushort>{ 329 } }, // Dark
            { 08, new List<ushort>{ 330 } }, // Curse
            { 09, new List<ushort>{ 331 } }, // Nerve
            { 10, new List<ushort>{ 332 } }, // Mind
            { 11, new List<ushort>{ } }, // Self-Destruct
            { 12, new List<ushort>{ 375, 376, 377 } }, // Shot
            { 13, new List<ushort>{ } }, // Heal
            { 14, new List<ushort>{ } }, // Support
            { 15, new List<ushort>{ } }, // Util
        };

        [HarmonyPatch(typeof(nbInit), nameof(nbInit.nbCallNewBattle))]
        private class InitBattlePatch
        {
            public static void Postfix()
            {
                auroraValue = 0;
                actionTrackers.Clear();
                foreach (var party in nbMainProcess.nbGetMainProcessData().party)
                    party.count = new short[21];
                sakahagiSkip = true;
                datNormalSkill.tbl[272].hpn = 50;
                //MelonLogger.Msg("-Battle Starts-");
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.CheckAction_NON))]
        private class CheckAction_NONPatch
        {
            public static void Prefix(ref nbActionProcessData_t a)
            {
                if ((a.data.encno == 1270 || a.data.encno == 1271 || a.data.encno == 1272 || a.data.encno == 1273) && a.type != 3 && a.form.formindex >= 4 && !pushedSkillList.Contains((ushort)a.adata))
                    a.type = 0;
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.CheckMukanNego))]
        private class CheckMukanNegoPatch
        {
            public static void Postfix(ref nbActionProcessData_t a, ref int __result)
            {
                if ((a.data.encno == 1270 || a.data.encno == 1271 || a.data.encno == 1272 || a.data.encno == 1273) && a.form.formindex >= 4)
                    __result = 0;
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.CheckSenseiNego))]
        private class CheckSenseiNegoPatch
        {
            public static void Postfix(ref nbActionProcessData_t a, ref int __result)
            {
                if ((a.data.encno == 1270 || a.data.encno == 1271 || a.data.encno == 1272 || a.data.encno == 1273) && a.form.formindex >= 4)
                    __result = 0;
            }
        }

        [HarmonyPatch(typeof(nbMainProcess), nameof(nbMainProcess.nbSetPressMaePhase))]
        private class PressMaePhasePatch
        {
            public static void Postfix(ref nbMainProcessData_t data)
            {
                previousUnitId = 0;
                faithfulCompanionActive = false;
                faithfulCompanionActive2 = false;

                short activeUnit = data.activeunit;

                if (activeUnit >= 4)
                {
                    var enemyUnits = data.enemyunit.Where(x => x.id != 0);
                    foreach (var unit in enemyUnits)
                    {
                        if (!actionTrackers.ContainsKey(unit.id))
                        {
                            actionTrackers.Add(unit.id, new ActionTracker());

                            if (new ushort[] { 252, 254, 258, 259, 264, 293 }.Contains(unit.id))
                                actionTrackers[unit.id].extraTurns = 1;
                            if (unit.id == 259)
                                nbMainProcess.nbGetPartyFromFormindex(4).count[19] = auroraValue;
                        }

                        if (unit.hp == 0 && !data.enemyunit.Where(x => x.id == unit.id && x.hp != 0).Any())
                        {
                            actionTrackers.Remove(unit.id);
                        }

                        if (actionTrackers.ContainsKey(unit.id))
                        {
                            data.press4_p += actionTrackers[unit.id].extraTurns;
                            data.press4_ten += actionTrackers[unit.id].extraTurns;
                        }

                        if (unit.id == 297)
                        {
                            if (unit.hp <= 1200 || actionTrackers[unit.id].phase == 3)
                            {
                                data.press4_p -= 2;
                                data.press4_ten -= 2;
                            }
                            else if (unit.hp <= 3600 || actionTrackers[unit.id].phase == 2)
                            {
                                data.press4_p -= 1;
                                data.press4_ten -= 1;
                            }
                        }

                        if (data.encno == 451)
                        {
                            if (actionTrackers[344].scriptVar1 == 2)
                            {
                                data.press4_p = 0;
                            }
                            else if (actionTrackers[344].scriptVar1 == 3)
                            {
                                data.press4_p += 1;
                                data.press4_ten += 1;
                            }
                            else if (actionTrackers[344].scriptVar1 == 4)
                            {
                                data.press4_p = 0;
                                data.press4_ten += 1;
                            }
                        }
                    }

                    foreach (var actionCounter in actionTrackers.Values)
                    {
                        actionCounter.currentBattleTurnCount++;
                        actionCounter.currentTurnActionCount = 0;
                        actionCounter.skillsUsedThisTurn.Clear();
                    }

                    for (int i = 4; i <= 13; i++)
                    {
                        try
                        {
                            // Reset Barriers
                            nbMainProcess.nbGetPartyFromFormindex(i).count[13] = 0;
                            nbMainProcess.nbGetPartyFromFormindex(i).count[14] = 0;
                        } catch { }
                    }

                    //MelonLogger.Msg("-Enemy Turn Starts-");
                }
                else if (activeUnit <= 3)
                {
                    // Dark Opus
                    if (dds3GlobalWork.DDS3_GBWK.heartsequip == 18)
                    {
                        bool darkOpusActive = true;
                        for (int i = 0; i <= 3; i++)
                        {
                            try
                            {
                                if (!(nbMainProcess.nbGetUnitWorkFromFormindex(i).id == 0 || demonPotentials[nbMainProcess.nbGetUnitWorkFromFormindex(i).id][7] > 0))
                                    darkOpusActive = false;
                            }
                            catch { }
                        }

                        if (darkOpusActive)
                        {
                            data.press4_ten += 1;
                        }
                    }

                    // Light Opus
                    if (dds3GlobalWork.DDS3_GBWK.heartsequip == 21)
                    {
                        bool lightOpusActive = true;
                        for (int i = 0; i <= 3; i++)
                        {
                            try
                            {
                                if (!(nbMainProcess.nbGetUnitWorkFromFormindex(i).id == 0 || demonPotentials[nbMainProcess.nbGetUnitWorkFromFormindex(i).id][6] > 0))
                                    lightOpusActive = false;
                            }
                            catch { }
                        }

                        if (lightOpusActive)
                        {
                            data.press4_ten += 1;
                        }
                    }

                    for (int i = 0; i <= 3; i++)
                    {
                        try
                        {
                            // Solitary Drift
                            if (data.press4_p == 1 && data.press4_ten == 1 && data.playerpcnt == 1 && datCalc.datCheckSyojiSkill(nbMainProcess.nbGetUnitWorkFromFormindex(i), 378) != 0)
                                data.press4_ten += 1;

                            // Reset Barriers
                            nbMainProcess.nbGetPartyFromFormindex(i).count[13] = 0;
                            nbMainProcess.nbGetPartyFromFormindex(i).count[14] = 0;
                        } catch { }
                    }

                    if (data.encno == 451)
                    {
                        if (actionTrackers[344].scriptVar1 == 2)
                        {
                            data.press4_p = 0;
                        }
                        else if (actionTrackers[344].scriptVar1 == 3)
                        {
                            data.press4_p += 1;
                            data.press4_ten += 1;
                        }
                        else if (actionTrackers[344].scriptVar1 == 4)
                        {
                            data.press4_p = 0;
                            data.press4_ten += 1;
                        }
                    }

                    //MelonLogger.Msg("-Ally Turn Starts-");
                }
            }
        }

        //[HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetVirtualAisyo))]
        //private class nbGetVirtualAisyoPatch
        //{
        //    public static void Postfix(ref int nskill, ref int sformindex, ref int dformindex, ref int __result)
        //    {
        //        //MelonLogger.Msg("--nbCalc.nbGetVirtualAisyo--");
        //        //MelonLogger.Msg("nskill: " + nskill);
        //        //MelonLogger.Msg("sformindex: " + sformindex);
        //        //MelonLogger.Msg("dformindex: " + dformindex);
        //        //MelonLogger.Msg("result: " + __result);
        //    }
        //}

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetVirtualKoukaPoint))]
        private class nbGetVirtualKoukaPointPatch
        {
            public static void Postfix(ref int nskill, ref int sformindex, ref int dformindex, ref int __result)
            {
                ////MelonLogger.Msg("--nbCalc.nbGetVirtualKoukaPoint--");
                ////MelonLogger.Msg("nskill: " + nskill);
                ////MelonLogger.Msg("sformindex: " + sformindex);
                ////MelonLogger.Msg("dformindex: " + dformindex);
                ////MelonLogger.Msg("result: " + __result);
                if (new int[] { 65536, 131072, 262144 }.Contains(nbCalc.nbGetVirtualAisyo(nskill, sformindex, dformindex)))
                    __result = 0;
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetAuroraPacket))]
        private class SetAuroraPacketPatch
        {
            public static void Postfix(ref nbActionProcessData_t a, ref int dformindex, ref int sframe)
            {
                auroraValue = nbMainProcess.nbGetPartyFromFormindex(4).count[19];
            }
        }


        [HarmonyPatch(typeof(nbAi), nameof(nbAi.nbSetAiTarget))]
        private class AiPatch
        {
            public static void Prefix(ref nbActionProcessData_t a, ref int code, ref int n)
            {
                actionProcessData = a;

                if (bossList.Contains(a.work.id) && !bossesWithMana.Contains(a.work.id))
                    a.work.mp = a.work.maxmp;

                actionTrackers[a.work.id].currentBattleActionCount++;
                actionTrackers[a.work.id].currentTurnActionCount++;
                //MelonLogger.Msg("ID: " + a.work.id);
                //MelonLogger.Msg("currentBattleTurnCount:" + actionTrackers[a.work.id].currentBattleTurnCount);
                //MelonLogger.Msg("currentBattleActionCount:" + actionTrackers[a.work.id].currentBattleActionCount);
                //MelonLogger.Msg("currentTurnActionCount:" + actionTrackers[a.work.id].currentTurnActionCount);
                //MelonLogger.Msg("-Action Starts-");
                SetTargetingRule(ref code, ref n, 0, 0);
                if (!pushedSkillList.Contains(a.work.nowindex))
                {
                    switch (a.work.id)
                    {
                        case 1: VishnuAI(ref a, ref code, ref n); break;
                        case 6: HorusAI(ref a, ref code, ref n); break;
                        case 7: LakshmiAI(ref a, ref code, ref n); break;
                        case 9: SarasvatiAI(ref a, ref code, ref n); break;
                        case 11: AmeNoUzumeAI(ref a, ref code, ref n); break;
                        case 12: ShivaAI(ref a, ref code, ref n); break;
                        case 14: QitianDashengAI(ref a, ref code, ref n); break;
                        case 15: DionysusAI(ref a, ref code, ref n); break;
                        case 18: ParvatiAI(ref a, ref code, ref n); break;
                        case 19: KushinadaHimeAI(ref a, ref code, ref n); break;
                        case 20: KikuriHimeAI(ref a, ref code, ref n); break;
                        case 25: OkuninushiAI(ref a, ref code, ref n); break;
                        case 28: TakeMinakataAI(ref a, ref code, ref n); break;
                        case 30: BaihuAI(ref a, ref code, ref n); break;
                        case 31: SenriAI(ref a, ref code, ref n); break;
                        case 32: ZhuqueAI(ref a, ref code, ref n); break;
                        case 33: ShiisaaAI(ref a, ref code, ref n); break;
                        case 34: XiezhaiAI(ref a, ref code, ref n); break;
                        case 35: UnicornAI(ref a, ref code, ref n); break;
                        case 79: ForcedNagaAI(ref a, ref code, ref n); break;
                        case 97: ForcedShikigamiAI(ref a, ref code, ref n); break;
                        case 108: BaphometAI(ref a, ref code, ref n); break;
                        case 124: NKENueAI(ref a, ref code, ref n); break;
                        case 138: NKEMichaelAI(ref a, ref code, ref n); break;
                        case 139: NKEGabrielAI(ref a, ref code, ref n); break;
                        case 140: NKERaphaelAI(ref a, ref code, ref n); break;
                        case 141: NKEUrielAI(ref a, ref code, ref n); break;
                        case 142: GaneshaAI(ref a, ref code, ref n); break;
                        case 143: ValkyrieAI(ref a, ref code, ref n); break;
                        case 145: KuramaTenguAI(ref a, ref code, ref n); break;
                        case 146: HanumanAI(ref a, ref code, ref n); break;
                        case 147: CuChulainnAI(ref a, ref code, ref n); break;
                        case 148: QingLongAI(ref a, ref code, ref n); break;
                        case 149: XuanwuAI(ref a, ref code, ref n); break;
                        case 151: MakamiAI(ref a, ref code, ref n); break;
                        case 152: GarudaAI(ref a, ref code, ref n); break;
                        case 162: BossManikinAI(ref a, ref code, ref n); break;
                        case 163: BossManikinAI(ref a, ref code, ref n); break;
                        case 164: BossManikinAI(ref a, ref code, ref n); break;
                        case 165: BossManikinAI(ref a, ref code, ref n); break;
                        case 166: BossManikinAI(ref a, ref code, ref n); break;
                        case 169: NKEKinKiAI(ref a, ref code, ref n); break;
                        case 170: NKESuiKiAI(ref a, ref code, ref n); break;
                        case 171: NKEFuuKiAI(ref a, ref code, ref n); break;
                        case 172: NKEOngyoKiAI(ref a, ref code, ref n); break;
                        case 195: NKEPaleRiderAI(ref a, ref code, ref n); break;
                        case 196: NKEWhiteRiderAI(ref a, ref code, ref n); break;
                        case 197: NKERedRiderAI(ref a, ref code, ref n); break;
                        case 198: NKEBlackRiderAI(ref a, ref code, ref n); break;
                        case 199: NKEMatadorAI(ref a, ref code, ref n); break;
                        case 200: NKEHellBikerAI(ref a, ref code, ref n); break;
                        case 201: NKEDaisoujouAI(ref a, ref code, ref n); break;
                        case 202: NKEMotherHarlotAI(ref a, ref code, ref n); break;
                        case 203: NKETrumpeterAI(ref a, ref code, ref n); break;
                        case 207: NKEBeelzebubManAI(ref a, ref code, ref n); break;
                        case 224: TamLinAI(ref a, ref code, ref n); break;
                        case 225: DoppelgangerAI(ref a, ref code, ref n); break;
                        case 228: VritraAI(ref a, ref code, ref n); break;
                        case 229: DemeeHoAI(ref a, ref code, ref n); break;

                        case 244: TripleReasonAhrimanAI(ref a, ref code, ref n); break;
                        case 245: TripleReasonBaalAvatarAI(ref a, ref code, ref n); break;
                        case 246: TripleReasonNoahAI(ref a, ref code, ref n); break;
                        case 248: BossSethAI(ref a, ref code, ref n); break;
                        case 249: SargeGirimekhalaAI(ref a, ref code, ref n); break;
                        case 250: NKEPixieAI(ref a, ref code, ref n); break;
                        case 251: NKEJackFrostAI(ref a, ref code, ref n); break;
                        case 252: BossDevilDanteAI(ref a, ref code, ref n); break;
                        case 253: BossGameteAI(ref a, ref code, ref n); break;
                        case 254: YHVHAI(ref a, ref code, ref n); break;

                        case 256: BossForneusAI(ref a, ref code, ref n); break;
                        case 257: BossSpecter1AI(ref a, ref code, ref n); break;
                        case 258: BossAhriman2AI(ref a, ref code, ref n); break;
                        case 259: BossNoah2AI(ref a, ref code, ref n); break;
                        case 261: ForcedKoppaTenguAI(ref a, ref code, ref n); break;
                        case 262: ForcedKaiwanAI(ref a, ref code, ref n); break;
                        case 263: BossOseAI(ref a, ref code, ref n); break;
                        case 264: BossKagutsuchi2AI(ref a, ref code, ref n); break;
                        case 266: BossKinKiAI(ref a, ref code, ref n); break;
                        case 267: BossSuiKiAI(ref a, ref code, ref n); break;
                        case 268: BossFuuKiAI(ref a, ref code, ref n); break;
                        case 269: BossOngyoKiAI(ref a, ref code, ref n); break;
                        case 270: BossClotho1AI(ref a, ref code, ref n); break;
                        case 271: BossLachesis1AI(ref a, ref code, ref n); break;
                        case 272: BossAtropos1AI(ref a, ref code, ref n); break;
                        case 274: BossGirimekhalaAI(ref a, ref code, ref n); break;
                        case 275: BossSpecter3AI(ref a, ref code, ref n); break;
                        case 276: BossAcielAI(ref a, ref code, ref n); break;
                        case 277: BossSkadiAI(ref a, ref code, ref n); break;
                        case 279: BossUrthonaAI(ref a, ref code, ref n); break;
                        case 280: BossUrizenAI(ref a, ref code, ref n); break;
                        case 281: BossLuvahAI(ref a, ref code, ref n); break;
                        case 282: BossTharmusAI(ref a, ref code, ref n); break;
                        case 283: BossFutomimiAI(ref a, ref code, ref n); break;
                        case 284: BossGabrielAI(ref a, ref code, ref n); break;
                        case 285: BossRaphaelAI(ref a, ref code, ref n); break;
                        case 286: BossUrielAI(ref a, ref code, ref n); break;
                        case 287: BossSamaelAI(ref a, ref code, ref n); break;
                        case 288: BossBaalAvatarAI(ref a, ref code, ref n); break;
                        case 289: BossOseHallelAI(ref a, ref code, ref n); break;
                        case 290: BossFlaurosHallelAI(ref a, ref code, ref n); break;
                        case 291: BossAhriman1AI(ref a, ref code, ref n); break;
                        case 292: BossNoah1AI(ref a, ref code, ref n); break;
                        case 293: BossKagutsuchi1AI(ref a, ref code, ref n); break;
                        case 294: BigSpecterAI(ref a, ref code, ref n); break;
                        case 295: BigSpecterAI(ref a, ref code, ref n); break;
                        case 296: BigSpecterAI(ref a, ref code, ref n); break;
                        case 297: BossMizuchiAI(ref a, ref code, ref n); break;
                        case 298: BossMichaelAI(ref a, ref code, ref n); break;
                        case 299: BossSakahagiAI(ref a, ref code, ref n); break;
                        case 300: BossOrthrusAI(ref a, ref code, ref n); break;
                        case 301: BossYaksiniAI(ref a, ref code, ref n); break;
                        case 302: BossThor1AI(ref a, ref code, ref n); break;
                        case 303: BossBlackFrostAI(ref a, ref code, ref n); break;
                        case 304: BossCerberusRAI(ref a, ref code, ref n); break;
                        case 305: BossCerberusCAI(ref a, ref code, ref n); break;
                        case 306: BossCerberusLAI(ref a, ref code, ref n); break;
                        case 307: BossEligorAI(ref a, ref code, ref n, 129); break; // Summons Yaka
                        case 308: BossEligorAI(ref a, ref code, ref n, 49); break; // Summons Dis
                        case 309: BossEligorAI(ref a, ref code, ref n, 118); break; // Summons Incubus
                        case 310: ForcedKelpieAI(ref a, ref code, ref n); break;
                        case 311: ForcedKelpieAI(ref a, ref code, ref n); break;
                        case 312: BossBerithAI(ref a, ref code, ref n); break;
                        case 313: ForcedSuccubusAI(ref a, ref code, ref n); break;
                        case 315: ForcedKaiwanAI(ref a, ref code, ref n); break;
                        case 317: BossTrollAI(ref a, ref code, ref n); break;
                        case 320: BossBishamonten1AI(ref a, ref code, ref n); break;
                        case 321: BossMaraAI(ref a, ref code, ref n); break;
                        case 322: BossBishamonten2AI(ref a, ref code, ref n); break;
                        case 323: BossJikokutenAI(ref a, ref code, ref n); break;
                        case 324: BossKoumokutenAI(ref a, ref code, ref n); break;
                        case 325: BossZouchoutenAI(ref a, ref code, ref n); break;
                        case 326: BossClotho2AI(ref a, ref code, ref n); break;
                        case 327: BossLachesis2AI(ref a, ref code, ref n); break;
                        case 328: BossAtropos2AI(ref a, ref code, ref n); break;
                        case 329: BossMitraAI(ref a, ref code, ref n); break;
                        case 333: BossMadaAI(ref a, ref code, ref n); break;
                        case 334: BossMotAI(ref a, ref code, ref n); break;
                        case 335: BossSurtAI(ref a, ref code, ref n); break;
                        case 243: BossPazuzuAI(ref a, ref code, ref n); break;
                        case 337: BossThor2AI(ref a, ref code, ref n); break;

                        case 339: BossDanteRaidou1AI(ref a, ref code, ref n); break;
                        case 340: ChaseDanteRaidouAI(ref a, ref code, ref n); break;
                        case 341: BossDanteRaidou2AI(ref a, ref code, ref n); break;
                        case 342: BossMetatronAI(ref a, ref code, ref n); break;
                        case 343: BossBeelzebubFlyAI(ref a, ref code, ref n); break;
                        case 344: BossLuciferAI(ref a, ref code, ref n); break;
                        case 345: BossPaleRiderAI(ref a, ref code, ref n); break;
                        case 346: BossWhiteRiderAI(ref a, ref code, ref n); break;
                        case 347: BossRedRiderAI(ref a, ref code, ref n); break;
                        case 348: BossBlackRiderAI(ref a, ref code, ref n); break;
                        case 349: BossMatadorAI(ref a, ref code, ref n); break;
                        case 350: BossHellBikerAI(ref a, ref code, ref n); break;
                        case 351: BossDaisoujouAI(ref a, ref code, ref n); break;
                        case 352: BossMotherHarlotAI(ref a, ref code, ref n); break;
                        case 353: BossTrumpeterAI(ref a, ref code, ref n); break;
                        case 356: NasuFlyAI(ref a, ref code, ref n); break;
                        case 358: BossLoaAI(ref a, ref code, ref n); break;
                        case 359: BossVirtueAI(ref a, ref code, ref n); break;
                        case 360: BossPowerAI(ref a, ref code, ref n); break;
                        case 361: BossLegionAI(ref a, ref code, ref n); break;

                        case 362: BossFlaurosAI(ref a, ref code, ref n); break;
                        case 363: RaidouTamLinAI(ref a, ref code, ref n); break;
                        case 364: RaidouGdonAI(ref a, ref code, ref n); break;
                        case 365: RaidouVritraAI(ref a, ref code, ref n); break;
                        case 366: RaidouJackFrostAI(ref a, ref code, ref n); break;
                        default: break;
                    }
                }
                //MelonLogger.Msg("skill: " + a.work.nowindex);
            }
        }

        private static void VishnuAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220) &&
                a.data.enemypcnt == 1)
                UseSkill(ref a, 220);
            else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(100) || 
                actionTrackers[a.work.id].skillsUsedThisTurn.Contains(195) || 
                actionTrackers[a.work.id].skillsUsedThisTurn.Contains(471))
            {
                int randomValue = random.Next(6);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 141); break;
                    case 2: UseSkill(ref a, 141); break;
                    case 3: UseSkill(ref a, 196); break;
                    case 4: UseSkill(ref a, 454); break;
                    case 5: UseSkill(ref a, 454); break;
                }
            }
            else
            {
                int randomValue = random.Next(10);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 100); break;
                    case 2: UseSkill(ref a, 100); break;
                    case 3: UseSkill(ref a, 141); break;
                    case 4: UseSkill(ref a, 141); break;
                    case 5: UseSkill(ref a, 195); break;
                    case 6: UseSkill(ref a, 196); break;
                    case 7: UseSkill(ref a, 454); break;
                    case 8: UseSkill(ref a, 454); break;
                    case 9: UseSkill(ref a, 471); break;
                }
            }
        }

        private static void HorusAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220) &&
                a.data.enemypcnt == 1)
                UseSkill(ref a, 220);
            else if (actionTrackers[a.work.id].currentBattleTurnCount == 1)
                UseSummonSkill(ref a, 226, (ushort)(64 + random.Next(2)));
            else if (actionTrackers[a.work.id].currentBattleTurnCount != 1 &&
                a.data.enemypcnt == 1)
                UseSummonSkill(ref a, 226, (ushort) (64 + random.Next(2)));
            else if (a.data.enemyunit.Where(x => x.hp < x.maxhp && x.flag != 0).Any())
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 30); break;
                    case 2: UseSkill(ref a, 193); break;
                    case 3: UseSkill(ref a, 40); break;
                    case 4: UseSkill(ref a, 40); break;
                }
            }
            else
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 30); break;
                    case 2: UseSkill(ref a, 30); break;
                    case 3: UseSkill(ref a, 193); break;
                    case 4: UseSkill(ref a, 193); break;
                }
            }
        }

        private static void LakshmiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            {
                if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
                    UseSkill(ref a, 219);
                else if (nbMainProcess.nbGetMainProcessData().enemypcnt <= 2 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(226))
                    UseSummonSkill(ref a, 226, 83);
                else if (nbMainProcess.nbGetMainProcessData().enemyunit.Where(x => x.hp < x.maxhp && x.flag != 0).Any())
                {
                    int randomValue = random.Next(5);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 41); break;
                        case 1: UseSkill(ref a, 41); break;
                        case 2: UseSkill(ref a, 41); break;
                        case 3: UseNormalAttack(ref a); break;
                        case 4: UseSkill(ref a, 197); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(2);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 197); break;
                    }
                }
            }
        }

        private static void SarasvatiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
                UseSkill(ref a, 220);
            else
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 443); break;
                    case 2: UseSkill(ref a, 443); break;
                    case 3: UseSkill(ref a, 185); break;
                    case 4: UseSkill(ref a, 198); break;
                }
            }
        }

        private static void AmeNoUzumeAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentTurnActionCount <= 1 &&
                nbMainProcess.nbGetMainProcessData().enemypcnt == 1)
            {
                if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(229))
                    UseSummonSkill(ref a, 229, 89);
                else
                    UseSkill(ref a, 219);
            }
            else
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 22); break;
                    case 2: UseSkill(ref a, 22); break;
                    case 3: UseSkill(ref a, 28); break;
                    case 4: UseSkill(ref a, 28); break;
                }
            }
        }

        private static void ShivaAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleTurnCount == 1)
                UseSkill(ref a, 470);
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220) &&
                a.data.enemypcnt == 1)
                UseSkill(ref a, 220);
            else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(104) ||
                actionTrackers[a.work.id].skillsUsedThisTurn.Contains(442) ||
                actionTrackers[a.work.id].skillsUsedThisTurn.Contains(470))
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 179); break;
                    case 2: UseSkill(ref a, 179); break;
                    case 3: UseSkill(ref a, 453); break;
                    case 4: UseSkill(ref a, 453); break;
                }
            }
            else
            {
                int randomValue = random.Next(10);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 104); break;
                    case 2: UseSkill(ref a, 104); break;
                    case 3: UseSkill(ref a, 179); break;
                    case 4: UseSkill(ref a, 179); break;
                    case 5: UseSkill(ref a, 442); break;
                    case 6: UseSkill(ref a, 442); break;
                    case 7: UseSkill(ref a, 453); break;
                    case 8: UseSkill(ref a, 453); break;
                    case 9: UseSkill(ref a, 470); break;
                }
            }
        }

        private static void QitianDashengAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
                UseSkill(ref a, 220);
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(64) && !EnemyPartyBuffed(2, 5) && a.work.mp > 0)
                UseSkill(ref a, 64);
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(65) && !EnemyPartyBuffed(2, 8) && a.work.mp > 0)
                UseSkill(ref a, 65);
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(66) && !EnemyPartyBuffed(2, 7) && a.work.mp > 0)
                UseSkill(ref a, 66);
            else
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 103); break;
                    case 2: UseSkill(ref a, 103); break;
                    case 3: UseSkill(ref a, 104); break;
                    case 5: UseSkill(ref a, 104); break;
                }
            }
        }

        private static void DionysusAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
                UseSkill(ref a, 220);
            else
            {
                int randomValue = random.Next(6);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 426); break;
                    case 2: UseSkill(ref a, 6); break;
                    case 3: UseSkill(ref a, 6); break;
                    case 4: UseSkill(ref a, 207); break;
                    case 5: UseSkill(ref a, 207); break;
                }
            }
        }

        private static void ParvatiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
                UseSkill(ref a, 220);
            else if (nbMainProcess.nbGetMainProcessData().enemyunit.Where(x => x.hp < x.maxhp && x.flag != 0).Any())
            {
                int randomValue = random.Next(8);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 40); break;
                    case 1: UseSkill(ref a, 40); break;
                    case 2: UseSkill(ref a, 40); break;
                    case 3: UseSkill(ref a, 3); break;
                    case 4: UseSkill(ref a, 6); break;
                    case 5: UseSkill(ref a, 476); break;
                    case 6: UseSkill(ref a, 214); break;
                    case 7: UseSkill(ref a, 215); break;
                }
            }
            else
            {
                int randomValue = random.Next(6);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 3); break;
                    case 2: UseSkill(ref a, 6); break;
                    case 3: UseSkill(ref a, 476); break;
                    case 4: UseSkill(ref a, 214); break;
                    case 5: UseSkill(ref a, 215); break;
                }
            }
        }

        private static void KushinadaHimeAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
                UseSkill(ref a, 220);
            else if (nbMainProcess.nbGetMainProcessData().enemypcnt <= 2 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(226))
            {
                int randomValue = random.Next(2);
                switch (randomValue)
                {
                    case 0: UseSummonSkill(ref a, 226, 99); break;
                    case 1: UseSummonSkill(ref a, 226, 100); break;
                }
            }
            else if (nbMainProcess.nbGetMainProcessData().enemyunit.Where(x => x.hp < x.maxhp && x.flag != 0).Any())
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 40); break;
                    case 1: UseSkill(ref a, 40); break;
                    case 2: UseSkill(ref a, 40); break;
                    case 3: UseSkill(ref a, 5); break;
                    case 4: UseSkill(ref a, 90); break;
                }
            }
            else
            {
                int randomValue = random.Next(3);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 5); break;
                    case 2: UseSkill(ref a, 90); break;
                }
            }
        }

        private static void KikuriHimeAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentTurnActionCount <= 1 &&
                actionTrackers[a.work.id].currentBattleTurnCount % 2 != 0)
                UseSkill(ref a, 219);
            else
            {
                if (nbMainProcess.nbGetMainProcessData().enemyunit.Where(x => x.hp < x.maxhp && x.flag != 0).Any())
                {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                        case 2: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                        case 3: UseSkill(ref a, 214); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 214); break;
                        case 2: UseSkill(ref a, 214); break;
                    }
                }
            }
        }

        private static void OkuninushiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277))
                UseSkill(ref a, 277);
            else
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 110); break;
                    case 2: UseSkill(ref a, 5); break;
                    case 3: UseSkill(ref a, 56); break;
                    case 4: UseSkill(ref a, 428); break;
                }
            }
        }

        private static void TakeMinakataAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
                UseSkill(ref a, 220);
            else if (AllyPartyBuffed(1))
                UseSkill(ref a, 57);
            else if (EnemyFocused(ref a))
            {
                int randomValue = random.Next(4);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 16); break;
                    case 2: UseSkill(ref a, 14); break;
                    case 3: UseSkill(ref a, 427); break;
                }
            }
            else
            {
                int randomValue = random.Next(4);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 16); break;
                    case 1: UseSkill(ref a, 14); break;
                    case 2: UseSkill(ref a, 224); break;
                    case 3: UseSkill(ref a, 427); break;
                }
            }
        }

        private static void BaihuAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277))
                UseSkill(ref a, 277);
            else if (EnemyFocused(ref a))
            {
                int randomValue = random.Next(8);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 120); break;
                    case 2: UseSkill(ref a, 120); break;
                    case 3: UseSkill(ref a, 126); break;
                    case 4: UseSkill(ref a, 126); break;
                    case 5: UseSkill(ref a, 9); break;
                    case 6: UseSkill(ref a, 15); break;
                    case 7: UseSkill(ref a, 183); break;
                }
            }
            else
            {
                int randomValue = random.Next(10);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 120); break;
                    case 1: UseSkill(ref a, 126); break;
                    case 2: UseSkill(ref a, 9); break;
                    case 3: UseSkill(ref a, 9); break;
                    case 4: UseSkill(ref a, 15); break;
                    case 5: UseSkill(ref a, 15); break;
                    case 6: UseSkill(ref a, 183); break;
                    case 7: UseSkill(ref a, 183); break;
                    case 8: UseSkill(ref a, 224); break;
                    case 9: UseSkill(ref a, 224); break;
                }
            }
        }

        private static void SenriAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentTurnActionCount <= 1 &&
                nbMainProcess.nbGetMainProcessData().enemypcnt == 1)
                UseSkill(ref a, 219);
            else
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 125); break;
                    case 1: UseSkill(ref a, 23); break;
                    case 2: UseSkill(ref a, 443); break;
                    case 3: UseSkill(ref a, 62); break;
                    case 4: UseSkill(ref a, 198); break;
                }
            }
        }

        private static void ZhuqueAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277))
                UseSkill(ref a, 277);
            else
            {
                int randomValue = random.Next(3);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 5); break;
                    case 1: UseSkill(ref a, 17); break;
                    case 2: UseSkill(ref a, 53); break;
                }
            }
        }

        private static void ShiisaaAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleActionCount <= 2)
                UseSkill(ref a, 203);
            else
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 121); break;
                    case 2: UseSkill(ref a, 123); break;
                    case 3: UseSkill(ref a, 182); break;
                    case 4: UseSkill(ref a, 182); break;
                }
            }
        }

        private static void XiezhaiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277))
                UseSkill(ref a, 277);
            else
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 11); break;
                    case 1: UseSkill(ref a, 97); break;
                    case 2: UseSkill(ref a, 193); break;
                    case 3: UseSkill(ref a, 202); break;
                    case 4: UseSkill(ref a, 437); break;
                }
            }
        }

        private static void UnicornAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleActionCount <= 1)
                UseSkill(ref a, 66);
            else if (nbMainProcess.nbGetMainProcessData().enemypcnt <= 2)
                UseSummonSkill(ref a, 226, 125);
            else
            {
                if (nbMainProcess.nbGetMainProcessData().enemyunit.Where(x => x.hp < x.maxhp && x.flag != 0).Any())
                {
                    int randomValue = random.Next(5);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                        case 1: UseSkill(ref a, 39); break;
                        case 2: UseSkill(ref a, 10); break;
                        case 3: UseSkill(ref a, 10); break;
                        case 4: UseSkill(ref a, 121); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 30); break;
                        case 2: UseSkill(ref a, 121); break;
                    }
                }
            }
        }

        private static void ForcedNagaAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (a.data.encno == 193 && actionTrackers[a.work.id].currentBattleActionCount <= 1)
                UseSkill(ref a, 220);
            else if (a.data.encno == 193 && actionTrackers[a.work.id].currentBattleActionCount <= 2)
                UseSkill(ref a, 97);
            else if (a.data.encno == 193 && actionTrackers[a.work.id].currentBattleActionCount <= 3)
                UseSummonSkill(ref a, 226, 95);
        }

        private static void ForcedShikigamiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (a.data.encno == 1267)
                UseSkill(ref a, 13);
        }

        private static void BaphometAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!EnemyConcentrated(ref a) && random.Next(10) < 3)
                UseSkill(ref a, 424);
        }

        private static void NKENueAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (a.work.nowindex == 227 && a.data.encno == 1270)
                UseNormalAttack(ref a);
        }

        private static void NKEMichaelAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!pushedSkillList.Contains(a.work.nowindex))
            {
                if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
                    UseSkill(ref a, 220);
                else if (!EnemyPartyBuffed(3) && random.Next(3 + Convert.ToInt32(actionTrackers[a.work.id].skillsUsedThisTurn.Contains(459))) == 0)
                    UseSkill(ref a, 459);
                else
                {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 108); break;
                        case 1: UseSkill(ref a, 467); break;
                        case 2: UseSkill(ref a, 141); break;
                        case 3: UseSkill(ref a, 27); break;
                    }
                }
            }
        }

        private static void NKEGabrielAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!pushedSkillList.Contains(a.work.nowindex))
            {
                if (a.data.enemypcnt < 2 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277))
                    UseSkill(ref a, 277);
                else if (actionTrackers[a.work.id].currentBattleTurnCount == 1 ||
                    !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(459) && !EnemyPartyBuffed(3) && random.Next(3) == 0)
                    UseSkill(ref a, 459);
                else if (EnemyConcentrated(ref a))
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 426); break;
                        case 1: UseSkill(ref a, 439); break;
                        case 2: UseSkill(ref a, 195); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 426); break;
                        case 1: UseSkill(ref a, 439); break;
                        case 2: UseSkill(ref a, 195); break;
                        case 3: UseSkill(ref a, 424); break;
                    }
                }
            }
        }

        private static void NKERaphaelAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!pushedSkillList.Contains(a.work.nowindex))
            {
                if (a.data.enemypcnt < 2 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277))
                    UseSkill(ref a, 277);
                else if (nbMainProcess.nbGetMainProcessData().enemyunit.Where(x => x.hp <= x.maxhp / 4 && x.flag != 0).Any())
                    UseSkill(ref a, 218);
                else
                {
                    int randomValue = random.Next(5);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 106); break;
                        case 1: UseSkill(ref a, 135); break;
                        case 2: UseSkill(ref a, 462); break;
                        case 3: UseSkill(ref a, 31); break;
                        case 4: UseSkill(ref a, 189); break;
                    }
                }
            }
        }

        private static void NKEUrielAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!pushedSkillList.Contains(a.work.nowindex))
            {
                if (a.data.enemypcnt < 2 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277))
                    UseSkill(ref a, 277);
                else if (actionTrackers[a.work.id].currentBattleTurnCount == 1 ||
                    !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(458) && !EnemyPartyBuffed(3) && random.Next(3) == 0)
                    UseSkill(ref a, 458);
                else
                {
                    int randomValue = random.Next(5);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 431); break;
                        case 1: UseSkill(ref a, 178); break;
                        case 2: UseSkill(ref a, 179); break;
                        case 3: UseSkill(ref a, 26); break;
                        case 4: UseSkill(ref a, 476); break;
                    }
                }
            }
        }

        private static void GaneshaAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220) &&
                nbMainProcess.nbGetMainProcessData().enemypcnt == 1)
                UseSkill(ref a, 220);
            else if (actionTrackers[a.work.id].currentBattleTurnCount == 1 ||
                !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(459) && !EnemyPartyBuffed(3) && random.Next(2) == 0)
                UseSkill(ref a, 459);
            else
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 106); break;
                    case 1: UseSkill(ref a, 110); break;
                    case 2: UseSkill(ref a, 155); break;
                    case 3: UseSkill(ref a, 24); break;
                    case 4: UseSkill(ref a, 211); break;
                }
            }
        }

        private static void ValkyrieAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277) && 
                nbMainProcess.nbGetMainProcessData().enemypcnt == 1)
                UseSkill(ref a, 277);
            else if (actionTrackers[a.work.id].currentBattleTurnCount == 1)
                UseSummonSkill(ref a, 226, 88);
            else if (actionTrackers[a.work.id].currentBattleTurnCount != 1 &&
                nbMainProcess.nbGetMainProcessData().enemypcnt == 1)
                UseSummonSkill(ref a, 226, 88);
            else if (nbMainProcess.nbGetMainProcessData().enemyunit.Where(x => x.hp < x.maxhp && x.flag != 0).Any())
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 109); break;
                    case 2: UseSkill(ref a, 2); break;
                    case 3: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                    case 4: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                }
            }
            else
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 109); break;
                    case 2: UseSkill(ref a, 109); break;
                    case 3: UseSkill(ref a, 2); break;
                    case 4: UseSkill(ref a, 2); break;
                }
            }
        }

        private static void KuramaTenguAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277) &&
                nbMainProcess.nbGetMainProcessData().enemypcnt == 1)
                UseSkill(ref a, 277);
            else if (actionTrackers[a.work.id].currentBattleTurnCount == 1)
                UseSummonSkill(ref a, 226, 48);
            else if (actionTrackers[a.work.id].currentBattleTurnCount != 1 &&
                nbMainProcess.nbGetMainProcessData().enemypcnt == 1)
                UseSummonSkill(ref a, 226, 48);
            else
            {
                int randomValue = random.Next(9);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 21); break;
                    case 2: UseSkill(ref a, 21); break;
                    case 3: UseSkill(ref a, 21); break;
                    case 4: UseSkill(ref a, 193); break;
                    case 5: UseSkill(ref a, 193); break;
                    case 6: UseSkill(ref a, 193); break;
                    case 7: UseSkill(ref a, 204); break;
                    case 8: UseSkill(ref a, 204); break;
                }
            }
        }

        private static void HanumanAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
                UseSkill(ref a, 220);
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(64) && !EnemyPartyBuffed(2, 5) && a.work.mp > 0)
                UseSkill(ref a, 64);
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(65) && !EnemyPartyBuffed(2, 8) && a.work.mp > 0)
                UseSkill(ref a, 65);
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(66) && !EnemyPartyBuffed(2, 7) && a.work.mp > 0)
                UseSkill(ref a, 66);
            else
            {
                int randomValue = random.Next(4);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 103); break;
                    case 2: UseSkill(ref a, 103); break;
                    case 3: UseSkill(ref a, 103); break;
                }
            }
        }

        private static void CuChulainnAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277))
                UseSkill(ref a, 277);
            else
            {
                int randomValue = random.Next(9);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 109); break;
                    case 2: UseSkill(ref a, 109); break;
                    case 3: UseSkill(ref a, 426); break;
                    case 4: UseSkill(ref a, 426); break;
                    case 5: UseSkill(ref a, 474); break;
                    case 6: UseSkill(ref a, 474); break;
                    case 7: UseSkill(ref a, 205); break;
                    case 8: UseSkill(ref a, 65); break;
                }
            }
        }

        private static void QingLongAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
                UseSkill(ref a, 220);
            else if (nbMainProcess.nbGetMainProcessData().enemypcnt <= 2 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(226))
            {
                int randomValue = random.Next(4);
                switch (randomValue)
                {
                    case 0: UseSummonSkill(ref a, 226, 40); break;
                    case 1: UseSummonSkill(ref a, 226, 41); break;
                    case 2: UseSummonSkill(ref a, 226, 42); break;
                    case 3: UseSummonSkill(ref a, 226, 43); break;
                }
            }
            else
            {
                int randomValue = random.Next(4);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 120); break;
                    case 1: UseSkill(ref a, 181); break;
                    case 2: UseSkill(ref a, 185); break;
                    case 3: UseSkill(ref a, 29); break;
                }
            }
        }

        private static void XuanwuAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            int randomValue = random.Next(6);
            switch (randomValue)
            {
                case 0: UseNormalAttack(ref a); break;
                case 1: UseSkill(ref a, 8); break;
                case 2: UseSkill(ref a, 180); break;
                case 3: UseSkill(ref a, 430); break;
                case 4: UseSkill(ref a, 66); break;
                case 5: UseSkill(ref a, 66); break;
            }
        }

        private static void MakamiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
                UseSkill(ref a, 220);
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
                UseSkill(ref a, 204);
            else if (actionTrackers[a.work.id].currentBattleActionCount <= 4)
                UseSummonSkill(ref a, 226, 85);
            else
            {
                if (nbMainProcess.nbGetMainProcessData().enemyunit.Where(x => x.hp < x.maxhp && x.flag != 0).Any())
                {
                    int randomValue = random.Next(5);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                        case 1: UseSkill(ref a, 39); break;
                        case 2: UseSkill(ref a, 117); break;
                        case 3: UseSkill(ref a, 176); break;
                        case 4: UseSkill(ref a, 176); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 117); break;
                        case 2: UseSkill(ref a, 176); break;
                        case 3: UseSkill(ref a, 176); break;
                    }
                }
                
            }
        }

        private static void GarudaAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
                UseSkill(ref a, 220);
            else if (a.data.enemypcnt < 2)
                UseSummonSkill(ref a, 226, 154);
            else
            {
                int randomValue = random.Next(6);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 126); break;
                    case 1: UseSkill(ref a, 186); break;
                    case 2: UseSkill(ref a, 462); break;
                    case 3: UseSkill(ref a, 31); break;
                    case 4: UseSkill(ref a, 65); break;
                    case 5: UseSkill(ref a, 204); break;
                }
            }
        }

        private static void NKEKinKiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (a.data.enemypcnt < 2 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
                UseSkill(ref a, 220);
            else if (EnemyFocused(ref a))
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 98); break;
                    case 1: UseSkill(ref a, 99); break;
                    case 2: UseSkill(ref a, 433); break;
                    case 3: UseSkill(ref a, 66); break;
                    case 4: UseSkill(ref a, 205); break;
                }
            }
            else
            {
                int randomValue = random.Next(6);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 98); break;
                    case 1: UseSkill(ref a, 99); break;
                    case 2: UseSkill(ref a, 433); break;
                    case 3: UseSkill(ref a, 66); break;
                    case 4: UseSkill(ref a, 205); break;
                    case 5: UseSkill(ref a, 224); break;
                }
            }
        }

        private static void NKESuiKiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (a.data.enemypcnt < 2 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
                UseSkill(ref a, 220);
            else if (AllyPartyBuffed(1) && random.Next(3) == 0)
                UseSkill(ref a, 57);
            else
            {
                int randomValue = random.Next(4);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 426); break;
                    case 1: UseSkill(ref a, 9); break;
                    case 2: UseSkill(ref a, 181); break;
                    case 3: UseSkill(ref a, 199); break;
                }
            }
        }

        private static void NKEFuuKiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (a.data.enemypcnt < 2 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
                UseSkill(ref a, 220);
            else if (AllyPartyBuffed(1) && random.Next(3) == 0)
                UseSkill(ref a, 57);
            else
            {
                int randomValue = random.Next(6);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 110); break;
                    case 1: UseSkill(ref a, 429); break;
                    case 2: UseSkill(ref a, 21); break;
                    case 3: UseSkill(ref a, 24); break;
                    case 4: UseSkill(ref a, 216); break;
                    case 5: UseSkill(ref a, 204); break;
                }
            }
        }

        private static void NKEOngyoKiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
                UseSkill(ref a, 220);
            else if (!EnemyPartyBuffed(3) && random.Next(3 + Convert.ToInt32(actionTrackers[a.work.id].skillsUsedThisTurn.Contains(458))) == 0)
                UseSkill(ref a, 458);
            else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(26) ||
                actionTrackers[a.work.id].skillsUsedThisTurn.Contains(432) ||
                actionTrackers[a.work.id].skillsUsedThisTurn.Contains(478))
            {
                int randomValue = random.Next(2);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 105); break;
                    case 1: UseSkill(ref a, 33); break;
                }
            }
            else
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 105); break;
                    case 1: UseSkill(ref a, 432); break;
                    case 2: UseSkill(ref a, 26); break;
                    case 3: UseSkill(ref a, 33); break;
                    case 4: UseSkill(ref a, 478); break;
                }
            }
        }

        private static void NKEPaleRiderAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277) && nbMainProcess.nbGetMainProcessData().enemypcnt == 1)
                UseSkill(ref a, 277);
            int randomValue = random.Next(5);
            switch (randomValue)
            {
                case 0: UseNormalAttack(ref a); break;
                case 1: UseSkill(ref a, 79); break;
                case 2: UseSkill(ref a, 63); break;
                case 3: UseSkill(ref a, 102); break;
                case 4: UseSkill(ref a, 451); break;
            }
        }

        private static void NKEWhiteRiderAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(277))
                UseSkill(ref a, 277);
            else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(229))
            {
                UseSummonSkill(ref a, 229, 197); return;
            }
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277) && nbMainProcess.nbGetMainProcessData().enemypcnt == 1)
                UseSkill(ref a, 277);
            else if (AllyPartyBuffed(1) && random.Next(3) == 0)
                UseSkill(ref a, 57);
            else
            {
                if (AllyPartyAllImmuneToAttr(287, 6))
                {
                    int randomValue = random.Next(2);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 178); break;
                        case 2: UseSkill(ref a, 135); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 178); break;
                        case 2: UseSkill(ref a, 135); break;
                        case 3: UseSkill(ref a, 287); break;
                    }
                }
            }
        }

        private static void NKERedRiderAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(229))
            {
                UseSummonSkill(ref a, 229, 198); return;
            }
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277) && nbMainProcess.nbGetMainProcessData().enemypcnt == 1)
                UseSkill(ref a, 277);
            else if (EnemyPartyDebuffed(3) && random.Next(3) == 0)
                UseSkill(ref a, 77);
            else
            {
                if (AllyPartyTetrakarn())
                {
                    int randomValue = random.Next(2);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 183); break;
                        case 1: UseSkill(ref a, 186); break;
                    }
                }
                else if (AllyPartyMakarakarn())
                {
                    int randomValue = random.Next(2);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 280); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 280); break;
                        case 2: UseSkill(ref a, 183); break;
                        case 3: UseSkill(ref a, 186); break;
                    }
                }
            }
        }

        private static void NKEBlackRiderAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(229))
            {
                UseSummonSkill(ref a, 229, 195); return;
            }
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277) && nbMainProcess.nbGetMainProcessData().enemypcnt == 1)
                UseSkill(ref a, 277);
            else if (AllyPartyBuffed(1) && random.Next(3) == 0)
                UseSkill(ref a, 57);
            else
            {
                int randomValue = random.Next(3);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 261); break;
                    case 2: UseSkill(ref a, 181); break;
                }
            }
        }

        private static void NKEMatadorAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277))
            {
                UseSkill(ref a, 277); return;
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
            {
                UseSkill(ref a, 276); return;
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 3)
            {
                UseSkill(ref a, 275); return;
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 4)
            {
                UseSkill(ref a, 224); return;
            }
            else if (EnemyPartyDebuffed(1) && random.Next(3) == 0)
            {
                UseSkill(ref a, 77); return;
            }
            else if (!EnemyPartyBuffed(3, 8) && random.Next(3) == 0)
            {
                UseSkill(ref a, 276); return;
            }
            else
            {
                if (EnemyFocused(ref a))
                {
                    int randomValue = random.Next(2);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 443); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 443); break;
                        case 2: UseSkill(ref a, 275); break;
                        case 3: UseSkill(ref a, 224); break;
                    }
                }
            }
        }

        private static void NKEHellBikerAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277))
            {
                UseSkill(ref a, 277); return;
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
            {
                UseSkill(ref a, 282); return;
            }
            else
            {
                if (actionTrackers[a.work.id].currentTurnActionCount >= 4 && EnemyPartyDebuffed(1) && random.Next(4) == 0)
                {
                    UseSkill(ref a, 77);
                }
                else if (!EnemyPartyBuffed(3, 4) && !EnemyPartyBuffed(3, 6) && random.Next(2 + Convert.ToInt32(actionTrackers[a.work.id].skillsUsedThisTurn.Contains(284))) == 0)
                {
                    UseSkill(ref a, 284);
                }
                else
                {
                    int randomValue = random.Next(5);
                    switch (randomValue)
                    {
                        case 0: HellBikerAttackPattern(ref a); break;
                        case 1: HellBikerAttackPattern(ref a); break;
                        case 2: HellBikerAttackPattern(ref a); break;
                        case 3: UseSkill(ref a, 282); break;
                        case 4: UseSkill(ref a, 283); break;
                    }
                }
            }
        }

        private static void NKEDaisoujouAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277))
            {
                UseSkill(ref a, 277); return;
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
            {
                UseSkill(ref a, 30); return;
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 3)
            {
                UseSkill(ref a, 34); return;
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 4)
            {
                UseSkill(ref a, 67); return;
            }
            else if (AllyPartyBuffed(1) && random.Next(4) == 0)
            {
                UseSkill(ref a, 57);
            }
            else
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 279); break;
                    case 2: UseSkill(ref a, 278); break;
                    case 3: UseSkill(ref a, 30); break;
                    case 4: UseSkill(ref a, 34); break;
                }
            }
        }

        private static void NKEMotherHarlotAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277))
            {
                UseSkill(ref a, 277); return;
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
            {
                UseSkill(ref a, 18); return;
            }
            else if (EnemyPartyDebuffed(1) && random.Next(3) == 0)
            {
                UseSkill(ref a, 77);
            }
            else
            {
                if (EnemyFocused(ref a))
                {
                    int randomValue = random.Next(6);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 285); break;
                        case 2: UseSkill(ref a, 286); break;
                        case 3: UseSkill(ref a, 18); break;
                        case 4: UseSkill(ref a, 183); break;
                        case 5: UseSkill(ref a, 205); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(8);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 285); break;
                        case 2: UseSkill(ref a, 286); break;
                        case 3: UseSkill(ref a, 18); break;
                        case 4: UseSkill(ref a, 183); break;
                        case 5: UseSkill(ref a, 205); break;
                        case 6: UseSkill(ref a, 224); break;
                        case 7: UseSkill(ref a, 224); break;
                    }
                }
            }
        }

        private static void NKETrumpeterAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if ((actionTrackers[a.work.id].currentBattleActionCount % 8) == 0)
            {
                UseSkill(ref a, 158); return;
            }
            else if (AllyPartyBuffed(1) && (actionTrackers[a.work.id].currentBattleActionCount % 4) == 0)
            {
                UseSkill(ref a, 57); return;
            }
            else if (a.data.enemypcnt >= 3 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(69))
            {
                UseSkill(ref a, 69); return;
            }
            else if (a.data.enemypcnt >= 3 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(70))
            {
                UseSkill(ref a, 70); return;
            }
            else if (actionTrackers[a.work.id].currentBattleTurnCount == 1)
            {
                UseNormalAttack(ref a); return;
            }
            else
            {
                int randomValue = random.Next(6);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseNormalAttack(ref a); break;
                    case 2: UseSkill(ref a, 6); break;
                    case 3: UseSkill(ref a, 12); break;
                    case 4: UseSkill(ref a, 18); break;
                    case 5: UseSkill(ref a, 24); break;
                }
            }
        }

        private static void NKEBeelzebubManAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
            {
                UseSkill(ref a, 219);
            }
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(77) && EnemyPartyDebuffed(1))
            {
                UseSkill(ref a, 77);
            }
            else
            {
                int randomValue = random.Next(4);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 429); break;
                    case 1: UseSkill(ref a, 18); break;
                    case 2: UseSkill(ref a, 24); break;
                    case 3: UseSkill(ref a, 27); break;
                }
            }
        }

        private static void TamLinAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
            {
                UseSkill(ref a, 219);
            }
            else
            {
                int randomValue = random.Next(6);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 103); break;
                    case 2: UseSkill(ref a, 182); break;
                    case 3: UseSkill(ref a, 30); break;
                    case 4: UseSkill(ref a, 64); break;
                    case 5: UseSkill(ref a, 205); break;
                }
            }
        }

        private static void DoppelgangerAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
            {
                UseSkill(ref a, 219);
            }
            else
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseNormalAttack(ref a); break;
                    case 2: UseNormalAttack(ref a); break;
                    case 3: UseSkill(ref a, 63); break;
                    case 4: UseSkill(ref a, 196); break;
                }
            }
        }

        private static void VritraAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277))
            {
                UseSkill(ref a, 277);
            }
            else
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 121); break;
                    case 1: UseSkill(ref a, 183); break;
                    case 2: UseSkill(ref a, 15); break;
                    case 3: UseSkill(ref a, 451); break;
                    case 4: UseSkill(ref a, 54); break;
                }
            }
        }

        private static void DemeeHoAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(277))
            {
                UseSkill(ref a, 277);
            }
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(459) && !EnemyPartyBuffed(2) && a.work.mp > 0)
            {
                UseSkill(ref a, 459);
            }
            else
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 126); break;
                    case 2: UseSkill(ref a, 481); break;
                    case 3: UseSkill(ref a, 12); break;
                    case 4: UseSkill(ref a, 35); break;
                }
            }
        }

        private static void TripleReasonAhrimanAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Ahriman HP%: " + currentHpPercent);
            //MelonLogger.Msg("Ahriman HP: " + a.work.hp);

            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(460) && EnemyPartyDebuffed(1) &&
                (a.data.playerpcnt == 1 && (actionTrackers[a.work.id].currentBattleTurnCount % 4) == 0) || (a.data.playerpcnt > 1 && (actionTrackers[a.work.id].currentBattleTurnCount % 3) == 0) &&
                actionTrackers[a.work.id].currentTurnActionCount >= 2 && a.data.press4_p <= 1 && a.data.press4_ten <= 1
                && random.Next(4) != 0)
            {
                UseSkill(ref a, 460);
            }
            else if (actionTrackers[a.work.id].currentBattleTurnCount == 1 ||
                actionTrackers[a.work.id].skillsUsedThisTurn.Contains(27) ||
                actionTrackers[a.work.id].skillsUsedThisTurn.Contains(168) ||
                actionTrackers[a.work.id].skillsUsedThisTurn.Contains(253))
            {
                UseSkill(ref a, 174);
            }
            else
            {
                int randomValue = random.Next(12);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 174); break;
                    case 1: UseSkill(ref a, 174); break;
                    case 2: UseSkill(ref a, 174); break;
                    case 3: UseSkill(ref a, 168); break;
                    case 4: UseSkill(ref a, 168); break;
                    case 5: UseSkill(ref a, 168); break;
                    case 6: UseSkill(ref a, 168); break;
                    case 7: UseSkill(ref a, 27); break;
                    case 8: UseSkill(ref a, 27); break;
                    case 9: UseSkill(ref a, 253); break;
                    case 10: UseSkill(ref a, 253); break;
                    case 11: UseSkill(ref a, 253); break;
                }
            }
        }

        private static void TripleReasonBaalAvatarAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Baal Avatar HP%: " + currentHpPercent);
            //MelonLogger.Msg("Baal Avatar HP: " + a.work.hp);

            if (a.data.enemypcnt > 1)
            {
                if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(459) ||
                    (a.data.press4_ten > a.data.press4_p && random.Next(2) == 0 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(459) && !EnemyPartyBuffed(3)))
                    UseSkill(ref a, 459);
                else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(195) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(444))
                {
                    int randomValue = random.Next(2);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 175); break;
                        case 1: UseSkill(ref a, 476); SetTargetingRule(ref code, ref n, 10, n); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 175); break;
                        case 1: UseSkill(ref a, 444); break;
                        case 2: UseSkill(ref a, 195); break;
                        case 3: UseSkill(ref a, 476); SetTargetingRule(ref code, ref n, 10, n); break;
                    }
                }

                if ((a.work.nowindex == 175 && AllyPartyAllImmuneToAttr(175, 0)) ||
                    (a.work.nowindex == 444 && AllyPartyAllImmuneToAttr(444, 4)) ||
                    ((a.work.nowindex == 195 || a.work.nowindex == 476) && AllyPartyAllImmuneToAttr(195, 6)))
                    UseSkill(ref a, 453);
            }
            else
            {
                if (a.data.press4_ten > a.data.press4_p && random.Next(2) == 0 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(458) && !EnemyPartyBuffed(3))
                    UseSkill(ref a, 458);
                else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(195) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(444))
                {
                    int randomValue = random.Next(2);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 175); break;
                        case 2: UseSkill(ref a, 476); SetTargetingRule(ref code, ref n, 10, n); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 175); break;
                        case 2: UseSkill(ref a, 444); break;
                        case 3: UseSkill(ref a, 195); break;
                        case 4: UseSkill(ref a, 476); SetTargetingRule(ref code, ref n, 10, n); break;
                    }
                }

                if ((a.work.nowindex == 175 && AllyPartyAllImmuneToAttr(175, 0)) ||
                    (a.work.nowindex == 444 && AllyPartyAllImmuneToAttr(444, 4)) ||
                    ((a.work.nowindex == 195 || a.work.nowindex == 476) && AllyPartyAllImmuneToAttr(195, 6)))
                    UseSkill(ref a, 453);
            }
        }
        
        private static void TripleReasonNoahAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Noah HP%: " + currentHpPercent);
            //MelonLogger.Msg("Noah HP: " + a.work.hp);

            if (actionTrackers[a.work.id].currentTurnActionCount == 1 && (actionTrackers[a.work.id].currentBattleTurnCount % 2) == 0 &&
                (AllyPartyBuffed(1) || EnemyPartyDebuffed(1)))
            {
                if (AllyPartyBuffed(1) && !EnemyPartyDebuffed(1))
                {
                    UseSkill(ref a, 57); return;
                }
                else if (!AllyPartyBuffed(1) && EnemyPartyDebuffed(1))
                {
                    UseSkill(ref a, 77); return;
                }
                else if (random.Next(2) == 0)
                {
                    UseSkill(ref a, 57); return;
                }
                else
                {
                    UseSkill(ref a, 77); return;
                }
            }
            else if (a.work.nowindex == 170 && actionTrackers[a.work.id].phase == 2
                && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(250) && random.Next(3) == 0)
                UseSkill(ref a, 250);
            else
                switch (auroraValue)
                {
                    case 0: UseSkill(ref a, 170); break;
                    case 248:
                        {
                            int randomValue = random.Next(4);
                            switch (randomValue)
                            {
                                case 0: UseSkill(ref a, 170); break;
                                case 1: UseSkill(ref a, 6); break;
                                case 2: UseSkill(ref a, 6); break;
                                case 3: UseSkill(ref a, 234); break;
                            }
                            break;
                        }
                    case 249:
                        {
                            int randomValue = random.Next(4);
                            switch (randomValue)
                            {
                                case 0: UseSkill(ref a, 170); break;
                                case 1: UseSkill(ref a, 12); break;
                                case 2: UseSkill(ref a, 12); break;
                                case 3: UseSkill(ref a, 234); break;
                            }
                            break;
                        }
                    case 250:
                        {
                            int randomValue = random.Next(4);
                            switch (randomValue)
                            {
                                case 0: UseSkill(ref a, 170); break;
                                case 1: UseSkill(ref a, 18); break;
                                case 2: UseSkill(ref a, 18); break;
                                case 3: UseSkill(ref a, 234); break;
                            }
                            break;
                        }
                    case 251:
                        {
                            int randomValue = random.Next(4);
                            switch (randomValue)
                            {
                                case 0: UseSkill(ref a, 170); break;
                                case 1: UseSkill(ref a, 24); break;
                                case 2: UseSkill(ref a, 24); break;
                                case 3: UseSkill(ref a, 234); break;
                            }
                            break;
                        }
                }

            if ((a.work.nowcommand == 0 && a.work.nowindex == 0) || (a.work.nowcommand == 1 && a.work.nowindex == 2))
                UseSkill(ref a, 170);
        }

        private static void BossSethAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Seth HP%: " + currentHpPercent);
            //MelonLogger.Msg("Seth HP: " + a.work.hp);

            if (currentHpPercent <= 70 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            else if (currentHpPercent <= 40 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;

            if (actionTrackers[a.work.id].phase == 1)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                    UseSkill(ref a, 423);
                else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(490) &&
                    (actionTrackers[a.work.id].currentBattleTurnCount == 1 || (actionTrackers[a.work.id].currentBattleTurnCount - 1) % 3 == 0))
                    UseSkill(ref a, 490);
                else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(432) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(27) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(442) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(462) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(63) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(207) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(451) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(478) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(490))
                {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 122); break;
                        case 1: UseSkill(ref a, 141); break;
                        case 2: UseSkill(ref a, 489); break;
                        case 3: UseSkill(ref a, 489); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(12);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 432); break;
                        case 1: UseSkill(ref a, 27); break;
                        case 2: UseSkill(ref a, 442); break;
                        case 3: UseSkill(ref a, 462); break;
                        case 4: UseSkill(ref a, 63); break;
                        case 5: UseSkill(ref a, 207); break;
                        case 6: UseSkill(ref a, 451); break;
                        case 7: UseSkill(ref a, 478); break;
                        case 8: UseSkill(ref a, 122); break;
                        case 9: UseSkill(ref a, 141); break;
                        case 10: UseSkill(ref a, 489); break;
                        case 11: UseSkill(ref a, 489); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(490) &&
                    (actionTrackers[a.work.id].currentBattleTurnCount - 1) % 3 == 0)
                    UseSkill(ref a, 490);
                else if (random.Next(4) == 0 &&
                    !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(57) &&
                    !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(77))
                {
                    if (AllyPartyBuffed(1) && random.Next(2) == 0)
                    {
                        UseSkill(ref a, 57); return;
                    }
                    else if (EnemyPartyDebuffed(1))
                    {
                        UseSkill(ref a, 77); return;
                    }
                }
                else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(432) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(27) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(442) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(462) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(63) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(207) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(451) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(490))
                {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 122); break;
                        case 1: UseSkill(ref a, 141); break;
                        case 2: UseSkill(ref a, 489); break;
                        case 3: UseSkill(ref a, 489); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(12);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 432); break;
                        case 1: UseSkill(ref a, 27); break;
                        case 2: UseSkill(ref a, 442); break;
                        case 3: UseSkill(ref a, 462); break;
                        case 4: UseSkill(ref a, 63); break;
                        case 5: UseSkill(ref a, 207); break;
                        case 6: UseSkill(ref a, 451); break;
                        case 7: UseSkill(ref a, 478); break;
                        case 8: UseSkill(ref a, 122); break;
                        case 9: UseSkill(ref a, 141); break;
                        case 10: UseSkill(ref a, 489); break;
                        case 11: UseSkill(ref a, 489); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 3)
            {
                if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(490) &&
                    (actionTrackers[a.work.id].currentBattleTurnCount - 1) % 3 == 0)
                    UseSkill(ref a, 490);
                else if (random.Next(4) == 0 &&
                    !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(57) &&
                    !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(77))
                {
                    if (AllyPartyBuffed(1) && random.Next(2) == 0)
                    {
                        UseSkill(ref a, 57); return;
                    }
                    else if (EnemyPartyDebuffed(1))
                    {
                        UseSkill(ref a, 77); return;
                    }
                }
                else if (!AllyPartyDebuffed(3) && random.Next(3 + (Convert.ToInt32(actionTrackers[a.work.id].skillsUsedThisTurn.Contains(206)) * 3)) == 0)
                    UseSkill(ref a, 206);
                else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(432) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(27) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(442) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(462) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(63) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(207) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(451) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(490))
                {
                    UseSkill(ref a, 489);
                }
                else
                {
                    int randomValue = random.Next(10);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 432); break;
                        case 1: UseSkill(ref a, 27); break;
                        case 2: UseSkill(ref a, 442); break;
                        case 3: UseSkill(ref a, 462); break;
                        case 4: UseSkill(ref a, 63); break;
                        case 5: UseSkill(ref a, 207); break;
                        case 6: UseSkill(ref a, 451); break;
                        case 7: UseSkill(ref a, 478); break;
                        case 8: UseSkill(ref a, 489); break;
                        case 9: UseSkill(ref a, 489); break;
                    }
                }
            }
        }

        private static void SargeGirimekhalaAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 422);
            else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(27))
                UseSkill(ref a, 27);
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(77) && EnemyPartyDebuffed(1))
                UseSkill(ref a, 77);
            else
            {
                int randomValue = random.Next(2);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 104); break;
                    case 1: UseSkill(ref a, 27); break;
                    case 2: UseSkill(ref a, 454); break;
                    case 3: UseSkill(ref a, 33); break;
                    case 4: UseSkill(ref a, 35); break;
                    case 5: UseSkill(ref a, 206); break;
                }
            }
        }

        private static void NKEPixieAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
            {
                UseSkill(ref a, 219);
            }
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(77) && EnemyPartyDebuffed(1))
            {
                UseSkill(ref a, 77);
            }
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(459) && !EnemyPartyBuffed(2) && a.work.mp > 0 && random.Next(2) == 0)
            {
                UseSkill(ref a, 459);
            }
            else
            {
                int randomValue = random.Next(2);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 441); break;
                    case 1: UseSkill(ref a, 27); break;
                }
            }
        }

        private static void NKEJackFrostAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 422);
            else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(466))
                UseSkill(ref a, 466);
            else if (BossCurrentHpPercent(ref a) <= 50 && !actionTrackers[a.work.id].skillsUsedThisBattle.Contains(27))
                UseSkill(ref a, 27);
            else if (AllyPartyStatus(2) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
                UseSkill(ref a, 219);
            else if (AllyPartyStatus(2))
            {
                UseNormalAttack(ref a); SetTargetingRule(ref code, ref n, 2, 2);
            }
            else if ((AllyPartyBuffed(2) || EnemyPartyDebuffed(2)) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
                UseSkill(ref a, 219);
            else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219) && AllyPartyBuffed(2))
                UseSkill(ref a, 57);
            else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219) && EnemyPartyDebuffed(2))
                UseSkill(ref a, 77);
            else if (AllyPartyTetrakarn() || AllyPartyMakarakarn())
                UseSkill(ref a, 26);
            else if (!AllyPartyAllImmuneToAttr(466, 2))
                UseSkill(ref a, 466);
            else
            {
                int randomValue = random.Next(3);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 63); break;
                    case 1: UseSkill(ref a, 15); break;
                    case 2: UseSkill(ref a, 21); break;
                }
            }
        }

        private static void BossGameteAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (a.work.mp >= 13)
            {
                if (a.work.mp >= 17 && AllyPartyBuffed(3))
                {
                    UseSkill(ref a, 57);
                }
                else if (a.work.mp >= 72 && nbMainProcess.nbGetMainProcessData().enemyunit.Where(x => x.hp < x.maxhp && x.flag != 0).Any())
                {
                    UseSkill(ref a, 41);
                }
                else
                {
                    int randomValue = random.Next(8);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 119); break;
                        case 2: UseSkill(ref a, 119); break;
                        case 3: UseSkill(ref a, 62); break;
                        case 4: UseSkill(ref a, 56); break;
                        case 5: UseSkill(ref a, 54); break;
                        case 6: UseSkill(ref a, 54); break;
                        case 7: UseSkill(ref a, 54); break;
                    }
                }
            }
            else
            {
                int randomValue = random.Next(4);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 119); break;
                    case 2: UseSkill(ref a, 119); break;
                    case 3: UseSkill(ref a, 62); break;
                }
            }
        }

        private static void YHVHAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("YHVH HP%: " + currentHpPercent);
            //MelonLogger.Msg("YHVH HP: " + a.work.hp);

            if (currentHpPercent <= 90 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            else if (currentHpPercent <= 50 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;

            if (actionTrackers[a.work.id].currentBattleActionCount == 1)
            {
                UseSkill(ref a, 498); return; // Scorn
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
            {
                UseSkill(ref a, 509); return; // Infinite Power
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 3)
            {
                UseSkill(ref a, 498); return; // Scorn
            }
            else
            {
                switch (actionTrackers[a.work.id].phase)
                {
                    case 1:
                        {
                            if (actionTrackers[a.work.id].currentBattleActionCount % 3 == 0)
                            {
                                UseSkill(ref a, 498); return; // Scorn
                            }
                            else if (actionTrackers[a.work.id].currentTurnActionCount == 1 && random.Next(5) == 0)
                            {
                                UseSkill(ref a, 511); return; // Divine Harmony
                            }
                            else if (actionTrackers[a.work.id].currentBattleTurnCount != 2 && a.data.press4_ten == 1 && a.data.press4_p <= 1)
                            {
                                int randomValue = random.Next(4);
                                switch (randomValue)
                                {
                                    case 0: UseSkill(ref a, 509); return; // Infinite Power
                                    case 1: UseSkill(ref a, 510); return; // Unending Curse
                                    default: break;
                                }
                            }

                            int randomValue2 = random.Next(10);
                            switch (randomValue2)
                            {
                                case 0: UseSkill(ref a, 499); break; // Crush
                                case 1: UseSkill(ref a, 499); break; // Crush
                                case 2: UseSkill(ref a, 499); break; // Crush
                                case 3:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(500))
                                            UseSkill(ref a, 500); // Rampage
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 4:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(500))
                                            UseSkill(ref a, 500); // Rampage
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 5:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(500))
                                            UseSkill(ref a, 500); // Rampage
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 6:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(501) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(502) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(503) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(504) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(508))
                                            UseSkill(ref a, 508); // Supernova
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 7:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(501) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(502) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(503) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(504) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(508))
                                            UseSkill(ref a, 508); // Supernova
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 8:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(505) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(506))
                                            UseSkill(ref a, 505); // Planned Chaos
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 9:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(505) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(506) && a.data.playerpcnt > 1)
                                        {
                                            UseSkill(ref a, 506); // Mouth of God
                                            SetTargetingRule(ref code, ref n, 10, n);
                                        }
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                            }

                            break;
                        }
                    case 2:
                        {
                            if (actionTrackers[a.work.id].currentTurnActionCount == 1 && random.Next(5) == 0)
                            {
                                UseSkill(ref a, 511); return; // Divine Harmony
                            }
                            else if (actionTrackers[a.work.id].currentBattleTurnCount != 2 && a.data.press4_ten == 1 && a.data.press4_p <= 1)
                            {
                                int randomValue = random.Next(4);
                                switch (randomValue)
                                {
                                    case 0: UseSkill(ref a, 509); return; // Infinite Power
                                    case 1: UseSkill(ref a, 510); return; // Unending Curse
                                    default: break;
                                }
                            }

                            int randomValue2 = random.Next(10);
                            switch (randomValue2)
                            {
                                case 0: UseSkill(ref a, 499); break; // Crush
                                case 1: UseSkill(ref a, 499); break; // Crush
                                case 2:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(500))
                                            UseSkill(ref a, 500); // Rampage
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 3:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(500))
                                            UseSkill(ref a, 500); // Rampage
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 4:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(501) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(502) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(503) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(504) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(508))
                                            YHVHElement(ref a); // X of God
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 5:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(501) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(502) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(503) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(504) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(508))
                                            YHVHElement(ref a); // X of God
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 6:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(501) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(502) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(503) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(504) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(508))
                                            UseSkill(ref a, 508); // Supernova
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 7:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(501) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(502) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(503) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(504) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(508))
                                            UseSkill(ref a, 508); // Supernova
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 8:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(505) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(506))
                                            UseSkill(ref a, 505); // Planned Chaos
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 9:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(505) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(506) && a.data.playerpcnt > 1)
                                        {
                                            UseSkill(ref a, 506); // Mouth of God
                                            SetTargetingRule(ref code, ref n, 10, n);
                                        }
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                            }

                            break;
                        }
                    case 3:
                        {
                            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(507))
                            {
                                UseSkill(ref a, 507); return; // Black Hole
                            }
                            else if (actionTrackers[a.work.id].currentTurnActionCount == 1 && random.Next(5) == 0)
                            {
                                UseSkill(ref a, 511); return; // Divine Harmony
                            }
                            else if (actionTrackers[a.work.id].currentBattleTurnCount != 2 && a.data.press4_ten == 1 && a.data.press4_p <= 1)
                            {
                                int randomValue = random.Next(4);
                                switch (randomValue)
                                {
                                    case 0: UseSkill(ref a, 509); return; // Infinite Power
                                    case 1: UseSkill(ref a, 510); return; // Unending Curse
                                    default: break;
                                }
                            }

                            int randomValue2 = random.Next(10);
                            switch (randomValue2)
                            {
                                case 0: UseSkill(ref a, 499); break; // Crush
                                case 1:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(500))
                                            UseSkill(ref a, 500); // Rampage
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 2:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(507))
                                            UseSkill(ref a, 507); // Black Hole
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 3:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(500))
                                            UseSkill(ref a, 500); // Rampage
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 4:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(501) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(502) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(503) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(504) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(508))
                                            YHVHElement(ref a); // X of God
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 5:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(501) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(502) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(503) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(504) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(508))
                                            YHVHElement(ref a); // X of God
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 6:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(501) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(502) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(503) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(504) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(508))
                                            UseSkill(ref a, 508); // Supernova
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 7:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(501) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(502) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(503) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(504) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(508))
                                            UseSkill(ref a, 508); // Supernova
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 8:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(505) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(506))
                                            UseSkill(ref a, 505); // Planned Chaos
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                                case 9:
                                    {
                                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(505) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(506) && a.data.playerpcnt > 1)
                                        {
                                            UseSkill(ref a, 506); // Mouth of God
                                            SetTargetingRule(ref code, ref n, 10, n);
                                        }
                                        else
                                            UseSkill(ref a, 499); // Crush
                                    }
                                    break;
                            }

                            break;
                        }
                }
            }
        }

        private static void YHVHElement(ref nbActionProcessData_t a)
        {
            int randomValue = random.Next(4);
            switch (randomValue)
            {
                case 0: UseSkill(ref a, 501); break;
                case 1: UseSkill(ref a, 502); break;
                case 2: UseSkill(ref a, 503); break;
                case 3: UseSkill(ref a, 504); break;
            }
        }

        private static void BossForneusAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Forneus HP%: " + currentHpPercent);
            //MelonLogger.Msg("Forneus HP: " + a.work.hp);

            if (currentHpPercent <= 60 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            else if (currentHpPercent <= 20 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;

            if (actionTrackers[a.work.id].extraTurns < 1)
            {
                UseSkill(ref a, 422); return;
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
            {
                UseSkill(ref a, 7);
                SetTargetingRule(ref code, ref n, 6, n);
                return;
            }
            
            if (actionTrackers[a.work.id].phase == 1)
            {
                int randomValue = random.Next(2);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 7); break;
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(10))
                    UseSkill(ref a, 10);
                else
                {
                    int randomValue = random.Next(2);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 7); break;
                    }
                }
            }
            else
            {
                if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(244))
                    UseSkill(ref a, 244);
                else
                {
                    int randomValue = random.Next(2);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 7); break;
                    }
                }
            }
        }

        private static void BossSpecter1AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleTurnCount != 1 && a.work.nowindex != 232)
            {
                if ((a.work.hp * 100 / a.work.maxhp) <= 25)
                    UseSkill(ref a, 51);
                else
                {
                    var skills = new List<ushort>();

                    if (!EnemyPartyBuffed(3, 7))
                        skills.Add(66);
                    if (!AllyPartyDebuffed(3, 4) || !AllyPartyDebuffed(3, 5))
                        skills.Add(52);

                    if (skills.Count == 0)
                        skills.Add(192);

                    int randomValue = random.Next(skills.Count);
                    UseSkill(ref a, skills[randomValue]);
                }
            }
        }

        private static void ForcedKoppaTenguAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleActionCount <= 4)
            {
                UseSummonSkill(ref a, 226, 261);
            }
        }

        private static void ForcedKaiwanAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            int randomValue = random.Next(5);
            switch (randomValue)
            {
                case 0: UseNormalAttack(ref a); break;
                case 1: UseSkill(ref a, 446); break;
                case 2: UseSkill(ref a, 447); break;
                case 3: UseSkill(ref a, 190); break;
                case 4: UseSkill(ref a, 199); break;
            }
        }

        private static void BossOseAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleActionCount == 1)
            {
                UseSkill(ref a, 423); return;
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
            {
                UseSkill(ref a, (ushort) (69 + random.Next(2))); return;
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 3)
            {
                UseSkill(ref a, 224); return;
            }
            else if (actionTrackers[a.work.id].currentTurnActionCount == 1 && !AllyPartyBuffed(2) && !EnemyPartyDebuffed(2))
            {
                UseSkill(ref a, (ushort)(69 + random.Next(2))); return;
            }
            else if (actionTrackers[a.work.id].currentTurnActionCount == 1)
            {
                if (AllyPartyBuffed(2))
                {
                    UseSkill(ref a, 57); return;
                }
                else
                {
                    UseSkill(ref a, 77); return;
                }
            }
            else
            {
                if (EnemyFocused(ref a))
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseNormalAttack(ref a); break;
                        case 2: UseSkill(ref a, 65); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 65); break;
                        case 2: UseSkill(ref a, 102); break;
                        case 3: UseSkill(ref a, 224); break;
                    }
                }
            }
        }

        private static void BossKinKiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Kin-Ki HP%: " + currentHpPercent);
            //MelonLogger.Msg("Kin-Ki HP: " + a.work.hp);

            if (currentHpPercent <= 40 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;

            if (actionTrackers[a.work.id].phase == 1 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
            {
                UseSkill(ref a, 219); return;
            }
            else if (actionTrackers[a.work.id].phase == 2 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
            {
                UseSkill(ref a, 220); return;
            }
            else if (EnemyPartyDebuffed(1) && random.Next(4) == 0)
            {
                UseSkill(ref a, 77); return;
            }
            else
            {
                int randomValue = random.Next(7);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 52); break;
                    case 2: UseSkill(ref a, 54); break;
                    case 3: UseSkill(ref a, 64); break;
                    case 4: UseSkill(ref a, 66); break;
                    case 5: UseSkill(ref a, 97); break;
                    case 6: UseSkill(ref a, 99); break;
                }
            }
        }

        private static void BossSuiKiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Sui-Ki HP%: " + currentHpPercent);
            //MelonLogger.Msg("Sui-Ki HP: " + a.work.hp);

            if (currentHpPercent <= 50 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;

            if (actionTrackers[a.work.id].phase == 1 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
            {
                UseSkill(ref a, 219); return;
            }
            else if (actionTrackers[a.work.id].phase == 2 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
            {
                UseSkill(ref a, 220); return;
            }
            else if (AllyPartyStatus(2))
            {
                UseSkill(ref a, 97); SetTargetingRule(ref code, ref n, 2, 2); return;
            }
            else if (AllyPartyBuffed(1) && random.Next(4) == 0)
            {
                UseSkill(ref a, 57); return;
            }
            else
            {
                int randomValue = random.Next(6);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 9); break;
                    case 1: UseSkill(ref a, 181); break;
                    case 2: UseSkill(ref a, 97); break;
                    case 3: UseSkill(ref a, 98); break;
                    case 4: UseSkill(ref a, 199); break;
                    case 5: UseSkill(ref a, 67); break;
                }
            }
        }

        private static void BossFuuKiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Fuu-Ki HP%: " + currentHpPercent);
            //MelonLogger.Msg("Fuu-Ki HP: " + a.work.hp);

            if (currentHpPercent <= 50 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;

            if (actionTrackers[a.work.id].phase == 1 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
            {
                UseSkill(ref a, 219); return;
            }
            else if (actionTrackers[a.work.id].phase == 2 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
            {
                UseSkill(ref a, 220); return;
            }
            else if (AllyPartyBuffed(1) && random.Next(4) == 0)
            {
                UseSkill(ref a, 57); return;
            }
            else
            {
                int randomValue = random.Next(6);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 21); break;
                    case 1: UseSkill(ref a, 185); break;
                    case 2: UseSkill(ref a, 97); break;
                    case 3: UseSkill(ref a, 110); break;
                    case 4: UseSkill(ref a, 216); break;
                    case 5: UseSkill(ref a, 67); break;
                }
            }
        }

        private static void BossOngyoKiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Ongyo-Ki HP%: " + currentHpPercent);
            //MelonLogger.Msg("Ongyo-Ki HP: " + a.work.hp);

            if (a.work.nowindex == 64)
                UseSkill(ref a, 206);
            else if (a.work.nowindex == 65)
                UseSkill(ref a, 25);
            else if (a.work.nowindex == 2)
                UseSkill(ref a, 105);
        }

        private static void BossClotho1AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(422))
                UseSkill(ref a, 422);
            else if (EnemyPartyDebuffed(1) && (actionTrackers[a.work.id].currentBattleTurnCount % 4) == 0)
                UseSkill(ref a, 77);
            else if (a.work.hp < a.work.maxhp && currentHpPercent > 1 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(37))
            {
                int randomValue = random.Next(9);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                    case 1: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                    case 2: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                    case 3: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                    case 4: UseSkill(ref a, 29); break;
                    case 5: UseSkill(ref a, 31); break;
                    case 6: UseSkill(ref a, 62); break;
                    case 7: UseSkill(ref a, 215); break;
                    case 8: UseNormalAttack(ref a); break;
                }
            }
            else if (currentHpPercent > 1)
            {
                int randomValue = random.Next(9);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 29); break;
                    case 1: UseSkill(ref a, 29); break;
                    case 2: UseSkill(ref a, 31); break;
                    case 3: UseSkill(ref a, 31); break;
                    case 4: UseSkill(ref a, 62); break;
                    case 5: UseSkill(ref a, 62); break;
                    case 6: UseSkill(ref a, 215); break;
                    case 7: UseSkill(ref a, 215); break;
                    case 8: UseNormalAttack(ref a); break;
                }
            }
        }

        private static void BossLachesis1AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(422))
                UseSkill(ref a, 422);
            else if (currentHpPercent > 1 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(206) && (actionTrackers[a.work.id].currentBattleTurnCount % 4) == 0)
            {
                UseSkill(ref a, 206); return;
            }
            else if (currentHpPercent > 1 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(69) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(70) && random.Next(2) == 0)
            {
                UseSkill(ref a, (ushort)(69 + random.Next(2))); return;
            }
            else if (currentHpPercent > 1)
            {
                int randomValue = random.Next(7);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseNormalAttack(ref a); break;
                    case 2: UseNormalAttack(ref a); break;
                    case 3: UseSkill(ref a, 52); break;
                    case 4: UseSkill(ref a, 54); break;
                    case 5: UseSkill(ref a, 64); break;
                    case 6: UseSkill(ref a, 66); break;
                }
            }
        }

        private static void BossAtropos1AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(422))
                UseSkill(ref a, 422);
            else if (currentHpPercent > 1 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(25) && (actionTrackers[a.work.id].currentBattleTurnCount % 4) == 0)
            {
                UseSkill(ref a, 25); return;
            }
            else if (currentHpPercent > 1)
            {
                int randomValue = random.Next(8);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 2); break;
                    case 1: UseSkill(ref a, 5); break;
                    case 2: UseSkill(ref a, 8); break;
                    case 3: UseSkill(ref a, 11); break;
                    case 4: UseSkill(ref a, 14); break;
                    case 5: UseSkill(ref a, 17); break;
                    case 6: UseSkill(ref a, 20); break;
                    case 7: UseSkill(ref a, 23); break;
                }
            }
        }

        private static void BossGirimekhalaAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (currentHpPercent <= 50 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;

            if (actionTrackers[a.work.id].extraTurns < 1)
            {
                UseSkill(ref a, 423); return;
            }
            else if (actionTrackers[a.work.id].currentBattleTurnCount == 1)
                UseNormalAttack(ref a);
            else if (AllyPartyBuffed(1) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
                UseSkill(ref a, 219);
            else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(57))
                UseSkill(ref a, 57);
            else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(206))
                UseSkill(ref a, 206);
            else if (actionTrackers[a.work.id].phase == 1)
            {
                int randomValue = random.Next(4);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 211); break;
                    case 2: UseSkill(ref a, 102); break;
                    case 3: UseSkill(ref a, 110); break;
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                int randomValue = random.Next(6);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 211); break;
                    case 2: UseSkill(ref a, 102); break;
                    case 3: UseSkill(ref a, 105); break;
                    case 4: UseSkill(ref a, 207); break;
                    case 5: UseSkill(ref a, 450); break;
                }
            }
        }

        private static void BossSpecter3AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (a.work.nowindex == 226)
                UseNormalAttack(ref a);

        }

        private static void BossAcielAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Aciel HP%: " + currentHpPercent);
            //MelonLogger.Msg("Aciel HP: " + a.work.hp);

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 423);
            else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(423))
                UseSkill(ref a, 100);
            else if (a.work.nowindex == 220)
                UseSkill(ref a, 219);
            else if (a.work.nowindex == 208)
            {
                if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(191))
                {
                    int randomValue = random.Next(5);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 122); break;
                        case 2: UseSkill(ref a, 122); break;
                        case 3: UseSkill(ref a, 100); break;
                        case 4: UseSkill(ref a, 100); break;
                    }
                }
                else
                    UseSkill(ref a, 208);
            }
            else if (a.work.nowindex == 191)
                UseSkill(ref a, 191);
            else if (a.work.nowindex != 220 && a.work.nowindex != 208 && a.work.nowindex != 191 && a.work.nowindex != 77 && a.work.nowindex != 57)
            {
                if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(208))
                    UseNormalAttack(ref a);
                else
                {
                    int randomValue = random.Next(5);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 122); break;
                        case 2: UseSkill(ref a, 122); break;
                        case 3: UseSkill(ref a, 100); break;
                        case 4: UseSkill(ref a, 100); break;
                    }
                }
            }
        }

        private static void BossSkadiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Skadi HP%: " + currentHpPercent);
            //MelonLogger.Msg("Skadi HP: " + a.work.hp);

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 423);
            else if (a.work.nowindex == 220)
                UseSkill(ref a, 219);
            else if (a.work.nowindex == 24)
                UseSkill(ref a, 468);
            else if (a.work.nowindex == 64 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(77) && EnemyPartyDebuffed(1))
                UseSkill(ref a, 77);
        }

        private static void BossUrthonaAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if ((a.work.nowindex == 15 || a.work.nowindex == 18) && random.Next(3) == 0)
                UseSkill(ref a, 440);
        }

        private static void BossUrizenAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if ((a.work.nowindex == 3 || a.work.nowindex == 6) && random.Next(3) == 0)
                UseSkill(ref a, 435);
        }

        private static void BossLuvahAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if ((a.work.nowindex == 21 || a.work.nowindex == 24) && random.Next(3) == 0)
                UseSkill(ref a, 443);
        }

        private static void BossTharmusAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if ((a.work.nowindex == 9 || a.work.nowindex == 12) && random.Next(3) == 0)
                UseSkill(ref a, 437);
        }

        private static void BossFutomimiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 422);
            else if (actionTrackers[a.work.id].currentBattleActionCount <= 2)
            {
                UseSummonSkill(ref a, 252, 162); return;
            }
            else if (currentHpPercent <= 15 && a.data.enemypcnt > 1)
                UseSkill(ref a, 51);
            else
            {
                if (EnemyFocused(ref a))
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 430); break;
                        case 1: UseSkill(ref a, 433); break;
                        case 2: UseSkill(ref a, 203); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(5);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 427); break;
                        case 1: UseSkill(ref a, 430); break;
                        case 2: UseSkill(ref a, 203); break;
                        case 3: UseSkill(ref a, 224); break;
                        case 4: UseSkill(ref a, 224); break;
                    }
                }
            }
        }

        private static void BossManikinAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (a.data.enemyunit.Where(x => x.id == 283 && (x.hp == 0 || x.flag == 0)).Any())
                Flee(ref a);
            else if (a.data.enemypcnt < 5)
                UseSummonSkill(ref a, 226, (ushort)(162 + random.Next(4)));
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(57) && EnemyPartyDebuffed(1) && random.Next(5) == 0)
                UseSkill(ref a, 77);
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(77) && AllyPartyBuffed(1) && random.Next(5) == 0)
                UseSkill(ref a, 57);
            else
            {
                int randomValue = random.Next(9);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 2); break;
                    case 1: UseSkill(ref a, 8); break;
                    case 2: UseSkill(ref a, 14); break;
                    case 3: UseSkill(ref a, 20); break;
                    case 4: UseSkill(ref a, 30); break;
                    case 5: UseSkill(ref a, 34); break;
                    case 6: UseSkill(ref a, 128); break;
                    case 7: UseSkill(ref a, 211); break;
                    case 8: UseSkill(ref a, 216); break;
                }
            }
        }

        private static void BossGabrielAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (a.data.enemyunit.Where(x => x.id != 284 && x.hp < x.maxhp && x.flag != 0).Any() && random.Next(2) == 0)
                UseSkill(ref a, 38);
            else
            {
                int randomValue = random.Next(3);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 426); break;
                    case 1: UseSkill(ref a, 12); break;
                    case 2: UseSkill(ref a, 195); break;
                }
            }
        }

        private static void BossRaphaelAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (a.work.nowindex != 69 && a.work.nowindex != 70)
            {
                int randomValue = random.Next(3);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 106); break;
                    case 1: UseSkill(ref a, 462); break;
                    case 2: UseSkill(ref a, 189); break;
                }
            }
        }

        private static void BossUrielAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(57) && EnemyPartyDebuffed(2) && random.Next(2) == 0)
                UseSkill(ref a, 77);
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(77) && AllyPartyBuffed(2) && random.Next(2) == 0)
                UseSkill(ref a, 57);
            else
            {
                int randomValue = random.Next(3);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 431); break;
                    case 1: UseSkill(ref a, 179); break;
                    case 2: UseSkill(ref a, 476); break;
                }
            }
        }

        private static void BossSamaelAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 423);
            else if (a.work.nowindex == 6)
                UseSkill(ref a, 178);
            else if (a.work.nowindex == 26 && random.Next(2) == 0)
                UseSkill(ref a, 432);
            else if (a.work.nowindex == 57 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(57))
                UseSkill(ref a, 57);
            else if (a.work.nowindex == 57 && actionTrackers[a.work.id].skillsUsedThisTurn.Contains(57))
                UseSkill(ref a, 432);
        }

        private static void BossBaalAvatarAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Baal Avatar HP%: " + currentHpPercent);
            //MelonLogger.Msg("Baal Avatar HP: " + a.work.hp);

            if (currentHpPercent <= 50 && actionTrackers[a.work.id].phase == 1)
            {
                actionTrackers[a.work.id].phase = 2;
                actionTrackers[a.work.id].skillsUsedThisBattle.Clear();
            }
                

            if (actionTrackers[a.work.id].currentBattleActionCount == 1 && a.data.playerpcnt == 4)
                UseSkill(ref a, 277);
            else if (AllyPartyStatus(0))
            {
                UseSkill(ref a, 201);
                SetTargetingRule(ref code, ref n, 2, 0);
            }
            else
            {
                if (actionTrackers[a.work.id].phase == 1)
                {
                    if (a.data.press4_ten > a.data.press4_p && random.Next(2) == 0 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(459) && !EnemyPartyBuffed(3))
                        UseSkill(ref a, 459);
                    else if (actionTrackers[a.work.id].currentBattleTurnCount != 1 && !actionTrackers[a.work.id].skillsUsedThisBattle.Contains(476))
                        UseSkill(ref a, 476);
                    else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(195) ||
                        actionTrackers[a.work.id].skillsUsedThisTurn.Contains(444))
                    {
                        int randomValue = random.Next(2);
                        switch (randomValue)
                        {
                            case 0: UseSkill(ref a, 175); break;
                            case 1: UseSkill(ref a, 476); SetTargetingRule(ref code, ref n, 10, n); break;
                        }
                    }
                    else
                    {
                        int randomValue = random.Next(4);
                        switch (randomValue)
                        {
                            case 0: UseSkill(ref a, 175); break;
                            case 1: UseSkill(ref a, 444); break;
                            case 2: UseSkill(ref a, 195); break;
                            case 3: UseSkill(ref a, 476); SetTargetingRule(ref code, ref n, 10, n); break;
                        }
                    }
                }
                else if (actionTrackers[a.work.id].phase == 2)
                {
                    if (a.data.enemypcnt > 1)
                    {
                        if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(459) ||
                            (a.data.press4_ten > a.data.press4_p && random.Next(2) == 0 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(459) && !EnemyPartyBuffed(3)))
                            UseSkill(ref a, 459);
                        else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(195) ||
                            actionTrackers[a.work.id].skillsUsedThisTurn.Contains(444))
                        {
                            int randomValue = random.Next(2);
                            switch (randomValue)
                            {
                                case 0: UseSkill(ref a, 175); break;
                                case 1: UseSkill(ref a, 476); SetTargetingRule(ref code, ref n, 10, n); break;
                            }
                        }
                        else
                        {
                            int randomValue = random.Next(4);
                            switch (randomValue)
                            {
                                case 0: UseSkill(ref a, 175); break;
                                case 1: UseSkill(ref a, 444); break;
                                case 2: UseSkill(ref a, 195); break;
                                case 3: UseSkill(ref a, 476); SetTargetingRule(ref code, ref n, 10, n); break;
                            }
                        }

                        if ((a.work.nowindex == 175 && AllyPartyAllImmuneToAttr(175, 0)) ||
                            (a.work.nowindex == 444 && AllyPartyAllImmuneToAttr(444, 4)) ||
                            ((a.work.nowindex == 195 || a.work.nowindex == 476) && AllyPartyAllImmuneToAttr(195, 6)))
                            UseSkill(ref a, 453);
                    }
                    else
                    {
                        if (a.data.press4_ten > a.data.press4_p && random.Next(2) == 0 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(458) && !EnemyPartyBuffed(3))
                            UseSkill(ref a, 458);
                        else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(195) ||
                            actionTrackers[a.work.id].skillsUsedThisTurn.Contains(444))
                        {
                            int randomValue = random.Next(2);
                            switch (randomValue)
                            {
                                case 0: UseSkill(ref a, 175); break;
                                case 2: UseSkill(ref a, 476); SetTargetingRule(ref code, ref n, 10, n); break;
                            }
                        }
                        else
                        {
                            int randomValue = random.Next(4);
                            switch (randomValue)
                            {
                                case 0: UseSkill(ref a, 175); break;
                                case 2: UseSkill(ref a, 444); break;
                                case 3: UseSkill(ref a, 195); break;
                                case 4: UseSkill(ref a, 476); SetTargetingRule(ref code, ref n, 10, n); break;
                            }
                        }

                        if ((a.work.nowindex == 175 && AllyPartyAllImmuneToAttr(175, 0)) ||
                            (a.work.nowindex == 444 && AllyPartyAllImmuneToAttr(444, 4)) ||
                            ((a.work.nowindex == 195 || a.work.nowindex == 476) && AllyPartyAllImmuneToAttr(195, 6)))
                            UseSkill(ref a, 453);
                    }
                }
            }
        }

        private static void BossOseHallelAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Ose Hallel HP%: " + currentHpPercent);
            //MelonLogger.Msg("Ose Hallel HP: " + a.work.hp);

            if (a.data.enemyunit.Where(x => x.id == 288 && x.hp <= x.maxhp * 0.6f && x.flag != 0).Any())
            {
                UseSkill(ref a, 38); 
                SetTargetingRule(ref code, ref n, 3, 288);
            }
            else if (EnemyPartyDebuffed(1) && random.Next(3) == 0)
                UseSkill(ref a, 77);
            else
            {
                int randomValue = random.Next(4);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 53); break;
                    case 1: UseSkill(ref a, 69); break;
                    case 2: UseSkill(ref a, 110); break;
                    case 3: UseSkill(ref a, 12); break;
                }
            }
        }

        private static void BossFlaurosHallelAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Flauros Hallel HP%: " + currentHpPercent);
            //MelonLogger.Msg("Flauros Hallel HP: " + a.work.hp);

            if (a.data.enemyunit.Where(x => x.id == 288 && x.hp <= x.maxhp * 0.6f && x.flag != 0).Any())
            {
                UseSkill(ref a, 38);
                SetTargetingRule(ref code, ref n, 3, 288);
            }
            else if (AllyPartyBuffed(1) && random.Next(3) == 0)
                UseSkill(ref a, 57);
            else
            {
                int randomValue = random.Next(4);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 52); break;
                    case 1: UseSkill(ref a, 70); break;
                    case 2: UseSkill(ref a, 104); break;
                    case 3: UseSkill(ref a, 6); break;
                }
            }
        }

        private static void BossAhriman2AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Ahriman HP%: " + currentHpPercent);
            //MelonLogger.Msg("Ahriman HP: " + a.work.hp);

            if (currentHpPercent <= 75 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            if (currentHpPercent <= 50 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;
            if (currentHpPercent <= 25 && actionTrackers[a.work.id].phase == 3)
                actionTrackers[a.work.id].phase = 4;


            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(460) && EnemyPartyDebuffed(1) &&
                (a.data.playerpcnt == 1 && (actionTrackers[a.work.id].currentBattleTurnCount % 4) == 0) || (a.data.playerpcnt > 1 && (actionTrackers[a.work.id].currentBattleTurnCount % 3) == 0) &&
                actionTrackers[a.work.id].currentTurnActionCount >= 2 && a.data.press4_p <= 1 && a.data.press4_ten <= 1
                && random.Next(3) != 0)
            {
                UseSkill(ref a, 460);
            }
            else if (actionTrackers[a.work.id].currentBattleTurnCount == 1 ||
                actionTrackers[a.work.id].skillsUsedThisTurn.Contains(27) ||
                actionTrackers[a.work.id].skillsUsedThisTurn.Contains(168) ||
                actionTrackers[a.work.id].skillsUsedThisTurn.Contains(253))
            {
                UseSkill(ref a, 174);
            }
            else
            {
                switch (actionTrackers[a.work.id].phase)
                {
                    case 1:
                        {
                            int randomValue = random.Next(12);
                            switch (randomValue)
                            {
                                case 0: UseSkill(ref a, 174); break;
                                case 1: UseSkill(ref a, 174); break;
                                case 2: UseSkill(ref a, 174); break;
                                case 3: UseSkill(ref a, 174); break;
                                case 4: UseSkill(ref a, 168); break;
                                case 5: UseSkill(ref a, 168); break;
                                case 6: UseSkill(ref a, 168); break;
                                case 7: UseSkill(ref a, 168); break;
                                case 8: UseSkill(ref a, 27); break;
                                case 9: UseSkill(ref a, 27); break;
                                case 10: UseSkill(ref a, 27); break;
                                case 11: UseSkill(ref a, 27); break;
                            }
                            break;
                        }
                    case 2:
                        {
                            int randomValue = random.Next(12);
                            switch (randomValue)
                            {
                                case 0: UseSkill(ref a, 174); break;
                                case 1: UseSkill(ref a, 174); break;
                                case 2: UseSkill(ref a, 174); break;
                                case 3: UseSkill(ref a, 168); break;
                                case 4: UseSkill(ref a, 168); break;
                                case 5: UseSkill(ref a, 168); break;
                                case 6: UseSkill(ref a, 168); break;
                                case 7: UseSkill(ref a, 27); break;
                                case 8: UseSkill(ref a, 27); break;
                                case 9: UseSkill(ref a, 27); break;
                                case 10: UseSkill(ref a, 253); break;
                                case 11: UseSkill(ref a, 253); break;
                            }
                            break;
                        }
                    case 3:
                        {
                            int randomValue = random.Next(12);
                            switch (randomValue)
                            {
                                case 0: UseSkill(ref a, 174); break;
                                case 1: UseSkill(ref a, 174); break;
                                case 2: UseSkill(ref a, 174); break;
                                case 3: UseSkill(ref a, 168); break;
                                case 4: UseSkill(ref a, 168); break;
                                case 5: UseSkill(ref a, 168); break;
                                case 6: UseSkill(ref a, 168); break;
                                case 7: UseSkill(ref a, 27); break;
                                case 8: UseSkill(ref a, 27); break;
                                case 9: UseSkill(ref a, 253); break;
                                case 10: UseSkill(ref a, 253); break;
                                case 11: UseSkill(ref a, 253); break;
                            }
                            break;
                        }
                    case 4:
                        {
                            int randomValue = random.Next(12);
                            switch (randomValue)
                            {
                                case 0: UseSkill(ref a, 174); break;
                                case 1: UseSkill(ref a, 174); break;
                                case 2: UseSkill(ref a, 168); break;
                                case 3: UseSkill(ref a, 168); break;
                                case 4: UseSkill(ref a, 168); break;
                                case 5: UseSkill(ref a, 168); break;
                                case 6: UseSkill(ref a, 253); break;
                                case 7: UseSkill(ref a, 253); break;
                                case 8: UseSkill(ref a, 253); break;
                                case 9: UseSkill(ref a, 253); break;
                                case 10: UseSkill(ref a, 253); break;
                                case 11: UseSkill(ref a, 253); break;
                            }
                            break;
                        }
                }
            }
        }

        private static void BossAhriman1AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Ahriman HP%: " + currentHpPercent);
            //MelonLogger.Msg("Ahriman HP: " + a.work.hp);

            if (a.work.nowindex == 171)
                UseSkill(ref a, 141);
        }

        private static void BossNoah2AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Noah HP%: " + currentHpPercent);
            //MelonLogger.Msg("Noah HP: " + a.work.hp);

            if (currentHpPercent <= 50 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;

            if (actionTrackers[a.work.id].currentTurnActionCount == 1 && (actionTrackers[a.work.id].currentBattleTurnCount % 2) == 0 &&
                (AllyPartyBuffed(1) || EnemyPartyDebuffed(1)))
            {
                if (AllyPartyBuffed(1) && !EnemyPartyDebuffed(1))
                {
                    UseSkill(ref a, 57); return;
                }
                else if (!AllyPartyBuffed(1) && EnemyPartyDebuffed(1))
                {
                    UseSkill(ref a, 77); return;
                }
                else if (random.Next(2) == 0)
                {
                    UseSkill(ref a, 57); return;
                }
                else
                {
                    UseSkill(ref a, 77); return;
                }
            }
            else if (a.work.nowindex == 57 || a.work.nowindex == 77 || (a.work.nowindex == 234 && random.Next(3) != 0 && actionTrackers[a.work.id].currentBattleTurnCount != 1) ||
                (a.work.nowindex == 6 && actionTrackers[a.work.id].skillsUsedThisTurn.Contains(6)) ||
                (a.work.nowindex == 12 && actionTrackers[a.work.id].skillsUsedThisTurn.Contains(12)) ||
                (a.work.nowindex == 18 && actionTrackers[a.work.id].skillsUsedThisTurn.Contains(18)) ||
                (a.work.nowindex == 24 && actionTrackers[a.work.id].skillsUsedThisTurn.Contains(24)) ||
                (a.work.nowindex == 250 && actionTrackers[a.work.id].skillsUsedThisTurn.Contains(250)))
                UseSkill(ref a, 170);
            else if (a.work.nowindex == 170 && actionTrackers[a.work.id].phase == 2 
                && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(250) && random.Next(3) == 0)
                UseSkill(ref a, 250);
            else if (a.work.nowindex == 6)
                UseSkill(ref a, 6);
            else if (a.work.nowindex == 12)
                UseSkill(ref a, 12);
            else if (a.work.nowindex == 18)
                UseSkill(ref a, 18);
            else if (a.work.nowindex == 24)
                UseSkill(ref a, 24);
            else if (a.work.nowindex == 250)
                UseSkill(ref a, 250);
        }

        private static void BossNoah1AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Noah HP%: " + currentHpPercent);
            //MelonLogger.Msg("Noah HP: " + a.work.hp);

            switch (auroraValue)
            {
                case 0: UseSkill(ref a, 169); break;
                case 248:
                    {
                        int randomValue = random.Next(2);
                        switch (randomValue)
                        {
                            case 0: UseSkill(ref a, 169); break;
                            case 1: UseSkill(ref a, 3); break;
                        }
                        break;
                    }
                case 249:
                    {
                        int randomValue = random.Next(2);
                        switch (randomValue)
                        {
                            case 0: UseSkill(ref a, 169); break;
                            case 1: UseSkill(ref a, 9); break;
                        }
                        break;
                    }
                case 250:
                    {
                        int randomValue = random.Next(2);
                        switch (randomValue)
                        {
                            case 0: UseSkill(ref a, 169); break;
                            case 1: UseSkill(ref a, 15); break;
                        }
                        break;
                    }
                case 251:
                    {
                        int randomValue = random.Next(2);
                        switch (randomValue)
                        {
                            case 0: UseSkill(ref a, 169); break;
                            case 1: UseSkill(ref a, 21); break;
                        }
                        break;
                    }
            }
        }

        private static void BossKagutsuchi2AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Kagutsuchi HP%: " + currentHpPercent);
            //MelonLogger.Msg("Kagutsuchi HP: " + a.work.hp);

            if (a.work.nowindex == 221)
                UseSkill(ref a, 221);
            else if (actionTrackers[a.work.id].currentTurnActionCount == 3 && (AllyPartyBuffed(1) || EnemyPartyDebuffed(1)))
            {
                if (AllyPartyBuffed(1) && random.Next(2) == 0)
                {
                    UseSkill(ref a, 57); return;
                }
                else if (EnemyPartyDebuffed(1))
                {
                    UseSkill(ref a, 77); return;
                }
            }
            else if (AllyPartyMakarakarn())
                UseSkill(ref a, 173);
            else
            {
                int randomValue = random.Next(7);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 173); break;
                    case 1: UseSkill(ref a, 173); break;
                    case 2: UseSkill(ref a, 6); break;
                    case 3: UseSkill(ref a, 12); break;
                    case 4: UseSkill(ref a, 18); break;
                    case 5: UseSkill(ref a, 24); break;
                    case 6: UseSkill(ref a, 195); break;
                }
            }
        }

        private static void BossKagutsuchi1AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Kagutsuchi HP%: " + currentHpPercent);
            //MelonLogger.Msg("Kagutsuchi HP: " + a.work.hp);

            if (a.work.nowindex == 241)
                UseSkill(ref a, 241);
            else if (random.Next(3 * (1 + Convert.ToInt32(actionTrackers[a.work.id].skillsUsedThisTurn.Contains(254)))) == 0 && !EnemyPartyBuffed(3))
                UseSkill(ref a, 254);
            else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(6) ||
                actionTrackers[a.work.id].skillsUsedThisTurn.Contains(12) ||
                actionTrackers[a.work.id].skillsUsedThisTurn.Contains(18) ||
                actionTrackers[a.work.id].skillsUsedThisTurn.Contains(24) ||
                actionTrackers[a.work.id].skillsUsedThisTurn.Contains(27))
            {
                UseSkill(ref a, 172);
            }
            else
            {
                int randomValue = random.Next(12);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 172); break;
                    case 1: UseSkill(ref a, 172); break;
                    case 2: UseSkill(ref a, 172); break;
                    case 3: UseSkill(ref a, 6); break;
                    case 4: UseSkill(ref a, 6); break;
                    case 5: UseSkill(ref a, 12); break;
                    case 6: UseSkill(ref a, 12); break;
                    case 7: UseSkill(ref a, 18); break;
                    case 8: UseSkill(ref a, 18); break;
                    case 9: UseSkill(ref a, 24); break;
                    case 10: UseSkill(ref a, 24); break;
                    case 11: UseSkill(ref a, 27); break;
                }
            }
        }


        private static void BigSpecterAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(423))
                UseSkill(ref a, 423);
            else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(153))
                UseSkill(ref a, 153);
            else if (AllyPartyBuffed(1) && ((actionTrackers[a.work.id].currentBattleTurnCount + 2) % 3) == 0)
                UseSkill(ref a, 57);
            else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(57) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(26) && actionTrackers[a.work.id].currentBattleTurnCount != 1)
                UseSkill(ref a, 26);
            else
            {
                int randomValue = random.Next(6);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 3); break;
                    case 2: UseSkill(ref a, 3); break;
                    case 3: UseSkill(ref a, 153); break;
                    case 4: UseSkill(ref a, 153); break;
                    case 5: UseSkill(ref a, 56); break;
                    case 6: UseSkill(ref a, 63); break;
                }
            }
        }

        private static void BossMizuchiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);
            if (currentHpPercent <= 60 && actionTrackers[a.work.id].phase == 1)
            {
                actionTrackers[a.work.id].phase = 2;
                actionTrackers[a.work.id].skillsUsedThisBattle.Clear();
            }
                
            if (currentHpPercent <= 20 && actionTrackers[a.work.id].phase == 2)
            {
                actionTrackers[a.work.id].phase = 3;
                actionTrackers[a.work.id].skillsUsedThisBattle.Clear();
            }
                

            if (actionTrackers[a.work.id].phase == 1)
            {
                if (actionTrackers[a.work.id].currentBattleActionCount == 1)
                {
                    UseSkill(ref a, 423); return;
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(245))
                {
                    UseSkill(ref a, 245); return;
                }
                else if (EnemyPartyDebuffed(1) && (actionTrackers[a.work.id].currentBattleTurnCount % 3) == 0 && actionTrackers[a.work.id].currentTurnActionCount == 1)
                {
                    UseSkill(ref a, 77); return;
                }
                else
                {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 98); break;
                        case 1: UseSkill(ref a, 9); break;
                        case 2: UseSkill(ref a, 12); break;
                        case 3: UseSkill(ref a, 181); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(245))
                {
                    UseSkill(ref a, 245); return;
                }
                else if (EnemyPartyDebuffed(1) && (actionTrackers[a.work.id].currentBattleTurnCount % 3) == 0 && actionTrackers[a.work.id].currentTurnActionCount == 1)
                {
                    UseSkill(ref a, 77); return;
                }
                else
                {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 98); break;
                        case 1: UseSkill(ref a, 8); break;
                        case 2: UseSkill(ref a, 11); break;
                        case 3: UseSkill(ref a, 437); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 3)
            {
                if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(245))
                {
                    UseSkill(ref a, 245); return;
                }
                else if (EnemyPartyDebuffed(1) && (actionTrackers[a.work.id].currentBattleTurnCount % 3) == 0 && actionTrackers[a.work.id].currentTurnActionCount == 1)
                {
                    UseSkill(ref a, 77); return;
                }
                else
                {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 98); break;
                        case 2: UseSkill(ref a, 7); break;
                        case 3: UseSkill(ref a, 10); break;
                    }
                }
            }
        }

        private static void BossMichaelAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Michael HP%: " + currentHpPercent);
            //MelonLogger.Msg("Michael HP: " + a.work.hp);

            if (currentHpPercent <= 50 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;

            if (actionTrackers[a.work.id].phase == 1)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                    UseSkill(ref a, 423);
                else if (!EnemyPartyBuffed(3) && random.Next(2 + Convert.ToInt32(actionTrackers[a.work.id].skillsUsedThisTurn.Contains(459))) == 0)
                    UseSkill(ref a, 459);
                else
                {
                    int randomValue = random.Next(8);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 103); break;
                        case 1: UseSkill(ref a, 103); break;
                        case 2: UseSkill(ref a, 108); break;
                        case 3: UseSkill(ref a, 108); break;
                        case 4: UseSkill(ref a, 134); break;
                        case 5: UseSkill(ref a, 134); break;
                        case 6: UseSkill(ref a, 27); break;
                        case 7: UseSkill(ref a, 31); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(467))
                    UseSkill(ref a, 467);
                else if (!EnemyPartyBuffed(3) && random.Next(2 + Convert.ToInt32(actionTrackers[a.work.id].skillsUsedThisTurn.Contains(459))) == 0)
                    UseSkill(ref a, 459);
                else
                {
                    int randomValue = random.Next(8);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 103); break;
                        case 1: UseSkill(ref a, 103); break;
                        case 2: UseSkill(ref a, 467); break;
                        case 3: UseSkill(ref a, 467); break;
                        case 4: UseSkill(ref a, 134); break;
                        case 5: UseSkill(ref a, 134); break;
                        case 6: UseSkill(ref a, 27); break;
                        case 7: UseSkill(ref a, 27); break;
                    }
                }
            }
        }

        private static void BossSakahagiAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (currentHpPercent <= 40 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;

            if (actionTrackers[a.work.id].extraTurns < 1)
            {
                UseSkill(ref a, 423);
            }
            else if (actionTrackers[a.work.id].phase == 2 && actionTrackers[a.work.id].skillsUsedThisBattle.Contains(27) && !actionTrackers[a.work.id].skillsUsedThisBattle.Contains(220))
            {
                UseSkill(ref a, 220);
            }
            else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
            {
                UseNormalAttack(ref a);
            }
            else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(27) || a.work.mp >= 46)
            {
                UseSkill(ref a, 27);
            }
            else
            {
                var itemSkills = new List<ushort> { 0, 2, 4, 8, 10, 14, 16, 20, 22, 30, 34, 55, 128 };
                if (!EnemyFocused(ref a) && !EnemyConcentrated(ref a))
                {
                    itemSkills.Add(82);
                    itemSkills.Add(224);
                    itemSkills.Add(424);
                }
                else if (!EnemyConcentrated(ref a))
                    itemSkills.Add(82);
                if (a.party.count[13] == 0 && a.party.count[14] == 0)
                {
                    itemSkills.Add(69);
                    itemSkills.Add(70);
                }
                if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(81))
                    itemSkills.Add(81);
                if (AllyPartyBuffed(1) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(77))
                    itemSkills.Add(57);
                if (EnemyPartyDebuffed(1) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(57))
                    itemSkills.Add(77);

                for (ushort i = 1; i <= 424; i++)
                {
                    if (itemSkills.Contains(i) && actionTrackers[a.work.id].skillsUsedThisBattle.Contains(i))
                        itemSkills.Remove(i);
                }

                int randomValue = random.Next(itemSkills.Count);
                if (randomValue == 0)
                    UseNormalAttack(ref a);
                else
                    UseSkill(ref a, itemSkills[randomValue]);
            }
        }

        private static void BossOrthrusAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (currentHpPercent <= 60 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            else if (currentHpPercent <= 20 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;

            if (actionTrackers[a.work.id].phase == 1)
            {
                int randomValue = random.Next(2);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 125); break;
                    case 1: UseSkill(ref a, 176); break;
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                {
                    UseSkill(ref a, 422); return;
                }
                else
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 125); break;
                        case 1: UseSkill(ref a, 2); break;
                        case 2: UseSkill(ref a, 5); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 3)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                {
                    UseSkill(ref a, 422); return;
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(203))
                {
                    UseSkill(ref a, 203); return;
                }
                else
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 430); break;
                        case 1: UseSkill(ref a, 3); break;
                        case 2: UseSkill(ref a, 177); break;
                    }
                }
            }
        }

        private static void BossYaksiniAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (currentHpPercent <= 65 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            else if (currentHpPercent <= 30 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;

            if (actionTrackers[a.work.id].phase == 1)
            {
                int randomValue = random.Next(3);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 461); break;
                    case 2: UseSkill(ref a, 20); break;
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                {
                    UseSkill(ref a, 422); return;
                }
                else
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 109); break;
                        case 1: UseSkill(ref a, 23); break;
                        case 2: UseSkill(ref a, 211); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 3)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                {
                    UseSkill(ref a, 422); return;
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(63))
                {
                    UseSkill(ref a, 63); return;
                }
                else
                {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 109); break;
                        case 1: UseSkill(ref a, 185); break;
                        case 2: UseSkill(ref a, 21); break;
                        case 3: UseSkill(ref a, 211); break;
                    }
                }
            }
        }

        private static void BossThor1AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (currentHpPercent <= 50 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            else if (currentHpPercent <= 20 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;

            if (actionTrackers[a.work.id].phase == 1)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                {
                    UseSkill(ref a, 422); return;
                }
                else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
                {
                    UseSkill(ref a, 16); return;
                }
                else {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 428); break;
                        case 2: UseSkill(ref a, 16); break;
                        case 3: UseSkill(ref a, 14); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                if (actionTrackers[a.work.id].extraTurns < 2)
                {
                    UseSkill(ref a, 422); return;
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(457) || a.work.badstatus != 0)
                {
                    UseSkill(ref a, 457); return;
                }
                else
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 428); break;
                        case 1: UseSkill(ref a, 17); break;
                        case 2: UseSkill(ref a, 469); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 3)
            {
                if (actionTrackers[a.work.id].extraTurns < 2)
                {
                    UseSkill(ref a, 422); return;
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(457) || a.work.badstatus != 0)
                {
                    UseSkill(ref a, 457); return;
                }
                else if (AllyPartyBuffed(1) && random.Next(2) == 0)
                {
                    UseSkill(ref a, 57);
                }
                else
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 17); break;
                        case 2: UseSkill(ref a, 469); break;
                    }
                }
            }
        }

        private static void BossBlackFrostAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (currentHpPercent <= 60 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;

            if (actionTrackers[a.work.id].extraTurns < 1)
            {
                UseSkill(ref a, 423); return;
            }
            if (actionTrackers[a.work.id].phase == 1)
            {
                if (actionTrackers[a.work.id].currentBattleActionCount == 2)
                {
                    UseSkill(ref a, 35); return;
                }
                else if (AllyPartyBuffed(2) || EnemyPartyDebuffed(2))
                {
                    if (AllyPartyBuffed(2))
                    {
                        UseSkill(ref a, 57); return;
                    }
                    else
                    {
                        UseSkill(ref a, 77); return;
                    }
                }
                else
                {
                    int randomValue = random.Next(5);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 9); break;
                        case 2: UseSkill(ref a, 12); break;
                        case 3: UseSkill(ref a, 35); break;
                        case 4: UseSkill(ref a, 98); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(6))
                {
                    UseSkill(ref a, 6); return;
                }
                else if (AllyPartyBuffed(3) || EnemyPartyDebuffed(3))
                {
                    if (AllyPartyBuffed(3))
                    {
                        UseSkill(ref a, 57); return;
                    }
                    else
                    {
                        UseSkill(ref a, 77); return;
                    }
                }
                else
                {
                    int randomValue = random.Next(5);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 6); break;
                        case 2: UseSkill(ref a, 438); break;
                        case 3: UseSkill(ref a, 35); break;
                        case 4: UseSkill(ref a, 434); break;
                    }
                }
            }
        }

        private static void BossCerberusRAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Cerberus R HP%: " + currentHpPercent);
            //MelonLogger.Msg("Cerberus R HP: " + a.work.hp);

            var enemypcnt = a.data.enemypcnt;
            
            if (EnemyPartyDebuffed(1) && (actionTrackers[a.work.id].currentBattleTurnCount % 3) == 0)
            {
                UseSkill(ref a, 77);
            }
            else
            {
                switch (enemypcnt)
                {
                    case 3:
                        {
                            int randomValue = random.Next(4);
                            switch (randomValue)
                            {
                                case 0: UseSkill(ref a, 64); break;
                                case 1: UseSkill(ref a, 66); break;
                                case 2: UseSkill(ref a, 53); break;
                                case 3: UseSkill(ref a, 54); break;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (a.data.enemyunit.Where(x => x.id == 305 && x.hp < x.maxhp && x.flag != 0).Any())
                            {
                                int randomValue = random.Next(4);
                                switch (randomValue)
                                {
                                    case 0: UseSkill(ref a, 64); break;
                                    case 1: UseSkill(ref a, 66); break;
                                    case 2: UseSkill(ref a, 53); break;
                                    case 3: UseSkill(ref a, 54); break;
                                }
                                break;
                            }
                            else
                            {
                                if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(6))
                                {
                                    int randomValue = random.Next(6);
                                    switch (randomValue)
                                    {
                                        case 0: UseNormalAttack(ref a); break;
                                        case 1: UseNormalAttack(ref a); break;
                                        case 2: UseSkill(ref a, 465); break;
                                        case 3: UseSkill(ref a, 465); break;
                                        case 4: UseSkill(ref a, 64); break;
                                        case 5: UseSkill(ref a, 66); break;
                                        case 6: UseSkill(ref a, 53); break;
                                        case 7: UseSkill(ref a, 54); break;
                                    }
                                    break;
                                }
                                else
                                {
                                    int randomValue = random.Next(8);
                                    switch (randomValue)
                                    {
                                        case 0: UseNormalAttack(ref a); break;
                                        case 1: UseNormalAttack(ref a); break;
                                        case 2: UseSkill(ref a, 465); break;
                                        case 3: UseSkill(ref a, 6); break;
                                        case 4: UseSkill(ref a, 64); break;
                                        case 5: UseSkill(ref a, 66); break;
                                        case 6: UseSkill(ref a, 53); break;
                                        case 7: UseSkill(ref a, 54); break;
                                    }
                                    break;
                                }
                            }
                        }
                    case 1:
                        {
                            if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(6))
                            {
                                int randomValue = random.Next(2);
                                switch (randomValue)
                                {
                                    case 0: UseNormalAttack(ref a); break;
                                    case 1: UseSkill(ref a, 465); break;
                                }
                                break;
                            }
                            else
                            {
                                int randomValue = random.Next(4);
                                switch (randomValue)
                                {
                                    case 0: UseNormalAttack(ref a); break;
                                    case 1: UseSkill(ref a, 465); break;
                                    case 2: UseSkill(ref a, 465); break;
                                    case 3: UseSkill(ref a, 6); break;
                                }
                                break;
                            }
                        }
                }
            }
        }

        private static void BossCerberusCAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Cerberus C HP%: " + currentHpPercent);
            //MelonLogger.Msg("Cerberus C HP: " + a.work.hp);

            var enemypcnt = a.data.enemypcnt;

            switch (enemypcnt)
            {
                case 3:
                    {
                        var skills = new List<ushort> { 0, 432, 465 };
                        if (!EnemyFocused(ref a) && !EnemyConcentrated(ref a))
                        {
                            skills.Add(224);
                            skills.Add(424);
                        }

                        if (!AllyPartyAllImmuneToAttr(3, 1))
                        {
                            skills.Add(3);
                            skills.Add(6);
                            if (skills.Contains(424))
                                skills.Remove(424);
                        }
                        else
                        {
                            skills.Add(454);
                        }

                        if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(6) && skills.Contains(6))
                            skills.Remove(6);

                        int randomValue = random.Next(skills.Count);
                        if (randomValue == 0)
                            UseNormalAttack(ref a);
                        else
                            UseSkill(ref a, skills[randomValue]);
                        break;
                    }
                case 2:
                    {
                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
                        {
                            UseSkill(ref a, 219); break;
                        }
                        else
                        {
                            var skills = new List<ushort> { 0, 432, 465 };
                            if (!EnemyFocused(ref a) && !EnemyConcentrated(ref a))
                            {
                                skills.Add(224);
                                skills.Add(424);
                            }

                            if (!AllyPartyAllImmuneToAttr(3, 1))
                            {
                                skills.Add(3);
                                skills.Add(6);
                                if (skills.Contains(424))
                                    skills.Remove(424);
                            }
                            else
                            {
                                skills.Add(454);
                            }

                            if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(6) && skills.Contains(6))
                                skills.Remove(6);

                            int randomValue = random.Next(skills.Count);
                            if (randomValue == 0)
                                UseNormalAttack(ref a);
                            else
                                UseSkill(ref a, skills[randomValue]);
                            break;
                        }
                    }
                case 1:
                    {
                        if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(220))
                        {
                            UseSkill(ref a, 220); break;
                        }
                        else
                        {
                            var skills = new List<ushort> { 0, 432, 465 };
                            if (!EnemyFocused(ref a) && !EnemyConcentrated(ref a))
                            {
                                skills.Add(224);
                                skills.Add(424);
                            }

                            if (!AllyPartyAllImmuneToAttr(3, 1))
                            {
                                skills.Add(3);
                                skills.Add(6);
                                if (skills.Contains(424))
                                    skills.Remove(424);
                            }
                            else
                            {
                                skills.Add(454);
                            }

                            if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(6) && skills.Contains(6))
                                skills.Remove(6);

                            int randomValue = random.Next(skills.Count);
                            if (randomValue == 0)
                                UseNormalAttack(ref a);
                            else
                                UseSkill(ref a, skills[randomValue]);
                            break;
                        }
                    }
            }
        }

        private static void BossCerberusLAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Cerberus L HP%: " + currentHpPercent);
            //MelonLogger.Msg("Cerberus L HP: " + a.work.hp);

            var enemypcnt = a.data.enemypcnt;

            switch (enemypcnt)
            {
                case 3:
                    {
                        if (a.data.enemyunit.Where(x => x.hp < x.maxhp && x.flag != 0).Any())
                        {
                            int randomValue = random.Next(5);
                            switch (randomValue)
                            {
                                case 0: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                                case 1: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                                case 2: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                                case 3: UseSkill(ref a, 465); break;
                                case 4: UseSkill(ref a, 31); break;
                            }
                            break;
                        }
                        else
                        {
                            int randomValue = random.Next(3);
                            switch (randomValue)
                            {
                                case 0: UseNormalAttack(ref a); break;
                                case 1: UseSkill(ref a, 465); break;
                                case 2: UseSkill(ref a, 31); break;
                            }
                            break;
                        }
                    }
                case 2:
                    {
                        if (a.data.enemyunit.Where(x => x.hp < x.maxhp && x.flag != 0).Any())
                        {
                            int randomValue = random.Next(5);
                            switch (randomValue)
                            {
                                case 0: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                                case 1: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                                case 2: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                                case 3: UseSkill(ref a, 465); break;
                                case 4: UseSkill(ref a, 31); break;
                            }
                            break;
                        }
                        else
                        {
                            int randomValue = random.Next(3);
                            switch (randomValue)
                            {
                                case 0: UseNormalAttack(ref a); break;
                                case 1: UseSkill(ref a, 465); break;
                                case 2: UseSkill(ref a, 31); break;
                            }
                            break;
                        }
                    }
                case 1:
                    {
                        int randomValue = random.Next(3);
                        switch (randomValue)
                        {
                            case 0: UseNormalAttack(ref a); break;
                            case 1: UseSkill(ref a, 465); break;
                            case 2: UseSkill(ref a, 31); break;
                        }
                        break;
                    }
            }
        }

        private static void BossEligorAI(ref nbActionProcessData_t a, ref int code, ref int n, ushort summonId)
        {
            if (actionTrackers[a.work.id].currentBattleActionCount == 1)
            {
                UseSkill(ref a, 220); return;
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount <= 3)
            {
                UseSummonSkill(ref a, 226, summonId); return;
            }
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
            {
                UseSkill(ref a, 219); return;
            }
            else
            {
                int randomValue = random.Next(6);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 66); break;
                    case 2: UseSkill(ref a, 66); break;
                    case 3: UseSkill(ref a, 98); break;
                    case 4: UseSkill(ref a, 97); break;
                    case 5: UseSkill(ref a, 32); break;
                }
            }
        }

        private static void ForcedKelpieAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (a.data.enemyunit.Where(x => x.hp < x.maxhp && x.flag != 0).Any())
            {
                int randomValue = random.Next(10);
                switch (randomValue)
                {
                    case 1: UseSkill(ref a, 61); break;
                    case 2: UseSkill(ref a, 437); break;
                    case 3: UseSkill(ref a, 121); break;
                    case 4: UseSkill(ref a, 457); break;
                    case 5: UseSkill(ref a, 457); break;
                    case 6: UseSkill(ref a, 457); break;
                    case 7: UseSkill(ref a, 457); break;
                    case 8: UseSkill(ref a, 457); break;
                    case 9: UseSkill(ref a, 457); break;
                }
            }
            else
            {
                int randomValue = random.Next(4);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 61); break;
                    case 2: UseSkill(ref a, 437); break;
                    case 3: UseSkill(ref a, 121); break;
                }
            }
        }

        private static void BossBerithAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleActionCount == 1)
            {
                UseSkill(ref a, 220); return;
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount <= 3)
            {
                UseSummonSkill(ref a, 226, 313); return;
            }
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
            {
                UseSkill(ref a, 219); return;
            }
            else
            {
                if (AllyPartyBuffed(1))
                {
                    UseSkill(ref a, 57);
                }
                else
                {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 5); break;
                        case 2: UseSkill(ref a, 177); break;
                        case 3: UseSkill(ref a, 101); break;
                    }
                }
            }
        }

        private static void ForcedSuccubusAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (AllyPartyStatus(2048))
            {
                UseSkill(ref a, 212);
            }
            else
            {
                int randomValue = random.Next(3);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 60); break;
                    case 2: UseSkill(ref a, 214); break;
                }
            }
        }

        private static void BossTrollAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (BossCurrentHpPercent(ref a) <= 25 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;

            if (actionTrackers[a.work.id].phase == 2 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
            {
                UseSkill(ref a, 219); return;
            }
            else
            {
                int randomValue = random.Next(4);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 98); break;
                    case 2: UseSkill(ref a, 181); break;
                    case 3: UseSkill(ref a, 427); break;
                }
            }
        }

        private static void BossBishamonten1AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (currentHpPercent <= 80 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            else if (currentHpPercent <= 50 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;

            if (actionTrackers[a.work.id].phase == 1)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                {
                    UseSkill(ref a, 423); return;
                }
                else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
                {
                    UseSkill(ref a, 104); return;
                }
                else
                {
                    int randomValue = random.Next(8);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 109); break;
                        case 2: UseSkill(ref a, 109); break;
                        case 3: UseSkill(ref a, 104); break;
                        case 4: UseSkill(ref a, 104); break;
                        case 5: UseSkill(ref a, 178); break;
                        case 6: UseSkill(ref a, 178); break;
                        case 7: UseSkill(ref a, 178); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                if (EnemyPartyDebuffed(1) && !actionTrackers[a.work.id].skillsUsedThisBattle.Contains(77))
                {
                    UseSkill(ref a, 77); return;
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(224))
                {
                    UseSkill(ref a, 224); return;
                }
                else if (EnemyFocused(ref a))
                {
                    int randomValue = random.Next(4);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 109); break;
                        case 1: UseSkill(ref a, 104); break;
                        case 2: UseSkill(ref a, 104); break;
                        case 3: UseSkill(ref a, 178); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(8);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 109); break;
                        case 2: UseSkill(ref a, 104); break;
                        case 3: UseSkill(ref a, 178); break;
                        case 4: UseSkill(ref a, 178); break;
                        case 5: UseSkill(ref a, 224); break;
                        case 6: UseSkill(ref a, 224); break;
                        case 7: UseSkill(ref a, 224); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 3)
            {
                if (AllyPartyBuffed(1) && !actionTrackers[a.work.id].skillsUsedThisBattle.Contains(57))
                {
                    UseSkill(ref a, 57);
                }
                else if (EnemyFocused(ref a))
                {
                    UseSkill(ref a, 104);
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(424))
                {
                    UseSkill(ref a, 424);
                }
                else if (EnemyConcentrated(ref a))
                {
                    int randomValue = random.Next(2);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 179); break;
                        case 1: UseSkill(ref a, 476); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(8);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 109); break;
                        case 1: UseSkill(ref a, 179); break;
                        case 2: UseSkill(ref a, 179); break;
                        case 3: UseSkill(ref a, 476); break;
                        case 4: UseSkill(ref a, 476); break;
                        case 5: UseSkill(ref a, 424); break;
                        case 6: UseSkill(ref a, 424); break;
                        case 7: UseSkill(ref a, 424); break;
                    }
                }

                if (a.work.nowindex == 424 && AllyPartyAllImmuneToAttr(179, 1) && AllyPartyAllImmuneToAttr(476, 6) && !EnemyFocused(ref a) && !EnemyConcentrated(ref a))
                {
                    UseSkill(ref a, 224);
                }
                else if ((a.work.nowindex == 179 && AllyPartyAllImmuneToAttr(179, 1)) ||
                    (a.work.nowindex == 476 && AllyPartyAllImmuneToAttr(476, 6)))
                {
                    UseSkill(ref a, 109);
                }
            }
        }

        private static void BossMaraAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 422);
            else if (actionTrackers[a.work.id].currentBattleActionCount <= 2)
            {
                UseSummonSkill(ref a, 252, 253); return;
            }
            else
            {
                if (!EnemyPartyBuffed(2, 4))
                {
                    UseSkill(ref a, 458);
                    SetTargetingRule(ref code, ref n, 3, 321);
                }
                else if (!EnemyFocused(ref a))
                {
                    UseSkill(ref a, 224);
                }
                else
                {
                    UseSkill(ref a, 97);
                    SetTargetingRule(ref code, ref n, 6, n);
                }
            }
        }

        private static void BossBishamonten2AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (actionTrackers[a.work.id].currentBattleActionCount == 1)
            {
                UseSkill(ref a, 423);
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
            {
                UseSkill(ref a, 104);
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 3)
            {
                UseSkill(ref a, 206);
            }
            else if (a.work.nowindex == 99)
            {
                UseSkill(ref a, 104);
            }
            else if (a.work.nowindex == 137)
            {
                UseSkill(ref a, 109);
            }
            else if (a.work.nowindex == 220)
            {
                UseSkill(ref a, 219);
            }
            else if (a.work.nowindex == 6 || a.work.nowindex == 177 || a.work.nowindex == 178)
            {
                int randomValue = random.Next(2);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 178); break;
                    case 1: UseSkill(ref a, 436); break;
                }
            }
        }

        private static void BossJikokutenAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleActionCount == 1)
            {
                UseSkill(ref a, 423);
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
            {
                UseSkill(ref a, (ushort)(69 + random.Next(2)));
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 3)
            {
                UseSkill(ref a, 459);
            }
            else if (actionTrackers[a.work.id].currentTurnActionCount == 1 && random.Next(2) == 0)
            {
                UseSkill(ref a, (ushort)(69 + random.Next(2)));
            }
            else if (AllyPartyStatus(2) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
            {
                UseSkill(ref a, 219);
            }
            else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(224))
            {
                UseSkill(ref a, 224);
            }
            else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(224))
            {
                UseSkill(ref a, (ushort)(105 + random.Next(2))); SetTargetingRule(ref code, ref n, 2, 2);
            }
            else if (!EnemyPartyBuffed(3) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(459) && random.Next(3) == 0)
            {
                UseSkill(ref a, 459);
            }
            else
            {
                int randomValue = random.Next(6);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 104); break;
                    case 1: UseSkill(ref a, 105); break;
                    case 2: UseSkill(ref a, 106); break;
                    case 3: UseSkill(ref a, 439); break;
                    case 4: UseSkill(ref a, 439); break;
                    case 5: UseSkill(ref a, 439); break;
                }

                if ((new ushort[] { 104, 105, 106 }.Contains(a.work.nowindex) && AllyPartyAllImmuneToAttr(104, 0)) ||
                    (a.work.nowindex == 275 && AllyPartyAllImmuneToAttr(439, 2)))
                {
                    UseSkill(ref a, 27);
                }
            }
        }

        private static void BossKoumokutenAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleActionCount == 1)
            {
                UseSkill(ref a, 423);
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
            {
                UseSkill(ref a, 206);
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 3)
            {
                UseSkill(ref a, 459);
            }
            else if (!AllyPartyDebuffed(3) && random.Next(3 + Convert.ToInt32(actionTrackers[a.work.id].skillsUsedThisTurn.Contains(206))) == 0)
            {
                UseSkill(ref a, 206);
            }
            else if (!EnemyPartyBuffed(3) && random.Next(3 + Convert.ToInt32(actionTrackers[a.work.id].skillsUsedThisTurn.Contains(459))) == 0)
            {
                UseSkill(ref a, 459);
            }
            else
            {
                int randomValue = random.Next(4);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 104); break;
                    case 1: UseSkill(ref a, 429); break;
                    case 2: UseSkill(ref a, 444); break;
                    case 3: UseSkill(ref a, 445); break;
                }

                if ((new ushort[] { 104, 429 }.Contains(a.work.nowindex) && AllyPartyAllImmuneToAttr(104, 0)) ||
                    (new ushort[] { 444, 445 }.Contains(a.work.nowindex) && AllyPartyAllImmuneToAttr(444, 4)))
                {
                    UseSkill(ref a, 27);
                }
            }
        }

        private static void BossZouchoutenAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleActionCount == 1)
            {
                UseSkill(ref a, 423);
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
            {
                UseSkill(ref a, 442);
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 3)
            {
                UseSkill(ref a, 459);
            }
            else if (actionTrackers[a.work.id].currentTurnActionCount == 1 && random.Next(2) == 0)
            {
                if (AllyPartyBuffed(1) && random.Next(2) == 0)
                {
                    UseSkill(ref a, 57); return;
                }
                else if (EnemyPartyDebuffed(1))
                {
                    UseSkill(ref a, 77); return;
                }
            }
            else if (AllyPartyStatus(1) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219))
            {
                UseSkill(ref a, 219);
            }
            else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(219) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(224))
            {
                UseSkill(ref a, 224);
            }
            else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(224))
            {
                UseSkill(ref a, 433); SetTargetingRule(ref code, ref n, 2, 1);
            }
            else if (!EnemyPartyBuffed(3) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(459) && random.Next(3) == 0)
            {
                UseSkill(ref a, 459);
            }
            else
            {
                int randomValue = random.Next(6);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 104); break;
                    case 1: UseSkill(ref a, 433); break;
                    case 2: UseSkill(ref a, 441); break;
                    case 3: UseSkill(ref a, 441); break;
                    case 4: UseSkill(ref a, 442); break;
                    case 5: UseSkill(ref a, 442); break;
                }

                if ((new ushort[] { 104, 433 }.Contains(a.work.nowindex) && AllyPartyAllImmuneToAttr(104, 0)) ||
                    (new ushort[] { 441, 442 }.Contains(a.work.nowindex) && AllyPartyAllImmuneToAttr(442, 3)))
                {
                    UseSkill(ref a, 27);
                }
            }
        }

        private static void BossClotho2AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            var enemypcnt = a.data.enemypcnt;

            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(422))
                UseSkill(ref a, 422);
            else
            {
                if (actionTrackers[a.work.id].extraTurns != 0)
                    foreach (var actionTracker in actionTrackers)
                        actionTracker.Value.extraTurns = 1;

                switch (enemypcnt)
                {
                    case 3:
                        {
                            if (a.data.enemyunit.Where(x => x.hp < x.maxhp && x.flag != 0).Any())
                            {
                                int randomValue = random.Next(9);
                                switch (randomValue)
                                {
                                    case 0: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                                    case 1: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                                    case 2: UseSkill(ref a, 39); break;
                                    case 3: UseSkill(ref a, 39); break;
                                    case 4: UseSkill(ref a, 29); break;
                                    case 5: UseSkill(ref a, 31); break;
                                    case 6: UseSkill(ref a, 62); break;
                                    case 7: UseSkill(ref a, 215); break;
                                    case 8: UseNormalAttack(ref a); break;
                                }
                            }
                            else
                            {
                                int randomValue = random.Next(9);
                                switch (randomValue)
                                {
                                    case 0: UseSkill(ref a, 29); break;
                                    case 1: UseSkill(ref a, 29); break;
                                    case 2: UseSkill(ref a, 31); break;
                                    case 3: UseSkill(ref a, 31); break;
                                    case 4: UseSkill(ref a, 62); break;
                                    case 5: UseSkill(ref a, 62); break;
                                    case 6: UseSkill(ref a, 215); break;
                                    case 7: UseSkill(ref a, 215); break;
                                    case 8: UseNormalAttack(ref a); break;
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            if (EnemyPartyDebuffed(1) && (actionTrackers[a.work.id].currentBattleTurnCount % 4) == 0)
                                UseSkill(ref a, 77);
                            else if (a.data.enemyunit.Where(x => x.hp < x.maxhp && x.flag != 0).Any())
                            {
                                int randomValue = random.Next(9);
                                switch (randomValue)
                                {
                                    case 0: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                                    case 1: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                                    case 2: UseSkill(ref a, 39); break;
                                    case 3: UseSkill(ref a, 39); break;
                                    case 4: UseSkill(ref a, 29); break;
                                    case 5: UseSkill(ref a, 31); break;
                                    case 6: UseSkill(ref a, 196); break;
                                    case 7: UseSkill(ref a, 196); break;
                                    case 8: UseNormalAttack(ref a); break;
                                }
                            }
                            else
                            {
                                int randomValue = random.Next(9);
                                switch (randomValue)
                                {
                                    case 0: UseSkill(ref a, 29); break;
                                    case 1: UseSkill(ref a, 29); break;
                                    case 2: UseSkill(ref a, 31); break;
                                    case 3: UseSkill(ref a, 31); break;
                                    case 4: UseSkill(ref a, 62); break;
                                    case 5: UseSkill(ref a, 215); break;
                                    case 6: UseSkill(ref a, 196); break;
                                    case 7: UseSkill(ref a, 196); break;
                                    case 8: UseNormalAttack(ref a); break;
                                }
                            }
                            break;
                        }
                    case 1:
                        {
                            if (EnemyPartyDebuffed(1) && (actionTrackers[a.work.id].currentBattleTurnCount % 3) == 0)
                                UseSkill(ref a, 77);
                            else if (a.data.enemyunit.Where(x => x.hp < x.maxhp && x.flag != 0).Any())
                            {
                                int randomValue = random.Next(9);
                                switch (randomValue)
                                {
                                    case 0: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                                    case 1: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                                    case 2: UseSkill(ref a, 37); SetTargetingRule(ref code, ref n, 1, n); break;
                                    case 3: UseSkill(ref a, 29); break;
                                    case 4: UseSkill(ref a, 31); break;
                                    case 5: UseSkill(ref a, 62); break;
                                    case 6: UseSkill(ref a, 215); break;
                                    case 7: UseSkill(ref a, 196); break;
                                    case 8: UseNormalAttack(ref a); break;
                                }
                            }
                            else
                            {
                                int randomValue = random.Next(9);
                                switch (randomValue)
                                {
                                    case 0: UseSkill(ref a, 29); break;
                                    case 1: UseSkill(ref a, 29); break;
                                    case 2: UseSkill(ref a, 31); break;
                                    case 3: UseSkill(ref a, 31); break;
                                    case 4: UseSkill(ref a, 62); break;
                                    case 5: UseSkill(ref a, 215); break;
                                    case 6: UseSkill(ref a, 196); break;
                                    case 7: UseSkill(ref a, 196); break;
                                    case 8: UseNormalAttack(ref a); break;
                                }
                            }
                            break;
                        }
                }
            }
        }

        private static void BossLachesis2AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            var enemypcnt = a.data.enemypcnt;

            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(422))
                UseSkill(ref a, 422);
            else
            {
                if (actionTrackers[a.work.id].extraTurns != 0)
                    foreach (var actionTracker in actionTrackers)
                        actionTracker.Value.extraTurns = 1;

                switch (enemypcnt)
                {
                    case 3:
                        {
                            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(69) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(70) && random.Next(2) == 0)
                            {
                                UseSkill(ref a, (ushort)(69 + random.Next(2))); return;
                            }
                            else
                            {
                                int randomValue = random.Next(7);
                                switch (randomValue)
                                {
                                    case 0: UseNormalAttack(ref a); break;
                                    case 1: UseNormalAttack(ref a); break;
                                    case 2: UseNormalAttack(ref a); break;
                                    case 3: UseSkill(ref a, 52); break;
                                    case 4: UseSkill(ref a, 54); break;
                                    case 5: UseSkill(ref a, 64); break;
                                    case 6: UseSkill(ref a, 66); break;
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(206) && (actionTrackers[a.work.id].currentBattleTurnCount % 4) == 0)
                            {
                                UseSkill(ref a, 206); return;
                            }
                            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(69) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(70) && random.Next(2) == 0)
                            {
                                UseSkill(ref a, (ushort)(69 + random.Next(2))); return;
                            }
                            else
                            {
                                int randomValue = random.Next(7);
                                switch (randomValue)
                                {
                                    case 0: UseNormalAttack(ref a); break;
                                    case 1: UseNormalAttack(ref a); break;
                                    case 2: UseNormalAttack(ref a); break;
                                    case 3: UseSkill(ref a, 52); break;
                                    case 4: UseSkill(ref a, 54); break;
                                    case 5: UseSkill(ref a, 64); break;
                                    case 6: UseSkill(ref a, 66); break;
                                }
                            }
                            break;
                        }
                    case 1:
                        {
                            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(206) && (actionTrackers[a.work.id].currentBattleTurnCount % 3) == 0)
                            {
                                UseSkill(ref a, 206); return;
                            }
                            else
                            {
                                int randomValue = random.Next(7);
                                switch (randomValue)
                                {
                                    case 0: UseNormalAttack(ref a); break;
                                    case 1: UseNormalAttack(ref a); break;
                                    case 2: UseNormalAttack(ref a); break;
                                    case 3: UseSkill(ref a, 52); break;
                                    case 4: UseSkill(ref a, 54); break;
                                    case 5: UseSkill(ref a, 64); break;
                                    case 6: UseSkill(ref a, 66); break;
                                }
                            }
                            break;
                        }
                }
            }
        }

        private static void BossAtropos2AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            var enemypcnt = a.data.enemypcnt;

            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(422))
                UseSkill(ref a, 422);
            else
            {
                if (actionTrackers[a.work.id].extraTurns != 0)
                    foreach (var actionTracker in actionTrackers)
                        actionTracker.Value.extraTurns = 1;

                switch (enemypcnt)
                {
                    case 3:
                        {
                            int randomValue = random.Next(8);
                            switch (randomValue)
                            {
                                case 0: UseSkill(ref a, 2); break;
                                case 1: UseSkill(ref a, 5); break;
                                case 2: UseSkill(ref a, 8); break;
                                case 3: UseSkill(ref a, 11); break;
                                case 4: UseSkill(ref a, 14); break;
                                case 5: UseSkill(ref a, 17); break;
                                case 6: UseSkill(ref a, 20); break;
                                case 7: UseSkill(ref a, 23); break;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(25) && (actionTrackers[a.work.id].currentBattleTurnCount % 4) == 0)
                            {
                                UseSkill(ref a, 25); return;
                            }
                            else
                            {
                                int randomValue = random.Next(8);
                                switch (randomValue)
                                {
                                    case 0: UseSkill(ref a, 2); break;
                                    case 1: UseSkill(ref a, 5); break;
                                    case 2: UseSkill(ref a, 8); break;
                                    case 3: UseSkill(ref a, 11); break;
                                    case 4: UseSkill(ref a, 14); break;
                                    case 5: UseSkill(ref a, 17); break;
                                    case 6: UseSkill(ref a, 20); break;
                                    case 7: UseSkill(ref a, 23); break;
                                }
                            }
                            break;
                        }
                    case 1:
                        {
                            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(25) && (actionTrackers[a.work.id].currentBattleTurnCount % 3) == 0)
                            {
                                UseSkill(ref a, 25); return;
                            }
                            else
                            {
                                int randomValue = random.Next(8);
                                switch (randomValue)
                                {
                                    case 0: UseSkill(ref a, 2); break;
                                    case 1: UseSkill(ref a, 5); break;
                                    case 2: UseSkill(ref a, 8); break;
                                    case 3: UseSkill(ref a, 11); break;
                                    case 4: UseSkill(ref a, 14); break;
                                    case 5: UseSkill(ref a, 17); break;
                                    case 6: UseSkill(ref a, 20); break;
                                    case 7: UseSkill(ref a, 23); break;
                                }
                            }
                            break;
                        }
                }
            }
        }

        private static void BossMitraAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (actionTrackers[a.work.id].currentTurnActionCount == 1)
                actionTrackers[a.work.id].scriptVar1 = (short) random.Next(2);

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 423);
            else if (a.data.playerpcnt > 1 && !actionTrackers[a.work.id].skillsUsedThisBattle.Contains(495))
            {
                UseSkill(ref a, 495);
                SetTargetingRule(ref code, ref n, 6, n);
            }
            else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(454))
            {
                UseSkill(ref a, 454);
                SetTargetingRule(ref code, ref n, 10, n);
            }
            else if (EnemyPartyDebuffed(1) && random.Next(2) == 0)
                UseSkill(ref a, 77);
            else if (actionTrackers[a.work.id].currentTurnActionCount == 1 && random.Next(3) != 0 && !AllyPartyDebuffed(3))
                UseSkill(ref a, 206);
            else
            {
                switch (actionTrackers[a.work.id].scriptVar1)
                {
                    case 0:
                        {
                            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(454) && random.Next(3) != 0)
                                UseSkill(ref a, 454);
                            else
                                UseSkill(ref a, 430);
                            break;
                        }
                    case 1:
                        {
                            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(35))
                                UseSkill(ref a, 35);
                            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(31))
                                UseSkill(ref a, 31);
                            else
                                UseSkill(ref a, 454);
                            break;
                        }
                }
            }
        }

        private static void BossMadaAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 422);
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
                UseSummonSkill(ref a, 226, 243);
            else if (a.data.enemypcnt < 3 && random.Next(2) == 0)
                UseSummonSkill(ref a, 226, 243);
            else if (EnemyPartyDebuffed(1) && random.Next(2) == 0)
                UseSkill(ref a, 77);
            else
            {
                int randomValue = random.Next(6);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 100); break;
                    case 1: UseSkill(ref a, 100); break;
                    case 2: UseSkill(ref a, 217); break;
                    case 3: UseSkill(ref a, 217); break;
                    case 4: UseSkill(ref a, 459); break;
                    case 5: UseSkill(ref a, 206); break;
                }
            }
        }

        private static void BossPazuzuAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleActionCount == 1)
                UseSkill(ref a, 187);
            else if (nbMainProcess.nbGetMainProcessData().enemyunit.Where(x => x.hp < x.maxhp && x.flag != 0).Any())
            {
                int randomValue = random.Next(10);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 40); break;
                    case 1: UseSkill(ref a, 40); break;
                    case 2: UseSkill(ref a, 40); break;
                    case 3: UseSkill(ref a, 40); break;
                    case 4: UseSkill(ref a, 40); break;
                    case 5: UseSkill(ref a, 114); break;
                    case 6: UseSkill(ref a, 114); break;
                    case 7: UseSkill(ref a, 187); break;
                    case 8: UseSkill(ref a, 187); break;
                    case 9: UseSkill(ref a, 196); break;
                }
            }
            else
            {
                int randomValue = random.Next(5);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 114); break;
                    case 1: UseSkill(ref a, 114); break;
                    case 2: UseSkill(ref a, 187); break;
                    case 3: UseSkill(ref a, 187); break;
                    case 4: UseSkill(ref a, 196); break;
                }
            }
        }

        private static void BossThor2AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (currentHpPercent <= 60 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            else if (currentHpPercent <= 20 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 423);
            else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(442))
                UseSkill(ref a, 442);
            else if (a.work.badstatus != 0)
                UseSkill(ref a, 457);
            else if (a.work.nowindex == 220)
                UseSkill(ref a, 219);
            else if (a.work.nowindex == 97)
                UseSkill(ref a, 429);
            else if (a.work.nowindex == 109)
                UseSkill(ref a, 100);
            else if (a.work.nowindex == 15)
                UseSkill(ref a, 469);
            else if (a.work.nowindex == 18 || a.work.nowindex == 183)
                UseSkill(ref a, 442);
            else if (a.work.nowindex == 64 || a.work.nowindex == 67)
                UseSkill(ref a, 459);
        }

        private static void BossMotAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (a.data.encno == 1275)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                    UseSkill(ref a, 423);
                else if (random.Next(5) <= 1)
                    UseSkill(ref a, 219);
                else if (EnemyPartyDebuffed(1) && random.Next(2) == 0)
                    UseSkill(ref a, 77);
                else
                {
                    int randomValue = random.Next(8);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 99); break;
                        case 1: UseSkill(ref a, 6); break;
                        case 2: UseSkill(ref a, 24); break;
                        case 3: UseSkill(ref a, 27); break;
                        case 4: UseSkill(ref a, 27); break;
                        case 5: UseSkill(ref a, 27); break;
                        case 6: UseSkill(ref a, 67); break;
                        case 7: UseSkill(ref a, 67); break;
                    }
                }
            }
            else
            {
                if (actionTrackers[a.work.id].extraTurns == 5 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(422))
                {
                    if (EnemyPartyDebuffed(1))
                        UseSkill(ref a, 77);
                    else if (AllyPartyBuffed(1))
                        UseSkill(ref a, 57);
                    else if (!EnemyPartyBuffed(3, 5))
                        UseSkill(ref a, 67);
                    else
                        UseSkill(ref a, 27);
                }
                else if (actionTrackers[a.work.id].extraTurns < 5 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(422))
                    UseSkill(ref a, 422);
                else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
                    UseSkill(ref a, 67);
                else if (EnemyPartyDebuffed(1) && random.Next(2) == 0)
                    UseSkill(ref a, 77);
                else
                {
                    if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(99) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(6) &&
                        !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(24) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(27))
                    {
                        int randomValue = random.Next(5);
                        switch (randomValue)
                        {
                            case 0: UseSkill(ref a, 99); break;
                            case 1: UseSkill(ref a, 6); break;
                            case 2: UseSkill(ref a, 24); break;
                            case 3: UseSkill(ref a, 27); break;
                            case 4: UseSkill(ref a, 67); break;
                        }
                    }
                    else
                    {
                        int randomValue = random.Next(2);
                        switch (randomValue)
                        {
                            case 0: UseNormalAttack(ref a); break;
                            case 1: UseSkill(ref a, 67); break;
                        }
                    }
                }
            }
        }

        private static void BossSurtAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 423);
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
                UseSkill(ref a, 436);
            else if (EnemyPartyDebuffed(1) && random.Next(2) == 0)
                UseSkill(ref a, 77);
            else
            {
                int randomValue = random.Next(6);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 103); break;
                    case 2: UseSkill(ref a, 108); break;
                    case 3: UseSkill(ref a, 178); break;
                    case 4: UseSkill(ref a, 436); break;
                    case 5: UseSkill(ref a, 203); break;
                }
            }
        }

        private static void BossDanteRaidou1AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 422);
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
                UseNormalAttack(ref a);
        }

        private static void ChaseDanteRaidouAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleActionCount == 1)
                UseSkill(ref a, 220);
            else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(266))
                UseSkill(ref a, 266);
        }

        private static void BossDanteRaidou2AI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (currentHpPercent <= 80 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            else if (currentHpPercent <= 40 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 422);
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
                UseSkill(ref a, 265);
            else if (actionTrackers[a.work.id].phase == 1)
            {
                if (EnemyPartyDebuffed(1) && random.Next(4) != 0)
                {
                    UseSkill(ref a, 274);
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(264))
                {
                    int randomValue = random.Next(10);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 262); break;
                        case 2: UseSkill(ref a, 262); break;
                        case 3: UseSkill(ref a, 262); break;
                        case 4: UseSkill(ref a, 263); break;
                        case 5: UseSkill(ref a, 263); break;
                        case 6: UseSkill(ref a, 263); break;
                        case 7: UseSkill(ref a, 264); break;
                        case 8: UseSkill(ref a, 264); break;
                        case 9: UseSkill(ref a, 264); break;
                    }
                }
                else
                {
                    int randomValue = random.Next(5);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 262); break;
                        case 2: UseSkill(ref a, 262); break;
                        case 3: UseSkill(ref a, 263); break;
                        case 4: UseSkill(ref a, 263); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(265) && random.Next(4) == 0)
                {
                    UseSkill(ref a, 265);
                }
                else
                {
                    int randomValue = random.Next(10);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 266); break;
                        case 1: UseSkill(ref a, 266); break;
                        case 2: UseSkill(ref a, 266); break;
                        case 3: UseSkill(ref a, 267); break;
                        case 4: UseSkill(ref a, 267); break;
                        case 5: UseSkill(ref a, 267); break;
                        case 6: UseSkill(ref a, 268); break;
                        case 7: UseSkill(ref a, 268); break;
                        case 8: UseSkill(ref a, 268); break;
                        case 9: UseSkill(ref a, 269); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 3)
            {
                if (EventBit.evtBitCheck(3712))
                {
                    UseSummonSkill(ref a, 497, 252);
                }
                else
                {
                    if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(252))
                    {
                        UseSummonSkill(ref a, 252, 363);
                        actionTrackers.Add(364, new ActionTracker());
                        actionTrackers.Add(365, new ActionTracker());
                        actionTrackers.Add(366, new ActionTracker());
                    }
                    else if (a.data.enemypcnt > 3)
                    {
                        int randomValue = random.Next(4);
                        switch (randomValue)
                        {
                            case 0: UseNormalAttack(ref a); break;
                            case 1: UseSkill(ref a, 262); break;
                            case 2: UseSkill(ref a, 263); break;
                            case 3: UseSkill(ref a, 264); break;
                        }
                    }
                    else
                    {
                        if (EnemyPartyDebuffed(1) && random.Next(4) == 0)
                        {
                            UseSkill(ref a, 274);
                        }
                        else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(264) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(267) &&
                                 !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(268) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(269))
                        {
                            int randomValue = random.Next(8);
                            switch (randomValue)
                            {
                                case 0: UseNormalAttack(ref a); break;
                                case 1: UseSkill(ref a, 262); break;
                                case 2: UseSkill(ref a, 263); break;
                                case 3: UseSkill(ref a, 264); break;
                                case 4: UseSkill(ref a, 266); break;
                                case 5: UseSkill(ref a, 267); break;
                                case 6: UseSkill(ref a, 268); break;
                                case 7: UseSkill(ref a, 269); break;
                            }
                        }
                        else
                        {
                            int randomValue = random.Next(4);
                            switch (randomValue)
                            {
                                case 0: UseNormalAttack(ref a); break;
                                case 1: UseSkill(ref a, 262); break;
                                case 2: UseSkill(ref a, 263); break;
                                case 3: UseSkill(ref a, 266); break;
                            }
                        }
                    }
                }
            }
        }

        private static void BossDevilDanteAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Boss HP%: " + currentHpPercent);
            //MelonLogger.Msg("Boss HP: " + a.work.hp);

            if (EnemyPartyDebuffed(1) && random.Next(4) == 0)
            {
                UseSkill(ref a, 274);
            }
            else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(264) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(267) && 
                     !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(268) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(269))
            {
                int randomValue = random.Next(8);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 262); break;
                    case 2: UseSkill(ref a, 263); break;
                    case 3: UseSkill(ref a, 264); break;
                    case 4: UseSkill(ref a, 266); break;
                    case 5: UseSkill(ref a, 267); break;
                    case 6: UseSkill(ref a, 268); break;
                    case 7: UseSkill(ref a, 269); break;
                }
            }
            else
            {
                int randomValue = random.Next(4);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 262); break;
                    case 2: UseSkill(ref a, 263); break;
                    case 3: UseSkill(ref a, 266); break;
                }
            }
        }

        private static void RaidouTamLinAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            int randomValue = random.Next(3);
            switch (randomValue)
            {
                case 0: UseNormalAttack(ref a); break;
                case 1: UseSkill(ref a, 103); break;
                case 2: UseSkill(ref a, 64); break;
            }
        }

        private static void RaidouGdonAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            int randomValue = random.Next(3);
            switch (randomValue)
            {
                case 0: UseNormalAttack(ref a); break;
                case 1: UseSkill(ref a, 5); break;
                case 2: UseSkill(ref a, 121); break;
            }
        }

        private static void RaidouVritraAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            int randomValue = random.Next(3);
            switch (randomValue)
            {
                case 0: UseNormalAttack(ref a); break;
                case 1: UseSkill(ref a, 177); break;
                case 2: UseSkill(ref a, 121); break;
            }
        }

        private static void RaidouJackFrostAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            int randomValue = random.Next(3);
            switch (randomValue)
            {
                case 0: UseNormalAttack(ref a); break;
                case 1: UseSkill(ref a, 463); break;
                case 2: UseSkill(ref a, 11); break;
            }
        }

        private static void BossMetatronAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Metatron HP%: " + currentHpPercent);
            //MelonLogger.Msg("Metatron HP: " + a.work.hp);

            if (currentHpPercent <= 75 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            if (currentHpPercent <= 40 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;

            if (actionTrackers[a.work.id].phase == 1)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                {
                    UseSkill(ref a, 422); return;
                }
                else if (actionTrackers[a.work.id].currentBattleTurnCount == 1)
                {
                    UseSkill(ref a, 31);
                }
                else if (actionTrackers[a.work.id].currentTurnActionCount == 1 && random.Next(2) == 0)
                {
                    if (AllyPartyBuffed(1) && random.Next(2) == 0)
                    {
                        UseSkill(ref a, 57); return;
                    }
                    else if (EnemyPartyDebuffed(1))
                    {
                        UseSkill(ref a, 77); return;
                    }
                }
                else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(6) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(31) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(431) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(27))
                {
                    UseNormalAttack(ref a);
                }
                else
                {
                    int randomValue = random.Next(8);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 6); break;
                        case 2: UseSkill(ref a, 6); break;
                        case 3: UseSkill(ref a, 31); break;
                        case 4: UseSkill(ref a, 31); break;
                        case 5: UseSkill(ref a, 431); break;
                        case 6: UseSkill(ref a, 431); break;
                        case 7: UseSkill(ref a, 27); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                if (actionTrackers[a.work.id].extraTurns < 2)
                {
                    UseSkill(ref a, 422); return;
                }
                if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(458) ||
                    !EnemyPartyBuffed(3) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(458) && random.Next(3) != 0)
                {
                    UseSkill(ref a, 458);
                }
                else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(6) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(31) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(431) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(27))
                {
                    UseNormalAttack(ref a);
                }
                else
                {
                    int randomValue = random.Next(10);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 6); break;
                        case 2: UseSkill(ref a, 6); break;
                        case 3: UseSkill(ref a, 31); break;
                        case 4: UseSkill(ref a, 31); break;
                        case 5: UseSkill(ref a, 431); break;
                        case 6: UseSkill(ref a, 431); break;
                        case 7: UseSkill(ref a, 27); break;
                        case 8: UseSkill(ref a, 27); break;
                        case 9: UseSkill(ref a, 27); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 3)
            {
                if (actionTrackers[a.work.id].extraTurns < 2)
                {
                    UseSkill(ref a, 422); return;
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(235))
                {
                    UseSkill(ref a, 235);
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(424) ||
                    (actionTrackers[a.work.id].currentTurnActionCount >= 2 && !EnemyConcentrated(ref a) && random.Next(2) == 0))
                {
                    UseSkill(ref a, 424);
                }
                else if (actionTrackers[a.work.id].currentTurnActionCount >= 2 && !EnemyPartyBuffed(3) && 
                    !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(458) && random.Next(2) == 0)
                {
                    UseSkill(ref a, 458);
                }
                else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(6) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(31) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(431) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(27) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(235))
                {
                    UseNormalAttack(ref a);
                }
                else
                {
                    int randomValue = random.Next(8);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 6); break;
                        case 1: UseSkill(ref a, 31); break;
                        case 2: UseSkill(ref a, 431); break;
                        case 3: UseSkill(ref a, 27); break;
                        case 4: UseSkill(ref a, 235); break;
                        case 5: UseSkill(ref a, 235); break;
                        case 6: UseSkill(ref a, 235); break;
                        case 7: UseSkill(ref a, 235); break;
                    }
                }
            }
        }

        private static void BossBeelzebubFlyAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Beelzebub HP%: " + currentHpPercent);
            //MelonLogger.Msg("Beelzebub HP: " + a.work.hp);

            if (currentHpPercent <= 75 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            if (currentHpPercent <= 25 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;

            if (actionTrackers[a.work.id].phase == 1)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                {
                    UseSkill(ref a, 422); return;
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(57) &&
                    (a.data.playerpcnt == 1 && AllyPartyBuffed(3)) || (a.data.playerpcnt > 1 && AllyPartyBuffed(2)))
                {
                    UseSkill(ref a, 57);
                }
                else if (actionTrackers[a.work.id].currentBattleTurnCount == 1 || 
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(18) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(27) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(462))
                {
                    UseSkill(ref a, 258);
                }
                else
                {
                    int randomValue = random.Next(8);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 258); break;
                        case 1: UseSkill(ref a, 258); break;
                        case 2: UseSkill(ref a, 258); break;
                        case 3: UseSkill(ref a, 18); break;
                        case 4: UseSkill(ref a, 18); break;
                        case 5: UseSkill(ref a, 462); break;
                        case 6: UseSkill(ref a, 462); break;
                        case 7: UseSkill(ref a, 27); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase >= 2)
            {
                if (actionTrackers[a.work.id].extraTurns < 2)
                {
                    UseSkill(ref a, 422); return;
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(259))
                {
                    UseSkill(ref a, 259);
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(226))
                {
                    UseSummonSkill(ref a, 226, 356);
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(57) && 
                    (a.data.playerpcnt == 1 && AllyPartyBuffed(3)) || (a.data.playerpcnt > 1 && AllyPartyBuffed(2)))
                {
                    UseSkill(ref a, 57);
                }
                else if (actionTrackers[a.work.id].phase == 2 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(226) && 
                    actionTrackers[a.work.id].currentTurnActionCount >= 2 && a.data.press4_p == 1 && a.data.press4_ten <= 2
                    && random.Next(3) != 0)
                {
                    UseSummonSkill(ref a, 226, 356);
                }
                else if (actionTrackers[a.work.id].phase == 3 && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(252) &&
                    actionTrackers[a.work.id].currentTurnActionCount >= 2 && a.data.press4_p <= 2 && a.data.press4_ten <= 2
                     && random.Next(3) != 0)
                {
                    UseSummonSkill(ref a, 252, 356);
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(77) && EnemyPartyDebuffed(1) && random.Next(2) == 0)
                {
                    UseSkill(ref a, 77);
                }
                else if (actionTrackers[a.work.id].currentBattleTurnCount == 1 ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(18) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(27) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(462) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(259))
                {
                    UseSkill(ref a, 258);
                }
                else
                {
                    int randomValue = random.Next(10);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 258); break;
                        case 1: UseSkill(ref a, 18); break;
                        case 2: UseSkill(ref a, 18); break;
                        case 3: UseSkill(ref a, 462); break;
                        case 4: UseSkill(ref a, 462); break;
                        case 5: UseSkill(ref a, 27); break;
                        case 6: UseSkill(ref a, 27); break;
                        case 7: UseSkill(ref a, 259); break;
                        case 8: UseSkill(ref a, 259); break;
                        case 9: UseSkill(ref a, 259); break;
                    }
                }
            }
            if (a.work.nowindex == 17)
                UseSkill(ref a, 18);
            else if (a.work.nowindex == 24)
                UseSkill(ref a, 462);
        }

        private static void NasuFlyAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (!EnemyFocused(ref a))
                UseSkill(ref a, 224);
            else
                UseSkill(ref a, 116);
        }

        private static void BossLuciferAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Lucifer HP%: " + currentHpPercent);
            //MelonLogger.Msg("Lucifer HP: " + a.work.hp);

            if (currentHpPercent <= 70 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            if (currentHpPercent <= 40 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;

            if (actionTrackers[a.work.id].phase == 1)
            {
                if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(272))
                {
                    UseSkill(ref a, 272);
                    actionTrackers[a.work.id].extraTurns = 2;
                    actionTrackers[a.work.id].scriptVar1 = 1;
                }
                else if (actionTrackers[a.work.id].currentTurnActionCount == 1 &&
                    actionTrackers[a.work.id].currentBattleTurnCount >= 3 &&
                    (actionTrackers[a.work.id].currentBattleTurnCount % 2) == 0 && 
                    !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(57) &&
                    !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(77))
                {
                    if (AllyPartyBuffed(1) && random.Next(2) == 0)
                    {
                        UseSkill(ref a, 57);
                    }
                    else if (EnemyPartyDebuffed(1))
                    {
                        UseSkill(ref a, 77);
                    }
                }
                else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(271) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(273) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(491) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(492) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(493) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(494) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(100) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(135))
                {
                    UseSkill(ref a, 270);
                }
                else
                {
                    int randomValue = random.Next(8);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 270); break;
                        case 1: UseSkill(ref a, 271); break;
                        case 2: UseSkill(ref a, 491); break;
                        case 3: UseSkill(ref a, 492); break;
                        case 4: UseSkill(ref a, 493); break;
                        case 5: UseSkill(ref a, 494); break;
                        case 6: UseSkill(ref a, 100); break;
                        case 7: UseSkill(ref a, 135); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                if (actionTrackers[a.work.id].currentTurnActionCount == 1 && 
                    (actionTrackers[a.work.id].currentBattleTurnCount % 4) == 0)
                {
                    UseSkill(ref a, 273);
                }
                else if (actionTrackers[a.work.id].currentTurnActionCount == 1 &&
                    (actionTrackers[a.work.id].currentBattleTurnCount % 2) == 0 &&
                    !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(57) &&
                    !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(77))
                {
                    if (AllyPartyBuffed(1) && random.Next(2) == 0)
                    {
                        UseSkill(ref a, 57);
                    }
                    else if (EnemyPartyDebuffed(1))
                    {
                        UseSkill(ref a, 77);
                    }
                }
                else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(271) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(273) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(491) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(492) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(493) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(494) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(100) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(135))
                {
                    UseSkill(ref a, 270);
                }
                else
                {
                    int randomValue = random.Next(8);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 270); break;
                        case 1: UseSkill(ref a, 271); break;
                        case 2: UseSkill(ref a, 491); break;
                        case 3: UseSkill(ref a, 492); break;
                        case 4: UseSkill(ref a, 493); break;
                        case 5: UseSkill(ref a, 494); break;
                        case 6: UseSkill(ref a, 100); break;
                        case 7: UseSkill(ref a, 135); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 3)
            {
                if (((actionTrackers[a.work.id].currentBattleTurnCount - 1) % 2) == 0 && a.data.press4_ten == 1 && a.data.press4_p <= 1)
                {
                    datNormalSkill.tbl[272].hpn = Convert.ToInt16(90 - random.Next(41));
                    UseSkill(ref a, 272);
                    switch (actionTrackers[a.work.id].scriptVar1)
                    {
                        case 1: actionTrackers[a.work.id].scriptVar1 = 2; break;
                        case 2: actionTrackers[a.work.id].scriptVar1 = 3; break;
                        case 3: actionTrackers[a.work.id].scriptVar1 = 4; break;
                        case 4: actionTrackers[a.work.id].scriptVar1 = 1; break;
                    }
                }
                else if (actionTrackers[a.work.id].currentTurnActionCount == 1 && 
                    (actionTrackers[a.work.id].currentBattleTurnCount % 2) == 0 && a.data.press4_p == 0)
                {
                    UseSkill(ref a, 273);
                }
                else if (actionTrackers[a.work.id].currentTurnActionCount == 1 &&
                    (actionTrackers[a.work.id].currentBattleTurnCount % 2) == 0 &&
                    !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(57) &&
                    !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(77))
                {
                    if (AllyPartyBuffed(1) && random.Next(2) == 0)
                    {
                        UseSkill(ref a, 57);
                    }
                    else if (EnemyPartyDebuffed(1))
                    {
                        UseSkill(ref a, 77);
                    }
                }
                else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(271) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(273) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(491) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(492) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(493) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(494) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(100) ||
                    actionTrackers[a.work.id].skillsUsedThisTurn.Contains(135))
                {
                    UseSkill(ref a, 270);
                }
                else
                {
                    int randomValue = random.Next(8);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 270); break;
                        case 1: UseSkill(ref a, 271); break;
                        case 2: UseSkill(ref a, 491); break;
                        case 3: UseSkill(ref a, 492); break;
                        case 4: UseSkill(ref a, 493); break;
                        case 5: UseSkill(ref a, 494); break;
                        case 6: UseSkill(ref a, 100); break;
                        case 7: UseSkill(ref a, 135); break;
                    }
                }
            }
        }

        private static void BossPaleRiderAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Pale Rider HP%: " + currentHpPercent);
            //MelonLogger.Msg("Pale Rider HP: " + a.work.hp);

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 423);
            else if (actionTrackers[a.work.id].currentBattleTurnCount == 1)
            {
                if (a.data.enemypcnt < 3)
                {
                    UseSummonSkill(ref a, 226, 358);
                }
            }
            else if (a.work.nowindex == 226)
            {
                if (!actionTrackers.ContainsKey(358))
                    actionTrackers.Add(358, new ActionTracker());
            }
            else if (a.work.nowindex == 12 || a.work.nowindex == 102)
            {
                int randomValue = random.Next(3);
                switch (randomValue)
                {
                    case 0: UseSkill(ref a, 63); break;
                    case 1: UseSkill(ref a, 102); break;
                    case 2: UseSkill(ref a, 451); break;
                }
            }
        }

        private static void BossWhiteRiderAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("White Rider HP%: " + currentHpPercent);
            //MelonLogger.Msg("White Rider HP: " + a.work.hp);

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 423);
            else if (actionTrackers[a.work.id].currentBattleTurnCount == 1)
            {
                if (a.data.enemypcnt < 3)
                {
                    UseSummonSkill(ref a, 226, 359);
                }
            }
            else if (a.work.nowindex == 226)
            {
                if (!actionTrackers.ContainsKey(359))
                    actionTrackers.Add(359, new ActionTracker());
            }
        }

        private static void BossRedRiderAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Red Rider HP%: " + currentHpPercent);
            //MelonLogger.Msg("Red Rider HP: " + a.work.hp);

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 423);
            else if (actionTrackers[a.work.id].currentBattleTurnCount == 1)
            {
                if (a.data.enemypcnt < 3)
                {
                    UseSummonSkill(ref a, 226, 360);
                }
            }
            else if (a.work.nowindex == 226)
            {
                if (!actionTrackers.ContainsKey(360))
                    actionTrackers.Add(360, new ActionTracker());
            }
        }

        private static void BossBlackRiderAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Black Rider HP%: " + currentHpPercent);
            //MelonLogger.Msg("Black Rider HP: " + a.work.hp);

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 423);
            else if (actionTrackers[a.work.id].currentBattleTurnCount == 1)
            {
                if (a.data.enemypcnt < 3)
                {
                    UseSummonSkill(ref a, 226, 361);
                }
            }
            else if (a.work.nowindex == 226)
            {
                if (!actionTrackers.ContainsKey(361))
                    actionTrackers.Add(361, new ActionTracker());
            }
            else if (AllyPartyBuffed(1) && random.Next(3) == 0)
                UseSkill(ref a, 57);
            else if (a.work.nowindex == 27)
                UseSkill(ref a, 26);
        }

        private static void BossMatadorAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Matador HP%: " + currentHpPercent);
            //MelonLogger.Msg("Matador HP: " + a.work.hp);

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 422);
            else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(276))
                UseSkill(ref a, 276);
            else if (a.work.nowindex == 22)
                UseSkill(ref a, 443);
            else if (a.work.nowindex == 275)
            {
                if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(275))
                    UseSkill(ref a, 275);
                else
                    UseNormalAttack(ref a);
            }
        }

        private static void BossHellBikerAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Hell Biker HP%: " + currentHpPercent);
            //MelonLogger.Msg("Hell Biker HP: " + a.work.hp);
            if (currentHpPercent <= 50 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;

            if (actionTrackers[a.work.id].phase == 1)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                    UseSkill(ref a, 422);
                else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
                {
                    UseSkill(ref a, 282);
                }
                else if (EnemyPartyDebuffed(1) && random.Next(4) == 0)
                {
                    UseSkill(ref a, 77);
                }
                else
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: HellBikerAttackPattern(ref a); break;
                        case 1: HellBikerAttackPattern(ref a); break;
                        case 2: UseSkill(ref a, 282); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                if (actionTrackers[a.work.id].extraTurns < 2)
                {
                    UseSkill(ref a, 422); return;
                }
                else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(284))
                {
                    UseSkill(ref a, 284);
                }
                else if (actionTrackers[a.work.id].currentTurnActionCount >= 3 && EnemyPartyDebuffed(1) && random.Next(4) == 0)
                {
                    UseSkill(ref a, 77);
                }
                else if (!EnemyPartyBuffed(3, 4) && !EnemyPartyBuffed(3, 6) && random.Next(2 + Convert.ToInt32(actionTrackers[a.work.id].skillsUsedThisTurn.Contains(284))) == 0)
                {
                    UseSkill(ref a, 284);
                }
                else
                {
                    int randomValue = random.Next(6);
                    switch (randomValue)
                    {
                        case 0: HellBikerAttackPattern(ref a); break;
                        case 1: HellBikerAttackPattern(ref a); break;
                        case 2: HellBikerAttackPattern(ref a); break;
                        case 3: UseSkill(ref a, 282); break;
                        case 4: UseSkill(ref a, 283); break;
                        case 5: UseSkill(ref a, 283); break;
                    }
                }
            }
        }

        private static void BossDaisoujouAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Daisoujou HP%: " + currentHpPercent);
            //MelonLogger.Msg("Daisoujou HP: " + a.work.hp);

            if (currentHpPercent <= 80 && actionTrackers[a.work.id].phase == 1)
                actionTrackers[a.work.id].phase = 2;
            else if (currentHpPercent <= 50 && actionTrackers[a.work.id].phase == 2)
                actionTrackers[a.work.id].phase = 3;

            if (actionTrackers[a.work.id].phase == 1)
            {
                if (actionTrackers[a.work.id].extraTurns < 1)
                    UseSkill(ref a, 422);
                else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
                {
                    UseSkill(ref a, 279);
                }
                else
                {
                    int randomValue = random.Next(2);
                    switch (randomValue)
                    {
                        case 0: UseNormalAttack(ref a); break;
                        case 1: UseSkill(ref a, 279); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 2)
            {
                if (!EnemyPartyBuffed(3, 5) && random.Next(2 + Convert.ToInt32(actionTrackers[a.work.id].skillsUsedThisTurn.Contains(67))) == 0)
                {
                    UseSkill(ref a, 67);
                }
                else if (AllyPartyBuffed(1) && random.Next(3) == 0)
                {
                    UseSkill(ref a, 57);
                }
                else
                {
                    int randomValue = random.Next(3);
                    switch (randomValue)
                    {
                        case 0: UseSkill(ref a, 279); break;
                        case 1: UseSkill(ref a, 30); break;
                        case 2: UseSkill(ref a, 34); break;
                    }
                }
            }
            else if (actionTrackers[a.work.id].phase == 3)
            {
                if (actionTrackers[a.work.id].extraTurns < 2)
                {
                    UseSkill(ref a, 422); return;
                }
                else if (!EnemyPartyBuffed(3, 5) && random.Next(3 + Convert.ToInt32(actionTrackers[a.work.id].skillsUsedThisTurn.Contains(67))) == 0)
                {
                    UseSkill(ref a, 67);
                }
                else if (AllyPartyBuffed(1) && random.Next(4) == 0)
                {
                    UseSkill(ref a, 57);
                }
                else
                {
                    if (EnemyConcentrated(ref a))
                    {
                        int randomValue = random.Next(3);
                        switch (randomValue)
                        {
                            case 0: UseSkill(ref a, 278); break;
                            case 1: UseSkill(ref a, 30); break;
                            case 2: UseSkill(ref a, 34); break;
                        }
                    }
                    else
                    {
                        int randomValue = random.Next(6);
                        switch (randomValue)
                        {
                            case 0: UseSkill(ref a, 279); break;
                            case 1: UseSkill(ref a, 278); break;
                            case 2: UseSkill(ref a, 30); break;
                            case 3: UseSkill(ref a, 34); break;
                            case 4: UseSkill(ref a, 424); break;
                            case 5: UseSkill(ref a, 424); break;
                        }
                    }
                }
            }
        }

        private static void BossMotherHarlotAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Mother Harlot HP%: " + currentHpPercent);
            //MelonLogger.Msg("Mother Harlot HP: " + a.work.hp);

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 423);
            else if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(18))
                UseSkill(ref a, 18);
            else if (a.work.nowindex == 17)
                UseSkill(ref a, 18);
            else if (a.work.nowindex == 56)
                UseSkill(ref a, 205);
        }

        private static void BossTrumpeterAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            ushort currentHpPercent = BossCurrentHpPercent(ref a);
            //MelonLogger.Msg("Trumpeter HP%: " + currentHpPercent);
            //MelonLogger.Msg("Trumpeter HP: " + a.work.hp);

            if (actionTrackers[a.work.id].extraTurns < 1)
                UseSkill(ref a, 423);
            else if (actionTrackers[a.work.id].currentBattleTurnCount == 1 && !actionTrackers[a.work.id].skillsUsedThisBattle.Contains(158))
                UseSkill(ref a, 158);
            else if (actionTrackers[a.work.id].currentBattleTurnCount == 1 && !actionTrackers[a.work.id].skillsUsedThisBattle.Contains(203))
                UseSkill(ref a, 203);
            else if (AllyPartyMakarakarn())
                UseSkill(ref a, 159);
            else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(158) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(57))
                UseSkill(ref a, 57);
            else if (actionTrackers[a.work.id].skillsUsedThisTurn.Contains(159) && !actionTrackers[a.work.id].skillsUsedThisTurn.Contains(27))
                UseSkill(ref a, 27);
            else if (a.work.nowindex == 27)
                UseSkill(ref a, 27);
            else if (a.work.nowindex == 57)
                UseSkill(ref a, 57);
            else if (a.work.nowindex == 158)
                UseSkill(ref a, 158);
            else if (a.work.nowindex == 159)
                UseSkill(ref a, 159);
        }

        private static void BossLoaAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleActionCount == 1)
                UseSkill(ref a, 206);
            else if (a.work.nowindex == 34)
                UseSkill(ref a, 35);
            else if (a.work.nowindex == 118)
                UseSkill(ref a, 448);
            else if (a.work.nowindex == 197)
                UseSkill(ref a, 34);
        }

        private static void BossVirtueAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleActionCount == 1)
                UseSkill(ref a, 54);
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
                UseSkill(ref a, 68);
            else if (a.work.nowindex == 69)
                UseSkill(ref a, 68);
            //else
            //{
            //    bool tetrajaUp = false;
            //    var allyParty = a.data.party.Where(x => (x.partyindex == 4 || x.partyindex == 6) && dds3GlobalWork.DDS3_GBWK.unitwork[x.partyindex].hp != 0);
            //    foreach (var unit in allyParty)
            //    {
            //        if (unit.count[11] >= 1)
            //            tetrajaUp = true;
            //    }
            //    if (!tetrajaUp)
            //        UseSkill(ref a, 68);
            //}
        }

        private static void BossPowerAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleActionCount == 1)
                UseSkill(ref a, 64);
        }

        private static void BossLegionAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleActionCount == 1)
                UseSkill(ref a, 64);
            else if (a.work.nowindex == 67)
                UseSkill(ref a, 64);
        }

        private static void BossFlaurosAI(ref nbActionProcessData_t a, ref int code, ref int n)
        {
            if (actionTrackers[a.work.id].currentBattleActionCount == 1)
            {
                UseSkill(ref a, 423); return;
            }
            else if (actionTrackers[a.work.id].currentBattleActionCount == 2)
            {
                UseSkill(ref a, 64); return;
            }
            else
            {
                int randomValue = random.Next(6);
                switch (randomValue)
                {
                    case 0: UseNormalAttack(ref a); break;
                    case 1: UseSkill(ref a, 64); break;
                    case 2: UseSkill(ref a, 33); break;
                    case 3: UseSkill(ref a, 108); break;
                    case 4: UseSkill(ref a, 126); break;
                    case 5: UseSkill(ref a, 435); break;
                }
            }
        }

        //------------------------------------------------------------

        private static void UseNormalAttack(ref nbActionProcessData_t a)
        {
            a.work.nowcommand = 0;
            a.work.nowindex = 0;
        }

        private static void UseSkill(ref nbActionProcessData_t a, ushort skillId)
        {
            a.work.nowcommand = 1;
            a.work.nowindex = skillId;

            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(skillId)) actionTrackers[a.work.id].skillsUsedThisBattle.Add(skillId);
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(skillId)) actionTrackers[a.work.id].skillsUsedThisTurn.Add(skillId);
        }

        private static void UseSummonSkill(ref nbActionProcessData_t a, ushort skillId, ushort devilId)
        {
            a.aisummonid = devilId;
            if (!actionTrackers.ContainsKey(devilId))
                actionTrackers.Add(devilId, new ActionTracker());
            
            a.work.nowcommand = 1;
            a.work.nowindex = skillId;

            if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(skillId)) actionTrackers[a.work.id].skillsUsedThisBattle.Add(skillId);
            if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(skillId)) actionTrackers[a.work.id].skillsUsedThisTurn.Add(skillId);
        }

        private static void Pass(ref nbActionProcessData_t a)
        {
            a.work.nowcommand = 3;
            a.work.nowindex = 0;
        }

        private static void Flee(ref nbActionProcessData_t a)
        {
            a.work.nowcommand = 7;
            a.work.nowindex = 0;
        }

        private static void HellBikerAttackPattern(ref nbActionProcessData_t a)
        {
            if (actionTrackers[a.work.id].scriptVar1 == 0)
            {
                a.work.nowcommand = 0;
                a.work.nowindex = 0;
            }
            else if (actionTrackers[a.work.id].scriptVar1 == 1 || actionTrackers[a.work.id].scriptVar1 == 3)
            {
                ushort skillId = 281;
                a.work.nowcommand = 1;
                a.work.nowindex = skillId;

                if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(skillId)) actionTrackers[a.work.id].skillsUsedThisBattle.Add(skillId);
                if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(skillId)) actionTrackers[a.work.id].skillsUsedThisTurn.Add(skillId);
            }
            else
            {
                ushort skillId = 97;
                a.work.nowcommand = 1;
                a.work.nowindex = skillId;

                if (!actionTrackers[a.work.id].skillsUsedThisBattle.Contains(skillId)) actionTrackers[a.work.id].skillsUsedThisBattle.Add(skillId);
                if (!actionTrackers[a.work.id].skillsUsedThisTurn.Contains(skillId)) actionTrackers[a.work.id].skillsUsedThisTurn.Add(skillId);
            }
            actionTrackers[a.work.id].scriptVar1++;
            if (actionTrackers[a.work.id].scriptVar1 == 4)
                actionTrackers[a.work.id].scriptVar1 = 0;
        }

        private static void SetTargetingRule(ref int code, ref int n, int newCode, int newN)
        {
            // -Rules-
            // 0  - Default AI
            // 1  - Target lowest HP
            // 2  - Target affected by status
            // 3  - Target specific ID
            // 4  - Target light-aligned demons
            // 5  - Target dark-alighned demons
            // 6  - Target Demi-fiend
            // 7  - ???
            // 8  - Target randomly
            // 9  - Target lowest level???
            // 10 - Target lowest level
            code = newCode;
            n = newN;
        }

        private static ushort BossCurrentHpPercent(ref nbActionProcessData_t a)
        {
            ushort maxhp = a.work.maxhp;
            ushort currenthp = a.work.hp;
            return (ushort) ((currenthp*100)/maxhp);
        }

        private static bool EnemyFocused(ref nbActionProcessData_t a)
        {
            return a.party.count[15] != 0;
        }

        private static bool EnemyConcentrated(ref nbActionProcessData_t a)
        {
            return a.party.count[20] != 0;
        }

        private static bool AllyPartyBuffed(ushort threshold)
        {
            var allyParty = nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3 && dds3GlobalWork.DDS3_GBWK.unitwork[x.partyindex].flag != 0);
            foreach (var unit in allyParty)
            {
                for (int i = 4; i <= 8; i++)
                {
                    if (unit.count[i] >= threshold)
                        return true;
                }
            }
            return false;
        }

        private static bool AllyPartyDebuffed(ushort threshold)
        {
            var allyParty = nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3 && dds3GlobalWork.DDS3_GBWK.unitwork[x.partyindex].flag != 0);
            foreach (var unit in allyParty)
            {
                for (int i = 4; i <= 8; i++)
                {
                    if (unit.count[i] <= threshold * -1)
                        return true;
                }
            }
            return false;
        }

        private static bool AllyPartyDebuffed(ushort threshold, int type)
        {
            var allyParty = nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3 && dds3GlobalWork.DDS3_GBWK.unitwork[x.partyindex].flag != 0);
            foreach (var unit in allyParty)
            {
                if (unit.count[type] <= threshold * -1)
                    return true;
            }
            return false;
        }

        private static bool EnemyPartyBuffed(ushort threshold)
        {
            var allyParty = nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex >= 4 && dds3GlobalWork.DDS3_GBWK.unitwork[x.partyindex].flag != 0);
            foreach (var unit in allyParty)
            {
                for (int i = 4; i <= 8; i++)
                {
                    if (unit.count[i] >= threshold)
                        return true;
                }
            }
            return false;
        }

        private static bool EnemyPartyBuffed(ushort threshold, int type)
        {
            var allyParty = nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex >= 4 && dds3GlobalWork.DDS3_GBWK.unitwork[x.partyindex].flag != 0);
            foreach (var unit in allyParty)
            {
                if (unit.count[type] >= threshold)
                    return true;
            }
            return false;
        }

        private static bool EnemyPartyDebuffed(ushort threshold)
        {
            var allyParty = nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex >= 4 && dds3GlobalWork.DDS3_GBWK.unitwork[x.partyindex].flag != 0);
            foreach (var unit in allyParty)
            {
                for (int i = 4; i <= 8; i++)
                {
                    if (unit.count[i] <= threshold * -1)
                        return true;
                }
            }
            return false;
        }

        private static bool AllyPartyStatus(ushort status)
        {
            var allyParty = nbMainProcess.nbGetMainProcessData().form.Where(x => x.formindex <= 3);
            try
            {
                foreach (var unit in allyParty)
                {
                    if (nbMainProcess.nbGetUnitWorkFromFormindex(unit.formindex).badstatus == status && nbMainProcess.nbGetUnitWorkFromFormindex(unit.formindex).flag != 0)
                        return true;
                }
            } catch { }
            return false;
        }

        private static bool AllyPartyTetrakarn()
        {
            var allyParty = nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3);
            foreach (var unit in allyParty)
            {
                if (unit.count[14] >= 1)
                    return true;
            }
            return false;
        }

        private static bool AllyPartyMakarakarn()
        {
            var allyParty = nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3);
            foreach (var unit in allyParty)
            {
                if (unit.count[13] >= 1)
                    return true;
            }
            return false;
        }

        private static bool AllyPartyAllImmuneToAttr(int nskill, int attr)
        {
            var allyParty = nbMainProcess.nbGetMainProcessData().party.Where(x => x.partyindex <= 3);
            foreach (var unit in allyParty)
            {
                try
                {
                    var work = nbMainProcess.nbGetUnitWorkFromFormindex(unit.formindex);
                    bool hasImmunityPassive = false;
                    foreach (var passive in immunityPassives[attr])
                    {
                        if (datCalc.datCheckSyojiSkill(work, passive) != 0)
                            hasImmunityPassive = true;
                    }

                    if (!new uint[] { 65536, 131072, 262144 }.Contains(nbCalc.nbGetAisyo(nskill, unit.formindex, attr)) && hasImmunityPassive == false)
                        return false;
                } catch { }
            }
            return true;
        }
    }

    internal class ActionTracker
    {
        public short currentBattleTurnCount;
        public short currentBattleActionCount;
        public short currentTurnActionCount;
        public short extraTurns;
        public short phase;
        public short scriptVar1;
        public List<ushort> skillsUsedThisBattle;
        public List<ushort> skillsUsedThisTurn;
        

        public ActionTracker()
        {
            this.currentBattleTurnCount = 0;
            this.currentBattleActionCount = 0;
            this.currentTurnActionCount = 0;
            this.extraTurns = 0;
            this.phase = 1;
            this.scriptVar1 = 0;
            this.skillsUsedThisBattle = new List<ushort>();
            this.skillsUsedThisTurn = new List<ushort>();
        }
    }
}