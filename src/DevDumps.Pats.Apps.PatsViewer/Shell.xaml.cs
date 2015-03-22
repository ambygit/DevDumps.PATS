using System.Windows;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;

namespace DevDumps.Pats.Apps.PatsViewer
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            InitializeComponent();
        }
    }
}
