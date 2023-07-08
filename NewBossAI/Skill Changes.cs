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
        public static nbActionProcessData_t? actionProcessData;

        [HarmonyPatch(typeof(datSkillName), nameof(datSkillName.Get))]
        private class SkillNamesPatch
        {
            public static bool Prefix(ref int id, ref string __result)
            {
                switch (id)
                {            
                    // Vanilla Skills
                    case 80: __result = "Muscle Drink"; return false;    
                    case 81: __result = "Life Stone"; return false;      
                    case 82: __result = "Chakra Drop"; return false;     
                    case 83: __result = "Chakra Pot"; return false;      
                    case 84: __result = "Great Chakra"; return false;    
                    case 85: __result = "Soma Droplet"; return false;    
                    case 86: __result = "Soma"; return false;   
                    case 90: __result = "Poison Arrow"; return false;    
                    case 92: __result = "Bead of Life"; return false;                 
                    case 94: __result = "Medicine"; return false;                     
                    case 113: __result = "Venom Needle"; return false;      
                    case 219: __result = "Rage"; return false;           
                    case 220: __result = "Psycho Rage"; return false;    

                    // New Skills
                    case 422: __result = "Beast Eye"; return false;      
                    case 423: __result = "Dragon Eye"; return false;     
                    case 424: __result = "Concentrate"; return false;
                    case 425: __result = "Impaler's Charge"; return false;
                    case 426: __result = "Pulinpaon"; return false;      
                    case 427: __result = "Poison Volley"; return false;      
                    case 428: __result = "Poison Salvo"; return false;      
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
                    // Vanilla Skills
                    case 28: __result = "Low Light damage to one foe. \nChance to instakill when \nweak to Light."; return false; // Hama
                    case 29: __result = "High Light damage to one foe. \nChance to instakill when \nweak to Light."; return false; // Hamaon
                    case 30: __result = "Low Light damage to all foes. \nChance to instakill when \nweak to Light."; return false; // Mahama
                    case 31: __result = "High Light damage to all foes. \nChance to instakill when \nweak to Light."; return false; // Mahamaon
                    case 32: __result = "Low Dark damage to one foe. \nChance to instakill when \nweak to Dark."; return false; // Mudo
                    case 33: __result = "High Dark damage to one foe. \nChance to instakill when \nweak to Dark."; return false; // Mudoon
                    case 34: __result = "Low Dark damage to all foes. \nChance to instakill when \nweak to Dark."; return false; // Mamudo
                    case 35: __result = "High Dark damage to all foes. \nChance to instakill when \nweak to Dark."; return false; // Mamudoon
                    case 61: __result = "Low Mind damage to one foe. \nChance to inflict Panic."; return false; // Pulinpa
                    case 63: __result = "High Mind damage to all foes. \nChance to inflict Panic."; return false; // Tentarafoo
                    case 69: __result = "Repels Magical attacks \nfor one ally once \nnext turn."; return false; // Makarakarn
                    case 70: __result = "Repels Physical attacks \nfor one ally once \nnext turn."; return false; // Tetrakarn
                    case 90: __result = "Low Curse damage to one foe. \nMay inflict Poison."; return false; // Poison Arrow
                    case 224: __result = "More than doubles damage \nof next Physical attack."; return false; // Focus
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
                    
                    // New Skills
                    case 424: __result = "More than doubles damage \nof next Magical attack."; return false; // Concentrate
                    case 425: __result = "More than doubles damage \nof next attack and grants Pierce."; return false; // Impaler's Charge
                    case 426: __result = "High Mind damage to one foe. \nChance to inflict Panic."; return false; // Pulinpaon
                    case 427: __result = "Medium Curse damage to all foes. \nMay inflict Poison."; return false; // Poison Volley
                    case 428: __result = "High Curse damage to one foe. \nMay inflict Poison."; return false; // Poison Salvo
                    default: return true;
                }
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.InitActionProcessData))]
        private class ActionProcessDataPatch
        {
            public static void Postfix(ref nbActionProcessData_t __result)
            {
                actionProcessData = __result;
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetAddPressPacket))]
        private class BeastEyePatch1
        {
            public static void Postfix(ref nbActionProcessData_t a, ref int nskill)
            {
                actionProcessData = a;

                if (a.newaddpresstype == 15 && (nskill == 422 || nskill == 423))
                {
                    if (nskill == 422)
                    {
                        a.newaddpresstype = 18;
                        actionTrackers[a.work.id].extraTurns += 1;
                    }
                    else if (nskill == 423)
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
                actionProcessData = a;

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
                actionProcessData = ad;

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

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetKoukaBadDamage))]
        private class CheckStatusPatch
        {
            public static void Postfix(ref int nskill, int sformindex, int dformindex, float ai, int nvirtual, ref uint __result)
            {
                if (datSkill.tbl[nskill].skillattr == 6 || datSkill.tbl[nskill].skillattr == 7)
                {
                    int[] lightSkills = new int[] { 28, 29, 30, 31 };
                    int[] darkSkills = new int[] { 32, 33, 34, 35 };

                    var lightResistance = Convert.ToString(nbCalc.nbGetAisyo(nskill, dformindex, 6), 2);
                    var darkResistance = Convert.ToString(nbCalc.nbGetAisyo(nskill, dformindex, 7), 2);

                    if ((lightSkills.Contains(nskill) && !(lightResistance.Length == 32 && lightResistance[lightResistance.Length - 32] == '1' && lightResistance[lightResistance.Length - 21] == '0')) ||
                        (darkSkills.Contains(nskill) && !(darkResistance.Length == 32 && darkResistance[darkResistance.Length - 32] == '1' && darkResistance[darkResistance.Length - 21] == '0')))
                    {
                        __result = 0;
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
            //datSkill_t[] skills = new datSkill_t[512];
            //for (int i = 0; i < datSkill.tbl.Length; i++)
            //    skills[i] = datSkill.tbl[i];
            //for (int i = datSkill.tbl.Length; i < skills.Length; i++)
            //    skills[i] = new datSkill_t();
            //datSkill.tbl = skills;

            datNormalSkill_t[] normalSkills = new datNormalSkill_t[512];
            for (int i = 0; i < datNormalSkill.tbl.Length; i++)
                normalSkills[i] = datNormalSkill.tbl[i];
            for (int i = datNormalSkill.tbl.Length; i < normalSkills.Length; i++)
                normalSkills[i] = new datNormalSkill_t();
            datNormalSkill.tbl = normalSkills;

            fclKeisyoSkillLevel_t[] skillLevels = new fclKeisyoSkillLevel_t[512];
            for (int i = 0; i < tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Length; i++)
                skillLevels[i] = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[i];
            for (int i = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Length; i < skillLevels.Length; i++)
                skillLevels[i] = new fclKeisyoSkillLevel_t();
            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl = skillLevels;

            datNormalSkillVisual_t[] visuals = new datNormalSkillVisual_t[512];
            for (int i = 0; i < datNormalSkillVisual.tbl.Length; i++)
                visuals[i] = datNormalSkillVisual.tbl[i];
            for (int i = datNormalSkillVisual.tbl.Length; i < visuals.Length; i++)
                visuals[i] = new datNormalSkillVisual_t();
            datNormalSkillVisual.tbl = visuals;

            nbActionProcess.SOBED[] SOBEDs = new nbActionProcess.SOBED[512];
            for (int i = 0; i < nbActionProcess.sobedtbl.Length; i++)
                SOBEDs[i] = nbActionProcess.sobedtbl[i];
            for (int i = nbActionProcess.sobedtbl.Length; i < SOBEDs.Length; i++)
                SOBEDs[i] = new nbActionProcess.SOBED();
            nbActionProcess.sobedtbl = SOBEDs;

            nbCameraSkillPtr_t[] cameras = new nbCameraSkillPtr_t[513];
            for (int i = 0; i < nbCamera_SkillPtrTable.tbl.Length; i++)
                cameras[i] = nbCamera_SkillPtrTable.tbl[i];
            for (int i = nbCamera_SkillPtrTable.tbl.Length; i < cameras.Length; i++)
                cameras[i] = new nbCameraSkillPtr_t();
            nbCamera_SkillPtrTable.tbl = cameras;

            // Normal Skills
            Zio(13);
            Hama(28);
            Hamaon(29);
            Mahama(30);
            Mahamaon(31);
            Mudo(32);
            Mudoon(33);
            Mamudo(34);
            Mamudoon(35);
            Pulinpa(61);
            Makarakarn(69);
            Tetrakarn(70);
            HourglassSkill(78);
            PoisonArrow(90);
            Focus(224);

            NewBeastEye(422);
            NewDragonEye(423);
            Concentrate(424);
            ImpalersCharge(425);
            Pulinpaon(426);
            PoisonVolley(427);
            PoisonSalvo(428);
            
            // Passive Skills
            Might(11);
            DrainAttack(14);
        }

        // Physical Skills
        
        
        // Fire Skills


        // Ice Skills
        
        
        // Elec Skills

        private static void Zio(ushort id)
        {
            //datNormalSkill.tbl[id];
        }

        // Force Skills
        
        
        // Almighty Skills
        
        // Light Skills

        private static void Hama(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 10;
            datNormalSkill.tbl[id].magiclimit = 120;
        }

        private static void Hamaon(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datNormalSkill.tbl[id].badlevel = 50;
            datNormalSkill.tbl[id].hpn = 70;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 20;
            datNormalSkill.tbl[id].magiclimit = 220;
        }

        private static void Mahama(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datNormalSkill.tbl[id].badlevel = 20;
            datNormalSkill.tbl[id].hpn = 25;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 10;
            datNormalSkill.tbl[id].magiclimit = 120;
        }

        private static void Mahamaon(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 20;
            datNormalSkill.tbl[id].magiclimit = 220;
        }

        // Dark Skills

        private static void Mudo(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].hpn = 40;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 10;
            datNormalSkill.tbl[id].magiclimit = 120;
        }

        private static void Mudoon(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datNormalSkill.tbl[id].badlevel = 50;
            datNormalSkill.tbl[id].hpn = 70;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 20;
            datNormalSkill.tbl[id].magiclimit = 220;
        }

        private static void Mamudo(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datNormalSkill.tbl[id].badlevel = 20;
            datNormalSkill.tbl[id].hpn = 25;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 10;
            datNormalSkill.tbl[id].magiclimit = 120;
        }

        private static void Mamudoon(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].hpn = 60;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 20;
            datNormalSkill.tbl[id].magiclimit = 220;
        }

        // Curse Skills

        private static void PoisonArrow(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 64;
            datNormalSkill.tbl[id].cost = 6;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].magicbase = 10;
            datNormalSkill.tbl[id].magiclimit = 120;
            datNormalSkill.tbl[id].targettype = 0;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[id].Level = 0;
        }

        private static void PoisonVolley(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 8;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 64;
            datNormalSkill.tbl[id].cost = 25;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 35;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 20;
            datNormalSkill.tbl[id].magiclimit = 220;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[id].Level = 0;
            OverWriteSkillEffect(id, 90);
        }

        private static void PoisonSalvo(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 8;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 40;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 64;
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 70;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 20;
            datNormalSkill.tbl[id].magiclimit = 220;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[id].Level = 0;
            OverWriteSkillEffect(id, 90);
        }

        // Nerve Skills


        // Mind Skills

        private static void Pulinpa(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].hpn = 30;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].magicbase = 10;
            datNormalSkill.tbl[id].magiclimit = 120;
        }

        private static void Pulinpaon(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 10;
            datSkill.tbl[id].index = (short) id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 40;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 8;
            datNormalSkill.tbl[id].cost = 10;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 70;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 10;
            datNormalSkill.tbl[id].magiclimit = 120;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[id].Level = 0;
            OverWriteSkillEffect(id, 63);
        }

        private static void Tentarafoo(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].hpn = 55;
            datNormalSkill.tbl[id].magicbase = 10;
            datNormalSkill.tbl[id].magiclimit = 120;
        }

        // Self-Destruct Skills


        // Healing Skills


        // Support Skills

        private static void Makarakarn(ushort id)
        {
            datNormalSkill.tbl[id].targettype = 0;
        }

        private static void Tetrakarn(ushort id)
        {
            datNormalSkill.tbl[id].targettype = 0;
        }

        private static void Focus(ushort id)
        {
            datSkill.tbl[id].skillattr = 14;
        }

        private static void Concentrate(ushort id)
        {
            datSkill.tbl[id].capacity = 2;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 14;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 5;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 33554432;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 1;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[id].Level = 5;
            OverWriteSkillEffect(id, 224);
        }

        private static void ImpalersCharge(ushort id)
        {
            datSkill.tbl[id].capacity = 2;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 14;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 5;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 50331648;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 1;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[id].Level = 0;
            OverWriteSkillEffect(id, 224);
        }

        // Utility Skills

        private static void HourglassSkill(ushort id)
        {
            datSkill.tbl[id].capacity = 4;
            datSkill.tbl[id].skillattr = 15; // Utility skill
            datNormalSkill.tbl[id].koukatype = 1; // Not Physical
            datNormalSkill.tbl[id].program = 14; // Phase shift
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targettype = 3; // Field
        }

        // Enemy-Only Skills

        private static void NewBeastEye(ushort id)
        {
            datSkill.tbl[id].capacity = 2;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 15;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 1;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 2;
            datNormalSkill.tbl[id].hojotype = 4096;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 13;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[id].Level = 0;
            OverWriteSkillEffect(id, 219);
        }

        private static void NewDragonEye(ushort id)
        {
            datSkill.tbl[id].capacity = 2;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 512;
            datSkill.tbl[id].skillattr = 15;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 1;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 255;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 2;
            datNormalSkill.tbl[id].hojotype = 4096;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 13;
            datNormalSkill.tbl[id].targetarea = 9;
            datNormalSkill.tbl[id].targetcntmax = 1;
            datNormalSkill.tbl[id].targetcntmin = 1;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[id].Level = 0;
            OverWriteSkillEffect(id, 219);
        }

        // Passive Skills

        private static void Might(ushort id)
        {
            datSpecialSkill.tbl[id].n = 750;
        }

        private static void DrainAttack(ushort id)
        {
            datSpecialSkill.tbl[id].n = 1;
        }
    }
}
