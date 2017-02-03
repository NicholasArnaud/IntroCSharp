using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMAssessment
{
    public class Player
    {
        Player(string Name, int Health, int Power )
        {
            name = Name;
            health = Health;
            power = Power;
        }

        private string name;
        private int health;
        private int power;
    }
}
