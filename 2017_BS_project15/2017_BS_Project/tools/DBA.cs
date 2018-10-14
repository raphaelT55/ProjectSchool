using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace _2017_BS_Project
{
    public class DBA
    {
        private string strConn = null;
        private SqlConnection connection = null;

        public SqlConnection getConnection() { return connection; }

        // DBA singelton implementation
        private static DBA instance;
        private DBA() { }

        public static DBA Instance {
            get {
                if (instance == null)
                { instance = new DBA(); }
                return instance;
            }
        }

        public string getConnStr()
        {
            return strConn;
        }

        public bool connect() {
            strConn = "Server = tcp:bsproject2017.database.windows.net,1433; Initial Catalog = proj; Persist Security Info = False; User ID = bsproject; Password = Admin159; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

            connection = new SqlConnection(strConn);
            if (connection != null) return true;
            return false;
        }

        public bool query(String sql)
        {
            try
            {
                connection.Open();
                SqlCommand insertCommand = new SqlCommand("", getConnection());
                insertCommand.CommandType = CommandType.Text;
                insertCommand.CommandText = sql;
                int newrows = insertCommand.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

    }
}
