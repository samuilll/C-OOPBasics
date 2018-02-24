using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class GoldenEditionBook:Book
    {

    public GoldenEditionBook(string author, string title, decimal price) : base(author, title, price)
    {
    }


    protected override  decimal Price
    {
        set
        {
            base.Price = value * 1.3M;
        }
    }


}

