using SmartMe.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
                                record.PasswordSafeId = GetInt(reader["PasswordSafeId"]);
                                record.ServiceName = GetString(reader["ServiceName"]);
                                record.Username = GetString(reader["Username"]);
                                record.Password = GetString(reader["Password"]);
                                record.ServiceType = GetString(reader["ServiceType"]);
                                record.SecurityQuestion1 = GetString(reader["SQ1"]);
                                record.SecurityAnswer1 = GetString(reader["SA1"]);
                                record.SecurityQuestion2 = GetString(reader["SQ2"]);
                                record.SecurityAnswer2 = GetString(reader["SA2"]);
                                record.SecurityQuestion3 = GetString(reader["SQ3"]);
                                record.SecurityAnswer3 = GetString(reader["SA3"]);

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

        #region Save
        public int Save(int passwordSafeId, string serviceName, string username, string password, string serviceType,
            string securityQuestion1, string securityAnswer1, string securityQuestion2, string securityAnswer2,
            string securityQuestion3, string securityAnswer3)
        {
            int newPasswordSafeId = 0;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(Query.SAVE_PASSWORD_SAFE_RECORD, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = "@passwordSafeId",
                            SqlDbType = SqlDbType.Int,
                            Value = passwordSafeId > 0 ? passwordSafeId : (object)DBNull.Value
                        });
                        sqlCommand.Parameters.Add(new SqlParameter() {
                            ParameterName = "@serviceName",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 255,
                            Value = serviceName
                        });
                        sqlCommand.Parameters.Add(new SqlParameter() {
                            ParameterName = "@serviceType",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 255,
                            Value = serviceType
                        });
                        sqlCommand.Parameters.Add(new SqlParameter() {
                            ParameterName = "@username",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 255,
                            Value = username
                        });
                        sqlCommand.Parameters.Add(new SqlParameter() {
                            ParameterName = "@password",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 255,
                            Value = password
                        });
                        sqlCommand.Parameters.Add(new SqlParameter() {
                            ParameterName = "@sq1",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 255,
                            Value = securityQuestion1 != null ? securityQuestion1 : (object)DBNull.Value
                        });
                        sqlCommand.Parameters.Add(new SqlParameter() {
                            ParameterName = "@sa1",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 255,
                            Value = securityAnswer1 != null ? securityAnswer1 : (object)DBNull.Value
                        });
                        sqlCommand.Parameters.Add(new SqlParameter() {
                            ParameterName = "@sq2",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 255,
                            Value = securityQuestion2 != null ? securityQuestion2 : (object)DBNull.Value
                        });
                        sqlCommand.Parameters.Add(new SqlParameter() {
                            ParameterName = "@sa2",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 255,
                            Value = securityAnswer2 != null ? securityAnswer2 : (object)DBNull.Value
                        });
                        sqlCommand.Parameters.Add(new SqlParameter() {
                            ParameterName = "@sq3",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 255,
                            Value = securityQuestion3 != null ? securityQuestion3 : (object)DBNull.Value
                        });
                        sqlCommand.Parameters.Add(new SqlParameter() {
                            ParameterName = "@sa3",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 255,
                            Value = securityAnswer3 != null ? securityAnswer3 : (object)DBNull.Value
                        });
                        sqlCommand.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = "@newPasswordSafeId",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.InputOutput,
                            Value = DBNull.Value
                        });

                        sqlCommand.ExecuteNonQuery();

                        if(passwordSafeId > 0)
                        {
                            newPasswordSafeId = passwordSafeId;
                        }
                        else
                        {
                            newPasswordSafeId = sqlCommand.Parameters["@newPasswordSafeId"] != null
                                ? Convert.ToInt32(sqlCommand.Parameters["@newPasswordSafeId"].Value) : 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return newPasswordSafeId;
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
