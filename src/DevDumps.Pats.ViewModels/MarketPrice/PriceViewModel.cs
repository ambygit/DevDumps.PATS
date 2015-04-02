using Microsoft.Practices.Prism.ViewModel;

namespace DevDumps.Pats.ViewModels.MarketPrice
{
    public class PriceViewModel : NotificationObject
    {
        private double _oldValue;
        private double _newValue;

        public void Update(double newPrice)
        {
            OldValue = NewValue;
            NewValue = newPrice;
        }

        public double NewValue
        {
            get { return _newValue; }
            set
            {
                _newValue = value;
                RaisePropertyChanged(()=>NewValue);
            }
        }

        public double OldValue
        {
            get { return _oldValue; }
            set
            {
                _oldValue = value;
                RaisePropertyChanged(()=>OldValue);
            }
        }
    }
}