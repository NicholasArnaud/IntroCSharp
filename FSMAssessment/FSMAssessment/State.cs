﻿using System;


namespace FSMAssessment
{
    class State
    {
        public State()
        {
            //Constructor
        }
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
