using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


    class Program
    {
    static void Main(string[] args)
    {
        Regex samePersonRegex = new Regex(@"(?<name>[A-Za-z]+? [A-Za-z]+?) (?<date>\d+/\d+/\d+)");     
        string dateOrName = Console.ReadLine().Trim();                                                         
        var personRelationLines = new List<string>();
        var fullPersonInfo = new List<Person>();

        SetInfoSeparated(samePersonRegex, personRelationLines, fullPersonInfo);

        CombineSeparateInfo(personRelationLines, fullPersonInfo);

        PrintTheResult(dateOrName, fullPersonInfo);
    }

    private static void CombineSeparateInfo( List<string> personRelationLines, List<Person> fullPersonInfo)
    {
        Regex dateToDateRegex = new Regex(@"(?<firstDate>\d+/\d+/\d+) - (?<secondDate>\d+/\d+/\d+)");
        Regex nameToBirthayRegex = new Regex(@"(?<name>[A-Za-z]+ [A-Za-z]+) - (?<date>\d+/\d+/\d+)");
        Regex birthayToNameRegex = new Regex(@"(?<date>\d+/\d+/\d+) - (?<name>[A-Za-z]+ [A-Za-z]+)");
        Regex nameToNameRegex = new Regex(@"(?<firstName>[A-Za-z]+ [A-Za-z]+) - (?<secondName>[A-Za-z]+ [A-Za-z]+)");

        foreach (var input in personRelationLines)
        {
            if (dateToDateRegex.IsMatch(input))
            {
                var firstDate = dateToDateRegex.Match(input).Groups["firstDate"].Value;
                var secondDate = dateToDateRegex.Match(input).Groups["secondDate"].Value;

                var parent = fullPersonInfo.FirstOrDefault(p => p.BirthDay == firstDate);
                var child = fullPersonInfo.FirstOrDefault(p => p.BirthDay == secondDate);

                if (parent != null && child != null)
                {
                    fullPersonInfo.FirstOrDefault(p => p.BirthDay == firstDate).Children.Add(child);
                    fullPersonInfo.FirstOrDefault(p => p.BirthDay == secondDate).Parents.Add(parent);
                }
            }
          else  if (nameToBirthayRegex.IsMatch(input))
            {
                var name = nameToBirthayRegex.Match(input).Groups["name"].Value;
                var date = nameToBirthayRegex.Match(input).Groups["date"].Value;

                var parent = fullPersonInfo.FirstOrDefault(p => p.Name == name);
                var child = fullPersonInfo.FirstOrDefault(p => p.BirthDay == date);

                if (parent != null && child != null)
                {
                    fullPersonInfo.FirstOrDefault(p => p.Name == name).Children.Add(child);
                    fullPersonInfo.FirstOrDefault(p => p.BirthDay == date).Parents.Add(parent);
                }
            }
          else  if (birthayToNameRegex.IsMatch(input))
            {
                var date = birthayToNameRegex.Match(input).Groups["date"].Value;
                var name = birthayToNameRegex.Match(input).Groups["name"].Value;

                var parent = fullPersonInfo.FirstOrDefault(p => p.BirthDay == date);
                var child = fullPersonInfo.FirstOrDefault(p => p.Name == name);

                if (parent != null && child != null)
                {
                    fullPersonInfo.FirstOrDefault(p => p.BirthDay == date).Children.Add(child);
                    fullPersonInfo.FirstOrDefault(p => p.Name == name).Parents.Add(parent);
                }
            }
          else  if (nameToNameRegex.IsMatch(input))
            {
                var firstName = nameToNameRegex.Match(input).Groups["firstName"].Value;
                var secondName = nameToNameRegex.Match(input).Groups["secondName"].Value;

                var parent = fullPersonInfo.FirstOrDefault(p => p.Name == firstName);
                var child = fullPersonInfo.FirstOrDefault(p => p.Name == secondName);

                if (parent != null && child != null)
                {
                    fullPersonInfo.FirstOrDefault(p => p.Name == firstName).Children.Add(child);
                    fullPersonInfo.FirstOrDefault(p => p.Name == secondName).Parents.Add(parent);
                }
            }
        }
    }

    private static void SetInfoSeparated(Regex samePersonRegex, List<string> personRelationLines, List<Person> fullPersonInfo)
    {
        while (true)
        {
            var commandLine = Console.ReadLine();

            if (commandLine == "End")
            {
                break;
            }
            if (samePersonRegex.IsMatch(commandLine))
            {
                var name = samePersonRegex.Match(commandLine).Groups["name"].Value;
                var birthay = samePersonRegex.Match(commandLine).Groups["date"].Value;

                fullPersonInfo.Add(new Person() { Name = name, BirthDay = birthay });
            }
            else
            {
                personRelationLines.Add(commandLine);
            }
        }
    }
    private static void PrintTheResult(string dateOrName, List<Person> fullPersonInfo)
    {
        var searchedPerson = fullPersonInfo.FirstOrDefault(p => p.Name == dateOrName);

        if (searchedPerson == null)
        {
            searchedPerson = fullPersonInfo.FirstOrDefault(p => p.BirthDay == dateOrName);
        }
        if (searchedPerson!=null)
        {
            Console.WriteLine(searchedPerson);
            Console.WriteLine("Parents:");
            foreach (var parent in searchedPerson.Parents)
            {
                Console.WriteLine(parent);
            }
            Console.WriteLine("Children:");
            foreach (var child in searchedPerson.Children)
            {
                Console.WriteLine(child);
            }
        }
       
    }
}

