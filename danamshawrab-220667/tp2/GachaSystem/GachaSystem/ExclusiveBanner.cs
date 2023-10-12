using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class ExclusiveBanner : Banner
    {
        public List<GachaItem> Items { get; set; }

        public ExclusiveBanner(int id, string name, DateTime startDate, DateTime endDate, int cost, List<GachaItem> items)
        {
            ID = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Cost = cost;
            Items = items;
        }
    }
}