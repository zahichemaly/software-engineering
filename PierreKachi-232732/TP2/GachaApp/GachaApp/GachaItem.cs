using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GachaApp
{
    public class GachaItem
    {
        private int ID;
        private String Name;

        public enum Rarity
        {
            ThreeStar,
            FourStar,
            FiveStar
        };
        private Rarity rarity;
        public int getId(){
            return ID;
        }
        public GachaItem(string name, int id, int rarity)
        {
            this.Name = name;
            this.ID = id;
            switch (rarity)
            {
                case 3:
                    this.rarity = Rarity.ThreeStar;
                    break;
                case 4:
                    this.rarity = Rarity.FourStar;
                    break;
                case 5:
                    this.rarity = Rarity.FiveStar;
                    break;

            }
        
        }
        public GachaItem() { }
        public int getRarity(){
            switch (rarity)
            {
                case Rarity.ThreeStar:
                    return 3;
                case Rarity.FourStar:
                    return 4;
                case Rarity.FiveStar:
                    return 5;
                default:
                    return 0;
            }
            

        }
    }
}
