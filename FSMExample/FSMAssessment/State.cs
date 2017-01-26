using System;
using System.Collections.Generic;
using System.IO;

namespace FSMAssessment
{
    public delegate void Handler();
    class State
    {
        public 
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
