using System;
using System.Data;
using System.Globalization;
using System.Windows.Data;

namespace DevDumps.WPFSDK.Common.Converters
{
    public class DoubleToPrecisionConverter : IValueConverter
    {
        public int Precision { get; set; }//Supporting upto 5
        private const string NanValue = "-";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var doubleValue = (double) value;

            if (double.IsNaN(doubleValue))
            {
                return NanValue;
            }

            var lowPrecision =  Math.Round(doubleValue, Precision);
            return lowPrecision.ToString("0.00###");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}