using System.Data;
using MySql.Data.MySqlClient;
namespace CRUD.Controller
{
  public class MySQL
    {
        static readonly string DatabaseServer = Properties.Settings.Default.Database;
        static readonly string MySQLPort = Properties.Settings.Default.Port;
        static readonly string Database = Properties.Settings.Default.Database;
        static readonly string UserID = Properties.Settings.Default.UserID;
        static readonly string Password = Properties.Settings.Default.Password;


        //static readonly string ConnectionString = "Server=" + DatabaseServer + ";Port=" + MySQLPort + ";Database=" + Database + ";user id=" + UserID + ";password=" + Password + " ; Connection Reset=true; SslMode=None; AllowPublicKeyRetrieval=True; Convert Zero Datetime=True";
        static readonly string ConnectionString = "Server=127.0.0.1;Port=8000;Database=crud;user id=root;password=vincemgrm;" +
            "Connection Reset=true;SslMode=None;AllowPublicKeyRetrieval=True;Convert Zero Datetime=True";


        public static bool IsConnected()
        {        

            MySqlConnection cnnDBConnection = new MySqlConnection(ConnectionString);
            try
            {
                cnnDBConnection.Open();
                cnnDBConnection.Dispose();
                return true;
            }
            catch
            {
                cnnDBConnection.Dispose();
                return false;
            }
    
        }
        public static void Push(string SQLStatement)
        {
            MySqlConnection xSqlConnection = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = SQLStatement,
                Connection = xSqlConnection
            };
            xSqlConnection.Open();
            cmd.ExecuteNonQuery();
            xSqlConnection.Close();
            cmd.Dispose();
        }
        public static DataTable Pull(string SQLStatement)
        {
            using (MySqlConnection SQLConn = new MySqlConnection(ConnectionString))
            {
                MySqlDataAdapter SqlDA = new MySqlDataAdapter();
                DataTable d = new DataTable();
                SQLConn.Open();
                try
                {
                    SqlDA.SelectCommand = new MySqlCommand(SQLStatement, SQLConn);
                    SqlDA.Fill(d);
                }
                catch { }
                SQLConn.Close();
                SqlDA.Dispose();
                d.Dispose();
                return d;
            }

        }
        public static int GetCount(string SQLStatement)
        {
            MySqlConnection SQLConn = new MySqlConnection(ConnectionString);
            MySqlDataAdapter SqlDA = new MySqlDataAdapter();
            DataSet myDataSet = new DataSet();
            SQLConn.Open();
            try
            {
                SqlDA.SelectCommand = new MySqlCommand(SQLStatement, SQLConn);
                SqlDA.Fill(myDataSet);
            }
            catch { }
            SQLConn.Close();
            SqlDA.Dispose();
            myDataSet.Dispose();
            return myDataSet.Tables[0].Rows.Count;
        }
       
    }
}
