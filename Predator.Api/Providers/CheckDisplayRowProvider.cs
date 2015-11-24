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
                    string commandtext = "CALL CreateCheck(@STORENUM,@BANKNAME,@RNUM,@ANUM,@CNUM,@FIRSTNAME,@LASTNAME,@FIRSTNAME2,@LASTNAME2,@INADDRESS,@INCITY,@INSTATE,@INZIPCODE,@PHONE,@CHECKAMOUNT,@CHECKDATE)";
                    using (MySqlCommand command = new MySqlCommand(commandtext, conn))
                    {
                        command.Parameters.Add("@STORENUM", MySqlDbType.Int32);
                        command.Parameters["@STORENUM"].Value = row.idStore;
                        command.Parameters.Add("@BANKNAME", MySqlDbType.VarChar);
                        command.Parameters["@BANKNAME"].Value = row.bName;
                        command.Parameters.Add("@ANUM", MySqlDbType.Int32);
                        command.Parameters["@ANUM"].Value = row.idAccount;
                        command.Parameters.Add("@RNUM", MySqlDbType.Int32);
                        command.Parameters["@RNUM"].Value = row.routingNum;
                        command.Parameters.Add("@CNUM", MySqlDbType.Int32);
                        command.Parameters["@CNUM"].Value = row.checkNum;
                        command.Parameters.Add("@FIRSTNAME", MySqlDbType.VarChar);
                        command.Parameters["@FIRSTNAME"].Value = row.fName;
                        command.Parameters.Add("@LASTNAME", MySqlDbType.VarChar);
                        command.Parameters["@LASTNAME"].Value = row.lName;
                        command.Parameters.Add("@FIRSTNAME2", MySqlDbType.VarChar);
                        command.Parameters["@FIRSTNAME2"].Value = (row.fName2 != null && row.fName2 != "") ? row.fName2 : null;
                        command.Parameters.Add("@LASTNAME2", MySqlDbType.VarChar);
                        command.Parameters["@LASTNAME2"].Value = (row.lName2 != null && row.lName2 != "") ? row.lName2 : null; 
                        command.Parameters.Add("@INADDRESS", MySqlDbType.VarChar);
                        command.Parameters["@INADDRESS"].Value = row.address;
                        command.Parameters.Add("@INCITY", MySqlDbType.VarChar);
                        command.Parameters["@INCITY"].Value = row.city;
                        command.Parameters.Add("@INSTATE", MySqlDbType.VarChar);
                        command.Parameters["@INSTATE"].Value = row.state;
                        command.Parameters.Add("@INZIPCODE", MySqlDbType.Int32);
                        command.Parameters["@INZIPCODE"].Value = row.zipcode;
                        command.Parameters.Add("@PHONE", MySqlDbType.VarChar);
                        command.Parameters["@PHONE"].Value = (row.phoneNum != null && row.phoneNum != "") ? row.phoneNum : null;
                        command.Parameters.Add("@CHECKAMOUNT", MySqlDbType.Float);
                        command.Parameters["@CHECKAMOUNT"].Value = row.amount;
                        command.Parameters.Add("@CHECKDATE", MySqlDbType.DateTime);
                        command.Parameters["@CHECKDATE"].Value = row.dateWritten;
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
@"UPDATE chekue
SET idAccount=@IDACCOUNT, idStore=@IDSTORE, checkNum=@CHECKNUM, amount=@AMOUNT, dateWritten=@DATEWRITTEN{AMOUNTPAID}{PAIDDATE}
WHERE idCheck=@IDCHECK";
                    if(row.amountPaid != -1)
                    {
                        commandText = commandText.Replace("{AMOUNTPAID}", ", amountPaid=@AMOUNTPAID");
                    }
                    else
                    {
                        commandText = commandText.Replace("{AMOUNTPAID}", "");
                    }
                    if(row.paidDate != null && row.paidDate != new DateTime(0))
                    {
                        commandText = commandText.Replace("{PAIDDATE}", ", paidDate=@PAIDDATE");
                    }
                    else
                    {
                        commandText = commandText.Replace("{PAIDDATE}", "");
                    }
                    MySqlCommand command = new MySqlCommand(commandText, conn);
                    //add and set all the parameters here.  Some hefty crying must first occur before I implement this....
                    if(row.amountPaid != -1)
                    {
                        command.Parameters.Add("@AMOUNTPAID", MySqlDbType.Float);
                        command.Parameters["@AMOUNTPAID"].Value = row.amountPaid;
                    }
                    if(row.paidDate != null && row.paidDate != new DateTime(0))
                    {
                        command.Parameters.Add("@PAIDDATE", MySqlDbType.DateTime);
                        command.Parameters["@PAIDDATE"].Value = row.paidDate;
                    }
                    command.Parameters.Add("@IDACCOUNT", MySqlDbType.Int32);
                    command.Parameters["@IDACCOUNT"].Value = row.idAccount;
                    command.Parameters.Add("@IDSTORE", MySqlDbType.Int32);
                    command.Parameters["@IDSTORE"].Value = row.idStore;
                    command.Parameters.Add("@CHECKNUM", MySqlDbType.Int32);
                    command.Parameters["@CHECKNUM"].Value = row.checkNum;
                    command.Parameters.Add("@AMOUNT", MySqlDbType.Float);
                    command.Parameters["@AMOUNT"].Value = row.amount;
                    command.Parameters.Add("@DATEWRITTEN", MySqlDbType.DateTime);
                    command.Parameters["@DATEWRITTEN"].Value = row.dateWritten;
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
