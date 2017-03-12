using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMe.DataAccess
{
    public class GenericDao
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public string GetStringValue(SqlDataReader reader, string key)
        {
            return reader[key] != DBNull.Value ? (string)reader[key] : null;
        }

        public int GetIntValue(SqlDataReader reader, string key)
        {
            return reader[key] != DBNull.Value ? (int)reader[key] : 0;
        }

    }
}
