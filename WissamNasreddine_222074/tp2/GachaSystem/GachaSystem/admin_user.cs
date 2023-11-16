using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class admin_user : BaseUser
    {
        public void Update_permanent_banner()
        {

        }

        public void Modify_exclusive_banner()
        {

        }

        public void Manage_users()
        {

        }
        public void Update_system_version()
        {

        }
        public void UpdateBannerCost(Banner Banner, int newCost)
        {
            Banner.Cost = newCost;
            Console.WriteLine($"Updated cost of {Banner.Name} to {newCost}");
        }
    }
}