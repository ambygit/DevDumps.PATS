using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace DevDumps.WPFSDK.Base.Shell
{
    public class AppBase : Application
    {
        private readonly BootstrapperBase _bootstrapper;

        public AppBase(BootstrapperBase bootstrapper)
        {
            _bootstrapper = bootstrapper;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
            Current.Dispatcher.UnhandledException += Dispatcher_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerUnobservedTaskException;
            Thread.CurrentThread.Name = "UIThread";

            _bootstrapper.Run();
        }

        private void TaskSchedulerUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
        }

        private void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
        }

        private void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }
    }
}