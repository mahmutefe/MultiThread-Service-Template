using System.Configuration;
using System.ServiceProcess;

namespace BatchProcessing
{
    public class ASysPrc
    {
        int _SrvMode = 0;

        public ASysPrc()
        {
            _SrvMode = int.Parse(ConfigurationManager.AppSettings["SRV_MODE"]);
        }

        public void Start()
        {
            if (_SrvMode == 1)
            {
                Logger.Logger.AddSystemInfoLog("Application started with Windows Service Mode");
                ServiceBase[] ServicesToRun = new ServiceBase[] { new ASysSrv() };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                Logger.Logger.AddSystemInfoLog("Application started with Console Application Mode");
                ASysMgr aSysMgr = new ASysMgr();
                ASysCmd aSysCmd = new ASysCmd();
                aSysMgr.Start();
                aSysCmd.Start();
                aSysMgr.Stop();
            }

            Logger.Logger.AddSystemInfoLog("Application stopped");
        }
    }
}
