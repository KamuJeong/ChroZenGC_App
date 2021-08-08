using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{

    public class IsNonZeroConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (double)System.Convert.ChangeType(value, typeof(double)) != 0;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
