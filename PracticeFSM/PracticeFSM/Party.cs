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
        public bool AddPlayer(Player a)
        {
            members.Add(a);
            return true;
        }
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