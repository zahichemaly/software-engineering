using System.Numerics;

namespace GachaSystem
{
    class Program
    {
        

        static void Main(string[] args)
        {
            
            Player player = new Player("Elie","H",1000);

            ExclusiveBanner rami = new();
            GachaItem item1 = new GachaItem(100,"Item1", Rarity.ThreeStar);
            GachaItem item2 = new GachaItem(200, "Item2", Rarity.FourStar);
            GachaItem item3 = new GachaItem(300, "Item3", Rarity.FiveStar);

            rami.Items.Add(item1);
            rami.Items.Add(item2);
            rami.Items.Add(item3);
            
            rami.StartDate = DateTime.Now;
            rami.EndDate = DateTime.Now.AddMinutes(1);
            rami.Cost = 1;


            PermanentBanner PB = new();
            GachaItem item4 = new GachaItem(301, "Item4", Rarity.FiveStar);
            GachaItem item5 = new GachaItem(302, "Item5", Rarity.FiveStar);
            GachaItem item6 = new GachaItem(303, "Item6", Rarity.FiveStar);

            PB.PermanentItems.Add(item4);
            PB.PermanentItems.Add(item5);
            PB.PermanentItems.Add(item6);

            for (int i = 1; i <= 10; i++)
            {
                GachaItem item = PerformPull(player, rami, PB);
                Console.WriteLine("Pull " + i + " : " + item.rarity + "," + item.Name);
            }
            WritePullHistoryToFile(player.PullHistory, player);
        }

        static void WritePullHistoryToFile(List<GachaItem> pullHistory, Player player)
        {
            string filePath = "C:/Users/popsmokkr/Desktop/gacha.txt";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var item in pullHistory)
                {
                    string pcName = Environment.MachineName;
                    string pcUsername = Environment.UserName;
                    int pullNumber = pullHistory.IndexOf(item) + 1;

                    string line = $"{pcName} {pcUsername} [{pullNumber}] [{player.PityCounter}] [{item.ID}] ";

                    if (item.rarity == Rarity.ThreeStar)
                    {
                        line += "3-star";
                    }   
                    else if (item.rarity == Rarity.FourStar)
                    {
                        line += $"4-star *";
                    }
                    else if (item.rarity == Rarity.FiveStar)
                    {
                        string bannerType = (item.Name.Contains("PERM")) ? "PERM" : "EXCL";
                        bool won5050 = (item.Name.Contains("True")) ? true : false;
                        line += $"5-star ##### [{bannerType}] [{won5050}]";
                    }

                    writer.WriteLine(line);
                }
            }
        }

        static void PerformPulls(Player player, ExclusiveBanner exclusiveBanner, PermanentBanner permanentBanner)
        {
            while (player.Balance >= exclusiveBanner.Cost || player.Balance >= permanentBanner.Cost)
            {
                GachaItem item = PerformPull(player, exclusiveBanner, permanentBanner);
                Console.WriteLine("You pulled a " + item.rarity + "," + item.Name);
            }
        }


        public static GachaItem PerformPull(Player player, ExclusiveBanner exclusiveBanner, PermanentBanner permanentBanner)
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 101); 

            Rarity rarity;
            if (randomNumber <= 2) 
                rarity = Rarity.FiveStar;
            else if (randomNumber <= 20) 
                rarity = Rarity.FourStar;
            else
                rarity = Rarity.ThreeStar;

            
            GachaItem item;

            if (rarity == Rarity.FiveStar)
            {
                
                bool hasReachedPityLimit = player.CheckFor5StarPity();
                if (hasReachedPityLimit)
                {
                    item = permanentBanner.PullRandom5StarItem();
                }
                else
                {
                    item = exclusiveBanner.PullRandom5StarItem();
                }
            }
            else
            {
                item = CreateRandomItem(rarity);
            }

            
            int cost = 100; 
            player.Balance -= cost;

           
            player.AddToPullHistory(item);

            return item;
        }

        static GachaItem CreateRandomItem(Rarity rarity)
        {
            Random random = new Random();
            string itemName = "";

            switch (rarity)
            {
                case Rarity.ThreeStar:
                    itemName = "3-Star Item";
                    break;
                case Rarity.FourStar:
                    itemName = "4-Star Item";
                    break;
                case Rarity.FiveStar:
                    itemName = "5-Star Item";
                    break;
                default:
                    itemName = "Unknown Item";
                    break;
            }

            
            return new GachaItem(0, itemName, rarity);
        }

        static void DisplayPullHistory(List<GachaItem> pullHistory)
        {
            Console.WriteLine("\nPull History:");
            foreach (GachaItem item in pullHistory)
            {
                Console.WriteLine(item.rarity + "," + item.Name);
            }
        }
    }
}




