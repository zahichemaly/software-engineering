using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaApp
{
    public class PermanentB : Banner
    {

        public PermanentB(GachaItem[] items, int cost, DateTime start, DateTime end, int id, string name):
            base(items, cost, start, end, id, name)
            {
            }
    }
}