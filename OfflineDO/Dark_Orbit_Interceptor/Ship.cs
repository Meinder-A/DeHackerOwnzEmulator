namespace Dark_Orbit_Interceptor
{
    using System;

    public class Ship
    {
        private string clan;
        private int clandiplomacy;
        private int clanid;
        private bool cloaked;
        private int company;
        private int curTime;
        private Vector delta = new Vector();
        private Vector destination = new Vector();
        private int galaxygatesdone;
        private int hp;
        private int id;
        private bool isNPC;
        private int maxhp;
        private int maxshield;
        private bool moving;
        private Vector normal = new Vector();
        private double posX;
        private double posY;
        private int shield;
        private int shipid;
        private Vector stepMove = new Vector();
        private bool taken;
        private int timeTaken;
        private string username;
        private double velocity;

        public Ship(int id1, int shipid1, string clan1, string username1, double posx1, double posy1, int company1, int clanid1, int clandiplomacy1, int galaxygatesdone1, bool isNPC1, bool cloaked1)
        {
            this.setShip(id1, shipid1, clan1, username1, posx1, posy1, company1, clanid1, clandiplomacy1, galaxygatesdone1, isNPC1, cloaked1);
        }

        public void clearShip()
        {
            this.id = -1;
            this.shipid = -1;
            this.clan = "";
            this.username = "";
            this.company = -1;
            this.clanid = -1;
            this.clandiplomacy = -1;
            this.galaxygatesdone = -1;
            this.isNPC = false;
            this.cloaked = false;
            this.hp = -1;
            this.maxhp = -1;
            this.shield = -1;
            this.maxshield = -1;
            this.taken = false;
            this.moving = false;
            this.timeTaken = -1;
            this.curTime = -1;
            this.velocity = -1.0;
            this.delta.x = -1.0;
            this.delta.y = -1.0;
            this.destination.x = -1.0;
            this.destination.y = -1.0;
            this.normal.x = -1.0;
            this.normal.y = -1.0;
            this.stepMove.x = -1.0;
            this.stepMove.y = -1.0;
        }

        public string getClan()
        {
            return this.clan;
        }

        public int getClanDiplomacy()
        {
            return this.clandiplomacy;
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

        public int getCurrentTime()
        {
            return this.curTime;
        }

        public int getGalaxyGatesDone()
        {
            return this.galaxygatesdone;
        }

        public int getHP()
        {
            return this.hp;
        }

        public int getID()
        {
            return this.id;
        }

        public bool getIsNPC()
        {
            return this.isNPC;
        }

        public int getMaxHP()
        {
            return this.maxhp;
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

        public int getShield()
        {
            return this.shield;
        }

        public int getShipID()
        {
            return this.shipid;
        }

        public bool getTaken()
        {
            return this.taken;
        }

        public int getTimeTaken()
        {
            return this.timeTaken;
        }

        public string getUsername()
        {
            return this.username;
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
                    this.posX += this.stepMove.x;
                    this.posY += this.stepMove.y;
                    this.curTime += 10;
                }
            }
        }

        public void setCurrentTime(int t)
        {
            this.curTime = t;
        }

        public void setHP(int hp1)
        {
            this.hp = hp1;
        }

        public void setHP(int hp1, int maxhp1)
        {
            this.hp = hp1;
            this.maxhp = maxhp1;
        }

        public void setMovementData(int x, int y, int timetaken1)
        {
            this.destination.x = x;
            this.destination.y = y;
            this.timeTaken = timetaken1;
            if ((this.timeTaken != 0) && ((this.destination.x != this.posX) || (this.destination.y != this.posY)))
            {
                this.delta.x = this.destination.x - this.posX;
                this.delta.y = this.destination.y - this.posY;
                double num = Math.Sqrt((this.delta.x * this.delta.x) + (this.delta.y * this.delta.y));
                this.normal.x = this.delta.x / num;
                this.normal.y = this.delta.y / num;
                this.curTime = 0;
                this.velocity = num / (((double) this.timeTaken) / 10.0);
                this.stepMove.x = this.normal.x * this.velocity;
                this.stepMove.y = this.normal.y * this.velocity;
                this.moving = true;
            }
        }

        public void setShield(int shield1)
        {
            this.shield = shield1;
        }

        public void setShield(int shield1, int maxshield1)
        {
            this.shield = shield1;
            this.maxshield = maxshield1;
        }

        public void setShip(int id1, int shipid1, string clan1, string username1, double posx1, double posy1, int company1, int clanid1, int clandiplomacy1, int galaxygatesdone1, bool isNPC1, bool cloaked1)
        {
            this.id = id1;
            this.shipid = shipid1;
            this.clan = clan1;
            this.username = username1;
            this.posX = posx1;
            this.posY = posy1;
            if (this.company > 3)
            {
                this.company = 0;
            }
            else
            {
                this.company = company1;
            }
            this.clanid = clanid1;
            this.clandiplomacy = clandiplomacy1;
            this.galaxygatesdone = galaxygatesdone1;
            this.isNPC = isNPC1;
            this.cloaked = cloaked1;
        }

        public void setTaken(bool t)
        {
            this.taken = t;
        }
    }
}

