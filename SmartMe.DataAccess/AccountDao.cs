using SmartMe.Model;
using SmartMe.Model.enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMe.DataAccess
{
    public class AccountDao : GenericDao
    {
        #region Get
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<Account> Get()
        {
            IList<Account> records = null;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(Query.GET_ACCOUNT_RECORDS, sqlConnection))
                    {
                        SqlDataReader reader = sqlCommand.ExecuteReader();

                        if (reader != null)
                        {
                            records = new List<Account>();
                            while (reader.Read())
                            {
                                Account record = new Account();
                                record.AccountId = GetInt(reader["AccountId"]);
                                record.AccountName = GetString(reader["AccountName"]);
                                record.AccountNumber = GetString(reader["AccountNumber"]);
                                record.AccountType = (AccountType)GetInt(reader["AccountTypeId"]);
                                record.AccountTypeName = GetString(reader["AccountType"]);
                                record.RoutingNumberPaperElectronic = GetString(reader["RoutingNumberPaperElectronic"]);
                                record.RoutingNumberWires = GetString(reader["RoutingNumberWires"]);
                                record.Cvv = GetString(reader["Cvv"]);
                                record.Pin = GetString(reader["Pin"]);
                                record.Email = GetString(reader["Email"]);
                                record.Address = GetString(reader["Address"]);
                                record.Phone1 = GetString(reader["Phone1"]);
                                record.Phone2 = GetString(reader["Phone2"]);

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
    }
}
