using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GashaSystem
{
    public class Player : BaseUser
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Balance { get; set; }
        public int Pulls { get; set; }
        public int PityCounter { get; set; }
        public List<PullHistory> History { get; set; }

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