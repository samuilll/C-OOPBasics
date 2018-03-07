using BashSoft.Exceptions;
using BashSoft.Judge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.IO.Commands
{
    public abstract class Command
    {
        private Tester judge;
        private StudentsRepository repository;
        private IOManager inputOutputManager;

        protected Tester Judge
        {
            get { return this.judge; }
        }
        protected StudentsRepository Repository
        {
            get
            { return this.repository; }
        }
        protected IOManager InputOutputManager
        {
            get { return this.inputOutputManager; }
        }

        protected Command(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        {
            this.Input = input;
            this.Data = data;
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;          
        }

        private string input;

        public string Input
        {
            get { return input; }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                input = value;
            }
        }

        private string[] data;

        public string[] Data
        {
            get { return data; }
            protected set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }
                data = value;
            }
        }

        protected void DisplayInvalidCommandMessage(string input)
        {
            OutputWriter.DisplayException($"The command '{input}' is invalid");
        }
        public abstract void Execute();

    }
}
