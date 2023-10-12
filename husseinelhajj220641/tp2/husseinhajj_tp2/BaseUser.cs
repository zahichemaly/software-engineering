using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace husseinhajj_tp2
{
    abstract public class BaseUser : IAccount
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Status Status
        {
            get => default;
            set
            {
            }
        }

        public BaseUser(int id, string firstName, string lastName, DateTime dateOfBirth)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public int GetAge()
        {
            int currentYear = DateTime.Now.Year;
            return currentYear - DateOfBirth.Year;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        abstract public void validate();
   
    }
}
