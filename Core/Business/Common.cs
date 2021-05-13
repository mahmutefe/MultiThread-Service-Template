using BatchProcessing.Core.Entity;
using BatchProcessing.Entry;
using System;
using System.Data.SqlClient;

namespace BatchProcessing.Core.Business
{
    public class Common
    {
        /// <summary>
        /// Get service configurations from database (You should manage this part based on your process.)
        /// </summary>
        /// <returns>Service configuration</returns>
        public static BatchProcessingDefinitionEntity GetBatchProcessingDefinition()
        {
            BatchProcessingDefinitionEntity def = null;
            using (SqlConnection connection = new SqlConnection(AppContext.ConnectionString))
            {
                connection.Open();
                string queryString = "SELECT FileReaderThreadCount, PendingTxnReaderThreadCount FROM TestDB.BatchProcessingTable (NOLOCK)";
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    def = new BatchProcessingDefinitionEntity();
                    def.FileReaderThreadCount = Convert.ToInt32(reader["FileReaderThreadCount"]);
                    def.PendingTransactionReaderThreadCount = Convert.ToInt32(reader["PendingTxnReaderThreadCount"]);
                    break;
                }
                reader.Close();
                connection.Close();
            }
            return def;
        }

        /// <summary>
        /// Gets short datetime in yyyyMMdd format
        /// </summary>
        /// <param name="date">Datetime</param>
        /// <returns>Formatted datetime</returns>
        public static Int64 ToShortDate(DateTime date)
        {
            return Convert.ToInt64(date.ToString("yyyyMMdd"));
        }

        /// <summary>
        /// Gets long  datetime in yyyyMMddHHmmss format
        /// </summary>
        /// <param name="date">Datetime</param>
        /// <returns>Formatted datetime</returns>
        public static Int64 ToLongDatetime(DateTime date)
        {
            return Convert.ToInt64(date.ToString("yyyyMMddHHmmss"));
        }
        
    }
}
