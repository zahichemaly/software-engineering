using System;
using System.Collections.Generic;
using System.IO;

namespace GachaSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player
            {
                ID = 1,
                FirstName = "Elie",
                LastName = "Hayek",
                DateOfBirth = new DateTime(2003, 4, 9),
                FiftyFiftyStatus = false,
                PityCounter = 0,
                Pulls = 0,
                Status = Status.Active,
                Balance = 1000,
            };

            Banner exclusiveBanner = new ExclusiveBanner
            {
                ID = 0,
                Cost = 100,
                StartDate = new DateTime(2023, 10, 9),
                EndDate = new DateTime(2023, 10, 13),
                Name = "Exclusive Banner",
                Items = new List<GachaItem>
                {
                    new GachaItem
                    {
                        ID=100,
                        Name = "EB1",
                        Rarity = Rarity.THREE_STARS,
                    },
                    new GachaItem
                    {
                        ID=200,
                        Name = "EB2",
                        Rarity = Rarity.FOUR_STARS,
                    },
                    new GachaItem
                    {
                        ID=300,
                        Name = "EB3",
                        Rarity = Rarity.FIVE_STARS,
                    }
                }
            };

            Banner permanentBanner = new PermanentBanner
            {
                ID = 1,
                Name = "Permanent Banner",
                Cost = 100,
                Items = new List<GachaItem>
                {
                    new GachaItem
                    {
                        ID=301,
                        Name = "PB1",
                        Rarity = Rarity.FIVE_STARS,
                    },
                    new GachaItem
                    {
                        ID=302,
                        Name = "PB2",
                        Rarity = Rarity.FIVE_STARS,
                    },
                    new GachaItem
                    {
                        ID=303,
                        Name = "PB3",
                        Rarity = Rarity.FIVE_STARS,
                    }
                }
            };

         
            while (player.Balance >= exclusiveBanner.Cost)
            {
                GachaItem pulledItem = player.PerformPull(exclusiveBanner);
                if (pulledItem == null)
                {
                    break;
                }

                player.Balance -= exclusiveBanner.Cost;

                History history = new History
                {
                    Item = pulledItem,
                    Banner = exclusiveBanner,
                    CreationDate = DateTime.Now,
                    PullNumber = player.Pulls + 1
                };
                player.PullHistories.Add(history);
                player.Pulls++;
            }


            var path = "gacha.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var history in player.PullHistories)
                {
                    
                        string rarityOutput = "";
                        switch (history.Item.Rarity)
                        {
                            case Rarity.THREE_STARS:
                                rarityOutput = "3-star";
                                break;
                            case Rarity.FOUR_STARS:
                                rarityOutput = "4-star *";
                                break;
                            case Rarity.FIVE_STARS:
                                string bannerType = history.Banner is PermanentBanner ? "PERM" : "EXCL";
                                bool fiftyFiftyWin = false;
                                rarityOutput = $"5-star ##### [{bannerType}] [{fiftyFiftyWin}]";
                                break;
                        }
                        writer.WriteLine($"[{Environment.MachineName}] [{Environment.UserName}] [{history.PullNumber}] [{player.PityCounter}] [{history.Item.ID}] {rarityOutput}");
                    
                }
            }



        }
    }
}
