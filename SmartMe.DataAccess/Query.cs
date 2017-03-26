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
            @"select * from PasswordSafe order by ServiceName, ServiceType";

        public static string SAVE_PASSWORD_SAFE_RECORD = @"spSavePasswordSafe";

        public static string DELETE_PASSWORD_SAFE_RECORD =
            @"delete from PasswordSafe where PasswordSafeId = ?";

    }
}
