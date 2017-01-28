using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractice
{
    class Program
    {
        static void Main(string[] args)
        {

            Ninja nin = new Ninja("Nin", 20,10);
            Zombie zom = new Zombie("Zom", 20, 10);


            zom.DoDamage(nin);
            zom.DoDamage(zom);

        }
    }
}
