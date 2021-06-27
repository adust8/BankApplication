using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseLibrary.Tables
{
    public class AccountIdentityNumber
    {
        [NotMapped]
        public int Id { get; set; }

        public ulong AccountNumber { get; set; }
    }
}