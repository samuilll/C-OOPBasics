using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storages;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster
{
  public  class StorageMaster
    {
        private List<Product> products;
        private List<Storage> storages;

        private Vehicle currentVehicle = null;

        public StorageMaster()
        {
            this.products = new List<Product>();
            this.storages = new List<Storage>();
        }

        private ProductFactory productFactory = new ProductFactory();
        private StorageFactory storageFactory = new StorageFactory();

        public string AddProduct(string type, double price)
        {
            Product product = this.productFactory.CreateProduct(type,price);
            this.products.Add(product);
            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = storageFactory.CreateStorage(type, name);
            this.storages.Add(storage);
            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = GetStorage(storageName);

            Vehicle vehicle = storage.GetVehicle(garageSlot);

            this.currentVehicle = vehicle;
            return $"Selected {vehicle.GetType().Name}";

        }


        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int count = 0;

            foreach (var productName in productNames)
            {
                Product product = GetTheProduct(productName);

                if (!this.currentVehicle.IsFull)
                {
                    this.currentVehicle.LoadProduct(product);
                    count++;
                }
                else
                {
                    break;
                }
            }

            return $"Loaded {count}/{productNames.Count()} products into {this.currentVehicle.GetType().Name}";
        }


        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!CheckIfSorageExist(sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            if (!CheckIfSorageExist(destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            Storage sourceStorage = GetStorage(sourceName);
            Storage destinationStorage = GetStorage(destinationName);

            int destinationSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            Vehicle vehicle = destinationStorage.GetVehicle(destinationSlot);


            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationSlot})";
        }

    

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = GetStorage(storageName);
            Vehicle vehicle = storage.GetVehicle(garageSlot);

            int productsInVehicle = vehicle.Trunk.Count;

          int unLoadCount =   storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unLoadCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            var sb = new StringBuilder();

            Storage storage = GetStorage(storageName);

            sb.AppendLine(storage.ToString());

            return sb.ToString().TrimEnd('\r','\n');
        }

        public string GetSummary()
        {
            var sb = new StringBuilder();

            foreach (var storage in this.storages.OrderByDescending(s=>s.Products.Sum(p=>p.Price)))
            {
                //  AmazonWarehouse:
                // Storage worth: $990.00

                sb.AppendLine($"{storage.Name}:");
                sb.AppendLine($"Storage worth: ${storage.Products.Sum(p => p.Price):F2}");

            }

            return sb.ToString().TrimEnd('\r', '\n');
        }

        private Storage GetStorage(string storageName)
        {
            return this.storages.First(s => s.Name == storageName);
        }


        private Product GetTheProduct(string productName)
        {
            if (this.products.Count==0)
            {
                throw new InvalidOperationException($"{productName} is out of stock!");
            }
            if (!this.products.Any(p => p.GetType().Name == productName))
            {
                throw new InvalidOperationException($"{productName} is out of stock!");
            }

            Product product = null;
            for (int i = this.products.Count - 1; i >= 0; i--)
            {
                if (this.products[i].GetType().Name == productName)
                {
                    product = this.products[i];
                    this.products.RemoveAt(i);
                    break;
                }
            }

            return product;
        }
        private bool CheckIfSorageExist(string name)
        {
            return this.storages.Any(s => s.Name == name);
        }

    }
}
