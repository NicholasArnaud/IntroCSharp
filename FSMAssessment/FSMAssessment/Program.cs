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
            Player Swine = new Player("Infested Swine", 120, 22, 3.4f);
            Player Doomsday = new Player("Doomsday", 100, 1, 5.5f);
            Player Aries = new Player("Aries", 100, 3, 7.8f);
            FSM<TurnStates> fsm = new FSM<TurnStates>();


            GameManager.Instance.fsm = fsm;
            GameManager.Instance.Aries = Aries;
            GameManager.Instance.Doomsday = Doomsday;
            GameManager.Instance.Swine = Swine;
            Combat combat = new Combat();
            TurnSystem turnManager = new TurnSystem();
            GameManager.Instance.turnManager = turnManager;
            GameManager.Instance.combat = combat;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}