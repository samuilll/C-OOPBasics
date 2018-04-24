using DungeonsAndCodeWizards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities
{
  public  class Warrior:Character,IAttackable
    {
        private const double _BaseHealth = 100;
        private const double _BaseArmor = 50;
        private const double _PointsAbility = 40;

        public Warrior(string name, Faction faction)
            : base(name, _BaseHealth, _BaseArmor, _PointsAbility, new Satchel(), faction)
        {

        }

        public void Attack(Character character)
        {
            base.CheckIfItIsAlive(this);
            base.CheckIfItIsAlive(character);

            if (this.Name==character.Name)
            {
                throw new InvalidOperationException(Constants.CannotAttackSelfOperationalException);
            }
            if (this.Faction == character.Faction)
            {
                throw new ArgumentException(string.Format(Constants.FriendlyFireArgumwntException,this.Faction.ToString()));
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
