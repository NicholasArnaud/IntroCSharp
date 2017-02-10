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
            Player Doomsday = new Player("Doomsday", 100, 10);
            Player Aries = new Player("Aries", 100, 3);
            FSM<TurnStates> fsm = new FSM<TurnStates>();
            Combat combat = new Combat();
            TurnSystem turnManager = new TurnSystem();
            GameManager.Instance.turnManager = turnManager;
            GameManager.Instance.combat = combat;
            GameManager.Instance.fsm = fsm;
            GameManager.Instance.Aries = Aries;
            GameManager.Instance.Doomsday = Doomsday;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}