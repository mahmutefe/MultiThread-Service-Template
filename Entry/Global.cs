using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchProcessing.Entry
{
    public class Global
    {
        public Global() { }

        public const string FILE_STATUS_WAITING = "W";
        public const string FILE_STATUS_VALID = "V";
        public const string FILE_STATUS_ERROR = "E";
        public const string FILE_STATUS_PENDING = "P";
        public const string FILE_STATUS_QUEUED = "Q";
        public const string FILE_STATUS_SUCCESS = "S";


        public const string FILE_DETAIL_RECORD_STATUS_VALID = "V";
        public const string FILE_DETAIL_RECORD_STATUS_CANCELED = "C";
        public const string FILE_DETAIL_RECORD_STATUS_ERROR = "E";

        public const string PENDING_TRANSACTION_RECORD_STATUS_WAITING = "W";
        
    }
}
