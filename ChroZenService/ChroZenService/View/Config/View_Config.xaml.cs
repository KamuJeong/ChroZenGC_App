using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChroZenService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View_Config : ContentView
    {
        public View_Config(ViewModel_Config model)
        {
            InitializeComponent();

            BindingContext = model;
        }

        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create("SelectedItem", typeof(int), typeof(View_Config), 1);

        public int SelectedItem
        {
            get => (int)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        private void OnSelectorClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                int select = (int)button.Parent.GetValue(Grid.RowProperty);

                if (select != SelectedItem)
                {
                    var unselectedItems = selector.Children.Where(i => (int)i.GetValue(Grid.RowProperty) == SelectedItem)
                                                            .Except(new View[] { topDeco, midDeco, botDeco });

                    foreach (var item in unselectedItems)
                    {
                        DecorateSelectedItem(item, false);
                    }

                    topDeco.IsVisible = select == 1;
                    midDeco.IsVisible = new int[] { 3, 4, 5, 7, 8, 9, 11, 12 }.Any(s => s == select);
                    botDeco.IsVisible = select == 13;

                    if (midDeco.IsVisible)
                        midDeco.SetValue(Grid.RowProperty, select);

                    var selectedItems = selector.Children.Where(i => (int)i.GetValue(Grid.RowProperty) == select)
                                                            .Except(new View[] { topDeco, midDeco, botDeco });

                    foreach (var item in selectedItems)
                    {
                        item.SetValue(Grid.RowProperty, 0);
                        item.SetValue(Grid.RowProperty, select);

                        DecorateSelectedItem(item, true);
                    }

                    SelectedItem = select;
                }
            }
        }

        private void DecorateSelectedItem(BindableObject item, bool select)
        {
            if (item is Grid grid)
            {
                foreach (var child in grid.Children)
                {
                    if(child is Label label)
                    {
                        if (select)
                        {
                            label.TextColor = Color.White;
                            label.FontAttributes = FontAttributes.Bold;
                            label.Scale = 1.3;
                            //label.FontSize = (double)Application.Current.Resources["ButtonFontSizeKey"];
                        }
                        else
                        {
                            label.TextColor = Color.Silver;
                            label.FontAttributes = FontAttributes.None;
                            label.Scale = 1.2;
                            //label.FontSize = (double)Application.Current.Resources["DefaultFontSizeKey"];
                        }
                    }
                }
            }
        }
    }
}