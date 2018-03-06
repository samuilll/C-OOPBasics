using System;


    class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End") break;

                var citizenInfo = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var citizen = new Citizen(citizenInfo[0], citizenInfo[1], int.Parse(citizenInfo[2]));

                Console.WriteLine(((IPerson) citizen).GetName());
                Console.WriteLine(((IResident) citizen).GetName());
            }
        }
    }

