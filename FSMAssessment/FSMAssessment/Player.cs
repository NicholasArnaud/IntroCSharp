using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMAssessment
{
    public class Player
    {
        Player(string Name, int Health, int Power )
        {
            name = Name;
            health = Health;
            power = Power;
        }
        public int Health
        {
            get { return health; }
            set
            {
                if (value <= 0) health = value;
                else health = 0;
            }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public string Name
        {
            get { return name; }
        }

        private string name;
        private int health;
        private int power;
    }
}
