using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities.Storages
{
   public abstract class Storage
    {

        public string Name { get;}

        public int Capacity { get; }
        public int GarageSlots { get;}

      public bool IsFull
        {
            get
            {
                return this.products.Sum(p => p.Weight) >= this.Capacity;
            }
        }

        private Vehicle[] garage;

        public IReadOnlyCollection<Vehicle> Garage
        {
            get { return (IReadOnlyCollection<Vehicle>)garage; }
        }

        private List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> garage)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = garage.ToArray();
            this.products = new List<Product>();
        }

        public IReadOnlyCollection<Product> Products
        {
            get { return (IReadOnlyCollection<Product>)products; }
        }

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot>=this.GarageSlots)
            {
                throw new InvalidOperationException(Constants.InvalidGarageSlotOperationException);
            }
            if (this.garage[garageSlot]==null)
            {
                throw new InvalidOperationException(Constants.NoVehicleInTheSlotOperationexeption);
            }

            return this.garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);

            bool ThereIsFreeSlot = deliveryLocation.Garage.Any(g=>g==null);

            if (!ThereIsFreeSlot)
            {
                throw new InvalidOperationException(Constants.NoRoomInGarageOperationException);
            }

           int freeSlot = -1;

            this.garage[garageSlot] = null;

            for (int i = 0; i < deliveryLocation.garage.Length; i++)
            {
                if (deliveryLocation.garage[i] == null)
                {
                    deliveryLocation.garage[i] = vehicle;
                    freeSlot = i;
                    break;
                }
            }

            return freeSlot;
        }

       public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(Constants.StorageIsFullOperationException);
            }

            Vehicle vehicle = this.GetVehicle(garageSlot);

            int count = 0;

            while (true)
            {
                if (vehicle.IsEmpty)
                {
                    break;
                }
                if (!this.IsFull)
                {
                    Product product = vehicle.Unload();
                    this.products.Add(product);
                    count++;
                }
                else 
                {
                    break;
                }
            }

            return count;
        }

        public override string ToString()
        {

            var sb = new StringBuilder();

            var sumOfTheProductsWeights = this.Products.Sum(p=>p.Weight);


            var temp = new Dictionary<string, int>();

            foreach (var product in this.Products)
            {
                if (!temp.ContainsKey(product.GetType().Name))
                {
                    temp[product.GetType().Name] = 0;
                }
                temp[product.GetType().Name]++;
            }

            sb.Append($"Stock ({sumOfTheProductsWeights}/{this.Capacity}): [");

            if (temp.Count>0)
            {
                foreach (var pair in temp.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
                {
                    sb.Append($"{pair.Key} ({pair.Value}), ");
                }
                sb.Remove(sb.Length-2,2);
            }

            sb.AppendLine("]");

            var tempList = new List<string>();
            foreach (var slot in this.Garage)
            {
                if (slot!=null)
                {
                    tempList.Add(slot.GetType().Name);
                }
                else
                {
                    tempList.Add("empty");
                }
            }

            sb.AppendLine($"Garage: [{string.Join("|", tempList.OrderByDescending(v => v!=null))}]");
            //Stock (2.7/10): [HardDrive (2), Gpu (1)]
            //Garage: [Semi|Semi|Semi|Van|empty|empty|empty|empty|empty|empty]

            return sb.ToString().TrimEnd('\r','\n');
        }

    }
}
