using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class System
    {
        public List<BaseUser> Users { get; set; }
        public Version CurrentVersion { get; set; }
        public List<ExclusiveBanner> ExclusiveBanners { get; set; }
        public List<GachaItem> PermanentBannerItems { get; set; }
    }
}