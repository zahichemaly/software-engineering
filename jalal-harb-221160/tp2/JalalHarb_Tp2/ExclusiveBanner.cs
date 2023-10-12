using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JalalHarb_Tp2
{
    public class ExclusiveBanner : Banner
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ExclusiveBanner(int id, string name, List<GachaItem> items, int cost, DateTime startDate, DateTime endDate) : base(id, name, items, cost)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}