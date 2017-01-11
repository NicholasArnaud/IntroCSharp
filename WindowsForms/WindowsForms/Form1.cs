using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{

    public partial class Leveler : Form
    {
        Player p = new Player();
        public Leveler()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LvlUp();
            display("textExp");
        }

        private void Progress(object sender, EventArgs e)
        {

            progressBar1.Value += 10;
            p.EXP += progressBar1.Value;
            if (progressBar1.Value >= progressBar1.Maximum)
            {
                progressBar1.Value = 0;
                LvlUp();
            }
            display("textExp");
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (progressBar1.Value > 0)
                progressBar1.Value -= 10;

        }

        private void textlvl_TextChanged(object sender, EventArgs e)
        {
        }

        private void textexp_TextChanged(object sender, EventArgs e)
        {
        }

        private void SecretCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                p.LVL = 100;
                p.EXP = 10000000;
            }
            display("textLvl");
            display("textExp");
            checkBox1.Checked = false;
        }



        void LvlUp()
        {
            display("textLvl");
            p.LVL += 1;
            progressBar1.Maximum = (p.LVL * 100) / 2;
        }

        public void display(string textfile)
        {
            if (textfile == "textLvl")
                textLvl.Text = "LVL: " + p.LVL.ToString();
            if (textfile == "textExp")
                textExp.Text = "XP: " + p.EXP.ToString();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;
            p.LVL = 1;
            p.EXP = 0;

            display("textLvl");
            display("textExp");
        }

    }

    public class Player
    {
        public Player()
        {
            exp = 0;
            lvl = 1;
        }
        private int lvl;
        private int exp;
        public int EXP
        {
            get { return exp; }
            set
            {
                if (value <= 0)
                    exp = 0;
                else
                    exp = value;
            }
        }
        public int LVL
        {
            get { return lvl; }
            set
            {
                if (value <= 0)
                    lvl = 0;
                else
                    lvl = value;
            }
        }
    }
}
