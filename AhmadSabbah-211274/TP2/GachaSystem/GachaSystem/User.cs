using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class BaseUser
    {
        public int ID
        {
            get => default;
            set
            {
            }
        }

        public string FisrtName
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
            throw new System.NotImplementedException();
        }

        public string GetFullName()
        {
            throw new System.NotImplementedException();
        }

        public DateTime DateOfBirth { get; set; }
    }
}