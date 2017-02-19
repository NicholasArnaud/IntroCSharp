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
            Player Swine = new Player("Infested Swine", 100, 22, 3.4f, 15);
            Player Doomsday = new Player("Doomsday", 100, 10, 5.5f, 10);
            Player Aries = new Player("Aries", 100, 12, 7.8f, 13);
            Player Jingles = new Player("Jester", 100, 25, 10.3f, 25);
            Player Vyral = new Player("Vyral", 100, 15, 6, 9);
            Player Syran = new Player("Syran", 100, 20, 8.7f, 5);
            Player CurrentPlayer = new Player();
            Player CurrentEnemy = new Player();
            StateSystem<TurnStates> fsm = new StateSystem<TurnStates>();

            TurnManager turnManager = new TurnManager();

            //sets information into singleton
            GameManager.Instance.stateSystem = fsm;
            GameManager.Instance.CurrentPlayer = CurrentPlayer;
            GameManager.Instance.CurrentEnemy = CurrentEnemy;
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