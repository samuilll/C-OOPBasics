using System;
using System.Collections.Generic;
using System.Text;


 public static   class ProviderFactory
    {

    public static Provider CreateProvider(List<string> args)
    {
        try
        {
            switch (args[0])
            {
                case "Solar":
                    {
                        return new SolarProvider(args[1], double.Parse(args[2]));
                    }
                case "Pressure":
                    {
                        return new PressureProvider(args[1], double.Parse(args[2]));
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

