using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeFSM
{
    public class Player
    {
        public Player(string namez)
        {
            Strength = 10;
            Health = 100;
            Name = namez;
        }


        public delegate void OnEndTurn();
        public OnEndTurn onEndTurn;
        private int strength;
        private int health;
        private string name;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value <= 0)
                {
                    health = 0;
                }
                health = value;
            }
        }
        public int Strength
        {
            get { return strength; }
            set
            {
                if (value <= 0)
                {
                    strength = 0;
                }

                strength = value;
            }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Ends the turn of a player
        /// </summary>
        public void EndTurn()
        {
            if (onEndTurn != null)
                onEndTurn.Invoke();
        }
        /// <summary>
        /// Attack enemy player
        /// </summary>
        /// <param name="enemy"></param>
        public void Attack(Player enemy)
        {
            enemy.Health -= this.Strength;
            this.EndTurn();
        }
        /// <summary>
        /// Defends player from enemy attack
        /// </summary>
        public void Defend()
        {
            this.EndTurn();
        }
    }
}