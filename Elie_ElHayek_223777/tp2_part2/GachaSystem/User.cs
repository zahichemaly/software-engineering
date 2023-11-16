using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    abstract public class BaseUser : IAccount
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

        public int pityCounter { get; set; }

        public DateTime DateOfBirth { get; set; }

        static Status Status { get; set; }
        public int GetAge()
        {
            throw new System.NotImplementedException();
        }

        public string GetFullName()
        {
            throw new System.NotImplementedException();
        }

        public abstract void Validate();


    }
}