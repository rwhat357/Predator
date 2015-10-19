using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Predator.Api.Utils;

namespace Predator.Api.Utils
{
    class MySqlConnectionManager
    {
        public static bool OpenConnection(MySqlConnection connection)
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Logger.Instance.WriteToLog("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Logger.Instance.WriteToLog("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public static bool CloseConnection(MySqlConnection connection)
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Logger.Instance.WriteToLog(ex.Message);
                return false;
            }
        }
    }
}
