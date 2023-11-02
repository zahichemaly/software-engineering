using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public abstract class Banner
    {
        public List<GachaItem> Items { get; set; }

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

        public DateTime StartDate
        {
            get => default;
            set
            {
            }
        }

        public DateTime EndDate
        {
            get => default;
            set
            {
            }
        }


        public int Cost
        {
            get => default;
            set
            {
            }
        }

        public bool IsBannerActive()
        {
            DateTime now = DateTime.Now;
            return StartDate <= now && now <= EndDate;
        }

        public GachaItem PerformPull()
        {
            return new GachaItem();
        }
    }
}