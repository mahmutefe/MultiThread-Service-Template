using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchProcessing.Entry;
using BatchProcessing.Core.Business;
using BatchProcessing.Core.Entity;

namespace BatchProcessing
{
    public class ASysMgr
    {
        ASysTransactionMgr aSysTransactionMgr = null;
        AppContext context = null;

        public ASysMgr()
        {
            BatchProcessingDefinition def = Common.getBatchProcessingDefinition();
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
