using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities
{
  public  class HealthPotion:Item
    {
        private const int weight = 5;

        public HealthPotion() : base(weight)
        {

        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(Constants.MustBeAliveOperationalException);
            }
            character.Health += 20;
        }
    }
}
