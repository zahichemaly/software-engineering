using System;

namespace GachaSystem
{
    public class PullHistory
    {
        public GachaItem Item { get; set; }
        public Banner banner { get; set; }
        public DateTime CreationDate { get; set; }
        public int PullNumber = 1;
        public RarityEnum rarity { get; set; }

        public PullHistory(GachaItem item, Banner banner, DateTime creationDate, int pullNumber,RarityEnum rar)
        {
            Item = item;
            banner = banner;
            CreationDate = creationDate;
            PullNumber = pullNumber;
            rarity = rar;
        }

        public PullHistory()
        {
        }
    }
}
