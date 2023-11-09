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


        public int GetAge()
        {
            return DateTime.Now.Year - DateOfBirth.Year;
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
        public abstract void Validate();

        public Status UserStatus { get; set; }
    }
}