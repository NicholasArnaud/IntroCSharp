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
        private float enemycharge = GameManager.Instance.Doomsday.Speed;
        private float playercharge = GameManager.Instance.Aries.Speed;
        public Combat()
        {
            //Constructor
        }

        public void ToEnter()
        {
            Debug.WriteLine("Entering Attack...");
            if (GameManager.Instance.Doomsday.Health != 0)
                ToAttack(GameManager.Instance.Aries, GameManager.Instance.Doomsday);
            else
                ToAttack(GameManager.Instance.Aries, GameManager.Instance.Swine);
        }

        public void ToAttack(Player current, Player target)
        {
            int turntoken = 0;
            int dmg = current.Power;
            Random rnd = new Random();
            int crit = rnd.Next(0, 10);
            int enemyCrit = rnd.Next(0, 22);
            if (current.Health != 0)
            {
                dmg += crit;
                target.Health -= dmg;
                turntoken += 1;
            }

            if (target.Health == 0)
                ToDeath(current);
            if (turntoken >= 1)
            {
                current.Health -= (enemyCrit + target.Power);
                turntoken = 0;
            }
            if (enemycharge >= playercharge)
            {
                current.Health -= (enemyCrit + target.Power);
                turntoken +=1;
            }
            Debug.WriteLine("Attacked");
        }

        public void ToDeath(Player current)
        {
            current.Health = current.MaxHealth;
            Debug.WriteLine("Enemy player is Dead");
            ToExit();
        }

        public void ToExit()
        {
            Debug.WriteLine("End of Combat");
        }
    }
}
