using DevDumps.Pats.Gateway.Clients.Market;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.ViewModel;

namespace DevDumps.Pats.ViewModels.MarketPrice
{
    public class MarketPriceViewModel : NotificationObject
    {
        private readonly string _currencyPair;
        private readonly IEventAggregator _eventAggregator;
        private PriceViewModel _bid = new PriceViewModel();
        private PriceViewModel _ask = new PriceViewModel();

        public MarketPriceViewModel(string currencyPair, IEventAggregator eventAggregator)
        {
            _currencyPair = currencyPair;
            _eventAggregator = eventAggregator;
        }

        public void Update(MarketPriceEventArgs eventArgs)
        {
            Bid.Update(eventArgs.MarketPrice.BidPrice);
            Ask.Update(eventArgs.MarketPrice.AskPrice);
        }

        public string CurrencyPair
        {
            get { return _currencyPair; }
        }

        public PriceViewModel Bid
        {
            get { return _bid; }
            set
            {
                _bid = value;
                RaisePropertyChanged(() => Bid);
            }
        }

        public PriceViewModel Ask
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