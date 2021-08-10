using ChroZenService.ViewModel.Main;
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
    public partial class View_Main_Center : ContentView
    {
        public View_Main_Center()
        {
            InitializeComponent();
        }

    }

    public class ContentHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            => int.Parse((string)parameter) == (int)value || ((int)value == -1 && int.Parse((string)parameter) == 2) ? new GridLength(58, GridUnitType.Star) : new GridLength(0);

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}