using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GachaSystem
{
    public class Player : BaseUser
    {
        private List<History> history = new List<History>();
        public PitySystem pitySystem = new PitySystem();
        public int Balance { get; set; }
        public int Pulls { get; set; }
        private bool Is50_50Lost = false;
        public GachaItem SimulatePull(List<GachaItem> items)
        {
             Random random = new Random();
            int index = random.Next(items.Count);
            return items[index];
        }


        public override void validate() { 
        
        
        }

        public void PerformPull(ExclusiveBanner banner)
        {
            if (Balance >= banner.Cost)
            {
                Balance -= banner.Cost;

               
                GachaItem pulledItem = SimulatePull(banner.Items);

                int pullNumber = Pulls + 1;

                if (pulledItem!=null)
                {
                     History pullHistoryEntry = new History
                    {
                        Item = pulledItem.Name,
                        PullDate = DateTime.Now,
                        PullNumber = pullNumber
                    };

                     history.Add(pullHistoryEntry);
                    Console.WriteLine($"Player {ID} pulled {pulledItem.ItemRarity} from {banner.Name}");
                }
                else
                {
                    Console.WriteLine($"No items available to pull from {banner.Name}.");
                }


            }
            else
            {
                Console.WriteLine("Insufficient balance to perform a pull.");
            }
        }

        public void TrackPullHistory()
        {
             foreach (var entry in history)
            {
                Console.WriteLine($"{entry.PullDate} - Pulled {entry.Item} on pull {entry.PullNumber}");
            }
        }

        public void TrackPityCounter()
        {
             Console.WriteLine($"Pity Counter: {pitySystem.PityCounter}");
        }
    }
}