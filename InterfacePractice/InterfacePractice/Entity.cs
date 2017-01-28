using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractice
{
    class Entity
    {
        #region Constructors
        public Entity() { }
        public Entity(string name,int h, int att)
        {
            Name = name; 
            Health = h;
            AttackPower = att;
        }
        #endregion

        #region getters & setters
        public int Health
        {
            get { return health; }
            set
            {
                if (value <= 0)
                    health = 0;
                else
                    health = value;
            }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int AttackPower
        {
            get { return attackPower; }
            set { attackPower = value; }
        }
        #endregion

        
        private int attackPower;
        private string name;
        private int health;
    }
}
