public class Date
{
    #region attributes
    private DateTime _value;
    #endregion

    #region properties
    public DateTime Value { get => _value; set => _value = value; }
    public string Formatted { get => _value.ToString(Config.Configuration.Format.Date); }
    #endregion

    #region constructors
    public Date(DateTime date) { 
        _value = date;
    }
    #endregion

}
