using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchProcessing.Core.Entity;
using System.Data.SqlClient;
using System.Configuration;
using BatchProcessing.Entry;

namespace BatchProcessing.Core.Business
{
    public class Common
    {
        public static BatchProcessingDefinition getBatchProcessingDefinition()
        {
            BatchProcessingDefinition def = null;
            using (SqlConnection connection = new SqlConnection(AppContext.ConnectionString))
            {
                connection.Open();
                string queryString = "SELECT FileReaderThreadCount, PendingTxnReaderThreadCount FROM INTERCPOS.Def.BatchProcessing (NOLOCK)";
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    def = new BatchProcessingDefinition();
                    def.FileReaderThreadCount = Convert.ToInt32(reader["FileReaderThreadCount"]);
                    def.PendingTransactionReaderThreadCount = Convert.ToInt32(reader["PendingTxnReaderThreadCount"]);
                    break;
                }
                reader.Close();
                connection.Close();
            }
            return def;
        }

        public static Int64 toShortDate(DateTime date)
        {
            return Convert.ToInt64(date.ToString("yyyyMMdd"));
        }

        public static Int64 toLongDatetime(DateTime date)
        {
            return Convert.ToInt64(date.ToString("yyyyMMddHHmmss"));
        }
        
    }
}
