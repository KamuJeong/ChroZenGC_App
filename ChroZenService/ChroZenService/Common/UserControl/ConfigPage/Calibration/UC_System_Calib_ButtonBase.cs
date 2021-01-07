using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{
    public class UC_System_Calib_ButtonBase : ContentView
    {
        #region BindableProperty

        #region IsStarted

        public static readonly BindableProperty IsStartedProperty = BindableProperty.Create("IsStarted", typeof(bool), typeof(UC_System_Calib_ButtonBase),
  defaultValue: false);

        public bool IsStarted
        {
            get { return (bool)GetValue(IsStartedProperty); }
            set { SetValue(IsStartedProperty, value); }
        }

        #endregion IsStarted

        #region IconMargin

        public static readonly BindableProperty IconMarginProperty = BindableProperty.Create("IconMargin", typeof(Thickness), typeof(UC_System_Calib_ButtonBase),
  propertyChanged: onIconMarginPropertyChanged,
  defaultValue: new Thickness(0, 0, 0, -6));

        public Thickness IconMargin
        {
            get { return (Thickness)GetValue(IconMarginProperty); }
            set { SetValue(IconMarginProperty, value); }
        }

        private static void onIconMarginPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderIcon).IconMargin = (Thickness)newValue;
            //}
        }

        #endregion IconMargin

        #region LabelMargin

        public static readonly BindableProperty LabelMarginProperty = BindableProperty.Create("LabelMargin", typeof(Thickness), typeof(UC_System_Calib_ButtonBase),
  propertyChanged: onLabelMarginPropertyChanged,
  defaultValue: new Thickness(-10, 1, 0, 0));

        public Thickness LabelMargin
        {
            get { return (Thickness)GetValue(LabelMarginProperty); }
            set { SetValue(LabelMarginProperty, value); }
        }

        private static void onLabelMarginPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderLabel).LabelMargin = (Thickness)newValue;
            //}
        }

        #endregion LabelMargin

        #region IsSmall

        public static readonly BindableProperty IsSmallProperty = BindableProperty.Create("IsSmall", typeof(bool), typeof(UC_System_Calib_ButtonBase),
  defaultValue: false);

        public bool IsSmall
        {
            get { return (bool)GetValue(IsSmallProperty); }
            set { SetValue(IsSmallProperty, value); }
        }

        #endregion IsSmall

        #region IsToggleButton

        public static readonly BindableProperty IsToggleButtonProperty = BindableProperty.Create("IsToggleButton", typeof(bool), typeof(UC_System_Calib_ButtonBase),
  propertyChanged: onIsToggleButtonPropertyChanged);

        public bool IsToggleButton
        {
            get { return (bool)GetValue(IsToggleButtonProperty); }
            set { SetValue(IsToggleButtonProperty, value); }
        }

        private static void onIsToggleButtonPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

        }

        #endregion IsToggleButton

        #region IsToggled

        public static readonly BindableProperty IsToggledProperty = BindableProperty.Create("IsToggled", typeof(bool), typeof(UC_System_Calib_ButtonBase),
  propertyChanged: onIsToggledPropertyChanged);

        public bool IsToggled
        {
            get { return (bool)GetValue(IsToggledProperty); }
            set { SetValue(IsToggledProperty, value); }
        }

        private static void onIsToggledPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

        }

        #endregion IsToggled

        #region ImgSource

        public static readonly BindableProperty ImgSourceProperty = BindableProperty.Create("ImgSource", typeof(ImageSource), typeof(UC_System_Calib_ButtonBase),
  propertyChanged: onImgSourcePropertyChanged);

        public ImageSource ImgSource
        {
            get { return (ImageSource)GetValue(ImgSourceProperty); }
            set { SetValue(ImgSourceProperty, value); }
        }

        private static void onImgSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

        }

        #endregion ImgSource

        #region ButtonWidth

        public static readonly BindableProperty ButtonWidthProperty = BindableProperty.Create("ButtonWidth", typeof(double), typeof(UC_System_Calib_ButtonBase));

        public double ButtonWidth
        {
            get { return (double)GetValue(ButtonWidthProperty); }
            set { SetValue(ButtonWidthProperty, value); }
        }

        #endregion ButtonWidth

        #region ButtonHeight

        public static readonly BindableProperty ButtonHeightProperty = BindableProperty.Create("ButtonHeight", typeof(double), typeof(UC_System_Calib_ButtonBase),
  propertyChanged: onButtonHeightPropertyChanged);

        public double ButtonHeight
        {
            get { return (double)GetValue(ButtonHeightProperty); }
            set { SetValue(ButtonHeightProperty, value); }
        }

        private static void onButtonHeightPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).ButtonHeight = (double)newValue;
            //}
        }

        #endregion ButtonHeight

        #region ButtonMargin

        public static readonly BindableProperty ButtonMarginProperty = BindableProperty.Create("ButtonMargin", typeof(Thickness), typeof(UC_System_Calib_ButtonBase),
  propertyChanged: onButtonMarginPropertyChanged);

        public Thickness ButtonMargin
        {
            get { return (Thickness)GetValue(ButtonMarginProperty); }
            set { SetValue(ButtonMarginProperty, value); }
        }

        private static void onButtonMarginPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).ButtonMargin = (Thickness)newValue;
            //}
        }

        #endregion ButtonMargin

        #region InnerMargin

        public static readonly BindableProperty InnerMarginProperty = BindableProperty.Create("InnerMargin", typeof(Thickness), typeof(UC_System_Calib_ButtonBase),
  propertyChanged: onInnerMarginPropertyChanged);

        public Thickness InnerMargin
        {
            get { return (Thickness)GetValue(InnerMarginProperty); }
            set { SetValue(InnerMarginProperty, value); }
        }

        private static void onInnerMarginPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).InnerMargin = (Thickness)newValue;
            //}
        }

        #endregion InnerMargin

        #region ButtonPadding

        public static readonly BindableProperty ButtonPaddingProperty = BindableProperty.Create("ButtonPadding", typeof(Thickness), typeof(UC_System_Calib_ButtonBase),
  propertyChanged: onButtonPaddingPropertyChanged);

        public Thickness ButtonPadding
        {
            get { return (Thickness)GetValue(ButtonPaddingProperty); }
            set { SetValue(ButtonPaddingProperty, value); }
        }

        private static void onButtonPaddingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).ButtonPadding = (Thickness)newValue;
            //}
        }

        #endregion ButtonPadding

        #region CornerRadius

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create("CornerRadius", typeof(double), typeof(UC_System_Calib_ButtonBase),
          propertyChanged: onCornerRadiusPropertyChanged);

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        private static void onCornerRadiusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).CornerRadius = (double)newValue;
            //}
        }

        #endregion CornerRadius

        #region InnerItemSelected

        public static readonly BindableProperty InnerItemSelectedProperty = BindableProperty.Create("InnerItemSelected", typeof(bool), typeof(UC_System_Calib_ButtonBase)
         );

        public bool InnerItemSelected
        {
            get { return (bool)GetValue(InnerItemSelectedProperty); }
            set { SetValue(InnerItemSelectedProperty, value); }
        }

        #endregion InnerItemSelected

        #region Text

        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(UC_System_Calib_ButtonBase));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private static void onTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).Text = (string)newValue;
            //}
        }

        #endregion Text

        #region ClickCommand

        public static readonly BindableProperty ClickCommandProperty = BindableProperty.Create("ClickCommand", typeof(RelayCommand), typeof(UC_System_Calib_ButtonBase)
            );


        public RelayCommand ClickCommand
        {
            get { return (RelayCommand)GetValue(ClickCommandProperty); }
            set { SetValue(ClickCommandProperty, value); }
        }

        private static void onClickCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).ClickCommand = (RelayCommand)newValue;
            //}
        }

        #endregion ClickCommand

        #region ClickCommandParameter

        public static readonly BindableProperty ClickCommandParameterProperty = BindableProperty.Create("ClickCommandParameter", typeof(object), typeof(UC_System_Calib_ButtonBase)
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

        #endregion BindableProperty
    }
}
