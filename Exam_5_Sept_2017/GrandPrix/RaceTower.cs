using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


  public  class RaceTower
    {
    public RaceTower()
    {
        this.competitors = new List<Driver>();
        this.OutOfTheGamePlayers = new Dictionary<string, string>();
        this.weather = "Sunny";
        this.currentLap = 0;
        this.IsInProgress = true;
    }

    public bool IsInProgress { get;private set; }
    private int currentLap;
    private int LapsNumber ;
    private int TrackLenght ;
    public Driver Winner { get; private set; }
    private List<Driver> competitors;
    private Dictionary<string, string> OutOfTheGamePlayers;
    private string weather;
  public  void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.LapsNumber = lapsNumber;
        this.TrackLenght = trackLength;
    }
  public  void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            Driver driver =new DriverFactory().CreateDriver(commandArgs);
            this.competitors.Add(driver);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); ;
        }
    }

 public   void DriverBoxes(List<string> commandArgs)
    {
        string boxType = commandArgs[0];
        string driverName = commandArgs[1];

        if (boxType== "ChangeTyres")
        {
            var tyreToAdd =new TyreFactory().CreateTyre(commandArgs.Skip(2).ToList());
            this.competitors.FirstOrDefault(c=>c.Name==driverName).ChangeTyres(tyreToAdd);
        }
        else
        {
            double fuelToAdd = double.Parse(commandArgs[2]);
            this.competitors.FirstOrDefault(c => c.Name == driverName).Refuel(fuelToAdd);
        }
    }



    public  string CompleteLaps(List<string> commandArgs)
    {
        var builder = new StringBuilder();

        int labsToAdd = int.Parse(commandArgs[0]);

        if (this.currentLap+labsToAdd>this.LapsNumber)
        {
            builder.AppendLine ($"There is no time! On lap {this.currentLap}.");
            return builder.ToString();
        }


        var drivers = this.competitors;

      
        for (int i = 1; i <= labsToAdd; i++)
        {
            foreach (var driver in drivers)
            {
                try
                {
                    driver.DriveOneLap(this.TrackLenght);
                }
                catch (ArgumentException ex)
                {
                    this.OutOfTheGamePlayers[driver.Name] = ex.Message;
                }
            }
            RemoveCrashedPlayers(drivers);
            this.CompetitorsTryToOvertake(drivers, i + this.currentLap, builder);
            RemoveCrashedPlayers(drivers);
        }
        this.currentLap += labsToAdd;
        this.competitors = drivers;
        if (this.currentLap == this.LapsNumber)
        {
            this.Winner = this.competitors.OrderBy(c => c.TotalTime).First();
            this.IsInProgress = false;
        }
        return builder.ToString();
    }

    private void RemoveCrashedPlayers(List<Driver> drivers)
    {
        foreach (var pair in this.OutOfTheGamePlayers)
        {
            if (drivers.Any(d => d.Name == pair.Key))
            {
                drivers.Remove(drivers.Find(d => d.Name == pair.Key));
            }
        }
    }

    private void CompetitorsTryToOvertake(List<Driver> drivers, int lap,StringBuilder builder)
    {
        drivers = drivers.OrderBy(c => c.TotalTime).ToList();
        
        for (int i = 0; i < this.competitors.Count-1; i++)
        {
            double timeSpan = drivers[i + 1].TotalTime - drivers[i].TotalTime;

            bool aggressiveCrashCheck = this.weather == "Foggy" && drivers[i].GetType().Name == "AgressiveDriver" && drivers[i].Car.Tyre.GetType().Name == "UltrasoftTyre" && timeSpan < 3;

            bool enduranceCrashCheck = this.weather == "Rainy" && drivers[i].GetType().Name == "EnduranceDriver" && drivers[i].Car.Tyre.GetType().Name == "HardTyre" && timeSpan < 3;

            if (aggressiveCrashCheck)
            {
           //     this.Competitors.Remove(this.Competitors.First(c => c.Name == drivers[i].Name));
                this.OutOfTheGamePlayers[drivers[i].Name] = "Crashed";
            }
           else if (enduranceCrashCheck)
            {
             //   this.Competitors.Remove(this.Competitors.First(c => c.Name == drivers[i].Name));
                this.OutOfTheGamePlayers[drivers[i].Name] = "Crashed";
            }
            else if (timeSpan<=2)
            {
                drivers[i].DecreaseTime(timeSpan);
                drivers[i + 1].IncreaseTime(timeSpan);
              builder.AppendLine($"{drivers[i].Name} has overtaken {drivers[i+1].Name} on lap {lap}.");
            }
        }
        
    }

    public  string GetLeaderboard()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"Lap {this.currentLap}/{this.LapsNumber}");

        int counter = 1;
        foreach (var driver in this.competitors.OrderBy(d=>d.TotalTime))
        {
            builder.AppendLine($"{counter} {driver.Name} {driver.TotalTime:f3}");
            counter++;
        }
        foreach (var driverFailurePair in this.OutOfTheGamePlayers.Reverse())
        {
            builder.AppendLine($"{counter} {driverFailurePair.Key} {driverFailurePair.Value}");
            counter++;
        }

        return builder.ToString(); ;
    }

  public  void ChangeWeather(List<string> commandArgs)
    {
        string weather = commandArgs[0];
        this.weather = weather;
    }

}

