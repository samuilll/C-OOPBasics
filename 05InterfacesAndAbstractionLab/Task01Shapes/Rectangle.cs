using System;
using System.Collections.Generic;
using System.Text;


  public  class Rectangle:IDrawable
    {
    private int width;

    public int Width
    {
        get { return width; }
      private  set { width = value; }
    }

    private int height;

    public int Height
    {
        get { return height; }
       private set { height = value; }
    }

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void Draw()
    {
        this.DrawLine(this.width, '*', '*');

        for (int i = 1; i < this.height - 1; ++i)
        {
            this.DrawLine(this.width, '*', ' ');
        }

        this.DrawLine(this.width, '*', '*');
    }

    private void DrawLine(double width, char end, char mid)
    {
        Console.Write(end);

        for (int i = 1; i < width - 1; ++i)
        {
            Console.Write(mid);
        }

        Console.WriteLine(end);
    }

}

