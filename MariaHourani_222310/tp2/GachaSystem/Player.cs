using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class Player : BaseUser
    {
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
        public void PerformPull(int cost)
        {

            if (Balance >= cost)
            {
                Balance -= cost; 
                Pulls++; 
            }
            else
            {
                Console.WriteLine("Insufficient balance to perform a pull.");
            }
        }

        public void PerformPull(ExclusiveBanner banner)
        {
            if(Balance > 0)
            {
                if (banner.StartDate >= DateTime.Now && banner.EndDate >= DateTime.Now)
                    if (Balance >= banner.Cost)
                    {
                        Balance -= banner.Cost; 
                        Pulls++;
                        Console.WriteLine("Pull from Exclusive Banner successful.");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance to perform a pull from Exclusive Banner.");
                    }
            }
          
        }
        private void CheckForFiveStarPull(string bannerName)
        {

        }

        /* public void PerformPull(ExclusiveBanner banner)
         {
            
             int permanentBannerCost = 10; 
             if (Balance >= permanentBannerCost)
             {
                 Balance -= permanentBannerCost;
                 Pulls++; 
                 Console.WriteLine("Pull from Permanent Banner successful.");
             }
             else
             {
                 Console.WriteLine("Insufficient balance to perform a pull from Permanent Banner.");
             }
         }*/
    }
}