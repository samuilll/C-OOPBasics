using System;
using System.Collections.Generic;
using System.Text;


public class Box
{
    private double width;
    private double height;
    private double length;

    public double Width
    {
        private get { return this.width; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }
    public double Height
    {
        get { return this.height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            this.height = value;
        }
    }
    public double Length
    {
        get { return this.length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }

    public Box(double length, double width, double height)
    {
        this.Width = width;
        this.Height = height;
        this.Length = length;
    }

    public double GetSurfaceArea()
    {
        return 2 * this.width * this.height + 2 * this.width * this.length + 2 * this.height * this.length;
    }
    public double GetLateralSurfaceArea()
    {
        return 2 * this.width * this.height + 2 * this.height * this.length;
    }
    public double GetVolume()
    {
        return this.height * this.width * this.length;
    }
}

