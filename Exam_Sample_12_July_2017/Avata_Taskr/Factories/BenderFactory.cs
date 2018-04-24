using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class BenderFactory
    {
    public static Bender CreateBender(List<string> args)
    {
        string benderType = args[0];
        string benderName = args[1];
        int benderPower = int.Parse(args[2]);
        double secondaryParameter = double.Parse(args[3]);

        switch (benderType)
        {
            case "Air":
                {
                    return new AirBender(benderName,benderPower,secondaryParameter);
                }
            case "Fire":
                {
                    return new FireBender(benderName, benderPower, secondaryParameter);
                }
            case "Earth":
                {
                    return new EarthBender(benderName, benderPower, secondaryParameter);
                }
            case "Water":
                {
                    return new WaterBender(benderName, benderPower, secondaryParameter);
                }         
        }

        throw new ArgumentException("Wrong input");
    }
    }

