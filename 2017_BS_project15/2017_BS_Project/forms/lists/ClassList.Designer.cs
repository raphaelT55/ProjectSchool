namespace _2017_BS_Project.forms.lists
{
    partial class ClassList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassList));
            this.CName = new System.Windows.Forms.Label();
            this.CMaxP = new System.Windows.Forms.Label();
            this.Cprojector = new System.Windows.Forms.CheckBox();
            this.CBoard = new System.Windows.Forms.CheckBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.CType = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.MaxP = new System.Windows.Forms.TextBox();
            this.add_new_btn = new System.Windows.Forms.Button();
            this.Update_btn = new System.Windows.Forms.Button();
            this.Delete_btn = new System.Windows.Forms.Button();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.IdNumber = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Name1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CName
            // 
            this.CName.AutoSize = true;
            this.CName.BackColor = System.Drawing.Color.Transparent;
            this.CName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CName.ForeColor = System.Drawing.Color.White;
            this.CName.Location = new System.Drawing.Point(10, 42);
            this.CName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.CName.Name = "CName";
            this.CName.Size = new System.Drawing.Size(35, 13);
            this.CName.TabIndex = 0;
            this.CName.Text = "Name";
            // 
            // CMaxP
            // 
            this.CMaxP.AutoSize = true;
            this.CMaxP.BackColor = System.Drawing.Color.Transparent;
            this.CMaxP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMaxP.ForeColor = System.Drawing.Color.White;
            this.CMaxP.Location = new System.Drawing.Point(7, 91);
            this.CMaxP.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.CMaxP.Name = "CMaxP";
            this.CMaxP.Size = new System.Drawing.Size(57, 13);
            this.CMaxP.TabIndex = 0;
            this.CMaxP.Text = "Max Place";
            // 
            // Cprojector
            // 
            this.Cprojector.AutoSize = true;
            this.Cprojector.BackColor = System.Drawing.Color.Transparent;
            this.Cprojector.Enabled = false;
            this.Cprojector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cprojector.ForeColor = System.Drawing.Color.White;
            this.Cprojector.Location = new System.Drawing.Point(10, 260);
            this.Cprojector.Margin = new System.Windows.Forms.Padding(1);
            this.Cprojector.Name = "Cprojector";
            this.Cprojector.Size = new System.Drawing.Size(68, 17);
            this.Cprojector.TabIndex = 4;
            this.Cprojector.Text = "Projector";
            this.Cprojector.UseVisualStyleBackColor = false;
            // 
            // CBoard
            // 
            this.CBoard.AutoSize = true;
            this.CBoard.BackColor = System.Drawing.Color.Transparent;
            this.CBoard.Enabled = false;
            this.CBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBoard.ForeColor = System.Drawing.Color.White;
            this.CBoard.Location = new System.Drawing.Point(100, 260);
            this.CBoard.Margin = new System.Windows.Forms.Padding(1);
            this.CBoard.Name = "CBoard";
            this.CBoard.Size = new System.Drawing.Size(54, 17);
            this.CBoard.TabIndex = 5;
            this.CBoard.Text = "Board";
            this.CBoard.UseVisualStyleBackColor = false;
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.GridColor = System.Drawing.Color.Silver;
            this.dataGridView.Location = new System.Drawing.Point(168, 10);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 40;
            this.dataGridView.Size = new System.Drawing.Size(587, 443);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_RowHeaderMouseClick);
            // 
            // CType
            // 
            this.CType.AutoSize = true;
            this.CType.BackColor = System.Drawing.Color.Transparent;
            this.CType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CType.ForeColor = System.Drawing.Color.White;
            this.CType.Location = new System.Drawing.Point(10, 139);
            this.CType.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.CType.Name = "CType";
            this.CType.Size = new System.Drawing.Size(31, 13);
            this.CType.TabIndex = 0;
            this.CType.Text = "Type";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(10, 56);
            this.name.Margin = new System.Windows.Forms.Padding(1);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(145, 20);
            this.name.TabIndex = 1;
            this.name.TextChanged += new System.EventHandler(this.Name_TextChanged);
            // 
            // MaxP
            // 
            this.MaxP.Enabled = false;
            this.MaxP.Location = new System.Drawing.Point(11, 105);
            this.MaxP.Margin = new System.Windows.Forms.Padding(1);
            this.MaxP.Name = "MaxP";
            this.MaxP.Size = new System.Drawing.Size(145, 20);
            this.MaxP.TabIndex = 2;
            this.MaxP.TextChanged += new System.EventHandler(this.MaxP_TextChanged);
            this.MaxP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MaxP_KeyPress);
            // 
            // add_new_btn
            // 
            this.add_new_btn.BackColor = System.Drawing.Color.Silver;
            this.add_new_btn.Enabled = false;
            this.add_new_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.add_new_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.add_new_btn.Location = new System.Drawing.Point(13, 366);
            this.add_new_btn.Margin = new System.Windows.Forms.Padding(1);
            this.add_new_btn.Name = "add_new_btn";
            this.add_new_btn.Size = new System.Drawing.Size(146, 27);
            this.add_new_btn.TabIndex = 6;
            this.add_new_btn.Text = "Add";
            this.add_new_btn.UseVisualStyleBackColor = false;
            this.add_new_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Update_btn
            // 
            this.Update_btn.BackColor = System.Drawing.Color.Silver;
            this.Update_btn.Enabled = false;
            this.Update_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Update_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Update_btn.Location = new System.Drawing.Point(13, 395);
            this.Update_btn.Margin = new System.Windows.Forms.Padding(1);
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.Size = new System.Drawing.Size(146, 27);
            this.Update_btn.TabIndex = 7;
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
            this.Delete_btn.Location = new System.Drawing.Point(13, 424);
            this.Delete_btn.Margin = new System.Windows.Forms.Padding(1);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(146, 27);
            this.Delete_btn.TabIndex = 8;
            this.Delete_btn.Text = "Delete";
            this.Delete_btn.UseVisualStyleBackColor = false;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeComboBox.Enabled = false;
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.TypeComboBox.Location = new System.Drawing.Point(10, 153);
            this.TypeComboBox.Margin = new System.Windows.Forms.Padding(1);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(146, 21);
            this.TypeComboBox.TabIndex = 3;
            this.TypeComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // IdNumber
            // 
            this.IdNumber.BackColor = System.Drawing.Color.Silver;
            this.IdNumber.Location = new System.Drawing.Point(10, 56);
            this.IdNumber.Margin = new System.Windows.Forms.Padding(1);
            this.IdNumber.Name = "IdNumber";
            this.IdNumber.ReadOnly = true;
            this.IdNumber.Size = new System.Drawing.Size(145, 20);
            this.IdNumber.TabIndex = 10;
            this.IdNumber.Visible = false;
            this.IdNumber.TextChanged += new System.EventHandler(this.IdNumber_TextChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Location = new System.Drawing.Point(10, 185);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(1);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(144, 62);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "0 - ClassRoom\n1 - Lab\n2 - Office";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(89, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 24);
            this.label3.TabIndex = 42;
            this.label3.Text = "Rooms";
            // 
            // Name1
            // 
            this.Name1.Location = new System.Drawing.Point(9, 56);
            this.Name1.Margin = new System.Windows.Forms.Padding(2);
            this.Name1.Name = "Name1";
            this.Name1.Size = new System.Drawing.Size(144, 20);
            this.Name1.TabIndex = 43;
            this.Name1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ClassList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::_2017_BS_Project.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(765, 463);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Name1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.IdNumber);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.add_new_btn);
            this.Controls.Add(this.MaxP);
            this.Controls.Add(this.name);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.CBoard);
            this.Controls.Add(this.Cprojector);
            this.Controls.Add(this.CType);
            this.Controls.Add(this.CMaxP);
            this.Controls.Add(this.CName);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClassList";
            this.Text = "ClassList";
            this.Load += new System.EventHandler(this.ClassList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CName;
        private System.Windows.Forms.Label CMaxP;
        private System.Windows.Forms.CheckBox Cprojector;
        private System.Windows.Forms.CheckBox CBoard;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label CType;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox MaxP;
        private System.Windows.Forms.Button add_new_btn;
        private System.Windows.Forms.Button Update_btn;
        private System.Windows.Forms.Button Delete_btn;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.TextBox IdNumber;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Name1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}