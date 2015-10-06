using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Predator.Api.Models
{
    public class Check
    {
        public int Id { get; set; }
        public string CheckNum { get; set; }

        public string AccountNum { get; set; }
        public string RoutingNum { get; set; }
        public Decimal Amount { get; set; }
        public DateTime CheckDate { get; set; }
        public int StoreId { get; set; }
        public int CashierId { get; set; }
        public int OffenseLevel { get; set; }
    }
}