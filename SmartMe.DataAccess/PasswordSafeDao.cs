using SmartMe.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

        #region GetRecords
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<PasswordSafe> GetRecords()
        {
            IList<PasswordSafe> records = null;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(Query.GET_PASSWORD_SAFE_RECORDS, sqlConnection))
                    {
                        SqlDataReader reader = sqlCommand.ExecuteReader();

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
            catch(Exception ex)
            {
                throw ex;
            }
            return records;
        }
        #endregion

        #region SaveRecord
        public bool SaveRecord(int passwordSafeId, string serviceName, string username, string password, string serviceType, 
            string securityQuestion1, string securityAnswer1, string securityQuestion2, string securityAnswer2, 
            string securityQuestion3, string securityAnswer3)
        {
            try
            {

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
    #endregion
}
