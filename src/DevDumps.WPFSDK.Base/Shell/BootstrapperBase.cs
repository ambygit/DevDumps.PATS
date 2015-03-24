using DevDumps.WPFSDK.Core.Unity;
using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace DevDumps.WPFSDK.Base.Shell
{
    public abstract class BootstrapperBase : UnityBootstrapper 
    {
        protected override IUnityContainer CreateContainer()
        {
            var container = base.CreateContainer();
            UnityContainerFactory.Init(container);

            return container;
        }
    }
}
