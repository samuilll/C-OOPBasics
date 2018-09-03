using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BashSoft.IO;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft
{
    class Launcher
    {
        static void Main(string[] args)
        {
           
            Tester tester = new Tester();
            IOManager ioManager = new IOManager();
            StudentsRepository repo = new StudentsRepository(new RepositoryFilter(),new RepositorySorter());

            CommandInterpreter currentInterpreter = new CommandInterpreter(tester,repo,ioManager);
            InputReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommnads();
        }
    }
}
