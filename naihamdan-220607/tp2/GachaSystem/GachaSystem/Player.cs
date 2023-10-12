using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class Player : BaseUser
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

        public int PityCounter { get; set; }

        public bool FiftyFiftyStatus { get; set; }

        public GachaItem PerformPull(Banner banner)
        {
            if (this.Balance < banner.Cost)
            {
                throw new InvalidOperationException("Not enough balance to perform pull");
            }

            if (!banner.IsBannerActive())
            {
                throw new InvalidOperationException("Cannot pull from inactive banner.");
            }

            Balance -= banner.Cost;

            Pulls += 1;

            GachaItem pulledIem = banner.PerformPull();

            UpdatePullHistory(pulledIem, banner);

            return pulledIem;
            
        }

        private void UpdatePullHistory(GachaItem item, Banner banner)
        {

        }
    }
}