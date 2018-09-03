using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        var firstDate = Console.ReadLine();

        var secondDate = Console.ReadLine();

        Console.WriteLine(DateModifier.CalculateTheDifference(firstDate,secondDate));

    }
}

