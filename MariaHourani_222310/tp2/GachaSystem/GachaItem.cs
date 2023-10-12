using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class GachaItem
    {
        public enum RarityEnum
        {
            Common = 3,
            Uncommon = 4,
            Rare = 5
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

        public RarityEnum Rarity { get; set; }
    }
}