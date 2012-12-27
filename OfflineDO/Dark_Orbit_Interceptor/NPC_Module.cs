namespace Dark_Orbit_Interceptor
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Threading;

    [StandardModule]
    internal sealed class NPC_Module
    {
        private static DateTime oldTime = DateTime.Now;
        private static Random rnd = new Random();

        public static bool checkForDoubleNPC(int userID)
        {
            int num2 = Module1.displayNPCs.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (mainFunctions.getNPCByID(Conversions.ToInteger(Module1.displayNPCs[i])).getUserID() == userID)
                {
                    return true;
                }
            }
            return false;
        }

        public static void checkNPCInRange(int heroX, int heroY)
        {
            ArrayList list = new ArrayList();
            int num6 = mainFunctions.getNPCCount() - 1;
            for (int i = 0; i <= num6; i++)
            {
                NPCShip ship = mainFunctions.getNPC(i);
                double num3 = ship.getPosX();
                double num4 = ship.getPosY();
                double num = heroX - num3;
                if ((num > -1500.0) & (num < 1500.0))
                {
                    double num5 = heroY - num4;
                    if ((num5 > -1500.0) & (num5 < 1500.0))
                    {
                        list.Add(ship);
                    }
                }
            }
            if (list.Count != 0)
            {
                IEnumerator enumerator;
                try
                {
                    enumerator = list.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        NPCShip current = (NPCShip) enumerator.Current;
                        if (!checkForDoubleNPC(current.getUserID()))
                        {
                            initConnection.createNPC(current.getUserID(), current.getPosX(), current.getPosY(), current.getShipType(), current.getUsername());
                            Module1.displayNPCs.Add(current.getUserID());
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
            }
        }

        public static void checkNPCMovement()
        {
            IEnumerator enumerator;
            IEnumerator enumerator2;
            ArrayList list = new ArrayList();
            try
            {
                enumerator = Module1.displayNPCs.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    NPCShip current = (NPCShip) enumerator.Current;
                    if (current.getMoving())
                    {
                        if ((DateTime.Now.Millisecond - current.getTime().Millisecond) >= current.getMoveTime())
                        {
                            current.setMoving(false);
                            list.Add(current);
                        }
                    }
                    else
                    {
                        list.Add(current);
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
            try
            {
                enumerator2 = list.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    NPCShip ship2 = (NPCShip) enumerator2.Current;
                    int num2 = (int) Math.Round((double) (ship2.getPosX() + rnd.Next(-100, 100)));
                    int num3 = (int) Math.Round((double) (ship2.getPosY() + rnd.Next(-100, 100)));
                    int num = (int) Math.Round(Math.Sqrt(((num2 - Module1.mainHero.getPosX()) * (num2 - Module1.mainHero.getPosX())) + ((num3 - Module1.mainHero.getPosY()) * (num3 - Module1.mainHero.getPosY()))));
                    int time = (int) Math.Round((double) (((double) num) / (((double) ship2.getSpeed()) / 1000.0)));
                    sendNPCMove(ship2.getUserID(), (double) num2, (double) num3, time);
                    ship2.setPosX((double) num2);
                    ship2.setPosY((double) num3);
                    ship2.setMoving(true);
                    ship2.setTime(DateTime.Now);
                    ship2.setMoveTime(time);
                    NPCShip ship3 = mainFunctions.getNPCByID(ship2.getUserID());
                }
            }
            finally
            {
                if (enumerator2 is IDisposable)
                {
                    (enumerator2 as IDisposable).Dispose();
                }
            }
        }

        public static void checkNPCMovement1()
        {
        }

        public static void checkOutRange(double heroX, double heroY)
        {
            if (Module1.displayNPCs.Count != 0)
            {
                ArrayList list = new ArrayList();
                int num7 = Module1.displayNPCs.Count - 1;
                for (int i = 0; i <= num7; i++)
                {
                    NPCShip ship = mainFunctions.getNPCByID(Conversions.ToInteger(Module1.displayNPCs[i]));
                    double num3 = ship.getPosX();
                    double num4 = ship.getPosY();
                    double num = heroX - num3;
                    if ((num < -1500.0) | (num > 1500.0))
                    {
                        list.Add(ship);
                    }
                    else
                    {
                        double num5 = heroY - num4;
                        if ((num5 < -1500.0) | (num5 > 1500.0))
                        {
                            list.Add(ship);
                        }
                    }
                }
                int num8 = list.Count - 1;
                for (int j = 0; j <= num8; j++)
                {
                    initConnection.removeNPCClient((NPCShip) list[j]);
                    Module1.displayNPCs.Remove(((NPCShip) list[j]).getUserID());
                }
            }
        }

        public static void createNPCs(int count, int type, int HP, int SHD, string username, int minDMG, int maxDMG, int speed)
        {
            int num2 = count;
            for (int i = 0; i <= num2; i++)
            {
                NPCShip ship = new NPCShip(rnd.Next(0xa98ac7, 0x5f5e0ff), type, HP, SHD, HP, SHD, username, (double) rnd.Next(10, 0x5207), (double) rnd.Next(10, 0x32c7), minDMG, maxDMG, speed);
                mainFunctions.addNPC(ship);
            }
        }

        public static void NPCMove1()
        {
            IEnumerator enumerator;
            try
            {
                enumerator = Module1.displayNPCs.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    NPCShip ship = mainFunctions.getNPCByID(Conversions.ToInteger(enumerator.Current));
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
                        double num10 = Math.Abs(num3);
                        double num11 = Math.Abs(num4);
                        if (num10 > num11)
                        {
                            if (num3 < 0.0)
                            {
                                num7 = num - ship.getSpeed();
                                num8 = num2;
                                initConnection.sendPacket("0|1|" + Conversions.ToString(ship.getUserID()) + "|" + Conversions.ToString(num7) + "|" + Conversions.ToString(num8) + "|1000");
                            }
                            else
                            {
                                num7 = num + ship.getSpeed();
                                num8 = num2;
                                initConnection.sendPacket("0|1|" + Conversions.ToString(ship.getUserID()) + "|" + Conversions.ToString(num7) + "|" + Conversions.ToString(num8) + "|1000");
                            }
                        }
                        else if (num4 < 0.0)
                        {
                            num7 = num;
                            num8 = num2 - ship.getSpeed();
                            initConnection.sendPacket("0|1|" + Conversions.ToString(ship.getUserID()) + "|" + Conversions.ToString(num7) + "|" + Conversions.ToString(num8) + "|1000");
                        }
                        else
                        {
                            num7 = num;
                            num8 = num2 + ship.getSpeed();
                            initConnection.sendPacket("0|1|" + Conversions.ToString(ship.getUserID()) + "|" + Conversions.ToString(num7) + "|" + Conversions.ToString(num8) + "|1000");
                        }
                    }
                    ship.setPosX(num7);
                    ship.setPosY(num8);
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        public static void NPCThread()
        {
            while (true)
            {
                while (true)
                {
                    if (!initConnection.heroJumping)
                    {
                        break;
                    }
                    mainFunctions.log("Stop NPC's, jumping maps...");
                    mainFunctions.removeAllNPCs();
                    Module1.displayNPCs = new ArrayList();
                    Thread.Sleep(0x1388);
                }
                if (Module1.accessingNPCs)
                {
                    while (Module1.accessingNPCs)
                    {
                    }
                }
                Module1.accessingNPCs = true;
                if (mainFunctions.getNPCCount() < 20)
                {
                    int num = Module1.mainHero.getMapID();
                    switch (num)
                    {
                        case 1:
                            createNPCs(20 - mainFunctions.getNPCCount(), 0x54, 400, 400, "-=[ Streuner ]=-", 20, 20, 200);
                            goto Label_0171;

                        case 2:
                            createNPCs(20 - mainFunctions.getNPCCount(), 0x47, 800, 800, "-=[ Lordakia ]=-", 60, 80, 250);
                            goto Label_0171;

                        case 3:
                            createNPCs(20 - mainFunctions.getNPCCount(), 0x48, 0x186a0, 0x186a0, "-=[ Devolorium ]=-", 800, 0x3e8, 200);
                            goto Label_0171;
                    }
                    if (num == 4)
                    {
                        createNPCs(20 - mainFunctions.getNPCCount(), 0x4a, 0x30d40, 0x30d40, "-=[ Sibleon ]=-", 0x6d6, 0x7d0, 150);
                    }
                    else
                    {
                        mainFunctions.log("Not on a recognised map...");
                        Thread.Sleep(0x3e8);
                    }
                }
            Label_0171:
                checkNPCInRange((int) Math.Round(Module1.mainHero.getPosX()), (int) Math.Round(Module1.mainHero.getPosY()));
                checkOutRange(Module1.mainHero.getPosX(), Module1.mainHero.getPosY());
                NPCMove1();
                Module1.accessingNPCs = false;
                Thread.Sleep(0x3e8);
            }
        }

        public static void sendNPCMove(int userID, double posX, double posY, int time)
        {
            initConnection.sendPacket("0|1|" + Conversions.ToString(userID) + "|" + Conversions.ToString(posX) + "|" + Conversions.ToString(posY) + "|" + Conversions.ToString(time));
            mainFunctions.log("NPC MOVE...");
        }
    }
}

