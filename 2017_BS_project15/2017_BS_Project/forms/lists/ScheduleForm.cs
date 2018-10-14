using _2017_BS_Project.tools;
using _2017_BS_Project.users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2017_BS_Project.forms.lists
{
    public partial class ScheduleForm : Form
    {
        private timeTable prefers;
        private timeTable schedule;
        private String prefers_color;
        private String schedule_color;
        private int user_scheudle_id;
        private List<Course> listCourses;
        private List<Prefers> listPrefers;
        private List<Room> avaliableRooms;
        private List<int> listUsersId;

        private Dictionary<int, Dictionary<int, ScheduleEvent>> dictSchedule;

        public ScheduleForm()
        {
            prefers = new timeTable();
            schedule = new timeTable();
            dictSchedule = new Dictionary<int, Dictionary<int, ScheduleEvent>>();
            user_scheudle_id = 0;

            InitializeComponent();
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            // load users
            UsersLoad();


            // init scheduling view
            userPrefers.DocumentText = prefers.fill(); // user prefers
            scheduleView.DocumentText = schedule.fill(); // user schedule
            prefers_color = "yellow";
            schedule_color = "green";

        }


        private void UsersLoad()
        {
            try
            {
                
                DBA db = DBA.Instance;
                db.connect();

                db.getConnection().Open();

                var select = "SELECT idNUmber,fname,lname, id FROM users WHERE type IN (3,4) ORDER by id ASC";
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
            string uId_Str = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            int UId = 0;
            if (uId_Str != "") { Int32.TryParse(uId_Str, out UId); }
            Console.Out.WriteLine(UId);

            // check if exist schedule 
            dictSchedule[UId] = new Dictionary<int, ScheduleEvent>();

            if (checkIFExistSchedule(UId)) {
                ScheduleLoad(UId);
            }


            user_scheudle_id = UId;
            
            load_prefers(UId);
            ScheduleLoad(UId);
            CourseLoad(UId);

            // clear fields 
            coursesChoose.Text = "";
            dayChoose.Text = "";
            startChoose.Text = "";
            endChoose.Text = "";
            rooms.Text = "";
        }

        private void ScheduleLoad(int uID)
        {            
            try
            {
                schedule.clearTable();

                DBA db = DBA.Instance;
                db.connect();
                var con = db.getConnection();
                con.Open();

                string query = "SELECT  * FROM schedule WHERE user_id = " + uID;
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
                            dictSchedule[uID][cID] = block;

                            schedule.buildEvent(day, title, start, end, schedule_color);
                        }
                    }
                }

                scheduleView.DocumentText = schedule.fill();
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CourseLoad(int uID)
        {
            coursesChoose.Items.Clear();
            listCourses = new List<Course>();
            try
            {
                DBA db = DBA.Instance;
                db.connect();
                var con = db.getConnection();
                con.Open();

                string query = "SELECT  id, name, lecture_hours, practice_hours, lab_hours FROM course WHERE id IN(SELECT id_course FROM courseToTT WHERE id_user =" + uID + " );";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            Course block = new Course(r.GetInt32(0), r.GetString(1), r.GetInt32(2), r.GetInt32(3), r.GetInt32(4));
                            listCourses.Add(block);
                            coursesChoose.Items.Add(block.ToString());
                        }
                    }
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SearchAvaliableRooms(string day, string start, string end)
        {
            // get all rooms for specific day
            List<Room> listRooms = new List<Room>();
            try
            {
                DBA db = DBA.Instance;
                db.connect();
                var con = db.getConnection();
                con.Open();

                string query = "SELECT  id, name, type, "+ day.ToLower() + " FROM classes";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            Room kita;
                            string dd = r.GetString(3).ToString();
                            if (r == null)
                            {
                                 kita = new Room(r.GetInt32(0), r.GetString(1), r.GetInt32(2), "");
                            }
                            else {  kita = new Room(r.GetInt32(0), r.GetString(1), r.GetInt32(2), r.GetString(3)); }

                            listRooms.Add(kita);
                        }
                    }
                }

                // filter rooms that avaliable in specific day and time
                avaliableRooms = new List<Room>();
                    rooms.Text = "";
                    rooms.Items.Clear();

                    int startH = strToInt(start.Split(':')[0]);
                    int endH = strToInt(end.Split(':')[0]);

                    foreach (Room k in listRooms)
                    {
                        bool checkRoom1 = true;
                        bool checkRoom2 = true;

                    // sql data form: "10:12, 14:18, 20:23"
                    // checking time is 18:20
                    if (k.Day != "")
                    {
                            string[] timeSlice = k.Day.Split(',');
                            for ( int i = 0; i < timeSlice.Length-1; i++)
                            {
                                string[] tStartEnd = timeSlice[i].Split(':');
                                int classStart = strToInt(tStartEnd[0]);
                                int classEnd = strToInt(tStartEnd[1]);

                                //  all event before time block
                                if (classStart < startH) {
                                    if (startH < classEnd) checkRoom1 = false;
                                }

                                // all event after time block
                                if (classStart > startH)
                                {
                                    if (endH > classStart) checkRoom2 = false;
                                }

                                //all events in the same time
                                if (classStart == startH ) { checkRoom1 = checkRoom2 = false; }     
                            }
                        }

                    // after all check if room is avaliable add to list
                    if (checkRoom1 && checkRoom2) {
                        rooms.Items.Add(k.ToString());
                        avaliableRooms.Add(k);
                    }
                    }   
            }

            catch (SqlException ex) {
                MessageBox.Show(ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void load_prefers(int uID)
        {
            try
            {

                listPrefers = new List<Prefers>();
                prefers.clearTable();
                //int tmpHour = 0;
                string[] tmp_;
                DBA db = DBA.Instance;
                db.connect();

                db.getConnection().Open();

                using (var command = new SqlCommand("SELECT * FROM prefers WHERE id_user = " + uID, db.getConnection()))
                {
                    using (var r = command.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            
                            // sunday
                            tmp_ = r.GetString(2).Split(',');
                            prefers.buildEvent("Sun", "Morning", tmp_[0]+":00", tmp_[1]+":00", prefers_color);
                            prefers.buildEvent("Sun", "Evening", tmp_[2] + ":00", tmp_[3] + ":00", prefers_color);

                            listPrefers.Add(new Prefers("Sun", strToInt(tmp_[0]), strToInt(tmp_[1])));
                            listPrefers.Add(new Prefers("Sun", strToInt(tmp_[2]), strToInt(tmp_[3])));

                            // monday
                            tmp_ = r.GetString(3).Split(',');
                            prefers.buildEvent("Mon", "Morning", tmp_[0] + ":00", tmp_[1] + ":00", prefers_color);
                            prefers.buildEvent("Mon", "Evening", tmp_[2] + ":00", tmp_[3] + ":00", prefers_color);

                            listPrefers.Add(new Prefers("Mon", strToInt(tmp_[0]), strToInt(tmp_[1])));
                            listPrefers.Add(new Prefers("Mon", strToInt(tmp_[2]), strToInt(tmp_[3])));

                            // tuesday
                            tmp_ = r.GetString(4).Split(',');
                            prefers.buildEvent("Tue", "Morning", tmp_[0] + ":00", tmp_[1] + ":00", prefers_color);
                            prefers.buildEvent("Tue", "Evening", tmp_[2] + ":00", tmp_[3] + ":00", prefers_color);

                            listPrefers.Add(new Prefers("Tue", strToInt(tmp_[0]), strToInt(tmp_[1])));
                            listPrefers.Add(new Prefers("Tue", strToInt(tmp_[2]), strToInt(tmp_[3])));

                            // wednesday
                            tmp_ = r.GetString(5).Split(',');
                            prefers.buildEvent("Wed", "Morning", tmp_[0] + ":00", tmp_[1] + ":00", prefers_color);
                            prefers.buildEvent("Wed", "Evening", tmp_[2] + ":00", tmp_[3] + ":00", prefers_color);

                            listPrefers.Add(new Prefers("Wed", strToInt(tmp_[0]), strToInt(tmp_[1])));
                            listPrefers.Add(new Prefers("Wed", strToInt(tmp_[2]), strToInt(tmp_[3])));


                            // thusday
                            tmp_ = r.GetString(6).Split(',');
                            prefers.buildEvent("Thu", "Morning", tmp_[0] + ":00", tmp_[1] + ":00", prefers_color);
                            prefers.buildEvent("Thu", "Evening", tmp_[2] + ":00", tmp_[3] + ":00", prefers_color);

                            listPrefers.Add(new Prefers("Thu", strToInt(tmp_[0]), strToInt(tmp_[1])));
                            listPrefers.Add(new Prefers("Thu", strToInt(tmp_[2]), strToInt(tmp_[3])));


                            // friday
                            tmp_ = r.GetString(7).Split(',');
                            prefers.buildEvent("Fri", "Morning", tmp_[0] + ":00", tmp_[1] + ":00", prefers_color);

                            listPrefers.Add(new Prefers("Fri", strToInt(tmp_[0]), strToInt(tmp_[1])));

                        }
                    }
                }
                userPrefers.DocumentText = prefers.fill();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error",
MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dayChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            startChoose.Enabled = true;
        }

        private void startChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            endChoose.Enabled = true;
        }

        private void endChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dC = dayChoose.GetItemText(dayChoose.SelectedItem);
            string sC = startChoose.GetItemText(startChoose.SelectedItem);
            string eC = endChoose.GetItemText(endChoose.SelectedItem);

            SearchAvaliableRooms(dC, sC, eC);
        }

        public int strToInt(string s)
        {
            int x = 0;
            Int32.TryParse(s, out x);
            return x;
        }

        private void setEvent_Click(object sender, EventArgs e)
        {
            string dC = dayChoose.GetItemText(dayChoose.SelectedItem);
            string sC= startChoose.GetItemText(startChoose.SelectedItem);
            string eC = endChoose.GetItemText(endChoose.SelectedItem);
 
            string course = coursesChoose.GetItemText(coursesChoose.SelectedItem);
            string r = rooms.GetItemText(rooms.SelectedItem);

            course = course.Remove(course.Length - 1); // remove last char
            string[] course_data = course.Split('[');
            int course_id = strToInt(course_data[1]);

            r = r.Remove(r.Length - 1); // remove last char
            string[] room_data = r.Split('[');
            int room_id = strToInt(room_data[1]);

            int start = strToInt(sC.Split(':')[0]);
            int end = strToInt(eC.Split(':')[0]);

            dictSchedule[user_scheudle_id][course_id] = (new ScheduleEvent(user_scheudle_id, course_id, course_data[0], dC, start, end, room_id, room_data[0]));

        }

        private void repaint()
        {
            scheduleView.DocumentText = schedule.clearTable();
            foreach (int key in dictSchedule[user_scheudle_id].Keys)
            {
                string day = dictSchedule[user_scheudle_id][key].Day;
                string course = dictSchedule[user_scheudle_id][key].Course_name;
                string room = dictSchedule[user_scheudle_id][key].Class_name;
                string title = course + " (" + room + ")";

                string start = dictSchedule[user_scheudle_id][key].Start.ToString() + ":00";
                string end = dictSchedule[user_scheudle_id][key].End.ToString() + ":00";

                schedule.buildEvent(day, title, start, end, schedule_color);
                Console.Out.WriteLine(dictSchedule[user_scheudle_id][key].ToString());
            }

            scheduleView.DocumentText = schedule.fill();
        }

        private void Preview_Click(object sender, EventArgs e)
        {
            repaint();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            string course = coursesChoose.GetItemText(coursesChoose.SelectedItem);
            course = course.Remove(course.Length - 1); // remove last char
            string[] course_data = course.Split('[');
            int course_id = strToInt(course_data[1]);

            dictSchedule[user_scheudle_id].Remove(course_id);
            repaint();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            DBSave(user_scheudle_id, false);
        }

        private void DBSave(int uID, bool all)
        {
            DBA db = DBA.Instance;
            db.connect();

            foreach (int key in dictSchedule[uID].Keys)
            {
                // delete previous
                db.query("DELETE schedule Where user_id = " + uID + " AND  course_id = " + key + " ");

                string day = dictSchedule[uID][key].Day;
                int user_id = dictSchedule[uID][key].User_id;
                int class_id = dictSchedule[uID][key].Class_id;
                int course_id = dictSchedule[uID][key].Course_id;
                int start = dictSchedule[uID][key].Start;
                int end = dictSchedule[uID][key].End;

                string course_name = dictSchedule[uID][key].Course_name;
                string class_name = dictSchedule[uID][key].Class_name;

                string class_appoinment = start.ToString() + ":" + end.ToString() + ",";

                db.query("INSERT INTO schedule (user_id,course_id, course_name, day, startH, endH, class_id, class_name) VALUES (" + user_id + ", '" + course_id + "', '" + course_name + "', '" + day + "', " + start + ", " + end + ", " + class_id + ", '" + class_name + "' )");

                db.query("UPDATE classes SET [" + day.ToLower() + "]=  [" + day.ToLower() + "] +  '" + class_appoinment + "' WHERE id =" + class_id);
            }
            if (!(all)) { MessageBox.Show("Data Saved"); }
        }

        private bool checkIFExistSchedule(int  uID)
        {
            DBA db = DBA.Instance;
            db.connect();
            db.getConnection().Open();
            string stm = "SELECT COUNT(*) FROM schedule WHERE user_id='" + uID + "'";
            SqlCommand cmd = new SqlCommand(stm, db.getConnection());
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            db.getConnection().Close();
            if (count == 0)
                return true;
            else
                return false;
        }


        // generate for one
        public void generateOne(int uId, bool all)
        {
            preloader.Visible = true;
            Application.DoEvents();

           // bool flag = false;

            if (uId == 0) { MessageBox.Show("Please Select Users"); return;  }
            else
            {
               
                load_prefers(uId);
                CourseLoad(uId);

                if (listCourses.Count == 0) { MessageBox.Show("This user does not have a courses!!!"); return; }
                else
                {
                    foreach (Course c in listCourses)
                    {
                        int lecture = c.Lecture_Hour;
                        int lab = c.Lab_Hour;
                        int practise = c.Pracise_Hour;

                        if (lecture > 0 || lab > 0 || practise > 0)
                        {

                            // user without prefers
                            if (listPrefers.Count == 0) {
                                int startTime = gRand(8, 17);
                                int endTime = 0;
                                if (lecture > 0) endTime = startTime + lecture;
                                else if (lab > 0) endTime = startTime + lab;
                                else if (practise > 0) endTime = startTime + practise;

                                string rDay = getRandDay();

                                SearchAvaliableRooms(rDay, startTime.ToString() + ":00", endTime.ToString() + ":00");
                                if (avaliableRooms.Count > 0)
                                {
                                    int randIndex = gRand(0, avaliableRooms.Count-1);
                                    Room a = avaliableRooms[randIndex];

                                   
                                    dictSchedule[uId][c.Id] = (new ScheduleEvent(uId, c.Id, c.Name, rDay, startTime, endTime, a.Id, a.Name));
                                }
                            }


                            // user with prefers
                            else
                            {
                                foreach (Prefers p in listPrefers)
                                {
                                    if (p.Start > 0)
                                    {
                                        int endTime = 0;
                                        if (lecture > 0) endTime = p.Start + lecture;
                                        else if (lab > 0) endTime = p.Start + lab;
                                        else if (practise > 0) endTime = p.Start + practise;

                                        SearchAvaliableRooms(p.Day, p.Start.ToString() + ":00", endTime.ToString() + ":00");
                                        if (avaliableRooms.Count > 0)
                                        {
                                            Room a = avaliableRooms[gRand(0, avaliableRooms.Count - 1)];

                                            dictSchedule[uId][c.Id] = (new ScheduleEvent(uId, c.Id, c.Name, p.Day, p.Start, endTime, a.Id, a.Name));

                                            listPrefers.Remove(p);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    DBSave(uId, all);
                }

            }
            preloader.Visible = false;
            Application.DoEvents();
        }

        public void generateAll()
        {
            // clear class room schedule
            DBA db = DBA.Instance;
            db.connect();

            db.query("UPDATE classes SET [sun]='', [mon]='', [tue]='', [wed]='', [thu]='', [fri]='' WHERE id > 0");

            // clear dictionary
            dictSchedule.Clear(); // reset previous data

            foreach (int id in listUsersId)
            {
                dictSchedule[id] = new Dictionary<int, ScheduleEvent>();
                generateOne(id, true);
            }
            MessageBox.Show("Data Saved");
        }


       public  int gRand(int from, int to) {
            int rInt = -1;
            while (rInt < 0)
            {
                Random r = new Random();
                rInt = r.Next(from, to);
            }
            return rInt;
        }

        private void generate_one_Click(object sender, EventArgs e)
        {
            generateOne(user_scheudle_id, false);
        }

        private void loadUsersId()
        {
            listUsersId = new List<int>();
            for (int x = 0; x < dataGridView1.Rows.Count-1; x++)
            {
                string id = dataGridView1.Rows[x].Cells[3].Value.ToString();
                Console.Out.WriteLine(id);
                int uId = strToInt(id);
                listUsersId.Add(uId);
            }
        }

        private void coursesChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (user_scheudle_id == 0) { MessageBox.Show("Please Choose user"); }
            else {
                string course = coursesChoose.GetItemText(coursesChoose.SelectedItem);
                string r = rooms.GetItemText(rooms.SelectedItem);

                course = course.Remove(course.Length - 1); // remove last char
                string[] course_data = course.Split('[');
                int course_id = strToInt(course_data[1]);

                if (dictSchedule[user_scheudle_id].ContainsKey(course_id))
                {
                    ReloadFileds(course_id);
                }
            }
        }

        private void ReloadFileds(int course_id)
        {
            ScheduleEvent se = dictSchedule[user_scheudle_id][course_id];
            dayChoose.Text = se.Day;
            startChoose.Text = se.Start.ToString();
            endChoose.Text = se.End.ToString();
            endChoose.Enabled = true;

            rooms.Text = se.Class_name + "[" + se.Class_id.ToString() + "]";
        }

        private string getRandDay()
        {
            List<string> days = new List<string>();
            days.Add("Sun");
            days.Add("Mon");
            days.Add("Tue");
            days.Add("Wed");
            days.Add("Thu");

            return days[gRand(0, days.Count-1)];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadUsersId();
            generateAll();
        }
    }
}
