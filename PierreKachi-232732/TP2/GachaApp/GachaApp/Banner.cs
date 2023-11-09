using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaApp
{
    public class Banner
    {
        private int ID;
        private String Name;
        private DateTime StartDate;
        private DateTime EndDate;
        private GachaItem[] items;
        private int Cost;

        public GachaItem[] getItems(){
            return items;
        }
        public int getCost(){
            return Cost;
        }
        public List<GachaItem> getFiveStars(){
            List<GachaItem> fiveStars = new List<GachaItem>();
            foreach(GachaItem item in items){
                if(item.getRarity() == 5){
                    fiveStars.Add(item);
                }
            }
            return fiveStars;

            

        }
        
        public List<GachaItem> getThreeStars(){
            List<GachaItem> threeStars = new List<GachaItem>();
            foreach(GachaItem item in items){
                if(item.getRarity() == 3){
                    threeStars.Add(item);
                }
            }
            return threeStars;
        }
        public List<GachaItem> getFourStars(){
            List<GachaItem> fourStars = new List<GachaItem>();
            foreach(GachaItem item in items){
                if(item.getRarity() == 4){
                    fourStars.Add(item);
                }
            }
            return fourStars;}
        public Banner(GachaItem[] items, int cost, DateTime start, DateTime end, int id, string name){
                this.items = items;
                this.Cost = cost;
                this.StartDate = start;
                this.EndDate = end;
                this.ID = id;
                this.Name = name;
                
            }
    }
}