using System;
using System.IO;
using System.Collections.Generic;

namespace GachaSystem
{
    class Program
    {
        static void Main(string[] args)
        {
             Player player = new Player
            {
                ID = 1,
                FirstName = "rami",
                LastName = "chalouhi",
                Balance = 1000
            };
             ExclusiveBanner exclusiveBanner = new ExclusiveBanner
            {
                ID = 1,
                Name = "Exclusive Banner",
                Cost = 100,
                Items = new List<GachaItem>
    {
        new GachaItem { ID = 100, Name = "3-Star", ItemRarity = GachaItem.Rarity.ThreeStar },
        new GachaItem { ID = 200, Name = "4-Star", ItemRarity = GachaItem.Rarity.FourStar },
        new GachaItem { ID = 300, Name = "5-Star", ItemRarity = GachaItem.Rarity.FiveStar }
    }
            };



             Random random = new Random();
            List<string> histories = new List<string>();

            while (player.Balance >= exclusiveBanner.Cost)
            {
                player.PerformPull(exclusiveBanner);
            }
        }
    }
}
