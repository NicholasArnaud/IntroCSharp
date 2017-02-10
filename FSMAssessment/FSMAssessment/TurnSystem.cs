
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
            
            Debug.WriteLine("Starting Up");
        }
        public void Idle()
        {
            Debug.WriteLine("Waiting...");
        }
        public void ToChoosePlayer()
        {
            Debug.WriteLine("Choosing Player");
        }
    }
}