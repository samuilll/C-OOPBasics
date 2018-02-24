using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class BankAccount
    {

        private int id;

        private decimal ballance;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public decimal Ballance
        {
            get { return this.ballance; }
            set { this.ballance = value; }
        }

        public override string ToString()
        {
            return $"Account ID{Id}, balance {Ballance:f2}" ;
        }

    public void Deposit(decimal amount)
    {
        this.Ballance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (this.Ballance >= amount)
        {
            this.Ballance-=amount;
        }
        else
        {
            Console.WriteLine("Insufficient balance");
        }
    }

    public BankAccount(int id)
    {
        this.Id = id;
    }
}

