namespace Dark_Orbit_Interceptor
{
    using System;

    public class DOShip
    {
        private int ammoType;
        private int BO2s;
        private int clanDiplomacy;
        private int clanID = 0;
        private string clanTag;
        private int cloaked;
        private int company;
        private int flaxDrones;
        private int GGDone;
        private int HP;
        private int irisDrones;
        private int isNPC;
        private int LF3s;
        private int MaxHP;
        private int MaxSHD;
        private double posX;
        private double posY;
        private int rank;
        private int SHD;
        private int shipType;
        private int userID;
        private string username;

        public DOShip(int userID1, int shipType1, int HP1, int SHD1, int maxHP1, int maxSHD1, string clanTag1, string username1, double posX1, double posY1, int company1, int clanID1, int clanDiplomacy1, int GGDone1, int isNPC1, int cloaked1, int rank1, int LF3s1, int BO2s1, int irisDrones1, int flaxDrones1, int ammoType1)
        {
            this.clearDOShip();
            this.userID = userID1;
            this.shipType = shipType1;
            this.HP = HP1;
            this.MaxHP = maxHP1;
            this.SHD = SHD1;
            this.MaxSHD = maxSHD1;
            this.clanTag = clanTag1;
            this.username = username1;
            this.posX = posX1;
            this.posY = posY1;
            this.company = company1;
            this.clanID = clanID1;
            this.clanDiplomacy = clanDiplomacy1;
            this.GGDone = GGDone1;
            this.isNPC = isNPC1;
            this.cloaked = cloaked1;
            this.rank = rank1;
            this.LF3s = LF3s1;
            this.BO2s = BO2s1;
            this.irisDrones = irisDrones1;
            this.flaxDrones = flaxDrones1;
            this.ammoType = ammoType1;
        }

        public void clearDOShip()
        {
            this.userID = -1;
            this.shipType = -1;
            this.HP = 0;
            this.SHD = 0;
            this.MaxHP = 0;
            this.MaxSHD = 0;
            this.clanTag = "";
            this.username = "";
            this.posX = -1.0;
            this.posY = -1.0;
            this.company = -1;
            this.clanID = 0;
            this.clanDiplomacy = -1;
            this.GGDone = -1;
            this.isNPC = 0;
            this.cloaked = 0;
            this.rank = 0;
            this.LF3s = -1;
            this.BO2s = -1;
            this.irisDrones = 0;
            this.flaxDrones = 0;
        }

        public int getAmmoType()
        {
            return this.ammoType;
        }

        public int getBO2s()
        {
            return this.BO2s;
        }

        public int getClanDiplomacy()
        {
            return this.clanDiplomacy;
        }

        public int getClanID()
        {
            return this.clanID;
        }

        public string getClanTag()
        {
            return this.clanTag;
        }

        public int getCloaked()
        {
            return this.cloaked;
        }

        public int getCompany()
        {
            return this.company;
        }

        public int getFlaxDrones()
        {
            return this.flaxDrones;
        }

        public int getGGDone()
        {
            return this.GGDone;
        }

        public int getHP()
        {
            return this.HP;
        }

        public int getIrisDrones()
        {
            return this.irisDrones;
        }

        public int getIsNPC()
        {
            return this.isNPC;
        }

        public int getLF3s()
        {
            return this.LF3s;
        }

        public int getMaxHP()
        {
            return this.MaxHP;
        }

        public int getMaxSHD()
        {
            return this.MaxSHD;
        }

        public double getPosX()
        {
            return this.posX;
        }

        public double getPosY()
        {
            return this.posY;
        }

        public int getRank()
        {
            return this.rank;
        }

        public int getSHD()
        {
            return this.SHD;
        }

        public int getShipType()
        {
            return this.shipType;
        }

        public int getUserID()
        {
            return this.userID;
        }

        public string getUsername()
        {
            return this.username;
        }

        public void setAmmoType(int ammoType1)
        {
            this.ammoType = ammoType1;
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
    }
}

