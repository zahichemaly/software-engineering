using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class admin_user : BaseUser
    {
        public void Update_Permanent_banner()
        {

        }

        public void Modify_Exclusive_banner()
        {

        }

        public void Manage_Users()
        {

        }

        public void Update_System_version()
        {

        }


        public void UpdateBannerCost(Banner banner, int newCost)
        {
            banner.Cost = newCost;
            Console.WriteLine($"Updated cost of {banner.Name} to {newCost}");
        }
    }
}