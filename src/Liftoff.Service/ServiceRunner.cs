using System;
using System.ServiceProcess;
using System.Threading;

namespace Liftoff.Service
{
    public class ServiceRunner : ServiceBase
    {
        private readonly bool _consoleMode;
        private readonly CancellationTokenSource _tokenSource;
        private readonly IManageServiceObjects _serviceObjectManager;
        private object _serviceObject;

        protected CancellationToken CancellationToken { get { return _tokenSource.Token; } }

        public ServiceRunner(IManageServiceObjects serviceObjectManager)
        {
            ServiceLogger.Info("Initializing...");

            _tokenSource = new CancellationTokenSource();
            _consoleMode = NativeMethods.GetConsoleWindow() != IntPtr.Zero;
            _serviceObjectManager = serviceObjectManager;
        }

        public void Run()
        {
            _serviceObject = _serviceObjectManager.BuildServiceObject();

            if (_consoleMode)
            {
                ServiceLogger.Info("Running in console mode - Press Ctrl-C to stop");

                Console.CancelKeyPress +=
                    (sender, args) =>
                    {
                        _tokenSource.Cancel();
                        args.Cancel = true;
                    };

                OnStart(Environment.GetCommandLineArgs());

                _tokenSource.Token.WaitHandle.WaitOne();

                OnStop();
            }
            else
            {
                ServiceLogger.Info("Running in service mode");
                Run(new ServiceBase[] { this });
            }
        }

        protected override void OnStart(string[] args)
        {
            ServiceLogger.Info("Starting...");

            _serviceObjectManager.Start(_serviceObject);

            ServiceLogger.Info("Started.");
        }

        protected override void OnStop()
        {
            ServiceLogger.Info("Stopping...");

            try
            {
                _tokenSource.Cancel();
                _serviceObjectManager.Stop(_serviceObject);
            }
            catch (Exception ex)
            {
                ServiceLogger.Fatal(ex.Message, ex);
                throw;
            }

            ServiceLogger.Info("Stopped.");
        }
    }
}