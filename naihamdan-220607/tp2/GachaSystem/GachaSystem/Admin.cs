using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class Admin:BaseUser
    {
        public int ID
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public DateTime DateOfBirth
        {
            get;
            set;
        }

        public int Balance
        {
            get;
            set;
        }

        public int Pulls
        {
            get;
            set;
        }

        public void updatePermanentBanner(PermanentBanner banner) { }

        public void AddExclusiveBanner() { }

        public void UpdateExclusiveBanner(ExclusiveBanner banner) { }

        public void DeleteExclusiveBanner(ExclusiveBanner banner) { }

        public void AddUser() { }

        public void RemoveUser(BaseUser user) { }

        public void UpdateSystemVersion(System system) { }

        public override void validate()
        {
           
        }
    }
}