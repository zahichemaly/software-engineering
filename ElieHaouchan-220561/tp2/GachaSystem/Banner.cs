using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public abstract class Banner
    {
        private int ID;
        private string Name;
        private int Cost;
        private List<GachaItem> items;


        public virtual void IsPullAllowed(Player player)
        {
            //To check if a player is allowed to perform a pull based on banner type (exclusive or permanent).
        }
    }
}