using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook;
using System.Dynamic;
using System.IO;
using _2017_BS_Project.tools;
using _2017_BS_Project.forms.lists;

namespace _2017_BS_Project.forms.fb
{

    public partial class InfoDialog : Form
    {
        private readonly TaskScheduler _ui;
        private readonly string _accessToken;

        public InfoDialog(string accessToken)
        {
            _accessToken = accessToken;
            _ui = TaskScheduler.FromCurrentSynchronizationContext();
            InitializeComponent();
        }

        public void fbLogOut()
        {
            var fb = new FacebookClient();

            var logoutUrl = fb.GetLogoutUrl(new
            {
                next = "https://www.facebook.com/connect/login_success.html",
                access_token = _accessToken
            });

            var webBrowser = new WebBrowser();
            webBrowser.Navigated += (o, args) =>
            {
                if (args.Url.AbsoluteUri == "https://www.facebook.com/connect/login_success.html")
                    Close();
            };
            webBrowser.Navigate(logoutUrl.AbsoluteUri);

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            fbLogOut();  
        }

        private void InfoDialog_Load(object sender, EventArgs e)
        {
           GraphApiExample();
        }

       
        private void GraphApiExample()
        {
            // note: avoid using synchronous methods if possible as it will block the thread until the result is received

            try
            {
                var fb = new FacebookClient(_accessToken);

                // instead of casting to IDictionary<string,object> or IList<object>
                // you can also make use of the dynamic keyword.
                dynamic result = fb.Get("me?fields=first_name,last_name,id,name");

                // You can either access it this way, using the .
                dynamic id = result.id;
                dynamic name = result.name;

                dynamic first_name = result.first_name;
                dynamic last_name = result.last_name;

                // if dynamic you don't need to cast explicitly.
                lblUserId.Text = "User Id: " + id;
                lnkName.Text = "Hi " + name;

                lblFirstName.Text = "First Name " + first_name;
                lblLastName.Text = "Last Name " + last_name;

               
                string iden = GlobalItems.getIdNumber("users", "fname", first_name);
                if (iden != id)
                {
                    Unproved obj = new Unproved();
                    obj.addUser(first_name, last_name, "", "", id,  6);
                }
                else
                {

                    this.Close();


                    GlobalItems.Login(id, "");
                    switch (GlobalItems.CheckUserLevel())
                    {
                        case 3:
                        case 4:
                            TeacherWin wnd = new TeacherWin(_accessToken);
                            wnd.Show(startFrom.Instance);
                            wnd.Select();
                            wnd.Focus();
                            break;

                        case 5:
                        case 6:
                            StudentWin wnd2 = new StudentWin(_accessToken);
                            wnd2.Show(startFrom.Instance);
                            wnd2.Select();
                            wnd2.Focus();
                       break;
                    }
                }
            }
            catch (FacebookApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InfoDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            startFrom.Instance.Show();
            GlobalItems.currentUser = null;
        }
    }
}
