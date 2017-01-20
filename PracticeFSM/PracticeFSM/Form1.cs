using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeFSM
{

    public partial class Form1 : Form
    {
        Player Cloud = new Player("Cloud");
        Player Tifa = new Player("Tifa");
        Player Barett = new Player("Barett");
        Player Aeris = new Player("Aeris");
        Player Vincent = new Player("Vincent");
        Player CaitSith = new Player("CaitSith");
        Player Active = new Player("Active");
        Player Evil = new Player("Evil");
        Party activeParty = new Party();
        
        List<Player> members = new List<Player>();
        
        public Form1()
        {
            activeParty.members = new List<Player>();
            InitializeComponent();
            activeParty.members.Add(Cloud);
            activeParty.members.Add(Tifa);
            activeParty.members.Add(Barett);
            activeParty.members.Add(Aeris);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        public enum State
        {
            ENDTURN,
            ATTACK,
            DEFEND,
        }
        public void FSM(State state)
        {
            switch (state)
            {
                case State.ENDTURN:
                    {
                        Active.EndTurn();
                        break;
                    }

                case State.ATTACK:
                    {
                        Active.Attack(Evil);
                        goto case State.ENDTURN;

                    }

                case State.DEFEND:
                    {
                        Active.Defend();
                        goto case State.ENDTURN;

                    }

                default:
                    break;
            }


        }
        //COMBAT
        private void Attack_Click(object sender, EventArgs e)
        {
            FSM(State.ATTACK);
        }
        private void Defend_Click(object sender, EventArgs e)
        {
            FSM(State.DEFEND);
        }
        private void End_Click(object sender, EventArgs e)
        {
            FSM(State.ENDTURN);
        }
        //CHARACTER SELECT
        private void CloudSelect_Click(object sender, EventArgs e)
        {
            Active = Cloud;
            textBox1.Text = Active.Name;
        }
        private void TifaSelect_Click(object sender, EventArgs e)
        {
            Active = Tifa;
            textBox1.Text = Active.Name;
        }
        private void BarettSelect_Click(object sender, EventArgs e)
        {
            Active = Barett;
            textBox1.Text = Active.Name;
        }
        private void AerisSelect_Click(object sender, EventArgs e)
        {
            Active = Aeris;
            textBox1.Text = Active.Name;
        }
        private void VincentSelect_Click(object sender, EventArgs e)
        {
            Active = Vincent;
            textBox1.Text = Active.Name;
        }
        private void CaitSithSelect_Click(object sender, EventArgs e)
        {
            Active = CaitSith;
            textBox1.Text = Active.Name;
        }

       
        //SAVE AND LOAD
        private void SaveData_Click(object sender, EventArgs e)
        {
            
        }

        private void LoadData_Click(object sender, EventArgs e)
        {

        }
    }
}