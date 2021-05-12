using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchProcessing.Entry;

namespace BatchProcessing
{
    public class ASysTransactionMgr
    {
        ASysTransactionFileReader aSysTransactionFileReader = null;
        ASysPendingTransactionReader aSysPendingTransactionReader = null;
        AppContext context = null;

        public ASysTransactionMgr(AppContext context)
        {
            this.context = context;
            aSysTransactionFileReader = new ASysTransactionFileReader(context);
            aSysPendingTransactionReader = new ASysPendingTransactionReader(context);
            
        }

        public void Start()
        {
            aSysPendingTransactionReader.Start();
            aSysTransactionFileReader.Start();
        }

        public void Stop()
        {
            aSysPendingTransactionReader.Stop();
            aSysTransactionFileReader.Stop();
        }
    }
}
