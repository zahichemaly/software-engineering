using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class ExclusiveBanner : Banner
    {
        private List<GachaItem> items; // Change the field name to lowercase

         
        public ExclusiveBanner()
        {
            Items = new List<GachaItem>(); // Initialize the Items property
        }

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

        public DateTime StartDate
        {
            get => default;
            set
            {
            }
        }

        public DateTime EndDate
        {
            get => default;
            set
            {
            }
        }
        public GachaItem PullRandom5StarItem()
        {
            Random random = new Random();
            List<GachaItem> fiveStarItems = Items.FindAll(Items => Items.rarity == Rarity.FiveStar);
            int index = random.Next(fiveStarItems.Count);
            return fiveStarItems[index];
        }

        public List<GachaItem> Items
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

        public GachaItem GachaItem
        {
            get => default;
            set
            {
            }
        }

        public override void IsPullAllowed(Player player)
        {
         }
    }
}
