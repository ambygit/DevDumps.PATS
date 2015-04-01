using System.Windows;
using System.Windows.Input;
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

        private void HandleMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void HandleCloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void HandleMinimizeWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void HandleMaximizeWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }
    }



}
