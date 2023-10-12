using System;

namespace GachaSystem
{
    public class PullHistory
    {
        public GachaItem Item { get; set; }
        public Banner banner { get; set; }
        public DateTime CreationDate { get; set; }
        public int PullNumber { get; set; }

        public PullHistory(GachaItem item, Banner banner, DateTime creationDate, int pullNumber)
        {
            Item = item;
            banner = banner;
            CreationDate = creationDate;
            PullNumber = pullNumber;
        }

        public PullHistory()
        {
        }
    }
}
