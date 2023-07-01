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
            public static void Postfix(ref int id, ref string __result)
            {
                switch (id)
                {
                    case 81: __result = "Beast Eye"; return;
                    case 219: __result = "Rage"; return;
                    case 220: __result = "Psycho Rage"; return;
                }
            }
        }
        [HarmonyPatch(typeof(nbActionProcess), nameof(nbActionProcess.SetAddPressPacket))]
        private class PressPatch1
        {
            public static void Postfix(ref nbActionProcessData_t a, ref int nskill)
            {
                if (a.newaddpresstype == 15 && nskill == 81)
                {
                    a.newaddpresstype = 18;
                    actionTrackers[a.work.id].extraTurns += 1;
                }
            }
        }
        [HarmonyPatch(typeof(nbMakePacket), nameof(nbMakePacket.nbMakeNewPressPacket))]
        private class PressPatch2
        {
            public static void Postfix(ref int startframe, ref int uniqueid, ref int ptype, ref nbFormation_t form)
            {
                if (ptype == 18)
                {
                    nbMakePacket.nbAddNewPressPacket(startframe, uniqueid, 1, 1);
                    nbHelpProcess.nbDispText("Turn Count increased!", string.Empty, 2, 45, 2315190144, false);
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

        private static void NewBeastEye()
        {
            datSkill.tbl[81].keisyoform = 512;
            datSkill.tbl[81].skillattr = 5;
            datNormalSkill.tbl[81].hojotype = 4096;
            datNormalSkill.tbl[81].hojopoint = 2;
            datNormalSkill.tbl[81].hpbase = 0;
            datNormalSkill.tbl[81].hpn = 50;
            datNormalSkill.tbl[81].hptype = 0;
            datNormalSkill.tbl[81].program = 13;
            datNormalSkill.tbl[81].use = 2;
            OverWriteSkillEffect(81, 219);
        }

        private static void PhysicalAttacksCureFreezeAndShock()
        {
            foreach (var skill in datNormalSkill.tbl.Where(x => x.koukatype == 0))
            {
                skill.badtype = 2;
                skill.basstatus = 3;
            }
        }
    }
}
