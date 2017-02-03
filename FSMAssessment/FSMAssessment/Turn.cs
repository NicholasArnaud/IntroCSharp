using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMAssessment
{
    class Turn 
    {
        Turn() { }
        public void ToStartUp()
        {
            
        }

        public void ToIdle()
        {
            throw new NotImplementedException();
        }

        public void ToChoosePlayer()
        {
            throw new NotImplementedException();
        }

        public void ToEndTurn()
        {
            throw new NotImplementedException();
        }

        public void ToEnterCombat(Player attacker)
        {
            Combat Entercom = new Combat();
            Entercom.ToEnter(attacker);
        }
        
    }
}
