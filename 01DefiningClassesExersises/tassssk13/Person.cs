using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Person
    {
        public string Name { get; set; }
        public string BirthDay { get; set; }
        public List<Person> Parents { get; set; }
        public List<Person> Children { get; set; }

        public Person()
        {
            this.Children = new List<Person>();
            this.Parents = new List<Person>();
        }
        public override string ToString()
        {
            return $"{this.Name} {this.BirthDay}";
        }
    }

