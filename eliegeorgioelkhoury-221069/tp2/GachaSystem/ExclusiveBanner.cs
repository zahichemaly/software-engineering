using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class ExclusiveBanner: Banner
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}