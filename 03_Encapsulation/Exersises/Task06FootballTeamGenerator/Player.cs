using System;
using System.Collections.Generic;
using System.Text;


  public  class Player
    {
    private string name;

    public string Name
    {
        get { return name; }
       private set
        {
            if (String.IsNullOrEmpty(value)||String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.NameException);
            }
            name = value;
        }
    }
    //endurance, sprint, dribble, passing and shooting
    private int endurance;

    private int Endurance
    {
        get { return endurance; }
        set
        {
            if ( value<0 || value >100)
            {
                throw new ArgumentException(ExceptionMessages.StatException(nameof(this.Endurance)));
            }
            endurance = value;
        }
    }

    private int sprint;

    private int Sprint
    {
        get { return sprint; }
         set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException(ExceptionMessages.StatException(nameof(this.Sprint)));
            }
            sprint = value;
        }
    }

    private int dribble;

    private int Dribble
    {
        get { return dribble; }
         set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException(ExceptionMessages.StatException(nameof(this.Dribble)));
            }
            dribble = value;
        }
    }

    private int passing;

    private int Passing
    {
        get { return passing; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException(ExceptionMessages.StatException(nameof(this.Passing)));
            }
            passing = value;
        }
    }

    private int shooting;

    private int Shooting
    {
        get { return shooting; }
         set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException(ExceptionMessages.StatException(nameof(this.Shooting)));
            }
            shooting = value;
        }
    }

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }

    public double GetRating()
    {
        return ((this.Endurance + this.Dribble + this.Passing + this.Shooting + this.Sprint) /5.0);
    }


}

