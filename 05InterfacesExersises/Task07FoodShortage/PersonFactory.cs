
    using Task07FoodShortage.Models;

public class PersonFactory
    {
        public static Person CreatePerson(string[] cmdArgs)
        {
            switch (cmdArgs.Length)
            {
            case 3:return new Rebel(cmdArgs[0],int.Parse(cmdArgs[1]),cmdArgs[2]);
            case 4: return new Citizen(cmdArgs[0], int.Parse(cmdArgs[1]),cmdArgs[2], cmdArgs[3]);
            default: return null;
            }
        }
    }
