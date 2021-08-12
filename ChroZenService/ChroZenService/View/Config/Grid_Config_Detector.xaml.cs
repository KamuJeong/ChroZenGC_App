using ChroZenGC.Core.Packets;
using ChroZenGC.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChroZenService
{
    public class isTCDConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((DetectorTypes)value)
            {
                case DetectorTypes.TCD:
                case DetectorTypes.µTCD:
                    return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class hasIgnitorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((DetectorTypes)value)
            {
                case DetectorTypes.FID:
                case DetectorTypes.NPD:
                case DetectorTypes.FPD:
                case DetectorTypes.PFPD:
                    return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class hasEletrometerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((DetectorTypes)value)
            {
                case DetectorTypes.FID:
                case DetectorTypes.NPD:
                case DetectorTypes.FPD:
                case DetectorTypes.PFPD:
                case DetectorTypes.µECD:
                    return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DetectorMaxTempConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((DetectorTypes)value)
            {
                case DetectorTypes.FID:
                    return 450.0f;
                case DetectorTypes.µTCD:
                    return 350.0f;
            }
            return 400.0f;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DetectorFlowEnableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !string.IsNullOrEmpty((string)(new DetectorGasConverter().Convert(value, typeof(string), "0", culture))) ||
                !string.IsNullOrEmpty((string)(new DetectorGasConverter().Convert(value, typeof(string), "1", culture))) ||
                !string.IsNullOrEmpty((string)(new DetectorGasConverter().Convert(value, typeof(string), "2", culture)));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DetectorGasEnableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !string.IsNullOrEmpty((string)(new DetectorGasConverter().Convert(value, typeof(string), parameter, culture)));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DetectorGasMaxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var gas = new DetectorGasConverter().Convert(value, typeof(string), parameter, culture);

            if ((DetectorTypes)value == DetectorTypes.µTCD)
            {
                switch (int.Parse((string)parameter))
                {
                    case 0: return 10.0f;
                    case 1: return 20.0f;
                }
            }
            else
            {
                switch (int.Parse((string)parameter))
                {
                    case 0:
                        switch (gas)
                        {
                            case "Air":
                            case "Air2":
                                return 500.0f;
                        }
                        return 100.0f;
                    case 1:
                        return 100.0f;
                    case 2:
                        return 150.0f;
                }
            }
            return 0.0f;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Grid_Config_Detector : ContentView
    {
        public Grid_Config_Detector()
        {
            InitializeComponent();
        }
    }
}