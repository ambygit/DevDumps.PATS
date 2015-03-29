using DevDumps.Pats.Apps.PatsViewer.Modules.MarketPrices;
using DevDumps.Pats.Apps.PatsViewer.Regions;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace DevDumps.Pats.Apps.PatsViewer.MarketPrices
{
    public class MarketPricesModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public MarketPricesModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionName.ContentRegionName, typeof (MarketPricesView));
        }
    }
}