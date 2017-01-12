using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NVZ_In_WinForms
{

    public partial class Form1 : Form
    {
        Player TheLegend27 = new Player("TheLegend27", 200, 20);
        Player TheGuy = new Player("TheGuy", 1, 100);
        Zombie NoobKilla = new Zombie("NoobKilla", 120, 20);
        Zombie GetRekt = new Zombie("GetRekt", 90, 40);
        Entity Active = new Entity();


        public Form1()
        {
            InitializeComponent();
            SET_Health("Legend");
            SET_Health("Guy");
            SET_Health("Killa");
            SET_Health("Rekt");
        }

        //CHARACTER SELECT
        private void GuySelect_Click(object sender, EventArgs e)
        {
            Select_Player("select");
            ATK_Visibility("select");
            Active = TheGuy;
        }

        private void LegSelect_Click(object sender, EventArgs e)
        {
            Select_Player("select");
            ATK_Visibility("select");
            Active = TheLegend27;
        }

        private void KillaSelect_Click(object sender, EventArgs e)
        {
            Select_Player("select");
            ATK_Visibility("select");
            Active = NoobKilla;
        }

        private void RektSelect_Click(object sender, EventArgs e)
        {
            Select_Player("select");
            ATK_Visibility("select");
            Active = GetRekt;
        }



        //ATTACK BUTTON
        private void ATKLeg_Click(object sender, EventArgs e)
        {
            Select_Player("chose");
            ATK_Visibility("attack");
            ATK_DMG("Legend");
        }
        private void ATKGuy_Click(object sender, EventArgs e)
        {
            Select_Player("chose");
            ATK_Visibility("attack");
            ATK_DMG("Guy");
        }
        private void ATKKilla_Click(object sender, EventArgs e)
        {
            Select_Player("chose");
            ATK_Visibility("attack");
            ATK_DMG("Killa");
        }
        private void ATKRekt_Click(object sender, EventArgs e)
        {
            Select_Player("chose");
            ATK_Visibility("attack");
            ATK_DMG("Rekt");
        }


        //HEALTH BAR
        private void RektHealth_Click(object sender, EventArgs e) { }

        private void KillaHealth_Click(object sender, EventArgs e) { }

        private void LegendHealth_Click(object sender, EventArgs e) { }

        private void GuyHealth_Click(object sender, EventArgs e) { }



        private void ATK_Visibility(string choose)
        {
            if (choose == "select")
            {
                ATKGuy.Visible = true;
                ATKLeg.Visible = true;
                ATKKilla.Visible = true;
                ATKRekt.Visible = true;
            }
            if (choose == "attack")
            {
                ATKGuy.Visible = false;
                ATKLeg.Visible = false;
                ATKKilla.Visible = false;
                ATKRekt.Visible = false;
            }
        }
        private void Select_Player(string choose)
        {
            if (choose == "select")
            {
                LegSelect.Enabled = false;
                GuySelect.Enabled = false;
                KillaSelect.Enabled = false;
                RektSelect.Enabled = false;
            }
            if (choose == "chose")
            {
                LegSelect.Enabled = true;
                GuySelect.Enabled = true;
                KillaSelect.Enabled = true;
                RektSelect.Enabled = true;
            }
        }
        private void ATK_DMG(string hits)
        {
            if (hits == "Legend")
            {
                Active.Hits(TheLegend27);
                LegendHealth.Value = TheLegend27.Health;
                LogBox.Text = Active.Name+" attacked TheLegend27 for "+ Active.AttackPower+" damage! \n";

            }

            if (hits == "Guy")
            {
                Active.Hits(TheGuy);
                GuyHealth.Value = TheGuy.Health;
                LogBox.Text = Active.Name + " attacked TheGuy for " + Active.AttackPower + " damage! \n";
            }

            if (hits == "Killa")
            {
                Active.Hits(NoobKilla);
                KillaHealth.Value = NoobKilla.Health;
                LogBox.Text = Active.Name + " attacked NoobKilla for " + Active.AttackPower + " damage! \n";
            }

            if (hits == "Rekt")
            {
                Active.Hits(GetRekt);
                RektHealth.Value = GetRekt.Health;
                LogBox.Text = Active.Name + " attacked GetRekt for " + Active.AttackPower + " damage! \n";
            }

        }
        private void SET_Health(string player)
        {
            if (player == "Legend")
            {
                LegendHealth.Maximum = TheLegend27.Health;
                LegendHealth.Value = TheLegend27.Health;
            }

            if (player == "Guy")
            {
                GuyHealth.Maximum = TheGuy.Health;
                GuyHealth.Value = TheGuy.Health;
            }

            if (player == "Killa")
            {
                KillaHealth.Maximum = NoobKilla.Health;
                KillaHealth.Value = NoobKilla.Health;
            }

            if (player == "Rekt")
            {
                RektHealth.Maximum = GetRekt.Health;
                RektHealth.Value = GetRekt.Health;
            }

        }

        private void LogBox_TextChanged(object sender, EventArgs e){ }
    }



    public class Entity
    {
        public Entity() { }
        public Entity(string name, int h, int att)
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
        public virtual void Hits(Entity enemy) { }

        private int deathCounter;
        private int attackPower;
        private string name;
        private int health;
        private float speed;
    }

    public class Player : Entity
    {
        public Player() { }
        public Player(string name, int h, int att) : base(name, h, att)
        {
            Name = name;
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
        public override void Hits(Entity enemy)
        {
            if (this.Name == enemy.Name)
            {
                this.Health = 0;
            }

            else if (enemy.Health > 0)
            {
                this.Attack(enemy);
            }
        }
    }

    public class Zombie : Entity
    {
        public Zombie() { }
        public Zombie(string name, int h, int att) : base(name, h, att)
        {
            Name = name;
            Health = h;
            AttackPower = att;
        }
        public override bool Attack(Entity enemy)
        {
            int e_pow = this.AttackPower;

            //Random rnd = new Random();
            //int crit = rnd.Next(0, 21);
            //e_pow += crit;
            //if (this.Name == "Brian")
            //    crit += 5;

            //if (crit >= 15)
            //    Console.WriteLine("CRITICAL STRIKE!!");

            enemy.Health -= e_pow;

            Random repost = new Random();
            int counter = repost.Next(0, 3);
            if (counter <= 1)
            {
                Random reDmg = new Random();
                int Dmg = reDmg.Next(1, 10);
                this.Health -= Dmg;
            }
            return true;
        }
        public override void Hits(Entity enemy)
        {
            if (this.Name == enemy.Name)
            {
                this.Health = 0;
            }
            else if (enemy.Health > 0)
            {
                this.Attack(enemy);
            }

        }
    }
}
