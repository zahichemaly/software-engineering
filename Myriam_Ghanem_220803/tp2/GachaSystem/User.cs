using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public abstract class BaseUser : IAccount
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public Status UserStatus { get; set; }

        public int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;
            if (DateOfBirth > today.AddYears(-age))
                age--;
            return age;
        }
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
        public abstract void Validate();
    }
}