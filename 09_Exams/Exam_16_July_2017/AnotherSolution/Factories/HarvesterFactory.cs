using System;
using System.Collections.Generic;
using System.Text;


public static class HarvesterFactory
{
    public static Harvester CreateHarvester(List<string> args)
    {
        switch (args[0])
        {
            case "Sonic":
                {
                    return new SonicHarvester(args[1], double.Parse(args[2]), double.Parse(args[3]), int.Parse(args[5]));
                }
            case "Hammer":
                {
                    return new HammerHarvester(args[1], double.Parse(args[2]), double.Parse(args[3]));
                }
            default: return null;
        }
    }
}

