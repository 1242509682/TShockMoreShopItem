﻿using System.Reflection;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Events;
using Terraria.ID;
using TShockAPI;

namespace MoreShopItem
{
    public class utils
    {
        public static string FromEmbeddedPath(string path)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames()
                .FirstOrDefault(name => name.EndsWith(path, StringComparison.OrdinalIgnoreCase))!;

            if (resourceName == null)
            {
                throw new ArgumentException($"嵌入资源 '{path}' 未找到。", nameof(path));
            }

            using Stream stream = assembly.GetManifestResourceStream(resourceName)!;
            if (stream == null)
            {
                throw new InvalidOperationException($"无法打开嵌入资源流: {resourceName}");
            }

            using StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }


        public static void Log(string msg)
        {
            TShock.Log.ConsoleInfo("[MoreShopItem]：" + msg);
        }

        public static Item[] SetupShop(int type, Player plr)
        {
            bool flag = plr.currentShoppingSettings.PriceAdjustment <= 0.8999999761581421;
            Item[] array = new Item[40];
            for (int i = 0; i < 40; i++)
            {
                array[i] = new Item();
            }
            int num = 0;
            switch (type)
            {
                case 1:
                    {
                        array[num].SetDefaults(88);
                        num++;
                        array[num].SetDefaults(87);
                        num++;
                        array[num].SetDefaults(35);
                        num++;
                        array[num].SetDefaults(1991);
                        num++;
                        array[num].SetDefaults(3509);
                        num++;
                        array[num].SetDefaults(3506);
                        num++;
                        array[num].SetDefaults(8);
                        num++;
                        array[num].SetDefaults(28);
                        num++;
                        if (Main.hardMode)
                        {
                            array[num].SetDefaults(188);
                            num++;
                        }
                        array[num].SetDefaults(110);
                        num++;
                        if (Main.hardMode)
                        {
                            array[num].SetDefaults(189);
                            num++;
                        }
                        array[num].SetDefaults(40);
                        num++;
                        array[num].SetDefaults(42);
                        num++;
                        array[num].SetDefaults(965);
                        num++;
                        if (plr.ZoneSnow)
                        {
                            array[num].SetDefaults(967);
                            num++;
                        }
                        if (plr.ZoneJungle)
                        {
                            array[num].SetDefaults(33);
                            num++;
                        }
                        if (Main.dayTime && Main.IsItAHappyWindyDay)
                        {
                            array[num++].SetDefaults(4074);
                        }
                        if (Main.bloodMoon)
                        {
                            array[num].SetDefaults(279);
                            num++;
                        }
                        if (!Main.dayTime)
                        {
                            array[num].SetDefaults(282);
                            num++;
                        }
                        if (NPC.downedBoss3)
                        {
                            array[num].SetDefaults(346);
                            num++;
                        }
                        if (Main.hardMode)
                        {
                            array[num].SetDefaults(488);
                            num++;
                        }
                        for (int num6 = 0; num6 < 58; num6++)
                        {
                            if (plr.inventory[num6].type == 930)
                            {
                                array[num].SetDefaults(931);
                                num++;
                                array[num].SetDefaults(1614);
                                num++;
                                break;
                            }
                        }
                        array[num].SetDefaults(1786);
                        num++;
                        if (Main.hardMode)
                        {
                            array[num].SetDefaults(1348);
                            num++;
                        }
                        if (Main.hardMode)
                        {
                            array[num].SetDefaults(3198);
                            num++;
                        }
                        if (NPC.downedBoss2 || NPC.downedBoss3 || Main.hardMode)
                        {
                            array[num++].SetDefaults(4063);
                            array[num++].SetDefaults(4673);
                        }
                        if (plr.HasItem(3107))
                        {
                            array[num].SetDefaults(3108);
                            num++;
                        }
                        break;
                    }
                case 2:
                    array[num].SetDefaults(97);
                    num++;
                    if (Main.bloodMoon || Main.hardMode)
                    {
                        if (WorldGen.SavedOreTiers.Silver == 168)
                        {
                            array[num].SetDefaults(4915);
                            num++;
                        }
                        else
                        {
                            array[num].SetDefaults(278);
                            num++;
                        }
                    }
                    if ((NPC.downedBoss2 && !Main.dayTime) || Main.hardMode)
                    {
                        array[num].SetDefaults(47);
                        num++;
                    }
                    array[num].SetDefaults(95);
                    num++;
                    array[num].SetDefaults(98);
                    num++;
                    if (plr.ZoneGraveyard && NPC.downedBoss3)
                    {
                        array[num++].SetDefaults(4703);
                    }
                    if (!Main.dayTime)
                    {
                        array[num].SetDefaults(324);
                        num++;
                    }
                    if (Main.hardMode)
                    {
                        array[num].SetDefaults(534);
                        num++;
                    }
                    if (Main.hardMode)
                    {
                        array[num].SetDefaults(1432);
                        num++;
                    }
                    if (Main.hardMode)
                    {
                        array[num].SetDefaults(2177);
                        num++;
                    }
                    if (plr.HasItem(1258))
                    {
                        array[num].SetDefaults(1261);
                        num++;
                    }
                    if (plr.HasItem(1835))
                    {
                        array[num].SetDefaults(1836);
                        num++;
                    }
                    if (plr.HasItem(3107))
                    {
                        array[num].SetDefaults(3108);
                        num++;
                    }
                    if (plr.HasItem(1782))
                    {
                        array[num].SetDefaults(1783);
                        num++;
                    }
                    if (plr.HasItem(1784))
                    {
                        array[num].SetDefaults(1785);
                        num++;
                    }
                    if (Main.halloween)
                    {
                        array[num].SetDefaults(1736);
                        num++;
                        array[num].SetDefaults(1737);
                        num++;
                        array[num].SetDefaults(1738);
                        num++;
                    }
                    break;
                case 3:
                    if (Main.bloodMoon)
                    {
                        if (WorldGen.crimson)
                        {
                            if (!Main.remixWorld)
                            {
                                array[num].SetDefaults(2886);
                                num++;
                            }
                            array[num].SetDefaults(2171);
                            num++;
                            array[num].SetDefaults(4508);
                            num++;
                        }
                        else
                        {
                            if (!Main.remixWorld)
                            {
                                array[num].SetDefaults(67);
                                num++;
                            }
                            array[num].SetDefaults(59);
                            num++;
                            array[num].SetDefaults(4504);
                            num++;
                        }
                    }
                    else
                    {
                        if (!Main.remixWorld)
                        {
                            array[num].SetDefaults(66);
                            num++;
                        }
                        array[num].SetDefaults(62);
                        num++;
                        array[num].SetDefaults(63);
                        num++;
                        array[num].SetDefaults(745);
                        num++;
                    }
                    if (Main.hardMode && plr.ZoneGraveyard)
                    {
                        if (WorldGen.crimson)
                        {
                            array[num].SetDefaults(59);
                        }
                        else
                        {
                            array[num].SetDefaults(2171);
                        }
                        num++;
                    }
                    array[num].SetDefaults(27);
                    num++;
                    array[num].SetDefaults(5309);
                    num++;
                    array[num].SetDefaults(114);
                    num++;
                    array[num].SetDefaults(1828);
                    num++;
                    array[num].SetDefaults(747);
                    num++;
                    if (Main.hardMode)
                    {
                        array[num].SetDefaults(746);
                        num++;
                    }
                    if (Main.hardMode)
                    {
                        array[num].SetDefaults(369);
                        num++;
                    }
                    if (Main.hardMode)
                    {
                        array[num].SetDefaults(4505);
                        num++;
                    }
                    if (plr.ZoneUnderworldHeight)
                    {
                        array[num++].SetDefaults(5214);
                    }
                    else if (plr.ZoneGlowshroom)
                    {
                        array[num++].SetDefaults(194);
                    }
                    if (Main.halloween)
                    {
                        array[num].SetDefaults(1853);
                        num++;
                        array[num].SetDefaults(1854);
                        num++;
                    }
                    if (NPC.downedSlimeKing)
                    {
                        array[num].SetDefaults(3215);
                        num++;
                    }
                    if (NPC.downedQueenBee)
                    {
                        array[num].SetDefaults(3216);
                        num++;
                    }
                    if (NPC.downedBoss1)
                    {
                        array[num].SetDefaults(3219);
                        num++;
                    }
                    if (NPC.downedBoss2)
                    {
                        if (WorldGen.crimson)
                        {
                            array[num].SetDefaults(3218);
                            num++;
                        }
                        else
                        {
                            array[num].SetDefaults(3217);
                            num++;
                        }
                    }
                    if (NPC.downedBoss3)
                    {
                        array[num].SetDefaults(3220);
                        num++;
                        array[num].SetDefaults(3221);
                        num++;
                    }
                    if (Main.hardMode)
                    {
                        array[num].SetDefaults(3222);
                        num++;
                    }
                    array[num++].SetDefaults(4047);
                    array[num++].SetDefaults(4045);
                    array[num++].SetDefaults(4044);
                    array[num++].SetDefaults(4043);
                    array[num++].SetDefaults(4042);
                    array[num++].SetDefaults(4046);
                    array[num++].SetDefaults(4041);
                    array[num++].SetDefaults(4241);
                    array[num++].SetDefaults(4048);
                    if (Main.hardMode)
                    {
                        switch (Main.moonPhase / 2)
                        {
                            case 0:
                                array[num++].SetDefaults(4430);
                                array[num++].SetDefaults(4431);
                                array[num++].SetDefaults(4432);
                                break;
                            case 1:
                                array[num++].SetDefaults(4433);
                                array[num++].SetDefaults(4434);
                                array[num++].SetDefaults(4435);
                                break;
                            case 2:
                                array[num++].SetDefaults(4436);
                                array[num++].SetDefaults(4437);
                                array[num++].SetDefaults(4438);
                                break;
                            default:
                                array[num++].SetDefaults(4439);
                                array[num++].SetDefaults(4440);
                                array[num++].SetDefaults(4441);
                                break;
                        }
                    }
                    break;
                case 4:
                    {
                        array[num].SetDefaults(168);
                        num++;
                        array[num].SetDefaults(166);
                        num++;
                        array[num].SetDefaults(167);
                        num++;
                        if (Main.hardMode)
                        {
                            array[num].SetDefaults(265);
                            num++;
                        }
                        if (Main.hardMode && NPC.downedPlantBoss && NPC.downedPirates)
                        {
                            array[num].SetDefaults(937);
                            num++;
                        }
                        if (Main.hardMode)
                        {
                            array[num].SetDefaults(1347);
                            num++;
                        }
                        for (int k = 0; k < 58; k++)
                        {
                            if (plr.inventory[k].type == 4827)
                            {
                                array[num].SetDefaults(4827);
                                num++;
                                break;
                            }
                        }
                        for (int l = 0; l < 58; l++)
                        {
                            if (plr.inventory[l].type == 4824)
                            {
                                array[num].SetDefaults(4824);
                                num++;
                                break;
                            }
                        }
                        for (int m = 0; m < 58; m++)
                        {
                            if (plr.inventory[m].type == 4825)
                            {
                                array[num].SetDefaults(4825);
                                num++;
                                break;
                            }
                        }
                        for (int n = 0; n < 58; n++)
                        {
                            if (plr.inventory[n].type == 4826)
                            {
                                array[num].SetDefaults(4826);
                                num++;
                                break;
                            }
                        }
                        break;
                    }
                case 5:
                    {
                        array[num].SetDefaults(254);
                        num++;
                        array[num].SetDefaults(981);
                        num++;
                        if (Main.dayTime)
                        {
                            array[num].SetDefaults(242);
                            num++;
                        }
                        if (Main.moonPhase == 0)
                        {
                            array[num].SetDefaults(245);
                            num++;
                            array[num].SetDefaults(246);
                            num++;
                            if (!Main.dayTime)
                            {
                                array[num++].SetDefaults(1288);
                                array[num++].SetDefaults(1289);
                            }
                        }
                        else if (Main.moonPhase == 1)
                        {
                            array[num].SetDefaults(325);
                            num++;
                            array[num].SetDefaults(326);
                            num++;
                        }
                        array[num].SetDefaults(269);
                        num++;
                        array[num].SetDefaults(270);
                        num++;
                        array[num].SetDefaults(271);
                        num++;
                        if (NPC.downedClown)
                        {
                            array[num].SetDefaults(503);
                            num++;
                            array[num].SetDefaults(504);
                            num++;
                            array[num].SetDefaults(505);
                            num++;
                        }
                        if (Main.bloodMoon)
                        {
                            array[num].SetDefaults(322);
                            num++;
                            if (!Main.dayTime)
                            {
                                array[num++].SetDefaults(3362);
                                array[num++].SetDefaults(3363);
                            }
                        }
                        if (NPC.downedAncientCultist)
                        {
                            if (Main.dayTime)
                            {
                                array[num++].SetDefaults(2856);
                                array[num++].SetDefaults(2858);
                            }
                            else
                            {
                                array[num++].SetDefaults(2857);
                                array[num++].SetDefaults(2859);
                            }
                        }
                        if (NPC.AnyNPCs(441))
                        {
                            array[num++].SetDefaults(3242);
                            array[num++].SetDefaults(3243);
                            array[num++].SetDefaults(3244);
                        }
                        if (plr.ZoneGraveyard)
                        {
                            array[num++].SetDefaults(4685);
                            array[num++].SetDefaults(4686);
                            array[num++].SetDefaults(4704);
                            array[num++].SetDefaults(4705);
                            array[num++].SetDefaults(4706);
                            array[num++].SetDefaults(4707);
                            array[num++].SetDefaults(4708);
                            array[num++].SetDefaults(4709);
                        }
                        if (plr.ZoneSnow)
                        {
                            array[num].SetDefaults(1429);
                            num++;
                        }
                        if (Main.halloween)
                        {
                            array[num].SetDefaults(1740);
                            num++;
                        }
                        if (Main.hardMode)
                        {
                            if (Main.moonPhase == 2)
                            {
                                array[num].SetDefaults(869);
                                num++;
                            }
                            if (Main.moonPhase == 3)
                            {
                                array[num].SetDefaults(4994);
                                num++;
                                array[num].SetDefaults(4997);
                                num++;
                            }
                            if (Main.moonPhase == 4)
                            {
                                array[num].SetDefaults(864);
                                num++;
                                array[num].SetDefaults(865);
                                num++;
                            }
                            if (Main.moonPhase == 5)
                            {
                                array[num].SetDefaults(4995);
                                num++;
                                array[num].SetDefaults(4998);
                                num++;
                            }
                            if (Main.moonPhase == 6)
                            {
                                array[num].SetDefaults(873);
                                num++;
                                array[num].SetDefaults(874);
                                num++;
                                array[num].SetDefaults(875);
                                num++;
                            }
                            if (Main.moonPhase == 7)
                            {
                                array[num].SetDefaults(4996);
                                num++;
                                array[num].SetDefaults(4999);
                                num++;
                            }
                        }
                        if (NPC.downedFrost)
                        {
                            if (Main.dayTime)
                            {
                                array[num].SetDefaults(1275);
                                num++;
                            }
                            else
                            {
                                array[num].SetDefaults(1276);
                                num++;
                            }
                        }
                        if (Main.halloween)
                        {
                            array[num++].SetDefaults(3246);
                            array[num++].SetDefaults(3247);
                        }
                        if (BirthdayParty.PartyIsUp)
                        {
                            array[num++].SetDefaults(3730);
                            array[num++].SetDefaults(3731);
                            array[num++].SetDefaults(3733);
                            array[num++].SetDefaults(3734);
                            array[num++].SetDefaults(3735);
                        }
                        int golferScoreAccumulated2 = Main.LocalPlayer.golferScoreAccumulated;
                        if (num < 38 && golferScoreAccumulated2 >= 2000)
                        {
                            array[num].SetDefaults(4744);
                            num++;
                        }
                        array[num].SetDefaults(5308);
                        num++;
                        break;
                    }
                case 6:
                    array[num].SetDefaults(128);
                    num++;
                    array[num].SetDefaults(486);
                    num++;
                    array[num].SetDefaults(398);
                    num++;
                    array[num].SetDefaults(84);
                    num++;
                    array[num].SetDefaults(407);
                    num++;
                    array[num].SetDefaults(161);
                    num++;
                    if (Main.hardMode)
                    {
                        array[num++].SetDefaults(5324);
                    }
                    break;
                case 7:
                    array[num].SetDefaults(487);
                    num++;
                    array[num].SetDefaults(496);
                    num++;
                    array[num].SetDefaults(500);
                    num++;
                    array[num].SetDefaults(507);
                    num++;
                    array[num].SetDefaults(508);
                    num++;
                    array[num].SetDefaults(531);
                    num++;
                    array[num].SetDefaults(149);
                    num++;
                    array[num].SetDefaults(576);
                    num++;
                    array[num].SetDefaults(3186);
                    num++;
                    if (Main.halloween)
                    {
                        array[num].SetDefaults(1739);
                        num++;
                    }
                    break;
                case 8:
                    array[num].SetDefaults(509);
                    num++;
                    array[num].SetDefaults(850);
                    num++;
                    array[num].SetDefaults(851);
                    num++;
                    array[num].SetDefaults(3612);
                    num++;
                    array[num].SetDefaults(510);
                    num++;
                    array[num].SetDefaults(530);
                    num++;
                    array[num].SetDefaults(513);
                    num++;
                    array[num].SetDefaults(538);
                    num++;
                    array[num].SetDefaults(529);
                    num++;
                    array[num].SetDefaults(541);
                    num++;
                    array[num].SetDefaults(542);
                    num++;
                    array[num].SetDefaults(543);
                    num++;
                    array[num].SetDefaults(852);
                    num++;
                    array[num].SetDefaults(853);
                    num++;
                    array[num++].SetDefaults(4261);
                    array[num++].SetDefaults(3707);
                    array[num].SetDefaults(2739);
                    num++;
                    array[num].SetDefaults(849);
                    num++;
                    array[num++].SetDefaults(1263);
                    array[num++].SetDefaults(3616);
                    array[num++].SetDefaults(3725);
                    array[num++].SetDefaults(2799);
                    array[num++].SetDefaults(3619);
                    array[num++].SetDefaults(3627);
                    array[num++].SetDefaults(3629);
                    array[num++].SetDefaults(585);
                    array[num++].SetDefaults(584);
                    array[num++].SetDefaults(583);
                    array[num++].SetDefaults(4484);
                    array[num++].SetDefaults(4485);
                    if (NPC.AnyNPCs(369) && (Main.moonPhase == 1 || Main.moonPhase == 3 || Main.moonPhase == 5 || Main.moonPhase == 7))
                    {
                        array[num].SetDefaults(2295);
                        num++;
                    }
                    break;
                case 9:
                    {
                        array[num].SetDefaults(588);
                        num++;
                        array[num].SetDefaults(589);
                        num++;
                        array[num].SetDefaults(590);
                        num++;
                        array[num].SetDefaults(597);
                        num++;
                        array[num].SetDefaults(598);
                        num++;
                        array[num].SetDefaults(596);
                        num++;
                        for (int num5 = 1873; num5 < 1906; num5++)
                        {
                            array[num].SetDefaults(num5);
                            num++;
                        }
                        break;
                    }
                case 10:
                    if (NPC.downedMechBossAny)
                    {
                        array[num].SetDefaults(756);
                        num++;
                        array[num].SetDefaults(787);
                        num++;
                    }
                    array[num].SetDefaults(868);
                    num++;
                    if (NPC.downedPlantBoss)
                    {
                        array[num].SetDefaults(1551);
                        num++;
                    }
                    array[num].SetDefaults(1181);
                    num++;
                    array[num++].SetDefaults(5231);
                    if (!Main.remixWorld)
                    {
                        array[num++].SetDefaults(783);
                    }
                    break;
                case 11:
                    if (!Main.remixWorld)
                    {
                        array[num++].SetDefaults(779);
                    }
                    if (Main.moonPhase >= 4 && Main.hardMode)
                    {
                        array[num++].SetDefaults(748);
                    }
                    else
                    {
                        array[num++].SetDefaults(839);
                        array[num++].SetDefaults(840);
                        array[num++].SetDefaults(841);
                    }
                    if (NPC.downedGolemBoss)
                    {
                        array[num++].SetDefaults(948);
                    }
                    if (Main.hardMode)
                    {
                        array[num++].SetDefaults(3623);
                    }
                    array[num++].SetDefaults(3603);
                    array[num++].SetDefaults(3604);
                    array[num++].SetDefaults(3607);
                    array[num++].SetDefaults(3605);
                    array[num++].SetDefaults(3606);
                    array[num++].SetDefaults(3608);
                    array[num++].SetDefaults(3618);
                    array[num++].SetDefaults(3602);
                    array[num++].SetDefaults(3663);
                    array[num++].SetDefaults(3609);
                    array[num++].SetDefaults(3610);
                    if (Main.hardMode || !Main.getGoodWorld)
                    {
                        array[num++].SetDefaults(995);
                    }
                    if (NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3)
                    {
                        array[num++].SetDefaults(2203);
                    }
                    if (WorldGen.crimson)
                    {
                        array[num++].SetDefaults(2193);
                    }
                    else
                    {
                        array[num++].SetDefaults(4142);
                    }
                    if (plr.ZoneGraveyard)
                    {
                        array[num++].SetDefaults(2192);
                    }
                    if (plr.ZoneJungle)
                    {
                        array[num++].SetDefaults(2204);
                    }
                    if (plr.ZoneSnow)
                    {
                        array[num++].SetDefaults(2198);
                    }
                    if ((double)(plr.position.Y / 16f) < Main.worldSurface * 0.3499999940395355)
                    {
                        array[num++].SetDefaults(2197);
                    }
                    if (plr.HasItem(832))
                    {
                        array[num++].SetDefaults(2196);
                    }
                    if (!Main.remixWorld)
                    {
                        if (Main.eclipse || Main.bloodMoon)
                        {
                            if (WorldGen.crimson)
                            {
                                array[num++].SetDefaults(784);
                            }
                            else
                            {
                                array[num++].SetDefaults(782);
                            }
                        }
                        else if (plr.ZoneHallow)
                        {
                            array[num++].SetDefaults(781);
                        }
                        else
                        {
                            array[num++].SetDefaults(780);
                        }
                        if (NPC.downedMoonlord)
                        {
                            array[num++].SetDefaults(5392);
                            array[num++].SetDefaults(5393);
                            array[num++].SetDefaults(5394);
                        }
                    }
                    if (Main.hardMode)
                    {
                        array[num++].SetDefaults(1344);
                        array[num++].SetDefaults(4472);
                    }
                    if (Main.halloween)
                    {
                        array[num++].SetDefaults(1742);
                    }
                    break;
                case 12:
                    array[num].SetDefaults(1037);
                    num++;
                    array[num].SetDefaults(2874);
                    num++;
                    array[num].SetDefaults(1120);
                    num++;
                    array[num].SetDefaults(1969);
                    num++;
                    if (Main.halloween)
                    {
                        array[num].SetDefaults(3248);
                        num++;
                        array[num].SetDefaults(1741);
                        num++;
                    }
                    if (Main.moonPhase == 0)
                    {
                        array[num].SetDefaults(2871);
                        num++;
                        array[num].SetDefaults(2872);
                        num++;
                    }
                    if (!Main.dayTime && Main.bloodMoon)
                    {
                        array[num].SetDefaults(4663);
                        num++;
                    }
                    if (plr.ZoneGraveyard)
                    {
                        array[num].SetDefaults(4662);
                        num++;
                    }
                    break;
                case 13:
                    array[num].SetDefaults(859);
                    num++;
                    if (Main.LocalPlayer.golferScoreAccumulated > 500)
                    {
                        array[num++].SetDefaults(4743);
                    }
                    array[num].SetDefaults(1000);
                    num++;
                    array[num].SetDefaults(1168);
                    num++;
                    if (Main.dayTime)
                    {
                        array[num].SetDefaults(1449);
                        num++;
                    }
                    else
                    {
                        array[num].SetDefaults(4552);
                        num++;
                    }
                    array[num].SetDefaults(1345);
                    num++;
                    array[num].SetDefaults(1450);
                    num++;
                    array[num++].SetDefaults(3253);
                    array[num++].SetDefaults(4553);
                    array[num++].SetDefaults(2700);
                    array[num++].SetDefaults(2738);
                    array[num++].SetDefaults(4470);
                    array[num++].SetDefaults(4681);
                    if (plr.ZoneGraveyard)
                    {
                        array[num++].SetDefaults(4682);
                    }
                    if (LanternNight.LanternsUp)
                    {
                        array[num++].SetDefaults(4702);
                    }
                    if (plr.HasItem(3548))
                    {
                        array[num].SetDefaults(3548);
                        num++;
                    }
                    if (NPC.AnyNPCs(229))
                    {
                        array[num++].SetDefaults(3369);
                    }
                    if (NPC.downedGolemBoss)
                    {
                        array[num++].SetDefaults(3546);
                    }
                    if (Main.hardMode)
                    {
                        array[num].SetDefaults(3214);
                        num++;
                        array[num].SetDefaults(2868);
                        num++;
                        array[num].SetDefaults(970);
                        num++;
                        array[num].SetDefaults(971);
                        num++;
                        array[num].SetDefaults(972);
                        num++;
                        array[num].SetDefaults(973);
                        num++;
                    }
                    array[num++].SetDefaults(4791);
                    array[num++].SetDefaults(3747);
                    array[num++].SetDefaults(3732);
                    array[num++].SetDefaults(3742);
                    if (BirthdayParty.PartyIsUp)
                    {
                        array[num++].SetDefaults(3749);
                        array[num++].SetDefaults(3746);
                        array[num++].SetDefaults(3739);
                        array[num++].SetDefaults(3740);
                        array[num++].SetDefaults(3741);
                        array[num++].SetDefaults(3737);
                        array[num++].SetDefaults(3738);
                        array[num++].SetDefaults(3736);
                        array[num++].SetDefaults(3745);
                        array[num++].SetDefaults(3744);
                        array[num++].SetDefaults(3743);
                    }
                    break;
                case 14:
                    array[num].SetDefaults(771);
                    num++;
                    if (Main.bloodMoon)
                    {
                        array[num].SetDefaults(772);
                        num++;
                    }
                    if (!Main.dayTime || Main.eclipse)
                    {
                        array[num].SetDefaults(773);
                        num++;
                    }
                    if (Main.eclipse)
                    {
                        array[num].SetDefaults(774);
                        num++;
                    }
                    if (NPC.downedMartians)
                    {
                        array[num++].SetDefaults(4445);
                        if (Main.bloodMoon || Main.eclipse)
                        {
                            array[num++].SetDefaults(4446);
                        }
                    }
                    if (Main.hardMode)
                    {
                        array[num].SetDefaults(4459);
                        num++;
                    }
                    if (Main.hardMode)
                    {
                        array[num].SetDefaults(760);
                        num++;
                    }
                    if (Main.hardMode)
                    {
                        array[num].SetDefaults(1346);
                        num++;
                    }
                    if (Main.hardMode)
                    {
                        array[num].SetDefaults(5451);
                        num++;
                    }
                    if (Main.hardMode)
                    {
                        array[num].SetDefaults(5452);
                        num++;
                    }
                    if (plr.ZoneGraveyard)
                    {
                        array[num].SetDefaults(4409);
                        num++;
                    }
                    if (plr.ZoneGraveyard)
                    {
                        array[num].SetDefaults(4392);
                        num++;
                    }
                    if (Main.halloween)
                    {
                        array[num].SetDefaults(1743);
                        num++;
                        array[num].SetDefaults(1744);
                        num++;
                        array[num].SetDefaults(1745);
                        num++;
                    }
                    if (NPC.downedMartians)
                    {
                        array[num++].SetDefaults(2862);
                        array[num++].SetDefaults(3109);
                    }
                    if (plr.HasItem(3384) || plr.HasItem(3664))
                    {
                        array[num].SetDefaults(3664);
                        num++;
                    }
                    break;
                case 15:
                    {
                        array[num].SetDefaults(1071);
                        num++;
                        array[num].SetDefaults(1072);
                        num++;
                        array[num].SetDefaults(1100);
                        num++;
                        for (int j = 1073; j <= 1084; j++)
                        {
                            array[num].SetDefaults(j);
                            num++;
                        }
                        array[num].SetDefaults(1097);
                        num++;
                        array[num].SetDefaults(1099);
                        num++;
                        array[num].SetDefaults(1098);
                        num++;
                        array[num].SetDefaults(1966);
                        num++;
                        if (Main.hardMode)
                        {
                            array[num].SetDefaults(1967);
                            num++;
                            array[num].SetDefaults(1968);
                            num++;
                        }
                        if (plr.ZoneGraveyard)
                        {
                            array[num].SetDefaults(4668);
                            num++;
                            if (NPC.downedPlantBoss)
                            {
                                array[num].SetDefaults(5344);
                                num++;
                            }
                        }
                        break;
                    }
                case 25:
                    {
                        if (Main.xMas)
                        {
                            int num2 = 1948;
                            while (num2 <= 1957 && num < 39)
                            {
                                array[num].SetDefaults(num2);
                                num2++;
                                num++;
                            }
                        }
                        int num3 = 2158;
                        while (num3 <= 2160 && num < 39)
                        {
                            array[num].SetDefaults(num3);
                            num3++;
                            num++;
                        }
                        int num4 = 2008;
                        while (num4 <= 2014 && num < 39)
                        {
                            array[num].SetDefaults(num4);
                            num4++;
                            num++;
                        }
                        if (!plr.ZoneGraveyard)
                        {
                            array[num].SetDefaults(1490);
                            num++;
                            if (Main.moonPhase <= 1)
                            {
                                array[num].SetDefaults(1481);
                                num++;
                            }
                            else if (Main.moonPhase <= 3)
                            {
                                array[num].SetDefaults(1482);
                                num++;
                            }
                            else if (Main.moonPhase <= 5)
                            {
                                array[num].SetDefaults(1483);
                                num++;
                            }
                            else
                            {
                                array[num].SetDefaults(1484);
                                num++;
                            }
                        }
                        if (plr.ShoppingZone_Forest)
                        {
                            array[num].SetDefaults(5245);
                            num++;
                        }
                        if (plr.ZoneCrimson)
                        {
                            array[num].SetDefaults(1492);
                            num++;
                        }
                        if (plr.ZoneCorrupt)
                        {
                            array[num].SetDefaults(1488);
                            num++;
                        }
                        if (plr.ZoneHallow)
                        {
                            array[num].SetDefaults(1489);
                            num++;
                        }
                        if (plr.ZoneJungle)
                        {
                            array[num].SetDefaults(1486);
                            num++;
                        }
                        if (plr.ZoneSnow)
                        {
                            array[num].SetDefaults(1487);
                            num++;
                        }
                        if (plr.ZoneDesert)
                        {
                            array[num].SetDefaults(1491);
                            num++;
                        }
                        if (Main.bloodMoon)
                        {
                            array[num].SetDefaults(1493);
                            num++;
                        }
                        if (!plr.ZoneGraveyard)
                        {
                            if ((double)(plr.position.Y / 16f) < Main.worldSurface * 0.3499999940395355)
                            {
                                array[num].SetDefaults(1485);
                                num++;
                            }
                            if ((double)(plr.position.Y / 16f) < Main.worldSurface * 0.3499999940395355 && Main.hardMode)
                            {
                                array[num].SetDefaults(1494);
                                num++;
                            }
                        }
                        if (Main.IsItStorming)
                        {
                            array[num].SetDefaults(5251);
                            num++;
                        }
                        if (plr.ZoneGraveyard)
                        {
                            array[num].SetDefaults(4723);
                            num++;
                            array[num].SetDefaults(4724);
                            num++;
                            array[num].SetDefaults(4725);
                            num++;
                            array[num].SetDefaults(4726);
                            num++;
                            array[num].SetDefaults(4727);
                            num++;
                            array[num].SetDefaults(5257);
                            num++;
                            array[num].SetDefaults(4728);
                            num++;
                            array[num].SetDefaults(4729);
                            num++;
                        }
                        break;
                    }
                case 16:
                    array[num++].SetDefaults(1430);
                    array[num++].SetDefaults(986);
                    if (NPC.AnyNPCs(108))
                    {
                        array[num++].SetDefaults(2999);
                    }
                    if (!Main.dayTime)
                    {
                        array[num++].SetDefaults(1158);
                    }
                    if (Main.hardMode && NPC.downedPlantBoss)
                    {
                        array[num++].SetDefaults(1159);
                        array[num++].SetDefaults(1160);
                        array[num++].SetDefaults(1161);
                        if (plr.ZoneJungle)
                        {
                            array[num++].SetDefaults(1167);
                        }
                        array[num++].SetDefaults(1339);
                    }
                    if (Main.hardMode && plr.ZoneJungle)
                    {
                        array[num++].SetDefaults(1171);
                        if (!Main.dayTime && NPC.downedPlantBoss)
                        {
                            array[num++].SetDefaults(1162);
                        }
                    }
                    array[num++].SetDefaults(909);
                    array[num++].SetDefaults(910);
                    array[num++].SetDefaults(940);
                    array[num++].SetDefaults(941);
                    array[num++].SetDefaults(942);
                    array[num++].SetDefaults(943);
                    array[num++].SetDefaults(944);
                    array[num++].SetDefaults(945);
                    array[num++].SetDefaults(4922);
                    array[num++].SetDefaults(4417);
                    if (plr.HasItem(1835))
                    {
                        array[num++].SetDefaults(1836);
                    }
                    if (plr.HasItem(1258))
                    {
                        array[num++].SetDefaults(1261);
                    }
                    if (Main.halloween)
                    {
                        array[num++].SetDefaults(1791);
                    }
                    break;
                case 17:
                    array[num].SetDefaults(928);
                    num++;
                    array[num].SetDefaults(929);
                    num++;
                    array[num].SetDefaults(876);
                    num++;
                    array[num].SetDefaults(877);
                    num++;
                    array[num].SetDefaults(878);
                    num++;
                    array[num].SetDefaults(2434);
                    num++;
                    if (plr.ZoneBeach && plr.position.Y < Main.worldSurface * 16.0)
                    {
                        array[num].SetDefaults(1180);
                        num++;
                    }
                    if (Main.hardMode && NPC.downedMechBossAny && NPC.AnyNPCs(208))
                    {
                        array[num].SetDefaults(1337);
                        num++;
                    }
                    break;
                case 18:
                    {
                        array[num].SetDefaults(1990);
                        num++;
                        array[num].SetDefaults(1979);
                        num++;
                        if (plr.statLifeMax >= 400)
                        {
                            array[num].SetDefaults(1977);
                            num++;
                        }
                        if (plr.statManaMax >= 200)
                        {
                            array[num].SetDefaults(1978);
                            num++;
                        }
                        long num7 = 0L;
                        for (int num8 = 0; num8 < 54; num8++)
                        {
                            if (plr.inventory[num8].type == 71)
                            {
                                num7 += plr.inventory[num8].stack;
                            }
                            if (plr.inventory[num8].type == 72)
                            {
                                num7 += plr.inventory[num8].stack * 100;
                            }
                            if (plr.inventory[num8].type == 73)
                            {
                                num7 += plr.inventory[num8].stack * 10000;
                            }
                            if (plr.inventory[num8].type == 74)
                            {
                                num7 += plr.inventory[num8].stack * 1000000;
                            }
                        }
                        if (num7 >= 1000000)
                        {
                            array[num].SetDefaults(1980);
                            num++;
                        }
                        if ((Main.moonPhase % 2 == 0 && Main.dayTime) || (Main.moonPhase % 2 == 1 && !Main.dayTime))
                        {
                            array[num].SetDefaults(1981);
                            num++;
                        }
                        if (plr.team != 0)
                        {
                            array[num].SetDefaults(1982);
                            num++;
                        }
                        if (Main.hardMode)
                        {
                            array[num].SetDefaults(1983);
                            num++;
                        }
                        if (NPC.AnyNPCs(208))
                        {
                            array[num].SetDefaults(1984);
                            num++;
                        }
                        if (Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                        {
                            array[num].SetDefaults(1985);
                            num++;
                        }
                        if (Main.hardMode && NPC.downedMechBossAny)
                        {
                            array[num].SetDefaults(1986);
                            num++;
                        }
                        if (Main.hardMode && NPC.downedMartians)
                        {
                            array[num].SetDefaults(2863);
                            num++;
                            array[num].SetDefaults(3259);
                            num++;
                        }
                        array[num++].SetDefaults(5104);
                        break;
                    }
                case 19:
                    {
                        for (int num9 = 0; num9 < 40; num9++)
                        {
                            if (Main.travelShop[num9] != 0)
                            {
                                array[num].netDefaults(Main.travelShop[num9]);
                                num++;
                            }
                        }
                        break;
                    }
                case 20:
                    if (Main.moonPhase == 0)
                    {
                        array[num].SetDefaults(284);
                        num++;
                    }
                    if (Main.moonPhase == 1)
                    {
                        array[num].SetDefaults(946);
                        num++;
                    }
                    if (Main.moonPhase == 2 && !Main.remixWorld)
                    {
                        array[num].SetDefaults(3069);
                        num++;
                    }
                    if (Main.moonPhase == 2 && Main.remixWorld)
                    {
                        array[num].SetDefaults(517);
                        num++;
                    }
                    if (Main.moonPhase == 3)
                    {
                        array[num].SetDefaults(4341);
                        num++;
                    }
                    if (Main.moonPhase == 4)
                    {
                        array[num].SetDefaults(285);
                        num++;
                    }
                    if (Main.moonPhase == 5)
                    {
                        array[num].SetDefaults(953);
                        num++;
                    }
                    if (Main.moonPhase == 6)
                    {
                        array[num].SetDefaults(3068);
                        num++;
                    }
                    if (Main.moonPhase == 7)
                    {
                        array[num].SetDefaults(3084);
                        num++;
                    }
                    if (Main.moonPhase % 2 == 0)
                    {
                        array[num].SetDefaults(3001);
                        num++;
                    }
                    if (Main.moonPhase % 2 != 0)
                    {
                        array[num].SetDefaults(28);
                        num++;
                    }
                    if (Main.moonPhase % 2 != 0 && Main.hardMode)
                    {
                        array[num].SetDefaults(188);
                        num++;
                    }
                    if (!Main.dayTime || Main.moonPhase == 0)
                    {
                        array[num].SetDefaults(3002);
                        num++;
                        if (plr.HasItem(930))
                        {
                            array[num].SetDefaults(5377);
                            num++;
                        }
                    }
                    else if (Main.dayTime && Main.moonPhase != 0)
                    {
                        array[num].SetDefaults(282);
                        num++;
                    }
                    if (Main.time % 60.0 * 60.0 * 6.0 <= 10800.0)
                    {
                        array[num].SetDefaults(3004);
                    }
                    else
                    {
                        array[num].SetDefaults(8);
                    }
                    num++;
                    if (Main.moonPhase == 0 || Main.moonPhase == 1 || Main.moonPhase == 4 || Main.moonPhase == 5)
                    {
                        array[num].SetDefaults(3003);
                    }
                    else
                    {
                        array[num].SetDefaults(40);
                    }
                    num++;
                    if (Main.moonPhase % 4 == 0)
                    {
                        array[num].SetDefaults(3310);
                    }
                    else if (Main.moonPhase % 4 == 1)
                    {
                        array[num].SetDefaults(3313);
                    }
                    else if (Main.moonPhase % 4 == 2)
                    {
                        array[num].SetDefaults(3312);
                    }
                    else
                    {
                        array[num].SetDefaults(3311);
                    }
                    num++;
                    array[num].SetDefaults(166);
                    num++;
                    array[num].SetDefaults(965);
                    num++;
                    if (Main.hardMode)
                    {
                        if (Main.moonPhase < 4)
                        {
                            array[num].SetDefaults(3316);
                        }
                        else
                        {
                            array[num].SetDefaults(3315);
                        }
                        num++;
                        array[num].SetDefaults(3334);
                        num++;
                        if (Main.bloodMoon)
                        {
                            array[num].SetDefaults(3258);
                            num++;
                        }
                    }
                    if (Main.moonPhase == 0 && !Main.dayTime)
                    {
                        array[num].SetDefaults(3043);
                        num++;
                    }
                    if (!plr.ateArtisanBread && Main.moonPhase >= 3 && Main.moonPhase <= 5)
                    {
                        array[num].SetDefaults(5326);
                        num++;
                    }
                    break;
                case 21:
                    {
                        bool flag2 = Main.hardMode && NPC.downedMechBossAny;
                        bool flag3 = Main.hardMode && NPC.downedGolemBoss;
                        array[num].SetDefaults(353);
                        num++;
                        array[num].SetDefaults(3828);
                        if (flag3)
                        {
                            array[num].shopCustomPrice = Item.buyPrice(0, 4);
                        }
                        else if (flag2)
                        {
                            array[num].shopCustomPrice = Item.buyPrice(0, 1);
                        }
                        else
                        {
                            array[num].shopCustomPrice = Item.buyPrice(0, 0, 25);
                        }
                        num++;
                        array[num].SetDefaults(3816);
                        num++;
                        array[num].SetDefaults(3813);
                        array[num].shopCustomPrice = 50;
                        array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                        num++;
                        num = 10;
                        array[num].SetDefaults(3818);
                        array[num].shopCustomPrice = 5;
                        array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                        num++;
                        array[num].SetDefaults(3824);
                        array[num].shopCustomPrice = 5;
                        array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                        num++;
                        array[num].SetDefaults(3832);
                        array[num].shopCustomPrice = 5;
                        array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                        num++;
                        array[num].SetDefaults(3829);
                        array[num].shopCustomPrice = 5;
                        array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                        if (flag2)
                        {
                            num = 20;
                            array[num].SetDefaults(3819);
                            array[num].shopCustomPrice = 15;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3825);
                            array[num].shopCustomPrice = 15;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3833);
                            array[num].shopCustomPrice = 15;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3830);
                            array[num].shopCustomPrice = 15;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                        }
                        if (flag3)
                        {
                            num = 30;
                            array[num].SetDefaults(3820);
                            array[num].shopCustomPrice = 60;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3826);
                            array[num].shopCustomPrice = 60;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3834);
                            array[num].shopCustomPrice = 60;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3831);
                            array[num].shopCustomPrice = 60;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                        }
                        if (flag2)
                        {
                            num = 4;
                            array[num].SetDefaults(3800);
                            array[num].shopCustomPrice = 15;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3801);
                            array[num].shopCustomPrice = 15;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3802);
                            array[num].shopCustomPrice = 15;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            num = 14;
                            array[num].SetDefaults(3797);
                            array[num].shopCustomPrice = 15;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3798);
                            array[num].shopCustomPrice = 15;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3799);
                            array[num].shopCustomPrice = 15;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            num = 24;
                            array[num].SetDefaults(3803);
                            array[num].shopCustomPrice = 15;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3804);
                            array[num].shopCustomPrice = 15;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3805);
                            array[num].shopCustomPrice = 15;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            num = 34;
                            array[num].SetDefaults(3806);
                            array[num].shopCustomPrice = 15;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3807);
                            array[num].shopCustomPrice = 15;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3808);
                            array[num].shopCustomPrice = 15;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                        }
                        if (flag3)
                        {
                            num = 7;
                            array[num].SetDefaults(3871);
                            array[num].shopCustomPrice = 50;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3872);
                            array[num].shopCustomPrice = 50;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3873);
                            array[num].shopCustomPrice = 50;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            num = 17;
                            array[num].SetDefaults(3874);
                            array[num].shopCustomPrice = 50;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3875);
                            array[num].shopCustomPrice = 50;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3876);
                            array[num].shopCustomPrice = 50;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            num = 27;
                            array[num].SetDefaults(3877);
                            array[num].shopCustomPrice = 50;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3878);
                            array[num].shopCustomPrice = 50;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3879);
                            array[num].shopCustomPrice = 50;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            num = 37;
                            array[num].SetDefaults(3880);
                            array[num].shopCustomPrice = 50;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3881);
                            array[num].shopCustomPrice = 50;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                            array[num].SetDefaults(3882);
                            array[num].shopCustomPrice = 50;
                            array[num].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
                            num++;
                        }
                        num = (flag3 ? 39 : ((!flag2) ? 4 : 30));
                        break;
                    }
                case 22:
                    {
                        array[num++].SetDefaults(4587);
                        array[num++].SetDefaults(4590);
                        array[num++].SetDefaults(4589);
                        array[num++].SetDefaults(4588);
                        array[num++].SetDefaults(4083);
                        array[num++].SetDefaults(4084);
                        array[num++].SetDefaults(4085);
                        array[num++].SetDefaults(4086);
                        array[num++].SetDefaults(4087);
                        array[num++].SetDefaults(4088);
                        int golferScoreAccumulated = plr.golferScoreAccumulated;
                        if (golferScoreAccumulated > 500)
                        {
                            array[num].SetDefaults(4039);
                            num++;
                            array[num].SetDefaults(4094);
                            num++;
                            array[num].SetDefaults(4093);
                            num++;
                            array[num].SetDefaults(4092);
                            num++;
                        }
                        array[num++].SetDefaults(4089);
                        array[num++].SetDefaults(3989);
                        array[num++].SetDefaults(4095);
                        array[num++].SetDefaults(4040);
                        array[num++].SetDefaults(4319);
                        array[num++].SetDefaults(4320);
                        if (golferScoreAccumulated > 1000)
                        {
                            array[num].SetDefaults(4591);
                            num++;
                            array[num].SetDefaults(4594);
                            num++;
                            array[num].SetDefaults(4593);
                            num++;
                            array[num].SetDefaults(4592);
                            num++;
                        }
                        array[num++].SetDefaults(4135);
                        array[num++].SetDefaults(4138);
                        array[num++].SetDefaults(4136);
                        array[num++].SetDefaults(4137);
                        array[num++].SetDefaults(4049);
                        if (golferScoreAccumulated > 500)
                        {
                            array[num].SetDefaults(4265);
                            num++;
                        }
                        if (golferScoreAccumulated > 2000)
                        {
                            array[num].SetDefaults(4595);
                            num++;
                            array[num].SetDefaults(4598);
                            num++;
                            array[num].SetDefaults(4597);
                            num++;
                            array[num].SetDefaults(4596);
                            num++;
                            if (NPC.downedBoss3)
                            {
                                array[num].SetDefaults(4264);
                                num++;
                            }
                        }
                        if (golferScoreAccumulated > 500)
                        {
                            array[num].SetDefaults(4599);
                            num++;
                        }
                        if (golferScoreAccumulated >= 1000)
                        {
                            array[num].SetDefaults(4600);
                            num++;
                        }
                        if (golferScoreAccumulated >= 2000)
                        {
                            array[num].SetDefaults(4601);
                            num++;
                        }
                        if (golferScoreAccumulated >= 2000)
                        {
                            if (Main.moonPhase == 0 || Main.moonPhase == 1)
                            {
                                array[num].SetDefaults(4658);
                                num++;
                            }
                            else if (Main.moonPhase == 2 || Main.moonPhase == 3)
                            {
                                array[num].SetDefaults(4659);
                                num++;
                            }
                            else if (Main.moonPhase == 4 || Main.moonPhase == 5)
                            {
                                array[num].SetDefaults(4660);
                                num++;
                            }
                            else if (Main.moonPhase == 6 || Main.moonPhase == 7)
                            {
                                array[num].SetDefaults(4661);
                                num++;
                            }
                        }
                        break;
                    }
                case 23:
                    {
                        BestiaryUnlockProgressReport bestiaryProgressReport = Main.GetBestiaryProgressReport();
                        if (BestiaryGirl_IsFairyTorchAvailable())
                        {
                            array[num++].SetDefaults(4776);
                        }
                        array[num++].SetDefaults(4767);
                        array[num++].SetDefaults(4759);
                        if (Main.moonPhase == 0 && !Main.dayTime)
                        {
                            array[num++].SetDefaults(5253);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 0.1f)
                        {
                            array[num++].SetDefaults(4672);
                        }
                        array[num++].SetDefaults(4829);
                        if (bestiaryProgressReport.CompletionPercent >= 0.25f)
                        {
                            array[num++].SetDefaults(4830);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 0.45f)
                        {
                            array[num++].SetDefaults(4910);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 0.3f)
                        {
                            array[num++].SetDefaults(4871);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 0.3f)
                        {
                            array[num++].SetDefaults(4907);
                        }
                        if (NPC.downedTowerSolar)
                        {
                            array[num++].SetDefaults(4677);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 0.1f)
                        {
                            array[num++].SetDefaults(4676);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 0.3f)
                        {
                            array[num++].SetDefaults(4762);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 0.25f)
                        {
                            array[num++].SetDefaults(4716);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 0.3f)
                        {
                            array[num++].SetDefaults(4785);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 0.3f)
                        {
                            array[num++].SetDefaults(4786);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 0.3f)
                        {
                            array[num++].SetDefaults(4787);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 0.3f && Main.hardMode)
                        {
                            array[num++].SetDefaults(4788);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 0.35f)
                        {
                            array[num++].SetDefaults(4763);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 0.4f)
                        {
                            array[num++].SetDefaults(4955);
                        }
                        if (Main.hardMode && Main.bloodMoon)
                        {
                            array[num++].SetDefaults(4736);
                        }
                        if (NPC.downedPlantBoss)
                        {
                            array[num++].SetDefaults(4701);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 0.5f)
                        {
                            array[num++].SetDefaults(4765);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 0.5f)
                        {
                            array[num++].SetDefaults(4766);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 0.5f)
                        {
                            array[num++].SetDefaults(5285);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 0.5f)
                        {
                            array[num++].SetDefaults(4777);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 0.7f)
                        {
                            array[num++].SetDefaults(4735);
                        }
                        if (bestiaryProgressReport.CompletionPercent >= 1f)
                        {
                            array[num++].SetDefaults(4951);
                        }
                        switch (Main.moonPhase)
                        {
                            case 0:
                            case 1:
                                array[num++].SetDefaults(4768);
                                array[num++].SetDefaults(4769);
                                break;
                            case 2:
                            case 3:
                                array[num++].SetDefaults(4770);
                                array[num++].SetDefaults(4771);
                                break;
                            case 4:
                            case 5:
                                array[num++].SetDefaults(4772);
                                array[num++].SetDefaults(4773);
                                break;
                            case 6:
                            case 7:
                                array[num++].SetDefaults(4560);
                                array[num++].SetDefaults(4775);
                                break;
                        }
                        break;
                    }
                case 24:
                    array[num++].SetDefaults(5071);
                    array[num++].SetDefaults(5072);
                    array[num++].SetDefaults(5073);
                    array[num++].SetDefaults(5076);
                    array[num++].SetDefaults(5077);
                    array[num++].SetDefaults(5078);
                    array[num++].SetDefaults(5079);
                    array[num++].SetDefaults(5080);
                    array[num++].SetDefaults(5081);
                    array[num++].SetDefaults(5082);
                    array[num++].SetDefaults(5083);
                    array[num++].SetDefaults(5084);
                    array[num++].SetDefaults(5085);
                    array[num++].SetDefaults(5086);
                    array[num++].SetDefaults(5087);
                    array[num++].SetDefaults(5310);
                    array[num++].SetDefaults(5222);
                    array[num++].SetDefaults(5228);
                    if (NPC.downedSlimeKing && NPC.downedQueenSlime)
                    {
                        array[num++].SetDefaults(5266);
                    }
                    if (Main.hardMode && NPC.downedMoonlord)
                    {
                        array[num++].SetDefaults(5044);
                    }
                    if (Main.tenthAnniversaryWorld)
                    {
                        array[num++].SetDefaults(1309);
                        array[num++].SetDefaults(1859);
                        array[num++].SetDefaults(1358);
                        if (plr.ZoneDesert)
                        {
                            array[num++].SetDefaults(857);
                        }
                        if (Main.bloodMoon)
                        {
                            array[num++].SetDefaults(4144);
                        }
                        if (Main.hardMode && NPC.downedPirates)
                        {
                            if (Main.moonPhase == 0 || Main.moonPhase == 1)
                            {
                                array[num++].SetDefaults(2584);
                            }
                            if (Main.moonPhase == 2 || Main.moonPhase == 3)
                            {
                                array[num++].SetDefaults(854);
                            }
                            if (Main.moonPhase == 4 || Main.moonPhase == 5)
                            {
                                array[num++].SetDefaults(855);
                            }
                            if (Main.moonPhase == 6 || Main.moonPhase == 7)
                            {
                                array[num++].SetDefaults(905);
                            }
                        }
                    }
                    array[num++].SetDefaults(5088);
                    break;
            }
            bool flag4 = type != 19 && type != 20;
            bool flag5 = TeleportPylonsSystem.DoesPositionHaveEnoughNPCs(2, plr.Center.ToTileCoordinates16());
            if (flag4 && (flag || Main.remixWorld) && flag5 && !plr.ZoneCorrupt && !plr.ZoneCrimson)
            {
                if (!plr.ZoneSnow && !plr.ZoneDesert && !plr.ZoneBeach && !plr.ZoneJungle && !plr.ZoneHallow && !plr.ZoneGlowshroom && (double)(plr.Center.Y / 16f) < Main.worldSurface && num < 39)
                {
                    if (Main.remixWorld)
                    {
                        if ((double)(plr.Center.Y / 16f) > Main.rockLayer && plr.Center.Y / 16f < Main.maxTilesY - 350 && num < 39)
                        {
                            array[num++].SetDefaults(4876);
                        }
                    }
                    else if ((double)(plr.Center.Y / 16f) < Main.worldSurface && num < 39)
                    {
                        array[num++].SetDefaults(4876);
                    }
                }
                if (plr.ZoneSnow && num < 39)
                {
                    array[num++].SetDefaults(4920);
                }
                if (plr.ZoneDesert && num < 39)
                {
                    array[num++].SetDefaults(4919);
                }
                if (Main.remixWorld)
                {
                    if (!plr.ZoneSnow && !plr.ZoneDesert && !plr.ZoneBeach && !plr.ZoneJungle && !plr.ZoneHallow && (double)(plr.Center.Y / 16f) >= Main.worldSurface && num < 39)
                    {
                        array[num++].SetDefaults(4917);
                    }
                }
                else if (!plr.ZoneSnow && !plr.ZoneDesert && !plr.ZoneBeach && !plr.ZoneJungle && !plr.ZoneHallow && !plr.ZoneGlowshroom && (double)(plr.Center.Y / 16f) >= Main.worldSurface && num < 39)
                {
                    array[num++].SetDefaults(4917);
                }
                bool flag6 = plr.ZoneBeach && plr.position.Y < Main.worldSurface * 16.0;
                if (Main.remixWorld)
                {
                    float num10 = plr.position.X / 16f;
                    float num11 = plr.position.Y / 16f;
                    flag6 |= ((double)num10 < Main.maxTilesX * 0.43 || (double)num10 > Main.maxTilesX * 0.57) && (double)num11 > Main.rockLayer && num11 < Main.maxTilesY - 350;
                }
                if (flag6 && num < 39)
                {
                    array[num++].SetDefaults(4918);
                }
                if (plr.ZoneJungle && num < 39)
                {
                    array[num++].SetDefaults(4875);
                }
                if (plr.ZoneHallow && num < 39)
                {
                    array[num++].SetDefaults(4916);
                }
                if (plr.ZoneGlowshroom && (!Main.remixWorld || plr.Center.Y / 16f < Main.maxTilesY - 200) && num < 39)
                {
                    array[num++].SetDefaults(4921);
                }
            }
            for (int num12 = 0; num12 < num; num12++)
            {
                array[num12].isAShopItem = true;
            }
            return array;
        }

        private static bool BestiaryGirl_IsFairyTorchAvailable()
        {
            if (!DidDiscoverBestiaryEntry(585))
            {
                return false;
            }
            if (!DidDiscoverBestiaryEntry(584))
            {
                return false;
            }
            if (!DidDiscoverBestiaryEntry(583))
            {
                return false;
            }
            return true;
        }

        private static bool DidDiscoverBestiaryEntry(int npcId)
        {
            return Main.BestiaryDB.FindEntryByNPCID(npcId).UIInfoProvider.GetEntryUICollectionInfo().UnlockState > BestiaryEntryUnlockState.NotKnownAtAll_0;
        }
    }
}
