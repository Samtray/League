using System.Data;

public class GameMapper
    {
        public static Game ToObject(DataRow row) { 
            Game game = new Game();
            game.Id = Convert.ToInt(row, "gameId");
            game.Field = FieldMapper.ToObject(row, new string[] { "fieldId", "fieldName" });
            game.Week = WeekMapper.ToObject(row, new string[] { "weekId", "weekDate", "weekStatus" });
            game.Home = TeamMapper.ToObject(row, new string[] { "homeId", "homeName", "homeLogo" });
            game.HomeScore = Convert.ToInt(row, "homeScore");
            game.Visitor = TeamMapper.ToObject(row, new string[] { "visitorId", "visitorName", "visitorLogo" });
            game.VisitorScore = Convert.ToInt(row, "visitorScore");
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
