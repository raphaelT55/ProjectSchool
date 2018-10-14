using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_BS_Project.tools
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int id_manager { get; set; }

        public Department(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }

        public Department(int _id, string _name, int _id_manager)
        {
            Id = _id;
            Name = _name;
            id_manager = _id_manager;
        }
    }
}
