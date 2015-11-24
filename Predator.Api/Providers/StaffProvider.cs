using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Predator.Api.Models;
using MySql.Data.MySqlClient;
using Predator.Api.Utils;

namespace Predator.Api.Providers
{
    class StaffProvider
    {
        internal IEnumerable<Staff> RetrieveAllStaff()
        {
            var staff = new List<Staff>();
            var staffMember = new Staff();
            using (MySqlConnection conn = new MySqlConnection(PredatorConstants.CONNECTION_STRING))
            {
                if (MySqlConnectionManager.OpenConnection(conn))
                {
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM checkDB.`staff`", conn))
                    {

                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            staffMember = new Staff()
                            {
                                /*IdCheck = reader.GetInt32("idCheck"),
                                IdAccount = reader.GetInt32("idAccount"),
                                IdStore = reader.GetInt32("idStore"),
                                CheckNum = reader.GetInt32("checkNum"),
                                Amount = reader.GetFloat("amount"),
                                DateWritten = reader.GetDateTime("dateWritten"),
                                AmountPaid = (!reader.IsDBNull(reader.GetOrdinal("amountPaid"))) ? reader.GetFloat("amountPaid") : -1,
                                PaidDate = (!reader.IsDBNull(reader.GetOrdinal("paidDate"))) ? reader.GetDateTime("paidDate") : new DateTime(0)*/
                                idStaff = reader.GetInt32("idStaff"),
                                fName = reader.GetString("fName"),
                                lName = reader.GetString("lName"),
                                username = reader.GetString("username"),
                                password = reader.GetString("password"),
                                email = reader.GetString("email"),
                                accessLevel = reader.GetInt32("accessLevel"),
                                creationDate = reader.GetDateTime("creationDate")
                            };
                            staff.Add(staffMember);
                        }
                    }
                    MySqlConnectionManager.CloseConnection(conn);
                }
            }
            return staff;
        }

        internal Staff RetrieveSingleStaff(int id)
        {
            var staff = new Staff();
            using (MySqlConnection conn = new MySqlConnection(PredatorConstants.CONNECTION_STRING))
            {
                if (MySqlConnectionManager.OpenConnection(conn))
                {
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM checkDB.`staff` WHERE staff.idStaff = " + Convert.ToString(id), conn))
                    {

                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            staff = new Staff()
                            {
                                /*IdCheck = reader.GetInt32("idCheck"),
                                IdAccount = reader.GetInt32("idAccount"),
                                IdStore = reader.GetInt32("idStore"),
                                CheckNum = reader.GetInt32("checkNum"),
                                Amount = reader.GetFloat("amount"),
                                DateWritten = reader.GetDateTime("dateWritten"),
                                AmountPaid = (!reader.IsDBNull(reader.GetOrdinal("amountPaid"))) ? reader.GetFloat("amountPaid") : -1,
                                PaidDate = (!reader.IsDBNull(reader.GetOrdinal("paidDate"))) ? reader.GetDateTime("paidDate") : new DateTime(0)*/
                                idStaff = reader.GetInt32("idStaff"),
                                fName = reader.GetString("fName"),
                                lName = reader.GetString("lName"),
                                username = reader.GetString("username"),
                                password = reader.GetString("password"),
                                email = reader.GetString("email"),
                                accessLevel = reader.GetInt32("accessLevel"),
                                creationDate = reader.GetDateTime("creationDate")
                            };
                        }
                    }
                    MySqlConnectionManager.CloseConnection(conn);
                }
            }
            return staff;
        }

        internal void CreateStaff(Staff staff)
        {
            using (MySqlConnection conn = new MySqlConnection(PredatorConstants.CONNECTION_STRING))
            {
                if (MySqlConnectionManager.OpenConnection(conn))
                {
                    string commandText =
@"INSERT INTO staff (fName, lName, username, password, email, accessLevel, creationDate)
VALUES(@FNAME, @LNAME, @USERNAME, @PASSWORD, @EMAIL, @ACCESSLEVEL, @CREATIONDATE)";
                    MySqlCommand command = new MySqlCommand(commandText, conn);
                    command.Parameters.Add("@FNAME", MySqlDbType.VarChar); ;
                    command.Parameters["@FNAME"].Value = staff.fName;
                    command.Parameters.Add("@LNAME", MySqlDbType.VarChar);
                    command.Parameters["@LNAME"].Value = staff.lName;
                    command.Parameters.Add("@USERNAME", MySqlDbType.VarChar);
                    command.Parameters["@USERNAME"].Value = staff.username;
                    command.Parameters.Add("@PASSWORD", MySqlDbType.VarChar);
                    command.Parameters["@PASSWORD"].Value = staff.password;
                    command.Parameters.Add("@EMAIL", MySqlDbType.VarChar);
                    command.Parameters["@EMAIL"].Value = staff.email;
                    command.Parameters.Add("@ACCESSLEVEL", MySqlDbType.Int32);
                    command.Parameters["@ACCESSLEVEL"].Value = staff.accessLevel;
                    command.Parameters.Add("@CREATIONDATE", MySqlDbType.DateTime);
                    command.Parameters["@CREATIONDATE"].Value = staff.creationDate;
                    command.ExecuteNonQuery();
                    MySqlConnectionManager.CloseConnection(conn);
                }
            }
        }

        internal void UpdateStaff(int id, Staff staff)
        {
            using (MySqlConnection conn = new MySqlConnection(PredatorConstants.CONNECTION_STRING))
            {
                if (MySqlConnectionManager.OpenConnection(conn))
                {
                    string commandText =
@"UPDATE staff
SET fName=@FNAME, lName=@LNAME, username=@USERNAME, password=@PASSWORD, email=@EMAIL, accessLevel=@ACCESSLEVEL
WHERE staffId=@STAFFID";
                    MySqlCommand command = new MySqlCommand(commandText, conn);
                    command.Parameters.Add("@FNAME", MySqlDbType.VarChar); ;
                    command.Parameters["@FNAME"].Value = staff.fName;
                    command.Parameters.Add("@LNAME", MySqlDbType.VarChar);
                    command.Parameters["@LNAME"].Value = staff.lName;
                    command.Parameters.Add("@USERNAME", MySqlDbType.VarChar);
                    command.Parameters["@USERNAME"].Value = staff.username;
                    command.Parameters.Add("@PASSWORD", MySqlDbType.VarChar);
                    command.Parameters["@PASSWORD"].Value = staff.password;
                    command.Parameters.Add("@EMAIL", MySqlDbType.VarChar);
                    command.Parameters["@EMAIL"].Value = staff.email;
                    command.Parameters.Add("@ACCESSLEVEL", MySqlDbType.Int32);
                    command.Parameters["@ACCESSLEVEL"].Value = staff.accessLevel;
                    command.Parameters.Add("@STAFFID", MySqlDbType.Int32);
                    command.Parameters["@STAFFID"].Value = id;
                    command.ExecuteNonQuery();
                    MySqlConnectionManager.CloseConnection(conn);
                }
            }
        }

        internal void DeleteStaff(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(PredatorConstants.CONNECTION_STRING))
            {
                if (MySqlConnectionManager.OpenConnection(conn))
                {
                    using (MySqlCommand command = new MySqlCommand("DELETE FROM checkDB.`staff` WHERE staff.idStaff = " + Convert.ToString(id), conn))
                    {
                        command.ExecuteNonQuery();
                    }
                    MySqlConnectionManager.CloseConnection(conn);
                }
            }
        }
    }
}
