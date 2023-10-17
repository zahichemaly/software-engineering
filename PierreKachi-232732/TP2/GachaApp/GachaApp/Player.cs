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
        private int Pulls;
        private History history;

        public void Pull() { }
    }
}