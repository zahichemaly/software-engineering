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
        public bool FiftyFiftyStatus { get; set; }
        public int Balance { get; set; }
        public int Pulls { get; set; }
        public int PityCounter { get; set; }
        public List<PullHistory> History { get; set; }

        public override void validate()
        {
            throw new NotImplementedException();
        }

        public GachaItem? SinglePull(Banner pool)
        {
            if (pool is ExclusiveBanner)
            {
                ExclusiveBanner banner = (ExclusiveBanner)pool;

                if (DateTime.Now < banner.StartDate || DateTime.Now > banner.EndDate)
                {
                    throw new Exception("Expeired");
                }
            }

            if (Balance - pool.Cost > 0 && pool.Items.Count > 0)
            {
                this.Balance -= pool.Cost;
                this.Pulls++;

                Rarity rarity;

                if (Pulls < 80)
                {
                    rarity = Rarity.threeStar;
                }
                else if (Pulls < 98)
                {
                    rarity = Rarity.fourStar;
                }
                else
                {
                    rarity = Rarity.fiveStar;
                }

                var possibleItems = pool.Items.Where(item => item.Rarity == rarity).ToList();

                if (rarity == Rarity.fourStar && !possibleItems.Any())
                {
                    return null;
                }

                GachaItem item = possibleItems[new Random().Next(possibleItems.Count)];

                this.History.Add(new PullHistory()
                {
                    banner = pool,
                    CreationDate = DateTime.Now,
                    item = item,
                    pullCounter = this.Pulls
                });

                return item;
            }

            return null;
        }
    }
}