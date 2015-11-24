using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Predator.Api.Models;
using Predator.Api.Providers;

namespace Predator.Api.Services
{
    class CheckDisplayRowService
    {
        static bool isTesting = false;
        static void setTesting(bool newval) { isTesting = newval; }
        static TestCheckDisplayRowProvider testProvider = new TestCheckDisplayRowProvider();
        static CheckDisplayRowProvider provider = new CheckDisplayRowProvider();

        public static CheckDisplayRow RetrieveSingleCheckDisplayRow(int checkID)
        {
            CheckDisplayRow row = null;
            if (isTesting) row = testProvider.RetrieveSingleCheckDisplayRow(checkID);
            else row = provider.RetrieveSingleCheckDisplayRow(checkID);
            return row;
        }

        public static IEnumerable<CheckDisplayRow> RetrieveAllCheckDisplayRows()
        {
            if (isTesting) return testProvider.RetrieveAllCheckDisplayRows();
            else return provider.RetrieveAllCheckDisplayRows();
        }

        public static void DeleteCheckDisplayRow(int checkID)
        {
            if (isTesting) testProvider.DeleteCheckDisplayRow(checkID);
            else provider.DeleteCheckDisplayRow(checkID);
        }

        public static void CreateCheckDisplayRow(CheckDisplayRow row)
        {
            if (isTesting) testProvider.CreateCheckDisplayRow(row);
            else provider.CreateCheckDisplayRow(row);
        }

        public static void UpdateCheckDisplayRow(int id, CheckDisplayRow row)
        {
            if (isTesting) testProvider.UpdateCheckDisplayRow(id, row);
            else provider.UpdateCheckDisplayRow(id, row);
        }
    }
}
