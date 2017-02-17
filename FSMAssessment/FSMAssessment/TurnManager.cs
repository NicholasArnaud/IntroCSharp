
using System.Diagnostics;

namespace FSMAssessment
{
    public class TurnManager
    {
        int i = 0;
        public TurnManager()
        {
            //Constructor
        }

        public void ToStartUp()
        {
            Debug.WriteLine("Starting Up");
            GameManager.Instance.currentState = "IDLE";
            GameManager.Instance.CurrentPlayer = GameManager.Instance.Players[0];
            GameManager.Instance.CurrentEnemy = GameManager.Instance.Players[1];
        }

        public void ToIdle()
        {
            Debug.WriteLine("Waiting...");
            if(GameManager.Instance.CurrentPlayer.IsDead)
            {
                GameManager.Instance.combat.ChangePlayer(GameManager.Instance.Players[2]);
                Form1._Form1.SetMaxHealthBar();
            }
            if(GameManager.Instance.CurrentEnemy.IsDead)
            {
                GameManager.Instance.combat.ChangeEnemy(GameManager.Instance.Players[3]);
                Form1._Form1.SetMaxHealthBar();
            }
        }

        public void ToChoosePlayer()
        {
            i++;
            if (i == GameManager.Instance.Players.Count) i = 0;
            Debug.WriteLine("Choosing Player Turns");
            Debug.WriteLine("Turn Order: ");
            // Lambda function to iterate through the entire length of the list and prints the order of 
            //players in the debugger
            GameManager.Instance.Players.ForEach((x => 
                Debug.WriteLine(GameManager.Instance.Players.IndexOf(x) + " " + x.ToString())));
            Debug.WriteLine("Current Player is: " + GameManager.Instance.CurrentPlayer.Name);
            Debug.WriteLine("Current Player is: " + GameManager.Instance.CurrentEnemy.Name);
        }

        public void ToEndTurn()
        {
            GameManager.Instance.currentState = "IDLE";
            ToIdle();
            Form1._Form1.UpdateLog("\n" + "End of Turn" + "\n");
            Debug.WriteLine("Ending Turn");            
        }
    }
}