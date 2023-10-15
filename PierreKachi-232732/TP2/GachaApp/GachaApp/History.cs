using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaApp
{
    public class historyItem
    { 
        private GachaItem item;
        private Banner RelatedBanner;
        private DateTime pullDate;
        private int pullNumber;

        public GachaItem GetItem()
    {
        return item;
    }

    public Banner GetRelatedBanner()
    {
        return RelatedBanner;
    }

    public DateTime GetPullDate()
    {
        return pullDate;
    }

    public int GetPullNumber()
    {
        return pullNumber;
    }
        public historyItem(GachaItem item, Banner banner, DateTime pullDate, int pullNumber){
            this.item = item;
            this.RelatedBanner = banner;
            this.pullDate = pullDate;
            this.pullNumber = pullNumber;
        }
    }
}