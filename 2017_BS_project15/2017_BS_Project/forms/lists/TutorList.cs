using _2017_BS_Project.tools;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2017_BS_Project.forms.lists
{
    public partial class TutorList : Form
    {
        public TutorList()
        {
            InitializeComponent();
        }

        private void DataLoad()
        {
            try
            {
                DBA db = DBA.Instance;
                db.connect();

                db.getConnection().Open();

                var select = "SELECT idNUmber,fname,lname,email,password, id FROM users WHERE type = 4 ORDER by id DESC";
                var dataAdapter = new SqlDataAdapter(select, db.getConnection());

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CoursesLoad()
        {
            List<Course> listCourses = new List<Course>();
            try
            {
                DBA db = DBA.Instance;
                db.connect();
                var con = db.getConnection();
                con.Open();

                string query = "SELECT id,name FROM course WHERE practice = 1 OR lab  = 1";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listCourses.Add(new Course((int)reader["id"], (string)reader["name"]));
                        }
                    }
                }

                foreach (Course c1 in listCourses)
                {
                    courses_list.Items.Add(c1.Name + "[" + c1.Id.ToString() + "]");
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TutorList_Load(object sender, EventArgs e)
        {
            DataLoad();
            CoursesLoad();
        }

        private bool checkIdNumber(String IdNumber)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.getConnection().Open();
            string stm = "SELECT COUNT(*) FROM users WHERE idNUmber='" + IdNumber + "'";
            SqlCommand cmd = new SqlCommand(stm, db.getConnection());
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            db.getConnection().Close();
            if (count == 0) 
                return true;
            
            else
            
                return false;
            
        }

        public void addTutor(string fname, string lname, string email, string pass, string id, int type)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.query("INSERT INTO users (fname, lname, email, password, idNUmber, type) VALUES ('" + fname + "', '" + lname + "', '" + email + "', '" + pass + "', '" + id + "', 4)");
        }

        private void add_new_btn_Click(object sender, EventArgs e)
        {
            DBA db = DBA.Instance;
            db.connect();


            if (this.checkIdNumber(IdNumber.Text))
            {
                addTutor(fname.Text, lname.Text, email.Text, password.Text, IdNumber.Text, 4);
                DataLoad();
            }
            else

                MessageBox.Show("Type another id number");
            
            
        }

        public void deleteTutor(string ID)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.query("DELETE  users where IdNUmber = " + ID + " and type = 4");
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            
            string ID = IdNumber.Text;
            if (ID != null)
            {
                deleteTutor(ID);
                MessageBox.Show("Record Deleted Successfully!");
            }
            else
                MessageBox.Show("Please Select Record to Delete");
            DataLoad();
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.query("UPDATE users SET [fname]='" + fname.Text + "', [lname]='" + lname.Text + "', [email]='" + email.Text + "',[password]='" + password.Text + "' WHERE idNUmber =" + IdNumber.Text);
            DataLoad();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IdNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            fname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            lname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            email.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            password.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            id.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

            Delete_btn.Enabled = true;
            Update_btn.Enabled = true;

            if (id.Text != "")
            {
                courses_list.Enabled = true;
                save_courses.Enabled = true;
                listActiveCourses();
            }
            else
            {
                courses_list.Enabled = false;
                save_courses.Enabled = false;
            }
        }

        private void IdNumber_TextChanged(object sender, EventArgs e)
        {
            if ((IdNumber.Text.Length == 4) && (email.Text.Length != 0) && (fname.Text.Length != 0) && (lname.Text.Length != 0) && (password.Text.Length >= 4))
            { add_new_btn.Enabled = true; }
        }

        private void fname_TextChanged(object sender, EventArgs e)
        {

            if ((IdNumber.Text.Length == 4) && (email.Text.Length != 0) && (fname.Text.Length != 0) && (lname.Text.Length != 0) && (password.Text.Length >= 4))
            { add_new_btn.Enabled = true; }
        }

        private void lname_TextChanged(object sender, EventArgs e)
        {
            if ((IdNumber.Text.Length == 4) && (email.Text.Length != 0) && (fname.Text.Length != 0) && (lname.Text.Length != 0) && (password.Text.Length >= 4))
            { add_new_btn.Enabled = true; }
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            if ((IdNumber.Text.Length == 4) && (email.Text.Length != 0) && (fname.Text.Length != 0) && (lname.Text.Length != 0) && (password.Text.Length >= 4))
            { add_new_btn.Enabled = true; }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            if ((IdNumber.Text.Length == 4) && (email.Text.Length != 0) && (fname.Text.Length != 0) && (lname.Text.Length != 0) && (password.Text.Length >= 4))
            { add_new_btn.Enabled = true; }
        }

        private void IdNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private bool isExistCoursesToThisUser(int user_id)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.getConnection().Open();
            string stm = "SELECT COUNT(*) FROM courseToTT WHERE id_user=" + user_id + "";
            SqlCommand cmd = new SqlCommand(stm, db.getConnection());
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            db.getConnection().Close();
            if (count > 0)
                return true;
            else
                return false;
        }

        public void listActiveCourses()
        {
            unCheckAllCourses();

            if (!(string.IsNullOrEmpty(id.Text)))
            {

                int id_user = Int32.Parse(id.Text);


                if (isExistCoursesToThisUser(id_user))
                {
                    List<int> coursesId = CoursesCurrentUser(id_user);
                    foreach (int l in coursesId)
                    {
                        var pattern = @"\[(.*?)\]";
                        for (int i = 0; i < courses_list.Items.Count; i++)
                        {
                            string str = (string)courses_list.Items[i];
                            var matches = Regex.Matches(str, pattern);
                            foreach (Match m in matches)
                            {
                                int cId = Int32.Parse(m.Groups[1].ToString());
                                if (l == cId) courses_list.SetItemChecked(i, true);
                            }
                        }
                    }
                }
            }
        }

        private void save_courses_Click(object sender, EventArgs e)
        {
            int id_user = Int32.Parse(id.Text);
            int cId;
            DBA db = DBA.Instance;
            db.connect();

            // delete previous link courses to teacher/tutor
            Console.WriteLine(id_user.ToString());
            db.query("DELETE courseToTT where id_user = " + id_user + "");


            var pattern = @"\[(.*?)\]";
            for (int i = 0; i < courses_list.Items.Count; i++)
            {
                if (courses_list.GetItemChecked(i))
                {
                    string str = (string)courses_list.Items[i];
                    var matches = Regex.Matches(str, pattern);

                    foreach (Match m in matches)
                    {
                        cId = Int32.Parse(m.Groups[1].ToString());

                        db.query("INSERT INTO courseToTT (id_user, id_course) VALUES (" + id_user + ", " + cId + ")");

                        Console.WriteLine(cId.ToString());
                    }
                }
            }
        }


        private List<int> CoursesCurrentUser(int id_user)
        {
            List<int> listCoursesId = new List<int>();
            try
            {
                DBA db = DBA.Instance;
                db.connect();
                var con = db.getConnection();
                con.Open();

                string query = "SELECT id_course FROM courseToTT WHERE id_user = " + id_user + "";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listCoursesId.Add((int)reader["id_course"]);
                        }
                    }
                }
                return listCoursesId;
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void unCheckAllCourses()
        {
            for (int i = 0; i < courses_list.Items.Count; i++)
            {
                courses_list.SetItemChecked(i, false);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
