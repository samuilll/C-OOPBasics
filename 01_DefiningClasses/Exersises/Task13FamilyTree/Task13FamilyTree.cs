using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Task13FamilyTree
    {
        static void Main(string[] args)
    {
        Regex samePersonRegex = new Regex(@"(?<name>[A-Za-z]+? [A-Za-z]+?) (?<date>\d+/\d+/\d+)");
        Regex dateToDateRegex = new Regex(@"(?<firstDate>\d+/\d+/\d+) - (?<secondDate>\d+/\d+/\d+)");
        Regex personToDateRegex = new Regex(@"(?<person>[A-Za-z]+ [A-Za-z]+) - (?<date>\d+/\d+/\d+)");
        Regex dateToPersonRegex = new Regex(@"(?<date>\d+/\d+/\d+) - (?<person>[A-Za-z]+ [A-Za-z]+)");
        Regex personToPersonRegex = new Regex(@"(?<firstPerson>[A-Za-z]+ [A-Za-z]+) - (?<secondPerson>[A-Za-z]+ [A-Za-z]+)");


        string dateOrName = Console.ReadLine();

        var person = new Person();

        if (!DateTime.TryParse(dateOrName, out var d))
        {
            person.Name = dateOrName;
        }
        else
        {
            person.BirthDay = dateOrName;
        }


        var fullDataList = new List<string>();


        while (true)
        {
            var commandLine = Console.ReadLine();

            if (commandLine == "End")
            {
                break;
            }

            fullDataList.Add(commandLine);     
        }

        var samePersonData = new List<string>();

        var relationData = new List<string>();

        var samePersonDictionary = new Dictionary<string, string>();

        SetInfo(samePersonRegex, person, fullDataList, samePersonData, relationData);


        foreach (var item in samePersonData)
        {
            var name = samePersonRegex.Match(item).Groups["name"].Value;
            var date = samePersonRegex.Match(item).Groups["date"].Value;

            samePersonDictionary[name] = date;
        }
        foreach (var input in relationData)
        {
            if (dateToDateRegex.IsMatch(input))
            {
                var firstDate = dateToDateRegex.Match(input).Groups["firstDate"].Value;
                var secondDate = dateToDateRegex.Match(input).Groups["secondDate"].Value;

                if (firstDate==person.BirthDay)
                {
                    var child = new Person();

                    if (samePersonDictionary.Any(n => n.Value == secondDate))
                    {
                        child.Name = samePersonDictionary.First(n => n.Value == secondDate).Key;
                        child.BirthDay = secondDate;
                        person.Children.Add(child);
                    }
                }
                else if(secondDate == person.BirthDay)
                {
                    var parent = new Person();
                    if (samePersonDictionary.Any(n => n.Value == firstDate))
                    {
                        parent.Name = samePersonDictionary.First(n => n.Value == firstDate).Key;
                        parent.BirthDay = firstDate;
                        person.Parents.Add(parent);
                    }
                }
            }
            if (personToDateRegex.IsMatch(input))
            {
                var name = personToDateRegex.Match(input).Groups["person"].Value;
                var date = personToDateRegex.Match(input).Groups["date"].Value;

                if (person.Name==name)
                {
                    var child = new Person();

                    if (samePersonDictionary.Any(n => n.Value == date))
                    {
                        child.Name = samePersonDictionary.First(n => n.Value == date).Key;
                        child.BirthDay = date;
                        person.Children.Add(child);
                    }
                }
                else if (date == person.BirthDay)
                {
                    var parent = new Person();
                    if (samePersonDictionary.Any(n => n.Key == name))
                    {
                        parent.BirthDay = samePersonDictionary.First(n => n.Key == name).Value;
                        parent.Name = name;
                        person.Parents.Add(parent);
                    }
                }

            }
            if (dateToPersonRegex.IsMatch(input))
            {
                var name = dateToPersonRegex.Match(input).Groups["person"].Value;
                var date = dateToPersonRegex.Match(input).Groups["date"].Value;

                if (person.Name == name)
                {
                    var parent = new Person();
                    if (samePersonDictionary.Any(n => n.Value == date))
                    {
                        parent.BirthDay = date;
                        parent.Name = samePersonDictionary.First(n => n.Value == date).Key;
                        person.Parents.Add(parent);
                    }
                   
                }
                else if (date == person.BirthDay)

                {
                    var child = new Person();

                    if (samePersonDictionary.Any(n => n.Key == name))
                    {
                        child.Name = name;
                        child.BirthDay = samePersonDictionary.First(n => n.Key == name).Value;
                        person.Children.Add(child);
                    }
                }
            }
            if (personToPersonRegex.IsMatch(input))
            {
                var firstPerson = personToPersonRegex.Match(input).Groups["firstPerson"].Value;
                var secondPerson = personToPersonRegex.Match(input).Groups["secondPerson"].Value;

                if (person.Name==firstPerson)
                {
                    var child = new Person();
                    if (samePersonDictionary.Any(n => n.Key == secondPerson))
                    {
                        child.Name = secondPerson;
                        child.BirthDay = samePersonDictionary.First(n => n.Key == secondPerson).Value;
                        person.Children.Add(child);
                    }
                }
                else if (secondPerson == person.Name)
                {
                    var parent = new Person();
                    if (samePersonDictionary.Any(n => n.Key == firstPerson))
                    {
                        parent.Name = firstPerson;
                        parent.BirthDay = samePersonDictionary.First(n => n.Key == firstPerson).Value;
                        person.Parents.Add(parent);
                    }
                }

            }
        }
        Console.WriteLine(person);
        Console.WriteLine("Parents:");
        foreach (var parent in person.Parents)
        {
            Console.WriteLine(parent);
        }
        Console.WriteLine("Children:");
        foreach (var child in person.Children)
        {
            Console.WriteLine(child);
        }

    }

    private static void SetInfo(Regex samePersonRegex, Person person, List<string> fullDataList, List<string> samePersonData, List<string> relationData)
    {
        if (person.Name == null)
        {
            foreach (var input in fullDataList)
            {
                if (samePersonRegex.IsMatch(input))
                {
                    samePersonData.Add(input);
                    if (samePersonRegex.Match(input).Groups["date"].Value == person.BirthDay)
                    {
                        person.Name = samePersonRegex.Match(input).Groups["name"].Value;
                        samePersonData.Remove(input);

                    }
                }
                else
                {
                    relationData.Add(input);
                }
            }
        }
        if (person.BirthDay == null)
        {
            foreach (var input in fullDataList)
            {
                if (samePersonRegex.IsMatch(input))
                {
                    samePersonData.Add(input);
                    if (samePersonRegex.Match(input).Groups["name"].Value == person.Name)
                    {
                        person.BirthDay = samePersonRegex.Match(input).Groups["date"].Value;
                        samePersonData.Remove(input);

                    }
                }
                else
                {
                    relationData.Add(input);
                }
            }
        }
    }

}

