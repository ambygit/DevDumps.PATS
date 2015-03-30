using DevDumps.Pats.Gateway.Clients.Market;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.ViewModel;

namespace DevDumps.Pats.ViewModels.MarketPrice
{
    public class MarketPriceViewModel : NotificationObject
    {
        private readonly string _currencyPair;
        private readonly IEventAggregator _eventAggregator;
        private double _bid;
        private double _ask;

        public MarketPriceViewModel(string currencyPair, IEventAggregator eventAggregator)
        {
            _currencyPair = currencyPair;
            _eventAggregator = eventAggregator;
        }

        public void Update(MarketPriceEventArgs eventArgs)
        {
            Bid = eventArgs.MarketPrice.BidPrice;
            Ask = eventArgs.MarketPrice.AskPrice;
        }

        public string CurrencyPair
        {
            get { return _currencyPair; }
        }

        public double Bid
        {
            get { return _bid; }
            set
            {
                _bid = value;
                RaisePropertyChanged(() => Bid);
            }
        }

        public double Ask
        {
            get { return _ask; }
            set
            {
                _ask = value;
                RaisePropertyChanged(()=>Ask);
            }
        }
    }
}