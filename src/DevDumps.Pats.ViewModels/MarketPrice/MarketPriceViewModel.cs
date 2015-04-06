using System.Windows.Input;
using DevDumps.Pats.Gateway.Clients.Market;
using DevDumps.WPFSDK.Core.Prism;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.ViewModel;

namespace DevDumps.Pats.ViewModels.MarketPrice
{
    public class MarketPriceViewModel : NotificationObject
    {
        private ICommand _subcribeCommand;
        public ICommand SubscribeCommand
        {
            get
            {
                return _subcribeCommand ??
                       (_subcribeCommand = new RelayCommand(o => SubscribeCurrency(o)));
            }
        }

        private string _currencyPair;
        private readonly IEventAggregator _eventAggregator;
        private readonly IMarketPricesSubscriptionManager _marketPricesSubscriptionManager;
        private PriceViewModel _bid = new PriceViewModel();
        private PriceViewModel _ask = new PriceViewModel();
        private bool _isBound;

        public MarketPriceViewModel(string currencyPair, IEventAggregator eventAggregator, IMarketPricesSubscriptionManager marketPricesSubscriptionManager)
        {
            _currencyPair = currencyPair;
            _eventAggregator = eventAggregator;
            _marketPricesSubscriptionManager = marketPricesSubscriptionManager;
        }


        private void SubscribeCurrency(object parameter)
        {
            var currencyPair = parameter as string;
            //ToDO:Validate
            if (currencyPair != null)
            {
                CurrencyPair = currencyPair.ToUpper();
                IsBound = true;
                Subscribe(CurrencyPair);
            }
        }

        private void Subscribe(string currencyPair)
        {
            _marketPricesSubscriptionManager.Subscribe(this, currencyPair);
        }

        public void Update(MarketPriceEventArgs eventArgs)
        {
            Bid.Update(eventArgs.MarketPrice.BidPrice);
            Ask.Update(eventArgs.MarketPrice.AskPrice);
        }

        public string CurrencyPair
        {
            get { return _currencyPair; }
            set
            {
                _currencyPair = value;
                RaisePropertyChanged(()=>CurrencyPair);
            }
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

        public bool IsBound
        {
            get { return _isBound; }
            set
            {
                _isBound = value;
                RaisePropertyChanged(()=>IsBound);
            }
        }

    }
}