using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predator.Api.Models
{
    class CheckDisplayRow
    {
        public int idCheck { get; set; }
        public int idAccount { get; set; }
        public int idStore { get; set; }
        public int checkNum { get; set; }
        public float amount { get; set; }
        public DateTime dateWritten { get; set; }
        public float amountPaid { get; set; }
        public DateTime paidDate { get; set; }
        public int routingNum { get; set; }
        public int accountNum { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string fName2 { get; set; }
        public string lName2 { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipcode { get; set; }
        public string phoneNum { get; set; }
        public string bName { get; set; }
        public string bAddress { get; set; }
        public string bCity { get; set; }
        public string bState { get; set; }
        public int bZipcode { get; set; }
        public int idStoreGroup { get; set; }
        public string sName { get; set; }
        public string sAddress { get; set; }
        public string sCity { get; set; }
        public string sState { get; set; }
        public int sZipcode { get; set; }
    }
}
