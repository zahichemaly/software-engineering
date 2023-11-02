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
             

        }
        public void AddExclusiveBanner(ExclusiveBanner banner) {
             
        }
        public void UpdateExclusiveBanner(ExclusiveBanner banner) {
            
        }
        public void DeleteExclusiveBanner(ExclusiveBanner banner) {
            //To delete an exclusive banner.
        }
        public void AddUser(Player player)
        {
        }
        public void RemoveUser(Player player) {
             
        }

        public void UpdateSystemVersion(Version newVersion)
        {
            
        }
    }
}