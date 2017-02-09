using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSMAssessment
{
    public enum TurnStates
    {
        INIT = 1,
        PLAYERSELECT = 2,
        ATK = 3,
        CHKDEAD = 4,
        ENDTURN = 5,
        EXIT = 9000,
    }
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            GameManager.Instance.current = GameManager.Instance.fsm.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TextLog_TextChanged(object sender, EventArgs e)
        {

        }
        private void AtkButton_Click(object sender, EventArgs e)
        {
            GameManager.Instance.fsm.ChangeState("ATK");
        }


        private new void Update()
        {
            switch (GameManager.Instance.current)
            {
                case "INIT":
                    GameManager.Instance.fsm.ChangeState("PLAYERSELECT");
                    break;
                case "PLAYERSELECT":
                    GameManager.Instance.fsm.ChangeState("ATK");
                    break;
                case "ATK":
                    GameManager.Instance.fsm.ChangeState("CHKDEAD");
                    break;
                case "CHKDEAD":
                    GameManager.Instance.fsm.ChangeState("ENDTURN");
                    break;
                case "ENDTURN":
                    GameManager.Instance.fsm.ChangeState("EXIT");
                    break;
                case "EXIT":
                    break;
            }
        }
    }
}
