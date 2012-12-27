namespace Dark_Orbit_Interceptor
{
    using System;

    public class Hero
    {
        private int admin;
        private int ammoType;
        private int BO2s;
        private int cargo;
        private string clan;
        private int clanid;
        private bool cloaked;
        private int company;
        private int config;
        private bool config2ShieldFull;
        private int CPU_Aim;
        private int CPU_Ammo_Buy;
        private int CPU_Arol;
        private int CPU_Cloak;
        private int CPU_Drone_Repair;
        private int CPU_HM7;
        private int CPU_Insta_Shield;
        private int CPU_Jump;
        private int CPU_Radar;
        private int CPU_Rllb;
        private int CPU_Robot;
        private int CPU_Rocket_Buy;
        private int CPU_Smart_Bomb;
        private int CPU_Turbo_Mine;
        private int credits;
        private int curTime;
        private Vector delta = new Vector();
        private Vector destination = new Vector();
        private int duranium;
        private int ECO10;
        private int EMP;
        private int endurium;
        private int expansionID;
        private int experience;
        private int galaxygatesdone;
        private int honor;
        private int hp;
        private int HSTRM01;
        private int id;
        private int Instashield;
        private double jackpot;
        private bool laserAttacking;
        private int LCB10;
        private int level;
        private int LF3s;
        private int mapID;
        private int maxcargo;
        private int maxhp;
        private int maxlaserammo;
        private int maxrocketammo;
        private int maxshield;
        private int MCB25;
        private int MCB50;
        private int Mine;
        private Vector moveStep = new Vector();
        private bool moving;
        private Vector normal = new Vector();
        private int PLD8;
        private int PLT2021;
        private int PLT2026;
        private int PLT3030;
        private double posX;
        private double posY;
        private bool premium;
        private int promerium;
        private int prometid;
        private int prometium;
        private int R310;
        private int rocketType;
        private int RSB75;
        private int SAB;
        private int selected_ship_id;
        private int seprom;
        private int shield;
        private int shipid;
        private int Smartbomb;
        private double speed;
        private bool target_in_range;
        private int terbium;
        private double timeTaken;
        private int UBR100;
        private int UCB100;
        private int uridium;
        private string username;
        private double velocity;
        private int xenomit;

        public Hero()
        {
            this.clearHero();
        }

        public void clearHero()
        {
            this.id = -1;
            this.username = "";
            this.shipid = -1;
            this.speed = -1.0;
            this.shield = -1;
            this.maxshield = -1;
            this.hp = -1;
            this.maxhp = -1;
            this.cargo = -1;
            this.maxcargo = -1;
            this.posX = -1.0;
            this.posY = -1.0;
            this.company = -1;
            this.clanid = -1;
            this.maxlaserammo = -1;
            this.maxrocketammo = -1;
            this.premium = false;
            this.experience = -1;
            this.honor = -1;
            this.level = -1;
            this.credits = -1;
            this.uridium = -1;
            this.jackpot = -1.0;
            this.admin = -1;
            this.clan = "";
            this.galaxygatesdone = -1;
            this.cloaked = false;
            this.prometium = -1;
            this.endurium = -1;
            this.terbium = -1;
            this.prometid = -1;
            this.duranium = -1;
            this.promerium = -1;
            this.seprom = -1;
            this.xenomit = -1;
            this.LCB10 = -1;
            this.MCB25 = -1;
            this.MCB50 = -1;
            this.UCB100 = -1;
            this.SAB = -1;
            this.RSB75 = -1;
            this.R310 = -1;
            this.PLT2026 = -1;
            this.PLT2021 = -1;
            this.PLT3030 = -1;
            this.PLD8 = -1;
            this.Smartbomb = -1;
            this.Instashield = -1;
            this.EMP = -1;
            this.HSTRM01 = -1;
            this.UBR100 = -1;
            this.ECO10 = -1;
            this.CPU_Drone_Repair = -1;
            this.CPU_Radar = -1;
            this.CPU_Jump = -1;
            this.CPU_Ammo_Buy = -1;
            this.CPU_Robot = -1;
            this.CPU_HM7 = -1;
            this.CPU_Smart_Bomb = -1;
            this.CPU_Insta_Shield = -1;
            this.CPU_Turbo_Mine = -1;
            this.CPU_Aim = -1;
            this.CPU_Arol = -1;
            this.CPU_Cloak = -1;
            this.CPU_Rllb = -1;
            this.CPU_Rocket_Buy = -1;
            this.laserAttacking = false;
            this.selected_ship_id = -1;
            this.target_in_range = false;
            this.moving = false;
            this.timeTaken = -1.0;
            this.curTime = -1;
            this.velocity = -1.0;
            this.delta.x = -1.0;
            this.delta.y = -1.0;
            this.destination.x = -1.0;
            this.destination.y = -1.0;
            this.normal.x = -1.0;
            this.normal.y = -1.0;
            this.moveStep.x = -1.0;
            this.moveStep.y = -1.0;
            this.config = -1;
            this.config2ShieldFull = false;
        }

        public int getAdmin()
        {
            return this.admin;
        }

        public int getAmmoType()
        {
            return this.ammoType;
        }

        public int getBO2s()
        {
            return this.BO2s;
        }

        public int getCargo()
        {
            return this.cargo;
        }

        public string getClan()
        {
            return this.clan;
        }

        public int getClanID()
        {
            return this.clanid;
        }

        public bool getCloaked()
        {
            return this.cloaked;
        }

        public int getCompany()
        {
            return this.company;
        }

        public bool getConfig2ShieldFull()
        {
            return this.config2ShieldFull;
        }

        public object getCPU(int n)
        {
            switch (n)
            {
                case 1:
                    return this.CPU_Drone_Repair;

                case 2:
                    return this.CPU_Radar;

                case 3:
                    return this.CPU_Jump;

                case 4:
                    return this.CPU_Ammo_Buy;

                case 5:
                    return this.CPU_Robot;

                case 6:
                    return this.CPU_HM7;

                case 7:
                    return 0;

                case 8:
                    return this.CPU_Smart_Bomb;

                case 9:
                    return this.CPU_Insta_Shield;

                case 10:
                    return this.CPU_Turbo_Mine;

                case 11:
                    return this.CPU_Aim;

                case 12:
                    return this.CPU_Arol;

                case 13:
                    return this.CPU_Cloak;

                case 14:
                    return this.CPU_Rllb;

                case 15:
                    return this.CPU_Rocket_Buy;
            }
            return -1;
        }

        public int getCredits()
        {
            return this.credits;
        }

        public int getCurrentConfig()
        {
            return this.config;
        }

        public int getDesX()
        {
            return (int) Math.Round(this.destination.x);
        }

        public int getDesY()
        {
            return (int) Math.Round(this.destination.y);
        }

        public int getDuranium()
        {
            return this.duranium;
        }

        public int getEndurium()
        {
            return this.endurium;
        }

        public int getExpansionID()
        {
            return this.expansionID;
        }

        public int getExperience()
        {
            return this.experience;
        }

        public int getGalaxyGatesDone()
        {
            return this.galaxygatesdone;
        }

        public int getHonor()
        {
            return this.honor;
        }

        public int getHP()
        {
            return this.hp;
        }

        public int getID()
        {
            return this.id;
        }

        public double getJackpot()
        {
            return this.jackpot;
        }

        public int getLaserAmmo1()
        {
            return this.LCB10;
        }

        public int getLaserAmmo2()
        {
            return this.MCB25;
        }

        public int getLaserAmmo3()
        {
            return this.MCB50;
        }

        public int getLaserAmmo4()
        {
            return this.UCB100;
        }

        public int getLaserAmmo5()
        {
            return this.SAB;
        }

        public int getLaserAmmo6()
        {
            return this.RSB75;
        }

        public bool getLaserAttacking()
        {
            return this.laserAttacking;
        }

        public int getLevel()
        {
            return this.level;
        }

        public int getLF3s()
        {
            return this.LF3s;
        }

        public int getMapID()
        {
            return this.mapID;
        }

        public int getMaxCargo()
        {
            return this.maxcargo;
        }

        public int getMaxHP()
        {
            return this.maxhp;
        }

        public int getMaxLaserAmmo()
        {
            return this.maxlaserammo;
        }

        public int getMaxRocketAmmo()
        {
            return this.maxrocketammo;
        }

        public int getMaxShield()
        {
            return this.maxshield;
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

        public bool getPremium()
        {
            return this.premium;
        }

        public int getPromerium()
        {
            return this.promerium;
        }

        public int getPrometid()
        {
            return this.prometid;
        }

        public int getPrometium()
        {
            return this.prometium;
        }

        public int getRocketAmmo1()
        {
            return this.R310;
        }

        public int getRocketAmmo2()
        {
            return this.PLT2026;
        }

        public int getRocketAmmo3()
        {
            return this.PLT2021;
        }

        public int getRocketAmmo4()
        {
            return this.PLT3030;
        }

        public int getRocketAmmo5()
        {
            return this.PLD8;
        }

        public int getRocketAmmo6()
        {
            return this.Mine;
        }

        public int getRocketAmmo7()
        {
            return this.Smartbomb;
        }

        public int getRocketAmmo8()
        {
            return this.Instashield;
        }

        public int getRocketAmmo9()
        {
            return this.EMP;
        }

        public int getRocketLaucnherAmmo1()
        {
            return this.HSTRM01;
        }

        public int getRocketLauncherAmmo2()
        {
            return this.UBR100;
        }

        public int getRocketLauncherAmmo3()
        {
            return this.ECO10;
        }

        public int getRocketType()
        {
            return this.rocketType;
        }

        public int getSelectedShipID()
        {
            return this.selected_ship_id;
        }

        public int getSeprom()
        {
            return this.seprom;
        }

        public int getShield()
        {
            return this.shield;
        }

        public int getShipID()
        {
            return this.shipid;
        }

        public double getSpeed()
        {
            return this.speed;
        }

        public bool getTargetInRange()
        {
            return this.target_in_range;
        }

        public int getTerbium()
        {
            return this.terbium;
        }

        public int getTotalLaserAmmo()
        {
            return (((((this.LCB10 + this.MCB25) + this.MCB50) + this.UCB100) + this.SAB) + this.RSB75);
        }

        public int getTotalRocketAmmo()
        {
            return (((((this.R310 + this.PLT2021) + this.PLT2026) + this.PLT3030) + this.ECO10) + this.Mine);
        }

        public int getUridium()
        {
            return this.uridium;
        }

        public string getUsername()
        {
            return this.username;
        }

        public int getXenomit()
        {
            return this.xenomit;
        }

        public bool isCargoEmpty()
        {
            return (this.cargo == this.maxcargo);
        }

        public bool isCargoFull()
        {
            return (this.cargo <= 0);
        }

        public bool isFullHealth()
        {
            return (this.hp >= this.maxhp);
        }

        public void move()
        {
            if (this.moving)
            {
                if (this.curTime >= this.timeTaken)
                {
                    this.moving = false;
                }
                else
                {
                    this.posX += this.moveStep.x;
                    this.posY += this.moveStep.y;
                    this.curTime += 10;
                }
            }
        }

        public void setAmmoType(int ammoType1)
        {
            this.ammoType = ammoType1;
        }

        public void setBO2s(int BO2s1)
        {
            this.BO2s = BO2s1;
        }

        public void setCargo(int prometium1, int endurium1, int terbium1, int prometid1, int duranium1, int promerium1, int seprom1, int xenomit1)
        {
            this.prometium = prometium1;
            this.endurium = endurium1;
            this.terbium = terbium1;
            this.prometid = prometid1;
            this.duranium = duranium1;
            this.promerium = promerium1;
            this.seprom = seprom1;
            this.xenomit = xenomit1;
            this.cargo = this.maxcargo - ((((((this.prometium + this.endurium) + this.terbium) + this.prometid) + this.duranium) + this.promerium) + this.seprom);
        }

        public void setConfig(int n)
        {
            this.config = n;
        }

        public void setConifg2Shield(bool yn)
        {
            this.config2ShieldFull = yn;
        }

        public void setCPUs(int cpu1, int cpu2, int cpu3, int cpu4, int cpu5, int cpu6, int cpu7, int cpu8, int cpu9, int cpu10, int cpu11, int cpu12, int cpu13, int cpu14, int cpu15)
        {
            this.CPU_Drone_Repair = cpu1;
            this.CPU_Radar = cpu2;
            this.CPU_Jump = cpu3;
            this.CPU_Ammo_Buy = cpu4;
            this.CPU_Robot = cpu5;
            this.CPU_HM7 = cpu6;
            this.CPU_Smart_Bomb = cpu8;
            this.CPU_Insta_Shield = cpu9;
            this.CPU_Turbo_Mine = cpu10;
            this.CPU_Aim = cpu11;
            this.CPU_Arol = cpu12;
            this.CPU_Cloak = cpu13;
            this.CPU_Rllb = cpu14;
            this.CPU_Rocket_Buy = cpu15;
        }

        public void setCredits(int credits1)
        {
            this.credits = credits1;
        }

        public void setCurrency(int credits1, int uridium1)
        {
            this.setCredits(credits1);
            this.setUridium(uridium1);
        }

        public void setExpansionID(int expansionID1)
        {
            this.expansionID = expansionID1;
        }

        public void setExperience(int experience1)
        {
            this.experience = experience1;
        }

        public void setHero(int id1, string username1, int shipid1, int speed1, int shield1, int maxshield1, int hp1, int maxhp1, int cargo1, int maxcargo1, double posx1, double posy1, int mapID1, int company1, int clanid1, int maxlaserammo1, int maxrocketammo1, int expansionID1, int premium1, int experience1, int honor1, int level1, int credits1, int uridium1, double jackpot1, int admin1, string clan1, int galaxygatesdone1, bool cloaked1, int ammoType1, int rocketType1)
        {
            this.id = id1;
            this.username = username1;
            this.shipid = shipid1;
            this.speed = speed1;
            this.shield = shield1;
            this.maxshield = maxshield1;
            this.hp = hp1;
            this.maxhp = maxhp1;
            this.cargo = cargo1;
            this.maxcargo = maxcargo1;
            this.posX = posx1;
            this.posY = posy1;
            this.company = company1;
            this.clanid = clanid1;
            this.maxlaserammo = maxlaserammo1;
            this.maxrocketammo = maxrocketammo1;
            this.premium = premium1 > 0;
            this.experience = experience1;
            this.honor = honor1;
            this.level = level1;
            this.credits = credits1;
            this.uridium = uridium1;
            this.jackpot = jackpot1;
            this.admin = admin1;
            this.clan = clan1;
            this.galaxygatesdone = galaxygatesdone1;
            this.cloaked = cloaked1;
            this.ammoType = ammoType1;
            this.rocketType = rocketType1;
            this.mapID = mapID1;
            this.expansionID = expansionID1;
        }

        public void setHonor(int honor1)
        {
            this.honor = honor1;
        }

        public void setHP(int hp1, int maxhp1)
        {
            this.hp = hp1;
            this.maxhp = maxhp1;
        }

        public void setJackpot(double jackpot1)
        {
            this.jackpot = jackpot1;
        }

        public void setLaserAmmo(int la1, int la2, int la3, int la4, int la5, int la6)
        {
            this.LCB10 = la1;
            this.MCB25 = la2;
            this.MCB50 = la3;
            this.UCB100 = la4;
            this.SAB = la5;
            this.RSB75 = la6;
        }

        public void setLaserAttacking(bool b)
        {
            this.laserAttacking = b;
        }

        public void setLevel(int level1)
        {
            this.level = level1;
        }

        public void setLF3s(int LF3s1)
        {
            this.LF3s = LF3s1;
        }

        public void setMapID(int mapID1)
        {
            this.mapID = mapID1;
        }

        public void setMovementData(int x, int y)
        {
            this.destination.x = x;
            this.destination.y = y;
            if ((this.timeTaken != 0.0) && ((this.destination.x != this.posX) || (this.destination.y != this.posY)))
            {
                this.delta.x = this.destination.x - this.posX;
                this.delta.y = this.destination.y - this.posY;
                double num = Math.Sqrt((this.delta.x * this.delta.x) + (this.delta.y * this.delta.y));
                this.timeTaken = (num / this.speed) * 1000.0;
                this.normal.x = this.delta.x / num;
                this.normal.y = this.delta.y / num;
                this.curTime = 0;
                this.velocity = num / (this.timeTaken / 10.0);
                this.moveStep.x = this.normal.x * this.velocity;
                this.moveStep.y = this.normal.y * this.velocity;
                this.moving = true;
            }
        }

        public void setPosX(int x)
        {
            this.posX = x;
        }

        public void setPosY(int y)
        {
            this.posY = y;
        }

        public void setRocketAmmo(int ra1, int ra2, int ra3, int ra4, int ra5, int ra6, int ra7, int ra8, int ra9)
        {
            this.R310 = ra1;
            this.PLT2026 = ra2;
            this.PLT2021 = ra3;
            this.PLT3030 = ra4;
            this.PLD8 = ra5;
            this.Mine = ra6;
            this.Smartbomb = ra7;
            this.Instashield = ra8;
            this.EMP = ra9;
        }

        public void setRocketLauncherAmmo(int rla1, int rla2, int rla3)
        {
            this.HSTRM01 = rla1;
            this.UBR100 = rla2;
            this.ECO10 = rla3;
        }

        public void setRocketType(int rocketType1)
        {
            this.rocketType = rocketType1;
        }

        public void setSelectedShipID(int id)
        {
            this.selected_ship_id = id;
        }

        public void setShield(int shield1, int maxshield1)
        {
            this.shield = shield1;
            this.maxshield = maxshield1;
        }

        public void setSpeed(int speed1)
        {
            this.speed = speed1;
        }

        public void setTargetInRange(bool inrange)
        {
            this.target_in_range = inrange;
        }

        public void setUridium(int uridium1)
        {
            this.uridium = uridium1;
        }
    }
}

