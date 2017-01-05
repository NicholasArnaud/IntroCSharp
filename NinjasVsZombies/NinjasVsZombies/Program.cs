using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjasVsZombies
{
    class Program
    {
        static void Main(string[] args)
        {
            Player TheLegend27 = new Player(200, 20);
            TheLegend27.Name = "Nick";
            TheLegend27.Speed = 15.0f;
            Player TheGuy = new Player(1, 100);
            TheGuy.Name = "James";
            TheGuy.Speed = 5.5f;
            Zombie NoobKilla = new Zombie(120, 15);
            NoobKilla.Name = "Matthew";
            NoobKilla.Speed = 10.5f;
            Zombie GetRekt = new Zombie(90, 20);
            GetRekt.Name = "Brian";
            GetRekt.Speed = 20.2f;
            List<Player> TeamA = new List<Player>();
            TeamA.Add(TheLegend27);
            TeamA.Add(TheGuy);
            List<Zombie> TeamZ = new List<Zombie>();
            TeamZ.Add(NoobKilla);
            TeamZ.Add(GetRekt);


            Console.WriteLine("Welcome! There are 4 characters. \n  2 Ninjas: TheLegend27 and TheGuy \n  2 Zombies: NoobKilla and GetRekt \n");
            Console.WriteLine("You can select who to attack by typing the name of \nthe character you want to attack and the character you want to attack.");
            Console.WriteLine("For example: Player attack Enemy \n");
            Console.WriteLine("To Quit simply press 'q' and the 'enter' key \n");
            string input;
            do
            {
                input = Console.ReadLine();

                //NINJA ATTACKS
                if (input == "TheLegend27 attack NoobKilla")
                {
                    if (NoobKilla.Health != 0)
                    {
                        TheLegend27.Attack(NoobKilla);
                        Console.WriteLine("You attacked NoobKilla");
                        Console.WriteLine(NoobKilla.Health);
                        if (NoobKilla.Health <= 0)
                            Console.WriteLine("YOU KILLED NOOBKILLA! \n");
                    }
                    else
                        Console.WriteLine("NoobKilla is already dead \n");
                }


                if (input == "TheLegend27 attack GetRekt")
                {
                    if (GetRekt.Health != 0)
                    {
                        TheLegend27.Attack(GetRekt);
                        Console.WriteLine("You attacked GetRekt");
                        Console.WriteLine(GetRekt.Health);
                        if (GetRekt.Health <= 0)
                            Console.WriteLine("YOU KILLED GETREKT! \n");
                    }
                    else
                        Console.WriteLine("GetRekt is already dead \n");
                }


                if (input == "TheGuy attack GetRekt")
                {
                    if (GetRekt.Health != 0)
                    {
                        Console.WriteLine("You attacked GetRekt");
                        TheGuy.Attack(GetRekt);
                        Console.WriteLine(GetRekt.Health);
                        if (GetRekt.Health <= 0)
                            Console.WriteLine("YOU KILLED GETREKT! \n");
                    }
                    else
                        Console.WriteLine("GetRekt is already dead \n");
                }


                if (input == "TheGuy attack NoobKilla")
                {
                    if (NoobKilla.Health != 0)
                    {
                        Console.WriteLine("You attacked NoobKilla");
                        TheGuy.Attack(NoobKilla);
                        Console.WriteLine(NoobKilla.Health);
                        if (NoobKilla.Health <= 0)
                            Console.WriteLine("YOU KILLED NOOBKILLA! \n");
                    }
                    else
                        Console.WriteLine("NoobKilla is already dead \n");
                }


                //ZOMBIE ATTACKS
                if (input == "GetRekt attack TheGuy")
                {
                    Console.WriteLine("You attacked TheGuy");
                    if (TheGuy.Health != 0)
                    {
                        if (TheGuy.Defend() == false)
                        {
                            GetRekt.Attack(TheGuy);
                            Console.WriteLine(TheGuy.Health);
                            if (TheGuy.Health <= 0)
                                Console.WriteLine("YOU KILLED THEGUY! \n");
                        }
                        else
                            Console.WriteLine("TheGuy dodged the attack!");
                    }
                    else
                        Console.WriteLine("TheGuy is already dead \n");
                }

                if (input == "GetRekt attack TheLegend27")
                {
                    Console.WriteLine("You attacked TheLegend27");
                    if (TheLegend27.Health != 0)
                    {
                        if (TheLegend27.Defend() == false)
                        {
                            GetRekt.Attack(TheLegend27);
                            Console.WriteLine(TheLegend27.Health);
                            if (TheLegend27.Health <= 0)
                                Console.WriteLine("YOU KILLED TheLegend27! \n");
                        }
                        else
                            Console.WriteLine("TheLegend27 dodged the attack!");
                    }
                    else
                        Console.WriteLine("TheLegend27 is already dead \n");
                }

                if (input == "NoobKilla attack TheLegend27")
                {
                    Console.WriteLine("You attacked TheLegend27");
                    if (TheLegend27.Health != 0)
                    {
                        if (TheLegend27.Defend() == false)
                        {
                            NoobKilla.Attack(TheLegend27);
                            Console.WriteLine(TheLegend27.Health);
                            if (TheLegend27.Health <= 0)
                                Console.WriteLine("YOU KILLED TheLegend27! \n");
                        }
                        else Console.WriteLine("TheLegend27 dodged the attack!");
                    }
                    else
                        Console.WriteLine("TheLegend27 is already dead \n");
                }

                if (input == "NoobKilla attack TheGuy")
                {
                    Console.WriteLine("You attacked TheGuy");
                    if (TheGuy.Health != 0)
                    {
                        if (TheLegend27.Defend() == false)
                        {
                            NoobKilla.Attack(TheGuy);
                            Console.WriteLine(TheGuy.Health);
                            if (TheGuy.Health <= 0)
                                Console.WriteLine("YOU KILLED THEGUY! \n");
                        }
                        else
                            Console.WriteLine("TheGuy dodged the attack!");
                    }
                    else
                        Console.WriteLine("TheGuy is already dead \n");
                }

                //FRIENDLY FIRE
                if (input == "NoobKilla attack GetRekt")
                    Console.WriteLine("YOU CAN NOT ATTACK YOUR TEAMMATE \n");
                if (input == "GetRekt attack NoobKilla")
                    Console.WriteLine("YOU CAN NOT ATTACK YOUR TEAMMATE \n");
                if (input == "TheLegend27 attack TheGuy")
                    Console.WriteLine("YOU CAN NOT ATTACK YOUR TEAMMATE \n");
                if (input == "TheGuy attack TheLegend27")
                    Console.WriteLine("YOU CAN NOT ATTACK YOUR TEAMMATE \n");

                //SUICIDE
                if (input == "NoobKilla attack NoobKilla")
                {
                    Console.WriteLine("NoobKilla commited suicide \n");
                    NoobKilla.Health = 0;
                }
                if (input == "GetRekt attack GetRekt")
                {
                    Console.WriteLine("GetRekt commited suicide \n");
                    GetRekt.Health = 0;
                }
                if (input == "TheLegend27 attack TheLegend27")
                {
                    Console.WriteLine("TheLegend commited suicide \n");
                    TheLegend27.Health = 0;
                }
                if (input == "TheGuy attack TheGuy")
                {
                    Console.WriteLine("TheGuy commited suicide \n");
                    TheGuy.Health = 0;
                }
            } while (input != "q");
            Console.Clear();
            Console.WriteLine("Thanks For Playing!");
            Console.Read();
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

        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int AttackPower
        {
            get { return attackPower; }
            set { attackPower = value; }
        }
        public virtual bool Attack(Entity enemy) { return true; }



        private int attackPower;
        private string name;
        private int health;
        private float speed;
    }

    public class Player : Entity
    {
        public Player() { }
        public Player(int h, int att) : base(h, att)
        {
            Health = h;
            AttackPower = att;
        }
        public override bool Attack(Entity enemy)
        {
            int e_pow = this.AttackPower;
            enemy.Health -= e_pow;
            if (enemy.Health <= 0)
            {
                enemy.Health = 0;
            }
            return true;
        }
        public bool Defend()
        {
            Random rnd = new Random();
            int tralse = rnd.Next(0, 2);
            if (tralse == 0)
                return false;
            if (tralse == 1)
                return true;
            else
                return false;
        }
    }

    public class Zombie : Entity
    {
        public Zombie() { }
        public Zombie(int h, int att)
        {
            Health = h;
            AttackPower = att;
        }
        public override bool Attack(Entity enemy)
        {
            int e_pow = this.AttackPower;
            enemy.Health -= e_pow;
            if(enemy.Health <= 0)
            {
                enemy.Health = 0;
            }
            return true;
        }
    }
}