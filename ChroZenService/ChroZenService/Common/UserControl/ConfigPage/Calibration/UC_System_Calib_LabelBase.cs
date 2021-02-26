using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{
    public class UC_System_Calib_LabelBase : ContentView
    {

        #region CornerRadius

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create("CornerRadius", typeof(double), typeof(UC_System_Calib_LabelBase));

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        #endregion CornerRadius

        #region Text

        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(UC_System_Calib_LabelBase));

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

        #region TextColor

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(UC_System_Calib_LabelBase));

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        private static void onTextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).TextColor = (string)newValue;
            //}
        }

        #endregion TextColor

        #region FontSize

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize", typeof(double), typeof(UC_System_Calib_LabelBase));

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        private static void onFontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).FontSize = (string)newValue;
            //}
        }

        #endregion FontSize

        #region TapGestureCommand

        public static readonly BindableProperty TapGestureCommandProperty = BindableProperty.Create("TapGestureCommand", typeof(RelayCommand), typeof(UC_System_Calib_LabelBase));

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

        #endregion TapGestureCommand

        #region TapGestureCommandParameter

        public static readonly BindableProperty TapGestureCommandParameterProperty = BindableProperty.Create("TapGestureCommandParameter", typeof(object), typeof(UC_System_Calib_LabelBase));

        public object TapGestureCommandParameter
        {
            get { return (object)GetValue(TapGestureCommandParameterProperty); }
            set { SetValue(TapGestureCommandParameterProperty, value); }
        }

        #endregion TapGestureCommandParameter
    }
}
