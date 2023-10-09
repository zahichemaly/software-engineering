using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class PullHistory : BaseUser
    {
        public Gacha Item { get; set; }
        public ExclusiceBanner Banner { get; set; }
        public DateTime CreationDate { get; set; }
        public int PullNumber { get; set; }

        public PullHistory(Gacha item, ExclusiceBanner banner, DateTime creationDate, int pullNumber)
        {
            Item = item;
            Banner = banner;
            CreationDate = creationDate;
            PullNumber = pullNumber;
        }
    }
}