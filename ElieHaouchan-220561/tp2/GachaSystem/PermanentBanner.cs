using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class PermanentBanner : Banner
    {

        

        public List<GachaItem> PermanentItems
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
            //Implementation of the abstract method to check if a player can pull from this permanent banner.
        }


    }
}