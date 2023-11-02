using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public abstract class BaseUser : IAccount
    {
        private int Status;

        public DateTime DateOfbirth { get; set; }

        public int ID
        {
            get => default;
            set
            {
            }
        }

        public string Firstname
        {
            get => default;
            set
            {
            }
        }

        public string Lastname
        {
            get => default;
            set
            {
            }
        }

        public int GetAge()
        {
            throw new System.NotImplementedException();
        }

        public string GetFullName()
        {
            throw new System.NotImplementedException();
        }

        public void validate()
        {
            throw new System.NotImplementedException();
        }
    }
}