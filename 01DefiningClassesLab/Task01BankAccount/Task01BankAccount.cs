using System;
using System.Collections.Generic;

class Task01BankAccount
    {
        static void Main(string[] args)
        {

        var data = new Dictionary<int, BankAccount>();

        while (true)
        {
            var cmdArgs = Console.ReadLine().Split();
            var cmdType = cmdArgs[0];

            if (cmdType=="End")
            {
                break;
            }
            switch (cmdType)
            {
                case "Create":
                    {
                        Create(cmdArgs, data);
                        break;
                    }
                case "Deposit":
                    {
                        Deposit(cmdArgs, data);
                        break;
                    }
                case "Withdraw":
                    {
                        WithDraw(cmdArgs, data);
                        break;
                    }
                case "Print":
                    {
                        Print(cmdArgs, data);
                        break;
                    }
                default:
                    break;
            }
        }
    }

    private static void Print(string[] cmdArgs, Dictionary<int, BankAccount> data)
    {
        var id = int.Parse(cmdArgs[1]);

        if (!data.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
            return;
        }

        Console.WriteLine(data[id]);
    }

    private static void WithDraw(string[] cmdArgs, Dictionary<int, BankAccount> data)
    {
        var id = int.Parse(cmdArgs[1]);

        var amount = int.Parse(cmdArgs[2]);

        if (!data.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");

            return;
        }

        data[id].Withdraw(amount);
    }

    private static void Deposit(string[] cmdArgs, Dictionary<int, BankAccount> data)
    {
        var id = int.Parse(cmdArgs[1]);

        var amount = int.Parse(cmdArgs[2]);

        if (!data.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");

            return;
        }

        data[id].Deposit(amount);

    }

    private static void Create(string[] cmdArgs, Dictionary<int, BankAccount> data)
    {
        var id = int.Parse(cmdArgs[1]);

        if (data.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");

            return;
        }

        var account = new BankAccount(id);

        data[id] = account;
    }
}

