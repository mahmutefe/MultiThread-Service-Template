using BatchProcessing.Core.Business;
using BatchProcessing.Core.Entity;
using BatchProcessing.Entry;

namespace BatchProcessing
{
    public class ASysMgr
    {
        ASysTransactionMgr aSysTransactionMgr = null;
        AppContext context = null;

        public ASysMgr()
        {
            BatchProcessingDefinitionEntity def = Common.GetBatchProcessingDefinition();
            context = new AppContext(def);
            aSysTransactionMgr = new ASysTransactionMgr(context);
        }

        public void Start() 
        {
            aSysTransactionMgr.Start();
        }

        public void Stop()
        {
            aSysTransactionMgr.Stop();
        }
    }
}
