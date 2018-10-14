using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_BS_Project.tools
{
    public class Prefers
    {
        public string Day { get; set; }
        public int Start { get; set; }
        public int End { get; set; }

        public Prefers(string day, int start, int end)
        {
            Day = day;
            Start = start;
            End = end;
        }
    }
}
