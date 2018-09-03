using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


 public   class Team
    {
    private string name;

    public string Name
    {
        get { return name; }
        private set
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.NameException);
            }
            name = value;
        }
    }

    private HashSet<Player> players;

    public Team(string teamName)
    {
        this.Name = teamName;
        this.players = new HashSet<Player>();
    }


    public void AddPlayer(Player player)
    {
        this.players.Add(player);
    }
    public void RemovePlayer(string playerName)
    {
        if (this.players.Any(p=>p.Name==playerName))
        {
            this.players.Remove(this.players.Where(p=>p.Name==playerName).First());
        }
        else
        {
            throw new ArgumentException(ExceptionMessages.MissingPlayer(playerName, this.Name));
        }
    }
    public double GetTeamRating()
    {
        if (this.players.Count>0)
        {
            return this.players.Select(p => p.GetRating()).Average();
        }

        return 0;
    }
}

