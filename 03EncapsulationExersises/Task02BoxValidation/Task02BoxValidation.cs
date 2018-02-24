using System;
using System.Linq;
using System.Reflection;

class Task02BoxValidation
{
    static void Main(string[] args)
    {
        //Type boxType = typeof(Box);
        //FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        //Console.WriteLine(fields.Count());

        var boxParams = new double[3];

        for (int i = 0; i < 3; i++)
        {
            boxParams[i] = double.Parse(Console.ReadLine());
        }

        Box box;

        try
        {
            box = new Box(boxParams[0], boxParams[1], boxParams[2]);
            Console.WriteLine($"Surface Area - {box.GetSurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.GetLateralSurfaceArea():f2}");
            Console.WriteLine($"Volume - {box.GetVolume():f2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
 

    }
}

