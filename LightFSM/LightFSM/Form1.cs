using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightFSM
{
    public partial class Form1 : Form
    {

        enum states
        {
            INIT = 0,
            GREEN = 1,
            YELLOW = 2,
            RED = 3,
            END = 9000,
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
