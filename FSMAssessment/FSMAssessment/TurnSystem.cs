using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FSMAssessment
{
    public class TurnSystem
    {
       

        public TurnSystem() { }

        public void ToStartUp()
        {
            ToIdle();
        }

        public void ToIdle()
        {
            ToChoosePlayer();
        }

        public void ToChoosePlayer()
        {
        }
    }
}