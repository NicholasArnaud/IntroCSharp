using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMAssessment
{
    class GameManager
    {
        private static GameManager instance = null;
        private GameManager()
        {
        }
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();

                }
                return instance;
            }
        }
        public FSM<TurnStates> fsm;
        public string current;
    }
}
