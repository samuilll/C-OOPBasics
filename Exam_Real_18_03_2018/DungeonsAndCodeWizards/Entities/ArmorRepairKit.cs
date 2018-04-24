using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities
{
  public  class ArmorRepairKit:Item
    {
        private const int weight = 10;

        public ArmorRepairKit() : base(weight)
        {

        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(Constants.MustBeAliveOperationalException);
            }
            character.Armor = character.BaseArmor;
        }
    }
}
