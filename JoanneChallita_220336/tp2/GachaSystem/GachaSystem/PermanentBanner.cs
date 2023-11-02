using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GachaSystem
{
    public class PermanentBanner : Banner
    {
        public PermanentBanner(int id, string name, List<GachaItem> items, int cost) : base(id, name, items, cost)
        {

        }
    }
}
