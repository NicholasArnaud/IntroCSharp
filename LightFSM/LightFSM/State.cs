using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LightFSM
{
    public delegate void Handler();
    class State
    {
        //enum States
        //{
        //    INIT = 0,
        //    GREEN = 1,
        //    YELLOW = 2,
        //    RED = 3,
        //    END = 9000,
        //}

        public Delegate currrentDel;
        public State currenetState;
        public State(State s, Delegate del)
        {
            currenetState = s;
            currrentDel = del;
        }

        public bool Handler()
        {
            Handler h;
            if (currrentDel != null)
            {
                h = currrentDel as Handler;
                h();
                return true;
            }
            return false;
        }
    }
}