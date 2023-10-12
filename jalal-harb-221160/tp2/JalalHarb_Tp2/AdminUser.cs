using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JalalHarb_Tp2
{
    public class AdminUser : BaseUser
    {
        public void UpdateSystemVersion(System sys, Version version)
        {

        }

        public void UpdateExclusiveBanner(ExclusiveBanner banner)
        {

        }

        public void DeleteExclusiveBanner(ExclusiveBanner banner)
        {

        }

        public PermanentBanner AddExclusiveBanner(ExclusiveBanner banner)
        {
            throw new NotImplementedException();
        }

        public void UpdatePermanentBanner(PermanentBanner banner)
        {

        }

        public void AddUser(System sys, BaseUser user)
        {

        }

        public void DeleteUser(System sys, BaseUser user)
        {

        }
        public override void validate()
        {
            throw new NotImplementedException();
        }
    }
}