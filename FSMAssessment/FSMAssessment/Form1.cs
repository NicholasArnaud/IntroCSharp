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
    public enum State
        {
            INIT = 1,
            PLAYERSELECT = 2,
            ATK = 3,
            CHKDEAD = 4,
            ENDTURN =5,
            EXIT = 9000,
        }
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FSM<State> fsm = new FSM<State>();
          
           
        }
    }
}
