using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class AdminUser: BaseUser
    {
        public void PermenantBannerUpdating() { }
        public void ManagingExclusiveBanner() { }     
        public void ManagingUsers() { }
        public void UpdatingSystemVersion() { }

        public override void validate() { }
    }
}