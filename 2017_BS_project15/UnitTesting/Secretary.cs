using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using _2017_BS_Project;
using _2017_BS_Project.forms.lists;
using _2017_BS_Project.tools;

namespace UnitTesting
{
    [TestClass]
    public class Secretary
    {
        [TestMethod]
        public void TestAddDepartments()
        {
            var f = new DepartmentList();
            f.addDepartment("Biologia");
            Assert.IsTrue(GlobalItems.checkItemsInDB("departments", "name", "Biologia"));
        }

        [TestMethod]
        public void TestDeleteDepartments()
        {
            var f = new DepartmentList();
            int id = GlobalItems.getKey("departments", "name", "Biologia");
            if (id > 0)
            {
                f.delete_department(id.ToString());
                Assert.IsFalse(GlobalItems.checkItemsInDB("departments", "name", "Biologia"));
            }
        }


        [TestMethod]
        public void TestAddCourse()
        {
            var f = new CourseList();
            f.addCourse("Test", 10, 50, 0, 0, 0, 0, 0, 0, 0, "Description");
            Assert.IsTrue(GlobalItems.checkItemsInDB("course", "name", "Test"));
        }

        [TestMethod]
        public void TestDeleteCourse()
        {
            var f = new CourseList();
            int id = GlobalItems.getKey("course", "name", "Test");
            if (id > 0)
            {
                f.DeleteCourse(id.ToString());
                Assert.IsFalse(GlobalItems.checkItemsInDB("course", "name", "Test"));
            }
        }


        [TestMethod]
        public void TestAddClass()
        {
            var f = new ClassList();
            f.addClass("Z100", "40", "0", 0, 0);
            Assert.IsTrue(GlobalItems.checkItemsInDB("classes", "name", "Z100"));
        }

        [TestMethod]
        public void TestDeleteClass()
        {
            var f = new ClassList();
            int id = GlobalItems.getKey("classes", "name", "Z100");
            if (id > 0)
            {
                f.deleteClass(id.ToString());
                Assert.IsFalse(GlobalItems.checkItemsInDB("classes", "name", "Z100"));
            }
        }

        [TestMethod]
        public void TestAddTeacher()
        {
            var f = new TeacherList();
            f.addTeacher("ZRob", "Rob", "rob@rob.com", "1111", "123456789", 3);
            Assert.IsTrue(GlobalItems.checkItemsInDB("users", "fname", "ZRob"));
        }

        [TestMethod]
        public void TestDeleteTeacher()
        {
            var f = new TeacherList();
            string id = GlobalItems.getIdNumber("users", "fname", "ZRob");
                f.deleteTeacher(id);
                Assert.IsFalse(GlobalItems.checkItemsInDB("users", "fname", "ZRob"));
            
        }


        [TestMethod]
        public void TestAddTutor()
        {
            var f = new TutorList();
            f.addTutor("ZRob2", "Rob", "rob@rob.com", "1111", "123456789", 3);
            Assert.IsTrue(GlobalItems.checkItemsInDB("users", "fname", "ZRob2"));
        }

        [TestMethod]
        public void TestDeleteTutor()
        {
            var f = new TutorList();
            string id = GlobalItems.getIdNumber("users", "fname", "ZRob2");
           
                f.deleteTutor(id.ToString());
                Assert.IsFalse(GlobalItems.checkItemsInDB("users", "fname", "ZRob2"));
            
        }

        [TestMethod]
        public void Login()
        {
            
            bool res = GlobalItems.Login("3333", "12345");
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void LoginWrong()
        {
            bool res = GlobalItems.Login("33657433", "15352345");
            Assert.IsFalse(res);
        }


        //[TestMethod]
        //public void TestAddStudent()
        //{
        //    var f = new StudentList();
        //    f.addStudent("ZRob3", "Rob", "rob@rob.com", "1111", "123456789", 3);
        //    Assert.IsTrue(GlobalItems.checkItemsInDB("users", "fname", "ZRob3"));
        //}

        //[TestMethod]
        //public void TestDeleteStudent()
        //{
        //    var f = new StudentList();
        //    string id = GlobalItems.getIdNumber("users", "fname", "ZRob3");

        //        f.deleteStudent(id.ToString());
        //        Assert.IsFalse(GlobalItems.checkItemsInDB("users", "fname", "ZRob3"));

        //}

    }
}
