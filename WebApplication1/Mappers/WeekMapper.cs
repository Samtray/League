
using System.Data;

public class WeekMapper
    {
    public static Week ToObject(DataRow row, string[] aliases)
    {
        Week week = new Week();
        week.Id = Convert.ToInt(row, aliases[0]);
        week.SetDate = Convert.ToDate(row, aliases[1]);
        week.SetStatus = Convert.ToInt(row, aliases[2]);
        return week;
    }

    public static List<Week> ToList(DataTable dataTable)
    {
        List<Week> list = new List<Week>();
        foreach (DataRow row in dataTable.Rows)
        {
            list.Add(ToObject(row, new string[] { "id", "date", "status" }));
        }
        return list;
    }
}
