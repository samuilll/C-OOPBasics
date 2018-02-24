using System;
using System.Collections.Generic;
using System.Text;


    class Rectangle
    {

    private string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    private decimal width;

    public decimal Width
    {
        get { return width; }
        set { width = value; }
    }

    private decimal height;

    public decimal Height
    {
        get { return height; }
        set { height = value; }
    }

    private decimal[] topLeftCoordinates;

    public decimal[] TopLeftCoordinates
    {
        get { return topLeftCoordinates; }
        set { topLeftCoordinates = value; }
    }

    public Rectangle(string id, decimal width, decimal height, decimal x, decimal y)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.TopLeftCoordinates = new decimal[] { x, y };
    }

    public static bool IsIntersected(Rectangle firstFigure,Rectangle secondFigure)
    {
        var intersect = false;

        

        if (Math.Abs(firstFigure.TopLeftCoordinates[0]) < Math.Abs(secondFigure.TopLeftCoordinates[0] + secondFigure.Width))
        {
            if (Math.Abs(firstFigure.TopLeftCoordinates[0] + firstFigure.Width) >= Math.Abs(secondFigure.TopLeftCoordinates[0]))
            {
                if (firstFigure.TopLeftCoordinates[1] < Math.Abs((secondFigure.TopLeftCoordinates[1] - secondFigure.Height)))
                {
                    if (Math.Abs(firstFigure.TopLeftCoordinates[1] + firstFigure.height) >= Math.Abs(secondFigure.TopLeftCoordinates[1]))
                    {
                        intersect = true;
                    }
                }
            }
        }

        return intersect;
    }




}

