using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseLibrary
{
    public class AccountType
    {
        [NotMapped]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<User> UserList { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}