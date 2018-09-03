using System;
using System.Collections.Generic;
using System.Linq;

class Task06CompanyRoster
    {
        static void Main(string[] args)
        {
        var commandsNumber = int.Parse(Console.ReadLine());

        var departments = new Dictionary<string, List<Employee>>();

        StoreTheInformation(commandsNumber, departments);

        PrintTheResult(departments);
    }
    private static void PrintTheResult(Dictionary<string, List<Employee>> departments)
    {
        var highestSalaryDeaprtment = departments
            .OrderByDescending(n => n.Value.Average(e => e.Salary))
            .First()
            .Value;

        Console.WriteLine($"Highest Average Salary: {highestSalaryDeaprtment[0].Department}");

        foreach (var employee in highestSalaryDeaprtment.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
        }
    }

    private static void StoreTheInformation(int commandsNumber, Dictionary<string, List<Employee>> departments)
    {
        for (int i = 0; i < commandsNumber; i++)
        {
            var cmdArgs = Console.ReadLine().Split();

            var name = cmdArgs[0];
            var salary = decimal.Parse(cmdArgs[1]);
            var position = cmdArgs[2];
            var department = cmdArgs[3];

            Employee currentEmployee;

            if (cmdArgs.Length == 6)
            {
                var email = cmdArgs[4];
                var age = int.Parse(cmdArgs[5]);

                currentEmployee = new Employee(name, salary, position, department, age, email);
            }
            else if (cmdArgs.Length == 5 && Int32.TryParse(cmdArgs[4], out int age))
            {
                currentEmployee = new Employee(name, salary, position, department, age);
            }
            else if (cmdArgs.Length == 5)
            {
                var email = cmdArgs[4];

                currentEmployee = new Employee(name, salary, position, department, email);

            }
            else
            {
                currentEmployee = new Employee(name, salary, position, department);

            }

            if (!departments.ContainsKey(department))
            {
                departments[department] = new List<Employee>();
            }
            departments[department].Add(currentEmployee);
        }
    }
}

