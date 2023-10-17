using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GachaSystem
{
    public  class Player : BaseUser
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Balance { get; set; }

        public int Pulls { get; set; }

        public int PityCounter { get; set; }

        public bool FiftyFiftyStatus { get; set; }

        public List<HistoryEntry> PullHistories { get; set; }

         new Rarity rarity { get; set; }

        public GachaItem PerformPull(Banner banner)
        {
            if (this.Balance < banner.Cost)
            {
                throw new InvalidOperationException("Not enough balance to perform pull");
            }

             if (!banner.IsBannerActive())
            {
                throw new InvalidOperationException("Cannot pull from inactive banner.");
            }

            var possibleItems = banner.Items.Where(item => item.Rarity == rarity).ToList();

            if (rarity == Rarity.FOUR_STARS && !possibleItems.Any())
            {
                Console.WriteLine("No items of 4-star rarity found in the banner.");
                return null;
            }

            Balance -= banner.Cost;
            Pulls += 1;

            Random random = new Random();
            if (possibleItems.Any())
            {
                int randomIndex = random.Next(possibleItems.Count);
                return possibleItems[randomIndex];
            }
            else
            {
                return null;
            }
        }



        private void UpdatePullHistory(GachaItem item, Banner banner) { 
        
        }
        public override void validate()
        {


        }

    }
}