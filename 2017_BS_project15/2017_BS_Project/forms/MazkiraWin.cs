using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using _2017_BS_Project.tools;
using _2017_BS_Project.forms.lists;

    namespace _2017_BS_Project.forms
{
    public partial class MazkiraWin : Form
    {
        public MazkiraWin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TeacherList obj = new TeacherList();
            obj.Show();
        }

        private void Mazkira_Load(object sender, EventArgs e)
        {
            label1.Text = "hellow " + GlobalItems.currentUser.fname + " " + GlobalItems.currentUser.lname + ":";
            button8.Text += "(" + GlobalItems.countItems(6).ToString() + ")";
        }

        private void Mazkira_FormClosed(object sender, FormClosedEventArgs e)
        {
            startFrom.Instance.Show();
            GlobalItems.currentUser = null;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DepartmentList obj = new DepartmentList();
            obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StudentList obj = new StudentList();
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TutorList obj = new TutorList();
            obj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CourseList obj = new CourseList();
            obj.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClassList obj = new ClassList();
            obj.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void scheduleOpen_Click(object sender, EventArgs e)
        {
            ScheduleForm obj = new ScheduleForm();
            obj.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Unproved obj = new Unproved();
            obj.Show();
        }
    }
}
