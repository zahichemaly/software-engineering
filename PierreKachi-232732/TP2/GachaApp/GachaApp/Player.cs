using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaApp
{
    public class Player : User
    {
        private int ID;
        private string FirstName;
        private string LastName;
        private DateTime DateOfBirth;
        private int Balance;
        private int pityPulls;
        private List<historyItem> history = new List<historyItem>();
        private List<GachaItem> inventory = new List<GachaItem>();
        private bool fiftyFifty = false;


        public Player(int id, string firstName, string lastName, DateTime d, int balance)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Balance = 0;
            pityPulls = 0;
            DateOfBirth = d;
            Balance = balance;
        }
        public List<historyItem> getHistory()
        {
            return history;
        }
        public int getBalance()
        {
            return Balance;
        }
        public void addToInv(GachaItem item)
        {
            inventory.Add(item);
        }
        public Player() { }
        public void AddBalance(int amount)
        {
            Balance += amount;
        }
        public void excPull(Banner excBanner, Banner permBanner)
        {

            if (Balance > excBanner.getCost())
            {
                Random rnd = new Random();
                GachaItem pulledItem = new GachaItem();
                if (pityPulls == 59)//heyde ya3ne this is his 60th pull
                {
                    int r2 = rnd.Next(0, 2);
                    if (r2 == 0)
                    {
                        GachaItem[] items = permBanner.getFiveStars().ToArray();
                        pulledItem = items[rnd.Next(0, items.Length)];
                        addToInv(pulledItem);
                        fiftyFifty = true;
                        ;


                    }
                    else
                    {

                        GachaItem[] items1 = excBanner.getFiveStars().ToArray();
                        pulledItem = items1[rnd.Next(0, items1.Length)];
                        addToInv(pulledItem);


                    }
                    fiftyFifty = false;
                    historyItem h2 = new historyItem(pulledItem, excBanner, DateTime.Now, pityPulls);
                    history.Add(h2);
                    return;
                }
                int r = rnd.Next(1, 101);
                if (r <= 80)
                {
                    GachaItem[] items = excBanner.getThreeStars().ToArray();
                    pulledItem = items[rnd.Next(0, items.Length)];
                    addToInv(pulledItem);


                }
                else if (r <= 98 && r > 80)
                {
                    GachaItem[] items = excBanner.getFourStars().ToArray();
                    pulledItem = items[rnd.Next(0, items.Length)];
                    addToInv(pulledItem);

                }
                else
                {
                    if (fiftyFifty)
                    {
                        GachaItem[] items = excBanner.getFiveStars().ToArray();
                        pulledItem = items[rnd.Next(0, items.Length)];
                        addToInv(pulledItem);
                        historyItem h1 = new historyItem(pulledItem, excBanner, DateTime.Now, pityPulls);
                        history.Add(h1);
                        pityPulls = 0;
                        return;
                    }
                    else
                    {
                        int r2 = rnd.Next(0, 2);
                        if (r2 == 0)
                        {
                            GachaItem[] items = permBanner.getFiveStars().ToArray();
                            pulledItem = items[rnd.Next(0, items.Length)];
                            addToInv(pulledItem);
                            fiftyFifty = true;
                            historyItem h3 = new historyItem(pulledItem, excBanner, DateTime.Now, pityPulls);
                            history.Add(h3);
                            pityPulls = 0;

                            return;
                        }
                        else
                        {

                            GachaItem[] items1 = excBanner.getFiveStars().ToArray();
                            pulledItem = items1[rnd.Next(0, items1.Length)];
                            addToInv(pulledItem);
                            fiftyFifty = false;
                            historyItem h4 = new historyItem(pulledItem, excBanner, DateTime.Now, pityPulls);
                            history.Add(h4);
                            pityPulls = 0;

                            return;//to not mess up the pulls


                        }
                    }
                }


                Balance -= excBanner.getCost();
                pityPulls++;
                historyItem h = new historyItem(pulledItem, excBanner, DateTime.Now, pityPulls);
                history.Add(h);
            }
            else
            {
                Console.WriteLine("Not enough money");
            }

        }

        public void standardPull(Banner banner)
        {
            Random rnd = new Random();
            GachaItem pulledItem = new GachaItem();

            if (Balance > banner.getCost())
            {

                if (pityPulls == 59)
                {


                    GachaItem[] items1 = banner.getFiveStars().ToArray();
                    pulledItem = items1[rnd.Next(0, items1.Length)];
                    addToInv(pulledItem);

                    historyItem h1 = new historyItem(pulledItem, banner, DateTime.Now, pityPulls);
                    history.Add(h1);
                    pityPulls = 0;
                    return;
                }



                int r = rnd.Next(1, 101);
                if (r <= 80)
                {
                    GachaItem[] items = banner.getThreeStars().ToArray();
                    pulledItem = items[rnd.Next(0, items.Length)];
                    addToInv(pulledItem);
                    pityPulls++;


                }
                else if (r <= 98 && r > 80)
                {
                    GachaItem[] items = banner.getFourStars().ToArray();
                    pulledItem = items[rnd.Next(0, items.Length)];
                    addToInv(pulledItem);
                    pityPulls++;


                }
                else
                {


                    GachaItem[] items1 = banner.getFiveStars().ToArray();
                    pulledItem = items1[rnd.Next(0, items1.Length)];
                    addToInv(pulledItem);
                    historyItem h5 = new historyItem(pulledItem, banner, DateTime.Now, pityPulls);
                    history.Add(h5);
                    pityPulls = 0;
                    return;





                }
                historyItem h = new historyItem(pulledItem, banner, DateTime.Now, pityPulls);
                history.Add(h);
                Balance -= banner.getCost();

            }
            else
            {
                Console.WriteLine("Not enough money");
            }

        }
    }
}

