using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class Player : BaseUser
    {
        public int Balance { get; set; }
        public int Pulls { get; set; }
        public int FiveStarPityCounter { get; set; }
        public PullResult LastPullResult { get; set; }

        public List<PullHistoryEntry> PullHistory { get; set; }

        public void PerformPull(ExclusiveBanner banner)
        {
           
            if (Balance >= banner.Cost)
            {
               
                DateTime currentDate = DateTime.Now;
                if (currentDate >= banner.StartDate && currentDate <= banner.EndDate)
                {
                   
                    Balance -= banner.Cost;

                    Pulls++;

                   
                    GachaItem pulledItem = DeterminePulledItem(banner.Items);

                 
                    if (PullHistory == null)
                    {
                        PullHistory = new List<PullHistoryEntry>();
                    }

                    PullHistoryEntry historyEntry = new PullHistoryEntry
                    {
                        Item = pulledItem,
                        Banner = banner,
                        CreationDate = currentDate,
                        PullNumber = Pulls
                    };

                   
                    LastPullResult = DeterminePullResult(banner, pulledItem);

                    if (pulledItem.Rarity == Rarity.FiveStar)
                    {
                        FiveStarPityCounter = 0;
                    }
                    else
                    {
                        
                        FiveStarPityCounter++;
                    }

                  
                    PullHistory.Add(historyEntry);
                }
                else
                {
                    Console.WriteLine("Cannot perform pull. The banner is not available at the current date.");
                }
            }
            else
            {
              
                Console.WriteLine("Insufficient balance to perform a pull.");
            }
        }


        private GachaItem DeterminePulledItem(List<GachaItem> items)
        {
           
            Random random = new Random();
            int randomIndex = random.Next(items.Count);
            return items[randomIndex];
        }

        private PullResult DeterminePullResult(ExclusiveBanner banner, GachaItem pulledItem)
        {
            
            Random random = new Random();
            int randomNumber = random.Next(1, 101);

            if (randomNumber <= 50)
            {
                return PullResult.Win50_50;
            }
            else if (banner.Items.Contains(pulledItem))
            {
                return PullResult.WinExclusive;
            }
            else
            {
                return PullResult.WinPermanent;
            }
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}