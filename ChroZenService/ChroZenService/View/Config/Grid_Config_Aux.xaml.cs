using ChroZenGC.Core.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChroZenService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Grid_Config_Aux : ContentView
    {
        public Grid_Config_Aux()
        {
            InitializeComponent();
        }
    }

    public class Aux4NameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch((Aux4Types)value)
            {
                case Aux4Types.Methanizer:
                    return "Methanizer";
                case Aux4Types.TransferLine:
                    return "Transfer Line";
            }

            return "Aux 4";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class Aux4MaxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((Aux4Types)value)
            {
                case Aux4Types.Methanizer:
                    return 400.0f;
                case Aux4Types.TransferLine:
                    return 350.0f;
            }

            return 250.0f;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class Aux4MinConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((Aux4Types)value)
            {
                case Aux4Types.TransferLine:
                    return 20.0f;
            }

            return 0.0f;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}