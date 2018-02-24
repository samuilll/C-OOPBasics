using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Cat
    {
        public string Breed { get; set; }

        public string Name { get; set; }

        public double Characteristic { get; set; }

        public Cat(string breed, string name, double character)
        {
            this.Breed = breed;
            this.Name = name;
            this.Characteristic = character;
        }

        public override string ToString()
        {
            if (this.Breed == "Cymric ")
            {
                return $"{this.Breed} {this.Name} {this.Characteristic:F2}";
            }

            return $"{this.Breed} {this.Name} {(int)this.Characteristic}";
        }

    }

