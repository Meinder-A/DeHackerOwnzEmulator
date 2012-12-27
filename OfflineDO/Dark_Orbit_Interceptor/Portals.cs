namespace Dark_Orbit_Interceptor
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Runtime.CompilerServices;

    public class Portals
    {
        private ArrayList portalID;
        private ArrayList posX;
        private ArrayList posY;

        public Portals()
        {
            this.clearPortals();
        }

        private double _getDistance(double x1, double y1, double x2, double y2)
        {
            return (Math.Pow(x2 - x1, 2.0) + Math.Pow(y2 - y1, 2.0));
        }

        private double _getDistance(int x1, int y1, int x2, int y2)
        {
            return (Math.Pow((double) (x2 - x1), 2.0) + Math.Pow((double) (y2 - y2), 2.0));
        }

        public void addPortal(int id1, int posx1, int posy1)
        {
            this.portalID.Add(id1);
            this.posX.Add(posx1);
            this.posY.Add(posy1);
        }

        public void clearPortals()
        {
            this.portalID = new ArrayList();
            this.posX = new ArrayList();
            this.posY = new ArrayList();
        }

        public void getClosestPortal(ref Hero hero, ref int outx, ref int outy)
        {
            ArrayList list = new ArrayList();
            ArrayList list2 = new ArrayList();
            ArrayList list3 = new ArrayList();
            int num11 = this.portalID.Count - 1;
            for (int i = 0; i <= num11; i++)
            {
                int num2 = Conversions.ToInteger(Conversion.Fix(RuntimeHelpers.GetObjectValue(this.portalID[i])));
                if ((((num2 != 50) && (num2 != 70)) && ((num2 != 60) && (num2 != 0x1f))) && ((num2 != 0x21) && (num2 != 0x23)))
                {
                    list.Add(RuntimeHelpers.GetObjectValue(this.portalID[i]));
                    list2.Add(RuntimeHelpers.GetObjectValue(this.posX[i]));
                    list3.Add(RuntimeHelpers.GetObjectValue(this.posY[i]));
                }
            }
            if (list.Count == 1)
            {
                outx = Conversions.ToInteger(Conversion.Fix(RuntimeHelpers.GetObjectValue(list2[0])));
                outy = Conversions.ToInteger(Conversion.Fix(RuntimeHelpers.GetObjectValue(list3[0])));
            }
            else if (list.Count > 1)
            {
                int num4 = Conversions.ToInteger(Conversion.Fix(RuntimeHelpers.GetObjectValue(list2[0])));
                int num5 = Conversions.ToInteger(Conversion.Fix(RuntimeHelpers.GetObjectValue(list3[0])));
                double num3 = this._getDistance((int) Math.Round(Conversion.Fix(Math.Round(hero.getPosX()))), (int) Math.Round(Conversion.Fix(Math.Round(hero.getPosY()))), num4, num5);
                int num12 = list.Count - 1;
                for (int j = 1; j <= num12; j++)
                {
                    int num7 = Conversions.ToInteger(Conversion.Fix(RuntimeHelpers.GetObjectValue(list2[j])));
                    int num8 = Conversions.ToInteger(Conversion.Fix(RuntimeHelpers.GetObjectValue(list3[j])));
                    double num9 = this._getDistance((int) Math.Round(Conversion.Fix(Math.Round(hero.getPosX()))), (int) Math.Round(Conversion.Fix(Math.Round(hero.getPosY()))), num7, num8);
                    if (!(Math.Min(num3, num9) == num3))
                    {
                        num4 = num7;
                        num5 = num8;
                        num3 = num9;
                    }
                }
                outx = num4;
                outy = num5;
            }
            else
            {
                outx = -1;
                outy = -1;
            }
        }

        public int getCount()
        {
            return this.portalID.Count;
        }

        public int getID(int index)
        {
            if ((index + 1) > this.portalID.Count)
            {
                return -1;
            }
            return Conversions.ToInteger(Conversion.Fix(RuntimeHelpers.GetObjectValue(this.portalID[index])));
        }

        public int getPosX(int index)
        {
            if ((index + 1) > this.posX.Count)
            {
                return -1;
            }
            return Conversions.ToInteger(Conversion.Fix(RuntimeHelpers.GetObjectValue(this.posX[index])));
        }

        public int getPosXWithID(int id)
        {
            int num3 = this.portalID.Count - 1;
            for (int i = 0; i <= num3; i++)
            {
                if (Conversions.ToInteger(Conversion.Fix(RuntimeHelpers.GetObjectValue(this.portalID[i]))) == id)
                {
                    return Conversions.ToInteger(Conversion.Fix(RuntimeHelpers.GetObjectValue(this.posX[i])));
                }
            }
            return -1;
        }

        public int getPosY(int index)
        {
            if ((index + 1) > this.posY.Count)
            {
                return -1;
            }
            return Conversions.ToInteger(Conversion.Fix(RuntimeHelpers.GetObjectValue(this.posY[index])));
        }

        public int getPosYWithID(int id)
        {
            int num3 = this.portalID.Count - 1;
            for (int i = 0; i <= num3; i++)
            {
                if (Conversions.ToInteger(Conversion.Fix(RuntimeHelpers.GetObjectValue(this.portalID[i]))) == id)
                {
                    return Conversions.ToInteger(Conversion.Fix(RuntimeHelpers.GetObjectValue(this.posY[i])));
                }
            }
            return -1;
        }

        public void removePortal(int id1)
        {
            int num;
            int num2 = (int) -((num == (this.portalID.Count - 1)) > false);
            for (num = 0; num <= num2; num++)
            {
                if (this.portalID[num].Equals(id1))
                {
                    this.portalID.RemoveAt(num);
                    break;
                }
            }
        }
    }
}

