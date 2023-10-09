using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public abstract class Player : BaseUser
    {

       
        private int Balance;

        private int Pulls;

        public Version Version
        {
            get => default;
            set
            {
            }
        }

        public void PerformPull(ExclusiveBanner banner)
        {
            Pulls++;

            //To allow a player to perform a pull, either from an exclusive banner or a permanent banner.
        }

        public void TrackPullHistory(ExclusiveBanner banner, GachaItem item)
        {
            if (item == null)
            {
                return;
            }

            Console.WriteLine("Item: " + item.Name);
            Console.WriteLine("Banner: " + banner.Name);
            Console.WriteLine("CreationDate: " + banner.StartDate);
            Console.WriteLine("Pull number: " + Pulls);

            //To track the history of pulls performed by the player.
        }

        public void CheckFor5StarPity()
        {
            //To check if the player is eligible for a 5-star pity item and handle the 50-50 rule.
        }


    }
}