using BatchProcessing.Entry;

namespace BatchProcessing
{
    public class ASysTransactionMgr
    {
        ASysSampleWorker1Thread aSysSampleWorker1Thread = null;
        ASysSampleWorker2Thread aSysSampleWorker2Thread = null;

        private AppContext context = null;

        public ASysTransactionMgr(AppContext context)
        {
            this.context = context;
            aSysSampleWorker1Thread = new ASysSampleWorker1Thread(context);
            aSysSampleWorker2Thread = new ASysSampleWorker2Thread(context);
            
        }

        public void Start()
        {
            aSysSampleWorker1Thread.Start();
            aSysSampleWorker2Thread.Start();
        }

        public void Stop()
        {
            aSysSampleWorker1Thread.Stop();
            aSysSampleWorker2Thread.Stop();
        }
    }
}
