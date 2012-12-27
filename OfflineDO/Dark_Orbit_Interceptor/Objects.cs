namespace Dark_Orbit_Interceptor
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Runtime.CompilerServices;

    public class Objects
    {
        private ArrayList bonusBoxes;
        private ArrayList cargoBoxes;
        private ArrayList resources;

        public Objects()
        {
            this.clearObjects();
        }

        private double _getDistance(int x1, int y1, int x2, int y2)
        {
            return (Math.Pow((double) (x2 - x1), 2.0) + Math.Pow((double) (y2 - y1), 2.0));
        }

        public void addBonusBox(string code, int posX, int posY)
        {
            this.bonusBoxes.Add(new BonusBox(code, posX, posY));
        }

        public void addCargoBox(string code, int posX, int posY)
        {
            this.cargoBoxes.Add(new CargoBox(code, posX, posY));
        }

        public void addResource(int type, string code, int posX, int posY)
        {
            this.resources.Add(new Resource(type, Conversions.ToInteger(code), posX, posY));
        }

        public void clearObjects()
        {
            this.bonusBoxes = new ArrayList();
            this.cargoBoxes = new ArrayList();
            this.resources = new ArrayList();
        }

        public int getBonusBoxCount()
        {
            return this.bonusBoxes.Count;
        }

        public BonusBox getBonxBos(int index)
        {
            if ((index + 1) > this.bonusBoxes.Count)
            {
                return null;
            }
            return (BonusBox) this.bonusBoxes[index];
        }

        public CargoBox getCargoBox(int index)
        {
            if ((index + 1) > this.cargoBoxes.Count)
            {
                return null;
            }
            return (CargoBox) this.cargoBoxes[index];
        }

        public int getCargoBoxCount()
        {
            return this.cargoBoxes.Count;
        }

        public BonusBox getClosestBonusBox(ref Hero hero, ref double outdist)
        {
            if (this.bonusBoxes.Count == 1)
            {
                outdist = this._getDistance((int) Math.Round(Conversion.Fix(Math.Round(hero.getPosX()))), (int) Math.Round(Conversion.Fix(Math.Round(hero.getPosY()))), ((BonusBox) this.bonusBoxes[0]).getPosX(), ((BonusBox) this.bonusBoxes[0]).getPosY());
                return (BonusBox) this.bonusBoxes[0];
            }
            if (this.bonusBoxes.Count > 1)
            {
                BonusBox box2 = (BonusBox) this.bonusBoxes[0];
                double num = this._getDistance((int) Math.Round(Conversion.Fix(Math.Round(hero.getPosX()))), (int) Math.Round(Conversion.Fix(Math.Round(hero.getPosY()))), box2.getPosX(), box2.getPosY());
                int num5 = this.bonusBoxes.Count - 1;
                for (int i = 1; i <= num5; i++)
                {
                    BonusBox box3 = (BonusBox) this.bonusBoxes[i];
                    double num3 = this._getDistance((int) Math.Round(Conversion.Fix(Math.Round(hero.getPosX()))), (int) Math.Round(Conversion.Fix(Math.Round(hero.getPosY()))), box3.getPosX(), box3.getPosY());
                    if (!(Math.Min(num, num3) == num))
                    {
                        box2 = box3;
                        num = num3;
                    }
                }
                outdist = num;
                return box2;
            }
            outdist = double.MaxValue;
            return null;
        }

        public CargoBox getClosestCargoBox(ref Hero hero, ref double outdist)
        {
            if (this.cargoBoxes.Count == 1)
            {
                outdist = this._getDistance((int) Math.Round(Conversion.Fix(Math.Round(hero.getPosX()))), (int) Math.Round(Conversion.Fix(Math.Round(hero.getPosY()))), ((CargoBox) this.cargoBoxes[0]).getPosX(), ((CargoBox) this.cargoBoxes[0]).getPosY());
                return (CargoBox) this.cargoBoxes[0];
            }
            if (this.cargoBoxes.Count > 1)
            {
                CargoBox box2 = (CargoBox) this.cargoBoxes[0];
                double num = this._getDistance((int) Math.Round(Conversion.Fix(Math.Round(hero.getPosX()))), (int) Math.Round(Conversion.Fix(Math.Round(hero.getPosY()))), box2.getPosX(), box2.getPosY());
                int num5 = this.cargoBoxes.Count - 1;
                for (int i = 1; i <= num5; i++)
                {
                    CargoBox box3 = (CargoBox) this.cargoBoxes[i];
                    double num3 = this._getDistance((int) Math.Round(Conversion.Fix(Math.Round(hero.getPosX()))), (int) Math.Round(Conversion.Fix(Math.Round(hero.getPosY()))), box3.getPosX(), box3.getPosY());
                    if (!(Math.Min(num, num3) == num))
                    {
                        box2 = box3;
                        num = num3;
                    }
                }
                outdist = num;
                return box2;
            }
            outdist = double.MaxValue;
            return null;
        }

        public Resource getClosestResource(ref Hero hero, ref double outdist, int type)
        {
            ArrayList list = this.getResources(type);
            if (list == null)
            {
                outdist = double.MaxValue;
                return null;
            }
            if (list.Count == 1)
            {
                outdist = this._getDistance((int) Math.Round(Conversion.Fix(Math.Round(hero.getPosX()))), (int) Math.Round(Conversion.Fix(Math.Round(hero.getPosY()))), ((Resource) list[0]).getPosX(), ((Resource) list[0]).getPosY());
                return (Resource) list[0];
            }
            if (list.Count > 1)
            {
                Resource resource2 = (Resource) list[0];
                double num = this._getDistance((int) Math.Round(Conversion.Fix(Math.Round(hero.getPosX()))), (int) Math.Round(Conversion.Fix(Math.Round(hero.getPosY()))), resource2.getPosX(), resource2.getPosY());
                int num5 = list.Count - 1;
                for (int i = 1; i <= num5; i++)
                {
                    Resource resource3 = (Resource) list[i];
                    double num3 = this._getDistance((int) Math.Round(Conversion.Fix(Math.Round(hero.getPosX()))), (int) Math.Round(Conversion.Fix(Math.Round(hero.getPosY()))), resource3.getPosX(), resource3.getPosY());
                    if (!(Math.Min(num, num3) == num))
                    {
                        resource2 = resource3;
                        num = num3;
                    }
                }
                outdist = num;
                return resource2;
            }
            outdist = double.MaxValue;
            return null;
        }

        public Resource getResource(int index)
        {
            if ((index + 1) > this.resources.Count)
            {
                return null;
            }
            return (Resource) this.resources[index];
        }

        public int getResourceCount()
        {
            return this.resources.Count;
        }

        public ArrayList getResources(int type)
        {
            ArrayList list2 = new ArrayList();
            int num2 = this.resources.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (((Resource) this.resources[i]).getResourceType() == type)
                {
                    list2.Add(RuntimeHelpers.GetObjectValue(this.resources[i]));
                }
            }
            if (list2.Count == 0)
            {
                return null;
            }
            return list2;
        }

        public void removeBonusBox(string code)
        {
            int num2 = this.bonusBoxes.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                BonusBox box = new BonusBox();
                box = (BonusBox) this.bonusBoxes[i];
                if (box.getCode() == code)
                {
                    this.bonusBoxes.RemoveAt(i);
                    break;
                }
            }
        }

        public void removeCargoBox(string code)
        {
            int num2 = this.cargoBoxes.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (code.Equals(((CargoBox) this.cargoBoxes[i]).getCode()))
                {
                    this.cargoBoxes.RemoveAt(i);
                    break;
                }
            }
        }

        public void removeResourceBox(string code)
        {
            int num2 = this.resources.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (code.Equals(((Resource) this.resources[i]).getCode()))
                {
                    this.resources.RemoveAt(i);
                    break;
                }
            }
        }
    }
}

