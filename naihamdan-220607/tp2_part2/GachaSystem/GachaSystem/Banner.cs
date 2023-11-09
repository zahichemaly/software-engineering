using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class Banner
    {
        public List<GachaItem> Items { get; set; }

        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        

        public int Cost
        {
            get;
            set;
        }


        public GachaItem PerformPull() {
            return new GachaItem();
        }
    }
}