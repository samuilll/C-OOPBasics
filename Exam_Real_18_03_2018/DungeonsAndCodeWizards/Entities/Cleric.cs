using DungeonsAndCodeWizards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities
{
  public  class Cleric:Character,IHealable
    {
        private const double _BaseHealth = 50;
        private const double _BaseArmor = 25;
        private const double _PointsAbility = 40;

        public Cleric(string name, Faction faction)
            : base(name, _BaseHealth, _BaseArmor, _PointsAbility, new Backpack(), faction)
        {
            this.RestHealMultiplier = 0.5;
        }

        public void Heal(Character character)
        {
            base.CheckIfItIsAlive(this);
            base.CheckIfItIsAlive(character);

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException(Constants.CannotHealEnemiesOperationalException);
            }

            character.Health += this.AbilityPoints;
        }
    }
}
