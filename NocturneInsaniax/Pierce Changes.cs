using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using System.ComponentModel.Design;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        // After getting the effectiveness of an attack on 1 target
        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetAisyo))]
        private class PiercePatch
        {
            public static void Postfix(ref uint __result, ref int attr, ref int formindex, ref int nskill)
            {
                var work = nbMainProcess.nbGetUnitWorkFromFormindex(formindex);

                if (attr == 12) // Shot
                {
                    var aisyo = datAisyo.Get(work.id, attr, work.flag);
                    __result = aisyo;

                    var aisyoString = Convert.ToString(aisyo, 2);
                    while (aisyoString.Length < 19)
                        aisyoString = "0" + aisyoString;

                    var aisyoSubstring = aisyoString.Substring(aisyoString.Length - 10).TrimStart('0');

                    uint aisyoRatio = 100;
                    if (string.IsNullOrEmpty(aisyoSubstring))
                        aisyoRatio = 0;
                    else
                        aisyoRatio = Convert.ToUInt32(aisyoSubstring, 2);

                    if (datCalc.datCheckSyojiSkill(work, 377) != 0)
                        __result = 131072 + aisyoRatio;
                    else if (datCalc.datCheckSyojiSkill(work, 376) != 0 && __result != 131072)
                        __result = 262144;
                    else if (datCalc.datCheckSyojiSkill(work, 375) != 0 && __result <= 65536)
                        __result = 65536;
                    else if (datCalc.datCheckSyojiSkill(work, 374) != 0 && __result == 50)
                        __result = 25;
                    else if (datCalc.datCheckSyojiSkill(work, 374) != 0)
                        __result = 50;

                    if (work.badstatus == 2 && (__result == 65536 || __result == 131072 || __result == 262144 || __result < 100))
                        __result = 100;
                }

                MelonLogger.Msg("--nbCalc.nbGetAisyo--");
                MelonLogger.Msg("nskill: " + nskill);
                MelonLogger.Msg("attr: " + attr);
                MelonLogger.Msg("formindex: " + formindex);
                MelonLogger.Msg("result: " + __result);

                if (work.id == 246 || work.id == 259 || work.id == 292)
                {
                    var party = nbMainProcess.nbGetPartyFromFormindex(formindex);

                    if (party.count[19] != 0)
                    {
                        if ((attr == 1 && party.count[19] == 249) ||
                        (attr == 2 && party.count[19] == 248) ||
                        (attr == 3 && party.count[19] == 251) ||
                        (attr == 4 && party.count[19] == 250))
                            __result = 2147483748;
                        else if (attr == 5 || attr == 11 || attr >= 13)
                            __result = 100;
                        else
                            __result = 131072;
                    }
                }

                var resistance = Convert.ToString(__result, 2);
                while (resistance.Length < 19)
                    resistance = "0" + resistance;

                var substring = resistance.Substring(resistance.Length - 10).TrimStart('0');

                uint ratio = 100;
                if (string.IsNullOrEmpty(substring))
                    ratio = 0;
                else
                    ratio = Convert.ToUInt32(substring, 2);

                bool isResist = ratio > 1 && ratio < 100;
                bool isNull = resistance[resistance.Length - 17] == '1';
                bool isRepel = resistance[resistance.Length - 18] == '1';
                bool isDrain = resistance[resistance.Length - 19] == '1';

                bool hasPierce = datCalc.datCheckSyojiSkill(nbMainProcess.nbGetUnitWorkFromFormindex(nbMainProcess.nbGetMainProcessData().party[actionProcessData.partyindex].formindex), 357) == 1 ||
                    datCalc.datCheckSyojiSkill(nbMainProcess.nbGetUnitWorkFromFormindex(nbMainProcess.nbGetMainProcessData().party[actionProcessData.partyindex].formindex), 361) == 1;

                bool hasAnimus = nbMainProcess.nbGetMainProcessData().party[actionProcessData.partyindex].count[15] > 0 && nbMainProcess.nbGetMainProcessData().party[actionProcessData.partyindex].count[20] > 0;

                bool undermineDivinity = (nbMainProcess.nbGetUnitWorkFromFormindex(nbMainProcess.nbGetMainProcessData().party[actionProcessData.partyindex].formindex).id == 161 ||
                    nbMainProcess.nbGetUnitWorkFromFormindex(nbMainProcess.nbGetMainProcessData().party[actionProcessData.partyindex].formindex).id == 287) &&
                    nbMainProcess.nbGetUnitWorkFromFormindex(formindex).badstatus != 0;

                if (nskill != -1 && attr >= 0 && attr <= 12 && datSkill.tbl[nskill].skillattr >= 0 && datSkill.tbl[nskill].skillattr <= 12 && datSkill.tbl[nskill].skillattr == attr &&
                    (hasPierce || (hasAnimus && (nskill == 0 || !(datNormalSkill.tbl[nskill].badtype != 0 && datNormalSkill.tbl[nskill].hptype == 0))) || undermineDivinity
                    || new int[] { 501, 502, 503, 504 }.Contains(nskill)))
                {
                    if (isNull || isDrain || (isRepel && new int[] { 501, 502, 503, 504 }.Contains(nskill)))
                    {
                        __result = 100;
                        nbMainProcess.nbGetMainProcessData().d31_kantuu = 1; // Displays the "Pierced!" message
                    }
                    if (isResist)
                    {
                        __result = __result - ratio + 100;
                        nbMainProcess.nbGetMainProcessData().d31_kantuu = 1; // Displays the "Pierced!" message
                    }
                }
            }
        }
    }
}