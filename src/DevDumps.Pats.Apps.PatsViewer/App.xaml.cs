using DevDumps.WPFSDK.Base.Shell;

namespace DevDumps.Pats.Apps.PatsViewer
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : AppBase
    {
        public App() : base(new Bootstrapper())
        {
        }
    }
}