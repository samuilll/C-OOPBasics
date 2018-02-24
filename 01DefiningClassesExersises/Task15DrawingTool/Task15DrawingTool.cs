using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task15DrawingTool
{
    static void Main(string[] args)
    {

        var figure = Console.ReadLine();

        if (figure == "Square")
        {
            var size = int.Parse(Console.ReadLine());

            var square = new Square(size);

            square.DrawNow();
        }
        else
        {
            var width = int.Parse(Console.ReadLine());

            var height = int.Parse(Console.ReadLine());

            var rectangle = new Rectangle(width, height);

            rectangle.DrawNow();


        }
    }
}

