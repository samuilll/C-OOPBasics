using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Rectangle
    {

    public int Width { get; set; }

    public int Height { get; set; }

    public Rectangle(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public void DrawNow()
    {
        for (int height = 0; height < this.Height; height++)
        {
            var line = new StringBuilder();

            line.Append("|");

            for (int width = 0; width < this.Width; width++)
            {
                if (height == 0 || height == this.Height-1)
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

