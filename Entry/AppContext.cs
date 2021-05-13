using BatchProcessing.Core.Entity;
using System;
using System.Configuration;
using System.IO;

namespace BatchProcessing.Entry
{
    public class AppContext
    {
        /// <summary>
        /// Gets connection string from App.Config file
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["connection_string"].ToString();
            }
        }

        private BatchProcessingDefinitionEntity def;
        /// <summary>
        /// Get Batch process processing definition
        /// </summary>
        public BatchProcessingDefinitionEntity BatchProcessingDefinition
        {
            get
            {
                return this.def;
            }
        }

        /// <summary>
        /// Gets Application context
        /// </summary>
        /// <param name="def"></param>
        public AppContext(BatchProcessingDefinitionEntity def)
        {
            this.def = def;
        }

        /// <summary>
        /// Reads file
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>File content as byte array</returns>
        public byte[] ReadAllBytes(string fileName)
        {
            byte[] buffer = null;
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, (int)fs.Length);
                }
            }
            catch (Exception ex)
            {
                buffer = null;
            }

            return buffer;
        }

        /// <summary>
        /// Gets Log File pattern from App.config file
        /// </summary>
        /// <returns></returns>
        public string GetTxnFilePattern()
        {
            return ConfigurationManager.AppSettings["TXN_FILE_PATTERN"];
        }

        /// <summary>
        /// Gets Log File path from App.config file
        /// </summary>
        /// <returns></returns>
        public string GetTxnFilePath()
        {
            return ConfigurationManager.AppSettings["TXN_FILE_PATH"];
        }

        /// <summary>
        /// Gets Temp File pattern from App.config file
        /// </summary>
        /// <returns></returns>
        public string GetTxnTempPath()
        {
            return ConfigurationManager.AppSettings["TXN_TEMP_PATH"];
        }

        /// <summary>
        /// Gets archived File pattern from App.config file
        /// </summary>
        /// <returns></returns>
        public string GetTxnArchivePath()
        {
            return ConfigurationManager.AppSettings["TXN_ARCHIVE_PATH"];
        }

        /// <summary>
        /// Gets error File pattern from App.config file
        /// </summary>
        /// <returns></returns>
        public string GetTxnErrorPath()
        {
            return ConfigurationManager.AppSettings["TXN_ERROR_PATH"];
        }
    }
}
