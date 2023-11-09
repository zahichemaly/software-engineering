using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class Player : BaseUser
    {
        public int ID { get; set; }

        public string FirstName { get ;set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Balance { get; set; }

        public int Pulls { get; set; }

        public int PityCounter { get; set; }

        public bool FiftyFiftyStatus { get; set; }

        public List<History> PullHistories { get; set; }

        public Player()
        {
            PullHistories = new List<History>();
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
            Rarity rarity;

            if (roll < 80)
            {
                rarity = Rarity.THREE_STARS;
            }
            else if (roll < 98)
            {
                rarity = Rarity.FOUR_STARS;
            }
            else
            {
                rarity = Rarity.FIVE_STARS;
            }

            Console.WriteLine($"Rolled a {roll}. Trying to pull a {rarity} item.");

            var possibleItems = banner.Items.Where(item => item.Rarity == rarity).ToList();

            if (rarity == Rarity.FOUR_STARS && !possibleItems.Any())
            {
                Console.WriteLine("No items of 4-star rarity found in the banner.");
                return null; 
            }

            return possibleItems[random.Next(possibleItems.Count)];
        }




        public override void validate()
        {
           
        }
    }
}