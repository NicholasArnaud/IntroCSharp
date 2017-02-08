﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMAssessment
{

    public class FSM<T>
    {


       public FSM()
        {
              Dictionary<string,State> states = new Dictionary<string,State>();
            states.Add("INIT", State.INIT);
        }
        TurnSystem Turn = new TurnSystem();
        Combat Battle = new Combat();

        public T current;
        
        public void Start()
        {
            ChangeState(current.INIT);
        }

        public void ChangeState(T State)
        {
            switch (current)
            {
                case State.INIT:
                    current = State.INIT;
                    break;
                case State.PLAYERSELECT:
                    current = State.PLAYERSELECT;
                    Turn.ToStartUp();
                    break;
                case Statem.ATK:
                    current = State.ATK;
                    break;
                case State.CHKDEAD:
                    current = State.CHKDEAD;
                    break;
                case State.ENDTURN:
                    current = State.ENDTURN;
                    break;
                case State.EXIT:
                    current = State.EXIT;
                    break;
            }
        }

        public void Update()
        {
            switch (current.ToString())
            {
                case current.ToString().INIT:
                    ChangeState(State.PLAYERSELECT);
                    break;
                case State.ATK:
                    ChangeState(State.CHKDEAD);
                    break;
                case State.CHKDEAD:
                    ChangeState(State.ENDTURN);
                    break;
                case State.ENDTURN:
                    ChangeState(State.PLAYERSELECT);
                    break;
            }
        }


    }
}