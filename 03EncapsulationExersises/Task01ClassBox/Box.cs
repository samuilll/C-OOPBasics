using System;
using System.Collections.Generic;
using System.Text;


public class Box
{

    private double width;
    private double height;
    private double lenght;

    public Box(double lenght,double width, double height )
    {
        this.width = width;
        this.height = height;
        this.lenght = lenght;
    }

    public double GetSurfaceArea()
    {
        return 2 * this.width * this.height + 2 * this.width * this.lenght + 2 * this.height * this.lenght;
    }
    public double GetLateralSurfaceArea()
    {
        return 2 * this.width * this.height + 2 * this.height * this.lenght;
    }
    public double GetVolume()
    {
        return this.height * this.width * this.lenght;
    }

}

