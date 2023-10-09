using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public abstract class BaseUser : IAccount
    {
        public Status UserStatus; 
        public abstract void validate();
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
        public DateTime DateOfBirth { get; set; }
        public string GetFullName()
        {
           return this.FirstName + " " + this.LastName; 
        }

        public int GetAge()
        {

            return -1; 
        }

    }
}