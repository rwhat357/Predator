using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Predator.Api.Models;

namespace Predator.Api.Providers
{
    public class CheckProvider
    {
        readonly string _connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        internal List<Check> GetAll()
        {
            var checks = new List<Check>();
            using (var con = new SqlConnection(_connetionString))
            {
                con.Open();

                using (var command = new SqlCommand("SELECT * FROM Pr_Checks", con))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        checks.Add(
                            new Check()
                          {
                                 Id = reader.GetInt32(0),
                                 CheckNum = reader.GetString(1),
                                 AccountNum = reader.GetString(2),
                                 RoutingNum = reader.GetString(3),
                                 Amount = reader.GetDecimal(4),
                                 CheckDate = reader.GetDateTime(5),
                                 StoreId = reader.GetInt32(6),
                                 CashierId = reader.GetInt32(7),
                                 OffenseLevel = reader.GetInt32(8)
                            });
                    }
                }
            }

            return checks;
        }
        
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
    }
}

