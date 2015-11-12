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

        public static CheckDisplayRow[] RetrieveAllCheckDisplayRows()
        {
            CheckDisplayRow[] rows = null;
            if (isTesting) rows = testProvider.RetrieveAllCheckDisplayRows();
            else rows = provider.RetrieveAllCheckDisplayRows();
            return rows;
        }

        public static void DeleteCheckDisplayRow(int checkID)
        {
            if (isTesting) testProvider.DeleteCheckDisplayRow(checkID);
            else provider.DeleteCheckDisplayRow(checkID);
        }

        public static void CreateCheckDisplayRow(string rowString)
        {
            if (isTesting) testProvider.CreateCheckDisplayRow(rowString);
            else provider.CreateCheckDisplayRow(rowString);
        }

        public static void UpdateCheckDisplayRow(int id, string value)
        {
            if (isTesting) testProvider.UpdateCheckDisplayRow(id, value);
            else provider.UpdateCheckDisplayRow(id, value);
        }
    }
}
