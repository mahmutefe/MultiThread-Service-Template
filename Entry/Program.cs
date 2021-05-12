using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;
using BatchProcessing;

namespace BatchProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Logger.IntializeLogger();
            ASysPrc SystemManager = new ASysPrc();
            SystemManager.Start();
        }
    }
}
