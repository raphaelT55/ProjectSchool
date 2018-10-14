using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using _2017_BS_Project.users;

namespace _2017_BS_Project.forms.lists
{
    public partial class MazkiraList : Form
    {
        public MazkiraList()
        {
            InitializeComponent();
        }
        private void show()
        {
            DataTable dt = new DataTable();
            DBA db = DBA.Instance;
            db.connect();
            db.getConnection().Open();
            var select = "SELECT * FROM users WHERE type=2 ORDER by id DESC";
            var dataAdapter = new SqlDataAdapter(select, db.getConnection());
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(dt);
            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format("IdNUmber LIKE '%{0}%'", IdNumber.Text);
            dataGridView1.DataSource = DV;
        }

        private void DataLoad()
        {
            try
            {
                add_new_btn.Enabled = false;
                Delete_btn.Enabled = false;
                Update_btn.Enabled = false;
                IdNumber.Enabled = true;
                IdNumber.Text = "";
                fname.Enabled = false;
                fname.Text = "";
                lname.Enabled = false;
                lname.Text = "";
                email.Enabled = false;
                email.Text = "";
                password.Enabled = false;
                password.Text = "";
                DBA db = DBA.Instance;
                db.connect();

                db.getConnection().Open();

                var select = "SELECT idNUmber,fname,lname,email,password FROM users WHERE type = 2";
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

        private void MazkiraList_Load(object sender, EventArgs e)
        {
            DataLoad();
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

        private void add_new_btn_Click(object sender, EventArgs e)
        {
            DBA db = DBA.Instance;
            db.connect();

            if ((fname.Text.Length != 0) && (lname.Text.Length != 0) && (email.Text.Length != 0) && (password.Text.Length != 0))
            {
                if (this.checkIdNumber(IdNumber.Text))
                {
                    db.query("INSERT INTO users (fname, lname, email, password, idNUmber, type) VALUES ('" + fname.Text + "', '" + lname.Text + "', '" + email.Text + "', '" + password.Text + "', '" + IdNumber.Text + "', 2)");
                    DataLoad();
                }
                else

                    MessageBox.Show("Type another id number");
            }
            else
                MessageBox.Show("Not all the details is filled");

        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            DBA db = DBA.Instance;
            db.connect();
            string ID = IdNumber.Text;
            if (ID != null)
            {
                // Users u = new Users("SELECT FROM users where IdNUmber=s");
                db.query("DELETE  users where IdNUmber = " + ID + " and type = 2");
                MessageBox.Show("Record Deleted Successfully!");
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
            DataLoad();

        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.query("UPDATE users SET [fname]='" + fname.Text + "', [lname]='" + lname.Text + "', [email]='" + email.Text + "',[password]='" + password.Text + "' WHERE idNUmber =" + IdNumber.Text);
            DataLoad();
        }

        private void IdNumber_TextChanged(object sender, EventArgs e)
        {
            //show();
            if (IdNumber.Text.Length !=0)
            { fname.Enabled = true;
                lname.Enabled = true;
                email.Enabled = true;
                password.Enabled = true;
                add_new_btn.Enabled = true;
            }
            else
            {
                fname.Enabled = false;
                fname.Text = "";
                lname.Enabled = false;
                lname.Text = "";
                email.Enabled = false;
                email.Text = "";
                password.Enabled = false;
                password.Text = "";
            }
        }

        private void dataGridView1_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            IdNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            fname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            lname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            email.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            password.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            Delete_btn.Enabled = true;
            Update_btn.Enabled = true;
            add_new_btn.Enabled = false;
            IdNumber.Enabled = false;
        }

        private void IdNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
