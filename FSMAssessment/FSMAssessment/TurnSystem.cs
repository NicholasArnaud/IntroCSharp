
using System.Diagnostics;

namespace FSMAssessment
{
    public class TurnSystem
    {
        public TurnSystem()
        {
            //Constructor
        }

        public void ToStartUp()
        {
            GameManager.Instance.currentState = "IDLE";
            Debug.WriteLine("Starting Up");
        }

        public void Idle()
        {
            Debug.WriteLine("Waiting...");
        }

        public void ToChoosePlayer()
        {
            Debug.WriteLine("Choosing Player Turns");
            Debug.WriteLine("Turn Order: ");
            GameManager.Instance.Players.ForEach((x => Debug.WriteLine(GameManager.Instance.Players.IndexOf(x) + " " + x.ToString())));
        }

        public void ToEndTurn()
        {
            Form1._Form1.updateLog("\n" + "End of Turn" + "\n");
            Debug.WriteLine("Ending Turn");
        }
    }
}