using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tehtava3.Properties;

namespace Tehtava3
{
    class DBViinit
    {
        public static DataTable GetTestData()
        {
            DataTable table = new DataTable();

            DataRow row = table.NewRow();
            row[0] = "Jukkis";
            row[1] = "Hassu viini";
            table.Rows.Add(row);

            return table;
        }

        public static DataSet GetData(string queryString)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Settings.Default.DBConnection))
                {
                    DataSet dataSet = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand(queryString, con);
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
