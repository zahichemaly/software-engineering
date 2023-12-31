﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class ExclusiveBanner: Banner
    {
        private List<GachaItem> Items;

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

        public int Cost;
        public bool IsBannerActive()
        {
          
            DateTime now = DateTime.Now;
            return StartDate <= now && now <= EndDate;
        }
    }
}
    
