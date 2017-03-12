using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMe.Model
{
    public class PasswordSafe
    {
        public int PasswordSafeId { get; set; }
        public string ServiceName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ServiceType { get; set; }
        public string SecurityQuestion1 { get; set; }
        public string SecurityAnswer1 { get; set; }
        public string SecurityQuestion2 { get; set; }
        public string SecurityAnswer2 { get; set; }
        public string SecurityQuestion3 { get; set; }
        public string SecurityAnswer3 { get; set; }

    }
}
