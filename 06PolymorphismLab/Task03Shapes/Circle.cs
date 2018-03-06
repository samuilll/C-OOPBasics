using System;
using System.Collections.Generic;
using System.Text;


  public  class Circle:Shape
    {

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    private double radius;

    public double Radius
    {
        get { return radius; }
      private  set { radius = value; }
    }

    public override double CalculatePerimeter()
    {
        var perimeter = 2 * Math.PI * this.Radius;

        return perimeter;

    }

    public override double CalculateArea()
    {
        var area = Math.PI * this.Radius * this.Radius;

        return area;
    }

    public override string Draw()
    {

        var builder = new StringBuilder();

        double r_in = this.radius - 0.4;

        double r_out = this.radius + 0.4;

        for (double y = this.radius; y >= -this.radius; --y)
        {
            for (double x = -this.radius; x < r_out; x += 0.5)
            {
                double value = x * x + y * y;

                if (value >= r_in * r_in && value <= r_out * r_out)
                {
                    builder.Append("*");
                }
                else
                {
                    builder.Append(" ");
                }
            }

            builder.AppendLine();
        }

        return builder.ToString();
    }
}

