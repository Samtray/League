    public class Team
    {
    #region attributes
    private string _id;
    private string _name;
    private string _logo;
    #endregion

    #region properties
    public string Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }

    public string Logo { get => Config.Configuration.Root + Config.Configuration.Files.Logos + _logo; set => _logo = value; }

    #endregion

    #region constructors
    public Team(string id, string name, string logo)
    {
        _id = id;
        _name = name;
        _logo = logo;
    }

    public Team()
    {
        _id = "";
        _name = "";
        _logo = "";
    }

    #endregion

    #region instance methods

    #endregion

    #region class methods
    public static List<Team> GetAll()
    {
        List<Team> list = new List<Team>();

        list.Add(new Team("CHV", "Chivas", "chivas.png"));
        list.Add(new Team("AME", "America", "america.png"));
        list.Add(new Team("CRZ", "Cruz Azul", "cruzazul.png"));

        return list;
    }
    #endregion
}
