using HarmonyLib;
using MelonLoader;
using Il2Cpp;
using Il2CppTMPro;
using UnityEngine;
using Il2Cppcamp_H;
using Il2Cppfacility_H;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2Cppnewbattle_H;
using static Il2Cpp.SteamDlcFileUtil;
using static Il2CppXRD773Unity.CommonMesh;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        [HarmonyPatch(typeof(nbHelpProcess), nameof(nbHelpProcess.nbDispText))]
        private class DispSkillNameColourPatch
        {
            public static void Postfix(ref string text1, ref string text2, ref int type, ref int max, ref uint col, ref bool type_skill)
            {
                if (type_skill)
                {
                    var commandId = actionProcessData.work.nowcommand; // 1 = skill, 5 = item
                    Color attrColour;

                    switch (commandId)
                    {
                        case 1:
                            var skillId = actionProcessData.work.nowindex;
                            var skillAttr = datSkill.tbl[skillId].skillattr;
                            attrColour = GetSkillAttrColour(skillAttr, 1);
                            break;
                        case 5:
                            var itemId = actionProcessData.work.nowindex;
                            var itemSkillId = datItem.tbl[itemId].skillid;
                            var itemSkillAttr = datSkill.tbl[itemSkillId].skillattr;
                            attrColour = GetSkillAttrColour(itemSkillAttr, 1);
                            break;
                        default:
                            attrColour = new Color(0.294f, 0.294f, 0.980f, 1);
                            break;
                    }

                    VertexGradient attrGradient = GetSkillAttrGradient(attrColour, 1);

                    nbMainProcess.GetBattleUI().transform.Find("../bannounce(Clone)/stretch/TextTM").gameObject.GetComponent<TextMeshProUGUI>().outlineColor = attrColour;
                    nbMainProcess.GetBattleUI().transform.Find("../bannounce(Clone)/stretch/TextTM").gameObject.GetComponent<TextMeshProUGUI>().enableVertexGradient = true;
                    nbMainProcess.GetBattleUI().transform.Find("../bannounce(Clone)/stretch/TextTM").gameObject.GetComponent<TextMeshProUGUI>().colorGradient = attrGradient;
                }
                else
                {
                    nbMainProcess.GetBattleUI().transform.Find("../bannounce(Clone)/stretch/TextTM").gameObject.GetComponent<TextMeshProUGUI>().outlineColor = new Color(0.294f, 0.294f, 0.980f, 1);
                    nbMainProcess.GetBattleUI().transform.Find("../bannounce(Clone)/stretch/TextTM").gameObject.GetComponent<TextMeshProUGUI>().enableVertexGradient = false;
                }
            }
        }

        [HarmonyPatch(typeof(nbCommSelProcess), nameof(nbCommSelProcess.DispComm1Comm))]
        private class DispComm1CommColourPatch
        {
            public static void Postfix(ref nbCommSelProcessData_t s, ref ushort d, ref int ox, ref int oy, ref int oz, ref uint col, ref int listidx, ref int col2)
            {
                nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().text =
                        nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().text.Replace("<material=\"TMC00\">", "").Replace("<material=\"TMC01\">", "").Replace("<material=\"TMC02\">", "");

                if (d <= 511)
                {
                    var skillAttr = datSkill.tbl[d].skillattr;
                    Color attrColour = col2 == 2
                        ? GetSkillAttrColour(skillAttr, 0.7f)
                        : GetSkillAttrColour(skillAttr, 1);
                    VertexGradient attrGradient = col2 == 2
                        ? GetSkillAttrGradient(attrColour, 0.7f)
                        : GetSkillAttrGradient(attrColour, 1);

                    nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().color = col2 == 2 ? new Color(1, 1, 1, 0.7f) : new Color(1, 1, 1, 1);
                    nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().outlineColor = attrColour;
                    nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().enableVertexGradient = true;
                    nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().colorGradient = attrGradient;
                }
                else
                {
                    if (col2 == 2)
                    {
                        nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 0.7f);
                        nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().outlineColor = new Color(0.294f, 0.294f, 0.980f, 0.7f);
                    }
                    else
                    {
                        nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 1);
                        nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().outlineColor = new Color(0.294f, 0.294f, 0.980f, 1);
                    }
                    nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().enableVertexGradient = false;
                }
            }
        }

        [HarmonyPatch(typeof(nbCommSelProcess), nameof(nbCommSelProcess.DispComm1Item))]
        private class DispComm1ItemColourPatch
        {
            public static void Postfix(ref nbCommSelProcessData_t s, ref ushort d, ref int ox, ref int oy, ref int oz, ref uint col, ref int listidx, ref int col2)
            {
                var itemSkillId = datItem.tbl[d].skillid;
                var itemSkillAttr = datSkill.tbl[itemSkillId].skillattr;
                Color attrColour = col2 == 2
                    ? GetSkillAttrColour(itemSkillAttr, 0.7f)
                    : GetSkillAttrColour(itemSkillAttr, 1);
                VertexGradient attrGradient = col2 == 2
                        ? GetSkillAttrGradient(attrColour, 0.7f)
                        : GetSkillAttrGradient(attrColour, 1);

                nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().text =
                    nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().text.Replace("<material=\"TMC00\">", "").Replace("<material=\"TMC01\">", "").Replace("<material=\"TMC02\">", "");
                nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().color = col2 == 2 ? new Color(1, 1, 1, 0.7f) : new Color(1, 1, 1, 1);
                nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().outlineColor = attrColour;
                nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().enableVertexGradient = true;
                nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().colorGradient = attrGradient;
            }
        }

        [HarmonyPatch(typeof(nbCommSelProcess), nameof(nbCommSelProcess.DispComm1Talk))]
        private class DispComm1TalkColourPatch
        {
            public static void Postfix(ref nbCommSelProcessData_t s, ref ushort d, ref int ox, ref int oy, ref int oz, ref uint col, ref int listidx, ref int col2)
            {
                nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 1);
                nbMainProcess.GetBattleUI().transform.Find("bmenu/normal_command/bmenu_command/bmenu_command0" + (listidx + 1) + "/bmenu_text01TM").gameObject.GetComponent<TextMeshProUGUI>().enableVertexGradient = false;
            }
        }

        [HarmonyPatch(typeof(nbPanelProcess), nameof(nbPanelProcess.nbPanelAnalyzeDraw))]
        private class AnalyzeSkillColourPatch
        {
            public static void Postfix(ref datUnitWork_t pUnitWork)
            {
                foreach (var skill in datDevilFormat.tbl[pUnitWork.id].skill.Where(x => x != 0))
                {
                    var skillAttr = datSkill.tbl[skill].skillattr;
                    Color attrColour = GetSkillAttrColour(skillAttr, 1);
                    VertexGradient attrGradient = GetSkillAttrGradient(attrColour, 1);

                    nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill0" + (datDevilFormat.tbl[pUnitWork.id].skill.IndexOf(skill) + 1) + "/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().outlineColor = attrColour;
                    nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill0" + (datDevilFormat.tbl[pUnitWork.id].skill.IndexOf(skill) + 1) + "/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().enableVertexGradient = true;
                    nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill0" + (datDevilFormat.tbl[pUnitWork.id].skill.IndexOf(skill) + 1) + "/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().colorGradient = attrGradient;
                }
            }
        }

        [HarmonyPatch(typeof(cmpDrawSkill), nameof(cmpDrawSkill.cmpSkillNameCostDraw))]
        private class cmpSkillNameCostDrawColourPatch
        {
            public static void Postfix(ref int idx, ref uint Col, ref ushort SkillID, ref datUnitWork_t pStock, ref sbyte MskFlag, ref sbyte SelFlag, ref int MatCol)
            {
                var skillAttr = datSkill.tbl[SkillID].skillattr;
                Color attrColour = GetSkillAttrColour(skillAttr, 1);
                VertexGradient attrGradient = GetSkillAttrGradient(attrColour, 1);

                if (idx == 0)
                {
                    cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_top/TextTM").gameObject.GetComponent<TextMeshProUGUI>().text
                    = cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_top/TextTM").gameObject.GetComponent<TextMeshProUGUI>().text.Replace("<material=\"TMC00\">", "");
                    cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_top/TextTM").gameObject.GetComponent<TextMeshProUGUI>().outlineColor = attrColour;
                    cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_top/TextTM").gameObject.GetComponent<TextMeshProUGUI>().enableVertexGradient = true;
                    cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_top/TextTM").gameObject.GetComponent<TextMeshProUGUI>().colorGradient = attrGradient;
                }
                else
                {
                    cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_base0" + (idx + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().text
                    = cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_base0" + (idx + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().text.Replace("<material=\"TMC00\">", "");
                    cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_base0" + (idx + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().outlineColor = attrColour;
                    cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_base0" + (idx + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().enableVertexGradient = true;
                    cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_base0" + (idx + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().colorGradient = attrGradient;
                }
            }
        }

        [HarmonyPatch(typeof(cmpInit), nameof(cmpInit.cmpItemTextSet))]
        private class cmpItemTextColourPatch
        {
            public static void Postfix(ref int idx, ref string text, ref uint col, ref int dType, ref int cType)
            {
                var items = cmpInit.CMP_GBWK.ItemIdx.Where(x => x != 0);
                if (items.Any()) 
                {
                    ushort itemId = 0;
                    foreach (var item in items)
                    {
                        var itemName = datItemName.Get(item);
                        if (itemName == text)
                        {
                            itemId = item; break;
                        }
                    }

                    var itemSkillId = datItem.tbl[itemId].skillid;
                    var itemSkillAttr = datSkill.tbl[itemSkillId].skillattr;
                    Color attrColour = GetSkillAttrColour(itemSkillAttr, 1);
                    VertexGradient attrGradient = GetSkillAttrGradient(attrColour, 1);

                    if (idx == 0)
                    {
                        cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_top/TextTM").gameObject.GetComponent<TextMeshProUGUI>().text
                        = cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_top/TextTM").gameObject.GetComponent<TextMeshProUGUI>().text.Replace("<material=\"TMC00\">", "").Replace("<material=\"TMC02\">", "");
                        cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_top/TextTM").gameObject.GetComponent<TextMeshProUGUI>().outlineColor = attrColour;
                        cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_top/TextTM").gameObject.GetComponent<TextMeshProUGUI>().enableVertexGradient = true;
                        cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_top/TextTM").gameObject.GetComponent<TextMeshProUGUI>().colorGradient = attrGradient;
                    }
                    else
                    {
                        cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_base0" + (idx + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().text
                        = cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_base0" + (idx + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().text.Replace("<material=\"TMC00\">", "").Replace("<material=\"TMC02\">", "");
                        cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_base0" + (idx + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().outlineColor = attrColour;
                        cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_base0" + (idx + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().enableVertexGradient = true;
                        cmpInit._campUIScr.transform.Find("menu_itemskill/menu_item_window/menuitem_base0" + (idx + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().colorGradient = attrGradient;
                    }
                }
            }
        }

        [HarmonyPatch(typeof(cmpDrawStatus), nameof(cmpDrawStatus.cmpDrawSkill))]
        private class cmpDrawSkillColourPatch
        {
            public static void Postfix(ref int X, ref int Y, ref uint[] pBaseCol, ref datUnitWork_t pStock, ref rstSkillInfo_t pSkillInfo, ref sbyte CursorPos, 
                                       ref sbyte CursorMode, ref uint NextSkillColor, ref sbyte DrawMode, ref uint Style)
            {
                foreach (int skill in pStock.skill.Where(x => x != 0))
                {
                    var skillAttr = datSkill.tbl[skill].skillattr;
                    Color attrColour = GetSkillAttrColour(skillAttr, 1);
                    VertexGradient attrGradient = GetSkillAttrGradient(attrColour, 1);

                    cmpStatus._statusUIScr.transform.Find("sskill/sskill_obtained0" + (pStock.skill.IndexOf(skill) + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().text
                    = cmpStatus._statusUIScr.transform.Find("sskill/sskill_obtained0" + (pStock.skill.IndexOf(skill) + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().text.Replace("<material=\"TMC00\">", "").Replace("<material=\"TMC21\">", "");
                    cmpStatus._statusUIScr.transform.Find("sskill/sskill_obtained0" + (pStock.skill.IndexOf(skill) + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().outlineColor = attrColour;
                    cmpStatus._statusUIScr.transform.Find("sskill/sskill_obtained0" + (pStock.skill.IndexOf(skill) + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().enableVertexGradient = true;
                    cmpStatus._statusUIScr.transform.Find("sskill/sskill_obtained0" + (pStock.skill.IndexOf(skill) + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().colorGradient = attrGradient;
                }
                foreach (ushort skill in pSkillInfo.SkillID.Where(x => x != 0))
                {
                    var skillAttr = datSkill.tbl[skill].skillattr;
                    Color attrColour = GetSkillAttrColour(skillAttr, 0.7f);
                    VertexGradient attrGradient = GetSkillAttrGradient(attrColour, 0.7f);

                    cmpStatus._statusUIScr.transform.Find("sskill/sskill_await2_0" + (pSkillInfo.SkillID.IndexOf(skill) + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 0.7f);
                    cmpStatus._statusUIScr.transform.Find("sskill/sskill_await2_0" + (pSkillInfo.SkillID.IndexOf(skill) + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().outlineColor = attrColour;
                    cmpStatus._statusUIScr.transform.Find("sskill/sskill_await2_0" + (pSkillInfo.SkillID.IndexOf(skill) + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().enableVertexGradient = true;
                    cmpStatus._statusUIScr.transform.Find("sskill/sskill_await2_0" + (pSkillInfo.SkillID.IndexOf(skill) + 1) + "/TextTM").gameObject.GetComponent<TextMeshProUGUI>().colorGradient = attrGradient;
                }
            }
        }

        [HarmonyPatch(typeof(cmpDrawStatus), nameof(cmpDrawStatus.cmpDrawStatusComEx2))]
        private class cmpDrawSkillColourPatch2
        {
            public static void Postfix(ref datUnitWork_t pStock, ref int X, ref int Y, ref byte Alpha, ref sbyte CursorPos, ref sbyte CursorMode, ref sbyte[] pParamOfs, 
                                       ref short SkillLevOfs, ref uint NextSkillColor, ref sbyte Style, ref sbyte FlashMode, ref sbyte SkillMode, ref sbyte modeldraw)
            {
                var birthDevilId = fclCombineInit.CMB_GBWK.BirthDevil.id;
                var birthDevilSkillTbl = tblSkill.fclSkillTbl[birthDevilId].Event;
                var baseSkillCount = birthDevilSkillTbl.Where(x => x.Type == 1 && x.TargetLevel == 0).Count();

                if (Style == 3)
                {
                    if (pStock.mitamaparam.Where(x => x != 0).Any())
                        baseSkillCount = 0;

                    for (int i = baseSkillCount + 1; i <= pStock.skillcnt; i++)
                    {
                        cmpStatus._statusUIScr.transform.Find("sskill/sskill_base/sskill_base0" + i + "/skill_select_waku").gameObject.active = true;
                    }
                }
                else 
                {
                    try
                    {
                        for (int i = 1; i <= 8; i++)
                        {
                            cmpStatus._statusUIScr.transform.Find("sskill/sskill_base/sskill_base0" + i + "/skill_select_waku").gameObject.active = false;
                        }
                    }
                    catch { }
                }
            }
        }

        [HarmonyPatch(typeof(fclShopDraw), nameof(fclShopDraw.shpDrawItem))]
        private class shpDrawItemColourPatch
        {
            public static void Postfix(ref string path, ref uint col, ref ushort item, ref int price)
            {
                var itemSkillId = datItem.tbl[item].skillid;
                var itemSkillAttr = datSkill.tbl[itemSkillId].skillattr;
                Color attrColour = col == 2
                    ? GetSkillAttrColour(itemSkillAttr, 0.7f)
                    : GetSkillAttrColour(itemSkillAttr, 1);
                VertexGradient attrGradient = col == 2
                        ? GetSkillAttrGradient(attrColour, 0.7f)
                        : GetSkillAttrGradient(attrColour, 1);

                fclUI.GetGameObject("shoplist").transform.Find("shop_row/" + path + "/Text_nameTM").gameObject.GetComponent<TextMeshProUGUI>().text
                    = fclUI.GetGameObject("shoplist").transform.Find("shop_row/" + path + "/Text_nameTM").gameObject.GetComponent<TextMeshProUGUI>().text.Replace("<material=\"TMC00\">", "");
                fclUI.GetGameObject("shoplist").transform.Find("shop_row/" + path + "/Text_nameTM").gameObject.GetComponent<TextMeshProUGUI>().color = col == 2 ? new Color(1, 1, 1, 0.7f) : new Color(1, 1, 1, 1);
                fclUI.GetGameObject("shoplist").transform.Find("shop_row/" + path + "/Text_nameTM").gameObject.GetComponent<TextMeshProUGUI>().outlineColor = attrColour;
                fclUI.GetGameObject("shoplist").transform.Find("shop_row/" + path + "/Text_nameTM").gameObject.GetComponent<TextMeshProUGUI>().enableVertexGradient = true;
                fclUI.GetGameObject("shoplist").transform.Find("shop_row/" + path + "/Text_nameTM").gameObject.GetComponent<TextMeshProUGUI>().colorGradient = attrGradient;
            }
        }

        [HarmonyPatch(typeof(fclRagDraw), nameof(fclRagDraw.ragDrawItemWindow))]
        private class ragDrawItemColourPatch
        {
            public static void Postfix(ref lstListWindow_t pListWindow, ref byte Type, ref sbyte[] pIdxList, ref int top, ref sbyte Mode)
            {
                for (int i = 1; i <= 10; i++) 
                {
                    string index = i < 10 ? "0" + i: i.ToString();
                    var text = fclUI.GetGameObject("ragitemlist").transform.Find("ragitem_row/ragitem_row" + index + "/Text_nameTM").gameObject.GetComponent<TextMeshProUGUI>().text.Replace("<material=\"TMC00\">", "").Replace("<material=\"TMC01\">", "");
                    ushort itemId = 0;
                    var items = fclRagShopTable.fclRagItemTbl.Where(x => x.ItemID != 0);
                    foreach (var item in items)
                    {
                        var itemName = datItemName.Get(item.ItemID);
                        if (itemName == text)
                        {
                            itemId = item.ItemID; break;
                        }
                    }

                    var itemSkillId = datItem.tbl[itemId].skillid;
                    var itemSkillAttr = datSkill.tbl[itemSkillId].skillattr;
                    Color attrColour = GetSkillAttrColour(itemSkillAttr, 1);
                    VertexGradient attrGradient = GetSkillAttrGradient(attrColour, 1);

                    fclUI.GetGameObject("ragitemlist").transform.Find("ragitem_row/ragitem_row" + index + "/Text_nameTM").gameObject.GetComponent<TextMeshProUGUI>().text
                        = fclUI.GetGameObject("ragitemlist").transform.Find("ragitem_row/ragitem_row" + index + "/Text_nameTM").gameObject.GetComponent<TextMeshProUGUI>().text.Replace("<material=\"TMC00\">", "").Replace("<material=\"TMC01\">", "");
                    fclUI.GetGameObject("ragitemlist").transform.Find("ragitem_row/ragitem_row" + index + "/Text_nameTM").gameObject.GetComponent<TextMeshProUGUI>().outlineColor = attrColour;
                    fclUI.GetGameObject("ragitemlist").transform.Find("ragitem_row/ragitem_row" + index + "/Text_nameTM").gameObject.GetComponent<TextMeshProUGUI>().enableVertexGradient = true;
                    fclUI.GetGameObject("ragitemlist").transform.Find("ragitem_row/ragitem_row" + index + "/Text_nameTM").gameObject.GetComponent<TextMeshProUGUI>().colorGradient = attrGradient;
                }
            }
        }

        [HarmonyPatch(typeof(fclRagDraw), nameof(fclRagDraw.ragDrawDevilWindow))]
        private class ragDrawDevilWindowColourPatch
        {
            public static void Postfix(ref lstListWindow_t pListWindow, ref byte Type, ref sbyte[] pIdxList, ref int top, ref sbyte Mode)
            {
                for (int i = 1; i <= 10; i++)
                {
                    string index = i < 10 ? "0" + i : i.ToString();
                    fclUI.GetGameObject("ragitemlist").transform.Find("ragitem_row/ragitem_row" + index + "/Text_nameTM").gameObject.GetComponent<TextMeshProUGUI>().enableVertexGradient = false;
                }
            }
        }

        public static Color GetSkillAttrColour(sbyte skillAttr, float a)
        {
            switch (skillAttr)
            {
                case 00: return new Color(0.788f, 0.000f, 0.000f, a); // Phys
                case 01: return new Color(1.000f, 0.369f, 0.000f, a); // Fire
                case 02: return new Color(0.239f, 0.560f, 1.000f, a); // Ice
                case 03: return new Color(1.000f, 0.784f, 0.000f, a); // Elec
                case 04: return new Color(0.055f, 0.702f, 0.000f, a); // Force
                case 05: return new Color(0.220f, 0.220f, 0.220f, a); // Almighty
                case 06: return new Color(0.851f, 0.800f, 0.500f, a); // Light
                case 07: return new Color(0.212f, 0.000f, 0.671f, a); // Dark
                case 08: return new Color(0.588f, 0.224f, 1.000f, a); // Curse
                case 09: return new Color(0.651f, 0.412f, 0.000f, a); // Nerve
                case 10: return new Color(0.788f, 0.000f, 0.839f, a); // Mind
                case 11: return new Color(0.220f, 0.220f, 0.220f, a); // Self-Destruct
                case 13: return new Color(0.851f, 0.447f, 0.682f, a); // Heal
                case 14: return new Color(0.282f, 0.929f, 0.624f, a); // Support
                default: return new Color(0.294f, 0.294f, 0.980f, a); // Default
            }
        }

        public static VertexGradient GetSkillAttrGradient(Color attrColour, float a)
        {
            return new VertexGradient { topLeft = new Color(1, 1, 1, a), topRight = new Color(1, 1, 1, a), bottomLeft = attrColour, bottomRight = attrColour };
        }
    }
}
