﻿using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using Il2Cppnewdata_H;
using Il2Cppresult2_H;
using Il2CppTMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Xml.Linq;
using Il2Cppnewbattle_H;

namespace NocturneInsaniax
{
    internal partial class NocturneInsaniax : MelonMod
    {
        private static Dictionary<ushort, InnateSkill> innateSkills = new Dictionary<ushort, InnateSkill>
        {
            { 000, new InnateSkill(383, "", "Description")}, // 000
            { 001, new InnateSkill(383, "Vishnu", "Description")}, // 001 Vishnu
            { 002, new InnateSkill(383, "Mitra", "Description")}, // 002 Mitra
            { 003, new InnateSkill(383, "Amaterasu", "Description")}, // 003 Amaterasu
            { 004, new InnateSkill(383, "Odin", "Description")}, // 004 Odin
            { 005, new InnateSkill(383, "Atavaka", "Description")}, // 005 Atavaka
            { 006, new InnateSkill(383, "Horus", "Description")}, // 006 Horus
            { 007, new InnateSkill(383, "Lakshmi", "Description")}, // 007 Lakshmi
            { 008, new InnateSkill(383, "Scathach", "Description")}, // 008 Scathach
            { 009, new InnateSkill(383, "Sarasvati", "Description")}, // 009 Sarasvati
            { 010, new InnateSkill(383, "Sati", "Description")}, // 010 Sati
            { 011, new InnateSkill(383, "Ame-no-Uzume", "Description")}, // 011 Ame-no-Uzume
            { 012, new InnateSkill(383, "Shiva", "Description")}, // 012 Shiva
            { 013, new InnateSkill(383, "Beidou Xingjun", "Description")}, // 013 Beidou Xingjun
            { 014, new InnateSkill(383, "Qitian Dasheng", "Description")}, // 014 Qitian Dasheng
            { 015, new InnateSkill(383, "Dionysus", "Description")}, // 015 Dionysus
            { 016, new InnateSkill(383, "Kali", "Description")}, // 016 Kali
            { 017, new InnateSkill(383, "Skadi", "Description")}, // 017 Skadi
            { 018, new InnateSkill(383, "Parvati", "Description")}, // 018 Parvati
            { 019, new InnateSkill(383, "Kushinada", "Description")}, // 019 Kushinada
            { 020, new InnateSkill(383, "Kikuri-Hime", "Description")}, // 020 Kikuri-Hime
            { 021, new InnateSkill(383, "Bishamonten", "Description")}, // 021 Bishamonten
            { 022, new InnateSkill(383, "Thor", "Description")}, // 022 Thor
            { 023, new InnateSkill(383, "Jikokuten", "Description")}, // 023 Jikokuten
            { 024, new InnateSkill(383, "Take-Mikazuchi", "Description")}, // 024 Take-Mikazuchi
            { 025, new InnateSkill(383, "Okuninushi", "Description")}, // 025 Okuninushi
            { 026, new InnateSkill(383, "Koumokuten", "Description")}, // 026 Koumokuten
            { 027, new InnateSkill(383, "Zouchouten", "Description")}, // 027 Zouchouten
            { 028, new InnateSkill(383, "Take-Minakata", "Description")}, // 028 Take-Minakata
            { 029, new InnateSkill(383, "Chimera", "Description")}, // 029 Chimera
            { 030, new InnateSkill(383, "Baihu", "Description")}, // 030 Baihu
            { 031, new InnateSkill(383, "Senri", "Description")}, // 031 Senri
            { 032, new InnateSkill(383, "Zhuque", "Description")}, // 032 Zhuque
            { 033, new InnateSkill(383, "Shiisaa", "Description")}, // 033 Shiisaa
            { 034, new InnateSkill(383, "Xiezhai", "Description")}, // 034 Xiezhai
            { 035, new InnateSkill(383, "Unicorn", "Description")}, // 035 Unicorn
            { 036, new InnateSkill(383, "Flaemis", "Description")}, // 036 Flaemis
            { 037, new InnateSkill(383, "Aquans", "Description")}, // 037 Aquans
            { 038, new InnateSkill(383, "Aeros", "Description")}, // 038 Aeros
            { 039, new InnateSkill(383, "Erthys", "Description")}, // 039 Erthys
            { 040, new InnateSkill(383, "Saki Mitama", "Description")}, // 040 Saki Mitama
            { 041, new InnateSkill(383, "Kushi Mitama", "Description")}, // 041 Kushi Mitama
            { 042, new InnateSkill(383, "Nigi Mitama", "Description")}, // 042 Nigi Mitama
            { 043, new InnateSkill(383, "Ara Mitama", "Description")}, // 043 Ara Mitama
            { 044, new InnateSkill(383, "Efreet", "Description")}, // 044 Efreet
            { 045, new InnateSkill(383, "Pulukishi", "Description")}, // 045 Pulukishi
            { 046, new InnateSkill(383, "Ongkhot", "Description")}, // 046 Ongkhot
            { 047, new InnateSkill(383, "Jinn", "Description")}, // 047 Jinn
            { 048, new InnateSkill(383, "Karasu Tengu", "Description")}, // 048 Karasu Tengu
            { 049, new InnateSkill(383, "Dís", "Description")}, // 049 Dís
            { 050, new InnateSkill(383, "Isora", "Description")}, // 050 Isora
            { 051, new InnateSkill(383, "Apsaras", "Description")}, // 051 Apsaras
            { 052, new InnateSkill(383, "Koppa Tengu", "Description")}, // 052 Koppa Tengu
            { 053, new InnateSkill(383, "Titania", "Description")}, // 053 Titania
            { 054, new InnateSkill(383, "Oberon", "Description")}, // 054 Oberon
            { 055, new InnateSkill(383, "Troll", "Description")}, // 055 Troll
            { 056, new InnateSkill(383, "Setanta", "Description")}, // 056 Setanta
            { 057, new InnateSkill(383, "Kelpie", "Description")}, // 057 Kelpie
            { 058, new InnateSkill(383, "Jack-o'-Lantern", "Description")}, // 058 Jack-o'-Lantern
            { 059, new InnateSkill(383, "High Pixie", "Description")}, // 059 High Pixie
            { 060, new InnateSkill(383, "Jack Frost", "Description")}, // 060 Jack Frost
            { 061, new InnateSkill(383, "Pixie", "Description")}, // 061 Pixie
            { 062, new InnateSkill(383, "Throne", "Description")}, // 062 Throne
            { 063, new InnateSkill(383, "Dominion", "Description")}, // 063 Dominion
            { 064, new InnateSkill(383, "Virtue", "Description")}, // 064 Virtue
            { 065, new InnateSkill(383, "Power", "Description")}, // 065 Power
            { 066, new InnateSkill(383, "Principality", "Description")}, // 066 Principality
            { 067, new InnateSkill(383, "Archangel", "Description")}, // 067 Archangel
            { 068, new InnateSkill(383, "Angel", "Description")}, // 068 Angel
            { 069, new InnateSkill(383, "Flauros", "Description")}, // 069 Flauros
            { 070, new InnateSkill(383, "Decarabia", "Description")}, // 070 Decarabia
            { 071, new InnateSkill(383, "Ose", "Description")}, // 071 Ose
            { 072, new InnateSkill(383, "Berith", "Description")}, // 072 Berith
            { 073, new InnateSkill(383, "Eligor", "Description")}, // 073 Eligor
            { 074, new InnateSkill(383, "Forneus", "Description")}, // 074 Forneus
            { 075, new InnateSkill(383, "Yurlungur", "Description")}, // 075 Yurlungur
            { 076, new InnateSkill(383, "Quetzalcoatl", "Description")}, // 076 Quetzalcoatl
            { 077, new InnateSkill(383, "Naga Raja", "Description")}, // 077 Naga Raja
            { 078, new InnateSkill(383, "Mizuchi", "Description")}, // 078 Mizuchi
            { 079, new InnateSkill(383, "Naga", "Description")}, // 079 Naga
            { 080, new InnateSkill(383, "Nozuchi", "Description")}, // 080 Nozuchi
            { 081, new InnateSkill(383, "Cerberus", "Description")}, // 081 Cerberus
            { 082, new InnateSkill(383, "Orthrus", "Description")}, // 082 Orthrus
            { 083, new InnateSkill(383, "Suparna", "Description")}, // 083 Suparna
            { 084, new InnateSkill(383, "Badb Catha", "Description")}, // 084 Badb Catha
            { 085, new InnateSkill(383, "Inugami", "Description")}, // 085 Inugami
            { 086, new InnateSkill(383, "Nekomata", "Description")}, // 086 Nekomata
            { 087, new InnateSkill(383, "Gogmagog", "Description")}, // 087 Gogmagog
            { 088, new InnateSkill(383, "Titan", "Description")}, // 088 Titan
            { 089, new InnateSkill(383, "Sarutahiko", "Description")}, // 089 Sarutahiko
            { 090, new InnateSkill(383, "Sudama", "Description")}, // 090 Sudama
            { 091, new InnateSkill(383, "Hua Po", "Description")}, // 091 Hua Po
            { 092, new InnateSkill(383, "Kodama", "Description")}, // 092 Kodama
            { 093, new InnateSkill(383, "Shiki-Ouji", "Description")}, // 093 Shiki-Ouji
            { 094, new InnateSkill(383, "Oni", "Description")}, // 094 Oni
            { 095, new InnateSkill(383, "Yomotsu-Ikusa", "Description")}, // 095 Yomotsu-Ikusa
            { 096, new InnateSkill(383, "Momunofu", "Description")}, // 096 Momunofu
            { 097, new InnateSkill(383, "Shikigami", "Description")}, // 097 Shikigami
            { 098, new InnateSkill(383, "Rangda", "Description")}, // 098 Rangda
            { 099, new InnateSkill(383, "Dakini", "Description")}, // 099 Dakini
            { 100, new InnateSkill(383, "Yaksini", "Description")}, // 100 Yaksini
            { 101, new InnateSkill(383, "Yomotsu-Shikome", "Description")}, // 101 Yomotsu-Shikome
            { 102, new InnateSkill(383, "Taraka", "Description")}, // 102 Taraka
            { 103, new InnateSkill(383, "Datsue-Ba", "Description")}, // 103 Datsue-Ba
            { 104, new InnateSkill(383, "Mada", "Description")}, // 104 Mada
            { 105, new InnateSkill(383, "Girimekhala", "Description")}, // 105 Girimekhala
            { 106, new InnateSkill(383, "Taotie", "Description")}, // 106 Taotie
            { 107, new InnateSkill(383, "Pazuzu", "Description")}, // 107 Pazuzu
            { 108, new InnateSkill(383, "Baphomet", "Description")}, // 108 Baphomet
            { 109, new InnateSkill(383, "Mot", "Description")}, // 109 Mot
            { 110, new InnateSkill(383, "Alciel", "Description")}, // 110 Alciel
            { 111, new InnateSkill(383, "Surt", "Description")}, // 111 Surt
            { 112, new InnateSkill(383, "Abaddon", "Description")}, // 112 Abaddon
            { 113, new InnateSkill(383, "Loki", "Description")}, // 113 Loki
            { 114, new InnateSkill(383, "Lilith", "Description")}, // 114 Lilith
            { 115, new InnateSkill(383, "Nyx", "Description")}, // 115 Nyx
            { 116, new InnateSkill(383, "Queen Mab", "Description")}, // 116 Queen Mab
            { 117, new InnateSkill(383, "Succubus", "Description")}, // 117 Succubus
            { 118, new InnateSkill(383, "Incubus", "Description")}, // 118 Incubus
            { 119, new InnateSkill(383, "Fomorian", "Description")}, // 119 Fomorian
            { 120, new InnateSkill(383, "Lilim", "Description")}, // 120 Lilim
            { 121, new InnateSkill(383, "Hresvelgr", "Description")}, // 121 Hresvelgr
            { 122, new InnateSkill(383, "Mothman", "Description")}, // 122 Mothman
            { 123, new InnateSkill(383, "Raiju", "Description")}, // 123 Raiju
            { 124, new InnateSkill(383, "Nue", "Description")}, // 124 Nue
            { 125, new InnateSkill(383, "Bicorn", "Description")}, // 125 Bicorn
            { 126, new InnateSkill(383, "Zhen", "Description")}, // 126 Zhen
            { 127, new InnateSkill(383, "Vetala", "Description")}, // 127 Vetala
            { 128, new InnateSkill(383, "Legion", "Description")}, // 128 Legion
            { 129, new InnateSkill(383, "Yaka", "Description")}, // 129 Yaka
            { 130, new InnateSkill(383, "Choronzon", "Description")}, // 130 Choronzon
            { 131, new InnateSkill(383, "Preta", "Description")}, // 131 Preta
            { 132, new InnateSkill(383, "Shadow", "Description")}, // 132 Shadow
            { 133, new InnateSkill(383, "Black Ooze", "Description")}, // 133 Black Ooze
            { 134, new InnateSkill(383, "Blob", "Description")}, // 134 Blob
            { 135, new InnateSkill(383, "Slime", "Description")}, // 135 Slime
            { 136, new InnateSkill(383, "Mou-Ryo", "Description")}, // 136 Mou-Ryo
            { 137, new InnateSkill(383, "Will o' Wisp", "Description")}, // 137 Will o' Wisp
            { 138, new InnateSkill(383, "Michael", "Description")}, // 138 Michael
            { 139, new InnateSkill(383, "Gabriel", "Description")}, // 139 Gabriel
            { 140, new InnateSkill(383, "Raphael", "Description")}, // 140 Raphael
            { 141, new InnateSkill(383, "Uriel", "Description")}, // 141 Uriel
            { 142, new InnateSkill(383, "Ganesha", "Description")}, // 142 Ganesha
            { 143, new InnateSkill(383, "Valkyrie", "Description")}, // 143 Valkyrie
            { 144, new InnateSkill(383, "Arahabaki", "Description")}, // 144 Arahabaki
            { 145, new InnateSkill(383, "Kurama Tengu", "Description")}, // 145 Kurama Tengu
            { 146, new InnateSkill(383, "Hanuman", "Description")}, // 146 Hanuman
            { 147, new InnateSkill(383, "Cu Chulainn", "Description")}, // 147 Cu Chulainn
            { 148, new InnateSkill(383, "Qing Long", "Description")}, // 148 Qing Long
            { 149, new InnateSkill(383, "Xuanwu", "Description")}, // 149 Xuanwu
            { 150, new InnateSkill(383, "Barong", "Description")}, // 150 Barong
            { 151, new InnateSkill(383, "Makami", "Description")}, // 151 Makami
            { 152, new InnateSkill(383, "Garuda", "Description")}, // 152 Garuda
            { 153, new InnateSkill(383, "Yatagarasu", "Description")}, // 153 Yatagarasu
            { 154, new InnateSkill(383, "Gurulu", "Description")}, // 154 Gurulu
            { 155, new InnateSkill(383, "Albion", "Description")}, // 155 Albion
            { 156, new InnateSkill(383, "Manikin", "Description")}, // 156 Manikin
            { 157, new InnateSkill(383, "Manikin", "Description")}, // 157 Manikin
            { 158, new InnateSkill(383, "Manikin", "Description")}, // 158 Manikin
            { 159, new InnateSkill(383, "Manikin", "Description")}, // 159 Manikin
            { 160, new InnateSkill(383, "Manikin", "Description")}, // 160 Manikin
            { 161, new InnateSkill(383, "Samael", "Description")}, // 161 Samael
            { 162, new InnateSkill(383, "Manikin", "Description")}, // 162 Manikin
            { 163, new InnateSkill(383, "Manikin", "Description")}, // 163 Manikin
            { 164, new InnateSkill(383, "Manikin", "Description")}, // 164 Manikin
            { 165, new InnateSkill(383, "Manikin", "Description")}, // 165 Manikin
            { 166, new InnateSkill(383, "Manikin", "Description")}, // 166 Manikin
            { 167, new InnateSkill(383, "Pisaca", "Description")}, // 167 Pisaca
            { 168, new InnateSkill(383, "Kaiwan", "Description")}, // 168 Kaiwan
            { 169, new InnateSkill(383, "Kin-Ki", "Description")}, // 169 Kin-Ki
            { 170, new InnateSkill(383, "Sui-Ki", "Description")}, // 170 Sui-Ki
            { 171, new InnateSkill(383, "Fuu-Ki", "Description")}, // 171 Fuu-Ki
            { 172, new InnateSkill(383, "Ongyo-Ki", "Description")}, // 172 Ongyo-Ki
            { 173, new InnateSkill(383, "Clotho", "Description")}, // 173 Clotho
            { 174, new InnateSkill(383, "Lachesis", "Description")}, // 174 Lachesis
            { 175, new InnateSkill(383, "Atropos", "Description")}, // 175 Atropos
            { 176, new InnateSkill(383, "Loa", "Description")}, // 176 Loa
            { 177, new InnateSkill(383, "Chatterskull", "Description")}, // 177 Chatterskull
            { 178, new InnateSkill(383, "Phantom", "Description")}, // 178 Phantom
            { 179, new InnateSkill(383, "Ose Hallel", "Description")}, // 179 Ose Hallel
            { 180, new InnateSkill(383, "Flaurose Hallel", "Description")}, // 180 Flaurose Hallel
            { 181, new InnateSkill(383, "Urthona", "Description")}, // 181 Urthona
            { 182, new InnateSkill(383, "Urizen", "Description")}, // 182 Urizen
            { 183, new InnateSkill(383, "Luvah", "Description")}, // 183 Luvah
            { 184, new InnateSkill(383, "Tharmus", "Description")}, // 184 Tharmus
            { 185, new InnateSkill(383, "Specter", "Description")}, // 185 Specter
            { 186, new InnateSkill(383, "Mara", "Description")}, // 186 Mara
            { 187, new InnateSkill(383, "", "Description")}, // 187 
            { 188, new InnateSkill(383, "", "Description")}, // 188 
            { 189, new InnateSkill(383, "", "Description")}, // 189 
            { 190, new InnateSkill(383, "", "Description")}, // 190 
            { 191, new InnateSkill(383, "", "Description")}, // 191 
            { 192, new InnateSkill(383, "Raidou/Dante", "Description")}, // 192 Raidou/Dante
            { 193, new InnateSkill(383, "Metatron", "Description")}, // 193 Metatron
            { 194, new InnateSkill(383, "Beelzebub (Fly)", "Description")}, // 194 Beelzebub (Fly)
            { 195, new InnateSkill(383, "Pale Rider", "Description")}, // 195 Pale Rider
            { 196, new InnateSkill(383, "White Rider", "Description")}, // 196 White Rider
            { 197, new InnateSkill(383, "Red Rider", "Description")}, // 197 Red Rider
            { 198, new InnateSkill(383, "Black Rider", "Description")}, // 198 Black Rider
            { 199, new InnateSkill(383, "Matador", "Description")}, // 199 Matador
            { 200, new InnateSkill(383, "Hell Biker", "Description")}, // 200 Hell Biker
            { 201, new InnateSkill(383, "Daisoujou", "Description")}, // 201 Daisoujou
            { 202, new InnateSkill(383, "Mother Harlot", "Description")}, // 202 Mother Harlot
            { 203, new InnateSkill(383, "Trumpeter", "Description")}, // 203 Trumpeter
            { 204, new InnateSkill(383, "Futomimi", "Description")}, // 204 Futomimi
            { 205, new InnateSkill(383, "Sakahagi", "Description")}, // 205 Sakahagi
            { 206, new InnateSkill(383, "Black Frost", "Description")}, // 206 Black Frost
            { 207, new InnateSkill(383, "Beelzebub (Man)", "Description")}, // 207 Beelzebub (Man)
            { 208, new InnateSkill(383, "", "Description")}, // 208 
            { 209, new InnateSkill(383, "", "Description")}, // 209 
            { 210, new InnateSkill(383, "", "Description")}, // 210 
            { 211, new InnateSkill(383, "", "Description")}, // 211 
            { 212, new InnateSkill(383, "", "Description")}, // 212 
            { 213, new InnateSkill(383, "", "Description")}, // 213 
            { 214, new InnateSkill(383, "", "Description")}, // 214 
            { 215, new InnateSkill(383, "", "Description")}, // 215 
            { 216, new InnateSkill(383, "", "Description")}, // 216 
            { 217, new InnateSkill(383, "", "Description")}, // 217 
            { 218, new InnateSkill(383, "", "Description")}, // 218 
            { 219, new InnateSkill(383, "", "Description")}, // 219 
            { 220, new InnateSkill(383, "", "Description")}, // 220 
            { 221, new InnateSkill(383, "", "Description")}, // 221 
            { 222, new InnateSkill(383, "", "Description")}, // 222 
            { 223, new InnateSkill(383, "", "Description")}, // 223 
            { 224, new InnateSkill(383, "Tam Lin", "Description")}, // 224 Tam Lin
            { 225, new InnateSkill(383, "Doppelganger", "Description")}, // 225 Doppelganger
            { 226, new InnateSkill(419, "Nightmare", "Description")}, // 226 Nightmare
            { 227, new InnateSkill(383, "", "Description")}, // 227 
            { 228, new InnateSkill(383, "", "Description")}, // 228 
            { 229, new InnateSkill(383, "", "Description")}, // 229 
            { 230, new InnateSkill(383, "", "Description")}, // 230 
            { 231, new InnateSkill(383, "", "Description")}, // 231 
            { 232, new InnateSkill(383, "", "Description")}, // 232 
            { 233, new InnateSkill(383, "", "Description")}, // 233 
            { 234, new InnateSkill(383, "", "Description")}, // 234 
            { 235, new InnateSkill(383, "", "Description")}, // 235 
            { 236, new InnateSkill(383, "", "Description")}, // 236 
            { 237, new InnateSkill(383, "", "Description")}, // 237 
            { 238, new InnateSkill(383, "", "Description")}, // 238 
            { 239, new InnateSkill(383, "", "Description")}, // 239 
            { 240, new InnateSkill(383, "", "Description")}, // 240 
            { 241, new InnateSkill(383, "", "Description")}, // 241 
            { 242, new InnateSkill(383, "", "Description")}, // 242 
            { 243, new InnateSkill(383, "", "Description")}, // 243 
            { 244, new InnateSkill(383, "", "Description")}, // 244 
            { 245, new InnateSkill(383, "", "Description")}, // 245 
            { 246, new InnateSkill(383, "", "Description")}, // 246 
            { 247, new InnateSkill(383, "", "Description")}, // 247 
            { 248, new InnateSkill(383, "", "Description")}, // 248 
            { 249, new InnateSkill(383, "", "Description")}, // 249 
            { 250, new InnateSkill(383, "", "Description")}, // 250 
            { 251, new InnateSkill(383, "", "Description")}, // 251 
            { 252, new InnateSkill(383, "Devil Dante", "Description")}, // 252 Devil Dante
            { 253, new InnateSkill(383, "Gamete", "Description")}, // 253 Gamete
            { 254, new InnateSkill(383, "YHVH", "Description")}, // 254 YHVH
            { 255, new InnateSkill(383, "", "Description")}, // 255 
            { 256, new InnateSkill(383, "Boss Forneus", "Description")}, // 256 Boss Forneus
            { 257, new InnateSkill(383, "Boss Specter 1 (Mini)", "Description")}, // 257 Boss Specter 1 (Mini)
            { 258, new InnateSkill(383, "Boss Ahriman 2", "Description")}, // 258 Boss Ahriman 2
            { 259, new InnateSkill(383, "Boss Noah 2", "Description")}, // 259 Boss Noah 2
            { 260, new InnateSkill(383, "Forced Incubus", "Description")}, // 260 Forced Incubus
            { 261, new InnateSkill(383, "Forced Koppa Tengu", "Description")}, // 261 Forced Koppa Tengu
            { 262, new InnateSkill(383, "Forced Kaiwan", "Description")}, // 262 Forced Kaiwan
            { 263, new InnateSkill(383, "Boss Ose", "Description")}, // 263 Boss Ose
            { 264, new InnateSkill(383, "Boss Kagutsuchi 2", "Description")}, // 264 Boss Kagutsuchi 2
            { 265, new InnateSkill(383, "Ambush Mizuchi", "Description")}, // 265 Ambush Mizuchi
            { 266, new InnateSkill(383, "Boss Kin-Ki", "Description")}, // 266 Boss Kin-Ki
            { 267, new InnateSkill(383, "Boss Sui-Ki", "Description")}, // 267 Boss Sui-Ki
            { 268, new InnateSkill(383, "Boss Fuu-Ki", "Description")}, // 268 Boss Fuu-Ki
            { 269, new InnateSkill(383, "Boss Ongyo-Ki", "Description")}, // 269 Boss Ongyo-Ki
            { 270, new InnateSkill(383, "Boss Clotho (Solo)", "Description")}, // 270 Boss Clotho (Solo)
            { 271, new InnateSkill(383, "Boss Lachesis (Solo)", "Description")}, // 271 Boss Lachesis (Solo)
            { 272, new InnateSkill(383, "Boss Atropos (Solo)", "Description")}, // 272 Boss Atropos (Solo)
            { 273, new InnateSkill(383, "Boss Specter 2", "Description")}, // 273 Boss Specter 2
            { 274, new InnateSkill(383, "Boss Girimekhala", "Description")}, // 274 Boss Girimekhala
            { 275, new InnateSkill(383, "Boss Specter 3", "Description")}, // 275 Boss Specter 3
            { 276, new InnateSkill(383, "Boss Aciel", "Description")}, // 276 Boss Aciel
            { 277, new InnateSkill(383, "Boss Skadi", "Description")}, // 277 Boss Skadi
            { 278, new InnateSkill(383, "Boss Albion", "Description")}, // 278 Boss Albion
            { 279, new InnateSkill(383, "Boss Urthona", "Description")}, // 279 Boss Urthona
            { 280, new InnateSkill(383, "Boss Urizen", "Description")}, // 280 Boss Urizen
            { 281, new InnateSkill(383, "Boss Luvah", "Description")}, // 281 Boss Luvah
            { 282, new InnateSkill(383, "Boss Tharmus", "Description")}, // 282 Boss Tharmus
            { 283, new InnateSkill(383, "Boss Futomimi", "Description")}, // 283 Boss Futomimi
            { 284, new InnateSkill(383, "Boss Gabriel", "Description")}, // 284 Boss Gabriel
            { 285, new InnateSkill(383, "Boss Raphael", "Description")}, // 285 Boss Raphael
            { 286, new InnateSkill(383, "Boss Uriel", "Description")}, // 286 Boss Uriel
            { 287, new InnateSkill(383, "Boss Samael", "Description")}, // 287 Boss Samael
            { 288, new InnateSkill(383, "Boss Baal Avatar", "Description")}, // 288 Boss Baal Avatar
            { 289, new InnateSkill(383, "Boss Ose Hallel", "Description")}, // 289 Boss Ose Hallel
            { 290, new InnateSkill(383, "Boss Flauros Hallel", "Description")}, // 290 Boss Flauros Hallel
            { 291, new InnateSkill(383, "Boss Ahriman 1", "Description")}, // 291 Boss Ahriman 1
            { 292, new InnateSkill(383, "Boss Noah 1", "Description")}, // 292 Boss Noah 1
            { 293, new InnateSkill(383, "Boss Kagutsuchi 1", "Description")}, // 293 Boss Kagutsuchi 1
            { 294, new InnateSkill(383, "Boss Specter 1 (Merged 6)", "Description")}, // 294 Boss Specter 1 (Merged 6)
            { 295, new InnateSkill(383, "Boss Specter 1 (Merged 4-5)", "Description")}, // 295 Boss Specter 1 (Merged 4-5)
            { 296, new InnateSkill(383, "Boss Specter 1 (Merged 2-3)", "Description")}, // 296 Boss Specter 1 (Merged 2-3)
            { 297, new InnateSkill(383, "Boss Mizuchi", "Description")}, // 297 Boss Mizuchi
            { 298, new InnateSkill(383, "", "Description")}, // 298 
            { 299, new InnateSkill(383, "Boss Sakahagi", "Description")}, // 299 Boss Sakahagi
            { 300, new InnateSkill(383, "Boss Orthrus", "Description")}, // 300 Boss Orthrus
            { 301, new InnateSkill(383, "Boss Yaksini", "Description")}, // 301 Boss Yaksini
            { 302, new InnateSkill(383, "Boss Thor", "Description")}, // 302 Boss Thor
            { 303, new InnateSkill(383, "Boss Black Frost", "Description")}, // 303 Boss Black Frost
            { 304, new InnateSkill(383, "Ambush Karasu Tengu", "Description")}, // 304 Ambush Karasu Tengu
            { 305, new InnateSkill(383, "Ambush Karasu Tengu", "Description")}, // 305 Ambush Karasu Tengu
            { 306, new InnateSkill(383, "Ambush Karasu Tengu", "Description")}, // 306 Ambush Karasu Tengu
            { 307, new InnateSkill(383, "Boss Eligor", "Description")}, // 307 Boss Eligor
            { 308, new InnateSkill(383, "Boss Eligor", "Description")}, // 308 Boss Eligor
            { 309, new InnateSkill(383, "Boss Eligor", "Description")}, // 309 Boss Eligor
            { 310, new InnateSkill(383, "Ambush Kelpie", "Description")}, // 310 Ambush Kelpie
            { 311, new InnateSkill(383, "Ambush Kelpie", "Description")}, // 311 Ambush Kelpie
            { 312, new InnateSkill(383, "Boss Berith", "Description")}, // 312 Boss Berith
            { 313, new InnateSkill(383, "Boss Succubus", "Description")}, // 313 Boss Succubus
            { 314, new InnateSkill(383, "Ambush High Pixie", "Description")}, // 314 Ambush High Pixie
            { 315, new InnateSkill(383, "Boss Kaiwan", "Description")}, // 315 Boss Kaiwan
            { 316, new InnateSkill(383, "Forced Nekomata", "Description")}, // 316 Forced Nekomata
            { 317, new InnateSkill(383, "Boss Troll", "Description")}, // 317 Boss Troll
            { 318, new InnateSkill(383, "Forced Will o' Wisp", "Description")}, // 318 Forced Will o' Wisp
            { 319, new InnateSkill(383, "Forced Preta", "Description")}, // 319 Forced Preta
            { 320, new InnateSkill(383, "Boss Bishamonten 1", "Description")}, // 320 Boss Bishamonten 1
            { 321, new InnateSkill(383, "Boss Mara", "Description")}, // 321 Boss Mara
            { 322, new InnateSkill(383, "Boss Bishamonten 2", "Description")}, // 322 Boss Bishamonten 2
            { 323, new InnateSkill(383, "Boss Jikokuten", "Description")}, // 323 Boss Jikokuten
            { 324, new InnateSkill(383, "Boss Koumokuten", "Description")}, // 324 Boss Koumokuten
            { 325, new InnateSkill(383, "Boss Zouchouten", "Description")}, // 325 Boss Zouchouten
            { 326, new InnateSkill(383, "Boss Clotho (Together)", "Description")}, // 326 Boss Clotho (Together)
            { 327, new InnateSkill(383, "Boss Lachesis (Together)", "Description")}, // 327 Boss Lachesis (Together)
            { 328, new InnateSkill(383, "Boss Atropos (Together)", "Description")}, // 328 Boss Atropos (Together)
            { 329, new InnateSkill(383, "Boss Mitra", "Description")}, // 329 Boss Mitra
            { 330, new InnateSkill(383, "", "Description")}, // 330 
            { 331, new InnateSkill(383, "", "Description")}, // 331 
            { 332, new InnateSkill(383, "", "Description")}, // 332 
            { 333, new InnateSkill(383, "Boss Mada", "Description")}, // 333 Boss Mada
            { 334, new InnateSkill(383, "Boss Mot", "Description")}, // 334 Boss Mot
            { 335, new InnateSkill(383, "Boss Surt", "Description")}, // 335 Boss Surt
            { 336, new InnateSkill(383, "Ambush Jack-o'-Lantern", "Description")}, // 336 Ambush Jack-o'-Lantern
            { 337, new InnateSkill(383, "Boss Thor 2", "Description")}, // 337 Boss Thor 2
            { 338, new InnateSkill(383, "", "Description")}, // 338 
            { 339, new InnateSkill(383, "Boss Raidou/Dante 1", "Description")}, // 339 Boss Raidou/Dante 1
            { 340, new InnateSkill(383, "Chase Raidou/Dante", "Description")}, // 340 Chase Raidou/Dante
            { 341, new InnateSkill(383, "Boss Raidou/Dante 2", "Description")}, // 341 Boss Raidou/Dante 2
            { 342, new InnateSkill(383, "Boss Metatron", "Description")}, // 342 Boss Metatron
            { 343, new InnateSkill(383, "Boss Beelzebub", "Description")}, // 343 Boss Beelzebub
            { 344, new InnateSkill(383, "Boss Lucifer", "Description")}, // 344 Boss Lucifer
            { 345, new InnateSkill(383, "Boss Pale Rider", "Description")}, // 345 Boss Pale Rider
            { 346, new InnateSkill(383, "Boss White Rider", "Description")}, // 346 Boss White Rider
            { 347, new InnateSkill(383, "Boss Red Rider", "Description")}, // 347 Boss Red Rider
            { 348, new InnateSkill(383, "Boss Black Rider", "Description")}, // 348 Boss Black Rider
            { 349, new InnateSkill(383, "Boss Matador", "Description")}, // 349 Boss Matador
            { 350, new InnateSkill(383, "Boss Hell Biker", "Description")}, // 350 Boss Hell Biker
            { 351, new InnateSkill(383, "Boss Daisoujou", "Description")}, // 351 Boss Daisoujou
            { 352, new InnateSkill(383, "Boss Mother Harlot", "Description")}, // 352 Boss Mother Harlot
            { 353, new InnateSkill(383, "Boss Trumpeter", "Description")}, // 353 Boss Trumpeter
            { 354, new InnateSkill(383, "", "Description")}, // 354 
            { 355, new InnateSkill(383, "", "Description")}, // 355 
            { 356, new InnateSkill(383, "", "Description")}, // 356 
            { 357, new InnateSkill(383, "", "Description")}, // 357 
            { 358, new InnateSkill(383, "Boss Loa", "Description")}, // 358 Boss Loa
            { 359, new InnateSkill(383, "Boss Virtue", "Description")}, // 359 Boss Virtue
            { 360, new InnateSkill(383, "Boss Power", "Description")}, // 360 Boss Power
            { 361, new InnateSkill(383, "Boss Legion", "Description")}, // 361 Boss Legion
            { 362, new InnateSkill(383, "Boss Flauros", "Description")}, // 362 Boss Flauros
            { 363, new InnateSkill(383, "", "Description")}, // 363 
            { 364, new InnateSkill(383, "", "Description")}, // 364 
            { 365, new InnateSkill(383, "", "Description")}, // 365 
            { 366, new InnateSkill(383, "", "Description")}, // 366 
            { 367, new InnateSkill(383, "", "Description")}, // 367 
            { 368, new InnateSkill(383, "", "Description")}, // 368 
            { 369, new InnateSkill(383, "", "Description")}, // 369 
            { 370, new InnateSkill(383, "", "Description")}, // 370 
            { 371, new InnateSkill(383, "", "Description")}, // 371 
            { 372, new InnateSkill(383, "", "Description")}, // 372 
            { 373, new InnateSkill(383, "", "Description")}, // 373 
            { 374, new InnateSkill(383, "", "Description")}, // 374 
            { 375, new InnateSkill(383, "", "Description")}, // 375 
            { 376, new InnateSkill(383, "", "Description")}, // 376 
            { 377, new InnateSkill(383, "", "Description")}, // 377 
            { 378, new InnateSkill(383, "", "Description")}, // 378 
            { 379, new InnateSkill(383, "", "Description")}, // 379 
            { 380, new InnateSkill(383, "", "Description")}, // 380 
            { 381, new InnateSkill(383, "", "Description")}, // 381 
            { 382, new InnateSkill(383, "", "Description")}, // 382 
            { 383, new InnateSkill(383, "", "Description")}  // 383 
        };

        static ushort innateSkillId = 383;

        [HarmonyPatch(typeof(cmpDrawStatus), nameof(cmpDrawStatus.cmpDrawSkill))]
        private class InnateSkillPatch1
        {
            // Before displaying skills in the status/level up/fusion/compendium menu 
            public static void Prefix(ref datUnitWork_t pStock, rstSkillInfo_t pSkillInfo)
            {
                // Add the trait skill to the list of displayed upcoming skills
                pSkillInfo.SkillID[pSkillInfo.SkillCnt] = innateSkillId;
                pSkillInfo.SkillCnt++;
            }

            // After displaying skills in the demon/magatama/level up/fusion/compendium status menu 
            public static void Postfix(datUnitWork_t pStock, rstSkillInfo_t pSkillInfo)
            {
                // For each upcoming skill
                for (int i = 0; i < pSkillInfo.SkillID.Length; i++)
                {
                    // Get the skill's ID
                    ushort skillID = pSkillInfo.SkillID[i];

                    // Don't do anything if there's no skill
                    if (skillID == 0) break;

                    if (skillID == 425 && pStock.id == 0)
                    {
                        // If you cannot get "Pierce"
                        if (!EventBit.evtBitCheck(2241))
                        {
                            cmpStatus._statusUIScr.awaitText[i].text = "？"; // Displays a "？"
                        }
                        continue; //Skip "Pierce" on Demi-fiend
                    }
                    else
                    {
                        string name = datSkillName.Get(skillID, pStock.id);

                        if (skillID == innateSkillId)
                        {
                            cmpStatus._statusUIScr.awaitText[i].text = EnableSkillColourOutlines.Value
                                ? name
                                : "<material=\"TMC01\">" + name;

                            cmpStatus._statusUIScr.transform.Find("sskill/sskill_await0" + (i + 1) + "/sskill_base").gameObject.active = false;
                            cmpStatus._statusUIScr.transform.Find("sskill/sskill_await0" + (i + 1) + "/sskill_base_2").gameObject.active = true;
                        }
                        else
                        {
                            cmpStatus._statusUIScr.awaitText[i].text = EnableSkillColourOutlines.Value
                                ? name
                                : "<material=\"TMC02\">" + name;

                            cmpStatus._statusUIScr.transform.Find("sskill/sskill_await0" + (i + 1) + "/sskill_base").gameObject.active = true;
                            cmpStatus._statusUIScr.transform.Find("sskill/sskill_await0" + (i + 1) + "/sskill_base_2").gameObject.active = false;
                        }
                    }
                }
            }
        }

        // After getting the name of a skill
        [HarmonyPatch(typeof(datSkillName), nameof(datSkillName.Get))]
        private class InnateSkillPatch2
        {
            public static void Postfix(int id, ref string __result)
            {
                // If it's the trait skill
                if (id == innateSkillId)
                {
                    string skillName;

                    // If it's Demi-fiend's trait skill
                    if (currentDemonID == 0)
                    {
                        // Display the name of the currently equipped magatama
                        skillName = datHeartsName.Get(dds3GlobalWork.DDS3_GBWK.heartsequip);
                        __result = "Trait: " + skillName;
                    }

                    // If it's a demon's trait skill
                    else
                    {
                        if (innateSkills[currentDemonID].skillId != 383)
                        {
                            __result = datSkillName.Get(innateSkills[currentDemonID].skillId);
                        }
                        else
                        {
                            __result = innateSkills[currentDemonID].skillName;
                        }
                    }
                }
            }
        }

        // After getting the description of a skill
        [HarmonyPatch(typeof(datSkillHelp_msg), nameof(datSkillHelp_msg.Get))]
        private class InnateSkillPatch3
        {
            public static void Postfix(int id, ref string __result)
            {
                // If it's the trait skill
                if (id == innateSkillId)
                {
                    // If it's Demi-fiend's trait skill
                    if (currentDemonID == 0)
                    {
                        // Display the name of the currently equipped magatama
                        __result = datHeartsName.Get(dds3GlobalWork.DDS3_GBWK.heartsequip) + "'s trait skill.";
                    }

                    // If it's a demon's trait skill
                    else
                    {
                        if (innateSkills[currentDemonID].skillId != 383)
                        {
                            __result = datSkillHelp_msg.Get(innateSkills[currentDemonID].skillId);
                        }
                        else
                        {
                            __result = innateSkills[currentDemonID].skillHelp;
                        }
                    }
                }
            }
        }

        // Before updating the cursor when selecting demons from the command menu
        [HarmonyPatch(typeof(cmpUpdate), nameof(cmpUpdate.cmpUpdateDevilSelect))]
        private class InnateSkillPatch4
        {
            public static void Prefix(sbyte BufIdx)
            {
                // Restrict the following code to the skill and party submenus (I couldn't find how to narrow it down further)
                if (BufIdx == 0)
                {
                    // For each demons in stock
                    for (int i = 0; i < dds3GlobalWork.DDS3_GBWK.unitwork.Length; i++)
                    {
                        // Skip "ghost" demon slots
                        if (i != 0 && dds3GlobalWork.DDS3_GBWK.unitwork[i].id == 0) continue;

                        // Get the ID of the last skill currently equipped and its index
                        int skillCount = dds3GlobalWork.DDS3_GBWK.unitwork[i].skillcnt;
                        int lastSkillIndex = skillCount - 1;
                        int lastSkill = dds3GlobalWork.DDS3_GBWK.unitwork[i].skill[lastSkillIndex];

                        // If it's not the trait skill, add it at the bottom of the list
                        if (lastSkill != innateSkillId)
                        {
                            dds3GlobalWork.DDS3_GBWK.unitwork[i].skill[lastSkillIndex + 1] = innateSkillId;
                            dds3GlobalWork.DDS3_GBWK.unitwork[i].skillcnt++;
                        }
                    }
                }
            }
        }

        // Before updating the cursor on the main command menu
        [HarmonyPatch(typeof(cmpUpdate), nameof(cmpUpdate.cmpUpdateRoot))]
        private class InnateSkillPatch5
        {
            public static void Prefix()
            {
                // For each demons in stock
                for (int i = 0; i < dds3GlobalWork.DDS3_GBWK.unitwork.Length; i++)
                {
                    // Skip "ghost" demon slots
                    if (i != 0 && dds3GlobalWork.DDS3_GBWK.unitwork[i].id == 0) continue;

                    // Get the ID of the last skill currently equipped and its index
                    int skillCount = dds3GlobalWork.DDS3_GBWK.unitwork[i].skillcnt;
                    int lastSkillIndex = skillCount - 1;
                    int lastSkill = dds3GlobalWork.DDS3_GBWK.unitwork[i].skill[lastSkillIndex];

                    // If it's the trait skill, remove it
                    if (lastSkill == innateSkillId)
                    {
                        dds3GlobalWork.DDS3_GBWK.unitwork[i].skill[lastSkillIndex] = 0;
                        dds3GlobalWork.DDS3_GBWK.unitwork[i].skillcnt--;
                    }
                }
            }
        }

        // After running the analysis panel
        [HarmonyPatch(typeof(nbPanelProcess), nameof(nbPanelProcess.nbPanelAnalyzeRun))]
        private class InnateSkillPatch6
        {
            public static void Postfix()
            {
                // There is someone to analyze
                if (nbPanelProcess.pNbPanelAnalyzeUnitWork != null)
                {
                    currentDemonID = nbPanelProcess.pNbPanelAnalyzeUnitWork.id; // Target's ID

                    // Replace the 9th skill by the trait (overrides what the "Analyze bosses" mod does)
                    nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_textTM").gameObject.GetComponent<TextMeshProUGUI>().text = EnableSkillColourOutlines.Value
                        ? datSkillName.Get(innateSkillId)
                        : "<material=\"TMC01\">" + datSkillName.Get(innateSkillId);
                    nbMainProcess.GetBattleUI(5).transform.Find("banalyze_skill/banalyze_skill09/banalyze_skill01").gameObject.GetComponent<Image>().color = new Color(0, 1, 0.75f, 1);
                }
            }
        }

        // Checks outside of battle for Life Refill/Mana Refill (on active party) every moon shift
        // Also checks Lucky Find/Mind's Eye (on active party) and Life/Mana Bonus/Gain/Surge (on everyone) when starting a battle
        // ALSO checks for Pierce/Son's Oath/[Relevant boost passive] (on attacker) and Endure/Never Yield/[Relevant passive resistances] (on attackee) when attacking
        // ALSO checks for Charisma (on attacker) when starting a negotiation
        // ALSO checks for Fast Retreat (on party) when trying to escape a battle
        // ALSO checks for Life Aid/Mana Aid/Victory Cry (on party) when leaving a battle
        // (0 = absent, 1 = present)
        [HarmonyPatch(typeof(datCalc), nameof(datCalc.datCheckSyojiSkill))]
        private class datCheckSyojiSkillPatch
        {
            public static void Postfix(datUnitWork_t work, uint skill, ref int __result)
            {
                if (innateSkills[work.id].skillId == skill)
                    __result = 1;
            }
        }

        // Get the number of members ready to intervene
        [HarmonyPatch(typeof(nbNegoProcess), nameof(nbNegoProcess.nbGetHojoSkillWorkCnt))]
        private class nbGetHojoSkillWorkCntPatch
        {
            public static void Postfix(ref nbNegoProcessData_t n, ref int __result)
            {
                var party = n.data.party;
                for (int i = 1; i <= 3; i++)
                {
                    var work = nbMainProcess.nbGetUnitWorkFromFormindex(party[i].formindex);
                    if (innateSkills[work.id].skillId >= 409 && innateSkills[work.id].skillId <= 420)
                    {
                        __result += 1;
                        break;
                    }
                }
            }
        }

        // Get the intervention effects (only if nbGetHojoSkillWorkCnt didn't return 0)
        [HarmonyPatch(typeof(nbNegoProcess), nameof(nbNegoProcess.nbSearchHojoSkillWork))]
        private class nbSearchHojoSkillWorkPatch
        {
            public static void Postfix(ref nbNegoProcessData_t n, ref int type, ref uint __result)
            {
                // int type
                // 1 = angry
                // 2 = leaves
                // 3 = battle continues
                // uint __result
                // Right-most bits: skill ID
                // Left-most bits: party index

                var party = n.data.party;
                for (short i = 1; i <= 3; i++)
                {
                    var work = nbMainProcess.nbGetUnitWorkFromFormindex(party[i].formindex);
                    if (innateSkills[work.id].skillId >= 409 && innateSkills[work.id].skillId <= 420)
                    {
                        var result = Convert.ToString(i, 2) + "0000000" + Convert.ToString(innateSkills[work.id].skillId, 2);
                        __result = Convert.ToUInt32(result, 2);
                        break;
                    }
                }
            }
        }

        internal struct InnateSkill
        {
            public ushort skillId;
            public string skillName;
            public string skillHelp;

            public InnateSkill(ushort skillId, string skillName, string skillHelp)
            { 
                this.skillId = skillId; 
                this.skillName = skillName; 
                this.skillHelp = skillHelp; 
            }
        }
    }
}