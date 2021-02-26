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
	public partial class UC_ON_OFF_Button : ContentView
	{
        #region IsOn

        public static readonly BindableProperty IsOnProperty = BindableProperty.Create("IsOn", typeof(bool), typeof(UC_ON_OFF_Button),
  defaultValue: false, defaultBindingMode: BindingMode.TwoWay);

        public bool IsOn
        {
            get { return (bool)GetValue(IsOnProperty); }
            set { SetValue(IsOnProperty, value); }
        }

        #endregion IsOn

        #region ImageMargin

        public static readonly BindableProperty ImageMarginProperty = BindableProperty.Create("ImageMargin", typeof(Thickness), typeof(UC_ON_OFF_Button),
  defaultValue: new Thickness(0, 0, 0, -6));

        public Thickness ImageMargin
        {
            get { return (Thickness)GetValue(ImageMarginProperty); }
            set { SetValue(ImageMarginProperty, value); }
        }

        #endregion ImageMargin

        #region ButtonMargin

        public static readonly BindableProperty ButtonMarginProperty = BindableProperty.Create("ButtonMargin", typeof(Thickness), typeof(UC_ON_OFF_Button));

        public Thickness ButtonMargin
        {
            get { return (Thickness)GetValue(ButtonMarginProperty); }
            set { SetValue(ButtonMarginProperty, value); }
        }

        #endregion ButtonMargin

        #region OnCommand

        public static readonly BindableProperty OnCommandProperty = BindableProperty.Create("OnCommand", typeof(RelayCommand), typeof(UC_ON_OFF_Button)
            );


        public RelayCommand OnCommand
        {
            get { return (RelayCommand)GetValue(OnCommandProperty); }
            set { SetValue(OnCommandProperty, value); }
        }

        private static void onOnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).OnCommand = (RelayCommand)newValue;
            //}
        }

        #endregion OnCommand

        #region OffCommand

        public static readonly BindableProperty OffCommandProperty = BindableProperty.Create("OffCommand", typeof(RelayCommand), typeof(UC_ON_OFF_Button)
            );


        public RelayCommand OffCommand
        {
            get { return (RelayCommand)GetValue(OffCommandProperty); }
            set { SetValue(OffCommandProperty, value); }
        }

        private static void onOffCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).OffCommand = (RelayCommand)newValue;
            //}
        }

        #endregion OffCommand

        #region ClickCommandParameter

        public static readonly BindableProperty ClickCommandParameterProperty = BindableProperty.Create("ClickCommandParameter", typeof(object), typeof(UC_ON_OFF_Button)
            );

        public object ClickCommandParameter
        {
            get { return (object)GetValue(ClickCommandParameterProperty); }
            set { SetValue(ClickCommandParameterProperty, value); }
        }

        private static void onClickCommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).ClickCommandParameter = newValue;
            //}
        }

        #endregion ClickCommandParameter

        public UC_ON_OFF_Button ()
		{
			InitializeComponent ();
		}
	}
}