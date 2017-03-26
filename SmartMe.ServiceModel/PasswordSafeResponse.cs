using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMe.ServiceModel
{
    public class PasswordSafeResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }

        public int PasswordSafeId { get; set; }
    }
}
