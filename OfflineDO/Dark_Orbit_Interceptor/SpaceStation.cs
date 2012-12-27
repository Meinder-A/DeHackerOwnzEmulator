namespace Dark_Orbit_Interceptor
{
    using System;

    public class SpaceStation
    {
        private bool draw;
        private int id;
        private int posX;
        private int posY;
        private string station_name;

        public SpaceStation()
        {
            this.clearSpaceStation();
        }

        public void clearSpaceStation()
        {
            this.id = -1;
            this.posX = -1;
            this.posY = -1;
            this.draw = false;
            this.station_name = "";
        }

        public bool doDraw()
        {
            return this.draw;
        }

        public int getID()
        {
            return this.id;
        }

        public int getPosX()
        {
            return this.posX;
        }

        public int getPosY()
        {
            return this.posY;
        }

        public string getStationName()
        {
            return this.station_name;
        }

        public void setSpaceStation(int id1, int posx1, int posy1, string station_name1, bool dodraw)
        {
            this.id = id1;
            this.posX = posx1;
            this.posY = posy1;
            this.draw = dodraw;
            this.station_name = station_name1;
        }
    }
}

