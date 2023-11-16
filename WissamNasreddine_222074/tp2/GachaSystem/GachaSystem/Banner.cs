using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GachaSystem
{
    public class Banner
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public DateTime StartDate = DateTime.Now;
        public int Cost { get; set; }
        public List<gacha_item> Items { get; set; }


        public gacha_item PullItem()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 101); // Generate a random number between 1 and 100

            gacha_item itemToPull = null;

            if (randomNumber <= 80)
            {
                itemToPull = Items.Find(i => i.Rarity == Rarity.Common);
            }
            else if (randomNumber <=98)
            {
                itemToPull = Items.Find(i => i.Rarity == Rarity.Uncommon);
            }
            else
            {
                itemToPull = Items.Find(i => i.Rarity == Rarity.Rare);
            }

            return itemToPull;
        }
    }
}
