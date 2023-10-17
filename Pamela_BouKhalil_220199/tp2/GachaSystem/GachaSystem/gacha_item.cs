public class gacha_item
{
    public int ID { get; set; }
    public Rarity ItemRarity { get; set; }

    public enum Rarity
    {
        VeryCommon,
        Uncommon,
        Rare
    }
}