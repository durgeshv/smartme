using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMe.DataAccess
{
    public class Query
    {
        public static string GET_PASSWORD_SAFE_RECORDS =
            @"select * from PasswordSafe";

        public static string INSERT_PASSWORD_SAFE_RECORD =
            @"insert into PasswordSafe (Service, ServiceType, Username, Password, SQ1, SA1, SQ2, SA2, SQ3, SA3) values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

        public static string UPDATE_PASSWORD_SAFE_RECORD =
            @"udpate PasswordSafe set Service = ?, ServiceType = ?, Username = ?, Password = ?, 
                SQ1 = ?, SA1 = ?, SQ2 = ?, SA2 = ?, SQ3 = ?, SA3 = ?) where PasswordSafeId = ?";

        public static string DELETE_PASSWORD_SAFE_RECORD =
            @"delete from PasswordSafe where PasswordSafeId = ?";

    }
}
