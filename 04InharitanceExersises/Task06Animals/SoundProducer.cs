using System;
using System.Collections.Generic;
using System.Text;


  public  class SoundProducer
    {

    public static void ProduceSound(Animal animal)
    {
        var kindOfAnimal = animal.GetType().Name;

        switch (kindOfAnimal)
        {
            case "Dog":
                {
                    Console.WriteLine("Woof!");
                    break;
                }
            case "Cat":
                {
                    Console.WriteLine("Meow meow");
                    break;
                }
            case "Frog":
                {
                    Console.WriteLine("Ribbit");
                    break;
                }
            case "Kitten":
                {
                    Console.WriteLine("Meow");
                    break;
                }
            case "Tomcat":
                {
                    Console.WriteLine("MEOW");
                    break;
                }
            default:
                break;
        }
    }
    }

