using BatchProcessing.Entry;
using System;
using System.Threading;

namespace BatchProcessing
{
    public class ASysSampleWorker1Thread : WorkerThread
    {
        AppContext context = null;

        public ASysSampleWorker1Thread(AppContext context)
        {
            this.context = context;
            this.ConfigThreadController(this.context.BatchProcessingDefinition.PendingTransactionReaderThreadCount);
        }

        protected override void WorkerJob()
        {
            Logger.Logger.AddSystemInfoLog(String.Format("[{0}] - ASysSampleWorker1Thread started..", Thread.CurrentThread.ManagedThreadId));
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

            //Write code here

            Logger.Logger.flushLogQueue(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
