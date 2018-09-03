using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


  public   class DriverFactory
    {

    public  Driver CreateDriver(List<string> args)
    {
        var driverType = args[0];
        var driverName = args[1];
        int carHP = int.Parse(args[2]);
        double fuelAmount = double.Parse(args[3]);
        Tyre tyre = new TyreFactory().CreateTyre(args.Skip(4).ToList());
        Car car = new Car(carHP,fuelAmount,tyre);

        switch (args[0])
        {
            case "Aggressive":
                {
                    return new AggressiveDriver(driverName,car);
                }
            case "Endurance":
                {
                    return new EnduranceDriver(driverName, car);
                }
            default:
                return null;
        }
    }
}

