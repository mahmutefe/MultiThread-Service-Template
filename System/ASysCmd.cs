using System;
using System.Collections.Generic;
using System.Text;

namespace BatchProcessing
{
    public class ASysCmd
    {
        public ASysCmd()
        {
        }
        public void Start()
        {
            string sCmd = string.Empty;
            bool bUp = true;


            while (bUp)
            {

                if ((sCmd = Console.ReadLine()) != null)
                {


                    if (sCmd == "log1")
                    {
                        for (int i = 0; i < 1000; i++)
                        {
                            Logger.Logger.AddDatabaseInfoLog("threadId:-1 >>>" + i.ToString());
                        }

                    }
                    if (sCmd.StartsWith("thread"))
                    {
                        Logger.Logger.AddDatabaseInfoLog("threadId:-" + Convert.ToInt32(sCmd.Substring(6, 1)).ToString(), Convert.ToInt32(sCmd.Substring(6, 1)));
                    }
                    if (sCmd.StartsWith("id"))
                    {
                        Logger.Logger.flushLogQueue(Convert.ToInt32(sCmd.Substring(2, 1)));
                    }

                }
            }
        }
    }
}
