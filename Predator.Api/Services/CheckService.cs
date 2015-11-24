using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Predator.Api.Providers;
using Predator.Api.Models;

namespace Predator.Api.Services
{
    class CheckService
    {
        static CheckProvider prov = new CheckProvider();
        static TestCheckProvider testprov = new TestCheckProvider();
        static bool isTesting = false;

        public static List<Check> GetAll()
        {
            if (!isTesting)
                return prov.GetAll();
            else
                return testprov.GetAll();
        }

        public static Check GetCheck(int id)
        {
            if (!isTesting)
                return prov.GetCheck(id);
            else
                return testprov.GetCheck(id);
        }

        public static Check AddCheck(Check check)
        {
            if (!isTesting)
                return prov.AddCheck(check);
            else
                return testprov.AddCheck(check);
        }

        public static void DeleteCheck(int id)
        {
            if (!isTesting)
                prov.DeleteCheck(id);
            else
                testprov.DeleteCheck(id);
        }
    }
}
