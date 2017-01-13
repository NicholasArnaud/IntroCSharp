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


        void EndTurn()
        {
            if (onEndTurn != null)
                onEndTurn.Invoke();
        }
        void EndParty()
        {
            if (onPartyEnd != null)
                onPartyEnd.Invoke();
        }

        public void Attack() { }
        public void Defend() { }

    }
}