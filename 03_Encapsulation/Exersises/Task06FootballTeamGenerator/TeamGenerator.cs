using System;
using System.Collections.Generic;
using System.Text;


    class TeamGenerator
    {

    private Dictionary<string,Team> teams;

   

    public void AddTeam(string teamName)
    {
        this.teams[teamName] = new Team(teamName);
    }
    public void AddPlayerToTheTeam(string teamName, Player player)
    {
        if (!teams.ContainsKey(teamName))
        {
            throw new ArgumentException(ExceptionMessages.MissingTeamException(teamName));
        }

        this.teams[teamName].AddPlayer(player);
    }
    public void RemovePlayerToTheTeam(string teamName, string playerName)
    {
        if (!teams.ContainsKey(teamName))
        {
            throw new ArgumentException(ExceptionMessages.MissingTeamException(teamName));
        }
        if (true)
        {
            this.teams[teamName].RemovePlayer(playerName);
        }
    }
    public double ShowStat(string teamName)
    {
        if (!teams.ContainsKey(teamName))
        {
            throw new ArgumentException(ExceptionMessages.MissingTeamException(teamName));
        }

       return this.teams[teamName].GetTeamRating();
    }

    public TeamGenerator()
    {
        this.teams = new Dictionary<string, Team>();
    }
    public bool ThereIsSuchATeam(string teamName)
    {
        return teams.ContainsKey(teamName);
    }

}

