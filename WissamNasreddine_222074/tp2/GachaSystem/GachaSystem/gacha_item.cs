using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class gacha_item
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

        public Rarity Rarity { get; set; }
    }

    public enum Rarity
    {
        Common=3 ,
        Uncommon=4 ,
        Rare=5
    }
}