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

        List<Player> TeamA = new List<Player>();
        List<Zombie> TeamB = new List<Zombie>();

        public bool fillParty()
        {
            TeamA.Add(TheLegend27);
            TeamA.Add(TheGuy);
            TeamB.Add(GetRekt);
            TeamB.Add(NoobKilla);
            return true;
        }

        public Form1()
        {
            InitializeComponent();
            fillParty();
            SET_Health("Legend");
            SET_Health("Guy");
            SET_Health("Killa");
            SET_Health("Rekt");
            LogBox.Text = "Choose a character to select and then choose who to attack!";
            StartTurn();
        }

        //CHARACTER SELECT
        private void GuySelect_Click(object sender, EventArgs e)
        {
            ATK_Visibility("select");
            Active = TheGuy;
        }
        private void LegSelect_Click(object sender, EventArgs e)
        {
            ATK_Visibility("select");
            Active = TheLegend27;
        }
        private void KillaSelect_Click(object sender, EventArgs e)
        {
            ATK_Visibility("select");
            Active = NoobKilla;
        }
        private void RektSelect_Click(object sender, EventArgs e)
        {
            ATK_Visibility("select");
            Active = GetRekt;
        }


        //TURNS
        private void StartTurn()
        {
            Random rnd = new Random();
            int firstTurn = rnd.Next(1, 10);
            if (firstTurn >= 5)
            {
                GuySelect.Enabled = true;
                LegSelect.Enabled = true;
                KillaSelect.Enabled = false;
                RektSelect.Enabled = false;
            }
            if (firstTurn < 5)
            {
                GuySelect.Enabled = false;
                LegSelect.Enabled = false;
                KillaSelect.Enabled = true;
                RektSelect.Enabled = true;

            }

        }



        //ATTACK BUTTONS
        private void ATKLeg_Click(object sender, EventArgs e)
        {

            ATK_Visibility("attack");
            ATK_DMG("Legend");

        }
        private void ATKGuy_Click(object sender, EventArgs e)
        {

            ATK_Visibility("attack");
            ATK_DMG("Guy");

        }
        private void ATKKilla_Click(object sender, EventArgs e)
        {

            ATK_Visibility("attack");
            ATK_DMG("Killa");

        }
        private void ATKRekt_Click(object sender, EventArgs e)
        {

            ATK_Visibility("attack");
            ATK_DMG("Rekt");
        }


        //HEALTH BARS
        /// <summary>
        /// progress bar for GetRekt that represents health
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RektHealth_Click(object sender, EventArgs e) { }
        /// <summary>
        /// progress bar for NoobKilla that represents health
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KillaHealth_Click(object sender, EventArgs e) { }
        /// <summary>
        /// progress bar for TheLegend27 that represents health
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LegendHealth_Click(object sender, EventArgs e) { }
        /// <summary>
        /// progress bar for TheGuy that represents health
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuyHealth_Click(object sender, EventArgs e) { }


        /// <summary>
        /// Turns visibilty on and off for the attack buttons
        /// </summary>
        /// <param name="choose"></param>
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
        /// <summary>
        /// Runs attack formulas
        /// </summary>
        /// <param name="hits"></param>
        private void ATK_DMG(string hits)
        {
            if (hits == "Legend")
            {
                bool def = TheLegend27.Defend();
                if (def == false)
                {
                    Active.Hits(TheLegend27);
                    LegendHealth.Value = TheLegend27.Health;

                    LogBox.Text = Active.Name + " attacked TheLegend27 for " + Active.AttackPower + " damage! \n";
                }
                if (def == true)
                {
                    LogBox.Text = "TheLegend27 dodged the attack!";
                }

            }

            if (hits == "Guy")
            {
                bool def = TheLegend27.Defend();
                if (def == false)
                {
                    Active.Hits(TheGuy);
                    GuyHealth.Value = TheGuy.Health;
                    LogBox.Text = Active.Name + " attacked TheGuy for " + Active.AttackPower + " damage! \n";
                }
                if (def == true)
                {
                    LogBox.Text = "TheGuy dodged the attack!";
                }
            }

            if (hits == "Killa")
            {
                Active.Hits(NoobKilla);
                KillaHealth.Value = NoobKilla.Health;
                Active.Crit(NoobKilla);
                LogBox.Text = Active.Name + " attacked NoobKilla for " + Active.AttackPower + " damage and took " + Active.critAmount + " extra!";
            }

            if (hits == "Rekt")
            {
                Active.Hits(GetRekt);
                Active.Crit(GetRekt);
                RektHealth.Value = GetRekt.Health;

                LogBox.Text = Active.Name + " attacked GetRekt for " + Active.AttackPower + " damage! and took " + Active.critAmount + " extra!";
            }

        }
        /// <summary>
        /// Sets value of progress bar equal to health value
        /// </summary>
        /// <param name="player"></param>
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
        //public bool NextPlayer()
        //{
        //    int i = 0;
        //    if (i < 2)
        //    {
        //        for (; i <= TeamA.Count; i++)
        //            TeamA.ElementAt(i);
        //        TeamA.Reverse();
        //    }
        //    else
        //    {
        //        for (int j = 0; j <= TeamB.Count; j++)
        //            TeamB.ElementAt(j);
        //        TeamB.Reverse();
        //    }

        //    return true;
        //}

        private void LogBox_TextChanged(object sender, EventArgs e) { }
    }



    public class Entity
    {
        public Entity() { }
        public Entity(string name, int h, int att)
        {
            health = h;
            attackPower = att;
            onEndTurn += EndTurn;
            onPartyEnd += EndParty;
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
        public void Crit(Entity enemy)
        {
            Random rnd = new Random();
            int crit = rnd.Next(0, 21);
            if (this.Name == "NoobKilla")
                crit += 5;
            enemy.Health -= crit;
            critAmount = crit;
        }
        public virtual bool Attack(Entity enemy) { return true; }
        public virtual void Hits(Entity enemy) { }
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


        public delegate void OnPartyEnd();
        public delegate void OnEndTurn();
        public OnEndTurn onEndTurn;

        public OnPartyEnd onPartyEnd;
        void EndTurn()
        {
            if (onEndTurn != null)
                onEndTurn.Invoke();
        }


        void EndParty()
        {
            if (onPartyEnd != null)
                onPartyEnd.Invoke();
        }


        public int critAmount;
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
