using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2017_BS_Project.forms.studentForms
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            //string[] course = DataBase.NameCourse();
            //foreach (string s in course)
            //{

            //    comboBox1.Items.Add(s);
            //    comboBox2.Items.Add(s);
            //    comboBox3.Items.Add(s);
            //    comboBox4.Items.Add(s);
            //    comboBox5.Items.Add(s);

            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your courses have been register !");
        }
    }
}
