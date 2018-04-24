using DungeonsAndCodeWizards.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
  public  class CharacterFactory
    {
        public Character CreateCharacter(string factionName,string typeName,string characterName)
        {
            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == typeName);

            if (!Enum.TryParse<Faction>(factionName, out Faction faction))
            {
                throw new ArgumentException($"Invalid faction \"{factionName}\"!");
            }
            if (type == null)
            {
                throw new ArgumentException($"Invalid character type \"{typeName}\"!");
            }

            Character character = (Character)Activator.CreateInstance(type,characterName,faction);

            return character;
        }
    }
}
