using System;
using System.Collections.Generic;
using System.IO;

namespace GachaSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating a new player object with initial details
            Player player = new Player
            {
                ID = 0,
                FirstName = "Rami",
                LastName = "Moubadder",
                DateOfBirth = new DateTime(2000, 05, 09),
                FiftyFiftyStatus = false,
                PityCounter = 0,
                Pulls = 0,
                Status = Status.Active,
                Balance = 1000,
            };

            // Creating an exclusive banner with specific items and details
            Banner exclusiveBanner = new ExclusiveBanner
            {
                ID = 0,
                Cost = 100,
                StartDate = new DateTime(2023, 10, 20),
                EndDate = new DateTime(2023, 10, 25),
                Name = "Exclusive Banner",
                Items = new List<GachaItem>
                {
                    new GachaItem
                    {
                        ID=100,
                        Name = "Item1",
                        Rarity = Rarity.THREE_STARS,
                    },
                    new GachaItem
                    {
                        ID=200,
                        Name = "Item2",
                        Rarity = Rarity.FOUR_STARS,
                    },
                    new GachaItem
                    {
                        ID=300,
                        Name = "Item3",
                        Rarity = Rarity.FIVE_STARS,
                    }
                }
            };

            // Creating a permanent banner with specific items and details
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
                        Name = "Item4",
                        Rarity = Rarity.FIVE_STARS,
                    },
                    new GachaItem
                    {
                        ID=302,
                        Name = "Item5",
                        Rarity = Rarity.FIVE_STARS,
                    },
                    new GachaItem
                    {
                        ID=303,
                        Name = "Item6",
                        Rarity = Rarity.FIVE_STARS,
                    }
                }
            };

            // Loop to simulate pulling from the exclusive banner until the player's balance is insufficient
            while (player.Balance >= exclusiveBanner.Cost)
            {
                // Performing a pull from the exclusive banner
                GachaItem pulledItem = player.PerformPull(exclusiveBanner);

                // Checking if a valid item was pulled
                if (pulledItem == null)
                {
                    Console.WriteLine("No valid item was pulled. Exiting the loop.");
                    break;
                }

                // Deducting the cost from the player's balance
                player.Balance -= exclusiveBanner.Cost;

                // Creating a history object for the pulled item and adding it to the player's history
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

            // Writing pull histories to a text file
            string path = Path.Combine("gacha.txt");
            using (StreamWriter writer = new StreamWriter(path))
            {
                // Iterating through player's pull histories and formatting the output
                foreach (var history in player.PullHistories)
                {
                    // Determining rarity output based on item rarity
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
                            // Determining banner type and fifty-fifty win status for 5-star items
                            string bannerType = history.Banner is PermanentBanner ? "PERM" : "EXCL";
                            bool fiftyFiftyWin = false; // Placeholder value, actual logic can be added here
                            rarityOutput = $"5-star ##### [{bannerType}] [{fiftyFiftyWin}]";
                            break;
                    }
                    // Writing formatted output to the file
                    writer.WriteLine($"{Environment.MachineName} {Environment.UserName} {history.PullNumber} {player.PityCounter} {history.Item.ID} {rarityOutput}");
                }
            }
        }
    }
}
