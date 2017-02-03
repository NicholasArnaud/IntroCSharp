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
    public class TurnSystem : ITurnManager
    {
        TurnSystem() { }
        FSM<Turns> turnSystem;

        public void ToStartUp()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void ToEndTurn()
        {
            throw new NotImplementedException();
        }
    }
}