using System;
using DevDumps.Pats.Model.Market;

namespace DevDumps.Pats.Gateway.Clients.Market
{

    public delegate void BrokerPriceUpdateHandler(object sender, BrokerPriceEventArgs eventArgs);

    public class BrokerPriceEventArgs : EventArgs
    {
        public BrokerPrice BrokerPrice { get; set; }
    }
}