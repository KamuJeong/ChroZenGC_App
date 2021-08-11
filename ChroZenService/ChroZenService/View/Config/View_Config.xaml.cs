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

        public ViewModel_Config Model => (ViewModel_Config)BindingContext;

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
                foreach (var v in gridMain.Children.Where(v => (int)v.GetValue(Grid.ColumnProperty) == 2))
                {
                    v.IsVisible = v == view;

                    switch(SelectedItem)
                    {
                        case 8:
                            break;
                        default:
                            //(v as View_Config_Tab)?.SelectedTabItem = 1;
                            break;
                    }
                }
            }
            else
            {
                foreach (var v in gridMain.Children.Where(v => (int)v.GetValue(Grid.ColumnProperty) == 2))
                {
                    v.IsVisible = false;
                }

                View_Config_Tab tab = null;
                switch (SelectedItem)
                {
                    case 1:
                        tab = Resolver.Resolve<View_Config_Tab>();
                        tab.TabContent = Resolver.Resolve<Grid_Config_Oven>();
                        tab.SelectedTabItem = 1;
                        break;
                    case 3:
                    case 4:
                    case 5:
                        tab = Resolver.Resolve<View_Config_Tab>();
                        tab.TabContent = Resolver.Resolve<Grid_Config_Inlet>();
                        tab.SelectedTabItem = 1;
                        Views[3] = Views[4] = Views[5] = tab;
                        break;
                    case 7:
                    case 8:
                    case 9:
                        tab = Resolver.Resolve<View_Config_Tab>();
                        tab.TabContent = Resolver.Resolve<Grid_Config_Detector>();
                        tab.SelectedTabItem = 1;
                        Views[7] = Views[8] = Views[9] = tab;
                        break;
                    case 13:
                        //tab = Resolver.Resolve<View_Config_Tab>();
                        //tab.TabContent = Resolver.Resolve<View_Config_InletConfig_Front>();
                        //tab.SelectedTabItem = 0;
                        break;
                }

                if (tab != null)
                {
                    gridMain.Children.Add(tab);
                    Grid.SetColumn(tab, 2);

                    Views[SelectedItem] = tab;
                }
            }
        }

        public int SelectedItem
        {
            get => Model.SelectedItem;
            set => Model.SelectedItem = value;
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