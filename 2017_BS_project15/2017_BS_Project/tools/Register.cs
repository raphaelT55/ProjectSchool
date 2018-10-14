using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2017_BS_Project.tools
{
    class Register
    {
        /*receive password and check his complexity return true if:
         * least upper
         * least one digit
         * long big than 7
         * else return false
        */
        public static bool CheckPassword(string password)
        {
            int count = 0;

            if (password.Length < 8)
            {

                return false;
            }
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 'A' && password[i] <= 'Z')
                    count++;
            }
            if (count == 0)
            {

                return false;
            }
            count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= '0' && password[i] <= '9')
                    count++;
            }
            if (count == 0)
            {

                return false;
            }
            return true;
        }
        // check if string is empty or not if yes return true if not return false
        public static bool CheckFieldEmpty(string message)
        {

            if (message == "")
            {
                return true;
            }

            return false;
        }
        // check if mail is proper(takin)
        public static bool CheckMail(string mail)
        {

            if (mail.Contains("@") == true)
            {
                return true;
            }

            return false;
        }
        // receives field Id, 
        // if Id is type int and if length of Id == 9 return true else return false
        public static bool CheckId(string Id)
        {

            int j = 0;
            if (Id.Length != 9)
                return false;
            if (Int32.TryParse(Id, out j) == false)
                return false;

            return true;

        }
        // receives 2 password
        // if they are identical return true else false
        public static bool CheckSamePassword(string password1, string password2)
        {
            if (password1 == password2)
                return true;
            return false;
        }

        //public static bool AccountExist(string Id)
        //{
        //    return DataBase.CheckIdExistence(Id);

        //}
    }
}
