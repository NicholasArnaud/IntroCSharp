using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractice
{
    class Zombie : Entity, IDamagable, IDamager
    {
        public Zombie() { }
        public Zombie(string name, int h, int att)
        {
            Name = name;
            Health = h;
            AttackPower = att;
        }




        public void TakeDamage(int dmg)
        {
           Health -= dmg;
        }

        public void DoDamage(IDamagable d)
        {
            d.TakeDamage(AttackPower);
        }
    }
}
