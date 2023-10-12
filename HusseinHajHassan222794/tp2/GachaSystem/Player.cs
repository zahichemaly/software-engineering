using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public abstract class Player: BaseUser
    {

        public override void validate() { }


        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Balance { get; set; }
        public int Pulls { get; set; }
        public int PityCounter { get; set; }
        public bool HasWon5050 { get; set; }
        public List<HistoryEntry> PullHistory { get; set; }

        public void PerformPull(Banner banner, DateTime currentDate)
        {
            if (Balance >= banner.Cost)
            {
                if (banner is ExclusiveBanner exclusiveBanner && currentDate >= exclusiveBanner.StartDate && currentDate <= exclusiveBanner.EndDate)
                {
                    Balance -= banner.Cost;
                    Pulls++;

                }
                else if (banner is PermanentBanner)
                {
                    Balance -= banner.Cost;
                    Pulls++;

                }
                else
                {
                    Console.WriteLine("This banner is not available for pulling at this time.");
                }
            }
            else
            {
                Console.WriteLine("Insufficient balance to perform a pull.");
            }
        }
    }
}