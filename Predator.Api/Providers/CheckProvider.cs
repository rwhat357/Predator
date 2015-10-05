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

        internal List<Check> Retrieve()
        {
            var checks = new List<Check>();

            var check = new Check();
            for (int i =0; i < 10; i++)
            {
                check = new Check
                {
                    Id = i,
                    CheckNum = "3",
                    AccountNum = "6666666666666",
                    RoutingNum = "234324243",
                    Amount = 445.00,
                    CheckDate = new DateTime(),
                    StoreId = 1,
                    CashierId = 40,
                    OffenseLevel = 1
                };

                checks.Add(check);
            }

            //string connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

            //var checks = new List<Check>();
            //using (SqlConnection con = new SqlConnection(connetionString))
            //{
            //    con.Open();

            //    using (SqlCommand command = new SqlCommand("SELECT * FROM Pr_Checks", con))
            //    {
            //        SqlDataReader reader = command.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            checks.Add(
            //                new Check()
            //                {
            //                       Id = reader.GetInt32(0),
            //                       CheckNum = reader.GetString(1),
            //                       AccountNum = reader.GetString(2),
            //                       RoutingNum = reader.GetString(3),
            //                       Amount = reader.GetDouble(4),
            //                       CheckDate = reader.GetDateTime(5),
            //                       StoreId = reader.GetInt32(6),
            //                       CashierId = reader.GetInt32(7),
            //                       OffenseLevel = reader.GetInt32(8)
            //                });

            //        }
            //    }
            //}

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
                Amount = 445.00,
                CheckDate = new DateTime(),
                StoreId = 1,
                CashierId = 40,
                OffenseLevel = 1
            };

            return check;
        }
    }
}

