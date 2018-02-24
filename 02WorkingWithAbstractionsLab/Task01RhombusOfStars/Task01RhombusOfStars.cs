using System;

public class Bum
{
    private int digit;

    public int Digit
    {
        get { return digit + 5; }
        set { digit = value; }
    }
        public Bum(int digit)
    {
        this.Digit = digit;
    }
    

}

class Task01RhombusOfStars
{
    static void Main(string[] args)
    {
        Console.WriteLine(new Bum(5).Digit);
    }
}

