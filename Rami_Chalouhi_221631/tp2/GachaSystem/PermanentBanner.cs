using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class PermanentBanner : Banner
    {
        public int ID
        {
            get => default;
            set
            {
            }
        }

        public string Name
        {
            get => default;
            set
            {
            }
        }
        public int Cost
        {
            get => default;
            set
            {
            }
        }

        public List<GachaItem> PermanentItems;
        
      
        public GachaItem GachaItem
        {
            get => default;
            set
            {
            }
        }
        public GachaItem PullRandom5StarItem()
        {
            Random random = new Random();
            List<GachaItem> fiveStarItems = PermanentItems.FindAll(PermanentItem => PermanentItem.rarity == Rarity.FiveStar);
            int index = random.Next(fiveStarItems.Count);
            return fiveStarItems[index];
        }
        public PermanentBanner()
        {
            PermanentItems = new List<GachaItem>();
        }

        
        public override void IsPullAllowed(Player player)
        {
            //Implementation of the abstract method to check if a player can pull from this permanent banner.
        }


    }
}