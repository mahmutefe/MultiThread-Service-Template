using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchProcessing.Core.Entity;
using System.Threading;
using BatchProcessing.Core.Business;
using BatchProcessing.Entry;

namespace BatchProcessing
{
    public class ASysPendingTransactionReader : WorkerThread
    {
        AppContext context = null;

        public ASysPendingTransactionReader(AppContext context)
        {
            this.context = context;
            this.ConfigThreadController(this.context.batchProcessingDefinition.PendingTransactionReaderThreadCount);
        }

        protected override void WorkerJob()
        {
            Logger.Logger.AddSystemInfoLog(String.Format("[{0}] - ASysPendingTransactionReader started..", Thread.CurrentThread.ManagedThreadId));
            while (IsUp)
            {
                DoJob();
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                }
            }
        }

        private void DoJob()
        {
            Logger.Logger.AddSystemInfoLog(string.Format("[{0}]-[{1}] File processiong", "FileName", "FileId"), Thread.CurrentThread.ManagedThreadId);
            
            Logger.Logger.flushLogQueue(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
