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
        private int enemycharge = 0;
        public Combat()
        {
            
        }

        public void ToEnter()
        {
            Debug.WriteLine("Entering Attack...");
            ToAttack(GameManager.Instance.Aries,GameManager.Instance.Doomsday);
        }

        public void ToAttack(Player current ,Player target)
        {
           enemycharge++;
            Debug.WriteLine("Attacked");
            int dmg = current.Power;
            Random rnd = new Random();
            int crit = rnd.Next(0, 10);
            dmg += crit;
            target.Health -= dmg;
            if (target.Health == 0)
                ToDeath(target);

            if (enemycharge == 3)
            {
                enemycharge = 0;
                current.Health -= target.Power;
            }
        }

        public void ToDeath(Player dead)
        {
            Debug.WriteLine("Player is Dead");
            ToExit();
        }

        public void ToExit()
        {
            Debug.WriteLine("End of Combat");
        }
    }
}
