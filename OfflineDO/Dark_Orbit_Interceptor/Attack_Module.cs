namespace Dark_Orbit_Interceptor
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Threading;

    [StandardModule]
    internal sealed class Attack_Module
    {
        private static int npcAttackID;
        private static double npcUpdatePosX = -1.0;
        private static double npcUpdatePosY = -1.0;
        private static Random rnd = new Random();
        private static int rocketCycle = 1;

        public static void ammoHandler(int ammoType, int amount, bool rockets)
        {
            if (rockets)
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
                if (ammoType == 1)
                {
                    num--;
                }
                else if (ammoType == 2)
                {
                    num2--;
                }
                else if (ammoType == 3)
                {
                    num3--;
                }
                else if (ammoType == 4)
                {
                    num4--;
                }
                initConnection.sendPacket("0|3|" + Conversions.ToString(num) + "|" + Conversions.ToString(num2) + "|" + Conversions.ToString(num3) + "|" + Conversions.ToString(num4) + "|" + Conversions.ToString(num5) + "|0|0|" + Conversions.ToString(num6) + "|" + Conversions.ToString(num7) + "|" + Conversions.ToString(num8) + "|" + Conversions.ToString(num9) + "|0|0|0");
                Module1.mainHero.setRocketAmmo(num, num2, num3, num4, num5, num6, num7, num8, num9);
            }
            else
            {
                int num10 = Module1.mainHero.getLaserAmmo1();
                int num11 = Module1.mainHero.getLaserAmmo2();
                int num12 = Module1.mainHero.getLaserAmmo3();
                int num13 = Module1.mainHero.getLaserAmmo4();
                int num14 = Module1.mainHero.getLaserAmmo5();
                int num15 = Module1.mainHero.getLaserAmmo6();
                if (ammoType == 1)
                {
                    num10 -= amount;
                }
                else if (ammoType == 2)
                {
                    num11 -= amount;
                }
                else if (ammoType == 3)
                {
                    num12 -= amount;
                }
                else if (ammoType == 4)
                {
                    num13 -= amount;
                }
                else if (ammoType == 5)
                {
                    num14 -= amount;
                }
                else if (ammoType == 6)
                {
                    num15 -= amount;
                }
                initConnection.sendPacket("0|B|" + Conversions.ToString(num10) + "|" + Conversions.ToString(num11) + "|" + Conversions.ToString(num12) + "|" + Conversions.ToString(num13) + "|" + Conversions.ToString(num14) + "|" + Conversions.ToString(num15));
                Module1.mainHero.setLaserAmmo(num10, num11, num12, num13, num14, num15);
            }
        }

        public static void attackingNPC(int userID)
        {
            npcAttackID = userID;
            new Thread(new ThreadStart(Attack_Module.attackTHD)).Start();
        }

        public static bool attackNPCRocket()
        {
            int num;
            if (rocketCycle == 0)
            {
                rocketCycle = 1;
                return false;
            }
            int ammoType = Module1.mainHero.getRocketType();
            NPCShip ship = mainFunctions.getNPCByID(npcAttackID);
            int num4 = ship.getHP();
            int attackedSHD = ship.getSHD();
            if (ammoType == Conversions.ToDouble("1"))
            {
                if (Module1.mainHero.getRocketAmmo1() <= 0)
                {
                    mainFunctions.log("Not enough rockets to carry out attack...");
                    return false;
                }
                num = rnd.Next(750, 0x3e8);
            }
            else if (ammoType == Conversions.ToDouble("2"))
            {
                if (Module1.mainHero.getRocketAmmo2() <= 0)
                {
                    mainFunctions.log("Not enough rockets to carry out attack...");
                    return false;
                }
                num = rnd.Next(0x640, 0x7d0);
            }
            else if (ammoType == Conversions.ToDouble("3"))
            {
                if (Module1.mainHero.getRocketAmmo3() <= 0)
                {
                    mainFunctions.log("Not enough rockets to carry out attack...");
                    return false;
                }
                num = rnd.Next(0xdac, 0xfa0);
            }
            else if (ammoType == Conversions.ToDouble("4"))
            {
                if (Module1.mainHero.getRocketAmmo4() <= 0)
                {
                    mainFunctions.log("Not enough rockets to carry out attack...");
                    return false;
                }
                num = rnd.Next(0x1518, 0x1770);
            }
            else
            {
                num = 0;
            }
            ammoHandler(ammoType, 1, true);
            if (num >= num4)
            {
                initConnection.sendPacket("0|v|" + Conversions.ToString(Module1.mainHero.getID()) + "|" + Conversions.ToString(npcAttackID) + "|H|" + Conversions.ToString(ammoType) + "|1|1");
                initConnection.updateAttackRockets(npcAttackID, 0, attackedSHD, num);
                ship.setHP(0);
                return true;
            }
            int attackedHP = num4 - num;
            initConnection.sendPacket("0|v|" + Conversions.ToString(Module1.mainHero.getID()) + "|" + Conversions.ToString(npcAttackID) + "|H|" + Conversions.ToString(ammoType) + "|1|1");
            initConnection.updateAttackRockets(npcAttackID, attackedHP, attackedSHD, num);
            rocketCycle = 0;
            return false;
        }

        public static void attackTHD()
        {
            goto Label_0264;
        Label_0007:
            if (initConnection.heroJumping)
            {
                Module1.mainHero.setLaserAttacking(false);
                npcUpdatePosX = -1.0;
                npcUpdatePosY = -1.0;
                rocketCycle = 1;
                return;
            }
            NPCShip ship = mainFunctions.getNPCByID(npcAttackID);
            if (ship.getHP() <= 0)
            {
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
                            getRewards(ship.getShipType(), ref str, ref str4, ref str2, ref str3);
                            initConnection.destroyNPC(npcAttackID);
                            mainFunctions.removeNPCByID(npcAttackID);
                            Module1.displayNPCs.Remove(npcAttackID);
                            NPCDead(Conversions.ToInteger(str), Conversions.ToInteger(str4), Conversions.ToInteger(str2), Conversions.ToInteger(str3));
                            mainFunctions.log("NPC dead...");
                            Module1.accessingNPCs = false;
                            Module1.mainHero.setLaserAttacking(false);
                            npcUpdatePosX = -1.0;
                            npcUpdatePosY = -1.0;
                            rocketCycle = 1;
                            goto Label_0223;
                        }
                    }
                }
                Module1.accessingNPCs = true;
                string credits = "";
                string uridium = "";
                string ep = "";
                string honor = "";
                getRewards(ship.getShipType(), ref credits, ref uridium, ref ep, ref honor);
                initConnection.destroyNPC(npcAttackID);
                mainFunctions.removeNPCByID(npcAttackID);
                Module1.displayNPCs.Remove(npcAttackID);
                NPCDead(Conversions.ToInteger(credits), Conversions.ToInteger(uridium), Conversions.ToInteger(ep), Conversions.ToInteger(honor));
                mainFunctions.log("NPC dead...");
                Module1.accessingNPCs = false;
                Module1.mainHero.setLaserAttacking(false);
                npcUpdatePosX = -1.0;
                npcUpdatePosY = -1.0;
                rocketCycle = 1;
                return;
            }
        Label_0223:
            if (heroAttackNPC() || attackNPCRocket())
            {
                goto Label_0007;
            }
            NPCAttackHero();
            NPCMove1(ship.getSpeed());
            Thread.Sleep(0x3e8);
        Label_0264:
            if (true)
            {
                goto Label_0007;
            }
        }

        public static void getRewards(int npcID, ref string credits, ref string uridium, ref string ep, ref string honor)
        {
            if (npcID == 0x54)
            {
                credits = "400";
                uridium = "1";
                ep = "400";
                honor = "2";
            }
            else if (npcID == 0x47)
            {
                credits = "800";
                uridium = "2";
                ep = "800";
                honor = "4";
            }
            else if (npcID == 0x48)
            {
                credits = "50000";
                uridium = "16";
                ep = "6400";
                honor = "32";
            }
            else if (npcID == 0x4a)
            {
                credits = "100000";
                uridium = "32";
                ep = "12800";
                honor = "64";
            }
        }

        public static bool heroAttackNPC()
        {
            NPCShip ship = mainFunctions.getNPCByID(npcAttackID);
            double num15 = ship.getPosX();
            double num16 = ship.getPosY();
            double num7 = Module1.mainHero.getPosX();
            double num8 = Module1.mainHero.getPosY();
            double num2 = num7 - num15;
            double num3 = num8 - num16;
            if (!((num2 > 800.0) | (num2 < -800.0)))
            {
                double num9;
                if ((num3 > 800.0) | (num3 < -800.0))
                {
                    return false;
                }
                int num17 = Module1.mainHero.getAmmoType();
                switch (num17)
                {
                    case 1:
                        if (Module1.mainHero.getLaserAmmo1() <= 0)
                        {
                            mainFunctions.log("Not enough ammo to carry out attack...");
                            return false;
                        }
                        break;

                    case 2:
                        if (Module1.mainHero.getLaserAmmo2() <= 0)
                        {
                            mainFunctions.log("Not enough ammo to carry out attack...");
                            return false;
                        }
                        break;

                    case 3:
                        if (Module1.mainHero.getLaserAmmo3() <= 0)
                        {
                            mainFunctions.log("Not enough ammo to carry out attack...");
                            return false;
                        }
                        break;

                    case 4:
                        if (Module1.mainHero.getLaserAmmo4() <= 0)
                        {
                            mainFunctions.log("Not enough ammo to carry out attack...");
                            return false;
                        }
                        break;

                    case 5:
                        if (Module1.mainHero.getLaserAmmo5() <= 0)
                        {
                            mainFunctions.log("Not enough ammo to carry out attack...");
                            return false;
                        }
                        break;

                    default:
                        if ((num17 == 6) && (Module1.mainHero.getLaserAmmo1() <= 0))
                        {
                            mainFunctions.log("Not enough ammo to carry out attack...");
                            return false;
                        }
                        break;
                }
                int amount = Module1.mainHero.getLF3s();
                int num = Module1.mainHero.getBO2s();
                int maxValue = amount * 150;
                int minValue = amount * 0x7d;
                if (ship.getSHD() <= 0)
                {
                    ship.setSHD(0);
                    num9 = 1.0;
                }
                else
                {
                    num9 = 0.4;
                }
                double num18 = 1.0 - num9;
                int dmgDone = rnd.Next(minValue, maxValue);
                if (Module1.mainHero.getAmmoType() == 2)
                {
                    dmgDone *= 2;
                }
                else if (Module1.mainHero.getAmmoType() == 3)
                {
                    dmgDone *= 3;
                }
                else if (Module1.mainHero.getAmmoType() == 4)
                {
                    dmgDone *= 4;
                }
                int num5 = (int) Math.Round((double) (dmgDone * num9));
                int num6 = (int) Math.Round((double) (dmgDone * num18));
                int attackedHP = ship.getHP() - num5;
                int attackedSHD = ship.getSHD() - num6;
                if (dmgDone > (ship.getHP() + ship.getSHD()))
                {
                    initConnection.sendAttack(npcAttackID, Module1.mainHero.getAmmoType() - 1, 0, 1);
                    initConnection.updateAttackLasers(npcAttackID, 0, 0, dmgDone);
                    ammoHandler(Module1.mainHero.getAmmoType(), amount, false);
                    ship.setHP(0);
                    ship.setSHD(0);
                    return true;
                }
                initConnection.sendAttack(npcAttackID, Module1.mainHero.getAmmoType() - 1, 0, 1);
                initConnection.updateAttackLasers(npcAttackID, attackedHP, attackedSHD, dmgDone);
                ammoHandler(Module1.mainHero.getAmmoType(), amount, false);
                ship.setHP(attackedHP);
                ship.setSHD(attackedSHD);
            }
            return false;
        }

        public static void NPCAttackHero()
        {
            NPCShip ship = mainFunctions.getNPCByID(npcAttackID);
            double num13 = ship.getPosX();
            double num14 = ship.getPosY();
            double num6 = Module1.mainHero.getPosX();
            double num7 = Module1.mainHero.getPosY();
            double num = num6 - num13;
            double num2 = num7 - num14;
            if ((!((num > 500.0) | (num < -500.0)) && !((num2 > 500.0) | (num2 < -500.0))) && !initConnection.heroEMP)
            {
                double num8;
                int num9;
                int num10;
                if (initConnection.heroInsta)
                {
                    num10 = 0;
                    num9 = 0;
                }
                else
                {
                    num10 = ship.getMinDMG();
                    num9 = ship.getMaxDMG();
                }
                if (Module1.mainHero.getShield() <= 0)
                {
                    Module1.mainHero.setShield(0, Module1.mainHero.getMaxHP());
                    num8 = 1.0;
                }
                else
                {
                    num8 = 0.1;
                }
                double num15 = 1.0 - num8;
                int dmgDone = rnd.Next(num10, num9);
                int num4 = (int) Math.Round((double) (dmgDone * num8));
                int num5 = (int) Math.Round((double) (dmgDone * num15));
                int attackedHP = Module1.mainHero.getHP() - num4;
                int attackedSHD = Module1.mainHero.getShield() - num5;
                initConnection.sendHeroAttack(npcAttackID, 0, 1, 0);
                initConnection.updateHeroAttackLasers(npcAttackID, attackedHP, attackedSHD, dmgDone);
                Module1.mainHero.setHP(attackedHP, Module1.mainHero.getMaxHP());
                Module1.mainHero.setShield(attackedSHD, Module1.mainHero.getMaxShield());
            }
        }

        public static void NPCDead(int credits, int uridium, int ep, int honour)
        {
            int num = Module1.mainHero.getCredits() + credits;
            int num4 = Module1.mainHero.getUridium() + uridium;
            int num2 = Module1.mainHero.getExperience() + ep;
            int num3 = Module1.mainHero.getHonor() + honour;
            initConnection.sendPacket("0|LM|ST|CRE|" + Conversions.ToString(credits) + "|" + Conversions.ToString(num));
            initConnection.sendPacket("0|LM|ST|URI|" + Conversions.ToString(uridium) + "|" + Conversions.ToString(num4));
            initConnection.sendPacket("0|LM|ST|EP|" + Conversions.ToString(ep) + "|" + Conversions.ToString(num2) + "|" + Conversions.ToString(Module1.mainHero.getLevel()));
            initConnection.sendPacket("0|LM|ST|HON|" + Conversions.ToString(honour) + "|" + Conversions.ToString(num3));
            Module1.mainHero.setCredits(num);
            Module1.mainHero.setUridium(num4);
            Module1.mainHero.setExperience(num2);
            Module1.mainHero.setHonor(num3);
        }

        public static void NPCMove1(int speed)
        {
            NPCShip ship = mainFunctions.getNPCByID(npcAttackID);
            if (!(npcUpdatePosX == -1.0))
            {
                ship.setPosX(npcUpdatePosX);
                ship.setPosY(npcUpdatePosY);
            }
            double num = ship.getPosX();
            double num2 = ship.getPosY();
            double num5 = Module1.mainHero.getPosX();
            double num6 = Module1.mainHero.getPosY();
            double num7 = num;
            double num8 = num2;
            bool flag = false;
            double num3 = num5 - num;
            if (num3 < 0.0)
            {
                if (num3 < -100.0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    num3 = 0.0;
                }
            }
            else if (num3 > 100.0)
            {
                flag = true;
            }
            else
            {
                flag = false;
                num3 = 0.0;
            }
            double num4 = num6 - num2;
            if (num4 < 0.0)
            {
                if (num4 < -100.0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    num4 = 0.0;
                }
            }
            else if (num4 > 100.0)
            {
                flag = true;
            }
            else
            {
                flag = false;
                num4 = 0.0;
            }
            if (flag)
            {
                double num9 = Math.Abs(num3);
                double num10 = Math.Abs(num4);
                if (num9 > num10)
                {
                    if (num3 < 0.0)
                    {
                        num7 = num - speed;
                        num8 = num2;
                        initConnection.sendPacket("0|1|" + Conversions.ToString(npcAttackID) + "|" + Conversions.ToString(num7) + "|" + Conversions.ToString(num8) + "|1000");
                    }
                    else
                    {
                        num7 = num + speed;
                        num8 = num2;
                        initConnection.sendPacket("0|1|" + Conversions.ToString(npcAttackID) + "|" + Conversions.ToString(num7) + "|" + Conversions.ToString(num8) + "|1000");
                    }
                }
                else if (num4 < 0.0)
                {
                    num7 = num;
                    num8 = num2 - speed;
                    initConnection.sendPacket("0|1|" + Conversions.ToString(npcAttackID) + "|" + Conversions.ToString(num7) + "|" + Conversions.ToString(num8) + "|1000");
                }
                else
                {
                    num7 = num;
                    num8 = num2 + speed;
                    initConnection.sendPacket("0|1|" + Conversions.ToString(npcAttackID) + "|" + Conversions.ToString(num7) + "|" + Conversions.ToString(num8) + "|1000");
                }
            }
            npcUpdatePosX = num7;
            npcUpdatePosY = num8;
        }
    }
}

