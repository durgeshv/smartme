using SmartMe.DataAccess;
using SmartMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMe.Service
{
    public class PasswordSafeService
    {
        public IList<PasswordSafe> GetRecords()
        {
            return new PasswordSafeDao().GetRecords();
        }

        public bool SaveRecord(PasswordSafe record)
        {

        }
    }
}
