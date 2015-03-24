using DevDumps.Pats.Gateway.Clients.Market;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.ViewModel;

namespace DevDumps.Pats.ViewModels.MarketPrices
{
    public class MarketPricesViewModel : NotificationObject
    {
        private readonly IPricingServiceClient _pricingServiceClient;
        private string _price;

        public MarketPricesViewModel(IEventAggregator eventAggregator, IPricingServiceClient pricingServiceClient)
        {
            _pricingServiceClient = pricingServiceClient;
            _pricingServiceClient.PriceUpdate += HandlePricingServiceClientPriceUpdate;
            Subscribe("EURJPY");
        }

        void HandlePricingServiceClientPriceUpdate(object sender, BrokerPriceEventArgs eventArgs)
        {
            Price = eventArgs.BrokerPrice.BidPrice.ToString();           
        }

        public void Subscribe(string currencyPair)
        {
            //TODO: get this from UI subscribtion
            _pricingServiceClient.Subscribe(currencyPair);

        }

        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged(()=>Price);
            }
        }
    }
}
