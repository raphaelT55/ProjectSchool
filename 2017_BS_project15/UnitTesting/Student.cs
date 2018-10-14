using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using _2017_BS_Project;
using _2017_BS_Project.forms.lists;
using _2017_BS_Project.tools;
using _2017_BS_Project.forms;
using System.Windows.Forms;
using System.Collections.Generic;

namespace UnitTesting
{
    [TestClass]
    public class Student
    {
       [TestMethod]
       public void getHollidays()
        {
            StudentWin obj = new StudentWin();
            Panel obj2 = null;

            List<Control> list = new List<Control>();
            GlobalItems.GetAllControl(obj, list);
            foreach (Control control in list)
            {
                if (control.GetType() == typeof(Panel)&&  control.Name == "hollidaysPanel") { obj2 = new Panel(); }
            }

            Assert.IsNotNull(obj2);
        }


        [TestMethod]
        public void getRequest()
        {
            StudentWin obj = new StudentWin();
            Panel obj2 = null;

            List<Control> list = new List<Control>();
            GlobalItems.GetAllControl(obj, list);
            foreach (Control control in list)
            {
                if (control.GetType() == typeof(Panel) && control.Name == "requestPanel") { obj2 = new Panel(); }
            }

            Assert.IsNotNull(obj2);
        }

        [TestMethod]
        public void getCourses()
        {
            StudentWin obj = new StudentWin();
            Panel obj2 = null;

            List<Control> list = new List<Control>();
            GlobalItems.GetAllControl(obj, list);
            foreach (Control control in list)
            {
                if (control.GetType() == typeof(Panel) && control.Name == "coursesPanel") { obj2 = new Panel(); }
            }

            Assert.IsNotNull(obj2);
        }

        [TestMethod]
        public void getInfo()
        {
            StudentWin obj = new StudentWin();
            Panel obj2 = null;

            List<Control> list = new List<Control>();
            GlobalItems.GetAllControl(obj, list);
            foreach (Control control in list)
            {
                if (control.GetType() == typeof(Panel) && control.Name == "myInfoPanel") { obj2 = new Panel(); }
            }

            Assert.IsNotNull(obj2);
        }

        [TestMethod]
        public void LoadSchedule()
        {
            int key = GlobalItems.getKey("users", "fname", "Dunkan");
            StudentWin obj = new StudentWin();
                obj.ScheduleLoad(key);
            Assert.IsNotNull(key);
        }

    }
}
