namespace Dark_Orbit_Interceptor
{
    using System;

    public class BonusBox
    {
        private string code;
        private int posX;
        private int posY;

        public BonusBox()
        {
            this.Clear();
        }

        public BonusBox(string code1, int posx1, int posy1)
        {
            this.setBonusBox(code1, posx1, posy1);
        }

        public void Clear()
        {
            if (this != null)
            {
                this.code = "";
                this.posX = -1;
                this.posY = -1;
            }
        }

        public string getCode()
        {
            if (this == null)
            {
                return "";
            }
            return this.code;
        }

        public int getPosX()
        {
            if (this == null)
            {
                return -1;
            }
            return this.posX;
        }

        public int getPosY()
        {
            if (this == null)
            {
                return -1;
            }
            return this.posY;
        }

        public void setBonusBox(string code1, int posx1, int posy1)
        {
            this.code = code1;
            this.posX = posx1;
            this.posY = posy1;
        }
    }
}

