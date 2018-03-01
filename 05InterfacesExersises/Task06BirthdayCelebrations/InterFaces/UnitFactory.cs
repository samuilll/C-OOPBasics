
    using System.Collections.Generic;

public class UnitFactory
    {

        public static Mammal CreateUnit(string[] cmdArgs)
        {
            switch (cmdArgs[0])
            {
                case "Citizen":
                {
                    return new Citizen(cmdArgs[1], int.Parse(cmdArgs[2]), cmdArgs[3], cmdArgs[4]);                   
                }
                case "Pet":
                {
                    return new Pet(cmdArgs[1],  cmdArgs[2]);
                }          
            default:
                {
                    return null;
                }
            }
        }
    }
