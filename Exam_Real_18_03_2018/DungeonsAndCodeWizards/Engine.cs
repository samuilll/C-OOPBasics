using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DungeonsAndCodeWizards
{
  public  class Engine
    {
        private DungeonMaster controller;

        public Engine(DungeonMaster controller)
        {
            this.controller = controller;
        }

        public void Run()
        {
            while (!this.controller.IsGameOver())
            {
                try
                {
                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Final stats:");
                        Console.WriteLine(controller.GetStats());

                        return;
                    }

                    string[] args = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string command = args[0];
                    args = args.Skip(1).ToArray();

                    
                    Type type = typeof(DungeonMaster);
                    MethodInfo method = type.GetMethods(BindingFlags.Public | BindingFlags.Instance).First(m => m.Name == command);
                    object[] objects = new object[] { args};

                    if (command=="IsGameOver"||command=="GetStats")
                    {
                        objects = null;
                    }
                          
                     string   result = method.Invoke(controller, objects).ToString();
                    

                    Console.WriteLine(result);
                }
                catch (TargetInvocationException ex)
                {
                    if (typeof(InvalidOperationException).IsAssignableFrom(ex.InnerException.GetType()))
                    {
                        Console.WriteLine("Invalid Operation: " + ex.InnerException.Message);
                    }
                    if (typeof(ArgumentException).IsAssignableFrom(ex.InnerException.GetType()))
                    {
                        Console.WriteLine("Parameter Error: " + ex.InnerException.Message);
                    }
                }
             
                //catch (Exception ex)
                //{
                //    Console.WriteLine("Exception: " + ex.Message);
                //}
                Console.ResetColor();

            }
        }
    }
}
