using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GachaSystem
{
    public class PullHistoryEntry
    {
        public GachaItem Item { get; set; }
        public ExclusiveBanner Banner { get; set; }
        public DateTime CreationDate { get; set; }
        public int PullNumber { get; set; }
    }
}
