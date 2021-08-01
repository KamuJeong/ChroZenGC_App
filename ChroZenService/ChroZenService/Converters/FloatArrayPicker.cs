using ChroZenGC.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{
    public class FloatArrayPicker : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(value is ArrayWrapper<float> arr)
            {
                return arr[int.Parse((string)parameter)];
            }
            return float.NaN;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
