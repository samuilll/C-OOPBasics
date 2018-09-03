using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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

//Pesho Peshev 23/5/1980
//Parents:
//Stamat Peshev 11/11/1951
//Penka Pesheva 9/2/1953
//Children:
//Gancho Peshev 1/1/2005
