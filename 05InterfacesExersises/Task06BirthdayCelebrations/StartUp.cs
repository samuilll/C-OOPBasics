using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
    {
        static void Main(string[] args)
    {

        List<Mammal> mammals = new List<Mammal>();

        StoremammalsInList(mammals);

        PrintTheResult(mammals);

    }

    private static void PrintTheResult(List<Mammal> mammals)
    {
        string seachedDate = Console.ReadLine();

        if (mammals.Any(m => m.HaveBirthay(seachedDate)))
        {
            mammals.Where(m => m.HaveBirthay(seachedDate)).ToList().ForEach(m => Console.WriteLine(m.Birthay));
        }
     
    }

    private static void StoremammalsInList(List<Mammal> mammals)
    {
        while (true)
        {
            string[] input = Console.ReadLine().Split();

            if (input[0] == "End")
            {
               break;
            }

            if (input[0]=="Robot")
            {
                continue;
            }

            var currentUnit = UnitFactory.CreateUnit(input);

            
                mammals.Add(currentUnit);
            
         
        }
    }
}

