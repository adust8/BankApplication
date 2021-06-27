using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace DatabaseLibrary.Tables
{
    public class AccountDB
    {
        public int Id { get; set; }
        public decimal Balance{ get; set; }
        public int UserId{ get; set; }
        public User User{ get; set; }
        public ulong AccountIdentificationNumber{ get; set; }
        public int AccountTypeId { get; set; }
        public AccountType AccountType{ get; set; }
        public string AccountPhoneNumber { get; set; }
        public DateTime CreatingAccountDate { get; set; }
        public DateTime NextReplenishment { get; set; }
    }
}
