using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Predator.Api.Models;
using MySql.Data.MySqlClient;
using Predator.Api.Utils;

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
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                if (MySqlConnectionManager.OpenConnection(conn))
                {
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM checkDB.`chekue`", conn))
                    {

                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            checks.Add(new Check()
                            {
                                IdCheck = reader.GetInt32("idCheck"),
                                IdAccount = reader.GetInt32("idAccount"),
                                IdStore = reader.GetInt32("idStore"),
                                CheckNum = reader.GetInt32("checkNum"),
                                Amount = reader.GetFloat("amount"),
                                DateWritten = reader.GetDateTime("dateWritten"),
                                AmountPaid = (!reader.IsDBNull(reader.GetOrdinal("amountPaid"))) ? reader.GetFloat("amountPaid") : -1,
                                PaidDate = (!reader.IsDBNull(reader.GetOrdinal("paidDate"))) ? reader.GetDateTime("paidDate") : new DateTime(0)
                            });
                        }
                    }
                    MySqlConnectionManager.CloseConnection(conn);
                }
            }

            return checks;
        }

        // RETURNS: One check that matches the given <id>
        internal Check GetCheck(int id)
        {
            var check = new Check();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                if (MySqlConnectionManager.OpenConnection(conn))
                {
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM checkDB.`chekue` AS checks WHERE checks.idCheck = " + Convert.ToString(id), conn))
                    {

                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            check = new Check()
                            {
                                IdCheck = reader.GetInt32("idCheck"),
                                IdAccount = reader.GetInt32("idAccount"),
                                IdStore = reader.GetInt32("idStore"),
                                CheckNum = reader.GetInt32("checkNum"),
                                Amount = reader.GetFloat("amount"),
                                DateWritten = reader.GetDateTime("dateWritten"),
                                AmountPaid = (!reader.IsDBNull(reader.GetOrdinal("amountPaid"))) ? reader.GetFloat("amountPaid") : -1,
                                PaidDate = (!reader.IsDBNull(reader.GetOrdinal("paidDate"))) ? reader.GetDateTime("paidDate") : new DateTime(0)
                            };
                        }
                    }
                    MySqlConnectionManager.CloseConnection(conn);
                }
            }
            return check;
        }

        // FUNCTION: Adds a new check to the database
        // RETURNS: Returns the check added to confirm that it was added
        internal Check AddCheck(Check check)
        {
            string commandstring = "INSERT INTO checkDB.`chekue` AS checks (idCheck, idAccount, idStore, checkNum, amount, dateWritten) VALUES ({VALUESTRING})";
            string valuestring = "" + check.IdCheck + "," + check.IdAccount + "," + check.IdStore + "," + check.CheckNum + "," + check.Amount + "," + check.DateWritten.ToString("yyyy-MM-dd");
            commandstring = commandstring.Replace("{VALUESTRING}", valuestring);
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                if (MySqlConnectionManager.OpenConnection(conn))
                {
                    using (MySqlCommand command = new MySqlCommand(commandstring, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                    MySqlConnectionManager.CloseConnection(conn);
                }
            }
            return check;
        }

        internal void DeleteCheck(int id)
        {
            throw new NotImplementedException();
        }
    }
}

