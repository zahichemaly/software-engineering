using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class Player
    {
        public int ID { get; set; }
        public bool Win5050 { get; set; }
        public int Balance { get; set; }
        public int Pulls { get; set; }
        public int Pitycounter { get; set; }
        public List<pulls_history> pullhist = new List<pulls_history>();

        public Player(int id, int balance)
        {
            ID = id;
            Balance = balance;
            pullhist = new List<pulls_history>();
        }

        public void PerformPull(Banner banner)
        {
            if (Balance >= banner.Cost)
            {
                Balance -= banner.Cost;
                Pulls++;

                gacha_item itemToPull = banner.PullItem();

                if (itemToPull != null)
                {
                    pulls_history entry = new pulls_history
                    {
                        Item = itemToPull,
                        Banner = banner,
                        Creationdate = DateTime.Now,
                        Pull_number = Pulls,
                        Win5050 = Win5050
                    };

                    pullhist.Add(entry);
                    UpdatePityAndFiftyFifty(itemToPull);

                    Console.WriteLine($"Player {ID} pulled {itemToPull.Rarity} from {banner.Name}");
                }
                else
                {
                    Console.WriteLine($"No items available to pull from {banner.Name}.");
                }
            }
            else
            {
                Console.WriteLine($"Player {ID} doesn't have enough balance to perform a pull.");
            }
        }

        public void WritePullHistoryToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var entry in pullhist)
                {
                    string rarityString = GetRarityString(entry.Item.Rarity, entry.Win5050, entry.Banner is Banner);
                    string pullInfo = $"[{Environment.MachineName}] [{Environment.UserName}] " +
                                     $"[{entry.Pull_number}] [{Pitycounter}] [{entry.Item.ID}] {rarityString}";

                    writer.WriteLine(pullInfo);
                }
            }
        }


        private void UpdatePityAndFiftyFifty(gacha_item item)
        {
            if (item != null && item.Rarity == Rarity.Rare)
            {
                Pitycounter = 0;
                Win5050 = false;
            }
            else
            {
                Pitycounter++;
                if (Pitycounter >= 60)
                {
                    Pitycounter = 0;
                    Win5050 = false;
                }
                else if (Pitycounter == 59)
                {
                    Win5050 = true;
                }
            }
        }


        private string GetRarityString(Rarity rarity, bool fiftyFiftyLost, bool isPermanent)
        {
            if (rarity == Rarity.Common)
            {
                return "3-star";
            }
            else if (rarity == Rarity.Uncommon)
            {
                return "4-star";
            }
            else if (rarity == Rarity.Rare)
            {
                string bannerType = isPermanent ? "[PERM]" : "[EXCL]";
                string fiftyFiftyResult = fiftyFiftyLost ? "[False]" : "[True]";
                return $"5-star {bannerType} {fiftyFiftyResult}";
            }
            return string.Empty;
        }
    }
}