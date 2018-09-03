using System;
using System.Collections.Generic;
using System.Text;


  public  class AnimalFactory
    {

    public static Animal ProduceAnimal(string animalType, string name, int age, string gender)
    {
        switch (animalType)
        {
            case "Dog":
                {
                    return new Dog(name, age, gender);
                }
            case "Cat":
                {
                    return new Cat(name, age, gender);
                }
            case "Frog":
                {
                    return new Frog(name, age, gender);
                }
            case "Kitten":
                {
                    return new Kitten(name, age, gender);
                }
            case "Tomcat":
                {
                    return new Tomcat(name, age, gender);
                }
            default: return null;
                
        }
    }
    }

