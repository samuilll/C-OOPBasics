using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Square
    {


    public int Size { get; set; }

    public Square(int size)
    {
        this.Size = size;
    }


    public void DrawNow()
    {
        for (int height = 0; height < this.Size; height++)
        {
            var line = new StringBuilder();

            line.Append("|");

            for (int width = 0; width < this.Size; width++)
            {
                if (height==0||height==this.Size-1)
                {
                    line.Append("-");
                }
                else
                {
                    line.Append(" ");
                }
            }
            line.Append("|");

            Console.WriteLine(line.ToString());
        }
    }
}

