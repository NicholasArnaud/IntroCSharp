using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSMAssessment
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GameManager.Instance.Players = new List<Player>();
            //creates all the needed entities on the start of the process
            Player Swine = new Player("Infested Swine", 120, 22, 3.4f);
            Player Doomsday = new Player("Doomsday", 100, 1, 5.5f);
            Player Aries = new Player("Aries", 100, 10, 7.8f);
            Player Jingles = new Player("Jester", 72, 25, 10.3f);
            Player CurrentPlayer = new Player();
            StateSystem<TurnStates> fsm = new StateSystem<TurnStates>();

            TurnSystem turnManager = new TurnSystem();

            //sets information into singleton
            GameManager.Instance.fsm = fsm;
            GameManager.Instance.CurrentPlayer = CurrentPlayer;
            GameManager.Instance.Aries = Aries;
            GameManager.Instance.Doomsday = Doomsday;
            GameManager.Instance.Swine = Swine;
            GameManager.Instance.Jingles = Jingles;
            GameManager.Instance.turnManager = turnManager;


            Combat combat = new Combat();
            GameManager.Instance.combat = combat;


            //Default
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}