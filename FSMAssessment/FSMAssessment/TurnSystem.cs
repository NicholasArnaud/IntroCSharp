
using System.Diagnostics;

namespace FSMAssessment
{
    public class TurnSystem
    {
       

        public TurnSystem() { }

        public void ToStartUp()
        {
            Debug.WriteLine("Start Up");
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