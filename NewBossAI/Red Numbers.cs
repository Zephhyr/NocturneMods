using HarmonyLib;
using MelonLoader;
using Il2Cppnewbattle_H;
using Il2Cppnewdata_H;
using UnityEngine;
using Il2Cpp;
using UnityEngine.UI;

namespace NewBossAI
{
    internal partial class NewBossAI : MelonMod
    {
        public static datUnitWork_t[] enemyUnits = new datUnitWork_t[] { };
        public static bool[] targets = new bool[16] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }; 
        public static Material? material;

        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetAllPacket))]
        private class RedNumbersPatch1
        {
            public static void Prefix(ref nbActionProcessData_t a, ref int koukatype, ref int nskill, ref int sformindex, ref int dformindex, ref int cnt, ref int frame, ref float koukaritu)
            {
                enemyUnits = dds3GlobalWork.DDS3_GBWK.unitwork;
                if (datNormalSkill.tbl[nskill].targetarea != 1)
                {
                    enemyUnits[sformindex] = nbMainProcess.nbGetUnitWorkFromFormindex(sformindex);
                    enemyUnits[dformindex] = nbMainProcess.nbGetUnitWorkFromFormindex(dformindex);
                }
            }
        }

        [HarmonyPatch(typeof(nbMakePacket), nameof(nbMakePacket.nbAddNumEffKoukaPacket))]
        private class RedNumbersPatch2
        {
            public static void Postfix(ref int startframe, ref int frame, ref int uniqueid, ref nbFormation_t form, ref int n, ref int n2, ref int type)
            {
                if (form.formindex >= 4 && ((enemyUnits[form.formindex].hp - n) <= (enemyUnits[form.formindex].maxhp / 4)) && (type == 0 || type == 4))
                    targets[form.formindex] = true;
                else
                    targets[form.formindex] = false;
            }
        }

        [HarmonyPatch(typeof(nbMainProcess), nameof(nbMainProcess.GetHitNum))]
        private class RedNumbersPatch3
        {
            public static void Postfix(ref int idx, ref int copyNumber, ref GameObject __result)
            {
                if (material == null)
                    material = new Material(__result.transform.Find("num_damage").gameObject.transform.Find("num_damage01").gameObject.GetComponent<Image>().material);

                var baseColor = __result.transform.Find("num_damage").gameObject.transform.Find("num_damage05").gameObject.GetComponent<Image>().color;

                if (targets[idx] && baseColor.r == 1 && baseColor.g == 1 && baseColor.b == 1)
                    material.color = new Color(1, 0.28f, 0.34f, 1);
                else
                    material.color = Color.white;

                var mat = new Material(material);
                __result.transform.Find("num_damage").gameObject.transform.Find("num_damage01").gameObject.GetComponent<Image>().material = mat;
                __result.transform.Find("num_damage").gameObject.transform.Find("num_damage02").gameObject.GetComponent<Image>().material = mat;
                __result.transform.Find("num_damage").gameObject.transform.Find("num_damage03").gameObject.GetComponent<Image>().material = mat;
                __result.transform.Find("num_damage").gameObject.transform.Find("num_damage04").gameObject.GetComponent<Image>().material = mat;
                __result.transform.Find("num_damage").gameObject.transform.Find("num_damage05").gameObject.GetComponent<Image>().material = mat;
            }
        }
    }
}
