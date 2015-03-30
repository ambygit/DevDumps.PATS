using System;
using System.Globalization;
using System.Windows.Data;

namespace DevDumps.WPFSDK.Common.Converters
{
    public class DoubleToPrecisionConverter : IValueConverter
    {
        public int Precision { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var doubleValue = (double) value;
            return Math.Round(doubleValue, Precision);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}