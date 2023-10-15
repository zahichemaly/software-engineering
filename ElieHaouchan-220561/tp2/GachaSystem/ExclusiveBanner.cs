using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class ExclusiveBanner : Banner
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
            //Implementation of the abstract method to check if a player can pull from this exclusive banner.
        }
    }
}