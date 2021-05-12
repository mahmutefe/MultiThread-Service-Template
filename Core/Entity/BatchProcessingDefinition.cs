using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatchProcessing.Core.Entity
{
    public class BatchProcessingDefinition
    {
        public int FileReaderThreadCount { get; set; }
        public int PendingTransactionReaderThreadCount { get; set; }
    }
}
