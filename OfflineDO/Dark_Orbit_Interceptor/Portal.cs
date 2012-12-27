namespace Dark_Orbit_Interceptor
{
    using System;

    public class Portal
    {
        private int id;
        private double posX;
        private double posY;

        public Portal(int id1, double posX1, double posY1)
        {
            this.id = id1;
            this.posX = posX1;
            this.posY = posY1;
        }

        public int getID()
        {
            return this.id;
        }

        public double getPosX()
        {
            return this.posX;
        }

        public double getPosY()
        {
            return this.posY;
        }
    }
}

