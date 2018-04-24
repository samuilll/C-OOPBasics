using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public  class NationsBuilder
    {

    public NationsBuilder()
    {
        this.AllWarsdata = new StringBuilder();
        this.warCounter = 1;
        IniciateArmiesAndMonumentsData();
    }

    private StringBuilder AllWarsdata;

    private int warCounter;
    private void IniciateArmiesAndMonumentsData()
    {
        benders = new Dictionary<string, List<Bender>>();
        monuments = new Dictionary<string, List<Monument>>();
        benders["Air"] = new List<Bender>();
        benders["Fire"] = new List<Bender>();
        benders["Earth"] = new List<Bender>();
        benders["Water"] = new List<Bender>();
        monuments["Fire"] = new List<Monument>();
        monuments["Earth"] = new List<Monument>();
        monuments["Air"] = new List<Monument>();
        monuments["Water"] = new List<Monument>();
    }

    private Dictionary<string, List<Bender>> benders;
    private Dictionary<string, List<Monument>> monuments;

    public void AssignBender(List<string> benderArgs)
    {
        var benderType = benderArgs[0];

        benders[benderType].Add(BenderFactory.CreateBender(benderArgs));
    }
   public void AssignMonument(List<string> monumentArgs)
    {
        var monumentType = monumentArgs[0];

        monuments[monumentType].Add(MonumentFactory.CreateMonument(monumentArgs));
    }
    public string GetStatus(string nationsType)
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine(nationsType+" Nation");
        builder.Append("Benders:");
        if (benders[nationsType].Count==0)
        {
            builder.AppendLine(" None");
        }
        else
        {
            builder.AppendLine();

            foreach (var bender in benders[nationsType])
            {
                builder.Append($"{bender}\n");
            }
        }
        builder.Append("Monuments:");
        if (monuments[nationsType].Count == 0)
        {
            builder.Append(" None");
            return builder.ToString();
        }
        else
        {
            builder.AppendLine();

            foreach (var monument in monuments[nationsType])
            {
                builder.Append($"{monument}\n");
            }
        }
       
        return builder.ToString().Substring(0,builder.Length-1);
    }
    public void IssueWar(string nationsType)
    {
        this.AllWarsdata.AppendLine($"War {this.warCounter} issued by {nationsType}");

        this.warCounter++;

        Dictionary<string, double> armiesPower = new Dictionary<string, double>();

        foreach (var nation in this.benders)
        {
            double totalbendersPower = nation.Value.Select(b => b.TotalPower()).Sum();

            var monumentMultiplier = this.monuments[nation.Key].Select(m => m.GetAffinityPower()).Sum();

            var totalArmyPower =monumentMultiplier!=0?(totalbendersPower / 100)*monumentMultiplier:totalbendersPower;

            armiesPower[nation.Key] = totalArmyPower;
        }

        string winnerArmyType = armiesPower.OrderByDescending(a => a.Value).Select(a => a.Key).First();

        List<Bender> winnerBenders = benders[winnerArmyType];

        List<Monument> winnerMonuments = monuments[winnerArmyType];

        this.IniciateArmiesAndMonumentsData();

        benders[winnerArmyType] = winnerBenders;

        monuments[winnerArmyType] = winnerMonuments;

    }
    public string GetWarsRecord()
    {
        var data = this.AllWarsdata.ToString();
        if (data.Length>0)
        {
            data = data.Substring(0, data.Length - 1);
        }
        return data;
    }

}

