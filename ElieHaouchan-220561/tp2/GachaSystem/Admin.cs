using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GachaSystem
{
    public class Admin : BaseUser
    {
                    

        public override void Validate()
        {
            throw new NotImplementedException();
        }

        public void UpdatePermanentBanner(PermanentBanner banner) {
            // To update the permanent banner. 

        }
        public void AddExclusiveBanner(ExclusiveBanner banner) {
            //To add a new exclusive banner. 
        }
        public void UpdateExclusiveBanner(ExclusiveBanner banner) {
            //To update an existing exclusive banner.
        }
        public void DeleteExclusiveBanner(ExclusiveBanner banner) {
            //To delete an exclusive banner.
        }
        public void AddUser(Player player) {
            //To add a new user to the system.
        }

        public void RemoveUser(Player player) {
            //To remove a user from the system.
        }

        public void UpdateSystemVersion(Version newVersion)
        {
            // To update the system version.
        }
    }
}