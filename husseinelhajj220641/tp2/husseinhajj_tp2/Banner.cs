using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace husseinhajj_tp2
{
    public class Banner
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<GachaItem> Items { get; set; }
        public int Cost { get; set; }
    }
}