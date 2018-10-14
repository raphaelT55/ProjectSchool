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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();

            //Courses[] v = Form1.student.courseSemester();
            //int check = 1;
            //foreach (Courses s in v)
            //    foreach (Courses x in v)
            //    {
            //        if (x.name == s.name &&  x.id!=s.id&&check==1 )
            //        {
            //            this.textBox1.AppendText(x.name + " " + x.StartHours + "h to " + x.EndHours + "h "+ x.day);
            //            this.textBox6.AppendText(s.name + " " + s.StartHours + "h to " + s.EndHours + "h"+ s.day);
            //            check++;
            //            break;
            //        }
            //        if (x.name == s.name && x.id != s.id && check == 2)
            //        {
            //            this.textBox2.AppendText(x.name + " " + x.StartHours + "h to " + x.EndHours + "h "+ x.day);
            //            this.textBox7.AppendText(s.name + " " + s.StartHours + "h to " + s.EndHours + "h "+ s.day);
            //            check++;
            //            break;
            //        }
            //        if (x.name == s.name && x.id != s.id && check == 3)
            //        {
            //            this.textBox3.AppendText(x.name + " " + x.StartHours + "h to " + x.EndHours + "h "+ x.day);
            //            this.textBox8.AppendText(s.name + " " + s.StartHours + "h to " + s.EndHours + "h "+ s.day);
            //            check++;
            //            break;
            //        }
            //        if (x.name == s.name && x.id != s.id && check == 4)
            //        {
            //            this.textBox4.AppendText(x.name + " " + x.StartHours + "h to " + x.EndHours + "h "+ x.day);
            //            this.textBox9.AppendText(s.name + " " + s.StartHours + "h to " + s.EndHours + "h"+ s.day);
            //            check++;
            //            break;
            //        }
            //        if (x.name == s.name && x.id != s.id && check == 5)
            //        {
            //            this.textBox5.AppendText(x.name + " " + x.StartHours + "h to " + x.EndHours + "h "+ x.day);
            //            this.textBox10.AppendText(s.name + " " + s.StartHours + "h to " + s.EndHours + "h "+ s.day);
            //            check++;
            //            break;
            //        }
                
            //    }

          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
          
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //Courses[] courses = new Courses[5];
            //for (int j = 0; j < 5; j++)
            //    courses[j] = new Courses();
            //Courses[] v = Form1.student.courseSemester();
            //int Id1=0;
            //int Id2=0;
            //int Id3=0;
            //int Id4=0;
            //int Id5=0;
            //int check = 1;
            //int index = 0;
            //foreach (Courses s in v)
            //    foreach (Courses x in v)
            //    {
            //        if (x.name == s.name && x.id != s.id && check == 1)
            //        {
            //            if (checkBox1.Checked == true)
            //            {
            //                Id1 = x.id;
            //                courses[index] = x;
            //                index++;
            //            }
            //            if (checkBox2.Checked == true)
            //            {
            //                Id1 = s.id;
            //                courses[index] = s;
            //                index++;
            //            }
            //            check++;
            //            break;
            //        }
            //        if (x.name == s.name && x.id != s.id && check == 2)
            //        {
            //            if (checkBox3.Checked == true)
            //            {
            //                Id2 = x.id;
            //                courses[index] = x;
            //                index++;
            //            }
            //            if (checkBox4.Checked == true)
            //            {
            //                Id2 = s.id;
            //                courses[index] = s;
            //                index++;
            //            }
            //            check++;
            //            break;
            //        }
            //        if (x.name == s.name && x.id != s.id && check == 3)
            //        {
            //            if (checkBox5.Checked == true)
            //            {
            //                Id3 = x.id;
            //                courses[index] = x;
            //                index++;
            //            }
            //            if (checkBox6.Checked == true)
            //            {
            //                Id3 = s.id;
            //                courses[index] = s;
            //                index++;
            //            }
            //            check++;
            //            break;
            //        }
            //        if (x.name == s.name && x.id != s.id && check == 4)
            //        {
            //            if (checkBox7.Checked == true)
            //            {
            //                Id4 = x.id;
            //                courses[index] = x;
            //                index++;
            //            }
            //            if (checkBox8.Checked == true)
            //            {
            //                Id4 = s.id;
            //                courses[index] = s;
            //                index++;
            //            }
            //            check++;
            //            break;
            //        }
            //        if (x.name == s.name && x.id != s.id && check == 5)
            //        {
            //            if (checkBox9.Checked == true)
            //            {
            //                Id5 = x.id;
            //                courses[index] = x;
            //                index++;
            //            }
            //            if (checkBox10.Checked == true)
            //            {
            //                Id5 = s.id;
            //                courses[index] = s;
            //                index++;
            //            }
            //            check++;
            //            break;
            //        }

            //    }


            //if (Form1.student.CourseSuperimposed(courses))
            //{
            //    DataBase.SetIdCourses(Id1, Id2, Id3, Id4, Id5);
            //    MessageBox.Show("Your choice has been save  !");
            //}

         
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (checkBox2.Enabled == true)
                checkBox2.Enabled = false;
            else
                checkBox2.Enabled = true;
        }

        private void checkBox2_MouseDown(object sender, MouseEventArgs e)
        {

            if (checkBox1.Enabled == true)
                checkBox1.Enabled = false;
            else
                checkBox1.Enabled = true;
        }

        private void checkBox3_MouseDown(object sender, MouseEventArgs e)
        {

            if (checkBox4.Enabled == true)
                checkBox4.Enabled = false;
            else
                checkBox4.Enabled = true;
        }
        private void checkBox4_MouseDown(object sender, MouseEventArgs e)
        {

            if (checkBox3.Enabled == true)
                checkBox3.Enabled = false;
            else
                checkBox3.Enabled = true;
        }
        private void checkBox5_MouseDown(object sender, MouseEventArgs e)
        {

            if (checkBox6.Enabled == true)
                checkBox6.Enabled = false;
            else
                checkBox6.Enabled = true;
        }
        private void checkBox6_MouseDown(object sender, MouseEventArgs e)
        {

            if (checkBox5.Enabled == true)
                checkBox5.Enabled = false;
            else
                checkBox5.Enabled = true;
        }
        private void checkBox7_MouseDown(object sender, MouseEventArgs e)
        {

            if (checkBox8.Enabled == true)
                checkBox8.Enabled = false;
            else
                checkBox8.Enabled = true;
        }
        private void checkBox8_MouseDown(object sender, MouseEventArgs e)
        {

            if (checkBox7.Enabled == true)
                checkBox7.Enabled = false;
            else
                checkBox7.Enabled = true;
        }
        private void checkBox9_MouseDown(object sender, MouseEventArgs e)
        {

            if (checkBox10.Enabled == true)
                checkBox10.Enabled = false;
            else
                checkBox10.Enabled = true;
        }
        private void checkBox10_MouseDown(object sender, MouseEventArgs e)
        {

            if (checkBox9.Enabled == true)
                checkBox9.Enabled = false;
            else
                checkBox9.Enabled = true;
        }
    }
}
