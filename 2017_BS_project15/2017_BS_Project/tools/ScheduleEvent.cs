using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_BS_Project.tools
{
    class ScheduleEvent
    {
        public int Id { get; set; }
        public int  User_id { get; set; }
        public int Course_id { get; set; }
        public string Course_name { get; set; }
        public string Day { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int Class_id { get; set; }
        public string Class_name { get; set; }

        public ScheduleEvent()
        {}

        public ScheduleEvent(int _user_id, int _course_id, string _course_name, string _day, int _start, int _end, int _class_id, string _class_name)
        {
            Id = 0;
            User_id = _user_id;
            Course_id = _course_id;
            Course_name = _course_name;
            Day = _day;
            Start = _start;
            End = _end;
            Class_id = _class_id;
            Class_name = _class_name;
        }


        public override String ToString()
        {
            return "{"+User_id+"} "+Day + " "+Start + "-" + End + " "+ Course_name+"["+ Course_id+"] "+ Class_name+"["+ Class_id+"]";
        }
    }
}
