using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseLibrary
{
    public class User
    {
        [NotMapped]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string PhoneNumber { get; set; }
        public LoginAndPassword LoginAndPassword { get; set; }
    }
}