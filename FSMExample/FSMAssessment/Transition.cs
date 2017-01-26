using System;
using System.Collections.Generic;
using System.IO;

namespace FSMAssessment
{

    class Transition
    {
        public Transition() { }
        private State destination;
        private int m_condition;
        public Transition(int token, State to)
        {
            m_condition = token;
            destination = to;
        }
    }
}