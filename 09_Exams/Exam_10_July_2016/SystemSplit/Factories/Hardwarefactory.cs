using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public static class Hardwarefactory
    {
    public static HardwareComponent CreateHardware(List<string> args)
    {
        string name = args[1];
        int maxCapacity = int.Parse(args[2]);
        int maxMemory = int.Parse(args[3]);

        switch (args[0])
        {
            case "RegisterPowerHardware":
                {
                    return new PowerHardwareComponent(name,maxCapacity,maxMemory);
                }
            case "RegisterHeavyHardware":
                {
                    return new HeavyHarwareComponent(name, maxCapacity, maxMemory);
                }
            default: return null;              
        }
    }

    }

