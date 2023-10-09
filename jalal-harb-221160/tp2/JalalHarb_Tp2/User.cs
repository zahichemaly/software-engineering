using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JalalHarb_Tp2
{
    public abstract class BaseUser : IAccount
    {
        private Status Status;

        private int ID { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }


        public int GetAge()
        {
            return DateTime.Now.Year - DateOfBirth.Year;
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public abstract void validate();
    }
}