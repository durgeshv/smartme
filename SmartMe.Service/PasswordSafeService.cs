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
            return new PasswordSafeDao().Get();
        }

        public int SaveRecord(int passwordSafeId, string serviceName, string serviceType, string username, string password, 
            string secretQuestion1, string secretAnswer1, string secretQuestion2, string secretAnswer2, string secretQuestion3, string secretAnswer3)
        {
            int newPasswordSafeId = 0;
            if(passwordSafeId > 0)
            {
                newPasswordSafeId = new PasswordSafeDao().Insert(serviceName, username, password, serviceType, 
                    secretQuestion1, secretAnswer1, secretQuestion2, secretAnswer2, secretQuestion3, secretAnswer3);
            }
            else
            {
                bool updated = new PasswordSafeDao().Update(passwordSafeId, serviceName, username, password, serviceType,
                    secretQuestion1, secretAnswer1, secretQuestion2, secretAnswer2, secretQuestion3, secretAnswer3);
                newPasswordSafeId = passwordSafeId;
            }
            return newPasswordSafeId;
        }
    }
}
