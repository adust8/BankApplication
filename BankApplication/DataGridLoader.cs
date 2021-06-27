using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLibrary.Tables;
using DatabaseLibrary;

namespace BankApplication
{
    public class DataGridLoader
    {
        public ulong AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public string PhoneNumber { get; set; }   
        
    }
}
