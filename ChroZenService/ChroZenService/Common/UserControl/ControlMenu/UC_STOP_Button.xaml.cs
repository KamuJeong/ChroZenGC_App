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
	public partial class UC_STOP_Button : ContentView
	{
        #region BindableProperty

        #region ButtonWidth

        public static readonly BindableProperty ButtonWidthProperty = BindableProperty.Create("ButtonWidth", typeof(double), typeof(UC_STOP_Button));

        public double ButtonWidth
        {
            get { return (double)GetValue(ButtonWidthProperty); }
            set { SetValue(ButtonWidthProperty, value); }
        }

        #endregion ButtonWidth

        #region ButtonHeight

        public static readonly BindableProperty ButtonHeightProperty = BindableProperty.Create("ButtonHeight", typeof(double), typeof(UC_STOP_Button));

        public double ButtonHeight
        {
            get { return (double)GetValue(ButtonHeightProperty); }
            set { SetValue(ButtonHeightProperty, value); }
        }

        #endregion ButtonHeight

        #region ButtonMargin

        public static readonly BindableProperty ButtonMarginProperty = BindableProperty.Create("ButtonMargin", typeof(Thickness), typeof(UC_STOP_Button));

        public Thickness ButtonMargin
        {
            get { return (Thickness)GetValue(ButtonMarginProperty); }
            set { SetValue(ButtonMarginProperty, value); }
        }
        #endregion ButtonMargin

        #region ButtonPadding

        public static readonly BindableProperty ButtonPaddingProperty = BindableProperty.Create("ButtonPadding", typeof(Thickness), typeof(UC_STOP_Button));

        public Thickness ButtonPadding
        {
            get { return (Thickness)GetValue(ButtonPaddingProperty); }
            set { SetValue(ButtonPaddingProperty, value); }
        }

        #endregion ButtonPadding

        #region CornerRadius

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create("CornerRadius", typeof(double), typeof(UC_STOP_Button));

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        #endregion CornerRadius

        #region InnerItemSelected

        public static readonly BindableProperty InnerItemSelectedProperty = BindableProperty.Create("InnerItemSelected", typeof(bool), typeof(UC_STOP_Button)
         );

        public bool InnerItemSelected
        {
            get { return (bool)GetValue(InnerItemSelectedProperty); }
            set { SetValue(InnerItemSelectedProperty, value); }
        }

        #endregion InnerItemSelected

        #region Text

        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(UC_STOP_Button));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion Text

        #region ClickCommand

        public static readonly BindableProperty ClickCommandProperty = BindableProperty.Create("ClickCommand", typeof(RelayCommand), typeof(UC_STOP_Button)
            );


        public RelayCommand ClickCommand
        {
            get { return (RelayCommand)GetValue(ClickCommandProperty); }
            set { SetValue(ClickCommandProperty, value); }
        }

        #endregion ClickCommand

        #region ClickCommandParameter

        public static readonly BindableProperty ClickCommandParameterProperty = BindableProperty.Create("ClickCommandParameter", typeof(object), typeof(UC_STOP_Button)
            );

        public object ClickCommandParameter
        {
            get { return (object)GetValue(ClickCommandParameterProperty); }
            set { SetValue(ClickCommandParameterProperty, value); }
        }

        #endregion ClickCommandParameter

        #endregion BindableProperty

        public UC_STOP_Button ()
		{
			InitializeComponent ();
		}
	}
}