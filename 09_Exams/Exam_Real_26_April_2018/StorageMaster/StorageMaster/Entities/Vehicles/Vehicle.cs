using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities.Vehicles
{
   public abstract class Vehicle
    {

        public int Capacity { get;}

        private List<Product> trunk;

        protected Vehicle(int capacity)
        {
           this.Capacity = capacity;
            this.trunk = new List<Product>();
        }

        public IReadOnlyCollection<Product> Trunk
        {
            get { return (IReadOnlyCollection<Product>)trunk; }
        }

        public bool IsFull => this.Trunk.Sum(p=>p.Weight)>=this.Capacity;
        public bool IsEmpty => this.Trunk.Count == 0;


        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(Constants.FullVehicleOperationException);
            }

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException(Constants.NoProductsInTheVehicleOperationException);
            }

            var product = this.trunk[this.trunk.Count-1];

            this.trunk.RemoveAt(this.trunk.Count-1);

            return product;
        }

    }
}
