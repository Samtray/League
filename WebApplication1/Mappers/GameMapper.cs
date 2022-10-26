using System.Data;

public class GameMapper
    {
        public static Game ToObject(DataRow row) { 
            Game game = new Game();
            game.Id = Convert.ToInt(row, "id");
            game.Time = Convert.ToTime(row, "time");
            game.Field = FieldMapper.ToObject(row, new string[] { "idField", "fieldName" });
            game.Week = WeekMapper.ToObject(row, new string[] { "idWeek", "date", "status" });
            game.Home = TeamMapper.ToObject(row, new string[] { "idTeamHome", "homeName", "homeLogo" });
            game.HomeScore = Convert.ToInt(row, "scoreHome");
            game.Visitor = TeamMapper.ToObject(row, new string[] { "idTeamVisitor", "visitorName", "visitorLogo" });
            game.VisitorScore = Convert.ToInt(row, "scoreVisitor");
            game.SetStatus = Convert.ToInt(row, "status");
            return game;
        }

        public static List<Game> ToList(DataTable dataTable)
        {
            List<Game> list = new List<Game>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(ToObject(row));
            }
            return list;
        }

}
