using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GachaSystem
{
    public class Player : BaseUser
    {
       
        public int Balance { get; set; }
        public int Pulls { get; set; }

        public List<PullHistoryEntry> PullHistory { get; private set; }
        public int FiveStarPityCounter { get; set; }
        public bool HasWon50_50 { get; set; }


        public Player(int id, string firstName, string lastName, DateTime dateOfBirth, Status status, int balance, int pulls)
           : base(id, firstName, lastName, dateOfBirth, status)
        {
            Balance = balance;
            Pulls = pulls;
            PullHistory = new List<PullHistoryEntry>();
            FiveStarPityCounter = 0;
            HasWon50_50 = false;
        }

        public bool PullFromBanner(Banner banner)
        {
            if (Balance >= banner.Cost)
            {
                Balance -= banner.Cost;
                Pulls++;

                var historyEntry = new PullHistoryEntry
                {
                    Item = DeterminePulledItem(banner), // Implement logic to determine the pulled item
                    Banner = banner,
                    CreationDate = DateTime.Now,
                    PullNumber = Pulls
                };

                PullHistory.Add(historyEntry);

                if (IsFiveStarItem(historyEntry.Item))
                {
                    FiveStarPityCounter = 0;
                    HasWon50_50 = false;
                }
                else
                {
                    FiveStarPityCounter++;
                    if (FiveStarPityCounter >= 60)
                    {
                        HasWon50_50 = Determine50_50Result(); // Implement 50-50 logic
                    }
                }

                return true;
            }

            return false;
        }

        private GachaItem DeterminePulledItem(Banner banner)
        {
           
            return banner.Items[0];
        }

        // Implement the logic to check if the item is a 5-star
        private bool IsFiveStarItem(GachaItem item)
        {
            // Add your logic here
            // Example: Check the rarity of the item
            return item.Rarity == Rarity.rare;
        }

        // Implement the 50-50 logic
        private bool Determine50_50Result()
        {
            // Add your logic here
            // Example: Generate a random result based on probability
            return new Random().Next(0, 2) == 0; // 50% chance of true or false
        }


    }
}