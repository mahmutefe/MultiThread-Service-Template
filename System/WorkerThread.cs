using System.Collections.Generic;
using System.Threading;

namespace BatchProcessing
{
    public abstract class WorkerThread
    {
        public const int MAX_THREAD_COUNT = 30;

        private List<Thread> _WorkerThreads = null;
        private object _LockObject = null;

        private Thread _ControllerThread = null;

        private bool runController = true;
        public bool RunController
        {
            get { return runController; }
            set { runController = value; }
        }

        public WorkerThread()
        {
            _WorkerThreads = new List<Thread>();
            _LockObject = new object();
            _ControllerThread = new Thread(new ThreadStart(ControllerJob));
            _ControllerThread.Name = "Controller";
        }

        private bool _IsControllerUp = false;

        private bool _IsUp = false;
        protected bool IsUp
        {
            get { return _IsUp; }
            set { _IsUp = value; }
        }

        private bool _IsRunning = false;
        public bool IsRunning
        {
            get { return _IsRunning; }
        }

        private int _ThreadCount = 1;

        private bool _IsConfigured = false;
        protected bool ConfigThreadController(int piThreadCount)
        {
            lock (_LockObject)
            {
                if (_IsConfigured)
                    return true;

                _IsConfigured = true;

                _ThreadCount = piThreadCount;

                if (_ThreadCount < 1 || _ThreadCount > MAX_THREAD_COUNT)
                    return false;

                for (int iThrIdx = 0; iThrIdx < _ThreadCount; iThrIdx++)
                {
                    Thread thWorker = new Thread(new ThreadStart(ThreadJob));
                    thWorker.Name = this.GetType().Name + iThrIdx.ToString();
                    _WorkerThreads.Add(thWorker);
                }

                return true;
            }
        }

        public virtual void Start()
        {
            lock (_LockObject)
            {
                if (_IsRunning)
                    return;

                _IsUp = true;
                foreach (Thread thWorker in _WorkerThreads)
                {
                    thWorker.Start();
                }

                _IsControllerUp = true;
                if (runController)
                {
                    _ControllerThread.Start();
                }

                _IsRunning = true;
            }
        }

        public virtual void Stop()
        {
            lock (_LockObject)
            {
                if (!_IsRunning)
                    return;

                _IsControllerUp = false;
                if (_ControllerThread.IsAlive)
                {
                    _ControllerThread.Join();
                }


                _IsUp = false;
                foreach (Thread thWorker in _WorkerThreads)
                {
                    thWorker.Join();
                }

                _IsRunning = false;
            }
        }

        private void ThreadJob()
        {
            WorkerJob();
        }

        protected virtual void WorkerJob() { }

        private void ControllerJob()
        {
            List<Thread> thCtrlCreatedThreads = new List<Thread>();
            int addThrCnt = 0;
            while (_IsControllerUp)
            {
                thCtrlCreatedThreads.Clear();
                for (int iIdx = _WorkerThreads.Count - 1; iIdx >= 0; iIdx--)
                {
                    if (!_WorkerThreads[iIdx].IsAlive)
                    {
                        _WorkerThreads[iIdx].Abort();
                        _WorkerThreads.RemoveAt(iIdx);
                        Thread thNew = new Thread(new ThreadStart(ThreadJob));
                        thCtrlCreatedThreads.Add(thNew);
                    }
                }
                addThrCnt = _ThreadCount - (thCtrlCreatedThreads.Count + _WorkerThreads.Count);
                for (int iIdx = 0; iIdx < addThrCnt; iIdx++)
                {
                    Thread thNew = new Thread(new ThreadStart(ThreadJob));
                    thNew.Name = this.GetType().Name;
                    thCtrlCreatedThreads.Add(thNew);
                }

                foreach (Thread thNew in thCtrlCreatedThreads)
                {
                    _WorkerThreads.Add(thNew);
                    thNew.Start();
                }

                Thread.Sleep(1000);
            }
        }
    }
}
