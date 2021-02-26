using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ChroZenService.ChroZenService_Const;
using static YC_ChroZenGC_Type.T_CHROZEN_GC_SYSTEM_CONFIG;

namespace ChroZenService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UC_MainPageButton : ContentView
    {
        MAIN_SIDE_BUTTON_TYPE _ButtonType = MAIN_SIDE_BUTTON_TYPE.DET;
        public MAIN_SIDE_BUTTON_TYPE ButtonType { get { return _ButtonType; } set { if (_ButtonType != value) { _ButtonType = value; OnPropertyChanged("ButtonType"); } } }

        public static readonly BindableProperty TapGestureCommandProperty = BindableProperty.Create("TapGestureCommand", typeof(RelayCommand), typeof(UC_MainPageButton),
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: onTapGestureCommandChanged);

        private static void onTapGestureCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
                (bindable as UC_MainPageButton).TapGestureCommand = (newValue as RelayCommand);
        }

        public RelayCommand TapGestureCommand
        {
            set
            {
                SetValue(TapGestureCommandProperty, value);
            }
            get
            {
                return (RelayCommand)GetValue(TapGestureCommandProperty);

            }
        }

        #region IsSelected : bool

        public static readonly BindableProperty IsSelectedProperty =
        BindableProperty.Create("IsSelected", typeof(bool), typeof(UC_MainPageButton),
            defaultValue: false,
            propertyChanged: onIsSelectedPropertyChanged
            , defaultBindingMode: BindingMode.TwoWay);

        private static void onIsSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as UC_MainPageButton).IsSelected = (bool)newValue;
            }
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        #endregion IsSelected : bool

        #region Title : string

        public static readonly BindableProperty TitleProperty =
        BindableProperty.Create("Title", typeof(string), typeof(UC_MainPageButton),
            defaultValue: "",
            propertyChanged: onTitlePropertyChanged
            , defaultBindingMode: BindingMode.OneWay);

        private static void onTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                //switch((bindable as UC_MainPageButton).ButtonType)
                //{
                //    case MAIN_SIDE_BUTTON_TYPE.DET:
                //        {
                //            (bindable as UC_MainPageButton).Title = ((E_DET_TYPE)newValue).ToString();
                //        }
                //        break;
                //    case MAIN_SIDE_BUTTON_TYPE.INLET:
                //        {
                //            (bindable as UC_MainPageButton).Title = ((E_INLET_TYPE)newValue).ToString();
                //        }
                //        break;
                //}
                (bindable as UC_MainPageButton).Title = newValue.ToString();
            }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        #endregion Title : string

        public UC_MainPageButton()
        {
            InitializeComponent();
        }
    }
}