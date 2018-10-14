using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2017_BS_Project.forms;
using _2017_BS_Project.tools;
using _2017_BS_Project.forms.lists;

//using _2017_BS_Project.forms.lists;

namespace _2017_BS_Project
{

    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            // start
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(startFrom.Instance);
           //Application.Run(new ScheduleForm());
        }
    }
}
