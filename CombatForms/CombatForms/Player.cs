﻿using System;
using System.Collections.Generic;
using System.IO;


namespace CombatForms
{
    class Player
    {
        Player() { }
        public Player(string name, int h, int att, float spd)
        {
            Name = name;
            Health = h;
            AttackPower = att;
            Speed = spd;
        }

        #region getters,setters
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
        #endregion

        #region player variables
        private int attackPower;
        private string name;
        private int health;
        private float speed;
        #endregion
    }
}
