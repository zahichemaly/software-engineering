using System;
using System.Collections.Generic;

namespace GachaSystem
{
    public class Player : BaseUser
    {
        public int Balance { get; set; }
        public int Pulls { get; set; }
        public int PityCounter { get; set; }
        public bool FiftyFiftyStatus { get; set; }
        public List<PullHistory> PlayerPullHistory { get; set; }

        public Player(int id, string lastName, string firstName, DateTime dateOfBirth, int initialBalance, int initialPulls)
            : base(id, lastName, firstName, dateOfBirth)
        {
            Balance = initialBalance;
            Pulls = initialPulls;
            PityCounter = 0;
            PlayerPullHistory = new List<PullHistory>();
        }
        public GachaItem PerformExclusivePull(ExclusiveBanner banner)
        {
            Random random = new Random();
            int roll = random.Next(100);
            RarityEnum rarity;

            if (roll < 80)
                rarity = RarityEnum.Common;
            else if (roll < 98)
                rarity = RarityEnum.Uncommon;
            else
                rarity = RarityEnum.Rare;

            Console.WriteLine($"Rolled a {roll}. Trying to pull a {rarity} item from Exclusive Banner.");

            var possibleItems = banner.Items.FindAll(item => item.Rarity == rarity);

            if (possibleItems.Count == 0)
            {
                Console.WriteLine("No items of the specified rarity found in the banner.");
                return null;
            }

            return possibleItems[random.Next(possibleItems.Count)];
        }
        public GachaItem PerformPermanentPull(PermanentBanner banner)
        {
            Random random = new Random();
            int roll = random.Next(100);
            RarityEnum rarity = RarityEnum.Rare;

            Console.WriteLine($"Rolled a {roll}. Trying to pull a {rarity} item from Permanent Banner.");

            var possibleItems = banner.Items.FindAll(item => item.Rarity == rarity);

            if (possibleItems.Count == 0)
            {
                Console.WriteLine("No items of the specified rarity found in the banner.");
                return null;
            }

            return possibleItems[random.Next(possibleItems.Count)];
        }

        public void CheckForFiveStarPull(string bannerName)
        {
            Random random = new Random();
            bool fiftyFiftyWin = random.Next(2) == 0;

            if (fiftyFiftyWin)
            {
                Console.WriteLine($"Player won the 50-50 and got the 5-star from the Exclusive Banner.");
            }
            else
            {         
                Console.WriteLine($"Player didn't win the 50-50, next 5-star will be from the Exclusive Banner.");

                UpdatePityCounter();
            }
        }

        private void UpdatePityCounter()
        {
            PityCounter++;

            if (PityCounter >= 60)
            {
              
                PityCounter = 0;
                Console.WriteLine("Guarantee a 5-star item on the next pull.");
            }
        }
        public GachaItem PerformPull(Banner banner)
        {
            if (banner == null)
            {
                throw new ArgumentNullException(nameof(banner), "Banner cannot be null.");
            }

            if (banner.Items == null || !banner.Items.Any())
            {
                throw new InvalidOperationException("Banner does not contain any items.");
            }

            Random random = new Random();
            int roll = random.Next(100);
            RarityEnum rarity;

            if (roll < 80)
            {
                rarity = RarityEnum.Common;
            }
            else if (roll < 98)
            {
                rarity = RarityEnum.Uncommon;
            }
            else
            {
                rarity = RarityEnum.Rare;
            }

            Console.WriteLine($"Rolled a {roll}. Trying to pull a {rarity} item.");

            var possibleItems = banner.Items.Where(item => item.Rarity == rarity).ToList();

            if (rarity == RarityEnum.Uncommon && !possibleItems.Any())
            {
                Console.WriteLine("No items of 4-star rarity found in the banner.");
                return null;
            }
            if (possibleItems.Count == 0)
            {
               
                return null;
            }
            var pulledItem = possibleItems[random.Next(possibleItems.Count)];
            Console.WriteLine($"Pulled item: {pulledItem.Name} (ID: {pulledItem.ID}, Rarity: {pulledItem.Rarity})");

           //return pulledItem;
            return possibleItems[random.Next(possibleItems.Count)];
        }
    }
}
