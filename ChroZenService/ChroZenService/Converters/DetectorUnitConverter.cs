using ChroZenGC.Core.Packets;
using System;
using Xamarin.Forms;

namespace ChroZenService
{
    public class DetectorUnitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DetectorTypes detectorType = value != null? (DetectorTypes)value : DetectorTypes.NotInstalled;
            return detectorType.Unit();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
