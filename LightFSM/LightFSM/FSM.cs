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
        //enum state names
        public enum State
        {
            INIT,
            RED,
            YELLOW,
            GREEN,
            EXIT,
        }

        //set name for stopwatch
        public Stopwatch stopWatch;

        //conditional
        public FSM(Stopwatch sw)
        {
            stopWatch = sw;
        }

        int DeathClock = 0;

        //State handlers
        //The actual function work that each state does
        public void Init()
        { stopWatch.Start(); }
        public void Exit()
        {
            Console.WriteLine("Quit program");
            stopWatch.Stop();
        }
        public void RedLight()
        {
            Console.WriteLine(current.ToString());
            Console.WriteLine(stopWatch.Elapsed.Seconds);
            stopWatch.Restart();
            DeathClock++;
        }
        public void YellowLight()
        {
            Console.WriteLine(current.ToString());
            Console.WriteLine(stopWatch.Elapsed.Seconds);

        }
        public void GreenLight()
        {
            Console.WriteLine(current.ToString());
            Console.WriteLine(stopWatch.Elapsed.Seconds);
        }



        //Changes the current state to equal the case that was called
        //Runs the function corresponding to the current state
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
                case State.YELLOW:
                    current = State.YELLOW;
                    YellowLight();
                    break;
                case State.GREEN:
                    current = State.GREEN;
                    GreenLight();
                    break;
                case State.EXIT:
                    current = State.EXIT;
                    Exit();
                    break;
            }

        }

        //Calls the ChangeState function when a certain condition is met 
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
                    if (DeathClock == 5)
                        ChangeState(State.EXIT);
                    break;

                case State.YELLOW:
                    if (stopWatch.Elapsed.Seconds >= 5)
                        ChangeState(State.RED);
                    break;

                case State.GREEN:
                    if (stopWatch.Elapsed.Seconds >= 3)
                        ChangeState(State.YELLOW);
                    break;

            }

        }

        //Starts the bloody program at a particular state
        public void Start()
        { ChangeState(State.INIT); }
    }
}