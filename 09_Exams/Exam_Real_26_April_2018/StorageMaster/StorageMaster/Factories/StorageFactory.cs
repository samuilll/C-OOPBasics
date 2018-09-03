﻿using StorageMaster.Entities.Storages;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Factories
{
   public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            switch (type)
            {
                case "AutomatedWarehouse":
                    {
                        return new AutomatedWarehouse(name);
                    }
                case "DistributionCenter":
                    {
                        return new DistributionCenter(name);
                    }
                case "Warehouse":
                    {
                        return new Warehouse(name);
                    }

                default:
                    {
                        throw new InvalidOperationException(Constants.InvalidStorageOperationException);
                    }
            }
        }
    }
}
