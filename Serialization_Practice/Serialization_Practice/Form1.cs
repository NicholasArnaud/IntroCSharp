using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serialization_Practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            Student curStudent = new Student(this.StudentName.Text, (int)this.StudentAge.Value, this.StudentID.Text);
            DataManage<Student>.Serialize("Student", curStudent);
        }

        private void LoadLast_Click(object sender, EventArgs e)
        {
            Student lastStudent = DataManage<Student>.Deserialize("Student");
            this.StudentName.Text = lastStudent.Name;
            this.StudentAge.Value = lastStudent.Age;
            this.StudentID.Text = lastStudent.ID;
        }
    }
}