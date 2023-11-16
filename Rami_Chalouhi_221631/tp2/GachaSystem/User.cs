using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public abstract class BaseUser : IAccount
    {
        private Status Status;

        public DateTime DateOfBirth { get; set; }
        public int ID
        {
            get => default;
            set
            {
            }
        }

        public string FirstName
        {
            get => default;
            set
            {
            }
        }

        public string LastName
        {
            get => default;
            set
            {
            }
        }

        public int GetAge()
        {
            return DateTime.Now.Year - DateOfBirth.Year;
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public abstract void Validate();  
           
    }
}