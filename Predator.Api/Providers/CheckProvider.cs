using System;
using System.Collections.Generic;
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
            var check = new Check
            {
                Name = "Fredy Whatley",
                Address = "Wade Hampton Blvd 1700",
                AccountNumber = 777777777,
                RoutingNumber = 6666666666666,
                OffenseLevel = 1
            };

            checks.Add(check);

            return checks;
        }

    }
}

