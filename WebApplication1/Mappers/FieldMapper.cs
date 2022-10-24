using System.Data;

public class FieldMapper
    {
    public static Field ToObject(DataRow row, string[] aliases) 
    {
        Field field = new Field();
        field.Id = Convert.ToString(row, aliases[0]);
        field.Name = Convert.ToString(row, aliases[1]);
        return field;
    }

    public static List<Field> ToList(DataTable dataTable)
    {
        List<Field> list = new List<Field>();
        foreach (DataRow row in dataTable.Rows)
        {
            list.Add(ToObject(row, new string[] { "id", "name" }));
        }
        return list;
    }
}
