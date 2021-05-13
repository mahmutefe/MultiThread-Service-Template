using BatchProcessing.Entry;
using System;
using System.Threading;

namespace BatchProcessing
{
    public class ASysSampleWorker2Thread : WorkerThread
    {
        AppContext context = null;

        public ASysSampleWorker2Thread(AppContext context)
        {
            this.context = context;
            this.ConfigThreadController(this.context.BatchProcessingDefinition.FileReaderThreadCount);
        }

        protected override void WorkerJob()
        {
            Logger.Logger.AddSystemInfoLog(String.Format("[{0}] - ASysSampleWorker2Thread Started..", Thread.CurrentThread.ManagedThreadId));
            while (IsUp)
            {
                DoJob();
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(300);
                }
            }    
        }

        private void DoJob() 
        {
            Logger.Logger.AddSystemInfoLog("Do job running..", Thread.CurrentThread.ManagedThreadId);

            //Write code here

            Logger.Logger.flushLogQueue(Thread.CurrentThread.ManagedThreadId);
        }

        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
