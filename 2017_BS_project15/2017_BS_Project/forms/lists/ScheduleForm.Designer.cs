namespace _2017_BS_Project.forms.lists
{
    partial class ScheduleForm
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
            this.userPrefers = new System.Windows.Forms.WebBrowser();
            this.scheduleView = new System.Windows.Forms.WebBrowser();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.coursesChoose = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dayChoose = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.startChoose = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.endChoose = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rooms = new System.Windows.Forms.ComboBox();
            this.setEvent = new System.Windows.Forms.Button();
            this.Preview = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.generate_one = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Remove = new System.Windows.Forms.Button();
            this.preloader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // userPrefers
            // 
            this.userPrefers.Location = new System.Drawing.Point(408, 39);
            this.userPrefers.MinimumSize = new System.Drawing.Size(20, 20);
            this.userPrefers.Name = "userPrefers";
            this.userPrefers.Size = new System.Drawing.Size(772, 251);
            this.userPrefers.TabIndex = 0;
            // 
            // scheduleView
            // 
            this.scheduleView.Location = new System.Drawing.Point(408, 332);
            this.scheduleView.MinimumSize = new System.Drawing.Size(20, 20);
            this.scheduleView.Name = "scheduleView";
            this.scheduleView.Size = new System.Drawing.Size(772, 355);
            this.scheduleView.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(381, 251);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(404, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "User Prefers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Choose user";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(404, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "User Schedule";
            // 
            // coursesChoose
            // 
            this.coursesChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coursesChoose.FormattingEnabled = true;
            this.coursesChoose.Location = new System.Drawing.Point(24, 332);
            this.coursesChoose.Name = "coursesChoose";
            this.coursesChoose.Size = new System.Drawing.Size(381, 24);
            this.coursesChoose.TabIndex = 6;
            this.coursesChoose.SelectedIndexChanged += new System.EventHandler(this.coursesChoose_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(20, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Schedule Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(21, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Choose course";
            // 
            // dayChoose
            // 
            this.dayChoose.FormattingEnabled = true;
            this.dayChoose.Items.AddRange(new object[] {
            "Sun",
            "Mon",
            "Tue",
            "Wed",
            "Thu",
            "Fri"});
            this.dayChoose.Location = new System.Drawing.Point(24, 375);
            this.dayChoose.Name = "dayChoose";
            this.dayChoose.Size = new System.Drawing.Size(109, 21);
            this.dayChoose.TabIndex = 9;
            this.dayChoose.SelectedIndexChanged += new System.EventHandler(this.dayChoose_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(21, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Day";
            // 
            // startChoose
            // 
            this.startChoose.Enabled = false;
            this.startChoose.FormattingEnabled = true;
            this.startChoose.Items.AddRange(new object[] {
            "8:00",
            "9:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00"});
            this.startChoose.Location = new System.Drawing.Point(159, 375);
            this.startChoose.Name = "startChoose";
            this.startChoose.Size = new System.Drawing.Size(109, 21);
            this.startChoose.TabIndex = 11;
            this.startChoose.SelectedIndexChanged += new System.EventHandler(this.startChoose_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(156, 359);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Start hour";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(293, 359);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "End hour";
            // 
            // endChoose
            // 
            this.endChoose.Enabled = false;
            this.endChoose.FormattingEnabled = true;
            this.endChoose.Items.AddRange(new object[] {
            "9:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "21:00",
            "22:00"});
            this.endChoose.Location = new System.Drawing.Point(296, 375);
            this.endChoose.Name = "endChoose";
            this.endChoose.Size = new System.Drawing.Size(109, 21);
            this.endChoose.TabIndex = 13;
            this.endChoose.SelectedIndexChanged += new System.EventHandler(this.endChoose_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(21, 407);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Avaliable Rooms";
            // 
            // rooms
            // 
            this.rooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rooms.FormattingEnabled = true;
            this.rooms.Location = new System.Drawing.Point(24, 426);
            this.rooms.Name = "rooms";
            this.rooms.Size = new System.Drawing.Size(381, 24);
            this.rooms.TabIndex = 16;
            // 
            // setEvent
            // 
            this.setEvent.Location = new System.Drawing.Point(24, 468);
            this.setEvent.Name = "setEvent";
            this.setEvent.Size = new System.Drawing.Size(98, 23);
            this.setEvent.TabIndex = 17;
            this.setEvent.Text = "Set Event";
            this.setEvent.UseVisualStyleBackColor = true;
            this.setEvent.Click += new System.EventHandler(this.setEvent_Click);
            // 
            // Preview
            // 
            this.Preview.Location = new System.Drawing.Point(235, 468);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(170, 23);
            this.Preview.TabIndex = 18;
            this.Preview.Text = "Preview";
            this.Preview.UseVisualStyleBackColor = true;
            this.Preview.Click += new System.EventHandler(this.Preview_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(24, 498);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(381, 23);
            this.Save.TabIndex = 19;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // generate_one
            // 
            this.generate_one.BackColor = System.Drawing.Color.Tomato;
            this.generate_one.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generate_one.Location = new System.Drawing.Point(21, 565);
            this.generate_one.Name = "generate_one";
            this.generate_one.Size = new System.Drawing.Size(381, 58);
            this.generate_one.TabIndex = 20;
            this.generate_one.Text = "Generate for active user";
            this.generate_one.UseVisualStyleBackColor = false;
            this.generate_one.Click += new System.EventHandler(this.generate_one_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Coral;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(21, 629);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(381, 58);
            this.button1.TabIndex = 21;
            this.button1.Text = "Generate for all  users";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(128, 468);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(101, 23);
            this.Remove.TabIndex = 22;
            this.Remove.Text = "Remove";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // preloader
            // 
            this.preloader.AutoSize = true;
            this.preloader.BackColor = System.Drawing.Color.Transparent;
            this.preloader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preloader.ForeColor = System.Drawing.Color.White;
            this.preloader.Location = new System.Drawing.Point(21, 534);
            this.preloader.Name = "preloader";
            this.preloader.Size = new System.Drawing.Size(119, 20);
            this.preloader.TabIndex = 23;
            this.preloader.Text = "Please Wait...";
            this.preloader.Visible = false;
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_2017_BS_Project.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(1192, 699);
            this.Controls.Add(this.preloader);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.generate_one);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Preview);
            this.Controls.Add(this.setEvent);
            this.Controls.Add(this.rooms);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.endChoose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.startChoose);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dayChoose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.coursesChoose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.scheduleView);
            this.Controls.Add(this.userPrefers);
            this.Name = "ScheduleForm";
            this.Text = "ScheduleForm";
            this.Load += new System.EventHandler(this.ScheduleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser userPrefers;
        private System.Windows.Forms.WebBrowser scheduleView;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox coursesChoose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox dayChoose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox startChoose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox endChoose;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox rooms;
        private System.Windows.Forms.Button setEvent;
        private System.Windows.Forms.Button Preview;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button generate_one;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.Label preloader;
    }
}