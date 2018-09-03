using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards;
namespace DungeonsAndCodeWizards.Entities
{
  public abstract  class Bag
    {
        private List<Item> items;

        protected Bag(int capacity)
        {
            this.capacity = capacity;
            this.items = new List<Item>();
        }

        private int capacity;
        private int Load => this.Items.Select(i => i.Weight).Sum();
     
        public IReadOnlyCollection<Item> Items
        {
            get { return (IReadOnlyCollection<Item>)items; }
        }

        public void AddItem(Item item)
        {
            if (this.Load+item.Weight>this.capacity)
            {
                throw new InvalidOperationException(Constants.FullBagOperationalException);
            }
            this.items.Add(item);
        }
      

        public Item GetItem(string name)
        {
            if (this.Items.Count==0)
            {
                throw new InvalidOperationException(Constants.EmptyBagOperaionalException);
            }

            Item item = this.items.FirstOrDefault(i=>i.GetType().Name==name);

            if (item==null)
            {
                throw new ArgumentException(string.Format(Constants.NoSuchAnItemArgumentException,name));
            }

            this.items.Remove(item);

            return item;
        }

    }
}
