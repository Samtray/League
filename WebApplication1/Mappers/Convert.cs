using System.Data;

public class Convert
{
    public static string ToString(DataRow row, string fieldName) {
        string value = "";
        if (row[fieldName] != DBNull.Value){
            return (string)row[fieldName];
        }
        return value;
    }

    public static int ToInt(DataRow row, string fieldName)
    {
        int value = 0;
        if (row[fieldName] != DBNull.Value)
        {
            return (int)row[fieldName];
        }
        return value;
    }

    public static DateTime ToDate(DataRow row, string fieldName)
    {
        DateTime value = new DateTime();
        if (row[fieldName] != DBNull.Value)
        {
            return (DateTime)row[fieldName];
        }
        return value;
    }
}

