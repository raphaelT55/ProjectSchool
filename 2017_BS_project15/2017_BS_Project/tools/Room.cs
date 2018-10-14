using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_BS_Project.tools
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Day { get; set; }

        public int Type { get; set; }

        public string Sun { get; set; }
        public string Mon { get; set; }
        public string Tue { get; set; }
        public string Wed { get; set; }
        public string Thu { get; set; }
        public string Fri { get; set; }


        public Room(int _id, string _name, int t, string _sun, string _mon, string _tue, string _wed, string _thu, string _fri)
        {
            Id = _id;
            Name = _name;
            Type = t;
            Sun = _sun;
            Mon = _mon;
            Tue = _tue;
            Wed = Wed;
            Thu = _thu;
            Fri = _fri;
        }


        public Room(int _id, string _name, int t, string _day)
        {
            Id = _id;
            Name = _name;
            Type = t;
            Day = _day;
        }

        public override String ToString()
        {
            return Name + "[" + Id + "]";
        }
    }
}
