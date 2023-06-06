using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using System.Collections;

[assembly: MelonInfo(typeof(ReworkedMitamaFusion50.ReworkedMitamaFusion50), "Reworked Mitama Fusion (50% stat increase cap)", "1.0.2", "Zephhyr")]
[assembly: MelonGame("", "smt3hd")]

namespace ReworkedMitamaFusion50
{
    internal class ReworkedMitamaFusion50 : MelonMod
    {
        [HarmonyPatch(typeof(fclCombineCalcCore), "cmbRndAddKeisyoSkillToSkill")]
        private class SkillOverwritePatch
        {
            public static void Prefix(ref datUnitWork_t pDevil1, ref datUnitWork_t pDevil2, ref datUnitWork_t pSacrifice, ref datUnitWork_t pStock,
                ref fclKeisyoList_t pKeisyoBuf, ref fclKeisyoListAll_t pKeisyoAllBuf)
            {
                if (datDevilFormat.Get(pDevil1.id).race == 8 || datDevilFormat.Get(pDevil2.id).race == 8)
                {
                    datUnitWork_t nonMitamaDevil = new datUnitWork_t();
                    if (datDevilFormat.Get(pDevil1.id).race == 8)
                        nonMitamaDevil.Copy(pDevil2);
                    else if (datDevilFormat.Get(pDevil2.id).race == 8)
                        nonMitamaDevil.Copy(pDevil1);

                    if (pKeisyoAllBuf.SkillID.IndexOf(0) != 0)
                    {
                        foreach (var skill in nonMitamaDevil.skill)
                            if (!pKeisyoAllBuf.SkillID.Contains((ushort)skill))
                                pKeisyoAllBuf.SkillID[pKeisyoAllBuf.SkillID.IndexOf(0)] = (ushort)skill;
                        pKeisyoAllBuf.SkillCnt = (sbyte)pKeisyoAllBuf.SkillID.Where(x => x != 0).Count();
                    }

                    foreach (var skill in pDevil1.skill.Where(x => x != 0))
                    {
                        var demonKeisyoFormBits = Convert.ToString(datDevilFormat.Get(pStock.id).keisyoform, 2);
                        while (demonKeisyoFormBits.Length < 12)
                            demonKeisyoFormBits = "0" + demonKeisyoFormBits;

                        var skillKeisyoFormBit = Convert.ToString(datSkill.tbl[skill].keisyoform, 2);

                        var demonCanInheritSkill = demonKeisyoFormBits[12 - skillKeisyoFormBit.Length] == skillKeisyoFormBit[0];

                        List<int> list = new List<int>();
                        foreach (var skillEvent in tblSkill.fclSkillTbl[pStock.id].Event.Where(x => x.Param != 0))
                            list.Add(skillEvent.Param);

                        var demonCanLearnSkill = list.Contains(skill);

                        var skillIsNotAlreadyInherited = !pStock.keisyoskill.Contains((ushort)skill);

                        if ((demonCanInheritSkill || demonCanLearnSkill) && skillIsNotAlreadyInherited)
                            pStock.keisyoskill[pStock.keisyoskill.IndexOf(0)] = (ushort)skill;
                    }

                    foreach (var skill in pDevil2.skill.Where(x => x != 0))
                    {
                        var demonKeisyoFormBits = Convert.ToString(datDevilFormat.Get(pStock.id).keisyoform, 2);
                        while (demonKeisyoFormBits.Length < 12)
                            demonKeisyoFormBits = "0" + demonKeisyoFormBits;

                        var skillKeisyoFormBit = Convert.ToString(datSkill.tbl[skill].keisyoform, 2);

                        var demonCanInheritSkill = demonKeisyoFormBits[12 - skillKeisyoFormBit.Length] == skillKeisyoFormBit[0];

                        List<int> list = new List<int>();
                        foreach (var skillEvent in tblSkill.fclSkillTbl[pStock.id].Event.Where(x => x.Param != 0))
                            list.Add(skillEvent.Param);

                        var demonCanLearnSkill = list.Contains(skill);

                        var skillIsNotAlreadyInherited = !pStock.keisyoskill.Contains((ushort)skill);

                        if ((demonCanInheritSkill || demonCanLearnSkill) && skillIsNotAlreadyInherited)
                            pStock.keisyoskill[pStock.keisyoskill.IndexOf(0)] = (ushort)skill;
                    }

                    int currentSkills = nonMitamaDevil.skill.Where(x => x != 0).Count();
                    int outputSkills = (int)((pDevil1.skillcnt + pDevil2.skillcnt + 2.7) / 3.7);
                    while (outputSkills < 8 && outputSkills <= currentSkills)
                    {
                        pDevil1.skillcnt++;
                        pDevil2.skillcnt++;
                        outputSkills = (int)((pDevil1.skillcnt + pDevil2.skillcnt + 2.7) / 3.7);
                    }

                    pStock.ClearSkill();
                }
            }

            public static void Postfix(ref datUnitWork_t pDevil1, ref datUnitWork_t pDevil2, ref datUnitWork_t pSacrifice, ref datUnitWork_t pStock,
                ref fclKeisyoList_t pKeisyoBuf, ref fclKeisyoListAll_t pKeisyoAllBuf)
            {
                if (pDevil1.skillcnt > pDevil1.skill.Where(x => x != 0).Count())
                    pDevil1.skillcnt = pDevil1.skill.Where(x => x != 0).Count();
                if (pDevil2.skillcnt > pDevil2.skill.Where(x => x != 0).Count())
                    pDevil2.skillcnt = pDevil2.skill.Where(x => x != 0).Count();
            }
        }

        [HarmonyPatch(typeof(fclCombineCalcCore), "cmbCalcParamPowerUp")]
        private class StatIncreasePatch
        {
            public static void Postfix(ref ushort MitamaID, ref datUnitWork_t pStock, ref sbyte __result)
            {
                for (int i = 0; i <= 5; i++)
                    if (pStock.mitamaparam[i] >= (sbyte)(pStock.param[i] * 0.5))
                        pStock.mitamaparam[i] = (sbyte)(pStock.param[i] * 0.5);
            }
        }
    }
}