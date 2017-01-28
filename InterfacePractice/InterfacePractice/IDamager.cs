using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePractice
{
    interface IDamager
    {
        void DoDamage(IDamagable d);
    }
}