using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMAssessment
{
    public class Player
    {
        public Player()
        { //Constructor
        }
        public Player(string Name, int Health, int Power, float Speed)
        {
            m_name = Name;
            m_health = Health;
            m_power = Power;
            m_speed = Speed;
            m_maxHealth = m_health;
        }

        public int MaxHealth
        {
            get { return m_maxHealth; }
            set { m_maxHealth = value; }
        }
        public int Health
        {
            get { return m_health; }
            set
            {
                if (value >= 0)
                    m_health = value;
                else m_health = 0;
            }
        }
        public int Power
        {
            get { return m_power; }
            set { m_power = value; }
        }
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        public float Speed
        {
            get { return m_speed; }
            set { m_speed = value; }
        }

        private int m_maxHealth;
        private string m_name;
        private int m_health;
        private int m_power;
        private float m_speed;
    }
}