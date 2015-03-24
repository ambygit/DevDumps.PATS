using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DevDumps.Pats.Model.Market;

namespace DevDumps.Pats.Gateway.Clients.Market
{
    public interface IPricingServiceClient
    {
        event BrokerPriceUpdateHandler PriceUpdate;
        void Subscribe(string currencyPair);
    }

    public class PricingServiceClient : IPricingServiceClient
    {
        public event BrokerPriceUpdateHandler PriceUpdate;
        private readonly Random _random = new Random();
        private readonly Dictionary<string, BrokerPrice> _subscriptions = new Dictionary<string, BrokerPrice>();
        private readonly Timer _timer;

        public PricingServiceClient()
        {
            _timer = new Timer(TimerTick,null,1000,1000);
        }

        private void TimerTick(object state)
        {
            SendPriceUpdate();
        }

        public void Subscribe(string currencyPair)
        {
            if (currencyPair == null) throw new ArgumentNullException("currencyPair");
            //ToDo: retain callback handler
            _subscriptions.Add(currencyPair,BrokerPrice.GetSamplePrice(currencyPair));
        }

        private void SendPriceUpdate()
        {
            foreach (var subscription in _subscriptions)
            {
                var brokerPrice = subscription.Value;
                double initialBid = Math.Max(0.1, brokerPrice.BidPrice + ((_random.NextDouble() * 2.0) - 1));
                double initialAsk = initialBid + (_random.NextDouble() + 0.5);
                brokerPrice.Update(initialBid, initialAsk);
                Task.Factory.StartNew(() =>
                {
                    var updateHandler = PriceUpdate;
                    if (updateHandler != null)
                    {
                        updateHandler(this, new BrokerPriceEventArgs() {BrokerPrice = brokerPrice});
                    }
                }
                    );
            }
            
        }
    }
}
