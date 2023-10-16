using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class pulls_history
    {
        public gacha_item Item { get; set; }

        public Banner Banner { get; set; }

        public DateTime Creationdate { get; set; }
        public int Pull_number { get; set; }
        public bool Win5050 { get; set; }
    }
}