//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//    class Program
//    {
//        static void Main(string[] args)
//        {
//        SystemState systemState = new SystemState();

//        DraftManager manager = new DraftManager(systemState);

//        bool programOver = false;

//        while (!programOver)
//        {
//            var input = Console.ReadLine().Split().ToList();

//            switch (input[0])
//            {
//                case "RegisterHarvester":
//                    {
//                        Console.Write(manager.RegisterHarvester(input));
//                        break;
//                    }
//                case "RegisterProvider":
//                    {
//                        Console.Write(manager.RegisterProvider(input));
//                        break;
//                    }
//                case "Day":
//                    {
//                        Console.Write(manager.Day());
//                        break;
//                    }
//                case "Mode":
//                    {
//                        Console.Write(manager.Mode(input));
//                        break;
//                    }
//                case "Check":
//                    {
//                        Console.Write(manager.Check(input));
//                        break;
//                    }
//                case "Shutdown":
//                    {
//                        programOver = true;
//                        Console.Write(manager.ShutDown());
//                        break;
//                    }
//            }
//        }
//    }
//    }
