using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChroZenService
{
    public class LastTabWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var length = string.IsNullOrEmpty((string)value) ? new GridLength(0) : GridLength.Star;
            return length;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View_Config_Tab : ContentView
    {
        public static readonly BindableProperty Tab1Property = BindableProperty.Create("Tab1", typeof(string), typeof(View_Config_Tab), "Config");

        public string Tab1
        {
            get => (string)GetValue(Tab1Property);
            set => SetValue(Tab1Property, value);
        }

        public static readonly BindableProperty Tab2Property = BindableProperty.Create("Tab2", typeof(string), typeof(View_Config_Tab), "Settings");

        public string Tab2
        {
            get => (string)GetValue(Tab2Property);
            set => SetValue(Tab2Property, value);
        }

        public static readonly BindableProperty Tab3Property = BindableProperty.Create("Tab3", typeof(string), typeof(View_Config_Tab), "");

        public string Tab3
        {
            get => (string)GetValue(Tab3Property);
            set => SetValue(Tab3Property, value);
        }


        public static readonly BindableProperty SelectedTabItemProperty = BindableProperty.Create("SelectedTabItem", typeof(int), typeof(View_Config_Tab), -1, propertyChanged: SelectedTabItemPropertyChanged);

        private static void SelectedTabItemPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is View_Config_Tab tab && tab.TabContent != null)
            {
                var grid = tab.TabContent.Content as Grid;

                foreach (var item in grid.Children)
                {
                    item.IsVisible = false;
                }

                for (int i = 0; i < grid.ColumnDefinitions.Count(); ++i)
                {
                    grid.ColumnDefinitions[i].Width = i == (int)newValue ? GridLength.Star : new GridLength(0);
                }

                foreach(var item in grid.Children)
                {
                    item.IsVisible = (int)item.GetValue(Grid.ColumnProperty) == (int)newValue; 
                }
            };
        }


        public int SelectedTabItem
        {
            get => (int)GetValue(SelectedTabItemProperty);
            set => SetValue(SelectedTabItemProperty, value);
        }

        public static readonly BindableProperty TabContentProperty = BindableProperty.Create("TabContent", typeof(ContentView), typeof(View_Config_Tab), null);

        public ContentView TabContent
        {
            get => (ContentView)GetValue(TabContentProperty);
            set => SetValue(TabContentProperty, value);
        }

        public View_Config_Tab()
        {
            InitializeComponent();
        }

        private void OnSelectTabItem(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                SelectedTabItem = (int)button.Parent.GetValue(Grid.ColumnProperty);
            }
        }
    }
}