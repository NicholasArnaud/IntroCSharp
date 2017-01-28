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
            #region Entity declerations
            Player TheLegend27 = new Player(200, 20);
            TheLegend27.Name = "TheLegend27";
            TheLegend27.Speed = 15.0f;
            Player TheGuy = new Player(1, 100);
            TheGuy.Name = "TheGuy";
            TheGuy.Speed = 5.5f;
            Zombie NoobKilla = new Zombie(120, 20);
            NoobKilla.Name = "NoobKilla";
            NoobKilla.Speed = 10.5f;
            Zombie GetRekt = new Zombie(90, 40);
            GetRekt.Name = "GetRekt";
            GetRekt.Speed = 20.2f;
            List<Player> TeamA = new List<Player>();
            TeamA.Add(TheLegend27);
            TeamA.Add(TheGuy);
            List<Zombie> TeamZ = new List<Zombie>();
            TeamZ.Add(NoobKilla);
            TeamZ.Add(GetRekt);
            int deathCounterN = 0;
            int deathCounterZ = 0;
            #endregion

            #region console rights
            Console.WriteLine("Welcome! There are 4 characters. \n  2 Ninjas: TheLegend27 and TheGuy \n  2 Zombies: NoobKilla and GetRekt \n");
            Console.WriteLine("You can select who to attack by typing the name of \nthe character you want to attack with and the character you want to attack.");
            Console.WriteLine("For example: Player attack Enemy \n");
            Console.WriteLine("You can view all players current HP and attack stats by typing 'stats'");
            Console.WriteLine("To Quit simply press 'q' and the 'enter' key");
            Console.WriteLine("Press 'c' to clear screen at any time \n");
            #endregion

            string input;
            do
            {
                input = Console.ReadLine();

                //NINJA ATTACKS
                #region Ninja Atk
                if (input == "TheLegend27 attack NoobKilla")
                    TheLegend27.Hits(NoobKilla);

                if (input == "TheLegend27 attack GetRekt")
                    TheLegend27.Hits(GetRekt);

                if (input == "TheGuy attack GetRekt")
                    TheGuy.Hits(GetRekt);

                if (input == "TheGuy attack NoobKilla")
                    TheGuy.Hits(NoobKilla);
                #endregion

                //ZOMBIE ATTACKS
                #region Zom Atk
                if (input == "GetRekt attack TheGuy")
                    GetRekt.Hits(TheGuy);

                if (input == "GetRekt attack TheLegend27")
                    GetRekt.Hits(TheLegend27);

                if (input == "NoobKilla attack TheLegend27")
                    NoobKilla.Hits(TheLegend27);

                if (input == "NoobKilla attack TheGuy")
                    NoobKilla.Hits(TheGuy);
                #endregion

                //CHECK STATS
                #region stats
                if (input == "stat")
                {
                    Console.Clear();
                    Console.WriteLine("THE NINJAS \n");
                    Console.WriteLine("TheLegend27: \n" + "HP: " + TheLegend27.Health + "\n" + "BASE ATK: " + TheLegend27.AttackPower + "\nREAL NAME: " + TheLegend27.Name + "\n");
                    Console.WriteLine("TheGuy: \n" + "HP: " + TheGuy.Health + "\n" + "BASE ATK: " + TheGuy.AttackPower + "\nREAL NAME: " + TheGuy.Name + "\n");
                    Console.WriteLine("THE ZOMBIES \n");
                    Console.WriteLine("NoobKilla: \n" + "HP: " + NoobKilla.Health + "\n" + "BASE ATK: " + NoobKilla.AttackPower + "\nREAL NAME: " + NoobKilla.Name + "\n");
                    Console.WriteLine("GetRekt: \n" + "HP: " + GetRekt.Health + "\n" + "BASE ATK: " + GetRekt.AttackPower + "\nREAL NAME: " + GetRekt.Name + "\n");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Resume at any time by attacking \n");
                }
                #endregion

                //CLEAR
                if (input == "c") { Console.Clear(); }


                //FRIENDLY FIRE
                #region Freind Fire
                if (input == "NoobKilla attack GetRekt")
                    Console.WriteLine("YOU CAN NOT ATTACK YOUR TEAMMATE \n");
                if (input == "GetRekt attack NoobKilla")
                    Console.WriteLine("YOU CAN NOT ATTACK YOUR TEAMMATE \n");
                if (input == "TheLegend27 attack TheGuy")
                    Console.WriteLine("YOU CAN NOT ATTACK YOUR TEAMMATE \n");
                if (input == "TheGuy attack TheLegend27")
                    Console.WriteLine("YOU CAN NOT ATTACK YOUR TEAMMATE \n");
                #endregion

                //SUICIDE
                #region suicide    
                if (input == "NoobKilla attack NoobKilla")
                {
                    NoobKilla.Hits(NoobKilla);
                    deathCounterZ++;
                }
                if (input == "GetRekt attack GetRekt")
                {
                    GetRekt.Hits(GetRekt);
                    deathCounterZ++;
                }


                if (input == "TheLegend27 attack TheLegend27")
                {
                    TheLegend27.Hits(TheLegend27);
                    deathCounterN++;
                }
                if (input == "TheGuy attack TheGuy")
                {
                    TheGuy.Hits(TheGuy);
                    deathCounterN++;
                }
                if (deathCounterN == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Zombies proved to be too much for the Ninjas and the Ninjas chose the coward's way out...");
                    Console.WriteLine("Zombies Win...");
                    Console.ReadLine();
                    input = "q";
                }
                if (deathCounterZ == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Ninjas proved to be too much for the Zombies and the Zombies chose the coward's way out...\n");
                    Console.WriteLine("What a very peculiar circumstance\n");
                    Console.WriteLine("Ninjas Win...?");
                    Console.ReadLine();
                    input = "q";
                }
                #endregion

                //WINNING
                #region
                if (TheLegend27.Health == 0 && TheGuy.Health == 0)
                {
                    Console.WriteLine("Congratulations Zombies! The Ninjas have been destroyed!");
                    Console.ReadLine();
                    input = "q";
                }
                if (GetRekt.Health == 0 && NoobKilla.Health == 0)
                {
                    Console.WriteLine("Congratulations Ninjas! The Zombies have been eraticated!");
                    Console.ReadLine();
                    input = "q";
                }

            } while (input != "q");
            Console.Clear();
            Console.WriteLine("Thanks For Playing!");
            Console.Read();
            #endregion
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
            set
            {
                if (value <= 0)
                    health = 0;
                else
                    health = value;
            }
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
        public int DeathCounter
        {
            get { return deathCounter; }
            set { deathCounter = value; }
        }
        public virtual bool Attack(Entity enemy) { return true; }


        private int deathCounter;
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
            return true;
        }
        public bool Defend()
        {
            Random rnd = new Random();
            int tralse = rnd.Next(0, 5);
            if (tralse <= 3)
                return false;
            if (tralse >= 4)
                return true;
            else
                return false;
        }
        public void Hits(Entity enemy)
        {

            if (this.Name == enemy.Name)
            {
                Console.WriteLine(this.Name + " commited suicide \n");
                this.Health = 0;
            }

            else if (enemy.Health > 0)
            {
                this.Attack(enemy);
                Console.WriteLine("You attacked " + enemy.Name);
                Console.WriteLine("HP Left: " + enemy.Health);
                if (enemy.Health <= 0)
                    Console.WriteLine("YOU KILLED" + enemy.Name + " ! \n");
            }
            else
                Console.WriteLine(enemy.Name + " is already dead \n");
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

            Random rnd = new Random();
            int crit = rnd.Next(0, 21);
            e_pow += crit;
            if (this.Name == "Brian")
                crit += 5;

            if (crit >= 15)
                Console.WriteLine("CRITICAL STRIKE!!");

            enemy.Health -= e_pow;

            Random repost = new Random();
            int counter = repost.Next(0, 3);
            if (counter <= 1)
            {
                Random reDmg = new Random();
                int Dmg = reDmg.Next(1, 10);
                this.Health -= Dmg;
                Console.WriteLine("Reposted! Took " + Dmg + " damage!");
                Console.WriteLine(this.Health);
            }
            return true;
        }
        public void Hits(Entity enemy)
        {
            if (this.Name == enemy.Name)
            {
                Console.WriteLine(this.Name + " commited suicide \n");
                this.Health = 0;
            }

            else if (enemy.Health > 0)
            {
                this.Attack(enemy);
                Console.WriteLine("You attacked " + enemy.Name);
                Console.WriteLine("HP Left: " + enemy.Health);
                if (enemy.Health <= 0)
                    Console.WriteLine("YOU KILLED" + enemy.Name + " ! \n");
            }
            else
                Console.WriteLine(enemy.Name + "is already dead \n");
        }
    }
}