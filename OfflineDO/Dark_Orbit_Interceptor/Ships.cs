namespace Dark_Orbit_Interceptor
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class Ships
    {
        private ArrayList ships;

        public Ships()
        {
            this.clearShips();
        }

        private double _getDistance(double x1, double y1, double x2, double y2)
        {
            return (Math.Pow(x2 - x1, 2.0) + Math.Pow(y2 - y1, 2.0));
        }

        public void addShip(int id, int shipid, string clan, string username, double posX, double posY, int company, int clanid, int clandiplomacy, int galaxygatesdone, bool isNPC, bool cloaked)
        {
            Ship ship = new Ship(id, shipid, clan, username, posX, posY, company, clanid, clandiplomacy, galaxygatesdone, isNPC, cloaked);
            this.ships.Add(ship);
        }

        public void clearShips()
        {
            this.ships = new ArrayList();
        }

        public Ship getClosestNPC(ref Hero hero, ref SpaceStation ss, ref Portals portals, ArrayList NPCsToExclude, bool[] clb, string[] NPCsNames, double maxdistance)
        {
            ArrayList list = new ArrayList();
            int num8 = clb.Count<bool>() - 1;
            for (int i = 0; i <= num8; i++)
            {
                if (clb[i])
                {
                    list.Add(NPCsNames[i]);
                }
            }
            if (list.Count > 0)
            {
                ArrayList list2 = new ArrayList();
                int num9 = list.Count - 1;
                for (int j = 0; j <= num9; j++)
                {
                    int num10 = this.ships.Count - 1;
                    for (int k = 0; k <= num10; k++)
                    {
                        Ship ship2 = (Ship) this.ships[k];
                        if (((ship2.getIsNPC() && !ship2.getTaken()) && ship2.getUsername().Equals(Conversions.ToString(list[j]))) && !this.isExcludedID(ship2.getID(), NPCsToExclude))
                        {
                            list2.Add(ship2);
                        }
                    }
                }
                if (list2.Count > 0)
                {
                    Ship ship3;
                    if (list2.Count == 1)
                    {
                        ship3 = (Ship) list2[0];
                    }
                    else
                    {
                        ship3 = (Ship) list2[0];
                        double num4 = this._getDistance(hero.getPosX(), hero.getPosY(), ship3.getPosX(), ship3.getPosY());
                        int num11 = list2.Count - 1;
                        for (int m = 0; m <= num11; m++)
                        {
                            Ship ship4 = (Ship) list2[m];
                            double num6 = this._getDistance(hero.getPosX(), hero.getPosY(), ship4.getPosX(), ship4.getPosY());
                            if (!(Math.Min(num4, num6) == num4))
                            {
                                ship3 = ship4;
                                num4 = num6;
                            }
                        }
                    }
                    if ((!this.isExcludedID(ship3.getID(), NPCsToExclude) && (Math.Sqrt(this._getDistance(hero.getPosX(), hero.getPosY(), ship3.getPosX(), ship3.getPosY())) < maxdistance)) && (Conversions.ToBoolean(Operators.NotObject(this.isCloseToSpaceStation(ship3, ss))) && !this.isCloseToPortal(ship3, portals)))
                    {
                        return ship3;
                    }
                }
            }
            return null;
        }

        public int getCount()
        {
            return this.ships.Count;
        }

        public Ship getShip(int index)
        {
            if ((index + 1) > this.ships.Count)
            {
                return null;
            }
            return (Ship) this.ships[index];
        }

        public Ship getShipWithID(int id)
        {
            int num2 = this.ships.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (id == ((Ship) this.ships[i]).getID())
                {
                    return (Ship) this.ships[i];
                }
            }
            return null;
        }

        public bool isCloseToPortal(Ship s, Portals p)
        {
            int num2;
            int num = p.getCount();
            int num3 = (int) -((num2 == (num - 1)) > false);
            for (num2 = 0; num2 <= num3; num2++)
            {
                if ((p.getID(num2) != -1) && (Math.Sqrt(this._getDistance(s.getPosX(), s.getPosY(), (double) p.getPosX(num2), (double) p.getPosY(num2))) < 1000.0))
                {
                    return true;
                }
            }
            return false;
        }

        public object isCloseToSpaceStation(Ship s, SpaceStation ss)
        {
            return ((ss.getID() != -1) && (Math.Sqrt(this._getDistance(s.getPosX(), s.getPosY(), (double) ss.getPosX(), (double) ss.getPosY())) < 1500.0));
        }

        public bool isExcludedID(int id, ArrayList NPCsToExclude)
        {
            int num2 = NPCsToExclude.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (id == Conversions.ToInteger(Conversion.Fix(RuntimeHelpers.GetObjectValue(NPCsToExclude[i]))))
                {
                    return true;
                }
            }
            return false;
        }

        public void removeShipWithID(int id)
        {
            int num2 = this.ships.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (id == ((Ship) this.ships[i]).getID())
                {
                    this.ships.RemoveAt(i);
                    break;
                }
            }
        }
    }
}

