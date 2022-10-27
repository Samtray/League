using System.Data;

public class TeamStatMapper
    {
    public static TeamStat ToObject(DataRow row, string[] aliases)
    {
        TeamStat ts = new TeamStat();
        ts.Id = Convert.ToInt(row, aliases[0]);
        ts.IdTeam = Convert.ToString(row, aliases[1]);
        ts.GamesPlayed = Convert.ToInt(row, aliases[2]);
        ts.Wins = Convert.ToInt(row, aliases[3]);
        ts.Losses = Convert.ToInt(row, aliases[4]);
        ts.RunsScored = Convert.ToInt(row, aliases[5]);
        ts.RunsAllowed = Convert.ToInt(row, aliases[6]);
        return ts;
    }

    public static List<TeamStat> ToList(DataTable dataTable)
    {
        List<TeamStat> list = new List<TeamStat>();
        foreach (DataRow row in dataTable.Rows)
        {
            list.Add(ToObject(row, new string[] { "id", "idTeam", "gamesPlayed", "wins", "losses", "runsScored", "runsAllowed" }));
        }
        return list;
    }
}
