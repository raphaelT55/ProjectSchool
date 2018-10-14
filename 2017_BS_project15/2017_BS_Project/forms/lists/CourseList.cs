using _2017_BS_Project.tools;
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
using System.Windows.Documents;
using System.Windows.Forms;

namespace _2017_BS_Project.forms.lists
{
    public partial class CourseList : Form
    {
        public CourseList()
        {
            InitializeComponent();
        }

        private bool checkUnique()
        {
            if (IdNumber.Text.Trim() == null || IdNumber.Text.Trim() == "") return true;
            string ID = IdNumber.Text.Trim();

            try
            {
                DBA db = DBA.Instance;
                db.connect();
                var conn = db.getConnection();
                conn.Open();

                //var select = "SELECT * FROM course";
                SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM course WHERE id = " + ID + " ", conn);
                Int32 count = (Int32)comm.ExecuteScalar();
                Console.WriteLine(count);
                if (count > 0) return false;
                return true;
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void DepartmentLoad()
        {
            List<Department> listDepartment = new List<Department>();
            try
            {
                DBA db = DBA.Instance;
                db.connect();
                var con = db.getConnection();
                con.Open();

                string query = "SELECT id,name FROM departments ORDER BY id DESC";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listDepartment.Add(new Department((int)reader["id"], (string)reader["name"]));
                        }
                    }
                }

                foreach (Department d1 in listDepartment)
                {
                    departmentBox.Items.Add(d1.Name + "[" + d1.Id.ToString() + "]");
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int DepId(String selectedItem)
        {
            Regex regex = new Regex(@"\[(.*)]");
            Match match = regex.Match(selectedItem);
            
            int IdD = 0;
            Int32.TryParse(match.Groups[1].ToString(), out IdD);
            return IdD;
        }

        private void setDepartment(int id)
        {
            DBA db = DBA.Instance;
            db.connect();
            var con = db.getConnection();
            con.Open();

            string query = "SELECT id,name FROM departments WHERE id = "+id;
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        Department current =  new Department((int)reader["id"], (string)reader["name"]);
                        departmentBox.Text = current.Name + "[" + current.Id.ToString() + "]";
                    }
                }
            }
        }

        private void DataLoad()
        {
            try
            {
                DBA db = DBA.Instance;
                db.connect();

                db.getConnection().Open();

                var select = "SELECT * FROM course ORDER by id DESC";
                var dataAdapter = new SqlDataAdapter(select, db.getConnection());

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView.ReadOnly = true;
                dataGridView.DataSource = ds.Tables[0];
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool DataCheck()
        {
            if ((name.Text.Length != 0))
            {
                MessageBox.Show("Name can not be empty", "Data Error",
    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!(Regex.IsMatch(capacity.Text, @"^\d+$")))
            {
                MessageBox.Show("Capacity have to be number", "Data Error",
    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private void Delete_Click(object sender, EventArgs e)
        {
            DeleteCourse(IdNumber.Text);
            clear();
            DataLoad();
            MessageBox.Show("Record deleted");
        }

        public void DeleteCourse(string ID)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.query("DELETE course where id = " + ID + " ");
           
        }

        private void Add_Click(object sender, EventArgs e)
        {

            // values
            string cName = name.Text;
            int curCap = 0;
            int maxCap = int.Parse(capacity.Text);
            int cLecture = 0;
            int cPractice = 0;
            int cLab = 0;

            int cLecH = 0;
            int cPH = 0;
            int cLabH = 0;

            if (lecture.Checked) {
                cLecture = 1;
                string t = lecHours.GetItemText(lecHours.SelectedItem);
                cLecH = int.Parse(t);
            }

            if (practice.Checked) {
                cPractice = 1;
                cPH = int.Parse(pHours.GetItemText(pHours.SelectedItem));
            }


            if (lab.Checked)
            {
                cLab = 1;
                cLabH = int.Parse(labHours.GetItemText(labHours.SelectedItem));
            }

            int id_dep = DepId(departmentBox.SelectedItem.ToString());
            String course_description = description.Text;

            //Console.WriteLine(cName + curCap + maxCap+ cLecture+ cLecH+ cPractice+ cPH+ cLab+ cLabH);

            DBA db = DBA.Instance;
            db.connect();
            db.query("INSERT INTO course (name,capacity, maxCapacity, lecture, lecture_hours, practice, practice_hours, lab, lab_hours, id_department, description) VALUES ('" + cName + "', '" + curCap + "', '" + maxCap + "', '" + cLecture + "', '" + cLecH + "', '" + cPractice + "', '" + cPH + "', '" + cLab + "', '" + cLabH + "' , '" + id_dep + "', '" + course_description + "' )");
            DataLoad();
        }

        public void addCourse(string cName, int curCap, int maxCap, int cLecture, int cLecH, int cPractice, int cPH, int cLab, int cLabH, int id_dep, string course_description)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.query("INSERT INTO course (name,capacity, maxCapacity, lecture, lecture_hours, practice, practice_hours, lab, lab_hours, id_department, description) VALUES ('" + cName + "', '" + curCap + "', '" + maxCap + "', '" + cLecture + "', '" + cLecH + "', '" + cPractice + "', '" + cPH + "', '" + cLab + "', '" + cLabH + "' , '" + id_dep + "', '" + course_description + "' )");
        }

        private void CourseList_Load(object sender, EventArgs e)
        {
            DataLoad();
            DepartmentLoad();
        }

        // get current data from data grid view
        private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string newId = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            string newName = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                string newCap = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            
            string uLecture = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            string uLectureHour = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
            string uPractice = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
            string uPracticeHour = dataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
            string uLab = dataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
            string uLabHour = dataGridView.Rows[e.RowIndex].Cells[9].Value.ToString();

            string department_id = dataGridView.Rows[e.RowIndex].Cells[10].Value.ToString();
            if (department_id != "") {
                int x = 0;
                Int32.TryParse(department_id, out x);
                Console.Out.Write(x);
                setDepartment(x);
            }

            string _desc = dataGridView.Rows[e.RowIndex].Cells[11].Value.ToString();
            description.Text = _desc;

            if (newName != "" && newCap != "" )
            {
                name.Text = newName;
                capacity.Text = newCap;
            }

            if (uLecture == "1") {
                lecture.Checked = true;
                lecHours.Text = uLectureHour;
            }
            else
            {
                lecture.Checked = false;
                lecHours.Text = "";
                lecHours.Enabled = false;

            }

            if (uPractice == "1")
            {
                practice.Checked = true;
                pHours.Text = uPracticeHour;
            }
            else
            {
                practice.Checked = false;
                pHours.Text = "";
                pHours.Enabled = false;

            }

            if (uLab == "1")
            {
                lab.Checked = true;
                labHours.Text = uLabHour;
            }
            else
            {
                lab.Checked = false;
                labHours.Text = "";
                labHours.Enabled = false;

            }

            IdNumber.Text = newId;

            if (checkUnique())
            {
                add_new_btn.Enabled = true;
                Delete_btn.Enabled = false;
                Update_btn.Enabled = false;
            }
            else
            {
                add_new_btn.Enabled = true;
                Delete_btn.Enabled = true;
                Update_btn.Enabled = true;
            }

        }

        private void Update_btn_Click(object sender, EventArgs e)
        {

            // values
            string cName = name.Text;
            //int curCap = 0;
            int maxCap = int.Parse(capacity.Text);
            int cLecture = 0;
            int cPractice = 0;
            int cLab = 0;

            int cLecH = 0;
            int cPH = 0;
            int cLabH = 0;

            if (lecture.Checked)
            {
                cLecture = 1;
                string t = lecHours.GetItemText(lecHours.SelectedItem);
                cLecH = int.Parse(t);
            }

            if (practice.Checked)
            {
                cPractice = 1;
                cPH = int.Parse(pHours.GetItemText(pHours.SelectedItem));
            }


            if (lab.Checked)
            {
                cLab = 1;
                cLabH = int.Parse(labHours.GetItemText(labHours.SelectedItem));
            }
            int id_dep = DepId(departmentBox.SelectedItem.ToString());
            string _desc = description.Text;

            DBA db = DBA.Instance;
            db.connect();
            db.query("UPDATE course SET [name]='" + cName + "', [maxCapacity]='" + maxCap + "', [lecture]='" + cLecture + "', [lecture_hours]='" + cLecH + "', [practice]='" + cPractice + "', [practice_hours]='" + cPH + "', [lab]='" + cLab + "', [lab_hours]='" + cLabH + "', [id_department]='" + id_dep + "', [description]='" + _desc + "'  WHERE id =" + IdNumber.Text);
            DataLoad();
        }

        private void lecture_CheckedChanged(object sender, EventArgs e)
        {
            if (lecture.Checked) 
                lecHours.Enabled = true;
            else
            lecHours.Enabled = false;
        }

        private void practice_CheckedChanged(object sender, EventArgs e)
        {
            if (practice.Checked)
                pHours.Enabled = true;
            else
                pHours.Enabled = false;
        }

        private void lab_CheckedChanged(object sender, EventArgs e)
        {
            if (lab.Checked)
                labHours.Enabled = true;
            else
                labHours.Enabled = false;
        }

        private void clear()
        {
            IdNumber.Text = "";
            name.Text = "";
            capacity.Text = "";
            lecture.Checked = false;
            practice.Checked = false;
            lab.Checked = false;
            lecHours.Enabled = false;
            pHours.Enabled = false;
            labHours.Enabled = false;
            lecHours.Text = "";
            pHours.Text = "";
            labHours.Text = "";
            departmentBox.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
