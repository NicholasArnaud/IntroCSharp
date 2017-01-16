using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeFSM
{
    public class Party
    {
        public Party() { }
        public List<Player> members;
        public Player current;
        /// <summary>
        /// Adds a player to the list in order they attack
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool AddPlayer(Player a)
        {
            members.Add(a);
            return true;
        }
        /// <summary>
        /// Retreives the next player
        /// </summary>
        /// <returns></returns>
        public Player GetNext()
        {
            for (int i = 0; i < members.Count; i++)
            {
                members.ElementAt(i);
                members.ElementAt(i).onEndTurn();
            }
            return current;
        }


    }
}