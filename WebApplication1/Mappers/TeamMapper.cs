using System.Data;
using System.Data.SqlClient;

public class TeamMapper
    {
    public static Team ToObject(DataRow row, string[] aliases) {

        Team team = new Team();
        team.Id = Convert.ToString(row, aliases[0]);
        team.Name = Convert.ToString(row, aliases[1]);
        team.Logo = Convert.ToString(row, aliases[2]);
        return team;
    }

    public static List<Team> ToList(DataTable dataTable) {
        List<Team> list = new List<Team>();
        foreach (DataRow row in dataTable.Rows)
        {
            list.Add(ToObject(row, new string[]{ "id", "name", "logo" }));
        }
        return list;
    }
}

