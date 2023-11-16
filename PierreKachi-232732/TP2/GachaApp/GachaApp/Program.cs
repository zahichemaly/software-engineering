using System;
using GachaApp;

public class Program
{
    public static void Main()
    {
        Player pierre = new Player(1, "Pierre", "Kachi", DateTime.Now, 0);
        pierre.AddBalance(1000);
        GachaItem[] items1 = new GachaItem[3];
        items1[0] = new GachaItem("Item1", 1, 3);
        items1[1] = new GachaItem("Item1", 2, 4);
        items1[2] = new GachaItem("Item1", 3, 5);
        ExclusiveB banner1 = new ExclusiveB(items1, 100, DateTime.Now, DateTime.Now, 1, "excb1");

        GachaItem[] items2 = new GachaItem[3];
        items2[0] = new GachaItem("Item1", 4, 5);
        items2[1] = new GachaItem("Item1", 5, 5);
        items2[2] = new GachaItem("Item1", 6, 5);
        PermanentB banner2 = new PermanentB(items2, 100, DateTime.Now, DateTime.Now, 1, "excb2");

        while (pierre.getBalance() > banner1.getCost())
        {
            pierre.excPull(banner1, banner2);
        }
        var path = "C:\\Users\\pierre\\Desktop\\uni shit\\soft eng\\ex1\\software-engineering\\PierreKachi-232732\\TP2\\GachaApp\\GachaApp\\gacha.txt";
        using (StreamWriter writer = new StreamWriter(path))
        {
            foreach (var history in pierre.getHistory())
            {
                string s = "";
                if (history.GetItem().getRarity() == 3)
                {
                    s = "Three Star";
                }
                else if (history.GetItem().getRarity() == 4)
                {
                    s = "Four Star";
                }
                else
                {
                    s = "Five Star";
                }
                string line = $"{Environment.MachineName} {Environment.UserName} " +
                                                 $"[{pierre.getHistory().Count}] [{history.GetPullNumber()}] " +
                                                 $"[{history.GetItem().getId()}] {s}";

                writer.WriteLine(line);
            }
        }






    }
}
