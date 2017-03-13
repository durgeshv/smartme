using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMe.DataAccess
{
    public class GenericDao
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["SqliteConnection"].ConnectionString;

        public string GetStringValue(SQLiteDataReader reader, string key)
        {
            return reader[key] != DBNull.Value ? (string)reader[key] : null;
        }

        public int GetIntValue(SQLiteDataReader reader, string key)
        {
            return reader[key] != DBNull.Value ? (int)reader[key] : 0;
        }

    }
}
