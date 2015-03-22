using System.Windows;
using System.Windows.Controls;
using DevDumps.Pats.Apps.PatsViewer.ModulesConfig;
using DevDumps.WPFSDK.Base.Shell;
using DevDumps.WPFSDK.Common.RegionAdapters;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace DevDumps.Pats.Apps.PatsViewer
{
    public class Bootstrapper : BootstrapperBase
    {
        public new IUnityContainer Container { get; private set; }

        protected override IUnityContainer CreateContainer()
        {
            Container = base.CreateContainer();

            Container.RegisterType<StackPanelRegionAdapter>();

            Container.RegisterType<Shell>();

            return Container;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog
            {
                Store = new ModuleConfigurationStore()
            };
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var defaultMappings = base.ConfigureRegionAdapterMappings();
            defaultMappings.RegisterMapping(typeof(StackPanel),Container.Resolve<StackPanelRegionAdapter>());

            return defaultMappings;
        }

        protected override DependencyObject CreateShell()
        {
            var shell =  Container.Resolve<Shell>();
            Application.Current.MainWindow = shell;
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            shell.Show();

            return shell;
        }
    }
}