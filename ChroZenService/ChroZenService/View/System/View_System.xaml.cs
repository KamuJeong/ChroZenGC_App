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

        public View_System(ViewModel_System model)
        {
            InitializeComponent();

            BindingContext = model;
        }

        public async void PreInitialize()
        {
            InitView(1);
            await Task.Yield();
            InitView(3);
            await Task.Yield();

        }

        public async void Initialize()
        {
            InitView(2);
            await Task.Yield();
        }

        private void InitView(int select)
        {
            if (Views.ContainsKey(select))
                return;

            View view = null;
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
                                                            .Except(new Xamarin.Forms.View[] { topDeco, midDeco });

                    foreach (var item in unselectedItems)
                    {
                        DecorateSelectedItem(item, false);
                    }

                    topDeco.IsVisible = select == 1;
                    midDeco.IsVisible = new int[] { 2, 3, 4, 5, 6 }.Any(s => s == select);

                    if (midDeco.IsVisible)
                        midDeco.SetValue(Grid.RowProperty, select);

                    var selectedItems = selector.Children.Where(i => (int)i.GetValue(Grid.RowProperty) == select)
                                                            .Except(new Xamarin.Forms.View[] { topDeco, midDeco });

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