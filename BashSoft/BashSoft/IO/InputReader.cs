using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.IO
{
   public class InputReader
    {
        private string endCommand = "quit";
        private CommandInterpreter interpreter;

        public InputReader(CommandInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommnads()
        {

            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.CurrentPath}> ");
                string input = Console.ReadLine();
                input = input.Trim();

                if (input==endCommand)
                {
                    break;
                }

                this.interpreter.InterpredCommand(input);
            }            
        }
    }
}
