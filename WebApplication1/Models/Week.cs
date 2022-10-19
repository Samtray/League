    public class Week
    {
    #region attributes
    private int _id;
    private DateTime _date;
    private int _status;


    #endregion

    #region properties
    public int Id { get => _id; set => _id = value; }
    public DateTime Date { get => _date; }
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
        List<Week> list = new List<Week>();
        list.Add(new Week(1, new DateTime(2022 - 10 - 9), 2));
        list.Add(new Week(2, new DateTime(2022 - 10 - 16), 1));
        list.Add(new Week(3, new DateTime(2022 - 10 - 22), 0));
        return list;
    }
    # endregion
}
