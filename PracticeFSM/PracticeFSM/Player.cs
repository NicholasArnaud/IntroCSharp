using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeFSM
{
    public class Player
    {
        public Player() { }

        public delegate void OnPartyEnd();
        public delegate void OnEndTurn();
        public OnEndTurn onEndTurn;
        public OnPartyEnd onPartyEnd;
        private int strength;
        private int health;
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
        /// <summary>
        /// Ends the turn of a player
        /// </summary>
        void EndTurn()
        {
            if (onEndTurn != null)
                onEndTurn.Invoke();
        }
        /// <summary>
        /// Ends the turn of a team
        /// </summary>
        void EndParty()
        {
            if (onPartyEnd != null)
                onPartyEnd.Invoke();
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