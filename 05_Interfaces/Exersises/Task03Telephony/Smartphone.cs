
using System;
using System.Collections.Generic;
using System.Linq;

public class Smartphone:ISmartPhone
    {
        public List<string> UrlList { get; private set; }
        public List<string> PhoneNumbersList { get; private set; }
        public string Model { get; private set; }

        public Smartphone(string model,List<string> phoneNumbersList, List<string> urlList)
    {
        this.Model = model;
        this.UrlList = urlList;
        this.PhoneNumbersList = phoneNumbersList;
    }

    public string PrintUrl( string url)
        {            
                if (!url.Any(char.IsDigit))
                {
                    return $"Browsing: {url}!";
                }
                else
                {
                    return new ArgumentException("Invalid URL!").Message;
                }           
        }

        public  string PrintPhoneNumber(string number)
        {
            if (number.All(char.IsDigit))
            {
                return $"Calling... {number}";
            }
            else
            {
                return new ArgumentException("Invalid number!").Message;
            }
        }

    
}
