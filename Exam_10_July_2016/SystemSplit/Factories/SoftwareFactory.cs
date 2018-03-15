using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class SoftwareFactory
    {
    public static SoftwareComponent CreateSoftware(List<string> args)
    {
        string hardComp = args[1];
        string name = args[2];
        int capacityConsuption = int.Parse(args[3]);
        int memoryConsumtion = int.Parse(args[4]);

        switch (args[0])
        {
            case "RegisterLightSoftware":
                {
                    return new LightSoftwareComponent(hardComp,name, capacityConsuption, memoryConsumtion);
                }
            case "RegisterExpressSoftware":
                {
                    return new ExpressSoftwareComponent(hardComp, name, capacityConsuption, memoryConsumtion);
                }
            default: return null;
        }
    }
}

