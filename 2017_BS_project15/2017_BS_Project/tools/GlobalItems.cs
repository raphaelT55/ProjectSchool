using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

using _2017_BS_Project.users;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Net;

namespace _2017_BS_Project.tools
{
    public static class GlobalItems
    {
        public static Users currentUser;


        

    public static void GetAllControl(Control c, List<Control> list)
    {
        foreach (Control control in c.Controls)
        {
            list.Add(control);

            if (control.GetType() == typeof(Panel))
                GetAllControl(control, list);
        }
    }

    public static void sendEmail(string Email)
        {

            try
            {
                DBA db = DBA.Instance;
                db.connect();
                var con = db.getConnection();
                con.Open();

                string query = "SELECT  password FROM users WHERE email = '" + Email + "' ";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            string pId = r.GetString(0);
                            MailMessage msg = new MailMessage("mazkirator@gmail.com", Email, "Password Recover", "Your password is " + pId);
                            msg.IsBodyHtml = true;
                            SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                            sc.UseDefaultCredentials = false;
                            NetworkCredential cre = new System.Net.NetworkCredential("mazkirator@gmail.com", "admin159");
                            sc.Credentials = cre;
                            sc.EnableSsl = true;
                            sc.Send(msg);
                        }
                       
                    }
                }
            }

            catch (SqlException ex)
            {
                Console.Out.WriteLine(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        public static bool Login(string idNumber, string pass)
        {
            try
            {
                DBA db = DBA.Instance;
                db.connect();

                db.getConnection().Open();
                
                using (var command = new SqlCommand("SELECT * FROM users WHERE idNUmber = '"+ idNumber + "' AND password = '"+ pass + "'", db.getConnection()))
                {
                    using (var r = command.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            currentUser = new Users(r.GetInt32(0), r.GetString(1), r.GetString(2), r.GetString(3), r.GetString(4), r.GetString(5), r.GetInt32(6));
                            return true;
                        }
                        else { return false; }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public static int CheckUserLevel()
        {
            if (currentUser != null)
                return GlobalItems.currentUser.type;
            return -1;
            
        }

        public static bool checkIdNumber(String IdNumber)
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


        public static int countItems(int type)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.getConnection().Open();
            string stm = "SELECT COUNT(*) FROM users WHERE type='" + type + "'";
            SqlCommand cmd = new SqlCommand(stm, db.getConnection());
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            db.getConnection().Close();
            return count;
        }


        public static bool checkItemsInDB(string table, string key, string item)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.getConnection().Open();
            string stm = "SELECT COUNT(*) FROM "+ table + " WHERE "+ key + "='" + item + "'";
            SqlCommand cmd = new SqlCommand(stm, db.getConnection());
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            db.getConnection().Close();
            if (count > 0) return true;
            else return false;
        }

        public static int getKey(string table, string key, string val)
        {
            try
            {
                DBA db = DBA.Instance;
                db.connect();
                var con = db.getConnection();
                con.Open();

                string query = "SELECT  id FROM "+ table + " WHERE "+key+" = '"+ val+ "' ";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read()) { int cID = r.GetInt32(0);
                            return cID;
                        }
                        return -1;
                    }
                }
            }

            catch (SqlException ex)
            {
                Console.Out.WriteLine(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }


        public static string getIdNumber(string table, string key, string val)
        {
            try
            {
                DBA db = DBA.Instance;
                db.connect();
                var con = db.getConnection();
                con.Open();

                string query = "SELECT  IdNUmber FROM " + table + " WHERE " + key + " = '" + val + "' ";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            string cID = r.GetString(0);
                            return cID;
                        }
                        return null;
                    }
                }
            }

            catch (SqlException ex)
            {
                Console.Out.WriteLine(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static bool checkUserEmail(string email)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.getConnection().Open();
            string stm = "SELECT COUNT(*) FROM users WHERE email='" + email + "'";
            SqlCommand cmd = new SqlCommand(stm, db.getConnection());
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            db.getConnection().Close();
            if (count > 0) return true;
            return false;
        }

        public static void Exit()
        {
            startFrom.Instance.Show();
            GlobalItems.currentUser = null;
        }

        public static int strToInt(string s)
        {
            int x = 0;
            Int32.TryParse(s, out x);
            return x;
        }

        public static async void slideDown(Panel o, int to, int interval = 10)
        {
            while (o.Location.Y < to)
            {
                await Task.Delay(interval);
                o.Location = new Point(o.Location.X, o.Location.Y + 10);
            }      
        }


        public static async void slideUp(Panel o, int to, int interval = 10)
        {
            while (o.Location.Y > to)
            {
                await Task.Delay(interval);
                o.Location = new Point(o.Location.X, o.Location.Y - 20);
            }
        }

        public static async void slideLeft(Panel o, int to, int interval = 10)
        {
            while (o.Location.X > to)
            {
                await Task.Delay(interval);
                o.Location = new Point(o.Location.X-20, o.Location.Y);
            }
        }

        public static async void slideRight(Panel o, int to, int interval = 10)
        {
            while (o.Location.X < to)
            {
                await Task.Delay(interval);
                o.Location = new Point(o.Location.X + 20, o.Location.Y);
            }
        }

        public static async void slideRightSize(Form o, int to, int interval = 5)
        {
            while (o.Size.Width < to)
            {
                await Task.Delay(interval);
                o.Size = new Size(o.Size.Width + 10, o.Size.Height);
            }
        }

        public static async void slideLeftSize(Form o, int to, int interval = 5)
        {
            while (o.Size.Width > to)
            {
                await Task.Delay(interval);
                o.Size = new Size(o.Size.Width - 10, o.Size.Height);
            }
        }


        public static async void slideDownSize(Form o, int to, int interval = 5)
        {
            while (o.Size.Height < to)
            {
                await Task.Delay(interval);
                o.Size = new Size(o.Size.Width, o.Size.Height + 10);
            }
        }

        public static async void slideUpSize(Form o, int to, int interval = 5)
        {
            while (o.Size.Height > to)
            {
                await Task.Delay(interval);
                o.Size = new Size(o.Size.Width, o.Size.Height - 10);
            }
        }


        public static async void FadeIn(Form o, int interval = 40)
        {
            //Object is not fully invisible. Fade it in
            while (o.Opacity < 1.0)
            {
                await Task.Delay(interval);
                o.Opacity += 0.05;
            }
            o.Opacity = 1; //make fully visible       
        }

        public static async void FadeOut(Form o, int interval = 40)
        {
            //Object is fully visible. Fade it out
            while (o.Opacity > 0.0)
            {
                await Task.Delay(interval);
                o.Opacity -= 0.05;
            }
            o.Opacity = 0; //make fully invisible       
        }


    }
}
