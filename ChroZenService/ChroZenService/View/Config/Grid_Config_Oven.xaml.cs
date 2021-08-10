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
    public partial class Grid_Config_Oven : ContentView
    {
        public Grid_Config_Oven()
        {
            InitializeComponent();
        }
    }

    public class IsOvenProgramModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (OvenMode)value == OvenMode.Program;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? OvenMode.Program : OvenMode.Isothermal;
        }
    }
}