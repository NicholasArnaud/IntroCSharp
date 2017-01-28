using System;
using System.Collections.Generic;
using System.IO;


namespace CombatForms
{
    delegate void CallBack();

   public class FSMCombat
    {
        private Dictionary<string, State> states;
        private Dictionary<string, Transition> transitions;
       public FSMCombat()
        {
            states = new Dictionary<string, State>();
            transitions = new Dictionary<string, Transition>();
        }

        
        public State current;
        public void Update()
        {
            switch (current)
            {
                case State.INIT:
                    current = State.INIT;
                    Init();
                    break;
                case State.TEAMA:
                    current = State.TEAMA;
                    TeamA();
                    break;
                case State.TEAMB:
                    current = State.TEAMB;
                    TeamB();
                    break;
                case State.END:
                    current = State.END;
                    End();
                    break;
            }
        }

        
        public void Init()
        {

        }

        public void TeamA()
        {
        }

        public void TeamB()
        {
        }

        public void End()
        {
        }

        public void TurnChoice()
        {   
        }


        public void ChangeState(State s)
        {
            switch (s)
            {
                case State.INIT:
                    ChangeState(State.TEAMA);
                    break;
                case State.TEAMA:
                    ChangeState(State.END);
                    break;
                case State.TEAMB:
                    ChangeState(State.END);
                    break;
                case State.END:
                    if (current == State.TEAMA)
                        ChangeState(State.TEAMB);
                    if (current == State.TEAMB)
                        ChangeState(State.TEAMA);
                    break;
            }
        }
    }
}