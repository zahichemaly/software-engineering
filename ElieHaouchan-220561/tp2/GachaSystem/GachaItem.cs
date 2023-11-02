using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GachaSystem
{
    public class GachaItem
    {

        public int ID
        {
            get => default;
            set
            {
            }
        }

        public string Name
        {
            get => default;
            set
            {
            }
        }

        public Rarity rarity; 

        public GachaItem(int ID, string Name, Rarity rarity)
        {
            this.ID = ID;
            this.Name = Name;
            rarity= new Rarity();
        }


    }
}