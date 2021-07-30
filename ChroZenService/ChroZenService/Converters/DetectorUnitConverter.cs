using ChroZenGC.Core.Packets;
using System;
using Xamarin.Forms;

namespace ChroZenService
{
    public class DetectorUnitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DetectorTypes detectorType = DetectorTypes.None;

            int detectorIndex = (int)value;
            if (detectorIndex >= 0 && detectorIndex <= 3)
                detectorType = Resolver.Resolve<ChroZenGC.Core.Model>().Configuration.DetectorType[detectorIndex];

            



            return "mV";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
