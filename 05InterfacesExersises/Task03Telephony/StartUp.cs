using System;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        Smartphone phone = new Smartphone("Smartphone",
            Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList(),
            Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
            );

        phone.PhoneNumbersList.ForEach(n => Console.WriteLine(phone.PrintPhoneNumber(n)));
        phone.UrlList.ForEach(u => Console.WriteLine(phone.PrintUrl(u)));
    }
}

