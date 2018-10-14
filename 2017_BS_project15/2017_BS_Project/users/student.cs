using _2017_BS_Project.tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2017_BS_Project.users
{
    class student : Visitor
    {
        protected string _semester;
        protected string _department;
        protected string _year;
        protected string _password;
      //  protected string _secondPassword;

        public student() : base()
        {

            _semester = "";
            _department = "";
            _year = "";
            _password = "";
           // _secondPassword = "";
        }

        public student(string semester, string department, string year, string password, string id, string fname, string lname, string email) : base(id, fname, lname, email)
        {

            this._semester = semester;
            this._department = department;
            this._year = year;
            this._password = password;
          //  this._secondPassword = secondPassword;
        }

        public string semester
        {
            get
            {
                return this._semester;
            }

            set
            {
                if (Register.CheckFieldEmpty(value) == false)
                    this._semester = value;
            }
        }
        // kakak
        public string department
        {
            get
            {
                return this._department;
            }

            set
            {
                if (Register.CheckFieldEmpty(value) == false)
                    this._department = value;
            }
        }

        public string year
        {
            get
            {
                return this._year;
            }

            set
            {
                if (Register.CheckFieldEmpty(value) == false)
                    this._year = value;
            }
        }

        public string password
        {
            get
            {
                return this._password;
            }

            set
            {
                if (Register.CheckPassword(value) == true && Register.CheckFieldEmpty(value) == false)
                    this._password = value;
            }
        }

        //public string secondPassword
        //{
        //    get
        //    {
        //        return this._secondPassword;
        //    }

        //    set
        //    {
        //        if (Register.CheckFieldEmpty(value) == false && Register.CheckSamePassword(value, value) == true)
        //            this._secondPassword = value;
        //    }
        //}

        public bool Connexion(string Id,string password)
        {

            if (_id==Id && _password == password && Id!= "")
            {
                MessageBox.Show("Connexion Successful");
                return true;
            }
            else
            {
                MessageBox.Show("Your Id or your password in not correct");
                return false;
            }
            
        }

        public bool ResetPassword(string Id, string mail)
        {

            if (_id == Id && _email == mail)
            {
                
                return true;
            }
            else
            {
                MessageBox.Show("Your Id or your email in not correct");
                return false;
            }

        }
        // Compare Password and Id if password and id in the database
        public bool ChangePassword(string Id, string password)
        {

            if (_id == Id && _password == password)
            {
               
                return true;
            }
            else
            {
                MessageBox.Show("Your Id or your email in not correct");
                return false;
            }

        }
        // update information in to database
        public void Student_Update()
        {
            DBA db = DBA.Instance;
            db.connect();

            db.getConnection().Open();

            using (var command = new SqlCommand("UPDATE students SET password='" + _password + "',email='" + _email + "',fname='" + _fname + "',lname='" + _lname + "',department='" + _department + "',year='" + _year + "',idNumber='" + _id + "' ,semester='" + _semester + "' WHERE idNumber= '" + _id + "'", db.getConnection()))
            {
                using (var r = command.ExecuteReader())
                {
                    while (r.Read())
                    {
                        MessageBox.Show(r.GetString(1));
                    }

                }
                MessageBox.Show("Your informations are register in the system !");
            }
            db.getConnection().Close();
        }

        public void UpdateRegister()
        {


            DBA db = DBA.Instance;
            db.connect();

            db.getConnection().Open();

            using (var command = new SqlCommand("INSERT INTO students (idNumber, password, email,fname,lname,semester,department,year,status)VALUES('" + _id + "','" + password + "','" + _email + "','" + _fname + "','" + _lname + "','" + _semester + "','" + _department + "','" + _year + "','0')", db.getConnection()))
            {
                using (var r = command.ExecuteReader())
                {
                    while (r.Read())
                    {
                        MessageBox.Show(r.GetString(1));
                    }

                }
            }
            db.getConnection().Close();
        }


        public  void ChoiceCourse(String Course1, String Course2, String Course3, String Course4, String Course5)
        {


            DBA db = DBA.Instance;
            db.connect();

            db.getConnection().Open();

            using (var command = new SqlCommand("INSERT INTO CourseSemester (Id, Course1, Course2,Course3,Course4,Course5)VALUES('" + _id +"','" + Course1 + "','" + Course2 + "','" + Course3 + "','" + Course4 + "','" + Course5 + "')", db.getConnection()))
            {
                using (var r = command.ExecuteReader())
                {
                    while (r.Read())
                    {
                        MessageBox.Show(r.GetString(1));
                    }
                    
                }
            }
            db.getConnection().Close();
        }

        //public Courses[] courseSemester()
        //{
        //    CoursesSemester[] coursesSeme = DataBase.coursesSemester();
        //    Courses[] coursesStudent = DataBase.course();
        //    Courses[] help = new Courses[10];
        //    for (int j = 0; j < 10; j++)
        //        help[j] = new Courses();
        //    int index = 0;
        //    foreach (CoursesSemester s in coursesSeme)
        //    {
        //        if (s.id == Form1.student.id)
        //            foreach (Courses v in coursesStudent)
        //            {
        //                if (s.Course1 == v.name || s.Course2 == v.name || s.Course3 == v.name || s.Course4 == v.name || s.Course5 == v.name)
        //                {
        //                    help[index] = v;
        //                    //

        //                    index++;
        //                }
        //            }

        //    }

        //    return help;
        //}


        //public bool CourseSuperimposed(Courses[] v)
        //{
        //    int index = 0;
        //    foreach (Courses x in v)
        //        index++;

        //    for (int i = 0; i < index; i++)
        //        for (int j = i + 1; j < index; j++)
        //            if (v[i].day == v[j].day && v[j].id != v[i].id)
        //            {
        //                if (v[i].EndHours > v[j].EndHours)
        //                    if (v[i].StartHours >= v[j].StartHours && v[i].StartHours <= v[j].EndHours)
        //                    {
        //                        MessageBox.Show(v[i].name + " is imcompatible with " + v[j].name);
        //                        return false;
        //                    }
        //                if (v[i].EndHours < v[j].EndHours)
        //                    if (v[j].StartHours >= v[i].StartHours && v[j].StartHours <= v[i].EndHours)
        //                    {
        //                        MessageBox.Show(v[i].name + " is imcompatible with " + v[j].name);
        //                        return false;
        //                    }
        //            }

        //    return true;
        //}


    }
}
