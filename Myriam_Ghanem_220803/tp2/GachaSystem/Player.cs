using System;
using System.Collections.Generic;

namespace GachaSystem
{
    public class Player : BaseUser
    {
        public int Balance { get; set; }
        public int Pulls { get; set; }
        public int FiveStarPityCounter { get; set; }
        public PullResult LastPullResult { get; set; }
        public List<PullHistoryEntry> PullHistory { get; set; }
        public ExclusiveBanner CurrentBanner { get; set; } 

        public void PerformPulls()
        {
            while (Balance >= CurrentBanner.Cost)
            {
                PerformPull();
            }
        }

        private void PerformPull()
        {
            DateTime currentDate = DateTime.Now;
            if (currentDate >= CurrentBanner.StartDate && currentDate <= CurrentBanner.EndDate)
            {
                Balance -= CurrentBanner.Cost;
                Pulls++;
                GachaItem pulledItem = DeterminePulledItem();

                if (PullHistory == null)
                {
                    PullHistory = new List<PullHistoryEntry>();
                }

                PullHistoryEntry historyEntry = new PullHistoryEntry
                {
                    Item = pulledItem,
                    Banner = CurrentBanner,
                    CreationDate = currentDate,
                    PullNumber = Pulls

                };

                LastPullResult = DeterminePullResult(CurrentBanner, pulledItem);

                if (pulledItem.ItemRarity == Rarity.FiveStar)
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

        private GachaItem DeterminePulledItem()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 101);

            Rarity rarity;
            if (randomNumber <= 80)
            {
                rarity = Rarity.ThreeStar;
            }
            else if (randomNumber <= 98)
            {
                rarity = Rarity.FourStar;
            }
            else
            {
                rarity = Rarity.FiveStar;
            }

            List<GachaItem> items = CurrentBanner.Items.FindAll(item => item.ItemRarity == rarity);

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
