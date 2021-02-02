using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChroZenService
{
    public class UC_Config_UnderLine_ButtonBase : ContentView
    {
        #region BindableProperty

        #region Text

        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(UC_Config_UnderLine_ButtonBase));

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

        #region UnitText

        public static readonly BindableProperty UnitTextProperty = BindableProperty.Create("UnitText", typeof(string), typeof(UC_Config_UnderLine_ButtonBase));

        public string UnitText
        {
            get { return (string)GetValue(UnitTextProperty); }
            set { SetValue(UnitTextProperty, value); }
        }

        private static void onUnitTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //if (newValue != null)
            //{
            //    (bindable as UC_TabHeaderButton).UnitText = (string)newValue;
            //}
        }

        #endregion UnitText

        #region ClickCommand

        public static readonly BindableProperty ClickCommandProperty = BindableProperty.Create("ClickCommand", typeof(RelayCommand), typeof(UC_Config_UnderLine_ButtonBase)
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

        public static readonly BindableProperty ClickCommandParameterProperty = BindableProperty.Create("ClickCommandParameter", typeof(object), typeof(UC_Config_UnderLine_ButtonBase)
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
