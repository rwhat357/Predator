using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Predator.Api.Models
{
    public class Check
    {
        public string Name { get; set; }

        public string Address { get; set; }
        public long RoutingNumber { get; set; }
        public long AccountNumber { get; set; }
        public int OffenseLevel { get; set; }
    }
}