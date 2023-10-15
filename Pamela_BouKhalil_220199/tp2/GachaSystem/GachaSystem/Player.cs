using GachaSystem;

public class Player
{
    public int ID { get; set; } 
    public bool FiftyFiftyLost { get; set; }
    public int Balance { get; set; }
    public int Pulls { get; set; }
    public int PityCounter { get; set; }
    public List<pulls_history> pullhist = new List<pulls_history>();
    
    public Player(int id,int balance)
    {
        ID = id;
        Balance = balance;
        pullhist= new List<pulls_history>();
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
                    CreationDate = DateTime.Now,
                    PullNumber = Pulls,
                    FiftyFiftyLost = FiftyFiftyLost
                };

                pullhist.Add(entry);
                UpdatePityAndFiftyFifty(itemToPull);

                Console.WriteLine($"Player {ID} pulled {itemToPull.ItemRarity} from {banner.Name}");
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
                string rarityString = GetRarityString(entry.Item.ItemRarity, entry.FiftyFiftyLost, entry.Banner is Permanent_banner);
                string pullInfo = $"[{Environment.MachineName}] [{Environment.UserName}] " +
                                 $"[{entry.PullNumber}] [{PityCounter}] [{entry.Item.ID}] {rarityString}";

                writer.WriteLine(pullInfo);
            }
        }
    }


    private void UpdatePityAndFiftyFifty(gacha_item item)
    {
        if (item != null && item.ItemRarity == gacha_item.Rarity.Rare)
        {
            PityCounter = 0;
            FiftyFiftyLost = false;
        }
        else
        {
            PityCounter++;
            if (PityCounter >= 60)
            {
                PityCounter = 0;
                FiftyFiftyLost = false;
            }
            else if (PityCounter == 59)
            {
                FiftyFiftyLost = true;
            }
        }
    }


    private string GetRarityString(gacha_item.Rarity rarity, bool fiftyFiftyLost, bool isPermanent)
    {
        if (rarity == gacha_item.Rarity.VeryCommon)
        {
            return "3-star";
        }
        else if (rarity == gacha_item.Rarity.Uncommon)
        {
            return "4-star";
        }
        else if (rarity == gacha_item.Rarity.Rare)
        {
            string bannerType = isPermanent ? "[PERM]" : "[EXCL]";
            string fiftyFiftyResult = fiftyFiftyLost ? "[False]" : "[True]";
            return $"5-star {bannerType} {fiftyFiftyResult}";
        }
        return string.Empty;
    }
}
