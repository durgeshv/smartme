using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMe.DataAccess
{
    public class Query
    {
        #region Password Safe
        public static string GET_PASSWORD_SAFE_RECORDS =
            @"select * from PasswordSafe order by ServiceName, ServiceType";

        public static string SAVE_PASSWORD_SAFE_RECORD = @"spSavePasswordSafe";

        public static string DELETE_PASSWORD_SAFE_RECORD =
            @"delete from PasswordSafe where PasswordSafeId = ?";
        #endregion

        #region Account
        public static string GET_ACCOUNT_RECORDS =
            @"select a.AccountId, a.AccountName, a.AccountNumber, a.AccountTypeId, at.Name as AccountType, 
	            a.RoutingNumberPaperElectronic, a.RoutingNumberWires, a.CVV, a.PIN, a.Email, a.[Address], a.Phone1, a.Phone2  
            from Account a
            inner join AccountType at on a.AccountTypeId = at.AccountTypeId
            order by AccountId ";
        #endregion
    }
}
