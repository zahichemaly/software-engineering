using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class Player : BaseUser
    {

       
        public int Balance;

        private int Pulls;

        public int PityCounter = 0;

        public List<GachaItem> PullHistory { get; }
        public Version Version
        {
            get => default;
            set
            {
            }
        }

        public Player(string firstName, string lastName, int balance)
        {
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
            PullHistory = new List<GachaItem>();
            
        }
       
        public void AddToPullHistory(GachaItem item)
        {
            PullHistory.Add(item);
        }

      /*  public void PerformPull(ExclusiveBanner banner)
        {
            Pulls++;

            //To allow a player to perform a pull, either from an exclusive banner or a permanent banner.
        } */

      

       

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

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}