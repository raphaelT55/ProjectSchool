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
    public partial class ClassList : Form
    {
        int projector;
        int board;

        public ClassList()
        {
            InitializeComponent();
        }

        private int isProjector()
        {
            if (Cprojector.Checked)  return 1;
            return 0;
        }

        private int isBoard()
        {
            if (CBoard.Checked) return 1;
            return 0;
        }

        private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MaxP.Text = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            IdNumber.Text = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("1"))
            { Cprojector.Checked = true; }
            else
                Cprojector.Checked = false;

            if (dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString().Equals("1"))
            { CBoard.Checked = true; }
            else
                CBoard.Checked = false;

            if (dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString().Equals("0"))
                TypeComboBox.Text = "0";

            if (dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString().Equals("1"))
                TypeComboBox.Text = "1";

            if (dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString().Equals("2"))
                TypeComboBox.Text = "2";
            name.Text = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            Name1.Text = name.Text;
            //name.Text = "";
            name.Visible = false;
            Name1.Visible = true;
            Delete_btn.Enabled = true;
            Update_btn.Enabled = true;
            add_new_btn.Enabled = false;
            TypeComboBox.Enabled = true;
            MaxP.Enabled = true;
        }

        private void show()
        {
            DataTable dt = new DataTable();
            DBA db = DBA.Instance;
            db.connect();
            db.getConnection().Open();
            var select = "SELECT * FROM classes";
            var dataAdapter = new SqlDataAdapter(select, db.getConnection());
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(dt);
            DataView DV = new DataView(dt);
            DV.RowFilter = string.Format("name LIKE '%{0}%'", name.Text);
            dataGridView.DataSource = DV;
        }

        private void DataLoad()
        {
            try
            {
                Name1.Text = "";
                name.Text = "";
                IdNumber.Text = "";
                Name1.Visible = false;
                name.Visible = true;
                add_new_btn.Enabled = false;
                Update_btn.Enabled = false;
                Delete_btn.Enabled = false;
                TypeComboBox.Text="";
                TypeComboBox.Enabled = false;
                MaxP.Text = "";
                MaxP.Enabled = false;
                Cprojector.Checked = false;
                CBoard.Checked = false;
                Cprojector.Enabled = false;
                CBoard.Enabled = false;
                DBA db = DBA.Instance;
                db.connect();

                db.getConnection().Open();

                var select = "SELECT id,name,maxPlaces,type,projector, board FROM classes ORDER by id DESC";
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

        public void addClass(string name, string maxPLaces, string type, int projector, int board)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.query("INSERT INTO classes (name,maxPlaces,type,projector, board) VALUES ('" + name + "', '" + maxPLaces + "', '" + type + "', '" + projector + "', '" + board + "' )");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            projector = this.isProjector();
            board = this.isBoard();
            addClass(Name1.Text, MaxP.Text, TypeComboBox.Text, projector, board);
            DataLoad();
        }

        private void ClassList_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void Name_TextChanged(object sender, EventArgs e)
        {
            show();
            if (name.Text.Length != 0)
            {
                add_new_btn.Enabled = true;
                TypeComboBox.Enabled = true;
                MaxP.Enabled = true;
            }
            else
            {
                add_new_btn.Enabled = true;
                TypeComboBox.Text = "";
                TypeComboBox.Enabled = false;
                MaxP.Enabled = false;
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(TypeComboBox.Text.Equals("2")))
            {
                Cprojector.Enabled = true;
                CBoard.Enabled = true;
            }
            else
            {
                Cprojector.Checked = false;
                CBoard.Checked = false;
                Cprojector.Enabled = false;
                CBoard.Enabled = false;
            }
            }

        private void MaxP_TextChanged(object sender, EventArgs e)
        {
            //string s = TypeComboBox.Text;
           // MessageBox.Show(s);

            if ((name.Text.Length != 0) && (!TypeComboBox.Text.Equals("")))
            { add_new_btn.Enabled = true; }
            else
                add_new_btn.Enabled = true;
        }

        private void MaxP_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!Char.IsDigit(ch) && ch !=8)
            {
                e.Handled = true;
            }
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            projector = this.isProjector();
            board = this.isBoard();
            DBA db = DBA.Instance;
            db.connect();
            db.query("UPDATE classes SET [name]='" + Name1.Text + "', [board]='" + board + "', [maxPlaces]='" + MaxP.Text + "', [type]='" + TypeComboBox.Text + "',[projector]='" + projector + "' WHERE id =" + IdNumber.Text);
            DataLoad();
        }

        public void deleteClass(string ID)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.query("DELETE classes where id = " + ID + " ");
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            deleteClass(IdNumber.Text);
            DataLoad();
        }

        private void IdNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
