using _2017_BS_Project.tools;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Register.CheckFieldEmpty(textBox6.Text) == true)
            {
                errorProvider1.SetError(textBox6, "Vous n'avez pas ou mal  mis votre mail");
                label6.Text = "YOUU NEED GOOD CONDITIONS (aaaa@...)!";

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (Register.CheckFieldEmpty(textBox6.Text) == true)
            {
                errorProvider1.SetError(textBox6, "Vous n'avez pas   mis votre mail");
                label6.Text = "FIELD EMPTY!";


            }
            if ( Register.CheckMail(textBox6.Text) == false)
                {
                errorProvider1.SetError(textBox6, "Vous n'avez mal  mis votre mail");
                label6.Text = "GOOD CONDITIONS PLEASE(aaaa@...)!";

            }

            else
            {
                MessageBox.Show("You will receive a mail from the school ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
