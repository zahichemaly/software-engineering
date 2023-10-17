using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace husseinhajj_tp2
{
    public abstract class BaseUser : IAccount
    {

        protected BaseUser(int id, string firstName, string lastName, DateTime dateOfBirth, bool fiftyFiftyStatus, int pityCounter, int pulls, Status status, int balance)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            FiftyFiftyStatus = fiftyFiftyStatus;
            PityCounter = pityCounter;
            Pulls = pulls;
            Status = status;
            Balance = balance;
        }

        private int ID { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool FiftyFiftyStatus { get; set; }
        public int PityCounter { get; set; }
        public int Pulls { get; set; }
        public Status Status { get; set; }
        public int Balance { get; set; }
        public List<PullHistory> PullHistory { get; set; }



        public int GetAge()
        {
            return DateTime.Now.Year - DateOfBirth.Year;
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public abstract void validate();
    }
}
