using SmartMe.DataAccess;
using SmartMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMe.Service
{
    public class AccountService
    {
        public IList<Account> GetRecords()
        {
            return new AccountDao().Get();
        }

    }
}
