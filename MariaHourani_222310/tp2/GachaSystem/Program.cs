using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Player player1 = new Player(1, "Doe", "John", new DateTime(1990, 1, 1), 1000, 0);
            List<GachaItem> gachaitems1 = new List<GachaItem>
            {
                new GachaItem(100,"Item1",GachaItem.RarityEnum.Common),
                new GachaItem(200,"Item2",GachaItem.RarityEnum.Uncommon),
                new GachaItem(300,"Item3",GachaItem.RarityEnum.Rare)
            };
            List<GachaItem> gachaitems2 = new List<GachaItem>
            {
                new GachaItem(301,"Item1",GachaItem.RarityEnum.Rare),
                new GachaItem(302,"Item2",GachaItem.RarityEnum.Rare),
                new GachaItem(303,"Item3",GachaItem.RarityEnum.Rare)
            };

            ExclusiveBanner exclusiveBanner1 = new ExclusiveBanner(1, "Exclusive Banner", gachaitems1, 
                100, DateTime.Now, DateTime.Now.AddDays(7));
            PermanentBanner permanentBanner1 = new PermanentBanner(1, "First Permanant Banner", gachaitems2,
                100);
        }
    }

}