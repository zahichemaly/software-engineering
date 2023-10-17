using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public abstract class BaseUser : IAccount
    {
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
            return 1;
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public DateTime DateOfBirth { get; set; }

        public void Validate()
        {
           
        }

        public  Status Status
        {
            get => default;
            set
            {
            }
        }
    }
}