using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Predator.Api.Models;
using MySql.Data.MySqlClient;

namespace Predator.Api.Providers
{
    public class CheckProvider
    {
        //readonly string _connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        //hardcoded connection string for the moment, used for connecting to the mysql server located at localhost, with the creds supplied in the server info doc
        readonly string _connectionString = "SERVER=localhost;DATABASE=checkDB;UID=koopa;PASSWORD=koopa1234;";

        internal List<Check> GetAll()
        {
            var checks = new List<Check>();
            MySqlConnection conn = new MySqlConnection(_connectionString);

            //using (var con = new SqlConnection(_connetionString))
            //{
            //    con.Open();

            //    using (var command = new SqlCommand("SELECT * FROM Pr_Checks", con))
            //    {
            //        var reader = command.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            checks.Add(
            //                new Check()
            //              {
            //                     Id = reader.GetInt32(0),
            //                     CheckNum = reader.GetString(1),
            //                     AccountNum = reader.GetString(2),
            //                     RoutingNum = reader.GetString(3),
            //                     Amount = reader.GetDecimal(4),
            //                     CheckDate = reader.GetDateTime(5),
            //                     StoreId = reader.GetInt32(6),
            //                     CashierId = reader.GetInt32(7),
            //                     OffenseLevel = reader.GetInt32(8)
            //                });
            //        }
            //    }
            //}

            return checks;
        }
        
        // RETURNS: One check that matches the given <id>
        internal Check GetCheck(int id)
        {
            var check = new Check
            {
                Id = id,
                CheckNum = "3",
                AccountNum = "6666666666666",
                RoutingNum = "234324243",
                Amount = new Decimal(445.00),
                CheckDate = new DateTime(),
                StoreId = 1,
                CashierId = 40,
                OffenseLevel = 1
            };

            return check;
            //var check = new Check();
            //using (var con = new SqlConnection(_connetionString))
            //{
            //    con.Open();

            //    using (var command = new SqlCommand("SELECT * FROM Pr_Checks ", con))
            //    {
            //        var reader = command.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            checks.Add(
            //                new Check()
            //                {
            //                    Id = reader.GetInt32(0),
            //                    CheckNum = reader.GetString(1),
            //                    AccountNum = reader.GetString(2),
            //                    RoutingNum = reader.GetString(3),
            //                    Amount = reader.GetDecimal(4),
            //                    CheckDate = reader.GetDateTime(5),
            //                    StoreId = reader.GetInt32(6),
            //                    CashierId = reader.GetInt32(7),
            //                    OffenseLevel = reader.GetInt32(8)
            //                });
            //        }
            //    }
            //}

            //return checks;
        }

        // FUNCTION: Adds a new check to the database
        // RETURNS: Returns the check added to confirm that it was added
        internal Check AddCheck(Check check)
        {
            check = new Check
            {
                Id = check.Id,
                CheckNum = "3",
                AccountNum = "6666666666666",
                RoutingNum = "234324243",
                Amount = new Decimal(445.00),
                CheckDate = new DateTime(),
                StoreId = 1,
                CashierId = 40,
                OffenseLevel = 1
            };

            return check;
        }

        private static bool OpenConnection(MySqlConnection conn)
        {
            try
            {
                conn.Open();
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
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
    }
}

