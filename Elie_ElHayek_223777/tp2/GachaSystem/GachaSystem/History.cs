﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class History
    {
        public GachaItem Item
        {
            get;
            set;
        }

        public Banner Banner
        {
            get;
            set;
        }

        public DateTime CreationDate
        {
            get;
            set;
        }

        public int PullNumber = 1;
    }
}