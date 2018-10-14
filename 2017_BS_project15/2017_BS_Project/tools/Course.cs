using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_BS_Project.tools
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int maxCapacity { get; set; }
        public int Capacity { get; set; }

        public int Lecture_Hour { get; set; }
        public int Pracise_Hour { get; set; }
        public int Lab_Hour { get; set; }

        public int Id_Department { get; set; }
        public string Description { get; set; }

        public Course(int _id, string _name)
        {
            Id = _id;
            Name = _name;

            maxCapacity = Capacity = Lecture_Hour = Pracise_Hour = Lab_Hour = 0;
        }

        public Course(int _id, string _name, int _MaxCapacity)
        {
            Id = _id;
            Name = _name;
            maxCapacity = _MaxCapacity;

            Capacity  = Lecture_Hour = Pracise_Hour = Lab_Hour = 0;
        }


        public Course(int _id, string _name, int _Lecture_Hour, int _Pracise_Hour, int _Lab_Hour)
        {
            Id = _id;
            Name = _name;
            Lecture_Hour = _Lecture_Hour;
            Pracise_Hour = _Pracise_Hour;
            Lab_Hour = _Lab_Hour;
        }


        public Course(int _id, string _name, int _MaxCapacity, int _Lecture_Hour, int _Pracise_Hour, int _Lab_Hour, int _id_department, string _description)
        {
            Id = _id;
            Name = _name;
            maxCapacity = _MaxCapacity;
            Lecture_Hour = _Lecture_Hour;
            Pracise_Hour = _Pracise_Hour;
            Lab_Hour = _Lab_Hour;
            Id_Department = _id_department;
            Description = _description;
        }

        public void incrementCapacity()
        {
            Capacity += 1;
        }


        public override String ToString()
        {
            return Name + "[" + Id + "]";
        }
    }
}
