using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Predator.Api.Models;
using Predator.Api.Utils;
using MySql.Data.MySqlClient;

namespace Predator.Api.Providers
{
    class CheckDisplayRowProvider
    {
        internal void CreateCheckDisplayRow(CheckDisplayRow row)
        {
            using (MySqlConnection conn = new MySqlConnection(PredatorConstants.CONNECTION_STRING))
            {
                if (MySqlConnectionManager.OpenConnection(conn))
                {
                    string commandtext = "";
                    using (MySqlCommand command = new MySqlCommand(commandtext, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                    MySqlConnectionManager.CloseConnection(conn);
                }
            }
        }

        internal CheckDisplayRow RetrieveSingleCheckDisplayRow(int id)
        {
            CheckDisplayRow row = null;
            using (MySqlConnection conn = new MySqlConnection(PredatorConstants.CONNECTION_STRING))
            {
                if (MySqlConnectionManager.OpenConnection(conn))
                {
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM checkdb.checkdisplayrow WHERE idCheck=" + Convert.ToString(id), conn))
                    {

                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            row = new CheckDisplayRow()
                            {
                                idCheck = reader.GetInt32("idCheck"),
                                idAccount = reader.GetInt32("idAccount"),
                                idStore = reader.GetInt32("idStore"),
                                checkNum = reader.GetInt32("checkNum"),
                                amount = reader.GetFloat("amount"),
                                dateWritten = reader.GetDateTime("dateWritten"),
                                //amountPaid = reader.GetFloat("amountPaid"),//nullable
                                //paidDate = reader.GetDateTime("paidDate"),//nullable
                                amountPaid = (!reader.IsDBNull(reader.GetOrdinal("amountPaid"))) ? reader.GetFloat("amountPaid") : -1,
                                paidDate = (!reader.IsDBNull(reader.GetOrdinal("paidDate"))) ? reader.GetDateTime("paidDate") : new DateTime(0),
                                routingNum = reader.GetInt32("routingNum"),
                                accountNum = reader.GetInt32("accountNum"),
                                fName = reader.GetString("fName"),
                                lName = reader.GetString("lName"),
                                //fName2 = reader.GetString("fName2"),//nullable
                                //lName2 = reader.GetString("lName2"),//
                                fName2 = (!reader.IsDBNull(reader.GetOrdinal("fName2"))) ? reader.GetString("fName2") : "",
                                lName2 = (!reader.IsDBNull(reader.GetOrdinal("lName2"))) ? reader.GetString("lName2") : "",
                                address = reader.GetString("address"),
                                city = reader.GetString("city"),
                                state = reader.GetString("state"),
                                zipcode = reader.GetInt32("zipcode"),
                                //phoneNum = reader.GetString("phoneNum"),//nullable
                                phoneNum = (!reader.IsDBNull(reader.GetOrdinal("phoneNum"))) ? reader.GetString("phoneNum") : "",
                                bName = reader.GetString("bName"),
                                bAddress = reader.GetString("bAddress"),
                                bCity = reader.GetString("bCity"),
                                bState = reader.GetString("bState"),
                                bZipcode = reader.GetInt32("bZipcode"),
                                idStoreGroup = reader.GetInt32("idStoreGroup"),
                                sName = reader.GetString("sName"),
                                sAddress = reader.GetString("sAddress"),
                                sCity = reader.GetString("sCity"),
                                sState = reader.GetString("sState"),
                                sZipcode = reader.GetInt32("sZipcode")
                            };
                        }
                    }
                    MySqlConnectionManager.CloseConnection(conn);
                }
            }
            return row;
        }

        internal IEnumerable<CheckDisplayRow> RetrieveAllCheckDisplayRows()
        {
            List<CheckDisplayRow> rows = new List<CheckDisplayRow>();
            CheckDisplayRow row = null;
            using (MySqlConnection conn = new MySqlConnection(PredatorConstants.CONNECTION_STRING))
            {
                if (MySqlConnectionManager.OpenConnection(conn))
                {
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM checkdb.checkdisplayrow", conn))
                    {

                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            row = new CheckDisplayRow()
                            {
                                idCheck = reader.GetInt32("idCheck"),
                                idAccount = reader.GetInt32("idAccount"),
                                idStore = reader.GetInt32("idStore"),
                                checkNum = reader.GetInt32("checkNum"),
                                amount = reader.GetFloat("amount"),
                                dateWritten = reader.GetDateTime("dateWritten"),
                                //amountPaid = reader.GetFloat("amountPaid"),//nullable
                                //paidDate = reader.GetDateTime("paidDate"),//nullable
                                amountPaid = (!reader.IsDBNull(reader.GetOrdinal("amountPaid"))) ? reader.GetFloat("amountPaid") : -1,
                                paidDate = (!reader.IsDBNull(reader.GetOrdinal("paidDate"))) ? reader.GetDateTime("paidDate") : new DateTime(0),
                                routingNum = reader.GetInt32("routingNum"),
                                accountNum = reader.GetInt32("accountNum"),
                                fName = reader.GetString("fName"),
                                lName = reader.GetString("lName"),
                                //fName2 = reader.GetString("fName2"),//nullable
                                //lName2 = reader.GetString("lName2"),//
                                fName2 = (!reader.IsDBNull(reader.GetOrdinal("fName2"))) ? reader.GetString("fName2") : "",
                                lName2 = (!reader.IsDBNull(reader.GetOrdinal("lName2"))) ? reader.GetString("lName2") : "",
                                address = reader.GetString("address"),
                                city = reader.GetString("city"),
                                state = reader.GetString("state"),
                                zipcode = reader.GetInt32("zipcode"),
                                //phoneNum = reader.GetString("phoneNum"),//nullable
                                phoneNum = (!reader.IsDBNull(reader.GetOrdinal("phoneNum"))) ? reader.GetString("phoneNum") : "",
                                bName = reader.GetString("bName"),
                                bAddress = reader.GetString("bAddress"),
                                bCity = reader.GetString("bCity"),
                                bState = reader.GetString("bState"),
                                bZipcode = reader.GetInt32("bZipcode"),
                                idStoreGroup = reader.GetInt32("idStoreGroup"),
                                sName = reader.GetString("sName"),
                                sAddress = reader.GetString("sAddress"),
                                sCity = reader.GetString("sCity"),
                                sState = reader.GetString("sState"),
                                sZipcode = reader.GetInt32("sZipcode")
                            };
                            rows.Add(row);
                        }
                    }
                    MySqlConnectionManager.CloseConnection(conn);
                }
            }
            return rows;
        }

        internal void UpdateCheckDisplayRow(int id, CheckDisplayRow row)
        {
            using (MySqlConnection conn = new MySqlConnection(PredatorConstants.CONNECTION_STRING))
            {
                if (MySqlConnectionManager.OpenConnection(conn))
                {
                    string commandText =
@"UPDATE staff
SET idAccount=@IDACCOUNT, idStore=@IDSTORE, checkNum=@CHECKNUM, amount=@AMOUNT, dateWritten=@DATEWRITTEN,{AMOUNTPAID}{PAIDDATE} routingNum=@ROUTINGNUM,
accountNum=@ACCOUNTNUM, fName=@FNAME, lName=@LNAME,{FNAME2}{LNAME2} address=@ADDRESS, city=@CITY, state=@STATE, zipcode=@ZIPCODE,{PHONENUM} bName=@BNAME,
bAddress=@BADDRESS, bCity=@BCITY, bState=@BSTATE, bZipcode=@BZIPCODE, idStoreGroup=@IDSTOREGROUP, sName=@SNAME, sAddress=SADDRESS, sCity=@SCITY, sState=@SSTATE,
sZipcode=@SZIPCODE
WHERE idCheck=@IDCHECK";
                    MySqlCommand command = new MySqlCommand(commandText, conn);

                    command.ExecuteNonQuery();
                    MySqlConnectionManager.CloseConnection(conn);
                }
            }
        }

        //This essentially deletes a single row
        internal void DeleteCheckDisplayRow(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(PredatorConstants.CONNECTION_STRING))
            {
                if (MySqlConnectionManager.OpenConnection(conn))
                {
                    using (MySqlCommand command = new MySqlCommand("DELETE FROM checkDB.`chekue` WHERE idCheck = " + Convert.ToString(id), conn))
                    {
                        command.ExecuteNonQuery();
                    }
                    MySqlConnectionManager.CloseConnection(conn);
                }
            }
        }
    }
}
