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
            get => default;
            set
            {
            }
        }

        public string FirstName
        {
            get => default;
            set
            {
            }
        }

        public string LastName
        {
            get => default;
            set
            {
            }
        }

        public DateTime DateOfBirth
        {
            get => default;
            set
            {
            }
        }

        public int Balance
        {
            get => default;
            set
            {
            }
        }

        public int Pulls
        {
            get => default;
            set
            {
            }
        }

        public void updatePermanentBanner(PermanentBanner banner) { }

        public void AddExclusiveBanner() { }

        public void UpdateExclusiveBanner(ExclusiveBanner banner) { }

        public void DeleteExclusiveBanner(ExclusiveBanner banner) { }

        public void AddUser() { }

        public void RemoveUser(BaseUser user) { }

        public void UpdateSystemVersion(System system) { }

    }
}