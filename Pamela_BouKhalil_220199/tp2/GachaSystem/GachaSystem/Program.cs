using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using GachaSystem; // Be sure to import your own namespace

Player p1 = new Player(1, 1000);

Exclusive_banner exclusive_Banner= new Exclusive_banner

    {
    Name = "My Exclusive Banner",
    Cost = 50, 
    Items = new List<gacha_item>
    {
        new gacha_item { ID = 100, ItemRarity = gacha_item.Rarity.VeryCommon },
        new gacha_item { ID = 200, ItemRarity = gacha_item.Rarity.Uncommon },
        new gacha_item { ID = 300, ItemRarity = gacha_item.Rarity.Rare }
    },
    startdate= DateTime.Now,
    EndDate = DateTime.Now.AddDays(30) // Set the end date of the banner (adjust as needed)
};

Permanent_banner permanent_banner=new Permanent_banner
{
    Name = "My Permanent Banner",
    Cost = 100, // Set the cost of a single pull
    Items = new List<gacha_item>
    {
        new gacha_item { ID = 301, ItemRarity = gacha_item.Rarity.Rare },
        new gacha_item { ID = 302, ItemRarity = gacha_item.Rarity.Rare },
        new gacha_item { ID = 303, ItemRarity = gacha_item.Rarity.Rare }
    },

    startdate= DateTime.Now
};

foreach (var item in exclusive_Banner.Items) 
{
    Console.WriteLine($"ID: {item.ID},Rarity: {item.ItemRarity}");
}



PerformPulls(p1, exclusive_Banner);

// Perform pulls on the permanent banner
PerformPulls(p1, permanent_banner);

// Write pull history to a file
string filePath = "gacha.txt"; // Adjust the file path as needed
p1.WritePullHistoryToFile(filePath);
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



