using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class PermanentBanner : Banner
    {
        public List<GachaItem> Items { get; set; }

      
        public PermanentBanner(int id, string name, int cost, List<GachaItem> items)
        {
            ID = id;
            Name = name;
            Cost = cost;
            Items = items;
        }
    }
}