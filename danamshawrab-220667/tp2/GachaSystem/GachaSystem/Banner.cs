﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
        public abstract class Banner
        {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Cost { get; set; }
        public List<GachaItem> Items { get; set; }

    }

    
}