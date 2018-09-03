using System;
using System.Runtime.InteropServices;

class StartUp
{
    static void Main(string[] args)
    {
        string driverName = Console.ReadLine();
       
        ICar car  = new Ferrari(driverName);
        Console.WriteLine(car);
    }
};

