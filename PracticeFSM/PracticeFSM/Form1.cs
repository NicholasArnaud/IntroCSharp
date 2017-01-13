using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeFSM
{

    public partial class Form1 : Form
    {
        Player Cloud = new Player();
        Player Tifa = new Player();
        Player Barett = new Player();
        Player Aeris = new Player();
        Player Vincent = new Player();
        Player CaitSith = new Player();
        Player Active = new Player();
        Party activeParty = new Party();
        
        public Form1()
        {
            InitializeComponent();
            activeParty.members.Add(Cloud);
            activeParty.members.Add(Tifa);
            activeParty.members.Add(Barett);
            activeParty.members.Add(Aeris);
        }
        private void Form1_Load(object sender, EventArgs e)
        { }
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
                        Active.Attack();
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

        }
        private void TifaSelect_Click(object sender, EventArgs e)
        {
            Active = Tifa;
        }
        private void BarettSelect_Click(object sender, EventArgs e)
        {
            Active = Barett;
        }
        private void AerisSelect_Click(object sender, EventArgs e)
        {
            Active = Aeris;
        }
        private void VincentSelect_Click(object sender, EventArgs e)
        {
            Active = Vincent;
        }
        private void CaitSithSelect_Click(object sender, EventArgs e)
        {
            Active = CaitSith;
        }
    }
}