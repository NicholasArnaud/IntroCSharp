using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatPractice
{
    class Stats
    {

        public Stats(string n, int v)
        {
            stats = new Dictionary<string, Stat>();
            modifiers = new Dictionary<string, Modifier>();
            
        }
    }
}
