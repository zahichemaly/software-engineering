using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class GachaItem
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // Define the Rarity enumeration within the GachaItem class
        public enum Rarity
        {
            ThreeStar,
            FourStar,
            FiveStar
        }

        public Rarity ItemRarity { get; set; }
    }

}