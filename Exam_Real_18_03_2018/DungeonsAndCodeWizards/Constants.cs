using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards
{
  public  class Constants
    {
        public const string MustBeAliveOperationalException = "Must be alive to perform this action!";
        public const string FullBagOperationalException = "Bag is full!";
        public const string EmptyBagOperaionalException = "Bag is empty!";
        public const string NoSuchAnItemArgumentException = "No item with name {0} in bag!";
        public const string NameCannotBeNullArgumentException = "Name cannot be null or whitespace!";
        public const string CannotAttackSelfOperationalException = "Cannot attack self!";
        public const string FriendlyFireArgumwntException = "Friendly fire! Both characters are from {0} faction!";
        public const string CannotHealEnemiesOperationalException = "Cannot heal enemy character!";


    }
}
