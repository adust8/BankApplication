using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankLibrary
{
    public class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Balance{ get; set; }
        public string AccountIdentificationNumber { get; set; }

    }
}
