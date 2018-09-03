using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public  class MonumentFactory
    {
    public static Monument CreateMonument(List<string> args)
    {
        string monumentType = args[0];
        string monumentName = args[1];
        int monumentAffinity = int.Parse(args[2]);

        switch (monumentType)
        {
            case "Air":
                {
                    return new AirMonument(monumentName, monumentAffinity);
                }
            case "Earth":
                {
                    return new EarthMonument(monumentName, monumentAffinity);
                }
            case "Fire":
                {
                    return new FireMonument(monumentName, monumentAffinity);
                }
            case "Water":
                {
                    return new WaterMonument(monumentName, monumentAffinity);
                }
        }

        throw new ArgumentException("Wrong input");
    }
}

