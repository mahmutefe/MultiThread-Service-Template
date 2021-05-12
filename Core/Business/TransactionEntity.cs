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
    public class TransactionEntity
    {
        public static bool fileStatusControl(string fileName, string fileStatus)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(AppContext.ConnectionString))
            {
                connection.Open();
                string queryString = "Sample select query ..";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@FileName", fileName);
                command.Parameters.AddWithValue("@FileStatus", fileStatus);
                int recordCount = Convert.ToInt32(command.ExecuteScalar());
                if (recordCount > 0)
                {
                    result = true;
                }
                connection.Close();
            }
            return result;
        }

        public static Int64 getFileIdByFileNameAndFileStatus(string fileName, string fileStatus)
        {
            Int64 fileId = -1;
            using (SqlConnection connection = new SqlConnection(AppContext.ConnectionString))
            {
                connection.Open();
                string queryString = "Sample sql query..";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@FileName", fileName);
                command.Parameters.AddWithValue("@FileStatus", fileStatus);
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    fileId = Convert.ToInt64(result);
                }
                
                connection.Close();
            }
            return fileId;
        }

        public static Int64 insertFileDetail(Sample3EntityClass detail)
        {
            Int64 recordId = -1;
            using (SqlConnection connection = new SqlConnection(AppContext.ConnectionString))
            {
                connection.Open();
                string queryString = @"Sample SQL query..";
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@Status", 1);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    recordId = Convert.ToInt64(result);
                }
                connection.Close();
            }
            return recordId;
        }

        public static void updateFileStatusAndRecordCounts(Sample2EntityClass file)
        {
            using (SqlConnection connection = new SqlConnection(AppContext.ConnectionString))
            {
                connection.Open();
                string queryString = @"Sample sql Query";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@UpdateDate", Common.toLongDatetime(DateTime.Now));

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void updateFileStatus(Sample2EntityClass file)
        {
            using (SqlConnection connection = new SqlConnection(AppContext.ConnectionString))
            {
                connection.Open();
                string queryString = @"Sample sql Query";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@UpdateDate", Common.toLongDatetime(DateTime.Now));

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static List<Sample2EntityClass> getUploadFileByFileStatus(string fileStatus)
        {
            List<Sample2EntityClass> list = new List<Sample2EntityClass>();
            using (SqlConnection connection = new SqlConnection(AppContext.ConnectionString))
            {
                connection.Open();
                string queryString = @"Sample sql Query ";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Status", 1);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Sample2EntityClass item = new Sample2EntityClass();
                    item.Id = Convert.ToInt64(reader["Id"]);
                    list.Add(item);
                }
                reader.Close();
                connection.Close();
            }
            return list;
        }

        public static List<Sample3EntityClass> getUploadFileDetailByFileIdAndRecordStatus(Int64 fileId, string recordStatus)
        {
            List<Sample3EntityClass> list = new List<Sample3EntityClass>();
            using (SqlConnection connection = new SqlConnection(AppContext.ConnectionString))
            {
                connection.Open();
                string queryString = @"Sample SQL query";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Status", 1);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Sample3EntityClass item = new Sample3EntityClass();
                    item.Id = Convert.ToInt64(reader["Id"]);
                    
                    list.Add(item);
                }
                reader.Close();
                connection.Close();
            }
            return list;
        }

        public static Int64 insertPendingTransaction(SampleEntityClass pendingTransaction)
        {
            Int64 recordId = -1;
            using (SqlConnection connection = new SqlConnection(AppContext.ConnectionString))
            {
                connection.Open();
                string queryString = @"Sample sql query";
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@FileId", pendingTransaction.Id);
                
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    recordId = Convert.ToInt64(result);
                }
                connection.Close();
            }
            return recordId;
        }
    }
}
