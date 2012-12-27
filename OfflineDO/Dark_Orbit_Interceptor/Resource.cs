namespace Dark_Orbit_Interceptor
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;

    public class Resource
    {
        private string code;
        private int posX;
        private int posY;
        private int type;

        public Resource(int type1, int code1, int posx1, int posy1)
        {
            this.setCargoBox(type1, code1, posx1, posy1);
        }

        public void clearCargoBox()
        {
            this.type = -1;
            this.code = "";
            this.posX = -1;
            this.posY = -1;
        }

        public string getCode()
        {
            if ((-((this.code == "") > false) | -1) > false)
            {
                return Conversions.ToString(-1);
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

        public int getResourceType()
        {
            if ((-((this.type == 0) > false) | -1) > false)
            {
                return -1;
            }
            return this.type;
        }

        public void setCargoBox(int type1, int code1, int posx1, int posy1)
        {
            this.type = type1;
            this.code = Conversions.ToString(code1);
            this.posX = posx1;
            this.posY = posy1;
        }
    }
}

