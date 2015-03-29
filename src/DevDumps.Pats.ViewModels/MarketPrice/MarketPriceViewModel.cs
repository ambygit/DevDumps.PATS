using DevDumps.Pats.Gateway.Clients.Market;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.ViewModel;

namespace DevDumps.Pats.ViewModels.MarketPrice
{
    public class MarketPriceViewModel : NotificationObject
    {
        private readonly string _currencyPair;
        private readonly IEventAggregator _eventAggregator;
        private string _price;

        public MarketPriceViewModel(string currencyPair, IEventAggregator eventAggregator)
        {
            _currencyPair = currencyPair;
            _eventAggregator = eventAggregator;
        }

        public void Update(MarketPriceEventArgs eventArgs)
        {
            Price = eventArgs.MarketPrice.BidPrice.ToString();
        }

        public string CurrencyPair
        {
            get { return _currencyPair; }
        }

        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged(() => Price);
            }
        }
    }
}