using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GachaSystem
{
    public abstract class BaseUser : IAccount
    {
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

        public Status Status
        {
            get => default;
            set
            {
            }
        }
        public BaseUser()
        {
        }

        
        public BaseUser(int id, string firstName, string lastName, DateTime dateOfBirth, Status status)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Status = status;
        }


        public int GetAge()
        {
            return DateTime.Now.Year - DateOfBirth.Year;
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
        public void Validate()
        {

        }
    }
}