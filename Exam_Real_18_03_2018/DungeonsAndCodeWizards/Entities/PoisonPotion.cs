using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities
{
  public  class PoisonPotion:Item
    {
        private const int weight = 5;

        public PoisonPotion() : base(weight)
        {

        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(Constants.MustBeAliveOperationalException);
            }
            character.Health -= 20;
            if (character.Health <= 0)
            {
                character.Health = 0;
                character.IsAlive = false;
            }
        }
    }
}
