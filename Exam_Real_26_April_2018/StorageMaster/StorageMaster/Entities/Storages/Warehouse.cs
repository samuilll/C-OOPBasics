using StorageMaster.Entities.Vehicles;
using StorageMaster.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Storages
{
    public class Warehouse : Storage
    {
        private const int defaultCapacity = 10;
        private const int defaultGarageSlots = 10;

        public Warehouse(string name) :
            base(name, defaultCapacity, defaultGarageSlots, new Vehicle[10]
            { new VehicleFactory().CreateVehicle("Semi"),
                 new VehicleFactory().CreateVehicle("Semi"),
                new VehicleFactory().CreateVehicle("Semi"),
                 null,
                 null,
                 null,
                 null,
                 null,
                 null,
                 null,
            })
        {
        }
    }
}
