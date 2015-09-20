using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Predator.Api.Models
{
    public class Account
    {
        public string Name { get; set; }

        public string Address { get; set; }
        public uint RoutingNumber { get; set; }
        public uint AccountNumber { get; set; }
    }
}