namespace _2017_BS_Project.forms.lists
{
    partial class StudentList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        { 
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentList));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.fname = new System.Windows.Forms.TextBox();
            this.lname = new System.Windows.Forms.TextBox();
            this.IdNumber = new System.Windows.Forms.TextBox();
            this.Delete_btn = new System.Windows.Forms.Button();
            this.Update_btn = new System.Windows.Forms.Button();
            this.add_new_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.id = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.courses_list = new System.Windows.Forms.CheckedListBox();
            this.save_courses = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(4, 166);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(4, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Last name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "First name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Id Number";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(4, 238);
            this.password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(148, 20);
            this.password.TabIndex = 25;
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(7, 184);
            this.email.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(145, 20);
            this.email.TabIndex = 24;
            this.email.TextChanged += new System.EventHandler(this.email_TextChanged);
            // 
            // fname
            // 
            this.fname.Location = new System.Drawing.Point(7, 77);
            this.fname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fname.Name = "fname";
            this.fname.Size = new System.Drawing.Size(145, 20);
            this.fname.TabIndex = 23;
            this.fname.TextChanged += new System.EventHandler(this.fname_TextChanged);
            // 
            // lname
            // 
            this.lname.Location = new System.Drawing.Point(7, 130);
            this.lname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(145, 20);
            this.lname.TabIndex = 22;
            this.lname.TextChanged += new System.EventHandler(this.lname_TextChanged);
            // 
            // IdNumber
            // 
            this.IdNumber.Location = new System.Drawing.Point(7, 21);
            this.IdNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.IdNumber.Name = "IdNumber";
            this.IdNumber.Size = new System.Drawing.Size(145, 20);
            this.IdNumber.TabIndex = 21;
            this.IdNumber.TextChanged += new System.EventHandler(this.IdNumber_TextChanged);
            this.IdNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdNumber_KeyPress);
            // 
            // Delete_btn
            // 
            this.Delete_btn.BackColor = System.Drawing.Color.DarkGray;
            this.Delete_btn.Enabled = false;
            this.Delete_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Delete_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Delete_btn.Location = new System.Drawing.Point(8, 375);
            this.Delete_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(146, 27);
            this.Delete_btn.TabIndex = 33;
            this.Delete_btn.Text = "Delete";
            this.Delete_btn.UseVisualStyleBackColor = false;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // Update_btn
            // 
            this.Update_btn.BackColor = System.Drawing.Color.DarkGray;
            this.Update_btn.Enabled = false;
            this.Update_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Update_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Update_btn.Location = new System.Drawing.Point(8, 347);
            this.Update_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.Size = new System.Drawing.Size(146, 27);
            this.Update_btn.TabIndex = 32;
            this.Update_btn.Text = "Update";
            this.Update_btn.UseVisualStyleBackColor = false;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // add_new_btn
            // 
            this.add_new_btn.BackColor = System.Drawing.Color.DarkGray;
            this.add_new_btn.Enabled = false;
            this.add_new_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.add_new_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.add_new_btn.Location = new System.Drawing.Point(8, 319);
            this.add_new_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.add_new_btn.Name = "add_new_btn";
            this.add_new_btn.Size = new System.Drawing.Size(146, 27);
            this.add_new_btn.TabIndex = 31;
            this.add_new_btn.Text = "Add";
            this.add_new_btn.UseVisualStyleBackColor = false;
            this.add_new_btn.Click += new System.EventHandler(this.add_new_btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(172, 14);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(580, 442);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(1, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(81, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 24);
            this.label7.TabIndex = 50;
            this.label7.Text = "Students";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(165, 429);
            this.tabControl1.TabIndex = 51;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.id);
            this.tabPage1.Controls.Add(this.IdNumber);
            this.tabPage1.Controls.Add(this.lname);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.fname);
            this.tabPage1.Controls.Add(this.email);
            this.tabPage1.Controls.Add(this.Delete_btn);
            this.tabPage1.Controls.Add(this.password);
            this.tabPage1.Controls.Add(this.Update_btn);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.add_new_btn);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(157, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "User Info";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(4, 266);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(148, 20);
            this.id.TabIndex = 52;
            this.id.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.courses_list);
            this.tabPage2.Controls.Add(this.save_courses);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(157, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "User Courses";
            // 
            // courses_list
            // 
            this.courses_list.Enabled = false;
            this.courses_list.FormattingEnabled = true;
            this.courses_list.Location = new System.Drawing.Point(6, 36);
            this.courses_list.Name = "courses_list";
            this.courses_list.Size = new System.Drawing.Size(145, 334);
            this.courses_list.TabIndex = 52;
            // 
            // save_courses
            // 
            this.save_courses.Enabled = false;
            this.save_courses.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.save_courses.Location = new System.Drawing.Point(6, 374);
            this.save_courses.Name = "save_courses";
            this.save_courses.Size = new System.Drawing.Size(145, 23);
            this.save_courses.TabIndex = 52;
            this.save_courses.Text = "Save";
            this.save_courses.UseVisualStyleBackColor = true;
            this.save_courses.Click += new System.EventHandler(this.save_courses_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "Courses";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // StudentList
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::_2017_BS_Project.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(765, 463);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StudentList";
            this.Load += new System.EventHandler(this.StudentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox fname;
        private System.Windows.Forms.TextBox lname;
        private System.Windows.Forms.TextBox IdNumber;
        private System.Windows.Forms.Button Delete_btn;
        private System.Windows.Forms.Button Update_btn;
        private System.Windows.Forms.Button add_new_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox courses_list;
        private System.Windows.Forms.Button save_courses;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}