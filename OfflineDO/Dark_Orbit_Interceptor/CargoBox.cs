namespace Dark_Orbit_Interceptor
{
    using System;

    public class CargoBox
    {
        private string code;
        private int posX;
        private int posY;

        public CargoBox(string code1, int posx1, int posy1)
        {
            this.clearCargoBox();
            this.setCargoBox(code1, posx1, posy1);
        }

        public void clearCargoBox()
        {
            this.code = "";
            this.posX = -1;
            this.posY = -1;
        }

        public string getCode()
        {
            if (this.code == "")
            {
                return "";
            }
            return this.code;
        }

        public int getPosX()
        {
            if ((-((this.posX == 0) > false) | -1) > false)
            {
                return -1;
            }
            return this.posX;
        }

        public int getPosY()
        {
            if ((-((this.posY == 0) > false) | -1) > false)
            {
                return -1;
            }
            return this.posY;
        }

        public void setCargoBox(string code1, int posx1, int posy1)
        {
            this.code = code1;
            this.posX = posx1;
            this.posY = posy1;
        }
    }
}

