using GachaSystem;

public class Banner
{
    public int id { get; set; }

    public string Name{get; set; }
    public int Cost { get; set; }
    public List<gacha_item> Items { get; set; }

    public DateTime startdate= DateTime.Now;

    public gacha_item PullItem()
    {
        Random random = new Random();
        double randomValue = random.NextDouble() * 100;

        gacha_item itemToPull = null;

        if (randomValue < 80) // 3-star
        {
            itemToPull = Items.Find(i => i.ItemRarity == gacha_item.Rarity.VeryCommon);
        }
        else if (randomValue < 98) // 4-star (80 + 18)
        {
            itemToPull = Items.Find(i => i.ItemRarity == gacha_item.Rarity.Uncommon);
        }
        else // 5-star (80 + 18 + 2)
        {
            itemToPull = Items.Find(i => i.ItemRarity == gacha_item.Rarity.Rare);
        }

        return itemToPull;
    }

}