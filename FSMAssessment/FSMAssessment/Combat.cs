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

        private int turntoken = 0;
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

            int dmg = current.Power;
            Random rnd = new Random();
            int crit = rnd.Next(0, 10);
            int enemyCrit = rnd.Next(0, 22);


            if (current.Health != 0)
            {
                dmg += crit;
                target.Health -= dmg;
                Form1._Form1.updateLog(current.Name + " has attacked " + target.Name + " for " + dmg.ToString() + " damage");
                turntoken += 1;
            }

            if (turntoken >= 1)
            {
                current.Health -= (enemyCrit + target.Power);
                turntoken = 0;
                Form1._Form1.updateLog(target.Name + " has attacked " + current.Name + " for " + (enemyCrit + target.Power).ToString() + " damage" + "\n");
            }
            if (target.Health == 0)
                ToDeath(target);
            if (current.Health == 0)
                ToDeath(current);
            Debug.WriteLine("Attacked");
            if (current.Health != 0)
                ToExit();
        }

        public void ToDeath(Player current)
        {
            Debug.WriteLine("A player is Dead");
            Form1._Form1.updateLog(current.Name + " is dead");
            Form1._Form1.Buttonenabler("AtkButton");
            ToExit();
        }

        public void ToExit()
        {
            Form1._Form1.updateLog("End of combat turn...");
            Debug.WriteLine("End of Combat");
        }
    }
}
