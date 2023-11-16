using System.Xml.Linq;

namespace JalalHarb_Tp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player
            {
                ID = 0,
                FirstName = "Jalal",
                LastName = "Harb",
                DateOfBirth = new DateTime(2002, 12, 24),
                FiftyFiftyStatus = false,
                PityCounter = 0,
                Pulls = 0,
                status = Status.Active,
                Balance = 1000,
            };

            Banner exclusiveBanner = new ExclusiveBanner(0, "Exclusive Banner", new List<GachaItem>
            {
                new GachaItem
                {
                    ID=100,
                    Name = "Item1",
                    Rarity = Rarity.threeStar,
                },
                new GachaItem
                {
                    ID=200,
                    Name = "Item2",
                    Rarity = Rarity.fourStar,
                },
                new GachaItem
                {
                    ID=300,
                    Name = "Item3",
                    Rarity = Rarity.fiveStar,
                }
            }, 100, new DateTime(2023, 10, 9), new DateTime(2023, 10, 20));

            Banner permanentBanner = new PermanentBanner(1, "Permanent Banner", new List<GachaItem>
            {
                new GachaItem
                {
                    ID=301,
                    Name = "Item4",
                    Rarity = Rarity.fiveStar,
                },
                new GachaItem
                {
                    ID=302,
                    Name = "Item5",
                    Rarity = Rarity.fiveStar,
                },
                new GachaItem
                {
                    ID=303,
                    Name = "Item6",
                    Rarity = Rarity.fiveStar,
                }
            }, 100);

            int maxPulls = 1000;
            while (player.Balance >= exclusiveBanner.Cost && player.Pulls < maxPulls)
            {
                GachaItem? pulledItem = player.SinglePull(exclusiveBanner);

                if (pulledItem == null)
                {
                    Console.WriteLine("No item was pulled");
                    break;
                }
                
                Console.WriteLine($"Pulled an item with a {pulledItem.Rarity} rarity");
            }

            string path = Path.Combine("gacha.txt");
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var history in player.History)
                {
                    string rarityOutput = "";
                    switch (history.item.Rarity)
                    {
                        case Rarity.threeStar:
                            rarityOutput = "3-star";
                            break;
                        case Rarity.fourStar:
                            rarityOutput = "4-star *";
                            break;
                        case Rarity.fiveStar:
                            string bannerType = history.banner is PermanentBanner ? "PERM" : "EXCL";
                            bool fiftyFiftyWin = false;
                            rarityOutput = $"5-star ##### [{bannerType}] [{fiftyFiftyWin}]";
                            break;
                    }

                    writer.WriteLine($"[{Environment.MachineName}] [{Environment.UserName}] [{history.pullCounter}] [{player.PityCounter}] [{history.item.ID}] {rarityOutput}");
                }
            }
        }
    }
}