using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace husseinhajj_tp2
{
    public class Player : BaseUser
    {
        private int ID { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private DateTime DateOfBirth { get; set; }
        private int Balance { get; set; }
        private int Pulls { get; set; }
        private int PityCounter { get; set; }
        public List<PullHistory> History { get; set; }

        public Player(int id, string firstName, string lastName, DateTime dateOfBirth) : base(id, firstName, lastName, dateOfBirth)
        {
        }

        public override void validate()
        {
            throw new NotImplementedException();
        }
        public void SinglePullExclusive(Banner pool)
        {
            if (pool is ExclusiveBanner)
            {
                ExclusiveBanner banner = (ExclusiveBanner)pool;



                if (DateTime.Now < banner.StartDate || DateTime.Now > banner.EndDate)
                {
                    return;
                }
            }



            if (Balance - pool.Cost > 0 && pool.Items.Count > 0)
            {
                this.Balance -= pool.Cost;
                this.Pulls++;
                pool.Items.RemoveAt(0);



                this.History.Add(new PullHistory()
                {
                    banner = pool,
                    CreationDate = DateTime.Now,
                    item = pool.Items[0],
                    pullCounter = this.Pulls
                });
            }
        }
    }
}