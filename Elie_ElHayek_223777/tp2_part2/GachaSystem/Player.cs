using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace GachaSystem
{
    abstract public class Player:BaseUser
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

        public System.DateTime DateOfBirth
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

        public HistoryPulls historyPull
        {
            get => default;
            set
            {
            }
        }

        public void PullBanner(Banner banner)
        {
            if (this.Balance < banner.cost)
                throw new Exception("Not enough balance");

            if (banner.IsExclusive && (DateTime.Now < banner.startDate || DateTime.Now > banner.endDate))
                throw new Exception("Banner is not active");

            this.Balance -= banner.cost;
            this.Pulls += 1;
            
        }

    }
}