using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Class Practice
            Enemy Joe = new Enemy();
            Joe.Attack();
            Console.WriteLine(Joe.Health);
            Console.WriteLine(Joe.Name);


            //Maths
            int lo = 4;
            int jo = lo + 3;




            //Linked List Practice
            List<Student> students = new List<Student>();
            Student Bob = new Student(10);
            students.Add(Bob);
            Student s = new Student(9);


            //String Practice
            string add = "Bob";
            string addie = "Joe";
            add += addie;
            Console.WriteLine(add);
            
            //Printing
            Console.WriteLine("Hello World");
            Console.WriteLine(jo);
            Console.Read();
        }
    }

    class Student
    {
        public Student() { }
        public Student(int ID){ id = ID; }
        
        private int id;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }



    class Enemy
    {
        public Enemy()
        {
            m_health = 100;
            m_attack = 20;
            Name = "Assassin";
        }

        private int m_health;
        private int m_attack;
        private string m_name;
        public void Attack()
        {

            Console.WriteLine("Attacked :", Name);
            m_health -= m_attack;

        }


        public int Health
        {
            get
            {
                return m_health;
            }
            set
            {
                m_health = value;
            }
        }

        public string Name
        {
            get
            {
                return m_name;
            }

            set
            {
                m_name = value;
            }
        }
    }
}

