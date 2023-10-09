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
    }
}