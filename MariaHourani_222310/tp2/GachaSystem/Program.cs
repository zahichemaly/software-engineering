using System;
using System.Collections.Generic;
using System.IO;

namespace GachaSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            Player player = new Player(1, "Doe", "John", DateTime.Now.AddYears(-20), 1000, 0);

            List<GachaItem> exclusiveItems = new List<GachaItem>
            {
                new GachaItem(100, "Item1", RarityEnum.Common),
                new GachaItem(200, "Item2", RarityEnum.Uncommon),
                new GachaItem(300, "Item3", RarityEnum.Rare)
            };
            ExclusiveBanner exclusiveBanner = new ExclusiveBanner(1, "Exclusive Banner", exclusiveItems, 10, DateTime.Now, DateTime.Now.AddMonths(1));

            List<GachaItem> permanentItems = new List<GachaItem>
            {
                new GachaItem(301, "Item1", RarityEnum.Rare),
                new GachaItem(302, "Item2", RarityEnum.Rare),
                new GachaItem(303, "Item3", RarityEnum.Rare)
            };
            PermanentBanner permanentBanner = new PermanentBanner(2, "Permanent Banner", permanentItems, 10);

            while (player.Balance > 0)
            {
                GachaItem pulledItem = player.PerformPull(exclusiveBanner);

                PullHistory pullHistory = new PullHistory
                {
                    Item = pulledItem,
                    banner = exclusiveBanner,
                    CreationDate = DateTime.Now,
                    PullNumber = player.Pulls,


                };
                player.PlayerPullHistory.Add(pullHistory);

                player.Pulls++;
                player.Balance -= exclusiveBanner.Cost;
            }

            var path = "gacha.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var history in player.PlayerPullHistory)
                {
                    string rarity = history.Item?.Rarity switch
                    {
                        RarityEnum.Common => "3-star",
                        RarityEnum.Uncommon => "4-star *",
                        RarityEnum.Rare => "5-star ##### " + (history.banner is ExclusiveBanner ? "[EXCL]" : "[PERM]") + "]",
                        _ => "Unknown Rarity"
                    };

                    string pullLine = $"[{Environment.MachineName}] [{Environment.UserName}] [{history.PullNumber}] [{player.PityCounter}] [{history.Item?.ID}] {rarity}";
                    writer.WriteLine(pullLine);
                }

                writer.Flush();
                writer.Close();
            }

        }
    }
}
