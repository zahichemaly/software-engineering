using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GashaSystem
{
    public class GachaItem
    {
        public int ID {  get; set; }
        public string Name { get; set; }

        public Rarity Rarity { get; set; }
    }
}