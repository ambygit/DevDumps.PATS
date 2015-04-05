using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DevDumps.Pats.Gateway.Clients.Market;
using DevDumps.WPFSDK.Core.Prism;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.ViewModel;

namespace DevDumps.Pats.ViewModels.MarketPrice
{
    public class MarketPricesViewModel : NotificationObject
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IPricingServiceClient _pricingServiceClient;
        private readonly ConcurrentDictionary<string,MarketPriceViewModel> _currencyToMarketPriceViewModel = new ConcurrentDictionary<string, MarketPriceViewModel>(); 
        private readonly  ObservableCollection<MarketPriceViewModel> _marketPrices = new ObservableCollection<MarketPriceViewModel>(); 
        private object _syncLock = new object();


        public MarketPricesViewModel(IEventAggregator eventAggregator, IPricingServiceClient pricingServiceClient)
        {
            _eventAggregator = eventAggregator;
            _pricingServiceClient = pricingServiceClient;
            _pricingServiceClient.PriceUpdate += HandlePricingServiceClientPriceUpdate;
            AddEmptySlot();
        }

        public void AddEmptySlot()
        {
            Subscribe(null);
        }

        private void Subscribe(string currencyPair)
        {
            var subscriptionKey = currencyPair;
            MarketPriceViewModel marketPriceViewModel;
            if (subscriptionKey == null)
            {
                marketPriceViewModel  = new MarketPriceViewModel("",_eventAggregator , _pricingServiceClient);
                marketPriceViewModel.IsBound = false;
            }
            else
            {
                 marketPriceViewModel = _currencyToMarketPriceViewModel.GetOrAdd(subscriptionKey,
              (key) => new MarketPriceViewModel(key, _eventAggregator,_pricingServiceClient));
            }
            lock (_syncLock)
            {
                //allow multiple UI for same subscription, add new for each subscription
                _marketPrices.Add(marketPriceViewModel);
            }
        }


        void HandlePricingServiceClientPriceUpdate(object sender, MarketPriceEventArgs eventArgs)
        {
            var subscriptionKey = eventArgs.CurrencyPair;

            MarketPriceViewModel marketPriceViewModel;
            if (_currencyToMarketPriceViewModel.TryGetValue(subscriptionKey, out marketPriceViewModel))
            {
                marketPriceViewModel.Update(eventArgs);
            }
            //else.. log unexpected price
        }


        public ObservableCollection<MarketPriceViewModel> MarketPrices
        {
            get { return _marketPrices; }
        }
    }
}
