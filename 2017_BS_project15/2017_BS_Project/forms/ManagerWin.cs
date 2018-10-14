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
using _2017_BS_Project;
using _2017_BS_Project.forms.lists;

namespace _2017_BS_Project.forms
{
    public partial class ManagerWin : Form
    {

        public ManagerWin()
        {
            InitializeComponent();
        }


        private void Manager_FormClosed(object sender, FormClosedEventArgs e)
        {
            startFrom.Instance.Show();
            GlobalItems.currentUser = null;
            
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            label1.Text = "hellow " + GlobalItems.currentUser.fname + " " + GlobalItems.currentUser.lname + ":";


            button8.Text += "("+ GlobalItems.countItems(6).ToString()+ ")";
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            DepartmentList dl = new DepartmentList();
            dl.Show();
        }

        private void btnTeachers_Click(object sender, EventArgs e)
        {
            TeacherList tl = new TeacherList();
            tl.Show();
        }

        private void btnPrograms_Click(object sender, EventArgs e)
        {
            StudentList obj = new StudentList();
            obj.Show();
        }

        private void btnPractisesrs_Click(object sender, EventArgs e)
        {
            TutorList tl = new TutorList();
            tl.Show();
        }

        private void btncourses_Click(object sender, EventArgs e)
        {
            CourseList cl = new CourseList();
            cl.Show();
        }

        private void btnSecretary_Click(object sender, EventArgs e)
        {
            MazkiraList ml = new MazkiraList();
            ml.Show();
        }

        private void tbnClasses_Click(object sender, EventArgs e)
        {
            ClassList cl = new ClassList();
            cl.Show();
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
