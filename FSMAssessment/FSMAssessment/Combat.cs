using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FSMAssessment
{
     class Combat 
    {
        public Combat()
        {

        }

        public void ToEnter(Player current, Player target)
        {
            ToAttack(current, target);
        }

        public void ToAttack(Player current ,Player target)
        {
            target.Health -= current.Power;

            if (target.Health == 0)
                ToDeath(target);
        }

        public void ToDeath(Player dead)
        {
            Debug.WriteLine("Player is Dead");
            ToExit();
        }

        public void ToExit()
        {
            
        }
    }
}
