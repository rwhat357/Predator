using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Predator.Api.Models
{
    public class Check
    {
        public int IdCheck { get; set; }
        public int IdAccount { get; set; }
        public int IdStore { get; set; }
        public int CheckNum { get; set; }
        public float Amount { get; set; }
        public DateTime DateWritten { get; set; }
        public float AmountPaid { get; set; }
        public DateTime PaidDate { get; set;}
    }
}