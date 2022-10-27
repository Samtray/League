using System.Data.SqlClient;

public class TeamStat
{
        private static string select = "select * from teamStats";


        private int _id;
        private string _idTeam;
        private int _gamesPlayed;
        private int wins;
        private int losses;
        private int runsScored;
        private int runsAllowed;

    public int Id { get => _id; set => _id = value; }
        public string IdTeam { get => _idTeam; set => _idTeam = value; }
        public int GamesPlayed { get => _gamesPlayed; set => _gamesPlayed = value; }
        public int Wins { get => wins; set => wins = value; }
        public int Losses { get => losses; set => losses = value; }
        public int RunsScored { get => runsScored; set => runsScored = value; }
        public int RunsAllowed { get => runsAllowed; set => runsAllowed = value; }

    public TeamStat(int id, string idTeam, int gamesPlayed, int wins, int losses, int runsScored, int runsAllowed)
    {
        _id = id;
        _idTeam = idTeam;
        _gamesPlayed = gamesPlayed;
        this.wins = wins;
        this.losses = losses;
        this.runsScored = runsScored;
        this.runsAllowed = runsAllowed;
    }

    public TeamStat()
    {
        _id = 0;
        _idTeam = "";
        _gamesPlayed = 0;
        this.wins = 0;
        this.losses = 0;
        this.runsScored = 0;
        this.runsAllowed = 0;
    }

    public static List<TeamStat> GetAll()
    {
        SqlCommand command = new SqlCommand(select + " order by idTeam");
        return TeamStatMapper.ToList(SqlServerConnection.ExecuteQuery(command));
    }

}