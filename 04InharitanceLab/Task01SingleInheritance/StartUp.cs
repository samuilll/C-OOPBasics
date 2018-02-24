using System;


    class StartUp
    {
        static void Main(string[] args)
        {
        var dog = new Dog();
        var animal = new Animal();

        animal.Eat();

        dog.Eat();
        dog.Bark();
    }
    }

