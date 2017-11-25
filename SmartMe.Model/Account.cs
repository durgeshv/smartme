using SmartMe.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMe.Model
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public string AccountTypeName { get; set; }
        public string RoutingNumberPaperElectronic { get; set; }
        public string RoutingNumberWires { get; set; }
        public string Cvv { get; set; }
        public string Pin { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }

    }
}
