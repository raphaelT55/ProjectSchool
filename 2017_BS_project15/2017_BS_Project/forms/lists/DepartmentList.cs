using _2017_BS_Project.tools;
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
    public partial class DepartmentList : Form
    {
        //int ID = 0;

        public DepartmentList()
        {
            InitializeComponent();
            DataLoad();
        }


        private void DataLoad()
        {
            try
            {
                name.Text = "";
                IdNum.Text = "";
                DBA db = DBA.Instance;
                db.connect();

                db.getConnection().Open();

                var select = "SELECT * FROM departments ORDER by id DESC";
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IdNum.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            name.Visible = false;
            name1.Visible = true;
            name1.Text = name.Text;
            Update_btn.Enabled = true;
            Delete_btn.Enabled = true;

        }

        private void show()
        {
            DataTable dt=new DataTable();
            DBA db = DBA.Instance;
            db.connect();
            db.getConnection().Open();
            var select = "SELECT * FROM departments";
            var dataAdapter = new SqlDataAdapter(select, db.getConnection());
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(dt);
            DataView DV = new DataView(dt);
            DV.RowFilter=string.Format("name LIKE '%{0}%'", name.Text);
            dataGridView1.DataSource = DV;
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            show();
            if ((name.Text.Length != 0))
            {
                //IdNum.Text = "";
                add_new_btn.Enabled = true;
                /*for (int i = 0; i < dataGridView1.RowCount-1; i++)
                {
                    if ((name.Text.ToLower()) == dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower())
                    {
                        //IdNum.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        name.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        //Update_btn.Enabled = true;
                        //Delete_btn.Enabled = true;
                        break;
                    }
                    else
                    {
                        IdNum.Text = "";                                              
                    }
                }*/
            }
            else { add_new_btn.Enabled = false;
                Update_btn.Enabled = false; 
                Delete_btn.Enabled = false; }

        }

        private void add_new_btn_Click_1(object sender, EventArgs e)
        {
            addDepartment(name.Text);
            DataLoad();
        }

        public void addDepartment(string name)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.query("INSERT INTO departments (name) VALUES ('" + name + "')");
           
        }

        private void Delete_btn_Click_1(object sender, EventArgs e)
        {
            delete_department(IdNum.Text);
            DataLoad();
            name1.Visible = false;
            name.Visible = true;
        }

        public void delete_department(string id)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.query("DELETE departments where id=" + id + "");
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.query("UPDATE departments SET[name] = '"+name1.Text+"' WHERE id = "+IdNum.Text+"");
            DataLoad();
            name1.Visible = false;
            name.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
