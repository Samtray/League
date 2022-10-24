
using System.Data.SqlClient;

public class Field
{
    #region sql statements
        private static string select = "select id, name from fields";
        #endregion

        #region attributes
        private string _id;
            private string _name;
            #endregion

        #region properties
        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        #endregion

        #region constructors
        public Field(string id, string name)
        {
            _id = id;
            _name = name;
        }

        public Field()
        {
            _id = "";
            _name = "";
        }

        #endregion

        #region instance methods

        #endregion

        #region class methods
        public static List<Field> GetAll() {
            SqlCommand command = new SqlCommand(select + " order by name");
            return FieldMapper.ToList(SqlServerConnection.ExecuteQuery(command));
        }
        #endregion

    }

