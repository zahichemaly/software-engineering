using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using GachaSystem; // Be sure to import your own namespace

namespace GachaSystem
{
    class Program
    {
        static void Main()
        {
            Player player = new Player(1, 1000);

            exclusive_banner exclusive_Banner = new exclusive_banner

            {
                Name = "Exclusive Banner 1",
                Cost = 50,
                Items = new List<gacha_item>
                {
                    new gacha_item { ID = 100, Rarity = Rarity.Common },
                    new gacha_item { ID = 200, Rarity = Rarity.Uncommon },
                    new gacha_item { ID = 300, Rarity = Rarity.Rare }
                },
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(30) 
            };

            permanent_banner permanent_banner = new permanent_banner
            {
                Name = "Permanent Banner 1",
                Cost = 100, // Set the cost of a single pull
                Items = new List<gacha_item>
                {
                    new gacha_item { ID = 301, Rarity = Rarity.Rare },
                    new gacha_item { ID = 302, Rarity = Rarity.Rare },
                    new gacha_item { ID = 303, Rarity = Rarity.Rare }
                },

                StartDate = DateTime.Now
            };

            foreach (var item in exclusive_Banner.Items)
            {
                Console.WriteLine($"ID: {item.ID},Rarity: {item.Rarity}");
            }



            PerformPulls(player, exclusive_Banner);

            // Perform pulls on the permanent banner
            PerformPulls(player, permanent_banner);

            // Write pull history to a file
            string filePath = "gacha.txt"; // Adjust the file path as needed
            player.WritePullHistoryToFile(filePath);
            admin_user admin = new admin_user();

            // Update the cost of the exclusive banner
            admin.UpdateBannerCost(exclusive_Banner, 60);

            static void PerformPulls(Player player, Banner banner)
            {
                while (player.Balance >= banner.Cost)
                {
                    player.PerformPull(banner);
                }
            }
        }
    }
}