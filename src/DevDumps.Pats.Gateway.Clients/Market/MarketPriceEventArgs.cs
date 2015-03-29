using System;
using DevDumps.Pats.Model.Market;

namespace DevDumps.Pats.Gateway.Clients.Market
{

    public delegate void MarketPriceUpdateHandler(object sender, MarketPriceEventArgs eventArgs);

    public class MarketPriceEventArgs : EventArgs
    {
        public MarketPrice MarketPrice { get; set; }
        public string CurrencyPair { get; set; }
    }
}