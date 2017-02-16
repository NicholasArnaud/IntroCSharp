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
        //sets turn manager variables
        private int turntoken = 0;

        public Combat()
        {
            //Constructor
        }

        public void ToEnter()
        {
            //enters the attack function depending on which enemy is active
            Debug.WriteLine("Entering Attack...");
            if (GameManager.Instance.Doomsday.Health != 0)
                ToAttack(GameManager.Instance.Aries, GameManager.Instance.Doomsday);
            else
                ToAttack(GameManager.Instance.Aries, GameManager.Instance.Swine);
        }

        public void ToAttack(Player current, Player target)
        {
            //sets a dmg value for the current player
            int dmg = current.Power;
            //random function for critial hits
            Random rnd = new Random();
            int crit = rnd.Next(0, 10);
            int enemyCrit = rnd.Next(0, 22);

            //first checks to see if player decided to just end his turn by pressing the "Pass Turn" button
            if (Form1._Form1.checkEndButton() == true)
            {
                //Runs just the enemy's attack 
                current.Health -= (enemyCrit + target.Power);
                turntoken = 0;
                Form1._Form1.updateLog(target.Name + " has attacked " + current.Name + " for " + (enemyCrit + target.Power).ToString() + " damage");
                Debug.WriteLine("Attacked");
                if (current.Health == 0)
                    ToDeath(current);
            }
            else
            {
                //checks to make sure current player and target enemy isn't dead
                if (current.Health != 0 && target.Health != 0)
                {
                    dmg += crit;
                    target.Health -= dmg;
                    Form1._Form1.updateLog(current.Name + " has attacked " + target.Name + " for " + dmg.ToString() + " damage");
                    turntoken += 1;
                } 

                //runs the enemy's turn to attack
                
                if (turntoken >= 1)
                {
                    current.Health -= (enemyCrit + target.Power);
                    turntoken = 0;
                    Form1._Form1.updateLog(target.Name + " has attacked " + current.Name + " for " + (enemyCrit + target.Power).ToString() + " damage");
                }
                //runs death function if the current player is dead or the enemy is dead
                if (target.Health == 0)
                {
                    current.Health = current.MaxHealth;
                    ToDeath(target);
                }
                else if (current.Health == 0)
                    ToDeath(current);

               

                Debug.WriteLine("Attacked");
            }


            //goes to the exit combat function if the current player isnt dead
            if (current.Health != 0)
                ToExit();
        }

        public void ToDeath(Player current)
        {
            Debug.WriteLine("A player is Dead");
            Form1._Form1.updateLog(current.Name + " is dead");

            //If player is dead, it disables the atk button
            if (current.Name == "Aries")
            {
                Form1._Form1.ButtonEnable("AtkButton");
                Form1._Form1.ButtonEnable("Potion");
            }
            GameManager.Instance.Players.Remove(current);

            Form1._Form1.updateHealthBar(GameManager.Instance.Aries, "PlayerHealth");
            Form1._Form1.updateHealthBar(GameManager.Instance.Doomsday, "EnemyHealth");
            //Goes to function to leave the combat state
            ToExit();
        }

        public void ToExit()
        {
            //simply states that the combat state is over
            Form1._Form1.updateLog("End of combat turn...");
            Debug.WriteLine("End of Combat");
        }
    }
}
