using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Predator.Api.Models;
using Predator.Api.Providers;

namespace Predator.Api.Services
{
    class StaffService
    {
        static StaffProvider prov = new StaffProvider();
        static TestStaffProvider testprov = new TestStaffProvider();
        static bool testing = false;

        public static IEnumerable<Staff> RetrieveAllStaff()
        {
            if (!testing) return prov.RetrieveAllStaff();
            else return testprov.RetrieveAllStaff();
        }

        public static Staff RetrieveSingleStaff(int id)
        {
            if (!testing) return prov.RetrieveSingleStaff(id);
            else return testprov.RetrieveSingleStaff();
        }

        public static void CreateStaff(Staff staff)
        {
            if (!testing) prov.CreateStaff(staff);
            else testprov.CreateStaff(staff);
        }

        public static void UpdateStaff(int id, Staff staff)
        {
            if (!testing) prov.UpdateStaff(id, staff);
            else testprov.UpdateStaff(id, staff);
        }

        public static void DeleteStaff(int id)
        {
            if (!testing) prov.DeleteStaff(id);
            else testprov.DeleteStaff(id);
        }
    }
}
