using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {

        var persons = new List<Person>();

        var products = new List<Product>();

        StorePersonsAndproductsTodata(persons, products);

        ShoppingSpree(persons, products);

        PrintEachPerson(persons);

    }

    private static void PrintEachPerson(List<Person> persons)
    {
        foreach (var person in persons)
        {
            Console.WriteLine(person);
        }
    }

    private static void ShoppingSpree(List<Person> persons, List<Product> products)
    {
        while (true)
        {
            var personProduct = Console.ReadLine().Split();

            if (personProduct[0] == "END")
            {
                break;
            }

            var personName = personProduct[0];

            var productName = personProduct[1];

            bool haveProductBought = persons.Where(p => p.Name == personName).First().TryToBuyTheProduct(products.Where(p => p.Name == productName).First());

            if (haveProductBought)
            {
                Console.WriteLine($"{personName} bought {productName}");
            }
            else
            {
                Console.WriteLine($"{personName} can't afford {productName}");
            }
        }
    }

    private static void StorePersonsAndproductsTodata(List<Person> persons, List<Product> products)
    {
        var personsLineSplitted = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        var productsLineSplitted = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var nameMoneyPair in personsLineSplitted)
        {
            try
            {
                GetThePersonAndAddToTheList(persons, nameMoneyPair);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Environment.Exit(3);

            }
        }
        foreach (var nameCostPair in productsLineSplitted)
        {
            try
            {
                GetTheProductAndAddToTheList(products, nameCostPair);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(3);
            }
        }
    }

    private static void GetTheProductAndAddToTheList(List<Product> products, string nameCostPair)
    {
        var name = nameCostPair.Split('=')[0];

        var cost = decimal.Parse(nameCostPair.Split('=')[1]);

        products.Add(new Product(name, cost));
    }

    private static void GetThePersonAndAddToTheList(List<Person> persons, string nameMoneyPair)
    {
        var name = nameMoneyPair.Split('=')[0];

        var money = decimal.Parse(nameMoneyPair.Split('=')[1]);

        persons.Add(new Person(name, money));
    }
}

