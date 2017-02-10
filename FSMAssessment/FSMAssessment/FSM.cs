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
            states = new Dictionary<string, State>();
            var v = Enum.GetValues(typeof(T));
            foreach (var e in v)
            {
                State s = new State(e as Enum);
                states.Add(s.name, s);
            }
        }
        Dictionary<string, State> states;
        public string Start()
        {
            return GameManager.Instance.current = "INIT";
        }

        public void ChangeState(string s)
        {
            GameManager.Instance.current = states[s].ToString();
        }
    }
}