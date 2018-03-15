using System;
using System.Collections.Generic;
using System.Text;


  public static class HarvesterFactory
    {
    public static Harvester CreateHarvester(List<string> args)
    {
        try
        {
            switch (args[0])
            {
                case "Sonic":
                    {
                        return new SonicHarvester(args[1], double.Parse(args[2]), double.Parse(args[3]), int.Parse(args[4]));
                    }
                case "Hammer":
                    {
                        return new HammerHarvester(args[1], double.Parse(args[2]), double.Parse(args[3]));
                    }
                default: return null;
            }
        }
        catch (ArgumentException ex)
        {
            throw ex;
        }
    }
}

