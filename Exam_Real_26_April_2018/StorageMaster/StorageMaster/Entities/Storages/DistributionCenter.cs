using StorageMaster.Entities.Vehicles;
using StorageMaster.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Storages
{
   public class DistributionCenter:Storage
    {
        private const int defaultCapacity = 2;
        private const int defaultGarageSlots = 5;

        public DistributionCenter(string name) :
            base(name, defaultCapacity, defaultGarageSlots, new Vehicle[5]
            { new VehicleFactory().CreateVehicle("Van"),
                new VehicleFactory().CreateVehicle("Van"),
                new VehicleFactory().CreateVehicle("Van"),
                null,
                null,
            })
        {
        }
    }
}
