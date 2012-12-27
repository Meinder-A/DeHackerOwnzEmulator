namespace Dark_Orbit_Interceptor
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;

    [StandardModule]
    internal sealed class Portal_Module
    {
        private static ArrayList curPortals = new ArrayList();

        public static void addPortal(Portal portal)
        {
            curPortals.Add(portal);
        }

        public static Portal getCurPortal(double heroX, double heroY)
        {
            IEnumerator enumerator;
            try
            {
                enumerator = curPortals.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Portal current = (Portal) enumerator.Current;
                    if ((((heroX - current.getPosX()) < 1000.0) & ((heroX - current.getPosX()) > 0.0)) && (((heroY - current.getPosY()) < 1000.0) & ((heroY - current.getPosY()) > 0.0)))
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

        public static Vector getHeroPos(int portalID)
        {
            Vector vector2 = new Vector();
            if ((portalID == 1) | (portalID == 4))
            {
                vector2.x = 2000.0;
                vector2.y = 2000.0;
                return vector2;
            }
            if ((((portalID == 2) | (portalID == 6)) | (portalID == 8)) | (portalID == 9))
            {
                vector2.x = 18500.0;
                vector2.y = 11500.0;
                return vector2;
            }
            if (portalID == 3)
            {
                vector2.x = 2000.0;
                vector2.y = 11500.0;
                return vector2;
            }
            if ((portalID == 5) | (portalID == 7))
            {
                vector2.x = 18500.0;
                vector2.y = 2000.0;
            }
            return vector2;
        }

        public static int getNewMap(int portalID)
        {
            if (portalID == 1)
            {
                return 2;
            }
            if (portalID != 2)
            {
                if (portalID == 3)
                {
                    return 3;
                }
                if (portalID == 4)
                {
                    return 4;
                }
                if (portalID == 5)
                {
                    return 2;
                }
                if (portalID == 6)
                {
                    return 1;
                }
                if (portalID == 7)
                {
                    return 4;
                }
                if (portalID == 8)
                {
                    return 2;
                }
                if (portalID == 9)
                {
                    return 3;
                }
            }
            return 1;
        }

        public static Portal getPortal(int index)
        {
            return (Portal) curPortals[index];
        }

        public static Portal getPortalByID(int id)
        {
            IEnumerator enumerator;
            try
            {
                enumerator = curPortals.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Portal current = (Portal) enumerator.Current;
                    if (current.getID() == id)
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

        public static ArrayList getPortalsByMap(int mapID)
        {
            ArrayList list2 = new ArrayList();
            if (mapID == 1)
            {
                Portal portal = new Portal(1, 18500.0, 11500.0);
                list2.Add(portal);
                return list2;
            }
            if (mapID == 2)
            {
                Portal portal2 = new Portal(2, 2000.0, 2000.0);
                list2.Add(portal2);
                Portal portal3 = new Portal(3, 18500.0, 2000.0);
                list2.Add(portal3);
                Portal portal4 = new Portal(5, 18500.0, 11500.0);
                list2.Add(portal4);
                return list2;
            }
            if (mapID == 3)
            {
                Portal portal5 = new Portal(4, 2000.0, 11500.0);
                list2.Add(portal5);
                Portal portal6 = new Portal(7, 18500.0, 2000.0);
                list2.Add(portal6);
                Portal portal7 = new Portal(0x1b, 18500.0, 11500.0);
                list2.Add(portal7);
                return list2;
            }
            if (mapID == 4)
            {
                Portal portal8 = new Portal(6, 2000.0, 2000.0);
                list2.Add(portal8);
                Portal portal9 = new Portal(0x1c, 18500.0, 2000.0);
                list2.Add(portal9);
                return list2;
            }
            return null;
        }

        public static void removeAllPortals()
        {
            curPortals = new ArrayList();
        }

        public static void setAllPortals(ArrayList portals)
        {
            IEnumerator enumerator;
            removeAllPortals();
            try
            {
                enumerator = portals.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Portal current = (Portal) enumerator.Current;
                    curPortals.Add(current);
                    initConnection.sendPacket("0|p|" + Conversions.ToString(current.getID()) + "|1|0|" + Conversions.ToString(current.getPosX()) + "|" + Conversions.ToString(current.getPosY()));
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

        public static void setAllPortalsByMap(int mapID)
        {
            ArrayList portals = new ArrayList();
            if (mapID == 1)
            {
                Portal portal = new Portal(1, 18500.0, 11500.0);
                portals.Add(portal);
            }
            else if (mapID == 2)
            {
                Portal portal2 = new Portal(2, 2000.0, 2000.0);
                portals.Add(portal2);
                Portal portal3 = new Portal(3, 18500.0, 2000.0);
                portals.Add(portal3);
                Portal portal4 = new Portal(4, 18500.0, 11500.0);
                portals.Add(portal4);
            }
            else if (mapID == 3)
            {
                Portal portal5 = new Portal(5, 2000.0, 11500.0);
                portals.Add(portal5);
                Portal portal6 = new Portal(6, 18500.0, 2000.0);
                portals.Add(portal6);
                Portal portal7 = new Portal(7, 18500.0, 11500.0);
                portals.Add(portal7);
            }
            else if (mapID == 4)
            {
                Portal portal8 = new Portal(8, 2000.0, 2000.0);
                portals.Add(portal8);
                Portal portal9 = new Portal(9, 18500.0, 2000.0);
                portals.Add(portal9);
            }
            setAllPortals(portals);
        }
    }
}

