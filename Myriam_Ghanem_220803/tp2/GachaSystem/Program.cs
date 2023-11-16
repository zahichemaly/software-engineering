using System;
using System.Collections.Generic;
using System.IO;



namespace GachaSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            Player player = new Player
            {
                ID = 1,
                FirstName = "Myriam",
                LastName = "Ghanem",
                DateOfBirth = new DateTime(1990, 1, 1),
                Balance = 1000,
                Pulls = 0,
                FiveStarPityCounter = 0,
                LastPullResult = PullResult.Win50_50,
                PullHistory = new List<PullHistoryEntry>()
            };
            List<GachaItem> exclusiveBannerItems = new List<GachaItem>
            {
                new GachaItem { ID = 100, Name = "Item 3-Star", ItemRarity = Rarity.ThreeStar },
                new GachaItem { ID = 200, Name = "Item 4-Star", ItemRarity = Rarity.FourStar },
                new GachaItem { ID = 300, Name = "Item 5-Star", ItemRarity = Rarity.FiveStar }
            };



            ExclusiveBanner exclusiveBanner = new ExclusiveBanner(1, "Exclusive Banner", exclusiveBannerItems, 300, DateTime.Now, DateTime.Now.AddMonths(1));



            List<GachaItem> permanentBannerItems = new List<GachaItem>
            {
                new GachaItem { ID = 301, Name = "Item 5-Star #1", ItemRarity = Rarity.FiveStar },
                new GachaItem { ID = 302, Name = "Item 5-Star #2", ItemRarity = Rarity.FiveStar },
                new GachaItem { ID = 303, Name = "Item 5-Star #3", ItemRarity = Rarity.FiveStar }
            };



            PermanentBanner permanentBanner = new PermanentBanner(2, "Permanent Banner", permanentBannerItems, 600);



            player.CurrentBanner = exclusiveBanner; 
            player.PerformPulls();



            using (StreamWriter writer = new StreamWriter("gacha.txt"))
            {
                foreach (var history in player.PullHistory)
                {
                    string pcName = Environment.MachineName;
                    string userName = Environment.UserName;
                    string rarityDescription;



                    if (history.Item.ItemRarity == Rarity.ThreeStar)
                    {
                        rarityDescription = "3-star";
                    }
                    else if (history.Item.ItemRarity == Rarity.FourStar)
                    {
                        rarityDescription = "4-star *";
                    }
                    else if (history.Item.ItemRarity == Rarity.FiveStar)
                    {
                        string bannerType = history.Banner is PermanentBanner ? "PERM" : "EXCL";
                        string win50_50 = player.LastPullResult == PullResult.Win50_50 ? "True" : "False";
                        rarityDescription = $"5-star ##### [{bannerType}] [{win50_50}]";
                    }
                    else
                    {
                        rarityDescription = "Unknown";
                    }



                   
                    string line = $"[{pcName}] [{userName}] [{history.PullNumber}] [{player.FiveStarPityCounter}] [{history.Item.ID}] {rarityDescription}";
                    writer.WriteLine(line);
                }
            }
        }
    }
}