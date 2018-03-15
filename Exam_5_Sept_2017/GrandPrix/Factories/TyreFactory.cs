using System;
using System.Collections.Generic;
using System.Text;


  public   class TyreFactory
    {

    public  Tyre CreateTyre(List<string> args)
    {
        double tyreHardness = double.Parse(args[1]);
        switch (args[0])
        {

            case "Ultrasoft":
                {
                    double grip = double.Parse(args[2]);
                    return new UltrasoftTyre(tyreHardness, grip);
                }
            case "Hard":
                {
                    return new HardTyre(tyreHardness);
                }
            default:
                return null;
        }
    }
    }

