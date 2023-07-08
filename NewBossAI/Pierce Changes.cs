using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;

namespace NewBossAI
{
    internal partial class NewBossAI : MelonMod
    {
        // After getting the effectiveness of an attack on 1 target
        [HarmonyPatch(typeof(nbCalc), nameof(nbCalc.nbGetAisyo))]
        private class PiercePatch
        {
            public static void Postfix(ref uint __result, ref int attr, ref int formindex, ref int nskill)
            {
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

                bool hasPierce = datCalc.datCheckSyojiSkill(nbMainProcess.nbGetUnitWorkFromFormindex(nbMainProcess.nbGetMainProcessData().party[nbMainProcess.nbGetMainProcessData().activeunit].formindex), 357) == 1 ||
                    datCalc.datCheckSyojiSkill(nbMainProcess.nbGetUnitWorkFromFormindex(nbMainProcess.nbGetMainProcessData().party[nbMainProcess.nbGetMainProcessData().activeunit].formindex), 361) == 1;
                
                bool charged = (nbMainProcess.nbGetMainProcessData().party[nbMainProcess.nbGetMainProcessData().activeunit].count[15] > 0 && nbMainProcess.nbGetMainProcessData().party[nbMainProcess.nbGetMainProcessData().activeunit].count[19] > 0);

                if (nskill != -1 && attr >= 0 && attr <= 11 && datSkill.tbl[nskill].skillattr >= 0 && datSkill.tbl[nskill].skillattr <= 11 && (hasPierce || charged))
                {
                    if (isResist)
                    {
                        __result = __result - ratio + 100;
                        nbMainProcess.nbGetMainProcessData().d31_kantuu = 1; // Displays the "Pierced!" message
                    }
                    else if (isNull)
                    {
                        __result = __result - 65536 + 100;
                        nbMainProcess.nbGetMainProcessData().d31_kantuu = 1; // Displays the "Pierced!" message
                    }
                    else if (isDrain)
                    {
                        __result = __result - 262144 + 100;
                        nbMainProcess.nbGetMainProcessData().d31_kantuu = 1; // Displays the "Pierced!" message
                    }
                }
            }
        }
    }
}