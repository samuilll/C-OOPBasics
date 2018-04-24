using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities
{
    public abstract class Character
    {
        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.baseArmor = armor;
            this.baseHealth = health;
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
        }

        private string name;
        private double health;
        private double baseHealth;
        private double baseArmor;
        private double armor;

        public double BaseHealth => this.baseHealth;
        public double BaseArmor => this.baseArmor;
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Constants.NameCannotBeNullArgumentException);
                }
                name = value;
            }
        }

        private bool isAlive;
        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
             set
            {
                isAlive = value;
            }
        }

        public double Health
        {
            get { return health; }
            set
            {
                health = Math.Min(this.baseHealth, value);
                if (value < 0)
                {
                    health = 0;
                }
            }
        }

        public double Armor
        {
            get { return armor; }
            set
            {
                armor = Math.Min(this.baseArmor, value);
                if (value < 0)
                {
                    armor = 0;
                }
            }
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; }

        public Faction Faction { get; }

        protected virtual double RestHealMultiplier { get; set; } = 0.2;

        public void TakeDamage(double hitPoints)
        {
            CheckIfItIsAlive(this);

            if (this.Armor > 0)
            {
                if (this.Armor >= hitPoints)
                {
                    this.Armor -= hitPoints;
                    return;
                }
                hitPoints -= this.Armor;
                this.Armor = 0;
            }
            this.Health -= hitPoints;

            if (this.Health <= 0)
            {
                this.Health = 0;
                this.IsAlive = false;
            }
        }

        protected void CheckIfItIsAlive(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(Constants.MustBeAliveOperationalException);
            }
        }

        public void Rest()
        {
            CheckIfItIsAlive(this);

            this.Health += (this.baseHealth * this.RestHealMultiplier);
        }
        public void UseItem(Item item)
        {
            CheckIfItIsAlive(this);

            item.AffectCharacter(this);
        }
        public void UseItemOn(Item item, Character character)
        {
            CheckIfItIsAlive(this);

            CheckIfItIsAlive(character);

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            CheckIfItIsAlive(this);
            CheckIfItIsAlive(character);

            character.Bag.AddItem(item);
        }

        public void ReceiveItem(Item item)
        {
            CheckIfItIsAlive(this);

            this.Bag.AddItem(item);
        }
        public override string ToString()
        {
            string isAliveString = this.IsAlive ? "Alive" : "Dead";
            string result = $"{this.Name} - HP: {this.Health}/{this.baseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {isAliveString}";
            return result;
        }
    }
}
