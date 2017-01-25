using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LightFSM
{

    class FSM
    {
        public FSM(Stopwatch sw)
        {
            stopWatch = sw;
        }

        public enum State
        {
            INIT,
            RED,
            YELLOW,
            GREEN,
            EXIT,
        }
        public Stopwatch stopWatch;


        //State handlers
        public void RedLight()
        {
            Console.WriteLine(stopWatch.Elapsed.Seconds);
            stopWatch.Restart();
        }
        public void Init()
        {stopWatch.Start(); }
        public void Exit()
        {Console.WriteLine("Quit program");}
        //....

       

        //   List<State> States = new List<State>();
        // List<Transition> Transitions = new List<Transition>();
        //  Dictionary<Enum, List<Transition>> transitionTable;
        public State current;
        public void ChangeState(State s)
        {
            switch (s)
            {
                case State.INIT:
                    current = State.INIT;
                    Init();
                    break;
                case State.RED:
                    current = State.RED;
                    RedLight();
                    break;
                    //...
            }

        }
        public void Update()
        {
            switch (current)
            {
                case State.INIT:
                    ChangeState(State.RED);
                    break;
                case State.RED:
                    if (stopWatch.Elapsed.Seconds >= 2)
                        ChangeState(State.GREEN);
                    break;
                    //...
            }

        }

        public void  Start()
        {
            ChangeState(State.INIT);
        }


        //public void AddState(State s)
        //{
        //    States.Add(s);
        //}

        //public void AddTransition(Transition t)
        //{
        //    Transitions.Add(t);
        //}

        //public void Feed(State to)
        //{
        //    transitionTable = new Dictionary<Enum, List<Transition>>();
        //}

    }
}