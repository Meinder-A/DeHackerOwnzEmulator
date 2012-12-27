namespace Dark_Orbit_Interceptor
{
    using Dark_Orbit_Interceptor.My;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Net.Sockets;
    using System.Threading;

    [StandardModule]
    internal sealed class Module1
    {
        public static bool accessingNPCs = false;
        public static ArrayList displayNPCs = new ArrayList();
        public static ArrayList displayShips = new ArrayList();
        private static TcpClient mainClient;
        public static string mainDir = @"C:\DO_Hacks\";
        public static Hero mainHero = new Hero();
        private static TcpListener mainSocket = new TcpListener(0x1f90);
        private static NetworkStream mainStream;
        private static Random randomClass = new Random();

        public static void load()
        {
            if (!MyProject.Computer.FileSystem.DirectoryExists(@"C:\DO_Hacks"))
            {
                mainFunctions.log("First time running, copying files over...");
                MyProject.Computer.FileSystem.CreateDirectory(@"C:\DO_Hacks");
                MyProject.Computer.FileSystem.CopyFile(AppDomain.CurrentDomain.BaseDirectory + @"resources\maps.txt", @"C:\DO_Hacks\maps.txt");
                MyProject.Computer.FileSystem.CopyFile(AppDomain.CurrentDomain.BaseDirectory + @"resources\test1.txt", @"C:\DO_Hacks\test1.txt");
                MyProject.Computer.FileSystem.CopyFile(AppDomain.CurrentDomain.BaseDirectory + @"resources\policy_response.txt", @"C:\DO_Hacks\policy_response.txt");
                MyProject.Computer.FileSystem.CopyFile(AppDomain.CurrentDomain.BaseDirectory + @"resources\hero_laserammo.dll", @"C:\DO_Hacks\hero_laserammo.dll");
                MyProject.Computer.FileSystem.CopyFile(AppDomain.CurrentDomain.BaseDirectory + @"resources\hero_rocketammo.dll", @"C:\DO_Hacks\hero_rocketammo.dll");
                MyProject.Computer.FileSystem.CopyFile(AppDomain.CurrentDomain.BaseDirectory + @"resources\hero.dll", @"C:\DO_Hacks\hero.dll");
                mainFunctions.log("Done setting up, now time for you set up hero...");
                Interaction.Shell(AppDomain.CurrentDomain.BaseDirectory + @"resources\setup_hero.exe", AppWinStyle.NormalFocus, false, -1);
            }
        }

        [STAThread]
        public static void Main()
        {
            Console.WriteLine("Welcome to the Dark Orbit Interceptor!");
            Console.WriteLine("");
            Console.WriteLine("The only program available to let you play Dark Orbit offline!");
            Console.WriteLine("");
            Console.WriteLine("Brought to you by: deHackerOwnz");
            Console.WriteLine("");
            Console.WriteLine("Awaiting commands...");
            if (Console.ReadLine() == "start")
            {
                load();
                Console.Clear();
                bool flag2 = initConnection.waitForClient();
                bool flag = initConnection.hackMapsPHP();
                bool flag3 = initConnection.hackSecurityPolicy();
                initConnection.listenToClient();
                while (true)
                {
                    switch (mainFunctions.getInput())
                    {
                        case "emp":
                            initConnection.sendPacket("0|S|EMP|" + Conversions.ToString(mainHero.getID()));
                            break;

                        case "send packet":
                        {
                            string packet = mainFunctions.getInput();
                            if (packet == "paste")
                            {
                                packet = MyProject.Computer.Clipboard.GetText();
                            }
                            initConnection.sendPacket(packet);
                            break;
                        }
                        case "start game":
                            mainGameLoop();
                            break;

                        case "rep":
                            initConnection.sendPacket("0|A|RS|0");
                            initConnection.sendPacket("0|A|HPT|222373|266000");
                            Thread.Sleep(0x1388);
                            initConnection.sendPacket("0|A|RS|0");
                            initConnection.sendPacket("0|A|HPT|262373|266000");
                            Thread.Sleep(0x1388);
                            initConnection.sendPacket("0|A|RS|0");
                            initConnection.sendPacket("0|A|HPT|282373|266000");
                            Thread.Sleep(0x1388);
                            initConnection.sendPacket("0|A|RS|0");
                            initConnection.sendPacket("0|A|HPT|302373|266000");
                            mainFunctions.log("Done...");
                            break;
                    }
                }
                Console.ReadLine();
            }
        }

        public static void mainGameLoop()
        {
            new Thread(new ThreadStart(NPC_Module.NPCThread)).Start();
            new Thread(new ThreadStart(initConnection.logoutHero)).Start();
            new Thread(new ThreadStart(Repair_Module.monitorHP)).Start();
            new Thread(new ThreadStart(Repair_Module.monitorSHD)).Start();
        }
    }
}

