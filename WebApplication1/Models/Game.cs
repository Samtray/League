using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Text.Json;
public class Game
{
    #region sql statements
    private static string select = "select * from VW_getGames";
    #endregion

    #region attributes
    private int _id;
    private Week _week;
    private Field _field;
    private Team _home;
    private int _homeScore;
    private Team _visitor;
    private int _visitorScore;
    private int _status;
    private TimeSpan _time;
    #endregion

    #region properties
    public int Id { get => _id; set => _id = value; }
    public Week Week { get => _week; set => _week = value; }
    public Field Field { get => _field; set => _field = value; }
    public Team Home { get => _home; set => _home = value; }
    public int HomeScore { get => _homeScore; set => _homeScore = value; }
    public Team Visitor { get => _visitor; set => _visitor = value; }
    public int VisitorScore { get => _visitorScore; set => _visitorScore = value; }
    public int SetStatus { set => _status = value; }
    public string Status { get => ((Status)_status).ToString(); }
    public TimeSpan Time { get => _time; set => _time = value; }


    #endregion

    #region contructors
    public Game(int id, Week week, Field field, Team home, int homeScore, Team visitor, int visitorScore, int status)
    {
        _id = id;
        _week = week;
        _field = field;
        _home = home;
        _homeScore = homeScore;
        _visitor = visitor;
        _visitorScore = visitorScore;
        _status = status;
    }

    public Game()
    {
        _id = 0;
        _week = new Week();
        _field = new Field();
        _home = new Team();
        _homeScore = 0;
        _visitor = new Team();
        _visitorScore = 0;
        _status = 0;
    }
    #endregion

    #region class methods

    public static int Finish(int id, int scoreVisitor, int scoreHome) {
        string statement = "spFinishGame";
        SqlCommand command = new SqlCommand(statement);
        command.Parameters.AddWithValue("@idGame", id);
        command.Parameters.AddWithValue("@scoreVisitor", scoreVisitor);
        command.Parameters.AddWithValue("@scoreHome", scoreHome);
        return SqlServerConnection.ExecuteProcedure(command);
    }

    public static List<Game> GetAll()
    {
        SqlCommand command = new SqlCommand(select);
        return GameMapper.ToList(SqlServerConnection.ExecuteQuery(command));
    }
    #endregion
}
