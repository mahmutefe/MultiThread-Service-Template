using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using BatchProcessing.Core.Entity;

namespace BatchProcessing.Entry
{
    public class AppContext
    {

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["connection_string"].ToString();
            }
        }

        private BatchProcessingDefinition def;
        public BatchProcessingDefinition batchProcessingDefinition
        {
            get
            {
                return this.def;
            }
        }

        public AppContext(BatchProcessingDefinition def)
        {
            this.def = def;
        }

        public byte[] readAllBytes(string fileName)
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

        public string getTxnFilePattern()
        {
            return ConfigurationManager.AppSettings["TXN_FILE_PATTERN"];
        }

        public string getTxnFilePath()
        {
            return ConfigurationManager.AppSettings["TXN_FILE_PATH"];
        }

        public string getTxnTempPath()
        {
            return ConfigurationManager.AppSettings["TXN_TEMP_PATH"];
        }

        public string getTxnArchivePath()
        {
            return ConfigurationManager.AppSettings["TXN_ARCHIVE_PATH"];
        }

        public string getTxnErrorPath()
        {
            return ConfigurationManager.AppSettings["TXN_ERROR_PATH"];
        }
    }
}
