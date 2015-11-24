using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predator.Api.Models
{
    public class Staff
    {
        public int idStaff { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int accessLevel { get; set; }
        public DateTime creationDate { get; set; }
    }
}
