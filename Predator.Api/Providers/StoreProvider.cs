using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Predator.Api.Utils;
using MySql.Data.MySqlClient;
using Predator.Api.Models;

namespace Predator.Api.Providers
{
    public class StoreProvider
    {

        //readonly string _connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        //hardcoded connection string for the moment, used for connecting to the mysql server located at localhost, with the creds supplied in the server info doc
        private readonly string _connectionString = "SERVER=localhost;DATABASE=checkDB;UID=koopa;PASSWORD=koopa1234;";

        public bool TestConnection()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var connectionState = connection.State.ToString();
                if (connectionState == "Open")
                {
                    connection.Close();
                    return true;
                }
                return false;
            }
        }

        internal IEnumerable<Store> GetAll()
        {
            var stores = new List<Store>();
            using (var conn = new MySqlConnection(_connectionString))
            {
                if (MySqlConnectionManager.OpenConnection(conn))
                {
                    using (var command = new MySqlCommand("SELECT * FROM checkDB.`store`", conn))
                    {

                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            stores.Add(new Store()
                            {
                                IdStore = reader.GetInt32("idStore"),
                                IdStoreGroup = reader.GetInt32("idStoreGroup"),
                                SName = reader.GetString("sName"),
                                Address = reader.GetString("address"),
                                City = reader.GetString("city"),
                                State = reader.GetString("state"),
                                Zipcode = reader.GetInt32("zipcode")

                                //IdCheck = reader.GetInt32("idCheck"),
                                //IdAccount = reader.GetInt32("idAccount"),
                                //IdStore = reader.GetInt32("idStore"),
                                //CheckNum = reader.GetInt32("checkNum"),
                                //Amount = reader.GetFloat("amount"),
                                //DateWritten = reader.GetDateTime("dateWritten"),
                                //AmountPaid = (!reader.IsDBNull(reader.GetOrdinal("amountPaid"))) ? reader.GetFloat("amountPaid") : -1,
                                //PaidDate = (!reader.IsDBNull(reader.GetOrdinal("paidDate"))) ? reader.GetDateTime("paidDate") : new DateTime(0)
                            });
                        }
                    }
                    MySqlConnectionManager.CloseConnection(conn);
                }
            }

            return stores;
        }



        //internal IEnumerable<Store> GetAll()
        //{
        //    var stores = new List<Store>();

        //    stores.Add(new Store()
        //    {
        //        IdStore = 1,
        //        IdStoreGroup = 2,
        //        sName = "Greenville 1",
        //        Address = "1700 Wade Hmapton",
        //        City = "Greenville",
        //        State = "SC",
        //        Zipcode = "29614"
        //    });
        //    stores.Add(new Store()
        //    {
        //        IdStore = 1,
        //        IdStoreGroup = 2,
        //        sName = "Greenville Store 2",
        //        Address = "300 ridgecrest",
        //        City = "Greenville",
        //        State = "SC",
        //        Zipcode = "29609"
        //    });

        //    return stores;

        //}

        internal string GetStoreById(int id)
        {
            throw new NotImplementedException();
        }
    }
}