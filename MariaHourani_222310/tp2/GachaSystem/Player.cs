using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class Player : BaseUser
    {
        public int Balance { get; set; }
        private int Pulls
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
                //PullHistory newpull = new PullHistory(gachaitem, banner, DateTime.Now,Pulls);
            }
            else
            {
                Console.WriteLine("Insufficient balance to perform a pull.");
            }
        }
        public Player(int id, string lastName, string firstName, DateTime dateOfBirth, int initialBalance, int initialPulls):
            base(id,lastName,firstName,dateOfBirth)
        {

        }

        public void PerformPull(ExclusiveBanner banner)
        {
            if(Balance > 0)
            {
                if (banner.StartDate >= DateTime.Now && banner.EndDate >= DateTime.Now)
                {
                    PerformPull(banner.Cost);
                }
            }
          
        }
        public void PerformPull(PermanentBanner banner)
        {
            if (Balance > 0)
            {
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