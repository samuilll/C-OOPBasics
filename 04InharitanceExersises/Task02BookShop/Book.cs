using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Book
    {

    protected string title;

    protected string Title
    {
        get { return title; }
        set
        {
            if (value.Length<3)
            {
                throw new ArgumentException(ExceptionMessages.TitleException);
            }
            title = value;
        }
    }

    protected string author;

    protected string Author
    {
        get { return author; }
        set
        {
            var indexOfSpace = value.IndexOf(' ');

            if (indexOfSpace > 0 && indexOfSpace < value.Length - 1 && char.IsDigit(value[indexOfSpace + 1]))
            {
                throw new ArgumentException(ExceptionMessages.AuthorException);
            }
            author = value;
        }
    }

    protected decimal price;

    protected virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value<=0)
            {
                throw new ArgumentException(ExceptionMessages.PriceException);
            }
            price = value;
        }
    }

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("Type: ").AppendLine(this.GetType().Name)
         .Append("Title: ").AppendLine(this.Title)
          .Append("Author: ").AppendLine(this.Author)
           .Append("Price: ").Append($"{ this.Price:f2}")
           .AppendLine();
        return sb.ToString();
    }

}

