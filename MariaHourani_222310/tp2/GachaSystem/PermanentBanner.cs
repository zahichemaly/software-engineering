using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class PermanentBanner : Banner 
    {
        public PermanentBanner(int id, string namee, List<GachaItem> gachaitems, int cost):
            base(id,namee,gachaitems,cost)
        {
           
        }
    }
}