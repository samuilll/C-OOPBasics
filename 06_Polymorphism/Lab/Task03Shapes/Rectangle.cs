using System;
using System.Collections.Generic;
using System.Text;


public class Rectangle : Shape
{

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    private double height;

    public double Height
    {
        get { return height; }
        private set { height = value; }
    }

    private double width;

    public double Width
    {
        get { return width; }
        private set { width = value; }
    }

    public override double CalculatePerimeter()
    {
        var perimeter = 2 * this.Height + 2 * this.Width;

        return perimeter;
    }

    public override double CalculateArea()
    {
        var area = this.Width * this.Height;

        return area;
    }

    private string Line(double width, char end, char mid)
    {
        var line = string.Empty;

        line += end;

        for (int i = 1; i < width - 1; ++i)
        {
            line += mid;
        }

        line += end;

        return line;
    }

    public override string Draw()
    {
        var builder = new StringBuilder();

        builder.AppendLine(this.Line(this.width, '*', '*'));

        for (int i = 1; i < this.height - 1; ++i)
        {
            builder.AppendLine(this.Line(this.width, '*', ' '));
        }

        builder.Append(this.Line(this.width, '*', '*'));

        return builder.ToString();
    }
}

