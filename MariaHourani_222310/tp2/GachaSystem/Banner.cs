using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class Banner
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<GachaItem> Items { get; set; }

        public int Cost { get; set; }
        public Banner()
        {

        }

        public Banner(int id, string namee,List<GachaItem> gachaitems,int cost)
        {
            ID = id;
            Name = namee;
            Items = gachaitems;
            Cost = cost;
        }
    }
}