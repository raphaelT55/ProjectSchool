using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_BS_Project.users
{
    public class Users
    {
        //private int id, type;
        //private string fname, lname, email, password, idNumber;

        public int id { get; set; }
        public int type { get; set; }

        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string idNumber { get; set; }

        public Users()
        {
            id = 0;
            type = -1;
            fname = lname = email = password = idNumber = "";
        }

        public Users(int _id, string _fname, string _lname, string _email, string _password, string _idNumber, int _type)
        {
            id = _id;
            type = _type;
            fname = _fname;
            lname = _lname;
            email = _email;
            password = _password;
            idNumber = _idNumber;
        }

        public string toString()
        {
            string userLevel= null;
            switch (type)
            {
                case 1: userLevel = "Manager"; break;
                case 2: userLevel = "Secretary"; break;
                case 3: userLevel = "Teacher"; break;
                case 4: userLevel = "Paracticer"; break;
                default: userLevel = "Undefined"; break;
            }
            return idNumber+" "+fname + " " + lname + " " + userLevel + " " + email + " " + password;
        }
    }
}
