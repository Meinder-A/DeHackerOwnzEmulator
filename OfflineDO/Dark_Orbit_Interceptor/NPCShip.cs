namespace Dark_Orbit_Interceptor
{
    using System;

    public class NPCShip
    {
        private bool attacked;
        private int HP;
        private int maxDMG;
        private int MaxHP;
        private int MaxSHD;
        private int minDMG;
        private int moveTime;
        private bool moving;
        private double posX;
        private double posY;
        private int SHD;
        private int shipType;
        private int speed;
        private DateTime time;
        private int userID;
        private string username;

        public NPCShip(int userID1, int shipType1, int HP1, int SHD1, int maxHP1, int maxSHD1, string username1, double posX1, double posY1, int minDMG1, int maxDMG1, int speed1)
        {
            this.clearNPCShip();
            this.userID = userID1;
            this.shipType = shipType1;
            this.HP = HP1;
            this.MaxHP = maxHP1;
            this.SHD = SHD1;
            this.MaxSHD = maxSHD1;
            this.username = username1;
            this.posX = posX1;
            this.posY = posY1;
            this.maxDMG = maxDMG1;
            this.minDMG = minDMG1;
            this.speed = speed1;
            this.moving = false;
        }

        public void clearNPCShip()
        {
            this.userID = -1;
            this.shipType = -1;
            this.HP = 0;
            this.SHD = 0;
            this.MaxHP = 0;
            this.MaxSHD = 0;
            this.username = "";
            this.posX = -1.0;
            this.posY = -1.0;
            this.minDMG = -1;
            this.maxDMG = -1;
            this.moving = false;
            this.moveTime = 0;
            this.speed = 0;
            this.attacked = false;
            this.time = DateTime.Now;
        }

        public bool getAttacked()
        {
            return this.attacked;
        }

        public int getHP()
        {
            return this.HP;
        }

        public int getMaxDMG()
        {
            return this.maxDMG;
        }

        public int getMaxHP()
        {
            return this.MaxHP;
        }

        public int getMaxSHD()
        {
            return this.MaxSHD;
        }

        public int getMinDMG()
        {
            return this.minDMG;
        }

        public int getMoveTime()
        {
            return this.moveTime;
        }

        public bool getMoving()
        {
            return this.moving;
        }

        public double getPosX()
        {
            return this.posX;
        }

        public double getPosY()
        {
            return this.posY;
        }

        public int getSHD()
        {
            return this.SHD;
        }

        public int getShipType()
        {
            return this.shipType;
        }

        public int getSpeed()
        {
            return this.speed;
        }

        public DateTime getTime()
        {
            return this.time;
        }

        public int getUserID()
        {
            return this.userID;
        }

        public string getUsername()
        {
            return this.username;
        }

        public void setAttacked(bool attacked1)
        {
            this.attacked = attacked1;
        }

        public void setHP(int HP1)
        {
            this.HP = HP1;
        }

        public void setMaxHP(int MaxHP1)
        {
            this.MaxHP = MaxHP1;
        }

        public void setMaxSHD(int MaxSHD1)
        {
            this.MaxSHD = MaxSHD1;
        }

        public void setMoveTime(int moveTime1)
        {
            this.moveTime = moveTime1;
        }

        public void setMoving(bool moving1)
        {
            this.moving = moving1;
        }

        public void setPosX(double PosX1)
        {
            this.posX = PosX1;
        }

        public void setPosY(double posY1)
        {
            this.posY = posY1;
        }

        public void setSHD(int SHD1)
        {
            this.SHD = SHD1;
        }

        public void setSpeed(int speed1)
        {
            this.speed = speed1;
        }

        public void setTime(DateTime time1)
        {
            this.time = time1;
        }
    }
}

