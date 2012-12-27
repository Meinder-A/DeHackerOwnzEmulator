namespace Dark_Orbit_Interceptor
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Threading;

    [StandardModule]
    internal sealed class Mine_Module
    {
        public static void heroEMPCooldown()
        {
            initConnection.empCooldown = true;
            Thread.Sleep(0x4e20);
            initConnection.empCooldown = false;
        }

        public static void heroEMPd()
        {
            int num = Module1.mainHero.getRocketAmmo1();
            int num2 = Module1.mainHero.getRocketAmmo2();
            int num3 = Module1.mainHero.getRocketAmmo3();
            int num4 = Module1.mainHero.getRocketAmmo4();
            int num5 = Module1.mainHero.getRocketAmmo5();
            int num6 = Module1.mainHero.getRocketAmmo6();
            int num7 = Module1.mainHero.getRocketAmmo7();
            int num8 = Module1.mainHero.getRocketAmmo8();
            int num9 = Module1.mainHero.getRocketAmmo9();
            initConnection.heroEMP = true;
            num9--;
            initConnection.sendPacket("0|3|" + Conversions.ToString(num) + "|" + Conversions.ToString(num2) + "|" + Conversions.ToString(num3) + "|" + Conversions.ToString(num4) + "|" + Conversions.ToString(num5) + "|0|0|" + Conversions.ToString(num6) + "|" + Conversions.ToString(num7) + "|" + Conversions.ToString(num8) + "|" + Conversions.ToString(num9) + "|0|0|0");
            Module1.mainHero.setRocketAmmo(num, num2, num3, num4, num5, num6, num7, num8, num9);
            Thread.Sleep(0xbb8);
            initConnection.heroEMP = false;
            new Thread(new ThreadStart(Mine_Module.heroEMPCooldown)).Start();
        }

        public static void heroInstaCooldown()
        {
            initConnection.instaCooldown = true;
            Thread.Sleep(0x4e20);
            initConnection.instaCooldown = false;
        }

        public static void heroInstad()
        {
            int num = Module1.mainHero.getRocketAmmo1();
            int num2 = Module1.mainHero.getRocketAmmo2();
            int num3 = Module1.mainHero.getRocketAmmo3();
            int num4 = Module1.mainHero.getRocketAmmo4();
            int num5 = Module1.mainHero.getRocketAmmo5();
            int num6 = Module1.mainHero.getRocketAmmo6();
            int num7 = Module1.mainHero.getRocketAmmo7();
            int num8 = Module1.mainHero.getRocketAmmo8();
            int num9 = Module1.mainHero.getRocketAmmo9();
            initConnection.heroInsta = true;
            num8--;
            initConnection.sendPacket("0|3|" + Conversions.ToString(num) + "|" + Conversions.ToString(num2) + "|" + Conversions.ToString(num3) + "|" + Conversions.ToString(num4) + "|" + Conversions.ToString(num5) + "|0|0|" + Conversions.ToString(num6) + "|" + Conversions.ToString(num7) + "|" + Conversions.ToString(num8) + "|" + Conversions.ToString(num9) + "|0|0|0");
            Module1.mainHero.setRocketAmmo(num, num2, num3, num4, num5, num6, num7, num8, num9);
            Thread.Sleep(0xbb8);
            initConnection.heroInsta = false;
            new Thread(new ThreadStart(Mine_Module.heroInstaCooldown)).Start();
        }

        public static void heroSbombCooldown()
        {
            initConnection.sbombCooldown = true;
            Thread.Sleep(0x4e20);
            initConnection.sbombCooldown = false;
        }

        public static void heroSbombd(double heroX, double heroY)
        {
            IEnumerator enumerator;
            try
            {
                enumerator = Module1.displayNPCs.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    int userID = Conversions.ToInteger(enumerator.Current);
                    NPCShip ship = mainFunctions.getNPCByID(userID);
                    double num13 = ship.getPosX();
                    double num14 = ship.getPosY();
                    double num11 = heroX - num13;
                    double num12 = heroY - num14;
                    num11 = Math.Abs(num11);
                    num12 = Math.Abs(num12);
                    if ((num11 < 1000.0) && (num12 < 1000.0))
                    {
                        int num17 = ship.getMaxHP();
                        int num16 = ship.getHP();
                        int dmgDone = (int) Math.Round((double) (num17 * 0.2));
                        if (dmgDone > num16)
                        {
                            initConnection.updateAttackLasers(userID, 0, 0, dmgDone);
                            ship.setHP(0);
                            ship.setSHD(0);
                            if (Module1.accessingNPCs)
                            {
                                while (true)
                                {
                                    if (!Module1.accessingNPCs)
                                    {
                                        Module1.accessingNPCs = true;
                                        string str = "";
                                        string str4 = "";
                                        string str2 = "";
                                        string str3 = "";
                                        Attack_Module.getRewards(ship.getShipType(), ref str, ref str4, ref str2, ref str3);
                                        initConnection.destroyNPC(userID);
                                        mainFunctions.removeNPCByID(userID);
                                        Module1.displayNPCs.Remove(userID);
                                        Attack_Module.NPCDead(Conversions.ToInteger(str), Conversions.ToInteger(str4), Conversions.ToInteger(str2), Conversions.ToInteger(str3));
                                        mainFunctions.log("NPC dead...");
                                        Module1.accessingNPCs = false;
                                        continue;
                                    }
                                }
                            }
                            Module1.accessingNPCs = true;
                            string credits = "";
                            string uridium = "";
                            string ep = "";
                            string honor = "";
                            Attack_Module.getRewards(userID, ref credits, ref uridium, ref ep, ref honor);
                            initConnection.destroyNPC(userID);
                            mainFunctions.removeNPCByID(userID);
                            Module1.displayNPCs.Remove(userID);
                            Attack_Module.NPCDead(Conversions.ToInteger(credits), Conversions.ToInteger(uridium), Conversions.ToInteger(ep), Conversions.ToInteger(honor));
                            mainFunctions.log("NPC dead...");
                            Module1.accessingNPCs = false;
                        }
                        else
                        {
                            int attackedHP = num16 - dmgDone;
                            initConnection.updateAttackLasers(userID, attackedHP, ship.getSHD(), dmgDone);
                            ship.setHP(attackedHP);
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            int num2 = Module1.mainHero.getRocketAmmo1();
            int num3 = Module1.mainHero.getRocketAmmo2();
            int num4 = Module1.mainHero.getRocketAmmo3();
            int num5 = Module1.mainHero.getRocketAmmo4();
            int num6 = Module1.mainHero.getRocketAmmo5();
            int num7 = Module1.mainHero.getRocketAmmo6();
            int num8 = Module1.mainHero.getRocketAmmo7();
            int num9 = Module1.mainHero.getRocketAmmo8();
            int num10 = Module1.mainHero.getRocketAmmo9();
            num8--;
            initConnection.sendPacket("0|3|" + Conversions.ToString(num2) + "|" + Conversions.ToString(num3) + "|" + Conversions.ToString(num4) + "|" + Conversions.ToString(num5) + "|" + Conversions.ToString(num6) + "|0|0|" + Conversions.ToString(num7) + "|" + Conversions.ToString(num8) + "|" + Conversions.ToString(num9) + "|" + Conversions.ToString(num10) + "|0|0|0");
            Module1.mainHero.setRocketAmmo(num2, num3, num4, num5, num6, num7, num8, num9, num10);
            new Thread(new ThreadStart(Mine_Module.heroSbombCooldown)).Start();
        }
    }
}

