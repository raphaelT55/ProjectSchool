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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //new
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    MessagesErrors();


        //    if (Register.CheckPassword(textBox3.Text) == true && Register.CheckFieldEmpty(textBox3.Text) == false  && Register.CheckSamePassword(textBox3.Text, textBox5.Text))

        //    if (Register.CheckFieldEmpty(textBox1.Text) == false && Register.CheckId(textBox1.Text) == true && DataBase.CheckIdExistence(textBox1.Text)==false)

        //            if (Register.CheckFieldEmpty(textBox2.Text) == false)

        //                if (Register.CheckFieldEmpty(textBox4.Text) == false)

        //                    if (Register.CheckFieldEmpty(textBox6.Text) == false && Register.CheckMail(textBox6.Text) == true)

        //                        if (!Register.CheckFieldEmpty(comboBox1.Text) && !Register.CheckFieldEmpty(comboBox2.Text) && !Register.CheckFieldEmpty(comboBox3.Text))

        //                        {

        //                            student student = new student(comboBox1.Text, comboBox2.Text, comboBox3.Text, textBox3.Text, textBox1.Text, textBox2.Text, textBox4.Text, textBox6.Text);
        //                            // DataBase.UpdateRegister(student.password, student.email, student.id, student.fname, student.lname, student.semester, student.department, student.year);
        //                            student.UpdateRegister();
        //                            MessageBox.Show("Successful Registration");
        //                            this.Close();
        //                        }

        //}

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox1.Items.Add("Sunday");
            comboBox1.Items.Add("Monday");
            comboBox1.Items.Add("Tuesday");
            comboBox1.Items.Add("wednesday");
            comboBox1.Items.Add("Thursday");
            comboBox1.Items.Add("Friday");
            comboBox1.Items.Add("Saturday");
            comboBox1.SelectedIndex = comboBox1.FindStringExact("Sunday");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = label5.Text;
            comboBox1.Items.Add(name);

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox1.Items.Add("a");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        //private void MessagesErrors()
        //{
        //    if (Register.CheckFieldEmpty(textBox1.Text) == true)
        //    {
        //        errorProvider1.SetError(textBox1, "Vous n'avez pas mis votre id");
        //        label10.Text = " 9 DIGITS MINIMUM !";

        //    }
        //    else
        //    {
        //        label10.Text = "";
        //    }
        //    if (Register.AccountExist(textBox1.Text) == true)
        //    {
        //        errorProvider1.SetError(textBox1, "Vous n'avez pas mis votre id");
        //        label10.Text = "YOUR ID IS ALREADY USED!";

        //    }
        //    else
        //    {
        //        label10.Text = "";
        //    }
        //    if (Register.CheckFieldEmpty(textBox2.Text) == true)
        //    {
        //        errorProvider1.SetError(textBox2, "Vous n'avez pas mis votre nom");
        //        label11.Text = " FIELD EMPTY !";

        //    }
        //    else
        //    {
        //        label11.Text = "";
        //    }
        //    if (Register.CheckFieldEmpty(textBox3.Text) == true)
        //    {
        //        errorProvider1.SetError(textBox3, "Vous n'avez pas mis votre nom");
        //        label16.Text = "1 UPPER 1 DIGIT AND MINIMUM 8 CHARACTERS !";

        //    }
        //    else
        //    {
        //        label16.Text = "";
        //    }
        //    if (Register.CheckFieldEmpty(textBox4.Text) == true)
        //    {
        //        errorProvider1.SetError(textBox4, "Vous n'avez pas mis votre nom");
        //        label12.Text = " FIELD EMPTY !";
        //    }
        //    else
        //    {
        //        label12.Text = "";
        //    }
        //    if (Register.CheckFieldEmpty(textBox5.Text) == true)
        //    {
        //        errorProvider1.SetError(textBox5, "You have to write the same password");
        //        label18.Text = "FIELD EMPTY";
        //    }
        //    else
        //    {
        //        label18.Text = "";
        //    }
        //    if (Register.CheckFieldEmpty(comboBox1.Text) == true)
        //    {
        //        errorProvider1.SetError(comboBox1, "Vous n'avez pas mis votre semestre");
        //        label13.Text = " FIELD EMPTY !";
        //    }
        //    else
        //    {
        //        label13.Text = "";
        //    }
        //    if (Register.CheckFieldEmpty(comboBox2.Text) == true)
        //    {
        //        errorProvider1.SetError(comboBox2, "Vous n'avez pas mis votre department");
        //        label14.Text = " FIELD EMPTY !";
        //    }
        //    else
        //    {
        //        label14.Text = "";
        //    }
        //    if (Register.CheckFieldEmpty(comboBox3.Text) == true)
        //    {
        //        errorProvider1.SetError(comboBox3, "Vous n'avez pas mis votre annee");
        //        label15.Text = "FIELD EMPTY !";
        //    }
        //    else
        //    {
        //        label15.Text = "";
        //    }
        //    if (Register.CheckFieldEmpty(textBox6.Text) == true)
        //    {
        //        errorProvider1.SetError(textBox6, "Vous n'avez pas ou mal  mis votre mail");
        //        label17.Text = "YOUU NEED GOOD CONDITIONS (aaaa@...)!";

        //    }
        //    else
        //    {
        //        label17.Text = "";
        //    }

        //    if (Register.CheckSamePassword(textBox3.Text, textBox5.Text) == false)
        //    {
        //        errorProvider1.SetError(textBox5, "Vous n'avez pas ou mal  mis votre mail");
        //        label18.Text = "WRITE THE SAME PASSWORD";
        //    }
        //    else
        //    {
        //        label18.Text = "";
        //    }

        //}

    }
}

