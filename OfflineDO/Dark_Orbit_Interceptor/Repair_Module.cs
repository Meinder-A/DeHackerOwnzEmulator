namespace Dark_Orbit_Interceptor
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Threading;

    [StandardModule]
    internal sealed class Repair_Module
    {
        private static int count = 0;
        private static double lastHeroX = -1.0;
        private static double lastHeroY = -1.0;
        private static int repStep = 0x3a98;
        private static int shdCount = 0;
        private static int shdStep = 0x4e20;

        public static void monitorHP()
        {
            while (true)
            {
                if (lastHeroX == -1.0)
                {
                    lastHeroX = Module1.mainHero.getPosX();
                    lastHeroY = Module1.mainHero.getPosY();
                }
                if (lastHeroX == Module1.mainHero.getPosX())
                {
                    if (lastHeroY == Module1.mainHero.getPosY())
                    {
                        if (!Module1.mainHero.getLaserAttacking())
                        {
                            count++;
                        }
                        else
                        {
                            lastHeroX = Module1.mainHero.getPosX();
                            lastHeroY = Module1.mainHero.getPosY();
                            count = 0;
                        }
                    }
                    else
                    {
                        lastHeroX = Module1.mainHero.getPosX();
                        lastHeroY = Module1.mainHero.getPosY();
                        count = 0;
                    }
                }
                else
                {
                    lastHeroX = Module1.mainHero.getPosX();
                    lastHeroY = Module1.mainHero.getPosY();
                    count = 0;
                }
                if (count >= 5)
                {
                    if (Module1.mainHero.getHP() < Module1.mainHero.getMaxHP())
                    {
                        int num = Module1.mainHero.getMaxHP() - Module1.mainHero.getHP();
                        if (num < repStep)
                        {
                            int num2 = Module1.mainHero.getMaxHP();
                            initConnection.sendPacket("0|A|HPT|" + Conversions.ToString(num2) + "|" + Conversions.ToString(Module1.mainHero.getMaxHP()));
                            Module1.mainHero.setHP(num2, Module1.mainHero.getMaxHP());
                            mainFunctions.log("Hero fully repaired...");
                        }
                        else
                        {
                            int num3 = Module1.mainHero.getHP() + repStep;
                            initConnection.sendPacket("0|A|HPT|" + Conversions.ToString(num3) + "|" + Conversions.ToString(Module1.mainHero.getMaxHP()));
                            Module1.mainHero.setHP(num3, Module1.mainHero.getMaxHP());
                            mainFunctions.log("Hero repairing...");
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }
                Thread.Sleep(0x3e8);
            }
        }

        public static void monitorSHD()
        {
            while (true)
            {
                if (!Module1.mainHero.getLaserAttacking())
                {
                    shdCount++;
                }
                else
                {
                    shdCount = 0;
                }
                if (shdCount >= 5)
                {
                    if (Module1.mainHero.getShield() < Module1.mainHero.getMaxShield())
                    {
                        int num = Module1.mainHero.getMaxShield() - Module1.mainHero.getShield();
                        if (num < shdStep)
                        {
                            int num2 = Module1.mainHero.getMaxShield();
                            initConnection.sendPacket("0|A|SHD|" + Conversions.ToString(num2) + "|" + Conversions.ToString(Module1.mainHero.getMaxShield()));
                            Module1.mainHero.setShield(num2, Module1.mainHero.getMaxShield());
                        }
                        else
                        {
                            int num3 = Module1.mainHero.getShield() + shdStep;
                            initConnection.sendPacket("0|A|SHD|" + Conversions.ToString(num3) + "|" + Conversions.ToString(Module1.mainHero.getMaxShield()));
                            Module1.mainHero.setShield(num3, Module1.mainHero.getMaxShield());
                        }
                    }
                    else
                    {
                        shdCount = 0;
                    }
                }
                Thread.Sleep(0x3e8);
            }
        }
    }
}

