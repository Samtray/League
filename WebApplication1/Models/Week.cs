using System.Data.SqlClient;

public class Week
    {
    #region sql statements
    private static string select = "select id, date, status from weeks";
    #endregion
    #region attributes
    private int _id;
    private DateTime _date;
    private int _status;


    #endregion

    #region properties
    public int Id { get => _id; set => _id = value; }
    public DateTime SetDate { set => _date = value; }
    public Date Date { get => new Date(_date); }
    public int SetStatus { set => _status = value; }

    public string Status { get => ((Status)_status).ToString(); }


    #endregion

    #region constructors

    public Week()
    {
        _id = 0;
        _date = new DateTime();
        _status = 0;
    }
    public Week(int id, DateTime date, int status)
    {
        _id = id;
        _date = date;
        _status = status;
    }
    #endregion

    #region instance methods
    public static List<Week> GetAll() {
        SqlCommand command = new SqlCommand(select + " order by date");
        return WeekMapper.ToList(SqlServerConnection.ExecuteQuery(command));
    }
    # endregion
}
