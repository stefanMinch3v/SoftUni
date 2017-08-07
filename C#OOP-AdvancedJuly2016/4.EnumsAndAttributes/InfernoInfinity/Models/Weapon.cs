namespace InfernoInfinity
{
    public abstract class Weapon
    {
        private string name;
        private int minDamage;
        private int maxDamage;
        private string[] gem;
        private string rareLevel;
        private int numOfSockets;
        private int strength;
        private int agility;
        private int vitality;

        protected Weapon(string rareLevel, string name, int maxDamage, int minDamage, int numOfSockets)
        {
            this.Name = name;
            this.MaxDamage = maxDamage;
            this.MinDamage = minDamage;
            this.RareLevel = rareLevel;
            this.NumOfSockets = numOfSockets;
            this.gem = new string[this.NumOfSockets];
            this.strength = 0;
            this.agility = 0;
            this.vitality = 0;
        }

        public virtual string RareLevel
        {
            get
            {
                return this.rareLevel;
            }

            protected set
            {
                if (value == "Uncommon")
                {
                    this.MinDamage *= 2;
                    this.MaxDamage *= 2;
                }
                else if (value == "Rare")
                {
                    this.MinDamage *= 3;
                    this.MaxDamage *= 3;
                }
                else if (value == "Epic")
                {
                    this.MinDamage *= 5;
                    this.MaxDamage *= 5;
                }

                this.rareLevel = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.name = value;
                }
            }
        }

        public virtual int MinDamage
        {
            get
            {
                return this.minDamage;
            }
            protected set
            {
                this.minDamage = value;
            }
        }

        public virtual int MaxDamage
        {
            get
            {
                return this.maxDamage;
            }
            protected set
            {
                this.maxDamage = value;
            }
        }

        public virtual int NumOfSockets
        {
            get
            {
                return this.numOfSockets;
            }
            protected set
            {
                this.numOfSockets = value;
            }
        }

        public virtual string[] Gem
        {
            get
            {
                return this.gem;
            }
            protected set
            {
                this.gem = value;
            }
        }

        public int Strength
        {
            get
            {
                return this.strength;
            }
            set
            {
                this.strength = value;
            }
        }

        public int Agility
        {
            get
            {
                return this.agility;
            }
            set
            {
                this.agility = value;
            }
        }

        public int Vitality
        {
            get
            {
                return this.vitality;
            }
            set
            {
                this.vitality = value;
            }
        }

        public void AddGem(string gem, int index)
        {
            if (index < 0 || index >= this.Gem.Length)
            {
                return;
            }
            this.gem[index] = gem;
        }

        public void CalculateGemStatus()
        {
            foreach (var item in gem)
            {
                if (item == null)
                {
                    continue;
                }
                if (item.Contains("Ruby"))
                {
                    this.strength += 7;
                    this.agility += 2;
                    this.vitality += 5;
                    CalculateQualityOfGems(item);
                }
                else if (item == "Emerald")
                {
                    this.strength += 1;
                    this.agility += 4;
                    this.vitality += 9;
                    CalculateQualityOfGems(item);
                }
                else if(item == "Amethyst")
                {
                    this.strength += 2;
                    this.agility += 8;
                    this.vitality += 4;
                    CalculateQualityOfGems(item);
                }
            }
        }

        public void RepairSocketAfterRemove()
        {
            foreach (var item in gem)
            {
                if (item != null)
                {
                    break;
                }
                this.Agility = 0;
                this.Vitality = 0;
                this.Strength = 0;
            }
        }

        private void CalculateQualityOfGems(string item)
        {
            if (item.Contains("Regular"))
            {
                this.strength += 2;
                this.agility += 2;
                this.vitality += 2;
            }
            else if (item.Contains("Perfect"))
            {
                this.strength += 5;
                this.agility += 5;
                this.vitality += 5;
            }
            else if (item.Contains("Flawless"))
            {
                this.strength += 10;
                this.agility += 10;
                this.vitality += 10;
            }
            else if (item.Contains("Chipped"))
            {
                this.strength += 1;
                this.agility += 1;
                this.vitality += 1;

            }
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= this.gem.Length)
            {
                return;
            }

            this.gem[index] = null;
        }

        public override string ToString()
        {
            return string.Format($"{this.Name}: {this.MinDamage += this.Strength * 2 + this.Agility}-{this.MaxDamage += this.Strength * 3 + this.Agility * 4} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality");
        }
    }
}