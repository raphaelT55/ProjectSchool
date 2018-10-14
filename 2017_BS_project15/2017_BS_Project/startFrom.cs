using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using _2017_BS_Project.forms.studentForms;
using _2017_BS_Project.tools;
using _2017_BS_Project.forms;
using System.Threading;
using _2017_BS_Project.forms.fb;
using Facebook;
using System.Net.Mail;

namespace _2017_BS_Project
{
    public partial class startFrom : Form
    {

        // DBA singelton implementation
        private static startFrom instance;
        private startFrom() {
            InitializeComponent(); }

        public static startFrom Instance
        {
            get
            {
                if (instance == null)
                { instance = new startFrom(); }
                return instance;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            await Task.Delay(2000);

            bool res = GlobalItems.Login(textBox1.Text, textBox2.Text);
            if (res)
            {

                this.Hide();
                textBox1.Text = "";
                textBox2.Text = "";

                if (GlobalItems.CheckUserLevel() == 1)
                {
                    ManagerWin wnd = new ManagerWin();
                    wnd.Show();
                }
                else if (GlobalItems.CheckUserLevel() == 2)
                {
                    MazkiraWin wnd = new MazkiraWin();
                    wnd.Show();
                }
                else if (GlobalItems.CheckUserLevel() == 3)
                {
                    TeacherWin wnd = new TeacherWin();
                    wnd.Show();
                }
                else if (GlobalItems.CheckUserLevel() == 4)
                {
                    TeacherWin wnd = new TeacherWin();
                    wnd.Show();
                }

                else if (GlobalItems.CheckUserLevel() == 5)
                {
                    StudentWin wnd = new StudentWin();
                    wnd.Show();
                }

                else
                {
                    MessageBox.Show("Your account is not approved by secretary");
                }

            }
            else
            {
                MessageBox.Show("This user is not exist", "Login Error",
    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            pictureBox2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            GlobalItems.slideLeftSize(this, 350);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void startFrom_Load(object sender, EventArgs e)
        {
            GlobalItems.FadeIn(this, 25);       
        }

        private void register_Click(object sender, EventArgs e)
        {
            GlobalItems.slideRightSize(this, 700);
        }

        private void reg_cancel_Click(object sender, EventArgs e)
        {
            GlobalItems.slideLeftSize(this, 350);
            reg_fname.Text = "";
            reg_lname.Text = "";
            reg_email.Text = "";
            reg_password.Text = "";
            reg_id.Text = "";
        }

        private void reg_send_Click(object sender, EventArgs e)
        {
            DBA db = DBA.Instance;
            db.connect();

            if (reg_id.Text != "" && reg_fname.Text != "" && reg_lname.Text != "" && reg_email.Text != "" && reg_password.Text != "")
            {

                if (GlobalItems.checkIdNumber(reg_id.Text))
                {
                    db.query("INSERT INTO users (fname, lname, email, password, idNUmber, type) VALUES ('" + reg_fname.Text + "', '" + reg_lname.Text + "', '" + reg_email.Text + "', '" + reg_password.Text + "', '" + reg_id.Text + "', 6)");

                    MessageBox.Show("Data is Saved, Please type your id number and password to login into system");

                    GlobalItems.slideLeftSize(this, 350);
                }
                else
                    MessageBox.Show("User with this id number is already exist in system, please type another id");
            }
            else
            {
                MessageBox.Show("All fields have to be filled");
            }
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form4 o = new Form4();
            o.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            GlobalItems.slideDownSize(this, 550);
        }

        private void fbBox_Click(object sender, EventArgs e)
        {
            this.Hide();
            FacebookStart();
        }


        private void FacebookStart()
        {
            // open the Facebook Login Dialog and ask for user permissions.
            var fbLoginDlg = new FacebookLoginDialog("1883803658504479", "public_profile,publish_actions");
            fbLoginDlg.ShowDialog();

            // The user has taken action, either allowed/denied or cancelled the authorization,
            // which can be known by looking at the dialogs FacebookOAuthResult property.
            // Depending on the result take appropriate actions.
            TakeLoggedInAction(fbLoginDlg.FacebookOAuthResult);

        }


        private void TakeLoggedInAction(FacebookOAuthResult facebookOAuthResult)
        {
            if (facebookOAuthResult == null)
            {
                // the user closed the FacebookLoginDialog, so do nothing.
                MessageBox.Show("Cancelled!");
                return;
            }

            // Even though facebookOAuthResult is not null, it could had been an 
            // OAuth 2.0 error, so make sure to check IsSuccess property always.
            if (facebookOAuthResult.IsSuccess)
            {
                // since our respone_type in FacebookLoginDialog was token,
                // we got the access_token
                // The user now has successfully granted permission to our app.
                var dlg = new InfoDialog(facebookOAuthResult.AccessToken);
                dlg.ShowDialog();
            }
            else
            {
                // for some reason we failed to get the access token.
                // most likely the user clicked don't allow.
                MessageBox.Show(facebookOAuthResult.ErrorDescription);
            }
        }

        // password recovery
        private void recoveryCancel_Click(object sender, EventArgs e)
        {
            GlobalItems.slideUpSize(this, 390);
        }

        private void recoverySend_Click(object sender, EventArgs e)
        {
            string email = recoveryEmail.Text;
            if (GlobalItems.checkUserEmail(email))
            {
                GlobalItems.sendEmail(email);
                MessageBox.Show("Your new password has been send to your email");
            }
            else
                MessageBox.Show("This email is not register in the system, Please enter correct email");

        }

        

    }
}
