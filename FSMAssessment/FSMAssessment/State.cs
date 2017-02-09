using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMAssessment
{
    class State
    {
        public State()
        { }
        public State(Enum e)
        {
            name = e.ToString();
        }
        public string name;
        public delegate void OnEnter();
        public delegate void OnExit();
        public OnEnter onEnter;


        public void AddEnterFunction(Delegate d)
        {
            onEnter += d as OnEnter;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
