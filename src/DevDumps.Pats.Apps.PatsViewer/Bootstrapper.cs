using DevDumps.WPFSDK.Base.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace PatsViewer
{
    public class Bootstrapper : BootstrapperBase
    {

        protected override IUnityContainer CreateContainer()
        {
            Container = base.CreateContainer();

            Container.RegisterType<Shell>();



            return Container;
        }

        protected override Microsoft.Practices.Prism.Modularity.IModuleCatalog CreateModuleCatalog()
        {
            return base.CreateModuleCatalog();
        }

        protected override System.Windows.DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        public IUnityContainer Container { get; private set; }
    }
}
