using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LightFSM
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