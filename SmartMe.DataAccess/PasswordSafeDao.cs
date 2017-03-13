using SmartMe.Model;
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
    #region PasswordSafeDao
    /// <summary>
    /// 
    /// </summary>
    public class PasswordSafeDao : GenericDao
    {

        #region Get
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<PasswordSafe> Get()
        {
            IList<PasswordSafe> records = null;
            try
            {
                using (SQLiteConnection sqlConnection = new SQLiteConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SQLiteCommand sqlCommand = new SQLiteCommand(Query.GET_PASSWORD_SAFE_RECORDS, sqlConnection))
                    {
                        SQLiteDataReader reader = sqlCommand.ExecuteReader();

                        if (reader != null)
                        {
                            records = new List<PasswordSafe>();
                            while (reader.Read())
                            {
                                PasswordSafe record = new PasswordSafe();
                                record.PasswordSafeId = GetIntValue(reader, "PasswordSafeId");
                                record.ServiceName = GetStringValue(reader, "ServiceName");
                                record.Username = GetStringValue(reader, "Username");
                                record.Password = GetStringValue(reader, "Password");
                                record.ServiceType = GetStringValue(reader, "ServiceType");
                                record.SecurityQuestion1 = GetStringValue(reader, "SQ1");
                                record.SecurityAnswer1 = GetStringValue(reader, "SA1");
                                record.SecurityQuestion2 = GetStringValue(reader, "SQ2");
                                record.SecurityAnswer2 = GetStringValue(reader, "SA2");
                                record.SecurityQuestion3 = GetStringValue(reader, "SQ3");
                                record.SecurityAnswer3 = GetStringValue(reader, "SA3");

                                records.Add(record);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return records;
        }
        #endregion

        #region Insert
        public int Insert(string serviceName, string username, string password, string serviceType,
            string securityQuestion1, string securityAnswer1, string securityQuestion2, string securityAnswer2,
            string securityQuestion3, string securityAnswer3)
        {
            long passwordSafeId = 0;
            try
            {
                using (SQLiteConnection sqlConnection = new SQLiteConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SQLiteCommand sqlCommand = new SQLiteCommand(Query.SAVE_PASSWORD_SAFE_RECORD, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(serviceName);
                        sqlCommand.Parameters.Add(serviceType);
                        sqlCommand.Parameters.Add(username);
                        sqlCommand.Parameters.Add(password);
                        sqlCommand.Parameters.Add(securityQuestion1);
                        sqlCommand.Parameters.Add(securityAnswer1);
                        sqlCommand.Parameters.Add(securityQuestion2);
                        sqlCommand.Parameters.Add(securityAnswer2);
                        sqlCommand.Parameters.Add(securityQuestion3);
                        sqlCommand.Parameters.Add(securityAnswer3);

                        passwordSafeId = (long)sqlCommand.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return (int)passwordSafeId;
        }
        #endregion

        #region Update
        public bool Update(int passwordSafeId, string serviceName, string username, string password, string serviceType,
            string securityQuestion1, string securityAnswer1, string securityQuestion2, string securityAnswer2,
            string securityQuestion3, string securityAnswer3)
        {
            try
            {
                using (SQLiteConnection sqlConnection = new SQLiteConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SQLiteCommand sqlCommand = new SQLiteCommand(Query.SAVE_PASSWORD_SAFE_RECORD, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(serviceName);
                        sqlCommand.Parameters.Add(serviceType);
                        sqlCommand.Parameters.Add(username);
                        sqlCommand.Parameters.Add(password);
                        sqlCommand.Parameters.Add(securityQuestion1);
                        sqlCommand.Parameters.Add(securityAnswer1);
                        sqlCommand.Parameters.Add(securityQuestion2);
                        sqlCommand.Parameters.Add(securityAnswer2);
                        sqlCommand.Parameters.Add(securityQuestion3);
                        sqlCommand.Parameters.Add(securityAnswer3);

                        sqlCommand.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        #endregion

        #region Delete
        public bool Delete(int passwordSafeId)
        {
            return true;
        }
        #endregion

    }
    #endregion
}
