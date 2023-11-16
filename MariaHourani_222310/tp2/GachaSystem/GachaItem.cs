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
        public RarityEnum Rarity { get; set; }

        public GachaItem(int id, string name, RarityEnum rarity)
        {

        }
        public GachaItem()
        {

        }
    }
}