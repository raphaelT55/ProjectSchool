namespace _2017_BS_Project.forms.lists
{
    partial class CourseList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CourseList));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.LName = new System.Windows.Forms.Label();
            this.Capicity = new System.Windows.Forms.Label();
            this.IdNumber = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.capacity = new System.Windows.Forms.TextBox();
            this.add_new_btn = new System.Windows.Forms.Button();
            this.Update_btn = new System.Windows.Forms.Button();
            this.Delete_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lecture = new System.Windows.Forms.CheckBox();
            this.practice = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lab = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lecHours = new System.Windows.Forms.ComboBox();
            this.pHours = new System.Windows.Forms.ComboBox();
            this.labHours = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.departmentBox = new System.Windows.Forms.ComboBox();
            this.description = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(169, 10);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 40;
            this.dataGridView.Size = new System.Drawing.Size(586, 442);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_RowHeaderMouseClick);
            // 
            // LName
            // 
            this.LName.AutoSize = true;
            this.LName.BackColor = System.Drawing.Color.Transparent;
            this.LName.ForeColor = System.Drawing.Color.White;
            this.LName.Location = new System.Drawing.Point(7, 38);
            this.LName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.LName.Name = "LName";
            this.LName.Size = new System.Drawing.Size(35, 13);
            this.LName.TabIndex = 1;
            this.LName.Text = "Name";
            // 
            // Capicity
            // 
            this.Capicity.AutoSize = true;
            this.Capicity.BackColor = System.Drawing.Color.Transparent;
            this.Capicity.ForeColor = System.Drawing.Color.White;
            this.Capicity.Location = new System.Drawing.Point(7, 82);
            this.Capicity.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Capicity.Name = "Capicity";
            this.Capicity.Size = new System.Drawing.Size(67, 13);
            this.Capicity.TabIndex = 1;
            this.Capicity.Text = "Max Capicity";
            // 
            // IdNumber
            // 
            this.IdNumber.BackColor = System.Drawing.Color.Silver;
            this.IdNumber.Location = new System.Drawing.Point(10, 52);
            this.IdNumber.Margin = new System.Windows.Forms.Padding(1);
            this.IdNumber.Name = "IdNumber";
            this.IdNumber.ReadOnly = true;
            this.IdNumber.Size = new System.Drawing.Size(145, 20);
            this.IdNumber.TabIndex = 2;
            this.IdNumber.Visible = false;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(12, 52);
            this.name.Margin = new System.Windows.Forms.Padding(1);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(145, 20);
            this.name.TabIndex = 2;
            // 
            // capacity
            // 
            this.capacity.Location = new System.Drawing.Point(12, 96);
            this.capacity.Margin = new System.Windows.Forms.Padding(1);
            this.capacity.Name = "capacity";
            this.capacity.Size = new System.Drawing.Size(145, 20);
            this.capacity.TabIndex = 2;
            // 
            // add_new_btn
            // 
            this.add_new_btn.BackColor = System.Drawing.Color.Silver;
            this.add_new_btn.Enabled = false;
            this.add_new_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.add_new_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.add_new_btn.Location = new System.Drawing.Point(8, 365);
            this.add_new_btn.Margin = new System.Windows.Forms.Padding(1);
            this.add_new_btn.Name = "add_new_btn";
            this.add_new_btn.Size = new System.Drawing.Size(146, 27);
            this.add_new_btn.TabIndex = 3;
            this.add_new_btn.Text = "Add";
            this.add_new_btn.UseVisualStyleBackColor = false;
            this.add_new_btn.Click += new System.EventHandler(this.Add_Click);
            // 
            // Update_btn
            // 
            this.Update_btn.BackColor = System.Drawing.Color.Silver;
            this.Update_btn.Enabled = false;
            this.Update_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Update_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Update_btn.Location = new System.Drawing.Point(8, 396);
            this.Update_btn.Margin = new System.Windows.Forms.Padding(1);
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.Size = new System.Drawing.Size(146, 27);
            this.Update_btn.TabIndex = 3;
            this.Update_btn.Text = "Update";
            this.Update_btn.UseVisualStyleBackColor = false;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // Delete_btn
            // 
            this.Delete_btn.BackColor = System.Drawing.Color.Silver;
            this.Delete_btn.Enabled = false;
            this.Delete_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Delete_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Delete_btn.Location = new System.Drawing.Point(8, 425);
            this.Delete_btn.Margin = new System.Windows.Forms.Padding(1);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(146, 27);
            this.Delete_btn.TabIndex = 3;
            this.Delete_btn.Text = "Delete";
            this.Delete_btn.UseVisualStyleBackColor = false;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(7, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Lecture hours";
            // 
            // lecture
            // 
            this.lecture.AutoSize = true;
            this.lecture.BackColor = System.Drawing.Color.Transparent;
            this.lecture.ForeColor = System.Drawing.Color.White;
            this.lecture.Location = new System.Drawing.Point(10, 169);
            this.lecture.Name = "lecture";
            this.lecture.Size = new System.Drawing.Size(62, 17);
            this.lecture.TabIndex = 8;
            this.lecture.Text = "Lecture";
            this.lecture.UseVisualStyleBackColor = false;
            this.lecture.CheckedChanged += new System.EventHandler(this.lecture_CheckedChanged);
            // 
            // practice
            // 
            this.practice.AutoSize = true;
            this.practice.BackColor = System.Drawing.Color.Transparent;
            this.practice.ForeColor = System.Drawing.Color.White;
            this.practice.Location = new System.Drawing.Point(8, 205);
            this.practice.Name = "practice";
            this.practice.Size = new System.Drawing.Size(65, 17);
            this.practice.TabIndex = 11;
            this.practice.Text = "Practice";
            this.practice.UseVisualStyleBackColor = false;
            this.practice.CheckedChanged += new System.EventHandler(this.practice_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Practice hours";
            // 
            // lab
            // 
            this.lab.AutoSize = true;
            this.lab.BackColor = System.Drawing.Color.Transparent;
            this.lab.ForeColor = System.Drawing.Color.White;
            this.lab.Location = new System.Drawing.Point(8, 241);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(44, 17);
            this.lab.TabIndex = 14;
            this.lab.Text = "Lab";
            this.lab.UseVisualStyleBackColor = false;
            this.lab.CheckedChanged += new System.EventHandler(this.lab_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Lab hours";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(78, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 24);
            this.label3.TabIndex = 16;
            this.label3.Text = "Courses";
            // 
            // lecHours
            // 
            this.lecHours.Enabled = false;
            this.lecHours.FormattingEnabled = true;
            this.lecHours.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5"});
            this.lecHours.Location = new System.Drawing.Point(88, 186);
            this.lecHours.Name = "lecHours";
            this.lecHours.Size = new System.Drawing.Size(69, 21);
            this.lecHours.TabIndex = 17;
            // 
            // pHours
            // 
            this.pHours.Enabled = false;
            this.pHours.FormattingEnabled = true;
            this.pHours.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.pHours.Location = new System.Drawing.Point(87, 222);
            this.pHours.Name = "pHours";
            this.pHours.Size = new System.Drawing.Size(69, 21);
            this.pHours.TabIndex = 18;
            // 
            // labHours
            // 
            this.labHours.Enabled = false;
            this.labHours.FormattingEnabled = true;
            this.labHours.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.labHours.Location = new System.Drawing.Point(87, 258);
            this.labHours.Name = "labHours";
            this.labHours.Size = new System.Drawing.Size(69, 21);
            this.labHours.TabIndex = 19;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 126);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Department";
            // 
            // departmentBox
            // 
            this.departmentBox.FormattingEnabled = true;
            this.departmentBox.Location = new System.Drawing.Point(10, 142);
            this.departmentBox.Name = "departmentBox";
            this.departmentBox.Size = new System.Drawing.Size(147, 21);
            this.departmentBox.TabIndex = 56;
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(8, 301);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(147, 60);
            this.description.TabIndex = 57;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(7, 285);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 58;
            this.label6.Text = "Description";
            // 
            // CourseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::_2017_BS_Project.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(765, 463);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.description);
            this.Controls.Add(this.departmentBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labHours);
            this.Controls.Add(this.pHours);
            this.Controls.Add(this.lecHours);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lab);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.practice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lecture);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.add_new_btn);
            this.Controls.Add(this.capacity);
            this.Controls.Add(this.name);
            this.Controls.Add(this.IdNumber);
            this.Controls.Add(this.Capicity);
            this.Controls.Add(this.LName);
            this.Controls.Add(this.dataGridView);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CourseList";
            this.Text = "CourseList";
            this.Load += new System.EventHandler(this.CourseList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label LName;
        private System.Windows.Forms.Label Capicity;
        private System.Windows.Forms.TextBox IdNumber;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox capacity;
        private System.Windows.Forms.Button add_new_btn;
        private System.Windows.Forms.Button Update_btn;
        private System.Windows.Forms.Button Delete_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox lecture;
        private System.Windows.Forms.CheckBox practice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox lab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox lecHours;
        private System.Windows.Forms.ComboBox pHours;
        private System.Windows.Forms.ComboBox labHours;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox departmentBox;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Label label6;
    }
}