using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMAssessment
{
    enum Turns
    {
        IDLE = 1,
        TEAMA = 2,
        TEAMB = 3,
        ENDTURN =99,

    }
    public class TurnSystem
    {
        public TurnSystem() { }
        FSM<Turns> turnSystem;

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

        public void ToEnterCombat(Player current)
        {
            
        }

        public void ToEndTurn()
        {
            throw new NotImplementedException();
        }
    }
}