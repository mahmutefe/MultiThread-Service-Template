using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatchProcessing.Entry;
using System.Threading;
using System.IO;
using System.Configuration;
using BatchProcessing.Core.Business;
using Microsoft.Office.Interop.Excel;
using BatchProcessing.Core.Entity;

namespace BatchProcessing
{
    public class ASysTransactionFileReader : WorkerThread
    {
        AppContext context = null;
        bool cleanTempFolder = false;

        public ASysTransactionFileReader(AppContext context)
        {
            this.context = context;
            this.ConfigThreadController(this.context.batchProcessingDefinition.FileReaderThreadCount);
        }

        protected override void WorkerJob()
        {
            Logger.Logger.AddSystemInfoLog(String.Format("[{0}] - ASysTransactionFileReader Started..", Thread.CurrentThread.ManagedThreadId));
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

            Logger.Logger.flushLogQueue(Thread.CurrentThread.ManagedThreadId);
        }
        public bool ExcelRowControl(Microsoft.Office.Interop.Excel.Worksheet excelObject, int rowIndex, int columnCount)
        {
            bool result = true;
            int nullColumnCount = 0;
            try
            {
                for (int k = 1; k <= columnCount; k++)//Total count of excell page column
                {
                    if (((Microsoft.Office.Interop.Excel.Range)excelObject.Cells[rowIndex, k]).Value2 == null)
                    {
                        nullColumnCount++;
                    }
                }
                if (nullColumnCount == columnCount)
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;

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
