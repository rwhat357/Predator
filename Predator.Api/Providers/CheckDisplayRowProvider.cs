using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Predator.Api.Models;
using Predator.Api.Utils;
using MySql.Data.MySqlClient;

namespace Predator.Api.Providers
{
    class CheckDisplayRowProvider
    {
        internal void CreateCheckDisplayRow(string rowString)
        {
            using (MySqlConnection conn = new MySqlConnection(PredatorConstants.CONNECTION_STRING))
            {
                if (MySqlConnectionManager.OpenConnection(conn))
                {
                    StringBuilder commandStringBuilder = new StringBuilder();
                    //make the stupid command string here
                    //making
                    //making
                    //making
                    using (MySqlCommand command = new MySqlCommand(commandStringBuilder.ToString()))
                    {
                        command.ExecuteNonQuery();
                    }
                    MySqlConnectionManager.CloseConnection(conn);
                }
            }
        }

        internal CheckDisplayRow RetrieveSingleCheckDisplayRow(int id)
        {
            CheckDisplayRow row = null;

            return row;
        }

        internal CheckDisplayRow[] RetrieveAllCheckDisplayRows()
        {
            CheckDisplayRow[] rows = null;

            return rows;
        }

        internal void UpdateCheckDisplayRow(int id, string valueString)
        {

        }

        internal void DeleteCheckDisplayRow(int id)
        {

        }
    }
}
