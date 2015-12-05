using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Predator.Api.Models
{
    public class Store
    {
        public int IdStore { get; set; }
        public int IdStoreGroup { get; set; }
        public string SName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string  State { get; set; }
        public int Zipcode { get; set; }
    }
}