using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class BaseUser : IAccount
    {
        private Status Status;

        public DateTime DateOfBirth { get; set; }

        public int id
        {
            get => default;
            set
            {
            }
        }

        public string firstname
        {
            get => default;
            set
            {
            }
        }

        public string lastname
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

        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}