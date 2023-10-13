using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GashaSystem.GachaItem;

namespace GashaSystem
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Player player = new Player
			{
				ID = 1,
				FirstName = "Felix",
				LastName = "hajj",
				DateOfBirth = new DateTime(1990, 5, 15),
				Balance = 1000,
			};

			ExclusiveBanner exclusiveBanner = new ExclusiveBanner
			{
				ID = 1,
				Name = "exclusive Banner",
				StartDate = new DateTime(2023, 10, 13),
				EndDate = new DateTime(2023, 10, 22),
				Cost = 100,
				Items = new List<GachaItem>
			{
				new GachaItem { ID = 100, Name = "3-Star Item", Rarity = GachaItem.Rarity.ThreeStar },
				new GachaItem { ID = 200, Name = "4-Star Item", Rarity = GachaItem.Rarity.FourStar },
				new GachaItem { ID = 300, Name = "5-Star Item", Rarity = GachaItem.Rarity.FiveStar }

			}
			};

			PermanentBanner permanentBanner = new PermanentBanner
			{
				Name = "Legendary Banner",
				Items = new List<GachaItem>
				{
					new GachaItem { ID = 301, Name = "5-Star Item 1", Rarity = GachaItem.Rarity.FiveStar },
					new GachaItem { ID = 302, Name = "5-Star Item 2", Rarity = GachaItem.Rarity.FiveStar },
					new GachaItem { ID = 303, Name = "5-Star Item 3", Rarity = GachaItem.Rarity.FiveStar }
				}
			};

			Random random = new Random();
			int totalPulls = 0;
			List<PullHistoryEntry> pullHistory = new List<PullHistoryEntry>();

			while (player.Balance > 0)
			{
				 int randomValue = random.Next(1, 101);
				  Rarity pulledRarity;
			
				  if (randomValue <= 2)
				  {
				     pulledRarity = GachaItem.Rarity.FiveStar;
				  }
				  else if (randomValue <= 20)
				 {
				      pulledRarity = GachaItem.Rarity.FourStar;
				  }
				  else
				  {
				     pulledRarity = GachaItem.Rarity.ThreeStar;
				 }

				  /*
				  int pityCounter = 0;
				 bool is5050Lost = false;


				  pullHistory.Add(new PullHistoryEntry
				  {
					    ItemID =
					    PullNumber = totalPulls + 1,
					    PityCounter = pityCounter,
					    Rarity = pulledRarity,
					    Is5050 = is5050Lost
				  });

				  player.Balance--;
				 totalPulls++;
				 */
			}


		}
	}

}
