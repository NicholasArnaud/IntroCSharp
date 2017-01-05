using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
  
namespace NinjasVsZombies
{
    public class Player : Entity
    {
        public Player() { }
        public Player(int h, int att) : base(h, att)
        {

        }
        public override bool Attack(Entity enemy) { return true; }
        public bool Defend() { return true; }
    }

    class Program
    {
        static void Main(string[] args)
        {
      
             int num = 5;
            Player p = new Player(1, 1);
            Console.WriteLine(p.name);
            //while (true)
            //{

            //    Console.ReadLine();
            //    num++;
            //}
            Console.ReadLine();

        }
    }

    public class Entity
    {
        public Entity() { }
        public Entity(int h, int att)
        {
            health = h;
            attackPower = att;
        }
        private int health;
        protected int Health
        {
            get { return health = Health; }
            set { health = value; }
        }
        private int attackPower;
        protected int AttackPower
        {
            get { return attackPower = AttackPower; }
            set { attackPower = value; }
        }
        public virtual bool Attack(Entity enemy) { return true; }
        private string Name
        {
            get { return name = Name; }
            set { name = value; }
        }

        public string name;
    }

    public class Zombie : Entity
    {
        public Zombie() { }
        public Zombie(int h, int att) { }
        public override bool Attack(Entity enemy) { return true; }
    }



}
