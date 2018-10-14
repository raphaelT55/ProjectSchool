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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
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

            //Courses[] courses = DataBase.course();
            //foreach (Courses s in courses)
            //{

            //    comboBox1.Items.Add(s.StartHours.ToString());
            //    comboBox2.Items.Add(s.StartHours.ToString());
            //    comboBox3.Items.Add(s.StartHours.ToString());
            //    comboBox4.Items.Add(s.StartHours.ToString());
            //    comboBox5.Items.Add(s.StartHours.ToString());

            //}

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result1 = comboBox1.Text;

            string result2 = comboBox2.Text;

            string result3 = comboBox3.Text;

            string result4 = comboBox4.Text;

            string result5 = comboBox5.Text;
           // Form1.student.ChoiceCourse(result1, result2, result3, result4, result5);
            MessageBox.Show("You have benn register in this course !");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form a = new Form12();
            a.Show();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
                comboBox2.Items.Remove(comboBox1.Text);
                comboBox3.Items.Remove(comboBox1.Text);
                comboBox4.Items.Remove(comboBox1.Text);
                comboBox5.Items.Remove(comboBox1.Text);

            
        }
        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {

            MessageBox.Show("on y est");


                comboBox1.Items.Remove(comboBox2.Text);
                comboBox3.Items.Remove(comboBox2.Text);
                comboBox4.Items.Remove(comboBox2.Text);
                comboBox5.Items.Remove(comboBox2.Text);

            
        }




        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            


                comboBox2.Items.Remove(comboBox3.Text);
                comboBox1.Items.Remove(comboBox3.Text);
                comboBox4.Items.Remove(comboBox3.Text);
                comboBox5.Items.Remove(comboBox3.Text);

            
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            


                comboBox2.Items.Remove(comboBox4.Text);
                comboBox3.Items.Remove(comboBox4.Text);
                comboBox5.Items.Remove(comboBox4.Text);
                comboBox1.Items.Remove(comboBox4.Text);

            
        }

        private void comboBox5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            


                comboBox1.Items.Remove(comboBox5.Text);
                comboBox2.Items.Remove(comboBox5.Text);
                comboBox3.Items.Remove(comboBox5.Text);
                comboBox4.Items.Remove(comboBox5.Text);

            
        }
    }
    }
