using System;

namespace GachaSystem
{
    internal class PullHistoryEntry
    {
        private GachaItem pulledItem;
        private ExclusiveBanner banner;
        private DateTime now;
        private int pulls;

        public PullHistoryEntry(GachaItem pulledItem, ExclusiveBanner banner, DateTime now, int pulls)
        {
            this.pulledItem = pulledItem;
            this.banner = banner;
            this.now = now;
            this.pulls = pulls;
        }
    }
}