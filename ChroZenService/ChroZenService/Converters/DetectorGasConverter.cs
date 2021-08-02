using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{
    public class DetectorGasConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DetectorTypes detectorType = value != null ? (DetectorTypes)value : DetectorTypes.NotInstalled;

            return int.Parse((string)parameter) switch
            {
                0 => detectorType.Gas1(),
                1 => detectorType.Gas2(),
                2 => detectorType.Gas3(),
                _ => ""
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}