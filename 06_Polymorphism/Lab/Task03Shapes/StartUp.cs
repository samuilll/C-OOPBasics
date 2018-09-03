using System;


    class StartUp
    {
        static void Main(string[] args)
        {

        Shape shape = new Rectangle(3,5);

        Console.WriteLine(shape.CalculateArea());
        Console.WriteLine(shape.CalculatePerimeter());
        Console.WriteLine(shape.Draw());

        Shape circle = new Circle(2.5);

        Console.WriteLine(circle.CalculateArea());
        Console.WriteLine(circle.CalculatePerimeter());
        Console.WriteLine(circle.Draw());
    }
    }

