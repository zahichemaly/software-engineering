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
            throw new System.NotImplementedException();
        }
        public string GetFullName()
        {
            throw new System.NotImplementedException();
        }
        public abstract void Validate();
    }
}