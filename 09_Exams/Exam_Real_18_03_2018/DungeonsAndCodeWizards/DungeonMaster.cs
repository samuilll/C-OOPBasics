using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Entities;
using DungeonsAndCodeWizards.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{
   public class DungeonMaster
    {
        private List<Character> characters;
        private Stack<Item> items;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;
        private int lastSurvivorRounds;

        private bool isGameOver = false;

        public DungeonMaster()
        {
            this.characters = new List<Character>();
            this.items = new Stack<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
            this.lastSurvivorRounds = 0;
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string type = args[1];
            string name = args[2];

            Character character = this.characterFactory.CreateCharacter(faction, type, name);

            this.characters.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = this.itemFactory.CreateItem(itemName);

            this.items.Push(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            CheckIfCharacterExist(characterName);
            CheckIfThereAreItemsInThePool();

            Character character = GetCharacter(characterName);
            Item item = this.items.Pop();

            character.Bag.AddItem(item);

            return $"{character.Name} picked up {item.GetType().Name}!";

        }
  
        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            CheckIfCharacterExist(characterName);

            Character character = GetCharacter(characterName);
            Item item = character.Bag.GetItem(itemName);

            item.AffectCharacter(character);


            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            CheckIfCharacterExist(giverName);
            CheckIfCharacterExist(receiverName);

            Character giver = GetCharacter(giverName);
            Character receiver = GetCharacter(receiverName);

            Item item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item,receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            CheckIfCharacterExist(giverName);
            CheckIfCharacterExist(receiverName);

            Character giver = GetCharacter(giverName);
            Character receiver = GetCharacter(receiverName);

            Item item = giver.Bag.GetItem(itemName);

            receiver.Bag.AddItem(item);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            if (this.characters.Count>0)
            {
                foreach (var character in this.characters.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
                {
                    sb.AppendLine(character.ToString());
                }
            }

            return sb.ToString().TrimEnd('\n','\r');
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            CheckIfCharacterExist(attackerName);
            CheckIfCharacterExist(receiverName);

            Character attacker = GetCharacter(attackerName);
            Character receiver = GetCharacter(receiverName);

            if (!typeof(IAttackable).IsAssignableFrom(attacker.GetType()))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            IAttackable tempAttacker = (IAttackable)attacker;

            tempAttacker.Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} " +
                $"hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().TrimEnd('\n','\r');
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            CheckIfCharacterExist(healerName);
            CheckIfCharacterExist(receiverName);

            Character healer = GetCharacter(healerName);
            Character receiver = GetCharacter(receiverName);

            if (!typeof(IHealable).IsAssignableFrom(healer.GetType()))
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            IHealable tempHealer = (IHealable)healer;

            tempHealer.Heal(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");


            return sb.ToString().TrimEnd('\n', '\r');
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            var survivors = this.characters.Where(c => c.IsAlive).ToList();

            foreach (var character in survivors)
            {
                var healthBeforeRest = character.Health;

                character.Rest();

                sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            if (survivors.Count<=1)
            {
                this.lastSurvivorRounds += 1;
            }
            if (this.lastSurvivorRounds>=2)
            {
                this.isGameOver = true;

                sb.AppendLine("Final stats:");

                sb.AppendLine(this.GetStats());

            }
            return sb.ToString().TrimEnd('\r','\n');
        }

        public bool IsGameOver()
        {
            return this.isGameOver;
        }


        private Item GetItem()
        {
            return this.items.Pop();
        }

        private Character GetCharacter(string characterName)
        {
            return this.characters.First(c => c.Name == characterName);
        }

        private void CheckIfThereAreItemsInThePool()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }
        }

        private void CheckIfCharacterExist(string characterName)
        {
            if (!this.characters.Any(c => c.Name == characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
            if (!this.characters.First(c=>c.Name==characterName).IsAlive)
            {
                throw new InvalidOperationException(Constants.MustBeAliveOperationalException);
            }
        }

    }
}
