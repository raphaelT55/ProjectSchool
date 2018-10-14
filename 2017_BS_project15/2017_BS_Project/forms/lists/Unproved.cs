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
    public partial class Unproved : Form
    {
        public Unproved()
        {
            InitializeComponent();
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
                typeChoose.Text = "New User";
                DBA db = DBA.Instance;
                db.connect();

                db.getConnection().Open();

                var select = "SELECT idNUmber,fname,lname,email,password FROM users WHERE type = 6";
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

        private void Unproved_Load(object sender, EventArgs e)
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

        public void addUser(string fname, string lname, string email, string pass, string id, int type)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.query("INSERT INTO users (fname, lname, email, password, idNUmber, type) VALUES ('" + fname + "', '" + lname + "', '" + email + "', '" + pass + "', '" + id + "', '" + type + "')");
        }

        private void add_new_btn_Click(object sender, EventArgs e)
        {
            
            if ((fname.Text.Length != 0) && (lname.Text.Length != 0) && (email.Text.Length != 0) && (password.Text.Length != 0))
            {
                if (this.checkIdNumber(IdNumber.Text))
                {
                    addUser(fname.Text, lname.Text, email.Text, password.Text, IdNumber.Text, 6);
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
                db.query("DELETE  users where IdNUmber = " + ID + " and type = 6");
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
            int newType = checkTypeByString(typeChoose.GetItemText(typeChoose.SelectedItem));
            String s = IdNumber.Text;

            DBA db = DBA.Instance;
            db.connect();
            db.query("UPDATE users SET [fname]='" + fname.Text + "', [lname]='" + lname.Text + "', [email]='" + email.Text + "',[password]='" + password.Text + "', [type] = " + newType + "  WHERE idNUmber = '" + s+ "' ");
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

        private int checkTypeByString(String s)
        {
            switch (s)
            {
                case "New User": return 6;
                case "Teacher": return 3;
                case "Tutor": return 4;
                case "Student": return 5;
                default: return 6;
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
