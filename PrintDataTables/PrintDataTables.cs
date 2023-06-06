using Il2Cppfacility_H;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using Il2Cppnewdata_H;
using Newtonsoft.Json;
using PrintDataTables;
using Il2Cppresult2_H;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Il2Cpp;

[assembly: MelonInfo(typeof(PrintDataToFile), "Print data tables to file", "1.0.0", "Zephhyr")]
[assembly: MelonGame("", "smt3hd")]

namespace PrintDataTables
{
    internal class PrintDataToFile : MelonMod
    {
        public override void OnInitializeMelon()
        {
            //PrintDatDevilAIInMultipleFiles();
            //PrintDatDevilFormat();
            //PrintDatSkill();
            //PrintDatSpecialSkill();
            //PrintSkillNames();
            //PrintSkillHelpMessages();
        }

        public static void PrintDatDevilFormat()
        {
            var devilFormatTable = datDevilFormat.tbl;
            List<List<string>> demons = new List<List<string>>();
            int i = 0;
            foreach (datDevilFormat_t devil in devilFormatTable)
            {
                var demon = new List<string>();
                demon.Add(i.ToString());
                demon.Add(devil.aisyoid.ToString());
                demon.Add(datDevilName.txt[i]);
                demon.Add(Localize.GetLocalizeText(datDevilName.txt_loc[i]));
                demon.Add(devil.attackattr.ToString());
                demon.Add(devil.attackcnt.ToString());
                demon.Add(devil.attackinterval.ToString());
                demon.Add(devil.dropexp.ToString());

                var dropitem = devil.dropitem.ToList();
                string dropitemString = string.Empty;
                foreach (var value in dropitem)
                    dropitemString = dropitemString + value.ToString() + "; ";

                demon.Add(dropitemString.TrimEnd(';', ' '));
                demon.Add(devil.dropmakka.ToString());

                var droppoint = devil.droppoint.ToList();
                string droppointString = string.Empty;
                foreach (var value in droppoint)
                    droppointString = droppointString + value.ToString() + "; ";

                demon.Add(droppointString.TrimEnd(';', ' '));
                demon.Add(devil.flag.ToString());
                demon.Add(devil.hougyokupoint.ToString());
                
                demon.Add(devil.keisyoform.ToString());
                demon.Add(devil.keisyotype.ToString());
                demon.Add(devil.level.ToString());
                demon.Add(devil.masekipoint.ToString());
                demon.Add(devil.maxhp.ToString());
                demon.Add(devil.maxmp.ToString());
                demon.Add(devil.hp.ToString());
                demon.Add(devil.mp.ToString());

                var param = devil.param.ToList();
                string paramString = string.Empty;
                foreach (var value in param)
                    paramString = paramString + value.ToString() + "; ";

                demon.Add(paramString.TrimEnd(';', ' '));
                demon.Add(devil.Pointer.ToString());
                demon.Add(devil.race.ToString());
                demon.Add(devil.reserve1.ToString());

                var skill = devil.skill.ToList();
                string skillString = string.Empty;
                foreach (var value in skill)
                    skillString = skillString + value.ToString() + "; ";

                demon.Add(skillString.TrimEnd(';', ' '));
                demon.Add(devil.specialbit.ToString());
                demon.Add(devil.specialitem.ToString());
                
                demons.Add(demon);
                i++;
            }
            List<string> lines = new List<string>();
            lines.Add("index, aisyoid, Name, LocalizedName, attackattr, attackcnt, attackinterval, dropexp, dropitem, dropmakka, droppoiint, " +
                "flag, hougyokupoint, keisyoform, keisyotype, level, masekipoint, maxhp, maxmp, hp, mp, param, Pointer, race, reserve1, skill, " +
                "specialbit, specialitem");

            foreach (List<string> demon in demons)
            {
                string line = string.Empty;
                foreach (string field in demon)
                {
                    line = line + field + ", ";
                }
                lines.Add(line.TrimEnd(',', ' '));
            }

            using (StreamWriter writer = new StreamWriter("D:\\Nocturne Mods\\Data\\datDevilFormat.csv"))
            {
                foreach (string line in lines)
                    writer.WriteLine(line);
            }
        }

        public static void PrintDatSkill()
        {
            var skillTable = datSkill.tbl;
            List<List<string>> skills = new List<List<string>>();

            int i = 0;
            foreach (datSkill_t skillEntry in skillTable)
            {
                var skill = new List<string>();
                skill.Add(i.ToString());
                skill.Add(datSkillName.txt[i]);
                skill.Add(datSkillName.Get(i));
                skill.Add(Regex.Replace(datSkillHelp_msg.Get(i), @"\r\n?|\n", "; "));
                skill.Add(skillEntry.capacity.ToString());
                skill.Add(skillEntry.flag.ToString());
                skill.Add(skillEntry.keisyoform.ToString());
                skill.Add(skillEntry.Pointer.ToString());
                skill.Add(skillEntry.skillattr.ToString());
                skill.Add(skillEntry.type.ToString());

                var ksl = tblKeisyoSkillLevel.fclKeisyoSkillLevelTbl.Where(x => x.SkillID == i);
                if (ksl.Count() != 0)
                    skill.Add(ksl.FirstOrDefault().Level.ToString());
                else
                    skill.Add(string.Empty);

                var normalSkill = datNormalSkill.tbl[skillEntry.index];
                skill.Add(normalSkill.badlevel.ToString());
                skill.Add(normalSkill.badtype.ToString());
                skill.Add(normalSkill.basstatus.ToString());
                skill.Add(normalSkill.cost.ToString());
                skill.Add(normalSkill.costbase.ToString());
                skill.Add(normalSkill.costtype.ToString());
                skill.Add(normalSkill.criticalpoint.ToString());
                skill.Add(normalSkill.deadtype.ToString());
                skill.Add(normalSkill.failpoint.ToString());
                skill.Add(normalSkill.flag.ToString());
                skill.Add(normalSkill.hitlevel.ToString());
                skill.Add(normalSkill.hitprog.ToString());
                skill.Add(normalSkill.hittype.ToString());
                skill.Add(normalSkill.hojopoint.ToString());
                skill.Add(normalSkill.hojotype.ToString());
                skill.Add(normalSkill.hpbase.ToString());
                skill.Add(normalSkill.hpn.ToString());
                skill.Add(normalSkill.hptype.ToString());
                skill.Add(normalSkill.koukatype.ToString());
                skill.Add(normalSkill.magicbase.ToString());
                skill.Add(normalSkill.magiclimit.ToString());
                skill.Add(normalSkill.minus.ToString());
                skill.Add(normalSkill.mpbase.ToString());
                skill.Add(normalSkill.mpn.ToString());
                skill.Add(normalSkill.mptype.ToString());
                skill.Add(normalSkill.Pointer.ToString());
                skill.Add(normalSkill.program.ToString());
                skill.Add(normalSkill.targetarea.ToString());
                skill.Add(normalSkill.targetcntmax.ToString());
                skill.Add(normalSkill.targetcntmin.ToString());
                skill.Add(normalSkill.targetprog.ToString());
                skill.Add(normalSkill.targetrandom.ToString());
                skill.Add(normalSkill.targetrule.ToString());
                skill.Add(normalSkill.targettype.ToString());
                skill.Add(normalSkill.untargetbadstat.ToString());
                skill.Add(normalSkill.use.ToString());

                skills.Add(skill);
                i++;
            }

            List<string> lines = new List<string>();
            lines.Add("index, Name, LocalizedName, Help_msg, capacity, flag, keisyoform, Pointer, skillattr, type, keisyoSkillLevel, " +
                "badlevel, badtype, basstatus, cost, costbase, costtype, criticalpoint, deadtype, failpoint, flag, hitlevel, hitprog, " +
                "hittype, hojopoint, hojotype, hpbase, hpn, hptype, koukatype, magicbase, magiclimit, minus, mpbase, mpn, mptype, Pointer (normalSkill), " +
                "program, targetarea, targetcntmax, targetcntmin, targetprog, targetrandom, targetrule, targettype, untargetbadstat, use");

            foreach (List<string> skill in skills)
            {
                string line = string.Empty;
                foreach (string field in skill)
                {
                    line = line + field + ", ";
                }
                lines.Add(line.TrimEnd(',', ' '));
            }

            using (StreamWriter writer = new StreamWriter("D:\\Nocturne Mods\\Data\\datSkill.csv"))
            {
                foreach (string line in lines)
                    writer.WriteLine(line);
            }
        }

        private void PrintSkillNames()
        {
            var skillNames = datSkillName.txt.ToList();

            using (StreamWriter writer = new StreamWriter("D:\\Nocturne Mods\\Data\\skillNames.csv"))
            {
                foreach (string skill in skillNames)
                {
                    writer.WriteLine(skill);
                }
            }
        }

        private void PrintSkillHelpMessages()
        {
            var skillNames = datSkillHelp_msg.txt.ToList();

            using (StreamWriter writer = new StreamWriter("D:\\Nocturne Mods\\Data\\skillHelpMessages.csv"))
            {
                foreach (string skill in skillNames)
                {
                    writer.WriteLine(skill);
                }
            }
        }

        private void PrintDatSpecialSkill()
        {
            var specialSkills = datSpecialSkill.tbl;

            List<List<string>> skills = new List<List<string>>();
            foreach (var specialSkill in specialSkills)
            {
                List<string> skill = new List<string>();
                skill.Add(specialSkill.a.ToString());
                skill.Add(specialSkill.b.ToString());
                skill.Add(specialSkill.m.ToString());
                skill.Add(specialSkill.n.ToString());
                skill.Add(specialSkill.Pointer.ToString());
                skills.Add(skill);
            }

            List<string> lines = new List<string>();
            lines.Add("");

            foreach (List<string> skill in skills)
            {
                string line = string.Empty;
                foreach (string field in skill)
                {
                    line = line + field + ", ";
                }
                lines.Add(line.TrimEnd(',', ' '));
            }

            using (StreamWriter writer = new StreamWriter("D:\\Nocturne Mods\\Data\\datSpecialSkill.csv"))
            {
                foreach (string line in lines)
                    writer.WriteLine(line);
            }
        }

        private void PrintDatNegoSkill()
        {
            var test = datNegoSkill.tbl;

            List<List<string>> skills = new List<List<string>>();
            foreach (var negoSkill in test)
            {
                List<string> skill = new List<string>();
                skill.Add(negoSkill.killeraisyo.ToString());

                var killeraisyo = negoSkill.killeraisyo.ToList();
                string killeraisyoString = string.Empty;
                foreach (var value in killeraisyo)
                    killeraisyoString = killeraisyoString + value.ToString() + "; ";

                skill.Add(negoSkill.ngaisyo.ToString());
                skill.Add(negoSkill.Pointer.ToString());
                skill.Add(negoSkill.rate.ToString());
                skill.Add(negoSkill.type.ToString());
                skills.Add(skill);
            }

            List<string> lines = new List<string>();
            lines.Add("");

            foreach (List<string> skill in skills)
            {
                string line = string.Empty;
                foreach (string field in skill)
                {
                    line = line + field + ", ";
                }
                lines.Add(line.TrimEnd(',', ' '));
            }

            using (StreamWriter writer = new StreamWriter("D:\\Nocturne Mods\\Data\\datNegoSkill.csv"))
            {
                foreach (string line in lines)
                    writer.WriteLine(line);
            }
        }

        public static void PrintCurrentCompendium()
        {
            var encyc = dds3GlobalWork.DDS3_GBWK.encyc_record;
            List<List<string>> demons = new List<List<string>>();
            
            if (encyc != null && encyc.pelem.Count != 0)
            {
                foreach (fclencyceelem_t encycelem in encyc.pelem)
                {
                    List<string> demon = new List<string>();

                    demon.Add(encycelem.id.ToString());
                    demon.Add(encycelem.exp.ToString());
                    demon.Add(encycelem.flag.ToString());
                    demon.Add(encycelem.hensinmae.ToString());
                    demon.Add(encycelem.hensinmaeexp.ToString());
                    var keiattr = encycelem.keiattr.ToList();
                    string keiattrString = string.Empty;
                    foreach (var value in keiattr)
                        keiattrString = keiattrString + value.ToString() + "; ";

                    demon.Add(keiattrString.TrimEnd(';', ' '));
                    var keisyoskill = encycelem.keisyoskill.ToList();
                    string keisyoskillString = string.Empty;
                    foreach (var value in keisyoskill)
                        keisyoskillString = keisyoskillString + value.ToString() + "; ";

                    demon.Add(keisyoskillString.TrimEnd(';', ' '));
                    demon.Add(encycelem.level.ToString());
                    var levelupparam = encycelem.levelupparam.ToList();
                    string levelupparamString = string.Empty;
                    foreach (var value in levelupparam)
                        levelupparamString = levelupparamString + value.ToString() + "; ";

                    demon.Add(levelupparamString.TrimEnd(';', ' '));
                    demon.Add(encycelem.maxhp.ToString());
                    demon.Add(encycelem.maxmp.ToString());
                    var mitamaparam = encycelem.mitamaparam.ToList();
                    string mitamaparamString = string.Empty;
                    foreach (var value in mitamaparam)
                        mitamaparamString = mitamaparamString + value.ToString() + "; ";

                    demon.Add(mitamaparamString.TrimEnd(';', ' '));
                    var param = encycelem.param.ToList();
                    string paramString = string.Empty;
                    foreach (var value in param)
                        paramString = paramString + value.ToString() + "; ";

                    demon.Add(paramString.TrimEnd(';', ' '));
                    demon.Add(encycelem.reserved0.ToString());
                    demon.Add(encycelem.reserved1.ToString());
                    demon.Add(encycelem.reserved2.ToString());
                    var skill = encycelem.skill.ToList();
                    string skillString = string.Empty;
                    foreach (var value in skill)
                        skillString = skillString + value.ToString() + "; ";

                    demon.Add(skillString.TrimEnd(';', ' '));
                    demon.Add(encycelem.skillcnt.ToString());
                    var skillparam = encycelem.skillparam.ToList();
                    string skillparamString = string.Empty;
                    foreach (var value in skillparam)
                        skillparamString = skillparamString + value.ToString() + "; ";

                    demon.Add(skillparamString.TrimEnd(';', ' '));

                    demons.Add(demon);
                }
            }
            List<string> lines = new List<string>();

            lines.Add("id, exp, flag, hensinmae, hensinmaeexp, keiattr, keisyoskill, level, levelupparam, maxhp, maxmp, mitamaparam, param, " +
                "reserved0, reserved1, reserved2, skill, skillcnt, skillparam");

            foreach (List<string> demon in demons)
            {
                string line = string.Empty;
                foreach (string field in demon)
                {
                    line = line + field + ", ";
                }
                lines.Add(line.TrimEnd(',', ' '));
            }

            using (StreamWriter writer = new StreamWriter("D:\\Nocturne Mods\\Data\\currentCompendium.csv"))
            {
                foreach (string line in lines)
                    writer.WriteLine(line);
            }
        }

        public static void PrintAllyDemons()
        {
            List<List<string>> demons = new List<List<string>>();

            for (int i = 0; i < 384; i++)
            {
                datDevilFormat_t devil = null;
                try
                {
                    devil = datDevilFormat.Get(i);
                }
                catch
                { }
                

                if (devil != null)
                {
                    var demon = new List<string>();
                    demon.Add(i.ToString());
                    demon.Add(devil.aisyoid.ToString());
                    demon.Add(datDevilName.txt[i]);
                    demon.Add(Localize.GetLocalizeText(datDevilName.txt_loc[i]));
                    demon.Add(devil.attackattr.ToString());
                    demon.Add(devil.attackcnt.ToString());
                    demon.Add(devil.attackinterval.ToString());
                    demon.Add(devil.flag.ToString());
                    demon.Add(devil.hougyokupoint.ToString());
                    demon.Add(devil.keisyoform.ToString());
                    demon.Add(devil.keisyotype.ToString());
                    demon.Add(devil.level.ToString());
                    demon.Add(devil.masekipoint.ToString());
                    demon.Add(devil.maxhp.ToString());
                    demon.Add(devil.maxmp.ToString());
                    demon.Add(devil.hp.ToString());
                    demon.Add(devil.mp.ToString());

                    var param = devil.param.ToList();
                    string paramString = string.Empty;
                    foreach (var value in param)
                        paramString = paramString + value.ToString() + "; ";

                    demon.Add(paramString.TrimEnd(';', ' '));
                    demon.Add(devil.Pointer.ToString());
                    demon.Add(devil.race.ToString());
                    demon.Add(devil.reserve1.ToString());

                    fclSkill_t devilSkill = null;
                    try
                    {
                        devilSkill = tblSkill.Get(i);
                    }
                    catch 
                    { }


                    if (devilSkill != null)
                    {
                        var devilSkillEvent = devilSkill.Event;
                        string skillEventParamString = string.Empty;
                        foreach (var dse in devilSkillEvent)
                            skillEventParamString = skillEventParamString + dse.Param.ToString() + "; ";

                        demon.Add(skillEventParamString.TrimEnd(';', ' '));
                        string skillEventLevelString = string.Empty;
                        foreach (var dse in devilSkillEvent)
                            skillEventLevelString = skillEventLevelString + dse.TargetLevel.ToString() + "; ";

                        demon.Add(skillEventLevelString.TrimEnd(';', ' '));
                        string growParamString = string.Empty;
                        foreach (var growParam in devilSkill.GrowParamTbl.ToList())
                            growParamString = growParamString + growParam.ToString() + "; ";

                        demon.Add(growParamString.TrimEnd(';', ' '));
                    }

                    demons.Add(demon);
                }
            }

            List<string> lines = new List<string>();
            lines.Add("index, aisyoid, Name, LocalizedName, attackattr, attackcnt, attackinterval, flag, hougyokupoint, keisyoform, " +
                "keisyotype, level, masekipoint, maxhp, maxmp, hp, mp, param, Pointer, race, reserve1, skillEventParam, skillTargetLevel, " +
                "growParam");

            foreach (List<string> demon in demons)
            {
                string line = string.Empty;
                foreach (string field in demon)
                {
                    line = line + field + ", ";
                }
                lines.Add(line.TrimEnd(',', ' '));
            }

            using (StreamWriter writer = new StreamWriter("D:\\Nocturne Mods\\Data\\allyDevil.csv"))
            {
                foreach (string line in lines)
                    writer.WriteLine(line);
            }
        }

        public static void PrintAffinities()
        {
            var affinityList = datAisyoName.txt;
            int i = 0;
            List<string> affinities = new List<string>();
            foreach (var affinity in affinityList)
            {
                string affinityParams = string.Empty;
                for (int j = 0; j < 12; j++)
                    affinityParams += datAisyo.Get(i, j) + "; ";

                affinities.Add(datAisyoName.Get(i) + "; " + affinityParams.TrimEnd(';', ' '));
                i++;
            }

            List<string> lines = new List<string>();

            using (StreamWriter writer = new StreamWriter("D:\\Nocturne Mods\\Data\\affinityList.csv"))
            {
                foreach (string line in affinities)
                    writer.WriteLine(line);
            }
        }

        public static void PrintMagatama()
        {
            var hearts = tblHearts.fclHeartsTbl;
            List<List<string>> magatamaList = new List<List<string>>();
            List<string> magatamaHelp = new List<string>();
            int i = 0;
            foreach (var heart in hearts)
            {
                List<string> magatama = new List<string>();
                magatama.Add(i.ToString());
                magatama.Add(heart.AisyoID.ToString());
                magatama.Add(heart.MasterAisyoID.ToString());
                magatama.Add(datHeartsName.txt[i]);
                magatama.Add(datHeartsName.Get(i));
                var autoAsignParamTbl = heart.AutoAsignParamTbl;
                var aaptString = string.Empty;
                foreach (var param in autoAsignParamTbl)
                    aaptString += param.ToString() + "; ";
                magatama.Add(aaptString.TrimEnd(';', ' '));
                var eventParam = heart.Event;
                var eventString = string.Empty;
                foreach (var e in eventParam)
                    eventString += e.ToString() + "; ";
                magatama.Add(eventString.TrimEnd(';', ' '));
                magatama.Add(heart.Flag.ToString());
                var growParam = heart.GrowParamTbl;
                var growParamString = string.Empty;
                foreach (var param in growParam)
                    growParamString += param.ToString() + "; ";
                magatama.Add(growParamString.TrimEnd(';', ' '));
                var masterGrowParam = heart.MasterGrowParamTbl;
                var masterGrowParamString = string.Empty;
                foreach (var param in masterGrowParam)
                    masterGrowParamString += param.ToString() + "; ";
                magatama.Add(masterGrowParamString.TrimEnd(';', ' '));
                var skills = heart.Skill;
                var skillsString = string.Empty;
                var targetLevelString = string.Empty;
                foreach (var skill in skills)
                {
                    skillsString += skill.ID.ToString() + "; ";
                    targetLevelString += skill.TargetLevel.ToString() + "; ";
                }
                magatama.Add(skillsString.TrimEnd(';', ' '));
                magatama.Add(targetLevelString.TrimEnd(';', ' '));
                magatama.Add(heart.Split.HeartsID.ToString());

                magatamaHelp.Add(i.ToString());
                magatamaHelp.Add(datHeartsHelp_msg.Get(i));

                magatamaList.Add(magatama);
                i++;
            }

            List<string> lines = new List<string>();

            foreach (List<string> magatama in magatamaList)
            {
                string line = string.Empty;
                foreach (string field in magatama)
                {
                    line = line + field + ", ";
                }
                lines.Add(line.TrimEnd(',', ' '));
            }

            using (StreamWriter writer = new StreamWriter("D:\\Nocturne Mods\\Data\\magatama1.csv"))
            {
                foreach (string line in lines)
                    writer.WriteLine(line);
            }

            using (StreamWriter writer = new StreamWriter("D:\\Nocturne Mods\\Data\\magatama2.csv"))
            {
                foreach (string help in magatamaHelp)
                    writer.WriteLine(help);
            }
        }

        public static void PrintItems()
        {
            var itemTable = datItem.tbl;
            List<List<string>> items = new List<List<string>>();
            int i = 0;
            foreach (var itemEntry in itemTable)
            {
                List<string> item = new List<string>();
                item.Add(i.ToString());
                item.Add(datItemName.txt[i]);
                item.Add(datItemName.Get(i));
                item.Add(Regex.Replace(datItemHelp_msg.Get(i), @"\r\n?|\n", ""));
                item.Add(itemEntry.flag.ToString());
                item.Add(itemEntry.price.ToString());
                item.Add(itemEntry.skillid.ToString());
                item.Add(itemEntry.use.ToString());
                items.Add(item);
                i++;
            }

            List<string> lines = new List<string>();

            foreach (List<string> item in items)
            {
                string line = string.Empty;
                foreach (string field in item)
                {
                    line = line + field + ", ";
                }
                lines.Add(line.TrimEnd(',', ' '));
            }

            using (StreamWriter writer = new StreamWriter("D:\\Nocturne Mods\\Data\\items.csv"))
            {
                foreach (string line in lines)
                    writer.WriteLine(line);
            }
        }

        public static void PrintEncounters()
        {
            var encounterTable = datEncount.tbl;
            List<List<string>> encounters = new List<List<string>>();
            int i = 0;
            foreach (var encounterEntry in encounterTable)
            {
                List<string> encounter = new List<string>();
                encounter.Add(i.ToString());
                encounter.Add(encounterEntry.areaid.ToString());
                encounter.Add(encounterEntry.backattack.ToString());
                encounter.Add(encounterEntry.btlsound.ToString());
                var devils = encounterEntry.devil;
                string devilString = string.Empty;
                string devilNameString = string.Empty;
                foreach (ushort devil in devils)
                    devilString += devil.ToString() + "; ";
                    
                var devilGroups = devils.GroupBy(x => x).Select(group => new { Value = group.Key, Count = group.Count() });
                foreach (var group in devilGroups)
                    devilNameString += group.Value != 0 ? Localize.GetLocalizeText(datDevilName.txt_loc[group.Value]) + "*" + group.Count + "; " : "";

                encounter.Add(devilString.TrimEnd(';', ' '));
                encounter.Add(devilNameString.TrimEnd(';', ' '));
                encounter.Add(encounterEntry.esc.ToString());
                encounter.Add(encounterEntry.flag.ToString());
                encounter.Add(encounterEntry.formationtype.ToString());
                encounter.Add(encounterEntry.item.ToString());
                encounter.Add(encounterEntry.itemcnt.ToString());
                encounter.Add(encounterEntry.maxcall.ToString());
                encounter.Add(encounterEntry.maxparty.ToString());
                encounter.Add(encounterEntry.stageid.ToString());
                encounters.Add(encounter);
                i++;
            }

            List<string> lines = new List<string>();

            foreach (List<string> encounter in encounters)
            {
                string line = string.Empty;
                foreach (string field in encounter)
                {
                    line = line + field + ", ";
                }
                lines.Add(line.TrimEnd(',', ' '));
            }

            using (StreamWriter writer = new StreamWriter("D:\\Nocturne Mods\\Data\\encounters.csv"))
            {
                foreach (string line in lines)
                    writer.WriteLine(line);
            }
        }

        public static void PrintDatDevilAI()
        {
            var devilAiTable = datDevilAI.divTbls;

            var output = JsonConvert.SerializeObject(devilAiTable);

            using (StreamWriter writer = new StreamWriter("D:\\Nocturne Mods\\Data\\devilAI.json"))
                writer.WriteLine(output);
        }

        public static void PrintDatDevilAIInMultipleFiles()
        {
            int i = 0;
            bool isNull = false;
            while (!isNull)
            {
                var devilAi = datDevilAI.tbl(i);
                if (devilAi == null)
                    isNull = true;
                else
                {
                    var output = JsonConvert.SerializeObject(devilAi);
                    using (StreamWriter writer = new StreamWriter("D:\\Nocturne Mods\\Data\\AI2\\" + i.ToString() + "-" + devilAi.scriptid.ToString() + ".json"))
                        writer.WriteLine(output);
                }
                i++;
            }
        }

        public static void TestPrint()
        {
            string[] messageStr = dds3ConfigMainSteam.MessageStr_;
            List<string> values = new List<string>();
            int i = 0;

            foreach (var value in messageStr)
            {
                MelonLogger.Msg(Localize.GetLocalizeText(messageStr[i]));
                i++;
            }

        }

        [HarmonyPatch(typeof(datDevilName), "Get")]
        private class Patch
        {
            public static void Postfix(ref int id, ref string __result)
            {
                //TestPrint();
                //PrintEncounters();
                //PrintItems();
                //PrintMagatama();
                //PrintAffinities();
                //PrintAllyDemons();
                //PrintDatSkill();
                //PrintDatDevilFormat();
                //PrintCurrentCompendium();
            }
        }
    }
}
