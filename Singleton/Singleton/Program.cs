using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            singleton.Instance.name = "bob";
            Debug.WriteLine("accessed the singleton " + singleton.Instance.name);
        }
    }
}