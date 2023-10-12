using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GachaSystem
{
    public class Player : BaseUser
    {
        public Player(int id, string firstName, string lastName, DateTime dateOfBirth, int balance)
       : base(id, firstName, lastName, dateOfBirth)
        {
            Balance = balance;
            Pulls = 0;
        }
        public int ID
        {
            get => default;
            set
            {
            }
        }
        public string FirstName;
        public string LastName;
        public DateTime DateOfBirth;
        int Balance;
        int Pulls;
        private void TrackPullHistory(GachaItem pulledItem, ExclusiveBanner banner)
        {
            PullHistoryEntry entry = new PullHistoryEntry(pulledItem, banner, DateTime.Now, Pulls);
            PullHistory.Add(entry);
        }
        public bool PerformPull(int cost, ExclusiveBanner banner)
            {
                if (Balance >= cost)
                {
                    Balance -= cost;
                    Pulls++;

                    GachaItem pulledItem = banner.PerformPull();

                    TrackPullHistory(pulledItem, banner);

                    Console.WriteLine($"Player performed a pull and spent {cost} points. Pulls: {Pulls}");
                    return true; 
                }
                else
                {
                    Console.WriteLine("Insufficient balance to perform a pull.");
                    return false;
                }
            }

        }


}