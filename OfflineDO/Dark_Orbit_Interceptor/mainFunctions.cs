namespace Dark_Orbit_Interceptor
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;

    [StandardModule]
    internal sealed class mainFunctions
    {
        private static ArrayList mainShips = new ArrayList();
        public static ArrayList npcShips = new ArrayList();

        public static void addNPC(NPCShip npc1)
        {
            npcShips.Add(npc1);
        }

        public static void addShip(DOShip ship1)
        {
            mainShips.Add(ship1);
        }

        public static void clearConsole()
        {
            Console.Clear();
        }

        public static string getInput()
        {
            return Console.ReadLine();
        }

        public static NPCShip getNPC(int index)
        {
            return (NPCShip) npcShips[index];
        }

        public static NPCShip getNPCByID(int userID)
        {
            IEnumerator enumerator;
            try
            {
                enumerator = npcShips.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    NPCShip current = (NPCShip) enumerator.Current;
                    if (current.getUserID() == userID)
                    {
                        return current;
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
            return null;
        }

        public static int getNPCCount()
        {
            return npcShips.Count;
        }

        public static DOShip getShip(int index)
        {
            return (DOShip) mainShips[index];
        }

        public static DOShip getShipByID(int userID)
        {
            IEnumerator enumerator;
            try
            {
                enumerator = mainShips.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DOShip current = (DOShip) enumerator.Current;
                    if (current.getUserID() == userID)
                    {
                        return current;
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
            return null;
        }

        public static int getShipCount()
        {
            return mainShips.Count;
        }

        public static void log(string message)
        {
            Console.WriteLine(message);
        }

        public static void removeAllNPCs()
        {
            npcShips = new ArrayList();
        }

        public static void removeNPC(int index)
        {
            npcShips.RemoveAt(index);
        }

        public static void removeNPCByID(int userID)
        {
            IEnumerator enumerator;
            int index = -1;
            try
            {
                enumerator = npcShips.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    NPCShip current = (NPCShip) enumerator.Current;
                    index++;
                    if (current.getUserID() == userID)
                    {
                        npcShips.RemoveAt(index);
                        return;
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

        public static void removeShip(int index)
        {
            mainShips.RemoveAt(index);
        }

        public static void removeShipByID(int userID)
        {
            IEnumerator enumerator;
            int index = -1;
            try
            {
                enumerator = mainShips.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DOShip current = (DOShip) enumerator.Current;
                    index++;
                    if (current.getUserID() == userID)
                    {
                        mainShips.RemoveAt(index);
                        return;
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
}

