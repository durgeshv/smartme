using System;
using System.Configuration;

namespace SmartMe.DataAccess
{
    public class GenericDao
    {
        protected string connectionString = ConfigurationManager.ConnectionStrings["SqlServerConnectionString"].ConnectionString;

        protected string GetString(object value)
        {
            return value != null ? value.ToString() : null;
        }

        protected int GetInt(object value)
        {
            return value != null && !string.IsNullOrEmpty(value.ToString()) ? Convert.ToInt32(value.ToString()) : 0;
        }

        protected bool GetBoolean(object value)
        {
            return value != null && !string.IsNullOrEmpty(value.ToString())
                && (value.ToString().ToLower().Equals("true") || value.ToString().Equals("1"));
        }

        protected DateTime? GetDate(object value)
        {
            return value != null && !string.IsNullOrEmpty(value.ToString()) && DateTime.Parse(value.ToString()) != null
                ? (DateTime?)Convert.ToDateTime(value.ToString()) : null;
        }

    }
}
