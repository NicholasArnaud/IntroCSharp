
using System.Diagnostics;

namespace FSMAssessment
{
    public class TurnSystem
    {
        int i = 0;
        public TurnSystem()
        {
            //Constructor
        }

        public void ToStartUp()
        {
            Debug.WriteLine("Starting Up");
            GameManager.Instance.currentState = "IDLE";
        }

        public void Idle()
        {
            Debug.WriteLine("Waiting...");
            GameManager.Instance.CurrentPlayer = GameManager.Instance.Players[0];
        }

        public void ToChoosePlayer()
        {
            i++;
            if (i == GameManager.Instance.Players.Count) i = 0;
            Debug.WriteLine("Choosing Player Turns");
            Debug.WriteLine("Turn Order: ");
            // Lambda function to iterate through the entire length of the list and prints the order of players in the debugger
            GameManager.Instance.Players.ForEach((x => Debug.WriteLine(GameManager.Instance.Players.IndexOf(x) + " " + x.ToString())));
           // GameManager.Instance.CurrentPlayer = GameManager.Instance.Players[i];
            Debug.WriteLine("Current Player is: " + GameManager.Instance.CurrentPlayer.Name);
        }

        public void ToEndTurn()
        {
            Form1._Form1.UpdateLog("\n" + "End of Turn" + "\n");
            Debug.WriteLine("Ending Turn");
        }
    }
}