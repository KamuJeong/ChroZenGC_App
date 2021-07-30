using ChroZenGC.Core.Packets;
using System;
using Xamarin.Forms;

namespace ChroZenService
{
    public class DetectorTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int detectorIndex = (int)value;
            if(detectorIndex >= 0 && detectorIndex <= 3)
                return Resolver.Resolve<ChroZenGC.Core.Model>().Configuration.DetectorType[detectorIndex];

            return DetectorTypes.None;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
