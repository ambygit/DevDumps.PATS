using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DevDumps.WPFSDK.Base.Shell
{
    public class AppBase : Application
    {
        private BootstrapperBase _bootstrapperBase;

        public AppBase(BootstrapperBase bootstrapperBase)
        {
            _bootstrapperBase = bootstrapperBase;
        }
    }
}
