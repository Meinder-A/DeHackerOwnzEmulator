namespace Dark_Orbit_Interceptor
{
    using Dark_Orbit_Interceptor.My;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading;

    [StandardModule]
    internal sealed class initConnection
    {
        public static bool empCooldown = false;
        public static bool heroEMP = false;
        public static bool heroInsta = false;
        public static bool heroJumping = false;
        public static bool instaCooldown = false;
        private static TcpClient mainClient;
        private static TcpListener mainSocket = new TcpListener(0x1f90);
        private static NetworkStream mainStream;
        private static TcpClient mapsLoadClient;
        private static TcpListener mapsLoadSocket = new TcpListener(0x232a);
        private static NetworkStream mapsLoadStream;
        private static TcpClient pageLoadClient;
        private static TcpListener pageLoadSocket = new TcpListener(0x2329);
        private static NetworkStream pageLoadStream;
        public static bool sbombCooldown = false;

        public static void createNPC(int userID, double posX, double posY, int type, string usrname)
        {
            sendPacket("0|C|" + Conversions.ToString(userID) + "|" + Conversions.ToString(type) + "|1||" + usrname + "|" + Conversions.ToString(posX) + "|" + Conversions.ToString(posY) + "|0|0|0|0|0|0|0|1|0");
            mainFunctions.log("Created NPC at, X: " + Conversions.ToString(posX) + ", Y: " + Conversions.ToString(posY) + "...");
        }

        public static void createShip(DOShip ship1)
        {
            sendPacket("0|C|" + Conversions.ToString(ship1.getUserID()) + "|" + Conversions.ToString(ship1.getShipType()) + "|3|" + ship1.getClanTag() + "|" + ship1.getUsername() + "|" + Conversions.ToString(ship1.getPosX()) + "|" + Conversions.ToString(ship1.getPosY()) + "|" + Conversions.ToString(ship1.getCompany()) + "|" + Conversions.ToString(ship1.getClanID()) + "|" + Conversions.ToString(ship1.getRank()) + "|0|" + Conversions.ToString(ship1.getClanDiplomacy()) + "|" + Conversions.ToString(ship1.getGGDone()) + "|0|0|0|0");
            mainFunctions.log("Created shiip...");
        }

        public static void destroyNPC(int userID)
        {
            sendPacket("0|K|" + Conversions.ToString(userID));
            mainFunctions.log("Ship: " + Conversions.ToString(userID) + "...Is destroyed...");
        }

        public static bool hackMapsPHP()
        {
            mainFunctions.log("\r\n");
            mainFunctions.log("Starting stage 2 - hacking maps.php...");
            mapsLoadSocket.Start();
            mapsLoadClient = mapsLoadSocket.AcceptTcpClient();
            mainFunctions.log("Accepted connection for maps.php...");
            mapsLoadStream = mapsLoadClient.GetStream();
            byte[] buffer = new byte[0x2729];
            mapsLoadStream.Read(buffer, 0, mapsLoadClient.ReceiveBufferSize);
            string str = Encoding.UTF8.GetString(buffer);
            mainFunctions.log("Received maps.php request packet from client...");
            string s = MyProject.Computer.FileSystem.ReadAllText(Module1.mainDir + "maps.txt");
            mapsLoadStream = mapsLoadClient.GetStream();
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            mapsLoadStream.Write(bytes, 0, bytes.Length);
            mapsLoadStream.Flush();
            mapsLoadStream.Close();
            mapsLoadSocket.Stop();
            mainFunctions.log("Sent maps.php packet back... Moving on to stage 3...");
            return true;
        }

        public static bool hackSecurityPolicy()
        {
            mainFunctions.log("\r\n");
            mainFunctions.log("Starting stage 3 - hacking security policy...");
            mainSocket.Start();
            mainClient = mainSocket.AcceptTcpClient();
            mainFunctions.log("Accepted connection from security policy...");
            mainStream = mainClient.GetStream();
            byte[] buffer = new byte[0x2729];
            mainStream.Read(buffer, 0, mainClient.ReceiveBufferSize);
            string str = Encoding.UTF8.GetString(buffer);
            mainFunctions.log("Received security policy packet from client...");
            string s = MyProject.Computer.FileSystem.ReadAllText(Module1.mainDir + "policy_response.txt");
            mainStream = mainClient.GetStream();
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            mainStream.Write(bytes, 0, bytes.Length);
            mainStream.Flush();
            mainStream.Close();
            mainClient.Close();
            mainSocket.Stop();
            mainFunctions.log("Sent hacked security policy... Get ready for game connection...");
            return true;
        }

        public static void listenToClient()
        {
            mainFunctions.log("\r\n");
            mainFunctions.log("Starting connection with client...");
            mainSocket.Start();
            mainClient = mainSocket.AcceptTcpClient();
            mainFunctions.log("Accepted connection from client...");
            mainFunctions.log("Waiting for packets...");
            new Thread(new ThreadStart(initConnection.receivePacket)).Start();
        }

        public static void logoutHero()
        {
            while (true)
            {
                Thread.Sleep(0x2710);
                string text = "0|I|" + Conversions.ToString(Module1.mainHero.getID()) + "|" + Module1.mainHero.getUsername() + "|" + Conversions.ToString(Module1.mainHero.getShipID()) + "|" + Conversions.ToString(Module1.mainHero.getSpeed()) + "|" + Conversions.ToString(Module1.mainHero.getShield()) + "|" + Conversions.ToString(Module1.mainHero.getMaxShield()) + "|" + Conversions.ToString(Module1.mainHero.getHP()) + "|" + Conversions.ToString(Module1.mainHero.getMaxHP()) + "|" + Conversions.ToString(Module1.mainHero.getCargo()) + "|" + Conversions.ToString(Module1.mainHero.getMaxCargo()) + "|" + Conversions.ToString(Module1.mainHero.getPosX()) + "|" + Conversions.ToString(Module1.mainHero.getPosY()) + "|" + Conversions.ToString(Module1.mainHero.getMapID()) + "|" + Conversions.ToString(Module1.mainHero.getCompany()) + "|" + Conversions.ToString(Module1.mainHero.getClanID()) + "|" + Conversions.ToString(Module1.mainHero.getMaxLaserAmmo()) + "|" + Conversions.ToString(Module1.mainHero.getMaxRocketAmmo()) + "|" + Conversions.ToString(Module1.mainHero.getExpansionID()) + "|" + Conversions.ToString(Convert.ToInt32(Module1.mainHero.getPremium())) + "|" + Conversions.ToString(Module1.mainHero.getExperience()) + "|" + Conversions.ToString(Module1.mainHero.getHonor()) + "|" + Conversions.ToString(Module1.mainHero.getLevel()) + "|" + Conversions.ToString(Module1.mainHero.getCredits()) + "|" + Conversions.ToString(Module1.mainHero.getUridium()) + "|" + Conversions.ToString(Module1.mainHero.getJackpot()) + "|" + Conversions.ToString(Module1.mainHero.getAdmin()) + "|" + Module1.mainHero.getClan() + "|" + Conversions.ToString(Module1.mainHero.getGalaxyGatesDone()) + "|" + Conversions.ToString(Convert.ToInt32(Module1.mainHero.getCloaked())) + "|0";
                MyProject.Computer.FileSystem.WriteAllText(@"C:\DO_Hacks\hero.dll", text, false);
                string str = Conversions.ToString(Module1.mainHero.getLaserAmmo1()) + "|" + Conversions.ToString(Module1.mainHero.getLaserAmmo2()) + "|" + Conversions.ToString(Module1.mainHero.getLaserAmmo3()) + "|" + Conversions.ToString(Module1.mainHero.getLaserAmmo4()) + "|" + Conversions.ToString(Module1.mainHero.getLaserAmmo5()) + "|" + Conversions.ToString(Module1.mainHero.getLaserAmmo6());
                MyProject.Computer.FileSystem.WriteAllText(@"C:\DO_Hacks\hero_laserammo.dll", str, false);
                string str2 = Conversions.ToString(Module1.mainHero.getRocketAmmo1()) + "|" + Conversions.ToString(Module1.mainHero.getRocketAmmo2()) + "|" + Conversions.ToString(Module1.mainHero.getRocketAmmo3()) + "|" + Conversions.ToString(Module1.mainHero.getRocketAmmo4()) + "|" + Conversions.ToString(Module1.mainHero.getRocketAmmo5()) + "|0|0|" + Conversions.ToString(Module1.mainHero.getRocketAmmo6()) + "|" + Conversions.ToString(Module1.mainHero.getRocketAmmo7()) + "|" + Conversions.ToString(Module1.mainHero.getRocketAmmo8()) + "|" + Conversions.ToString(Module1.mainHero.getRocketAmmo9()) + "|0|0|0";
                MyProject.Computer.FileSystem.WriteAllText(@"C:\DO_Hacks\hero_rocketammo.dll", str2, false);
                mainFunctions.log("Saved Hero...");
            }
        }

        public static void packetHandler(string packet)
        {
            string[] strArray = packet.Split(new char[] { '|' });
            if (strArray[0] == "LOGIN")
            {
                setupClientWindow();
                setupHero(Module1.mainDir + "hero.dll");
                setupMoreClient();
            }
            if (strArray[0] == "SEL")
            {
                mainFunctions.log("Selected ship: " + strArray[1]);
                DOShip expression = mainFunctions.getShipByID(Conversions.ToInteger(strArray[1]));
                if (Information.IsNothing(expression))
                {
                    NPCShip ship2 = mainFunctions.getNPCByID(Conversions.ToInteger(strArray[1]));
                    sendPacket("0|N|" + Conversions.ToString(ship2.getUserID()) + "|" + Conversions.ToString(ship2.getShipType()) + "|" + Conversions.ToString(ship2.getHP()) + "|" + Conversions.ToString(ship2.getMaxHP()) + "|" + Conversions.ToString(ship2.getSHD()) + "|" + Conversions.ToString(ship2.getMaxSHD()) + "|0");
                }
                else
                {
                    sendPacket("0|N|" + Conversions.ToString(expression.getUserID()) + "|" + Conversions.ToString(expression.getShipType()) + "|" + Conversions.ToString(expression.getHP()) + "|" + Conversions.ToString(expression.getMaxHP()) + "|" + Conversions.ToString(expression.getSHD()) + "|" + Conversions.ToString(expression.getMaxSHD()) + "|" + Conversions.ToString(expression.getCloaked()));
                }
            }
            if (strArray[0] == "a")
            {
                mainFunctions.log("Attacking ship: " + strArray[1]);
                if (Information.IsNothing(mainFunctions.getShipByID(Conversions.ToInteger(strArray[1]))))
                {
                    NPCShip ship4 = mainFunctions.getNPCByID(Conversions.ToInteger(strArray[1]));
                    Attack_Module.attackingNPC(Conversions.ToInteger(strArray[1]));
                }
                Module1.mainHero.setLaserAttacking(true);
            }
            if (strArray[0] == "1")
            {
                Module1.mainHero.setPosX(Conversions.ToInteger(strArray[1]));
                Module1.mainHero.setPosY(Conversions.ToInteger(strArray[2]));
            }
            if (strArray[0] == "u")
            {
                Module1.mainHero.setAmmoType(Conversions.ToInteger(strArray[1]));
                mainFunctions.log("Hero's ammo is now: " + Conversions.ToString(Module1.mainHero.getAmmoType()));
            }
            if (strArray[0] == "G")
            {
                Module1.mainHero.setLaserAttacking(false);
            }
            if (strArray[0] == "S")
            {
                if (strArray[1] == "SMB")
                {
                    if (sbombCooldown)
                    {
                        mainFunctions.log("wait... sbmb cooling...");
                        return;
                    }
                    sendPacket("0|n|SMB|" + Conversions.ToString(Module1.mainHero.getID()));
                    Mine_Module.heroSbombd(Module1.mainHero.getPosX(), Module1.mainHero.getPosY());
                    mainFunctions.log("Hero set off Sbomb...");
                }
                else if (strArray[1] == "ISH")
                {
                    if (instaCooldown)
                    {
                        mainFunctions.log("Wait... Insta cooling...");
                        return;
                    }
                    sendPacket("0|n|ISH|" + Conversions.ToString(Module1.mainHero.getID()));
                    if (heroInsta)
                    {
                        return;
                    }
                    new Thread(new ThreadStart(Mine_Module.heroInstad)).Start();
                    mainFunctions.log("Hero set off Insta Shield...");
                }
                else if (strArray[1] == "EMP")
                {
                    if (empCooldown)
                    {
                        mainFunctions.log("Wait... EMP cooling...");
                        return;
                    }
                    sendPacket("0|n|EMP|" + Conversions.ToString(Module1.mainHero.getID()));
                    if (heroEMP)
                    {
                        return;
                    }
                    new Thread(new ThreadStart(Mine_Module.heroEMPd)).Start();
                    mainFunctions.log("Hero set off EMP...");
                }
            }
            if (strArray[0] == "d")
            {
                Module1.mainHero.setRocketType(Conversions.ToInteger(strArray[1]));
                mainFunctions.log("Hero's rocket ammo is now: " + strArray[1]);
            }
            if (strArray[0] == "l")
            {
            }
            if (strArray[0] == "j")
            {
                Portal portal = Portal_Module.getCurPortal(Module1.mainHero.getPosX(), Module1.mainHero.getPosY());
                if (!Information.IsNothing(portal))
                {
                    heroJumping = true;
                    sendPacket("0|U|99|" + Conversions.ToString(portal.getID()));
                    mainFunctions.log("Sent jumping thingy...");
                    Thread.Sleep(0xbb8);
                    mainFunctions.log("Jump should be done now...");
                    Module1.mainHero.setMapID(Portal_Module.getNewMap(portal.getID()));
                    Vector vector = Portal_Module.getHeroPos(portal.getID());
                    Module1.mainHero.setPosX((int) Math.Round(vector.x));
                    Module1.mainHero.setPosY((int) Math.Round(vector.y));
                    string text = "0|I|" + Conversions.ToString(Module1.mainHero.getID()) + "|" + Module1.mainHero.getUsername() + "|" + Conversions.ToString(Module1.mainHero.getShipID()) + "|" + Conversions.ToString(Module1.mainHero.getSpeed()) + "|" + Conversions.ToString(Module1.mainHero.getShield()) + "|" + Conversions.ToString(Module1.mainHero.getMaxShield()) + "|" + Conversions.ToString(Module1.mainHero.getHP()) + "|" + Conversions.ToString(Module1.mainHero.getMaxHP()) + "|" + Conversions.ToString(Module1.mainHero.getCargo()) + "|" + Conversions.ToString(Module1.mainHero.getMaxCargo()) + "|" + Conversions.ToString(Module1.mainHero.getPosX()) + "|" + Conversions.ToString(Module1.mainHero.getPosY()) + "|" + Conversions.ToString(Module1.mainHero.getMapID()) + "|" + Conversions.ToString(Module1.mainHero.getCompany()) + "|" + Conversions.ToString(Module1.mainHero.getClanID()) + "|" + Conversions.ToString(Module1.mainHero.getMaxLaserAmmo()) + "|" + Conversions.ToString(Module1.mainHero.getMaxRocketAmmo()) + "|" + Conversions.ToString(Module1.mainHero.getExpansionID()) + "|" + Conversions.ToString(Convert.ToInt32(Module1.mainHero.getPremium())) + "|" + Conversions.ToString(Module1.mainHero.getExperience()) + "|" + Conversions.ToString(Module1.mainHero.getHonor()) + "|" + Conversions.ToString(Module1.mainHero.getLevel()) + "|" + Conversions.ToString(Module1.mainHero.getCredits()) + "|" + Conversions.ToString(Module1.mainHero.getUridium()) + "|" + Conversions.ToString(Module1.mainHero.getJackpot()) + "|" + Conversions.ToString(Module1.mainHero.getAdmin()) + "|" + Module1.mainHero.getClan() + "|" + Conversions.ToString(Module1.mainHero.getGalaxyGatesDone()) + "|" + Conversions.ToString(Convert.ToInt32(Module1.mainHero.getCloaked())) + "|0";
                    MyProject.Computer.FileSystem.WriteAllText(@"C:\DO_Hacks\hero.dll", text, false);
                    string str = Conversions.ToString(Module1.mainHero.getLaserAmmo1()) + "|" + Conversions.ToString(Module1.mainHero.getLaserAmmo2()) + "|" + Conversions.ToString(Module1.mainHero.getLaserAmmo3()) + "|" + Conversions.ToString(Module1.mainHero.getLaserAmmo4()) + "|" + Conversions.ToString(Module1.mainHero.getLaserAmmo5()) + "|" + Conversions.ToString(Module1.mainHero.getLaserAmmo6());
                    MyProject.Computer.FileSystem.WriteAllText(@"C:\DO_Hacks\hero_laserammo.dll", str, false);
                    string str2 = Conversions.ToString(Module1.mainHero.getRocketAmmo1()) + "|" + Conversions.ToString(Module1.mainHero.getRocketAmmo2()) + "|" + Conversions.ToString(Module1.mainHero.getRocketAmmo3()) + "|" + Conversions.ToString(Module1.mainHero.getRocketAmmo4()) + "|" + Conversions.ToString(Module1.mainHero.getRocketAmmo5()) + "|0|0|" + Conversions.ToString(Module1.mainHero.getRocketAmmo6()) + "|" + Conversions.ToString(Module1.mainHero.getRocketAmmo7()) + "|" + Conversions.ToString(Module1.mainHero.getRocketAmmo8()) + "|" + Conversions.ToString(Module1.mainHero.getRocketAmmo9()) + "|0|0|0";
                    MyProject.Computer.FileSystem.WriteAllText(@"C:\DO_Hacks\hero_rocketammo.dll", str2, false);
                    mainFunctions.log("Saved Hero...");
                    setupHero(Module1.mainDir + "hero.dll");
                    setupMoreClient();
                    heroJumping = false;
                }
                else
                {
                    mainFunctions.log("not close enough to portal...");
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        public static void receivePacket()
        {
            try
            {
                int num;
                int num2;
                while (true)
                {
                    ProjectData.ClearProjectError();
                    num = 2;
                    mainStream = mainClient.GetStream();
                    byte[] buffer = new byte[0x2729];
                    mainStream.Read(buffer, 0, mainClient.ReceiveBufferSize);
                    string packet = Encoding.UTF8.GetString(buffer);
                    packet = packet.Substring(0, packet.IndexOf("\n"));
                    mainFunctions.log("Received packet from client...\r\n" + packet);
                    packetHandler(packet);
                }
            Label_007B:
                ProjectData.EndApp();
                if (num2 != 0)
                {
                    ProjectData.ClearProjectError();
                }
                return;
            Label_0084:
                num2 = -1;
                switch (num)
                {
                    case 0:
                    case 1:
                        goto Label_00BA;

                    case 2:
                        goto Label_007B;
                }
            }
            catch (object obj1) when (?)
            {
                ProjectData.SetProjectError((Exception) obj1);
                goto Label_0084;
            }
        Label_00BA:
            throw ProjectData.CreateProjectError(-2146828237);
        }

        public static void removeNPCClient(NPCShip npc1)
        {
            sendPacket("0|R|" + Conversions.ToString(npc1.getUserID()));
            mainFunctions.log("Deleted NPC: " + Conversions.ToString(npc1.getUserID()));
        }

        public static void removeShipClient(DOShip ship1)
        {
            sendPacket("0|R|" + Conversions.ToString(ship1.getUserID()));
            mainFunctions.log("Deleted ship: " + Conversions.ToString(ship1.getUserID()));
        }

        public static void sendAttack(int userID, int ammoTyper, int bioSHD, int bioLasers)
        {
            sendPacket("0|a|" + Conversions.ToString(Module1.mainHero.getID()) + "|" + Conversions.ToString(userID) + "|" + Conversions.ToString(ammoTyper) + "|" + Conversions.ToString(bioSHD) + "|" + Conversions.ToString(bioLasers));
            mainFunctions.log("sent attack...");
        }

        public static void sendHeroAttack(int userID, int ammoTyper, int bioSHD, int bioLasers)
        {
            sendPacket("0|a|" + Conversions.ToString(userID) + "|" + Conversions.ToString(Module1.mainHero.getID()) + "|" + Conversions.ToString(ammoTyper) + "|" + Conversions.ToString(bioSHD) + "|" + Conversions.ToString(bioLasers));
            mainFunctions.log("sent hero attack...");
        }

        public static void sendPacket(string packet)
        {
            mainStream = mainClient.GetStream();
            byte[] bytes = Encoding.UTF8.GetBytes(packet + "\r\n\0");
            mainStream.Write(bytes, 0, bytes.Length);
            mainStream.Flush();
            mainFunctions.log("Sent packet: " + packet);
            Thread.Sleep(5);
        }

        public static void setupClientWindow()
        {
            sendPacket("0|TX|S|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0");
            sendPacket("0|A|SET|1|1|1|1|1|1|1|1|1|1|1|0|0|1|1|1|2|1|1|0|0|1|0|1|1");
            sendPacket("0|7|AUTO_START|1");
            sendPacket("0|7|SHOW_DRONES|1");
            sendPacket("0|7|SLOTMENU_ORDER,0|0");
            sendPacket("0|7|CLIENT_RESOLUTION|3,1280,720");
            sendPacket("0|7|DISPLAY_ENGINE_WASTE|0");
            sendPacket("0|7|MAINMENU_POSITION,0|320,502");
            sendPacket("0|7|MAINMENU_POSITION,1|349,480");
            sendPacket("0|7|MAINMENU_POSITION,2|394,622");
            sendPacket("0|7|SEL_HST|9");
            sendPacket("0|7|DOUBLECLICK_ATTACK|1");
            sendPacket("0|7|MAINMENU_POSITION,3|514,623");
            sendPacket("0|7|WINDOW_SETTINGS,3|0,444,-1,0,1,1057,329,1,20,39,530,0,3,1021,528,1,5,-10,-6,0,24,463,15,0,10,101,307,0,36,100,400,0,13,315,122,0,23,1067,132,0");
            sendPacket("0|7|WINDOW_SETTINGS,2|0,263,2,1,1,488,1,1,15,724,5,1,3,1016,458,0,5,5,5,0,24,500,61,0,10,-2,155,1,20,-1,382,1,13,187,50,0,23,838,213,1");
            sendPacket("0|7|SIMPLE_SHIPS|0");
            sendPacket("0|7|BAR_STATUS|32,1,34,0,35,0,23,1,24,1,25,1,26,1,27,1,39,0");
            sendPacket("0|7|RESIZABLE_WINDOWS,3|5,240,150,20,321,171");
            sendPacket("0|7|DISPLAY_WINDOW_BACKGROUND|0");
            sendPacket("0|7|RESIZABLE_WINDOWS,2|5,240,150,20,308,246");
            sendPacket("0|7|PRELOAD_USER_SHIPS|1");
            sendPacket("0|7|SLOTMENU_POSITION,3|478,593");
            sendPacket("0|7|RESIZABLE_WINDOWS,0|5,251,142,20,303,217");
            sendPacket("0|7|AUTO_REFINEMENT|0");
            sendPacket("0|7|SLOTMENU_POSITION,1|312,451");
            sendPacket("0|7|WINDOW_SETTINGS,1|0,271,38,0,1,481,4,0,24,500,61,0,3,1016,458,1,5,-3,-9,0,10,-2,155,1,20,2,390,1,13,187,50,0,23,835,201,1");
            sendPacket("0|7|SLOTMENU_POSITION,2|358,592");
            sendPacket("0|7|WINDOW_SETTINGS,0|0,18,9,1,1,244,14,1,24,173,63,0,3,558,406,1,5,7,5,0,10,89,198,0,20,-10,370,1,13,85,62,0,23,604,135,1");
            sendPacket("0|7|SLOTMENU_POSITION,0|284,477");
            sendPacket("0|7|QUICKBAR_SLOT|3,46,39,6,7,50,12,13,23,-1");
            sendPacket("0|7|ALWAYS_DRAGGABLE_WINDOWS|1");
            sendPacket("0|7|QUICKSLOT_STOP_ATTACK|1");
        }

        public static void setupHero(string heroDir)
        {
            string packet = MyProject.Computer.FileSystem.ReadAllText(heroDir);
            string[] strArray = packet.Split(new char[] { '|' });
            Module1.mainHero.setHero(Convert.ToInt32(strArray[2]), strArray[3], Convert.ToInt32(strArray[4]), Convert.ToInt32(strArray[5]), Convert.ToInt32(strArray[6]), Convert.ToInt32(strArray[7]), Convert.ToInt32(strArray[8]), Convert.ToInt32(strArray[9]), Convert.ToInt32(strArray[10]), Convert.ToInt32(strArray[11]), Convert.ToDouble(strArray[12]), Convert.ToDouble(strArray[13]), Convert.ToInt32(strArray[14]), Convert.ToInt32(strArray[15]), Convert.ToInt32(strArray[0x10]), Convert.ToInt32(strArray[0x11]), Convert.ToInt32(strArray[0x12]), Convert.ToInt32(strArray[0x13]), Convert.ToInt32(strArray[20]), Convert.ToInt32(strArray[0x15]), Convert.ToInt32(strArray[0x16]), Convert.ToInt32(strArray[0x17]), Convert.ToInt32(strArray[0x18]), Convert.ToInt32(strArray[0x19]), Convert.ToDouble(strArray[0x1a]), Convert.ToInt32(strArray[0x1b]), strArray[0x1c], Convert.ToInt32(strArray[0x1d]), Convert.ToBoolean(Convert.ToInt32(strArray[30])), 1, 1);
            Module1.mainHero.setLF3s(0x1f);
            Module1.mainHero.setBO2s(0x10);
            sendPacket(packet);
            string str2 = MyProject.Computer.FileSystem.ReadAllText(@"C:\DO_Hacks\hero_laserammo.dll");
            sendPacket("0|B|" + str2);
            string str3 = MyProject.Computer.FileSystem.ReadAllText(@"C:\DO_Hacks\hero_rocketammo.dll");
            sendPacket("0|3|" + str3);
            string[] strArray2 = str2.Split(new char[] { '|' });
            Module1.mainHero.setLaserAmmo(Conversions.ToInteger(strArray2[0]), Conversions.ToInteger(strArray2[1]), Conversions.ToInteger(strArray2[2]), Conversions.ToInteger(strArray2[3]), Conversions.ToInteger(strArray2[4]), Conversions.ToInteger(strArray2[5]));
            string[] strArray3 = str3.Split(new char[] { '|' });
            Module1.mainHero.setRocketAmmo(Conversions.ToInteger(strArray3[0]), Conversions.ToInteger(strArray3[1]), Conversions.ToInteger(strArray3[2]), Conversions.ToInteger(strArray3[3]), Conversions.ToInteger(strArray3[4]), Conversions.ToInteger(strArray3[7]), Conversions.ToInteger(strArray3[8]), Conversions.ToInteger(strArray3[9]), Conversions.ToInteger(strArray3[10]));
        }

        public static void setupMoreClient()
        {
            sendPacket("0|A|CC|2");
            sendPacket("0|RL|S|0|9|0");
            sendPacket("0|RL|R|51|0|36");
            sendPacket("0|TX|S|0|0|0|0|0|0|1|1|0|0|0|0|0|0|0");
            sendPacket("0|A|ITM|0|0|2|0|3|0|1|1|0|0|0|1|0|0|0|0");
            sendPacket("0|E|1|0|0|7832|0|0|0|0|0");
            sendPacket("0|m|1|21000|13500");
            if (Module1.mainHero.getMapID() == 1)
            {
                sendPacket("0|s|0|1|Vice Station|1|1500|1000|1000");
            }
            Portal_Module.setAllPortalsByMap(Module1.mainHero.getMapID());
            sendPacket("0|n|ctb|m|0");
            sendPacket("0|n|INV|39213288|1");
            sendPacket("0|n|e|88888888|0/8");
            sendPacket("0|A|CPU|R|1");
            sendPacket("0|A|CPU|J|2|1|6");
            sendPacket("0|S|CFG|2");
            sendPacket("0|n|w|0");
            sendPacket("0|g|a|b,1000,1,10000.0,C,2,500.0,U,3,1000.0,U,5,1000.0,U|r,100,1,10000,C,2,50000,C,3,500.0,U,4,700.0,U");
            sendPacket("0|9|ini|{case:605,0,1,1{cond:1275,27,2,14,24,5,5,0,1,2}{cond:1140,6,15,5,5,0,1,2}{cond:1141,6,16,4,5,1,1,1}{cond:1142,6,17,0,5,0,1,1}{cond:1143,6,18,0,5,0,1,1}{cond:1144,6,19,0,5,0,1,1}{cond:1145,6,20,0,5,0,1,1}{cond:1146,6,21,0,5,0,1,1}{cond:1147,6,22,0,5,0,1,1}{cond:1148,6,23,0,5,0,1,1}}");
            sendPacket("0|9|p|605");
            sendPacket("0|A|BS|0/0/0/0/0/0/0/0/0/0");
            sendPacket("0|A|FWX|INL|-1");
            sendPacket("0|A|SET|1|1|1|1|1|1|1|1|1|1|1|0|0|1|1|1|2|1|1|0|0|1|0|1|1");
            sendPacket("0|D|1046|713|1|0|0|0|0|0|1046|713");
            sendPacket("0|PET|I|0|0|0");
            sendPacket("0|A|v|450");
            sendPacket("0|8");
            sendPacket("0|E|1|0|0|7832|0|0|0|0|0");
            sendPacket("0|LAB|UPD|INFO|LASER|14|5563|ROCKET|13|0");
            sendPacket("0|u|" + Conversions.ToString(Module1.mainHero.getAmmoType()));
        }

        public static void updateAttackLasers(int userID, int attackedHP, int attackedSHD, int dmgDone)
        {
            sendPacket("0|Y|" + Conversions.ToString(Module1.mainHero.getID()) + "|" + Conversions.ToString(userID) + "|L|" + Conversions.ToString(attackedHP) + "|" + Conversions.ToString(attackedSHD) + "|" + Conversions.ToString(dmgDone) + "|0");
            mainFunctions.log("updated laser attack...");
        }

        public static void updateAttackRockets(int userID, int attackedHP, int attackedSHD, int dmgDone)
        {
            sendPacket("0|Y|" + Conversions.ToString(Module1.mainHero.getID()) + "|" + Conversions.ToString(userID) + "|R|" + Conversions.ToString(attackedHP) + "|" + Conversions.ToString(attackedSHD) + "|" + Conversions.ToString(dmgDone) + "|0");
            mainFunctions.log("updated rocket attack...");
        }

        public static void updateHeroAttackLasers(int userID, int attackedHP, int attackedSHD, int dmgDone)
        {
            sendPacket("0|Y|" + Conversions.ToString(userID) + "|" + Conversions.ToString(Module1.mainHero.getID()) + "|L|" + Conversions.ToString(attackedHP) + "|" + Conversions.ToString(attackedSHD) + "|" + Conversions.ToString(dmgDone) + "|0");
            mainFunctions.log("updated hero laser attack...");
        }

        public static bool waitForClient()
        {
            mainFunctions.clearConsole();
            mainFunctions.log("Starting stage 1 - loading spacemap...");
            pageLoadSocket.Start();
            pageLoadClient = pageLoadSocket.AcceptTcpClient();
            mainFunctions.log("Accepted connection from client...");
            pageLoadStream = pageLoadClient.GetStream();
            byte[] buffer = new byte[0x2729];
            pageLoadStream.Read(buffer, 0, pageLoadClient.ReceiveBufferSize);
            string str = Encoding.UTF8.GetString(buffer);
            mainFunctions.log("Received page load packet from client...");
            string s = MyProject.Computer.FileSystem.ReadAllText(Module1.mainDir + "test1.txt");
            pageLoadStream = pageLoadClient.GetStream();
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            pageLoadStream.Write(bytes, 0, bytes.Length);
            pageLoadStream.Flush();
            pageLoadStream.Close();
            pageLoadSocket.Stop();
            mainFunctions.log("Sent page load packet back... Moving on to stage 2...");
            return true;
        }
    }
}

