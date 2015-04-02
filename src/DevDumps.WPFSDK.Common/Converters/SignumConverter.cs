using System;
using System.Globalization;
using System.Windows.Data;
using DevDumps.WPFSDK.Core.Extensions;

namespace DevDumps.WPFSDK.Common.Converters
{
    public class SignumConverter : IMultiValueConverter
    {
        public virtual object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 2) return 0;
            if (values[0] == null || !values[0].GetType().Implements<IConvertible>()) return 0;
            if (values[1] == null || !values[1].GetType().Implements<IConvertible>()) return 0;
            var v0 = System.Convert.ToDouble(values[0]);
            if (double.IsNaN(v0)) return 0;
            var v1 = System.Convert.ToDouble(values[1]);
            if (double.IsNaN(v1)) return 0;

            int result = GetResult(v0, v1);
            return result;
        }

        public virtual object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        protected virtual int GetResult(double lhs, double rhs)
        {
            return Math.Sign(lhs - rhs);
        }
        
    }
}