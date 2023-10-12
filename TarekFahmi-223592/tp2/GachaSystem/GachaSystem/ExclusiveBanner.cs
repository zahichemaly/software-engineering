using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class ExclusiveBanner
    {
        public int ID;
        public string Name;
        public DateTime StartDate;
        public DateTime EndDate;
    
        public List<GachaItem> Items;
        public int Cost;
    }
}