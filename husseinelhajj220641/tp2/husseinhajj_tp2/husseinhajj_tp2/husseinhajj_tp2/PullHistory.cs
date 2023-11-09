using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace husseinhajj_tp2
{
    public class PullHistory
    {
        public GachaItem item { get; set; }
        public Banner banner { get; set; }
        public DateTime CreationDate { get; set; }
        public int pullCounter { get; set; }    
    }
}