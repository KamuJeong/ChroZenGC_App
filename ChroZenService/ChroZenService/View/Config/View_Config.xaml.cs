using ChroZenGC.Core.Packets;
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

        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create("SelectedItem", typeof(int), typeof(View_Config),
                                                                        defaultBindingMode: BindingMode.TwoWay, propertyChanged: SelectItemChanged);

        private static void SelectItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is View_Config view)
            {
                view.Select((int)oldValue, (int)newValue);
            }
        }

        public int SelectedItem
        {
            get => (int)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public View_Config(ViewModel_Config model)
        {
            InitializeComponent();

            BindingContext = model;

            SetBinding(SelectedItemProperty, new Binding("SelectedItem"));
        }

        public async void PreInitialize()
        {
            InitView(1);
            await Task.Delay(100);
            InitView(11);
            await Task.Delay(100);
            InitView(12);
            await Task.Delay(100);
            InitView(13);
            await Task.Delay(100);
        }

        public async void Initialize()
        {
            for (int i = 0; i < 14; ++i)
            {
                InitView(i);
                await Task.Yield();
            }
            SelectedItem = 1;
        }

        private void InitView(int select)
        {
            void ScrollToTop(Element element)
            {
                foreach(var e in element.LogicalChildren)
                {
                    if (e is ScrollView scroll)
                        scroll.ScrollToAsync(0, 0, false);

                    ScrollToTop(e);
                }
            }


            if (Views.ContainsKey(select))
            {
                if(Views[select] is View_Config_Tab t)
                {
                    t.SelectedTabItem = select < 10 ? 1 : 0;
                    ScrollToTop(t);
                }
                return;
            }

            View_Config_Tab tab = null;
            switch (select)
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
                    tab.BindingContext = Model.Inlets[select - 3];
                    tab.SelectedTabItem = 1;
                    break;
                case 7:
                case 8:
                case 9:
                    tab = Resolver.Resolve<View_Config_Tab>();
                    tab.TabContent = Resolver.Resolve<Grid_Config_Detector>();
                    tab.BindingContext = Model.Detectors[select - 7];
                    tab.SelectedTabItem = 1;
                    break;
                case 11:
                    tab = Resolver.Resolve<View_Config_Tab>();
                    tab.Tab1 = "Signal 1";
                    tab.Tab2 = "Signal 2";
                    tab.Tab3 = "Signal 3";
                    tab.TabContent = Resolver.Resolve<Grid_Config_Signal>();
                    tab.SelectedTabItem = 0;
                    break;
                case 12:
                    tab = Resolver.Resolve<View_Config_Tab>();
                    tab.Tab1 = "Initial";
                    tab.Tab2 = "Program";
                    tab.TabContent = Resolver.Resolve<Grid_Config_Valve>();
                    tab.BindingContext = Model.Valve;
                    tab.SelectedTabItem = 0;
                    break;
                case 13:
                    tab = Resolver.Resolve<View_Config_Tab>();
                    tab.Tab1 = "Temperature";
                    tab.Tab2 = "Flow";
                    tab.TabContent = Resolver.Resolve<Grid_Config_Aux>();
                    tab.SelectedTabItem = 0;
                    break;
            }

            if (tab != null)
            {
                gridMain.Children.Add(tab);
                Grid.SetColumn(tab, 2);
                Views[select] = tab;

                ShowView();
            }
        }


        private void ShowView()
        {
            if (Views.TryGetValue(SelectedItem, out Xamarin.Forms.View view))
            {
                foreach (var v in gridMain.Children.Where(v => (int)v.GetValue(Grid.ColumnProperty) == 2))
                {
                    v.IsVisible = v == view;

                    switch (SelectedItem)
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

                InitView(SelectedItem);
            }
        }


        private void OnSelectorClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                SelectedItem = (int)button.Parent.GetValue(Grid.RowProperty);
            }
        }

        private void Select(int oldValue, int newValue)
        {
            var unselectedItems = selector.Children.Where(i => (int)i.GetValue(Grid.RowProperty) == oldValue)
                                        .Except(new Xamarin.Forms.View[] { topDeco, midDeco, botDeco });

            foreach (var item in unselectedItems)
            {
                DecorateSelectedItem(item, false);
            }


            topDeco.IsVisible = newValue == 1;
            midDeco.IsVisible = new int[] { 3, 4, 5, 7, 8, 9, 11, 12 }.Any(s => s == newValue);
            botDeco.IsVisible = newValue == 13;

            if (midDeco.IsVisible)
                midDeco.SetValue(Grid.RowProperty, newValue);

            var selectedItems = selector.Children.Where(i => (int)i.GetValue(Grid.RowProperty) == newValue)
                                                    .Except(new Xamarin.Forms.View[] { topDeco, midDeco, botDeco });

            foreach (var item in selectedItems)
            {
                item.SetValue(Grid.RowProperty, 0);
                item.SetValue(Grid.RowProperty, newValue);

                DecorateSelectedItem(item, true);
            }
            ShowView();
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