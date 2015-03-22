using DevDumps.WPFSDK.Base.Shell;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PatsViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : AppBase
    {
        public App() : base(new Bootstrapper()) { }
    }
}
