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
