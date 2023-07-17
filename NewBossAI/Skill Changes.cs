using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2Cppnewbattle_H;
using Il2Cppeffect_H;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
                    case 188: __result = "Punishment"; return false;      
                    case 189: __result = "Judgement Light"; return false;      
                    case 422: __result = "Beast Eye"; return false;      
                    case 423: __result = "Dragon Eye"; return false;     
                    case 424: __result = "Concentrate"; return false;
                    case 425: __result = "Impaler's Animus"; return false;
                    case 426: __result = "Sakura Rage"; return false;
                    case 427: __result = "Fang Breaker"; return false;
                    case 428: __result = "Defense Kuzushi"; return false;
                    case 429: __result = "Primal Force"; return false;
                    case 430: __result = "Chi Blast"; return false;
                    case 431: __result = "Revelation"; return false;
                    case 432: __result = "Gate of Hell"; return false;
                    case 433: __result = "Akashic Arts"; return false;
                    case 434: __result = "Bloodbath"; return false;
                    case 435: __result = "Scald"; return false;
                    case 436: __result = "Trisagion"; return false;
                    case 437: __result = "Refrigerate"; return false;
                    case 438: __result = "Cocytus"; return false;
                    case 439: __result = "Fimbulvetr"; return false;
                    case 440: __result = "Jolt"; return false;
                    case 441: __result = "Thunder Gods"; return false;
                    case 442: __result = "Thunder Reign"; return false;
                    case 443: __result = "Dervish"; return false;
                    case 444: __result = "Heavenly Cyclone"; return false;
                    case 445: __result = "Vayavya"; return false;
                    case 446: __result = "Wicked Curse"; return false;
                    case 447: __result = "Damnation"; return false;

                    case 456: __result = "Pulinpaon"; return false;      
                    case 457: __result = "Poison Volley"; return false;      
                    case 458: __result = "Poison Salvo"; return false;      
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
                    case 276: __result = "Maximizes own Evasion/Hit Rate."; return false; // Red Capote
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
                    case 188: __result = "Light: Chance to instakill one foe."; return false; // Punishment
                    case 189: __result = "Light: Chance to instakill all foes."; return false; // Judgement Light
                    case 424: __result = "More than doubles damage \nof next Magical attack."; return false; // Concentrate
                    case 425: __result = "More than doubles damage \nof next attack and grants Pierce."; return false; // Impaler's Animus
                    case 426: __result = "High Physical damage to all foes. \nChance to inflict Charm."; return false; // Sakura Rage
                    case 427: __result = "Low Physical damage to one foe. \nLowers target's Physical Attack."; return false; // Fang Breaker
                    case 428: __result = "Low Physical damage to one foe. \nLowers target's Defense."; return false; // Defense Kuzushi
                    case 429: __result = "Massive Physical damage to one foe."; return false; // Primal Force
                    case 430: __result = "Low Physical damage to all foes. \nHigh critial rate."; return false; // Chi Blast
                    case 431: __result = "High Physical damage to all foes. \nChance to inflict Mute."; return false; // Revelation
                    case 432: __result = "High Physical damage to all foes. \nChance to inflict Stone."; return false; // Gate of Hell
                    case 433: __result = "High Physical damage to one foe."; return false; // Akashic Arts
                    case 434: __result = "High Physical damage to random foes. \nHigh critial rate."; return false; // Bloodbath
                    case 435: __result = "Low Fire damage to all foes. \nLowers targets' Physical Attack."; return false; // Scald
                    case 436: __result = "Massive Fire damage to all foes."; return false; // Trisagion
                    case 437: __result = "Low Ice damage to one foe. \nLowers targets' Evasion/Hit Rate."; return false; // Refrigerate
                    case 438: __result = "High Ice damage to random foes."; return false; // Cocytus
                    case 439: __result = "Massive Ice damage to all foes."; return false; // Fimbulvetr
                    case 440: __result = "Low Elec damage to one foe. \nHigh chance to inflict shock"; return false; // Jolt
                    case 441: __result = "Massive Elec damage to one foe."; return false; // Thunder Gods
                    case 442: __result = "Massive Elec damage to all foes."; return false; // Thunder Reign
                    case 443: __result = "Low Force damage to all foes. \nLowers targets' Evasion"; return false; // Dervish
                    case 444: __result = "High Force damage to random foes."; return false; // Heavenly Cyclone
                    case 445: __result = "Massive Force damage to all foes."; return false; // Vayavya
                    case 446: __result = "Dark: Chance to instakill one foe."; return false; // Wicked Curse
                    case 447: __result = "Dark: Chance to instakill all foes."; return false; // Damnation

                    case 456: __result = "High Mind damage to one foe. \nChance to inflict Panic."; return false; // Pulinpaon
                    case 457: __result = "Medium Curse damage to all foes. \nMay inflict Poison."; return false; // Poison Volley
                    case 458: __result = "High Curse damage to one foe. \nMay inflict Poison."; return false; // Poison Salvo
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

        [HarmonyPatch(typeof(nbHelpProcess), nameof(nbHelpProcess.nbDispText))]
        private class DispTextPatch
        {
            public static void Prefix(ref string text1, ref string text2, ref int type)
            {
                if (type == 1 && actionProcessData.work.nowcommand == 1)
                {
                    switch (actionProcessData.work.nowindex)
                    {
                        case 54: type = 0; text1 = "Decreased enemy's Defense!"; break;
                        case 276: type = 0; text1 = "Evasion/Hit Rate maximized!"; break;
                        default: break;
                    }
                    
                }
            }
        }

        //------------------------------------------------------------

        private static void OverWriteSkillEffect(ushort targetId, ushort originId)
        {
            datNormalSkillVisual.tbl[targetId] = new datNormalSkillVisual_t { 
                motion = datNormalSkillVisual.tbl[originId].motion,
                animetype = datNormalSkillVisual.tbl[originId].animetype,
                hatudo = datNormalSkillVisual.tbl[originId].hatudo,
                bedno = datNormalSkillVisual.tbl[originId].bedno
            };
            nbActionProcess.sobedtbl[targetId] = new nbActionProcess.SOBED {
                keyname = nbActionProcess.sobedtbl[originId].keyname,
                bed_fname = nbActionProcess.sobedtbl[originId].bed_fname,
                se0_str = nbActionProcess.sobedtbl[originId].se0_str,
                se1_str = nbActionProcess.sobedtbl[originId].se1_str,
                tga_fname = nbActionProcess.sobedtbl[originId].tga_fname,
                pbdata = nbActionProcess.sobedtbl[originId].pbdata
            };
            nbCamera_SkillPtrTable.tbl[targetId] = new nbCameraSkillPtr_t {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[originId].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[originId].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[originId].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[originId].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[originId].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[originId].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[originId].anim
            };
        }

        private static void OverWriteSkillEffect(ushort targetId, ushort animOriginId, ushort effectOriginId)
        {
            datNormalSkillVisual.tbl[targetId] = new datNormalSkillVisual_t
            {
                motion = datNormalSkillVisual.tbl[animOriginId].motion,
                animetype = datNormalSkillVisual.tbl[animOriginId].animetype,
                hatudo = datNormalSkillVisual.tbl[animOriginId].hatudo,
                bedno = datNormalSkillVisual.tbl[animOriginId].bedno
            };
            nbActionProcess.sobedtbl[targetId] = new nbActionProcess.SOBED
            {
                keyname = nbActionProcess.sobedtbl[effectOriginId].keyname,
                bed_fname = nbActionProcess.sobedtbl[effectOriginId].bed_fname,
                se0_str = nbActionProcess.sobedtbl[effectOriginId].se0_str,
                se1_str = nbActionProcess.sobedtbl[effectOriginId].se1_str,
                tga_fname = nbActionProcess.sobedtbl[effectOriginId].tga_fname,
                pbdata = nbActionProcess.sobedtbl[effectOriginId].pbdata
            };
            nbCamera_SkillPtrTable.tbl[targetId] = new nbCameraSkillPtr_t
            {
                ptr_shot_1 = nbCamera_SkillPtrTable.tbl[effectOriginId].ptr_shot_1,
                ptr_shot_23 = nbCamera_SkillPtrTable.tbl[effectOriginId].ptr_shot_23,
                ptr_angleH = nbCamera_SkillPtrTable.tbl[effectOriginId].ptr_angleH,
                ptr_angleW = nbCamera_SkillPtrTable.tbl[effectOriginId].ptr_angleW,
                ptr_H = nbCamera_SkillPtrTable.tbl[effectOriginId].ptr_H,
                ptr_W = nbCamera_SkillPtrTable.tbl[effectOriginId].ptr_W,
                anim = nbCamera_SkillPtrTable.tbl[effectOriginId].anim
            };
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
            RedCapote(276);

            Punishment(188);
            JudgementLight(189);
            NewBeastEye(422);
            NewDragonEye(423);
            Concentrate(424);
            ImpalersAnimus(425);
            SakuraRage(426);
            FangBreaker(427);
            DefenseKuzushi(428);
            PrimalForce(429);
            ChiBlast(430);
            Revelation(431);
            GateOfHell(432);
            AkashicArts(433);
            Bloodbath(434);
            Scald(435);
            Trisagion(436);
            Refrigerate(437);
            Cocytus(438);
            Fimbulvetr(439);
            Jolt(440);
            ThunderGods(441);
            ThunderReign(442);
            Dervish(443);
            HeavenlyCyclone(444);
            Vayavya(445);
            WickedCurse(446);
            Damnation(447);
            Mjolnir(448);

            PoisonVolley(456);
            PoisonSalvo(457);
            Pulinpaon(458);
            
            
            // Passive Skills
            Might(11);
            DrainAttack(14);
        }

        // Physical Skills

        private static void SakuraRage(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 16;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 20;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 128;
            datNormalSkill.tbl[id].cost = 23;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 20;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 6;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 34;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 5;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 1;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[id].Level = 0;
            OverWriteSkillEffect(id, 98, 285);
        }

        private static void FangBreaker(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 16;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 15;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 10;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 20;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 2;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 36;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
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
            OverWriteSkillEffect(id, 96);
        }

        private static void DefenseKuzushi(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 16;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 15;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 10;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 20;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 128;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 32;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
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
            OverWriteSkillEffect(id, 96, 107);
        }

        private static void PrimalForce(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 16;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 17;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 3;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 76;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
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
            OverWriteSkillEffect(id, 96, 139);
        }

        private static void ChiBlast(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 128;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 17;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 50;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 12;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 28;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
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
            OverWriteSkillEffect(id, 65, 101);
        }

        private static void Revelation(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 128;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 32;
            datNormalSkill.tbl[id].cost = 29;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 30;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 8;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
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
            OverWriteSkillEffect(id, 28, 143);
        }

        private static void GateOfHell(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 128;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 25;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 1024;
            datNormalSkill.tbl[id].cost = 27;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 38;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 8;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 43;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
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
            OverWriteSkillEffect(id, 98, 281);
        }

        private static void AkashicArts(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 16;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 17;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 46;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 3;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 42;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 3;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 0;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 0;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[id].Level = 0;
            OverWriteSkillEffect(id, 96, 275);
        }

        private static void Bloodbath(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 128;
            datSkill.tbl[id].skillattr = 0;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 25;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 50;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 13;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 0;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 31;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
            datNormalSkill.tbl[id].minus = 100;
            datNormalSkill.tbl[id].mpbase = 0;
            datNormalSkill.tbl[id].mpn = 50;
            datNormalSkill.tbl[id].mptype = 0;
            datNormalSkill.tbl[id].program = 0;
            datNormalSkill.tbl[id].targetarea = 2;
            datNormalSkill.tbl[id].targetcntmax = 5;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 1;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[id].Level = 0;
            OverWriteSkillEffect(id, 100);
        }

        // Fire Skills

        private static void Scald(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 1;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 2;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 27;
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
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[id].Level = 0;
            OverWriteSkillEffect(id, 4, 101);
        }

        private static void Trisagion(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 1;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 40;
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
            datNormalSkill.tbl[id].hpn = 80;
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
            OverWriteSkillEffect(id, 179);
        }

        // Ice Skills

        private static void Refrigerate(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 2;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 25;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2;
            datNormalSkill.tbl[id].cost = 7;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 544;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 33;
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
            OverWriteSkillEffect(id, 7);
        }

        private static void Cocytus(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 2;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 33;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2;
            datNormalSkill.tbl[id].cost = 32;
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
            datNormalSkill.tbl[id].hpn = 27;
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
            datNormalSkill.tbl[id].targetcntmax = 7;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 1;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[id].Level = 0;
            OverWriteSkillEffect(id, 7, 180);
        }

        private static void Fimbulvetr(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 2;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 22;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2;
            datNormalSkill.tbl[id].cost = 35;
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
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[id].Level = 0;
            OverWriteSkillEffect(id, 181);
            nbActionProcess.sobedtbl[id].bed_fname = nbActionProcess.sobedtbl[12].bed_fname;
            nbActionProcess.sobedtbl[id].keyname = nbActionProcess.sobedtbl[181].keyname;
            nbActionProcess.sobedtbl[id].se0_str = nbActionProcess.sobedtbl[181].se0_str;
            nbActionProcess.sobedtbl[id].se1_str = nbActionProcess.sobedtbl[12].se1_str;
            nbActionProcess.sobedtbl[id].tga_fname = nbActionProcess.sobedtbl[181].tga_fname;
        }

        private static void Niflheim(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 2;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 22;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2;
            datNormalSkill.tbl[id].cost = 35;
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
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[id].Level = 0;
            OverWriteSkillEffect(id, 181);
            nbActionProcess.sobedtbl[id].bed_fname =  nbActionProcess.sobedtbl[12].bed_fname;
            nbActionProcess.sobedtbl[id].keyname = nbActionProcess.sobedtbl[181].keyname;
            nbActionProcess.sobedtbl[id].se0_str = nbActionProcess.sobedtbl[181].se0_str;
            nbActionProcess.sobedtbl[id].se1_str = nbActionProcess.sobedtbl[12].se1_str;
            nbActionProcess.sobedtbl[id].tga_fname = nbActionProcess.sobedtbl[181].tga_fname;
            nbActionProcess.sobedtbl[id].pbdata = nbActionProcess.sobedtbl[12].pbdata;
        }

        // Elec Skills

        private static void Zio(ushort id)
        {
            //datNormalSkill.tbl[id];
        }

        private static void Jolt(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 3;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 75;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 1;
            datNormalSkill.tbl[id].cost = 7;
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
            datNormalSkill.tbl[id].hpn = 27;
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
            OverWriteSkillEffect(id, 182);
        }

        private static void ThunderGods(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 3;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 40;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 1;
            datNormalSkill.tbl[id].cost = 15;
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
            datNormalSkill.tbl[id].hpn = 80;
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
            OverWriteSkillEffect(id, 15, 193);
        }

        private static void ThunderReign(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 3;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 22;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 1;
            datNormalSkill.tbl[id].cost = 35;
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
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[id].Level = 0;
            OverWriteSkillEffect(id, 15, 195);
            //nbActionProcess.sobedtbl[id].se0_str = nbActionProcess.sobedtbl[193].se0_str;
        }

        private static void Mjolnir(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 256;
            datSkill.tbl[id].skillattr = 3;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 1;
            datNormalSkill.tbl[id].cost = 15;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 1;
            datNormalSkill.tbl[id].criticalpoint = 20;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 99;
            datNormalSkill.tbl[id].hojotype = 0;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 50;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
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
            OverWriteSkillEffect(id, 106, 15);
            datNormalSkillVisual.tbl[id].bedno = datNormalSkillVisual.tbl[15].bedno;
            datNormalSkillVisual.tbl[id].hatudo = datNormalSkillVisual.tbl[15].hatudo;
        }

        // Force Skills

        private static void Dervish(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 4;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 12;
            datNormalSkill.tbl[id].costbase = 0;
            datNormalSkill.tbl[id].costtype = 2;
            datNormalSkill.tbl[id].criticalpoint = 0;
            datNormalSkill.tbl[id].deadtype = 0;
            datNormalSkill.tbl[id].failpoint = 0;
            datNormalSkill.tbl[id].flag = 0;
            datNormalSkill.tbl[id].hitlevel = 100;
            datNormalSkill.tbl[id].hitprog = 0;
            datNormalSkill.tbl[id].hittype = 1;
            datNormalSkill.tbl[id].hojopoint = 1;
            datNormalSkill.tbl[id].hojotype = 32;
            datNormalSkill.tbl[id].hpbase = 0;
            datNormalSkill.tbl[id].hpn = 27;
            datNormalSkill.tbl[id].hptype = 1;
            datNormalSkill.tbl[id].koukatype = 0;
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
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[id].Level = 0;
            OverWriteSkillEffect(id, 22, 184);
        }

        private static void HeavenlyCyclone(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 4;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 32;
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
            datNormalSkill.tbl[id].hpn = 32;
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
            datNormalSkill.tbl[id].targetcntmax = 7;
            datNormalSkill.tbl[id].targetcntmin = 3;
            datNormalSkill.tbl[id].targetprog = 0;
            datNormalSkill.tbl[id].targetrandom = 1;
            datNormalSkill.tbl[id].targetrule = 0;
            datNormalSkill.tbl[id].targettype = 1;
            datNormalSkill.tbl[id].untargetbadstat = 0;
            datNormalSkill.tbl[id].use = 2;

            tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl[id].Level = 0;
            OverWriteSkillEffect(id, 24, 282);
        }

        private static void Vayavya(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 4;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 255;
            datNormalSkill.tbl[id].badtype = 0;
            datNormalSkill.tbl[id].basstatus = 0;
            datNormalSkill.tbl[id].cost = 40;
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
            datNormalSkill.tbl[id].hpn = 80;
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
            OverWriteSkillEffect(id, 186);
        }

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

        private static void Punishment(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 6;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 50;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2048;
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
            datNormalSkill.tbl[id].hpn = 0;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
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
            datNormalSkillVisual.tbl[id] = datNormalSkillVisual.tbl[28];
        }

        private static void JudgementLight(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 6;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2048;
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
            datNormalSkill.tbl[id].hpn = 0;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
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
            datNormalSkillVisual.tbl[id] = datNormalSkillVisual.tbl[28];
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

        private static void WickedCurse(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 7;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 50;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2048;
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
            datNormalSkill.tbl[id].hpn = 0;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
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
            OverWriteSkillEffect(id, 32, 243);
        }

        private static void Damnation(ushort id)
        {
            datSkill.tbl[id].capacity = 6;
            datSkill.tbl[id].flag = 0;
            datSkill.tbl[id].keisyoform = 1;
            datSkill.tbl[id].skillattr = 7;
            datSkill.tbl[id].index = (short)id;
            datSkill.tbl[id].type = 0;

            datNormalSkill.tbl[id].badlevel = 30;
            datNormalSkill.tbl[id].badtype = 1;
            datNormalSkill.tbl[id].basstatus = 2048;
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
            datNormalSkill.tbl[id].hpn = 0;
            datNormalSkill.tbl[id].hptype = 0;
            datNormalSkill.tbl[id].koukatype = 1;
            datNormalSkill.tbl[id].magicbase = 0;
            datNormalSkill.tbl[id].magiclimit = 0;
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
            OverWriteSkillEffect(id, 32, 243);
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

        private static void RedCapote(ushort id)
        {
            datNormalSkill.tbl[id].hojopoint = 6;
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

        private static void ImpalersAnimus(ushort id)
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
