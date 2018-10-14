using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2017_BS_Project.forms.studentForms;
using _2017_BS_Project.tools;
using System.Data.SqlClient;
using _2017_BS_Project.forms.fb;
using Facebook;

namespace _2017_BS_Project.forms {
    public partial class StudentWin : Form
    {
        private string accessToken;

        public StudentWin()
        {
            InitializeComponent();
        }

        public StudentWin(string _accessToken)
        {
            accessToken = _accessToken;
            InitializeComponent();
        }

        public async void ScheduleLoad(int uID)
        {
            try
            {
                timeTable scheduleObj = new timeTable();
                webBrowser1.DocumentText = scheduleObj.clearTable();

                DBA db = DBA.Instance;
                db.connect();
                var con = db.getConnection();
                con.Open();

                string query = "SELECT  * FROM schedule WHERE id IN(SELECT l_id FROM studentSchedule WHERE user_id = "+uID+" )";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            int cID = r.GetInt32(2);
                            string day = r.GetString(4);
                            string title = r.GetString(3) + " " + r.GetString(8);
                            string start = r.GetInt32(5).ToString() + ":00";
                            string end = r.GetInt32(6).ToString() + ":00";

                            scheduleObj.buildEvent(day, title, start, end, "lightgreen");
                        }
                    }
                }

                await Task.Delay(1000);
                webBrowser1.DocumentText = scheduleObj.fill();
                
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void putInCourseList(string s)
        {
            List<ComboBox> addCourseList = new List<ComboBox>();
            addCourseList.Add(c1);
            addCourseList.Add(c2);
            addCourseList.Add(c3);
            addCourseList.Add(c4);
            addCourseList.Add(c5);


            int ind = 0;
            while(ind < 5)
            {
                if (addCourseList[ind].Text == "")
                {
                    addCourseList[ind].Text = s;
                    return;
                }
                ind++;
            }
        }

        private void putOptions(string s)
        {
            List<ComboBox> CourseOptionsList = new List<ComboBox>();
            CourseOptionsList.Add(optC1);
            CourseOptionsList.Add(optC2);
            CourseOptionsList.Add(optC3);
            CourseOptionsList.Add(optC4);
            CourseOptionsList.Add(optC5);


            int ind = 0;
            while (ind < 5)
            {
                if (CourseOptionsList[ind].Text == "")
                {
                    CourseOptionsList[ind].Text = s;
                    return;
                }
                ind++;
            }
        }

        private void CourseLoad()
        {
            try
            {
                DBA db = DBA.Instance;
                db.connect();
                var con = db.getConnection();
                con.Open();

                string query = "SELECT  id, name FROM course";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {

                            c1.Items.Add(r.GetString(1) + "[" + r.GetInt32(0) + "]");
                            c2.Items.Add(r.GetString(1) + "[" + r.GetInt32(0) + "]");
                            c3.Items.Add(r.GetString(1) + "[" + r.GetInt32(0) + "]");
                            c4.Items.Add(r.GetString(1) + "[" + r.GetInt32(0) + "]");
                            c5.Items.Add(r.GetString(1) + "[" + r.GetInt32(0) + "]");
                        }
                    }
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void studentScheduleOptions(int uID)
        {
            try
            {
                DBA db = DBA.Instance;
                db.connect();
                var con = db.getConnection();
                con.Open();

                string query = "SELECT  id, day, startH, endH, class_name FROM schedule WHERE id IN(SELECT l_id FROM studentSchedule WHERE user_id =" + uID + " )";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            string res = r.GetInt32(0).ToString() + "| => " + r.GetString(1) + " " + r.GetInt32(2).ToString() + " - " + r.GetInt32(3).ToString();
                            putOptions(res);
                        }
                    }
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CourseByUserLoad(int uID)
        {
            try
            {
                DBA db = DBA.Instance;
                db.connect();
                var con = db.getConnection();
                con.Open();

                string query = "SELECT  id, name FROM course WHERE id IN(SELECT id_course FROM courseToTT WHERE id_user =" + uID + " );";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            putInCourseList(r.GetString(1) + "[" + r.GetInt32(0) + "]");
                        }
                    }
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void userInfoLoad()
        {
            Fname.Text = GlobalItems.currentUser.fname;
            Lname.Text = GlobalItems.currentUser.lname;
            Email.Text = GlobalItems.currentUser.email;
            Password.Text = GlobalItems.currentUser.password;
        }

        

        private void Form6_Load(object sender, EventArgs e)
        {

            userInfoLoad();
            CourseLoad();
            CourseByUserLoad(GlobalItems.currentUser.id);
            studentScheduleOptions(GlobalItems.currentUser.id);
            ScheduleLoad(GlobalItems.currentUser.id);

            

            if (GlobalItems.CheckUserLevel() == 6)
            {
                button3.Enabled = false;
                button2.Enabled = false;
                MessageBox.Show("Option courses and My Info no active for now. Secretary will update your data and you will have acsses to this option");
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            studentSchedule a = new studentSchedule();
            a.Show();

        }



        private void button5_Click(object sender, EventArgs e)
        {

            
            InfoDialog obj = new InfoDialog(accessToken);
            obj.fbLogOut();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form a = new Form8();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form a = new Form9();
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you already inform your course validate?", "My Application",MessageBoxButtons.YesNo, MessageBoxIcon.Question)    == DialogResult.Yes)
            {
                Form Application = new Form10();
                Application.Show();
            }
            else {
                Form a = new Form11();
                a.Show();
            }

           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form a = new Form13();
            a.Show();
        }


        private void Student_FormClosed(object sender, FormClosedEventArgs e)
        {
            startFrom.Instance.Show();
            GlobalItems.currentUser = null;

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            GlobalItems.slideRight(hollidaysPanel, 0);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            GlobalItems.slideLeft(hollidaysPanel, -260);
        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {
            GlobalItems.slideRight(myInfoPanel, 0);
        }

        private void hideInfo_Click(object sender, EventArgs e)
        {
            GlobalItems.slideLeft(myInfoPanel, -260);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Fname.Text != "" && Lname.Text != "" && Email.Text != "" && Password.Text != "")
            {
                DBA db = DBA.Instance;
                db.connect();
                db.query("UPDATE users SET[fname] = '" + Fname.Text + "', [lname]='" + Lname.Text + "', [email]='" + Email.Text + "', [password]='" + Password.Text + "' WHERE id = " + GlobalItems.currentUser.id + "");

                GlobalItems.currentUser.fname = Fname.Text;
                GlobalItems.currentUser.lname = Lname.Text;
                GlobalItems.currentUser.email = Email.Text;
                GlobalItems.currentUser.password = Password.Text;
                MessageBox.Show("Data Saved");
            }
            else { MessageBox.Show("All fields have to be filled"); }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            GlobalItems.slideRight(coursesPanel, 0);
        }

        private void coursesHide_Click(object sender, EventArgs e)
        {
            GlobalItems.slideLeft(coursesPanel, -660);
        }

        private void CourseUpdate(int uId)
        {
            List<ComboBox> addCourseList = new List<ComboBox>();
            addCourseList.Add(c1);
            addCourseList.Add(c2);
            addCourseList.Add(c3);
            addCourseList.Add(c4);
            addCourseList.Add(c5);


            DBA db = DBA.Instance;
            db.connect();
            db.query("DELETE courseToTT where id_user = " + uId + "");

            int ind = 0;
            while (ind < 5)
            {
                if (addCourseList[ind].Text != "")
                {
                    string course = addCourseList[ind].GetItemText(addCourseList[ind].SelectedItem);

                    course = course.Remove(course.Length - 1);
                    string[] course_data = course.Split('[');
                    int course_id = GlobalItems.strToInt(course_data[1]);

                    db.query("INSERT INTO courseToTT (id_user, id_course) VALUES (" + uId + ", " + course_id + ")");
                }
                ind++;
            }
        }

        private int getEventId(string eve)
        {
            if (eve == "" || eve == null) return 0;
            string[] c = eve.Split('|');
            return GlobalItems.strToInt(c[0]);
        }

        private void bildStudentSchedule(int uId)
        {
            bool flag = true;
            if (c1.Text != "" && optC1.Text == "") flag = false;
            if (c2.Text != "" && optC2.Text == "") flag = false;
            if (c3.Text != "" && optC3.Text == "") flag = false;
            if (c4.Text != "" && optC4.Text == "") flag = false;
            if (c5.Text != "" && optC5.Text == "") flag = false;

            if (!flag) { MessageBox.Show("Option by each course cannot be empty!!!"); return; }

            List<int> lId = new List<int>();
            lId.Add(getEventId(optC1.Text));
            lId.Add(getEventId(optC2.Text));
            lId.Add(getEventId(optC3.Text));
            lId.Add(getEventId(optC4.Text));
            lId.Add(getEventId(optC5.Text));

            DBA db = DBA.Instance;
            db.connect();

            db.query("DELETE studentSchedule where user_id = " + uId + "");

            foreach (int i in lId)
            {  
                if (i != 0) 
                db.query("INSERT INTO studentSchedule (user_id, l_id) VALUES (" + uId + ", " + i + ")");
            }

        }

        private void btnSaveCourse_Click(object sender, EventArgs e)
        {
            CourseUpdate(GlobalItems.currentUser.id);
            bildStudentSchedule(GlobalItems.currentUser.id);
            ScheduleLoad(GlobalItems.currentUser.id);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GlobalItems.slideRight(requestPanel, 0);
        }

        private void hideRequest_Click(object sender, EventArgs e)
        {
            GlobalItems.slideLeft(requestPanel, -260);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You will receive your certificate by email ");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You will receive your certificate by email ");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You will receive your certificate by email ");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You will receive your certificate by email ");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You will receive your certificate by email ");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You will receive your certificate by email ");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GlobalItems.slideRight(friend_id, 0);
        }

        private void hideFriend_Click(object sender, EventArgs e)
        {
            GlobalItems.slideLeft(friend_id, -260);
        }

        private void Send_Click(object sender, EventArgs e)
        {
            string id = GlobalItems.getIdNumber("users", "IdNUmber", fId.Text);
            if (id != null)
            {
                int friend_id = checkStudentId(id);
                if (friend_id != -1)
                {
                    int i;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 2000;

                    for (i = 0; i <= 2000; i++)
                    {
                        progressBar1.Value = i;
                    }

                    if (progressBar1.Value == 2000)
                    { 
                        CourseByUserLoad(friend_id);
                        studentScheduleOptions(friend_id);

                        CourseUpdate(GlobalItems.currentUser.id);
                        bildStudentSchedule(GlobalItems.currentUser.id);
                        ScheduleLoad(GlobalItems.currentUser.id);

                        MessageBox.Show("Data Saved!");
                        return;
                    }
                }
                MessageBox.Show("Error ID is incorrect!!!");
                return;
            }
            MessageBox.Show("Error ID is incorrect!!!");
            return;
        }


        public int checkStudentId(string ID)
        {
            try
            {
                DBA db = DBA.Instance;
                db.connect();
                var con = db.getConnection();
                con.Open();

                string query = "SELECT  id FROM users WHERE IdNUmber = '" + ID + "' AND type = 5 ";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            int cID = r.GetInt32(0);
                            return cID;
                        }
                        return -1;
                    }
                }
            }

            catch (SqlException ex)
            {
                Console.Out.WriteLine(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }


        public void getAllCourseOptions(int course_id, ComboBox opt)
        {
            try
            {
                DBA db = DBA.Instance;
                db.connect();
                var con = db.getConnection();
                con.Open();

                string query = "SELECT  id, day, startH, endH, class_name FROM schedule WHERE course_id = " + course_id;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            string res = r.GetInt32(0).ToString() + "| => " + r.GetString(1) + " " + r.GetInt32(2).ToString() + " - " + r.GetInt32(3).ToString();
                            opt.Items.Add(res);
                               
                        }
                        
                    }
                }
            }

            catch (SqlException ex)
            {
                Console.Out.WriteLine(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }

        private void c1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string course = c1.GetItemText(c1.SelectedItem);
            optC1.Text = "";
            if (course != "")
            {
                optC1.Items.Clear();
                course = course.Remove(course.Length - 1);
                string[] course_data = course.Split('[');
                int course_id = GlobalItems.strToInt(course_data[1]);
                getAllCourseOptions(course_id, optC1);
            }
            else
            {
                optC1.Items.Clear();
            }
        }

        private void c2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string course = c2.GetItemText(c2.SelectedItem);
            optC2.Text = "";
            if (course != "")
            {
                optC2.Items.Clear();
                course = course.Remove(course.Length - 1);
                string[] course_data = course.Split('[');
                int course_id = GlobalItems.strToInt(course_data[1]);
                getAllCourseOptions(course_id, optC2);
            }
            else
            {
                optC2.Items.Clear();
            }
        }

        

        private void c3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string course = c3.GetItemText(c3.SelectedItem);
            optC3.Text = "";
            if (course != "")
            {
                optC3.Items.Clear();
                course = course.Remove(course.Length - 1);
                string[] course_data = course.Split('[');
                int course_id = GlobalItems.strToInt(course_data[1]);
                getAllCourseOptions(course_id, optC3);
            }
            else
            {
                optC3.Items.Clear();
            }
        }

        private void c4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string course = c4.GetItemText(c4.SelectedItem);
            optC4.Text = "";
            if (course != "")
            {
                optC4.Items.Clear();
                course = course.Remove(course.Length - 1);
                string[] course_data = course.Split('[');
                int course_id = GlobalItems.strToInt(course_data[1]);
                getAllCourseOptions(course_id, optC4);
            }
            else
            {
                optC4.Items.Clear();
            }
        }

        private void c5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string course = c5.GetItemText(c5.SelectedItem);
            optC5.Text = "";
            if (course != "")
            {
                optC5.Items.Clear();
                course = course.Remove(course.Length - 1);
                string[] course_data = course.Split('[');
                int course_id = GlobalItems.strToInt(course_data[1]);
                getAllCourseOptions(course_id, optC5);
            }
            else
            {
                optC5.Items.Clear();
            }
        }
    }
}
