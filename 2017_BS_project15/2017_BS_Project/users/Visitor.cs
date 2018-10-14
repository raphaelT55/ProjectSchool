using _2017_BS_Project.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_BS_Project.users
{
    class Visitor 
    {
        protected string _id;
        protected string _fname;
        protected string _lname;
        protected int _status;
        protected string _email;

        public Visitor()
        {
            _id = "";
            _fname = "";
            _lname = "";
            _status = 0;
            _email = "";
        }

        public Visitor(string id, string fname, string lname, string email)
        {
            this._id = id;
            this._fname = fname;
            this._lname = lname;
            this._status = 0;
            this._email = email;

        }

        public string id
        {
            get
            {
                return this._id;
            }

            set
            {
                if ((Register.CheckId(value)) == true && (Register.CheckFieldEmpty(value)) == false)
                    this._id = value;
            }
        }

        public string fname
        {
            get
            {
                return this._fname;
            }

            set
            {
                if (Register.CheckFieldEmpty(value) == false)
                    this._fname = value;
            }
        }

        public string lname
        {
            get
            {
                return this._lname;
            }

            set
            {
                if (Register.CheckFieldEmpty(value) == false)
                    this._lname = value;
            }
        }

        public int status
        {
            get
            {
                return this._status;
            }

            set
            {
                this._status = value;
            }
        }

        public string email
        {
            get
            {
                return this._email;
            }

            set
            {
                if (Register.CheckFieldEmpty(value) == false && Register.CheckMail(value) == true)
                    this._email = value;
            }
        }


    }
}
//