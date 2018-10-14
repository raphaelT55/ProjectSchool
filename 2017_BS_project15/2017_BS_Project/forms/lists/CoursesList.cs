using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2017_BS_Project.forms.lists
{
    public partial class CoursesList : Form
    {
        int ID = 0;

        public CoursesList()
        {
            InitializeComponent();
            DataLoad();
        }

        private void DataLoad()
        {
            try
            {
                DBA db = DBA.Instance;
                db.connect();

                db.getConnection().Open();

                var select = "SELECT * FROM course";
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


        private void add_new_btn_Click(object sender, EventArgs e)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.query("INSERT INTO course (name, capacity) VALUES ('" + name.Text + "', '" + maxStudent.Text + "')");
            DataLoad();
        }

        private void dataGridView1_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            maxStudent.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

        }

        private void Update_btn_Click_1(object sender, EventArgs e)
        {
            DBA db = DBA.Instance;
            db.connect();

            db.query("UPDATE course SET [name] = '" + name.Text + "', [capacity] = '" + maxStudent.Text + "' WHERE id = " + ID + "");
            DataLoad();
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            DBA db = DBA.Instance;
            db.connect();

            db.query("DELETE course WHERE id=" + ID + "");
            DataLoad();
        }
    }


}
