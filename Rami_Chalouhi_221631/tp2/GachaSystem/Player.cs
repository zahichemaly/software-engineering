using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class Player : BaseUser
    {
        public int PityCounter = 0;
        public List<GachaItem> PullHistory { get; }
        public Player(string firstName, string lastName, int balance)
        {
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
            PullHistory = new List<GachaItem>();

        }
        public override void Validate()
        {

        }
        public int Balance;

        public int Pulls;

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

        }

        public void TrackPullHistory(ExclusiveBanner banner, GachaItem item)
        {
            if (item == null)
            {
                return;


            }

            Console.WriteLine("Item: " + item.Name);
            Console.WriteLine("Pull number: " + Pulls);


            Console.WriteLine("Banner: " + banner.Name);
            Console.WriteLine("CreationDate: " + banner.StartDate);

        }
        public void AddToPullHistory(GachaItem item)
        {
            PullHistory.Add(item);
        }
        public bool CheckFor5StarPity()
        {
            if (PullHistory.Any() && PullHistory.Last().rarity != Rarity.FiveStar)
            {
                PityCounter++;
            }
            else
            {
                PityCounter = 0;
            }

            return PityCounter >= 60; // This value is based on your requirement for a guaranteed 5-star
        }
    }
    }