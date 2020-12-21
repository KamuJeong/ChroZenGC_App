using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChroZenService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UC_TabHeaderButton : ContentView
    {
        #region BindableProperty

        #region ButtonWidth

        public static readonly BindableProperty ButtonWidthProperty = BindableProperty.Create("ButtonWidth", typeof(double), typeof(UC_TabHeaderButton),
  propertyChanged: onButtonWidthPropertyChanged);

        public double ButtonWidth
        {
            get { return (double)GetValue(ButtonWidthProperty); }
            set { SetValue(ButtonWidthProperty, value); }
        }

        private static void onButtonWidthPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as UC_TabHeaderButton).ButtonWidth = (double)newValue;
            }
        }

        #endregion ButtonWidth

        #region ButtonHeight

        public static readonly BindableProperty ButtonHeightProperty = BindableProperty.Create("ButtonHeight", typeof(double), typeof(UC_TabHeaderButton),
  propertyChanged: onButtonHeightPropertyChanged);

        public double ButtonHeight
        {
            get { return (double)GetValue(ButtonHeightProperty); }
            set { SetValue(ButtonHeightProperty, value); }
        }

        private static void onButtonHeightPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as UC_TabHeaderButton).ButtonHeight = (double)newValue;
            }
        }

        #endregion ButtonHeight

        #region ButtonMargin

        public static readonly BindableProperty ButtonMarginProperty = BindableProperty.Create("ButtonMargin", typeof(Thickness), typeof(UC_TabHeaderButton),
  propertyChanged: onButtonMarginPropertyChanged);

        public Thickness ButtonMargin
        {
            get { return (Thickness)GetValue(ButtonMarginProperty); }
            set { SetValue(ButtonMarginProperty, value); }
        }

        private static void onButtonMarginPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as UC_TabHeaderButton).ButtonMargin = (Thickness)newValue;
            }
        }

        #endregion ButtonMargin

        #region ButtonPadding

        public static readonly BindableProperty ButtonPaddingProperty = BindableProperty.Create("ButtonPadding", typeof(Thickness), typeof(UC_TabHeaderButton),
  propertyChanged: onButtonPaddingPropertyChanged);

        public Thickness ButtonPadding
        {
            get { return (Thickness)GetValue(ButtonPaddingProperty); }
            set { SetValue(ButtonPaddingProperty, value); }
        }

        private static void onButtonPaddingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as UC_TabHeaderButton).ButtonPadding = (Thickness)newValue;
            }
        }

        #endregion ButtonPadding

        #region CornerRadius

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create("CornerRadius", typeof(double), typeof(UC_TabHeaderButton),
          propertyChanged: onCornerRadiusPropertyChanged);

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        private static void onCornerRadiusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as UC_TabHeaderButton).CornerRadius = (double)newValue;
            }
        }

        #endregion CornerRadius

        #region InnerItemSelected

        public static readonly BindableProperty InnerItemSelectedProperty = BindableProperty.Create("InnerItemSelected", typeof(bool), typeof(UC_TabHeaderButton)
         );

        public bool InnerItemSelected
        {
            get { return (bool)GetValue(InnerItemSelectedProperty); }
            set { SetValue(InnerItemSelectedProperty, value); }
        }
        
        #endregion InnerItemSelected

        #region Text

        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(UC_TabHeaderButton));       

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private static void onTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as UC_TabHeaderButton).Text = (string)newValue;
            }
        }

        #endregion Text

        #region ClickCommand

        public static readonly BindableProperty ClickCommandProperty = BindableProperty.Create("ClickCommand", typeof(RelayCommand), typeof(UC_TabHeaderButton)
            );


        public RelayCommand ClickCommand
        {
            get { return (RelayCommand)GetValue(ClickCommandProperty); }
            set { SetValue(ClickCommandProperty, value); }
        }

        private static void onClickCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as UC_TabHeaderButton).ClickCommand = (RelayCommand)newValue;
            }
        }

        #endregion ClickCommand

        #region ClickCommandParameter

        public static readonly BindableProperty ClickCommandParameterProperty = BindableProperty.Create("ClickCommandParameter", typeof(object), typeof(UC_TabHeaderButton)
            );

        public object ClickCommandParameter
        {
            get { return (object)GetValue(ClickCommandParameterProperty); }
            set { SetValue(ClickCommandParameterProperty, value); }
        }

        private static void onClickCommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as UC_TabHeaderButton).ClickCommandParameter = newValue;
            }
        }

        #endregion ClickCommandParameter

        #endregion BindableProperty

        public UC_TabHeaderButton()
        {
            InitializeComponent();
        }
    }
}