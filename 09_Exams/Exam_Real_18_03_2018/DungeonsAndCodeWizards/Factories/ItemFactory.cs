using DungeonsAndCodeWizards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
  public  class ItemFactory
    {
        public Item CreateItem(string name)
        {
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == name);

            if (type == null)
            {
                throw new ArgumentException($"Invalid item \"{name}\"!");
            }

            Item item = (Item)Activator.CreateInstance(type);

            return item;
        }
    }
}
