using System;
using System.Collections.Generic;
using System.Text;


   public class ExceptionMessages
    {

    public const string NameException = "A name should not be empty.";

    public static string StatException(string stat)
    {
        return $"{stat} should be between 0 and 100.";
    }

    public static string MissingPlayer(string playerName, string teamName)
    {
        return $"Player {playerName} is not in {teamName} team.";
    }
    public static string MissingTeamException(string teamName)
    {
        return $"Team {teamName} does not exist.";
    }
    
}

