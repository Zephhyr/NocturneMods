using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2Cppnewbattle_H;
using Il2Cppeffect_H;
using UnityEngine;

namespace NewBossAI
{
    internal partial class NewBossAI : MelonMod
    {
        [HarmonyPatch(typeof(datSkillName), nameof(datSkillName.Get))]
        private class SkillNamesPatch
        {
            public static bool Prefix(ref int id, ref string __result)
            {
                switch (id)
                {
                    case 88: __result = "Beast Eye"; return false;
                    case 89: __result = "Dragon Eye"; return false;
                    case 219: __result = "Rage"; return false;
                    case 220: __result = "Psycho Rage"; return false;
                    default: return true;
                }
            }
        }

        [HarmonyPatch(typeof(datSkillHelp_msg), nameof(datSkillHelp_msg.Get))]
        private class SkillDescriptionPatch
        {
            public static bool Prefix(ref int id, ref string __result)
            {
                switch (id)
                {
                    case 69: __result = "Repels Magical attacks \nfor one ally once \nnext turn."; return false; // Makarakarn
                    case 70: __result = "Repels Physical attacks \nfor one ally once \nnext turn."; return false; // Tetrakarn
                    case 296: __result = "Guarantees escape \nwhen possible."; return false; // Fast Retreat
                    case 298: __result = "Prevents being attacked \nfrom behind."; return false; // Mind's Eye
                    case 299: __result = "Greatly raises critical \nhit rate of normal attacks."; return false; // Might
                    case 300: __result = "Drastically raises critical \nhit rate of normal attacks \nduring full Kagutsuchi."; return false; // Bright Might
                    case 301: __result = "Drastically raises critical \nhit rate of normal attacks \nduring new Kagutsuchi."; return false; // Dark Might
                    case 313: __result = "Protects against Physical Attacks"; return false; // Anti-Phys
                    case 314: __result = "Protects against Fire Attacks"; return false; // Anti-Fire
                    case 315: __result = "Protects against Ice Attacks"; return false; // Anti-Ice
                    case 316: __result = "Protects against Elec Attacks"; return false; // Anti-Elec
                    case 317: __result = "Protects against Force Attacks"; return false; // Anti-Force
                    case 354: __result = "Earn 100% EXP when \nnot participating in battle."; return false; // Watchful
                    case 357: __result = "Attacks ignore all resistances \nexcept Repel."; return false; // Pierce
                    default: return true;
                }
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetAddPressPacket))]
        private class BeastEyePatch1
        {
            public static void Postfix(ref nbActionProcessData_t a, ref int nskill)
            {
                if (a.newaddpresstype == 15 && nskill == 88)
                {
                    if (nskill == 88)
                    {
                        a.newaddpresstype = 18;
                        actionTrackers[a.work.id].extraTurns += 1;
                    }
                    else if (nskill == 89)
                    {
                        a.newaddpresstype = 19;
                        actionTrackers[a.work.id].extraTurns += 2;
                    }
                }
            }
        }
        [HarmonyPatch(typeof(nbMakePacket), nameof(nbMakePacket.nbMakeNewPressPacket))]
        private class BeastEyePatch2
        {
            public static void Postfix(ref int startframe, ref int uniqueid, ref int ptype, ref nbFormation_t form)
            {
                if (ptype == 18)
                {
                    nbMakePacket.nbAddNewPressPacket(startframe, uniqueid, 1, 1);
                    nbHelpProcess.nbDispText("Turn Count increased!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (ptype == 19)
                {
                    nbMakePacket.nbAddNewPressPacket(startframe, uniqueid, 2, 2);
                    nbHelpProcess.nbDispText("Turn Count increased!", string.Empty, 2, 45, 2315190144, false);
                }
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetAllPacket))]
        private class RemoveFreezeAndShockPatch
        {
            public static void Postfix(ref nbActionProcessData_t a, ref int koukatype, ref int nskill, ref int sformindex, ref int dformindex, 
                                       ref int cnt, ref int frame, ref float koukaritu)
            {
                datUnitWork_t target = nbMainProcess.nbGetUnitWorkFromFormindex(dformindex);
                if (datNormalSkill.tbl[nskill].koukatype == 0 && (target.badstatus == 1 || target.badstatus == 2))
                {
                    var form = a.data.form[dformindex];
                    nbMakePacket.nbMakeBadKaifukuPacket(frame, a.uniqueid, ref form);
                }
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetHitType))]
        private class CritPassivesPatch
        {
            public static void Postfix(ref nbActionProcessData_t ad, ref int nskill, ref int sformindex, ref int dformindex, ref int __result)
            {
                if (__result == 1 && (ad.autoskill == 300 || ad.autoskill == 301))
                {
                    __result = random.Next(2);
                    ad.autoskill = 0;
                }
                else if (ad.autoskill == 299)
                    ad.autoskill = 0;
            }
        }


        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbCheckBackAttack))]
        private class MindsEyePatch
        {
            public static void Postfix(ref int __result)
            {
                // If someone has Mind's Eye, then always avoid back attacks
                if (datCalc.datCheckSkillInParty(298) == 1) __result = 0;
            }
        }

        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datExecSkill))]
        private class OutOfBattleSkillPatch
        {
            public static void Postfix(ref int nskill)
            {
                // If using an hourglass, set the Kagutsuchi phase to full
                if (nskill == 78)
                {
                    if (evtMoon.evtGetAgeOfMoon16() != 8)
                    {
                        // If the full Kagutsuchi has already passed
                        if (evtMoon.evtGetAgeOfMoon16() > 8)
                        {
                            // Clear all effects that last "until a new kagutsuchi"
                            fldMain.fldEsutoMaClearMsg();
                            fldMain.fldRiberaMaClearMsg();
                            fldMain.fldRifutoMaClearMsg();
                            fldMain.fldLightMaClearMsg();
                        }

                        dds3GlobalWork.DDS3_GBWK.Moon.MoveCnt = 0; // Beginning of a new phase
                        evtMoon.evtSetAgeOfMoon(8); // Set Kagutsuchi's phase to full
                    }
                }
            }
        }

        //------------------------------------------------------------

        private static void OverWriteSkillEffect(ushort targetId, ushort originId)
        {
            datNormalSkillVisual.tbl[targetId] = datNormalSkillVisual.tbl[originId];
            nbActionProcess.sobedtbl[targetId] = nbActionProcess.sobedtbl[originId];
            nbCamera_SkillPtrTable.tbl[targetId] = nbCamera_SkillPtrTable.tbl[originId];
        }

        private static void ApplySkillChanges()
        {
            // Normal Skills
            Zio();
            Makarakarn();
            Tetrakarn();
            HourglassSkill();
            NewBeastEye();
            NewDragonEye();

            //Passive Skills
            Might();
            DrainAttack();
        }

        private static void Zio()
        {
            //datNormalSkill.tbl[13];
        }

        private static void Makarakarn()
        {
            datNormalSkill.tbl[69].targettype = 0;
        }

        private static void Tetrakarn()
        {
            datNormalSkill.tbl[70].targettype = 0;
        }

        private static void HourglassSkill()
        {
            datSkill.tbl[78].capacity = 4;
            datSkill.tbl[78].skillattr = 15; // Utility skill
            datNormalSkill.tbl[78].koukatype = 1; // Not Physical
            datNormalSkill.tbl[78].program = 14; // Phase shift
            datNormalSkill.tbl[78].targetcntmax = 1;
            datNormalSkill.tbl[78].targetcntmin = 1;
            datNormalSkill.tbl[78].targettype = 3; // Field
        }

        private static void NewBeastEye()
        {
            datSkill.tbl[88].keisyoform = 512;
            datSkill.tbl[88].skillattr = 5;
            datNormalSkill.tbl[88].hojotype = 4096;
            datNormalSkill.tbl[88].hojopoint = 2;
            datNormalSkill.tbl[88].hpbase = 0;
            datNormalSkill.tbl[88].hpn = 50;
            datNormalSkill.tbl[88].hptype = 0;
            datNormalSkill.tbl[88].program = 13;
            datNormalSkill.tbl[88].use = 2;
            OverWriteSkillEffect(88, 219);
        }

        private static void NewDragonEye()
        {
            datSkill.tbl[89].keisyoform = 512;
            datSkill.tbl[89].skillattr = 5;
            datNormalSkill.tbl[89].hojotype = 4096;
            datNormalSkill.tbl[89].hojopoint = 2;
            datNormalSkill.tbl[89].hpbase = 0;
            datNormalSkill.tbl[89].hpn = 50;
            datNormalSkill.tbl[89].hptype = 0;
            datNormalSkill.tbl[89].program = 13;
            datNormalSkill.tbl[89].use = 2;
            OverWriteSkillEffect(89, 219);
        }

        private static void Might()
        {
            datSpecialSkill.tbl[11].n = 750;
        }

        private static void DrainAttack()
        {
            datSpecialSkill.tbl[14].n = 1;
        }
    }
}
