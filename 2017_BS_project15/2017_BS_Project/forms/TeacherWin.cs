using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2017_BS_Project.tools;
using System.Data.SqlClient;
using _2017_BS_Project.users;
using _2017_BS_Project.forms.fb;

namespace _2017_BS_Project.forms
{
    public partial class TeacherWin : Form
    {

        /** TAB 1 SCHEDULE CODE *************************************************************/


        public void displaySchedule() {
            // disable all controls
            TabPage page = tabControl1.SelectedTab;
            var controls = page.Controls;
            foreach (var control in controls)
            {
                Panel obj = (Panel)control;
                foreach (var tb in obj.Controls.OfType<RichTextBox>())
                {
                    RichTextBox txt = (RichTextBox)tb;
                    Console.Out.WriteLine(txt.Name);
                    txt.Enabled = false;
                }
            }

            ScheduleLoad(GlobalItems.currentUser.id);

        }

        private void searchTextBox(List<RichTextBox> dayL, string txt) {
            int ind = 0;
            while(ind < dayL.Count)
            {
                if (dayL[ind].Enabled == false)
                {
                    dayL[ind].Text = txt;
                    dayL[ind].Enabled = true;
                    return;
                }
                ind++;
            }
        }

        private void putInSchedule(string day, string room, string course, int start, int end)
        {
            List<RichTextBox> SunL = new List<RichTextBox>();
            SunL.Add(sun1);
            SunL.Add(sun2);
            SunL.Add(sun4);
            SunL.Add(sun3);

            List<RichTextBox> MonL = new List<RichTextBox>();
            MonL.Add(mon1);
            MonL.Add(mon2);
            MonL.Add(mon3);
            MonL.Add(mon4);

            List<RichTextBox> TueL = new List<RichTextBox>();
            TueL.Add(tue1);
            TueL.Add(tue2);
            TueL.Add(tue3);
            TueL.Add(tue4);

            List<RichTextBox> WedL = new List<RichTextBox>();
            WedL.Add(wed1);
            WedL.Add(wed2);
            WedL.Add(wed3);
            WedL.Add(wed4);

            List<RichTextBox> ThuL = new List<RichTextBox>();
            ThuL.Add(thu1);
            ThuL.Add(thu2);
            ThuL.Add(thu3);
            ThuL.Add(thu4);

            List<RichTextBox> FriL = new List<RichTextBox>();
            FriL.Add(fri1);
            FriL.Add(fri2);
            FriL.Add(fri3);
            FriL.Add(fri4);


            switch (day)
            {
                case"Sun":
                    searchTextBox(SunL, "[" + start.ToString() + ":00 - " + end.ToString() + ":00] " + course + " " + room);
                    break;

                case "Mon":
                    searchTextBox(MonL, "[" + start.ToString() + ":00 - " + end.ToString() + ":00] " + course + " " + room);
                    break;

                case "Tue":
                    searchTextBox(TueL, "[" + start.ToString() + ":00 - " + end.ToString() + ":00] " + course + " " + room);
                    break;

                case "Wed":
                    searchTextBox(WedL, "[" + start.ToString() + ":00 - " + end.ToString() + ":00] " + course + " " + room);
                    break;

                case "Thu":
                    searchTextBox(ThuL, "[" + start.ToString() + ":00 - " + end.ToString() + ":00] " + course + " " + room);
                    break;

                case "Fri":
                    searchTextBox(FriL, "[" + start.ToString() + ":00 - " + end.ToString() + ":00] " + course + " " + room);
                    break;
            }
        }

        private void ScheduleLoad(int uID)
        {
            try
            {
                DBA db = DBA.Instance;
                db.connect();
                var con = db.getConnection();
                con.Open();

                string query = "SELECT  * FROM schedule WHERE user_id = " + uID + "ORDER BY startH ASC";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            int cID = r.GetInt32(2);
                            string day = r.GetString(4);
                            string title = r.GetString(3) + " " + r.GetString(8);
                            string start = r.GetInt32(5).ToString() + ":00";
                            string end = r.GetInt32(6).ToString() + ":00";

                            ScheduleEvent block = new ScheduleEvent(r.GetInt32(1), r.GetInt32(2), r.GetString(3), r.GetString(4), r.GetInt32(5), r.GetInt32(6), r.GetInt32(7), r.GetString(8));

                            putInSchedule(block.Day, block.Class_name, block.Course_name, block.Start, block.End);
                        }
                    }
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /** END SCHEDULE  **************************************************************/



        /**  TAB 2 CONSTRAINS CODE AND GLOBAL EVENTS ****************************************/

        public bool flagPrefers = false; // user don't have previous prefers
           
           // html patern of schedule table
           public string schedule_pattern = "<!DOCTYPE html><html><style>body{margin:0px;padding:0px}div{margin:0px;padding:0px;height:40px;display:block;vertical-align:middle;line-height:40px}.row{clear:both;width:100%}.col{float:left;width:14%;border:1px solid #eee}.dayRow{font-weight:bold;text-align:center}.bg{background:#9cf}.timeCol{width:50px;text-align:center;font-weight:bold}div.sc.col{position:relative}span{font-size:12px}.event{width:100%;position:relative;border:1px solid #9cf;overflow:hidden}.event span{display:block}span.title{font-weight:bold;font-size:14px}</style><body><div class='sc'><div class='row dayRow'><div class='col bg timeCol'></div><div class='col bg'>Sun</div><div class='col bg'>Mon</div><div class='col bg'>Tue</div><div class='col bg'>Wed</div><div class='col bg'>Thu</div><div class='col bg'>Fri</div></div><div class='row'><div class='col bg timeCol'>8:00</div><div class='col'><Sun8></div><div class='col'><Mon8></div><div class='col'><Tue8></div><div class='col'><Wed8></div><div class='col'><Thu8></div><div class='col'><Fri8></div></div><div class='row'><div class='col bg timeCol'>9:00</div><div class='col'><Sun9></div><div class='col'><Mon9></div><div class='col'><Tue9></div><div class='col'><Wed9></div><div class='col'><Thu9></div><div class='col'><Fri9></div></div><div class='row'><div class='col bg timeCol'>10:00</div><div class='col'><Sun10></div><div class='col'><Mon10></div><div class='col'><Tue10></div><div class='col'><Wed10></div><div class='col'><Thu10></div><div class='col'><Fri10></div></div><div class='row'><div class='col bg timeCol'>11:00</div><div class='col'><Sun11></div><div class='col'><Mon11></div><div class='col'><Tue11></div><div class='col'><Wed11></div><div class='col'><Thu11></div><div class='col'><Fri11></div></div><div class='row'><div class='col bg timeCol'>12:00</div><div class='col'><Sun12></div><div class='col'><Mon12></div><div class='col'><Tue12></div><div class='col'><Wed12></div><div class='col'><Thu12></div><div class='col'><Fri12></div></div><div class='row'><div class='col bg timeCol'>13:00</div><div class='col'><Sun13></div><div class='col'><Mon13></div><div class='col'><Tue13></div><div class='col'><Wed13></div><div class='col'><Thu13></div><div class='col'><Fri13></div></div><div class='row'><div class='col bg timeCol'>14:00</div><div class='col'><Sun14></div><div class='col'><Mon14></div><div class='col'><Tue14></div><div class='col'><Wed14></div><div class='col'><Thu14></div><div class='col'><Fri14></div></div><div class='row'><div class='col bg timeCol'>15:00</div><div class='col'><Sun15></div><div class='col'><Mon15></div><div class='col'><Tue15></div><div class='col'><Wed15></div><div class='col'><Thu15></div><div class='col'><Fri15></div></div><div class='row'><div class='col bg timeCol'>16:00</div><div class='col'><Sun16></div><div class='col'><Mon16></div><div class='col'><Tue16></div><div class='col'><Wed16></div><div class='col'><Thu16></div><div class='col'><Fri16></div></div><div class='row'><div class='col bg timeCol'>17:00</div><div class='col'><Sun17></div><div class='col'><Mon17></div><div class='col'><Tue17></div><div class='col'><Wed17></div><div class='col'><Thu17></div><div class='col'><Fri17></div></div><div class='row'><div class='col bg timeCol'>18:00</div><div class='col'><Sun18></div><div class='col'><Mon18></div><div class='col'><Tue18></div><div class='col'><Wed18></div><div class='col'><Thu18></div><div class='col'><Fri18></div></div><div class='row'><div class='col bg timeCol'>19:00</div><div class='col'><Sun19></div><div class='col'><Mon19></div><div class='col'><Tue19></div><div class='col'><Wed19></div><div class='col'><Thu19></div><div class='col'><Fri19></div></div><div class='row'><div class='col bg timeCol'>20:00</div><div class='col'><Sun20></div><div class='col'><Mon20></div><div class='col'><Tue20></div><div class='col'><Wed20></div><div class='col'><Thu20></div><div class='col'><Fri20></div></div><div class='row'><div class='col bg timeCol'>21:00</div><div class='col'><Sun21></div><div class='col'><Mon21></div><div class='col'><Tue21></div><div class='col'><Wed21></div><div class='col'><Thu21></div><div class='col'><Fri21></div></div></div></body></html>";

           public string display_str = null;

        private string accessToken;

           public TeacherWin()
           {
               InitializeComponent();
           }

        public TeacherWin(string _accessToken)
        {
            accessToken = _accessToken;
            InitializeComponent();
        }

        private void Teacher_FormClosed(object sender, FormClosedEventArgs e)
           {
            InfoDialog obj = new InfoDialog(accessToken);
            obj.fbLogOut();

            startFrom.Instance.Show();
               GlobalItems.currentUser=null;
           }

           private async void Teacher_Load(object sender, EventArgs e)
           {
            //label1.Text = "hellow " + GlobalItems.currentUser.fname + " " + GlobalItems.currentUser.lname + ":";

            displaySchedule();

            CourseLoad();
            fill();
            editInfo();


            await Task.Delay(250);
            //GlobalItems.FadeIn(this, 50);

            // animation
            await Task.Delay(2000);
            preloaderPanel.Location = new Point(preloaderPanel.Location.X, -650);
            //GlobalItems.slideUp(preloaderPanel, -650);

            //await Task.Delay(100);
            //GlobalItems.slideDown(Mon, 21);

            //await Task.Delay(100);
            //GlobalItems.slideRight(Tue, 12);
            //GlobalItems.slideUp(Wed, 328);

            ////await Task.Delay(100);
            //GlobalItems.slideRight(Thu, 495);
            //GlobalItems.slideRight(Fri, 734);

            //await Task.Delay(3000);
            //brand.Visible = true;
        }


        private void Teacher_Showed(object sender, System.EventArgs e)
           {
               // check if this user has previous prefers
               if (isExistPrefers())
               {
                   flagPrefers = true;
                   load_prefers();

                   setUserPrefers();
                   fill();
               }
           }

           public void fill()
           {
               if (display_str == null)
                   display_str = schedule_pattern;
               webBrowser1.DocumentText = display_str;
           }

           public void clearTable()
           {

               display_str = schedule_pattern;
               webBrowser1.DocumentText = display_str;
           }

           public void clearTableWithReset()
           {

               var c = GetAll(this, typeof(ComboBox));
               foreach (ComboBox cc in c)
               {
                cc.Text = "";
                cc.SelectedIndex = cc.FindStringExact("");
               }

               display_str = schedule_pattern;
               webBrowser1.DocumentText = display_str;
           }

           public void addEvent(string day, string title, string teacher, int start, int end, string color)
           {
               string search_patern = "<" + day + start.ToString() + ">".Trim();
               int p = display_str.IndexOf(search_patern);

               if (p != -1)
               {
                   string search_mark_begin = "<" + day + start.ToString() + "!>".Trim();
                   string search_mark_end = "<" + day + start.ToString() + "*>".Trim();

                   int height = (end - start) * 40;
                   string event_pattern = search_mark_begin + "<div class='event' style='background-color:" + color + "; height:" + height + "px;'> <span class='title'>" + title + "</span><span class='desc'>" + teacher + "</span><span class='desc'>" + start + ":00 - " + end + ":00</span></div>" + search_mark_end;

                   display_str = display_str.Replace(search_patern, event_pattern);
               }
           }

           private bool isExistPrefers()
           {
            try
            {
                DBA db = DBA.Instance;
                db.connect();
                db.getConnection().Open();
                string stm = "SELECT COUNT(*) FROM prefers WHERE id_user=" + GlobalItems.currentUser.id + "";
                SqlCommand cmd = new SqlCommand(stm, db.getConnection());
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                db.getConnection().Close();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                Console.Out.WriteLine("No Prefers");
                return false;
            }
           }

           public string checkTime(string t)
           {
               if (t == "0") return "";
               else return t+":00";
           }

           public void load_prefers()
           {
               try
               {
                   int tmpHour = 0;
                   string[] tmp_;
                   DBA db = DBA.Instance;
                   db.connect();

                   db.getConnection().Open();

                   using (var command = new SqlCommand("SELECT * FROM prefers WHERE id_user = " + GlobalItems.currentUser.id, db.getConnection()))
                   {
                       using (var r = command.ExecuteReader())
                       {
                           if (r.Read())
                           {
                               tmp_ = r.GetString(2).Split(',');
                               sun_1.Text = checkTime(tmp_[0]);
                               sun_2.Text = checkTime(tmp_[1]);
                               sun_3.Text = checkTime(tmp_[2]);
                               sun_4.Text = checkTime(tmp_[3]);

                               tmp_ = r.GetString(3).Split(',');
                               mon_1.Text = checkTime(tmp_[0]);
                               mon_2.Text = checkTime(tmp_[1]);
                               mon_3.Text = checkTime(tmp_[2]);
                               mon_4.Text = checkTime(tmp_[3]);

                               tmp_ = r.GetString(4).Split(',');
                               tue_1.Text = checkTime(tmp_[0]);
                               tue_2.Text = checkTime(tmp_[1]);
                               tue_3.Text = checkTime(tmp_[2]);
                               tue_4.Text = checkTime(tmp_[3]);

                               tmp_ = r.GetString(5).Split(',');
                               wed_1.Text = checkTime(tmp_[0]);
                               wed_2.Text = checkTime(tmp_[1]);
                               wed_3.Text = checkTime(tmp_[2]);
                               wed_4.Text = checkTime(tmp_[3]);

                               tmp_ = r.GetString(6).Split(',');
                               thu_1.Text = checkTime(tmp_[0]);
                               thu_2.Text = checkTime(tmp_[1]);
                               thu_3.Text = checkTime(tmp_[2]);
                               thu_4.Text = checkTime(tmp_[3]);

                               tmp_ = r.GetString(7).Split(',');
                               fri_1.Text = checkTime(tmp_[0]);
                               fri_2.Text = checkTime(tmp_[1]);


                               tmpHour = r.GetInt32(8);
                               summary.Text = tmpHour.ToString();
                           }
                       }
                   }
               }
               catch (SqlException ex)
               {
                   MessageBox.Show(ex.Message, "SQL Error",
MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }

           private void preview_Click(object sender, EventArgs e)
           {

               clearTable();
               setUserPrefers();
               fill();
           }

           public void setUserPrefers()
           {
               string sunM1, sunM2, sunE1, sunE2;
               string color = "gold";
               // Sunday
               sunM1 = sun_1.GetItemText(sun_1.SelectedItem);
               sunM2 = sun_2.GetItemText(sun_2.SelectedItem);
               buildEvent("Sun", "Morning", sunM1, sunM2, color);

               sunE1 = sun_3.GetItemText(sun_3.SelectedItem);
               sunE2 = sun_4.GetItemText(sun_4.SelectedItem);
               buildEvent("Sun", "Evening", sunE1, sunE2, color);

               // Monday
               sunM1 = mon_1.GetItemText(mon_1.SelectedItem);
               sunM2 = mon_2.GetItemText(mon_2.SelectedItem);
               buildEvent("Mon", "Morning", sunM1, sunM2, color);

               sunE1 = mon_3.GetItemText(mon_3.SelectedItem);
               sunE2 = mon_4.GetItemText(mon_4.SelectedItem);
               buildEvent("Mon", "Evening", sunE1, sunE2, color);

               // Tuesday
               sunM1 = tue_1.GetItemText(tue_1.SelectedItem);
               sunM2 = tue_2.GetItemText(tue_2.SelectedItem);
               buildEvent("Tue", "Morning", sunM1, sunM2, color);

               sunE1 = tue_3.GetItemText(tue_3.SelectedItem);
               sunE2 = tue_4.GetItemText(tue_4.SelectedItem);
               buildEvent("Tue", "Evening", sunE1, sunE2, color);

               // Wednesday
               sunM1 = wed_1.GetItemText(wed_1.SelectedItem);
               sunM2 = wed_2.GetItemText(wed_2.SelectedItem);
               buildEvent("Wed", "Morning", sunM1, sunM2, color);

               sunE1 = wed_3.GetItemText(wed_3.SelectedItem);
               sunE2 = wed_4.GetItemText(wed_4.SelectedItem);
               buildEvent("Wed", "Evening", sunE1, sunE2, color);

               // Thusday
               sunM1 = thu_1.GetItemText(thu_1.SelectedItem);
               sunM2 = thu_2.GetItemText(thu_2.SelectedItem);
               buildEvent("Thu", "Morning", sunM1, sunM2, color);

               sunE1 = thu_3.GetItemText(thu_3.SelectedItem);
               sunE2 = thu_4.GetItemText(thu_4.SelectedItem);
               buildEvent("Thu", "Evening", sunE1, sunE2, color);

               // Friday
               sunM1 = fri_1.GetItemText(fri_1.SelectedItem);
               sunM2 = fri_2.GetItemText(fri_2.SelectedItem);
               buildEvent("Fri", "Morning", sunM1, sunM2, color);

               buildEvent("Fri", "Evening", "14:00", "22:00", "gray");
           }

           public bool checkEvent(string start, string end)
           {
               
               string[] startTime = start.Split(':');
               string[] endtTime = end.Split(':');

               int startInt = Int32.Parse(startTime[0]);
               int endtInt = Int32.Parse(endtTime[0]);

               if (startInt >= endtInt)
                   return false;
               return true;
           }

           public bool buildEvent(string day, string eventTitle, string start, string end, string color)
           {
               if (start == "" || end == "")
                   return false;

               string[] startTime =  start.Split(':');
               string[] endtTime = end.Split(':');

               int startInt = Int32.Parse(startTime[0]);
               int endtInt = Int32.Parse(endtTime[0]);

               if (startInt >= endtInt)
                   return false;

               addEvent(day, eventTitle, "", startInt, endtInt, color);
               return true;
           }

           private void reset_Click(object sender, EventArgs e)
           {
               clearTableWithReset();
           }

           private void save_Click(object sender, EventArgs e)
           {
               List<string> user_prefers = new List<string>();

               var c = GetAll(this, typeof(ComboBox));
               foreach (ComboBox cc in c)
               {
                   string el = cc.GetItemText(cc.SelectedItem);
                   if (el == "")
                       user_prefers.Add("0");
                   else
                   {
                       string[] hour = el.Split(':');
                       user_prefers.Add(hour[0]);
                   }
               }

               user_prefers.Reverse();

               int user_id = GlobalItems.currentUser.id;

               List<string> list_sunday = new List<string>();
               for (var i = 0; i < 4; i++) { list_sunday.Add(user_prefers[i]); }

               List<string> list_monday = new List<string>();
               for (var i = 4; i < 8; i++) { list_monday.Add(user_prefers[i]); }

               List<string> list_tusday = new List<string>();
               for (var i = 8; i < 12; i++) { list_tusday.Add(user_prefers[i]); }

               List<string> list_wednesday = new List<string>();
               for (var i = 12; i < 16; i++) { list_wednesday.Add(user_prefers[i]); }

               List<string> list_thusday = new List<string>();
               for (var i = 16; i < 20; i++) { list_thusday.Add(user_prefers[i]); }

               List<string> list_friday = new List<string>();
               for (var i = 20; i < user_prefers.Count; i++) { list_friday.Add(user_prefers[i]); }

               string resSun = String.Join<string>(",", list_sunday);
               string resMon = String.Join<string>(",", list_monday);
               string resTue = String.Join<string>(",", list_tusday);
               string resWed = String.Join<string>(",", list_wednesday);
               string resThu = String.Join<string>(",", list_thusday);
               string resFri = String.Join<string>(",", list_friday);

               int sum_hours = calculateHours(user_prefers);
               summary.Text = sum_hours.ToString();

               Console.WriteLine(resSun);
               Console.WriteLine(resMon);
               Console.WriteLine(resTue);
               Console.WriteLine(resWed);
               Console.WriteLine(resThu);
               Console.WriteLine(resFri);

               

               DBA db = DBA.Instance;
               db.connect();

               if (!flagPrefers)
               {
                   db.query("INSERT INTO prefers (id_user, sun, mon, tue, wed, thu, fri, sum_hours) VALUES (" + user_id + ", '" + resSun + "', '" + resMon + "', '" + resTue + "', '" + resWed + "', '" + resThu + "', '" + resFri + "', " + sum_hours + " )");
               }
               else
               {
                   db.query("UPDATE prefers SET [sun]='" + resSun + "', [mon]='" + resMon + "', [tue]='" + resTue + "',[wed]='" + resWed + "', [thu]='" + resThu + "', [fri]='" + resFri + "', [sum_hours]=" + sum_hours + " WHERE id_user =" + GlobalItems.currentUser.id);
               }

               if (sum_hours > 0) {
                db.query("UPDATE users SET [hasSchedule]=1, [sum_hours] = "+sum_hours+"  WHERE id =" + GlobalItems.currentUser.id);
            }

               MessageBox.Show("Data has been saved");
            flagPrefers = true;

           }

           public int calculateHours(List<string> times)
           {
               int temp = 0, start,end;

               for (var i = 0; i < times.Count; i=i+2) {
                   start = Int32.Parse(times[i]);
                   end = Int32.Parse(times[i+1]);
                   if (start <= end)
                       temp += end - start;
               }
               return temp;
           }

           public IEnumerable<Control> GetAll(Control control, Type type)
           {
               var controls = control.Controls.Cast<Control>();

               return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                         .Concat(controls)
                                         .Where(c => c.GetType() == type);
           }



        /* END CONSTRAINS CODE AND GLOBAL EVENTS *************************************/


        /* TAB 3 EDIT PROFILE *************************************/
        private void editInfo()
        {
            Fname.Text = GlobalItems.currentUser.fname;
            Lname.Text = GlobalItems.currentUser.lname;
            Email.Text = GlobalItems.currentUser.email;
            Password.Text = GlobalItems.currentUser.password;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.query("UPDATE users SET[fname] = '" + Fname.Text.ToString() + "', [lname]='" + Lname.Text.ToString() + "', [email]='" + Email.Text.ToString() + "', [password]='" + Password.Text.ToString() + "' WHERE id = " + GlobalItems.currentUser.id + "");
            GlobalItems.currentUser.fname = Fname.Text;
            GlobalItems.currentUser.lname = Lname.Text;
            GlobalItems.currentUser.email = Email.Text;
            GlobalItems.currentUser.password = Password.Text;
            editInfo();
        }
        /* END EDIT PROFILE *************************************/





        /* TAB 4 DISPLAY USER'S COURSES *************************************/
        private void CourseLoad()
        {
            String topStr = "<!doctype html><html><head><style>.course { display: block; width: 40%; padding: 1%; margin:1.5%; float: left; border-radius: 4px; border:2px solid #ccc; background: #efefef; }.course h3 {color:#9cf; font-weight: bold; margin-top: 4px; margin-bottom: : 0px;}.course .time { margin-top: 10px; font-weight: bold; color:#9cf;  }.course .users { margin-top: 10px; font-weight: bold; color:#F28128;  }</style></head>";


            List<String> listCourses = new List<String> ();
            try
            {
                DBA db = DBA.Instance;
                db.connect();
                var con = db.getConnection();
                con.Open();

                string query = "SELECT  name, maxCapacity, lecture_hours, description FROM course WHERE id IN(SELECT id_course FROM courseToTT WHERE id_user =" + GlobalItems.currentUser.id + " );";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            String block = "<div class='course'><h3>"+reader["name"]+ "</h3><div class='desc'>" + reader["description"] + "</div><div class='time'>Hours &#8987 " + reader["lecture_hours"] + "</div><div class='users'>Students " + reader["maxCapacity"] + "</div></div>";
                            listCourses.Add(block);
                        }
                    }
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            String endStr = "<div style='clear:both;'></div></body></html>";

            String res = topStr + String.Join(String.Empty, listCourses) + endStr;
            userCourses.DocumentText = res;

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void lblLname_Click(object sender, EventArgs e)
        {

        }

        private void lblFname_Click(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lname_TextChanged(object sender, EventArgs e)
        {

        }

        private void Fname_TextChanged(object sender, EventArgs e)
        {

        }

        /* END DISPLAY USER'S COURSES *************************************/

    }
}
