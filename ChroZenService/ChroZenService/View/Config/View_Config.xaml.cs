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
        private Dictionary<int, Xamarin.Forms.View> Views { get; } = new Dictionary<int, Xamarin.Forms.View>();


        public View_Config(ViewModel_Config model)
        {
            InitializeComponent();

            BindingContext = model;

            ShowView();
        }

        private void ShowView()
        {
            if (Views.TryGetValue(SelectedItem, out Xamarin.Forms.View view))
            {
                selectedView.Content = view;
            }
            else
            {
                //switch(SelectedItem)
                //{
 




                //}

            }
        }

        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create("SelectedItem", typeof(int), typeof(View_Config), 1);

        public int SelectedItem
        {
            get => (int)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public static readonly BindableProperty Tab1Property = BindableProperty.Create("Tab1", typeof(string), typeof(View_Config), "Config");

        public string Tab1
        {
            get => (string)GetValue(Tab1Property);
            set => SetValue(Tab1Property, value);
        }

        public static readonly BindableProperty Tab2Property = BindableProperty.Create("Tab2", typeof(string), typeof(View_Config), "Settings");

        public string Tab2
        {
            get => (string)GetValue(Tab2Property);
            set => SetValue(Tab2Property, value);
        }

        public static readonly BindableProperty Tab3Property = BindableProperty.Create("Tab3", typeof(string), typeof(View_Config), "");

        public string Tab3
        {
            get => (string)GetValue(Tab3Property);
            set => SetValue(Tab3Property, value);
        }

        public static readonly BindableProperty SelectedTabItemProperty = BindableProperty.Create("SelectedTabItem", typeof(int), typeof(View_Config), 1);

        public int SelectedTabItem
        {
            get => (int)GetValue(SelectedTabItemProperty);
            set => SetValue(SelectedTabItemProperty, value);
        }

        private void OnSelectorClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                int select = (int)button.Parent.GetValue(Grid.RowProperty);

                if (select != SelectedItem)
                {
                    var unselectedItems = selector.Children.Where(i => (int)i.GetValue(Grid.RowProperty) == SelectedItem)
                                                            .Except(new Xamarin.Forms.View[] { topDeco, midDeco, botDeco });

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
                                                            .Except(new Xamarin.Forms.View[] { topDeco, midDeco, botDeco });

                    foreach (var item in selectedItems)
                    {
                        item.SetValue(Grid.RowProperty, 0);
                        item.SetValue(Grid.RowProperty, select);

                        DecorateSelectedItem(item, true);
                    }

                    SelectedItem = select;

                    ShowView();
                }
            }
        }

        private void DecorateSelectedItem(BindableObject item, bool select)
        {
            if (item is Grid grid)
            {
                foreach (var child in grid.Children)
                {
                    if (child is Label label)
                    {
                        if (select)
                        {
                            label.TextColor = Color.White;
                            label.FontAttributes = FontAttributes.Bold;
                            label.Scale = 1.3;
                        }
                        else
                        {
                            label.TextColor = Color.Silver;
                            label.FontAttributes = FontAttributes.None;
                            label.Scale = 1.2;
                        }
                    }
                }
            }
        }
    }
}