using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaApp
{
    public abstract class User : IAccount
    {
        public DateTime DateOfBirth { get; set; }

        public String FirstName
        {
            get => default;
            set
            {
            }
        }

        public String LastName
        {
            get => default;
            set
            {
            }
        }

        public int ID
        {
            get => default;
            set
            {
            }
        }

        public Status Status
        {
            get => default;
            set
            {
            }
        }

        public void validate() { }
        public string getFullName()
        {
            return FirstName + " " + LastName;
        }

        public int getAge()
        {
            DateTime now = DateTime.Today;
            int age = now.Year - DateOfBirth.Year;
            if (DateOfBirth > now.AddYears(-age))
                age--;
            return age;

        }
    }
}