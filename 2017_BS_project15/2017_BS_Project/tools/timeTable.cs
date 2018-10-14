using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_BS_Project.tools
{
    public class timeTable
    {

        public string Schedule_pattern { get; set; }
        public string Display_str { get; set; }


        public timeTable()
        {
                    // html patern of schedule table
         Schedule_pattern = "<!DOCTYPE html><html><style>body{margin:0px;padding:0px}div{margin:0px;padding:0px;height:40px;display:block;vertical-align:middle;line-height:40px}.row{clear:both;width:100%}.col{float:left;width:14%;border:1px solid #eee}.dayRow{font-weight:bold;text-align:center}.bg{background:#9cf}.timeCol{width:50px;text-align:center;font-weight:bold}div.sc.col{position:relative}span{font-size:12px}.event{width:100%;position:relative;border:1px solid #9cf;overflow:hidden}.event span{display:block}span.title{font-weight:bold;font-size:14px}</style><body><div class='sc'><div class='row dayRow'><div class='col bg timeCol'></div><div class='col bg'>Sun</div><div class='col bg'>Mon</div><div class='col bg'>Tue</div><div class='col bg'>Wed</div><div class='col bg'>Thu</div><div class='col bg'>Fri</div></div><div class='row'><div class='col bg timeCol'>8:00</div><div class='col'><Sun8></div><div class='col'><Mon8></div><div class='col'><Tue8></div><div class='col'><Wed8></div><div class='col'><Thu8></div><div class='col'><Fri8></div></div><div class='row'><div class='col bg timeCol'>9:00</div><div class='col'><Sun9></div><div class='col'><Mon9></div><div class='col'><Tue9></div><div class='col'><Wed9></div><div class='col'><Thu9></div><div class='col'><Fri9></div></div><div class='row'><div class='col bg timeCol'>10:00</div><div class='col'><Sun10></div><div class='col'><Mon10></div><div class='col'><Tue10></div><div class='col'><Wed10></div><div class='col'><Thu10></div><div class='col'><Fri10></div></div><div class='row'><div class='col bg timeCol'>11:00</div><div class='col'><Sun11></div><div class='col'><Mon11></div><div class='col'><Tue11></div><div class='col'><Wed11></div><div class='col'><Thu11></div><div class='col'><Fri11></div></div><div class='row'><div class='col bg timeCol'>12:00</div><div class='col'><Sun12></div><div class='col'><Mon12></div><div class='col'><Tue12></div><div class='col'><Wed12></div><div class='col'><Thu12></div><div class='col'><Fri12></div></div><div class='row'><div class='col bg timeCol'>13:00</div><div class='col'><Sun13></div><div class='col'><Mon13></div><div class='col'><Tue13></div><div class='col'><Wed13></div><div class='col'><Thu13></div><div class='col'><Fri13></div></div><div class='row'><div class='col bg timeCol'>14:00</div><div class='col'><Sun14></div><div class='col'><Mon14></div><div class='col'><Tue14></div><div class='col'><Wed14></div><div class='col'><Thu14></div><div class='col'><Fri14></div></div><div class='row'><div class='col bg timeCol'>15:00</div><div class='col'><Sun15></div><div class='col'><Mon15></div><div class='col'><Tue15></div><div class='col'><Wed15></div><div class='col'><Thu15></div><div class='col'><Fri15></div></div><div class='row'><div class='col bg timeCol'>16:00</div><div class='col'><Sun16></div><div class='col'><Mon16></div><div class='col'><Tue16></div><div class='col'><Wed16></div><div class='col'><Thu16></div><div class='col'><Fri16></div></div><div class='row'><div class='col bg timeCol'>17:00</div><div class='col'><Sun17></div><div class='col'><Mon17></div><div class='col'><Tue17></div><div class='col'><Wed17></div><div class='col'><Thu17></div><div class='col'><Fri17></div></div><div class='row'><div class='col bg timeCol'>18:00</div><div class='col'><Sun18></div><div class='col'><Mon18></div><div class='col'><Tue18></div><div class='col'><Wed18></div><div class='col'><Thu18></div><div class='col'><Fri18></div></div><div class='row'><div class='col bg timeCol'>19:00</div><div class='col'><Sun19></div><div class='col'><Mon19></div><div class='col'><Tue19></div><div class='col'><Wed19></div><div class='col'><Thu19></div><div class='col'><Fri19></div></div><div class='row'><div class='col bg timeCol'>20:00</div><div class='col'><Sun20></div><div class='col'><Mon20></div><div class='col'><Tue20></div><div class='col'><Wed20></div><div class='col'><Thu20></div><div class='col'><Fri20></div></div><div class='row'><div class='col bg timeCol'>21:00</div><div class='col'><Sun21></div><div class='col'><Mon21></div><div class='col'><Tue21></div><div class='col'><Wed21></div><div class='col'><Thu21></div><div class='col'><Fri21></div></div></div></body></html>";

           Display_str = Schedule_pattern;
    }

        public string fill()
        {
            if (Display_str == null)
                Display_str = Schedule_pattern;
           return Display_str;
        }

        public string clearTable()
        {
            Display_str = Schedule_pattern;
             return Display_str;
        }

        public bool buildEvent(string day, string eventTitle, string start, string end, string color)
        {
            if (start == "" || end == "")
                return false;

            string[] startTime = start.Split(':');
            string[] endtTime = end.Split(':');

            int startInt = Int32.Parse(startTime[0]);
            int endtInt = Int32.Parse(endtTime[0]);

            if (startInt >= endtInt)
                return false;

            addEvent(day, eventTitle, "", startInt, endtInt, color);
            return true;
        }

        public void addEvent(string day, string title, string teacher, int start, int end, string color)
        {
            string search_patern = "<" + day + start.ToString() + ">".Trim();
            string current = Display_str;
            int p = current.IndexOf(search_patern);

            if (p != -1)
            {
                string search_mark_begin = "<" + day + start.ToString() + "!>".Trim();
                string search_mark_end = "<" + day + start.ToString() + "*>".Trim();

                int height = (end - start) * 40;
                string event_pattern = search_mark_begin + "<div class='event' style='background-color:" + color + "; height:" + height + "px;'> <span class='title'>" + title + "</span><span class='desc'>" + teacher + "</span><span class='desc'>" + start + ":00 - " + end + ":00</span></div>" + search_mark_end;

                Display_str = Display_str.Replace(search_patern, event_pattern);
            }
        }
    }
}
