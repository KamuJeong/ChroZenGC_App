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
    public partial class View_System : ContentView
    {
        private Dictionary<int, Xamarin.Forms.View> Views { get; } = new Dictionary<int, Xamarin.Forms.View>();

        public ViewModel_System Model => (ViewModel_System)BindingContext;


        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create("SelectedItem", typeof(int), typeof(View_System), 
                                                                        defaultBindingMode: BindingMode.TwoWay, propertyChanged: SelectItemChanged);

        private static void SelectItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if(bindable is View_System view)
            {
                view.Select((int)oldValue, (int)newValue);
            }
        }

        public int SelectedItem
        {
            get => (int)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public View_System(ViewModel_System model)
        {
            InitializeComponent();

            BindingContext = model;

            SetBinding(SelectedItemProperty, new Binding("SelectedItem"));
        }

        public async void PreInitialize()
        {
            InitView(1);
            await Task.Delay(100);
            InitView(2);
            await Task.Delay(100);
            InitView(3);
            await Task.Delay(100);
            InitView(4);
            await Task.Delay(100);
            InitView(5);
            await Task.Delay(100);
            InitView(6);
            await Task.Delay(100);
        }

        public async void Initialize()
        {
            for(int i=0; i<14; ++i)
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
                foreach (var e in element.LogicalChildren)
                {
                    if (e is ScrollView scroll)
                        scroll.ScrollToAsync(0, 0, false);

                    ScrollToTop(e);
                }
            }

            if (Views.ContainsKey(select))
            {
                ScrollToTop(Views[select]);
                return;
            }

            Xamarin.Forms.View view = null;
            switch (select)
            {
                case 1:
                    view = Resolver.Resolve<View_System_Information>();
                    break;
                case 2:
                    view = Resolver.Resolve<View_System_Config>();
                    break;
                case 3:
                    view = Resolver.Resolve<View_System_Settings>();
                    break;
                case 4:
                    view = Resolver.Resolve<View_System_Diagnostics>();
                    break;
                case 5:
                    view = Resolver.Resolve<View_System_Calibration>();
                    view.BindingContext = Model.Calibration;
                    break;
                case 6:
                    view = Resolver.Resolve<View_System_TimeControl>();
                    break;
                case 7:
                    view = Resolver.Resolve<View_System_About>();
                    break;

            }

            if (view != null)
            {
                gridMain.Children.Add(view);
                Grid.SetColumn(view, 2);
                Views[select] = view;

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
                        case 4:
                            (v as View_System_Diagnostics)?.GoHome();
                            break;
                        case 5:
                            (v as View_System_Calibration)?.GoHome();
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
                ShowView();
            }
        }

        private void Select(int oldValue, int newValue)
        {
            var unselectedItems = selector.Children.Where(i => (int)i.GetValue(Grid.RowProperty) == oldValue)
                                        .Except(new Xamarin.Forms.View[] { topDeco, midDeco });

            foreach (var item in unselectedItems)
            {
                DecorateSelectedItem(item, false);
            }

            topDeco.IsVisible = newValue == 1;
            midDeco.IsVisible = new int[] { 2, 3, 4, 5, 6, 7 }.Any(s => s == newValue);

            if (midDeco.IsVisible)
                midDeco.SetValue(Grid.RowProperty, newValue);

            var selectedItems = selector.Children.Where(i => (int)i.GetValue(Grid.RowProperty) == newValue)
                                                    .Except(new Xamarin.Forms.View[] { topDeco, midDeco });

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