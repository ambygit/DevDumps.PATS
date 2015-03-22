using Microsoft.Practices.Prism.PubSubEvents;

namespace DevDumps.Pats.ViewModels.MarketPrices
{
    public class MarketPricesViewModel
    {
        public MarketPricesViewModel(IEventAggregator eventAggregator)
        {
            Price = (1.23).ToString();
        }

        public string Price { get; set; }
    }
}
