using HarmonyLib;
using Il2Cpp;
using Il2Cppnewbattle_H;
using Il2Cppnewdata_H;
using MelonLoader;
using MelonLoader.TinyJSON;

namespace NewBossAI
{
    internal partial class NewBossAI : MelonMod
    {
        public static short chargeNowcommand;
        public static ushort chargeNowindex;
        public static short focusState;
        public static short concentrateState;

        public static short[] currentUnitBuffs;
        public static short[][] currentSideBuffs;

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbSetHojoCounter))]
        private class FocusPatch
        {
            public static void Prefix(ref int formindex, ref int type, ref int point)
            {
                if ((chargeNowindex <= 287 || chargeNowindex >= 424) && type == 15 && (chargeNowcommand == 6 || datNormalSkill.tbl[chargeNowindex].koukatype == 0))
                    point = focusState;
                else if ((chargeNowindex <= 287 || chargeNowindex >= 424) && type == 19 && (chargeNowcommand == 6 || datNormalSkill.tbl[chargeNowindex].koukatype == 1))
                    point = concentrateState;
            }
        }

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetAction_SKILL))]
        private class FocusPatch2
        {
            public static void Prefix(ref nbActionProcessData_t a)
            {
                actionProcessData = a;

                chargeNowcommand = a.work.nowcommand;
                chargeNowindex = a.work.nowindex;
                focusState = a.party.count[15];
                concentrateState = a.party.count[19];
            }

            public static void Postfix(ref nbActionProcessData_t a)
            {
                actionProcessData = a;

                sbyte skillattr = -1;
                if (chargeNowcommand == 0 || chargeNowcommand == 1)
                    skillattr = datSkill.tbl[chargeNowindex].skillattr;
                else if (chargeNowcommand == 5)
                    skillattr = datSkill.tbl[datItem.tbl[chargeNowindex].skillid].skillattr;

                bool validskill = chargeNowindex <= 287 || chargeNowindex >= 422;
                bool chargedPhysical = datNormalSkill.tbl[chargeNowindex].koukatype == 0 && focusState == 1;
                bool chargedMagical = datNormalSkill.tbl[chargeNowindex].koukatype == 1 && (datNormalSkill.tbl[chargeNowindex].hptype == 1 || datNormalSkill.tbl[chargeNowindex].hptype == 12) && concentrateState == 1;

                if (skillattr >= 0 && skillattr <= 11 && validskill && (chargedPhysical || chargedMagical))
                {
                    a.party.count[15] = 0;
                    a.party.count[19] = 0;
                }
            }
        }

        [HarmonyPatch(typeof(nbSkillError), nameof(nbSkillError.nbCheckBattleSkillError2))]
        private class FocusPatch3
        {
            public static void Postfix(ref int nskill, ref uint select, ref int __result)
            {
                if ((nskill == 224 || nskill == 424 || nskill == 425) && (nbMainProcess.nbGetMainProcessData().party[nbMainProcess.nbGetMainProcessData().activeunit].count[15] > 0 ||
                    nbMainProcess.nbGetMainProcessData().party[nbMainProcess.nbGetMainProcessData().activeunit].count[19] > 0))
                {
                    __result = 4;
                }
            }
        }

        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbSetHojoKouka))]
        private class FocusPatch4
        {
            public static void Prefix(ref int formindex, ref uint hojotype, ref int hojopoint, ref int nvirtual)
            {
                currentUnitBuffs = nbMainProcess.nbGetPartyFromFormindex(formindex).count;

                if (formindex <= 3)
                {
                    currentSideBuffs = new short[nbMainProcess.nbGetMainProcessData().playerpcnt][];
                    for (int i = 0; i < nbMainProcess.nbGetMainProcessData().playerpcnt; i++)
                        currentSideBuffs[i] = nbMainProcess.nbGetMainProcessData().party[nbMainProcess.nbGetMainProcessData().form[i].partyindex].count;
                }
                else
                {
                    currentSideBuffs = new short[nbMainProcess.nbGetMainProcessData().enemypcnt][];
                    for (int i = 4; i < (4 + nbMainProcess.nbGetMainProcessData().enemypcnt); i++)
                        currentSideBuffs[i - 4] =  nbMainProcess.nbGetMainProcessData().party[nbMainProcess.nbGetMainProcessData().form[i].partyindex].count;
                }
            }

            public static void Postfix(ref int formindex, ref uint hojotype, ref int hojopoint, ref int nvirtual, ref int __result)
            {
                var arr = Convert.ToString(hojotype, 2);

                if (arr.Length >= 26 && arr[arr.Length - 26] == '1')
                {
                    var ivar2 = nbCalc.nbSetHojoAddCounter(formindex, 19, 1, nvirtual);
                    if (ivar2 != 0)
                        __result -= ivar2;

                    nbHelpProcess.nbDispText(datDevilName.Get(nbMainProcess.nbGetUnitWorkFromFormindex(formindex).id) + " is building up power!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (actionProcessData.work.nowcommand == 1 && hojotype == 2 && hojopoint == 1 && actionProcessData.work.nowindex == 427)
                {
                    var limitReached = true;
                    if (currentUnitBuffs[4] >= -2)
                        limitReached = false;

                    if (limitReached)
                        nbHelpProcess.nbDispText("Limit reached.", string.Empty, 2, 45, 2315190144, false);
                    else
                        nbHelpProcess.nbDispText("Decreased Physical Attack!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (actionProcessData.work.nowcommand == 1 && hojotype == 2 && hojopoint == 1 && actionProcessData.work.nowindex == 435)
                {
                    var limitReached = true;
                    foreach (var unitBuffs in currentSideBuffs)
                    {
                        if (unitBuffs[4] >= -2)
                        {
                            limitReached = false;
                            break;
                        }
                    }

                    if (limitReached)
                        nbHelpProcess.nbDispText("Limit reached.", string.Empty, 2, 45, 2315190144, false);
                    else
                        nbHelpProcess.nbDispText("Decreased Physical Attack!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (actionProcessData.work.nowcommand == 1 && hojotype == 10 && hojopoint == 1 && actionProcessData.work.nowindex == 268)
                {
                    var limitReached = true;
                    foreach (var unitBuffs in currentSideBuffs)
                    {
                        if (unitBuffs[4] >= -2 || unitBuffs[5] >= -2)
                        {
                            limitReached = false;
                            break;
                        }
                    }

                    if (limitReached)
                        nbHelpProcess.nbDispText("Limit reached.", string.Empty, 2, 45, 2315190144, false);
                    else
                        nbHelpProcess.nbDispText("Decreased Physical/Magical Attack!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (actionProcessData.work.nowcommand == 1 && hojotype == 128 && hojopoint == 1 && actionProcessData.work.nowindex == 202)
                {
                    var limitReached = true;
                    foreach (var unitBuffs in currentSideBuffs)
                    {
                        if (unitBuffs[7] >= -2)
                        {
                            limitReached = false;
                            break;
                        }
                    }

                    if (limitReached)
                        nbHelpProcess.nbDispText("Limit reached.", string.Empty, 2, 45, 2315190144, false);
                    else
                        nbHelpProcess.nbDispText("Decreased Defense!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (actionProcessData.work.nowcommand == 1 && hojotype == 128 && hojopoint == 6 && actionProcessData.work.nowindex == 470)
                {
                    var limitReached = true;
                    foreach (var unitBuffs in currentSideBuffs)
                    {
                        if (unitBuffs[7] >= -2)
                        {
                            limitReached = false;
                            break;
                        }
                    }

                    if (limitReached)
                        nbHelpProcess.nbDispText("Limit reached.", string.Empty, 2, 45, 2315190144, false);
                    else
                        nbHelpProcess.nbDispText("Defense minimized!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (actionProcessData.work.nowcommand == 1 && hojotype == 128 && hojopoint == 1 && (actionProcessData.work.nowindex == 428 || actionProcessData.work.nowindex == 463 || actionProcessData.work.nowindex == 466))
                {
                    var limitReached = true;
                    if (currentUnitBuffs[7] >= -2)
                        limitReached = false;

                    if (limitReached)
                        nbHelpProcess.nbDispText("Limit reached.", string.Empty, 2, 45, 2315190144, false);
                    else
                        nbHelpProcess.nbDispText("Decreased Defense!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (actionProcessData.work.nowcommand == 1 && hojotype == 544 && hojopoint == 1 && (actionProcessData.work.nowindex == 244 || actionProcessData.work.nowindex == 267 || actionProcessData.work.nowindex == 285 || actionProcessData.work.nowindex == 437))
                {
                    var limitReached = true;
                    if (currentUnitBuffs[6] >= -2 || currentUnitBuffs[8] >= -2)
                        limitReached = false;

                    if (limitReached)
                        nbHelpProcess.nbDispText("Limit reached.", string.Empty, 2, 45, 2315190144, false);
                    else
                        nbHelpProcess.nbDispText("Decreased Evasion/Hit Rate!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (actionProcessData.work.nowcommand == 1 && hojotype == 32 && hojopoint == 1 && actionProcessData.work.nowindex == 443)
                {
                    var limitReached = true;
                    foreach (var unitBuffs in currentSideBuffs)
                    {
                        if (unitBuffs[6] >= -2)
                        {
                            limitReached = false;
                            break;
                        }
                    }

                    if (limitReached)
                        nbHelpProcess.nbDispText("Limit reached.", string.Empty, 2, 45, 2315190144, false);
                    else
                        nbHelpProcess.nbDispText("Decreased Evasion!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (actionProcessData.work.nowcommand == 1 && hojotype == 512 && hojopoint == 1 && actionProcessData.work.nowindex == 268)
                {
                    var limitReached = true;
                    foreach (var unitBuffs in currentSideBuffs)
                    {
                        if (unitBuffs[8] >= -2)
                        {
                            limitReached = false;
                            break;
                        }
                    }

                    if (limitReached)
                        nbHelpProcess.nbDispText("Limit reached.", string.Empty, 2, 45, 2315190144, false);
                    else
                        nbHelpProcess.nbDispText("Decreased Hit Rate!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (actionProcessData.work.nowcommand == 1 && hojotype == 160 && hojopoint == 1 && actionProcessData.work.nowindex == 262)
                {
                    var limitReached = true;
                    if (currentUnitBuffs[6] >= -2 || currentUnitBuffs[7] >= -2)
                    {
                        limitReached = false;
                    }

                    if (limitReached)
                        nbHelpProcess.nbDispText("Limit reached.", string.Empty, 2, 45, 2315190144, false);
                    else
                        nbHelpProcess.nbDispText("Decreased Evasion/Defense!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (actionProcessData.work.nowcommand == 1 && hojotype == 160 && hojopoint == 1 && actionProcessData.work.nowindex == 468)
                {
                    var limitReached = true;
                    foreach (var unitBuffs in currentSideBuffs)
                    {
                        if (unitBuffs[6] >= -2 || unitBuffs[7] >= -2)
                        {
                            limitReached = false;
                            break;
                        }
                    }

                    if (limitReached)
                        nbHelpProcess.nbDispText("Limit reached.", string.Empty, 2, 45, 2315190144, false);
                    else
                        nbHelpProcess.nbDispText("Decreased Evasion/Defense!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (actionProcessData.work.nowcommand == 1 && hojotype == 682 && hojopoint == 1 && actionProcessData.work.nowindex == 453)
                {
                    var limitReached = true;
                    for (int i = 4; i <= 8; i++)
                    {
                        if (currentUnitBuffs[i] >= -2)
                            limitReached = false;
                        break;
                    }

                    if (limitReached)
                        nbHelpProcess.nbDispText("Limit reached.", string.Empty, 2, 45, 2315190144, false);
                    else
                        nbHelpProcess.nbDispText("Decreased all stats performance!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (actionProcessData.work.nowcommand == 1 && hojotype == 682 && hojopoint == 1 && actionProcessData.work.nowindex == 467)
                {
                    var limitReached = true;
                    foreach (var unitBuffs in currentSideBuffs)
                    {
                        for (int i = 4; i <= 8; i++)
                        {
                            if (unitBuffs[i] >= -2)
                            {
                                limitReached = false;
                                break;
                            }
                            break;
                        }
                    }

                    if (limitReached)
                        nbHelpProcess.nbDispText("Limit reached.", string.Empty, 2, 45, 2315190144, false);
                    else
                        nbHelpProcess.nbDispText("Decreased all stats performance!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (actionProcessData.work.nowcommand == 1 && hojotype == 273 && hojopoint == 1 && actionProcessData.work.nowindex == 284)
                {
                    var limitReached = true;
                    foreach (var unitBuffs in currentSideBuffs)
                    {
                        if (unitBuffs[4] <= 2 || unitBuffs[6] <= 2 || unitBuffs[8] <= 2)
                        {
                            limitReached = false;
                            break;
                        }
                    }

                    if (limitReached)
                        nbHelpProcess.nbDispText("Limit reached.", string.Empty, 2, 45, 2315190144, false);
                    else
                        nbHelpProcess.nbDispText("Physical Attack/Evasion/Hit Rate increased!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (actionProcessData.work.nowcommand == 1 && hojotype == 341 && hojopoint == 2 && actionProcessData.work.nowindex == 458)
                {
                    var limitReached = true;
                    for (int i = 4; i <= 8; i++)
                    {
                        if (currentUnitBuffs[i] <= 2) 
                            limitReached = false; 
                        break;
                    }
                        
                    if (limitReached)
                        nbHelpProcess.nbDispText("Limit reached.", string.Empty, 2, 45, 2315190144, false);
                    else
                        nbHelpProcess.nbDispText("Greatly increased all stats performance!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (actionProcessData.work.nowcommand == 1 && hojotype == 341 && hojopoint == 1 && actionProcessData.work.nowindex == 459)
                {
                    var limitReached = true;
                    foreach (var unitBuffs in currentSideBuffs)
                    {
                        for (int i = 4; i <= 8; i++)
                        {
                            if (unitBuffs[i] <= 2)
                                limitReached = false;
                            break;
                        }
                    }

                    if (limitReached)
                        nbHelpProcess.nbDispText("Limit reached.", string.Empty, 2, 45, 2315190144, false);
                    else
                        nbHelpProcess.nbDispText("Increased all stats performance!", string.Empty, 2, 45, 2315190144, false);
                }
                else if (actionProcessData.work.nowcommand == 1 && hojotype == 263168 && hojopoint == 1 && actionProcessData.work.nowindex == 460)
                {
                    nbHelpProcess.nbDispText("All -kaja & -nda effects negated!", string.Empty, 2, 45, 2315190144, false);
                }
            }
        }
    }
}