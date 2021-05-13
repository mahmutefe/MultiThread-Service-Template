using System.ComponentModel;
using System.ServiceProcess;

namespace BatchProcessing
{
    public partial class ASysSrv : ServiceBase
    {
        ASysMgr aSysMgr = null;

        public ASysSrv()
        {
            InitializeComponent();
        }

        public ASysSrv(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            aSysMgr = new ASysMgr();
            aSysMgr.Start();
        }
        protected override void OnStop()
        {
            aSysMgr.Stop();
        }
        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnContinue()
        {
            base.OnContinue();
        }


        private void InitializeComponent()
        {
            // 
            // ASysSrv
            // 
            this.ServiceName = "BatchProcessing";

        }

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
