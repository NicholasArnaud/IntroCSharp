using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LightFSM
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            FSM fsm = new FSM(sw);
            fsm.Start();
            while(true)
            {
                fsm.Update();
            }
        }
    }
}