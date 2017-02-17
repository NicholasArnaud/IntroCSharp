using System;
using System.Diagnostics;

namespace FSMAssessment
{
    class Combat
    {
        //sets turn manager variables
        private int turntoken = 0;
        public string combatLog;        

        public Combat()
        {
            //Constructor
        }

        public void ToEnter()
        {
            GameManager gm = GameManager.Instance;
            //enters the attack function depending on which enemy is active
            Debug.WriteLine("Entering Attack...");
            if (gm.Doomsday.Health != 0 && gm.CurrentPlayer.Health != 0)
                ToAttack(gm.CurrentPlayer, gm.Doomsday);
            else if (gm.Swine.Health != 0 && gm.CurrentPlayer.Health != 0)
                ToAttack(gm.CurrentPlayer, gm.Swine);
            //else if (GameManager.Instance.Doomsday.Health != 0 && GameManager.Instance.Jingles.Health != 0)
            //    ToAttack(GameManager.Instance.Jingles, GameManager.Instance.Doomsday);
            //else if (GameManager.Instance.Swine.Health != 0 && GameManager.Instance.Jingles.Health != 0)
            //    ToAttack(GameManager.Instance.Jingles, GameManager.Instance.Swine);
            else
                return;
        }
        public void PassAttack(Player player, Player enemy)
        {
            //Runs just the enemy's attack 
            player.Health -= enemy.Power;
            turntoken = 0;
            combatLog += enemy.Name + " has attacked " + player.Name + " for " + enemy.Power.ToString() + " damage \n";
            Debug.WriteLine("Attacked");
            if (player.Health == 0)
            {
                ToDeath(player);
                return;
            }
            ToExit();
        }
        public void ToAttack(Player current, Player target)
        {
            //sets a dmg value for the current player
            int dmg = current.Power;
            //random function for critial hits
            Random rnd = new Random();
            int crit = rnd.Next(0, 10);
            int enemyCrit = rnd.Next(0, 22);

            //checks to make sure current player and target enemy isn't dead
            if (current.Health != 0 && target.Health != 0)
            {
                dmg += crit;
                target.Health -= dmg;
                combatLog += current.Name + " has attacked " + target.Name + " for " + dmg.ToString() + " damage \n";
                turntoken += 1;
            }

            //runs the enemy's turn to attack
            if (turntoken >= 1)
            {
                current.Health -= (enemyCrit + target.Power);
                turntoken = 0;
                combatLog += target.Name + " has attacked " + current.Name + " for " + (enemyCrit + target.Power).ToString() + " damage \n";
            }
            
            Debug.WriteLine("Attacked");


            //runs death function if the current player is dead or the enemy is dead
            if (target.Health == 0)
            {
                current.Health = current.MaxHealth;
                ToDeath(target);
                return;
            }
            else if (current.Health == 0)
            {
                ToDeath(current);
                return;
            }
            //goes to the exit combat function if the current player isnt dead
            if (current.Health != 0)
                ToExit();
        }

        public void ToDeath(Player current)
        {
            Debug.WriteLine("A player is Dead");
            combatLog += current.Name + " is dead \n";
          //  GameManager.Instance.Players.Remove(current);
            //Goes to function to leave the combat state
            ToExit();
        }

        public void ToExit()
        {
            //simply states that the combat state is over
            combatLog += "End of combat turn... \n";
            combatLog += "-------------------------- \n";
            Debug.WriteLine("End of Combat");
        }
    }
}