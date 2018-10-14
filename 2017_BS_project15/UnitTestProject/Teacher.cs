using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using _2017_BS_Project;
using _2017_BS_Project.tools;
using _2017_BS_Project.users;
using _2017_BS_Project.forms;
using _2017_BS_Project.forms.lists;

namespace UnitTestProject
{
    [TestClass]
    public class Teacher
    {


        [TestMethod]
        public void TestLoginTrue()
        {
            Assert.AreEqual(GlobalItems.Login("3333", "12345"), true);

        }
    }
}
